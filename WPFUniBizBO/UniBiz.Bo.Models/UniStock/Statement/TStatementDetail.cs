// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.TStatementDetail
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class TStatementDetail : UbModelBase<TStatementDetail>
  {
    protected long _sd_StatementNo;
    private int _sd_Seq;
    private long _sd_SiteID;
    private long _sd_GoodsCode;
    protected long _sd_BoxCode;
    private string _sd_BarCode = string.Empty;
    protected int _sd_CategoryCode;
    private int _sd_TaxDiv;
    private int _sd_SalesUnit;
    private int _sd_StockUnit;
    private int _sd_PackUnit;
    private int _sd_LinkRowNCount;
    private double _sd_CostGoods;
    private double _sd_PriceGoods;
    private double _sd_OrderQty;
    private double _sd_BoxQty;
    private double _sd_BuyQty;
    private double _sd_CheckQty;
    private double _sd_CostInput;
    private double _sd_CostInputVat;
    private double _sd_CostTaxAmt;
    private double _sd_CostTaxFreeAmt;
    private double _sd_CostVatAmt;
    private double _sd_Deposit;
    private double _sd_PriceTaxAmt;
    private double _sd_PriceTaxFreeAmt;
    private double _sd_PriceVatAmt;
    private string _sd_EventYn = "N";
    private int _sd_Native;
    private string _sd_HistoryID = string.Empty;
    private string _sd_Memo = string.Empty;
    private int _sd_MobieSeq;
    private DateTime? _sd_InDate;
    private int _sd_InUser;
    private DateTime? _sd_ModDate;
    private int _sd_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.sd_StatementNo,
      (object) this.sd_Seq
    };

    public virtual long sd_StatementNo
    {
      get => this._sd_StatementNo;
      set
      {
        this._sd_StatementNo = value;
        this.Changed(nameof (sd_StatementNo));
        this.Changed("DicKeyString");
      }
    }

    public int sd_Seq
    {
      get => this._sd_Seq;
      set
      {
        this._sd_Seq = value;
        this.Changed(nameof (sd_Seq));
        this.Changed("DicKeyString");
      }
    }

    [JsonIgnore]
    public string DicKeyString => string.Format("{0}|{1}", (object) this.sd_StatementNo, (object) this.sd_Seq);

    public long sd_SiteID
    {
      get => this._sd_SiteID;
      set
      {
        this._sd_SiteID = value;
        this.Changed(nameof (sd_SiteID));
      }
    }

    public long sd_GoodsCode
    {
      get => this._sd_GoodsCode;
      set
      {
        this._sd_GoodsCode = value;
        this.Changed(nameof (sd_GoodsCode));
      }
    }

    public virtual long sd_BoxCode
    {
      get => this._sd_BoxCode;
      set
      {
        this._sd_BoxCode = value;
        this.Changed(nameof (sd_BoxCode));
      }
    }

    public string sd_BarCode
    {
      get => this._sd_BarCode;
      set
      {
        this._sd_BarCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (sd_BarCode));
      }
    }

    public virtual int sd_CategoryCode
    {
      get => this._sd_CategoryCode;
      set
      {
        this._sd_CategoryCode = value;
        this.Changed(nameof (sd_CategoryCode));
      }
    }

    public int sd_TaxDiv
    {
      get => this._sd_TaxDiv;
      set
      {
        this._sd_TaxDiv = value;
        this.Changed(nameof (sd_TaxDiv));
        this.Changed("sd_IsTax");
        this.Changed("sd_IsTax");
      }
    }

    public string sd_TaxDivDesc => Enum2StrConverter.ToTaxDiv(this.sd_TaxDiv).ToDescription();

    public bool sd_IsTax => Enum2StrConverter.ToTaxDiv(this.sd_TaxDiv) == EnumTaxDiv.TAX;

    public int sd_SalesUnit
    {
      get => this._sd_SalesUnit;
      set
      {
        this._sd_SalesUnit = value;
        this.Changed(nameof (sd_SalesUnit));
        this.Changed("sd_SalesUnitDesc");
      }
    }

    public string sd_SalesUnitDesc => this.sd_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.sd_SalesUnit).ToDescription() : string.Empty;

    public int sd_StockUnit
    {
      get => this._sd_StockUnit;
      set
      {
        this._sd_StockUnit = value;
        this.Changed(nameof (sd_StockUnit));
        this.Changed("sd_StockUnitDesc");
        this.Changed("sd_IsStockUnitAmount");
      }
    }

    public string sd_StockUnitDesc => this.sd_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.sd_StockUnit).ToDescription() : string.Empty;

    public bool sd_IsStockUnitAmount => Enum2StrConverter.ToStockUnit(this.sd_StockUnit) == EnumStockUnit.AMOUNT;

    public int sd_PackUnit
    {
      get => this._sd_PackUnit;
      set
      {
        this._sd_PackUnit = value;
        this.Changed(nameof (sd_PackUnit));
        this.Changed("sd_PackUnitDesc");
        this.Changed("sd_IsPackUnitEA");
        this.Changed("sd_IsPackUnitBOX");
        this.Changed("sd_IsPackUnitBOM");
      }
    }

    public string sd_PackUnitDesc => this.sd_PackUnit != 0 ? Enum2StrConverter.ToPackUnit(this.sd_PackUnit).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool sd_IsPackUnitEA => Enum2StrConverter.ToPackUnit(this.sd_PackUnit) == EnumPackUnit.EA;

    [JsonIgnore]
    public bool sd_IsPackUnitBOX => Enum2StrConverter.ToPackUnit(this.sd_PackUnit) == EnumPackUnit.BOX;

    [JsonIgnore]
    public bool sd_IsPackUnitBOM => Enum2StrConverter.ToPackUnit(this.sd_PackUnit) == EnumPackUnit.BOM;

    public int sd_LinkRowNCount
    {
      get => this._sd_LinkRowNCount;
      set
      {
        this._sd_LinkRowNCount = value;
        this.Changed(nameof (sd_LinkRowNCount));
      }
    }

    public double sd_CostGoods
    {
      get => this._sd_CostGoods;
      set
      {
        this._sd_CostGoods = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostGoods));
      }
    }

    public double sd_PriceGoods
    {
      get => this._sd_PriceGoods;
      set
      {
        this._sd_PriceGoods = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_PriceGoods));
      }
    }

    public double sd_OrderQty
    {
      get => this._sd_OrderQty;
      set
      {
        this._sd_OrderQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_OrderQty));
      }
    }

    public double sd_BoxQty
    {
      get => this._sd_BoxQty;
      set
      {
        this._sd_BoxQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_BoxQty));
      }
    }

    public double sd_BuyQty
    {
      get => this._sd_BuyQty;
      set
      {
        this._sd_BuyQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_BuyQty));
      }
    }

    public double sd_CheckQty
    {
      get => this._sd_CheckQty;
      set
      {
        this._sd_CheckQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CheckQty));
      }
    }

    public double sd_CostInput
    {
      get => this._sd_CostInput;
      set
      {
        this._sd_CostInput = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostInput));
        this.Changed("sd_CostInputPrice");
      }
    }

    public double sd_CostInputVat
    {
      get => this._sd_CostInputVat;
      set
      {
        this._sd_CostInputVat = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostInputVat));
        this.Changed("sd_CostInputPrice");
      }
    }

    [JsonIgnore]
    public double sd_CostInputPrice
    {
      get => this.sd_CostInput + this.sd_CostInputVat;
      set
      {
        this.CalcCostInputPrice(value);
        this.Changed("sd_CostInput");
        this.Changed("sd_CostInputVat");
      }
    }

    public void CalcCostInputPrice(double p_CostInputPrice)
    {
      if (this.sd_IsTax)
      {
        this._sd_CostInputVat = p_CostInputPrice.ToPriceVat();
        this._sd_CostInput = p_CostInputPrice - this._sd_CostInputVat;
      }
      else
      {
        this._sd_CostInput = p_CostInputPrice;
        this._sd_CostInputVat = 0.0;
      }
    }

    public double sd_CostTaxAmt
    {
      get => this._sd_CostTaxAmt;
      set
      {
        this._sd_CostTaxAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostTaxAmt));
        this.Changed("sd_CostTaxVatSumAmt");
        this.Changed("sd_CostTaxSumAmt");
        this.Changed("sd_CostSumAmt");
        this.Changed("sd_ProfitAmt");
        this.Changed("sd_SaleMargin");
        this.Changed("sd_TotalAmount");
      }
    }

    public double sd_CostTaxFreeAmt
    {
      get => this._sd_CostTaxFreeAmt;
      set
      {
        this._sd_CostTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostTaxFreeAmt));
        this.Changed("sd_CostTaxSumAmt");
        this.Changed("sd_CostSumAmt");
        this.Changed("sd_ProfitAmt");
        this.Changed("sd_SaleMargin");
        this.Changed("sd_TotalAmount");
      }
    }

    [JsonIgnore]
    public double sd_CostTaxSumAmt
    {
      get => this.sd_CostTaxAmt + this.sd_CostTaxFreeAmt;
      set
      {
        this.CalcCostTaxSumAmt(value);
        this.Changed("sd_CostTaxAmt");
        this.Changed("sd_CostTaxFreeAmt");
        this.Changed("sd_CostVatAmt");
      }
    }

    public void CalcCostTaxSumAmt(double p_Amount)
    {
      if (this.sd_IsTax)
      {
        this._sd_CostTaxAmt = p_Amount;
        this._sd_CostVatAmt = p_Amount.ToCostVat();
      }
      else
        this._sd_CostTaxFreeAmt = p_Amount;
    }

    public double sd_CostVatAmt
    {
      get => this._sd_CostVatAmt;
      set
      {
        this._sd_CostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_CostVatAmt));
        this.Changed("sd_CostTaxVatSumAmt");
        this.Changed("sd_CostSumAmt");
        this.Changed("sd_TotalAmount");
      }
    }

    [JsonIgnore]
    public double sd_CostTaxVatSumAmt => this.sd_CostTaxAmt + this.sd_CostVatAmt;

    [JsonIgnore]
    public double sd_CostSumAmt
    {
      get => this.sd_CostTaxAmt + this.sd_CostTaxFreeAmt + this.sd_CostVatAmt;
      set
      {
        this.CalcCostSumAmt(value);
        this.Changed("sd_CostTaxAmt");
        this.Changed("sd_CostTaxFreeAmt");
        this.Changed("sd_CostVatAmt");
      }
    }

    public void CalcCostSumAmt(double p_Amount)
    {
      if (this.sd_IsTax)
      {
        this._sd_CostVatAmt = p_Amount.ToPriceVat();
        this._sd_CostTaxAmt = p_Amount - this._sd_CostVatAmt;
      }
      else
        this._sd_CostTaxFreeAmt = p_Amount;
    }

    public double sd_Deposit
    {
      get => this._sd_Deposit;
      set
      {
        this._sd_Deposit = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_Deposit));
        this.Changed("sd_TotalAmount");
      }
    }

    [JsonIgnore]
    public double sd_TotalAmount => this.sd_CostTaxAmt + this.sd_CostTaxFreeAmt + this.sd_CostVatAmt + this.sd_Deposit;

    public double sd_PriceTaxAmt
    {
      get => this._sd_PriceTaxAmt;
      set
      {
        this._sd_PriceTaxAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_PriceTaxAmt));
        this.Changed("sd_PriceTaxSumAmt");
        this.Changed("sd_PriceSumAmt");
        this.Changed("sd_ProfitAmt");
        this.Changed("sd_SaleMargin");
      }
    }

    public double sd_PriceTaxFreeAmt
    {
      get => this._sd_PriceTaxFreeAmt;
      set
      {
        this._sd_PriceTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_PriceTaxFreeAmt));
        this.Changed("sd_PriceTaxSumAmt");
        this.Changed("sd_PriceSumAmt");
        this.Changed("sd_ProfitAmt");
        this.Changed("sd_SaleMargin");
      }
    }

    [JsonIgnore]
    public double sd_PriceTaxSumAmt => this.sd_PriceTaxAmt + this.sd_PriceTaxFreeAmt;

    public double sd_PriceVatAmt
    {
      get => this._sd_PriceVatAmt;
      set
      {
        this._sd_PriceVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sd_PriceVatAmt));
        this.Changed("sd_PriceSumAmt");
      }
    }

    public double sd_PriceSumAmt
    {
      get => this.sd_PriceTaxAmt + this.sd_PriceTaxFreeAmt + this.sd_PriceVatAmt;
      set
      {
        this.CalcPriceSumAmt(value);
        this.Changed("sd_PriceVatAmt");
        this.Changed("sd_PriceTaxAmt");
        this.Changed("sd_PriceTaxFreeAmt");
      }
    }

    public void CalcPriceSumAmt(double p_Amount)
    {
      if (this.sd_IsTax)
      {
        this._sd_PriceVatAmt = p_Amount.ToPriceVat();
        this._sd_PriceTaxAmt = p_Amount - this._sd_PriceVatAmt;
      }
      else
        this._sd_PriceTaxFreeAmt = p_Amount;
    }

    public double sd_ProfitAmt => this.sd_PriceTaxAmt + this.sd_PriceTaxFreeAmt - (this.sd_CostTaxAmt + this.sd_CostTaxFreeAmt);

    [JsonIgnore]
    public double sd_SaleMargin => (this.sd_CostTaxAmt + this.sd_CostTaxFreeAmt).ToSaleMargin(this.sd_PriceTaxAmt + this.sd_PriceTaxFreeAmt);

    public string sd_EventYn
    {
      get => this._sd_EventYn;
      set
      {
        this._sd_EventYn = value;
        this.Changed(nameof (sd_EventYn));
        this.Changed("sd_IsEvent");
      }
    }

    [JsonIgnore]
    public bool sd_IsEvent => string.Equals(this.sd_EventYn, "Y");

    public int sd_Native
    {
      get => this._sd_Native;
      set
      {
        this._sd_Native = value;
        this.Changed(nameof (sd_Native));
      }
    }

    public string sd_HistoryID
    {
      get => this._sd_HistoryID;
      set
      {
        this._sd_HistoryID = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (sd_HistoryID));
      }
    }

    public string sd_Memo
    {
      get => this._sd_Memo;
      set
      {
        this._sd_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (sd_Memo));
      }
    }

    public int sd_MobieSeq
    {
      get => this._sd_MobieSeq;
      set
      {
        this._sd_MobieSeq = value;
        this.Changed(nameof (sd_MobieSeq));
      }
    }

    public DateTime? sd_InDate
    {
      get => this._sd_InDate;
      set
      {
        this._sd_InDate = value;
        this.Changed(nameof (sd_InDate));
      }
    }

    public int sd_InUser
    {
      get => this._sd_InUser;
      set
      {
        this._sd_InUser = value;
        this.Changed(nameof (sd_InUser));
      }
    }

    public DateTime? sd_ModDate
    {
      get => this._sd_ModDate;
      set
      {
        this._sd_ModDate = value;
        this.Changed(nameof (sd_ModDate));
      }
    }

    public int sd_ModUser
    {
      get => this._sd_ModUser;
      set
      {
        this._sd_ModUser = value;
        this.Changed(nameof (sd_ModUser));
      }
    }

    public TStatementDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sd_StatementNo", new TTableColumn()
      {
        tc_orgin_name = "sd_StatementNo",
        tc_trans_name = "전표 코드"
      });
      columnInfo.Add("sd_Seq", new TTableColumn()
      {
        tc_orgin_name = "sd_Seq",
        tc_trans_name = "순서"
      });
      columnInfo.Add("sd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sd_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "sd_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("sd_BoxCode", new TTableColumn()
      {
        tc_orgin_name = "sd_BoxCode",
        tc_trans_name = "등록코드"
      });
      columnInfo.Add("sd_BarCode", new TTableColumn()
      {
        tc_orgin_name = "sd_BarCode",
        tc_trans_name = "스캔코드"
      });
      columnInfo.Add("sd_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "sd_CategoryCode",
        tc_trans_name = "소부류코드"
      });
      columnInfo.Add("sd_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "sd_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51
      });
      columnInfo.Add("sd_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "sd_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("sd_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "sd_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("sd_PackUnit", new TTableColumn()
      {
        tc_orgin_name = "sd_PackUnit",
        tc_trans_name = "묶음단위",
        tc_comm_code = 54
      });
      columnInfo.Add("sd_LinkRowNCount", new TTableColumn()
      {
        tc_orgin_name = "sd_LinkRowNCount",
        tc_trans_name = "연결행건수"
      });
      columnInfo.Add("sd_CostGoods", new TTableColumn()
      {
        tc_orgin_name = "sd_CostGoods",
        tc_trans_name = "원단가(마스타)"
      });
      columnInfo.Add("sd_PriceGoods", new TTableColumn()
      {
        tc_orgin_name = "sd_PriceGoods",
        tc_trans_name = "매단가(마스타)"
      });
      columnInfo.Add("sd_OrderQty", new TTableColumn()
      {
        tc_orgin_name = "sd_OrderQty",
        tc_trans_name = "발주량"
      });
      columnInfo.Add("sd_BoxQty", new TTableColumn()
      {
        tc_orgin_name = "sd_BoxQty",
        tc_trans_name = "등록량"
      });
      columnInfo.Add("sd_BuyQty", new TTableColumn()
      {
        tc_orgin_name = "sd_BuyQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("sd_CheckQty", new TTableColumn()
      {
        tc_orgin_name = "sd_CheckQty",
        tc_trans_name = "검수량"
      });
      columnInfo.Add("sd_CostInput", new TTableColumn()
      {
        tc_orgin_name = "sd_CostInput",
        tc_trans_name = "원단가"
      });
      columnInfo.Add("sd_CostInputVat", new TTableColumn()
      {
        tc_orgin_name = "sd_CostInputVat",
        tc_trans_name = "원단가VAT"
      });
      columnInfo.Add("sd_CostTaxAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_CostTaxAmt",
        tc_trans_name = "과세금액"
      });
      columnInfo.Add("sd_CostTaxFreeAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_CostTaxFreeAmt",
        tc_trans_name = "면세금액"
      });
      columnInfo.Add("sd_CostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_CostVatAmt",
        tc_trans_name = "부가세금액"
      });
      columnInfo.Add("sd_Deposit", new TTableColumn()
      {
        tc_orgin_name = "sd_Deposit",
        tc_trans_name = "보증금"
      });
      columnInfo.Add("sd_PriceTaxAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_PriceTaxAmt",
        tc_trans_name = "매가 과세금액"
      });
      columnInfo.Add("sd_PriceTaxFreeAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_PriceTaxFreeAmt",
        tc_trans_name = "매가 면세금액"
      });
      columnInfo.Add("sd_PriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_PriceVatAmt",
        tc_trans_name = "매가 부가세금액"
      });
      columnInfo.Add("sd_ProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "sd_ProfitAmt",
        tc_trans_name = "세제외이익액"
      });
      columnInfo.Add("sd_EventYn", new TTableColumn()
      {
        tc_orgin_name = "sd_EventYn",
        tc_trans_name = "이벤트 사용상태"
      });
      columnInfo.Add("sd_Native", new TTableColumn()
      {
        tc_orgin_name = "sd_Native",
        tc_trans_name = "원산지"
      });
      columnInfo.Add("sd_HistoryID", new TTableColumn()
      {
        tc_orgin_name = "sd_HistoryID",
        tc_trans_name = "이력 ID"
      });
      columnInfo.Add("sd_Memo", new TTableColumn()
      {
        tc_orgin_name = "sd_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("sd_MobieSeq", new TTableColumn()
      {
        tc_orgin_name = "sd_MobieSeq",
        tc_trans_name = "모바일 전표 순번"
      });
      columnInfo.Add("sd_InDate", new TTableColumn()
      {
        tc_orgin_name = "sd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("sd_InUser", new TTableColumn()
      {
        tc_orgin_name = "sd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("sd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "sd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("sd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "sd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.StatementDetail;
      this.sd_StatementNo = 0L;
      this.sd_Seq = 0;
      this.sd_SiteID = 0L;
      this.sd_GoodsCode = this.sd_BoxCode = 0L;
      this.sd_BarCode = string.Empty;
      this.sd_CategoryCode = 0;
      this.sd_TaxDiv = 1;
      this.sd_SalesUnit = 1;
      this.sd_StockUnit = 2;
      this.sd_PackUnit = 1;
      this.sd_LinkRowNCount = 0;
      this.sd_CostGoods = this.sd_PriceGoods = 0.0;
      this.sd_OrderQty = this.sd_BoxQty = this.sd_BuyQty = this.sd_CheckQty = 0.0;
      this.sd_CostInput = this.sd_CostInputVat = 0.0;
      this.sd_CostTaxAmt = this.sd_CostTaxFreeAmt = this.sd_CostVatAmt = 0.0;
      this.sd_Deposit = 0.0;
      this.sd_PriceTaxAmt = this.sd_PriceTaxFreeAmt = this.sd_PriceVatAmt = 0.0;
      this.sd_EventYn = "N";
      this.sd_Native = 0;
      this.sd_HistoryID = string.Empty;
      this.sd_Memo = string.Empty;
      this.sd_MobieSeq = 0;
      this.sd_InDate = new DateTime?();
      this.sd_InUser = 0;
      this.sd_ModDate = new DateTime?();
      this.sd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TStatementDetail();

    public override object Clone()
    {
      TStatementDetail tstatementDetail = base.Clone() as TStatementDetail;
      tstatementDetail.sd_StatementNo = this.sd_StatementNo;
      tstatementDetail.sd_Seq = this.sd_Seq;
      tstatementDetail.sd_SiteID = this.sd_SiteID;
      tstatementDetail.sd_BoxCode = this.sd_BoxCode;
      tstatementDetail.sd_GoodsCode = this.sd_GoodsCode;
      tstatementDetail.sd_BarCode = this.sd_BarCode;
      tstatementDetail.sd_CategoryCode = this.sd_CategoryCode;
      tstatementDetail.sd_TaxDiv = this.sd_TaxDiv;
      tstatementDetail.sd_SalesUnit = this.sd_SalesUnit;
      tstatementDetail.sd_StockUnit = this.sd_StockUnit;
      tstatementDetail.sd_PackUnit = this.sd_PackUnit;
      tstatementDetail.sd_LinkRowNCount = this.sd_LinkRowNCount;
      tstatementDetail.sd_CostGoods = this.sd_CostGoods;
      tstatementDetail.sd_PriceGoods = this.sd_PriceGoods;
      tstatementDetail.sd_OrderQty = this.sd_OrderQty;
      tstatementDetail.sd_BoxQty = this.sd_BoxQty;
      tstatementDetail.sd_BuyQty = this.sd_BuyQty;
      tstatementDetail.sd_CheckQty = this.sd_CheckQty;
      tstatementDetail.sd_CostInput = this.sd_CostInput;
      tstatementDetail.sd_CostInputVat = this.sd_CostInputVat;
      tstatementDetail.sd_CostTaxAmt = this.sd_CostTaxAmt;
      tstatementDetail.sd_CostTaxFreeAmt = this.sd_CostTaxFreeAmt;
      tstatementDetail.sd_CostVatAmt = this.sd_CostVatAmt;
      tstatementDetail.sd_Deposit = this.sd_Deposit;
      tstatementDetail.sd_PriceTaxAmt = this.sd_PriceTaxAmt;
      tstatementDetail.sd_PriceTaxFreeAmt = this.sd_PriceTaxFreeAmt;
      tstatementDetail.sd_PriceVatAmt = this.sd_PriceVatAmt;
      tstatementDetail.sd_EventYn = this.sd_EventYn;
      tstatementDetail.sd_Native = this.sd_Native;
      tstatementDetail.sd_HistoryID = this.sd_HistoryID;
      tstatementDetail.sd_Memo = this.sd_Memo;
      tstatementDetail.sd_MobieSeq = this.sd_MobieSeq;
      tstatementDetail.sd_InDate = this.sd_InDate;
      tstatementDetail.sd_InUser = this.sd_InUser;
      tstatementDetail.sd_ModDate = this.sd_ModDate;
      tstatementDetail.sd_ModUser = this.sd_ModUser;
      return (object) tstatementDetail;
    }

    public void PutData(TStatementDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sd_StatementNo = pSource.sd_StatementNo;
      this.sd_Seq = pSource.sd_Seq;
      this.sd_SiteID = pSource.sd_SiteID;
      this.sd_BoxCode = pSource.sd_BoxCode;
      this.sd_GoodsCode = pSource.sd_GoodsCode;
      this.sd_BarCode = pSource.sd_BarCode;
      this.sd_CategoryCode = pSource.sd_CategoryCode;
      this.sd_TaxDiv = pSource.sd_TaxDiv;
      this.sd_SalesUnit = pSource.sd_SalesUnit;
      this.sd_StockUnit = pSource.sd_StockUnit;
      this.sd_PackUnit = pSource.sd_PackUnit;
      this.sd_LinkRowNCount = pSource.sd_LinkRowNCount;
      this.sd_CostGoods = pSource.sd_CostGoods;
      this.sd_PriceGoods = pSource.sd_PriceGoods;
      this.sd_OrderQty = pSource.sd_OrderQty;
      this.sd_BoxQty = pSource.sd_BoxQty;
      this.sd_BuyQty = pSource.sd_BuyQty;
      this.sd_CheckQty = pSource.sd_CheckQty;
      this.sd_CostInput = pSource.sd_CostInput;
      this.sd_CostInputVat = pSource.sd_CostInputVat;
      this.sd_CostTaxAmt = pSource.sd_CostTaxAmt;
      this.sd_CostTaxFreeAmt = pSource.sd_CostTaxFreeAmt;
      this.sd_CostVatAmt = pSource.sd_CostVatAmt;
      this.sd_Deposit = pSource.sd_Deposit;
      this.sd_PriceTaxAmt = pSource.sd_PriceTaxAmt;
      this.sd_PriceTaxFreeAmt = pSource.sd_PriceTaxFreeAmt;
      this.sd_PriceVatAmt = pSource.sd_PriceVatAmt;
      this.sd_EventYn = pSource.sd_EventYn;
      this.sd_Native = pSource.sd_Native;
      this.sd_HistoryID = pSource.sd_HistoryID;
      this.sd_Memo = pSource.sd_Memo;
      this.sd_MobieSeq = pSource.sd_MobieSeq;
      this.sd_InDate = pSource.sd_InDate;
      this.sd_InUser = pSource.sd_InUser;
      this.sd_ModDate = pSource.sd_ModDate;
      this.sd_ModUser = pSource.sd_ModUser;
    }

    public bool CalcAddSum(TStatementDetail pSource)
    {
      if (pSource == null)
        return false;
      this.sd_OrderQty += pSource.sd_OrderQty;
      this.sd_BoxQty += pSource.sd_BoxQty;
      this.sd_BuyQty += pSource.sd_BuyQty;
      this.sd_CheckQty += pSource.sd_CheckQty;
      this.sd_CostTaxAmt += pSource.sd_CostTaxAmt;
      this.sd_CostTaxFreeAmt += pSource.sd_CostTaxFreeAmt;
      this.sd_CostVatAmt += pSource.sd_CostVatAmt;
      this.sd_Deposit += pSource.sd_Deposit;
      this.sd_PriceTaxAmt += pSource.sd_PriceTaxAmt;
      this.sd_PriceTaxFreeAmt += pSource.sd_PriceTaxFreeAmt;
      this.sd_PriceVatAmt += pSource.sd_PriceVatAmt;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, TStatementDetail pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.sd_OrderQty.IsZero() && pSource.sd_BoxQty.IsZero() && pSource.sd_BuyQty.IsZero() && pSource.sd_CheckQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sd_CostTaxAmt.IsZero() && pSource.sd_CostTaxFreeAmt.IsZero() && pSource.sd_CostVatAmt.IsZero() && pSource.sd_Deposit.IsZero() && pSource.sd_PriceTaxAmt.IsZero() && pSource.sd_PriceTaxFreeAmt.IsZero() && pSource.sd_PriceVatAmt.IsZero());

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sd_StatementNo = p_rs.GetFieldLong("sd_StatementNo");
        if (this.sd_StatementNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sd_Seq = p_rs.GetFieldInt("sd_Seq");
        this.sd_SiteID = p_rs.GetFieldLong("sd_SiteID");
        this.sd_GoodsCode = p_rs.GetFieldLong("sd_GoodsCode");
        this.sd_BoxCode = p_rs.GetFieldLong("sd_BoxCode");
        this.sd_BarCode = p_rs.GetFieldString("sd_BarCode");
        this.sd_CategoryCode = p_rs.GetFieldInt("sd_CategoryCode");
        this.sd_TaxDiv = p_rs.GetFieldInt("sd_TaxDiv");
        this.sd_SalesUnit = p_rs.GetFieldInt("sd_SalesUnit");
        this.sd_StockUnit = p_rs.GetFieldInt("sd_StockUnit");
        this.sd_PackUnit = p_rs.GetFieldInt("sd_PackUnit");
        this.sd_LinkRowNCount = p_rs.GetFieldInt("sd_LinkRowNCount");
        this.sd_CostGoods = p_rs.GetFieldDouble("sd_CostGoods");
        this.sd_PriceGoods = p_rs.GetFieldDouble("sd_PriceGoods");
        this.sd_OrderQty = p_rs.GetFieldDouble("sd_OrderQty");
        this.sd_BoxQty = p_rs.GetFieldDouble("sd_BoxQty");
        this.sd_BuyQty = p_rs.GetFieldDouble("sd_BuyQty");
        this.sd_CheckQty = p_rs.GetFieldDouble("sd_CheckQty");
        this.sd_CostInput = p_rs.GetFieldDouble("sd_CostInput");
        this.sd_CostInputVat = p_rs.GetFieldDouble("sd_CostInputVat");
        this.sd_CostTaxAmt = p_rs.GetFieldDouble("sd_CostTaxAmt");
        this.sd_CostTaxFreeAmt = p_rs.GetFieldDouble("sd_CostTaxFreeAmt");
        this.sd_CostVatAmt = p_rs.GetFieldDouble("sd_CostVatAmt");
        this.sd_Deposit = p_rs.GetFieldDouble("sd_Deposit");
        this.sd_PriceTaxAmt = p_rs.GetFieldDouble("sd_PriceTaxAmt");
        this.sd_PriceTaxFreeAmt = p_rs.GetFieldDouble("sd_PriceTaxFreeAmt");
        this.sd_PriceVatAmt = p_rs.GetFieldDouble("sd_PriceVatAmt");
        this.sd_EventYn = p_rs.GetFieldString("sd_EventYn");
        this.sd_Native = p_rs.GetFieldInt("sd_Native");
        this.sd_HistoryID = p_rs.GetFieldString("sd_HistoryID");
        this.sd_Memo = p_rs.GetFieldString("sd_Memo");
        this.sd_MobieSeq = p_rs.GetFieldInt("sd_MobieSeq");
        this.sd_InDate = p_rs.GetFieldDateTime("sd_InDate");
        this.sd_InUser = p_rs.GetFieldInt("sd_InUser");
        this.sd_ModDate = p_rs.GetFieldDateTime("sd_ModDate");
        this.sd_ModUser = p_rs.GetFieldInt("sd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " sd_StatementNo,sd_Seq,sd_SiteID,sd_GoodsCode,sd_BoxCode,sd_BarCode,sd_CategoryCode,sd_TaxDiv,sd_SalesUnit,sd_StockUnit,sd_PackUnit,sd_LinkRowNCount,sd_CostGoods,sd_PriceGoods,sd_OrderQty,sd_BoxQty,sd_BuyQty,sd_CheckQty,sd_CostInput,sd_CostInputVat,sd_CostTaxAmt,sd_CostTaxFreeAmt,sd_CostVatAmt,sd_Deposit,sd_PriceTaxAmt,sd_PriceTaxFreeAmt,sd_PriceVatAmt,sd_ProfitAmt,sd_EventYn,sd_Native,sd_HistoryID,sd_Memo,sd_MobieSeq,sd_InDate,sd_InUser,sd_ModDate,sd_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.sd_StatementNo, (object) this.sd_Seq) + string.Format(",{0}", (object) this.sd_SiteID) + string.Format(",{0},{1},'{2}',{3},{4},{5},{6},{7},{8}", (object) this.sd_GoodsCode, (object) this.sd_BoxCode, (object) this.sd_BarCode, (object) this.sd_CategoryCode, (object) this.sd_TaxDiv, (object) this.sd_SalesUnit, (object) this.sd_StockUnit, (object) this.sd_PackUnit, (object) this.sd_LinkRowNCount) + "," + this.sd_CostGoods.FormatTo("{0:0.0000}") + "," + this.sd_PriceGoods.FormatTo("{0:0.0000}") + "," + this.sd_OrderQty.FormatTo("{0:0.0000}") + "," + this.sd_BoxQty.FormatTo("{0:0.0000}") + "," + this.sd_BuyQty.FormatTo("{0:0.0000}") + "," + this.sd_CheckQty.FormatTo("{0:0.0000}") + "," + this.sd_CostInput.FormatTo("{0:0.0000}") + "," + this.sd_CostInputVat.FormatTo("{0:0.0000}") + "," + this.sd_CostTaxAmt.FormatTo("{0:0.0000}") + "," + this.sd_CostTaxFreeAmt.FormatTo("{0:0.0000}") + "," + this.sd_CostVatAmt.FormatTo("{0:0.0000}") + "," + this.sd_Deposit.FormatTo("{0:0.0000}") + "," + this.sd_PriceTaxAmt.FormatTo("{0:0.0000}") + "," + this.sd_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + "," + this.sd_PriceVatAmt.FormatTo("{0:0.0000}") + "," + this.sd_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",'{0}',{1},'{2}','{3}'", (object) this.sd_EventYn, (object) this.sd_Native, (object) this.sd_HistoryID, (object) this.sd_Memo) + string.Format(",{0}", (object) this.sd_MobieSeq) + string.Format(",{0},{1}", (object) this.sd_InDate.GetDateToStrInNull(), (object) this.sd_InUser) + string.Format(",{0},{1}", (object) this.sd_ModDate.GetDateToStrInNull(), (object) this.sd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.sd_StatementNo, (object) this.sd_Seq, (object) this.sd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TStatementDetail tstatementDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstatementDetail.\u003C\u003En__0();
      if (await tstatementDetail.OleDB.ExecuteAsync(tstatementDetail.InsertQuery()))
        return true;
      tstatementDetail.message = " " + tstatementDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tstatementDetail.sd_StatementNo, (object) tstatementDetail.sd_Seq, (object) tstatementDetail.sd_SiteID) + " 내용 : " + tstatementDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "sd_GoodsCode", (object) this.sd_GoodsCode, (object) "sd_BoxCode", (object) this.sd_BoxCode) + string.Format(",{0}='{1}',{2}={3}", (object) "sd_BarCode", (object) this.sd_BarCode, (object) "sd_CategoryCode", (object) this.sd_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sd_TaxDiv", (object) this.sd_TaxDiv, (object) "sd_SalesUnit", (object) this.sd_SalesUnit, (object) "sd_StockUnit", (object) this.sd_StockUnit) + string.Format(",{0}={1},{2}={3}", (object) "sd_PackUnit", (object) this.sd_PackUnit, (object) "sd_LinkRowNCount", (object) this.sd_LinkRowNCount) + ",sd_CostGoods=" + this.sd_CostGoods.FormatTo("{0:0.0000}") + ",sd_PriceGoods=" + this.sd_PriceGoods.FormatTo("{0:0.0000}") + ",sd_OrderQty=" + this.sd_OrderQty.FormatTo("{0:0.0000}") + ",sd_BoxQty=" + this.sd_BoxQty.FormatTo("{0:0.0000}") + ",sd_BuyQty=" + this.sd_BuyQty.FormatTo("{0:0.0000}") + ",sd_CheckQty=" + this.sd_CheckQty.FormatTo("{0:0.0000}") + ",sd_CostInput=" + this.sd_CostInput.FormatTo("{0:0.0000}") + ",sd_CostInputVat=" + this.sd_CostInputVat.FormatTo("{0:0.0000}") + ",sd_CostTaxAmt=" + this.sd_CostTaxAmt.FormatTo("{0:0.0000}") + ",sd_CostTaxFreeAmt=" + this.sd_CostTaxFreeAmt.FormatTo("{0:0.0000}") + ",sd_CostVatAmt=" + this.sd_CostVatAmt.FormatTo("{0:0.0000}") + ",sd_Deposit=" + this.sd_Deposit.FormatTo("{0:0.0000}") + ",sd_PriceTaxAmt=" + this.sd_PriceTaxAmt.FormatTo("{0:0.0000}") + ",sd_PriceTaxFreeAmt=" + this.sd_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + ",sd_PriceVatAmt=" + this.sd_PriceVatAmt.FormatTo("{0:0.0000}") + ",sd_ProfitAmt=" + this.sd_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3},{4}='{5}'", (object) "sd_EventYn", (object) this.sd_EventYn, (object) "sd_Native", (object) this.sd_Native, (object) "sd_HistoryID", (object) this.sd_HistoryID) + ",sd_Memo='" + this.sd_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "sd_ModDate", (object) this.sd_ModDate.GetDateToStrInNull(), (object) "sd_ModUser", (object) this.sd_ModUser) + string.Format(" WHERE {0}={1}", (object) "sd_StatementNo", (object) this.sd_StatementNo) + string.Format(" AND {0}={1}", (object) "sd_Seq", (object) this.sd_Seq) + string.Format(" AND {0}={1}", (object) "sd_SiteID", (object) this.sd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.sd_StatementNo, (object) this.sd_Seq, (object) this.sd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TStatementDetail tstatementDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstatementDetail.\u003C\u003En__1();
      if (await tstatementDetail.OleDB.ExecuteAsync(tstatementDetail.UpdateQuery()))
        return true;
      tstatementDetail.message = " " + tstatementDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tstatementDetail.sd_StatementNo, (object) tstatementDetail.sd_Seq, (object) tstatementDetail.sd_SiteID) + " 내용 : " + tstatementDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementDetail.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "sd_GoodsCode", (object) this.sd_GoodsCode, (object) "sd_BoxCode", (object) this.sd_BoxCode) + string.Format(",{0}='{1}',{2}={3}", (object) "sd_BarCode", (object) this.sd_BarCode, (object) "sd_CategoryCode", (object) this.sd_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sd_TaxDiv", (object) this.sd_TaxDiv, (object) "sd_SalesUnit", (object) this.sd_SalesUnit, (object) "sd_StockUnit", (object) this.sd_StockUnit) + string.Format(",{0}={1},{2}={3}", (object) "sd_PackUnit", (object) this.sd_PackUnit, (object) "sd_LinkRowNCount", (object) this.sd_LinkRowNCount) + ",sd_CostGoods=" + this.sd_CostGoods.FormatTo("{0:0.0000}") + ",sd_PriceGoods=" + this.sd_PriceGoods.FormatTo("{0:0.0000}") + ",sd_OrderQty=" + this.sd_OrderQty.FormatTo("{0:0.0000}") + ",sd_BoxQty=" + this.sd_BoxQty.FormatTo("{0:0.0000}") + ",sd_BuyQty=" + this.sd_BuyQty.FormatTo("{0:0.0000}") + ",sd_CheckQty=" + this.sd_CheckQty.FormatTo("{0:0.0000}") + ",sd_CostInput=" + this.sd_CostInput.FormatTo("{0:0.0000}") + ",sd_CostInputVat=" + this.sd_CostInputVat.FormatTo("{0:0.0000}") + ",sd_CostTaxAmt=" + this.sd_CostTaxAmt.FormatTo("{0:0.0000}") + ",sd_CostTaxFreeAmt=" + this.sd_CostTaxFreeAmt.FormatTo("{0:0.0000}") + ",sd_CostVatAmt=" + this.sd_CostVatAmt.FormatTo("{0:0.0000}") + ",sd_Deposit=" + this.sd_Deposit.FormatTo("{0:0.0000}") + ",sd_PriceTaxAmt=" + this.sd_PriceTaxAmt.FormatTo("{0:0.0000}") + ",sd_PriceTaxFreeAmt=" + this.sd_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + ",sd_PriceVatAmt=" + this.sd_PriceVatAmt.FormatTo("{0:0.0000}") + ",sd_ProfitAmt=" + this.sd_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3},{4}='{5}'", (object) "sd_EventYn", (object) this.sd_EventYn, (object) "sd_Native", (object) this.sd_Native, (object) "sd_HistoryID", (object) this.sd_HistoryID) + ",sd_Memo='" + this.sd_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "sd_ModDate", (object) this.sd_ModDate.GetDateToStrInNull(), (object) "sd_ModUser", (object) this.sd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.sd_StatementNo, (object) this.sd_Seq, (object) this.sd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TStatementDetail tstatementDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstatementDetail.\u003C\u003En__1();
      if (await tstatementDetail.OleDB.ExecuteAsync(tstatementDetail.UpdateExInsertQuery()))
        return true;
      tstatementDetail.message = " " + tstatementDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tstatementDetail.sd_StatementNo, (object) tstatementDetail.sd_Seq, (object) tstatementDetail.sd_SiteID) + " 내용 : " + tstatementDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementDetail.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(hashtable[(object) "sd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sd_StatementNo") && Convert.ToInt64(hashtable[(object) "sd_StatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_StatementNo", hashtable[(object) "sd_StatementNo"]));
        if (hashtable.ContainsKey((object) "sd_Seq") && Convert.ToInt32(hashtable[(object) "sd_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_Seq", hashtable[(object) "sd_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_BoxCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "sd_BoxCode") && Convert.ToInt64(hashtable[(object) "sd_BoxCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_BoxCode", hashtable[(object) "sd_BoxCode"]));
        if (hashtable.ContainsKey((object) "sd_GoodsCode") && Convert.ToInt64(hashtable[(object) "sd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_GoodsCode", hashtable[(object) "sd_GoodsCode"]));
        if (hashtable.ContainsKey((object) "sd_BarCode") && hashtable[(object) "sd_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sd_BarCode", hashtable[(object) "sd_BarCode"]));
        if (hashtable.ContainsKey((object) "sd_CategoryCode") && Convert.ToInt32(hashtable[(object) "sd_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_CategoryCode", hashtable[(object) "sd_CategoryCode"]));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        if (hashtable.ContainsKey((object) "sd_TaxDiv") && Convert.ToInt32(hashtable[(object) "sd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_TaxDiv", hashtable[(object) "sd_TaxDiv"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "gd_SalesUnit_IN_") && hashtable[(object) "gd_SalesUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_SalesUnit", hashtable[(object) "gd_SalesUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "sd_SalesUnit") && Convert.ToInt32(hashtable[(object) "sd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_SalesUnit", hashtable[(object) "sd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "sd_SalesUnit_IN_") && hashtable[(object) "sd_SalesUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_SalesUnit", hashtable[(object) "sd_SalesUnit_IN_"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_StockUnit", hashtable[(object) "gd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "gd_StockUnit_IN_") && hashtable[(object) "gd_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_StockUnit", hashtable[(object) "gd_StockUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "sd_StockUnit") && Convert.ToInt32(hashtable[(object) "sd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_StockUnit", hashtable[(object) "sd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "sd_StockUnit_IN_") && hashtable[(object) "sd_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_StockUnit", hashtable[(object) "sd_StockUnit_IN_"]));
        if (hashtable.ContainsKey((object) "gd_PackUnit") && Convert.ToInt32(hashtable[(object) "gd_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_PackUnit", hashtable[(object) "gd_PackUnit"]));
        else if (hashtable.ContainsKey((object) "gd_PackUnit_IN_") && hashtable[(object) "gd_PackUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_PackUnit", hashtable[(object) "gd_PackUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "sd_PackUnit") && Convert.ToInt32(hashtable[(object) "sd_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_PackUnit", hashtable[(object) "sd_PackUnit"]));
        else if (hashtable.ContainsKey((object) "sd_PackUnit_IN_") && hashtable[(object) "sd_PackUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_PackUnit", hashtable[(object) "sd_StockUnit_IN_"]));
        if (hashtable.ContainsKey((object) "sd_EventYn") && hashtable[(object) "sd_EventYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sd_EventYn", hashtable[(object) "sd_EventYn"]));
        if (hashtable.ContainsKey((object) "sd_Native") && Convert.ToInt32(hashtable[(object) "sd_Native"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_Native", hashtable[(object) "sd_Native"]));
        if (hashtable.ContainsKey((object) "sd_HistoryID") && hashtable[(object) "sd_HistoryID"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sd_HistoryID", hashtable[(object) "sd_HistoryID"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sd_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "sd_HistoryID", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  sd_StatementNo,sd_Seq,sd_SiteID,sd_GoodsCode,sd_BoxCode,sd_BarCode,sd_CategoryCode,sd_TaxDiv,sd_SalesUnit,sd_StockUnit,sd_PackUnit,sd_LinkRowNCount,sd_CostGoods,sd_PriceGoods,sd_OrderQty,sd_BoxQty,sd_BuyQty,sd_CheckQty,sd_CostInput,sd_CostInputVat,sd_CostTaxAmt,sd_CostTaxFreeAmt,sd_CostVatAmt,sd_Deposit,sd_PriceTaxAmt,sd_PriceTaxFreeAmt,sd_PriceVatAmt,sd_ProfitAmt,sd_EventYn,sd_Native,sd_HistoryID,sd_Memo,sd_MobieSeq,sd_InDate,sd_InUser,sd_ModDate,sd_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
