// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier.SaleByDayDateSupplierBefore
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
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier
{
  public class SaleByDayDateSupplierBefore : SaleByDayDateSupplier<SaleByDayDateSupplierBefore>
  {
    private double _sbd_SlipCustomerBefore;
    private double _sbd_GoodsCustomerBefore;
    private double _sbd_CategoryCustomerBefore;
    private double _sbd_SupplierCustomerBefore;
    private double _sbd_BoxQtyBefore;
    private double _sbd_SaleQtyBefore;
    private double _sbd_DcAmtGoodsBefore;
    private double _sbd_DcAmtEventBefore;
    private double _sbd_DcAmtCouponBefore;
    private double _sbd_DcAmtPromotionBefore;
    private double _sbd_DcAmtManualBefore;
    private double _sbd_DcAmtMemberBefore;
    private double _sbd_EnurySlipBefore;
    private double _sbd_EnuryEndBefore;
    private double _sbd_DepositBefore;
    private double _sbd_TotalSaleAmtBefore;
    private double _sbd_SaleAmtBefore;
    private double _sbd_SaleVatAmtBefore;
    private double _sbd_SaleCostAmtBefore;
    private double _sbd_ChargeAmtBefore;
    private double _sbd_ProfitAmtBefore;
    private double _sbd_PreTaxProfitAmtBefore;
    private double _sbd_AddPointBefore;
    private double _sbd_PayCashBefore;
    private double _sbd_PayCardBefore;
    private double _sbd_PayEtcBefore;
    private double _sbd_GoalAmountBefore;
    private double _sbd_GoalProfitAmountBefore;
    private double _sbd_SaleQtyRuleBefore;
    private double _sbd_SaleAmtRuleBefore;
    [JsonIgnore]
    public new static string MainCol = SaleByDayDateStore.MainCol + "\n,sbd_SlipCustomerBefore,sbd_GoodsCustomerBefore,sbd_CategoryCustomerBefore,sbd_SupplierCustomerBefore,sbd_BoxQtyBefore,sbd_SaleQtyBefore,sbd_DcAmtGoodsBefore,sbd_DcAmtEventBefore,sbd_DcAmtCouponBefore,sbd_DcAmtPromotionBefore,sbd_DcAmtManualBefore,sbd_DcAmtMemberBefore,sbd_EnurySlipBefore,sbd_EnuryEndBefore,sbd_DepositBefore,sbd_TotalSaleAmtBefore,sbd_SaleAmtBefore,sbd_SaleVatAmtBefore,sbd_SaleCostAmtBefore,sbd_ChargeAmtBefore,sbd_ProfitAmtBefore,sbd_PreTaxProfitAmtBefore,sbd_AddPointBefore,sbd_PayCashBefore,sbd_PayCardBefore,sbd_PayEtcBefore,sbd_GoalAmountBefore,sbd_GoalProfitAmountBefore";
    [JsonIgnore]
    public new static string SubCol = SaleByDayDateStore.SubCol + "\n,SUM(sbd_SlipCustomerBefore) AS sbd_SlipCustomerBefore,SUM(sbd_GoodsCustomerBefore) AS sbd_GoodsCustomerBefore,SUM(sbd_CategoryCustomerBefore) AS sbd_CategoryCustomerBefore,SUM(sbd_SupplierCustomerBefore) AS sbd_SupplierCustomerBefore,SUM(sbd_BoxQtyBefore) AS sbd_BoxQtyBefore,SUM(sbd_SaleQtyBefore) AS sbd_SaleQtyBefore,SUM(sbd_DcAmtGoodsBefore) AS sbd_DcAmtGoodsBefore,SUM(sbd_DcAmtEventBefore) AS sbd_DcAmtEventBefore,SUM(sbd_DcAmtCouponBefore) AS sbd_DcAmtCouponBefore,SUM(sbd_DcAmtPromotionBefore) AS sbd_DcAmtPromotionBefore,SUM(sbd_DcAmtManualBefore) AS sbd_DcAmtManualBefore,SUM(sbd_DcAmtMemberBefore) AS sbd_DcAmtMemberBefore,SUM(sbd_EnurySlipBefore) AS sbd_EnurySlipBefore,SUM(sbd_EnuryEndBefore) AS sbd_EnuryEndBefore,SUM(sbd_DepositBefore) AS sbd_DepositBefore,SUM(sbd_TotalSaleAmtBefore) AS sbd_TotalSaleAmtBefore,SUM(sbd_SaleAmtBefore) AS sbd_SaleAmtBefore,SUM(sbd_SaleVatAmtBefore) AS sbd_SaleVatAmtBefore,SUM(sbd_SaleCostAmtBefore) AS sbd_SaleCostAmtBefore,SUM(sbd_ChargeAmtBefore) AS sbd_ChargeAmtBefore,SUM(sbd_ProfitAmtBefore) AS sbd_ProfitAmtBefore,SUM(sbd_PreTaxProfitAmtBefore) AS sbd_PreTaxProfitAmtBefore,SUM(sbd_AddPointBefore) AS sbd_AddPointBefore,SUM(sbd_PayCashBefore) AS sbd_PayCashBefore,SUM(sbd_PayCardBefore) AS sbd_PayCardBefore,SUM(sbd_PayEtcBefore) AS sbd_PayEtcBefore\n,SUM(sbd_GoalAmountBefore) AS sbd_GoalAmountBefore,SUM(sbd_GoalProfitAmountBefore) AS sbd_GoalProfitAmountBefore";
    [JsonIgnore]
    public static string BaseColMakerBefore = "\n,SUM(sbd_SlipCustomer) AS sbd_SlipCustomerBefore,SUM(sbd_GoodsCustomer) AS sbd_GoodsCustomerBefore,SUM(sbd_CategoryCustomer) AS sbd_CategoryCustomerBefore,SUM(sbd_SupplierCustomer) AS sbd_SupplierCustomerBefore,SUM(sbd_BoxQty) AS sbd_BoxQtyBefore,SUM(sbd_SaleQty) AS sbd_SaleQtyBefore,SUM(sbd_DcAmtGoods) AS sbd_DcAmtGoodsBefore,SUM(sbd_DcAmtEvent) AS sbd_DcAmtEventBefore,SUM(sbd_DcAmtCoupon) AS sbd_DcAmtCouponBefore,SUM(sbd_DcAmtPromotion) AS sbd_DcAmtPromotionBefore,SUM(sbd_DcAmtManual) AS sbd_DcAmtManualBefore,SUM(sbd_DcAmtMember) AS sbd_DcAmtMemberBefore,SUM(sbd_EnurySlip) AS sbd_EnurySlipBefore,SUM(sbd_EnuryEnd) AS sbd_EnuryEndBefore,SUM(sbd_Deposit) AS sbd_DepositBefore,SUM(sbd_TotalSaleAmt) AS sbd_TotalSaleAmtBefore,SUM(sbd_SaleAmt) AS sbd_SaleAmtBefore,SUM(sbd_SaleVatAmt) AS sbd_SaleVatAmtBefore,SUM(sbd_SaleCostAmt) AS sbd_SaleCostAmtBefore,SUM(sbd_ChargeAmt) AS sbd_ChargeAmtBefore,SUM(sbd_ProfitAmt) AS sbd_ProfitAmtBefore,SUM(sbd_PreTaxProfitAmt) AS sbd_PreTaxProfitAmtBefore,SUM(sbd_AddPoint) AS sbd_AddPointBefore,SUM(sbd_PayCash) AS sbd_PayCashBefore,SUM(sbd_PayCard) AS sbd_PayCardBefore,SUM(sbd_PayEtc) AS sbd_PayEtcBefore";
    [JsonIgnore]
    public new static string TableCol = SaleByDayDateStore.TableCol + "\n,0 AS sbd_SlipCustomerBefore,0 AS sbd_GoodsCustomerBefore,0 AS sbd_CategoryCustomerBefore,0 AS sbd_SupplierCustomerBefore,0 AS sbd_BoxQtyBefore,0 AS sbd_SaleQtyBefore,0 AS sbd_DcAmtGoodsBefore,0 AS sbd_DcAmtEventBefore,0 AS sbd_DcAmtCouponBefore,0 AS sbd_DcAmtPromotionBefore,0 AS sbd_DcAmtManualBefore,0 AS sbd_DcAmtMemberBefore,0 AS sbd_EnurySlipBefore,0 AS sbd_EnuryEndBefore,0 AS sbd_DepositBefore,0 AS sbd_TotalSaleAmtBefore,0 AS sbd_SaleAmtBefore,0 AS sbd_SaleVatAmtBefore,0 AS sbd_SaleCostAmtBefore,0 AS sbd_ChargeAmtBefore,0 AS sbd_ProfitAmtBefore,0 AS sbd_PreTaxProfitAmtBefore,0 AS sbd_AddPointBefore,0 AS sbd_PayCashBefore,0 AS sbd_PayCardBefore,0 AS sbd_PayEtcBefore,0 AS sbd_GoalAmountBefore,0 AS sbd_GoalProfitAmountBefore";
    [JsonIgnore]
    public static string TableColBefore = ",0 AS sbd_SlipCustomer,0 AS sbd_GoodsCustomer,0 AS sbd_CategoryCustomer,0 AS sbd_SupplierCustomer,0 AS sbd_BoxQty,0 AS sbd_SaleQty,0 AS sbd_DcAmtGoods,0 AS sbd_DcAmtEvent,0 AS sbd_DcAmtCoupon,0 AS sbd_DcAmtPromotion,0 AS sbd_DcAmtManual,0 AS sbd_DcAmtMember,0 AS sbd_EnurySlip,0 AS sbd_EnuryEnd,0 AS sbd_Deposit,0 AS sbd_TotalSaleAmt,0 AS sbd_SaleAmt,0 AS sbd_SaleVatAmt,0 AS sbd_SaleCostAmt,0 AS sbd_ChargeAmt,0 AS sbd_ProfitAmt,0 AS sbd_PreTaxProfitAmt,0 AS sbd_AddPoint,0 AS sbd_PayCash,0 AS sbd_PayCard,0 AS sbd_PayEtc,0 AS sbd_GoalAmount,0 AS sbd_GoalProfitAmount\n,sbd_SlipCustomerBefore,sbd_GoodsCustomerBefore,sbd_CategoryCustomerBefore,sbd_SupplierCustomerBefore,sbd_BoxQtyBefore,sbd_SaleQtyBefore,sbd_DcAmtGoodsBefore,sbd_DcAmtEventBefore,sbd_DcAmtCouponBefore,sbd_DcAmtPromotionBefore,sbd_DcAmtManualBefore,sbd_DcAmtMemberBefore,sbd_EnurySlipBefore,sbd_EnuryEndBefore,sbd_DepositBefore,sbd_TotalSaleAmtBefore,sbd_SaleAmtBefore,sbd_SaleVatAmtBefore,sbd_SaleCostAmtBefore,sbd_ChargeAmtBefore,sbd_ProfitAmtBefore,sbd_PreTaxProfitAmtBefore,sbd_AddPointBefore,sbd_PayCashBefore,sbd_PayCardBefore,sbd_PayEtcBefore,0 AS sbd_GoalAmountBefore,0 AS sbd_GoalProfitAmountBefore";

    public double sbd_SlipCustomerBefore
    {
      get => this._sbd_SlipCustomerBefore;
      set
      {
        this._sbd_SlipCustomerBefore = value;
        this.Changed(nameof (sbd_SlipCustomerBefore));
      }
    }

    public double sbd_GoodsCustomerBefore
    {
      get => this._sbd_GoodsCustomerBefore;
      set
      {
        this._sbd_GoodsCustomerBefore = value;
        this.Changed(nameof (sbd_GoodsCustomerBefore));
      }
    }

    public double sbd_CategoryCustomerBefore
    {
      get => this._sbd_CategoryCustomerBefore;
      set
      {
        this._sbd_CategoryCustomerBefore = value;
        this.Changed(nameof (sbd_CategoryCustomerBefore));
      }
    }

    public double sbd_SupplierCustomerBefore
    {
      get => this._sbd_SupplierCustomerBefore;
      set
      {
        this._sbd_SupplierCustomerBefore = value;
        this.Changed(nameof (sbd_SupplierCustomerBefore));
      }
    }

    public double sbd_BoxQtyBefore
    {
      get => this._sbd_BoxQtyBefore;
      set
      {
        this._sbd_BoxQtyBefore = value;
        this.Changed(nameof (sbd_BoxQtyBefore));
      }
    }

    public double sbd_SaleQtyBefore
    {
      get => this._sbd_SaleQtyBefore;
      set
      {
        this._sbd_SaleQtyBefore = value;
        this.Changed(nameof (sbd_SaleQtyBefore));
      }
    }

    public double sbd_DcAmtGoodsBefore
    {
      get => this._sbd_DcAmtGoodsBefore;
      set
      {
        this._sbd_DcAmtGoodsBefore = value;
        this.Changed(nameof (sbd_DcAmtGoodsBefore));
      }
    }

    public double sbd_DcAmtEventBefore
    {
      get => this._sbd_DcAmtEventBefore;
      set
      {
        this._sbd_DcAmtEventBefore = value;
        this.Changed(nameof (sbd_DcAmtEventBefore));
      }
    }

    public double sbd_DcAmtCouponBefore
    {
      get => this._sbd_DcAmtCouponBefore;
      set
      {
        this._sbd_DcAmtCouponBefore = value;
        this.Changed(nameof (sbd_DcAmtCouponBefore));
      }
    }

    public double sbd_DcAmtPromotionBefore
    {
      get => this._sbd_DcAmtPromotionBefore;
      set
      {
        this._sbd_DcAmtPromotionBefore = value;
        this.Changed(nameof (sbd_DcAmtPromotionBefore));
      }
    }

    public double sbd_DcAmtManualBefore
    {
      get => this._sbd_DcAmtManualBefore;
      set
      {
        this._sbd_DcAmtManualBefore = value;
        this.Changed(nameof (sbd_DcAmtManualBefore));
      }
    }

    public double sbd_DcAmtMemberBefore
    {
      get => this._sbd_DcAmtMemberBefore;
      set
      {
        this._sbd_DcAmtMemberBefore = value;
        this.Changed(nameof (sbd_DcAmtMemberBefore));
      }
    }

    public double sbd_EnurySlipBefore
    {
      get => this._sbd_EnurySlipBefore;
      set
      {
        this._sbd_EnurySlipBefore = value;
        this.Changed(nameof (sbd_EnurySlipBefore));
      }
    }

    public double sbd_EnuryEndBefore
    {
      get => this._sbd_EnuryEndBefore;
      set
      {
        this._sbd_EnuryEndBefore = value;
        this.Changed(nameof (sbd_EnuryEndBefore));
      }
    }

    public double sbd_DepositBefore
    {
      get => this._sbd_DepositBefore;
      set
      {
        this._sbd_DepositBefore = value;
        this.Changed(nameof (sbd_DepositBefore));
      }
    }

    public double sbd_TotalSaleAmtBefore
    {
      get => this._sbd_TotalSaleAmtBefore;
      set
      {
        this._sbd_TotalSaleAmtBefore = value;
        this.Changed(nameof (sbd_TotalSaleAmtBefore));
      }
    }

    public double sbd_SaleAmtBefore
    {
      get => this._sbd_SaleAmtBefore;
      set
      {
        this._sbd_SaleAmtBefore = value;
        this.Changed(nameof (sbd_SaleAmtBefore));
      }
    }

    public double sbd_SaleVatAmtBefore
    {
      get => this._sbd_SaleVatAmtBefore;
      set
      {
        this._sbd_SaleVatAmtBefore = value;
        this.Changed(nameof (sbd_SaleVatAmtBefore));
      }
    }

    public double sbd_SaleCostAmtBefore
    {
      get => this._sbd_SaleCostAmtBefore;
      set
      {
        this._sbd_SaleCostAmtBefore = value;
        this.Changed(nameof (sbd_SaleCostAmtBefore));
      }
    }

    public double sbd_ChargeAmtBefore
    {
      get => this._sbd_ChargeAmtBefore;
      set
      {
        this._sbd_ChargeAmtBefore = value;
        this.Changed(nameof (sbd_ChargeAmtBefore));
      }
    }

    public double sbd_ProfitAmtBefore
    {
      get => this._sbd_ProfitAmtBefore;
      set
      {
        this._sbd_ProfitAmtBefore = value;
        this.Changed(nameof (sbd_ProfitAmtBefore));
      }
    }

    public double sbd_PreTaxProfitAmtBefore
    {
      get => this._sbd_PreTaxProfitAmtBefore;
      set
      {
        this._sbd_PreTaxProfitAmtBefore = value;
        this.Changed(nameof (sbd_PreTaxProfitAmtBefore));
      }
    }

    public double sbd_AddPointBefore
    {
      get => this._sbd_AddPointBefore;
      set
      {
        this._sbd_AddPointBefore = value;
        this.Changed(nameof (sbd_AddPointBefore));
      }
    }

    public double sbd_PayCashBefore
    {
      get => this._sbd_PayCashBefore;
      set
      {
        this._sbd_PayCashBefore = value;
        this.Changed(nameof (sbd_PayCashBefore));
      }
    }

    public double sbd_PayCardBefore
    {
      get => this._sbd_PayCardBefore;
      set
      {
        this._sbd_PayCardBefore = value;
        this.Changed(nameof (sbd_PayCardBefore));
      }
    }

    public double sbd_PayEtcBefore
    {
      get => this._sbd_PayEtcBefore;
      set
      {
        this._sbd_PayEtcBefore = value;
        this.Changed(nameof (sbd_PayEtcBefore));
      }
    }

    public double sbd_GoalAmountBefore
    {
      get => this._sbd_GoalAmountBefore;
      set
      {
        this._sbd_GoalAmountBefore = value;
        this.Changed(nameof (sbd_GoalAmountBefore));
      }
    }

    public double sbd_GoalProfitAmountBefore
    {
      get => this._sbd_GoalProfitAmountBefore;
      set
      {
        this._sbd_GoalProfitAmountBefore = value;
        this.Changed(nameof (sbd_GoalProfitAmountBefore));
      }
    }

    public double sbd_SaleQtyRuleBefore
    {
      get => this._sbd_SaleQtyRuleBefore;
      set
      {
        this._sbd_SaleQtyRuleBefore = value;
        this.Changed(nameof (sbd_SaleQtyRuleBefore));
      }
    }

    public double sbd_SaleAmtRuleBefore
    {
      get => this._sbd_SaleAmtRuleBefore;
      set
      {
        this._sbd_SaleAmtRuleBefore = value;
        this.Changed(nameof (sbd_SaleAmtRuleBefore));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.sbd_SlipCustomerBefore = this.sbd_GoodsCustomerBefore = this.sbd_CategoryCustomerBefore = this.sbd_SupplierCustomerBefore = 0.0;
      this.sbd_BoxQtyBefore = this.sbd_SaleQtyBefore = 0.0;
      this.sbd_DcAmtGoodsBefore = this.sbd_DcAmtEventBefore = this.sbd_DcAmtCouponBefore = this.sbd_DcAmtPromotionBefore = this.sbd_DcAmtManualBefore = this.sbd_DcAmtMemberBefore = 0.0;
      this.sbd_EnurySlipBefore = this.sbd_EnuryEndBefore = this.sbd_DepositBefore = 0.0;
      this.sbd_TotalSaleAmtBefore = this.sbd_SaleAmtBefore = this.sbd_SaleVatAmtBefore = this.sbd_SaleCostAmtBefore = this.sbd_ChargeAmtBefore = this.sbd_ProfitAmtBefore = this.sbd_PreTaxProfitAmtBefore = 0.0;
      this.sbd_AddPointBefore = 0.0;
      this.sbd_PayCashBefore = this.sbd_PayCardBefore = this.sbd_PayEtcBefore = 0.0;
      this.sbd_GoalAmountBefore = this.sbd_SaleQtyRuleBefore = this.sbd_SaleAmtRuleBefore = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByDayDateSupplierBefore();

    public override object Clone()
    {
      SaleByDayDateSupplierBefore dateSupplierBefore = base.Clone() as SaleByDayDateSupplierBefore;
      dateSupplierBefore.sbd_SlipCustomerBefore = this.sbd_SlipCustomerBefore;
      dateSupplierBefore.sbd_GoodsCustomerBefore = this.sbd_GoodsCustomerBefore;
      dateSupplierBefore.sbd_CategoryCustomerBefore = this.sbd_CategoryCustomerBefore;
      dateSupplierBefore.sbd_SupplierCustomerBefore = this.sbd_SupplierCustomerBefore;
      dateSupplierBefore.sbd_BoxQtyBefore = this.sbd_BoxQtyBefore;
      dateSupplierBefore.sbd_SaleQtyBefore = this.sbd_SaleQtyBefore;
      dateSupplierBefore.sbd_DcAmtGoodsBefore = this.sbd_DcAmtGoodsBefore;
      dateSupplierBefore.sbd_DcAmtEventBefore = this.sbd_DcAmtEventBefore;
      dateSupplierBefore.sbd_DcAmtCouponBefore = this.sbd_DcAmtCouponBefore;
      dateSupplierBefore.sbd_DcAmtPromotionBefore = this.sbd_DcAmtPromotionBefore;
      dateSupplierBefore.sbd_DcAmtManualBefore = this.sbd_DcAmtManualBefore;
      dateSupplierBefore.sbd_DcAmtMemberBefore = this.sbd_DcAmtMemberBefore;
      dateSupplierBefore.sbd_EnurySlipBefore = this.sbd_EnurySlipBefore;
      dateSupplierBefore.sbd_EnuryEndBefore = this.sbd_EnuryEndBefore;
      dateSupplierBefore.sbd_DepositBefore = this.sbd_DepositBefore;
      dateSupplierBefore.sbd_TotalSaleAmtBefore = this.sbd_TotalSaleAmtBefore;
      dateSupplierBefore.sbd_SaleAmtBefore = this.sbd_SaleAmtBefore;
      dateSupplierBefore.sbd_SaleVatAmtBefore = this.sbd_SaleVatAmtBefore;
      dateSupplierBefore.sbd_SaleCostAmtBefore = this.sbd_SaleCostAmtBefore;
      dateSupplierBefore.sbd_ChargeAmtBefore = this.sbd_ChargeAmtBefore;
      dateSupplierBefore.sbd_ProfitAmtBefore = this.sbd_ProfitAmtBefore;
      dateSupplierBefore.sbd_PreTaxProfitAmtBefore = this.sbd_PreTaxProfitAmtBefore;
      dateSupplierBefore.sbd_AddPointBefore = this.sbd_AddPointBefore;
      dateSupplierBefore.sbd_PayCashBefore = this.sbd_PayCashBefore;
      dateSupplierBefore.sbd_PayCardBefore = this.sbd_PayCardBefore;
      dateSupplierBefore.sbd_PayEtcBefore = this.sbd_PayEtcBefore;
      dateSupplierBefore.sbd_GoalAmountBefore = this.sbd_GoalAmountBefore;
      dateSupplierBefore.sbd_SaleQtyRuleBefore = this.sbd_SaleQtyRuleBefore;
      dateSupplierBefore.sbd_SaleAmtRuleBefore = this.sbd_SaleAmtRuleBefore;
      return (object) dateSupplierBefore;
    }

    public void PutData(SaleByDayDateSupplierBefore pSource)
    {
      this.PutData((SaleByDayDateSupplier) pSource);
      this.sbd_SlipCustomerBefore = pSource.sbd_SlipCustomerBefore;
      this.sbd_GoodsCustomerBefore = pSource.sbd_GoodsCustomerBefore;
      this.sbd_CategoryCustomerBefore = pSource.sbd_CategoryCustomerBefore;
      this.sbd_SupplierCustomerBefore = pSource.sbd_SupplierCustomerBefore;
      this.sbd_BoxQtyBefore = pSource.sbd_BoxQtyBefore;
      this.sbd_SaleQtyBefore = pSource.sbd_SaleQtyBefore;
      this.sbd_DcAmtGoodsBefore = pSource.sbd_DcAmtGoodsBefore;
      this.sbd_DcAmtEventBefore = pSource.sbd_DcAmtEventBefore;
      this.sbd_DcAmtCouponBefore = pSource.sbd_DcAmtCouponBefore;
      this.sbd_DcAmtPromotionBefore = pSource.sbd_DcAmtPromotionBefore;
      this.sbd_DcAmtManualBefore = pSource.sbd_DcAmtManualBefore;
      this.sbd_DcAmtMemberBefore = pSource.sbd_DcAmtMemberBefore;
      this.sbd_EnurySlipBefore = pSource.sbd_EnurySlipBefore;
      this.sbd_EnuryEndBefore = pSource.sbd_EnuryEndBefore;
      this.sbd_DepositBefore = pSource.sbd_DepositBefore;
      this.sbd_TotalSaleAmtBefore = pSource.sbd_TotalSaleAmtBefore;
      this.sbd_SaleAmtBefore = pSource.sbd_SaleAmtBefore;
      this.sbd_SaleVatAmtBefore = pSource.sbd_SaleVatAmtBefore;
      this.sbd_SaleCostAmtBefore = pSource.sbd_SaleCostAmtBefore;
      this.sbd_ChargeAmtBefore = pSource.sbd_ChargeAmtBefore;
      this.sbd_ProfitAmtBefore = pSource.sbd_ProfitAmtBefore;
      this.sbd_PreTaxProfitAmtBefore = pSource.sbd_PreTaxProfitAmtBefore;
      this.sbd_AddPointBefore = pSource.sbd_AddPointBefore;
      this.sbd_PayCashBefore = pSource.sbd_PayCashBefore;
      this.sbd_PayCardBefore = pSource.sbd_PayCardBefore;
      this.sbd_PayEtcBefore = pSource.sbd_PayEtcBefore;
      this.sbd_GoalAmountBefore = pSource.sbd_GoalAmountBefore;
      this.sbd_SaleQtyRuleBefore = pSource.sbd_SaleQtyRuleBefore;
      this.sbd_SaleAmtRuleBefore = pSource.sbd_SaleAmtRuleBefore;
    }

    public bool CalcAddSum(SaleByDayDateSupplierBefore pSource)
    {
      if (pSource == null || !this.CalcAddSum((SaleByDayDateStore) pSource))
        return false;
      this.sbd_SlipCustomerBefore += pSource.sbd_SlipCustomerBefore;
      this.sbd_GoodsCustomerBefore += pSource.sbd_GoodsCustomerBefore;
      this.sbd_CategoryCustomerBefore += pSource.sbd_CategoryCustomerBefore;
      this.sbd_SupplierCustomerBefore += pSource.sbd_SupplierCustomerBefore;
      this.sbd_BoxQtyBefore += pSource.sbd_BoxQtyBefore;
      this.sbd_SaleQtyBefore += pSource.sbd_SaleQtyBefore;
      this.sbd_DcAmtGoodsBefore += pSource.sbd_DcAmtGoodsBefore;
      this.sbd_DcAmtEventBefore += pSource.sbd_DcAmtEventBefore;
      this.sbd_DcAmtCouponBefore += pSource.sbd_DcAmtCouponBefore;
      this.sbd_DcAmtPromotionBefore += pSource.sbd_DcAmtPromotionBefore;
      this.sbd_DcAmtManualBefore += pSource.sbd_DcAmtManualBefore;
      this.sbd_DcAmtMemberBefore += pSource.sbd_DcAmtMemberBefore;
      this.sbd_EnurySlipBefore += pSource.sbd_EnurySlipBefore;
      this.sbd_EnuryEndBefore += pSource.sbd_EnuryEndBefore;
      this.sbd_DepositBefore += pSource.sbd_DepositBefore;
      this.sbd_TotalSaleAmtBefore += pSource.sbd_TotalSaleAmtBefore;
      this.sbd_SaleAmtBefore += pSource.sbd_SaleAmtBefore;
      this.sbd_SaleVatAmtBefore += pSource.sbd_SaleVatAmtBefore;
      this.sbd_SaleCostAmtBefore += pSource.sbd_SaleCostAmtBefore;
      this.sbd_ChargeAmtBefore += pSource.sbd_ChargeAmtBefore;
      this.sbd_ProfitAmtBefore += pSource.sbd_ProfitAmtBefore;
      this.sbd_PreTaxProfitAmtBefore += pSource.sbd_PreTaxProfitAmtBefore;
      this.sbd_AddPointBefore += pSource.sbd_AddPointBefore;
      this.sbd_PayCashBefore += pSource.sbd_PayCashBefore;
      this.sbd_PayCardBefore += pSource.sbd_PayCardBefore;
      this.sbd_PayEtcBefore += pSource.sbd_PayEtcBefore;
      this.sbd_GoalAmountBefore += pSource.sbd_GoalAmountBefore;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByDayDateSupplierBefore pSource) => pSource == null || this.IsZero(pCheckType, (SaleByDayDateSupplier) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_SaleQtyBefore.IsZero() && pSource.sbd_SlipCustomerBefore.IsZero() && pSource.sbd_GoodsCustomerBefore.IsZero() && pSource.sbd_CategoryCustomerBefore.IsZero() && pSource.sbd_SupplierCustomerBefore.IsZero() && pSource.sbd_AddPointBefore.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_DcAmtGoodsBefore.IsZero() && pSource.sbd_DcAmtEventBefore.IsZero() && pSource.sbd_DcAmtCouponBefore.IsZero() && pSource.sbd_DcAmtPromotionBefore.IsZero() && pSource.sbd_DcAmtManualBefore.IsZero() && pSource.sbd_DcAmtMemberBefore.IsZero() && pSource.sbd_EnurySlipBefore.IsZero() && pSource.sbd_EnuryEndBefore.IsZero() && pSource.sbd_DepositBefore.IsZero() && pSource.sbd_TotalSaleAmtBefore.IsZero() && pSource.sbd_SaleAmtBefore.IsZero() && pSource.sbd_SaleVatAmtBefore.IsZero() && pSource.sbd_SaleCostAmtBefore.IsZero() && pSource.sbd_ChargeAmtBefore.IsZero() && pSource.sbd_ProfitAmtBefore.IsZero() && pSource.sbd_PreTaxProfitAmtBefore.IsZero() && pSource.sbd_PayCashBefore.IsZero() && pSource.sbd_PayCardBefore.IsZero() && pSource.sbd_PayEtcBefore.IsZero() && pSource.sbd_GoalAmountBefore.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.sbd_SlipCustomerBefore = p_rs.GetFieldDouble("sbd_SlipCustomerBefore");
        this.sbd_GoodsCustomerBefore = p_rs.GetFieldDouble("sbd_GoodsCustomerBefore");
        this.sbd_CategoryCustomerBefore = p_rs.GetFieldDouble("sbd_CategoryCustomerBefore");
        this.sbd_SupplierCustomerBefore = p_rs.GetFieldDouble("sbd_SupplierCustomerBefore");
        this.sbd_BoxQtyBefore = p_rs.GetFieldDouble("sbd_BoxQtyBefore");
        this.sbd_SaleQtyBefore = p_rs.GetFieldDouble("sbd_SaleQtyBefore");
        this.sbd_DcAmtGoodsBefore = p_rs.GetFieldDouble("sbd_DcAmtGoodsBefore");
        this.sbd_DcAmtEventBefore = p_rs.GetFieldDouble("sbd_DcAmtEventBefore");
        this.sbd_DcAmtCouponBefore = p_rs.GetFieldDouble("sbd_DcAmtCouponBefore");
        this.sbd_DcAmtPromotionBefore = p_rs.GetFieldDouble("sbd_DcAmtPromotionBefore");
        this.sbd_DcAmtManualBefore = p_rs.GetFieldDouble("sbd_DcAmtManualBefore");
        this.sbd_DcAmtMemberBefore = p_rs.GetFieldDouble("sbd_DcAmtMemberBefore");
        this.sbd_EnurySlipBefore = p_rs.GetFieldDouble("sbd_EnurySlipBefore");
        this.sbd_EnuryEndBefore = p_rs.GetFieldDouble("sbd_EnuryEndBefore");
        this.sbd_DepositBefore = p_rs.GetFieldDouble("sbd_DepositBefore");
        this.sbd_TotalSaleAmtBefore = p_rs.GetFieldDouble("sbd_TotalSaleAmtBefore");
        this.sbd_SaleAmtBefore = p_rs.GetFieldDouble("sbd_SaleAmtBefore");
        this.sbd_SaleVatAmtBefore = p_rs.GetFieldDouble("sbd_SaleVatAmtBefore");
        this.sbd_SaleCostAmtBefore = p_rs.GetFieldDouble("sbd_SaleCostAmtBefore");
        this.sbd_ChargeAmtBefore = p_rs.GetFieldDouble("sbd_ChargeAmtBefore");
        this.sbd_ProfitAmtBefore = p_rs.GetFieldDouble("sbd_ProfitAmtBefore");
        this.sbd_PreTaxProfitAmtBefore = p_rs.GetFieldDouble("sbd_PreTaxProfitAmtBefore");
        this.sbd_AddPointBefore = p_rs.GetFieldDouble("sbd_AddPointBefore");
        this.sbd_PayCashBefore = p_rs.GetFieldDouble("sbd_PayCashBefore");
        this.sbd_PayCardBefore = p_rs.GetFieldDouble("sbd_PayCardBefore");
        this.sbd_PayEtcBefore = p_rs.GetFieldDouble("sbd_PayEtcBefore");
        this.sbd_GoalAmountBefore = p_rs.GetFieldDouble("sbd_GoalAmountBefore");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByDayDateSupplierBefore>> SelectDateSupplierBeforeListAsync(
      object p_param)
    {
      SaleByDayDateSupplierBefore dateSupplierBefore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dateSupplierBefore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dateSupplierBefore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dateSupplierBefore1.GetSelectQuery(p_param)))
        {
          dateSupplierBefore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dateSupplierBefore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByDayDateSupplierBefore>) null;
        }
        IList<SaleByDayDateSupplierBefore> lt_list = (IList<SaleByDayDateSupplierBefore>) new List<SaleByDayDateSupplierBefore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByDayDateSupplierBefore dateSupplierBefore2 = dateSupplierBefore1.OleDB.Create<SaleByDayDateSupplierBefore>();
            if (dateSupplierBefore2.GetFieldValues(rs))
            {
              dateSupplierBefore2.row_number = lt_list.Count + 1;
              lt_list.Add(dateSupplierBefore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dateSupplierBefore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByDayDateSupplierBefore> SelectDateSupplierBeforeEnumerableAsync(
      object p_param)
    {
      SaleByDayDateSupplierBefore dateSupplierBefore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dateSupplierBefore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dateSupplierBefore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dateSupplierBefore1.GetSelectQuery(p_param)))
        {
          dateSupplierBefore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dateSupplierBefore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByDayDateSupplierBefore dateSupplierBefore2 = dateSupplierBefore1.OleDB.Create<SaleByDayDateSupplierBefore>();
            if (dateSupplierBefore2.GetFieldValues(rs))
            {
              dateSupplierBefore2.row_number = ++row_number;
              yield return dateSupplierBefore2;
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
      StringBuilder stringBuilder = new StringBuilder(new SaleByDayDateStore().GetSelectWhereAnd(p_param, false));
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

    protected Hashtable SearchConditionDefaultBefore(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEFORE_"))
          hashtable.Add((object) "sbd_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEFORE__BEGIN_"))
          hashtable.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEFORE__END_"))
          hashtable.Add((object) "sbd_SaleDate_END_", dictionaryEntry.Value);
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
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append("\n,T_BASE AS (\nSELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(",gdh_Supplier AS sbd_Supplier");
        stringBuilder.Append(SaleByDayDateStore.BaseColMaker);
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionDefault((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY");
        if (!p_isStoreTotal)
          stringBuilder.Append(" sbd_StoreCode,");
        stringBuilder.Append(" gdh_Supplier");
        stringBuilder.Append(")");
        stringBuilder.Append(",T_BEFORE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(",gdh_Supplier AS sbd_Supplier");
        stringBuilder.Append(SaleByDayDateSupplierBefore.BaseColMakerBefore);
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionDefaultBefore((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY");
        if (!p_isStoreTotal)
          stringBuilder.Append(" sbd_StoreCode,");
        stringBuilder.Append(" gdh_Supplier");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append("\nSELECT NULL AS sbd_SaleDate,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,sbd_Supplier,su_SupplierType AS sbd_SupplierType,0 AS sbd_CategoryCode,0 AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SaleByDayDateSupplierBefore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append("\n,si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,su_SupplierName,su_SupplierViewCode,su_UseYn,su_HeadSupplier,su_SupplierType,su_SupplierKind");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(SaleByDayDateSupplierBefore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(SaleByDayDateSupplierBefore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(SaleByDayDateSupplierBefore.TableColBefore);
        stringBuilder.Append("\nFROM T_BEFORE");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_StoreCode,sbd_Supplier");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\nINNER JOIN T_SUPPLIER ON sbd_Supplier=su_Supplier" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append(" ORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbd_StoreCode");
          stringBuilder.Append(",su_SupplierType,su_SupplierName,su_SupplierViewCode,su_HeadSupplier");
        }
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
  }
}
