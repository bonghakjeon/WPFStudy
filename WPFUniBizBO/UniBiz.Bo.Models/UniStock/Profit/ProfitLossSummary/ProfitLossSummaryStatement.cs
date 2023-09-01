// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.ProfitLossSummaryStatement
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
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary
{
  public class ProfitLossSummaryStatement : TProfitLossSummary<ProfitLossSummaryStatement>
  {
    private long _sh_StatementNo;
    private DateTime? _sh_ConfirmDate;
    private int _pls_YyyyMmBefore;
    private string _si_StoreName;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private Action<string> _CallBackMessage;

    public long sh_StatementNo
    {
      get => this._sh_StatementNo;
      set
      {
        this._sh_StatementNo = value;
        this.Changed(nameof (sh_StatementNo));
      }
    }

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
        if (this._sh_ConfirmDate.HasValue)
        {
          DateTime dateTime = this._sh_ConfirmDate.Value;
          int num = dateTime.Year * 100;
          dateTime = this._sh_ConfirmDate.Value;
          int month = dateTime.Month;
          this.pls_YyyyMm = num + month;
          DateTime dateAdd = this._sh_ConfirmDate.Value.ToFirstDateOfMonth().GetDateAdd(0, 0, -1);
          this.pls_YyyyMmBefore = dateAdd.Year * 100 + dateAdd.Month;
        }
        this.Changed("MonthFirstDay");
        this.Changed("MonthLastDay");
      }
    }

    public DateTime? MonthFirstDay => this.sh_ConfirmDate.HasValue ? new DateTime?(this.sh_ConfirmDate.Value.ToFirstDateOfMonth()) : new DateTime?();

    public DateTime? MonthLastDay => this.sh_ConfirmDate.HasValue ? new DateTime?(this.sh_ConfirmDate.Value.ToLastDateOfMonth()) : new DateTime?();

    public int pls_YyyyMmBefore
    {
      get => this._pls_YyyyMmBefore;
      set
      {
        this._pls_YyyyMmBefore = value;
        this.Changed(nameof (pls_YyyyMmBefore));
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

    public ProfitLossSummaryStatement()
    {
    }

    public ProfitLossSummaryStatement(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.sh_StatementNo = 0L;
      this.sh_ConfirmDate = new DateTime?();
      this.pls_YyyyMmBefore = 0;
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
      if (this.pls_YyyyMmBefore == 0)
      {
        this.message = "년월(pls_YyyyMmBefore)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pls_StoreCode == 0)
      {
        this.message = "지점코드(pls_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sh_StatementNo == 0L)
      {
        this.message = "전표 코드(sh_StatementNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sh_ConfirmDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "확정일(sh_ConfirmDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
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
      ProfitLossSummaryStatement summaryStatement = this;
      try
      {
        if (summaryStatement.db_status == 0)
        {
          if (!await summaryStatement.InsertAsync())
            throw new UniServiceException(summaryStatement.message, summaryStatement.TableCode.ToDescription() + " 등록 오류");
        }
        else if (summaryStatement.db_status > 0)
        {
          if (!await summaryStatement.UpdateAsync((UbModelBase) null))
            throw new UniServiceException(summaryStatement.message, summaryStatement.TableCode.ToDescription() + " 등록 오류");
        }
        return true;
      }
      catch (Exception ex)
      {
        summaryStatement.message = " " + summaryStatement.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(summaryStatement.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      long p_sh_StatementNo,
      DateTime p_sh_ConfirmDate)
    {
      ProfitLossSummaryStatement summaryStatement = this;
      bool isMessage = summaryStatement._CallBackMessage != null && pJobInfo != null;
      try
      {
        summaryStatement.pls_SiteID = p_sh_SiteID;
        summaryStatement.pls_StoreCode = p_sh_StoreCode;
        summaryStatement.sh_StatementNo = p_sh_StatementNo;
        summaryStatement.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate);
        if (summaryStatement.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + summaryStatement.message);
        Log.Logger.DebugColor("\n전표 재고 마감 " + pWorkDesc + " 해당 재고 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<ProfitLossSummaryStatement> summaryStatementList = await summaryStatement.SelectStatementListAsync();
        if (summaryStatementList == null)
          throw new Exception("조회에러.\n" + summaryStatement.message);
        int count = 0;
        int viewPro = 0;
        int total = summaryStatementList.Count;
        foreach (ProfitLossSummaryStatement item in (IEnumerable<ProfitLossSummaryStatement>) summaryStatementList)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          item.SetAdoDatabase(summaryStatement.OleDB);
          if (item.pls_SiteID == 0L)
            item.pls_SiteID = summaryStatement.pls_SiteID;
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
              summaryStatement._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        summaryStatement.message = " " + summaryStatement.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(summaryStatement.message);
      }
      return false;
    }

    public bool ProcApply(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      long p_sh_StatementNo,
      DateTime p_sh_ConfirmDate)
    {
      bool flag = this._CallBackMessage != null && pJobInfo != null;
      try
      {
        this.pls_SiteID = p_sh_SiteID;
        this.pls_StoreCode = p_sh_StoreCode;
        this.sh_StatementNo = p_sh_StatementNo;
        this.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate);
        if (this.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + this.message);
        Log.Logger.DebugColor("\n전표 재고 마감 " + pWorkDesc + " 해당 재고 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<ProfitLossSummaryStatement> summaryStatementList = this.SelectStatementList();
        if (summaryStatementList == null)
          throw new Exception("조회에러.\n" + this.message);
        int num1 = 0;
        int num2 = 0;
        int count = summaryStatementList.Count;
        foreach (ProfitLossSummaryStatement summaryStatement in (IEnumerable<ProfitLossSummaryStatement>) summaryStatementList)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          summaryStatement.SetAdoDatabase(this.OleDB);
          if (summaryStatement.pls_SiteID == 0L)
            summaryStatement.pls_SiteID = this.pls_SiteID;
          summaryStatement.CalcEndQty();
          if (summaryStatement.pls_IsStockUnitAmount)
          {
            if (!summaryStatement.pls_AdjustCostAmt.IsZero())
            {
              summaryStatement.pls_EndCostAmt = summaryStatement.pls_AdjustCostAmt;
              if (!summaryStatement.pls_AdjustQty.IsZero())
                summaryStatement.pls_EndQty = summaryStatement.pls_AdjustQty;
              else if (summaryStatement.pls_EndCostAmt > 0.0)
                summaryStatement.pls_EndQty = 1.0;
              else if (summaryStatement.pls_EndCostAmt < 0.0)
                summaryStatement.pls_EndQty = -1.0;
              else
                summaryStatement.pls_EndQty = 0.0;
            }
            else
            {
              summaryStatement.pls_EndCostAmt = 0.0;
              summaryStatement.pls_EndQty = 0.0;
            }
            if (!summaryStatement.pls_AdjustPriceAmt.IsZero())
              summaryStatement.pls_EndPriceAmt = summaryStatement.pls_AdjustPriceAmt;
            else
              summaryStatement.pls_EndPriceAmt = 0.0;
            summaryStatement.pls_AdjustQty = 0.0;
            summaryStatement.pls_AdjustCostAmt = 0.0;
            summaryStatement.pls_AdjustPriceAmt = 0.0;
            summaryStatement.pls_AdjustPriceCostSumAmt = 0.0;
            if (summaryStatement.pls_EndCostAmt.IsZero() && summaryStatement.pls_EndPriceAmt.IsZero())
              summaryStatement.pls_EndQty = 0.0;
          }
          else
          {
            if (((summaryStatement.pls_BaseAvgCost.IsZero() ? 0.0 : summaryStatement.pls_BaseQty) + summaryStatement.pls_BuyQty + summaryStatement.pls_InnerMoveInQty + summaryStatement.pls_OuterMoveInQty).IsZero())
            {
              summaryStatement.pls_EndAvgCost = 0.0;
            }
            else
            {
              double dAmount = Math.Abs(summaryStatement.pls_BaseQty * summaryStatement.pls_BaseAvgCost) + Math.Abs(summaryStatement.pls_BuyCostAmt) + Math.Abs(summaryStatement.pls_InnerMoveInCostAmt) + Math.Abs(summaryStatement.pls_OuterMoveInCostAmt);
              double dQty = Math.Abs(summaryStatement.pls_BaseAvgCost.IsZero() ? 0.0 : summaryStatement.pls_BaseQty) + Math.Abs(summaryStatement.pls_BuyQty) + Math.Abs(summaryStatement.pls_InnerMoveInQty) + Math.Abs(summaryStatement.pls_OuterMoveInQty);
              summaryStatement.pls_EndAvgCost = CalcHelper.ToArgCost3(dAmount, dQty);
            }
            if (!summaryStatement.pls_AdjustQty.IsZero())
            {
              summaryStatement.pls_AdjustCostAmt = summaryStatement.pls_EndAvgCost * summaryStatement.pls_AdjustQty;
              summaryStatement.pls_AdjustPriceAmt = summaryStatement.pls_EndPrice * summaryStatement.pls_AdjustQty;
              if (summaryStatement.pls_IsTax)
              {
                summaryStatement.pls_AdjustCostVatAmt = summaryStatement.pls_AdjustCostAmt.ToCostVat();
                summaryStatement.pls_AdjustPriceVatAmt = summaryStatement.pls_AdjustPriceAmt.ToPriceVat();
              }
              else
              {
                summaryStatement.pls_AdjustCostVatAmt = 0.0;
                summaryStatement.pls_AdjustPriceVatAmt = 0.0;
              }
            }
            else
            {
              summaryStatement.pls_AdjustCostAmt = 0.0;
              summaryStatement.pls_AdjustCostVatAmt = 0.0;
              summaryStatement.pls_AdjustPriceVatAmt = 0.0;
              summaryStatement.pls_AdjustPriceVatAmt = 0.0;
            }
            if (!summaryStatement.pls_DisuseQty.IsZero())
            {
              summaryStatement.pls_DisuseCostAmt = summaryStatement.pls_EndAvgCost * summaryStatement.pls_DisuseQty;
              summaryStatement.pls_DisusePriceAmt = summaryStatement.pls_EndPrice * summaryStatement.pls_DisuseQty;
              if (summaryStatement.pls_IsTax)
              {
                summaryStatement.pls_DisuseCostVatAmt = summaryStatement.pls_DisuseCostAmt.ToCostVat();
                summaryStatement.pls_DisusePriceVatAmt = summaryStatement.pls_DisusePriceAmt.ToPriceVat();
              }
              else
              {
                summaryStatement.pls_DisuseCostVatAmt = 0.0;
                summaryStatement.pls_DisusePriceVatAmt = 0.0;
              }
            }
            else
            {
              summaryStatement.pls_DisuseCostAmt = 0.0;
              summaryStatement.pls_DisuseCostVatAmt = 0.0;
              summaryStatement.pls_DisusePriceAmt = 0.0;
              summaryStatement.pls_DisusePriceVatAmt = 0.0;
            }
            summaryStatement.pls_EndCostAmt = summaryStatement.pls_EndAvgCost * summaryStatement.pls_EndQty;
            summaryStatement.pls_EndPriceAmt = summaryStatement.pls_EndPrice * summaryStatement.pls_EndQty;
            if (summaryStatement.pls_IsTax)
            {
              summaryStatement.pls_EndCostVatAmt = summaryStatement.pls_EndCostAmt.ToCostVat();
              summaryStatement.pls_EndPriceVatAmt = summaryStatement.pls_EndPriceAmt.ToCostVat();
            }
            else
            {
              summaryStatement.pls_EndCostVatAmt = 0.0;
              summaryStatement.pls_EndPriceVatAmt = 0.0;
            }
            summaryStatement.CalcEndPriceAmt();
          }
          summaryStatement.CalcTaxVat();
          summaryStatement.CalcEndPriceCostAmt();
          summaryStatement.CalcSaleProfit();
          summaryStatement.CalcSalePriceProfit();
          summaryStatement.CalcSalePriceUpDown();
          if (!summaryStatement.IsZero(EnumZeroCheck.ALL))
            summaryStatement.ItemSave();
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            num2 = num3;
            if (flag)
            {
              JobEvtProgressing jobEvtProgressing = new JobEvtProgressing();
              jobEvtProgressing.SiteID = pJobInfo.SiteID;
              jobEvtProgressing.Id = pJobInfo.Id;
              jobEvtProgressing.JobId = pJobInfo.JobId;
              jobEvtProgressing.Title = "지점" + summaryStatement.si_StoreName + " 작업";
              jobEvtProgressing.Msg = string.Format("[{0}({1})] {2} 작업중 ({3}/{4})", (object) summaryStatement.gd_GoodsName, (object) summaryStatement.gd_BarCode, (object) num2, (object) num1, (object) count);
              jobEvtProgressing.ProgressValue = (double) num2 / 100.0;
              this._CallBackMessage(jobEvtProgressing.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<bool> ProcNextAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      long p_sh_StatementNo,
      DateTime p_sh_ConfirmDate)
    {
      ProfitLossSummaryStatement summaryStatement = this;
      DateTime lastDay = DateTime.Now.ToLastDateOfMonth();
      try
      {
        summaryStatement.pls_SiteID = p_sh_SiteID;
        summaryStatement.pls_StoreCode = p_sh_StoreCode;
        summaryStatement.sh_StatementNo = p_sh_StatementNo;
        summaryStatement.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate.ToLastDateOfMonth());
        if (summaryStatement.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + summaryStatement.message);
        for (DateTime ConfirmDate = summaryStatement.sh_ConfirmDate.Value; ConfirmDate <= lastDay; ConfirmDate = ConfirmDate.GetDateAdd(0, 1, 0))
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          int num = await summaryStatement.ProcApplyAsync(pJobInfo, pWorkDesc, p_sh_SiteID, p_sh_StoreCode, p_sh_StatementNo, ConfirmDate) ? 1 : 0;
        }
        return true;
      }
      catch (Exception ex)
      {
        summaryStatement.message = " " + summaryStatement.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(summaryStatement.message);
      }
      return false;
    }

    public bool ProcNext(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      long p_sh_StatementNo,
      DateTime p_sh_ConfirmDate)
    {
      DateTime lastDateOfMonth = DateTime.Now.ToLastDateOfMonth();
      try
      {
        this.pls_SiteID = p_sh_SiteID;
        this.pls_StoreCode = p_sh_StoreCode;
        this.sh_StatementNo = p_sh_StatementNo;
        this.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate.ToLastDateOfMonth());
        if (this.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + this.message);
        for (DateTime dateAdd = this.sh_ConfirmDate.Value; dateAdd <= lastDateOfMonth; dateAdd = dateAdd.GetDateAdd(0, 1, 0))
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          this.ProcApply(pJobInfo, pWorkDesc, p_sh_SiteID, p_sh_StoreCode, p_sh_StatementNo, dateAdd);
        }
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<ProfitLossSummaryStatement>> SelectStatementListAsync()
    {
      ProfitLossSummaryStatement summaryStatement1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryStatement1.OleDB.ConnectionUrl, pCommandTimeout: 180);
        rs = new UniOleDbRecordset(db, summaryStatement1.OleDB.CommandTimeout);
        if (summaryStatement1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + summaryStatement1.TableCode.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + summaryStatement1.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(summaryStatement1.message);
        }
        if (!await rs.OpenAsync(summaryStatement1.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pls_SiteID",
            (object) summaryStatement1.pls_SiteID
          },
          {
            (object) "pls_YyyyMm",
            (object) summaryStatement1.pls_YyyyMm
          },
          {
            (object) "pls_YyyyMmBefore",
            (object) summaryStatement1.pls_YyyyMmBefore
          },
          {
            (object) "pls_StoreCode",
            (object) summaryStatement1.pls_StoreCode
          },
          {
            (object) "sh_StatementNo",
            (object) summaryStatement1.sh_StatementNo
          },
          {
            (object) "sh_ConfirmDate",
            (object) summaryStatement1.sh_ConfirmDate.Value.ToLastDateOfMonth()
          },
          {
            (object) "MonthFirstDay",
            (object) summaryStatement1.MonthFirstDay
          },
          {
            (object) "MonthLastDay",
            (object) summaryStatement1.MonthLastDay
          }
        })))
        {
          summaryStatement1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryStatement>) null;
        }
        List<ProfitLossSummaryStatement> lt_list = new List<ProfitLossSummaryStatement>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryStatement summaryStatement2 = summaryStatement1.OleDB.Create<ProfitLossSummaryStatement>();
            if (summaryStatement2.GetFieldValues(rs))
            {
              summaryStatement2.row_number = lt_list.Count + 1;
              lt_list.Add(summaryStatement2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return (IList<ProfitLossSummaryStatement>) lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public IList<ProfitLossSummaryStatement> SelectStatementList()
    {
      UniOleDbRecordset p_rs = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl, pCommandTimeout: 180);
        p_rs = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (this.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + this.TableCode.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + this.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(this.message);
        }
        if (!p_rs.Open(this.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pls_SiteID",
            (object) this.pls_SiteID
          },
          {
            (object) "pls_YyyyMm",
            (object) this.pls_YyyyMm
          },
          {
            (object) "pls_YyyyMmBefore",
            (object) this.pls_YyyyMmBefore
          },
          {
            (object) "pls_StoreCode",
            (object) this.pls_StoreCode
          },
          {
            (object) "sh_StatementNo",
            (object) this.sh_StatementNo
          },
          {
            (object) "sh_ConfirmDate",
            (object) this.sh_ConfirmDate.Value.ToLastDateOfMonth()
          },
          {
            (object) "MonthFirstDay",
            (object) this.MonthFirstDay
          },
          {
            (object) "MonthLastDay",
            (object) this.MonthLastDay
          }
        })))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryStatement>) null;
        }
        List<ProfitLossSummaryStatement> summaryStatementList = new List<ProfitLossSummaryStatement>();
        if (p_rs.IsDataRead())
        {
          do
          {
            ProfitLossSummaryStatement summaryStatement = this.OleDB.Create<ProfitLossSummaryStatement>();
            if (summaryStatement.GetFieldValues(p_rs))
            {
              summaryStatement.row_number = summaryStatementList.Count + 1;
              summaryStatementList.Add(summaryStatement);
            }
          }
          while (p_rs.IsDataRead());
        }
        return (IList<ProfitLossSummaryStatement>) summaryStatementList;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        p_rs?.Close();
        pOleDB?.Close();
      }
    }

    public async IAsyncEnumerable<ProfitLossSummaryStatement> SelectStatementEnumerableAsync()
    {
      ProfitLossSummaryStatement summaryStatement1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryStatement1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryStatement1.OleDB.CommandTimeout);
        if (summaryStatement1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + summaryStatement1.message + "\n--------------------------------------------------------------------------------------------------");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (!await rs.OpenAsync(summaryStatement1.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pls_SiteID",
            (object) summaryStatement1.pls_SiteID
          },
          {
            (object) "pls_YyyyMm",
            (object) summaryStatement1.pls_YyyyMm
          },
          {
            (object) "pls_YyyyMmBefore",
            (object) summaryStatement1.pls_YyyyMmBefore
          },
          {
            (object) "pls_StoreCode",
            (object) summaryStatement1.pls_StoreCode
          },
          {
            (object) "sh_StatementNo",
            (object) summaryStatement1.sh_StatementNo
          },
          {
            (object) "MonthFirstDay",
            (object) summaryStatement1.MonthFirstDay
          },
          {
            (object) "MonthLastDay",
            (object) summaryStatement1.MonthLastDay
          }
        })))
        {
          summaryStatement1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ProfitLossSummaryStatement summaryStatement2 = summaryStatement1.OleDB.Create<ProfitLossSummaryStatement>();
            if (summaryStatement2.GetFieldValues(rs))
            {
              summaryStatement2.row_number = ++row_number;
              yield return summaryStatement2;
            }
          }
          while (await rs.IsDataReadAsync());
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
        long p_sd_StatementNo = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "pls_SiteID") && Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "sh_StatementNo") && Convert.ToInt64(hashtable2[(object) "sh_StatementNo"].ToString()) > 0L)
            p_sd_StatementNo = Convert.ToInt64(hashtable2[(object) "sh_StatementNo"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStatementDetailGoods(p_sd_StatementNo, uniBase, p_SiteID));
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
        stringBuilder.Append("\nINNER JOIN T_STORE ON pls_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND pls_SiteID=gdh_SiteID\nINNER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND pls_SiteID=su_SiteID\nINNER JOIN T_CATEGORY ON gdh_GoodsCategory=ctg_ID AND pls_SiteID=ctg_SiteID AND ctg_DepositYn='N'\nINNER JOIN T_STATE_GOODS ON pls_GoodsCode=gd_GoodsCode AND pls_SiteID=gd_SiteID");
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

    public string ToWithStatementDetailGoods(long p_sd_StatementNo, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\n,T_STATEMENT_DETAIL_GOODS AS (\nSELECT god_sd_GoodsCode" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "sd_StatementNo", (object) p_sd_StatementNo) + string.Format(" AND {0}={1}", (object) "sd_SiteID", (object) p_SiteID) + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nGROUP BY sd_GoodsCode");
      return stringBuilder.ToString();
    }

    public string ToWithWorkStateGoods(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STATE_GOODS AS (\nSELECT  gd_GoodsCode,gd_SiteID,gd_TaxDiv,gd_SalesUnit,gd_StockUnit,gd_GoodsName,gd_BarCode" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON gd_GoodsCode=god_sd_GoodsCode");
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
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1));
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
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON gdh_GoodsCode=god_sd_GoodsCode");
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
        stringBuilder.Append("\n,TBodyStartTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm", (object) "pls_StoreCode", (object) "pls_GoodsCode") + ",pls_SiteID,pls_EndQty AS pls_BaseQty,pls_EndAvgCost AS pls_BaseAvgCost,pls_EndCostAmt AS pls_BaseCostAmt,pls_EndCostVatAmt AS pls_BaseCostVatAmt,pls_EndPrice AS pls_BasePrice,pls_EndPriceCostAmt AS pls_BasePriceCostAmt,pls_EndPriceCostVatAmt AS pls_BasePriceCostVatAmt,pls_EndPriceAmt AS pls_BasePriceAmt,pls_EndPriceVatAmt AS pls_BasePriceVatAmt,0 AS db_status" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON pls_GoodsCode=god_sd_GoodsCode");
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
        stringBuilder.Append("\n,TBodyEndTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm", (object) "pls_StoreCode", (object) "pls_GoodsCode") + ",pls_SiteID,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt" + string.Format(",{0} AS {1}", (object) 2, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON pls_GoodsCode=god_sd_GoodsCode");
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
        stringBuilder.Append("\n,TBodySaleTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sbd_StoreCode AS pls_StoreCode,sbd_GoodsCode AS pls_GoodsCode,sbd_SiteID AS pls_SiteID,SUM(sbd_SaleQty) AS pls_SaleQty,SUM(sbd_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(sbd_SaleAmt) AS pls_SaleAmt,SUM(sbd_SaleVatAmt) AS pls_SaleVatAmt,SUM(sbd_ProfitAmt) AS pls_SaleProfit,SUM(sbd_PreTaxProfitAmt) AS pls_SalePriceProfit,SUM(sbd_EnurySlip) AS pls_EnurySlip,SUM(sbd_EnuryEnd) AS pls_EnuryEnd,SUM(sbd_DcAmtManual) AS pls_DcAmtManual,SUM(sbd_DcAmtEvent) AS pls_DcAmtEvent,SUM(sbd_DcAmtGoods) AS pls_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(sbd_DcAmtMember) AS pls_DcAmtMember,SUM(sbd_SlipCustomer) AS pls_Customer,SUM(sbd_GoodsCustomer) AS pls_CustomerGoods,SUM(sbd_CategoryCustomer) AS pls_CustomerCategory,SUM(sbd_SupplierCustomer) AS pls_CustomerSupplier,0 AS db_status" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sbd_GoodsCode=god_sd_GoodsCode" + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sbd_SaleDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && !p_param1.ContainsKey((object) "sbd_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "MonthFirstDay"))
            p_param1.Add((object) "sbd_SaleDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "MonthLastDay"))
            p_param1.Add((object) "sbd_SaleDate_END_", (object) this.MonthLastDay);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(" WHERE sbd_SaleDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbd_SaleDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyBuyTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_BuyQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_BuyCostAmt,SUM(sd_CostVatAmt) AS pls_BuyCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_BuyPriceAmt,SUM(sd_PriceVatAmt) AS pls_BuyPriceVatAmt,0 AS db_status" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyReturnTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_ReturnQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_ReturnCostAmt,SUM(sd_CostVatAmt) AS pls_ReturnCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_ReturnPriceAmt,SUM(sd_PriceVatAmt) AS pls_ReturnPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyInnerMoveOutTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_InnerMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyInnerMoveInTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_InnerMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyOuterMoveOutTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_OuterMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyOuterMoveInTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty) AS pls_OuterMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyAdjustTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty*sh_InOutDiv) AS pls_AdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS pls_AdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS pls_AdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS pls_AdjustPriceCostSumAmt,SUM(0) AS pls_AdjustPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append("\n,TBodyDisuseTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.pls_YyyyMm, (object) "pls_YyyyMm") + ",sh_StoreCode AS pls_StoreCode,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID,SUM(sd_BuyQty*sh_InOutDiv*-1) AS pls_DisuseQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisuseCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv*-1) AS pls_DisuseCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisusePriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv*-1) AS pls_DisusePriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*-1*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv*-1 END) AS pls_DisusePriceCostSumAmt,SUM(0) AS pls_DisusePriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_STATEMENT_DETAIL_GOODS ON sd_GoodsCode=god_sd_GoodsCode" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("MonthLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.MonthFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.MonthLastDay);
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
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.MonthFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.MonthLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
