// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Diff.SalesByDayDiff
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniBiz.Bo.Models.Converter;
using UniBizUtil.Util;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Diff
{
  public class SalesByDayDiff : UbModelBase<SalesByDayDiff>
  {
    private double _sbd_SlipCustomer;
    private double _sbd_GoodsCustomer;
    private double _sbd_CategoryCustomer;
    private double _sbd_SupplierCustomer;
    private double _sbd_BoxQty;
    private double _sbd_SaleQty;
    private double _sbd_DcAmtGoods;
    private double _sbd_DcAmtEvent;
    private double _sbd_DcAmtCoupon;
    private double _sbd_DcAmtPromotion;
    private double _sbd_DcAmtManual;
    private double _sbd_DcAmtMember;
    private double _sbd_EnurySlip;
    private double _sbd_EnuryEnd;
    private double _sbd_Deposit;
    private double _sbd_TotalSaleAmt;
    private double _sbd_SaleAmt;
    private double _sbd_SaleVatAmt;
    private double _sbd_SaleCostAmt;
    private double _sbd_ChargeAmt;
    private double _sbd_ProfitAmt;
    private double _sbd_PreTaxProfitAmt;
    private double _sbd_AddPoint;
    private double _sbd_PayCash;
    private double _sbd_PayCard;
    private double _sbd_PayEtc;
    private double _sbd_GoalAmount;
    private double _sbd_SaleQtyRule;
    private double _sbd_SaleAmtRule;

    public double sbd_SlipCustomer
    {
      get => this._sbd_SlipCustomer;
      set
      {
        this._sbd_SlipCustomer = value;
        this.Changed(nameof (sbd_SlipCustomer));
      }
    }

    public double sbd_GoodsCustomer
    {
      get => this._sbd_GoodsCustomer;
      set
      {
        this._sbd_GoodsCustomer = value;
        this.Changed(nameof (sbd_GoodsCustomer));
      }
    }

    public double sbd_CategoryCustomer
    {
      get => this._sbd_CategoryCustomer;
      set
      {
        this._sbd_CategoryCustomer = value;
        this.Changed(nameof (sbd_CategoryCustomer));
      }
    }

    public double sbd_SupplierCustomer
    {
      get => this._sbd_SupplierCustomer;
      set
      {
        this._sbd_SupplierCustomer = value;
        this.Changed(nameof (sbd_SupplierCustomer));
      }
    }

    public double sbd_BoxQty
    {
      get => this._sbd_BoxQty;
      set
      {
        this._sbd_BoxQty = value;
        this.Changed(nameof (sbd_BoxQty));
      }
    }

    public double sbd_SaleQty
    {
      get => this._sbd_SaleQty;
      set
      {
        this._sbd_SaleQty = value;
        this.Changed(nameof (sbd_SaleQty));
      }
    }

    public double sbd_DcAmtGoods
    {
      get => this._sbd_DcAmtGoods;
      set
      {
        this._sbd_DcAmtGoods = value;
        this.Changed(nameof (sbd_DcAmtGoods));
      }
    }

    public double sbd_DcAmtEvent
    {
      get => this._sbd_DcAmtEvent;
      set
      {
        this._sbd_DcAmtEvent = value;
        this.Changed(nameof (sbd_DcAmtEvent));
      }
    }

    public double sbd_DcAmtCoupon
    {
      get => this._sbd_DcAmtCoupon;
      set
      {
        this._sbd_DcAmtCoupon = value;
        this.Changed(nameof (sbd_DcAmtCoupon));
      }
    }

    public double sbd_DcAmtPromotion
    {
      get => this._sbd_DcAmtPromotion;
      set
      {
        this._sbd_DcAmtPromotion = value;
        this.Changed(nameof (sbd_DcAmtPromotion));
      }
    }

    public double sbd_DcAmtManual
    {
      get => this._sbd_DcAmtManual;
      set
      {
        this._sbd_DcAmtManual = value;
        this.Changed(nameof (sbd_DcAmtManual));
      }
    }

    public double sbd_DcAmtMember
    {
      get => this._sbd_DcAmtMember;
      set
      {
        this._sbd_DcAmtMember = value;
        this.Changed(nameof (sbd_DcAmtMember));
      }
    }

    public double sbd_EnurySlip
    {
      get => this._sbd_EnurySlip;
      set
      {
        this._sbd_EnurySlip = value;
        this.Changed(nameof (sbd_EnurySlip));
      }
    }

    public double sbd_EnuryEnd
    {
      get => this._sbd_EnuryEnd;
      set
      {
        this._sbd_EnuryEnd = value;
        this.Changed(nameof (sbd_EnuryEnd));
      }
    }

    public double sbd_Deposit
    {
      get => this._sbd_Deposit;
      set
      {
        this._sbd_Deposit = value;
        this.Changed(nameof (sbd_Deposit));
      }
    }

    public double sbd_TotalSaleAmt
    {
      get => this._sbd_TotalSaleAmt;
      set
      {
        this._sbd_TotalSaleAmt = value;
        this.Changed(nameof (sbd_TotalSaleAmt));
      }
    }

    public double sbd_SaleAmt
    {
      get => this._sbd_SaleAmt;
      set
      {
        this._sbd_SaleAmt = value;
        this.Changed(nameof (sbd_SaleAmt));
      }
    }

    public double sbd_SaleVatAmt
    {
      get => this._sbd_SaleVatAmt;
      set
      {
        this._sbd_SaleVatAmt = value;
        this.Changed(nameof (sbd_SaleVatAmt));
      }
    }

    public double sbd_SaleCostAmt
    {
      get => this._sbd_SaleCostAmt;
      set
      {
        this._sbd_SaleCostAmt = value;
        this.Changed(nameof (sbd_SaleCostAmt));
      }
    }

    public double sbd_ChargeAmt
    {
      get => this._sbd_ChargeAmt;
      set
      {
        this._sbd_ChargeAmt = value;
        this.Changed(nameof (sbd_ChargeAmt));
      }
    }

    public double sbd_ProfitAmt
    {
      get => this._sbd_ProfitAmt;
      set
      {
        this._sbd_ProfitAmt = value;
        this.Changed(nameof (sbd_ProfitAmt));
      }
    }

    public double sbd_PreTaxProfitAmt
    {
      get => this._sbd_PreTaxProfitAmt;
      set
      {
        this._sbd_PreTaxProfitAmt = value;
        this.Changed(nameof (sbd_PreTaxProfitAmt));
      }
    }

    public double sbd_AddPoint
    {
      get => this._sbd_AddPoint;
      set
      {
        this._sbd_AddPoint = value;
        this.Changed(nameof (sbd_AddPoint));
      }
    }

    public double sbd_PayCash
    {
      get => this._sbd_PayCash;
      set
      {
        this._sbd_PayCash = value;
        this.Changed(nameof (sbd_PayCash));
      }
    }

    public double sbd_PayCard
    {
      get => this._sbd_PayCard;
      set
      {
        this._sbd_PayCard = value;
        this.Changed(nameof (sbd_PayCard));
      }
    }

    public double sbd_PayEtc
    {
      get => this._sbd_PayEtc;
      set
      {
        this._sbd_PayEtc = value;
        this.Changed(nameof (sbd_PayEtc));
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

    public SalesByDayDiff() => this.Clear();

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SalesByDay;
      this.sbd_SlipCustomer = this.sbd_GoodsCustomer = this.sbd_CategoryCustomer = this.sbd_SupplierCustomer = 0.0;
      this.sbd_BoxQty = this.sbd_SaleQty = 0.0;
      this.sbd_DcAmtGoods = this.sbd_DcAmtEvent = this.sbd_DcAmtCoupon = this.sbd_DcAmtPromotion = this.sbd_DcAmtManual = this.sbd_DcAmtMember = 0.0;
      this.sbd_EnurySlip = this.sbd_EnuryEnd = this.sbd_Deposit = 0.0;
      this.sbd_TotalSaleAmt = this.sbd_SaleAmt = this.sbd_SaleVatAmt = this.sbd_SaleCostAmt = this.sbd_ChargeAmt = this.sbd_ProfitAmt = this.sbd_PreTaxProfitAmt = 0.0;
      this.sbd_AddPoint = 0.0;
      this.sbd_PayCash = this.sbd_PayCard = this.sbd_PayEtc = 0.0;
      this.sbd_GoalAmount = this.sbd_SaleQtyRule = this.sbd_SaleAmtRule = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SalesByDayDiff();

    public override object Clone()
    {
      SalesByDayDiff salesByDayDiff = base.Clone() as SalesByDayDiff;
      salesByDayDiff.sbd_SlipCustomer = this.sbd_SlipCustomer;
      salesByDayDiff.sbd_GoodsCustomer = this.sbd_GoodsCustomer;
      salesByDayDiff.sbd_CategoryCustomer = this.sbd_CategoryCustomer;
      salesByDayDiff.sbd_SupplierCustomer = this.sbd_SupplierCustomer;
      salesByDayDiff.sbd_BoxQty = this.sbd_BoxQty;
      salesByDayDiff.sbd_SaleQty = this.sbd_SaleQty;
      salesByDayDiff.sbd_DcAmtGoods = this.sbd_DcAmtGoods;
      salesByDayDiff.sbd_DcAmtEvent = this.sbd_DcAmtEvent;
      salesByDayDiff.sbd_DcAmtCoupon = this.sbd_DcAmtCoupon;
      salesByDayDiff.sbd_DcAmtPromotion = this.sbd_DcAmtPromotion;
      salesByDayDiff.sbd_DcAmtManual = this.sbd_DcAmtManual;
      salesByDayDiff.sbd_DcAmtMember = this.sbd_DcAmtMember;
      salesByDayDiff.sbd_EnurySlip = this.sbd_EnurySlip;
      salesByDayDiff.sbd_EnuryEnd = this.sbd_EnuryEnd;
      salesByDayDiff.sbd_Deposit = this.sbd_Deposit;
      salesByDayDiff.sbd_TotalSaleAmt = this.sbd_TotalSaleAmt;
      salesByDayDiff.sbd_SaleAmt = this.sbd_SaleAmt;
      salesByDayDiff.sbd_SaleVatAmt = this.sbd_SaleVatAmt;
      salesByDayDiff.sbd_SaleCostAmt = this.sbd_SaleCostAmt;
      salesByDayDiff.sbd_ChargeAmt = this.sbd_ChargeAmt;
      salesByDayDiff.sbd_ProfitAmt = this.sbd_ProfitAmt;
      salesByDayDiff.sbd_PreTaxProfitAmt = this.sbd_PreTaxProfitAmt;
      salesByDayDiff.sbd_AddPoint = this.sbd_AddPoint;
      salesByDayDiff.sbd_PayCash = this.sbd_PayCash;
      salesByDayDiff.sbd_PayCard = this.sbd_PayCard;
      salesByDayDiff.sbd_PayEtc = this.sbd_PayEtc;
      salesByDayDiff.sbd_GoalAmount = this.sbd_GoalAmount;
      salesByDayDiff.sbd_SaleQtyRule = this.sbd_SaleQtyRule;
      salesByDayDiff.sbd_SaleAmtRule = this.sbd_SaleAmtRule;
      return (object) salesByDayDiff;
    }

    public void PutData(SalesByDayDiff pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sbd_SlipCustomer = pSource.sbd_SlipCustomer;
      this.sbd_GoodsCustomer = pSource.sbd_GoodsCustomer;
      this.sbd_CategoryCustomer = pSource.sbd_CategoryCustomer;
      this.sbd_SupplierCustomer = pSource.sbd_SupplierCustomer;
      this.sbd_BoxQty = pSource.sbd_BoxQty;
      this.sbd_SaleQty = pSource.sbd_SaleQty;
      this.sbd_DcAmtGoods = pSource.sbd_DcAmtGoods;
      this.sbd_DcAmtEvent = pSource.sbd_DcAmtEvent;
      this.sbd_DcAmtCoupon = pSource.sbd_DcAmtCoupon;
      this.sbd_DcAmtPromotion = pSource.sbd_DcAmtPromotion;
      this.sbd_DcAmtManual = pSource.sbd_DcAmtManual;
      this.sbd_DcAmtMember = pSource.sbd_DcAmtMember;
      this.sbd_EnurySlip = pSource.sbd_EnurySlip;
      this.sbd_EnuryEnd = pSource.sbd_EnuryEnd;
      this.sbd_Deposit = pSource.sbd_Deposit;
      this.sbd_TotalSaleAmt = pSource.sbd_TotalSaleAmt;
      this.sbd_SaleAmt = pSource.sbd_SaleAmt;
      this.sbd_SaleVatAmt = pSource.sbd_SaleVatAmt;
      this.sbd_SaleCostAmt = pSource.sbd_SaleCostAmt;
      this.sbd_ChargeAmt = pSource.sbd_ChargeAmt;
      this.sbd_ProfitAmt = pSource.sbd_ProfitAmt;
      this.sbd_PreTaxProfitAmt = pSource.sbd_PreTaxProfitAmt;
      this.sbd_AddPoint = pSource.sbd_AddPoint;
      this.sbd_PayCash = pSource.sbd_PayCash;
      this.sbd_PayCard = pSource.sbd_PayCard;
      this.sbd_PayEtc = pSource.sbd_PayEtc;
      this.sbd_GoalAmount = pSource.sbd_GoalAmount;
      this.sbd_SaleQtyRule = pSource.sbd_SaleQtyRule;
      this.sbd_SaleAmtRule = pSource.sbd_SaleAmtRule;
    }

    public virtual bool CalcAddSum(SalesByDayDiff pSource)
    {
      if (pSource == null)
        return false;
      this.sbd_SlipCustomer += pSource.sbd_SlipCustomer;
      this.sbd_GoodsCustomer += pSource.sbd_GoodsCustomer;
      this.sbd_CategoryCustomer += pSource.sbd_CategoryCustomer;
      this.sbd_SupplierCustomer += pSource.sbd_SupplierCustomer;
      this.sbd_SaleQty += pSource.sbd_SaleQty;
      this.sbd_DcAmtGoods += pSource.sbd_DcAmtGoods;
      this.sbd_DcAmtEvent += pSource.sbd_DcAmtEvent;
      this.sbd_DcAmtCoupon += pSource.sbd_DcAmtCoupon;
      this.sbd_DcAmtPromotion += pSource.sbd_DcAmtPromotion;
      this.sbd_DcAmtManual += pSource.sbd_DcAmtManual;
      this.sbd_DcAmtMember += pSource.sbd_DcAmtMember;
      this.sbd_EnurySlip += pSource.sbd_EnurySlip;
      this.sbd_EnuryEnd += pSource.sbd_EnuryEnd;
      this.sbd_Deposit += pSource.sbd_Deposit;
      this.sbd_TotalSaleAmt += pSource.sbd_TotalSaleAmt;
      this.sbd_SaleAmt += pSource.sbd_SaleAmt;
      this.sbd_SaleVatAmt += pSource.sbd_SaleVatAmt;
      this.sbd_SaleCostAmt += pSource.sbd_SaleCostAmt;
      this.sbd_ChargeAmt += pSource.sbd_ChargeAmt;
      this.sbd_ProfitAmt += pSource.sbd_ProfitAmt;
      this.sbd_PreTaxProfitAmt += pSource.sbd_PreTaxProfitAmt;
      this.sbd_AddPoint += pSource.sbd_AddPoint;
      this.sbd_PayCash += pSource.sbd_PayCash;
      this.sbd_PayCard += pSource.sbd_PayCard;
      this.sbd_PayEtc += pSource.sbd_PayEtc;
      this.sbd_GoalAmount += pSource.sbd_GoalAmount;
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, SalesByDayDiff pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_SaleQty.IsZero() && pSource.sbd_SlipCustomer.IsZero() && pSource.sbd_GoodsCustomer.IsZero() && pSource.sbd_CategoryCustomer.IsZero() && pSource.sbd_SupplierCustomer.IsZero() && pSource.sbd_AddPoint.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.sbd_DcAmtGoods.IsZero() && pSource.sbd_DcAmtEvent.IsZero() && pSource.sbd_DcAmtCoupon.IsZero() && pSource.sbd_DcAmtPromotion.IsZero() && pSource.sbd_DcAmtManual.IsZero() && pSource.sbd_DcAmtMember.IsZero() && pSource.sbd_EnurySlip.IsZero() && pSource.sbd_EnuryEnd.IsZero() && pSource.sbd_Deposit.IsZero() && pSource.sbd_TotalSaleAmt.IsZero() && pSource.sbd_SaleAmt.IsZero() && pSource.sbd_SaleVatAmt.IsZero() && pSource.sbd_SaleCostAmt.IsZero() && pSource.sbd_ChargeAmt.IsZero() && pSource.sbd_ProfitAmt.IsZero() && pSource.sbd_PreTaxProfitAmt.IsZero() && pSource.sbd_PayCash.IsZero() && pSource.sbd_PayCard.IsZero() && pSource.sbd_PayEtc.IsZero() && pSource.sbd_GoalAmount.IsZero());

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);
  }
}
