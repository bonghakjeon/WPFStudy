// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.Goods.GoodsView
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.Goods
{
  public class GoodsView : TGoods<GoodsView>
  {
    private long _gi_GoodsCode;
    private int _gi_ImgType;
    protected byte[] _gi_ThumbData = new byte[0];
    protected byte[] _gi_OriginData = new byte[0];
    private string _gdob_BarCode;
    private IList<GoodsOldBarcodeView> _Lt_OldBarcode;
    private string _mk_MakerName;
    private string _br_BrandName;
    private string _inEmpName;
    private string _modEmpName;
    private GoodsHistoryView _GoodsHistoryInfo;
    private IList<GoodsHistoryView> _Lt_History;
    private GoodsHistoryByStoreDic _Dic_GoodsHistoryByStore;
    private GoodsStoreInfoView _GoodsStoreInfo;
    private int _ea_GoodsCode;
    private double _ea_StockConvQty;
    private string _ea_GoodsName;
    private string _ea_BarCode;
    private string _ea_GoodsSize;
    private IList<GoodsPackView> _Lt_GoodsPack;
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
    protected bool _gd_IsCreateBarCode;

    public long gi_GoodsCode
    {
      get => this._gi_GoodsCode;
      set
      {
        this._gi_GoodsCode = value;
        this.Changed(nameof (gi_GoodsCode));
      }
    }

    public int gi_ImgType
    {
      get => this._gi_ImgType;
      set
      {
        this._gi_ImgType = value;
        this.Changed(nameof (gi_ImgType));
      }
    }

    public byte[] gi_ThumbData
    {
      get => this._gi_ThumbData;
      set
      {
        this._gi_ThumbData = value;
        this.Changed(nameof (gi_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.gi_ThumbData != null && this.gi_ThumbData.Length != 0;

    public byte[] gi_OriginData
    {
      get => this._gi_OriginData;
      set
      {
        this._gi_OriginData = value;
        this.Changed(nameof (gi_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.gi_OriginData != null && this.gi_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        string fileExtensionName = Enum2StrConverter.ToImageFileExtensionName(this.gi_ImgType);
        if (this.IsOriginData)
          return "data:image/" + fileExtensionName + ";base64," + this.gi_OriginData.ToBase64();
        return this.IsThumbData ? "data:image/" + fileExtensionName + ";base64," + this.gi_ThumbData.ToBase64() : (string) null;
      }
    }

    public string gdob_BarCode
    {
      get => this._gdob_BarCode;
      set
      {
        this._gdob_BarCode = value;
        this.Changed(nameof (gdob_BarCode));
      }
    }

    [JsonPropertyName("lt_OldBarcode")]
    public IList<GoodsOldBarcodeView> Lt_OldBarcode
    {
      get => this._Lt_OldBarcode ?? (this._Lt_OldBarcode = (IList<GoodsOldBarcodeView>) new List<GoodsOldBarcodeView>());
      set
      {
        this._Lt_OldBarcode = value;
        this.Changed(nameof (Lt_OldBarcode));
      }
    }

    public string mk_MakerName
    {
      get => this._mk_MakerName;
      set
      {
        this._mk_MakerName = value;
        this.Changed(nameof (mk_MakerName));
      }
    }

    public string br_BrandName
    {
      get => this._br_BrandName;
      set
      {
        this._br_BrandName = value;
        this.Changed(nameof (br_BrandName));
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

    [JsonPropertyName("goodsHistoryInfo")]
    public GoodsHistoryView GoodsHistoryInfo
    {
      get => this._GoodsHistoryInfo ?? (this._GoodsHistoryInfo = new GoodsHistoryView());
      set
      {
        this._GoodsHistoryInfo = value;
        this.Changed(nameof (GoodsHistoryInfo));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<GoodsHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<GoodsHistoryView>) new List<GoodsHistoryView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    [JsonPropertyName("dic_GoodsHistoryByStore")]
    public GoodsHistoryByStoreDic Dic_GoodsHistoryByStore
    {
      get => this._Dic_GoodsHistoryByStore ?? (this._Dic_GoodsHistoryByStore = new GoodsHistoryByStoreDic());
      set
      {
        this._Dic_GoodsHistoryByStore = value;
        this.Changed(nameof (Dic_GoodsHistoryByStore));
      }
    }

    [JsonPropertyName("goodsStoreInfo")]
    public GoodsStoreInfoView GoodsStoreInfo
    {
      get => this._GoodsStoreInfo ?? (this._GoodsStoreInfo = new GoodsStoreInfoView());
      set
      {
        this._GoodsStoreInfo = value;
        this.Changed(nameof (GoodsStoreInfo));
      }
    }

    public int ea_GoodsCode
    {
      get => this._ea_GoodsCode;
      set
      {
        this._ea_GoodsCode = value;
        this.Changed(nameof (ea_GoodsCode));
      }
    }

    public double ea_StockConvQty
    {
      get => this._ea_StockConvQty;
      set
      {
        this._ea_StockConvQty = value;
        this.Changed(nameof (ea_StockConvQty));
      }
    }

    public string ea_GoodsName
    {
      get => this._ea_GoodsName;
      set
      {
        this._ea_GoodsName = value;
        this.Changed(nameof (ea_GoodsName));
      }
    }

    public string ea_BarCode
    {
      get => this._ea_BarCode;
      set
      {
        this._ea_BarCode = value;
        this.Changed(nameof (ea_BarCode));
      }
    }

    public string ea_GoodsSize
    {
      get => this._ea_GoodsSize;
      set
      {
        this._ea_GoodsSize = value;
        this.Changed(nameof (ea_GoodsSize));
      }
    }

    [JsonPropertyName("lt_GoodsPack")]
    public IList<GoodsPackView> Lt_GoodsPack
    {
      get => this._Lt_GoodsPack ?? (this._Lt_GoodsPack = (IList<GoodsPackView>) new List<GoodsPackView>());
      set
      {
        this._Lt_GoodsPack = value;
        this.Changed(nameof (Lt_GoodsPack));
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

    public bool gd_IsCreateBarCode
    {
      get => this._gd_IsCreateBarCode;
      set
      {
        this._gd_IsCreateBarCode = value;
        this.Changed(nameof (gd_IsCreateBarCode));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gdh_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "gdh_StoreCode",
        tc_trans_name = "지점코드",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_StartDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_StartDate",
        tc_trans_name = "시작일",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_EndDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_EndDate",
        tc_trans_name = "종료일",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_GoodsCategory", new TTableColumn()
      {
        tc_orgin_name = "gdh_GoodsCategory",
        tc_trans_name = "소분류",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_Supplier", new TTableColumn()
      {
        tc_orgin_name = "gdh_Supplier",
        tc_trans_name = "업체",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_ChargeRate", new TTableColumn()
      {
        tc_orgin_name = "gdh_ChargeRate",
        tc_trans_name = "수수료율",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_BuyCost", new TTableColumn()
      {
        tc_orgin_name = "gdh_BuyCost",
        tc_trans_name = "매입원가",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_BuyVat", new TTableColumn()
      {
        tc_orgin_name = "gdh_BuyVat",
        tc_trans_name = "매입VAT",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_SalePrice", new TTableColumn()
      {
        tc_orgin_name = "gdh_SalePrice",
        tc_trans_name = "판매가",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_EventCost", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventCost",
        tc_trans_name = "행사원가",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_EventVat", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventVat",
        tc_trans_name = "행사VAT",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_EventPrice", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventPrice",
        tc_trans_name = "행사판매가",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_MemberPrice1", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice1",
        tc_trans_name = "회원가",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_MemberPrice2", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice2",
        tc_trans_name = "회원가2",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_MemberPrice3", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice3",
        tc_trans_name = "회원가3",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_PointRate", new TTableColumn()
      {
        tc_orgin_name = "gdh_PointRate",
        tc_trans_name = "회원특별적립율",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_InDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_InDate",
        tc_trans_name = "이력등록일",
        tc_col_status = 1
      });
      columnInfo.Add("gdh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_ModDate",
        tc_trans_name = "이력변경일",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_DeliveryDiv", new TTableColumn()
      {
        tc_orgin_name = "gdsh_DeliveryDiv",
        tc_trans_name = "배송 구분",
        tc_col_status = 1,
        tc_comm_code = 60
      });
      columnInfo.Add("gdsh_MinOrderUnit", new TTableColumn()
      {
        tc_orgin_name = "gdsh_MinOrderUnit",
        tc_trans_name = "최소 발주량",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_MultiSuplierYn", new TTableColumn()
      {
        tc_orgin_name = "gdsh_MultiSuplierYn",
        tc_trans_name = "복수거래처 여부",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_OrderEndDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_OrderEndDate",
        tc_trans_name = "발주중지",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_SaleEndDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_SaleEndDate",
        tc_trans_name = "판매중지",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_StorageStockQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_StorageStockQty",
        tc_trans_name = "창고 적정 재고 유지량",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierViewCode", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierViewCode",
        tc_trans_name = "식별코드",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierType",
        tc_trans_name = "형태",
        tc_col_status = 1,
        tc_comm_code = 40
      });
      columnInfo.Add("dpt_lv1_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_ID",
        tc_trans_name = "부서ID",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv1_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_ViewCode",
        tc_trans_name = "부서코드",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv1_Name", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_Name",
        tc_trans_name = "부서명",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_ID",
        tc_trans_name = "팀ID",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_ViewCode",
        tc_trans_name = "팀코드",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_Name", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_Name",
        tc_trans_name = "팀명",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_Depth", new TTableColumn()
      {
        tc_orgin_name = "dpt_Depth",
        tc_trans_name = "부서 단계",
        tc_col_status = 1
      });
      columnInfo.Add("dpt_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_ID",
        tc_trans_name = "부서ID",
        tc_col_status = 1
      });
      columnInfo.Add("dpt_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_ViewCode",
        tc_trans_name = "PC코드",
        tc_col_status = 1
      });
      columnInfo.Add("dpt_DeptName", new TTableColumn()
      {
        tc_orgin_name = "dpt_DeptName",
        tc_trans_name = "PC명",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_lv1_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_ID",
        tc_trans_name = "대분류ID",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv1_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_ViewCode",
        tc_trans_name = "대분류코드",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv1_Name", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_Name",
        tc_trans_name = "대분류명",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_ID",
        tc_trans_name = "중분류ID",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_ViewCode",
        tc_trans_name = "중분류코드",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_Name", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_Name",
        tc_trans_name = "중분류명",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_Depth", new TTableColumn()
      {
        tc_orgin_name = "ctg_Depth",
        tc_trans_name = "분류단계",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_ID",
        tc_trans_name = "분류ID",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_ViewCode",
        tc_trans_name = "소분류코드",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_CategoryName", new TTableColumn()
      {
        tc_orgin_name = "ctg_CategoryName",
        tc_trans_name = "소분류명",
        tc_col_status = 1
      });
      columnInfo.Add("mk_MakerName", new TTableColumn()
      {
        tc_orgin_name = "mk_MakerName",
        tc_trans_name = "제조사명",
        tc_col_status = 1
      });
      columnInfo.Add("br_BrandName", new TTableColumn()
      {
        tc_orgin_name = "br_BrandName",
        tc_trans_name = "브랜드명",
        tc_col_status = 1
      });
      columnInfo.Add("pls_EndQty", new TTableColumn()
      {
        tc_orgin_name = "pls_EndQty",
        tc_trans_name = "수량",
        tc_col_status = 1
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.gi_GoodsCode = 0L;
      this.gi_ImgType = 0;
      this.gi_ThumbData = new byte[0];
      this.gi_OriginData = new byte[0];
      this.ea_GoodsCode = 0;
      this.ea_StockConvQty = 0.0;
      this.ea_GoodsName = string.Empty;
      this.ea_BarCode = string.Empty;
      this.ea_GoodsSize = string.Empty;
      this.GoodsHistoryInfo = (GoodsHistoryView) null;
      this.GoodsStoreInfo = (GoodsStoreInfoView) null;
      this.mk_MakerName = string.Empty;
      this.br_BrandName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.pls_EndQty = this.pls_EndAvgCost = this.pls_EndCostAmt = this.pls_EndCostVatAmt = 0.0;
      this.pls_SaleQty = this.pls_SaleAmt = 0.0;
      this.pls_BuyQty = this.pls_BuyCostAmt = this.pls_BuyCostVatAmt = 0.0;
      this.pls_InnerMoveInQty = this.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostVatAmt = 0.0;
      this.pls_OuterMoveInQty = this.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostVatAmt = 0.0;
      this.Lt_History = (IList<GoodsHistoryView>) null;
      this.Lt_OldBarcode = (IList<GoodsOldBarcodeView>) null;
      this.Lt_GoodsPack = (IList<GoodsPackView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsView();

    public override object Clone()
    {
      GoodsView goodsView = base.Clone() as GoodsView;
      goodsView.gi_GoodsCode = this.gi_GoodsCode;
      goodsView.gi_ImgType = this.gi_ImgType;
      goodsView.gi_ThumbData = this.gi_ThumbData;
      goodsView.gi_OriginData = this.gi_OriginData;
      goodsView.ea_GoodsCode = this.ea_GoodsCode;
      goodsView.ea_StockConvQty = this.ea_StockConvQty;
      goodsView.ea_GoodsName = this.ea_GoodsName;
      goodsView.ea_BarCode = this.ea_BarCode;
      goodsView.ea_GoodsSize = this.ea_GoodsSize;
      goodsView.GoodsHistoryInfo = (GoodsHistoryView) null;
      if (this.GoodsHistoryInfo.gdh_StoreCode > 0)
        goodsView.GoodsHistoryInfo = this.GoodsHistoryInfo;
      goodsView.GoodsStoreInfo = (GoodsStoreInfoView) null;
      if (this.GoodsStoreInfo.gdsh_StoreCode > 0)
        goodsView.GoodsStoreInfo = this.GoodsStoreInfo;
      goodsView.mk_MakerName = this.mk_MakerName;
      goodsView.br_BrandName = this.br_BrandName;
      goodsView.inEmpName = this.inEmpName;
      goodsView.modEmpName = this.modEmpName;
      goodsView.pls_EndQty = this.pls_EndQty;
      goodsView.pls_EndAvgCost = this.pls_EndAvgCost;
      goodsView.pls_EndCostAmt = this.pls_EndCostAmt;
      goodsView.pls_EndCostVatAmt = this.pls_EndCostVatAmt;
      goodsView.pls_SaleQty = this.pls_SaleQty;
      goodsView.pls_SaleAmt = this.pls_SaleAmt;
      goodsView.pls_BuyQty = this.pls_BuyQty;
      goodsView.pls_BuyCostAmt = this.pls_BuyCostAmt;
      goodsView.pls_BuyCostVatAmt = this.pls_BuyCostVatAmt;
      goodsView.pls_InnerMoveInQty = this.pls_InnerMoveInQty;
      goodsView.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostAmt;
      goodsView.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInCostVatAmt;
      goodsView.pls_OuterMoveInQty = this.pls_OuterMoveInQty;
      goodsView.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostAmt;
      goodsView.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInCostVatAmt;
      goodsView.Lt_History = (IList<GoodsHistoryView>) null;
      if (this.Lt_History.Count > 0)
      {
        foreach (GoodsHistoryView goodsHistoryView in (IEnumerable<GoodsHistoryView>) this.Lt_History)
          goodsView.Lt_History.Add(goodsHistoryView);
      }
      goodsView.Lt_OldBarcode = (IList<GoodsOldBarcodeView>) null;
      if (this.Lt_OldBarcode.Count > 0)
      {
        foreach (GoodsOldBarcodeView goodsOldBarcodeView in (IEnumerable<GoodsOldBarcodeView>) this.Lt_OldBarcode)
          goodsView.Lt_OldBarcode.Add(goodsOldBarcodeView);
      }
      goodsView.Lt_GoodsPack = (IList<GoodsPackView>) null;
      if (this.Lt_GoodsPack.Count > 0)
      {
        foreach (GoodsPackView goodsPackView in (IEnumerable<GoodsPackView>) this.Lt_GoodsPack)
          goodsView.Lt_GoodsPack.Add(goodsPackView);
      }
      return (object) goodsView;
    }

    public void PutData(GoodsView pSource)
    {
      this.PutData((TGoods) pSource);
      this.gi_GoodsCode = pSource.gi_GoodsCode;
      this.gi_ImgType = pSource.gi_ImgType;
      this.gi_ThumbData = pSource.gi_ThumbData;
      this.gi_OriginData = pSource.gi_OriginData;
      this.ea_GoodsCode = pSource.ea_GoodsCode;
      this.ea_StockConvQty = pSource.ea_StockConvQty;
      this.ea_GoodsName = pSource.ea_GoodsName;
      this.ea_BarCode = pSource.ea_BarCode;
      this.ea_GoodsSize = pSource.ea_GoodsSize;
      this.GoodsHistoryInfo = (GoodsHistoryView) null;
      if (pSource.GoodsHistoryInfo.gdh_StoreCode > 0)
        this.GoodsHistoryInfo.PutData(pSource.GoodsHistoryInfo);
      this.GoodsStoreInfo = (GoodsStoreInfoView) null;
      if (pSource.GoodsStoreInfo.gdsh_StoreCode > 0)
        this.GoodsStoreInfo.PutData(pSource.GoodsStoreInfo);
      this.mk_MakerName = pSource.mk_MakerName;
      this.br_BrandName = pSource.br_BrandName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
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
      this.Lt_History = (IList<GoodsHistoryView>) null;
      if (pSource.Lt_History.Count > 0)
      {
        foreach (GoodsHistoryView pSource1 in (IEnumerable<GoodsHistoryView>) pSource.Lt_History)
        {
          GoodsHistoryView goodsHistoryView = new GoodsHistoryView();
          goodsHistoryView.PutData(pSource1);
          this.Lt_History.Add(goodsHistoryView);
        }
      }
      this.Lt_OldBarcode = (IList<GoodsOldBarcodeView>) null;
      if (pSource.Lt_OldBarcode.Count > 0)
      {
        foreach (GoodsOldBarcodeView pSource2 in (IEnumerable<GoodsOldBarcodeView>) pSource.Lt_OldBarcode)
        {
          GoodsOldBarcodeView goodsOldBarcodeView = new GoodsOldBarcodeView();
          goodsOldBarcodeView.PutData(pSource2);
          this.Lt_OldBarcode.Add(goodsOldBarcodeView);
        }
      }
      this.Lt_GoodsPack = (IList<GoodsPackView>) null;
      if (pSource.Lt_GoodsPack.Count <= 0)
        return;
      foreach (GoodsPackView pSource3 in (IEnumerable<GoodsPackView>) pSource.Lt_GoodsPack)
      {
        GoodsPackView goodsPackView = new GoodsPackView();
        goodsPackView.PutData(pSource3);
        this.Lt_GoodsPack.Add(goodsPackView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gd_SiteID == 0L)
      {
        this.message = "싸이트(gd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.gd_GoodsName))
      {
        this.message = "상품명(gd_GoodsName)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (Enum2StrConverter.ToTaxDiv(this.gd_TaxDiv) == EnumTaxDiv.NONE)
      {
        this.message = "과면세(gd_TaxDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSalesUnit(this.gd_SalesUnit) == EnumSalesUnit.NONE)
      {
        this.message = "판매단위(gd_SalesUnit)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToStockUnit(this.gd_StockUnit) == EnumStockUnit.NONE)
      {
        this.message = "재고단위(gd_StockUnit)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToPackUnit(this.gd_PackUnit) == EnumPackUnit.NONE)
      {
        this.message = "묶음단위(gd_PackUnit)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gd_StorageDiv == 0)
      {
        this.message = "보관방법(gd_StorageDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.IsNew)
      {
        if (this.GoodsHistoryInfo.gdh_GoodsCategory == 0)
        {
          this.message = "소분류(gdh_GoodsCategory)  " + EnumDataCheck.CodeZero.ToDescription();
          return EnumDataCheck.CodeZero;
        }
        if (this.GoodsHistoryInfo.gdh_Supplier == 0)
        {
          this.message = "업체(gdh_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
          return EnumDataCheck.CodeZero;
        }
      }
      return EnumDataCheck.Success;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.gd_IsCreateBarCode && string.IsNullOrEmpty(this.gd_BarCode))
      {
        string empty = string.Empty;
        int nLen = 0;
        ProgOptionView progOptionInfo = Enum2StrConverter.ToProgOptionInfo(this.gd_SiteID, this.GoodsHistoryInfo.gdh_StoreCode, EnumOptionType.opt_StoreCodeLen);
        if (progOptionInfo != null)
          nLen = Convert.ToInt32(progOptionInfo.opt_Value);
        if (Enum2StrConverter.ToSalesUnit(this.gd_SalesUnit) == EnumSalesUnit.AMOUNT)
          this.gd_BarCode = string.Format("{0:000000}", (object) (Convert.ToInt32(this.MaxBarBCode(p_db, "20", this.gd_SiteID)) + 1));
        else if (nLen >= 6 && nLen != 13)
        {
          string str = this.MaxBarBCode(p_db, string.Empty, this.gd_SiteID);
          if (str.Length > nLen)
          {
            this.message = "상품바코드(gd_BarCode) 발번 에러 " + EnumDataCheck.Valid.ToDescription();
            return EnumDataCheck.Valid;
          }
          this.gd_BarCode = nLen != 6 ? string.Format("{0}", (object) (Convert.ToInt64(str) + 1L)).FillLeftZero(nLen) : (!str.Equals("199999") ? string.Format("{0:000000}", (object) (Convert.ToInt32(str) + 1)) : "300001");
        }
        else
          this.gd_BarCode = string.Format("{0}", (object) (Convert.ToInt64(this.MaxBarBCode(p_db, "22", this.gd_SiteID)) + 1L)).FillLeftZero(12).ToEanCheckDigit();
      }
      if (!string.IsNullOrEmpty(this.gd_BarCode))
      {
        IList<GoodsView> goodsViewList = p_db.Create<GoodsView>().SelectListE<GoodsView>((object) new Hashtable()
        {
          {
            (object) "gd_SiteID",
            (object) this.gd_SiteID
          },
          {
            (object) "_BarCodeALL_",
            (object) this.gd_BarCode
          }
        });
        if (goodsViewList != null && goodsViewList.Count > 0)
        {
          if (this.IsNew)
          {
            this.message = "상품바코드(gd_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsViewList[0].gd_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
            return EnumDataCheck.Exists;
          }
          if (this.IsUpdate)
          {
            foreach (GoodsView goodsView in (IEnumerable<GoodsView>) goodsViewList)
            {
              if (goodsView.gd_GoodsCode != this.gd_GoodsCode)
              {
                this.message = "상품바코드(gd_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsView.gd_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
                return EnumDataCheck.Exists;
              }
            }
          }
        }
      }
      return EnumDataCheck.Success;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsGoodsSave && !p_app_employee.IsGoodsSavePriceExcept)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public string MaxBarBCodeQuery(string p_barcode, long p_gd_SiteID)
    {
      if (p_barcode.Equals("20"))
        return "SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(gd_BarCode),'200000') AS code  FROM ( SELECT gd_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gd_BarCode)=6 AND gd_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_gd_SiteID) + " UNION ALL  SELECT gdob_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gdob_BarCode)=6 AND gdob_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_gd_SiteID) + ") MAIN";
      if (string.IsNullOrEmpty(p_barcode))
      {
        int num = 0;
        ProgOptionView progOptionInfo = Enum2StrConverter.ToProgOptionInfo(this.gd_SiteID, this.GoodsHistoryInfo.gdh_StoreCode, EnumOptionType.opt_StoreCodeLen);
        if (progOptionInfo != null)
          num = Convert.ToInt32(progOptionInfo.opt_Value);
        if (num >= 6)
          return "SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(gd_BarCode),'000000') AS code  FROM ( SELECT gd_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gd_BarCode)=6 AND SUBSTRING(gd_BarCode,1,2) != '20'" + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_gd_SiteID) + " UNION ALL  SELECT gdob_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gdob_BarCode)=6 AND SUBSTRING(gdob_BarCode,1,2) != '20'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_gd_SiteID) + ") MAIN";
        p_barcode = "22";
        return "SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(SUBSTRING(gd_BarCode,1,12)),'" + p_barcode + p_barcode.FillStr("0", 12 - p_barcode.Length) + "') AS code  FROM ( SELECT gd_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gd_BarCode)=13 AND gd_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_gd_SiteID) + " UNION ALL  SELECT gdob_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gdob_BarCode)=13 AND gdob_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_gd_SiteID) + ") MAIN";
      }
      p_barcode = "22";
      return "SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(SUBSTRING(gd_BarCode,1,12)),'" + p_barcode + p_barcode.FillStr("0", 12 - p_barcode.Length) + "') AS code  FROM ( SELECT gd_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gd_BarCode)=13 AND gd_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_gd_SiteID) + " UNION ALL  SELECT gdob_BarCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + DbQueryHelper.ToLen() + "(gdob_BarCode)=13 AND gdob_BarCode LIKE '" + p_barcode + "%'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_gd_SiteID) + ") MAIN";
    }

    public string MaxBarBCode(UniOleDatabase p_db, string p_barcode, long p_gd_SiteID)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string pSql = this.MaxBarBCodeQuery(p_barcode, p_gd_SiteID);
        if (!uniOleDbRecordset.Open(pSql))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return string.Empty;
        }
        return uniOleDbRecordset.IsDataRead() ? uniOleDbRecordset.GetFieldString(0) : string.Empty;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(gd_GoodsCode), 0)+1 AS gd_GoodsCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.gd_GoodsCode = uniOleDbRecordset.GetFieldLong(0);
        return this.gd_GoodsCode > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      GoodsView goodsView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(goodsView.CreateCodeQuery()))
        {
          goodsView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          goodsView.gd_GoodsCode = rs.GetFieldLong(0);
        return goodsView.gd_GoodsCode > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public bool InsertHistory(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      try
      {
        IList<StoreInfoView> storeInfoViewList = p_db.Create<StoreInfoView>().SelectListE<StoreInfoView>((object) new Hashtable()
        {
          {
            (object) "si_UseYn",
            (object) "Y"
          },
          {
            (object) "si_SiteID",
            (object) this.gd_SiteID
          }
        });
        DateTime firstDateOfMonth = DateTime.Now.ToFirstDateOfMonth();
        foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) storeInfoViewList)
        {
          GoodsHistoryView goodsHistoryView = p_db.Create<GoodsHistoryView>();
          goodsHistoryView.gdh_SiteID = (long) storeInfoView.si_StoreCode;
          goodsHistoryView.gdh_GoodsCode = this.gd_GoodsCode;
          goodsHistoryView.gdh_StartDate = new DateTime?(firstDateOfMonth);
          goodsHistoryView.gdh_EndDate = new DateTime?(new DateTime(2999, 12, 31));
          goodsHistoryView.gdh_SiteID = this.gd_SiteID;
          goodsHistoryView.gdh_GoodsCategory = this.GoodsHistoryInfo.gdh_GoodsCategory;
          goodsHistoryView.gdh_Supplier = this.GoodsHistoryInfo.gdh_Supplier;
          goodsHistoryView.gdh_ChargeRate = this.GoodsHistoryInfo.gdh_ChargeRate;
          goodsHistoryView.gdh_BuyCost = this.GoodsHistoryInfo.gdh_BuyCost;
          goodsHistoryView.gdh_BuyVat = this.GoodsHistoryInfo.gdh_BuyVat;
          goodsHistoryView.gdh_SalePrice = this.GoodsHistoryInfo.gdh_SalePrice;
          goodsHistoryView.gdh_EventCost = this.GoodsHistoryInfo.gdh_EventCost;
          goodsHistoryView.gdh_EventVat = this.GoodsHistoryInfo.gdh_EventVat;
          goodsHistoryView.gdh_EventPrice = this.GoodsHistoryInfo.gdh_EventPrice;
          goodsHistoryView.gdh_MemberPrice1 = this.GoodsHistoryInfo.gdh_MemberPrice1;
          goodsHistoryView.gdh_MemberPrice2 = this.GoodsHistoryInfo.gdh_MemberPrice2;
          goodsHistoryView.gdh_MemberPrice3 = this.GoodsHistoryInfo.gdh_MemberPrice3;
          goodsHistoryView.gdh_PointRate = this.GoodsHistoryInfo.gdh_PointRate;
          if (!goodsHistoryView.InsertData(p_db, p_app_employee, false))
            throw new Exception(goodsHistoryView.message);
        }
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

    public async Task<bool> InsertHistoryAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      GoodsView goodsView = this;
      try
      {
        IList<StoreInfoView> storeInfoViewList = p_db.Create<StoreInfoView>().SelectListE<StoreInfoView>((object) new Hashtable()
        {
          {
            (object) "si_UseYn",
            (object) "Y"
          },
          {
            (object) "si_SiteID",
            (object) goodsView.gd_SiteID
          }
        });
        DateTime dt_start = DateTime.Now.ToFirstDateOfMonth();
        foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) storeInfoViewList)
        {
          GoodsHistoryView history = p_db.Create<GoodsHistoryView>();
          history.gdh_SiteID = (long) storeInfoView.si_StoreCode;
          history.gdh_GoodsCode = goodsView.gd_GoodsCode;
          history.gdh_StartDate = new DateTime?(dt_start);
          history.gdh_EndDate = new DateTime?(new DateTime(2999, 12, 31));
          history.gdh_SiteID = goodsView.gd_SiteID;
          history.gdh_GoodsCategory = goodsView.GoodsHistoryInfo.gdh_GoodsCategory;
          history.gdh_Supplier = goodsView.GoodsHistoryInfo.gdh_Supplier;
          history.gdh_ChargeRate = goodsView.GoodsHistoryInfo.gdh_ChargeRate;
          history.gdh_BuyCost = goodsView.GoodsHistoryInfo.gdh_BuyCost;
          history.gdh_BuyVat = goodsView.GoodsHistoryInfo.gdh_BuyVat;
          history.gdh_SalePrice = goodsView.GoodsHistoryInfo.gdh_SalePrice;
          history.gdh_EventCost = goodsView.GoodsHistoryInfo.gdh_EventCost;
          history.gdh_EventVat = goodsView.GoodsHistoryInfo.gdh_EventVat;
          history.gdh_EventPrice = goodsView.GoodsHistoryInfo.gdh_EventPrice;
          history.gdh_MemberPrice1 = goodsView.GoodsHistoryInfo.gdh_MemberPrice1;
          history.gdh_MemberPrice2 = goodsView.GoodsHistoryInfo.gdh_MemberPrice2;
          history.gdh_MemberPrice3 = goodsView.GoodsHistoryInfo.gdh_MemberPrice3;
          history.gdh_PointRate = goodsView.GoodsHistoryInfo.gdh_PointRate;
          if (!await history.InsertDataAsync(p_db, p_app_employee, false))
            throw new Exception(history.message);
          history = (GoodsHistoryView) null;
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsView.message = ex.Message;
      }
      return false;
    }

    public bool InsertPack(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      try
      {
        if (this.Lt_GoodsPack.Count == 0)
          return true;
        int num = 0;
        foreach (GoodsPackView goodsPackView in (IEnumerable<GoodsPackView>) this.Lt_GoodsPack)
        {
          if (this.gd_TaxDiv != goodsPackView.EaInfo.gd_TaxDiv)
            throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 과면세 불일치");
          if (EnumPackUnit.EA != Enum2StrConverter.ToPackUnit(goodsPackView.EaInfo.gd_PackUnit))
            throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 안(포함) 상품 묶음단위 EA 만 가능.");
          num += goodsPackView.EaInfo.gd_Deposit;
          goodsPackView.gdp_GoodsCode = this.gd_GoodsCode;
          goodsPackView.gdp_SiteID = this.gd_SiteID;
          if (!goodsPackView.InsertData(p_db, p_app_employee, false))
            throw new Exception(goodsPackView.message);
        }
        if (this.gd_Deposit != num)
          throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 보증금 가격 불일치");
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

    public async Task<bool> InsertPackAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      GoodsView goodsView = this;
      try
      {
        if (goodsView.Lt_GoodsPack.Count == 0)
          return true;
        int sum_Deposit = 0;
        foreach (GoodsPackView item in (IEnumerable<GoodsPackView>) goodsView.Lt_GoodsPack)
        {
          if (goodsView.gd_TaxDiv != item.EaInfo.gd_TaxDiv)
            throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 과면세 불일치");
          if (EnumPackUnit.EA != Enum2StrConverter.ToPackUnit(item.EaInfo.gd_PackUnit))
            throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 안(포함) 상품 묶음단위 EA 만 가능.");
          sum_Deposit += item.EaInfo.gd_Deposit;
          item.gdp_GoodsCode = goodsView.gd_GoodsCode;
          item.gdp_SiteID = goodsView.gd_SiteID;
          if (!await item.InsertDataAsync(p_db, p_app_employee, false))
            throw new Exception(item.message);
        }
        if (goodsView.gd_Deposit != sum_Deposit)
          throw new Exception(TableCodeType.GoodsPack.ToDescription() + " 보증금 가격 불일치");
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsView.message = ex.Message;
      }
      return false;
    }

    public bool InsertOldBarcode(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      try
      {
        if (this.Lt_OldBarcode.Count == 0)
          return true;
        foreach (GoodsOldBarcodeView goodsOldBarcodeView in (IEnumerable<GoodsOldBarcodeView>) this.Lt_OldBarcode)
        {
          goodsOldBarcodeView.gdob_GoodsCode = this.gd_GoodsCode;
          goodsOldBarcodeView.gdob_SiteID = this.gd_SiteID;
          if (this.IsNew && !goodsOldBarcodeView.InsertData(p_db, p_app_employee, false))
            throw new Exception(goodsOldBarcodeView.message);
        }
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

    public async Task<bool> InsertOldBarcodeAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      GoodsView goodsView = this;
      try
      {
        if (goodsView.Lt_OldBarcode.Count == 0)
          return true;
        foreach (GoodsOldBarcodeView item in (IEnumerable<GoodsOldBarcodeView>) goodsView.Lt_OldBarcode)
        {
          item.gdob_GoodsCode = goodsView.gd_GoodsCode;
          item.gdob_SiteID = goodsView.gd_SiteID;
          if (goodsView.IsNew)
          {
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new Exception(item.message);
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsView.message = ex.Message;
      }
      return false;
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
          if (this.gd_SiteID == 0L)
            this.gd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.gd_GoodsCode == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertHistory(p_db, p_app_employee))
          throw new Exception(this.message);
        if (!this.InsertPack(p_db, p_app_employee))
          throw new Exception(this.message);
        if (!this.InsertOldBarcode(p_db, p_app_employee))
          throw new Exception(this.message);
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      GoodsView goodsView = this;
      try
      {
        goodsView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await goodsView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsView.gd_SiteID == 0L)
            goodsView.gd_SiteID = p_app_employee.emp_SiteID;
          if (!goodsView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (goodsView.gd_GoodsCode == 0L && !goodsView.CreateCode(p_db))
          throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsView.InsertAsync())
          throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 등록 오류");
        if (!await goodsView.InsertHistoryAsync(p_db, p_app_employee))
          throw new Exception(goodsView.message);
        if (!await goodsView.InsertPackAsync(p_db, p_app_employee))
          throw new Exception(goodsView.message);
        if (!await goodsView.InsertOldBarcodeAsync(p_db, p_app_employee))
          throw new Exception(goodsView.message);
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsView.db_status = 4;
        goodsView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsView.message = ex.Message;
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
        if (this.gd_GoodsCode == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 상품코드(gd_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertOldBarcode(p_db, p_app_employee))
          throw new Exception(this.message);
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      GoodsView goodsView = this;
      try
      {
        goodsView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsView.DataCheck(p_db))
            throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 권한 검사 실패");
        if (goodsView.gd_GoodsCode == 0L)
          throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 상품코드(gd_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsView.UpdateAsync())
          throw new UniServiceException(goodsView.message, goodsView.TableCode.ToDescription() + " 변경 오류");
        if (!await goodsView.InsertOldBarcodeAsync(p_db, p_app_employee))
          throw new Exception(goodsView.message);
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsView.db_status = 4;
        goodsView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.GoodsHistoryInfo.gdh_StoreCode = p_rs.GetFieldInt("gdh_StoreCode");
      this.GoodsHistoryInfo.gdh_GoodsCode = p_rs.GetFieldLong("gdh_GoodsCode");
      this.GoodsHistoryInfo.gdh_StartDate = p_rs.GetFieldDateTime("gdh_StartDate");
      this.GoodsHistoryInfo.gdh_EndDate = p_rs.GetFieldDateTime("gdh_EndDate");
      this.GoodsHistoryInfo.gdh_SiteID = p_rs.GetFieldLong("gdh_SiteID");
      this.GoodsHistoryInfo.gdh_GoodsCategory = p_rs.GetFieldInt("gdh_GoodsCategory");
      this.GoodsHistoryInfo.gdh_Supplier = p_rs.GetFieldInt("gdh_Supplier");
      this.GoodsHistoryInfo.gdh_ChargeRate = p_rs.GetFieldDouble("gdh_ChargeRate");
      this.GoodsHistoryInfo.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
      this.GoodsHistoryInfo.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
      this.GoodsHistoryInfo.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
      this.GoodsHistoryInfo.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
      this.GoodsHistoryInfo.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
      this.GoodsHistoryInfo.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
      this.GoodsHistoryInfo.gdh_MemberPrice1 = p_rs.GetFieldDouble("gdh_MemberPrice1");
      this.GoodsHistoryInfo.gdh_MemberPrice2 = p_rs.GetFieldDouble("gdh_MemberPrice2");
      this.GoodsHistoryInfo.gdh_MemberPrice3 = p_rs.GetFieldDouble("gdh_MemberPrice3");
      this.GoodsHistoryInfo.gdh_PointRate = p_rs.GetFieldDouble("gdh_PointRate");
      this.GoodsHistoryInfo.gdh_InDate = p_rs.GetFieldDateTime("gdh_InDate");
      this.GoodsHistoryInfo.gdh_InUser = p_rs.GetFieldInt("gdh_InUser");
      this.GoodsHistoryInfo.gdh_ModDate = p_rs.GetFieldDateTime("gdh_ModDate");
      this.GoodsHistoryInfo.gdh_ModUser = p_rs.GetFieldInt("gdh_ModUser");
      this.GoodsStoreInfo.gdsh_DeliveryDiv = p_rs.GetFieldInt("gdsh_DeliveryDiv");
      this.GoodsStoreInfo.gdsh_MinOrderUnit = p_rs.GetFieldDouble("gdsh_MinOrderUnit");
      this.GoodsStoreInfo.gdsh_MultiSuplierYn = p_rs.GetFieldString("gdsh_MultiSuplierYn");
      this.GoodsStoreInfo.gdsh_OrderEndDate = p_rs.GetFieldDateTime("gdsh_OrderEndDate");
      this.GoodsStoreInfo.gdsh_SaleEndDate = p_rs.GetFieldDateTime("gdsh_SaleEndDate");
      this.GoodsStoreInfo.gdsh_StorageStockQty = p_rs.GetFieldDouble("gdsh_StorageStockQty");
      this.GoodsHistoryInfo.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.GoodsHistoryInfo.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.GoodsHistoryInfo.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.GoodsHistoryInfo.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_Depth = 3;
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_ID = p_rs.GetFieldInt("dpt_lv3_ID");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_ViewCode = p_rs.GetFieldString("dpt_lv3_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_DeptName = p_rs.GetFieldString("dpt_lv3_Name");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
      this.GoodsHistoryInfo.CategoryInfo.ctg_Depth = 3;
      this.GoodsHistoryInfo.CategoryInfo.ctg_ID = p_rs.GetFieldInt("ctg_lv3_ID");
      this.GoodsHistoryInfo.CategoryInfo.ctg_ViewCode = p_rs.GetFieldString("ctg_lv3_ViewCode");
      this.GoodsHistoryInfo.CategoryInfo.ctg_CategoryName = p_rs.GetFieldString("ctg_lv3_Name");
      this.mk_MakerName = p_rs.GetFieldString("mk_MakerName");
      this.br_BrandName = p_rs.GetFieldString("br_BrandName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
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
      this.ea_GoodsCode = p_rs.GetFieldInt("ea_GoodsCode");
      this.ea_StockConvQty = p_rs.GetFieldDouble("ea_StockConvQty");
      this.ea_GoodsName = p_rs.GetFieldString("ea_GoodsName");
      this.ea_BarCode = p_rs.GetFieldString("ea_BarCode");
      this.ea_GoodsSize = p_rs.GetFieldString("ea_GoodsSize");
      this.gdob_BarCode = p_rs.GetFieldString("gdob_BarCode");
      this.gi_GoodsCode = (long) p_rs.GetFieldInt("gi_GoodsCode");
      this.gi_ImgType = p_rs.GetFieldInt("gi_ImgType");
      if (p_rs.IsFieldName("gi_ThumbData"))
      {
        if (this.gi_ThumbData != null)
          this.gi_ThumbData = (byte[]) null;
        this.gi_ThumbData = p_rs.GetFieldBytes("gi_ThumbData");
      }
      if (p_rs.IsFieldName("gi_OriginData"))
      {
        if (this.gi_OriginData != null)
          this.gi_OriginData = (byte[]) null;
        this.gi_OriginData = p_rs.GetFieldBytes("gi_OriginData");
      }
      return true;
    }

    public async Task<GoodsView> SelectOneAsync(
      long p_gd_GoodsCode,
      long p_gd_SiteID = 0,
      bool p_is_thumb_image = false,
      bool p_is_origin_image = false)
    {
      GoodsView goodsView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gd_GoodsCode",
          (object) p_gd_GoodsCode
        }
      };
      if (p_is_thumb_image)
        p_param.Add((object) "IS_THUMB_IMAGE_VIEW", (object) p_is_thumb_image);
      if (p_is_origin_image)
        p_param.Add((object) "IS_FILE_IMAGE_VIEW", (object) p_is_origin_image);
      if (p_gd_SiteID > 0L)
        p_param.Add((object) "gd_SiteID", (object) p_gd_SiteID);
      return await goodsView.SelectOneTAsync<GoodsView>((object) p_param);
    }

    public async Task<IList<GoodsView>> SelectListAsync(object p_param)
    {
      GoodsView goodsView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsView1.GetSelectQuery(p_param)))
        {
          goodsView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsView>) null;
        }
        IList<GoodsView> lt_list = (IList<GoodsView>) new List<GoodsView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsView goodsView2 = goodsView1.OleDB.Create<GoodsView>();
            if (goodsView2.GetFieldValues(rs))
            {
              goodsView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable)
      {
        DateTime? nullable = new DateTime?();
        if (hashtable.ContainsKey((object) "_DT_DATE_") && hashtable[(object) "_DT_DATE_"].ToString().Length > 0)
          nullable = new DateTime?(Convert.ToDateTime(hashtable[(object) "_DT_DATE_"].ToString()));
        if (hashtable.ContainsKey((object) "구바코드 포함 바코드") && hashtable[(object) "구바코드 포함 바코드"].ToString().Length > 0)
        {
          if (hashtable.ContainsKey((object) "구바코드 포함 유무") && Convert.ToBoolean(hashtable[(object) "구바코드 포함 유무"].ToString()))
          {
            stringBuilder.Append(" AND (gd_BarCode='" + hashtable[(object) "구바코드 포함 바코드"].ToString() + "'");
            stringBuilder.Append(" OR gdob_BarCode='" + hashtable[(object) "구바코드 포함 바코드"].ToString() + "'");
            stringBuilder.Append(")");
          }
          else
            stringBuilder.Append(" AND gd_BarCode='" + hashtable[(object) "구바코드 포함 바코드"].ToString() + "'");
        }
        bool flag1 = hashtable.ContainsKey((object) "gdsh_OrderEndDate_LIVE_") && Convert.ToBoolean(hashtable[(object) "gdsh_OrderEndDate_LIVE_"].ToString());
        bool flag2 = hashtable.ContainsKey((object) "gdsh_OrderEndDate_END_") && Convert.ToBoolean(hashtable[(object) "gdsh_OrderEndDate_END_"].ToString());
        if (!(flag1 & flag2))
        {
          if (flag1)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_OrderEndDate,'2999-12-31 23:59:59') > '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
          else if (flag2)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_OrderEndDate,'2999-12-31 23:59:59') < '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
        }
        if (hashtable.ContainsKey((object) "gdsh_SaleEndDate") && hashtable[(object) "gdsh_SaleEndDate"].ToString().Length > 0)
        {
          stringBuilder.Append(" AND gdsh_SaleEndDate >='" + new DateTime?((DateTime) hashtable[(object) "gdsh_SaleEndDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gdsh_SaleEndDate <='" + new DateTime?((DateTime) hashtable[(object) "gdsh_SaleEndDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        bool flag3 = hashtable.ContainsKey((object) "gdsh_SaleEndDate_LIVE_") && Convert.ToBoolean(hashtable[(object) "gdsh_SaleEndDate_LIVE_"].ToString());
        bool flag4 = hashtable.ContainsKey((object) "gdsh_SaleEndDate_END_") && Convert.ToBoolean(hashtable[(object) "gdsh_SaleEndDate_END_"].ToString());
        if (!(flag3 & flag4))
        {
          if (flag3)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_SaleEndDate,'2999-12-31 23:59:59') > '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
          else if (flag4)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_SaleEndDate,'2999-12-31 23:59:59') < '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
        }
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
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
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num1 = 0;
        long num2 = 0;
        int num3 = 0;
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gd_SiteID") && Convert.ToInt64(hashtable[(object) "gd_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "gd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            num3 = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "구바코드 포함 유무") && Convert.ToBoolean(hashtable[(object) "구바코드 포함 유무"].ToString()) || hashtable.ContainsKey((object) "구바코드 포함 바코드") && hashtable[(object) "구바코드 포함 바코드"].ToString().Length > 0)
            flag1 = true;
          if (hashtable.ContainsKey((object) "썸네일 이미지 포함 유무") && Convert.ToBoolean(hashtable[(object) "썸네일 이미지 포함 유무"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "썸네일 이미지 포함 유무"].ToString());
          if (hashtable.ContainsKey((object) "이미지 포함 유무") && Convert.ToBoolean(hashtable[(object) "이미지 포함 유무"].ToString()))
            flag3 = Convert.ToBoolean(hashtable[(object) "이미지 포함 유무"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num2);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) num2);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (num3 > 0)
        {
          stringBuilder.Append(",T_BOOKMARK_GOODS AS ( SELECT bgl_GoodsCode,bgl_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) num3));
          if (num2 > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) num2));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(",T_GOODS_IMAGE AS ( SELECT gi_GoodsCode,gi_SiteID,gi_ImgType");
        if (flag2)
          stringBuilder.Append(",gi_ThumbData");
        if (flag3)
          stringBuilder.Append(",gi_OriginData");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) TableCodeType.GoodsImage, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gi_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BOX_TO_EA AS (\n SELECT gdp_GoodsCode AS box_GoodsCode,gdp_SiteID AS box_SiteID,gdp_SubGoodsCode AS ea_GoodsCode,gdp_StockConvQty AS ea_StockConvQty,EA.gd_GoodsName AS ea_GoodsName,EA.gd_BarCode AS ea_BarCode,EA.gd_GoodsSize AS ea_GoodsSize" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} AS EA {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_SubGoodsCode=EA.gd_GoodsCode AND gdp_SiteID=EA.gd_SiteID" + string.Format("\n INNER JOIN {0}{1} AS BOX {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=BOX.gd_GoodsCode AND gdp_SiteID=BOX.gd_SiteID" + string.Format(" AND BOX.{0}>{1} AND BOX.{2}<{3}", (object) "gd_PackUnit", (object) 1, (object) "gd_PackUnit", (object) 4));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdp_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_MAKER AS (SELECT mk_MakerCode,mk_SiteID,mk_MakerName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Maker, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mk_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BRAND AS (SELECT br_BrandCode,br_SiteID,br_BrandName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Brand, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "br_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate,gdh_InDate,gdh_InUser,gdh_ModDate,gdh_ModUser\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n LEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
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
            p_param1.Add((object) "gdh_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_SiteID", (object) num2));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (flag1)
        {
          stringBuilder.Append(",T_OLD_BARCODE AS (SELECT gdob_GoodsCode,gdob_BarCode,gdob_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsOldBarcode, (object) DbQueryHelper.ToWithNolock()));
          if (num2 > 0L)
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdob_SiteID", (object) num2));
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(",T_STORE_GOODS AS (\nSELECT gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_StorageStockQty" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsStoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdsh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdsh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add((object) "gdsh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode_IN_"))
            p_param1.Add((object) "gdsh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add((object) "gdsh_GoodsCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdsh_SiteID"))
            p_param1.Add((object) "gdsh_SiteID", (object) num2);
          stringBuilder.Append(new GoodsStoreInfoView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdsh_SiteID", (object) num2));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PLS AS (\nSELECT pls_YyyyMm,pls_GoodsCode,pls_SiteID,SUM(pls_EndQty) AS pls_EndQty,AVG(pls_EndAvgCost) AS pls_EndAvgCost,SUM(pls_EndCostAmt) AS pls_EndCostAmt,SUM(pls_EndCostVatAmt) AS pls_EndCostVatAmt,SUM(pls_SaleQty) AS pls_SaleQty,SUM(pls_SaleAmt) AS pls_SaleAmt,SUM(pls_BuyQty) AS pls_BuyQty,SUM(pls_BuyCostAmt) AS pls_BuyCostAmt,SUM(pls_BuyCostVatAmt) AS pls_BuyCostVatAmt,SUM(pls_InnerMoveInQty) AS pls_InnerMoveInQty,SUM(pls_InnerMoveInCostAmt) AS pls_InnerMoveInCostAmt,SUM(pls_InnerMoveInCostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(pls_OuterMoveInQty) AS pls_OuterMoveInQty,SUM(pls_OuterMoveInCostAmt) AS pls_OuterMoveInCostAmt,SUM(pls_OuterMoveInCostVatAmt) AS pls_OuterMoveInCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "pls_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pls_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add((object) "pls_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add((object) "pls_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
          {
            int int32 = Convert.ToInt32(new DateTime?((DateTime) dictionaryEntry.Value).GetDateToStr("yyyyMM"));
            p_param1.Add((object) "pls_YyyyMm", (object) int32);
          }
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) num2));
        stringBuilder.Append("\n GROUP BY pls_YyyyMm,pls_GoodsCode,pls_SiteID");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT pls_YyyyMm,gdp_GoodsCode AS pls_GoodsCode,pls_SiteID,SUM(pls_EndQty/gdp_StockConvQty) AS pls_EndQty,AVG(pls_EndAvgCost) AS pls_EndAvgCost,SUM(pls_EndCostAmt/gdp_StockConvQty) AS pls_EndCostAmt,SUM(pls_EndCostVatAmt/gdp_StockConvQty) AS pls_EndCostVatAmt,SUM(pls_SaleQty/gdp_StockConvQty) AS pls_SaleQty,SUM(pls_SaleAmt/gdp_StockConvQty) AS pls_SaleAmt,SUM(pls_BuyQty/gdp_StockConvQty) AS pls_BuyQty,SUM(pls_BuyCostAmt/gdp_StockConvQty) AS pls_BuyCostAmt,SUM(pls_BuyCostVatAmt/gdp_StockConvQty) AS pls_BuyCostVatAmt,SUM(pls_InnerMoveInQty/gdp_StockConvQty) AS pls_InnerMoveInQty,SUM(pls_InnerMoveInCostAmt/gdp_StockConvQty) AS pls_InnerMoveInCostAmt,SUM(pls_InnerMoveInCostVatAmt/gdp_StockConvQty) AS pls_InnerMoveInCostVatAmt,SUM(pls_OuterMoveInQty/gdp_StockConvQty) AS pls_OuterMoveInQty,SUM(pls_OuterMoveInCostAmt/gdp_StockConvQty) AS pls_OuterMoveInCostAmt,SUM(pls_OuterMoveInCostVatAmt/gdp_StockConvQty) AS pls_OuterMoveInCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + " ON pls_GoodsCode=gdp_SubGoodsCode AND gdp_StockConvQty>0");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gd_SiteID"))
            p_param1.Add((object) "pls_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pls_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add((object) "pls_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
          {
            int int32 = Convert.ToInt32(new DateTime?((DateTime) dictionaryEntry.Value).GetDateToStr("yyyyMM"));
            p_param1.Add((object) "pls_YyyyMm", (object) int32);
          }
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) num2));
        stringBuilder.Append("\n GROUP BY pls_YyyyMm,gdp_GoodsCode,pls_SiteID");
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_AbcValue,gd_StorageDiv,gd_EachDeliveryYn,gd_VolumeTotal,gd_VolumeUnit,gd_VolumeUnitText,gd_AddedProperty,gd_Memo,gd_ErpCode,gd_ExCode,gd_UseYn,gd_InDate,gd_InUser,gd_ModDate,gd_ModUser,gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate,gdh_InDate,gdh_InUser,gdh_ModDate,gdh_ModUser\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_StorageStockQty\n,si_StoreName\n,su_SupplierName,su_SupplierViewCode,su_SupplierType\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name\n,mk_MakerName,br_BrandName\n,inEmpName,modEmpName\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt\n,ea_GoodsCode,ea_StockConvQty,ea_GoodsName,ea_BarCode,ea_GoodsSize," + (flag1 ? "gdob_BarCode" : "''") + " AS gdob_BarCode\n,gi_GoodsCode,gi_ImgType");
        if (flag2)
          stringBuilder.Append(",gi_ThumbData");
        if (flag3)
          stringBuilder.Append(",gi_OriginData");
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON gd_GoodsCode=gdh_GoodsCode AND gd_SiteID=gdh_SiteID\n INNER JOIN T_STORE ON gdh_StoreCode=si_StoreCode AND gdh_SiteID=si_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND gdh_SiteID=su_SiteID\n LEFT OUTER JOIN T_MAKER ON gd_MakerCode=mk_MakerCode AND gd_SiteID=mk_SiteID\n LEFT OUTER JOIN T_BRAND ON gd_BrandCode=br_BrandCode AND gd_SiteID=br_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON gd_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON gd_ModUser=emp_CodeMod\n LEFT OUTER JOIN T_STORE_GOODS ON gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID\n LEFT OUTER JOIN T_PLS ON gd_GoodsCode=pls_GoodsCode AND gd_SiteID=pls_SiteID\n LEFT OUTER JOIN T_GOODS_IMAGE ON gd_GoodsCode=gi_GoodsCode AND gd_SiteID=gi_SiteID\n LEFT OUTER JOIN T_BOX_TO_EA ON gd_GoodsCode=box_GoodsCode AND gd_SiteID=box_SiteID");
        if (flag1)
          stringBuilder.Append("\n LEFT OUTER JOIN T_OLD_BARCODE ON gd_GoodsCode=gdob_GoodsCode AND gd_SiteID=gdob_SiteID");
        if (num3 > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (num1 <= 0)
        {
          if (!string.IsNullOrEmpty(empty))
            stringBuilder.Append(" ORDER BY " + empty);
          else
            stringBuilder.Append(" ORDER BY gd_GoodsCode");
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
