// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.ProfitLossSummaryWork
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary
{
  public class ProfitLossSummaryWork : TProfitLossSummary<ProfitLossSummaryWork>
  {
    private DateTime? _WorkOriginDate;
    private int _pls_YyyyMmBefore;
    private string _WorkStoreCodeIn;
    private string _si_StoreName;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private Action<string> _CallBackMessage;

    public DateTime? WorkOriginDate
    {
      get => this._WorkOriginDate;
      set
      {
        this._WorkOriginDate = value;
        this.Changed(nameof (WorkOriginDate));
        if (this._WorkOriginDate.HasValue)
        {
          DateTime dateTime = this._WorkOriginDate.Value;
          int num = dateTime.Year * 100;
          dateTime = this._WorkOriginDate.Value;
          int month = dateTime.Month;
          this.pls_YyyyMm = num + month;
          DateTime dateAdd = this._WorkOriginDate.Value.ToFirstDateOfMonth().GetDateAdd(0, 0, -1);
          this.pls_YyyyMmBefore = dateAdd.Year * 100 + dateAdd.Month;
        }
        this.Changed("WorkFirstDay");
        this.Changed("WorkLastDay");
      }
    }

    public DateTime? WorkFirstDay => this.WorkOriginDate.HasValue ? new DateTime?(this.WorkOriginDate.Value.ToFirstDateOfMonth()) : new DateTime?();

    public DateTime? WorkLastDay => this.WorkOriginDate.HasValue ? new DateTime?(this.WorkOriginDate.Value.ToLastDateOfMonth()) : new DateTime?();

    public int pls_YyyyMmBefore
    {
      get => this._pls_YyyyMmBefore;
      set
      {
        this._pls_YyyyMmBefore = value;
        this.Changed(nameof (pls_YyyyMmBefore));
      }
    }

    public string WorkStoreCodeIn
    {
      get => this._WorkStoreCodeIn;
      set
      {
        this._WorkStoreCodeIn = value;
        this.Changed(nameof (WorkStoreCodeIn));
      }
    }

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gd_BarCode
    {
      get => this._gd_BarCode;
      set
      {
        this._gd_BarCode = value;
        this.Changed(nameof (gd_BarCode));
      }
    }

    public ProfitLossSummaryWork()
    {
    }

    public ProfitLossSummaryWork(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.WorkOriginDate = new DateTime?();
      this.pls_YyyyMmBefore = 0;
      this.WorkStoreCodeIn = (string) null;
      this.si_StoreName = this.gd_GoodsName = this.gd_BarCode = string.Empty;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pls_SiteID == 0L)
      {
        this.message = "싸이트(pls_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_YyyyMm == 0)
      {
        this.message = "년월(pls_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_StoreCode == 0 && string.IsNullOrEmpty(this.WorkStoreCodeIn))
      {
        this.message = "지점코드(pls_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.WorkOriginDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "작업 기준일자(WorkOriginDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    public override async Task<bool> DataClearAsync(Hashtable p_param)
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      // ISSUE: reference to a compiler-generated method
      profitLossSummaryWork.\u003C\u003En__0();
      if (p_param == null || p_param.Count == 0)
      {
        if (p_param == null)
          p_param = new Hashtable();
        p_param.Add((object) "pls_SiteID", (object) profitLossSummaryWork.pls_SiteID);
        p_param.Add((object) "pls_YyyyMm", (object) profitLossSummaryWork.pls_YyyyMm);
        if (string.IsNullOrEmpty(profitLossSummaryWork.WorkStoreCodeIn))
          p_param.Add((object) "pls_StoreCode", (object) profitLossSummaryWork.pls_StoreCode);
        else
          p_param.Add((object) "pls_StoreCode_IN_", (object) profitLossSummaryWork.WorkStoreCodeIn);
      }
      if (await profitLossSummaryWork.OleDB.ExecuteAsync(profitLossSummaryWork.DataClearQuery(p_param)))
        return true;
      profitLossSummaryWork.message = " " + profitLossSummaryWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) profitLossSummaryWork.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) profitLossSummaryWork.pls_YyyyMm, (object) profitLossSummaryWork.pls_StoreCode, (object) profitLossSummaryWork.pls_GoodsCode, (object) profitLossSummaryWork.pls_SiteID) + " 내용 : " + profitLossSummaryWork.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(profitLossSummaryWork.message);
      return false;
    }

    public override bool ItemSave()
    {
      try
      {
        if (this.db_status == 0)
        {
          if (!this.Insert())
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        }
        else if (this.db_status > 0 && !this.Update((UbModelBase) null))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override async Task<bool> ItemSaveAsync()
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      try
      {
        if (profitLossSummaryWork.db_status == 0)
        {
          if (!await profitLossSummaryWork.InsertAsync())
            throw new UniServiceException(profitLossSummaryWork.message, profitLossSummaryWork.TableCode.ToDescription() + " 등록 오류");
        }
        else if (profitLossSummaryWork.db_status > 0)
        {
          if (!await profitLossSummaryWork.UpdateAsync((UbModelBase) null))
            throw new UniServiceException(profitLossSummaryWork.message, profitLossSummaryWork.TableCode.ToDescription() + " 등록 오류");
        }
        return true;
      }
      catch (Exception ex)
      {
        profitLossSummaryWork.message = " " + profitLossSummaryWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(profitLossSummaryWork.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      JobEvtProfitWork pData)
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      bool isMessage = profitLossSummaryWork._CallBackMessage != null && pJobInfo != null;
      try
      {
        if (isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage1 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage1.SiteID = pJobInfo.SiteID;
          jobEvtMessage1.Id = pJobInfo.Id;
          jobEvtMessage1.JobId = pJobInfo.JobId;
          jobEvtMessage1.Msg = profitLossSummaryWork.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.";
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage2 = jobEvtMessage1;
          profitLossSummaryWork._CallBackMessage(jobEvtMessage2.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        else
          Log.Logger.DebugColor(profitLossSummaryWork.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<ProfitLossSummaryWork> list = await profitLossSummaryWork.SelectListAsync();
        if (list == null)
          throw new Exception("조회에러.\n" + profitLossSummaryWork.message);
        if (pData.WorkInfo.WorkData.plwc_AmountWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_QtyWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_WeightWorkCnt > 0)
        {
          if (pData.WorkInfo.WorkData.plwc_AmountWorkCnt > 0)
            await profitLossSummaryWork.StatementStockUnitAmountAsync(profitLossSummaryWork.OleDB, pData);
          if (pData.WorkInfo.WorkData.plwc_QtyWorkCnt > 0)
            await profitLossSummaryWork.StatementStockUnitQtyAsync(profitLossSummaryWork.OleDB, pData);
          int plwcWeightWorkCnt = pData.WorkInfo.WorkData.plwc_WeightWorkCnt;
        }
        await profitLossSummaryWork.ProfitLossWorkLogAsync(profitLossSummaryWork.OleDB, pData);
        if (isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage3 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage3.SiteID = pJobInfo.SiteID;
          jobEvtMessage3.Id = pJobInfo.Id;
          jobEvtMessage3.JobId = pJobInfo.JobId;
          jobEvtMessage3.Msg = profitLossSummaryWork.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 해당 데이터 CLEAR 중 잠시만 ......";
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage4 = jobEvtMessage3;
          profitLossSummaryWork._CallBackMessage(jobEvtMessage4.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        else
          Log.Logger.DebugColor(profitLossSummaryWork.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 해당 데이터 CLEAR 중 잠시만 ......");
        if (!await profitLossSummaryWork.DataClearAsync((Hashtable) null))
          throw new Exception("작업 취소 처리.\n" + profitLossSummaryWork.message);
        int total = list.Count;
        int count = 0;
        int viewPro = 0;
        foreach (ProfitLossSummaryWork item in (IEnumerable<ProfitLossSummaryWork>) list)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          item.SetAdoDatabase(profitLossSummaryWork.OleDB);
          if (item.pls_SiteID == 0L)
            item.pls_SiteID = profitLossSummaryWork.pls_SiteID;
          item.CalcEndQty();
          if (item.pls_IsStockUnitAmount)
          {
            if (!item.pls_AdjustCostAmt.IsZero())
            {
              item.pls_EndCostAmt = item.pls_AdjustCostAmt;
              if (!item.pls_AdjustQty.IsZero())
                item.pls_EndQty = item.pls_AdjustQty;
              else if (item.pls_EndCostAmt > 0.0)
                item.pls_EndQty = 1.0;
              else if (item.pls_EndCostAmt < 0.0)
                item.pls_EndQty = -1.0;
              else
                item.pls_EndQty = 0.0;
            }
            else
            {
              item.pls_EndCostAmt = 0.0;
              item.pls_EndQty = 0.0;
            }
            if (!item.pls_AdjustPriceAmt.IsZero())
              item.pls_EndPriceAmt = item.pls_AdjustPriceAmt;
            else
              item.pls_EndPriceAmt = 0.0;
            item.pls_AdjustQty = 0.0;
            item.pls_AdjustCostAmt = 0.0;
            item.pls_AdjustPriceAmt = 0.0;
            item.pls_AdjustPriceCostSumAmt = 0.0;
            if (item.pls_EndCostAmt.IsZero() && item.pls_EndPriceAmt.IsZero())
              item.pls_EndQty = 0.0;
          }
          else
          {
            if (((item.pls_BaseAvgCost.IsZero() ? 0.0 : item.pls_BaseQty) + item.pls_BuyQty + item.pls_InnerMoveInQty + item.pls_OuterMoveInQty).IsZero())
              item.pls_EndAvgCost = 0.0;
            else
              item.pls_EndAvgCost = CalcHelper.ToArgCost3(Math.Abs(item.pls_BaseQty * item.pls_BaseAvgCost) + Math.Abs(item.pls_BuyCostAmt) + Math.Abs(item.pls_InnerMoveInCostAmt) + Math.Abs(item.pls_OuterMoveInCostAmt), Math.Abs(item.pls_BaseAvgCost.IsZero() ? 0.0 : item.pls_BaseQty) + Math.Abs(item.pls_BuyQty) + Math.Abs(item.pls_InnerMoveInQty) + Math.Abs(item.pls_OuterMoveInQty));
            if (!item.pls_AdjustQty.IsZero())
            {
              item.pls_AdjustCostAmt = item.pls_EndAvgCost * item.pls_AdjustQty;
              item.pls_AdjustPriceAmt = item.pls_EndPrice * item.pls_AdjustQty;
              if (item.pls_IsTax)
              {
                item.pls_AdjustCostVatAmt = item.pls_AdjustCostAmt.ToCostVat();
                item.pls_AdjustPriceVatAmt = item.pls_AdjustPriceAmt.ToPriceVat();
              }
              else
              {
                item.pls_AdjustCostVatAmt = 0.0;
                item.pls_AdjustPriceVatAmt = 0.0;
              }
            }
            else
            {
              item.pls_AdjustCostAmt = 0.0;
              item.pls_AdjustCostVatAmt = 0.0;
              item.pls_AdjustPriceVatAmt = 0.0;
              item.pls_AdjustPriceVatAmt = 0.0;
            }
            if (!item.pls_DisuseQty.IsZero())
            {
              item.pls_DisuseCostAmt = item.pls_EndAvgCost * item.pls_DisuseQty;
              item.pls_DisusePriceAmt = item.pls_EndPrice * item.pls_DisuseQty;
              if (item.pls_IsTax)
              {
                item.pls_DisuseCostVatAmt = item.pls_DisuseCostAmt.ToCostVat();
                item.pls_DisusePriceVatAmt = item.pls_DisusePriceAmt.ToPriceVat();
              }
              else
              {
                item.pls_DisuseCostVatAmt = 0.0;
                item.pls_DisusePriceVatAmt = 0.0;
              }
            }
            else
            {
              item.pls_DisuseCostAmt = 0.0;
              item.pls_DisuseCostVatAmt = 0.0;
              item.pls_DisusePriceAmt = 0.0;
              item.pls_DisusePriceVatAmt = 0.0;
            }
            item.pls_EndCostAmt = item.pls_EndAvgCost * item.pls_EndQty;
            item.pls_EndPriceAmt = item.pls_EndPrice * item.pls_EndQty;
            if (item.pls_IsTax)
            {
              item.pls_EndCostVatAmt = item.pls_EndCostAmt.ToCostVat();
              item.pls_EndPriceVatAmt = item.pls_EndPriceAmt.ToCostVat();
            }
            else
            {
              item.pls_EndCostVatAmt = 0.0;
              item.pls_EndPriceVatAmt = 0.0;
            }
            item.CalcEndPriceAmt();
          }
          item.CalcTaxVat();
          item.CalcEndPriceCostAmt();
          item.CalcSaleProfit();
          item.CalcSalePriceProfit();
          item.CalcSalePriceUpDown();
          if (!item.IsZero(EnumZeroCheck.ALL))
          {
            int num1 = await item.ItemSaveAsync() ? 1 : 0;
          }
          ++count;
          int num2 = count * 100 / total;
          if (viewPro != num2)
          {
            viewPro = num2;
            if (isMessage)
            {
              JobEvtProgressing jobEvtProgressing1 = new JobEvtProgressing();
              jobEvtProgressing1.SiteID = pJobInfo.SiteID;
              jobEvtProgressing1.Id = pJobInfo.Id;
              jobEvtProgressing1.JobId = pJobInfo.JobId;
              jobEvtProgressing1.Title = "지점" + item.si_StoreName + " 작업";
              jobEvtProgressing1.Msg = string.Format("[{0}({1})] {2} 작업중 ({3}/{4})", (object) item.gd_GoodsName, (object) item.gd_BarCode, (object) viewPro, (object) count, (object) total);
              jobEvtProgressing1.ProgressValue = (double) viewPro / 100.0;
              JobEvtProgressing jobEvtProgressing2 = jobEvtProgressing1;
              profitLossSummaryWork._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        profitLossSummaryWork.message = " " + profitLossSummaryWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pJobInfo.SiteID;
          jobEvtMessageErr1.Id = pJobInfo.Id;
          jobEvtMessageErr1.JobId = pJobInfo.JobId;
          jobEvtMessageErr1.Msg = profitLossSummaryWork.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + "/n" + ex.Message;
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          profitLossSummaryWork._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(profitLossSummaryWork.message);
      }
      return false;
    }

    private async Task StatementStockUnitDeleteAsync(
      UniOleDatabase pDB,
      JobEvtProfitWork pData,
      EnumStockUnit p_stock_unit)
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      bool isMessage = profitLossSummaryWork._CallBackMessage != null && pData != null;
      try
      {
        Log.Logger.DebugColor("\n재고 전표(" + p_stock_unit.ToDescription() + ") 삭제 작업...");
        Hashtable param = new Hashtable();
        int total = 0;
        int success = 0;
        string[] strArray = pData.WorkInfo.WorkStoreCodeIn.Split(',');
        for (int index = 0; index < strArray.Length; ++index)
        {
          string str = strArray[index];
          param.Clear();
          param.Add((object) "sh_StoreCode", (object) Convert.ToInt32(str));
          param.Add((object) "sh_SiteID", (object) pData.SiteID);
          param.Add((object) "sh_ConfirmDate", (object) pData.WorkInfo.WorkOriginDate.Value);
          param.Add((object) "sh_StatementType", (object) 5);
          param.Add((object) "sh_DeviceType", (object) 6);
          param.Add((object) "sh_ReasonCode", (object) (int) p_stock_unit);
          IList<StatementHeaderView> statementHeaderViewList = await pDB.Create<StatementHeaderView>().SelectListAsync((object) param);
          total += statementHeaderViewList.Count;
          foreach (StatementHeaderView statementHeaderView in (IEnumerable<StatementHeaderView>) statementHeaderViewList)
          {
            statementHeaderView.sh_ConfirmStatus = 3;
            statementHeaderView.DB_STATUS = EnumDBStatus.UPDATE;
            if (await statementHeaderView.UpdateDataAsync(pDB, pData.EmployeeInfo, true))
              ++success;
          }
        }
        strArray = (string[]) null;
        if (total > 0)
        {
          if (isMessage)
          {
            UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage1 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
            jobEvtMessage1.SiteID = pData.SiteID;
            jobEvtMessage1.Id = pData.Id;
            jobEvtMessage1.JobId = pData.JobId;
            jobEvtMessage1.Msg = string.Format("= {0}/{1} 건 자동({2}) 삭제 완료.", (object) success, (object) total, (object) p_stock_unit.ToDescription());
            UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage2 = jobEvtMessage1;
            profitLossSummaryWork._CallBackMessage(jobEvtMessage2.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
          }
          else
            Log.Logger.DebugColor(profitLossSummaryWork.error_message_format.Replace("[METHOD]", UbModelBase.GetAsyncMethodName(nameof (StatementStockUnitDeleteAsync))).Replace("[REMARK]", string.Format("{0} 재고 전표({1})\n - {2}/{3} 건 자동({4}) 삭제 완료.", (object) pData.resourceDesc, (object) p_stock_unit.ToDescription(), (object) success, (object) total, (object) p_stock_unit.ToDescription())));
        }
        param = (Hashtable) null;
      }
      catch (Exception ex)
      {
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pData.SiteID;
          jobEvtMessageErr1.Id = pData.Id;
          jobEvtMessageErr1.JobId = pData.JobId;
          jobEvtMessageErr1.Msg = ex.Message ?? "";
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          profitLossSummaryWork._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(profitLossSummaryWork.error_message_format.Replace("[METHOD]", UbModelBase.GetAsyncMethodName(nameof (StatementStockUnitDeleteAsync))).Replace("[REMARK]", pData.resourceDesc + " 재고 전표 삭제 실패\nerror = " + ex.Message));
      }
    }

    private async Task StatementStockUnitAmountAsync(UniOleDatabase pDB, JobEvtProfitWork pData)
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      bool isMessage = profitLossSummaryWork._CallBackMessage != null && pData != null;
      try
      {
        await profitLossSummaryWork.StatementStockUnitDeleteAsync(pDB, pData, EnumStockUnit.AMOUNT);
        Log.Logger.DebugColor("\n재고 전표(" + EnumStockUnit.AMOUNT.ToDescription() + ") 생성 작업...");
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "sd_SiteID", (object) pData.SiteID);
        p_param.Add((object) "sh_ConfirmDate", (object) pData.WorkInfo.WorkOriginDate);
        if (pData.WorkInfo.WorkStoreCodeIn.Contains(","))
          p_param.Add((object) "si_StoreCode_IN_", (object) pData.WorkInfo.WorkStoreCodeIn);
        else
          p_param.Add((object) "si_StoreCode", (object) Convert.ToInt32(pData.WorkInfo.WorkStoreCodeIn));
        StatementHeaderView header = (StatementHeaderView) null;
        StatementDetailView detail = pDB.Create<StatementDetailView>();
        IList<StatementDetailView> statementDetailViewList = await detail.AdjustAmountSelectListAsync(p_param);
        if (statementDetailViewList == null)
          throw new Exception("작업 취소 처리.\n" + detail.message);
        foreach (StatementDetailView item in (IEnumerable<StatementDetailView>) statementDetailViewList)
        {
          if (header == null)
          {
            header = pDB.Create<StatementHeaderView>();
            header.sh_StoreCode = item.sh_StoreCode;
            header.sh_ConfirmDate = pData.WorkInfo.WorkOriginDate;
            header.sh_OrderDate = pData.WorkInfo.WorkOriginDate;
            header.sh_OrderStatus = 4;
            header.sh_ConfirmStatus = 1;
            header.sh_Supplier = 1001;
            header.sh_SupplierType = 1;
            header.sh_InOutDiv = 1;
            header.sh_StatementType = 5;
            header.sh_ReasonCode = 1;
            header.sh_DeviceType = 6;
            header.sh_Memo = "재고조사 " + EnumStockUnit.AMOUNT.ToDescription() + " 재고조정 전표";
            header.Lt_Details.Clear();
          }
          else if (header.sh_StoreCode != item.sh_StoreCode)
          {
            header.sh_InDate = new DateTime?(DateTime.Now);
            if (header.Lt_Details.Count > 0)
            {
              if (!await header.InsertDataAsync(pDB, pData.EmployeeInfo, true))
                throw new Exception("작업 취소 처리.\n" + header.message);
              Log.Logger.DebugColor(string.Format("\n신규전표 번호 : {0}", (object) header.sh_StatementNo));
            }
            header.Clear();
            header.sh_StoreCode = item.sh_StoreCode;
            header.sh_ConfirmDate = pData.WorkInfo.WorkOriginDate;
            header.sh_OrderDate = pData.WorkInfo.WorkOriginDate;
            header.sh_OrderStatus = 4;
            header.sh_ConfirmStatus = 1;
            header.sh_Supplier = 1001;
            header.sh_SupplierType = 1;
            header.sh_InOutDiv = 1;
            header.sh_StatementType = 5;
            header.sh_ReasonCode = 1;
            header.sh_DeviceType = 6;
            header.sh_Memo = "재고조사 " + EnumStockUnit.AMOUNT.ToDescription() + " 재고조정 전표";
            header.Lt_Details.Clear();
          }
          item.sd_StatementNo = 0L;
          item.DB_STATUS = EnumDBStatus.NEW;
          header.Lt_Details.Add(item);
        }
        if (header != null && header.Lt_Details.Count > 0)
        {
          header.sh_InDate = new DateTime?(DateTime.Now);
          if (!await header.InsertDataAsync(pDB, pData.EmployeeInfo, true))
            throw new Exception("작업 취소 처리.\n" + header.message);
          Log.Logger.DebugColor(string.Format("\n신규전표 번호 : {0}", (object) header.sh_StatementNo));
        }
        header = (StatementHeaderView) null;
        detail = (StatementDetailView) null;
      }
      catch (Exception ex)
      {
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pData.SiteID;
          jobEvtMessageErr1.Id = pData.Id;
          jobEvtMessageErr1.JobId = pData.JobId;
          jobEvtMessageErr1.Msg = ex.Message ?? "";
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          profitLossSummaryWork._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(profitLossSummaryWork.error_message_format.Replace("[METHOD]", UbModelBase.GetAsyncMethodName(nameof (StatementStockUnitAmountAsync))).Replace("[REMARK]", pData.resourceDesc + " 재고 전표(" + EnumStockUnit.AMOUNT.ToDescription() + ") 작업 실패\nerror = " + ex.Message));
      }
    }

    private async Task StatementStockUnitQtyAsync(UniOleDatabase pDB, JobEvtProfitWork pData)
    {
      ProfitLossSummaryWork profitLossSummaryWork = this;
      bool isMessage = profitLossSummaryWork._CallBackMessage != null && pData != null;
      try
      {
        await profitLossSummaryWork.StatementStockUnitDeleteAsync(pDB, pData, EnumStockUnit.QTY);
        Log.Logger.DebugColor("\n재고 전표(" + EnumStockUnit.QTY.ToDescription() + ") 생성 작업...");
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "sd_SiteID", (object) pData.SiteID);
        p_param.Add((object) "sh_ConfirmDate", (object) pData.WorkInfo.WorkOriginDate);
        if (pData.WorkInfo.WorkStoreCodeIn.Contains(","))
          p_param.Add((object) "si_StoreCode_IN_", (object) pData.WorkInfo.WorkStoreCodeIn);
        else
          p_param.Add((object) "si_StoreCode", (object) Convert.ToInt32(pData.WorkInfo.WorkStoreCodeIn));
        StatementHeaderView header = (StatementHeaderView) null;
        IAsyncEnumerator<StatementDetailView> asyncEnumerator = pDB.Create<StatementDetailView>().AdjustQtySelectEnumerableAsync(p_param).GetAsyncEnumerator();
        try
        {
          while (true)
          {
            if (await asyncEnumerator.MoveNextAsync())
            {
              StatementDetailView item = asyncEnumerator.Current;
              if (header == null)
              {
                header = pDB.Create<StatementHeaderView>();
                header.sh_StoreCode = item.sh_StoreCode;
                header.sh_ConfirmDate = pData.WorkInfo.WorkOriginDate;
                header.sh_OrderDate = pData.WorkInfo.WorkOriginDate;
                header.sh_OrderStatus = 4;
                header.sh_ConfirmStatus = 1;
                header.sh_Supplier = 1001;
                header.sh_SupplierType = 1;
                header.sh_InOutDiv = 1;
                header.sh_StatementType = 5;
                header.sh_ReasonCode = 2;
                header.sh_DeviceType = 6;
                header.sh_Memo = "재고조사 " + EnumStockUnit.QTY.ToDescription() + " 재고조정 전표";
                header.Lt_Details.Clear();
              }
              else if (header.sh_StoreCode != item.sh_StoreCode)
              {
                header.sh_InDate = new DateTime?(DateTime.Now);
                if (header.Lt_Details.Count > 0)
                {
                  if (await header.InsertDataAsync(pDB, pData.EmployeeInfo, true))
                    Log.Logger.DebugColor(string.Format("\n신규전표 번호 : {0}", (object) header.sh_StatementNo));
                  else
                    break;
                }
                header.Clear();
                header.sh_StoreCode = item.sh_StoreCode;
                header.sh_ConfirmDate = pData.WorkInfo.WorkOriginDate;
                header.sh_OrderDate = pData.WorkInfo.WorkOriginDate;
                header.sh_OrderStatus = 4;
                header.sh_ConfirmStatus = 1;
                header.sh_Supplier = 1001;
                header.sh_SupplierType = 1;
                header.sh_InOutDiv = 1;
                header.sh_StatementType = 5;
                header.sh_ReasonCode = 2;
                header.sh_DeviceType = 6;
                header.sh_Memo = "재고조사 " + EnumStockUnit.QTY.ToDescription() + " 재고조정 전표";
                header.Lt_Details.Clear();
              }
              item.sd_StatementNo = 0L;
              item.DB_STATUS = EnumDBStatus.NEW;
              if (!item.gdh_EventPrice.IsZero())
                item.sd_PriceGoods = item.gdh_EventPrice;
              else if (!item.gdh_SalePrice.IsZero())
                item.sd_PriceGoods = item.gdh_SalePrice;
              item.CalcSum();
              header.Lt_Details.Add(item);
              item = (StatementDetailView) null;
            }
            else
              goto label_24;
          }
          throw new Exception("작업 취소 처리.\n" + header.message);
        }
        finally
        {
label_24:
          if (asyncEnumerator != null)
            await asyncEnumerator.DisposeAsync();
        }
        asyncEnumerator = (IAsyncEnumerator<StatementDetailView>) null;
        if (header != null && header.Lt_Details.Count > 0)
        {
          header.sh_InDate = new DateTime?(DateTime.Now);
          if (!await header.InsertDataAsync(pDB, pData.EmployeeInfo, true))
            throw new Exception("작업 취소 처리.\n" + header.message);
          Log.Logger.DebugColor(string.Format("\n신규전표 번호 : {0}", (object) header.sh_StatementNo));
        }
        header = (StatementHeaderView) null;
      }
      catch (Exception ex)
      {
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pData.SiteID;
          jobEvtMessageErr1.Id = pData.Id;
          jobEvtMessageErr1.JobId = pData.JobId;
          jobEvtMessageErr1.Msg = ex.Message ?? "";
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          profitLossSummaryWork._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(profitLossSummaryWork.error_message_format.Replace("[METHOD]", UbModelBase.GetAsyncMethodName(nameof (StatementStockUnitQtyAsync))).Replace("[REMARK]", pData.resourceDesc + " 재고 전표(" + EnumStockUnit.QTY.ToDescription() + ") 작업 실패\nerror = " + ex.Message));
      }
      finally
      {
        await Task.CompletedTask;
      }
    }

    private async Task ProfitLossWorkLogAsync(UniOleDatabase pDB, JobEvtProfitWork pData)
    {
      Log.Logger.DebugColor("\n수불 작업 로그 남기기...");
      int yyyyMm = pData.WorkInfo.WorkOriginDate.Value.Year * 100 + pData.WorkInfo.WorkOriginDate.Value.Month;
      string[] strArray = pData.WorkInfo.WorkStoreCodeIn.Split(',');
      for (int index = 0; index < strArray.Length; ++index)
      {
        string storeCode = strArray[index];
        ProfitLossWorkCntView data = await pDB.Create<ProfitLossWorkCntView>().SelectOneAsync(yyyyMm, Convert.ToInt32(storeCode), pData.SiteID);
        if (data == null || data.plwc_YyyyMm == 0)
        {
          if (data == null)
            data = pDB.Create<ProfitLossWorkCntView>();
          data.plwc_YyyyMm = yyyyMm;
          data.plwc_StoreCode = Convert.ToInt32(storeCode);
          data.plwc_SiteID = pData.SiteID;
          data.DB_STATUS = EnumDBStatus.NEW;
        }
        else
          data.DB_STATUS = EnumDBStatus.UPDATE;
        data.plwc_OriginDate = pData.WorkInfo.WorkOriginDate;
        data.plwc_WorkCnt = 1;
        data.plwc_WorkDate = new DateTime?(DateTime.Now);
        data.plwc_WorkEmployee = pData.EmployeeInfo.emp_Code;
        if (pData.WorkInfo.WorkData.plwc_AmountWorkCnt > 0)
        {
          data.plwc_AmountWorkCnt = 1;
          data.plwc_AmountWorkDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_AmountWorkCnt = 0;
          data.plwc_AmountWorkDate = new DateTime?();
        }
        if (pData.WorkInfo.WorkData.plwc_QtyWorkCnt > 0)
        {
          data.plwc_QtyWorkCnt = 1;
          data.plwc_QtyWorkDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_QtyWorkCnt = 0;
          data.plwc_QtyWorkDate = new DateTime?();
        }
        if (pData.WorkInfo.WorkData.plwc_WeightWorkCnt > 0)
        {
          data.plwc_WeightWorkCnt = 1;
          data.plwc_WeightWorkDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_WeightWorkCnt = 0;
          data.plwc_WeightWorkDate = new DateTime?();
        }
        if (pData.WorkInfo.WorkData.plwc_MinusToZeroWorkCnt > 0)
        {
          data.plwc_MinusToZeroWorkCnt = 1;
          data.plwc_MinusToZeroWorkDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_MinusToZeroWorkCnt = 0;
          data.plwc_MinusToZeroWorkDate = new DateTime?();
        }
        if (pData.WorkInfo.WorkData.plwc_PoorToZeroWorkCnt > 0)
        {
          data.plwc_PoorToZeroWorkCnt = 1;
          data.plwc_PoorToZeroWorkDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_PoorToZeroWorkCnt = 0;
          data.plwc_PoorToZeroWorkDate = new DateTime?();
        }
        if (pData.WorkInfo.WorkData.plwc_AmountWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_QtyWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_WeightWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_MinusToZeroWorkCnt > 0 || pData.WorkInfo.WorkData.plwc_PoorToZeroWorkCnt > 0)
        {
          data.plwc_ApplyCnt = 1;
          data.plwc_ApplyDate = pData.WorkInfo.WorkOriginDate;
        }
        else
        {
          data.plwc_ApplyCnt = 0;
          data.plwc_ApplyDate = new DateTime?();
        }
        if (data.IsUpdate)
        {
          if (!await data.UpdateDataAsync(pDB, pData.EmployeeInfo, false))
            throw new UniServiceException(data.message, data.TableCode.ToDescription() + " 변경 오류");
        }
        else if (data.IsNew)
        {
          if (!await data.InsertDataAsync(pDB, pData.EmployeeInfo, false))
            throw new UniServiceException(data.message, data.TableCode.ToDescription() + " 변경 오류");
        }
        data = (ProfitLossWorkCntView) null;
        storeCode = (string) null;
      }
      strArray = (string[]) null;
    }

    public async Task<IList<ProfitLossSummaryWork>> SelectListAsync()
    {
      ProfitLossSummaryWork profitLossSummaryWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(profitLossSummaryWork1.OleDB.ConnectionUrl, pCommandTimeout: 180);
        rs = new UniOleDbRecordset(db, profitLossSummaryWork1.OleDB.CommandTimeout);
        if (profitLossSummaryWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + profitLossSummaryWork1.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(profitLossSummaryWork1.message);
        }
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "pls_SiteID", (object) profitLossSummaryWork1.pls_SiteID);
        p_param.Add((object) "pls_YyyyMm", (object) profitLossSummaryWork1.pls_YyyyMm);
        if (string.IsNullOrEmpty(profitLossSummaryWork1.WorkStoreCodeIn))
          p_param.Add((object) "pls_StoreCode", (object) profitLossSummaryWork1.pls_StoreCode);
        else
          p_param.Add((object) "pls_StoreCode_IN_", (object) profitLossSummaryWork1.WorkStoreCodeIn);
        p_param.Add((object) "WorkOriginDate", (object) profitLossSummaryWork1.WorkOriginDate.Value);
        p_param.Add((object) "pls_YyyyMmBefore", (object) profitLossSummaryWork1.pls_YyyyMmBefore);
        if (!await rs.OpenAsync(profitLossSummaryWork1.GetSelectQuery((object) p_param)))
        {
          profitLossSummaryWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryWork>) null;
        }
        IList<ProfitLossSummaryWork> lt_list = (IList<ProfitLossSummaryWork>) new List<ProfitLossSummaryWork>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryWork profitLossSummaryWork2 = profitLossSummaryWork1.OleDB.Create<ProfitLossSummaryWork>();
            if (profitLossSummaryWork2.GetFieldValues(rs))
            {
              profitLossSummaryWork2.row_number = lt_list.Count + 1;
              lt_list.Add(profitLossSummaryWork2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ProfitLossSummaryWork> SelectEnumerableAsync()
    {
      ProfitLossSummaryWork profitLossSummaryWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(profitLossSummaryWork1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, profitLossSummaryWork1.OleDB.CommandTimeout);
        if (profitLossSummaryWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + profitLossSummaryWork1.message + "\n--------------------------------------------------------------------------------------------------");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else
        {
          Hashtable p_param = new Hashtable();
          p_param.Add((object) "pls_SiteID", (object) profitLossSummaryWork1.pls_SiteID);
          p_param.Add((object) "pls_YyyyMm", (object) profitLossSummaryWork1.pls_YyyyMm);
          if (string.IsNullOrEmpty(profitLossSummaryWork1.WorkStoreCodeIn))
            p_param.Add((object) "pls_StoreCode", (object) profitLossSummaryWork1.pls_StoreCode);
          else
            p_param.Add((object) "pls_StoreCode_IN_", (object) profitLossSummaryWork1.WorkStoreCodeIn);
          p_param.Add((object) "WorkOriginDate", (object) profitLossSummaryWork1.WorkOriginDate.Value);
          p_param.Add((object) "pls_YyyyMmBefore", (object) profitLossSummaryWork1.pls_YyyyMmBefore);
          if (!await rs.OpenAsync(profitLossSummaryWork1.GetSelectQuery((object) p_param)))
          {
            profitLossSummaryWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossSummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
            // ISSUE: reference to a compiler-generated field
            this.\u003C\u003Ew__disposeMode = true;
          }
          else if (await rs.IsDataReadAsync())
          {
            int row_number = 0;
            do
            {
              ProfitLossSummaryWork profitLossSummaryWork2 = profitLossSummaryWork1.OleDB.Create<ProfitLossSummaryWork>();
              if (profitLossSummaryWork2.GetFieldValues(rs))
              {
                profitLossSummaryWork2.row_number = ++row_number;
                yield return profitLossSummaryWork2;
              }
            }
            while (await rs.IsDataReadAsync());
          }
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.db_status = p_rs.GetFieldInt("db_status");
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        double fieldDouble = p_rs.GetFieldDouble("gdh_SalePrice");
        if (!fieldDouble.IsZero())
          this.pls_EndPrice = fieldDouble;
        else
          this.pls_EndPrice = p_rs.GetFieldDouble("gdh_SalePrice");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "pls_SiteID") && Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkStateGoods(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryInvtQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkStartQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkEndQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkSaleQuery(p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithWorkBuyQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkReturnQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkInnerMoveOutQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkInnerMoveInQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkOuterMoveOutQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkOuterMoveInQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkAdjustQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkDisuseQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\nSELECT pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,gdh_Supplier AS pls_Supplier,su_SupplierType AS pls_SupplierType,gdh_GoodsCategory AS pls_CategoryCode,gd_TaxDiv AS pls_TaxDiv,gd_StockUnit AS pls_StockUnit,gd_SalesUnit AS pls_SalesUnit");
        stringBuilder.Append(TProfitLossSummary.MainCol);
        stringBuilder.Append("\n,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat");
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append("\n,gd_GoodsName,gd_BarCode");
        stringBuilder.Append("\n,gdh_SalePrice,gdh_EventPrice");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.SubCol);
        stringBuilder.Append("\n,MAX(db_status) AS db_status");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyStartCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyEndCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyEndTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodySaleCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodySaleTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyBuyCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyBuyTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyReturnCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyReturnTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyInnerMoveOutCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyInnerMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyInnerMoveInCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyInnerMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyOuterMoveOutCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyOuterMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyOuterMoveInCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyOuterMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyAdjustCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyAdjustTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append(TProfitLossSummary.TBodyDisuseCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyDisuseTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY pls_YyyyMm,pls_StoreCode,pls_GoodsCode");
        stringBuilder.Append(",pls_SiteID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\n INNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND pls_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND pls_SiteID=su_SiteID\n INNER JOIN T_CATEGORY ON gdh_GoodsCategory=ctg_ID AND pls_SiteID=ctg_SiteID AND ctg_DepositYn='N'\n INNER JOIN T_STATE_GOODS ON pls_GoodsCode=gd_GoodsCode AND pls_SiteID=gd_SiteID");
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pls_YyyyMm,pls_StoreCode,pls_GoodsCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkStateGoods(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STATE_GOODS AS ( SELECT  gd_GoodsCode,gd_SiteID,gd_TaxDiv,gd_SalesUnit,gd_StockUnit,gd_GoodsName,gd_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          p_param1.Add((object) "gd_PackUnit", (object) 1);
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "gd_PackUnit", (object) 1));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkGoodsHistoryQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TGoodsHistory().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkStartQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyStartTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm", (object) "pls_StoreCode", (object) "pls_GoodsCode") + ",pls_SiteID,pls_EndQty AS pls_BaseQty,pls_EndAvgCost AS pls_BaseAvgCost,pls_EndCostAmt AS pls_BaseCostAmt,pls_EndCostVatAmt AS pls_BaseCostVatAmt,pls_EndPrice AS pls_BasePrice,pls_EndPriceCostAmt AS pls_BasePriceCostAmt,pls_EndPriceCostVatAmt AS pls_BasePriceCostVatAmt,pls_EndPriceAmt AS pls_BasePriceAmt,pls_EndPriceVatAmt AS pls_BasePriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_YyyyMmBefore"))
            p_param1.Add((object) "pls_YyyyMm", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pls_YyyyMm"))
            p_param1.Add((object) "pls_YyyyMm", (object) this.pls_YyyyMmBefore);
          if (!p_param1.ContainsKey((object) "pls_StoreCode") && !p_param1.ContainsKey((object) "pls_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode", (object) this.pls_StoreCode);
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pls_YyyyMm", (object) this.pls_YyyyMmBefore));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkEndQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyEndTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm", (object) "pls_StoreCode", (object) "pls_GoodsCode") + ",pls_SiteID,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt" + string.Format(",{0} AS {1}", (object) 2, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_YyyyMm"))
            p_param1.Add((object) "pls_YyyyMm", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pls_YyyyMm"))
            p_param1.Add((object) "pls_YyyyMm", (object) this.pls_YyyyMm);
          if (!p_param1.ContainsKey((object) "pls_StoreCode") && !p_param1.ContainsKey((object) "pls_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode", (object) this.pls_StoreCode);
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pls_YyyyMm", (object) this.pls_YyyyMm));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkSaleQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodySaleTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sbd_StoreCode AS pls_StoreCode,sbd_GoodsCode AS pls_GoodsCode,sbd_SiteID AS pls_SiteID,SUM(sbd_SaleQty) AS pls_SaleQty,SUM(sbd_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(sbd_SaleAmt) AS pls_SaleAmt,SUM(sbd_SaleVatAmt) AS pls_SaleVatAmt,SUM(sbd_ProfitAmt) AS pls_SaleProfit,SUM(sbd_PreTaxProfitAmt) AS pls_SalePriceProfit,SUM(sbd_EnurySlip) AS pls_EnurySlip,SUM(sbd_EnuryEnd) AS pls_EnuryEnd,SUM(sbd_DcAmtManual) AS pls_DcAmtManual,SUM(sbd_DcAmtEvent) AS pls_DcAmtEvent,SUM(sbd_DcAmtGoods) AS pls_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(sbd_DcAmtMember) AS pls_DcAmtMember,SUM(sbd_SlipCustomer) AS pls_Customer,SUM(sbd_GoodsCustomer) AS pls_CustomerGoods,SUM(sbd_CategoryCustomer) AS pls_CustomerCategory,SUM(sbd_SupplierCustomer) AS pls_CustomerSupplier,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sbd_SaleDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && !p_param1.ContainsKey((object) "sbd_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "WorkFirstDay"))
            p_param1.Add((object) "sbd_SaleDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "WorkLastDay"))
            p_param1.Add((object) "sbd_SaleDate_END_", (object) this.WorkLastDay);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(" WHERE sbd_SaleDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbd_SaleDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append("\nGROUP BY sbd_StoreCode,sbd_GoodsCode,sbd_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkBuyQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyBuyTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_BuyQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_BuyCostAmt,SUM(sd_CostVatAmt) AS pls_BuyCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_BuyPriceAmt,SUM(sd_PriceVatAmt) AS pls_BuyPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", (object) 1));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkReturnQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyReturnTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_ReturnQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_ReturnCostAmt,SUM(sd_CostVatAmt) AS pls_ReturnCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_ReturnPriceAmt,SUM(sd_PriceVatAmt) AS pls_ReturnPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", (object) 1));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkInnerMoveOutQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyInnerMoveOutTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_InnerMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 3);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 3));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkInnerMoveInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyInnerMoveInTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_InnerMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 3);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 3));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkOuterMoveOutQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyOuterMoveOutTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_OuterMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 4);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 4));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkOuterMoveInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyOuterMoveInTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_OuterMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 4);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 4));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkAdjustQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyAdjustTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty*sh_InOutDiv) AS pls_AdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS pls_AdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS pls_AdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS pls_AdjustPriceCostSumAmt,SUM(0) AS pls_AdjustPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 5);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 5));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkDisuseQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyDisuseTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty*sh_InOutDiv*-1) AS pls_DisuseQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisuseCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv*-1) AS pls_DisuseCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisusePriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv*-1) AS pls_DisusePriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*-1*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv*-1 END) AS pls_DisusePriceCostSumAmt,SUM(0) AS pls_DisusePriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 6);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 6));
        }
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
