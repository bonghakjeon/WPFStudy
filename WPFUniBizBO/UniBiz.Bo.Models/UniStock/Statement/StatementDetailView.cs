// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementDetailView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniStock.Inventory.InventorySummary;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementDetailView : TStatementDetail<StatementDetailView>
  {
    private int _sh_StoreCode;
    private int _sh_OrderStatus;
    private DateTime? _sh_ConfirmDate;
    private int _sh_ConfirmStatus;
    private int _sh_Supplier;
    private int _sh_InOutDiv;
    private int _sh_StatementType;
    private int _gdh_SupplierTypeOuterMoveIn;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _si_LocationUseYn;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private int _su_PreTaxDiv;
    private int _su_MultiSuplierDiv;
    private int _su_DeductionDayDiv;
    private string _su_NewStatementYn;
    private int _su_SupplierTypeOuterMoveIn;
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
    private string _gd_UseYn;
    private DateTime? _gdh_StartDate;
    private DateTime? _gdh_EndDate;
    private int _gdh_GoodsCategory;
    private int _gdh_Supplier;
    private double _gdh_ChargeRate;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;
    private int _dpt_ID;
    private string _dpt_ViewCode;
    private string _dpt_DeptName;
    private int _ctg_lv1_ID;
    private string _ctg_lv1_ViewCode;
    private string _ctg_lv1_Name;
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;
    private string _ctg_ViewCode;
    private string _ctg_CategoryName;
    private int _gdsh_DeliveryDiv;
    private double _gdsh_MinOrderUnit;
    private string _gdsh_MultiSuplierYn;
    private DateTime? _gdsh_OrderEndDate;
    private DateTime? _gdsh_SaleEndDate;
    private double _pls_EndQty;
    private double _pls_EndAvgCost;
    private double _pls_EndCostAmt;
    private double _pls_EndCostVatAmt;
    private double _pls_SaleQty;
    private double _pls_SaleAmt;
    private double _pls_BuyQty;
    private double _pls_BuyCostAmt;
    private double _pls_BuyCostVatAmt;
    private double _pls_InnerMoveInQty;
    private double _pls_InnerMoveInCostAmt;
    private double _pls_InnerMoveInCostVatAmt;
    private double _pls_OuterMoveInQty;
    private double _pls_OuterMoveInCostAmt;
    private double _pls_OuterMoveInCostVatAmt;
    private double _gdp_StockConvQty;
    private string _inEmpName;
    private string _modEmpName;
    private IList<GoodsPackBomTypeSet> _Lt_BomTypePackSet;
    private IList<StatementDetailView> _Lt_History;

    public int sh_StoreCode
    {
      get => this._sh_StoreCode;
      set
      {
        this._sh_StoreCode = value;
        this.Changed(nameof (sh_StoreCode));
      }
    }

    public int sh_OrderStatus
    {
      get => this._sh_OrderStatus;
      set
      {
        this._sh_OrderStatus = value;
        this.Changed(nameof (sh_OrderStatus));
        this.Changed("sh_OrderStatusDesc");
        this.Changed("IsOrderConfirm");
        this.Changed("IsOrderNotConfirm");
        this.Changed("IsOrderToStatement");
        this.Changed("IsOrderDead");
        this.Changed("IsOrderDelete");
        this.Changed("IsOrder");
      }
    }

    public string sh_OrderStatusDesc => this.sh_OrderStatus != 0 ? Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool IsOrderConfirm => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Confirm;

    [JsonIgnore]
    public bool IsOrderNotConfirm => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.NotConfirm;

    [JsonIgnore]
    public bool IsOrderToStatement => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Statement;

    [JsonIgnore]
    public bool IsOrderDead => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Dead;

    [JsonIgnore]
    public bool IsOrderDelete => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Delete;

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
      }
    }

    public int sh_ConfirmStatus
    {
      get => this._sh_ConfirmStatus;
      set
      {
        this._sh_ConfirmStatus = value;
        this.Changed(nameof (sh_ConfirmStatus));
        this.Changed("sh_ConfirmStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
        this.Changed("IsDelete");
        this.Changed("IsOrder");
      }
    }

    public string sh_ConfirmStatusDesc => this.sh_ConfirmStatus != 0 ? Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool IsConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.Confirm;

    [JsonIgnore]
    public bool IsNotConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.NotConfirm;

    [JsonIgnore]
    public bool IsDelete => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.Delete;

    [JsonIgnore]
    public bool IsOrder => this.IsNotConfirm && !this.IsOrderDead;

    public int sh_Supplier
    {
      get => this._sh_Supplier;
      set
      {
        this._sh_Supplier = value;
        this.Changed(nameof (sh_Supplier));
      }
    }

    public int sh_InOutDiv
    {
      get => this._sh_InOutDiv;
      set
      {
        this._sh_InOutDiv = value;
        this.Changed(nameof (sh_InOutDiv));
        this.Changed("IsInOutNormal");
        this.Changed("IsInOutReturn");
        this.Changed("IsOuterMoveIn");
        this.Changed("IsOuterMoveOut");
      }
    }

    [JsonIgnore]
    public bool IsInOutNormal => Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv) == EnumInOutDiv.Normal;

    [JsonIgnore]
    public bool IsInOutReturn => Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv) == EnumInOutDiv.Return;

    public int sh_StatementType
    {
      get => this._sh_StatementType;
      set
      {
        this._sh_StatementType = value;
        this.Changed(nameof (sh_StatementType));
        this.Changed("sh_StatementTypeDesc");
        this.Changed("IsBuy");
        this.Changed("IsSale");
        this.Changed("IsInnerMove");
        this.Changed("IsOuterMove");
        this.Changed("IsOuterMoveIn");
        this.Changed("IsOuterMoveOut");
        this.Changed("IsAdjust");
        this.Changed("IsDisuse");
        this.Changed("IsStockMove");
        this.Changed("IsPayment");
      }
    }

    [JsonIgnore]
    public string sh_StatementTypeDesc => this.sh_StatementType != 0 ? Enum2StrConverter.ToStatementType(this.sh_StatementType).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool IsBuy => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Buy;

    [JsonIgnore]
    public bool IsSale => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Sale;

    [JsonIgnore]
    public bool IsInnerMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.InnerMove;

    [JsonIgnore]
    public bool IsOuterMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove;

    [JsonIgnore]
    public bool IsOuterMoveIn => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove && this.IsInOutNormal;

    [JsonIgnore]
    public bool IsOuterMoveOut => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove && this.IsInOutReturn;

    [JsonIgnore]
    public bool IsAdjust => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Adjust;

    [JsonIgnore]
    public bool IsDisuse => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Disuse;

    [JsonIgnore]
    public bool IsStockMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.StockMove;

    [JsonIgnore]
    public bool IsPayment => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Payment;

    public int gdh_SupplierTypeOuterMoveIn
    {
      get => this._gdh_SupplierTypeOuterMoveIn;
      set
      {
        this._gdh_SupplierTypeOuterMoveIn = value;
        this.Changed(nameof (gdh_SupplierTypeOuterMoveIn));
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

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = value;
        this.Changed(nameof (si_LocationUseYn));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = value;
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public int su_SupplierKind
    {
      get => this._su_SupplierKind;
      set
      {
        this._su_SupplierKind = value;
        this.Changed(nameof (su_SupplierKind));
      }
    }

    public string su_SupplierKindDesc => this.su_SupplierKind != 0 ? Enum2StrConverter.ToSupplierKind(this.su_SupplierKind).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = value;
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public int su_PreTaxDiv
    {
      get => this._su_PreTaxDiv;
      set
      {
        this._su_PreTaxDiv = value;
        this.Changed(nameof (su_PreTaxDiv));
      }
    }

    public string su_PreTaxDivDesc => this.su_PreTaxDiv != 0 ? Enum2StrConverter.ToStdPreTax(this.su_PreTaxDiv).ToDescription() : string.Empty;

    public int su_MultiSuplierDiv
    {
      get => this._su_MultiSuplierDiv;
      set
      {
        this._su_MultiSuplierDiv = value;
        this.Changed(nameof (su_MultiSuplierDiv));
      }
    }

    public string su_MultiSuplierDivDesc => this.su_MultiSuplierDiv != 0 ? Enum2StrConverter.ToSupplierMulti(this.su_MultiSuplierDiv).ToDescription() : string.Empty;

    public int su_DeductionDayDiv
    {
      get => this._su_DeductionDayDiv;
      set
      {
        this._su_DeductionDayDiv = value;
        this.Changed(nameof (su_DeductionDayDiv));
      }
    }

    public string su_DeductionDayDivDesc => this.su_DeductionDayDiv != 0 ? Enum2StrConverter.ToSupplierDeductionDayType(this.su_DeductionDayDiv).ToDescription() : string.Empty;

    public string su_NewStatementYn
    {
      get => this._su_NewStatementYn;
      set
      {
        this._su_NewStatementYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (su_NewStatementYn));
        this.Changed("su_IsNewStatementYn");
        this.Changed("su_NewStatementYnDesc");
      }
    }

    public bool su_IsNewStatementYn => "Y".Equals(this.su_NewStatementYn);

    public string su_NewStatementYnDesc => !"Y".Equals(this.su_NewStatementYn) ? "미사용" : "사용";

    public int su_SupplierTypeOuterMoveIn
    {
      get => this._su_SupplierTypeOuterMoveIn;
      set
      {
        this._su_SupplierTypeOuterMoveIn = value;
        this.Changed(nameof (su_SupplierTypeOuterMoveIn));
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

    public string gd_GoodsSize
    {
      get => this._gd_GoodsSize;
      set
      {
        this._gd_GoodsSize = value;
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

    public DateTime? gdh_StartDate
    {
      get => this._gdh_StartDate;
      set
      {
        this._gdh_StartDate = value;
        this.Changed(nameof (gdh_StartDate));
      }
    }

    public DateTime? gdh_EndDate
    {
      get => this._gdh_EndDate;
      set
      {
        this._gdh_EndDate = value;
        this.Changed(nameof (gdh_EndDate));
      }
    }

    public int gdh_GoodsCategory
    {
      get => this._gdh_GoodsCategory;
      set
      {
        this._gdh_GoodsCategory = value;
        this.Changed(nameof (gdh_GoodsCategory));
      }
    }

    public int gdh_Supplier
    {
      get => this._gdh_Supplier;
      set
      {
        this._gdh_Supplier = value;
        this.Changed(nameof (gdh_Supplier));
      }
    }

    public double gdh_ChargeRate
    {
      get => this._gdh_ChargeRate;
      set
      {
        this._gdh_ChargeRate = value;
        this.Changed(nameof (gdh_ChargeRate));
      }
    }

    public double gdh_BuyCost
    {
      get => this._gdh_BuyCost;
      set
      {
        this._gdh_BuyCost = value;
        this.Changed(nameof (gdh_BuyCost));
      }
    }

    public double gdh_BuyVat
    {
      get => this._gdh_BuyVat;
      set
      {
        this._gdh_BuyVat = value;
        this.Changed(nameof (gdh_BuyVat));
      }
    }

    public double gdh_SalePrice
    {
      get => this._gdh_SalePrice;
      set
      {
        this._gdh_SalePrice = value;
        this.Changed(nameof (gdh_SalePrice));
      }
    }

    public double gdh_EventCost
    {
      get => this._gdh_EventCost;
      set
      {
        this._gdh_EventCost = value;
        this.Changed(nameof (gdh_EventCost));
      }
    }

    public double gdh_EventVat
    {
      get => this._gdh_EventVat;
      set
      {
        this._gdh_EventVat = value;
        this.Changed(nameof (gdh_EventVat));
      }
    }

    public double gdh_EventPrice
    {
      get => this._gdh_EventPrice;
      set
      {
        this._gdh_EventPrice = value;
        this.Changed(nameof (gdh_EventPrice));
      }
    }

    public int dpt_lv1_ID
    {
      get => this._dpt_lv1_ID;
      set
      {
        this._dpt_lv1_ID = value;
        this.Changed(nameof (dpt_lv1_ID));
      }
    }

    public string dpt_lv1_ViewCode
    {
      get => this._dpt_lv1_ViewCode;
      set
      {
        this._dpt_lv1_ViewCode = value;
        this.Changed(nameof (dpt_lv1_ViewCode));
      }
    }

    public string dpt_lv1_Name
    {
      get => this._dpt_lv1_Name;
      set
      {
        this._dpt_lv1_Name = value;
        this.Changed(nameof (dpt_lv1_Name));
      }
    }

    public int dpt_lv2_ID
    {
      get => this._dpt_lv2_ID;
      set
      {
        this._dpt_lv2_ID = value;
        this.Changed(nameof (dpt_lv2_ID));
      }
    }

    public string dpt_lv2_ViewCode
    {
      get => this._dpt_lv2_ViewCode;
      set
      {
        this._dpt_lv2_ViewCode = value;
        this.Changed(nameof (dpt_lv2_ViewCode));
      }
    }

    public string dpt_lv2_Name
    {
      get => this._dpt_lv2_Name;
      set
      {
        this._dpt_lv2_Name = value;
        this.Changed(nameof (dpt_lv2_Name));
      }
    }

    public int dpt_ID
    {
      get => this._dpt_ID;
      set
      {
        this._dpt_ID = value;
        this.Changed(nameof (dpt_ID));
      }
    }

    public string dpt_ViewCode
    {
      get => this._dpt_ViewCode;
      set
      {
        this._dpt_ViewCode = value;
        this.Changed(nameof (dpt_ViewCode));
      }
    }

    public string dpt_DeptName
    {
      get => this._dpt_DeptName;
      set
      {
        this._dpt_DeptName = value;
        this.Changed(nameof (dpt_DeptName));
      }
    }

    public int ctg_lv1_ID
    {
      get => this._ctg_lv1_ID;
      set
      {
        this._ctg_lv1_ID = value;
        this.Changed(nameof (ctg_lv1_ID));
      }
    }

    public string ctg_lv1_ViewCode
    {
      get => this._ctg_lv1_ViewCode;
      set
      {
        this._ctg_lv1_ViewCode = value;
        this.Changed(nameof (ctg_lv1_ViewCode));
      }
    }

    public string ctg_lv1_Name
    {
      get => this._ctg_lv1_Name;
      set
      {
        this._ctg_lv1_Name = value;
        this.Changed(nameof (ctg_lv1_Name));
      }
    }

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
      }
    }

    public string ctg_lv2_ViewCode
    {
      get => this._ctg_lv2_ViewCode;
      set
      {
        this._ctg_lv2_ViewCode = value;
        this.Changed(nameof (ctg_lv2_ViewCode));
      }
    }

    public string ctg_lv2_Name
    {
      get => this._ctg_lv2_Name;
      set
      {
        this._ctg_lv2_Name = value;
        this.Changed(nameof (ctg_lv2_Name));
      }
    }

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = value;
        this.Changed(nameof (ctg_ViewCode));
      }
    }

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = value;
        this.Changed(nameof (ctg_CategoryName));
      }
    }

    public int gdsh_DeliveryDiv
    {
      get => this._gdsh_DeliveryDiv;
      set
      {
        this._gdsh_DeliveryDiv = value;
        this.Changed(nameof (gdsh_DeliveryDiv));
      }
    }

    public string gdsh_DeliveryDivDesc => this.gdsh_DeliveryDiv <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo((long) this.gdsh_DeliveryDiv, EnumCommonCodeType.InnerDeliveryDiv, this.gdsh_DeliveryDiv);

    public double gdsh_MinOrderUnit
    {
      get => this._gdsh_MinOrderUnit;
      set
      {
        this._gdsh_MinOrderUnit = value;
        this.Changed(nameof (gdsh_MinOrderUnit));
      }
    }

    public string gdsh_MultiSuplierYn
    {
      get => this._gdsh_MultiSuplierYn;
      set
      {
        this._gdsh_MultiSuplierYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gdsh_MultiSuplierYn));
        this.Changed("gdsh_IsMultiSuplierYn");
        this.Changed("gdsh_MultiSuplierYnDesc");
      }
    }

    public bool gdsh_IsMultiSuplierYn => "Y".Equals(this.gdsh_MultiSuplierYn);

    public string gdsh_MultiSuplierYnDesc => !"Y".Equals(this.gdsh_MultiSuplierYn) ? "미사용" : "사용";

    public DateTime? gdsh_OrderEndDate
    {
      get => this._gdsh_OrderEndDate;
      set
      {
        this._gdsh_OrderEndDate = value;
        this.Changed(nameof (gdsh_OrderEndDate));
      }
    }

    public DateTime? gdsh_SaleEndDate
    {
      get => this._gdsh_SaleEndDate;
      set
      {
        this._gdsh_SaleEndDate = value;
        this.Changed(nameof (gdsh_SaleEndDate));
      }
    }

    public double pls_EndQty
    {
      get => this._pls_EndQty;
      set
      {
        this._pls_EndQty = value;
        this.Changed(nameof (pls_EndQty));
      }
    }

    public double pls_EndAvgCost
    {
      get => this._pls_EndAvgCost;
      set
      {
        this._pls_EndAvgCost = value;
        this.Changed(nameof (pls_EndAvgCost));
      }
    }

    public double pls_EndCostAmt
    {
      get => this._pls_EndCostAmt;
      set
      {
        this._pls_EndCostAmt = value;
        this.Changed(nameof (pls_EndCostAmt));
      }
    }

    public double pls_EndCostVatAmt
    {
      get => this._pls_EndCostVatAmt;
      set
      {
        this._pls_EndCostVatAmt = value;
        this.Changed(nameof (pls_EndCostVatAmt));
      }
    }

    public double pls_SaleQty
    {
      get => this._pls_SaleQty;
      set
      {
        this._pls_SaleQty = value;
        this.Changed(nameof (pls_SaleQty));
      }
    }

    public double pls_SaleAmt
    {
      get => this._pls_SaleAmt;
      set
      {
        this._pls_SaleAmt = value;
        this.Changed(nameof (pls_SaleAmt));
      }
    }

    public double pls_BuyQty
    {
      get => this._pls_BuyQty;
      set
      {
        this._pls_BuyQty = value;
        this.Changed(nameof (pls_BuyQty));
      }
    }

    public double pls_BuyCostAmt
    {
      get => this._pls_BuyCostAmt;
      set
      {
        this._pls_BuyCostAmt = value;
        this.Changed(nameof (pls_BuyCostAmt));
      }
    }

    public double pls_BuyCostVatAmt
    {
      get => this._pls_BuyCostVatAmt;
      set
      {
        this._pls_BuyCostVatAmt = value;
        this.Changed(nameof (pls_BuyCostVatAmt));
      }
    }

    public double pls_InnerMoveInQty
    {
      get => this._pls_InnerMoveInQty;
      set
      {
        this._pls_InnerMoveInQty = value;
        this.Changed(nameof (pls_InnerMoveInQty));
      }
    }

    public double pls_InnerMoveInCostAmt
    {
      get => this._pls_InnerMoveInCostAmt;
      set
      {
        this._pls_InnerMoveInCostAmt = value;
        this.Changed(nameof (pls_InnerMoveInCostAmt));
      }
    }

    public double pls_InnerMoveInCostVatAmt
    {
      get => this._pls_InnerMoveInCostVatAmt;
      set
      {
        this._pls_InnerMoveInCostVatAmt = value;
        this.Changed(nameof (pls_InnerMoveInCostVatAmt));
      }
    }

    public double pls_OuterMoveInQty
    {
      get => this._pls_OuterMoveInQty;
      set
      {
        this._pls_OuterMoveInQty = value;
        this.Changed(nameof (pls_OuterMoveInQty));
      }
    }

    public double pls_OuterMoveInCostAmt
    {
      get => this._pls_OuterMoveInCostAmt;
      set
      {
        this._pls_OuterMoveInCostAmt = value;
        this.Changed(nameof (pls_OuterMoveInCostAmt));
      }
    }

    public double pls_OuterMoveInCostVatAmt
    {
      get => this._pls_OuterMoveInCostVatAmt;
      set
      {
        this._pls_OuterMoveInCostVatAmt = value;
        this.Changed(nameof (pls_OuterMoveInCostVatAmt));
      }
    }

    public double gdp_StockConvQty
    {
      get => this._gdp_StockConvQty;
      set
      {
        this._gdp_StockConvQty = value;
        this.Changed(nameof (gdp_StockConvQty));
      }
    }

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    [JsonPropertyName("lt_BomTypePackSet")]
    public IList<GoodsPackBomTypeSet> Lt_BomTypePackSet
    {
      get => this._Lt_BomTypePackSet ?? (this._Lt_BomTypePackSet = (IList<GoodsPackBomTypeSet>) new List<GoodsPackBomTypeSet>());
      set
      {
        this._Lt_BomTypePackSet = value;
        this.Changed(nameof (Lt_BomTypePackSet));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<StatementDetailView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<StatementDetailView>) new List<StatementDetailView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.sh_StoreCode = this.sh_OrderStatus = this.sh_ConfirmStatus = this.sh_Supplier = this.sh_InOutDiv = this.sh_StatementType = 0;
      this.sh_ConfirmDate = new DateTime?();
      this.gdh_SupplierTypeOuterMoveIn = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = "N";
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_PreTaxDiv = this.su_MultiSuplierDiv = this.su_DeductionDayDiv = 0;
      this.su_NewStatementYn = "Y";
      this.gd_GoodsName = this.gd_BarCode = this.gd_GoodsSize = string.Empty;
      this.gd_TaxDiv = 0;
      this.gd_MakerCode = this.gd_BrandCode = 0;
      this.gd_BoxGoodsCode = 0L;
      this.gd_BoxPackQty = 0.0;
      this.gd_Deposit = 0;
      this.gd_SalesUnit = 0;
      this.gd_MinOrderUnit = 0.0;
      this.gd_StockUnit = 0;
      this.gd_StockConvQty = 0.0;
      this.gd_UseYn = "Y";
      DateTime? nullable = new DateTime?();
      this.gdh_EndDate = nullable;
      this.gdh_StartDate = nullable;
      this.gdh_GoodsCategory = this.gdh_Supplier = 0;
      this.gdh_ChargeRate = this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_SalePrice = 0.0;
      this.gdh_EventCost = this.gdh_EventVat = this.gdh_EventPrice = 0.0;
      this.dpt_lv1_ID = 0;
      this.dpt_lv1_ViewCode = this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ID = 0;
      this.dpt_lv2_ViewCode = this.dpt_lv2_Name = string.Empty;
      this.dpt_ID = 0;
      this.dpt_ViewCode = this.dpt_DeptName = string.Empty;
      this.ctg_lv1_ID = 0;
      this.ctg_lv1_ViewCode = this.ctg_lv1_Name = string.Empty;
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = this.ctg_lv2_Name = string.Empty;
      this.ctg_ViewCode = this.ctg_CategoryName = string.Empty;
      this.gdsh_DeliveryDiv = 0;
      this.gdsh_MinOrderUnit = 0.0;
      this.gdsh_MultiSuplierYn = "N";
      this.gdsh_OrderEndDate = new DateTime?();
      this.gdsh_SaleEndDate = new DateTime?();
      this.pls_EndQty = this.pls_EndAvgCost = this.pls_EndCostAmt = this.pls_EndCostVatAmt = 0.0;
      this.pls_SaleQty = this.pls_SaleAmt = 0.0;
      this.pls_BuyQty = this.pls_BuyCostAmt = this.pls_BuyCostVatAmt = 0.0;
      this.pls_InnerMoveInQty = this.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostVatAmt = 0.0;
      this.pls_OuterMoveInQty = this.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostVatAmt = 0.0;
      this.gdp_StockConvQty = 0.0;
      this.inEmpName = this.modEmpName = string.Empty;
      this.Lt_BomTypePackSet = (IList<GoodsPackBomTypeSet>) null;
      this.Lt_History = (IList<StatementDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StatementDetailView();

    public override object Clone()
    {
      StatementDetailView statementDetailView = base.Clone() as StatementDetailView;
      statementDetailView.sh_StoreCode = this.sh_StoreCode;
      statementDetailView.sh_OrderStatus = this.sh_OrderStatus;
      statementDetailView.sh_ConfirmStatus = this.sh_ConfirmStatus;
      statementDetailView.sh_Supplier = this.sh_Supplier;
      statementDetailView.sh_InOutDiv = this.sh_InOutDiv;
      statementDetailView.sh_StatementType = this.sh_StatementType;
      statementDetailView.sh_ConfirmDate = this.sh_ConfirmDate;
      statementDetailView.gdh_SupplierTypeOuterMoveIn = this.gdh_SupplierTypeOuterMoveIn;
      statementDetailView.si_StoreName = this.si_StoreName;
      statementDetailView.si_StoreViewCode = this.si_StoreViewCode;
      statementDetailView.si_UseYn = this.si_UseYn;
      statementDetailView.si_StoreType = this.si_StoreType;
      statementDetailView.si_LocationUseYn = this.si_LocationUseYn;
      statementDetailView.su_SupplierName = this.su_SupplierName;
      statementDetailView.su_SupplierViewCode = this.su_SupplierViewCode;
      statementDetailView.su_SupplierType = this.su_SupplierType;
      statementDetailView.su_SupplierKind = this.su_SupplierKind;
      statementDetailView.su_UseYn = this.su_UseYn;
      statementDetailView.su_PreTaxDiv = this.su_PreTaxDiv;
      statementDetailView.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      statementDetailView.su_DeductionDayDiv = this.su_DeductionDayDiv;
      statementDetailView.su_NewStatementYn = this.su_NewStatementYn;
      statementDetailView.gd_GoodsName = this.gd_GoodsName;
      statementDetailView.gd_BarCode = this.gd_BarCode;
      statementDetailView.gd_GoodsSize = this.gd_GoodsSize;
      statementDetailView.gd_TaxDiv = this.gd_TaxDiv;
      statementDetailView.gd_MakerCode = this.gd_MakerCode;
      statementDetailView.gd_BrandCode = this.gd_BrandCode;
      statementDetailView.gd_BoxGoodsCode = this.gd_BoxGoodsCode;
      statementDetailView.gd_BoxPackQty = this.gd_BoxPackQty;
      statementDetailView.gd_Deposit = this.gd_Deposit;
      statementDetailView.gd_SalesUnit = this.gd_SalesUnit;
      statementDetailView.gd_MinOrderUnit = this.gd_MinOrderUnit;
      statementDetailView.gd_StockUnit = this.gd_StockUnit;
      statementDetailView.gd_StockConvQty = this.gd_StockConvQty;
      statementDetailView.gd_UseYn = this.gd_UseYn;
      statementDetailView.gdh_StartDate = this.gdh_StartDate;
      statementDetailView.gdh_EndDate = this.gdh_EndDate;
      statementDetailView.gdh_GoodsCategory = this.gdh_GoodsCategory;
      statementDetailView.gdh_Supplier = this.gdh_Supplier;
      statementDetailView.gdh_ChargeRate = this.gdh_ChargeRate;
      statementDetailView.gdh_BuyCost = this.gdh_BuyCost;
      statementDetailView.gdh_BuyVat = this.gdh_BuyVat;
      statementDetailView.gdh_SalePrice = this.gdh_SalePrice;
      statementDetailView.gdh_EventCost = this.gdh_EventCost;
      statementDetailView.gdh_EventVat = this.gdh_EventVat;
      statementDetailView.gdh_EventPrice = this.gdh_EventPrice;
      statementDetailView.dpt_lv1_ID = this.dpt_lv1_ID;
      statementDetailView.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      statementDetailView.dpt_lv1_Name = this.dpt_lv1_Name;
      statementDetailView.dpt_lv2_ID = this.dpt_lv2_ID;
      statementDetailView.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      statementDetailView.dpt_lv2_Name = this.dpt_lv2_Name;
      statementDetailView.dpt_ID = this.dpt_ID;
      statementDetailView.dpt_ViewCode = this.dpt_ViewCode;
      statementDetailView.dpt_DeptName = this.dpt_DeptName;
      statementDetailView.ctg_lv1_ID = this.ctg_lv1_ID;
      statementDetailView.ctg_lv1_ViewCode = this.ctg_lv1_ViewCode;
      statementDetailView.ctg_lv1_Name = this.ctg_lv1_Name;
      statementDetailView.ctg_lv2_ID = this.ctg_lv2_ID;
      statementDetailView.ctg_lv2_ViewCode = this.ctg_lv2_ViewCode;
      statementDetailView.ctg_lv2_Name = this.ctg_lv2_Name;
      statementDetailView.ctg_ViewCode = this.ctg_ViewCode;
      statementDetailView.ctg_CategoryName = this.ctg_CategoryName;
      statementDetailView.gdsh_DeliveryDiv = this.gdsh_DeliveryDiv;
      statementDetailView.gdsh_MinOrderUnit = this.gdsh_MinOrderUnit;
      statementDetailView.gdsh_MultiSuplierYn = this.gdsh_MultiSuplierYn;
      statementDetailView.gdsh_OrderEndDate = this.gdsh_OrderEndDate;
      statementDetailView.gdsh_SaleEndDate = this.gdsh_SaleEndDate;
      statementDetailView.pls_EndQty = this.pls_EndQty;
      statementDetailView.pls_EndAvgCost = this.pls_EndAvgCost;
      statementDetailView.pls_EndCostAmt = this.pls_EndCostAmt;
      statementDetailView.pls_EndCostVatAmt = this.pls_EndCostVatAmt;
      statementDetailView.pls_SaleQty = this.pls_SaleQty;
      statementDetailView.pls_SaleAmt = this.pls_SaleAmt;
      statementDetailView.pls_BuyQty = this.pls_BuyQty;
      statementDetailView.pls_BuyCostAmt = this.pls_BuyCostAmt;
      statementDetailView.pls_BuyCostVatAmt = this.pls_BuyCostVatAmt;
      statementDetailView.pls_InnerMoveInQty = this.pls_InnerMoveInQty;
      statementDetailView.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostAmt;
      statementDetailView.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInCostVatAmt;
      statementDetailView.pls_OuterMoveInQty = this.pls_OuterMoveInQty;
      statementDetailView.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostAmt;
      statementDetailView.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInCostVatAmt;
      statementDetailView.gdp_StockConvQty = this.gdp_StockConvQty;
      statementDetailView.inEmpName = this.inEmpName;
      statementDetailView.modEmpName = this.modEmpName;
      statementDetailView.Lt_BomTypePackSet = this.Lt_BomTypePackSet;
      statementDetailView.Lt_History = this.Lt_History;
      return (object) statementDetailView;
    }

    public void PutData(StatementDetailView pSource)
    {
      this.PutData((TStatementDetail) pSource);
      this.sh_StoreCode = pSource.sh_StoreCode;
      this.sh_OrderStatus = pSource.sh_OrderStatus;
      this.sh_ConfirmStatus = pSource.sh_ConfirmStatus;
      this.sh_Supplier = pSource.sh_Supplier;
      this.sh_InOutDiv = pSource.sh_InOutDiv;
      this.sh_StatementType = pSource.sh_StatementType;
      this.sh_ConfirmDate = pSource.sh_ConfirmDate;
      this.gdh_SupplierTypeOuterMoveIn = pSource.gdh_SupplierTypeOuterMoveIn;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.su_DeductionDayDiv = pSource.su_DeductionDayDiv;
      this.su_NewStatementYn = pSource.su_NewStatementYn;
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
      this.gd_UseYn = pSource.gd_UseYn;
      this.gdh_StartDate = pSource.gdh_StartDate;
      this.gdh_EndDate = pSource.gdh_EndDate;
      this.gdh_GoodsCategory = pSource.gdh_GoodsCategory;
      this.gdh_Supplier = pSource.gdh_Supplier;
      this.gdh_ChargeRate = pSource.gdh_ChargeRate;
      this.gdh_BuyCost = pSource.gdh_BuyCost;
      this.gdh_BuyVat = pSource.gdh_BuyVat;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventCost = pSource.gdh_EventCost;
      this.gdh_EventVat = pSource.gdh_EventVat;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
      this.dpt_lv1_ID = pSource.dpt_lv1_ID;
      this.dpt_lv1_ViewCode = pSource.dpt_lv1_ViewCode;
      this.dpt_lv1_Name = pSource.dpt_lv1_Name;
      this.dpt_lv2_ID = pSource.dpt_lv2_ID;
      this.dpt_lv2_ViewCode = pSource.dpt_lv2_ViewCode;
      this.dpt_lv2_Name = pSource.dpt_lv2_Name;
      this.dpt_ID = pSource.dpt_ID;
      this.dpt_ViewCode = pSource.dpt_ViewCode;
      this.dpt_DeptName = pSource.dpt_DeptName;
      this.ctg_lv1_ID = pSource.ctg_lv1_ID;
      this.ctg_lv1_ViewCode = pSource.ctg_lv1_ViewCode;
      this.ctg_lv1_Name = pSource.ctg_lv1_Name;
      this.ctg_lv2_ID = pSource.ctg_lv2_ID;
      this.ctg_lv2_ViewCode = pSource.ctg_lv2_ViewCode;
      this.ctg_lv2_Name = pSource.ctg_lv2_Name;
      this.ctg_ViewCode = pSource.ctg_ViewCode;
      this.ctg_CategoryName = pSource.ctg_CategoryName;
      this.gdsh_DeliveryDiv = pSource.gdsh_DeliveryDiv;
      this.gdsh_MinOrderUnit = pSource.gdsh_MinOrderUnit;
      this.gdsh_MultiSuplierYn = pSource.gdsh_MultiSuplierYn;
      this.gdsh_OrderEndDate = pSource.gdsh_OrderEndDate;
      this.gdsh_SaleEndDate = pSource.gdsh_SaleEndDate;
      this.pls_EndQty = pSource.pls_EndQty;
      this.pls_EndAvgCost = pSource.pls_EndAvgCost;
      this.pls_EndCostAmt = pSource.pls_EndCostAmt;
      this.pls_EndCostVatAmt = pSource.pls_EndCostVatAmt;
      this.pls_SaleQty = pSource.pls_SaleQty;
      this.pls_SaleAmt = pSource.pls_SaleAmt;
      this.pls_BuyQty = pSource.pls_BuyQty;
      this.pls_BuyCostAmt = pSource.pls_BuyCostAmt;
      this.pls_BuyCostVatAmt = pSource.pls_BuyCostVatAmt;
      this.pls_InnerMoveInQty = pSource.pls_InnerMoveInQty;
      this.pls_InnerMoveInCostAmt = pSource.pls_InnerMoveInCostAmt;
      this.pls_InnerMoveInCostVatAmt = pSource.pls_InnerMoveInCostVatAmt;
      this.pls_OuterMoveInQty = pSource.pls_OuterMoveInQty;
      this.pls_OuterMoveInCostAmt = pSource.pls_OuterMoveInCostAmt;
      this.pls_OuterMoveInCostVatAmt = pSource.pls_OuterMoveInCostVatAmt;
      this.gdp_StockConvQty = pSource.gdp_StockConvQty;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_BomTypePackSet = (IList<GoodsPackBomTypeSet>) null;
      if (pSource.Lt_BomTypePackSet.Count > 0)
      {
        foreach (GoodsPackBomTypeSet ltBomTypePack in (IEnumerable<GoodsPackBomTypeSet>) pSource.Lt_BomTypePackSet)
        {
          GoodsPackBomTypeSet goodsPackBomTypeSet = new GoodsPackBomTypeSet();
          goodsPackBomTypeSet.PutData(ltBomTypePack);
          this.Lt_BomTypePackSet.Add(goodsPackBomTypeSet);
        }
      }
      this.Lt_History = (IList<StatementDetailView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (StatementDetailView pSource1 in (IEnumerable<StatementDetailView>) pSource.Lt_History)
      {
        StatementDetailView statementDetailView = new StatementDetailView();
        statementDetailView.PutData(pSource1);
        this.Lt_History.Add(statementDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.sd_SiteID == 0L)
      {
        this.message = "싸이트(sd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sd_StatementNo == 0L)
      {
        this.message = "전표 코드(sd_StatementNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToTaxDiv(this.sd_TaxDiv) == EnumTaxDiv.NONE)
      {
        this.message = "과면세(sd_TaxDiv) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToSalesUnit(this.sd_SalesUnit) == EnumSalesUnit.NONE)
      {
        this.message = "판매단위(sd_SalesUnit) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToStockUnit(this.sd_StockUnit) == EnumStockUnit.NONE)
      {
        this.message = "재고단위(sd_StockUnit) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToPackUnit(this.sd_PackUnit) != EnumPackUnit.NONE)
        return EnumDataCheck.Success;
      this.message = "묶음단위(sd_PackUnit) " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    public EnumDataCheck DataCheckOn(UniOleDatabase p_db) => this.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(sd_Seq), 0)+1 AS sd_Seq" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "sd_StatementNo", (object) this.sd_StatementNo);
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.sd_Seq = uniOleDbRecordset.GetFieldInt(0);
        return this.sd_Seq > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      StatementDetailView statementDetailView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView.CreateCodeQuery()))
        {
          statementDetailView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          statementDetailView.sd_Seq = rs.GetFieldInt(0);
        return statementDetailView.sd_Seq > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.sh_StoreCode = p_rs.GetFieldInt("sh_StoreCode");
      this.sh_OrderStatus = p_rs.GetFieldInt("sh_OrderStatus");
      this.sh_ConfirmDate = p_rs.GetFieldDateTime("sh_ConfirmDate");
      this.sh_ConfirmStatus = p_rs.GetFieldInt("sh_ConfirmStatus");
      this.sh_Supplier = p_rs.GetFieldInt("sh_Supplier");
      this.sh_InOutDiv = p_rs.GetFieldInt("sh_InOutDiv");
      this.sh_StatementType = p_rs.GetFieldInt("sh_StatementType");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
      this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
      this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
      this.su_DeductionDayDiv = p_rs.GetFieldInt("su_DeductionDayDiv");
      this.su_NewStatementYn = p_rs.GetFieldString("su_NewStatementYn");
      if (p_rs.IsFieldName("su_SupplierTypeOuterMoveIn"))
        this.su_SupplierTypeOuterMoveIn = p_rs.GetFieldInt("su_SupplierTypeOuterMoveIn");
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
      this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
      this.gdh_StartDate = p_rs.GetFieldDateTime("gdh_StartDate");
      this.gdh_EndDate = p_rs.GetFieldDateTime("gdh_EndDate");
      this.gdh_GoodsCategory = p_rs.GetFieldInt("gdh_GoodsCategory");
      this.gdh_Supplier = p_rs.GetFieldInt("gdh_Supplier");
      this.gdh_ChargeRate = p_rs.GetFieldDouble("gdh_ChargeRate");
      this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
      this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
      this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
      this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
      this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
      this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
      this.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.dpt_ID = p_rs.GetFieldInt("dpt_ID");
      this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
      this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
      this.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
      this.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
      this.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
      this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
      this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
      this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
      this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
      this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
      this.gdsh_DeliveryDiv = p_rs.GetFieldInt("gdsh_DeliveryDiv");
      this.gdsh_MinOrderUnit = p_rs.GetFieldDouble("gdsh_MinOrderUnit");
      this.gdsh_MultiSuplierYn = p_rs.GetFieldString("gdsh_MultiSuplierYn");
      this.gdsh_OrderEndDate = p_rs.GetFieldDateTime("gdsh_OrderEndDate");
      this.gdsh_SaleEndDate = p_rs.GetFieldDateTime("gdsh_SaleEndDate");
      this.pls_EndQty = p_rs.GetFieldDouble("pls_EndQty");
      this.pls_EndAvgCost = p_rs.GetFieldDouble("pls_EndAvgCost");
      this.pls_EndCostAmt = p_rs.GetFieldDouble("pls_EndCostAmt");
      this.pls_EndCostVatAmt = p_rs.GetFieldDouble("pls_EndCostVatAmt");
      this.pls_SaleQty = p_rs.GetFieldDouble("pls_SaleQty");
      this.pls_SaleAmt = p_rs.GetFieldDouble("pls_SaleAmt");
      this.pls_BuyQty = p_rs.GetFieldDouble("pls_BuyQty");
      this.pls_BuyCostAmt = p_rs.GetFieldDouble("pls_BuyCostAmt");
      this.pls_BuyCostVatAmt = p_rs.GetFieldDouble("pls_BuyCostVatAmt");
      this.pls_InnerMoveInQty = p_rs.GetFieldDouble("pls_InnerMoveInQty");
      this.pls_InnerMoveInCostAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostAmt");
      this.pls_InnerMoveInCostVatAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostVatAmt");
      this.pls_OuterMoveInQty = p_rs.GetFieldDouble("pls_OuterMoveInQty");
      this.pls_OuterMoveInCostAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostAmt");
      this.pls_OuterMoveInCostVatAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostVatAmt");
      this.gdp_StockConvQty = p_rs.GetFieldDouble("gdp_StockConvQty");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<StatementDetailView> SelectOneAsync(
      long p_sd_StatementNo,
      int p_sd_Seq,
      long p_sd_SiteID = 0)
    {
      StatementDetailView statementDetailView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sd_StatementNo",
          (object) p_sd_StatementNo
        },
        {
          (object) "sd_Seq",
          (object) p_sd_Seq
        }
      };
      if (p_sd_SiteID > 0L)
        p_param.Add((object) "sd_SiteID", (object) p_sd_SiteID);
      return await statementDetailView.SelectOneTAsync<StatementDetailView>((object) p_param);
    }

    public async Task<IList<StatementDetailView>> SelectListAsync(object p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.GetSelectQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDetailView>) null;
        }
        IList<StatementDetailView> lt_list = (IList<StatementDetailView>) new List<StatementDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDetailView> SelectEnumerableAsync(object p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.GetSelectQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = ++row_number;
              yield return statementDetailView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sd_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "sd_HistoryID", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num = 0;
        long p_SiteID = 0;
        bool pIsHeaderDefultTable = false;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(hashtable2[(object) "sd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "sd_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "StatementHeader_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "StatementHeader_DEFULT_TABLE_"].ToString()))
            pIsHeaderDefultTable = Convert.ToBoolean(hashtable2[(object) "StatementHeader_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeaderQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, pIsHeaderDefultTable));
        stringBuilder.Append(this.ToWithGoodsStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\nSELECT  sd_StatementNo,sd_Seq,sd_SiteID,sd_GoodsCode,sd_BoxCode,sd_BarCode,sd_CategoryCode,sd_TaxDiv,sd_SalesUnit,sd_StockUnit,sd_PackUnit,sd_LinkRowNCount,sd_CostGoods,sd_PriceGoods,sd_OrderQty,sd_BoxQty,sd_BuyQty,sd_CheckQty,sd_CostInput,sd_CostInputVat,sd_CostTaxAmt,sd_CostTaxFreeAmt,sd_CostVatAmt,sd_Deposit,sd_PriceTaxAmt,sd_PriceTaxFreeAmt,sd_PriceVatAmt,sd_ProfitAmt,sd_EventYn,sd_Native,sd_HistoryID,sd_Memo,sd_MobieSeq,sd_InDate,sd_InUser,sd_ModDate,sd_ModUser\n,sh_StoreCode,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_InOutDiv,sh_StatementType\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON sd_StatementNo=sh_StatementNo AND sd_SiteID=sh_SiteID\nINNER JOIN T_STORE ON sh_StoreCode=si_StoreCode AND sh_SiteID=si_SiteID\nLEFT OUTER JOIN T_GOODS ON sd_BoxCode=gd_GoodsCode AND sd_SiteID=gd_SiteID\nLEFT OUTER JOIN T_GOOD_CODE ON sd_BoxCode=gdp_GoodsCode\nLEFT OUTER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND sd_BoxCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND su_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON sh_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND sd_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON sh_StoreCode=pls_StoreCode AND sd_BoxCode=pls_GoodsCode AND sd_SiteID=pls_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON sd_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON sd_ModUser=emp_CodeMod");
        if (!pIsHeaderDefultTable && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (pIsHeaderDefultTable)
          stringBuilder.Append("\nORDER BY sd_StatementNo,sd_Seq");
        else if (num <= 0)
        {
          if (!string.IsNullOrEmpty(empty))
            stringBuilder.Append("\nORDER BY " + empty);
          else
            stringBuilder.Append("\nORDER BY sd_StatementNo,sd_Seq");
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
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

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
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
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
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement,su_DeductionDayDiv,su_NewStatementYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
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

    public string ToWithEmployeeInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeModQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithHeaderQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool pIsHeaderDefultTable)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HEADER AS ( SELECT sh_StatementNo,sh_SiteID,sh_StoreCode,sh_OrderDate,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_SupplierType,sh_InOutDiv,sh_StatementType,sh_ReasonCode,sh_MobieStatementNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()));
        if (pIsHeaderDefultTable)
        {
          stringBuilder.Append(new StatementHeaderView().GetSelectWhereAnd(p_param));
        }
        else
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
              p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sd_StatementNo"))
              p_param1.Add((object) "sh_StatementNo", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_StatementNo"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_StatementType"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_StatementType_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_IsStatementPayment_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_OrderDate"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_OrderDate_BEGIN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_OrderDate_END_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate_BEGIN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate_END_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_IsStatementOrder_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmStatus"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_InOutDiv"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_Supplier"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("su_SupplierType_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_ReasonCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_DeviceType"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("sh_AssignUser"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("emp_Code"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            stringBuilder.Append(new StatementHeaderView().GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsStatementQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_STATEMENT AS ( SELECT sd_BoxCode AS gse_sd_BoxCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + string.Format(" INNER JOIN T_HEADER ON {0}={1} AND {2}={3}", (object) "sh_StatementNo", (object) this.sd_StatementNo, (object) "sh_SiteID", (object) this.sd_SiteID));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sd_StatementNo"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StatementNo"))
            p_param1.Add((object) "sd_StatementNo", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sd_SiteID"))
            p_param1.Add((object) "sd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new StatementHeaderView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sd_SiteID", (object) p_SiteID));
        stringBuilder.Append(" GROUP BY sd_BoxCode");
        stringBuilder.Append(")");
      }
      finally
      {
        if (p_param1.Count > 0)
          p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsCodeQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_StockConvQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}!={1}", (object) "gd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_STATEMENT ON gdp_GoodsCode=gse_sd_BoxCode" + string.Format("\nWHERE {0}={1}", (object) "gdp_SiteID", (object) p_SiteID) + " AND gdp_StockConvQty > 0\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_STATEMENT ON gd_GoodsCode=gse_sd_BoxCode" + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1) + "\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_STATEMENT ON gd_GoodsCode=gse_sd_BoxCode" + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4) + ")");
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
        stringBuilder.Append("\n,T_GOODS AS (\nSELECT  gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_CODE ON gdp_GoodsCode=gd_GoodsCode");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsHistoryQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_ChargeRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_GOODS ON gd_GoodsCode=gdh_GoodsCode AND gd_SiteID=gdh_SiteID\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sd_GoodsCode"))
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

    public string ToWithStoreGoodsQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STORE_GOODS AS (\nSELECT gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_StorageStockQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsStoreInfo, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOODS ON gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sd_GoodsCode"))
            p_param1.Add((object) "gdsh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add((object) "gdsh_GoodsCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdsh_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TGoodsStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdsh_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPlsQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append(",T_PLS AS (\nSELECT pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,pls_EndQty/gdp_StockConvQty AS pls_EndQty,pls_EndAvgCost,pls_EndCostAmt/gdp_StockConvQty AS pls_EndCostAmt,pls_EndCostVatAmt/gdp_StockConvQty AS pls_EndCostVatAmt,pls_SaleQty/gdp_StockConvQty AS pls_SaleQty,pls_SaleAmt/gdp_StockConvQty AS pls_SaleAmt,pls_BuyQty/gdp_StockConvQty AS pls_BuyQty,pls_BuyCostAmt/gdp_StockConvQty AS pls_BuyCostAmt,pls_BuyCostVatAmt/gdp_StockConvQty AS pls_BuyCostVatAmt,pls_InnerMoveInQty/gdp_StockConvQty AS pls_InnerMoveInQty,pls_InnerMoveInCostAmt/gdp_StockConvQty AS pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt/gdp_StockConvQty AS pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty/gdp_StockConvQty AS pls_OuterMoveInQty,pls_OuterMoveInCostAmt/gdp_StockConvQty AS pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt/gdp_StockConvQty AS pls_OuterMoveInCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_HEADER ON sh_StoreCode=pls_StoreCode AND pls_YyyyMm=" + "sh_ConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + string.Format(" AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID) + "\n INNER JOIN T_GOOD_CODE ON gdp_SubGoodsCode=pls_GoodsCode) ");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithInventorySummaryQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID,
      EnumStockUnit p_StockUnit)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_INVENTORY_SUMMARY AS (\n SELECT ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        if (p_StockUnit == EnumStockUnit.AMOUNT)
          stringBuilder.Append(",SUM(ivts_InventoryQty) AS ivts_InventoryQty,SUM(ivts_InventoryCostAmt) AS ivts_InventoryCostAmt,SUM(ivts_InventoryCostVatAmt) AS ivts_InventoryCostVatAmt,SUM(ivts_InventoryPriceAmt) AS ivts_InventoryPriceAmt,SUM(ivts_InventoryPriceVatAmt) AS ivts_InventoryPriceVatAmt");
        else
          stringBuilder.Append(",SUM(ivts_AdjustQty) AS ivts_AdjustQty,SUM(ivts_AdjustCostAmt) AS ivts_AdjustCostAmt,SUM(ivts_AdjustCostVatAmt) AS ivts_AdjustCostVatAmt,SUM(ivts_AdjustPriceAmt) AS ivts_AdjustPriceAmt,SUM(ivts_AdjustPriceVatAmt) AS ivts_AdjustPriceVatAmt");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.InventorySummary, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "ivts_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate"))
            p_param1.Add((object) "_DT_DATE_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "ivts_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "ivts_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "ivts_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "ivts_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "ivts_SiteID"))
            p_param1.Add((object) "ivts_SiteID", (object) p_SiteID);
          if (p_StockUnit > EnumStockUnit.NONE)
            p_param1.Add((object) "ivts_StockUnit", (object) (int) p_StockUnit);
          p_param1.Add((object) "ivts_AdjustQty_IS_NOT_DATA_VALUE_ZERO_", (object) true);
          stringBuilder.Append(new TInventorySummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ivts_SiteID", (object) 0));
          if (p_StockUnit > EnumStockUnit.NONE)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StockUnit", (object) (int) p_StockUnit));
        }
        stringBuilder.Append("\nGROUP BY ivts_StoreCode,ivts_GoodsCode,ivts_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsHistoryByInventorySummaryQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_ChargeRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_INVENTORY_SUMMARY ON ivts_StoreCode=gdh_StoreCode AND ivts_GoodsCode=gdh_GoodsCode AND ivts_SiteID=gdh_SiteID\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate"))
            p_param1.Add((object) "_DT_DATE_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TGoodsHistory().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ivts_SiteID", (object) 0));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public virtual void CalcSum(bool p_is_order = false)
    {
      double num = p_is_order ? this.sd_OrderQty : this.sd_BoxQty;
      if (this.sd_IsTax)
      {
        this.sd_CostTaxFreeAmt = 0.0;
        this.sd_PriceTaxFreeAmt = 0.0;
        this.sd_CostTaxAmt = CalcHelper.CalcDoubleToFormatDouble(num * this.sd_CostInput);
        this.sd_CostVatAmt = num * this.sd_CostInputPrice - this.sd_CostTaxAmt;
        this.sd_PriceVatAmt = (num * this.sd_PriceGoods).ToPriceVat();
        this.sd_PriceTaxAmt = num * this.sd_PriceGoods - this.sd_PriceVatAmt;
      }
      else
      {
        this.sd_CostTaxAmt = 0.0;
        this.sd_CostVatAmt = 0.0;
        this.sd_PriceTaxAmt = 0.0;
        this.sd_PriceVatAmt = 0.0;
        this.sd_CostTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(num * this.sd_CostInput);
        this.sd_PriceTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(num * this.sd_PriceGoods);
      }
      this.sd_Deposit = num * (double) this.gd_Deposit;
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.sd_SiteID == 0L)
            this.sd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sd_Seq == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      StatementDetailView statementDetailView = this;
      try
      {
        statementDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementDetailView.DataCheck(p_db))
            throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (statementDetailView.sd_SiteID == 0L)
            statementDetailView.sd_SiteID = p_app_employee.emp_SiteID;
          if (!statementDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (statementDetailView.sd_Seq == 0)
        {
          if (!await statementDetailView.CreateCodeAsync(p_db))
            throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await statementDetailView.InsertAsync())
          throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 등록 오류");
        statementDetailView.db_status = 4;
        statementDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementDetailView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.sd_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순서(sd_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      StatementDetailView statementDetailView = this;
      try
      {
        statementDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementDetailView.DataCheck(p_db))
            throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!statementDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (statementDetailView.sd_Seq == 0)
          throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 순서(sd_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await statementDetailView.UpdateAsync())
          throw new UniServiceException(statementDetailView.message, statementDetailView.TableCode.ToDescription() + " 변경 오류");
        statementDetailView.db_status = 4;
        statementDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementDetailView.message = ex.Message;
      }
      return false;
    }

    public string AdjustAmountQuery(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        long p_SiteID = 0;
        DateTime? p_day = new DateTime?();
        if (p_param.ContainsKey((object) "DBMS") && p_param[(object) "DBMS"].ToString().Length > 0)
          uniBase = p_param[(object) "DBMS"].ToString();
        if (p_param.ContainsKey((object) "table") && p_param[(object) "table"].ToString().Length > 0)
          p_param[(object) "table"].ToString();
        if (p_param.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString()) > 0L)
          p_SiteID = Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString());
        if (p_param.ContainsKey((object) "sh_StoreCode") && Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString()) > 0)
          Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString());
        if (p_param.ContainsKey((object) "sh_ConfirmDate"))
          p_day = new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]);
        stringBuilder.Append(this.ToWithStoreQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithInventorySummaryQuery(p_param, uniBase, p_SiteID, EnumStockUnit.AMOUNT));
        stringBuilder.Append(this.ToWithGoodsHistoryByInventorySummaryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\nSELECT  1 AS sd_StatementNo,0 AS sd_Seq,si_SiteID AS sd_SiteID,gd_GoodsCode AS sd_GoodsCode,gd_GoodsCode AS sd_BoxCode,gd_BarCode AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,gdh_BuyCost AS sd_CostGoods,ivts_InventoryPriceAmt/ivts_InventoryQty AS sd_PriceGoods,0 AS sd_OrderQty,ivts_InventoryQty AS sd_BoxQty,ivts_InventoryQty AS sd_BuyQty,0 AS sd_CheckQty,ivts_InventoryCostAmt/ivts_InventoryQty AS sd_CostInput,ivts_InventoryCostVatAmt/ivts_InventoryQty AS sd_CostInputVat" + string.Format(",CASE {0} WHEN {1} THEN {2} ELSE 0 END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_InventoryCostAmt", (object) "sd_CostTaxAmt") + string.Format(",CASE {0} WHEN {1} THEN 0 ELSE {2} END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_InventoryCostAmt", (object) "sd_CostTaxFreeAmt") + ",ivts_InventoryCostVatAmt AS sd_CostVatAmt,0 AS sd_Deposit" + string.Format(",CASE {0} WHEN {1} THEN {2}-{3} ELSE 0 END AS {4}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_InventoryPriceAmt", (object) "ivts_InventoryPriceVatAmt", (object) "sd_PriceTaxAmt") + string.Format(",CASE {0} WHEN {1} THEN 0 ELSE {2} END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_InventoryPriceAmt", (object) "sd_PriceTaxFreeAmt") + ",ivts_InventoryPriceVatAmt AS sd_PriceVatAmt,0 AS sd_ProfitAmt,'N' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser\n,si_StoreCode AS sh_StoreCode,0 AS sh_OrderStatus,NULL AS sh_ConfirmDate,0 AS sh_ConfirmStatus,0 AS sh_Supplier" + string.Format(",0 AS {0},{1} AS {2}", (object) "sh_InOutDiv", (object) 5, (object) "sh_StatementType") + "\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,1 AS gdsh_DeliveryDiv,0 AS gdsh_MinOrderUnit,'Y' AS gdsh_MultiSuplierYn,NULL AS gdsh_OrderEndDate,NULL AS gdsh_SaleEndDate\n,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_SaleQty,0 AS pls_SaleAmt,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt\n,1 AS gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID\nINNER JOIN T_INVENTORY_SUMMARY ON si_StoreCode=ivts_StoreCode AND gd_GoodsCode=ivts_GoodsCode AND gd_SiteID=ivts_SiteID AND ivts_InventoryQty != 0\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID");
        stringBuilder.Append("\n");
        stringBuilder.Append("ORDER BY gd_BarCode,gd_GoodsCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<IList<StatementDetailView>> AdjustAmountSelectListAsync(Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.AdjustAmountQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDetailView>) null;
        }
        IList<StatementDetailView> lt_list = (IList<StatementDetailView>) new List<StatementDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDetailView> AdjustAmountSelectEnumerableAsync(
      Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.AdjustAmountQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = ++row_number;
              yield return statementDetailView2;
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

    public string AdjustQtyQuery(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        long p_SiteID = 0;
        DateTime? p_day = new DateTime?();
        if (p_param.ContainsKey((object) "DBMS") && p_param[(object) "DBMS"].ToString().Length > 0)
          uniBase = p_param[(object) "DBMS"].ToString();
        if (p_param.ContainsKey((object) "table") && p_param[(object) "table"].ToString().Length > 0)
          p_param[(object) "table"].ToString();
        if (p_param.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString()) > 0L)
          p_SiteID = Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString());
        if (p_param.ContainsKey((object) "sh_StoreCode") && Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString()) > 0)
          Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString());
        if (p_param.ContainsKey((object) "sh_ConfirmDate"))
          p_day = new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]);
        stringBuilder.Append(this.ToWithStoreQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithInventorySummaryQuery(p_param, uniBase, p_SiteID, EnumStockUnit.QTY));
        stringBuilder.Append(this.ToWithGoodsHistoryByInventorySummaryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\nSELECT  1 AS sd_StatementNo,0 AS sd_Seq,si_SiteID AS sd_SiteID,gd_GoodsCode AS sd_GoodsCode,gd_GoodsCode AS sd_BoxCode,gd_BarCode AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,gdh_BuyCost AS sd_CostGoods,gdh_SalePrice AS sd_PriceGoods,0 AS sd_OrderQty,ivts_AdjustQty AS sd_BoxQty,ivts_AdjustQty AS sd_BuyQty,0 AS sd_CheckQty,ivts_AdjustCostAmt/ivts_AdjustQty AS sd_CostInput,ivts_AdjustCostVatAmt/ivts_AdjustQty AS sd_CostInputVat" + string.Format(",CASE {0} WHEN {1} THEN {2} ELSE 0 END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_AdjustCostAmt", (object) "sd_CostTaxAmt") + string.Format(",CASE {0} WHEN {1} THEN 0 ELSE {2} END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_AdjustCostAmt", (object) "sd_CostTaxFreeAmt") + ",ivts_AdjustCostVatAmt AS sd_CostVatAmt,0 AS sd_Deposit" + string.Format(",CASE {0} WHEN {1} THEN {2} ELSE 0 END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_AdjustPriceAmt", (object) "sd_PriceTaxAmt") + string.Format(",CASE {0} WHEN {1} THEN 0 ELSE {2} END AS {3}", (object) "gd_TaxDiv", (object) 1, (object) "ivts_AdjustPriceAmt", (object) "sd_PriceTaxFreeAmt") + ",ivts_AdjustPriceVatAmt AS sd_PriceVatAmt,0 AS sd_ProfitAmt,'N' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser\n,si_StoreCode AS sh_StoreCode,0 AS sh_OrderStatus,NULL AS sh_ConfirmDate,0 AS sh_ConfirmStatus,0 AS sh_Supplier" + string.Format(",0 AS {0},{1} AS {2}", (object) "sh_InOutDiv", (object) 5, (object) "sh_StatementType") + "\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,1 AS gdsh_DeliveryDiv,0 AS gdsh_MinOrderUnit,'Y' AS gdsh_MultiSuplierYn,NULL AS gdsh_OrderEndDate,NULL AS gdsh_SaleEndDate\n,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_SaleQty,0 AS pls_SaleAmt,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt\n,1 AS gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID\nINNER JOIN T_INVENTORY_SUMMARY ON si_StoreCode=ivts_StoreCode AND gd_GoodsCode=ivts_GoodsCode AND gd_SiteID=ivts_SiteID AND ivts_AdjustQty != 0\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID");
        stringBuilder.Append("\n");
        stringBuilder.Append("ORDER BY gd_BarCode,gd_GoodsCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<IList<StatementDetailView>> AdjustQtySelectListAsync(Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.AdjustQtyQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDetailView>) null;
        }
        IList<StatementDetailView> lt_list = (IList<StatementDetailView>) new List<StatementDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDetailView> AdjustQtySelectEnumerableAsync(
      Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.AdjustQtyQuery(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = ++row_number;
              yield return statementDetailView2;
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

    public string QueryGoods(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        long p_SiteID = 0;
        int p_pls_StoreCode = 0;
        DateTime? p_day = new DateTime?();
        string p_sd_BarCode = (string) null;
        long p_sd_BoxCode = 0;
        if (p_param.ContainsKey((object) "DBMS") && p_param[(object) "DBMS"].ToString().Length > 0)
          uniBase = p_param[(object) "DBMS"].ToString();
        if (p_param.ContainsKey((object) "table") && p_param[(object) "table"].ToString().Length > 0)
          p_param[(object) "table"].ToString();
        if (p_param.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString()) > 0L)
          p_SiteID = Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString());
        if (p_param.ContainsKey((object) "sh_StoreCode") && Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString()) > 0)
          p_pls_StoreCode = Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString());
        if (p_param.ContainsKey((object) "sh_Supplier") && Convert.ToInt32(p_param[(object) "sh_Supplier"].ToString()) > 0)
          Convert.ToInt32(p_param[(object) "sh_Supplier"].ToString());
        if (p_param.ContainsKey((object) "sh_ConfirmDate"))
          p_day = new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]);
        if (p_param.ContainsKey((object) "sd_BarCode") && !string.IsNullOrEmpty(p_param[(object) "sd_BarCode"]?.ToString()))
          p_sd_BarCode = p_param[(object) "sd_BarCode"].ToString();
        if (p_param.ContainsKey((object) "sd_BoxCode") && Convert.ToInt64(p_param[(object) "sd_BoxCode"].ToString()) > 0L)
          p_sd_BoxCode = Convert.ToInt64(p_param[(object) "sd_BoxCode"].ToString());
        if (!p_day.HasValue)
        {
          Exception exception1 = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery((object) p_param, uniBase, p_SiteID));
        if (p_sd_BoxCode > 0L)
          stringBuilder.Append(this.ToWithGoodsSearchBoxBarcodeQuery(p_sd_BoxCode, uniBase, p_SiteID));
        else if (!string.IsNullOrEmpty(p_sd_BarCode))
        {
          stringBuilder.Append(this.ToWithGoodsSearchBarcodeQuery(p_sd_BarCode, uniBase, p_SiteID));
        }
        else
        {
          Exception exception2 = new Exception("상품 정보 부족");
        }
        stringBuilder.Append(this.ToWithGoodsSearchHistoryQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsSearchQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeSearchQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsSearchQuery(Convert.ToInt32(new DateTime?(p_day.Value).GetDateToStr("yyyyMM")), p_pls_StoreCode, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n\nSELECT  1 AS sd_StatementNo,0 AS sd_Seq,gd_SiteID AS sd_SiteID,gdp_SubGoodsCode AS sd_GoodsCode,gd_GoodsCode AS sd_BoxCode," + (p_sd_BoxCode > 0L ? "gd_BarCode" : "'" + p_sd_BarCode + "'") + " AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,gdh_BuyCost AS sd_CostGoods,gdh_SalePrice AS sd_PriceGoods,0 AS sd_OrderQty,0 AS sd_BoxQty,0 AS sd_BuyQty,0 AS sd_CheckQty,gdh_BuyCost AS sd_CostInput,gdh_BuyVat AS sd_CostInputVat,0 AS sd_CostTaxAmt,0 AS sd_CostTaxFreeAmt,0 AS sd_CostVatAmt,0 AS sd_Deposit,0 AS sd_PriceTaxAmt,0 AS sd_PriceTaxFreeAmt,0 AS sd_PriceVatAmt,0 AS sd_ProfitAmt,'N' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser\n,si_StoreCode AS sh_StoreCode,0 AS sh_OrderStatus,NULL AS sh_ConfirmDate,0 AS sh_ConfirmStatus,0 AS sh_Supplier,0 AS sh_InOutDiv,0 AS sh_StatementType\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gd_GoodsCode AND gdob_SiteID=gd_SiteID\nINNER JOIN T_GOOD_CODE ON gd_GoodsCode=gdp_GoodsCode\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON si_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON si_StoreCode=pls_StoreCode AND gdp_SubGoodsCode=pls_GoodsCode AND gd_SiteID=pls_SiteID");
        if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\nORDER BY gd_BarCode,gd_GoodsCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<IList<StatementDetailView>> SelectGoodsListAsync(Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.QueryGoods(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDetailView>) null;
        }
        IList<StatementDetailView> lt_list = (IList<StatementDetailView>) new List<StatementDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDetailView> SelectGoodsEnumerableAsync(Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.QueryGoods(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = ++row_number;
              yield return statementDetailView2;
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

    public string QueryGoodsOuterMove(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        long p_SiteID = 0;
        int p_pls_StoreCode = 0;
        int num = 0;
        DateTime? p_day = new DateTime?();
        string p_sd_BarCode = (string) null;
        long p_sd_BoxCode = 0;
        if (p_param.ContainsKey((object) "DBMS") && p_param[(object) "DBMS"].ToString().Length > 0)
          uniBase = p_param[(object) "DBMS"].ToString();
        if (p_param.ContainsKey((object) "table") && p_param[(object) "table"].ToString().Length > 0)
          p_param[(object) "table"].ToString();
        if (p_param.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString()) > 0L)
          p_SiteID = Convert.ToInt64(p_param[(object) "sd_SiteID"].ToString());
        if (p_param.ContainsKey((object) "sh_StoreCode") && Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString()) > 0)
          p_pls_StoreCode = Convert.ToInt32(p_param[(object) "sh_StoreCode"].ToString());
        if (p_param.ContainsKey((object) "sh_Supplier") && Convert.ToInt32(p_param[(object) "sh_Supplier"].ToString()) > 0)
          num = Convert.ToInt32(p_param[(object) "sh_Supplier"].ToString());
        if (p_param.ContainsKey((object) "sh_ConfirmDate"))
          p_day = new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]);
        if (p_param.ContainsKey((object) "sd_BarCode") && !string.IsNullOrEmpty(p_param[(object) "sd_BarCode"]?.ToString()))
          p_sd_BarCode = p_param[(object) "sd_BarCode"].ToString();
        if (p_param.ContainsKey((object) "sd_BoxCode") && Convert.ToInt64(p_param[(object) "sd_BoxCode"].ToString()) > 0L)
          p_sd_BoxCode = Convert.ToInt64(p_param[(object) "sd_BoxCode"].ToString());
        if (p_pls_StoreCode == 0 || num == 0)
        {
          Exception exception1 = new Exception("지점 정보 부족");
        }
        if (!p_day.HasValue)
        {
          Exception exception2 = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsLinkSupplierTypeQuery(uniBase, p_SiteID));
        if (p_sd_BoxCode > 0L)
          stringBuilder.Append(this.ToWithGoodsSearchBoxBarcodeQuery(p_sd_BoxCode, uniBase, p_SiteID));
        else if (!string.IsNullOrEmpty(p_sd_BarCode))
        {
          stringBuilder.Append(this.ToWithGoodsSearchBarcodeQuery(p_sd_BarCode, uniBase, p_SiteID));
        }
        else
        {
          Exception exception3 = new Exception("상품 정보 부족");
        }
        stringBuilder.Append(this.ToWithGoodsSearchHistoryQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsSearchHistoryInStorePriceQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsSearchQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeSearchQuery((object) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsSearchQuery(Convert.ToInt32(new DateTime?(p_day.Value).GetDateToStr("yyyyMM")), p_pls_StoreCode, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n\nSELECT  1 AS sd_StatementNo,0 AS sd_Seq,gd_SiteID AS sd_SiteID,gdp_SubGoodsCode AS sd_GoodsCode,gd_GoodsCode AS sd_BoxCode," + (p_sd_BoxCode > 0L ? "gd_BarCode" : "'" + p_sd_BarCode + "'") + " AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,price_gdh_BuyCost AS sd_CostGoods,price_gdh_SalePrice AS sd_PriceGoods,0 AS sd_OrderQty,0 AS sd_BoxQty,0 AS sd_BuyQty,0 AS sd_CheckQty,price_gdh_BuyCost AS sd_CostInput,price_gdh_BuyVat AS sd_CostInputVat,0 AS sd_CostTaxAmt,0 AS sd_CostTaxFreeAmt,0 AS sd_CostVatAmt,0 AS sd_Deposit,0 AS sd_PriceTaxAmt,0 AS sd_PriceTaxFreeAmt,0 AS sd_PriceVatAmt,0 AS sd_ProfitAmt,'N' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser\n,si_StoreCode AS sh_StoreCode,0 AS sh_OrderStatus,NULL AS sh_ConfirmDate,0 AS sh_ConfirmStatus,0 AS sh_Supplier,0 AS sh_InOutDiv,0 AS sh_StatementType\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,price_su_SupplierType AS su_SupplierTypeOuterMoveIn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gd_GoodsCode AND gdob_SiteID=gd_SiteID\nINNER JOIN T_GOOD_CODE ON gd_GoodsCode=gdp_GoodsCode\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'\nINNER JOIN T_HISTORY_IN_STORE_PRICE ON  gd_GoodsCode=price_gdh_GoodsCode AND price_gdh_StartDate<='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND price_gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON si_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON si_StoreCode=pls_StoreCode AND gdp_SubGoodsCode=pls_GoodsCode AND gd_SiteID=pls_SiteID");
        if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\nORDER BY gd_BarCode,gd_GoodsCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<IList<StatementDetailView>> SelectGoodsOuterMoveListAsync(Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.QueryGoodsOuterMove(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDetailView>) null;
        }
        IList<StatementDetailView> lt_list = (IList<StatementDetailView>) new List<StatementDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDetailView> SelectGoodsOuterMoveEnumerableAsync(
      Hashtable p_param)
    {
      StatementDetailView statementDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementDetailView1.QueryGoodsOuterMove(p_param)))
        {
          statementDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDetailView statementDetailView2 = statementDetailView1.OleDB.Create<StatementDetailView>();
            if (statementDetailView2.GetFieldValues(rs))
            {
              statementDetailView2.row_number = ++row_number;
              yield return statementDetailView2;
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

    public string ToWithGoodsSearchBoxBarcodeQuery(long p_sd_BoxCode, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\n,T_BARCODE AS (\nSELECT gd_GoodsCode AS gdob_GoodsCode,gd_BarCode AS gdob_BarCode,gd_SiteID AS gdob_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gd_GoodsCode", (object) p_sd_BoxCode) + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + ")");
      return stringBuilder.ToString();
    }

    public string ToWithGoodsSearchBarcodeQuery(string p_sd_BarCode, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\n,T_BARCODE AS (\nSELECT gdob_GoodsCode,gdob_BarCode,gdob_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + "\nWHERE gdob_BarCode='" + p_sd_BarCode + "'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_SiteID) + "\nUNION ALL\nSELECT gd_GoodsCode AS gdob_GoodsCode,gd_BarCode AS gdob_BarCode,gd_SiteID AS gdob_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + " AND gd_BarCode='" + p_sd_BarCode + "')");
      return stringBuilder.ToString();
    }

    public string ToWithGoodsSearchHistoryQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_ChargeRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gdh_GoodsCode AND gdob_SiteID=gdh_SiteID\nINNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate"))
            p_param1.Add((object) "_DT_DATE_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
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

    public string ToWithGoodsSearchHistoryInStorePriceQuery(
      object p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY_IN_STORE_PRICE AS (\nSELECT gdh_StoreCode AS price_gdh_StoreCode,gdh_GoodsCode AS price_gdh_GoodsCode,gdh_StartDate AS price_gdh_StartDate,gdh_EndDate AS price_gdh_EndDate,gdh_SiteID AS price_gdh_SiteID,gdh_BuyCost AS price_gdh_BuyCost,gdh_BuyVat AS price_gdh_BuyVat,gdh_SalePrice AS price_gdh_SalePrice,gdh_EventCost AS price_gdh_EventCost,gdh_EventVat AS price_gdh_EventVat,gdh_EventPrice AS price_gdh_EventPrice,gdh_ChargeRate AS price_gdh_ChargeRate\n,su_SupplierType AS price_su_SupplierType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gdh_GoodsCode AND gdob_SiteID=gdh_SiteID\nINNER JOIN T_STORE_GOODS_SUPPTYPE ON gdh_Supplier=su_Supplier AND gdh_SiteID=su_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_Supplier"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_ConfirmDate"))
            p_param1.Add((object) "_DT_DATE_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
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

    public string ToWithStoreGoodsSearchQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STORE_GOODS AS (\nSELECT gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_StorageStockQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsStoreInfo, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gdsh_GoodsCode AND gdob_SiteID=gdsh_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sd_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdsh_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TGoodsStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdsh_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsCodeSearchQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_StockConvQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gdp_GoodsCode AND gdob_SiteID=gdp_SiteID" + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}!={1}", (object) "gd_PackUnit", (object) 4) + string.Format("\nWHERE {0}={1}", (object) "gdp_SiteID", (object) p_SiteID) + " AND gdp_StockConvQty > 0\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gd_GoodsCode AND gdob_SiteID=gd_SiteID" + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1) + "\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_BARCODE ON gdob_GoodsCode=gd_GoodsCode AND gdob_SiteID=gd_SiteID" + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4) + ")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPlsSearchQuery(
      int p_pls_YyyyMm,
      int p_pls_StoreCode,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append(",T_PLS AS (\nSELECT pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,pls_EndQty/gdp_StockConvQty AS pls_EndQty,pls_EndAvgCost,pls_EndCostAmt/gdp_StockConvQty AS pls_EndCostAmt,pls_EndCostVatAmt/gdp_StockConvQty AS pls_EndCostVatAmt,pls_SaleQty/gdp_StockConvQty AS pls_SaleQty,pls_SaleAmt/gdp_StockConvQty AS pls_SaleAmt,pls_BuyQty/gdp_StockConvQty AS pls_BuyQty,pls_BuyCostAmt/gdp_StockConvQty AS pls_BuyCostAmt,pls_BuyCostVatAmt/gdp_StockConvQty AS pls_BuyCostVatAmt,pls_InnerMoveInQty/gdp_StockConvQty AS pls_InnerMoveInQty,pls_InnerMoveInCostAmt/gdp_StockConvQty AS pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt/gdp_StockConvQty AS pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty/gdp_StockConvQty AS pls_OuterMoveInQty,pls_OuterMoveInCostAmt/gdp_StockConvQty AS pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt/gdp_StockConvQty AS pls_OuterMoveInCostVatAmt" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_CODE ON gdp_SubGoodsCode=pls_GoodsCode" + string.Format("\nWHERE {0}={1}", (object) "pls_YyyyMm", (object) p_pls_YyyyMm) + string.Format(" AND {0}={1}", (object) "pls_StoreCode", (object) p_pls_StoreCode) + string.Format(" AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID) + ") ");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithStoreGoodsLinkSupplierTypeQuery(string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\n,T_STORE_GOODS_SUPPTYPE AS (\nSELECT su_Supplier,su_SiteID,su_SupplierType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID) + ")");
      return stringBuilder.ToString();
    }
  }
}
