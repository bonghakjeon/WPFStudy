// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList.BookmarkGoodsListView
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
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList
{
  public class BookmarkGoodsListView : TBookmarkGoodsList<BookmarkGoodsListView>
  {
    private BookmarkGoodsGroupView _HeaderInfo;
    private GoodsView _GoodsInfo;
    private string _inEmpName;
    private string _modEmpName;
    private double _pls_EndQty;
    private double _pls_EndAvgCost;
    private double _pls_EndCostAmt;
    private double _pls_EndCostVatAmt;
    private double _pls_SaleQty;
    private double _pls_SaleAmt;
    private double _pls_BuyQty;
    private double _pls_BuyCostAmt;
    private double _pls_BuyCostVatAmt;
    private long _gdp_SubGoodsCode;
    private double _gdp_StockConvQty;

    [JsonPropertyName("headerInfo")]
    public BookmarkGoodsGroupView HeaderInfo
    {
      get => this._HeaderInfo ?? (this._HeaderInfo = new BookmarkGoodsGroupView());
      set
      {
        this._HeaderInfo = value;
        this.Changed(nameof (HeaderInfo));
      }
    }

    [JsonPropertyName("goodsInfo")]
    public GoodsView GoodsInfo
    {
      get => this._GoodsInfo ?? (this._GoodsInfo = new GoodsView());
      set
      {
        this._GoodsInfo = value;
        this.Changed(nameof (GoodsInfo));
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

    public long gdp_SubGoodsCode
    {
      get => this._gdp_SubGoodsCode;
      set
      {
        this._gdp_SubGoodsCode = value;
        this.Changed(nameof (gdp_SubGoodsCode));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("bgg_GroupID", new TTableColumn()
      {
        tc_orgin_name = "bgg_GroupID",
        tc_trans_name = "관심상품그룹",
        tc_col_status = 1
      });
      columnInfo.Add("bgg_GroupName", new TTableColumn()
      {
        tc_orgin_name = "bgg_GroupName",
        tc_trans_name = "관심상품그룹명",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드",
        tc_col_status = 1
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
      });
      columnInfo.Add("pls_EndQty", new TTableColumn()
      {
        tc_orgin_name = "pls_EndQty",
        tc_trans_name = "수량",
        tc_col_status = 1
      });
      columnInfo.Add("pls_EndAvgCost", new TTableColumn()
      {
        tc_orgin_name = "pls_EndAvgCost",
        tc_trans_name = "평균원가",
        tc_col_status = 1
      });
      columnInfo.Add("pls_EndCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndCostAmt",
        tc_trans_name = "원가금액",
        tc_col_status = 1
      });
      columnInfo.Add("pls_EndCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndCostVatAmt",
        tc_trans_name = "부가세",
        tc_col_status = 1
      });
      columnInfo.Add("pls_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleQty",
        tc_trans_name = "수량",
        tc_col_status = 1
      });
      columnInfo.Add("pls_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleAmt",
        tc_trans_name = "매출액",
        tc_col_status = 1
      });
      columnInfo.Add("pls_BuyQty", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyQty",
        tc_trans_name = "수량",
        tc_col_status = 1
      });
      columnInfo.Add("pls_BuyCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyCostAmt",
        tc_trans_name = "세제외금액",
        tc_col_status = 1
      });
      columnInfo.Add("pls_BuyCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyCostVatAmt",
        tc_trans_name = "부가세",
        tc_col_status = 1
      });
      columnInfo.Add("gd_GoodsName", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsName",
        tc_trans_name = "상품명"
      });
      columnInfo.Add("gd_BarCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BarCode",
        tc_trans_name = "상품바코드",
        tc_col_status = 1
      });
      columnInfo.Add("gd_GoodsSize", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsSize",
        tc_trans_name = "규격",
        tc_col_status = 1
      });
      columnInfo.Add("gd_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "gd_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51,
        tc_col_status = 1
      });
      columnInfo.Add("gd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gd_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
      });
      columnInfo.Add("gd_PackUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_PackUnit",
        tc_trans_name = "묶음단위",
        tc_comm_code = 54,
        tc_col_status = 1
      });
      columnInfo.Add("gd_Deposit", new TTableColumn()
      {
        tc_orgin_name = "gd_Deposit",
        tc_trans_name = "보증금",
        tc_col_status = 1
      });
      columnInfo.Add("gd_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52,
        tc_col_status = 1
      });
      columnInfo.Add("gd_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53,
        tc_col_status = 1
      });
      columnInfo.Add("gd_StockConvQty", new TTableColumn()
      {
        tc_orgin_name = "gd_StockConvQty",
        tc_trans_name = "재고환산수량",
        tc_col_status = 1
      });
      columnInfo.Add("gd_BoxGoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BoxGoodsCode",
        tc_trans_name = "박스코드",
        tc_col_status = 1
      });
      columnInfo.Add("gd_BoxPackQty", new TTableColumn()
      {
        tc_orgin_name = "gd_BoxPackQty",
        tc_trans_name = "박스입수",
        tc_col_status = 1
      });
      columnInfo.Add("gd_MinOrderUnit", new TTableColumn()
      {
        tc_orgin_name = "gd_MinOrderUnit",
        tc_trans_name = "최소발주량",
        tc_col_status = 1
      });
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
      columnInfo.Add("ctg_ViewCodeAll", new TTableColumn()
      {
        tc_orgin_name = "ctg_ViewCodeAll",
        tc_trans_name = "분류 코드",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_CategoryName", new TTableColumn()
      {
        tc_orgin_name = "ctg_CategoryName",
        tc_trans_name = "소분류명",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_ViewCode",
        tc_trans_name = "소분류코드",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierViewCode", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierViewCode",
        tc_trans_name = "식별코드",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40,
        tc_col_status = 1
      });
      columnInfo.Add("gd_MakerCode", new TTableColumn()
      {
        tc_orgin_name = "gd_MakerCode",
        tc_trans_name = "제조사코드",
        tc_col_status = 1
      });
      columnInfo.Add("gd_BrandCode", new TTableColumn()
      {
        tc_orgin_name = "gd_BrandCode",
        tc_trans_name = "브랜드코드",
        tc_col_status = 1
      });
      columnInfo.Add("gdsh_DeliveryDiv", new TTableColumn()
      {
        tc_orgin_name = "gdsh_DeliveryDiv",
        tc_trans_name = "배송 구분",
        tc_comm_code = 60,
        tc_col_status = 1
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
      columnInfo.Add("gdp_SubGoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdp_SubGoodsCode",
        tc_trans_name = "구성 상품",
        tc_col_status = 1
      });
      columnInfo.Add("gdp_StockConvQty", new TTableColumn()
      {
        tc_orgin_name = "gdp_StockConvQty",
        tc_trans_name = "구성 입수량",
        tc_col_status = 1
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원"
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.HeaderInfo = (BookmarkGoodsGroupView) null;
      this.GoodsInfo = (GoodsView) null;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.pls_EndQty = this.pls_EndAvgCost = this.pls_EndCostAmt = this.pls_EndCostVatAmt = 0.0;
      this.pls_SaleQty = this.pls_SaleAmt = 0.0;
      this.pls_BuyQty = this.pls_BuyCostAmt = this.pls_BuyCostVatAmt = 0.0;
      this.gdp_SubGoodsCode = 0L;
      this.gdp_StockConvQty = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new BookmarkGoodsListView();

    public override object Clone()
    {
      BookmarkGoodsListView bookmarkGoodsListView = base.Clone() as BookmarkGoodsListView;
      bookmarkGoodsListView.HeaderInfo = (BookmarkGoodsGroupView) null;
      if (this.HeaderInfo.bgg_GroupID > 0)
        bookmarkGoodsListView.HeaderInfo = this.HeaderInfo;
      bookmarkGoodsListView.GoodsInfo = (GoodsView) null;
      if (this.GoodsInfo.gd_GoodsCode > 0L)
        bookmarkGoodsListView.GoodsInfo = this.GoodsInfo;
      bookmarkGoodsListView.inEmpName = this.inEmpName;
      bookmarkGoodsListView.modEmpName = this.modEmpName;
      bookmarkGoodsListView.pls_EndQty = this.pls_EndQty;
      bookmarkGoodsListView.pls_EndAvgCost = this.pls_EndAvgCost;
      bookmarkGoodsListView.pls_EndCostAmt = this.pls_EndCostAmt;
      bookmarkGoodsListView.pls_EndCostVatAmt = this.pls_EndCostVatAmt;
      bookmarkGoodsListView.pls_SaleQty = this.pls_SaleQty;
      bookmarkGoodsListView.pls_SaleAmt = this.pls_SaleAmt;
      bookmarkGoodsListView.pls_BuyQty = this.pls_BuyQty;
      bookmarkGoodsListView.pls_BuyCostAmt = this.pls_BuyCostAmt;
      bookmarkGoodsListView.pls_BuyCostVatAmt = this.pls_BuyCostVatAmt;
      bookmarkGoodsListView.gdp_SubGoodsCode = this.gdp_SubGoodsCode;
      bookmarkGoodsListView.gdp_StockConvQty = this.gdp_StockConvQty;
      return (object) bookmarkGoodsListView;
    }

    public void PutData(BookmarkGoodsListView pSource)
    {
      this.PutData((TBookmarkGoodsList) pSource);
      this.HeaderInfo = (BookmarkGoodsGroupView) null;
      if (pSource.HeaderInfo.bgg_GroupID > 0)
        this.HeaderInfo.PutData(pSource.HeaderInfo);
      this.GoodsInfo = (GoodsView) null;
      if (pSource.GoodsInfo.gd_GoodsCode > 0L)
        this.GoodsInfo.PutData(pSource.GoodsInfo);
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
      this.gdp_SubGoodsCode = pSource.gdp_SubGoodsCode;
      this.gdp_StockConvQty = pSource.gdp_StockConvQty;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.bgl_SiteID == 0L)
      {
        this.message = "싸이트(bgl_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.bgl_GroupID == 0)
      {
        this.message = "관심상품그룹(bgl_GroupID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.bgl_GoodsCode != 0L)
        return EnumDataCheck.Success;
      this.message = "관심상품코드(bgl_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
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
      IList<BookmarkGoodsListView> bookmarkGoodsListViewList = p_db.Create<BookmarkGoodsListView>().SelectListE<BookmarkGoodsListView>((object) new Hashtable()
      {
        {
          (object) "bgl_SiteID",
          (object) this.bgl_SiteID
        },
        {
          (object) "bgl_GroupID",
          (object) this.bgl_GroupID
        },
        {
          (object) "bgl_GoodsCode",
          (object) this.bgl_GoodsCode
        }
      });
      if (this.IsNew)
      {
        if (bookmarkGoodsListViewList != null && bookmarkGoodsListViewList.Count > 0)
        {
          this.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + bookmarkGoodsListViewList[0].GoodsInfo?.gd_GoodsName + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
          return EnumDataCheck.Exists;
        }
      }
      else if (this.IsUpdate)
      {
        if (bookmarkGoodsListViewList == null && bookmarkGoodsListViewList.Count == 0)
        {
          this.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.NULL.ToDescription();
          return EnumDataCheck.NULL;
        }
        if (bookmarkGoodsListViewList.Count > 1)
        {
          this.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.Exists.ToDescription();
          return EnumDataCheck.Exists;
        }
      }
      return EnumDataCheck.Success;
    }

    protected override async Task<EnumDataCheck> DataCheckAsync(UniOleDatabase p_db)
    {
      BookmarkGoodsListView bookmarkGoodsListView = this;
      EnumDataCheck enumDataCheck = bookmarkGoodsListView.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        bookmarkGoodsListView.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      IList<BookmarkGoodsListView> bookmarkGoodsListViewList = await p_db.Create<BookmarkGoodsListView>().SelectListAsync((object) new Hashtable()
      {
        {
          (object) "bgl_SiteID",
          (object) bookmarkGoodsListView.bgl_SiteID
        },
        {
          (object) "bgl_GroupID",
          (object) bookmarkGoodsListView.bgl_GroupID
        },
        {
          (object) "bgl_GoodsCode",
          (object) bookmarkGoodsListView.bgl_GoodsCode
        }
      });
      if (bookmarkGoodsListView.IsNew)
      {
        if (bookmarkGoodsListViewList != null && bookmarkGoodsListViewList.Count > 0)
        {
          bookmarkGoodsListView.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + bookmarkGoodsListViewList[0].GoodsInfo?.gd_GoodsName + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
          return EnumDataCheck.Exists;
        }
      }
      else if (bookmarkGoodsListView.IsUpdate)
      {
        if (bookmarkGoodsListViewList == null && bookmarkGoodsListViewList.Count == 0)
        {
          bookmarkGoodsListView.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.NULL.ToDescription();
          return EnumDataCheck.NULL;
        }
        if (bookmarkGoodsListViewList.Count > 1)
        {
          bookmarkGoodsListView.message = "관심상품코드(bgl_GoodsCode) " + EnumDataCheck.Exists.ToDescription();
          return EnumDataCheck.Exists;
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
      if (!p_app_employee.IsMasterCommonSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
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
          if (this.bgl_SiteID == 0L)
            this.bgl_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
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
      BookmarkGoodsListView bookmarkGoodsListView = this;
      try
      {
        bookmarkGoodsListView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await bookmarkGoodsListView.DataCheckAsync(p_db))
            throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (bookmarkGoodsListView.bgl_SiteID == 0L)
            bookmarkGoodsListView.bgl_SiteID = p_app_employee.emp_SiteID;
          if (!bookmarkGoodsListView.IsPermit(p_app_employee))
            throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsListView.InsertAsync())
          throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsListView.db_status = 4;
        bookmarkGoodsListView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.Message;
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
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
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
      BookmarkGoodsListView bookmarkGoodsListView = this;
      try
      {
        bookmarkGoodsListView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await bookmarkGoodsListView.DataCheckAsync(p_db))
            throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!bookmarkGoodsListView.IsPermit(p_app_employee))
          throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsListView.UpdateAsync())
          throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsListView.db_status = 4;
        bookmarkGoodsListView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.Message;
      }
      return false;
    }

    public override bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
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

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      BookmarkGoodsListView bookmarkGoodsListView = this;
      try
      {
        bookmarkGoodsListView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await bookmarkGoodsListView.DataCheckAsync(p_db))
            throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!bookmarkGoodsListView.IsPermit(p_app_employee))
          throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsListView.DeleteAsync())
          throw new UniServiceException(bookmarkGoodsListView.message, bookmarkGoodsListView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsListView.db_status = 4;
        bookmarkGoodsListView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsListView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.GoodsInfo.GoodsHistoryInfo.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.GoodsInfo.GoodsHistoryInfo.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.GoodsInfo.GoodsHistoryInfo.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.GoodsInfo.GoodsHistoryInfo.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.GoodsInfo.GoodsHistoryInfo.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.GoodsInfo.GoodsHistoryInfo.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.GoodsInfo.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.GoodsInfo.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
      this.GoodsInfo.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
      this.GoodsInfo.gd_TaxDiv = p_rs.GetFieldInt("gd_TaxDiv");
      this.GoodsInfo.gd_MakerCode = p_rs.GetFieldInt("gd_MakerCode");
      this.GoodsInfo.gd_BrandCode = p_rs.GetFieldInt("gd_BrandCode");
      this.GoodsInfo.gd_BoxGoodsCode = p_rs.GetFieldLong("gd_BoxGoodsCode");
      this.GoodsInfo.gd_BoxPackQty = p_rs.GetFieldDouble("gd_BoxPackQty");
      this.GoodsInfo.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
      this.GoodsInfo.gd_SalesUnit = p_rs.GetFieldInt("gd_SalesUnit");
      this.GoodsInfo.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
      this.GoodsInfo.gd_StockUnit = p_rs.GetFieldInt("gd_StockUnit");
      this.GoodsInfo.gd_StockConvQty = p_rs.GetFieldDouble("gd_StockConvQty");
      this.GoodsInfo.gd_PackUnit = p_rs.GetFieldInt("gd_PackUnit");
      this.GoodsInfo.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
      this.GoodsInfo.GoodsHistoryInfo.gdh_StoreCode = p_rs.GetFieldInt("gdh_StoreCode");
      this.GoodsInfo.GoodsHistoryInfo.gdh_StartDate = p_rs.GetFieldDateTime("gdh_StartDate");
      this.GoodsInfo.GoodsHistoryInfo.gdh_EndDate = p_rs.GetFieldDateTime("gdh_EndDate");
      this.GoodsInfo.GoodsHistoryInfo.gdh_SiteID = this.bgl_SiteID;
      this.GoodsInfo.GoodsHistoryInfo.gdh_ChargeRate = p_rs.GetFieldDouble("gdh_ChargeRate");
      this.GoodsInfo.GoodsHistoryInfo.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
      this.GoodsInfo.GoodsHistoryInfo.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
      this.GoodsInfo.GoodsHistoryInfo.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
      this.GoodsInfo.GoodsHistoryInfo.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
      this.GoodsInfo.GoodsHistoryInfo.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
      this.GoodsInfo.GoodsHistoryInfo.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
      this.GoodsInfo.GoodsHistoryInfo.gdh_MemberPrice1 = p_rs.GetFieldDouble("gdh_MemberPrice1");
      this.GoodsInfo.GoodsHistoryInfo.gdh_MemberPrice2 = p_rs.GetFieldDouble("gdh_MemberPrice2");
      this.GoodsInfo.GoodsHistoryInfo.gdh_MemberPrice3 = p_rs.GetFieldDouble("gdh_MemberPrice3");
      this.GoodsInfo.GoodsHistoryInfo.gdh_GoodsCategory = p_rs.GetFieldInt("gdh_GoodsCategory");
      this.GoodsInfo.GoodsHistoryInfo.gdh_Supplier = p_rs.GetFieldInt("gdh_Supplier");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
      this.GoodsInfo.GoodsHistoryInfo.CategoryInfo.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
      this.GoodsInfo.GoodsStoreInfo.gdsh_DeliveryDiv = p_rs.GetFieldInt("gdsh_DeliveryDiv");
      this.GoodsInfo.GoodsStoreInfo.gdsh_MinOrderUnit = p_rs.GetFieldDouble("gdsh_MinOrderUnit");
      this.GoodsInfo.GoodsStoreInfo.gdsh_MultiSuplierYn = p_rs.GetFieldString("gdsh_MultiSuplierYn");
      this.GoodsInfo.GoodsStoreInfo.gdsh_OrderEndDate = p_rs.GetFieldDateTime("gdsh_OrderEndDate");
      this.GoodsInfo.GoodsStoreInfo.gdsh_SaleEndDate = p_rs.GetFieldDateTime("gdsh_SaleEndDate");
      this.pls_EndQty = p_rs.GetFieldDouble("pls_EndQty");
      this.pls_EndAvgCost = p_rs.GetFieldDouble("pls_EndAvgCost");
      this.pls_EndCostAmt = p_rs.GetFieldDouble("pls_EndCostAmt");
      this.pls_SaleQty = p_rs.GetFieldDouble("pls_SaleQty");
      this.pls_SaleAmt = p_rs.GetFieldDouble("pls_SaleAmt");
      this.pls_BuyQty = p_rs.GetFieldDouble("pls_BuyQty");
      this.pls_BuyCostAmt = p_rs.GetFieldDouble("pls_BuyCostAmt");
      this.pls_BuyCostVatAmt = p_rs.GetFieldDouble("pls_BuyCostVatAmt");
      this.gdp_SubGoodsCode = p_rs.GetFieldLong("gdp_SubGoodsCode");
      this.gdp_StockConvQty = p_rs.GetFieldDouble("gdp_StockConvQty");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<BookmarkGoodsListView> SelectOneAsync(
      int p_bgl_GroupID,
      long p_bgl_GoodsCode,
      long p_bgl_SiteID = 0)
    {
      BookmarkGoodsListView bookmarkGoodsListView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "bgl_GroupID",
          (object) p_bgl_GroupID
        },
        {
          (object) "bgl_GoodsCode",
          (object) p_bgl_GoodsCode
        }
      };
      if (p_bgl_SiteID > 0L)
        p_param.Add((object) "bgl_SiteID", (object) p_bgl_SiteID);
      return await bookmarkGoodsListView.SelectOneTAsync<BookmarkGoodsListView>((object) p_param);
    }

    public async Task<IList<BookmarkGoodsListView>> SelectListAsync(object p_param)
    {
      BookmarkGoodsListView bookmarkGoodsListView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(bookmarkGoodsListView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, bookmarkGoodsListView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(bookmarkGoodsListView1.GetSelectQuery(p_param)))
        {
          bookmarkGoodsListView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + bookmarkGoodsListView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<BookmarkGoodsListView>) null;
        }
        IList<BookmarkGoodsListView> lt_list = (IList<BookmarkGoodsListView>) new List<BookmarkGoodsListView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            BookmarkGoodsListView bookmarkGoodsListView2 = bookmarkGoodsListView1.OleDB.Create<BookmarkGoodsListView>();
            if (bookmarkGoodsListView2.GetFieldValues(rs))
            {
              bookmarkGoodsListView2.row_number = lt_list.Count + 1;
              lt_list.Add(bookmarkGoodsListView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + bookmarkGoodsListView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_InUser", hashtable[(object) "emp_Code"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        long num1 = 0;
        int num2 = 0;
        DateTime now = DateTime.Now;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "bgl_SiteID") && Convert.ToInt64(hashtable[(object) "bgl_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "bgl_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("bgl_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num1);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("bgl_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) num1);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HEADER AS (SELECT bgg_GroupID,bgg_SiteID,bgg_GroupName,bgg_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsGroup, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("bgl_SiteID"))
            p_param1.Add((object) "bgg_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("bgl_GroupID"))
            p_param1.Add((object) "bgg_GroupID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("bgg_UseYn"))
            p_param1.Add((object) "bgg_UseYn", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("emp_Code"))
            p_param1.Add((object) "emp_Code", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "bgg_SiteID"))
            p_param1.Add((object) "bgg_SiteID", (object) num1);
          stringBuilder.Append(new TBookmarkGoodsGroup().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "bgg_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_DETAIL_GOODS AS (SELECT bgl_GoodsCode,bgl_SiteID FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("bgl_SiteID"))
            p_param1.Add((object) "bgl_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("bgl_GroupID"))
            p_param1.Add((object) "bgl_GroupID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("emp_Code"))
            p_param1.Add((object) "bgl_InUser", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TBookmarkGoodsList().GetSelectWhereAnd((object) p_param1));
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "bgl_SiteID", (object) num1));
        stringBuilder.Append("\nGROUP BY bgl_GoodsCode,bgl_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_SiteID,gdp_StockConvQty" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format(" INNER JOIN {0}{1} {2} ON {3}={4} AND {5}={6} AND {7}!={8}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock(), (object) "gdp_GoodsCode", (object) "gd_GoodsCode", (object) "gdp_SiteID", (object) "gd_SiteID", (object) "gd_PackUnit", (object) 4) + " INNER JOIN T_DETAIL_GOODS ON gdp_GoodsCode=bgl_GoodsCode AND gdp_SiteID=bgl_SiteID");
        if (num1 > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_SiteID", (object) num1));
          stringBuilder.Append(" AND gdp_StockConvQty>0");
        }
        else
          stringBuilder.Append(" WHERE gdp_StockConvQty>0");
        stringBuilder.Append("\n");
        stringBuilder.Append(" UNION ALL SELECT gd_GoodsCode,gd_GoodsCode,gd_SiteID,1 AS gdp_StockConvQty" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " INNER JOIN T_DETAIL_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        if (num1 > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1));
        }
        else
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_PackUnit", (object) 1));
        stringBuilder.Append("\n");
        stringBuilder.Append(" UNION ALL SELECT gd_GoodsCode,gd_GoodsCode,gd_SiteID,1 AS gdp_StockConvQty" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " INNER JOIN T_DETAIL_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        if (num1 > 0L)
        {
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4));
        }
        else
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_PackUnit", (object) 4));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_GOODS AS (\nSELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_UseYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_GOOD_CODE ON gd_GoodsCode=gdp_GoodsCode");
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_GOODS ON gdh_GoodsCode=gd_GoodsCode AND gdh_SiteID=gd_SiteID");
        stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_StoreCode", (object) num2));
        stringBuilder.Append("\n AND gdh_StartDate<='" + new DateTime?(now).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append("\n AND gdh_EndDate>='" + new DateTime?(now).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n AND {0}={1}", (object) "gdh_SiteID", (object) num1));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE_GOODS AS (\nSELECT gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_StorageStockQty" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsStoreInfo, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_GOODS ON gdsh_GoodsCode=gd_GoodsCode AND gdsh_SiteID=gd_SiteID");
        stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdsh_StoreCode", (object) num2));
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n AND {0}={1}", (object) "gdsh_SiteID", (object) num1));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PLS AS (\nSELECT pls_YyyyMm,pls_StoreCode,gdp_GoodsCode AS pls_GoodsCode,pls_SiteID,pls_EndQty/gdp_StockConvQty AS pls_EndQty,pls_EndAvgCost,pls_EndCostAmt/gdp_StockConvQty AS pls_EndCostAmt,pls_EndCostVatAmt/gdp_StockConvQty AS pls_EndCostVatAmt,pls_SaleQty/gdp_StockConvQty AS pls_SaleQty,pls_SaleAmt/gdp_StockConvQty AS pls_SaleAmt,pls_BuyQty/gdp_StockConvQty AS pls_BuyQty,pls_BuyCostAmt/gdp_StockConvQty AS pls_BuyCostAmt,pls_BuyCostVatAmt/gdp_StockConvQty AS pls_BuyCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_GOOD_CODE ON pls_GoodsCode=gdp_SubGoodsCode AND pls_SiteID=gdp_SiteID");
        stringBuilder.Append("\n WHERE pls_YyyyMm=" + new DateTime?(now).GetDateToStr("yyyyMM"));
        stringBuilder.Append(string.Format("\n AND {0}={1}", (object) "pls_StoreCode", (object) num2));
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n AND {0}={1}", (object) "pls_SiteID", (object) num1));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  bgl_GroupID,bgl_GoodsCode,bgl_SiteID,bgl_UseYn,bgl_InDate,bgl_InUser,bgl_ModDate,bgl_ModUser\n,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_BoxGoodsCode,gd_BoxPackQty,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_StockConvQty,gd_PackUnit,gd_UseYn\n,gdh_StoreCode,gdh_StartDate,gdh_EndDate,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_GoodsCategory,gdh_Supplier\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_lv3_ViewCode AS ctg_ViewCode,ctg_lv3_Name AS ctg_CategoryName\n,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderEndDate,gdsh_SaleEndDate\n,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_SaleQty,pls_SaleAmt,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt\n,gdp_SubGoodsCode,gdp_StockConvQty,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HEADER ON bgl_GroupID=bgg_GroupID AND bgl_SiteID=bgg_SiteID" + string.Format("\n INNER JOIN T_STORE ON si_StoreCode={0}", (object) num2) + "\n LEFT OUTER JOIN T_GOODS ON bgl_GoodsCode=gd_GoodsCode AND bgl_SiteID=gd_SiteID\n LEFT OUTER JOIN T_GOOD_CODE ON bgl_GoodsCode=gdp_GoodsCode\n LEFT OUTER JOIN T_HISTORY ON si_StoreCode=gdh_StoreCode AND bgl_GoodsCode=gdh_GoodsCode AND '" + new DateTime?(now).GetDateToStr("yyyy-MM-dd 00:00:00") + "'>= gdh_StartDate AND '" + new DateTime?(now).GetDateToStr("yyyy-MM-dd 23:59:59") + "'<= gdh_EndDate AND bgl_SiteID=gdh_SiteID\n LEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND bgl_SiteID=view_category_v1.ctg_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND bgl_SiteID=su_SiteID" + string.Format("\n LEFT OUTER JOIN T_STORE_GOODS ON {0}={1} AND {2}={3}", (object) "gd_GoodsCode", (object) "gdsh_GoodsCode", (object) "gdsh_StoreCode", (object) num2) + string.Format("\n LEFT OUTER JOIN T_PLS ON {0}={1} AND {2}={3}", (object) "pls_StoreCode", (object) num2, (object) "bgl_GoodsCode", (object) "pls_GoodsCode") + " AND bgl_SiteID=pls_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON bgl_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON bgl_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
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
