// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryDetailView
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
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryDetailView : TInventoryDetail<InventoryDetailView>
  {
    private TInventoryHeader _HeaerInfo;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _si_LocationUseYn;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private int _gd_MakerCode;
    private int _gd_BrandCode;
    private double _gd_MinOrderUnit;
    private int _gd_Deposit;
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
    private string _ih_EmpName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<GoodsPackBomTypeSet> _Lt_BomTypePackSet;
    private IList<InventoryDetailView> _Lt_History;
    private IList<InventoryDetailView> _Lt_BomTypeGoods;

    [JsonPropertyName("heaerInfo")]
    public TInventoryHeader HeaerInfo
    {
      get => this._HeaerInfo ?? (this._HeaerInfo = new TInventoryHeader());
      set
      {
        this._HeaerInfo = value;
        this.Changed(nameof (HeaerInfo));
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

    public double gd_MinOrderUnit
    {
      get => this._gd_MinOrderUnit;
      set
      {
        this._gd_MinOrderUnit = value;
        this.Changed(nameof (gd_MinOrderUnit));
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

    public string ih_EmpName
    {
      get => this._ih_EmpName;
      set
      {
        this._ih_EmpName = value;
        this.Changed(nameof (ih_EmpName));
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
    public IList<InventoryDetailView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<InventoryDetailView>) new List<InventoryDetailView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    [JsonPropertyName("lt_BomTypeGoods")]
    public IList<InventoryDetailView> Lt_BomTypeGoods
    {
      get => this._Lt_BomTypeGoods ?? (this._Lt_BomTypeGoods = (IList<InventoryDetailView>) new List<InventoryDetailView>());
      set
      {
        this._Lt_BomTypeGoods = value;
        this.Changed(nameof (Lt_BomTypeGoods));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.HeaerInfo = (TInventoryHeader) null;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = "N";
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.gd_GoodsName = this.gd_BarCode = this.gd_GoodsSize = string.Empty;
      this.gd_MakerCode = this.gd_BrandCode = 0;
      this.gd_Deposit = 0;
      this.gd_MinOrderUnit = 0.0;
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
      this.ih_EmpName = this.inEmpName = this.modEmpName = string.Empty;
      this.Lt_BomTypePackSet = (IList<GoodsPackBomTypeSet>) null;
      this.Lt_History = (IList<InventoryDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventoryDetailView();

    public override object Clone()
    {
      InventoryDetailView inventoryDetailView = base.Clone() as InventoryDetailView;
      inventoryDetailView.HeaerInfo = this.HeaerInfo;
      inventoryDetailView.si_StoreName = this.si_StoreName;
      inventoryDetailView.si_StoreViewCode = this.si_StoreViewCode;
      inventoryDetailView.si_UseYn = this.si_UseYn;
      inventoryDetailView.si_StoreType = this.si_StoreType;
      inventoryDetailView.si_LocationUseYn = this.si_LocationUseYn;
      inventoryDetailView.su_SupplierName = this.su_SupplierName;
      inventoryDetailView.su_SupplierViewCode = this.su_SupplierViewCode;
      inventoryDetailView.su_SupplierType = this.su_SupplierType;
      inventoryDetailView.gd_GoodsName = this.gd_GoodsName;
      inventoryDetailView.gd_BarCode = this.gd_BarCode;
      inventoryDetailView.gd_GoodsSize = this.gd_GoodsSize;
      inventoryDetailView.gd_MakerCode = this.gd_MakerCode;
      inventoryDetailView.gd_BrandCode = this.gd_BrandCode;
      inventoryDetailView.gd_Deposit = this.gd_Deposit;
      inventoryDetailView.gd_MinOrderUnit = this.gd_MinOrderUnit;
      inventoryDetailView.gd_StockConvQty = this.gd_StockConvQty;
      inventoryDetailView.gd_UseYn = this.gd_UseYn;
      inventoryDetailView.gdh_StartDate = this.gdh_StartDate;
      inventoryDetailView.gdh_EndDate = this.gdh_EndDate;
      inventoryDetailView.gdh_GoodsCategory = this.gdh_GoodsCategory;
      inventoryDetailView.gdh_Supplier = this.gdh_Supplier;
      inventoryDetailView.gdh_ChargeRate = this.gdh_ChargeRate;
      inventoryDetailView.gdh_BuyCost = this.gdh_BuyCost;
      inventoryDetailView.gdh_BuyVat = this.gdh_BuyVat;
      inventoryDetailView.gdh_SalePrice = this.gdh_SalePrice;
      inventoryDetailView.gdh_EventCost = this.gdh_EventCost;
      inventoryDetailView.gdh_EventVat = this.gdh_EventVat;
      inventoryDetailView.gdh_EventPrice = this.gdh_EventPrice;
      inventoryDetailView.dpt_lv1_ID = this.dpt_lv1_ID;
      inventoryDetailView.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      inventoryDetailView.dpt_lv1_Name = this.dpt_lv1_Name;
      inventoryDetailView.dpt_lv2_ID = this.dpt_lv2_ID;
      inventoryDetailView.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      inventoryDetailView.dpt_lv2_Name = this.dpt_lv2_Name;
      inventoryDetailView.dpt_ID = this.dpt_ID;
      inventoryDetailView.dpt_ViewCode = this.dpt_ViewCode;
      inventoryDetailView.dpt_DeptName = this.dpt_DeptName;
      inventoryDetailView.ctg_lv1_ID = this.ctg_lv1_ID;
      inventoryDetailView.ctg_lv1_ViewCode = this.ctg_lv1_ViewCode;
      inventoryDetailView.ctg_lv1_Name = this.ctg_lv1_Name;
      inventoryDetailView.ctg_lv2_ID = this.ctg_lv2_ID;
      inventoryDetailView.ctg_lv2_ViewCode = this.ctg_lv2_ViewCode;
      inventoryDetailView.ctg_lv2_Name = this.ctg_lv2_Name;
      inventoryDetailView.ctg_ViewCode = this.ctg_ViewCode;
      inventoryDetailView.ctg_CategoryName = this.ctg_CategoryName;
      inventoryDetailView.gdsh_DeliveryDiv = this.gdsh_DeliveryDiv;
      inventoryDetailView.gdsh_MinOrderUnit = this.gdsh_MinOrderUnit;
      inventoryDetailView.gdsh_MultiSuplierYn = this.gdsh_MultiSuplierYn;
      inventoryDetailView.gdsh_OrderEndDate = this.gdsh_OrderEndDate;
      inventoryDetailView.gdsh_SaleEndDate = this.gdsh_SaleEndDate;
      inventoryDetailView.pls_EndQty = this.pls_EndQty;
      inventoryDetailView.pls_EndAvgCost = this.pls_EndAvgCost;
      inventoryDetailView.pls_EndCostAmt = this.pls_EndCostAmt;
      inventoryDetailView.pls_EndCostVatAmt = this.pls_EndCostVatAmt;
      inventoryDetailView.pls_SaleQty = this.pls_SaleQty;
      inventoryDetailView.pls_SaleAmt = this.pls_SaleAmt;
      inventoryDetailView.pls_BuyQty = this.pls_BuyQty;
      inventoryDetailView.pls_BuyCostAmt = this.pls_BuyCostAmt;
      inventoryDetailView.pls_BuyCostVatAmt = this.pls_BuyCostVatAmt;
      inventoryDetailView.pls_InnerMoveInQty = this.pls_InnerMoveInQty;
      inventoryDetailView.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostAmt;
      inventoryDetailView.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInCostVatAmt;
      inventoryDetailView.pls_OuterMoveInQty = this.pls_OuterMoveInQty;
      inventoryDetailView.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostAmt;
      inventoryDetailView.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInCostVatAmt;
      inventoryDetailView.gdp_StockConvQty = this.gdp_StockConvQty;
      inventoryDetailView.ih_EmpName = this.ih_EmpName;
      inventoryDetailView.inEmpName = this.inEmpName;
      inventoryDetailView.modEmpName = this.modEmpName;
      inventoryDetailView.Lt_BomTypePackSet = this.Lt_BomTypePackSet;
      inventoryDetailView.Lt_History = this.Lt_History;
      return (object) inventoryDetailView;
    }

    public void PutData(InventoryDetailView pSource)
    {
      this.PutData((TInventoryDetail) pSource);
      this.HeaerInfo = (TInventoryHeader) null;
      if (pSource.HeaerInfo.ih_StatementNo > 0L)
        this.HeaerInfo.PutData(pSource.HeaerInfo);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_MakerCode = pSource.gd_MakerCode;
      this.gd_BrandCode = pSource.gd_BrandCode;
      this.gd_Deposit = pSource.gd_Deposit;
      this.gd_MinOrderUnit = pSource.gd_MinOrderUnit;
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
      this.ih_EmpName = pSource.ih_EmpName;
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
      this.Lt_History = (IList<InventoryDetailView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (InventoryDetailView pSource1 in (IEnumerable<InventoryDetailView>) pSource.Lt_History)
      {
        InventoryDetailView inventoryDetailView = new InventoryDetailView();
        inventoryDetailView.PutData(pSource1);
        this.Lt_History.Add(inventoryDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.id_SiteID == 0L)
      {
        this.message = "싸이트(id_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.id_StatementNo == 0L)
      {
        this.message = "재고조사전표번호(id_StatementNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToTaxDiv(this.id_TaxDiv) == EnumTaxDiv.NONE)
      {
        this.message = "면과세(id_TaxDiv) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToSalesUnit(this.id_SalesUnit) == EnumSalesUnit.NONE)
      {
        this.message = "판매단위(id_SalesUnit) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToStockUnit(this.id_StockUnit) == EnumStockUnit.NONE)
      {
        this.message = "재고단위(id_StockUnit) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToPackUnit(this.id_PackUnit) != EnumPackUnit.NONE)
        return EnumDataCheck.Success;
      this.message = "묶음단위(id_PackUnit) " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    public EnumDataCheck DataCheckOn(UniOleDatabase p_db) => this.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(id_Seq), 0)+1 AS id_Seq" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "id_StatementNo", (object) this.id_StatementNo);
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
          this.id_Seq = uniOleDbRecordset.GetFieldInt(0);
        return this.id_Seq > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      InventoryDetailView inventoryDetailView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView.CreateCodeQuery()))
        {
          inventoryDetailView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          inventoryDetailView.id_Seq = rs.GetFieldInt(0);
        return inventoryDetailView.id_Seq > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual void CalcSum()
    {
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
          if (this.id_SiteID == 0L)
            this.id_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.id_Seq == 0 && !this.CreateCode(p_db))
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
      InventoryDetailView inventoryDetailView = this;
      try
      {
        inventoryDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryDetailView.DataCheck(p_db))
            throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (inventoryDetailView.id_SiteID == 0L)
            inventoryDetailView.id_SiteID = p_app_employee.emp_SiteID;
          if (!inventoryDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (inventoryDetailView.id_Seq == 0)
        {
          if (!await inventoryDetailView.CreateCodeAsync(p_db))
            throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await inventoryDetailView.InsertAsync())
          throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 등록 오류");
        inventoryDetailView.db_status = 4;
        inventoryDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryDetailView.message = ex.Message;
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
        if (this.id_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(id_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      InventoryDetailView inventoryDetailView = this;
      try
      {
        inventoryDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryDetailView.DataCheck(p_db))
            throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!inventoryDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (inventoryDetailView.id_Seq == 0)
          throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 순번(id_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await inventoryDetailView.UpdateAsync())
          throw new UniServiceException(inventoryDetailView.message, inventoryDetailView.TableCode.ToDescription() + " 변경 오류");
        inventoryDetailView.db_status = 4;
        inventoryDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryDetailView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.HeaerInfo.GetFieldValues(p_rs);
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
      this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
      this.gd_MakerCode = p_rs.GetFieldInt("gd_MakerCode");
      this.gd_BrandCode = p_rs.GetFieldInt("gd_BrandCode");
      this.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
      this.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
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
      this.ih_EmpName = p_rs.GetFieldString("ih_EmpName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<InventoryDetailView> SelectOneAsync(
      long p_id_StatementNo,
      int p_id_Seq,
      long p_id_SiteID = 0)
    {
      InventoryDetailView inventoryDetailView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "id_StatementNo",
          (object) p_id_StatementNo
        },
        {
          (object) "id_Seq",
          (object) p_id_Seq
        }
      };
      if (p_id_SiteID > 0L)
        p_param.Add((object) "id_SiteID", (object) p_id_SiteID);
      return await inventoryDetailView.SelectOneTAsync<InventoryDetailView>((object) p_param);
    }

    public async Task<IList<InventoryDetailView>> SelectListAsync(object p_param)
    {
      InventoryDetailView inventoryDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView1.GetSelectQuery(p_param)))
        {
          inventoryDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventoryDetailView>) null;
        }
        IList<InventoryDetailView> lt_list = (IList<InventoryDetailView>) new List<InventoryDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventoryDetailView inventoryDetailView2 = inventoryDetailView1.OleDB.Create<InventoryDetailView>();
            if (inventoryDetailView2.GetFieldValues(rs))
            {
              inventoryDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventoryDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventoryDetailView> SelectEnumerableAsync(object p_param)
    {
      InventoryDetailView inventoryDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView1.GetSelectQuery(p_param)))
        {
          inventoryDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            InventoryDetailView inventoryDetailView2 = inventoryDetailView1.OleDB.Create<InventoryDetailView>();
            if (inventoryDetailView2.GetFieldValues(rs))
            {
              inventoryDetailView2.row_number = ++row_number;
              yield return inventoryDetailView2;
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
          if (hashtable2.ContainsKey((object) "id_SiteID") && Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "InventoryHeader_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "InventoryHeader_DEFULT_TABLE_"].ToString()))
            pIsHeaderDefultTable = Convert.ToBoolean(hashtable2[(object) "InventoryHeader_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeAssignQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeaderQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, pIsHeaderDefultTable));
        stringBuilder.Append(this.ToWithGoodsStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\nSELECT  id_StatementNo,id_Seq,id_SiteID,id_Supplier,id_CategoryCode,id_GoodsCode,id_BoxCode,id_BarCode,id_TaxDiv,id_SalesUnit,id_StockUnit,id_PackUnit,id_LinkRowNCount,id_BoxQty,id_InventoryQty,id_InventoryCost,id_InventoryCostAmt,id_InventoryCostVatAmt,id_AvgCost,id_AvgCostAmt,id_AvgCostVatAmt,id_InventoryPrice,id_InventoryPriceAmt,id_MobileSeq,id_InDate,id_InUser,id_ModDate,id_ModUser\n,ih_StatementNo,ih_SiteID,ih_StoreCode,ih_Title,ih_EmpCode,ih_InventoryStatus,ih_InventoryDate,ih_ApplyType,ih_ApplyDate,ih_DeviceType,ih_DeviceKey,ih_DeviceName,ih_GoodsCount,ih_CostAmt,ih_CostVatAmt,ih_AvgCostAmt,ih_AvgCostVatAmt,ih_PriceAmt,ih_PosNo,ih_TransNo,ih_LocationCode,ih_LocationCount,ih_StockUnit,ih_Memo,ih_MobileStatementNo,ih_InDate,ih_InUser,ih_ModDate,ih_ModUser,ih_EmpName\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_MakerCode,gd_BrandCode,gd_Deposit,gd_MinOrderUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON id_StatementNo=ih_StatementNo AND id_SiteID=ih_SiteID\nINNER JOIN T_STORE ON ih_StoreCode=si_StoreCode AND ih_SiteID=si_SiteID\nLEFT OUTER JOIN T_GOODS ON id_BoxCode=gd_GoodsCode AND id_SiteID=gd_SiteID\nLEFT OUTER JOIN T_GOOD_CODE ON id_BoxCode=gdp_GoodsCode\nLEFT OUTER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND id_BoxCode=gdh_GoodsCode AND ih_InventoryDate>=gdh_StartDate AND ih_InventoryDate<=gdh_EndDate\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND id_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON ih_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND id_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON ih_StoreCode=pls_StoreCode AND id_BoxCode=pls_GoodsCode AND id_SiteID=pls_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON id_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON id_ModUser=emp_CodeMod\nLEFT OUTER JOIN T_EMPLOYEE_ASSIGN ON ih_EmpCode=emp_CodeAssign");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num <= 0)
        {
          if (!string.IsNullOrEmpty(empty))
            stringBuilder.Append(" ORDER BY " + empty);
          else
            stringBuilder.Append(" ORDER BY id_StatementNo,id_Seq");
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode_IN_"))
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
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

    public string ToWithEmployeeAssignQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_ASSIGN AS ( SELECT emp_Code AS emp_CodeAssign,emp_Name AS ih_EmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
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
        stringBuilder.Append("\n,T_HEADER AS ( SELECT  ih_StatementNo,ih_SiteID,ih_StoreCode,ih_Title,ih_EmpCode,ih_InventoryStatus,ih_InventoryDate,ih_ApplyType,ih_ApplyDate,ih_DeviceType,ih_DeviceKey,ih_DeviceName,ih_GoodsCount,ih_CostAmt,ih_CostVatAmt,ih_AvgCostAmt,ih_AvgCostVatAmt,ih_PriceAmt,ih_PosNo,ih_TransNo,ih_LocationCode,ih_LocationCount,ih_StockUnit,ih_Memo,ih_MobileStatementNo,ih_InDate,ih_InUser,ih_ModDate,ih_ModUser" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.InventoryHeader, (object) DbQueryHelper.ToWithNolock()));
        if (pIsHeaderDefultTable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new InventoryHeaderView().GetSelectWhereAnd(p_param));
        }
        else
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
              p_param1.Add((object) "ih_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("id_StatementNo"))
              p_param1.Add((object) "ih_StatementNo", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_StatementNo"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_InventoryStatus"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_InventoryDate"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_InventoryDate_BEGIN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_InventoryDate_END_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_ApplyType"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_ApplyDate"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_ApplyDate_BEGIN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_ApplyDate_END_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_DeviceType"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_DeviceKey"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_StockUnit"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_StockUnit_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("id_StockUnit"))
              p_param1.Add((object) "ih_StockUnit", dictionaryEntry.Value);
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
            if (dictionaryEntry.Key.ToString().Equals("emp_Code"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_EmpCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_PosNo"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_TransNo"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_LocationCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "ih_SiteID"))
              p_param1.Add((object) "ih_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(new TInventoryHeader().GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "ih_SiteID", (object) p_SiteID));
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
        stringBuilder.Append("\n,T_GOOD_STATEMENT AS ( SELECT id_BoxCode AS gse_id_BoxCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.InventoryDetail, (object) DbQueryHelper.ToWithNolock()) + string.Format(" INNER JOIN T_HEADER ON {0}={1} AND {2}={3}", (object) "ih_StatementNo", (object) this.id_StatementNo, (object) "ih_SiteID", (object) this.id_SiteID));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("id_StatementNo"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StatementNo"))
            p_param1.Add((object) "id_StatementNo", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "id_SiteID"))
            p_param1.Add((object) "id_SiteID", (object) p_SiteID);
          stringBuilder.Append(new InventoryHeaderView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "id_SiteID", (object) p_SiteID));
        stringBuilder.Append(" GROUP BY id_BoxCode");
        stringBuilder.Append(")");
      }
      finally
      {
        if (p_param1.Count > 0)
          p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsCodeQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsStatement = true)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_StockConvQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}!={1}", (object) "gd_PackUnit", (object) 4));
        if (p_IsStatement)
          stringBuilder.Append("\nINNER JOIN T_GOOD_STATEMENT ON gdp_GoodsCode=gse_id_BoxCode");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gdp_SiteID", (object) p_SiteID) + " AND gdp_StockConvQty > 0");
        stringBuilder.Append("\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (p_IsStatement)
          stringBuilder.Append("\nINNER JOIN T_GOOD_STATEMENT ON gd_GoodsCode=gse_id_BoxCode");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1));
        stringBuilder.Append("\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (p_IsStatement)
          stringBuilder.Append("\nINNER JOIN T_GOOD_STATEMENT ON gd_GoodsCode=gse_id_BoxCode");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4) + ")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsBomCodeQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_StockConvQty" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
            p_param1.Add((object) "gdp_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("id_BoxCode"))
            p_param1.Add((object) "gdp_GoodsCode", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdp_SiteID"))
            p_param1.Add((object) "gdp_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "gdp_StockConvQty데이터 0 제외"))
            p_param1.Add((object) "gdp_StockConvQty데이터 0 제외", (object) true);
          stringBuilder.Append(new TGoodsPack().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_SiteID", (object) p_SiteID) + " AND gdp_StockConvQty > 0");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSubGoodsCode = false)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOODS AS (\nSELECT  gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (!p_IsSubGoodsCode)
          stringBuilder.Append("\nINNER JOIN T_GOOD_CODE ON gdp_GoodsCode=gd_GoodsCode");
        else
          stringBuilder.Append("\nINNER JOIN T_GOOD_CODE ON gdp_SubGoodsCode=gd_GoodsCode");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("id_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_") && !p_param1.ContainsKey((object) "_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_InventoryDate") && !p_param1.ContainsKey((object) "_DT_DATE_"))
            p_param1.Add((object) "_DT_DATE_", dictionaryEntry.Value);
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
          if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("id_GoodsCode"))
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

    public string ToWithPlsQuery(object p_param, string p_dbms, long p_SiteID, bool p_IsHeader = true)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PLS AS (\nSELECT pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,pls_EndQty/gdp_StockConvQty AS pls_EndQty,pls_EndAvgCost,pls_EndCostAmt/gdp_StockConvQty AS pls_EndCostAmt,pls_EndCostVatAmt/gdp_StockConvQty AS pls_EndCostVatAmt,pls_SaleQty/gdp_StockConvQty AS pls_SaleQty,pls_SaleAmt/gdp_StockConvQty AS pls_SaleAmt,pls_BuyQty/gdp_StockConvQty AS pls_BuyQty,pls_BuyCostAmt/gdp_StockConvQty AS pls_BuyCostAmt,pls_BuyCostVatAmt/gdp_StockConvQty AS pls_BuyCostVatAmt,pls_InnerMoveInQty/gdp_StockConvQty AS pls_InnerMoveInQty,pls_InnerMoveInCostAmt/gdp_StockConvQty AS pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt/gdp_StockConvQty AS pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty/gdp_StockConvQty AS pls_OuterMoveInQty,pls_OuterMoveInCostAmt/gdp_StockConvQty AS pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt/gdp_StockConvQty AS pls_OuterMoveInCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        if (p_IsHeader)
          stringBuilder.Append("\n INNER JOIN T_HEADER ON pls_YyyyMm=" + "ih_InventoryDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND ih_StoreCode=pls_StoreCode" + string.Format(" AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n INNER JOIN T_GOOD_CODE ON gdp_SubGoodsCode=pls_GoodsCode");
        if (!p_IsHeader)
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("id_SiteID"))
              p_param1.Add((object) "pls_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("ih_InventoryDate"))
              p_param1.Add((object) "pls_YyyyMm", (object) ((DateTime) dictionaryEntry.Value).ToIntFormat("yyyyMM"));
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "pls_SiteID"))
              p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
            stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pls_SiteID", (object) 0L));
        }
        stringBuilder.Append(") ");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithBarCodeQuery(
      string p_barCode,
      bool p_IsOldBarcode,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_BARCODE AS (");
        stringBuilder.Append("\nSELECT gd_GoodsCode AS gdob_GoodsCode,gd_BarCode AS gdob_BarCode,gd_SiteID AS gdob_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + " AND gd_BarCode='" + p_barCode + "'");
        if (p_IsOldBarcode)
          stringBuilder.Append("\nUNION ALL\nSELECT gdob_GoodsCode,gdob_BarCode,gdob_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gdob_SiteID", (object) p_SiteID) + " AND gdob_BarCode='" + p_barCode + "'");
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<InventoryDetailView> SelectGoodsOneAsync(
      long p_id_BoxCode,
      string p_id_BarCode,
      DateTime p_ih_InventoryDate,
      long p_id_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "id_BoxCode",
          (object) p_id_BoxCode
        },
        {
          (object) "id_BarCode",
          (object) p_id_BarCode
        },
        {
          (object) "ih_InventoryDate",
          (object) p_ih_InventoryDate
        }
      };
      if (p_id_SiteID > 0L)
        p_param.Add((object) "id_SiteID", (object) p_id_SiteID);
      return await this.SelectGoodsOneAsync((object) p_param);
    }

    public async Task<IList<InventoryDetailView>> SelectGoodsListAsync(object p_param)
    {
      InventoryDetailView inventoryDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView1.SelectGoodsQuery(p_param)))
        {
          inventoryDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventoryDetailView>) null;
        }
        IList<InventoryDetailView> lt_list = (IList<InventoryDetailView>) new List<InventoryDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventoryDetailView inventoryDetailView2 = inventoryDetailView1.OleDB.Create<InventoryDetailView>();
            if (inventoryDetailView2.GetFieldValues(rs))
            {
              inventoryDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventoryDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async Task<InventoryDetailView> SelectGoodsOneAsync(object p_param)
    {
      InventoryDetailView inventoryDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView1.SelectGoodsQuery(p_param)))
        {
          inventoryDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
          return (InventoryDetailView) null;
        }
        if (await rs.IsDataReadAsync())
        {
          InventoryDetailView inventoryDetailView2 = inventoryDetailView1.OleDB.Create<InventoryDetailView>();
          if (inventoryDetailView2.GetFieldValues(rs))
          {
            inventoryDetailView2.row_number = 1;
            return inventoryDetailView2;
          }
        }
        return (InventoryDetailView) null;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async Task<IList<InventoryDetailView>> SelectGoodsBomListAsync(object p_param)
    {
      InventoryDetailView inventoryDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryDetailView1.SelectGoodsBomQuery(p_param)))
        {
          inventoryDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventoryDetailView>) null;
        }
        IList<InventoryDetailView> lt_list = (IList<InventoryDetailView>) new List<InventoryDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventoryDetailView inventoryDetailView2 = inventoryDetailView1.OleDB.Create<InventoryDetailView>();
            if (inventoryDetailView2.GetFieldValues(rs))
            {
              inventoryDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventoryDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public string SelectGoodsQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        string p_barCode = (string) null;
        long num = 0;
        DateTime? p_day = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "id_SiteID") && Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "id_BoxCode") && Convert.ToInt64(hashtable2[(object) "id_BoxCode"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable2[(object) "id_BoxCode"].ToString());
          if (hashtable2.ContainsKey((object) "id_BarCode") && !string.IsNullOrEmpty(hashtable2[(object) "id_BarCode"].ToString()))
            p_barCode = hashtable2[(object) "id_BarCode"].ToString();
          if (hashtable2.ContainsKey((object) "ih_InventoryDate") && !string.IsNullOrEmpty(hashtable2[(object) "ih_InventoryDate"].ToString()))
            p_day = new DateTime?((DateTime) hashtable2[(object) "ih_InventoryDate"]);
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (num == 0L && !string.IsNullOrEmpty(p_barCode))
          stringBuilder.Append(this.ToWithBarCodeQuery(p_barCode, true, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeQuery(p_param, uniBase, p_SiteID, false));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, false));
        stringBuilder.Append("\nSELECT  0 AS id_StatementNo,0 AS id_Seq,gd_SiteID AS id_SiteID,gdh_Supplier AS id_Supplier,gdh_GoodsCategory AS id_CategoryCode,gdp_SubGoodsCode AS id_GoodsCode,gd_GoodsCode AS id_BoxCode," + (string.IsNullOrEmpty(p_barCode) ? "gd_BarCode" : string.Format("'%s'", (object) p_barCode)) + " AS id_BarCode,gd_TaxDiv AS id_TaxDiv,gd_SalesUnit AS id_SalesUnit,gd_StockUnit AS id_StockUnit,gd_PackUnit AS id_PackUnit,0 AS id_LinkRowNCount,0 AS id_BoxQty,0 AS id_InventoryQty,gdh_BuyCost AS id_InventoryCost,0 AS id_InventoryCostAmt,0 AS id_InventoryCostVatAmt,pls_EndAvgCost AS id_AvgCost,0 AS id_AvgCostAmt,0 AS id_AvgCostVatAmt,gdh_SalePrice AS id_InventoryPrice,0 AS id_InventoryPriceAmt,0 AS id_MobileSeq,NULL AS id_InDate,0 AS id_InUser,NULL AS id_ModDate,0 AS id_ModUser\n,0 AS ih_StatementNo,gd_SiteID AS ih_SiteID,si_StoreCode AS ih_StoreCode,'' AS ih_Title,0 AS ih_EmpCode,0 AS ih_InventoryStatus," + (!p_day.HasValue ? "NULL" : p_day.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'")) + " AS ih_InventoryDate,0 AS ih_ApplyType,NULL AS ih_ApplyDate,0 AS ih_DeviceType,0 AS ih_DeviceKey,'' AS ih_DeviceName,0 AS ih_GoodsCount,0 AS ih_CostAmt,0 AS ih_CostVatAmt,0 AS ih_AvgCostAmt,0 AS ih_AvgCostVatAmt,0 AS ih_PriceAmt,0 AS ih_PosNo,0 AS ih_TransNo,0 AS ih_LocationCode,0 AS ih_LocationCount,0 AS ih_StockUnit,'' AS ih_Memo,0 AS ih_MobileStatementNo,NULL AS ih_InDate,0 AS ih_InUser,NULL AS ih_ModDate,0 AS ih_ModUser,'' AS ih_EmpName\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_MakerCode,gd_BrandCode,gd_Deposit,gd_MinOrderUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append("\nFROM T_GOODS\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID");
        if (num == 0L && !string.IsNullOrEmpty(p_barCode))
          stringBuilder.Append("\nINNER JOIN T_BARCODE ON gd_GoodsCode=gdob_GoodsCode AND gd_SiteID=gdob_SiteID");
        stringBuilder.Append("\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode\nLEFT OUTER JOIN T_GOOD_CODE ON gd_GoodsCode=gdp_GoodsCode\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON si_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON si_StoreCode=pls_StoreCode AND gd_GoodsCode=pls_GoodsCode AND gd_SiteID=pls_SiteID");
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_GoodsCode", (object) num) + string.Format("\nAND {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
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

    public string SelectGoodsBomQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        DateTime? p_day = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "id_SiteID") && Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "id_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "id_BoxCode") && Convert.ToInt64(hashtable2[(object) "id_BoxCode"].ToString()) > 0L)
            Convert.ToInt64(hashtable2[(object) "id_BoxCode"].ToString());
          if (hashtable2.ContainsKey((object) "ih_InventoryDate") && !string.IsNullOrEmpty(hashtable2[(object) "ih_InventoryDate"].ToString()))
            p_day = new DateTime?((DateTime) hashtable2[(object) "ih_InventoryDate"]);
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsBomCodeQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID, true));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithStoreGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPlsQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, false));
        stringBuilder.Append("\nSELECT  0 AS id_StatementNo,0 AS id_Seq,gd_SiteID AS id_SiteID,gdh_Supplier AS id_Supplier,gdh_GoodsCategory AS id_CategoryCode,gdp_SubGoodsCode AS id_GoodsCode,gd_GoodsCode AS id_BoxCode,gd_BarCode AS id_BarCode,gd_TaxDiv AS id_TaxDiv,gd_SalesUnit AS id_SalesUnit,gd_StockUnit AS id_StockUnit,gd_PackUnit AS id_PackUnit,0 AS id_LinkRowNCount,0 AS id_BoxQty,0 AS id_InventoryQty,gdh_BuyCost AS id_InventoryCost,0 AS id_InventoryCostAmt,0 AS id_InventoryCostVatAmt,pls_EndAvgCost AS id_AvgCost,0 AS id_AvgCostAmt,0 AS id_AvgCostVatAmt,gdh_SalePrice AS id_InventoryPrice,0 AS id_InventoryPriceAmt,0 AS id_MobileSeq,NULL AS id_InDate,0 AS id_InUser,NULL AS id_ModDate,0 AS id_ModUser\n,0 AS ih_StatementNo,gd_SiteID AS ih_SiteID,si_StoreCode AS ih_StoreCode,'' AS ih_Title,0 AS ih_EmpCode,0 AS ih_InventoryStatus," + (!p_day.HasValue ? "NULL" : p_day.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'")) + " AS ih_InventoryDate,0 AS ih_ApplyType,NULL AS ih_ApplyDate,0 AS ih_DeviceType,0 AS ih_DeviceKey,'' AS ih_DeviceName,0 AS ih_GoodsCount,0 AS ih_CostAmt,0 AS ih_CostVatAmt,0 AS ih_AvgCostAmt,0 AS ih_AvgCostVatAmt,0 AS ih_PriceAmt,0 AS ih_PosNo,0 AS ih_TransNo,0 AS ih_LocationCode,0 AS ih_LocationCount,0 AS ih_StockUnit,'' AS ih_Memo,0 AS ih_MobileStatementNo,NULL AS ih_InDate,0 AS ih_InUser,NULL AS ih_ModDate,0 AS ih_ModUser,'' AS ih_EmpName\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_MakerCode,gd_BrandCode,gd_Deposit,gd_MinOrderUnit,gd_StockConvQty,gd_UseYn\n,gdh_StartDate,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_ID,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code ,ctg_lv3_ViewCode AS ctg_ViewCode, ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,gdp_StockConvQty\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append("\nFROM T_GOODS\nINNER JOIN T_STORE ON gd_SiteID=si_SiteID");
        stringBuilder.Append("\nINNER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND gd_GoodsCode=gdh_GoodsCode\nLEFT OUTER JOIN T_GOOD_CODE ON gd_GoodsCode=gdp_GoodsCode\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND gd_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_STORE_GOODS ON si_StoreCode=gdsh_StoreCode AND gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID\nLEFT OUTER JOIN T_PLS ON si_StoreCode=pls_StoreCode AND gd_GoodsCode=pls_GoodsCode AND gd_SiteID=pls_SiteID");
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
