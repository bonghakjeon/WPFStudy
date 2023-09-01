// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.TInventoryDetail
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

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class TInventoryDetail : UbModelBase<TInventoryDetail>
  {
    protected long _id_StatementNo;
    private int _id_Seq;
    private long _id_SiteID;
    private int _id_Supplier;
    private int _id_CategoryCode;
    private long _id_GoodsCode;
    private long _id_BoxCode;
    private string _id_BarCode = string.Empty;
    private int _id_TaxDiv;
    private int _id_SalesUnit;
    private int _id_StockUnit;
    private int _id_PackUnit;
    private int _id_LinkRowNCount;
    private double _id_BoxQty;
    private double _id_InventoryQty;
    private double _id_InventoryCost;
    private double _id_InventoryCostAmt;
    private double _id_InventoryCostVatAmt;
    private double _id_AvgCost;
    private double _id_AvgCostAmt;
    private double _id_AvgCostVatAmt;
    private double _id_InventoryPrice;
    private double _id_InventoryPriceAmt;
    private int _id_MobileSeq;
    private DateTime? _id_InDate;
    private int _id_InUser;
    private DateTime? _id_ModDate;
    private int _id_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.id_StatementNo,
      (object) this.id_Seq
    };

    public virtual long id_StatementNo
    {
      get => this._id_StatementNo;
      set
      {
        this._id_StatementNo = value;
        this.Changed(nameof (id_StatementNo));
        this.Changed("DicKeyString");
      }
    }

    public int id_Seq
    {
      get => this._id_Seq;
      set
      {
        this._id_Seq = value;
        this.Changed(nameof (id_Seq));
        this.Changed("DicKeyString");
      }
    }

    [JsonIgnore]
    public string DicKeyString => string.Format("{0}|{1}", (object) this.id_StatementNo, (object) this.id_Seq);

    public long id_SiteID
    {
      get => this._id_SiteID;
      set
      {
        this._id_SiteID = value;
        this.Changed(nameof (id_SiteID));
      }
    }

    public int id_Supplier
    {
      get => this._id_Supplier;
      set
      {
        this._id_Supplier = value;
        this.Changed(nameof (id_Supplier));
      }
    }

    public int id_CategoryCode
    {
      get => this._id_CategoryCode;
      set
      {
        this._id_CategoryCode = value;
        this.Changed(nameof (id_CategoryCode));
      }
    }

    public long id_GoodsCode
    {
      get => this._id_GoodsCode;
      set
      {
        this._id_GoodsCode = value;
        this.Changed(nameof (id_GoodsCode));
      }
    }

    public long id_BoxCode
    {
      get => this._id_BoxCode;
      set
      {
        this._id_BoxCode = value;
        this.Changed(nameof (id_BoxCode));
      }
    }

    public string id_BarCode
    {
      get => this._id_BarCode;
      set
      {
        this._id_BarCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (id_BarCode));
      }
    }

    public int id_TaxDiv
    {
      get => this._id_TaxDiv;
      set
      {
        this._id_TaxDiv = value;
        this.Changed(nameof (id_TaxDiv));
        this.Changed("id_TaxDivDesc");
        this.Changed("id_IsTax");
      }
    }

    public string id_TaxDivDesc => Enum2StrConverter.ToTaxDiv(this.id_TaxDiv).ToDescription();

    public bool id_IsTax => Enum2StrConverter.ToTaxDiv(this.id_TaxDiv) == EnumTaxDiv.TAX;

    public int id_SalesUnit
    {
      get => this._id_SalesUnit;
      set
      {
        this._id_SalesUnit = value;
        this.Changed(nameof (id_SalesUnit));
        this.Changed("id_SalesUnitDesc");
      }
    }

    public string id_SalesUnitDesc => this.id_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.id_SalesUnit).ToDescription() : string.Empty;

    public int id_StockUnit
    {
      get => this._id_StockUnit;
      set
      {
        this._id_StockUnit = value;
        this.Changed(nameof (id_StockUnit));
        this.Changed("id_StockUnitDesc");
        this.Changed("id_IsStockUnitAmount");
      }
    }

    public string id_StockUnitDesc => this.id_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.id_StockUnit).ToDescription() : string.Empty;

    public bool id_IsStockUnitAmount => Enum2StrConverter.ToStockUnit(this.id_StockUnit) == EnumStockUnit.AMOUNT;

    public int id_PackUnit
    {
      get => this._id_PackUnit;
      set
      {
        this._id_PackUnit = value;
        this.Changed(nameof (id_PackUnit));
        this.Changed("id_PackUnitDesc");
        this.Changed("id_IsPackUnitEA");
        this.Changed("id_IsPackUnitBOX");
        this.Changed("id_IsPackUnitBOM");
      }
    }

    public string id_PackUnitDesc => this.id_PackUnit != 0 ? Enum2StrConverter.ToPackUnit(this.id_PackUnit).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool id_IsPackUnitEA => Enum2StrConverter.ToPackUnit(this.id_PackUnit) == EnumPackUnit.EA;

    [JsonIgnore]
    public bool id_IsPackUnitBOX => Enum2StrConverter.ToPackUnit(this.id_PackUnit) == EnumPackUnit.BOX;

    [JsonIgnore]
    public bool id_IsPackUnitBOM => Enum2StrConverter.ToPackUnit(this.id_PackUnit) == EnumPackUnit.BOM;

    public int id_LinkRowNCount
    {
      get => this._id_LinkRowNCount;
      set
      {
        this._id_LinkRowNCount = value;
        this.Changed(nameof (id_LinkRowNCount));
      }
    }

    public double id_BoxQty
    {
      get => this._id_BoxQty;
      set
      {
        this._id_BoxQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_BoxQty));
      }
    }

    public double id_InventoryQty
    {
      get => this._id_InventoryQty;
      set
      {
        this._id_InventoryQty = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryQty));
      }
    }

    public double id_InventoryCost
    {
      get => this._id_InventoryCost;
      set
      {
        this._id_InventoryCost = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryCost));
      }
    }

    public double id_InventoryCostAmt
    {
      get => this._id_InventoryCostAmt;
      set
      {
        this._id_InventoryCostAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryCostAmt));
      }
    }

    public double id_InventoryCostVatAmt
    {
      get => this._id_InventoryCostVatAmt;
      set
      {
        this._id_InventoryCostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryCostVatAmt));
      }
    }

    public double id_AvgCost
    {
      get => this._id_AvgCost;
      set
      {
        this._id_AvgCost = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_AvgCost));
      }
    }

    public double id_AvgCostAmt
    {
      get => this._id_AvgCostAmt;
      set
      {
        this._id_AvgCostAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_AvgCostAmt));
      }
    }

    public double id_AvgCostVatAmt
    {
      get => this._id_AvgCostVatAmt;
      set
      {
        this._id_AvgCostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_AvgCostVatAmt));
      }
    }

    public double id_InventoryPrice
    {
      get => this._id_InventoryPrice;
      set
      {
        this._id_InventoryPrice = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryPrice));
      }
    }

    public double id_InventoryPriceAmt
    {
      get => this._id_InventoryPriceAmt;
      set
      {
        this._id_InventoryPriceAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (id_InventoryPriceAmt));
      }
    }

    public int id_MobileSeq
    {
      get => this._id_MobileSeq;
      set
      {
        this._id_MobileSeq = value;
        this.Changed(nameof (id_MobileSeq));
      }
    }

    public DateTime? id_InDate
    {
      get => this._id_InDate;
      set
      {
        this._id_InDate = value;
        this.Changed(nameof (id_InDate));
      }
    }

    public int id_InUser
    {
      get => this._id_InUser;
      set
      {
        this._id_InUser = value;
        this.Changed(nameof (id_InUser));
      }
    }

    public DateTime? id_ModDate
    {
      get => this._id_ModDate;
      set
      {
        this._id_ModDate = value;
        this.Changed(nameof (id_ModDate));
      }
    }

    public int id_ModUser
    {
      get => this._id_ModUser;
      set
      {
        this._id_ModUser = value;
        this.Changed(nameof (id_ModUser));
      }
    }

    public TInventoryDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("id_StatementNo", new TTableColumn()
      {
        tc_orgin_name = "id_StatementNo",
        tc_trans_name = "재고조사전표번호"
      });
      columnInfo.Add("id_Seq", new TTableColumn()
      {
        tc_orgin_name = "id_Seq",
        tc_trans_name = "순번"
      });
      columnInfo.Add("id_SiteID", new TTableColumn()
      {
        tc_orgin_name = "id_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("id_Supplier", new TTableColumn()
      {
        tc_orgin_name = "id_Supplier",
        tc_trans_name = "협력업체"
      });
      columnInfo.Add("id_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "id_CategoryCode",
        tc_trans_name = "분류"
      });
      columnInfo.Add("id_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "id_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("id_BoxCode", new TTableColumn()
      {
        tc_orgin_name = "id_BoxCode",
        tc_trans_name = "등록코드"
      });
      columnInfo.Add("id_BarCode", new TTableColumn()
      {
        tc_orgin_name = "id_BarCode",
        tc_trans_name = "상품바코드"
      });
      columnInfo.Add("id_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "id_TaxDiv",
        tc_trans_name = "면과세",
        tc_comm_code = 51
      });
      columnInfo.Add("id_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "id_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("id_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "id_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("id_PackUnit", new TTableColumn()
      {
        tc_orgin_name = "id_PackUnit",
        tc_trans_name = "묶음단위",
        tc_comm_code = 54
      });
      columnInfo.Add("id_LinkRowNCount", new TTableColumn()
      {
        tc_orgin_name = "id_LinkRowNCount",
        tc_trans_name = "연결행건수"
      });
      columnInfo.Add("id_BoxQty", new TTableColumn()
      {
        tc_orgin_name = "id_BoxQty",
        tc_trans_name = "등록량"
      });
      columnInfo.Add("id_InventoryQty", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryQty",
        tc_trans_name = "재고수량"
      });
      columnInfo.Add("id_InventoryCost", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryCost",
        tc_trans_name = "원단가"
      });
      columnInfo.Add("id_InventoryCostAmt", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryCostAmt",
        tc_trans_name = "원가합계"
      });
      columnInfo.Add("id_InventoryCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryCostVatAmt",
        tc_trans_name = "원가합계VAT"
      });
      columnInfo.Add("id_AvgCost", new TTableColumn()
      {
        tc_orgin_name = "id_AvgCost",
        tc_trans_name = "평균원가"
      });
      columnInfo.Add("id_AvgCostAmt", new TTableColumn()
      {
        tc_orgin_name = "id_AvgCostAmt",
        tc_trans_name = "평균원가합계"
      });
      columnInfo.Add("id_AvgCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "id_AvgCostVatAmt",
        tc_trans_name = "평균원가합계VAT"
      });
      columnInfo.Add("id_InventoryPrice", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryPrice",
        tc_trans_name = "매단가"
      });
      columnInfo.Add("id_InventoryPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "id_InventoryPriceAmt",
        tc_trans_name = "매가합계"
      });
      columnInfo.Add("id_MobileSeq", new TTableColumn()
      {
        tc_orgin_name = "id_MobileSeq",
        tc_trans_name = "모바일용 순번"
      });
      columnInfo.Add("id_InDate", new TTableColumn()
      {
        tc_orgin_name = "id_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("id_InUser", new TTableColumn()
      {
        tc_orgin_name = "id_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("id_ModDate", new TTableColumn()
      {
        tc_orgin_name = "id_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("id_ModUser", new TTableColumn()
      {
        tc_orgin_name = "id_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.InventoryDetail;
      this.id_StatementNo = 0L;
      this.id_Seq = 0;
      this.id_SiteID = 0L;
      this.id_Supplier = this.id_CategoryCode = 0;
      this.id_GoodsCode = this.id_BoxCode = 0L;
      this.id_MobileSeq = 0;
      this.id_TaxDiv = 0;
      this.id_SalesUnit = 1;
      this.id_StockUnit = 2;
      this.id_PackUnit = 1;
      this.id_LinkRowNCount = 0;
      this.id_BoxQty = this.id_InventoryQty = this.id_InventoryCost = this.id_InventoryCostAmt = this.id_InventoryCostVatAmt = 0.0;
      this.id_AvgCost = this.id_AvgCostAmt = this.id_AvgCostVatAmt = this.id_InventoryPrice = this.id_InventoryPriceAmt = 0.0;
      this.id_BarCode = string.Empty;
      this.id_ModUser = this.id_InUser = 0;
      DateTime? nullable = new DateTime?();
      this.id_ModDate = nullable;
      this.id_InDate = nullable;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TInventoryDetail();

    public override object Clone()
    {
      TInventoryDetail tinventoryDetail = base.Clone() as TInventoryDetail;
      tinventoryDetail.id_StatementNo = this.id_StatementNo;
      tinventoryDetail.id_Seq = this.id_Seq;
      tinventoryDetail.id_SiteID = this.id_SiteID;
      tinventoryDetail.id_Supplier = this.id_Supplier;
      tinventoryDetail.id_CategoryCode = this.id_CategoryCode;
      tinventoryDetail.id_GoodsCode = this.id_GoodsCode;
      tinventoryDetail.id_BoxCode = this.id_BoxCode;
      tinventoryDetail.id_BarCode = this.id_BarCode;
      tinventoryDetail.id_TaxDiv = this.id_TaxDiv;
      tinventoryDetail.id_SalesUnit = this.id_SalesUnit;
      tinventoryDetail.id_StockUnit = this.id_StockUnit;
      tinventoryDetail.id_PackUnit = this.id_PackUnit;
      tinventoryDetail.id_LinkRowNCount = this.id_LinkRowNCount;
      tinventoryDetail.id_BoxQty = this.id_BoxQty;
      tinventoryDetail.id_InventoryQty = this.id_InventoryQty;
      tinventoryDetail.id_InventoryCost = this.id_InventoryCost;
      tinventoryDetail.id_InventoryCostAmt = this.id_InventoryCostAmt;
      tinventoryDetail.id_InventoryCostVatAmt = this.id_InventoryCostVatAmt;
      tinventoryDetail.id_AvgCost = this.id_AvgCost;
      tinventoryDetail.id_AvgCostAmt = this.id_AvgCostAmt;
      tinventoryDetail.id_AvgCostVatAmt = this.id_AvgCostVatAmt;
      tinventoryDetail.id_InventoryPrice = this.id_InventoryPrice;
      tinventoryDetail.id_InventoryPriceAmt = this.id_InventoryPriceAmt;
      tinventoryDetail.id_MobileSeq = this.id_MobileSeq;
      tinventoryDetail.id_InDate = this.id_InDate;
      tinventoryDetail.id_InUser = this.id_InUser;
      tinventoryDetail.id_ModDate = this.id_ModDate;
      tinventoryDetail.id_ModUser = this.id_ModUser;
      return (object) tinventoryDetail;
    }

    public void PutData(TInventoryDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.id_StatementNo = pSource.id_StatementNo;
      this.id_Seq = pSource.id_Seq;
      this.id_SiteID = pSource.id_SiteID;
      this.id_Supplier = pSource.id_Supplier;
      this.id_CategoryCode = pSource.id_CategoryCode;
      this.id_GoodsCode = pSource.id_GoodsCode;
      this.id_BoxCode = pSource.id_BoxCode;
      this.id_BarCode = pSource.id_BarCode;
      this.id_TaxDiv = pSource.id_TaxDiv;
      this.id_SalesUnit = pSource.id_SalesUnit;
      this.id_StockUnit = pSource.id_StockUnit;
      this.id_PackUnit = pSource.id_PackUnit;
      this.id_LinkRowNCount = pSource.id_LinkRowNCount;
      this.id_BoxQty = pSource.id_BoxQty;
      this.id_InventoryQty = pSource.id_InventoryQty;
      this.id_InventoryCost = pSource.id_InventoryCost;
      this.id_InventoryCostAmt = pSource.id_InventoryCostAmt;
      this.id_InventoryCostVatAmt = pSource.id_InventoryCostVatAmt;
      this.id_AvgCost = pSource.id_AvgCost;
      this.id_AvgCostAmt = pSource.id_AvgCostAmt;
      this.id_AvgCostVatAmt = pSource.id_AvgCostVatAmt;
      this.id_InventoryPrice = pSource.id_InventoryPrice;
      this.id_InventoryPriceAmt = pSource.id_InventoryPriceAmt;
      this.id_MobileSeq = pSource.id_MobileSeq;
      this.id_InDate = pSource.id_InDate;
      this.id_InUser = pSource.id_InUser;
      this.id_ModDate = pSource.id_ModDate;
      this.id_ModUser = pSource.id_ModUser;
    }

    public bool CalcAddSum(TInventoryDetail pSource)
    {
      if (pSource == null)
        return false;
      this.id_BoxQty += pSource.id_BoxQty;
      this.id_InventoryQty += pSource.id_InventoryQty;
      this.id_InventoryCostAmt += pSource.id_InventoryCostAmt;
      this.id_InventoryCostVatAmt += pSource.id_InventoryCostVatAmt;
      this.id_AvgCostAmt += pSource.id_AvgCostAmt;
      this.id_AvgCostVatAmt += pSource.id_AvgCostVatAmt;
      this.id_InventoryPriceAmt += pSource.id_InventoryPriceAmt;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, TInventoryDetail pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.id_BoxQty.IsZero() && pSource.id_InventoryQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.id_InventoryCostAmt.IsZero() && pSource.id_InventoryCostVatAmt.IsZero() && pSource.id_AvgCostAmt.IsZero() && pSource.id_AvgCostVatAmt.IsZero() && pSource.id_InventoryPriceAmt.IsZero());

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.id_StatementNo = p_rs.GetFieldLong("id_StatementNo");
        this.id_Seq = p_rs.GetFieldInt("id_Seq");
        this.id_SiteID = p_rs.GetFieldLong("id_SiteID");
        if (this.id_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.id_Supplier = p_rs.GetFieldInt("id_Supplier");
        this.id_CategoryCode = p_rs.GetFieldInt("id_CategoryCode");
        this.id_GoodsCode = p_rs.GetFieldLong("id_GoodsCode");
        this.id_BoxCode = p_rs.GetFieldLong("id_BoxCode");
        this.id_BarCode = p_rs.GetFieldString("id_BarCode");
        this.id_TaxDiv = p_rs.GetFieldInt("id_TaxDiv");
        this.id_SalesUnit = p_rs.GetFieldInt("id_SalesUnit");
        this.id_StockUnit = p_rs.GetFieldInt("id_StockUnit");
        this.id_PackUnit = p_rs.GetFieldInt("id_PackUnit");
        this.id_LinkRowNCount = p_rs.GetFieldInt("id_LinkRowNCount");
        this.id_BoxQty = p_rs.GetFieldDouble("id_BoxQty");
        this.id_InventoryQty = p_rs.GetFieldDouble("id_InventoryQty");
        this.id_InventoryCost = p_rs.GetFieldDouble("id_InventoryCost");
        this.id_InventoryCostAmt = p_rs.GetFieldDouble("id_InventoryCostAmt");
        this.id_InventoryCostVatAmt = p_rs.GetFieldDouble("id_InventoryCostVatAmt");
        this.id_AvgCost = p_rs.GetFieldDouble("id_AvgCost");
        this.id_AvgCostAmt = p_rs.GetFieldDouble("id_AvgCostAmt");
        this.id_AvgCostVatAmt = p_rs.GetFieldDouble("id_AvgCostVatAmt");
        this.id_InventoryPrice = p_rs.GetFieldDouble("id_InventoryPrice");
        this.id_InventoryPriceAmt = p_rs.GetFieldDouble("id_InventoryPriceAmt");
        this.id_MobileSeq = p_rs.GetFieldInt("id_MobileSeq");
        this.id_InDate = p_rs.GetFieldDateTime("id_InDate");
        this.id_InUser = p_rs.GetFieldInt("id_InUser");
        this.id_ModDate = p_rs.GetFieldDateTime("id_ModDate");
        this.id_ModUser = p_rs.GetFieldInt("id_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " id_StatementNo,id_Seq,id_SiteID,id_Supplier,id_CategoryCode,id_GoodsCode,id_BoxCode,id_BarCode,id_TaxDiv,id_SalesUnit,id_StockUnit,id_PackUnit,id_LinkRowNCount,id_BoxQty,id_InventoryQty,id_InventoryCost,id_InventoryCostAmt,id_InventoryCostVatAmt,id_AvgCost,id_AvgCostAmt,id_AvgCostVatAmt,id_InventoryPrice,id_InventoryPriceAmt,id_MobileSeq,id_InDate,id_InUser,id_ModDate,id_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.id_StatementNo, (object) this.id_Seq) + string.Format(",{0}", (object) this.id_SiteID) + string.Format(",{0},{1}", (object) this.id_Supplier, (object) this.id_CategoryCode) + string.Format(",{0},{1},'{2}'", (object) this.id_GoodsCode, (object) this.id_BoxCode, (object) this.id_BarCode) + string.Format(",{0},{1},{2},{3},{4}", (object) this.id_TaxDiv, (object) this.id_SalesUnit, (object) this.id_StockUnit, (object) this.id_PackUnit, (object) this.id_LinkRowNCount) + "," + this.id_BoxQty.FormatTo("{0:0.0000}") + "," + this.id_InventoryQty.FormatTo("{0:0.0000}") + "," + this.id_InventoryCost.FormatTo("{0:0.0000}") + "," + this.id_InventoryCostAmt.FormatTo("{0:0.0000}") + "," + this.id_InventoryCostVatAmt.FormatTo("{0:0.0000}") + "," + this.id_AvgCost.FormatTo("{0:0.0000}") + "," + this.id_AvgCostAmt.FormatTo("{0:0.0000}") + "," + this.id_AvgCostVatAmt.FormatTo("{0:0.0000}") + "," + this.id_InventoryPrice.FormatTo("{0:0.0000}") + "," + this.id_InventoryPriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0}", (object) this.id_MobileSeq) + string.Format(",{0},{1}", (object) this.id_InDate.GetDateToStrInNull(), (object) this.id_InUser) + string.Format(",{0},{1}", (object) this.id_ModDate.GetDateToStrInNull(), (object) this.id_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.id_StatementNo, (object) this.id_Seq, (object) this.id_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TInventoryDetail tinventoryDetail = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryDetail.\u003C\u003En__0();
      if (await tinventoryDetail.OleDB.ExecuteAsync(tinventoryDetail.InsertQuery()))
        return true;
      tinventoryDetail.message = " " + tinventoryDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryDetail.id_StatementNo, (object) tinventoryDetail.id_Seq, (object) tinventoryDetail.id_SiteID) + " 내용 : " + tinventoryDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "id_Supplier", (object) this.id_Supplier, (object) "id_CategoryCode", (object) this.id_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "id_GoodsCode", (object) this.id_GoodsCode, (object) "id_BoxCode", (object) this.id_BoxCode, (object) "id_BarCode", (object) this.id_BarCode) + string.Format(",{0}={1},{2}={3}", (object) "id_TaxDiv", (object) this.id_TaxDiv, (object) "id_SalesUnit", (object) this.id_SalesUnit) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "id_StockUnit", (object) this.id_StockUnit, (object) "id_PackUnit", (object) this.id_PackUnit, (object) "id_LinkRowNCount", (object) this.id_LinkRowNCount) + ",id_BoxQty=" + this.id_BoxQty.FormatTo("{0:0.0000}") + ",id_InventoryQty=" + this.id_InventoryQty.FormatTo("{0:0.0000}") + ",id_InventoryCost=" + this.id_InventoryCost.FormatTo("{0:0.0000}") + ",id_InventoryCostAmt=" + this.id_InventoryCostAmt.FormatTo("{0:0.0000}") + ",id_InventoryCostVatAmt=" + this.id_InventoryCostVatAmt.FormatTo("{0:0.0000}") + ",id_AvgCost=" + this.id_AvgCost.FormatTo("{0:0.0000}") + ",id_AvgCostAmt=" + this.id_AvgCostAmt.FormatTo("{0:0.0000}") + ",id_AvgCostVatAmt=" + this.id_AvgCostVatAmt.FormatTo("{0:0.0000}") + ",id_InventoryPrice=" + this.id_InventoryPrice.FormatTo("{0:0.0000}") + ",id_InventoryPriceAmt=" + this.id_InventoryPriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "id_MobileSeq", (object) this.id_MobileSeq) + string.Format(",{0}={1},{2}={3}", (object) "id_ModDate", (object) this.id_ModDate.GetDateToStrInNull(), (object) "id_ModUser", (object) this.id_ModUser) + string.Format(" WHERE {0}={1}", (object) "id_StatementNo", (object) this.id_StatementNo) + string.Format(" AND {0}={1}", (object) "id_Seq", (object) this.id_Seq) + string.Format(" AND {0}={1}", (object) "id_SiteID", (object) this.id_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.id_StatementNo, (object) this.id_Seq, (object) this.id_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TInventoryDetail tinventoryDetail = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryDetail.\u003C\u003En__1();
      if (await tinventoryDetail.OleDB.ExecuteAsync(tinventoryDetail.UpdateQuery()))
        return true;
      tinventoryDetail.message = " " + tinventoryDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryDetail.id_StatementNo, (object) tinventoryDetail.id_Seq, (object) tinventoryDetail.id_SiteID) + " 내용 : " + tinventoryDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryDetail.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "id_Supplier", (object) this.id_Supplier, (object) "id_CategoryCode", (object) this.id_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "id_GoodsCode", (object) this.id_GoodsCode, (object) "id_BoxCode", (object) this.id_BoxCode, (object) "id_BarCode", (object) this.id_BarCode) + string.Format(",{0}={1},{2}={3}", (object) "id_TaxDiv", (object) this.id_TaxDiv, (object) "id_SalesUnit", (object) this.id_SalesUnit) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "id_StockUnit", (object) this.id_StockUnit, (object) "id_PackUnit", (object) this.id_PackUnit, (object) "id_LinkRowNCount", (object) this.id_LinkRowNCount) + ",id_BoxQty=" + this.id_BoxQty.FormatTo("{0:0.0000}") + ",id_InventoryQty=" + this.id_InventoryQty.FormatTo("{0:0.0000}") + ",id_InventoryCost=" + this.id_InventoryCost.FormatTo("{0:0.0000}") + ",id_InventoryCostAmt=" + this.id_InventoryCostAmt.FormatTo("{0:0.0000}") + ",id_InventoryCostVatAmt=" + this.id_InventoryCostVatAmt.FormatTo("{0:0.0000}") + ",id_AvgCost=" + this.id_AvgCost.FormatTo("{0:0.0000}") + ",id_AvgCostAmt=" + this.id_AvgCostAmt.FormatTo("{0:0.0000}") + ",id_AvgCostVatAmt=" + this.id_AvgCostVatAmt.FormatTo("{0:0.0000}") + ",id_InventoryPrice=" + this.id_InventoryPrice.FormatTo("{0:0.0000}") + ",id_InventoryPriceAmt=" + this.id_InventoryPriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "id_MobileSeq", (object) this.id_MobileSeq) + string.Format(",{0}={1},{2}={3}", (object) "id_ModDate", (object) this.id_ModDate.GetDateToStrInNull(), (object) "id_ModUser", (object) this.id_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.id_StatementNo, (object) this.id_Seq, (object) this.id_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TInventoryDetail tinventoryDetail = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryDetail.\u003C\u003En__1();
      if (await tinventoryDetail.OleDB.ExecuteAsync(tinventoryDetail.UpdateExInsertQuery()))
        return true;
      tinventoryDetail.message = " " + tinventoryDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryDetail.id_StatementNo, (object) tinventoryDetail.id_Seq, (object) tinventoryDetail.id_SiteID) + " 내용 : " + tinventoryDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryDetail.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "id_SiteID") && Convert.ToInt64(hashtable[(object) "id_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "id_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "id_StatementNo") && Convert.ToInt64(hashtable[(object) "id_StatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_StatementNo", hashtable[(object) "id_StatementNo"]));
        if (hashtable.ContainsKey((object) "id_Seq") && Convert.ToInt32(hashtable[(object) "id_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_Seq", hashtable[(object) "id_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "id_Supplier") && Convert.ToInt32(hashtable[(object) "id_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_Supplier", hashtable[(object) "id_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "id_Supplier_IN_") && hashtable[(object) "id_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_Supplier", hashtable[(object) "id_Supplier_IN_"]));
        if (hashtable.ContainsKey((object) "id_CategoryCode") && Convert.ToInt32(hashtable[(object) "id_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_CategoryCode", hashtable[(object) "id_CategoryCode"]));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_BoxCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "id_BoxCode") && Convert.ToInt64(hashtable[(object) "id_BoxCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_BoxCode", hashtable[(object) "id_BoxCode"]));
        if (hashtable.ContainsKey((object) "id_BarCode") && hashtable[(object) "id_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "id_BarCode", hashtable[(object) "id_BarCode"]));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        if (hashtable.ContainsKey((object) "id_TaxDiv") && Convert.ToInt32(hashtable[(object) "id_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_TaxDiv", hashtable[(object) "id_TaxDiv"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "gd_SalesUnit_IN_") && hashtable[(object) "gd_SalesUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_SalesUnit", hashtable[(object) "gd_SalesUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "id_SalesUnit") && Convert.ToInt32(hashtable[(object) "id_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_SalesUnit", hashtable[(object) "id_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "id_SalesUnit_IN_") && hashtable[(object) "id_SalesUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_SalesUnit", hashtable[(object) "id_SalesUnit_IN_"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_StockUnit", hashtable[(object) "gd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "gd_StockUnit_IN_") && hashtable[(object) "gd_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_StockUnit", hashtable[(object) "gd_StockUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "id_StockUnit") && Convert.ToInt32(hashtable[(object) "id_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_StockUnit", hashtable[(object) "id_StockUnit"]));
        else if (hashtable.ContainsKey((object) "id_StockUnit_IN_") && hashtable[(object) "id_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_StockUnit", hashtable[(object) "id_StockUnit_IN_"]));
        if (hashtable.ContainsKey((object) "gd_PackUnit") && Convert.ToInt32(hashtable[(object) "gd_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_PackUnit", hashtable[(object) "gd_PackUnit"]));
        else if (hashtable.ContainsKey((object) "gd_PackUnit_IN_") && hashtable[(object) "gd_PackUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_PackUnit", hashtable[(object) "gd_PackUnit_IN_"]));
        else if (hashtable.ContainsKey((object) "id_PackUnit") && Convert.ToInt32(hashtable[(object) "id_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "id_PackUnit", hashtable[(object) "id_PackUnit"]));
        else if (hashtable.ContainsKey((object) "id_PackUnit_IN_") && hashtable[(object) "id_PackUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "id_PackUnit", hashtable[(object) "id_PackUnit_IN_"]));
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
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  id_StatementNo,id_Seq,id_SiteID,id_Supplier,id_CategoryCode,id_GoodsCode,id_BoxCode,id_BarCode,id_TaxDiv,id_SalesUnit,id_StockUnit,id_PackUnit,id_LinkRowNCount,id_BoxQty,id_InventoryQty,id_InventoryCost,id_InventoryCostAmt,id_InventoryCostVatAmt,id_AvgCost,id_AvgCostAmt,id_AvgCostVatAmt,id_InventoryPrice,id_InventoryPriceAmt,id_MobileSeq,id_InDate,id_InUser,id_ModDate,id_ModUser");
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
