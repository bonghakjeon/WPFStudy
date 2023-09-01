// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.InventorySummaryWork
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
using UniBiz.Bo.Models.UniStock.Inventory.InventoryWork;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventorySummary
{
  public class InventorySummaryWork : TInventorySummary<InventorySummaryWork>
  {
    private DateTime? _WorkInventoryDate;
    private int _ivts_YyyyMmBefore;
    private string _WorkStoreCodeIn;
    private Action<string> _CallBackMessage;

    public DateTime? WorkInventoryDate
    {
      get => this._WorkInventoryDate;
      set
      {
        this._WorkInventoryDate = value;
        this.Changed(nameof (WorkInventoryDate));
        if (this._WorkInventoryDate.HasValue)
        {
          DateTime dateTime = this._WorkInventoryDate.Value;
          int num = dateTime.Year * 100;
          dateTime = this._WorkInventoryDate.Value;
          int month = dateTime.Month;
          this.ivts_YyyyMm = num + month;
          dateTime = this._WorkInventoryDate.Value;
          this.ivts_Day = dateTime.Day;
          DateTime dateAdd = this._WorkInventoryDate.Value.ToFirstDateOfMonth().GetDateAdd(0, 0, -1);
          this.ivts_YyyyMmBefore = dateAdd.Year * 100 + dateAdd.Month;
        }
        this.Changed("WorkFirstDay");
        this.Changed("WorkLastDay");
      }
    }

    public DateTime? WorkFirstDay => this.WorkInventoryDate.HasValue ? new DateTime?(this.WorkInventoryDate.Value.ToFirstDateOfMonth()) : new DateTime?();

    public DateTime? WorkLastDay => this.WorkInventoryDate.HasValue ? new DateTime?(this.WorkInventoryDate.Value.ToLastDateOfMonth()) : new DateTime?();

    public int ivts_YyyyMmBefore
    {
      get => this._ivts_YyyyMmBefore;
      set
      {
        this._ivts_YyyyMmBefore = value;
        this.Changed(nameof (ivts_YyyyMmBefore));
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

    public InventorySummaryWork()
    {
    }

    public InventorySummaryWork(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.WorkInventoryDate = new DateTime?();
      this.ivts_YyyyMmBefore = 0;
      this.WorkStoreCodeIn = (string) null;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ivts_SiteID == 0L)
      {
        this.message = "싸이트(ivts_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_YyyyMm == 0)
      {
        this.message = "마감년월(ivts_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_Day == 0)
      {
        this.message = "일자(ivts_Day)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ivts_StoreCode == 0 && string.IsNullOrEmpty(this.WorkStoreCodeIn))
      {
        this.message = "지점코드(ivts_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.WorkInventoryDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "재고조사일자(WorkInventoryDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    public override async Task<bool> DataClearAsync(Hashtable p_param)
    {
      InventorySummaryWork inventorySummaryWork = this;
      // ISSUE: reference to a compiler-generated method
      inventorySummaryWork.\u003C\u003En__0();
      if ((p_param == null || p_param.Count == 0) && p_param == null)
        p_param = new Hashtable();
      if (!p_param.ContainsKey((object) "ivts_SiteID"))
        p_param.Add((object) "ivts_SiteID", (object) inventorySummaryWork.ivts_SiteID);
      if (!p_param.ContainsKey((object) "ivts_YyyyMm"))
        p_param.Add((object) "ivts_YyyyMm", (object) inventorySummaryWork.ivts_YyyyMm);
      if (!p_param.ContainsKey((object) "ivts_Day"))
        p_param.Add((object) "ivts_Day", (object) inventorySummaryWork.ivts_Day);
      if (!p_param.ContainsKey((object) "ivts_StoreCode") && !p_param.ContainsKey((object) "ivts_StoreCode_IN_"))
      {
        if (string.IsNullOrEmpty(inventorySummaryWork.WorkStoreCodeIn))
          p_param.Add((object) "ivts_StoreCode", (object) inventorySummaryWork.ivts_StoreCode);
        else
          p_param.Add((object) "ivts_StoreCode_IN_", (object) inventorySummaryWork.WorkStoreCodeIn);
      }
      if (await inventorySummaryWork.OleDB.ExecuteAsync(inventorySummaryWork.DataClearQuery(p_param)))
        return true;
      inventorySummaryWork.message = " " + inventorySummaryWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) inventorySummaryWork.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) inventorySummaryWork.ivts_YyyyMm, (object) inventorySummaryWork.ivts_StoreCode, (object) inventorySummaryWork.ivts_GoodsCode, (object) inventorySummaryWork.ivts_SiteID) + " 내용 : " + inventorySummaryWork.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(inventorySummaryWork.message);
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
      InventorySummaryWork inventorySummaryWork = this;
      try
      {
        if (inventorySummaryWork.db_status == 0)
        {
          if (!await inventorySummaryWork.InsertAsync())
            throw new UniServiceException(inventorySummaryWork.message, inventorySummaryWork.TableCode.ToDescription() + " 등록 오류");
        }
        else if (inventorySummaryWork.db_status > 0)
        {
          if (!await inventorySummaryWork.UpdateAsync((UbModelBase) null))
            throw new UniServiceException(inventorySummaryWork.message, inventorySummaryWork.TableCode.ToDescription() + " 등록 오류");
        }
        return true;
      }
      catch (Exception ex)
      {
        inventorySummaryWork.message = " " + inventorySummaryWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(inventorySummaryWork.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      JobEvtInventoryWork pData)
    {
      InventorySummaryWork inventorySummaryWork1 = this;
      bool isMessage = inventorySummaryWork1._CallBackMessage != null && pJobInfo != null;
      try
      {
        if (isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage1 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage1.SiteID = pJobInfo.SiteID;
          jobEvtMessage1.Id = pJobInfo.Id;
          jobEvtMessage1.JobId = pJobInfo.JobId;
          jobEvtMessage1.Msg = inventorySummaryWork1.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.";
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage2 = jobEvtMessage1;
          inventorySummaryWork1._CallBackMessage(jobEvtMessage2.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        else
          Log.Logger.DebugColor(inventorySummaryWork1.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<InventorySummaryWork> list = await inventorySummaryWork1.SelectListAsync();
        if (list == null)
          throw new Exception("조회에러.\n" + inventorySummaryWork1.message);
        await inventorySummaryWork1.InventoryWorkCntLogAsync(inventorySummaryWork1.OleDB, pData);
        if (isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage3 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage3.SiteID = pJobInfo.SiteID;
          jobEvtMessage3.Id = pJobInfo.Id;
          jobEvtMessage3.JobId = pJobInfo.JobId;
          jobEvtMessage3.Msg = inventorySummaryWork1.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 해당 데이터 CLEAR 중 잠시만 ......";
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage4 = jobEvtMessage3;
          inventorySummaryWork1._CallBackMessage(jobEvtMessage4.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        else
          Log.Logger.DebugColor(inventorySummaryWork1.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + " 해당 데이터 CLEAR 중 잠시만 ......");
        if (!await inventorySummaryWork1.DataClearAsync((Hashtable) null))
          throw new Exception("작업 취소 처리.\n" + inventorySummaryWork1.message);
        int total = list.Count;
        int count = 0;
        int viewPro = 0;
        foreach (InventorySummaryWork inventorySummaryWork2 in (IEnumerable<InventorySummaryWork>) list)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          inventorySummaryWork2.SetAdoDatabase(inventorySummaryWork1.OleDB);
          if (inventorySummaryWork2.ivts_SiteID == 0L)
            inventorySummaryWork2.ivts_SiteID = inventorySummaryWork1.ivts_SiteID;
          inventorySummaryWork2.CalcEndQty();
          if (inventorySummaryWork2.ivts_IsStockUnitAmount)
          {
            inventorySummaryWork2.ivts_PreAdjustQty = 0.0;
            inventorySummaryWork2.ivts_PreAdjustCostAmt = 0.0;
            inventorySummaryWork2.ivts_PreAdjustCostVatAmt = 0.0;
            inventorySummaryWork2.ivts_PreAdjustPriceAmt = 0.0;
            inventorySummaryWork2.ivts_PreAdjustPriceVatAmt = 0.0;
            inventorySummaryWork2.ivts_EndQty = inventorySummaryWork2.ivts_PreAdjustQty;
            inventorySummaryWork2.ivts_EndCostAmt = inventorySummaryWork2.ivts_PreAdjustCostAmt;
            inventorySummaryWork2.ivts_EndCostVatAmt = inventorySummaryWork2.ivts_PreAdjustCostVatAmt;
            inventorySummaryWork2.ivts_EndPriceAmt = inventorySummaryWork2.ivts_PreAdjustPriceAmt;
            inventorySummaryWork2.ivts_EndPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_EndPriceAmt.ToPriceVat() : 0.0;
            inventorySummaryWork2.ivts_AdjustQty = 0.0;
            inventorySummaryWork2.ivts_AdjustCostAmt = 0.0;
            inventorySummaryWork2.ivts_AdjustCostVatAmt = 0.0;
            inventorySummaryWork2.ivts_AdjustPriceAmt = 0.0;
            inventorySummaryWork2.ivts_AdjustPriceVatAmt = 0.0;
            if (inventorySummaryWork2.ivts_EndCostAmt.IsZero() && inventorySummaryWork2.ivts_EndPriceAmt.IsZero())
              inventorySummaryWork2.ivts_EndQty = 0.0;
          }
          else
          {
            if (((inventorySummaryWork2.ivts_BaseAvgCost.IsZero() ? 0.0 : inventorySummaryWork2.ivts_BaseQty) + inventorySummaryWork2.ivts_BuyQty + inventorySummaryWork2.ivts_InnerMoveInQty + inventorySummaryWork2.ivts_OuterMoveInQty).IsZero())
            {
              inventorySummaryWork2.ivts_EndAvgCost = 0.0;
            }
            else
            {
              double dAmount = Math.Abs(inventorySummaryWork2.ivts_BaseQty * inventorySummaryWork2.ivts_BaseAvgCost) + Math.Abs(inventorySummaryWork2.ivts_BuyCostAmt) + Math.Abs(inventorySummaryWork2.ivts_InnerMoveInCostAmt) + Math.Abs(inventorySummaryWork2.ivts_OuterMoveInCostAmt);
              double dQty = Math.Abs(inventorySummaryWork2.ivts_BaseAvgCost.IsZero() ? 0.0 : inventorySummaryWork2.ivts_BaseQty) + Math.Abs(inventorySummaryWork2.ivts_BuyQty) + Math.Abs(inventorySummaryWork2.ivts_InnerMoveInQty) + Math.Abs(inventorySummaryWork2.ivts_OuterMoveInQty);
              inventorySummaryWork2.ivts_EndAvgCost = CalcHelper.ToArgCost3(dAmount, dQty);
            }
            if (!inventorySummaryWork2.ivts_PreAdjustQty.IsZero())
            {
              inventorySummaryWork2.ivts_PreAdjustCostAmt = inventorySummaryWork2.ivts_EndAvgCost * inventorySummaryWork2.ivts_PreAdjustQty;
              inventorySummaryWork2.ivts_PreAdjustPriceAmt = inventorySummaryWork2.ivts_EndPrice * inventorySummaryWork2.ivts_PreAdjustQty;
              if (inventorySummaryWork2.ivts_IsTax)
              {
                inventorySummaryWork2.ivts_PreAdjustCostVatAmt = inventorySummaryWork2.ivts_PreAdjustCostAmt.ToCostVat();
                inventorySummaryWork2.ivts_PreAdjustPriceVatAmt = inventorySummaryWork2.ivts_PreAdjustPriceAmt.ToPriceVat();
              }
              else
              {
                inventorySummaryWork2.ivts_PreAdjustCostVatAmt = 0.0;
                inventorySummaryWork2.ivts_PreAdjustPriceVatAmt = 0.0;
              }
            }
            else
            {
              inventorySummaryWork2.ivts_PreAdjustCostAmt = 0.0;
              inventorySummaryWork2.ivts_PreAdjustPriceAmt = 0.0;
              inventorySummaryWork2.ivts_PreAdjustCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_PreAdjustPriceVatAmt = 0.0;
            }
            if (!inventorySummaryWork2.ivts_DisuseQty.IsZero())
            {
              inventorySummaryWork2.ivts_DisuseCostAmt = inventorySummaryWork2.ivts_EndAvgCost * inventorySummaryWork2.ivts_DisuseQty;
              inventorySummaryWork2.ivts_DisusePriceAmt = inventorySummaryWork2.ivts_EndPrice * inventorySummaryWork2.ivts_DisuseQty;
              if (inventorySummaryWork2.ivts_IsTax)
              {
                inventorySummaryWork2.ivts_DisuseCostVatAmt = inventorySummaryWork2.ivts_DisuseCostAmt.ToCostVat();
                inventorySummaryWork2.ivts_DisusePriceVatAmt = inventorySummaryWork2.ivts_DisusePriceAmt.ToPriceVat();
              }
              else
              {
                inventorySummaryWork2.ivts_DisuseCostVatAmt = 0.0;
                inventorySummaryWork2.ivts_DisusePriceVatAmt = 0.0;
              }
            }
            else
            {
              inventorySummaryWork2.ivts_DisuseCostAmt = 0.0;
              inventorySummaryWork2.ivts_DisusePriceAmt = 0.0;
              inventorySummaryWork2.ivts_DisuseCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_DisusePriceVatAmt = 0.0;
            }
            if (!inventorySummaryWork2.ivts_AdjustQty.IsZero())
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = inventorySummaryWork2.ivts_EndAvgCost * inventorySummaryWork2.ivts_AdjustQty;
              inventorySummaryWork2.ivts_AdjustPriceAmt = inventorySummaryWork2.ivts_EndPrice * inventorySummaryWork2.ivts_AdjustQty;
              if (inventorySummaryWork2.ivts_IsTax)
              {
                inventorySummaryWork2.ivts_AdjustCostVatAmt = inventorySummaryWork2.ivts_AdjustCostAmt.ToCostVat();
                inventorySummaryWork2.ivts_AdjustPriceVatAmt = inventorySummaryWork2.ivts_AdjustPriceAmt.ToPriceVat();
              }
              else
              {
                inventorySummaryWork2.ivts_AdjustCostVatAmt = 0.0;
                inventorySummaryWork2.ivts_AdjustPriceVatAmt = 0.0;
              }
            }
            else
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceVatAmt = 0.0;
            }
            inventorySummaryWork2.ivts_EndCostAmt = inventorySummaryWork2.ivts_EndAvgCost * inventorySummaryWork2.ivts_EndQty;
            inventorySummaryWork2.ivts_EndPriceAmt = inventorySummaryWork2.ivts_EndPrice * inventorySummaryWork2.ivts_EndQty;
            if (inventorySummaryWork2.ivts_IsTax)
            {
              inventorySummaryWork2.ivts_EndCostVatAmt = inventorySummaryWork2.ivts_EndCostAmt.ToCostVat();
              inventorySummaryWork2.ivts_EndPriceVatAmt = inventorySummaryWork2.ivts_EndPriceAmt.ToPriceVat();
            }
            else
            {
              inventorySummaryWork2.ivts_EndCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_EndPriceVatAmt = 0.0;
            }
            inventorySummaryWork2.CalcEndPriceAmt();
          }
          inventorySummaryWork2.CalcTaxVat();
          inventorySummaryWork2.CalcEndPriceCostAmt();
          inventorySummaryWork2.CalcSaleProfit();
          inventorySummaryWork2.CalcSalePriceProfit();
          inventorySummaryWork2.CalcSalePriceUpDown();
          if (!inventorySummaryWork2.ivts_IsStockUnitAmount)
          {
            if (pData.WorkInfo.WorkData.iwc_AllWorkCnt == 0 && inventorySummaryWork2.ivts_IsInventory == 0)
              inventorySummaryWork2.ivts_InventoryQty = inventorySummaryWork2.ivts_EndQty;
            if (pData.WorkInfo.WorkData.iwc_AllWorkCnt == 0 && inventorySummaryWork2.ivts_IsInventory == 0 && pData.WorkInfo.WorkData.iwc_MinusToZeroWorkCnt > 0 && inventorySummaryWork2.ivts_InventoryQty < 0.0)
              inventorySummaryWork2.ivts_InventoryQty = 0.0;
            if (!inventorySummaryWork2.ivts_InventoryQty.IsZero())
            {
              inventorySummaryWork2.ivts_InventoryCostAmt = inventorySummaryWork2.ivts_InventoryQty * inventorySummaryWork2.ivts_EndAvgCost;
              inventorySummaryWork2.ivts_InventoryCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_InventoryCostAmt.ToCostVat() : 0.0;
              inventorySummaryWork2.ivts_InventoryPriceAmt = inventorySummaryWork2.ivts_InventoryQty * inventorySummaryWork2.ivts_EndPrice;
              inventorySummaryWork2.ivts_InventoryPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_InventoryPriceAmt.ToPriceVat() : 0.0;
              inventorySummaryWork2.ivts_InventoryPriceCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_InventoryPriceCostSumAmt.ToPriceVat() : 0.0;
            }
            else
            {
              inventorySummaryWork2.ivts_InventoryCostAmt = 0.0;
              inventorySummaryWork2.ivts_InventoryCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_InventoryPriceAmt = 0.0;
              inventorySummaryWork2.ivts_InventoryPriceVatAmt = 0.0;
              inventorySummaryWork2.ivts_InventoryPriceCostSumAmt = 0.0;
              inventorySummaryWork2.ivts_InventoryPriceCostVatAmt = 0.0;
            }
          }
          inventorySummaryWork2.ivts_LossQty = inventorySummaryWork2.ivts_InventoryQty - inventorySummaryWork2.ivts_EndQty;
          if (!inventorySummaryWork2.ivts_LossQty.IsZero())
          {
            inventorySummaryWork2.ivts_LossCostAmt = inventorySummaryWork2.ivts_LossQty * inventorySummaryWork2.ivts_EndAvgCost;
            inventorySummaryWork2.ivts_LossCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_LossCostAmt.ToCostVat() : 0.0;
            inventorySummaryWork2.ivts_LossPriceAmt = inventorySummaryWork2.ivts_LossQty * inventorySummaryWork2.ivts_EndPrice;
            inventorySummaryWork2.ivts_LossPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_LossPriceAmt.ToPriceVat() : 0.0;
            inventorySummaryWork2.ivts_LossPriceCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_LossPriceCostSumAmt.ToPriceVat() : 0.0;
            inventorySummaryWork2.ivts_LossPriceCostSumAmt = inventorySummaryWork2.ivts_InventoryPriceCostSumAmt - inventorySummaryWork2.ivts_EndPriceAmt;
            inventorySummaryWork2.ivts_LossPriceCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_LossPriceCostSumAmt.ToPriceVat() : 0.0;
          }
          else
          {
            inventorySummaryWork2.ivts_LossCostAmt = 0.0;
            inventorySummaryWork2.ivts_LossCostVatAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceVatAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceCostVatAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceCostSumAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceCostVatAmt = 0.0;
          }
          if (pData.WorkInfo.WorkData.iwc_AmountWorkCnt > 0 && inventorySummaryWork2.ivts_IsStockUnitAmount)
          {
            inventorySummaryWork2.ivts_EndQty = inventorySummaryWork2.ivts_InventoryQty;
            inventorySummaryWork2.ivts_EndCostAmt = inventorySummaryWork2.ivts_InventoryCostAmt;
            inventorySummaryWork2.ivts_EndCostVatAmt = inventorySummaryWork2.ivts_InventoryCostVatAmt;
            inventorySummaryWork2.ivts_EndPriceAmt = inventorySummaryWork2.ivts_InventoryPriceAmt;
            inventorySummaryWork2.ivts_EndPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_EndPriceAmt.ToPriceVat() : 0.0;
            inventorySummaryWork2.CalcSaleProfit();
            inventorySummaryWork2.CalcSalePriceProfit();
            inventorySummaryWork2.CalcSalePriceUpDown();
            inventorySummaryWork2.ivts_LossQty = 0.0;
            inventorySummaryWork2.ivts_LossCostAmt = 0.0;
            inventorySummaryWork2.ivts_LossCostVatAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceVatAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceCostSumAmt = 0.0;
            inventorySummaryWork2.ivts_LossPriceCostVatAmt = 0.0;
          }
          if (pData.WorkInfo.WorkData.iwc_QtyWorkCnt > 0 && inventorySummaryWork2.ivts_IsStockUnitQty)
          {
            inventorySummaryWork2.ivts_AdjustQty = inventorySummaryWork2.ivts_InventoryQty - inventorySummaryWork2.ivts_EndQty;
            if (!inventorySummaryWork2.ivts_AdjustQty.IsZero())
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = inventorySummaryWork2.ivts_AdjustQty * inventorySummaryWork2.ivts_EndAvgCost;
              inventorySummaryWork2.ivts_AdjustCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustCostAmt.ToCostVat() : 0.0;
              inventorySummaryWork2.ivts_AdjustPriceAmt = inventorySummaryWork2.ivts_AdjustQty * inventorySummaryWork2.ivts_EndPrice;
              inventorySummaryWork2.ivts_AdjustPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustPriceAmt.ToPriceVat() : 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostSumAmt = inventorySummaryWork2.ivts_InventoryPriceCostSumAmt - inventorySummaryWork2.ivts_EndPriceAmt;
              inventorySummaryWork2.ivts_AdjustPriceCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustPriceCostSumAmt.ToPriceVat() : 0.0;
            }
            else
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceVatAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostSumAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostVatAmt = 0.0;
            }
          }
          if (pData.WorkInfo.WorkData.iwc_WeightWorkCnt > 0 && inventorySummaryWork2.ivts_IsStockUnitWeight)
          {
            inventorySummaryWork2.ivts_AdjustQty = inventorySummaryWork2.ivts_InventoryQty - inventorySummaryWork2.ivts_EndQty;
            if (!inventorySummaryWork2.ivts_AdjustQty.IsZero())
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = inventorySummaryWork2.ivts_AdjustQty * inventorySummaryWork2.ivts_EndAvgCost;
              inventorySummaryWork2.ivts_AdjustCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustCostAmt.ToCostVat() : 0.0;
              inventorySummaryWork2.ivts_AdjustPriceAmt = inventorySummaryWork2.ivts_AdjustQty * inventorySummaryWork2.ivts_EndPrice;
              inventorySummaryWork2.ivts_AdjustPriceVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustPriceAmt.ToPriceVat() : 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostSumAmt = inventorySummaryWork2.ivts_InventoryPriceCostSumAmt - inventorySummaryWork2.ivts_EndPriceAmt;
              inventorySummaryWork2.ivts_AdjustPriceCostVatAmt = inventorySummaryWork2.ivts_IsTax ? inventorySummaryWork2.ivts_AdjustPriceCostSumAmt.ToPriceVat() : 0.0;
            }
            else
            {
              inventorySummaryWork2.ivts_AdjustCostAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustCostVatAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceVatAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostSumAmt = 0.0;
              inventorySummaryWork2.ivts_AdjustPriceCostVatAmt = 0.0;
            }
          }
          int num1 = await inventorySummaryWork2.ItemSaveAsync() ? 1 : 0;
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
              jobEvtProgressing1.Title = "지점 작업";
              jobEvtProgressing1.Msg = string.Format("{0} 작업중 ({1}/{2})", (object) viewPro, (object) count, (object) total);
              jobEvtProgressing1.ProgressValue = (double) viewPro / 100.0;
              JobEvtProgressing jobEvtProgressing2 = jobEvtProgressing1;
              inventorySummaryWork1._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        inventorySummaryWork1.message = " " + inventorySummaryWork1.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pJobInfo.SiteID;
          jobEvtMessageErr1.Id = pJobInfo.Id;
          jobEvtMessageErr1.JobId = pJobInfo.JobId;
          jobEvtMessageErr1.Msg = inventorySummaryWork1.TableCode.ToDescription() + (string.IsNullOrEmpty(pWorkDesc) ? string.Empty : "[" + pWorkDesc + "]") + "/n" + ex.Message;
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          inventorySummaryWork1._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(inventorySummaryWork1.message);
      }
      return false;
    }

    private async Task InventoryWorkCntLogAsync(UniOleDatabase pDB, JobEvtInventoryWork pData)
    {
      Log.Logger.DebugColor("\nLog 데이터 등록 중 잠시만 ......");
      string[] strArray = pData.WorkInfo.WorkStoreCodeIn.Split(',');
      for (int index = 0; index < strArray.Length; ++index)
      {
        string storeCode = strArray[index];
        InventoryWorkCntView inventoryWorkCntView1 = pDB.Create<InventoryWorkCntView>();
        DateTime? nullable1 = pData.WorkInfo.WorkInventoryDate;
        DateTime p_iwc_InventoryDate = nullable1.Value;
        int int32 = Convert.ToInt32(storeCode);
        long siteId = pData.SiteID;
        InventoryWorkCntView data = await inventoryWorkCntView1.SelectOneAsync(p_iwc_InventoryDate, int32, siteId);
        if (data != null)
        {
          nullable1 = data.iwc_InventoryDate;
          if (nullable1.HasValue)
          {
            data.DB_STATUS = EnumDBStatus.UPDATE;
            goto label_8;
          }
        }
        if (data == null)
          data = pDB.Create<InventoryWorkCntView>();
        InventoryWorkCntView inventoryWorkCntView2 = data;
        nullable1 = pData.WorkInfo.WorkInventoryDate;
        DateTime? nullable2 = new DateTime?(nullable1.Value);
        inventoryWorkCntView2.iwc_InventoryDate = nullable2;
        data.iwc_StoreCode = Convert.ToInt32(storeCode);
        data.iwc_SiteID = pData.SiteID;
        data.DB_STATUS = EnumDBStatus.NEW;
label_8:
        data.iwc_WorkCnt = 1;
        data.iwc_WorkDate = new DateTime?(DateTime.Now);
        data.iwc_WorkEmployee = pData.EmployeeInfo.emp_Code;
        if (pData.WorkInfo.WorkData.iwc_AmountWorkCnt > 0)
        {
          data.iwc_AmountWorkCnt = 1;
          data.iwc_AmountWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_AmountWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView3 = data;
          nullable1 = new DateTime?();
          DateTime? nullable3 = nullable1;
          inventoryWorkCntView3.iwc_AmountWorkDate = nullable3;
        }
        if (pData.WorkInfo.WorkData.iwc_QtyWorkCnt > 0)
        {
          data.iwc_QtyWorkCnt = 1;
          data.iwc_QtyWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_QtyWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView4 = data;
          nullable1 = new DateTime?();
          DateTime? nullable4 = nullable1;
          inventoryWorkCntView4.iwc_QtyWorkDate = nullable4;
        }
        if (pData.WorkInfo.WorkData.iwc_WeightWorkCnt > 0)
        {
          data.iwc_WeightWorkCnt = 1;
          data.iwc_WeightWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_WeightWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView5 = data;
          nullable1 = new DateTime?();
          DateTime? nullable5 = nullable1;
          inventoryWorkCntView5.iwc_WeightWorkDate = nullable5;
        }
        if (pData.WorkInfo.WorkData.iwc_AllWorkCnt > 0)
        {
          data.iwc_AllWorkCnt = 1;
          data.iwc_AllWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_AllWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView6 = data;
          nullable1 = new DateTime?();
          DateTime? nullable6 = nullable1;
          inventoryWorkCntView6.iwc_AllWorkDate = nullable6;
        }
        if (pData.WorkInfo.WorkData.iwc_MinusToZeroWorkCnt > 0)
        {
          data.iwc_MinusToZeroWorkCnt = 1;
          data.iwc_MinusToZeroWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_MinusToZeroWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView7 = data;
          nullable1 = new DateTime?();
          DateTime? nullable7 = nullable1;
          inventoryWorkCntView7.iwc_MinusToZeroWorkDate = nullable7;
        }
        if (pData.WorkInfo.WorkData.iwc_PoorToZeroWorkCnt > 0)
        {
          data.iwc_PoorToZeroWorkCnt = 1;
          data.iwc_PoorToZeroWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_PoorToZeroWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView8 = data;
          nullable1 = new DateTime?();
          DateTime? nullable8 = nullable1;
          inventoryWorkCntView8.iwc_PoorToZeroWorkDate = nullable8;
        }
        if (pData.WorkInfo.WorkData.iwc_UnRegToZeroWorkCnt > 0)
        {
          data.iwc_UnRegToZeroWorkCnt = 1;
          data.iwc_UnRegToZeroWorkDate = pData.WorkInfo.WorkInventoryDate;
        }
        else
        {
          data.iwc_UnRegToZeroWorkCnt = 0;
          InventoryWorkCntView inventoryWorkCntView9 = data;
          nullable1 = new DateTime?();
          DateTime? nullable9 = nullable1;
          inventoryWorkCntView9.iwc_UnRegToZeroWorkDate = nullable9;
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
        data = (InventoryWorkCntView) null;
        storeCode = (string) null;
      }
      strArray = (string[]) null;
    }

    public async Task<IList<InventorySummaryWork>> SelectListAsync()
    {
      InventorySummaryWork inventorySummaryWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventorySummaryWork1.OleDB.ConnectionUrl, pCommandTimeout: 180);
        rs = new UniOleDbRecordset(db, inventorySummaryWork1.OleDB.CommandTimeout);
        if (inventorySummaryWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + inventorySummaryWork1.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(inventorySummaryWork1.message);
        }
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "ivts_SiteID", (object) inventorySummaryWork1.ivts_SiteID);
        p_param.Add((object) "ivts_YyyyMm", (object) inventorySummaryWork1.ivts_YyyyMm);
        p_param.Add((object) "ivts_Day", (object) inventorySummaryWork1.ivts_Day);
        if (string.IsNullOrEmpty(inventorySummaryWork1.WorkStoreCodeIn))
          p_param.Add((object) "ivts_StoreCode", (object) inventorySummaryWork1.ivts_StoreCode);
        else
          p_param.Add((object) "ivts_StoreCode_IN_", (object) inventorySummaryWork1.WorkStoreCodeIn);
        p_param.Add((object) "WorkInventoryDate", (object) inventorySummaryWork1.WorkInventoryDate.Value);
        p_param.Add((object) "ivts_YyyyMmBefore", (object) inventorySummaryWork1.ivts_YyyyMmBefore);
        if (!await rs.OpenAsync(inventorySummaryWork1.GetSelectQuery((object) p_param)))
        {
          inventorySummaryWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventorySummaryWork>) null;
        }
        IList<InventorySummaryWork> lt_list = (IList<InventorySummaryWork>) new List<InventorySummaryWork>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventorySummaryWork inventorySummaryWork2 = inventorySummaryWork1.OleDB.Create<InventorySummaryWork>();
            if (inventorySummaryWork2.GetFieldValues(rs))
            {
              inventorySummaryWork2.row_number = lt_list.Count + 1;
              lt_list.Add(inventorySummaryWork2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventorySummaryWork> SelectEnumerableAsync()
    {
      InventorySummaryWork inventorySummaryWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventorySummaryWork1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventorySummaryWork1.OleDB.CommandTimeout);
        if (inventorySummaryWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + inventorySummaryWork1.message + "\n--------------------------------------------------------------------------------------------------");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else
        {
          Hashtable p_param = new Hashtable();
          p_param.Add((object) "ivts_SiteID", (object) inventorySummaryWork1.ivts_SiteID);
          p_param.Add((object) "ivts_YyyyMm", (object) inventorySummaryWork1.ivts_YyyyMm);
          p_param.Add((object) "ivts_Day", (object) inventorySummaryWork1.ivts_Day);
          p_param.Add((object) "ivts_StoreCode", (object) inventorySummaryWork1.ivts_StoreCode);
          if (string.IsNullOrEmpty(inventorySummaryWork1.WorkStoreCodeIn))
            p_param.Add((object) "ivts_StoreCode", (object) inventorySummaryWork1.ivts_StoreCode);
          else
            p_param.Add((object) "ivts_StoreCode_IN_", (object) inventorySummaryWork1.WorkStoreCodeIn);
          p_param.Add((object) "ivts_YyyyMmBefore", (object) inventorySummaryWork1.ivts_YyyyMmBefore);
          if (!await rs.OpenAsync(inventorySummaryWork1.GetSelectQuery((object) p_param)))
          {
            inventorySummaryWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventorySummaryWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
            // ISSUE: reference to a compiler-generated field
            this.\u003C\u003Ew__disposeMode = true;
          }
          else if (await rs.IsDataReadAsync())
          {
            int row_number = 0;
            do
            {
              InventorySummaryWork inventorySummaryWork2 = inventorySummaryWork1.OleDB.Create<InventorySummaryWork>();
              if (inventorySummaryWork2.GetFieldValues(rs))
              {
                inventorySummaryWork2.row_number = ++row_number;
                yield return inventorySummaryWork2;
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
        double fieldDouble = p_rs.GetFieldDouble("gdh_SalePrice");
        if (!fieldDouble.IsZero())
          this.ivts_EndPrice = fieldDouble;
        else
          this.ivts_EndPrice = p_rs.GetFieldDouble("gdh_SalePrice");
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
          if (hashtable2.ContainsKey((object) "ivts_SiteID") && Convert.ToInt64(hashtable2[(object) "ivts_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "ivts_SiteID"].ToString());
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
        stringBuilder.Append(this.ToWithWorkAdjustDayQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkAdjustDayAmountQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkDisuseQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkInventoryQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\nSELECT" + string.Format(" {0} AS {1},{2} AS {3}", (object) this.ivts_YyyyMm, (object) "ivts_YyyyMm", (object) this.ivts_Day, (object) "ivts_Day") + ",ivts_StoreCode,ivts_GoodsCode,ivts_SiteID,gdh_Supplier AS ivts_Supplier,su_SupplierType AS ivts_SupplierType,gdh_GoodsCategory AS ivts_CategoryCode,gd_TaxDiv AS ivts_TaxDiv,gd_StockUnit AS ivts_StockUnit,gd_SalesUnit AS ivts_SalesUnit");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\n,0 AS ivts_PriceUp,0 AS ivts_PriceUpVat,0 AS ivts_PriceDown,0 AS ivts_PriceDownVat");
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\n,gdh_SalePrice,gdh_EventPrice");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  MAX(WorkInventoryDate) AS WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.SubCol);
        stringBuilder.Append("\n,MAX(db_status) AS db_status");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyStartCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyEndCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyEndTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodySaleCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodySaleTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyBuyCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyBuyTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyReturnCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyReturnTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyInnerMoveOutCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyInnerMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyInnerMoveInCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyInnerMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyOuterMoveOutCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyOuterMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyOuterMoveInCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyOuterMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyAdjustCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyAdjustTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyAdjustCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyAdjustDayTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyAdjustCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyAdjustDayAmountTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyDisuseCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyDisuseTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(TInventorySummary.TBodyInventoryCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyInventoryTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY ivts_StoreCode,ivts_GoodsCode");
        stringBuilder.Append(",ivts_SiteID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\n INNER JOIN T_HISTORY ON ivts_StoreCode=gdh_StoreCode AND ivts_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND ivts_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND ivts_SiteID=su_SiteID\n INNER JOIN T_CATEGORY ON gdh_GoodsCategory=ctg_ID AND ivts_SiteID=ctg_SiteID AND ctg_DepositYn='N'\n INNER JOIN T_STATE_GOODS ON ivts_GoodsCode=gd_GoodsCode AND ivts_SiteID=gd_SiteID");
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ivts_StoreCode,ivts_GoodsCode");
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
        stringBuilder.Append("\n,T_STATE_GOODS AS ( SELECT  gd_GoodsCode,gd_SiteID,gd_TaxDiv,gd_SalesUnit,gd_StockUnit" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
        stringBuilder.Append("\n,TBodyStartTable AS (\nSELECT " + this.WorkFirstDay.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'").ToDateTime() + " AS WorkInventoryDate,pls_StoreCode AS ivts_StoreCode,pls_GoodsCode AS ivts_GoodsCode,pls_SiteID AS ivts_SiteID,pls_EndQty AS ivts_BaseQty,pls_EndAvgCost AS ivts_BaseAvgCost,pls_EndCostAmt AS ivts_BaseCostAmt,pls_EndCostVatAmt AS ivts_BaseCostVatAmt,pls_EndPrice AS ivts_BasePrice,pls_EndPriceCostAmt AS ivts_BasePriceCostAmt,pls_EndPriceCostVatAmt AS ivts_BasePriceCostVatAmt,pls_EndPriceAmt AS ivts_BasePriceAmt,pls_EndPriceVatAmt AS ivts_BasePriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "pls_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_YyyyMmBefore"))
            p_param1.Add((object) "pls_YyyyMm", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "pls_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pls_YyyyMm"))
            p_param1.Add((object) "pls_YyyyMm", (object) this.ivts_YyyyMmBefore);
          if (!p_param1.ContainsKey((object) "pls_StoreCode") && !p_param1.ContainsKey((object) "pls_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode", (object) this.ivts_StoreCode);
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pls_YyyyMm", (object) this.ivts_YyyyMmBefore));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_StoreCode", (object) this.ivts_StoreCode));
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
        stringBuilder.Append("\n,TBodyEndTable AS (\nSELECT " + this.WorkFirstDay.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'").ToDateTime() + " AS WorkInventoryDate,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt" + string.Format(",{0} AS {1}", (object) 2, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.InventorySummary, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_YyyyMm"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_Day"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "ivts_SiteID"))
            p_param1.Add((object) "ivts_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "ivts_YyyyMm"))
            p_param1.Add((object) "ivts_YyyyMm", (object) this.ivts_YyyyMm);
          if (!p_param1.ContainsKey((object) "ivts_Day"))
            p_param1.Add((object) "ivts_Day", (object) this.ivts_Day);
          if (!p_param1.ContainsKey((object) "ivts_StoreCode") && !p_param1.ContainsKey((object) "ivts_StoreCode_IN_"))
            p_param1.Add((object) "ivts_StoreCode", (object) this.ivts_StoreCode);
          stringBuilder.Append(new TInventorySummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "ivts_YyyyMm", (object) this.ivts_YyyyMm));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ivts_Day", (object) this.ivts_Day));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ivts_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ivts_SiteID", (object) p_SiteID));
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
        stringBuilder.Append("\n,TBodySaleTable AS (\nSELECT sbd_SaleDate AS WorkInventoryDate,sbd_StoreCode AS ivts_StoreCode,sbd_GoodsCode AS ivts_GoodsCode,sbd_SiteID AS ivts_SiteID,SUM(sbd_SaleQty) AS ivts_SaleQty,SUM(sbd_TotalSaleAmt) AS ivts_TotalSaleAmt,SUM(sbd_SaleAmt) AS ivts_SaleAmt,SUM(sbd_SaleVatAmt) AS ivts_SaleVatAmt,SUM(sbd_ProfitAmt) AS ivts_SaleProfit,SUM(sbd_ProfitAmt) AS ivts_SalePriceProfit,SUM(sbd_EnurySlip) AS ivts_EnurySlip,SUM(sbd_EnuryEnd) AS ivts_EnuryEnd,SUM(sbd_DcAmtManual) AS ivts_DcAmtManual,SUM(sbd_DcAmtEvent) AS ivts_DcAmtEvent,SUM(sbd_DcAmtGoods) AS ivts_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS ivts_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS ivts_DcAmtPromotion,SUM(sbd_DcAmtMember) AS ivts_DcAmtMember,SUM(sbd_SlipCustomer) AS ivts_Customer,SUM(sbd_GoodsCustomer) AS ivts_CustomerGoods,SUM(sbd_CategoryCustomer) AS ivts_CustomerCategory,SUM(sbd_SupplierCustomer) AS ivts_CustomerSupplier,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sbd_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append("\nGROUP BY sbd_SaleDate,sbd_StoreCode,sbd_GoodsCode,sbd_SiteID");
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
        stringBuilder.Append("\n,TBodyBuyTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_BuyQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_BuyCostAmt,SUM(sd_CostVatAmt) AS ivts_BuyCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_BuyPriceAmt,SUM(sd_PriceVatAmt) AS ivts_BuyPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", (object) 1));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyReturnTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_ReturnQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_ReturnCostAmt,SUM(sd_CostVatAmt) AS ivts_ReturnCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_ReturnPriceAmt,SUM(sd_PriceVatAmt) AS ivts_ReturnPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", (object) 1));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyInnerMoveOutTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_InnerMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_InnerMoveOutCostAmt,SUM(sd_CostVatAmt) AS ivts_InnerMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_InnerMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS ivts_InnerMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 3));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyInnerMoveInTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_InnerMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_InnerMoveInCostAmt,SUM(sd_CostVatAmt) AS ivts_InnerMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_InnerMoveInPriceAmt,SUM(sd_PriceVatAmt) AS ivts_InnerMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 3));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyOuterMoveOutTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_OuterMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_OuterMoveOutCostAmt,SUM(sd_CostVatAmt) AS ivts_OuterMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_OuterMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS ivts_OuterMoveOutPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) -1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 4));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyOuterMoveInTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty) AS ivts_OuterMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS ivts_OuterMoveInCostAmt,SUM(sd_CostVatAmt) AS ivts_OuterMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS ivts_OuterMoveInPriceAmt,SUM(sd_PriceVatAmt) AS ivts_OuterMoveInPriceVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 4));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyAdjustTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty*sh_InOutDiv) AS ivts_PreAdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS ivts_PreAdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS ivts_PreAdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS ivts_PreAdjustPriceCostSumAmt,SUM(0) AS ivts_PreAdjustPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format(" AND {0}!={1}", (object) "sd_StockUnit", (object) 1) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, 0, -1));
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay.Value.GetDateAdd(0, 0, -1));
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 5);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <'" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 5));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkAdjustDayQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyAdjustDayTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty*sh_InOutDiv) AS ivts_PreAdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS ivts_PreAdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS ivts_PreAdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS ivts_PreAdjustPriceCostSumAmt,SUM(0) AS ivts_PreAdjustPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format(" AND {0}!={1}", (object) "sd_StockUnit", (object) 1) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
          {
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
          }
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 5);
          if (!p_param1.ContainsKey((object) "sh_DeviceType_IS_NOT_EQUALS_"))
            p_param1.Add((object) "sh_DeviceType_IS_NOT_EQUALS_", (object) 6);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 5));
          stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "sh_DeviceType", (object) 6));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkAdjustDayAmountQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyAdjustDayAmountTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty*sh_InOutDiv) AS ivts_PreAdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS ivts_PreAdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS ivts_PreAdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS ivts_PreAdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS ivts_PreAdjustPriceCostSumAmt,SUM(0) AS ivts_PreAdjustPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format(" AND {0}={1}", (object) "sd_StockUnit", (object) 1) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
          {
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
          }
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkLastDay);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 5));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
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
        stringBuilder.Append("\n,TBodyDisuseTable AS (\nSELECT sh_ConfirmDate AS WorkInventoryDate,sh_StoreCode AS ivts_StoreCode,sd_GoodsCode AS ivts_GoodsCode,sh_SiteID AS ivts_SiteID,SUM(sd_BuyQty*sh_InOutDiv*-1) AS ivts_DisuseQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv*-1) AS ivts_DisuseCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv*-1) AS ivts_DisuseCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv*-1) AS ivts_DisusePriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv*-1) AS ivts_DisusePriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*-1*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv*-1 END) AS ivts_DisusePriceCostSumAmt,SUM(0) AS ivts_DisusePriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
            p_param1.Add((object) "sh_StoreCode", (object) this.ivts_StoreCode);
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
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND sh_ConfirmDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sh_ConfirmDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 6));
        }
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode,sd_GoodsCode,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkInventoryQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyInventoryTable AS (\nSELECT ih_InventoryDate AS WorkInventoryDate,ih_StoreCode AS ivts_StoreCode,id_GoodsCode AS ivts_GoodsCode,ih_SiteID AS ivts_SiteID,SUM(id_InventoryQty) AS ivts_InventoryQty,SUM(id_InventoryCostAmt) AS ivts_InventoryCostAmt,SUM(id_InventoryCostVatAmt) AS ivts_InventoryCostVatAmt,SUM(id_InventoryPriceAmt) AS ivts_InventoryPriceAmt,SUM(0) AS ivts_InventoryPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "id_StockUnit", (object) 2) + " THEN id_InventoryQty*gdh_SalePrice ELSE (id_InventoryPriceAmt) END) AS ivts_InventoryPriceCostSumAmt,SUM(0) AS ivts_InventoryPriceCostVatAmt,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.InventoryHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.InventoryDetail, (object) DbQueryHelper.ToWithNolock()) + " ON ih_StatementNo=id_StatementNo AND ih_SiteID=id_SiteID" + string.Format(" AND {0}!={1}", (object) "id_PackUnit", (object) 4) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON ih_StoreCode=gdh_StoreCode AND id_GoodsCode=gdh_GoodsCode AND ih_InventoryDate>=gdh_StartDate AND ih_InventoryDate<=gdh_EndDate AND ih_SiteID=gdh_SiteID\n INNER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 1));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "ih_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "ih_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
            p_param1.Add((object) "ih_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
          {
            p_param1.Add((object) "ih_InventoryDate_BEGIN_", dictionaryEntry.Value);
            p_param1.Add((object) "ih_InventoryDate_END_", dictionaryEntry.Value);
          }
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "ih_SiteID"))
            p_param1.Add((object) "ih_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "ih_StoreCode") && !p_param1.ContainsKey((object) "ih_StoreCode_IN_"))
            p_param1.Add((object) "ih_StoreCode", (object) this.ivts_StoreCode);
          if (!p_param1.ContainsKey((object) "ih_InventoryDate_BEGIN_"))
            p_param1.Add((object) "ih_InventoryDate_BEGIN_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "ih_InventoryDate_END_"))
            p_param1.Add((object) "ih_InventoryDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "ih_InventoryStatus"))
            p_param1.Add((object) "ih_InventoryStatus", (object) 1);
          stringBuilder.Append(new TInventoryHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ih_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StoreCode", (object) this.ivts_StoreCode));
          stringBuilder.Append(" AND ih_InventoryDate >='" + this.WorkFirstDay.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ih_InventoryDate <='" + this.WorkLastDay.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_InventoryStatus", (object) 1));
        }
        stringBuilder.Append("\nGROUP BY ih_InventoryDate,ih_StoreCode,id_GoodsCode,ih_SiteID");
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
