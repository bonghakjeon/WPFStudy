// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Diff.SalesByDayDiffStore
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Diff
{
  public class SalesByDayDiffStore : TSalesByDay<SalesByDayDiffStore>
  {
    private int _rowDataType;
    private int _sbd_SaleDays;
    private double _sbd_GoalAmount;
    private double _sbd_GoalProfitAmount;
    private double _sbd_SaleQtyRule;
    private double _sbd_SaleAmtRule;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private SalesByDayDiff _DayInfo;
    private SalesByDayDiff _WeekInfo;
    private SalesByDayDiff _MonthInfo;
    private SalesByDayDiff _YearInfo;
    protected const string _ColDay = "_Day";
    protected const string _ColWeek = "_Week";
    protected const string _ColMonth = "_Month";
    protected const string _ColYear = "_Year";

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == 3;

    public int sbd_SaleDays
    {
      get => this._sbd_SaleDays;
      set
      {
        this._sbd_SaleDays = value;
        this.Changed(nameof (sbd_SaleDays));
      }
    }

    public double sbd_GoalAmount
    {
      get => this._sbd_GoalAmount;
      set
      {
        this._sbd_GoalAmount = value;
        this.Changed(nameof (sbd_GoalAmount));
      }
    }

    public double sbd_GoalProfitAmount
    {
      get => this._sbd_GoalProfitAmount;
      set
      {
        this._sbd_GoalProfitAmount = value;
        this.Changed(nameof (sbd_GoalProfitAmount));
      }
    }

    public double sbd_SaleQtyRule
    {
      get => this._sbd_SaleQtyRule;
      set
      {
        this._sbd_SaleQtyRule = value;
        this.Changed(nameof (sbd_SaleQtyRule));
      }
    }

    public double sbd_SaleAmtRule
    {
      get => this._sbd_SaleAmtRule;
      set
      {
        this._sbd_SaleAmtRule = value;
        this.Changed(nameof (sbd_SaleAmtRule));
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

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public override double sbd_SaleQty
    {
      get => this._sbd_SaleQty;
      set
      {
        this._sbd_SaleQty = value;
        this.Changed(nameof (sbd_SaleQty));
        this.Changed("sbd_SaleQtyDayDiff");
        this.Changed("sbd_SaleQtyWeekDiff");
        this.Changed("sbd_SaleQtyMonthDiff");
        this.Changed("sbd_SaleQtyYearDiff");
      }
    }

    public override double sbd_SaleAmt
    {
      get => this._sbd_SaleAmt;
      set
      {
        this._sbd_SaleAmt = value;
        this.Changed(nameof (sbd_SaleAmt));
        this.Changed("sbd_SaleAmtDayDiff");
        this.Changed("sbd_SaleAmtWeekDiff");
        this.Changed("sbd_SaleAmtMonthDiff");
        this.Changed("sbd_SaleAmtYearDiff");
      }
    }

    [JsonIgnore]
    public SalesByDayDiff DayInfo
    {
      get => this._DayInfo ?? (this._DayInfo = new SalesByDayDiff());
      set
      {
        this._DayInfo = value;
        this.Changed(nameof (DayInfo));
        this.Changed("sbd_SaleQtyDay");
        this.Changed("sbd_SaleQtyDayDiff");
        this.Changed("sbd_SaleAmtDay");
        this.Changed("sbd_SaleAmtDayDiff");
      }
    }

    public double sbd_SaleQtyDay => this.DayInfo.sbd_SaleQty;

    public double sbd_SaleQtyDayDiff => this.sbd_SaleQty - this.DayInfo.sbd_SaleQty;

    public double sbd_SaleAmtDay => this.DayInfo.sbd_SaleAmt;

    public double sbd_SaleAmtDayDiff => this.sbd_SaleAmt - this.DayInfo.sbd_SaleAmt;

    [JsonIgnore]
    public SalesByDayDiff WeekInfo
    {
      get => this._WeekInfo ?? (this._WeekInfo = new SalesByDayDiff());
      set
      {
        this._WeekInfo = value;
        this.Changed(nameof (WeekInfo));
        this.Changed("sbd_SaleQtyWeek");
        this.Changed("sbd_SaleQtyWeekDiff");
        this.Changed("sbd_SaleAmtWeek");
        this.Changed("sbd_SaleAmtWeekDiff");
      }
    }

    public double sbd_SaleQtyWeek => this.WeekInfo.sbd_SaleQty;

    public double sbd_SaleQtyWeekDiff => this.sbd_SaleQty - this.WeekInfo.sbd_SaleQty;

    public double sbd_SaleAmtWeek => this.WeekInfo.sbd_SaleAmt;

    public double sbd_SaleAmtWeekDiff => this.sbd_SaleAmt - this.WeekInfo.sbd_SaleAmt;

    [JsonIgnore]
    public SalesByDayDiff MonthInfo
    {
      get => this._MonthInfo ?? (this._MonthInfo = new SalesByDayDiff());
      set
      {
        this._MonthInfo = value;
        this.Changed(nameof (MonthInfo));
        this.Changed("sbd_SaleQtyMonth");
        this.Changed("sbd_SaleQtyMonthDiff");
        this.Changed("sbd_SaleAmtMonth");
        this.Changed("sbd_SaleAmtMonthDiff");
      }
    }

    public double sbd_SaleQtyMonth => this.MonthInfo.sbd_SaleQty;

    public double sbd_SaleQtyMonthDiff => this.sbd_SaleQty - this.MonthInfo.sbd_SaleQty;

    public double sbd_SaleAmtMonth => this.WeekInfo.sbd_SaleAmt;

    public double sbd_SaleAmtMonthDiff => this.sbd_SaleAmt - this.MonthInfo.sbd_SaleAmt;

    [JsonIgnore]
    public SalesByDayDiff YearInfo
    {
      get => this._YearInfo ?? (this._YearInfo = new SalesByDayDiff());
      set
      {
        this._YearInfo = value;
        this.Changed(nameof (YearInfo));
        this.Changed("sbd_SaleQtyYear");
        this.Changed("sbd_SaleQtyYearDiff");
        this.Changed("sbd_SaleAmtYear");
        this.Changed("sbd_SaleAmtYearDiff");
      }
    }

    public double sbd_SaleQtyYear => this.YearInfo.sbd_SaleQty;

    public double sbd_SaleQtyYearDiff => this.sbd_SaleQty - this.YearInfo.sbd_SaleQty;

    public double sbd_SaleAmtYear => this.YearInfo.sbd_SaleAmt;

    public double sbd_SaleAmtYearDiff => this.sbd_SaleAmt - this.YearInfo.sbd_SaleAmt;

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.sbd_SaleDays = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.sbd_GoalAmount = this.sbd_SaleQtyRule = this.sbd_SaleAmtRule = 0.0;
      this.DayInfo = (SalesByDayDiff) null;
      this.WeekInfo = (SalesByDayDiff) null;
      this.MonthInfo = (SalesByDayDiff) null;
      this.YearInfo = (SalesByDayDiff) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByDayDiffStore();

    public override object Clone()
    {
      SalesByDayDiffStore salesByDayDiffStore = base.Clone() as SalesByDayDiffStore;
      salesByDayDiffStore.rowDataType = this.rowDataType;
      salesByDayDiffStore.sbd_SaleDays = this.sbd_SaleDays;
      salesByDayDiffStore.si_StoreName = this.si_StoreName;
      salesByDayDiffStore.si_StoreViewCode = this.si_StoreViewCode;
      salesByDayDiffStore.si_UseYn = this.si_UseYn;
      salesByDayDiffStore.si_StoreType = this.si_StoreType;
      salesByDayDiffStore.sbd_GoalAmount = this.sbd_GoalAmount;
      salesByDayDiffStore.sbd_SaleQtyRule = this.sbd_SaleQtyRule;
      salesByDayDiffStore.sbd_SaleAmtRule = this.sbd_SaleAmtRule;
      salesByDayDiffStore.DayInfo = this.DayInfo;
      salesByDayDiffStore.WeekInfo = this.WeekInfo;
      salesByDayDiffStore.MonthInfo = this.MonthInfo;
      salesByDayDiffStore.YearInfo = this.YearInfo;
      return (object) salesByDayDiffStore;
    }

    public void PutData(SalesByDayDiffStore pSource)
    {
      this.PutData((TSalesByDay) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sbd_SaleDays = pSource.sbd_SaleDays;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.sbd_GoalAmount = pSource.sbd_GoalAmount;
      this.sbd_SaleQtyRule = pSource.sbd_SaleQtyRule;
      this.sbd_SaleAmtRule = pSource.sbd_SaleAmtRule;
      this.DayInfo.PutData(pSource.DayInfo);
      this.WeekInfo.PutData(pSource.WeekInfo);
      this.MonthInfo.PutData(pSource.MonthInfo);
      this.YearInfo.PutData(pSource.YearInfo);
    }

    public bool CalcAddSum(SalesByDayDiffStore pSource)
    {
      if (pSource == null || !this.CalcAddSum((TSalesByDay) pSource))
        return false;
      this.sbd_GoalAmount += pSource.sbd_GoalAmount;
      this.DayInfo.CalcAddSum(pSource.DayInfo);
      this.WeekInfo.CalcAddSum(pSource.WeekInfo);
      this.MonthInfo.CalcAddSum(pSource.MonthInfo);
      this.YearInfo.CalcAddSum(pSource.YearInfo);
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SalesByDayDiffStore pSource) => pSource == null || this.IsZero(pCheckType, (TSalesByDay) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_GoalAmount.IsZero()) && this.DayInfo.IsZero(pCheckType) && this.WeekInfo.IsZero(pCheckType) && this.MonthInfo.IsZero(pCheckType) && this.YearInfo.IsZero(pCheckType);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        this.sbd_GoalAmount = p_rs.GetFieldDouble("sbd_GoalAmount");
        if (p_rs.IsFieldName("sbd_SaleQty_Day"))
        {
          this.DayInfo.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer_Day");
          this.DayInfo.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer_Day");
          this.DayInfo.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer_Day");
          this.DayInfo.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer_Day");
          this.DayInfo.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty_Day");
          this.DayInfo.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty_Day");
          this.DayInfo.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods_Day");
          this.DayInfo.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent_Day");
          this.DayInfo.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon_Day");
          this.DayInfo.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion_Day");
          this.DayInfo.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual_Day");
          this.DayInfo.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember_Day");
          this.DayInfo.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip_Day");
          this.DayInfo.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd_Day");
          this.DayInfo.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit_Day");
          this.DayInfo.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt_Day");
          this.DayInfo.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt_Day");
          this.DayInfo.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt_Day");
          this.DayInfo.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt_Day");
          this.DayInfo.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt_Day");
          this.DayInfo.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt_Day");
          this.DayInfo.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt_Day");
          this.DayInfo.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint_Day");
          this.DayInfo.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash_Day");
          this.DayInfo.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard_Day");
          this.DayInfo.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc_Day");
        }
        if (p_rs.IsFieldName("sbd_SaleQty_Week"))
        {
          this.DayInfo.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer_Week");
          this.DayInfo.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer_Week");
          this.DayInfo.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer_Week");
          this.DayInfo.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer_Week");
          this.DayInfo.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty_Week");
          this.DayInfo.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty_Week");
          this.DayInfo.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods_Week");
          this.DayInfo.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent_Week");
          this.DayInfo.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon_Week");
          this.DayInfo.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion_Week");
          this.DayInfo.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual_Week");
          this.DayInfo.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember_Week");
          this.DayInfo.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip_Week");
          this.DayInfo.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd_Week");
          this.DayInfo.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit_Week");
          this.DayInfo.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt_Week");
          this.DayInfo.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt_Week");
          this.DayInfo.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt_Week");
          this.DayInfo.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt_Week");
          this.DayInfo.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt_Week");
          this.DayInfo.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt_Week");
          this.DayInfo.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt_Week");
          this.DayInfo.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint_Week");
          this.DayInfo.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash_Week");
          this.DayInfo.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard_Week");
          this.DayInfo.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc_Week");
        }
        if (p_rs.IsFieldName("sbd_SaleQty_Month"))
        {
          this.DayInfo.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer_Month");
          this.DayInfo.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer_Month");
          this.DayInfo.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer_Month");
          this.DayInfo.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer_Month");
          this.DayInfo.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty_Month");
          this.DayInfo.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty_Month");
          this.DayInfo.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods_Month");
          this.DayInfo.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent_Month");
          this.DayInfo.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon_Month");
          this.DayInfo.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion_Month");
          this.DayInfo.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual_Month");
          this.DayInfo.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember_Month");
          this.DayInfo.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip_Month");
          this.DayInfo.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd_Month");
          this.DayInfo.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit_Month");
          this.DayInfo.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt_Month");
          this.DayInfo.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt_Month");
          this.DayInfo.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt_Month");
          this.DayInfo.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt_Month");
          this.DayInfo.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt_Month");
          this.DayInfo.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt_Month");
          this.DayInfo.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt_Month");
          this.DayInfo.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint_Month");
          this.DayInfo.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash_Month");
          this.DayInfo.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard_Month");
          this.DayInfo.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc_Month");
        }
        if (p_rs.IsFieldName("sbd_SaleQty_Year"))
        {
          this.DayInfo.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer_Year");
          this.DayInfo.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer_Year");
          this.DayInfo.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer_Year");
          this.DayInfo.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer_Year");
          this.DayInfo.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty_Year");
          this.DayInfo.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty_Year");
          this.DayInfo.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods_Year");
          this.DayInfo.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent_Year");
          this.DayInfo.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon_Year");
          this.DayInfo.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion_Year");
          this.DayInfo.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual_Year");
          this.DayInfo.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember_Year");
          this.DayInfo.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip_Year");
          this.DayInfo.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd_Year");
          this.DayInfo.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit_Year");
          this.DayInfo.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt_Year");
          this.DayInfo.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt_Year");
          this.DayInfo.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt_Year");
          this.DayInfo.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt_Year");
          this.DayInfo.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt_Year");
          this.DayInfo.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt_Year");
          this.DayInfo.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt_Year");
          this.DayInfo.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint_Year");
          this.DayInfo.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash_Year");
          this.DayInfo.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard_Year");
          this.DayInfo.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc_Year");
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

    public async Task<IList<SalesByDayDiffStore>> SelectDateStoreListAsync(object p_param)
    {
      SalesByDayDiffStore salesByDayDiffStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByDayDiffStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByDayDiffStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByDayDiffStore1.GetSelectQuery(p_param)))
        {
          salesByDayDiffStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayDiffStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByDayDiffStore>) null;
        }
        IList<SalesByDayDiffStore> lt_list = (IList<SalesByDayDiffStore>) new List<SalesByDayDiffStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByDayDiffStore salesByDayDiffStore2 = salesByDayDiffStore1.OleDB.Create<SalesByDayDiffStore>();
            if (salesByDayDiffStore2.GetFieldValues(rs))
            {
              salesByDayDiffStore2.row_number = lt_list.Count + 1;
              lt_list.Add(salesByDayDiffStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayDiffStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByDayDiffStore> SelectDateStoreEnumerableAsync(object p_param)
    {
      SalesByDayDiffStore salesByDayDiffStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(salesByDayDiffStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, salesByDayDiffStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(salesByDayDiffStore1.GetSelectQuery(p_param)))
        {
          salesByDayDiffStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + salesByDayDiffStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByDayDiffStore salesByDayDiffStore2 = salesByDayDiffStore1.OleDB.Create<SalesByDayDiffStore>();
            if (salesByDayDiffStore2.GetFieldValues(rs))
            {
              salesByDayDiffStore2.row_number = ++row_number;
              yield return salesByDayDiffStore2;
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

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    protected Hashtable SearchConditionDefault(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
    }

    protected Hashtable SearchConditionBase(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
    }

    protected Hashtable SearchConditionDay(Hashtable p_param, int pCalcDay)
    {
      Hashtable hashtable = this.SearchConditionDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, 0, pCalcDay));
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, 0, pCalcDay));
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, 0, pCalcDay));
      }
      return hashtable;
    }

    protected Hashtable SearchConditionMonth(Hashtable p_param, bool pIsWeekOf)
    {
      Hashtable hashtable = this.SearchConditionDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeMonth, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, -1, 0));
        }
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeMonth, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, -1, 0));
        }
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeMonth, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(0, -1, 0));
        }
      }
      return hashtable;
    }

    protected Hashtable SearchConditionYear(Hashtable p_param, bool pIsWeekOf)
    {
      Hashtable hashtable = this.SearchConditionDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeYear, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(-1, 0, 0));
        }
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeYear, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(-1, 0, 0));
        }
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
        {
          if (pIsWeekOf)
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).ToWeekOfAdd(EnumDateDiv.typeYear, -1));
          else
            hashtable.Add(dictionaryEntry.Key, (object) ((DateTime) dictionaryEntry.Value).GetDateAdd(-1, 0, 0));
        }
      }
      return hashtable;
    }

    protected Hashtable SearchConditionGoalByDeptDefault(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add((object) "gbd_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add((object) "gbd_StoreCode", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
        {
          hashtable.Add((object) "gbd_StoreCode_IN_", dictionaryEntry.Value);
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
      }
      return hashtable;
    }

    protected Hashtable SearchConditionGoalByDeptBase(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionGoalByDeptDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add((object) "gbd_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add((object) "gbd_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add((object) "gbd_SaleDate_END_", dictionaryEntry.Value);
      }
      return hashtable;
    }

    protected Hashtable SearchConditionGoalByCategoryDefault(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add((object) "gbc_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add((object) "gbc_StoreCode", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
        {
          hashtable.Add((object) "gbc_StoreCode_IN_", dictionaryEntry.Value);
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
      }
      return hashtable;
    }

    protected Hashtable SearchConditionGoalByCategoryBase(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionGoalByCategoryDefault(p_param);
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add((object) "gbc_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add((object) "gbc_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add((object) "gbc_SaleDate_END_", dictionaryEntry.Value);
      }
      return hashtable;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        bool pIsDay = false;
        bool pIsWeek = false;
        bool pIsMonth = false;
        bool pIsYear = false;
        bool pIsWeekOf = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sbd_SiteID") && Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_IsDay_") && Convert.ToBoolean(hashtable[(object) "_IsDay_"].ToString()))
            pIsDay = Convert.ToBoolean(hashtable[(object) "_IsDay_"].ToString());
          if (hashtable.ContainsKey((object) "_IsWeek_") && Convert.ToBoolean(hashtable[(object) "_IsWeek_"].ToString()))
            pIsWeek = Convert.ToBoolean(hashtable[(object) "_IsWeek_"].ToString());
          if (hashtable.ContainsKey((object) "_IsMonth_") && Convert.ToBoolean(hashtable[(object) "_IsMonth_"].ToString()))
            pIsMonth = Convert.ToBoolean(hashtable[(object) "_IsMonth_"].ToString());
          if (hashtable.ContainsKey((object) "_IsYear_") && Convert.ToBoolean(hashtable[(object) "_IsYear_"].ToString()))
            pIsYear = Convert.ToBoolean(hashtable[(object) "_IsYear_"].ToString());
          if (hashtable.ContainsKey((object) "_ConditionDayBeforeType_") && Convert.ToInt32(hashtable[(object) "_ConditionDayBeforeType_"].ToString()) > 0)
            pIsWeekOf = EnumContionDayBeforeType.Week == Enum2StrConverter.ToContionDayBeforeType(Convert.ToInt32(hashtable[(object) "_ConditionDayBeforeType_"].ToString()));
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append("\n,T_BASE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(SalesByDayDiffStore.BaseColMaker(string.Empty));
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionBase((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n GROUP BY sbd_StoreCode");
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_BASE_GOAL_DEPT AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        else
          stringBuilder.Append(" gbd_StoreCode AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(SalesByDayDiffStore.BaseGoalDeptColMaker(string.Empty));
        stringBuilder.Append(string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoalByDept, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        p_param1 = this.SearchConditionGoalByDeptBase((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gbd_SiteID"))
            p_param1.Add((object) "gbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoalByDeptView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gbd_SiteID", (object) p_SiteID));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n GROUP BY gbd_StoreCode");
        stringBuilder.Append(")");
        if (pIsDay)
        {
          stringBuilder.Append("\n,T_DAY AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.BaseColMaker("_Day"));
          stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionDay((Hashtable) p_param, -1);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
          if (!p_isStoreTotal)
            stringBuilder.Append("\n GROUP BY sbd_StoreCode");
          stringBuilder.Append(")");
        }
        if (pIsWeek)
        {
          stringBuilder.Append("\n,T_WEEK AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.BaseColMaker("_Week"));
          stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionDay((Hashtable) p_param, -7);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
          if (!p_isStoreTotal)
            stringBuilder.Append("\n GROUP BY sbd_StoreCode");
          stringBuilder.Append(")");
        }
        if (pIsMonth)
        {
          stringBuilder.Append("\n,T_MONTH AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.BaseColMaker("_Month"));
          stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionMonth((Hashtable) p_param, pIsWeekOf);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
          if (!p_isStoreTotal)
            stringBuilder.Append("\n GROUP BY sbd_StoreCode");
          stringBuilder.Append(")");
        }
        if (pIsYear)
        {
          stringBuilder.Append("\n,T_YEAR AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.BaseColMaker("_Year"));
          stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionYear((Hashtable) p_param, pIsWeekOf);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
          if (!p_isStoreTotal)
            stringBuilder.Append("\n GROUP BY sbd_StoreCode");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECT NULL AS sbd_SaleDate,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,0 AS sbd_Supplier,0 AS sbd_SupplierType,0 AS sbd_CategoryCode,0 AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SalesByDayDiffStore.MainCol(pIsDay, pIsWeek, pIsMonth, pIsYear));
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SalesByDayDiffStore.SubCol(pIsDay, pIsWeek, pIsMonth, pIsYear));
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SalesByDayDiffStore.TableCol(pIsDay, pIsWeek, pIsMonth, pIsYear));
        stringBuilder.Append("\nFROM T_BASE");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SalesByDayDiffStore.TableColGoal(1, pIsDay, pIsWeek, pIsMonth, pIsYear));
        stringBuilder.Append("\nFROM T_BASE_GOAL_DEPT");
        if (pIsDay)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.TableCol(2, pIsDay, pIsWeek, pIsMonth, pIsYear));
          stringBuilder.Append("\nFROM T_DAY");
        }
        if (pIsWeek)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.TableCol(3, pIsDay, pIsWeek, pIsMonth, pIsYear));
          stringBuilder.Append("\nFROM T_WEEK");
        }
        if (pIsWeek)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.TableCol(4, pIsDay, pIsWeek, pIsMonth, pIsYear));
          stringBuilder.Append("\nFROM T_MONTH");
        }
        if (pIsWeek)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_StoreCode");
          stringBuilder.Append(SalesByDayDiffStore.TableCol(5, pIsDay, pIsWeek, pIsMonth, pIsYear));
          stringBuilder.Append("\nFROM T_YEAR");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_StoreCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbd_StoreCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public static string MainCol(bool pIsDay, bool pIsWeek, bool pIsMonth, bool pIsYear)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(",sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc,sbd_GoalAmount,sbd_GoalProfitAmount");
      if (pIsDay)
        stringBuilder.Append(",sbd_SlipCustomer_Day,sbd_GoodsCustomer_Day,sbd_CategoryCustomer_Day,sbd_SupplierCustomer_Day,sbd_BoxQty_Day,sbd_SaleQty_Day,sbd_DcAmtGoods_Day,sbd_DcAmtEvent_Day,sbd_DcAmtCoupon_Day,sbd_DcAmtPromotion_Day,sbd_DcAmtManual_Day,sbd_DcAmtMember_Day,sbd_EnurySlip_Day,sbd_EnuryEnd_Day,sbd_Deposit_Day,sbd_TotalSaleAmt_Day,sbd_SaleAmt_Day,sbd_SaleVatAmt_Day,sbd_SaleCostAmt_Day,sbd_ChargeAmt_Day,sbd_ProfitAmt_Day,sbd_PreTaxProfitAmt_Day,sbd_AddPoint_Day,sbd_PayCash_Day,sbd_PayCard_Day,sbd_PayEtc_Day,sbd_GoalAmount_Day,sbd_GoalProfitAmount_Day");
      if (pIsWeek)
        stringBuilder.Append(",sbd_SlipCustomer_Week,sbd_GoodsCustomer_Week,sbd_CategoryCustomer_Week,sbd_SupplierCustomer_Week,sbd_BoxQty_Week,sbd_SaleQty_Week,sbd_DcAmtGoods_Week,sbd_DcAmtEvent_Week,sbd_DcAmtCoupon_Week,sbd_DcAmtPromotion_Week,sbd_DcAmtManual_Week,sbd_DcAmtMember_Week,sbd_EnurySlip_Week,sbd_EnuryEnd_Week,sbd_Deposit_Week,sbd_TotalSaleAmt_Week,sbd_SaleAmt_Week,sbd_SaleVatAmt_Week,sbd_SaleCostAmt_Week,sbd_ChargeAmt_Week,sbd_ProfitAmt_Week,sbd_PreTaxProfitAmt_Week,sbd_AddPoint_Week,sbd_PayCash_Week,sbd_PayCard_Week,sbd_PayEtc_Week,sbd_GoalAmount_Week,sbd_GoalProfitAmount_Week");
      if (pIsMonth)
        stringBuilder.Append(",sbd_SlipCustomer_Month,sbd_GoodsCustomer_Month,sbd_CategoryCustomer_Month,sbd_SupplierCustomer_Month,sbd_BoxQty_Month,sbd_SaleQty_Month,sbd_DcAmtGoods_Month,sbd_DcAmtEvent_Month,sbd_DcAmtCoupon_Month,sbd_DcAmtPromotion_Month,sbd_DcAmtManual_Month,sbd_DcAmtMember_Month,sbd_EnurySlip_Month,sbd_EnuryEnd_Month,sbd_Deposit_Month,sbd_TotalSaleAmt_Month,sbd_SaleAmt_Month,sbd_SaleVatAmt_Month,sbd_SaleCostAmt_Month,sbd_ChargeAmt_Month,sbd_ProfitAmt_Month,sbd_PreTaxProfitAmt_Month,sbd_AddPoint_Month,sbd_PayCash_Month,sbd_PayCard_Month,sbd_PayEtc_Month,sbd_GoalAmount_Month,sbd_GoalProfitAmount_Month");
      if (pIsYear)
        stringBuilder.Append(",sbd_SlipCustomer_Year,sbd_GoodsCustomer_Year,sbd_CategoryCustomer_Year,sbd_SupplierCustomer_Year,sbd_BoxQty_Year,sbd_SaleQty_Year,sbd_DcAmtGoods_Year,sbd_DcAmtEvent_Year,sbd_DcAmtCoupon_Year,sbd_DcAmtPromotion_Year,sbd_DcAmtManual_Year,sbd_DcAmtMember_Year,sbd_EnurySlip_Year,sbd_EnuryEnd_Year,sbd_Deposit_Year,sbd_TotalSaleAmt_Year,sbd_SaleAmt_Year,sbd_SaleVatAmt_Year,sbd_SaleCostAmt_Year,sbd_ChargeAmt_Year,sbd_ProfitAmt_Year,sbd_PreTaxProfitAmt_Year,sbd_AddPoint_Year,sbd_PayCash_Year,sbd_PayCard_Year,sbd_PayEtc_Year,sbd_GoalAmount_Year,sbd_GoalProfitAmount_Year");
      return stringBuilder.ToString();
    }

    public static string SubCol(bool pIsDay, bool pIsWeek, bool pIsMonth, bool pIsYear)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(",SUM(sbd_SlipCustomer) AS sbd_SlipCustomer,SUM(sbd_GoodsCustomer) AS sbd_GoodsCustomer,SUM(sbd_CategoryCustomer) AS sbd_CategoryCustomer,SUM(sbd_SupplierCustomer) AS sbd_SupplierCustomer,SUM(sbd_BoxQty) AS sbd_BoxQty,SUM (sbd_SaleQty) AS sbd_SaleQty,SUM(sbd_DcAmtGoods) AS sbd_DcAmtGoods,SUM(sbd_DcAmtEvent) AS sbd_DcAmtEvent,SUM(sbd_DcAmtCoupon) AS sbd_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS sbd_DcAmtPromotion,SUM(sbd_DcAmtManual) AS sbd_DcAmtManual,SUM(sbd_DcAmtMember) AS sbd_DcAmtMember,SUM(sbd_EnurySlip) AS sbd_EnurySlip,SUM(sbd_EnuryEnd) AS sbd_EnuryEnd,SUM(sbd_Deposit) AS sbd_Deposit,SUM(sbd_TotalSaleAmt) AS sbd_TotalSaleAmt,SUM(sbd_SaleAmt) AS sbd_SaleAmt,SUM(sbd_SaleVatAmt) AS sbd_SaleVatAmt,SUM(sbd_SaleCostAmt) AS sbd_SaleCostAmt,SUM(sbd_ChargeAmt) AS sbd_ChargeAmt,SUM(sbd_ProfitAmt) AS sbd_ProfitAmt,SUM(sbd_PreTaxProfitAmt) AS sbd_PreTaxProfitAmt,SUM(sbd_AddPoint) AS sbd_AddPoint,SUM(sbd_PayCash) AS sbd_PayCash,SUM(sbd_PayCard) AS sbd_PayCard,SUM(sbd_PayEtc) AS sbd_PayEtc,SUM(sbd_GoalAmount) AS sbd_GoalAmount,SUM(sbd_GoalProfitAmount) AS sbd_GoalProfitAmount");
      if (pIsDay)
        stringBuilder.Append(",SUM(sbd_SlipCustomer_Day) AS sbd_SlipCustomer_Day,SUM(sbd_GoodsCustomer_Day) AS sbd_GoodsCustomer_Day,SUM(sbd_CategoryCustomer_Day) AS sbd_CategoryCustomer_Day,SUM(sbd_SupplierCustomer_Day) AS sbd_SupplierCustomer_Day,SUM(sbd_BoxQty_Day) AS sbd_BoxQty_Day,SUM(sbd_SaleQty_Day) AS sbd_SaleQty_Day,SUM(sbd_DcAmtGoods_Day) AS sbd_DcAmtGoods_Day,SUM(sbd_DcAmtEvent_Day) AS sbd_DcAmtEvent_Day,SUM(sbd_DcAmtCoupon_Day) AS sbd_DcAmtCoupon_Day,SUM(sbd_DcAmtPromotion_Day) AS sbd_DcAmtPromotion_Day,SUM(sbd_DcAmtManual_Day) AS sbd_DcAmtManual_Day,SUM(sbd_DcAmtMember_Day) AS sbd_DcAmtMember_Day,SUM(sbd_EnurySlip_Day) AS sbd_EnurySlip_Day,SUM(sbd_EnuryEnd_Day) AS sbd_EnuryEnd_Day,SUM(sbd_Deposit_Day) AS sbd_Deposit_Day,SUM(sbd_TotalSaleAmt_Day) AS sbd_TotalSaleAmt_Day,SUM(sbd_SaleAmt_Day) AS sbd_SaleAmt_Day,SUM(sbd_SaleVatAmt_Day) AS sbd_SaleVatAmt_Day,SUM(sbd_SaleCostAmt_Day) AS sbd_SaleCostAmt_Day,SUM(sbd_ChargeAmt_Day) AS sbd_ChargeAmt_Day,SUM(sbd_ProfitAmt_Day) AS sbd_ProfitAmt_Day,SUM(sbd_PreTaxProfitAmt_Day) AS sbd_PreTaxProfitAmt_Day,SUM(sbd_AddPoint_Day) AS sbd_AddPoint_Day,SUM(sbd_PayCash_Day) AS sbd_PayCash_Day,SUM(sbd_PayCard_Day) AS sbd_PayCard_Day,SUM(sbd_PayEtc_Day) AS sbd_PayEtc_Day,SUM(sbd_GoalAmount_Day) AS sbd_GoalAmount_Day,SUM(sbd_GoalProfitAmount_Day) AS sbd_GoalProfitAmount_Day");
      if (pIsWeek)
        stringBuilder.Append(",SUM(sbd_SlipCustomer_Week) AS sbd_SlipCustomer_Week,SUM(sbd_GoodsCustomer_Week) AS sbd_GoodsCustomer_Week,SUM(sbd_CategoryCustomer_Week) AS sbd_CategoryCustomer_Week,SUM(sbd_SupplierCustomer_Week) AS sbd_SupplierCustomer_Week,SUM(sbd_BoxQty_Week) AS sbd_BoxQty_Week,SUM(sbd_SaleQty_Week) AS sbd_SaleQty_Week,SUM(sbd_DcAmtGoods_Week) AS sbd_DcAmtGoods_Week,SUM(sbd_DcAmtEvent_Week) AS sbd_DcAmtEvent_Week,SUM(sbd_DcAmtCoupon_Week) AS sbd_DcAmtCoupon_Week,SUM(sbd_DcAmtPromotion_Week) AS sbd_DcAmtPromotion_Week,SUM(sbd_DcAmtManual_Week) AS sbd_DcAmtManual_Week,SUM(sbd_DcAmtMember_Week) AS sbd_DcAmtMember_Week,SUM(sbd_EnurySlip_Week) AS sbd_EnurySlip_Week,SUM(sbd_EnuryEnd_Week) AS sbd_EnuryEnd_Week,SUM(sbd_Deposit_Week) AS sbd_Deposit_Week,SUM(sbd_TotalSaleAmt_Week) AS sbd_TotalSaleAmt_Week,SUM(sbd_SaleAmt_Week) AS sbd_SaleAmt_Week,SUM(sbd_SaleVatAmt_Week) AS sbd_SaleVatAmt_Week,SUM(sbd_SaleCostAmt_Week) AS sbd_SaleCostAmt_Week,SUM(sbd_ChargeAmt_Week) AS sbd_ChargeAmt_Week,SUM(sbd_ProfitAmt_Week) AS sbd_ProfitAmt_Week,SUM(sbd_PreTaxProfitAmt_Week) AS sbd_PreTaxProfitAmt_Week,SUM(sbd_AddPoint_Week) AS sbd_AddPoint_Week,SUM(sbd_PayCash_Week) AS sbd_PayCash_Week,SUM(sbd_PayCard_Week) AS sbd_PayCard_Week,SUM(sbd_PayEtc_Week) AS sbd_PayEtc_Week,SUM(sbd_GoalAmount_Week) AS sbd_GoalAmount_Week,SUM(sbd_GoalProfitAmount_Week) AS sbd_GoalProfitAmount_Week");
      if (pIsMonth)
        stringBuilder.Append(",SUM(sbd_SlipCustomer_Month) AS sbd_SlipCustomer_Month,SUM(sbd_GoodsCustomer_Month) AS sbd_GoodsCustomer_Month,SUM(sbd_CategoryCustomer_Month) AS sbd_CategoryCustomer_Month,SUM(sbd_SupplierCustomer_Month) AS sbd_SupplierCustomer_Month,SUM(sbd_BoxQty_Month) AS sbd_BoxQty_Month,SUM(sbd_SaleQty_Month) AS sbd_SaleQty_Month,SUM(sbd_DcAmtGoods_Month) AS sbd_DcAmtGoods_Month,SUM(sbd_DcAmtEvent_Month) AS sbd_DcAmtEvent_Month,SUM(sbd_DcAmtCoupon_Month) AS sbd_DcAmtCoupon_Month,SUM(sbd_DcAmtPromotion_Month) AS sbd_DcAmtPromotion_Month,SUM(sbd_DcAmtManual_Month) AS sbd_DcAmtManual_Month,SUM(sbd_DcAmtMember_Month) AS sbd_DcAmtMember_Month,SUM(sbd_EnurySlip_Month) AS sbd_EnurySlip_Month,SUM(sbd_EnuryEnd_Month) AS sbd_EnuryEnd_Month,SUM(sbd_Deposit_Month) AS sbd_Deposit_Month,SUM(sbd_TotalSaleAmt_Month) AS sbd_TotalSaleAmt_Month,SUM(sbd_SaleAmt_Month) AS sbd_SaleAmt_Month,SUM(sbd_SaleVatAmt_Month) AS sbd_SaleVatAmt_Month,SUM(sbd_SaleCostAmt_Month) AS sbd_SaleCostAmt_Month,SUM(sbd_ChargeAmt_Month) AS sbd_ChargeAmt_Month,SUM(sbd_ProfitAmt_Month) AS sbd_ProfitAmt_Month,SUM(sbd_PreTaxProfitAmt_Month) AS sbd_PreTaxProfitAmt_Month,SUM(sbd_AddPoint_Month) AS sbd_AddPoint_Month,SUM(sbd_PayCash_Month) AS sbd_PayCash_Month,SUM(sbd_PayCard_Month) AS sbd_PayCard_Month,SUM(sbd_PayEtc_Month) AS sbd_PayEtc_Month,SUM(sbd_GoalAmount_Month) AS sbd_GoalAmount_Month,SUM(sbd_GoalProfitAmount_Month) AS sbd_GoalProfitAmount_Month");
      if (pIsYear)
        stringBuilder.Append(",SUM(sbd_SlipCustomer_Year) AS sbd_SlipCustomer_Year,SUM(sbd_GoodsCustomer_Year) AS sbd_GoodsCustomer_Year,SUM(sbd_CategoryCustomer_Year) AS sbd_CategoryCustomer_Year,SUM(sbd_SupplierCustomer_Year) AS sbd_SupplierCustomer_Year,SUM(sbd_BoxQty_Year) AS sbd_BoxQty_Year,SUM(sbd_SaleQty_Year) AS sbd_SaleQty_Year,SUM(sbd_DcAmtGoods_Year) AS sbd_DcAmtGoods_Year,SUM(sbd_DcAmtEvent_Year) AS sbd_DcAmtEvent_Year,SUM(sbd_DcAmtCoupon_Year) AS sbd_DcAmtCoupon_Year,SUM(sbd_DcAmtPromotion_Year) AS sbd_DcAmtPromotion_Year,SUM(sbd_DcAmtManual_Year) AS sbd_DcAmtManual_Year,SUM(sbd_DcAmtMember_Year) AS sbd_DcAmtMember_Year,SUM(sbd_EnurySlip_Year) AS sbd_EnurySlip_Year,SUM(sbd_EnuryEnd_Year) AS sbd_EnuryEnd_Year,SUM(sbd_Deposit_Year) AS sbd_Deposit_Year,SUM(sbd_TotalSaleAmt_Year) AS sbd_TotalSaleAmt_Year,SUM(sbd_SaleAmt_Year) AS sbd_SaleAmt_Year,SUM(sbd_SaleVatAmt_Year) AS sbd_SaleVatAmt_Year,SUM(sbd_SaleCostAmt_Year) AS sbd_SaleCostAmt_Year,SUM(sbd_ChargeAmt_Year) AS sbd_ChargeAmt_Year,SUM(sbd_ProfitAmt_Year) AS sbd_ProfitAmt_Year,SUM(sbd_PreTaxProfitAmt_Year) AS sbd_PreTaxProfitAmt_Year,SUM(sbd_AddPoint_Year) AS sbd_AddPoint_Year,SUM(sbd_PayCash_Year) AS sbd_PayCash_Year,SUM(sbd_PayCard_Year) AS sbd_PayCard_Year,SUM(sbd_PayEtc_Year) AS sbd_PayEtc_Year,SUM(sbd_GoalAmount_Year) AS sbd_GoalAmount_Year,SUM(sbd_GoalProfitAmount_Year) AS sbd_GoalProfitAmount_Year");
      return stringBuilder.ToString();
    }

    public static string TableCol(bool pIsDay, bool pIsWeek, bool pIsMonth, bool pIsYear)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(",sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc,0 AS sbd_GoalAmount,0 AS sbd_GoalProfitAmount");
      if (pIsDay)
        stringBuilder.Append(",0 AS sbd_SlipCustomer_Day,0 AS sbd_GoodsCustomer_Day,0 AS sbd_CategoryCustomer_Day,0 AS sbd_SupplierCustomer_Day,0 AS sbd_BoxQty_Day,0 AS sbd_SaleQty_Day,0 AS sbd_DcAmtGoods_Day,0 AS sbd_DcAmtEvent_Day,0 AS sbd_DcAmtCoupon_Day,0 AS sbd_DcAmtPromotion_Day,0 AS sbd_DcAmtManual_Day,0 AS sbd_DcAmtMember_Day,0 AS sbd_EnurySlip_Day,0 AS sbd_EnuryEnd_Day,0 AS sbd_Deposit_Day,0 AS sbd_TotalSaleAmt_Day,0 AS sbd_SaleAmt_Day,0 AS sbd_SaleVatAmt_Day,0 AS sbd_SaleCostAmt_Day,0 AS sbd_ChargeAmt_Day,0 AS sbd_ProfitAmt_Day,0 AS sbd_PreTaxProfitAmt_Day,0 AS sbd_AddPoint_Day,0 AS sbd_PayCash_Day,0 AS sbd_PayCard_Day,0 AS sbd_PayEtc_Day,0 AS sbd_GoalAmount_Day,0 AS sbd_GoalProfitAmount_Day");
      if (pIsWeek)
        stringBuilder.Append(",0 AS sbd_SlipCustomer_Week,0 AS sbd_GoodsCustomer_Week,0 AS sbd_CategoryCustomer_Week,0 AS sbd_SupplierCustomer_Week,0 AS sbd_BoxQty_Week,0 AS sbd_SaleQty_Week,0 AS sbd_DcAmtGoods_Week,0 AS sbd_DcAmtEvent_Week,0 AS sbd_DcAmtCoupon_Week,0 AS sbd_DcAmtPromotion_Week,0 AS sbd_DcAmtManual_Week,0 AS sbd_DcAmtMember_Week,0 AS sbd_EnurySlip_Week,0 AS sbd_EnuryEnd_Week,0 AS sbd_Deposit_Week,0 AS sbd_TotalSaleAmt_Week,0 AS sbd_SaleAmt_Week,0 AS sbd_SaleVatAmt_Week,0 AS sbd_SaleCostAmt_Week,0 AS sbd_ChargeAmt_Week,0 AS sbd_ProfitAmt_Week,0 AS sbd_PreTaxProfitAmt_Week,0 AS sbd_AddPoint_Week,0 AS sbd_PayCash_Week,0 AS sbd_PayCard_Week,0 AS sbd_PayEtc_Week,0 AS sbd_GoalAmount_Week,0 AS sbd_GoalProfitAmount_Week");
      if (pIsMonth)
        stringBuilder.Append(",0 AS sbd_SlipCustomer_Month,0 AS sbd_GoodsCustomer_Month,0 AS sbd_CategoryCustomer_Month,0 AS sbd_SupplierCustomer_Month,0 AS sbd_BoxQty_Month,0 AS sbd_SaleQty_Month,0 AS sbd_DcAmtGoods_Month,0 AS sbd_DcAmtEvent_Month,0 AS sbd_DcAmtCoupon_Month,0 AS sbd_DcAmtPromotion_Month,0 AS sbd_DcAmtManual_Month,0 AS sbd_DcAmtMember_Month,0 AS sbd_EnurySlip_Month,0 AS sbd_EnuryEnd_Month,0 AS sbd_Deposit_Month,0 AS sbd_TotalSaleAmt_Month,0 AS sbd_SaleAmt_Month,0 AS sbd_SaleVatAmt_Month,0 AS sbd_SaleCostAmt_Month,0 AS sbd_ChargeAmt_Month,0 AS sbd_ProfitAmt_Month,0 AS sbd_PreTaxProfitAmt_Month,0 AS sbd_AddPoint_Month,0 AS sbd_PayCash_Month,0 AS sbd_PayCard_Month,0 AS sbd_PayEtc_Month,0 AS sbd_GoalAmount_Month,0 AS sbd_GoalProfitAmount_Month");
      if (pIsYear)
        stringBuilder.Append(",0 AS sbd_SlipCustomer_Year,0 AS sbd_GoodsCustomer_Year,0 AS sbd_CategoryCustomer_Year,0 AS sbd_SupplierCustomer_Year,0 AS sbd_BoxQty_Year,0 AS sbd_SaleQty_Year,0 AS sbd_DcAmtGoods_Year,0 AS sbd_DcAmtEvent_Year,0 AS sbd_DcAmtCoupon_Year,0 AS sbd_DcAmtPromotion_Year,0 AS sbd_DcAmtManual_Year,0 AS sbd_DcAmtMember_Year,0 AS sbd_EnurySlip_Year,0 AS sbd_EnuryEnd_Year,0 AS sbd_Deposit_Year,0 AS sbd_TotalSaleAmt_Year,0 AS sbd_SaleAmt_Year,0 AS sbd_SaleVatAmt_Year,0 AS sbd_SaleCostAmt_Year,0 AS sbd_ChargeAmt_Year,0 AS sbd_ProfitAmt_Year,0 AS sbd_PreTaxProfitAmt_Year,0 AS sbd_AddPoint_Year,0 AS sbd_PayCash_Year,0 AS sbd_PayCard_Year,0 AS sbd_PayEtc_Year,0 AS sbd_GoalAmount_Year,0 AS sbd_GoalProfitAmount_Year");
      return stringBuilder.ToString();
    }

    public static string TableCol(
      int pType,
      bool pIsDay,
      bool pIsWeek,
      bool pIsMonth,
      bool pIsYear)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      if (pIsDay)
      {
        if (pType == 2)
          stringBuilder.Append(",sbd_SlipCustomer_Day,sbd_GoodsCustomer_Day,sbd_CategoryCustomer_Day,sbd_SupplierCustomer_Day,sbd_BoxQty_Day,sbd_SaleQty_Day,sbd_DcAmtGoods_Day,sbd_DcAmtEvent_Day,sbd_DcAmtCoupon_Day,sbd_DcAmtPromotion_Day,sbd_DcAmtManual_Day,sbd_DcAmtMember_Day,sbd_EnurySlip_Day,sbd_EnuryEnd_Day,sbd_Deposit_Day,sbd_TotalSaleAmt_Day,sbd_SaleAmt_Day,sbd_SaleVatAmt_Day,sbd_SaleCostAmt_Day,sbd_ChargeAmt_Day,sbd_ProfitAmt_Day,sbd_PreTaxProfitAmt_Day,sbd_AddPoint_Day,sbd_PayCash_Day,sbd_PayCard_Day,sbd_PayEtc_Day,0 AS sbd_GoalAmount_Day,0 AS sbd_GoalProfitAmount_Day");
        else
          stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      }
      if (pIsWeek)
      {
        if (pType == 3)
          stringBuilder.Append(",sbd_SlipCustomer_Week,sbd_GoodsCustomer_Week,sbd_CategoryCustomer_Week,sbd_SupplierCustomer_Week,sbd_BoxQty_Week,sbd_SaleQty_Week,sbd_DcAmtGoods_Week,sbd_DcAmtEvent_Week,sbd_DcAmtCoupon_Week,sbd_DcAmtPromotion_Week,sbd_DcAmtManual_Week,sbd_DcAmtMember_Week,sbd_EnurySlip_Week,sbd_EnuryEnd_Week,sbd_Deposit_Week,sbd_TotalSaleAmt_Week,sbd_SaleAmt_Week,sbd_SaleVatAmt_Week,sbd_SaleCostAmt_Week,sbd_ChargeAmt_Week,sbd_ProfitAmt_Week,sbd_PreTaxProfitAmt_Week,sbd_AddPoint_Week,sbd_PayCash_Week,sbd_PayCard_Week,sbd_PayEtc_Week,0 AS sbd_GoalAmount_Week,0 AS sbd_GoalProfitAmount_Week");
        else
          stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      }
      if (pIsMonth)
      {
        if (pType == 4)
          stringBuilder.Append(",sbd_SlipCustomer_Month,sbd_GoodsCustomer_Month,sbd_CategoryCustomer_Month,sbd_SupplierCustomer_Month,sbd_BoxQty_Month,sbd_SaleQty_Month,sbd_DcAmtGoods_Month,sbd_DcAmtEvent_Month,sbd_DcAmtCoupon_Month,sbd_DcAmtPromotion_Month,sbd_DcAmtManual_Month,sbd_DcAmtMember_Month,sbd_EnurySlip_Month,sbd_EnuryEnd_Month,sbd_Deposit_Month,sbd_TotalSaleAmt_Month,sbd_SaleAmt_Month,sbd_SaleVatAmt_Month,sbd_SaleCostAmt_Month,sbd_ChargeAmt_Month,sbd_ProfitAmt_Month,sbd_PreTaxProfitAmt_Month,sbd_AddPoint_Month,sbd_PayCash_Month,sbd_PayCard_Month,sbd_PayEtc_Month,0 AS sbd_GoalAmount_Month,0 AS sbd_GoalProfitAmount_Month");
        else
          stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      }
      if (pIsYear)
      {
        if (pType == 5)
          stringBuilder.Append(",sbd_SlipCustomer_Year,sbd_GoodsCustomer_Year,sbd_CategoryCustomer_Year,sbd_SupplierCustomer_Year,sbd_BoxQty_Year,sbd_SaleQty_Year,sbd_DcAmtGoods_Year,sbd_DcAmtEvent_Year,sbd_DcAmtCoupon_Year,sbd_DcAmtPromotion_Year,sbd_DcAmtManual_Year,sbd_DcAmtMember_Year,sbd_EnurySlip_Year,sbd_EnuryEnd_Year,sbd_Deposit_Year,sbd_TotalSaleAmt_Year,sbd_SaleAmt_Year,sbd_SaleVatAmt_Year,sbd_SaleCostAmt_Year,sbd_ChargeAmt_Year,sbd_ProfitAmt_Year,sbd_PreTaxProfitAmt_Year,sbd_AddPoint_Year,sbd_PayCash_Year,sbd_PayCard_Year,sbd_PayEtc_Year,0 AS sbd_GoalAmount_Year,0 AS sbd_GoalProfitAmount_Year");
        else
          stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      }
      return stringBuilder.ToString();
    }

    public static string TableColGoal(
      int pType,
      bool pIsDay,
      bool pIsWeek,
      bool pIsMonth,
      bool pIsYear)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
      if (pType == 1)
        stringBuilder.Append(",sbd_GoalAmount,sbd_GoalProfitAmount");
      else
        stringBuilder.Append(",0 AS sbd_GoalAmount,0 AS sbd_GoalProfitAmount");
      if (pIsDay)
      {
        stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
        if (pType == 2)
          stringBuilder.Append(",sbd_GoalAmount_Day,sbd_GoalProfitAmount_Day");
        else
          stringBuilder.Append(",0,0");
      }
      if (pIsWeek)
      {
        stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
        if (pType == 3)
          stringBuilder.Append(",sbd_GoalAmount_Week,sbd_GoalProfitAmount_Week");
        else
          stringBuilder.Append(",0,0");
      }
      if (pIsMonth)
      {
        stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
        if (pType == 4)
          stringBuilder.Append(",sbd_GoalAmount_Month,sbd_GoalProfitAmount_Month");
        else
          stringBuilder.Append(",0,0");
      }
      if (pIsYear)
      {
        stringBuilder.Append(",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0");
        if (pType == 4)
          stringBuilder.Append(",sbd_GoalAmount_Year,sbd_GoalProfitAmount_Year");
        else
          stringBuilder.Append(",0,0");
      }
      return stringBuilder.ToString();
    }

    public static string BaseColMaker(string pColAdd) => ",SUM(sbd_SlipCustomer) AS sbd_SlipCustomer" + pColAdd + ",SUM(sbd_GoodsCustomer) AS sbd_GoodsCustomer" + pColAdd + ",SUM(sbd_CategoryCustomer) AS sbd_CategoryCustomer" + pColAdd + ",SUM(sbd_SupplierCustomer) AS sbd_SupplierCustomer" + pColAdd + ",SUM(sbd_BoxQty) AS sbd_BoxQty" + pColAdd + ",SUM(sbd_SaleQty) AS sbd_SaleQty" + pColAdd + ",SUM(sbd_DcAmtGoods) AS sbd_DcAmtGoods" + pColAdd + ",SUM(sbd_DcAmtEvent) AS sbd_DcAmtEvent" + pColAdd + ",SUM(sbd_DcAmtCoupon) AS sbd_DcAmtCoupon" + pColAdd + ",SUM(sbd_DcAmtPromotion) AS sbd_DcAmtPromotion" + pColAdd + ",SUM(sbd_DcAmtManual) AS sbd_DcAmtManual" + pColAdd + ",SUM(sbd_DcAmtMember) AS sbd_DcAmtMember" + pColAdd + ",SUM(sbd_EnurySlip) AS sbd_EnurySlip" + pColAdd + ",SUM(sbd_EnuryEnd) AS sbd_EnuryEnd" + pColAdd + ",SUM(sbd_Deposit) AS sbd_Deposit" + pColAdd + ",SUM(sbd_TotalSaleAmt) AS sbd_TotalSaleAmt" + pColAdd + ",SUM(sbd_SaleAmt) AS sbd_SaleAmt" + pColAdd + ",SUM(sbd_SaleVatAmt) AS sbd_SaleVatAmt" + pColAdd + ",SUM(sbd_SaleCostAmt) AS sbd_SaleCostAmt" + pColAdd + ",SUM(sbd_ChargeAmt) AS sbd_ChargeAmt" + pColAdd + ",SUM(sbd_ProfitAmt) AS sbd_ProfitAmt" + pColAdd + ",SUM(sbd_PreTaxProfitAmt) AS sbd_PreTaxProfitAmt" + pColAdd + ",SUM(sbd_AddPoint) AS sbd_AddPoint" + pColAdd + ",SUM(sbd_PayCash) AS sbd_PayCash" + pColAdd + ",SUM(sbd_PayCard) AS sbd_PayCard" + pColAdd + ",SUM(sbd_PayEtc) AS sbd_PayEtc" + pColAdd;

    public static string BaseGoalDeptColMaker(string pColAdd) => ",SUM(gbd_GoalSaleAmt) AS sbd_GoalAmount" + pColAdd + ",SUM(gbd_GoalProfitAmt) AS sbd_GoalProfitAmount" + pColAdd;

    public static string BaseGoalCategoryColMaker(string pColAdd) => ",SUM(gbc_GoalSaleAmt) AS sbd_GoalAmount" + pColAdd + ",SUM(gbc_GoalProfitAmt) AS sbd_GoalProfitAmount" + pColAdd;

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV1_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV2_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV3_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_1_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_2_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_3_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithViewCategoryLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_VIEW_CATEGORY_LV1 AS (SELECT dpt_lv1_ID,dpt_lv2_ID,dept_code,ctg_lv1_ID,ctg_SiteID FROM " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock());
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(" GROUP BY dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithBookmarkGoodsQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      int p_bgg_GroupID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_bgg_GroupID > 0)
        {
          stringBuilder.Append("\n,T_BOOKMARK_GOODS AS ( SELECT bgl_GoodsCode,bgl_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) p_bgg_GroupID));
          if (p_SiteID > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) p_SiteID));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
        }
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_GOODS AS ( SELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_SalesUnit,gd_StockUnit,gd_BoxGoodsCode,gd_MakerCode,gd_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_PackUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_AbcValue"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_UseYn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsHistoryQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_isStoreTotal = false)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "gdh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add((object) "gdh_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_GoodsHistoryDiv_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          if (p_isStoreTotal && !p_param1.ContainsKey((object) "gdh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", (object) 1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
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
