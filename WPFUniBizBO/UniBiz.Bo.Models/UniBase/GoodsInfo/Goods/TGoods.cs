// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.Goods.TGoods
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
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.Goods
{
  public class TGoods : UbModelBase<TGoods>
  {
    private long _gd_GoodsCode;
    private long _gd_SiteID;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private int _gd_TaxDiv;
    private int _gd_MakerCode;
    private int _gd_BrandCode;
    private long _gd_BoxGoodsCode;
    private double _gd_BoxPackQty;
    private int _gd_Deposit;
    private int _gd_SalesUnit;
    private double _gd_MinOrderUnit;
    private int _gd_StockUnit;
    private double _gd_StockConvQty;
    private int _gd_PackUnit;
    private int _gd_AbcValue;
    private int _gd_StorageDiv;
    private string _gd_EachDeliveryYn;
    private int _gd_VolumeTotal;
    private int _gd_VolumeUnit;
    private string _gd_VolumeUnitText;
    private int _gd_AddedProperty;
    private string _gd_Memo;
    private string _gd_ErpCode;
    private string _gd_ExCode;
    private string _gd_UseYn;
    private DateTime? _gd_InDate;
    private int _gd_InUser;
    private DateTime? _gd_ModDate;
    private int _gd_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.gd_GoodsCode
    };

    public long gd_GoodsCode
    {
      get => this._gd_GoodsCode;
      set
      {
        this._gd_GoodsCode = value;
        this.Changed(nameof (gd_GoodsCode));
      }
    }

    public long gd_SiteID
    {
      get => this._gd_SiteID;
      set
      {
        this._gd_SiteID = value;
        this.Changed(nameof (gd_SiteID));
      }
    }

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gd_BarCode
    {
      get => this._gd_BarCode;
      set
      {
        this._gd_BarCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (gd_BarCode));
      }
    }

    public string gd_GoodsSize
    {
      get => this._gd_GoodsSize;
      set
      {
        this._gd_GoodsSize = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gd_GoodsSize));
      }
    }

    public int gd_TaxDiv
    {
      get => this._gd_TaxDiv;
      set
      {
        this._gd_TaxDiv = value;
        this.Changed(nameof (gd_TaxDiv));
        this.Changed("gd_TaxDivDesc");
        this.Changed("gd_IsTax");
      }
    }

    public string gd_TaxDivDesc => this.gd_TaxDiv != 0 ? Enum2StrConverter.ToTaxDiv(this.gd_TaxDiv).ToDescription() : string.Empty;

    public bool gd_IsTax => Enum2StrConverter.ToTaxDiv(this.gd_TaxDiv) == EnumTaxDiv.TAX;

    public int gd_MakerCode
    {
      get => this._gd_MakerCode;
      set
      {
        this._gd_MakerCode = value;
        this.Changed(nameof (gd_MakerCode));
      }
    }

    public int gd_BrandCode
    {
      get => this._gd_BrandCode;
      set
      {
        this._gd_BrandCode = value;
        this.Changed(nameof (gd_BrandCode));
      }
    }

    public long gd_BoxGoodsCode
    {
      get => this._gd_BoxGoodsCode;
      set
      {
        this._gd_BoxGoodsCode = value;
        this.Changed(nameof (gd_BoxGoodsCode));
      }
    }

    public double gd_BoxPackQty
    {
      get => this._gd_BoxPackQty;
      set
      {
        this._gd_BoxPackQty = value;
        this.Changed(nameof (gd_BoxPackQty));
      }
    }

    public int gd_Deposit
    {
      get => this._gd_Deposit;
      set
      {
        this._gd_Deposit = value;
        this.Changed(nameof (gd_Deposit));
      }
    }

    public int gd_SalesUnit
    {
      get => this._gd_SalesUnit;
      set
      {
        this._gd_SalesUnit = value;
        this.Changed(nameof (gd_SalesUnit));
        this.Changed("gd_SalesUnitDesc");
      }
    }

    public string gd_SalesUnitDesc => this.gd_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.gd_SalesUnit).ToDescription() : string.Empty;

    public double gd_MinOrderUnit
    {
      get => this._gd_MinOrderUnit;
      set
      {
        this._gd_MinOrderUnit = value;
        this.Changed(nameof (gd_MinOrderUnit));
      }
    }

    public int gd_StockUnit
    {
      get => this._gd_StockUnit;
      set
      {
        this._gd_StockUnit = value;
        this.Changed(nameof (gd_StockUnit));
        this.Changed("gd_StockUnitDesc");
      }
    }

    public string gd_StockUnitDesc => this.gd_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.gd_StockUnit).ToDescription() : string.Empty;

    public double gd_StockConvQty
    {
      get => this._gd_StockConvQty;
      set
      {
        this._gd_StockConvQty = value;
        this.Changed(nameof (gd_StockConvQty));
      }
    }

    public int gd_PackUnit
    {
      get => this._gd_PackUnit;
      set
      {
        this._gd_PackUnit = value;
        this.Changed(nameof (gd_PackUnit));
        this.Changed("gd_PackUnitDesc");
        this.Changed("gd_IsPackUnitEA");
      }
    }

    public string gd_PackUnitDesc => this.gd_PackUnit != 0 ? Enum2StrConverter.ToPackUnit(this.gd_PackUnit).ToDescription() : string.Empty;

    public bool gd_IsPackUnitEA => Enum2StrConverter.ToPackUnit(this.gd_PackUnit) == EnumPackUnit.EA;

    public int gd_AbcValue
    {
      get => this._gd_AbcValue;
      set
      {
        this._gd_AbcValue = value;
        this.Changed(nameof (gd_AbcValue));
        this.Changed("gd_AbcValueDesc");
      }
    }

    public string gd_AbcValueDesc => this.gd_AbcValue <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.gd_SiteID, EnumCommonCodeType.ABCType, this.gd_AbcValue);

    public int gd_StorageDiv
    {
      get => this._gd_StorageDiv;
      set
      {
        this._gd_StorageDiv = value;
        this.Changed(nameof (gd_StorageDiv));
      }
    }

    public string gd_StorageDivDesc => this.gd_StorageDiv <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.gd_SiteID, EnumCommonCodeType.StorageDiv, this.gd_StorageDiv);

    public string gd_EachDeliveryYn
    {
      get => this._gd_EachDeliveryYn;
      set
      {
        this._gd_EachDeliveryYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gd_EachDeliveryYn));
        this.Changed("gd_IsEachDeliveryYn");
        this.Changed("gd_EachDeliveryYnDesc");
      }
    }

    public bool gd_IsEachDeliveryYn => "Y".Equals(this.gd_EachDeliveryYn);

    public string gd_EachDeliveryYnDesc => !"Y".Equals(this.gd_EachDeliveryYn) ? "미사용" : "사용";

    public int gd_VolumeTotal
    {
      get => this._gd_VolumeTotal;
      set
      {
        this._gd_VolumeTotal = value;
        this.Changed(nameof (gd_VolumeTotal));
      }
    }

    public int gd_VolumeUnit
    {
      get => this._gd_VolumeUnit;
      set
      {
        this._gd_VolumeUnit = value;
        this.Changed(nameof (gd_VolumeUnit));
      }
    }

    public string gd_VolumeUnitText
    {
      get => this._gd_VolumeUnitText;
      set
      {
        this._gd_VolumeUnitText = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gd_VolumeUnitText));
      }
    }

    public int gd_AddedProperty
    {
      get => this._gd_AddedProperty;
      set
      {
        this._gd_AddedProperty = value;
        this.Changed(nameof (gd_AddedProperty));
      }
    }

    public string gd_Memo
    {
      get => this._gd_Memo;
      set
      {
        this._gd_Memo = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (gd_Memo));
      }
    }

    public string gd_ErpCode
    {
      get => this._gd_ErpCode;
      set
      {
        this._gd_ErpCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (gd_ErpCode));
      }
    }

    public string gd_ExCode
    {
      get => this._gd_ExCode;
      set
      {
        this._gd_ExCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (gd_ExCode));
      }
    }

    public string gd_UseYn
    {
      get => this._gd_UseYn;
      set
      {
        this._gd_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gd_UseYn));
        this.Changed("gd_IsUseYn");
        this.Changed("gd_UseYnDesc");
      }
    }

    public bool gd_IsUseYn => "Y".Equals(this.gd_UseYn);

    public string gd_UseYnDesc => !"Y".Equals(this.gd_UseYn) ? "미사용" : "사용";

    public DateTime? gd_InDate
    {
      get => this._gd_InDate;
      set
      {
        this._gd_InDate = value;
        this.Changed(nameof (gd_InDate));
      }
    }

    public int gd_InUser
    {
      get => this._gd_InUser;
      set
      {
        this._gd_InUser = value;
        this.Changed(nameof (gd_InUser));
      }
    }

    public DateTime? gd_ModDate
    {
      get => this._gd_ModDate;
      set
      {
        this._gd_ModDate = value;
        this.Changed(nameof (gd_ModDate));
      }
    }

    public int gd_ModUser
    {
      get => this._gd_ModUser;
      set
      {
        this._gd_ModUser = value;
        this.Changed(nameof (gd_ModUser));
      }
    }

    public TGoods() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gd_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("gd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gd_GoodsName", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsName",
        tc_trans_name = "상품명"
      });
      columnInfo.Add("gd_BarCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BarCode",
        tc_trans_name = "상품바코드"
      });
      columnInfo.Add("gd_GoodsSize", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsSize",
        tc_trans_name = "규격"
      });
      columnInfo.Add("gd_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "gd_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51
      });
      columnInfo.Add("gd_MakerCode", new TTableColumn()
      {
        tc_orgin_name = "gd_MakerCode",
        tc_trans_name = "제조사코드"
      });
      columnInfo.Add("gd_BrandCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BrandCode",
        tc_trans_name = "브랜드코드"
      });
      columnInfo.Add("gd_BoxGoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BoxGoodsCode",
        tc_trans_name = "박스코드"
      });
      columnInfo.Add("gd_BoxPackQty", new TTableColumn()
      {
        tc_orgin_name = "gd_BoxPackQty",
        tc_trans_name = "박스입수"
      });
      columnInfo.Add("gd_Deposit", new TTableColumn()
      {
        tc_orgin_name = "gd_Deposit",
        tc_trans_name = "보증금"
      });
      columnInfo.Add("gd_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("gd_MinOrderUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_MinOrderUnit",
        tc_trans_name = "최소발주량"
      });
      columnInfo.Add("gd_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("gd_StockConvQty", new TTableColumn()
      {
        tc_orgin_name = "gd_StockConvQty",
        tc_trans_name = "재고환산수량"
      });
      columnInfo.Add("gd_PackUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_PackUnit",
        tc_trans_name = "묶음단위",
        tc_comm_code = 54
      });
      columnInfo.Add("gd_AbcValue", new TTableColumn()
      {
        tc_orgin_name = "gd_AbcValue",
        tc_trans_name = "ABC분석",
        tc_comm_code = 56
      });
      columnInfo.Add("gd_StorageDiv", new TTableColumn()
      {
        tc_orgin_name = "gd_StorageDiv",
        tc_trans_name = "보관방법",
        tc_comm_code = 57
      });
      columnInfo.Add("gd_EachDeliveryYn", new TTableColumn()
      {
        tc_orgin_name = "gd_EachDeliveryYn",
        tc_trans_name = "개별배송여부"
      });
      columnInfo.Add("gd_VolumeTotal", new TTableColumn()
      {
        tc_orgin_name = "gd_VolumeTotal",
        tc_trans_name = "총용량"
      });
      columnInfo.Add("gd_VolumeUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_VolumeUnit",
        tc_trans_name = "단위용량"
      });
      columnInfo.Add("gd_VolumeUnitText", new TTableColumn()
      {
        tc_orgin_name = "gd_VolumeUnitText",
        tc_trans_name = "기준단위"
      });
      columnInfo.Add("gd_AddedProperty", new TTableColumn()
      {
        tc_orgin_name = "gd_AddedProperty",
        tc_trans_name = "추가상품속성"
      });
      columnInfo.Add("gd_Memo", new TTableColumn()
      {
        tc_orgin_name = "gd_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("gd_ErpCode", new TTableColumn()
      {
        tc_orgin_name = "gd_ErpCode",
        tc_trans_name = "ERP 연결코드"
      });
      columnInfo.Add("gd_ExCode", new TTableColumn()
      {
        tc_orgin_name = "gd_ExCode",
        tc_trans_name = "확장 연결코드"
      });
      columnInfo.Add("gd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gd_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("gd_InDate", new TTableColumn()
      {
        tc_orgin_name = "gd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gd_InUser", new TTableColumn()
      {
        tc_orgin_name = "gd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Goods;
      this.gd_GoodsCode = 0L;
      this.gd_SiteID = 0L;
      this.gd_GoodsName = string.Empty;
      this.gd_BarCode = string.Empty;
      this.gd_GoodsSize = string.Empty;
      this.gd_TaxDiv = 1;
      this.gd_MakerCode = this.gd_BrandCode = 0;
      this.gd_BoxGoodsCode = 0L;
      this.gd_BoxPackQty = 0.0;
      this.gd_Deposit = 0;
      this.gd_SalesUnit = 1;
      this.gd_MinOrderUnit = 0.0;
      this.gd_StockUnit = 2;
      this.gd_StockConvQty = 0.0;
      this.gd_PackUnit = 1;
      this.gd_AbcValue = 0;
      this.gd_StorageDiv = 1;
      this.gd_EachDeliveryYn = "Y";
      this.gd_VolumeTotal = this.gd_VolumeUnit = 0;
      this.gd_VolumeUnitText = string.Empty;
      this.gd_AddedProperty = 0;
      this.gd_Memo = string.Empty;
      this.gd_ErpCode = string.Empty;
      this.gd_ExCode = string.Empty;
      this.gd_UseYn = "Y";
      this.gd_InDate = new DateTime?();
      this.gd_InUser = 0;
      this.gd_ModDate = new DateTime?();
      this.gd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoods();

    public override object Clone()
    {
      TGoods tgoods = base.Clone() as TGoods;
      tgoods.gd_GoodsCode = this.gd_GoodsCode;
      tgoods.gd_SiteID = this.gd_SiteID;
      tgoods.gd_GoodsName = this.gd_GoodsName;
      tgoods.gd_BarCode = this.gd_BarCode;
      tgoods.gd_GoodsSize = this.gd_GoodsSize;
      tgoods.gd_TaxDiv = this.gd_TaxDiv;
      tgoods.gd_MakerCode = this.gd_MakerCode;
      tgoods.gd_BrandCode = this.gd_BrandCode;
      tgoods.gd_BoxGoodsCode = this.gd_BoxGoodsCode;
      tgoods.gd_BoxPackQty = this.gd_BoxPackQty;
      tgoods.gd_Deposit = this.gd_Deposit;
      tgoods.gd_SalesUnit = this.gd_SalesUnit;
      tgoods.gd_MinOrderUnit = this.gd_MinOrderUnit;
      tgoods.gd_StockUnit = this.gd_StockUnit;
      tgoods.gd_StockConvQty = this.gd_StockConvQty;
      tgoods.gd_PackUnit = this.gd_PackUnit;
      tgoods.gd_AbcValue = this.gd_AbcValue;
      tgoods.gd_StorageDiv = this.gd_StorageDiv;
      tgoods.gd_EachDeliveryYn = this.gd_EachDeliveryYn;
      tgoods.gd_VolumeTotal = this.gd_VolumeTotal;
      tgoods.gd_VolumeUnit = this.gd_VolumeUnit;
      tgoods.gd_VolumeUnitText = this.gd_VolumeUnitText;
      tgoods.gd_AddedProperty = this.gd_AddedProperty;
      tgoods.gd_Memo = this.gd_Memo;
      tgoods.gd_ErpCode = this.gd_ErpCode;
      tgoods.gd_ExCode = this.gd_ExCode;
      tgoods.gd_UseYn = this.gd_UseYn;
      tgoods.gd_InDate = this.gd_InDate;
      tgoods.gd_InUser = this.gd_InUser;
      tgoods.gd_ModDate = this.gd_ModDate;
      tgoods.gd_ModUser = this.gd_ModUser;
      return (object) tgoods;
    }

    public void PutData(TGoods pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gd_GoodsCode = pSource.gd_GoodsCode;
      this.gd_SiteID = pSource.gd_SiteID;
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_TaxDiv = pSource.gd_TaxDiv;
      this.gd_MakerCode = pSource.gd_MakerCode;
      this.gd_BrandCode = pSource.gd_BrandCode;
      this.gd_BoxGoodsCode = pSource.gd_BoxGoodsCode;
      this.gd_BoxPackQty = pSource.gd_BoxPackQty;
      this.gd_Deposit = pSource.gd_Deposit;
      this.gd_SalesUnit = pSource.gd_SalesUnit;
      this.gd_MinOrderUnit = pSource.gd_MinOrderUnit;
      this.gd_StockUnit = pSource.gd_StockUnit;
      this.gd_StockConvQty = pSource.gd_StockConvQty;
      this.gd_PackUnit = pSource.gd_PackUnit;
      this.gd_AbcValue = pSource.gd_AbcValue;
      this.gd_StorageDiv = pSource.gd_StorageDiv;
      this.gd_EachDeliveryYn = pSource.gd_EachDeliveryYn;
      this.gd_VolumeTotal = pSource.gd_VolumeTotal;
      this.gd_VolumeUnit = pSource.gd_VolumeUnit;
      this.gd_VolumeUnitText = pSource.gd_VolumeUnitText;
      this.gd_AddedProperty = pSource.gd_AddedProperty;
      this.gd_Memo = pSource.gd_Memo;
      this.gd_ErpCode = pSource.gd_ErpCode;
      this.gd_ExCode = pSource.gd_ExCode;
      this.gd_UseYn = pSource.gd_UseYn;
      this.gd_InDate = pSource.gd_InDate;
      this.gd_InUser = pSource.gd_InUser;
      this.gd_ModDate = pSource.gd_ModDate;
      this.gd_ModUser = pSource.gd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gd_GoodsCode = p_rs.GetFieldLong("gd_GoodsCode");
        if (this.gd_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gd_SiteID = p_rs.GetFieldLong("gd_SiteID");
        this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
        this.gd_TaxDiv = p_rs.GetFieldInt("gd_TaxDiv");
        this.gd_MakerCode = p_rs.GetFieldInt("gd_MakerCode");
        this.gd_BrandCode = p_rs.GetFieldInt("gd_BrandCode");
        this.gd_BoxGoodsCode = p_rs.GetFieldLong("gd_BoxGoodsCode");
        this.gd_BoxPackQty = p_rs.GetFieldDouble("gd_BoxPackQty");
        this.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
        this.gd_SalesUnit = p_rs.GetFieldInt("gd_SalesUnit");
        this.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
        this.gd_StockUnit = p_rs.GetFieldInt("gd_StockUnit");
        this.gd_StockConvQty = p_rs.GetFieldDouble("gd_StockConvQty");
        this.gd_PackUnit = p_rs.GetFieldInt("gd_PackUnit");
        this.gd_AbcValue = p_rs.GetFieldInt("gd_AbcValue");
        this.gd_StorageDiv = p_rs.GetFieldInt("gd_StorageDiv");
        this.gd_EachDeliveryYn = p_rs.GetFieldString("gd_EachDeliveryYn");
        this.gd_VolumeTotal = p_rs.GetFieldInt("gd_VolumeTotal");
        this.gd_VolumeUnit = p_rs.GetFieldInt("gd_VolumeUnit");
        this.gd_VolumeUnitText = p_rs.GetFieldString("gd_VolumeUnitText");
        this.gd_AddedProperty = p_rs.GetFieldInt("gd_AddedProperty");
        this.gd_Memo = p_rs.GetFieldString("gd_Memo");
        this.gd_ErpCode = p_rs.GetFieldString("gd_ErpCode");
        this.gd_ExCode = p_rs.GetFieldString("gd_ExCode");
        this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
        this.gd_InDate = p_rs.GetFieldDateTime("gd_InDate");
        this.gd_InUser = p_rs.GetFieldInt("gd_InUser");
        this.gd_ModDate = p_rs.GetFieldDateTime("gd_ModDate");
        this.gd_ModUser = p_rs.GetFieldInt("gd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_AbcValue,gd_StorageDiv,gd_EachDeliveryYn,gd_VolumeTotal,gd_VolumeUnit,gd_VolumeUnitText,gd_AddedProperty,gd_Memo,gd_ErpCode,gd_ExCode,gd_UseYn,gd_InDate,gd_InUser,gd_ModDate,gd_ModUser) VALUES ( " + string.Format(" {0}", (object) this.gd_GoodsCode) + string.Format(",{0}", (object) this.gd_SiteID) + string.Format(",'{0}','{1}','{2}',{3}", (object) this.gd_GoodsName, (object) this.gd_BarCode, (object) this.gd_GoodsSize, (object) this.gd_TaxDiv) + string.Format(",{0},{1},{2},{3}", (object) this.gd_MakerCode, (object) this.gd_BrandCode, (object) this.gd_BoxGoodsCode, (object) this.gd_BoxPackQty.FormatTo("{0:0.0000}")) + string.Format(",{0},{1},{2},{3}", (object) this.gd_Deposit, (object) this.gd_SalesUnit, (object) this.gd_MinOrderUnit.FormatTo("{0:0.0000}"), (object) this.gd_StockUnit) + string.Format(",{0},{1},{2},{3}", (object) this.gd_StockConvQty.FormatTo("{0:0.0000}"), (object) this.gd_PackUnit, (object) this.gd_AbcValue, (object) this.gd_StorageDiv) + string.Format(",'{0}',{1},{2},'{3}'", (object) this.gd_EachDeliveryYn, (object) this.gd_VolumeTotal, (object) this.gd_VolumeUnit, (object) this.gd_VolumeUnitText) + string.Format(",{0},'{1}','{2}','{3}'", (object) this.gd_AddedProperty, (object) this.gd_Memo, (object) this.gd_ErpCode, (object) this.gd_ExCode) + ",'" + this.gd_UseYn + "'" + string.Format(",{0},{1}", (object) this.gd_InDate.GetDateToStrInNull(), (object) this.gd_InUser) + string.Format(",{0},{1}", (object) this.gd_ModDate.GetDateToStrInNull(), (object) this.gd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gd_GoodsCode, (object) this.gd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoods tgoods = this;
      // ISSUE: reference to a compiler-generated method
      tgoods.\u003C\u003En__0();
      if (await tgoods.OleDB.ExecuteAsync(tgoods.InsertQuery()))
        return true;
      tgoods.message = " " + tgoods.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoods.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoods.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoods.gd_GoodsCode, (object) tgoods.gd_SiteID) + " 내용 : " + tgoods.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoods.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gd_GoodsName='" + this.gd_GoodsName + "',gd_BarCode='" + this.gd_BarCode + "',gd_GoodsSize='" + this.gd_GoodsSize + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_MakerCode", (object) this.gd_MakerCode, (object) "gd_BrandCode", (object) this.gd_BrandCode) + ",gd_BoxPackQty=" + this.gd_BoxPackQty.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "gd_Deposit", (object) this.gd_Deposit) + ",gd_MinOrderUnit=" + this.gd_MinOrderUnit.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gd_AbcValue", (object) this.gd_AbcValue, (object) "gd_StorageDiv", (object) this.gd_StorageDiv) + ",gd_EachDeliveryYn='" + this.gd_EachDeliveryYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_VolumeTotal", (object) this.gd_VolumeTotal, (object) "gd_VolumeUnit", (object) this.gd_VolumeUnit) + ",gd_VolumeUnitText='" + this.gd_VolumeUnitText + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "gd_AddedProperty", (object) this.gd_AddedProperty, (object) "gd_Memo", (object) this.gd_Memo) + ",gd_ErpCode='" + this.gd_ErpCode + "',gd_ExCode='" + this.gd_ExCode + "',gd_UseYn='" + this.gd_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_ModDate", (object) this.gd_ModDate.GetDateToStrInNull(), (object) "gd_ModUser", (object) this.gd_ModUser) + string.Format(" WHERE {0}={1}", (object) "gd_GoodsCode", (object) this.gd_GoodsCode) + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) this.gd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gd_GoodsCode, (object) this.gd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoods tgoods = this;
      // ISSUE: reference to a compiler-generated method
      tgoods.\u003C\u003En__1();
      if (await tgoods.OleDB.ExecuteAsync(tgoods.UpdateQuery()))
        return true;
      tgoods.message = " " + tgoods.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoods.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoods.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoods.gd_GoodsCode, (object) tgoods.gd_SiteID) + " 내용 : " + tgoods.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoods.message);
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
      stringBuilder.Append(" gd_GoodsName='" + this.gd_GoodsName + "',gd_BarCode='" + this.gd_BarCode + "',gd_GoodsSize='" + this.gd_GoodsSize + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_MakerCode", (object) this.gd_MakerCode, (object) "gd_BrandCode", (object) this.gd_BrandCode) + ",gd_BoxPackQty=" + this.gd_BoxPackQty.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "gd_Deposit", (object) this.gd_Deposit) + ",gd_MinOrderUnit=" + this.gd_MinOrderUnit.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gd_AbcValue", (object) this.gd_AbcValue, (object) "gd_StorageDiv", (object) this.gd_StorageDiv) + ",gd_EachDeliveryYn='" + this.gd_EachDeliveryYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_VolumeTotal", (object) this.gd_VolumeTotal, (object) "gd_VolumeUnit", (object) this.gd_VolumeUnit) + ",gd_VolumeUnitText='" + this.gd_VolumeUnitText + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "gd_AddedProperty", (object) this.gd_AddedProperty, (object) "gd_Memo", (object) this.gd_Memo) + ",gd_ErpCode='" + this.gd_ErpCode + "',gd_ExCode='" + this.gd_ExCode + "',gd_UseYn='" + this.gd_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gd_ModDate", (object) this.gd_ModDate.GetDateToStrInNull(), (object) "gd_ModUser", (object) this.gd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gd_GoodsCode, (object) this.gd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoods tgoods = this;
      // ISSUE: reference to a compiler-generated method
      tgoods.\u003C\u003En__1();
      if (await tgoods.OleDB.ExecuteAsync(tgoods.UpdateExInsertQuery()))
        return true;
      tgoods.message = " " + tgoods.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoods.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoods.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoods.gd_GoodsCode, (object) tgoods.gd_SiteID) + " 내용 : " + tgoods.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoods.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gd_SiteID") && Convert.ToInt64(hashtable[(object) "gd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_GoodsCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "gd_GoodsCode_IN_") && hashtable[(object) "gd_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gd_GoodsCode", hashtable[(object) "gd_GoodsCode_IN_"]));
        else
          stringBuilder.Append(" AND gd_GoodsCode>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gd_GoodsName") && hashtable[(object) "gd_GoodsName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_GoodsName", hashtable[(object) "gd_GoodsName"]));
        if (hashtable.ContainsKey((object) "gd_BarCode") && hashtable[(object) "gd_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_BarCode", hashtable[(object) "gd_BarCode"]));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        if (hashtable.ContainsKey((object) "mk_MakerCode") && Convert.ToInt32(hashtable[(object) "mk_MakerCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_MakerCode", hashtable[(object) "mk_MakerCode"]));
        else if (hashtable.ContainsKey((object) "gd_MakerCode") && Convert.ToInt32(hashtable[(object) "gd_MakerCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_MakerCode", hashtable[(object) "gd_MakerCode"]));
        else if (hashtable.ContainsKey((object) "mk_MakerCode_IN_") && hashtable[(object) "mk_MakerCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mk_MakerCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gd_MakerCode", hashtable[(object) "mk_MakerCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_MakerCode", hashtable[(object) "mk_MakerCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "gd_MakerCode_IN_") && hashtable[(object) "gd_MakerCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "gd_MakerCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gd_MakerCode", hashtable[(object) "gd_MakerCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_MakerCode", hashtable[(object) "gd_MakerCode_IN_"]));
        }
        if (hashtable.ContainsKey((object) "br_BrandCode") && Convert.ToInt32(hashtable[(object) "br_BrandCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_MakerCode", hashtable[(object) "br_BrandCode"]));
        else if (hashtable.ContainsKey((object) "gd_BrandCode") && Convert.ToInt32(hashtable[(object) "gd_BrandCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_BrandCode", hashtable[(object) "gd_BrandCode"]));
        else if (hashtable.ContainsKey((object) "br_BrandCode_IN_") && hashtable[(object) "br_BrandCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "br_BrandCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gd_BrandCode", hashtable[(object) "br_BrandCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_BrandCode", hashtable[(object) "br_BrandCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "gd_BrandCode_IN_") && hashtable[(object) "gd_BrandCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "gd_BrandCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gd_BrandCode", hashtable[(object) "gd_BrandCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_BrandCode", hashtable[(object) "gd_BrandCode_IN_"]));
        }
        if (hashtable.ContainsKey((object) "gd_BoxGoodsCode") && Convert.ToInt64(hashtable[(object) "gd_BoxGoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_BoxGoodsCode", hashtable[(object) "gd_BoxGoodsCode"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_StockUnit", hashtable[(object) "gd_StockUnit"]));
        if (hashtable.ContainsKey((object) "gd_PackUnit") && Convert.ToInt32(hashtable[(object) "gd_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_PackUnit", hashtable[(object) "gd_PackUnit"]));
        if (hashtable.ContainsKey((object) "gd_AbcValue") && Convert.ToInt32(hashtable[(object) "gd_AbcValue"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_AbcValue", hashtable[(object) "gd_AbcValue"]));
        if (hashtable.ContainsKey((object) "gd_StorageDiv") && Convert.ToInt32(hashtable[(object) "gd_StorageDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_StorageDiv", hashtable[(object) "gd_StorageDiv"]));
        if (hashtable.ContainsKey((object) "gd_EachDeliveryYn") && hashtable[(object) "gd_EachDeliveryYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_EachDeliveryYn", hashtable[(object) "gd_EachDeliveryYn"]));
        if (hashtable.ContainsKey((object) "gd_ErpCode") && hashtable[(object) "gd_ErpCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_ErpCode", hashtable[(object) "gd_ErpCode"]));
        if (hashtable.ContainsKey((object) "gd_ExCode") && hashtable[(object) "gd_ExCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_ExCode", hashtable[(object) "gd_ExCode"]));
        if (hashtable.ContainsKey((object) "gd_UseYn") && hashtable[(object) "gd_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_UseYn", hashtable[(object) "gd_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gd_GoodsName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gd_GoodsSize", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gd_BarCode", hashtable[(object) "_KEY_WORD_"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_AbcValue,gd_StorageDiv,gd_EachDeliveryYn,gd_VolumeTotal,gd_VolumeUnit,gd_VolumeUnitText,gd_AddedProperty,gd_Memo,gd_ErpCode,gd_ExCode,gd_UseYn,gd_InDate,gd_InUser,gd_ModDate,gd_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
