// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.TSalesByDay
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay
{
  public class TSalesByDay : UbModelBase<TSalesByDay>
  {
    protected DateTime? _sbd_SaleDate;
    private int _sbd_StoreCode;
    private long _sbd_BoxCode;
    protected long _sbd_GoodsCode;
    protected int _sbd_Supplier;
    private int _sbd_SupplierType;
    protected int _sbd_CategoryCode;
    protected int _sbd_DeptCode;
    private int _sbd_MakerCode;
    private int _sbd_KeySeq;
    private long _sbd_SiteID;
    private int _sbd_DayOfWeek;
    private int _sbd_WeekOfYear;
    private int _sbd_DayOfYear;
    private int _sbd_SkyCondition;
    private int _sbd_TaxDiv;
    private int _sbd_SalesUnit;
    private int _sbd_StockUnit;
    private double _sbd_SlipCustomer;
    private double _sbd_GoodsCustomer;
    private double _sbd_CategoryCustomer;
    private double _sbd_SupplierCustomer;
    private double _sbd_BoxQty;
    protected double _sbd_SaleQty;
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
    protected double _sbd_SaleAmt;
    private double _sbd_SaleVatAmt;
    private double _sbd_SaleCostAmt;
    private double _sbd_ChargeAmt;
    private double _sbd_ProfitAmt;
    private double _sbd_PreTaxProfitAmt;
    private double _sbd_AddPoint;
    private double _sbd_PayCash;
    private double _sbd_PayCard;
    private double _sbd_PayEtc;

    public override object _Key => (object) new object[10]
    {
      (object) this.sbd_SaleDate,
      (object) this.sbd_StoreCode,
      (object) this.sbd_BoxCode,
      (object) this.sbd_GoodsCode,
      (object) this.sbd_Supplier,
      (object) this.sbd_SupplierType,
      (object) this.sbd_CategoryCode,
      (object) this.sbd_DeptCode,
      (object) this.sbd_MakerCode,
      (object) this.sbd_KeySeq
    };

    public virtual DateTime? sbd_SaleDate
    {
      get => this._sbd_SaleDate;
      set
      {
        this._sbd_SaleDate = value;
        this.Changed(nameof (sbd_SaleDate));
      }
    }

    public int sbd_StoreCode
    {
      get => this._sbd_StoreCode;
      set
      {
        this._sbd_StoreCode = value;
        this.Changed(nameof (sbd_StoreCode));
      }
    }

    public long sbd_BoxCode
    {
      get => this._sbd_BoxCode;
      set
      {
        this._sbd_BoxCode = value;
        this.Changed(nameof (sbd_BoxCode));
      }
    }

    public virtual long sbd_GoodsCode
    {
      get => this._sbd_GoodsCode;
      set
      {
        this._sbd_GoodsCode = value;
        this.Changed(nameof (sbd_GoodsCode));
      }
    }

    public virtual int sbd_Supplier
    {
      get => this._sbd_Supplier;
      set
      {
        this._sbd_Supplier = value;
        this.Changed(nameof (sbd_Supplier));
      }
    }

    public int sbd_SupplierType
    {
      get => this._sbd_SupplierType;
      set
      {
        this._sbd_SupplierType = value;
        this.Changed(nameof (sbd_SupplierType));
        this.Changed("sbd_SupplierTypeDesc");
      }
    }

    public string sbd_SupplierTypeDesc => this.sbd_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.sbd_SupplierType).ToDescription() : string.Empty;

    public virtual int sbd_CategoryCode
    {
      get => this._sbd_CategoryCode;
      set
      {
        this._sbd_CategoryCode = value;
        this.Changed(nameof (sbd_CategoryCode));
      }
    }

    public virtual int sbd_DeptCode
    {
      get => this._sbd_DeptCode;
      set
      {
        this._sbd_DeptCode = value;
        this.Changed(nameof (sbd_DeptCode));
      }
    }

    public int sbd_MakerCode
    {
      get => this._sbd_MakerCode;
      set
      {
        this._sbd_MakerCode = value;
        this.Changed(nameof (sbd_MakerCode));
      }
    }

    public int sbd_KeySeq
    {
      get => this._sbd_KeySeq;
      set
      {
        this._sbd_KeySeq = value;
        this.Changed(nameof (sbd_KeySeq));
      }
    }

    public long sbd_SiteID
    {
      get => this._sbd_SiteID;
      set
      {
        this._sbd_SiteID = value;
        this.Changed(nameof (sbd_SiteID));
      }
    }

    public int sbd_DayOfWeek
    {
      get => this._sbd_DayOfWeek;
      set
      {
        this._sbd_DayOfWeek = value;
        this.Changed(nameof (sbd_DayOfWeek));
      }
    }

    public int sbd_WeekOfYear
    {
      get => this._sbd_WeekOfYear;
      set
      {
        this._sbd_WeekOfYear = value;
        this.Changed(nameof (sbd_WeekOfYear));
      }
    }

    public int sbd_DayOfYear
    {
      get => this._sbd_DayOfYear;
      set
      {
        this._sbd_DayOfYear = value;
        this.Changed(nameof (sbd_DayOfYear));
      }
    }

    public int sbd_SkyCondition
    {
      get => this._sbd_SkyCondition;
      set
      {
        this._sbd_SkyCondition = value;
        this.Changed(nameof (sbd_SkyCondition));
      }
    }

    public int sbd_TaxDiv
    {
      get => this._sbd_TaxDiv;
      set
      {
        this._sbd_TaxDiv = value;
        this.Changed(nameof (sbd_TaxDiv));
        this.Changed("sbd_TaxDivDesc");
      }
    }

    public string sbd_TaxDivDesc => this.sbd_TaxDiv != 0 ? Enum2StrConverter.ToTaxDiv(this.sbd_TaxDiv).ToDescription() : string.Empty;

    public int sbd_SalesUnit
    {
      get => this._sbd_SalesUnit;
      set
      {
        this._sbd_SalesUnit = value;
        this.Changed(nameof (sbd_SalesUnit));
        this.Changed("sbd_SalesUnitDesc");
      }
    }

    public string sbd_SalesUnitDesc => this.sbd_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.sbd_SalesUnit).ToDescription() : string.Empty;

    public int sbd_StockUnit
    {
      get => this._sbd_StockUnit;
      set
      {
        this._sbd_StockUnit = value;
        this.Changed(nameof (sbd_StockUnit));
        this.Changed("sbd_StockUnitDesc");
      }
    }

    public string sbd_StockUnitDesc => this.sbd_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.sbd_StockUnit).ToDescription() : string.Empty;

    public double sbd_SlipCustomer
    {
      get => this._sbd_SlipCustomer;
      set
      {
        this._sbd_SlipCustomer = value;
        this.Changed(nameof (sbd_SlipCustomer));
        this.Changed("sbd_SlipCustomerPrice");
      }
    }

    [JsonIgnore]
    public double sbd_SlipCustomerPrice => CalcHelper.ToPersonsPrice(this.sbd_SaleAmt, this.sbd_SlipCustomer);

    public double sbd_GoodsCustomer
    {
      get => this._sbd_GoodsCustomer;
      set
      {
        this._sbd_GoodsCustomer = value;
        this.Changed(nameof (sbd_GoodsCustomer));
        this.Changed("sbd_GoodsCustomerPrice");
      }
    }

    [JsonIgnore]
    public double sbd_GoodsCustomerPrice => CalcHelper.ToPersonsPrice(this.sbd_SaleAmt, this.sbd_GoodsCustomer);

    public double sbd_CategoryCustomer
    {
      get => this._sbd_CategoryCustomer;
      set
      {
        this._sbd_CategoryCustomer = value;
        this.Changed(nameof (sbd_CategoryCustomer));
        this.Changed("sbd_CategoryCustomerPrice");
      }
    }

    [JsonIgnore]
    public double sbd_CategoryCustomerPrice => CalcHelper.ToPersonsPrice(this.sbd_SaleAmt, this.sbd_CategoryCustomer);

    public double sbd_SupplierCustomer
    {
      get => this._sbd_SupplierCustomer;
      set
      {
        this._sbd_SupplierCustomer = value;
        this.Changed(nameof (sbd_SupplierCustomer));
        this.Changed("sbd_SupplierCustomerPrice");
      }
    }

    [JsonIgnore]
    public double sbd_SupplierCustomerPrice => CalcHelper.ToPersonsPrice(this.sbd_SaleAmt, this.sbd_SupplierCustomer);

    public double sbd_BoxQty
    {
      get => this._sbd_BoxQty;
      set
      {
        this._sbd_BoxQty = value;
        this.Changed(nameof (sbd_BoxQty));
      }
    }

    public virtual double sbd_SaleQty
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

    public virtual double sbd_SaleAmt
    {
      get => this._sbd_SaleAmt;
      set
      {
        this._sbd_SaleAmt = value;
        this.Changed(nameof (sbd_SaleAmt));
        this.Changed("sbd_SlipCustomerPrice");
        this.Changed("sbd_GoodsCustomerPrice");
        this.Changed("sbd_CategoryCustomerPrice");
        this.Changed("sbd_SupplierCustomerPrice");
        this.Changed("sbd_ProfitRule");
        this.Changed("sbd_ProfitRule_ListCalc");
        this.Changed("sbd_PreTaxProfitRule");
        this.Changed("sbd_PreTaxProfitRule_ListCalc");
      }
    }

    public double sbd_SaleVatAmt
    {
      get => this._sbd_SaleVatAmt;
      set
      {
        this._sbd_SaleVatAmt = value;
        this.Changed(nameof (sbd_SaleVatAmt));
        this.Changed("sbd_ProfitRule");
        this.Changed("sbd_ProfitRule_ListCalc");
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
        this.Changed("sbd_ProfitRule");
        this.Changed("sbd_ProfitRule_ListCalc");
      }
    }

    [JsonIgnore]
    public double sbd_ProfitRule => CalcHelper.ToSaleProfitMargin(this.sbd_ProfitAmt, this.sbd_SaleAmt - this.sbd_SaleVatAmt);

    [JsonIgnore]
    public static Func<IEnumerable, object> sbd_ProfitRule_ListCalc { get; } = (Func<IEnumerable, object>) (p =>
    {
      TSalesByDay[] array = p.Cast<TSalesByDay>().ToArray<TSalesByDay>();
      return (object) CalcHelper.ToSaleProfitMargin(((IEnumerable<TSalesByDay>) array).Sum<TSalesByDay>((Func<TSalesByDay, double>) (it => it == null ? 0.0 : it.sbd_ProfitAmt)), ((IEnumerable<TSalesByDay>) array).Sum<TSalesByDay>((Func<TSalesByDay, double>) (it => it == null ? 0.0 : it.sbd_SaleAmt)) - ((IEnumerable<TSalesByDay>) array).Sum<TSalesByDay>((Func<TSalesByDay, double>) (it => it == null ? 0.0 : it.sbd_SaleVatAmt)));
    });

    public double sbd_PreTaxProfitAmt
    {
      get => this._sbd_PreTaxProfitAmt;
      set
      {
        this._sbd_PreTaxProfitAmt = value;
        this.Changed(nameof (sbd_PreTaxProfitAmt));
        this.Changed("sbd_PreTaxProfitRule");
        this.Changed("sbd_PreTaxProfitRule_ListCalc");
      }
    }

    [JsonIgnore]
    public double sbd_PreTaxProfitRule => CalcHelper.ToSaleProfitMargin(this.sbd_PreTaxProfitAmt, this.sbd_SaleAmt);

    [JsonIgnore]
    public static Func<IEnumerable, object> sbd_PreTaxProfitRule_ListCalc { get; } = (Func<IEnumerable, object>) (p =>
    {
      TSalesByDay[] array = p.Cast<TSalesByDay>().ToArray<TSalesByDay>();
      return (object) CalcHelper.ToSaleProfitMargin(((IEnumerable<TSalesByDay>) array).Sum<TSalesByDay>((Func<TSalesByDay, double>) (it => it == null ? 0.0 : it.sbd_PreTaxProfitAmt)), ((IEnumerable<TSalesByDay>) array).Sum<TSalesByDay>((Func<TSalesByDay, double>) (it => it == null ? 0.0 : it.sbd_SaleAmt)));
    });

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

    public TSalesByDay() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sbd_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "sbd_SaleDate",
        tc_trans_name = "판매일자"
      });
      columnInfo.Add("sbd_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("sbd_BoxCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_BoxCode",
        tc_trans_name = "BOXCODE"
      });
      columnInfo.Add("sbd_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("sbd_Supplier", new TTableColumn()
      {
        tc_orgin_name = "sbd_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("sbd_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "sbd_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("sbd_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_CategoryCode",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("sbd_DeptCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_DeptCode",
        tc_trans_name = "부서ID"
      });
      columnInfo.Add("sbd_MakerCode", new TTableColumn()
      {
        tc_orgin_name = "sbd_MakerCode",
        tc_trans_name = "제조사코드"
      });
      columnInfo.Add("sbd_KeySeq", new TTableColumn()
      {
        tc_orgin_name = "sbd_KeySeq",
        tc_trans_name = "KEY"
      });
      columnInfo.Add("sbd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sbd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sbd_DayOfWeek", new TTableColumn()
      {
        tc_orgin_name = "sbd_DayOfWeek",
        tc_trans_name = "요일 "
      });
      columnInfo.Add("sbd_WeekOfYear", new TTableColumn()
      {
        tc_orgin_name = "sbd_WeekOfYear",
        tc_trans_name = "년주차 "
      });
      columnInfo.Add("sbd_DayOfYear", new TTableColumn()
      {
        tc_orgin_name = "sbd_DayOfYear",
        tc_trans_name = "일수 "
      });
      columnInfo.Add("sbd_SkyCondition", new TTableColumn()
      {
        tc_orgin_name = "sbd_SkyCondition",
        tc_trans_name = "날씨 "
      });
      columnInfo.Add("sbd_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "sbd_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51
      });
      columnInfo.Add("sbd_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "sbd_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("sbd_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "sbd_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("sbd_SlipCustomer", new TTableColumn()
      {
        tc_orgin_name = "sbd_SlipCustomer",
        tc_trans_name = "객수"
      });
      columnInfo.Add("sbd_GoodsCustomer", new TTableColumn()
      {
        tc_orgin_name = "sbd_GoodsCustomer",
        tc_trans_name = "객수"
      });
      columnInfo.Add("sbd_CategoryCustomer", new TTableColumn()
      {
        tc_orgin_name = "sbd_CategoryCustomer",
        tc_trans_name = "객수"
      });
      columnInfo.Add("sbd_SupplierCustomer", new TTableColumn()
      {
        tc_orgin_name = "sbd_SupplierCustomer",
        tc_trans_name = "객수"
      });
      columnInfo.Add("sbd_BoxQty", new TTableColumn()
      {
        tc_orgin_name = "sbd_BoxQty",
        tc_trans_name = "매출BOX수량"
      });
      columnInfo.Add("sbd_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "sbd_SaleQty",
        tc_trans_name = "매출수량"
      });
      columnInfo.Add("sbd_DcAmtGoods", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtGoods",
        tc_trans_name = "행사할인"
      });
      columnInfo.Add("sbd_DcAmtEvent", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtEvent",
        tc_trans_name = "이벤트할인"
      });
      columnInfo.Add("sbd_DcAmtCoupon", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtCoupon",
        tc_trans_name = "쿠폰할인"
      });
      columnInfo.Add("sbd_DcAmtPromotion", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtPromotion",
        tc_trans_name = "프로모션할인"
      });
      columnInfo.Add("sbd_DcAmtManual", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtManual",
        tc_trans_name = "키할인"
      });
      columnInfo.Add("sbd_DcAmtMember", new TTableColumn()
      {
        tc_orgin_name = "sbd_DcAmtMember",
        tc_trans_name = "회원할인"
      });
      columnInfo.Add("sbd_EnurySlip", new TTableColumn()
      {
        tc_orgin_name = "sbd_EnurySlip",
        tc_trans_name = "영수증에누리"
      });
      columnInfo.Add("sbd_EnuryEnd", new TTableColumn()
      {
        tc_orgin_name = "sbd_EnuryEnd",
        tc_trans_name = "끝전에누리"
      });
      columnInfo.Add("sbd_Deposit", new TTableColumn()
      {
        tc_orgin_name = "sbd_Deposit",
        tc_trans_name = "보증금"
      });
      columnInfo.Add("sbd_TotalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_TotalSaleAmt",
        tc_trans_name = "총매출금액"
      });
      columnInfo.Add("sbd_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_SaleAmt",
        tc_trans_name = "매출금액"
      });
      columnInfo.Add("sbd_SaleVatAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_SaleVatAmt",
        tc_trans_name = "매출부가세"
      });
      columnInfo.Add("sbd_SaleCostAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_SaleCostAmt",
        tc_trans_name = "세제외매출"
      });
      columnInfo.Add("sbd_ChargeAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_ChargeAmt",
        tc_trans_name = "판매수수료"
      });
      columnInfo.Add("sbd_ProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_ProfitAmt",
        tc_trans_name = "세제외이익",
        tc_col_hint = "[세제외이익(sbd_ProfitAmt)은 마스타원가로 계산됨]"
      });
      columnInfo.Add("sbd_PreTaxProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "sbd_PreTaxProfitAmt",
        tc_trans_name = "세포함이익"
      });
      columnInfo.Add("sbd_AddPoint", new TTableColumn()
      {
        tc_orgin_name = "sbd_AddPoint",
        tc_trans_name = "발생포인트"
      });
      columnInfo.Add("sbd_PayCash", new TTableColumn()
      {
        tc_orgin_name = "sbd_PayCash",
        tc_trans_name = "현금결제"
      });
      columnInfo.Add("sbd_PayCard", new TTableColumn()
      {
        tc_orgin_name = "sbd_PayCard",
        tc_trans_name = "카드결제"
      });
      columnInfo.Add("sbd_PayEtc", new TTableColumn()
      {
        tc_orgin_name = "sbd_PayEtc",
        tc_trans_name = "기타"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SalesByDay;
      this.sbd_SaleDate = new DateTime?();
      this.sbd_StoreCode = 0;
      this.sbd_BoxCode = this.sbd_GoodsCode = 0L;
      this.sbd_Supplier = this.sbd_SupplierType = this.sbd_CategoryCode = this.sbd_DeptCode = this.sbd_MakerCode = this.sbd_KeySeq = 0;
      this.sbd_SiteID = 0L;
      this.sbd_DayOfWeek = this.sbd_WeekOfYear = this.sbd_DayOfYear = this.sbd_SkyCondition = 0;
      this.sbd_TaxDiv = this.sbd_SalesUnit = this.sbd_StockUnit = 0;
      this.sbd_SlipCustomer = this.sbd_GoodsCustomer = this.sbd_CategoryCustomer = this.sbd_SupplierCustomer = 0.0;
      this.sbd_BoxQty = this.sbd_SaleQty = 0.0;
      this.sbd_DcAmtGoods = this.sbd_DcAmtEvent = this.sbd_DcAmtCoupon = this.sbd_DcAmtPromotion = this.sbd_DcAmtManual = this.sbd_DcAmtMember = 0.0;
      this.sbd_EnurySlip = this.sbd_EnuryEnd = this.sbd_Deposit = 0.0;
      this.sbd_TotalSaleAmt = this.sbd_SaleAmt = this.sbd_SaleVatAmt = this.sbd_SaleCostAmt = this.sbd_ChargeAmt = this.sbd_ProfitAmt = this.sbd_PreTaxProfitAmt = 0.0;
      this.sbd_AddPoint = 0.0;
      this.sbd_PayCash = this.sbd_PayCard = this.sbd_PayEtc = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSalesByDay();

    public override object Clone()
    {
      TSalesByDay tsalesByDay = base.Clone() as TSalesByDay;
      tsalesByDay.sbd_SaleDate = this.sbd_SaleDate;
      tsalesByDay.sbd_StoreCode = this.sbd_StoreCode;
      tsalesByDay.sbd_BoxCode = this.sbd_BoxCode;
      tsalesByDay.sbd_GoodsCode = this.sbd_GoodsCode;
      tsalesByDay.sbd_Supplier = this.sbd_Supplier;
      tsalesByDay.sbd_SupplierType = this.sbd_SupplierType;
      tsalesByDay.sbd_CategoryCode = this.sbd_CategoryCode;
      tsalesByDay.sbd_DeptCode = this.sbd_DeptCode;
      tsalesByDay.sbd_MakerCode = this.sbd_MakerCode;
      tsalesByDay.sbd_KeySeq = this.sbd_KeySeq;
      tsalesByDay.sbd_SiteID = this.sbd_SiteID;
      tsalesByDay.sbd_DayOfWeek = this.sbd_DayOfWeek;
      tsalesByDay.sbd_WeekOfYear = this.sbd_WeekOfYear;
      tsalesByDay.sbd_DayOfYear = this.sbd_DayOfYear;
      tsalesByDay.sbd_SkyCondition = this.sbd_SkyCondition;
      tsalesByDay.sbd_TaxDiv = this.sbd_TaxDiv;
      tsalesByDay.sbd_SalesUnit = this.sbd_SalesUnit;
      tsalesByDay.sbd_StockUnit = this.sbd_StockUnit;
      tsalesByDay.sbd_SlipCustomer = this.sbd_SlipCustomer;
      tsalesByDay.sbd_GoodsCustomer = this.sbd_GoodsCustomer;
      tsalesByDay.sbd_CategoryCustomer = this.sbd_CategoryCustomer;
      tsalesByDay.sbd_SupplierCustomer = this.sbd_SupplierCustomer;
      tsalesByDay.sbd_BoxQty = this.sbd_BoxQty;
      tsalesByDay.sbd_SaleQty = this.sbd_SaleQty;
      tsalesByDay.sbd_DcAmtGoods = this.sbd_DcAmtGoods;
      tsalesByDay.sbd_DcAmtEvent = this.sbd_DcAmtEvent;
      tsalesByDay.sbd_DcAmtCoupon = this.sbd_DcAmtCoupon;
      tsalesByDay.sbd_DcAmtPromotion = this.sbd_DcAmtPromotion;
      tsalesByDay.sbd_DcAmtManual = this.sbd_DcAmtManual;
      tsalesByDay.sbd_DcAmtMember = this.sbd_DcAmtMember;
      tsalesByDay.sbd_EnurySlip = this.sbd_EnurySlip;
      tsalesByDay.sbd_EnuryEnd = this.sbd_EnuryEnd;
      tsalesByDay.sbd_Deposit = this.sbd_Deposit;
      tsalesByDay.sbd_TotalSaleAmt = this.sbd_TotalSaleAmt;
      tsalesByDay.sbd_SaleAmt = this.sbd_SaleAmt;
      tsalesByDay.sbd_SaleVatAmt = this.sbd_SaleVatAmt;
      tsalesByDay.sbd_SaleCostAmt = this.sbd_SaleCostAmt;
      tsalesByDay.sbd_ChargeAmt = this.sbd_ChargeAmt;
      tsalesByDay.sbd_ProfitAmt = this.sbd_ProfitAmt;
      tsalesByDay.sbd_PreTaxProfitAmt = this.sbd_PreTaxProfitAmt;
      tsalesByDay.sbd_AddPoint = this.sbd_AddPoint;
      tsalesByDay.sbd_PayCash = this.sbd_PayCash;
      tsalesByDay.sbd_PayCard = this.sbd_PayCard;
      tsalesByDay.sbd_PayEtc = this.sbd_PayEtc;
      return (object) tsalesByDay;
    }

    public void PutData(TSalesByDay pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sbd_SaleDate = pSource.sbd_SaleDate;
      this.sbd_StoreCode = pSource.sbd_StoreCode;
      this.sbd_BoxCode = pSource.sbd_BoxCode;
      this.sbd_GoodsCode = pSource.sbd_GoodsCode;
      this.sbd_Supplier = pSource.sbd_Supplier;
      this.sbd_SupplierType = pSource.sbd_SupplierType;
      this.sbd_CategoryCode = pSource.sbd_CategoryCode;
      this.sbd_DeptCode = pSource.sbd_DeptCode;
      this.sbd_MakerCode = pSource.sbd_MakerCode;
      this.sbd_KeySeq = pSource.sbd_KeySeq;
      this.sbd_SiteID = pSource.sbd_SiteID;
      this.sbd_DayOfWeek = pSource.sbd_DayOfWeek;
      this.sbd_WeekOfYear = pSource.sbd_WeekOfYear;
      this.sbd_DayOfYear = pSource.sbd_DayOfYear;
      this.sbd_SkyCondition = pSource.sbd_SkyCondition;
      this.sbd_TaxDiv = pSource.sbd_TaxDiv;
      this.sbd_SalesUnit = pSource.sbd_SalesUnit;
      this.sbd_StockUnit = pSource.sbd_StockUnit;
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
    }

    public virtual bool CalcAddSum(TSalesByDay pSource)
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
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, TSalesByDay pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.sbd_SaleQty.IsZero() && pSource.sbd_SlipCustomer.IsZero() && pSource.sbd_GoodsCustomer.IsZero() && pSource.sbd_CategoryCustomer.IsZero() && pSource.sbd_SupplierCustomer.IsZero() && pSource.sbd_AddPoint.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_DcAmtGoods.IsZero() && pSource.sbd_DcAmtEvent.IsZero() && pSource.sbd_DcAmtCoupon.IsZero() && pSource.sbd_DcAmtPromotion.IsZero() && pSource.sbd_DcAmtManual.IsZero() && pSource.sbd_DcAmtMember.IsZero() && pSource.sbd_EnurySlip.IsZero() && pSource.sbd_EnuryEnd.IsZero() && pSource.sbd_Deposit.IsZero() && pSource.sbd_TotalSaleAmt.IsZero() && pSource.sbd_SaleAmt.IsZero() && pSource.sbd_SaleVatAmt.IsZero() && pSource.sbd_SaleCostAmt.IsZero() && pSource.sbd_ChargeAmt.IsZero() && pSource.sbd_ProfitAmt.IsZero() && pSource.sbd_PreTaxProfitAmt.IsZero() && pSource.sbd_PayCash.IsZero() && pSource.sbd_PayCard.IsZero() && pSource.sbd_PayEtc.IsZero());

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sbd_SaleDate = p_rs.GetFieldDateTime("sbd_SaleDate");
        this.sbd_StoreCode = p_rs.GetFieldInt("sbd_StoreCode");
        if (this.sbd_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sbd_BoxCode = p_rs.GetFieldLong("sbd_BoxCode");
        this.sbd_GoodsCode = p_rs.GetFieldLong("sbd_GoodsCode");
        this.sbd_Supplier = p_rs.GetFieldInt("sbd_Supplier");
        this.sbd_SupplierType = p_rs.GetFieldInt("sbd_SupplierType");
        this.sbd_CategoryCode = p_rs.GetFieldInt("sbd_CategoryCode");
        this.sbd_DeptCode = p_rs.GetFieldInt("sbd_DeptCode");
        this.sbd_MakerCode = p_rs.GetFieldInt("sbd_MakerCode");
        this.sbd_KeySeq = p_rs.GetFieldInt("sbd_KeySeq");
        this.sbd_SiteID = p_rs.GetFieldLong("sbd_SiteID");
        this.sbd_DayOfWeek = p_rs.GetFieldInt("sbd_DayOfWeek");
        this.sbd_WeekOfYear = p_rs.GetFieldInt("sbd_WeekOfYear");
        this.sbd_DayOfYear = p_rs.GetFieldInt("sbd_DayOfYear");
        this.sbd_SkyCondition = p_rs.GetFieldInt("sbd_SkyCondition");
        this.sbd_TaxDiv = p_rs.GetFieldInt("sbd_TaxDiv");
        this.sbd_SalesUnit = p_rs.GetFieldInt("sbd_SalesUnit");
        this.sbd_StockUnit = p_rs.GetFieldInt("sbd_StockUnit");
        this.sbd_SlipCustomer = p_rs.GetFieldDouble("sbd_SlipCustomer");
        this.sbd_GoodsCustomer = p_rs.GetFieldDouble("sbd_GoodsCustomer");
        this.sbd_CategoryCustomer = p_rs.GetFieldDouble("sbd_CategoryCustomer");
        this.sbd_SupplierCustomer = p_rs.GetFieldDouble("sbd_SupplierCustomer");
        this.sbd_BoxQty = p_rs.GetFieldDouble("sbd_BoxQty");
        this.sbd_SaleQty = p_rs.GetFieldDouble("sbd_SaleQty");
        this.sbd_DcAmtGoods = p_rs.GetFieldDouble("sbd_DcAmtGoods");
        this.sbd_DcAmtEvent = p_rs.GetFieldDouble("sbd_DcAmtEvent");
        this.sbd_DcAmtCoupon = p_rs.GetFieldDouble("sbd_DcAmtCoupon");
        this.sbd_DcAmtPromotion = p_rs.GetFieldDouble("sbd_DcAmtPromotion");
        this.sbd_DcAmtManual = p_rs.GetFieldDouble("sbd_DcAmtManual");
        this.sbd_DcAmtMember = p_rs.GetFieldDouble("sbd_DcAmtMember");
        this.sbd_EnurySlip = p_rs.GetFieldDouble("sbd_EnurySlip");
        this.sbd_EnuryEnd = p_rs.GetFieldDouble("sbd_EnuryEnd");
        this.sbd_Deposit = p_rs.GetFieldDouble("sbd_Deposit");
        this.sbd_TotalSaleAmt = p_rs.GetFieldDouble("sbd_TotalSaleAmt");
        this.sbd_SaleAmt = p_rs.GetFieldDouble("sbd_SaleAmt");
        this.sbd_SaleVatAmt = p_rs.GetFieldDouble("sbd_SaleVatAmt");
        this.sbd_SaleCostAmt = p_rs.GetFieldDouble("sbd_SaleCostAmt");
        this.sbd_ChargeAmt = p_rs.GetFieldDouble("sbd_ChargeAmt");
        this.sbd_ProfitAmt = p_rs.GetFieldDouble("sbd_ProfitAmt");
        this.sbd_PreTaxProfitAmt = p_rs.GetFieldDouble("sbd_PreTaxProfitAmt");
        this.sbd_AddPoint = p_rs.GetFieldDouble("sbd_AddPoint");
        this.sbd_PayCash = p_rs.GetFieldDouble("sbd_PayCash");
        this.sbd_PayCard = p_rs.GetFieldDouble("sbd_PayCard");
        this.sbd_PayEtc = p_rs.GetFieldDouble("sbd_PayEtc");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " sbd_SaleDate,sbd_StoreCode,sbd_BoxCode,sbd_GoodsCode,sbd_Supplier,sbd_SupplierType,sbd_CategoryCode,sbd_DeptCode,sbd_MakerCode,sbd_KeySeq,sbd_SiteID,sbd_DayOfWeek,sbd_WeekOfYear,sbd_DayOfYear,sbd_SkyCondition,sbd_TaxDiv,sbd_SalesUnit,sbd_StockUnit,sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc) VALUES (  '" + this.sbd_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(",{0},{1},{2}", (object) this.sbd_StoreCode, (object) this.sbd_BoxCode, (object) this.sbd_GoodsCode) + string.Format(",{0},{1},{2}", (object) this.sbd_Supplier, (object) this.sbd_SupplierType, (object) this.sbd_CategoryCode) + string.Format(",{0},{1},{2}", (object) this.sbd_DeptCode, (object) this.sbd_MakerCode, (object) this.sbd_KeySeq) + string.Format(",{0}", (object) this.sbd_SiteID) + string.Format(",{0},{1},{2},{3}", (object) this.sbd_DayOfWeek, (object) this.sbd_WeekOfYear, (object) this.sbd_DayOfYear, (object) this.sbd_SkyCondition) + string.Format(",{0},{1},{2}", (object) this.sbd_TaxDiv, (object) this.sbd_SalesUnit, (object) this.sbd_StockUnit) + "," + this.sbd_SlipCustomer.FormatTo("{0:0.0000}") + "," + this.sbd_GoodsCustomer.FormatTo("{0:0.0000}") + "," + this.sbd_CategoryCustomer.FormatTo("{0:0.0000}") + "," + this.sbd_SupplierCustomer.FormatTo("{0:0.0000}") + "," + this.sbd_BoxQty.FormatTo("{0:0.0000}") + "," + this.sbd_SaleQty.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtGoods.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtEvent.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtCoupon.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtPromotion.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtManual.FormatTo("{0:0.0000}") + "," + this.sbd_DcAmtMember.FormatTo("{0:0.0000}") + "," + this.sbd_EnurySlip.FormatTo("{0:0.0000}") + "," + this.sbd_EnuryEnd.FormatTo("{0:0.0000}") + "," + this.sbd_Deposit.FormatTo("{0:0.0000}") + "," + this.sbd_TotalSaleAmt.FormatTo("{0:0.0000}") + "," + this.sbd_SaleAmt.FormatTo("{0:0.0000}") + "," + this.sbd_SaleVatAmt.FormatTo("{0:0.0000}") + "," + this.sbd_SaleCostAmt.FormatTo("{0:0.0000}") + "," + this.sbd_ChargeAmt.FormatTo("{0:0.0000}") + "," + this.sbd_ProfitAmt.FormatTo("{0:0.0000}") + "," + this.sbd_PreTaxProfitAmt.FormatTo("{0:0.0000}") + "," + this.sbd_AddPoint.FormatTo("{0:0.0000}") + string.Format(",{0},{1},{2}", (object) this.sbd_PayCash, (object) this.sbd_PayCard, (object) this.sbd_PayEtc) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbd_SaleDate, (object) this.sbd_StoreCode, (object) this.sbd_BoxCode, (object) this.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) this.sbd_Supplier, (object) this.sbd_SupplierType, (object) this.sbd_CategoryCode, (object) this.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) this.sbd_MakerCode, (object) this.sbd_KeySeq, (object) this.sbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSalesByDay tsalesByDay = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByDay.\u003C\u003En__0();
      if (await tsalesByDay.OleDB.ExecuteAsync(tsalesByDay.InsertQuery()))
        return true;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      tsalesByDay.message = " " + tsalesByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByDay.sbd_SaleDate, (object) __nonvirtual (tsalesByDay.sbd_StoreCode), (object) tsalesByDay.sbd_BoxCode, (object) tsalesByDay.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) tsalesByDay.sbd_Supplier, (object) tsalesByDay.sbd_SupplierType, (object) tsalesByDay.sbd_CategoryCode, (object) tsalesByDay.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) tsalesByDay.sbd_MakerCode, (object) tsalesByDay.sbd_KeySeq, (object) __nonvirtual (tsalesByDay.sbd_SiteID)) + " 내용 : " + tsalesByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByDay.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " sbd_SlipCustomer=" + this.sbd_SlipCustomer.FormatTo("{0:0.0000}") + ",sbd_GoodsCustomer=" + this.sbd_GoodsCustomer.FormatTo("{0:0.0000}") + ",sbd_CategoryCustomer=" + this.sbd_CategoryCustomer.FormatTo("{0:0.0000}") + ",sbd_SupplierCustomer=" + this.sbd_SupplierCustomer.FormatTo("{0:0.0000}") + ",sbd_BoxQty=" + this.sbd_BoxQty.FormatTo("{0:0.0000}") + ",sbd_SaleQty=" + this.sbd_SaleQty.FormatTo("{0:0.0000}") + ",sbd_DcAmtGoods=" + this.sbd_DcAmtGoods.FormatTo("{0:0.0000}") + ",sbd_DcAmtEvent=" + this.sbd_DcAmtEvent.FormatTo("{0:0.0000}") + ",sbd_DcAmtCoupon=" + this.sbd_DcAmtCoupon.FormatTo("{0:0.0000}") + ",sbd_DcAmtPromotion=" + this.sbd_DcAmtPromotion.FormatTo("{0:0.0000}") + ",sbd_DcAmtManual=" + this.sbd_DcAmtManual.FormatTo("{0:0.0000}") + ",sbd_DcAmtMember=" + this.sbd_DcAmtMember.FormatTo("{0:0.0000}") + ",sbd_EnurySlip=" + this.sbd_EnurySlip.FormatTo("{0:0.0000}") + ",sbd_EnuryEnd=" + this.sbd_EnuryEnd.FormatTo("{0:0.0000}") + ",sbd_Deposit=" + this.sbd_Deposit.FormatTo("{0:0.0000}") + ",sbd_TotalSaleAmt=" + this.sbd_TotalSaleAmt.FormatTo("{0:0.0000}") + ",sbd_SaleAmt=" + this.sbd_SaleAmt.FormatTo("{0:0.0000}") + ",sbd_SaleVatAmt=" + this.sbd_SaleVatAmt.FormatTo("{0:0.0000}") + ",sbd_SaleCostAmt=" + this.sbd_SaleCostAmt.FormatTo("{0:0.0000}") + ",sbd_ChargeAmt=" + this.sbd_ChargeAmt.FormatTo("{0:0.0000}") + ",sbd_ProfitAmt=" + this.sbd_ProfitAmt.FormatTo("{0:0.0000}") + ",sbd_PreTaxProfitAmt=" + this.sbd_PreTaxProfitAmt.FormatTo("{0:0.0000}") + ",sbd_AddPoint=" + this.sbd_AddPoint.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sbd_PayCash", (object) this.sbd_PayCash, (object) "sbd_PayCard", (object) this.sbd_PayCard, (object) "sbd_PayEtc", (object) this.sbd_PayEtc) + " WHERE sbd_SaleDate='" + this.sbd_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "sbd_StoreCode", (object) this.sbd_StoreCode) + string.Format(" AND {0}={1}", (object) "sbd_BoxCode", (object) this.sbd_BoxCode) + string.Format(" AND {0}={1}", (object) "sbd_GoodsCode", (object) this.sbd_GoodsCode) + string.Format(" AND {0}={1}", (object) "sbd_Supplier", (object) this.sbd_Supplier) + string.Format(" AND {0}={1}", (object) "sbd_SupplierType", (object) this.sbd_SupplierType) + string.Format(" AND {0}={1}", (object) "sbd_CategoryCode", (object) this.sbd_CategoryCode) + string.Format(" AND {0}={1}", (object) "sbd_DeptCode", (object) this.sbd_DeptCode) + string.Format(" AND {0}={1}", (object) "sbd_MakerCode", (object) this.sbd_MakerCode) + string.Format(" AND {0}={1}", (object) "sbd_KeySeq", (object) this.sbd_KeySeq) + string.Format(" AND {0}={1}", (object) "sbd_SiteID", (object) this.sbd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbd_SaleDate, (object) this.sbd_StoreCode, (object) this.sbd_BoxCode, (object) this.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) this.sbd_Supplier, (object) this.sbd_SupplierType, (object) this.sbd_CategoryCode, (object) this.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) this.sbd_MakerCode, (object) this.sbd_KeySeq, (object) this.sbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSalesByDay tsalesByDay = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByDay.\u003C\u003En__1();
      if (await tsalesByDay.OleDB.ExecuteAsync(tsalesByDay.UpdateQuery()))
        return true;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      tsalesByDay.message = " " + tsalesByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByDay.sbd_SaleDate, (object) __nonvirtual (tsalesByDay.sbd_StoreCode), (object) tsalesByDay.sbd_BoxCode, (object) tsalesByDay.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) tsalesByDay.sbd_Supplier, (object) tsalesByDay.sbd_SupplierType, (object) tsalesByDay.sbd_CategoryCode, (object) tsalesByDay.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) tsalesByDay.sbd_MakerCode, (object) tsalesByDay.sbd_KeySeq, (object) __nonvirtual (tsalesByDay.sbd_SiteID)) + " 내용 : " + tsalesByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByDay.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(" sbd_SlipCustomer=" + this.sbd_SlipCustomer.FormatTo("{0:0.0000}") + ",sbd_GoodsCustomer=" + this.sbd_GoodsCustomer.FormatTo("{0:0.0000}") + ",sbd_CategoryCustomer=" + this.sbd_CategoryCustomer.FormatTo("{0:0.0000}") + ",sbd_SupplierCustomer=" + this.sbd_SupplierCustomer.FormatTo("{0:0.0000}") + ",sbd_BoxQty=" + this.sbd_BoxQty.FormatTo("{0:0.0000}") + ",sbd_SaleQty=" + this.sbd_SaleQty.FormatTo("{0:0.0000}") + ",sbd_DcAmtGoods=" + this.sbd_DcAmtGoods.FormatTo("{0:0.0000}") + ",sbd_DcAmtEvent=" + this.sbd_DcAmtEvent.FormatTo("{0:0.0000}") + ",sbd_DcAmtCoupon=" + this.sbd_DcAmtCoupon.FormatTo("{0:0.0000}") + ",sbd_DcAmtPromotion=" + this.sbd_DcAmtPromotion.FormatTo("{0:0.0000}") + ",sbd_DcAmtManual=" + this.sbd_DcAmtManual.FormatTo("{0:0.0000}") + ",sbd_DcAmtMember=" + this.sbd_DcAmtMember.FormatTo("{0:0.0000}") + ",sbd_EnurySlip=" + this.sbd_EnurySlip.FormatTo("{0:0.0000}") + ",sbd_EnuryEnd=" + this.sbd_EnuryEnd.FormatTo("{0:0.0000}") + ",sbd_Deposit=" + this.sbd_Deposit.FormatTo("{0:0.0000}") + ",sbd_TotalSaleAmt=" + this.sbd_TotalSaleAmt.FormatTo("{0:0.0000}") + ",sbd_SaleAmt=" + this.sbd_SaleAmt.FormatTo("{0:0.0000}") + ",sbd_SaleVatAmt=" + this.sbd_SaleVatAmt.FormatTo("{0:0.0000}") + ",sbd_SaleCostAmt=" + this.sbd_SaleCostAmt.FormatTo("{0:0.0000}") + ",sbd_ChargeAmt=" + this.sbd_ChargeAmt.FormatTo("{0:0.0000}") + ",sbd_ProfitAmt=" + this.sbd_ProfitAmt.FormatTo("{0:0.0000}") + ",sbd_PreTaxProfitAmt=" + this.sbd_PreTaxProfitAmt.FormatTo("{0:0.0000}") + ",sbd_AddPoint=" + this.sbd_AddPoint.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sbd_PayCash", (object) this.sbd_PayCash, (object) "sbd_PayCard", (object) this.sbd_PayCard, (object) "sbd_PayEtc", (object) this.sbd_PayEtc));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) this.sbd_SaleDate, (object) this.sbd_StoreCode, (object) this.sbd_BoxCode, (object) this.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) this.sbd_Supplier, (object) this.sbd_SupplierType, (object) this.sbd_CategoryCode, (object) this.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) this.sbd_MakerCode, (object) this.sbd_KeySeq, (object) this.sbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TSalesByDay tsalesByDay = this;
      // ISSUE: reference to a compiler-generated method
      tsalesByDay.\u003C\u003En__1();
      if (await tsalesByDay.OleDB.ExecuteAsync(tsalesByDay.UpdateExInsertQuery()))
        return true;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      tsalesByDay.message = " " + tsalesByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsalesByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsalesByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3}", (object) tsalesByDay.sbd_SaleDate, (object) __nonvirtual (tsalesByDay.sbd_StoreCode), (object) tsalesByDay.sbd_BoxCode, (object) tsalesByDay.sbd_GoodsCode) + string.Format(",{0},{1},{2},{3}", (object) tsalesByDay.sbd_Supplier, (object) tsalesByDay.sbd_SupplierType, (object) tsalesByDay.sbd_CategoryCode, (object) tsalesByDay.sbd_DeptCode) + string.Format(",{0},{1},{2})\n", (object) tsalesByDay.sbd_MakerCode, (object) tsalesByDay.sbd_KeySeq, (object) __nonvirtual (tsalesByDay.sbd_SiteID)) + " 내용 : " + tsalesByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsalesByDay.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "sbd_SiteID") && Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sbd_SaleDate"))
        {
          stringBuilder.Append(" AND sbd_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "sbd_SaleDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbd_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "sbd_SaleDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "sbd_SaleDate_BEGIN_") && hashtable.ContainsKey((object) "sbd_SaleDate_END_"))
        {
          stringBuilder.Append(" AND sbd_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "sbd_SaleDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND sbd_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "sbd_SaleDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "sbd_StoreCode") && Convert.ToInt32(hashtable[(object) "sbd_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", hashtable[(object) "sbd_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "sbd_StoreCode_IN_") && hashtable[(object) "sbd_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "sbd_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_StoreCode", hashtable[(object) "sbd_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StoreCode", hashtable[(object) "sbd_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "sbd_BoxCode") && Convert.ToInt64(hashtable[(object) "sbd_BoxCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_BoxCode", hashtable[(object) "sbd_BoxCode"]));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_GoodsCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "sbd_GoodsCode") && Convert.ToInt64(hashtable[(object) "sbd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_GoodsCode", hashtable[(object) "sbd_GoodsCode"]));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "sbd_Supplier") && Convert.ToInt32(hashtable[(object) "sbd_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_Supplier", hashtable[(object) "sbd_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "sbd_Supplier_IN_") && hashtable[(object) "sbd_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "sbd_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_Supplier", hashtable[(object) "sbd_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SupplierType", hashtable[(object) "su_SupplierType"]));
        else if (hashtable.ContainsKey((object) "sbd_SupplierType") && Convert.ToInt32(hashtable[(object) "sbd_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SupplierType", hashtable[(object) "sbd_SupplierType"]));
        else if (hashtable.ContainsKey((object) "su_SupplierType_IN_") && hashtable[(object) "su_SupplierType_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_SupplierType_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "sbd_SupplierType_IN_") && hashtable[(object) "sbd_SupplierType_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "sbd_SupplierType_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_SupplierType", hashtable[(object) "sbd_SupplierType_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SupplierType", hashtable[(object) "sbd_SupplierType_IN_"]));
        }
        if (hashtable.ContainsKey((object) "sbd_CategoryCode") && Convert.ToInt32(hashtable[(object) "sbd_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_CategoryCode", hashtable[(object) "sbd_CategoryCode"]));
        if (hashtable.ContainsKey((object) "sbd_DeptCode") && Convert.ToInt32(hashtable[(object) "sbd_DeptCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_DeptCode", hashtable[(object) "sbd_DeptCode"]));
        if (hashtable.ContainsKey((object) "sbd_MakerCode") && Convert.ToInt32(hashtable[(object) "sbd_MakerCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_MakerCode", hashtable[(object) "sbd_MakerCode"]));
        if (hashtable.ContainsKey((object) "sbd_KeySeq") && Convert.ToInt32(hashtable[(object) "sbd_KeySeq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_KeySeq", hashtable[(object) "sbd_KeySeq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        else if (hashtable.ContainsKey((object) "sbd_TaxDiv") && Convert.ToInt32(hashtable[(object) "sbd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_TaxDiv", hashtable[(object) "sbd_TaxDiv"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "sbd_SalesUnit") && Convert.ToInt32(hashtable[(object) "sbd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_SalesUnit", hashtable[(object) "sbd_SalesUnit"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StockUnit", hashtable[(object) "gd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "sbd_StockUnit") && Convert.ToInt32(hashtable[(object) "sbd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sbd_StockUnit", hashtable[(object) "sbd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "gd_StockUnit_IN_") && hashtable[(object) "gd_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sbd_StockUnit", hashtable[(object) "gd_StockUnit_IN_"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniSales = UbModelBase.UNI_SALES;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniSales = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  sbd_SaleDate,sbd_StoreCode,sbd_BoxCode,sbd_GoodsCode,sbd_Supplier,sbd_SupplierType,sbd_CategoryCode,sbd_DeptCode,sbd_MakerCode,sbd_KeySeq,sbd_SiteID,sbd_DayOfWeek,sbd_WeekOfYear,sbd_DayOfYear,sbd_SkyCondition,sbd_TaxDiv,sbd_SalesUnit,sbd_StockUnit,sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniSales) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------" + string.Format("\n{0}", (object) stringBuilder) + "\n--------------------------------------------------------------------------------------------------");
      return stringBuilder.ToString();
    }
  }
}
