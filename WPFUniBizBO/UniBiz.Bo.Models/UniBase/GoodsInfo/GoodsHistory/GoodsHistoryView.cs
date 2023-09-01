// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory.GoodsHistoryView
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory
{
  public class GoodsHistoryView : TGoodsHistory<GoodsHistoryView>
  {
    private string _arrStrStoreCode;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private CategoryView _CategoryInfo;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private int _gd_TaxDiv;
    private int _gd_SalesUnit;
    private int _gd_StockUnit;
    private int _gd_PackUnit;
    private double _gd_MinOrderUnit;
    private int _gd_Deposit;
    private string _gd_UseYn;
    private int _gd_MakerCode;
    private int _gd_BrandCode;
    private string _mk_MakerName;
    private string _br_BrandName;
    private long _link_StdGoodsCode;
    private string _inEmpName;
    private string _modEmpName;

    public string arrStrStoreCode
    {
      get => this._arrStrStoreCode ?? (this._arrStrStoreCode = string.Empty);
      set
      {
        this._arrStrStoreCode = value;
        this.Changed(nameof (arrStrStoreCode));
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
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

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
        this.Changed("su_SupplierTypeDesc");
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    [JsonPropertyName("categoryInfo")]
    public CategoryView CategoryInfo
    {
      get => this._CategoryInfo ?? (this._CategoryInfo = new CategoryView());
      set
      {
        this._CategoryInfo = value;
        this.Changed(nameof (CategoryInfo));
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

    public string gd_UseYn
    {
      get => this._gd_UseYn;
      set
      {
        this._gd_UseYn = value;
        this.Changed(nameof (gd_UseYn));
        this.Changed("gd_IsUseYn");
        this.Changed("gd_UseYnDesc");
      }
    }

    public bool gd_IsUseYn => "Y".Equals(this.gd_UseYn);

    public string gd_UseYnDesc => !"Y".Equals(this.gd_UseYn) ? "미사용" : "사용";

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

    public long link_StdGoodsCode
    {
      get => this._link_StdGoodsCode;
      set
      {
        this._link_StdGoodsCode = value;
        this.Changed(nameof (link_StdGoodsCode));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
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
      this.CategoryInfo = (CategoryView) null;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.su_SupplierType = 0;
      this.su_SupplierName = string.Empty;
      this.su_SupplierViewCode = string.Empty;
      this.gd_GoodsName = string.Empty;
      this.gd_BarCode = string.Empty;
      this.gd_GoodsSize = string.Empty;
      this.gd_UseYn = "Y";
      this.gd_TaxDiv = this.gd_PackUnit = this.gd_SalesUnit = this.gd_Deposit = 0;
      this.gd_MakerCode = this.gd_BrandCode = 0;
      this.mk_MakerName = string.Empty;
      this.br_BrandName = string.Empty;
      this.link_StdGoodsCode = 0L;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsHistoryView();

    public override object Clone()
    {
      GoodsHistoryView goodsHistoryView = base.Clone() as GoodsHistoryView;
      goodsHistoryView.si_StoreName = this.si_StoreName;
      goodsHistoryView.si_StoreViewCode = this.si_StoreViewCode;
      goodsHistoryView.si_UseYn = this.si_UseYn;
      goodsHistoryView.su_SupplierType = this.su_SupplierType;
      goodsHistoryView.su_SupplierName = this.su_SupplierName;
      goodsHistoryView.su_SupplierViewCode = this.su_SupplierViewCode;
      goodsHistoryView.CategoryInfo = (CategoryView) null;
      if (this.CategoryInfo.ctg_ID > 0)
        goodsHistoryView.CategoryInfo = this.CategoryInfo;
      goodsHistoryView.gd_GoodsName = this.gd_GoodsName;
      goodsHistoryView.gd_BarCode = this.gd_BarCode;
      goodsHistoryView.gd_GoodsSize = this.gd_GoodsSize;
      goodsHistoryView.gd_TaxDiv = this.gd_TaxDiv;
      goodsHistoryView.gd_PackUnit = this.gd_PackUnit;
      goodsHistoryView.gd_SalesUnit = this.gd_SalesUnit;
      goodsHistoryView.gd_Deposit = this.gd_Deposit;
      goodsHistoryView.gd_UseYn = this.gd_UseYn;
      goodsHistoryView.gd_MakerCode = this.gd_MakerCode;
      goodsHistoryView.gd_BrandCode = this.gd_BrandCode;
      goodsHistoryView.mk_MakerName = this.mk_MakerName;
      goodsHistoryView.br_BrandName = this.br_BrandName;
      goodsHistoryView.inEmpName = this.inEmpName;
      goodsHistoryView.modEmpName = this.modEmpName;
      return (object) goodsHistoryView;
    }

    public void PutData(GoodsHistoryView pSource)
    {
      this.PutData((TGoodsHistory) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.CategoryInfo = (CategoryView) null;
      if (pSource.CategoryInfo.ctg_ID > 0)
        this.CategoryInfo.PutData(pSource.CategoryInfo);
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_TaxDiv = pSource.gd_TaxDiv;
      this.gd_PackUnit = pSource.gd_PackUnit;
      this.gd_SalesUnit = pSource.gd_SalesUnit;
      this.gd_Deposit = pSource.gd_Deposit;
      this.gd_UseYn = pSource.gd_UseYn;
      this.gd_MakerCode = pSource.gd_MakerCode;
      this.gd_BrandCode = pSource.gd_BrandCode;
      this.mk_MakerName = pSource.mk_MakerName;
      this.br_BrandName = pSource.br_BrandName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gdh_SiteID == 0L)
      {
        this.message = "싸이트(gdh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdh_StoreCode == 0)
      {
        this.message = "지점코드(gdh_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdh_GoodsCode == 0L)
      {
        this.message = "상품코드(gdh_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.gdh_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(gdh_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.gdh_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(gdh_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.gdh_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.gdh_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 <= intFormat2)
        return EnumDataCheck.Success;
      this.message = "시작일(gdh_StartDate) > 종료일(gdh_EndDate)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsGoodsSave)
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
          if (this.gdh_SiteID == 0L)
            this.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
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
      GoodsHistoryView goodsHistoryView = this;
      try
      {
        goodsHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView.gdh_SiteID == 0L)
            goodsHistoryView.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await goodsHistoryView.InsertAsync())
          throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 등록 오류");
        goodsHistoryView.db_status = 4;
        goodsHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView.message = ex.Message;
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
      GoodsHistoryView goodsHistoryView = this;
      try
      {
        goodsHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await goodsHistoryView.UpdateAsync())
          throw new UniServiceException(goodsHistoryView.message, goodsHistoryView.TableCode.ToDescription() + " 변경 오류");
        goodsHistoryView.db_status = 4;
        goodsHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
      this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
      this.gd_TaxDiv = p_rs.GetFieldInt("gd_TaxDiv");
      this.gd_MakerCode = p_rs.GetFieldInt("gd_MakerCode");
      this.gd_BrandCode = p_rs.GetFieldInt("gd_BrandCode");
      this.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
      this.gd_SalesUnit = p_rs.GetFieldInt("gd_SalesUnit");
      this.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
      this.gd_StockUnit = p_rs.GetFieldInt("gd_StockUnit");
      this.gd_PackUnit = p_rs.GetFieldInt("gd_PackUnit");
      this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.CategoryInfo.DeptInfo.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.CategoryInfo.DeptInfo.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.CategoryInfo.DeptInfo.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.CategoryInfo.DeptInfo.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.CategoryInfo.DeptInfo.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.CategoryInfo.DeptInfo.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.CategoryInfo.DeptInfo.dpt_Depth = 3;
      this.CategoryInfo.DeptInfo.dpt_ID = p_rs.GetFieldInt("dpt_lv3_ID");
      this.CategoryInfo.DeptInfo.dpt_ViewCode = p_rs.GetFieldString("dpt_lv3_ViewCode");
      this.CategoryInfo.DeptInfo.dpt_DeptName = p_rs.GetFieldString("dpt_lv3_Name");
      this.CategoryInfo.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
      this.CategoryInfo.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
      this.CategoryInfo.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
      this.CategoryInfo.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
      this.CategoryInfo.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
      this.CategoryInfo.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
      this.CategoryInfo.ctg_Depth = 3;
      this.CategoryInfo.ctg_ID = this.gdh_GoodsCategory;
      this.CategoryInfo.ctg_ViewCode = p_rs.GetFieldString("ctg_lv3_ViewCode");
      this.CategoryInfo.ctg_CategoryName = p_rs.GetFieldString("ctg_lv3_Name");
      this.link_StdGoodsCode = p_rs.GetFieldLong("link_StdGoodsCode");
      this.mk_MakerName = p_rs.GetFieldString("mk_MakerName");
      this.br_BrandName = p_rs.GetFieldString("br_BrandName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GoodsHistoryView> SelectOneAsync(
      int p_gdh_StoreCode,
      long p_gdh_GoodsCode,
      DateTime p_gdh_StartDate,
      long p_gdh_SiteID = 0)
    {
      GoodsHistoryView goodsHistoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gdh_StoreCode",
          (object) p_gdh_StoreCode
        },
        {
          (object) "gdh_GoodsCode",
          (object) p_gdh_GoodsCode
        },
        {
          (object) "gdh_StartDate",
          (object) p_gdh_StartDate
        }
      };
      if (p_gdh_SiteID > 0L)
        p_param.Add((object) "gdh_SiteID", (object) p_gdh_SiteID);
      return await goodsHistoryView.SelectOneTAsync<GoodsHistoryView>((object) p_param);
    }

    public async Task<IList<GoodsHistoryView>> SelectListAsync(object p_param)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsHistoryView1.GetSelectQuery(p_param)))
        {
          goodsHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsHistoryView>) null;
        }
        IList<GoodsHistoryView> lt_list = (IList<GoodsHistoryView>) new List<GoodsHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsHistoryView goodsHistoryView2 = goodsHistoryView1.OleDB.Create<GoodsHistoryView>();
            if (goodsHistoryView2.GetFieldValues(rs))
            {
              goodsHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "gd_BarCode") && hashtable[(object) "gd_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_BarCode", hashtable[(object) "gd_BarCode"]));
        if (hashtable.ContainsKey((object) "dpt_lv1_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv1_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_lv1_ID", hashtable[(object) "dpt_lv1_ID"]));
        if (hashtable.ContainsKey((object) "dpt_lv2_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv2_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_lv2_ID", hashtable[(object) "dpt_lv2_ID"]));
        if (hashtable.ContainsKey((object) "dpt_lv3_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv3_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND dept_code={0}", hashtable[(object) "dpt_lv3_ID"]));
        if (hashtable.ContainsKey((object) "ctg_lv1_ID") && Convert.ToInt32(hashtable[(object) "ctg_lv1_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_lv1_ID", hashtable[(object) "ctg_lv1_ID"]));
        else if (hashtable.ContainsKey((object) "ctg_lv1_ID_IN_") && hashtable[(object) "ctg_lv1_ID_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ctg_lv1_ID", hashtable[(object) "ctg_lv1_ID_IN_"]));
        if (hashtable.ContainsKey((object) "ctg_lv2_ID") && Convert.ToInt32(hashtable[(object) "ctg_lv2_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_lv2_ID", hashtable[(object) "ctg_lv2_ID"]));
        else if (hashtable.ContainsKey((object) "ctg_lv2_ID_IN_") && hashtable[(object) "ctg_lv2_ID_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ctg_lv2_ID", hashtable[(object) "ctg_lv2_ID_IN_"]));
        if (hashtable.ContainsKey((object) "ctg_lv3_ID") && Convert.ToInt32(hashtable[(object) "ctg_lv3_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_GoodsCategory", hashtable[(object) "ctg_lv3_ID"]));
        else if (hashtable.ContainsKey((object) "ctg_lv3_ID_IN_") && hashtable[(object) "ctg_lv3_ID_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_GoodsCategory", hashtable[(object) "ctg_lv3_ID_IN_"]));
        if (hashtable.ContainsKey((object) "su_SupplierType") && hashtable[(object) "su_SupplierType"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SupplierType", hashtable[(object) "su_SupplierType"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gd_GoodsName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gd_BarCode", hashtable[(object) "_KEY_WORD_"]));
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
        long num4 = 0;
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
          if (hashtable.ContainsKey((object) "gdh_SiteID") && Convert.ToInt64(hashtable[(object) "gdh_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "gdh_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            num3 = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_LinkStdGoodsCode_") && Convert.ToInt64(hashtable[(object) "_LinkStdGoodsCode_"].ToString()) > 0L)
            num4 = Convert.ToInt64(hashtable[(object) "_LinkStdGoodsCode_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdh_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
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
          if (dictionaryEntry.Key.ToString().Equals("gdh_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
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
        if (num4 > 0L)
        {
          stringBuilder.Append(",T_LINK_GOODS AS (\nSELECT gdp_GoodsCode AS link_GoodsCode" + string.Format(",{0} AS {1}", (object) num4, (object) "link_StdGoodsCode") + ",gdp_SiteID AS link_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()));
          if (num2 > 0L)
          {
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_SiteID", (object) num2));
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdp_SubGoodsCode", (object) num4));
          }
          else
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_SubGoodsCode", (object) num4));
          stringBuilder.Append("\n");
          stringBuilder.Append(" UNION ALL SELECT gdp_SubGoodsCode AS link_GoodsCode" + string.Format(",{0} AS {1}", (object) num4, (object) "link_StdGoodsCode") + ",gdp_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()));
          if (num2 > 0L)
          {
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_SiteID", (object) num2));
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdp_GoodsCode", (object) num4));
          }
          else
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdp_GoodsCode", (object) num4));
          stringBuilder.Append("\n");
          stringBuilder.Append(" UNION ALL SELECT gd_GoodsCode AS link_GoodsCode" + string.Format(",{0} AS {1}", (object) num4, (object) "link_StdGoodsCode") + ",gd_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
          if (num2 > 0L)
          {
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num2));
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_GoodsCode", (object) num4));
          }
          else
            stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_GoodsCode", (object) num4));
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
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
        stringBuilder.Append(",T_GOODS AS (SELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_PackUnit,gd_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (num3 > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdh_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add((object) "gd_MakerCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add((object) "gd_MakerCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add((object) "gd_BrandCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add((object) "gd_BrandCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_PackUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_AbcValue"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_UseYn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num2);
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_SiteID,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate,gdh_InDate,gdh_InUser,gdh_ModDate,gdh_ModUser,si_StoreName,si_UseYn,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_MakerCode,gd_BrandCode,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_PackUnit,gd_UseYn,su_SupplierName,su_SupplierViewCode,su_SupplierType,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_lv3_ViewCode,ctg_lv3_Name," + (num4 > 0L ? string.Empty : "0") + " AS link_StdGoodsCode,mk_MakerName,br_BrandName,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON gdh_StoreCode=si_StoreCode AND gdh_SiteID=si_SiteID\n INNER JOIN T_GOODS ON gdh_GoodsCode=gd_GoodsCode AND gdh_SiteID=gd_SiteID\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND gdh_SiteID=su_SiteID\n LEFT OUTER JOIN T_MAKER ON gd_MakerCode=mk_MakerCode AND gdh_SiteID=mk_SiteID\n LEFT OUTER JOIN T_BRAND ON gd_BrandCode=br_BrandCode AND gdh_SiteID=br_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON gdh_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON gdh_ModUser=emp_CodeMod");
        if (num4 > 0L)
          stringBuilder.Append("\n INNER JOIN T_LINK_GOODS ON gdh_GoodsCode=link_GoodsCode AND gdh_SiteID=link_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (num1 > 0)
        {
          switch (num1)
          {
            case 1:
              stringBuilder.Append(" ORDER BY gdh_StoreCode,gdh_GoodsCode,gdh_StartDate DESC");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY gdh_StoreCode,gdh_GoodsCode,gdh_StartDate");
              break;
            case 3:
              stringBuilder.Append(" ORDER BY gdh_GoodsCode,gdh_StoreCode,gdh_StartDate DESC");
              break;
            case 4:
              stringBuilder.Append(" ORDER BY gdh_GoodsCode,gdh_StoreCode,gdh_StartDate");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gdh_StoreCode,gdh_GoodsCode,gdh_StartDate");
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

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      try
      {
        goodsHistoryView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView1.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView1.gdh_SiteID == 0L)
            goodsHistoryView1.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(goodsHistoryView1.gdh_SiteID))
        {
          logs.dml_CodeInt = goodsHistoryView1.gdh_StoreCode;
          logs.dml_CodeLong = goodsHistoryView1.gdh_GoodsCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) goodsHistoryView1.gdh_StoreCode, (object) goodsHistoryView1.gdh_GoodsCode, (object) goodsHistoryView1.IntStartDate, (object) goodsHistoryView1.gdh_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(goodsHistoryView1.arrStrStoreCode))
          goodsHistoryView1.arrStrStoreCode = goodsHistoryView1.gdh_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_START_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        Hashtable hashtable1 = param;
        DateTime? nullable1 = goodsHistoryView1.gdh_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_END_DATE_", (object) local1);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> infos = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        GoodsHistoryByStoreDic dic_Store = new GoodsHistoryByStoreDic();
        dic_Store.AddRange((IEnumerable<GoodsHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        Hashtable hashtable2 = param;
        nullable1 = goodsHistoryView1.gdh_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_DATE_", (object) local2);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        foreach (GoodsHistoryView goodsHistoryView2 in (IEnumerable<GoodsHistoryView>) await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param))
        {
          GoodsHistoryView item = goodsHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store[item.gdh_StoreCode] != null && dic_Store[item.gdh_StoreCode].Count != 0)
          {
            logs.Init(p_login_employee, goodsHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            double num1 = item.gdh_BuyCost;
            if (!num1.Equals(goodsHistoryView1.gdh_BuyCost))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_BuyCost", "매입원가", item.gdh_BuyCost, goodsHistoryView1.gdh_BuyCost));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_SalePrice;
            if (!num1.Equals(goodsHistoryView1.gdh_SalePrice))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_SalePrice", "판매가", item.gdh_SalePrice, goodsHistoryView1.gdh_SalePrice));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_EventCost;
            if (!num1.Equals(goodsHistoryView1.gdh_EventCost))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_EventCost", "행사원가", item.gdh_EventCost, goodsHistoryView1.gdh_EventCost));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_EventPrice;
            if (!num1.Equals(goodsHistoryView1.gdh_EventPrice))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_EventPrice", "행사판매가", item.gdh_EventPrice, goodsHistoryView1.gdh_EventPrice));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_MemberPrice1;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice1))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice1", "회원가", item.gdh_MemberPrice1, goodsHistoryView1.gdh_MemberPrice1));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_MemberPrice2;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice2))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice2", "회원가2", item.gdh_MemberPrice2, goodsHistoryView1.gdh_MemberPrice2));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_MemberPrice3;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice3))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice3", "회원가3", item.gdh_MemberPrice3, goodsHistoryView1.gdh_MemberPrice3));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.gdh_GoodsCategory.Equals(goodsHistoryView1.gdh_GoodsCategory))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_GoodsCategory", "소분류", item.gdh_GoodsCategory, goodsHistoryView1.gdh_GoodsCategory));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.gdh_Supplier.Equals(goodsHistoryView1.gdh_Supplier))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_Supplier", "업체", item.gdh_Supplier, goodsHistoryView1.gdh_Supplier));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_PointRate;
            if (!num1.Equals(goodsHistoryView1.gdh_PointRate))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_PointRate", "회원특별적립율", item.gdh_PointRate, goodsHistoryView1.gdh_PointRate));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.gdh_StartDate = goodsHistoryView1.gdh_StartDate;
            item.gdh_EndDate = goodsHistoryView1.gdh_EndDate;
            item.gdh_BuyCost = goodsHistoryView1.gdh_BuyCost;
            item.gdh_BuyVat = item.gd_IsTax ? goodsHistoryView1.gdh_BuyCost.ToCostVat() : 0.0;
            item.gdh_SalePrice = goodsHistoryView1.gdh_SalePrice;
            if (Enum2StrConverter.IsSupplierTypeDirect(item.su_SupplierType))
            {
              if (Enum2StrConverter.ToSalesUnit(goodsHistoryView1.gd_SalesUnit) == EnumSalesUnit.AMOUNT)
              {
                if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
                else if (goodsHistoryView1.gd_IsTax)
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice - goodsHistoryView1.gdh_SalePrice.ToPriceVat());
                else
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice);
              }
            }
            else if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
              item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
            else if (goodsHistoryView1.gd_IsTax)
              item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice - goodsHistoryView1.gdh_SalePrice.ToPriceVat());
            else
              item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice);
            item.gdh_EventCost = goodsHistoryView1.gdh_EventCost;
            item.gdh_EventVat = goodsHistoryView1.gdh_EventVat;
            item.gdh_EventPrice = goodsHistoryView1.gdh_EventPrice;
            item.gdh_MemberPrice1 = goodsHistoryView1.gdh_MemberPrice1;
            item.gdh_MemberPrice2 = goodsHistoryView1.gdh_MemberPrice2;
            item.gdh_MemberPrice3 = goodsHistoryView1.gdh_MemberPrice3;
            item.gdh_GoodsCategory = goodsHistoryView1.gdh_GoodsCategory;
            item.gdh_Supplier = goodsHistoryView1.gdh_Supplier;
            item.gdh_PointRate = goodsHistoryView1.gdh_PointRate;
            item.gdh_InUser = p_app_employee.emp_Code;
            item.gdh_ModUser = p_app_employee.emp_Code;
            foreach (GoodsHistoryView history in dic_Store[item.gdh_StoreCode])
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (!await history.DeleteAsync())
                  throw new Exception(history.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView next_data = p_db.Create<GoodsHistoryView>();
                next_data.PutData(history);
                GoodsHistoryView goodsHistoryView3 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView3.gdh_EndDate = nullable2;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                GoodsHistoryView goodsHistoryView4 = next_data;
                nullable1 = item.gdh_EndDate;
                DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                goodsHistoryView4.gdh_StartDate = nullable3;
                next_data.gdh_SiteID = goodsHistoryView1.gdh_SiteID;
                next_data = await next_data.InsertAsync() ? (GoodsHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView5 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView5.gdh_EndDate = nullable4;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView6 = history;
                int gdhStoreCode = history.gdh_StoreCode;
                long gdhGoodsCode = history.gdh_GoodsCode;
                nullable1 = history.gdh_StartDate;
                DateTime p_gdh_StartDate = nullable1.Value;
                nullable1 = item.gdh_EndDate;
                DateTime dateAdd = nullable1.Value.GetDateAdd(0, 0, 1);
                long gdhSiteId = history.gdh_SiteID;
                if (!await goodsHistoryView6.UpdateStartDateAsync(gdhStoreCode, gdhGoodsCode, p_gdh_StartDate, dateAdd, gdhSiteId))
                  throw new Exception(history.message);
              }
            }
            if (!await item.InsertAsync())
              throw new Exception(item.message);
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num2 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (GoodsHistoryView) null;
          }
        }
        goodsHistoryView1.db_status = 4;
        goodsHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView1.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterPriceDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      try
      {
        goodsHistoryView1.SetAdoDatabase(p_db);
        goodsHistoryView1.gdh_EndDate = new DateTime?(new DateTime(2999, 12, 31));
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView1.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView1.gdh_SiteID == 0L)
            goodsHistoryView1.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(goodsHistoryView1.gdh_SiteID))
        {
          logs.dml_CodeInt = goodsHistoryView1.gdh_StoreCode;
          logs.dml_CodeLong = goodsHistoryView1.gdh_GoodsCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) goodsHistoryView1.gdh_StoreCode, (object) goodsHistoryView1.gdh_GoodsCode, (object) goodsHistoryView1.IntStartDate, (object) goodsHistoryView1.gdh_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(goodsHistoryView1.arrStrStoreCode))
          goodsHistoryView1.arrStrStoreCode = goodsHistoryView1.gdh_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_START_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        param.Add((object) "_DT_END_DATE_", (object) goodsHistoryView1.gdh_EndDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> infos = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        GoodsHistoryByStoreDic dic_Store = new GoodsHistoryByStoreDic();
        dic_Store.AddRange((IEnumerable<GoodsHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        foreach (GoodsHistoryView goodsHistoryView2 in (IEnumerable<GoodsHistoryView>) await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param))
        {
          GoodsHistoryView item = goodsHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store[item.gdh_StoreCode] != null && dic_Store[item.gdh_StoreCode].Count != 0)
          {
            logs.Init(p_login_employee, goodsHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            double num1 = item.gdh_BuyCost;
            if (!num1.Equals(goodsHistoryView1.gdh_BuyCost))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_BuyCost", "매입원가", item.gdh_BuyCost, goodsHistoryView1.gdh_BuyCost));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_SalePrice;
            if (!num1.Equals(goodsHistoryView1.gdh_SalePrice))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_SalePrice", "판매가", item.gdh_SalePrice, goodsHistoryView1.gdh_SalePrice));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.gdh_StartDate = goodsHistoryView1.gdh_StartDate;
            item.gdh_EndDate = goodsHistoryView1.gdh_EndDate;
            item.gdh_BuyCost = goodsHistoryView1.gdh_BuyCost;
            item.gdh_BuyVat = item.gd_IsTax ? goodsHistoryView1.gdh_BuyCost.ToCostVat() : 0.0;
            item.gdh_SalePrice = goodsHistoryView1.gdh_SalePrice;
            if (Enum2StrConverter.IsSupplierTypeDirect(item.su_SupplierType))
            {
              if (Enum2StrConverter.ToSalesUnit(goodsHistoryView1.gd_SalesUnit) == EnumSalesUnit.AMOUNT)
              {
                if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
                else if (goodsHistoryView1.gd_IsTax)
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice - goodsHistoryView1.gdh_SalePrice.ToPriceVat());
                else
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice);
              }
            }
            else if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
              item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
            else if (goodsHistoryView1.gd_IsTax)
              item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice - goodsHistoryView1.gdh_SalePrice.ToPriceVat());
            else
              item.gdh_ChargeRate = goodsHistoryView1.gdh_BuyCost.ToSaleMargin(goodsHistoryView1.gdh_SalePrice);
            item.gdh_EventCost = 0.0;
            item.gdh_EventVat = 0.0;
            item.gdh_EventPrice = 0.0;
            item.gdh_MemberPrice1 = 0.0;
            item.gdh_MemberPrice2 = 0.0;
            item.gdh_MemberPrice3 = 0.0;
            item.gdh_InUser = p_app_employee.emp_Code;
            item.gdh_ModUser = p_app_employee.emp_Code;
            foreach (GoodsHistoryView history in dic_Store[item.gdh_StoreCode])
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (!await history.DeleteAsync())
                  throw new Exception(history.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView next_data = p_db.Create<GoodsHistoryView>();
                next_data.PutData(history);
                history.gdh_EndDate = new DateTime?(item.gdh_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                next_data.gdh_StartDate = new DateTime?(item.gdh_EndDate.Value.GetDateAdd(0, 0, 1));
                next_data.gdh_SiteID = goodsHistoryView1.gdh_SiteID;
                next_data = await next_data.InsertAsync() ? (GoodsHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                history.gdh_EndDate = new DateTime?(item.gdh_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView3 = history;
                int gdhStoreCode = history.gdh_StoreCode;
                long gdhGoodsCode = history.gdh_GoodsCode;
                DateTime? nullable = history.gdh_StartDate;
                DateTime p_gdh_StartDate = nullable.Value;
                nullable = item.gdh_EndDate;
                DateTime dateAdd = nullable.Value.GetDateAdd(0, 0, 1);
                long gdhSiteId = history.gdh_SiteID;
                if (!await goodsHistoryView3.UpdateStartDateAsync(gdhStoreCode, gdhGoodsCode, p_gdh_StartDate, dateAdd, gdhSiteId))
                  throw new Exception(history.message);
              }
            }
            if (!await item.InsertAsync())
              throw new Exception(item.message);
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num2 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (GoodsHistoryView) null;
          }
        }
        goodsHistoryView1.db_status = 4;
        goodsHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView1.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterEventPriceDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      try
      {
        goodsHistoryView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView1.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView1.gdh_SiteID == 0L)
            goodsHistoryView1.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(goodsHistoryView1.gdh_SiteID))
        {
          logs.dml_CodeInt = goodsHistoryView1.gdh_StoreCode;
          logs.dml_CodeLong = goodsHistoryView1.gdh_GoodsCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) goodsHistoryView1.gdh_StoreCode, (object) goodsHistoryView1.gdh_GoodsCode, (object) goodsHistoryView1.IntStartDate, (object) goodsHistoryView1.gdh_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(goodsHistoryView1.arrStrStoreCode))
          goodsHistoryView1.arrStrStoreCode = goodsHistoryView1.gdh_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_START_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        Hashtable hashtable1 = param;
        DateTime? nullable1 = goodsHistoryView1.gdh_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_END_DATE_", (object) local1);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> infos = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        GoodsHistoryByStoreDic dic_Store = new GoodsHistoryByStoreDic();
        dic_Store.AddRange((IEnumerable<GoodsHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        Hashtable hashtable2 = param;
        nullable1 = goodsHistoryView1.gdh_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_DATE_", (object) local2);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> goodsHistoryViewList = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        List<GoodsHistoryView> lt_event_insert = new List<GoodsHistoryView>();
        GoodsHistoryView event_origin = (GoodsHistoryView) null;
        GoodsHistoryView event_origin_end = (GoodsHistoryView) null;
        foreach (GoodsHistoryView goodsHistoryView2 in (IEnumerable<GoodsHistoryView>) goodsHistoryViewList)
        {
          GoodsHistoryView item = goodsHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store[item.gdh_StoreCode] != null && dic_Store[item.gdh_StoreCode].Count != 0)
          {
            logs.Init(p_login_employee, goodsHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            double num1 = item.gdh_EventCost;
            if (!num1.Equals(goodsHistoryView1.gdh_EventCost))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_EventCost", "행사원가", item.gdh_EventCost, goodsHistoryView1.gdh_EventCost));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_EventPrice;
            if (!num1.Equals(goodsHistoryView1.gdh_EventPrice))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_EventPrice", "행사판매가", item.gdh_EventPrice, goodsHistoryView1.gdh_EventPrice));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.gdh_StartDate = goodsHistoryView1.gdh_StartDate;
            item.gdh_EndDate = goodsHistoryView1.gdh_EndDate;
            item.gdh_EventCost = goodsHistoryView1.gdh_EventCost;
            item.gdh_EventVat = item.gd_IsTax ? goodsHistoryView1.gdh_EventCost.ToCostVat() : 0.0;
            item.gdh_EventPrice = goodsHistoryView1.gdh_EventPrice;
            if (Enum2StrConverter.IsSupplierTypeDirect(item.su_SupplierType))
            {
              if (Enum2StrConverter.ToSalesUnit(goodsHistoryView1.gd_SalesUnit) == EnumSalesUnit.AMOUNT)
              {
                if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
                else if (goodsHistoryView1.gd_IsTax)
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_EventCost.ToSaleMargin(goodsHistoryView1.gdh_EventPrice - goodsHistoryView1.gdh_EventPrice.ToPriceVat());
                else
                  item.gdh_ChargeRate = goodsHistoryView1.gdh_EventCost.ToSaleMargin(goodsHistoryView1.gdh_EventPrice);
              }
            }
            else if (!goodsHistoryView1.gdh_ChargeRate.IsZero())
              item.gdh_ChargeRate = goodsHistoryView1.gdh_ChargeRate;
            else if (goodsHistoryView1.gd_IsTax)
              item.gdh_ChargeRate = goodsHistoryView1.gdh_EventCost.ToSaleMargin(goodsHistoryView1.gdh_EventPrice - goodsHistoryView1.gdh_EventPrice.ToPriceVat());
            else
              item.gdh_ChargeRate = goodsHistoryView1.gdh_EventCost.ToSaleMargin(goodsHistoryView1.gdh_EventPrice);
            item.gdh_MemberPrice1 = 0.0;
            item.gdh_MemberPrice2 = 0.0;
            item.gdh_MemberPrice3 = 0.0;
            item.gdh_InUser = p_app_employee.emp_Code;
            item.gdh_ModUser = p_app_employee.emp_Code;
            lt_event_insert.Clear();
            if (event_origin == null)
              event_origin = p_db.Create<GoodsHistoryView>();
            else
              event_origin.Clear();
            event_origin.PutData(item);
            lt_event_insert.Add(event_origin);
            foreach (GoodsHistoryView history in dic_Store[item.gdh_StoreCode])
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_event_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_event_insert[0].IntStartDate == history.IntEndDate)
                    lt_event_insert[0].gdh_EndDate = history.gdh_EndDate;
                  else if (lt_event_insert[0].IntStartDate < history.IntStartDate)
                  {
                    GoodsHistoryView goodsHistoryView3 = lt_event_insert[0];
                    nullable1 = history.gdh_StartDate;
                    DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                    goodsHistoryView3.gdh_EndDate = nullable2;
                  }
                }
                if (history.IntStartDate == item.IntStartDate)
                {
                  if (!await history.DeleteAsync())
                    throw new Exception(history.message);
                }
                else if (!await history.UpdateAsync((UbModelBase) null))
                  throw new Exception(history.message);
                if (item.IntEndDate > history.IntEndDate)
                {
                  if (lt_event_insert.Count == 1)
                  {
                    if (event_origin_end == null)
                      event_origin_end = p_db.Create<GoodsHistoryView>();
                    else
                      event_origin_end.Clear();
                    event_origin_end.PutData(item);
                    lt_event_insert.Add(event_origin_end);
                  }
                  GoodsHistoryView goodsHistoryView4 = lt_event_insert[1];
                  nullable1 = history.gdh_EndDate;
                  DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                  goodsHistoryView4.gdh_StartDate = nullable3;
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView next_data = p_db.Create<GoodsHistoryView>();
                next_data.PutData(history);
                GoodsHistoryView goodsHistoryView5 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView5.gdh_EndDate = nullable4;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                GoodsHistoryView goodsHistoryView6 = next_data;
                nullable1 = item.gdh_EndDate;
                DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                goodsHistoryView6.gdh_StartDate = nullable5;
                next_data.gdh_SiteID = goodsHistoryView1.gdh_SiteID;
                next_data = await next_data.InsertAsync() ? (GoodsHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView7 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable6 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView7.gdh_EndDate = nullable6;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView8 = history;
                int gdhStoreCode = history.gdh_StoreCode;
                long gdhGoodsCode = history.gdh_GoodsCode;
                nullable1 = history.gdh_StartDate;
                DateTime p_gdh_StartDate = nullable1.Value;
                nullable1 = item.gdh_EndDate;
                DateTime dateAdd = nullable1.Value.GetDateAdd(0, 0, 1);
                long gdhSiteId = history.gdh_SiteID;
                if (!await goodsHistoryView8.UpdateStartDateAsync(gdhStoreCode, gdhGoodsCode, p_gdh_StartDate, dateAdd, gdhSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_event_insert.Count == 2)
            {
              foreach (GoodsHistoryView goodsHistoryView9 in dic_Store[item.gdh_StoreCode])
              {
                if (goodsHistoryView9.IntStartDate == lt_event_insert[1].IntStartDate)
                {
                  int num2 = await goodsHistoryView9.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (GoodsHistoryView goodsHistoryView10 in lt_event_insert)
            {
              if (goodsHistoryView10.IntStartDate <= goodsHistoryView10.IntEndDate)
              {
                if (!await goodsHistoryView10.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num3 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (GoodsHistoryView) null;
          }
        }
        goodsHistoryView1.db_status = 4;
        goodsHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView1.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterMemberPriceDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      try
      {
        goodsHistoryView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView1.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView1.gdh_SiteID == 0L)
            goodsHistoryView1.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(goodsHistoryView1.gdh_SiteID))
        {
          logs.dml_CodeInt = goodsHistoryView1.gdh_StoreCode;
          logs.dml_CodeLong = goodsHistoryView1.gdh_GoodsCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) goodsHistoryView1.gdh_StoreCode, (object) goodsHistoryView1.gdh_GoodsCode, (object) goodsHistoryView1.IntStartDate, (object) goodsHistoryView1.gdh_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(goodsHistoryView1.arrStrStoreCode))
          goodsHistoryView1.arrStrStoreCode = goodsHistoryView1.gdh_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_START_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        Hashtable hashtable1 = param;
        DateTime? nullable1 = goodsHistoryView1.gdh_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_END_DATE_", (object) local1);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> infos = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        GoodsHistoryByStoreDic dic_Store = new GoodsHistoryByStoreDic();
        dic_Store.AddRange((IEnumerable<GoodsHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        Hashtable hashtable2 = param;
        nullable1 = goodsHistoryView1.gdh_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_DATE_", (object) local2);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> goodsHistoryViewList = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        List<GoodsHistoryView> lt_origin_insert = new List<GoodsHistoryView>();
        GoodsHistoryView origin_start = (GoodsHistoryView) null;
        GoodsHistoryView origin_end = (GoodsHistoryView) null;
        foreach (GoodsHistoryView goodsHistoryView2 in (IEnumerable<GoodsHistoryView>) goodsHistoryViewList)
        {
          GoodsHistoryView item = goodsHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store[item.gdh_StoreCode] != null && dic_Store[item.gdh_StoreCode].Count != 0)
          {
            logs.Init(p_login_employee, goodsHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            double num1 = item.gdh_MemberPrice1;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice1))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice1", "회원가", item.gdh_MemberPrice1, goodsHistoryView1.gdh_MemberPrice1));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_MemberPrice2;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice2))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice2", "회원가2", item.gdh_MemberPrice2, goodsHistoryView1.gdh_MemberPrice2));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_MemberPrice3;
            if (!num1.Equals(goodsHistoryView1.gdh_MemberPrice3))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_MemberPrice3", "회원가3", item.gdh_MemberPrice3, goodsHistoryView1.gdh_MemberPrice3));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.gdh_StartDate = goodsHistoryView1.gdh_StartDate;
            item.gdh_EndDate = goodsHistoryView1.gdh_EndDate;
            item.gdh_MemberPrice1 = goodsHistoryView1.gdh_MemberPrice1;
            item.gdh_MemberPrice2 = goodsHistoryView1.gdh_MemberPrice2;
            item.gdh_MemberPrice3 = goodsHistoryView1.gdh_MemberPrice3;
            item.gdh_InUser = p_app_employee.emp_Code;
            item.gdh_ModUser = p_app_employee.emp_Code;
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<GoodsHistoryView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            foreach (GoodsHistoryView history in dic_Store[item.gdh_StoreCode])
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                    lt_origin_insert[0].gdh_EndDate = history.gdh_EndDate;
                  else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                  {
                    GoodsHistoryView goodsHistoryView3 = lt_origin_insert[0];
                    nullable1 = history.gdh_StartDate;
                    DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                    goodsHistoryView3.gdh_EndDate = nullable2;
                  }
                }
                if (history.IntStartDate == item.IntStartDate)
                {
                  if (!await history.DeleteAsync())
                    throw new Exception(history.message);
                }
                else if (!await history.UpdateAsync((UbModelBase) null))
                  throw new Exception(history.message);
                if (item.IntEndDate > history.IntEndDate)
                {
                  if (lt_origin_insert.Count == 1)
                  {
                    if (origin_end == null)
                      origin_end = p_db.Create<GoodsHistoryView>();
                    else
                      origin_end.Clear();
                    origin_end.PutData(item);
                    lt_origin_insert.Add(origin_end);
                  }
                  GoodsHistoryView goodsHistoryView4 = lt_origin_insert[1];
                  nullable1 = history.gdh_EndDate;
                  DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                  goodsHistoryView4.gdh_StartDate = nullable3;
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView next_data = p_db.Create<GoodsHistoryView>();
                next_data.PutData(history);
                GoodsHistoryView goodsHistoryView5 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView5.gdh_EndDate = nullable4;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                GoodsHistoryView goodsHistoryView6 = next_data;
                nullable1 = item.gdh_EndDate;
                DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                goodsHistoryView6.gdh_StartDate = nullable5;
                next_data.gdh_SiteID = goodsHistoryView1.gdh_SiteID;
                next_data = await next_data.InsertAsync() ? (GoodsHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView7 = history;
                nullable1 = item.gdh_StartDate;
                DateTime? nullable6 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                goodsHistoryView7.gdh_EndDate = nullable6;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView8 = history;
                int gdhStoreCode = history.gdh_StoreCode;
                long gdhGoodsCode = history.gdh_GoodsCode;
                nullable1 = history.gdh_StartDate;
                DateTime p_gdh_StartDate = nullable1.Value;
                nullable1 = item.gdh_EndDate;
                DateTime dateAdd = nullable1.Value.GetDateAdd(0, 0, 1);
                long gdhSiteId = history.gdh_SiteID;
                if (!await goodsHistoryView8.UpdateStartDateAsync(gdhStoreCode, gdhGoodsCode, p_gdh_StartDate, dateAdd, gdhSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_origin_insert.Count == 2)
            {
              foreach (GoodsHistoryView goodsHistoryView9 in dic_Store[item.gdh_StoreCode])
              {
                if (goodsHistoryView9.IntStartDate == lt_origin_insert[1].IntStartDate)
                {
                  int num2 = await goodsHistoryView9.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (GoodsHistoryView goodsHistoryView10 in lt_origin_insert)
            {
              if (goodsHistoryView10.IntStartDate <= goodsHistoryView10.IntEndDate)
              {
                if (!await goodsHistoryView10.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num3 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (GoodsHistoryView) null;
          }
        }
        goodsHistoryView1.db_status = 4;
        goodsHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView1.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterCodeDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      GoodsHistoryView goodsHistoryView1 = this;
      try
      {
        goodsHistoryView1.SetAdoDatabase(p_db);
        goodsHistoryView1.gdh_EndDate = new DateTime?(new DateTime(2999, 12, 31));
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsHistoryView1.DataCheck(p_db))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsHistoryView1.gdh_SiteID == 0L)
            goodsHistoryView1.gdh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(goodsHistoryView1.gdh_SiteID))
        {
          logs.dml_CodeInt = goodsHistoryView1.gdh_StoreCode;
          logs.dml_CodeLong = goodsHistoryView1.gdh_GoodsCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) goodsHistoryView1.gdh_StoreCode, (object) goodsHistoryView1.gdh_GoodsCode, (object) goodsHistoryView1.IntStartDate, (object) goodsHistoryView1.gdh_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(goodsHistoryView1.arrStrStoreCode))
          goodsHistoryView1.arrStrStoreCode = goodsHistoryView1.gdh_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_START_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        param.Add((object) "_DT_END_DATE_", (object) goodsHistoryView1.gdh_EndDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> infos = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        GoodsHistoryByStoreDic dic_Store = new GoodsHistoryByStoreDic();
        dic_Store.AddRange((IEnumerable<GoodsHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(goodsHistoryView1.message, goodsHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "gdh_SiteID", (object) goodsHistoryView1.gdh_SiteID);
        param.Add((object) "gdh_StoreCode_IN_", (object) goodsHistoryView1.arrStrStoreCode);
        param.Add((object) "gdh_GoodsCode", (object) goodsHistoryView1.gdh_GoodsCode);
        param.Add((object) "_DT_DATE_", (object) goodsHistoryView1.gdh_StartDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<GoodsHistoryView> goodsHistoryViewList = await p_db.Create<GoodsHistoryView>().SelectListAsync((object) param);
        List<GoodsHistoryView> lt_origin_insert = new List<GoodsHistoryView>();
        GoodsHistoryView origin_start = (GoodsHistoryView) null;
        GoodsHistoryView origin_end = (GoodsHistoryView) null;
        foreach (GoodsHistoryView goodsHistoryView2 in (IEnumerable<GoodsHistoryView>) goodsHistoryViewList)
        {
          GoodsHistoryView item = goodsHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store[item.gdh_StoreCode] != null && dic_Store[item.gdh_StoreCode].Count != 0)
          {
            logs.Init(p_login_employee, goodsHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            int num1 = item.gdh_GoodsCategory;
            if (!num1.Equals(goodsHistoryView1.gdh_GoodsCategory))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_GoodsCategory", "소분류", item.gdh_GoodsCategory, goodsHistoryView1.gdh_GoodsCategory));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            num1 = item.gdh_Supplier;
            if (!num1.Equals(goodsHistoryView1.gdh_Supplier))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_Supplier", "업체", item.gdh_Supplier, goodsHistoryView1.gdh_Supplier));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.gdh_PointRate.Equals(goodsHistoryView1.gdh_PointRate))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("gdh_PointRate", "회원특별적립율", item.gdh_PointRate, goodsHistoryView1.gdh_PointRate));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.gdh_StartDate = goodsHistoryView1.gdh_StartDate;
            item.gdh_EndDate = goodsHistoryView1.gdh_EndDate;
            item.gdh_GoodsCategory = goodsHistoryView1.gdh_GoodsCategory;
            item.gdh_Supplier = goodsHistoryView1.gdh_Supplier;
            item.gdh_PointRate = goodsHistoryView1.gdh_PointRate;
            item.gdh_InUser = p_app_employee.emp_Code;
            item.gdh_ModUser = p_app_employee.emp_Code;
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<GoodsHistoryView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            foreach (GoodsHistoryView history in dic_Store[item.gdh_StoreCode])
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                    lt_origin_insert[0].gdh_EndDate = history.gdh_EndDate;
                  else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                    lt_origin_insert[0].gdh_EndDate = new DateTime?(history.gdh_StartDate.Value.GetDateAdd(0, 0, -1));
                }
                if (history.IntStartDate == item.IntStartDate)
                {
                  if (!await history.DeleteAsync())
                    throw new Exception(history.message);
                }
                else if (!await history.UpdateAsync((UbModelBase) null))
                  throw new Exception(history.message);
                if (item.IntEndDate > history.IntEndDate)
                {
                  if (lt_origin_insert.Count == 1)
                  {
                    if (origin_end == null)
                      origin_end = p_db.Create<GoodsHistoryView>();
                    else
                      origin_end.Clear();
                    origin_end.PutData(item);
                    lt_origin_insert.Add(origin_end);
                  }
                  lt_origin_insert[1].gdh_StartDate = new DateTime?(history.gdh_EndDate.Value.GetDateAdd(0, 0, 1));
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView next_data = p_db.Create<GoodsHistoryView>();
                next_data.PutData(history);
                history.gdh_EndDate = new DateTime?(item.gdh_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                next_data.gdh_StartDate = new DateTime?(item.gdh_EndDate.Value.GetDateAdd(0, 0, 1));
                next_data.gdh_SiteID = goodsHistoryView1.gdh_SiteID;
                next_data = await next_data.InsertAsync() ? (GoodsHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                history.gdh_EndDate = new DateTime?(item.gdh_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                GoodsHistoryView goodsHistoryView3 = history;
                int gdhStoreCode = history.gdh_StoreCode;
                long gdhGoodsCode = history.gdh_GoodsCode;
                DateTime? nullable = history.gdh_StartDate;
                DateTime p_gdh_StartDate = nullable.Value;
                nullable = item.gdh_EndDate;
                DateTime dateAdd = nullable.Value.GetDateAdd(0, 0, 1);
                long gdhSiteId = history.gdh_SiteID;
                if (!await goodsHistoryView3.UpdateStartDateAsync(gdhStoreCode, gdhGoodsCode, p_gdh_StartDate, dateAdd, gdhSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_origin_insert.Count == 2)
            {
              foreach (GoodsHistoryView goodsHistoryView4 in dic_Store[item.gdh_StoreCode])
              {
                if (goodsHistoryView4.IntStartDate == lt_origin_insert[1].IntStartDate)
                {
                  int num2 = await goodsHistoryView4.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (GoodsHistoryView goodsHistoryView5 in lt_origin_insert)
            {
              if (goodsHistoryView5.IntStartDate <= goodsHistoryView5.IntEndDate)
              {
                if (!await goodsHistoryView5.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num3 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (GoodsHistoryView) null;
          }
        }
        goodsHistoryView1.db_status = 4;
        goodsHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsHistoryView1.message = ex.Message;
      }
      return false;
    }
  }
}
