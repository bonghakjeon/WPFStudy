// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo.GoodsStoreInfoView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo
{
  public class GoodsStoreInfoView : TGoodsStoreInfo<GoodsStoreInfoView>
  {
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
    private GoodsHistoryView _GoodsHistoryInfo;
    private string _inEmpName;
    private string _modEmpName;

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
      this.gd_GoodsName = string.Empty;
      this.gd_BarCode = string.Empty;
      this.gd_GoodsSize = string.Empty;
      this.gd_TaxDiv = this.gd_SalesUnit = this.gd_StockUnit = this.gd_PackUnit = this.gd_Deposit = 0;
      this.gd_MinOrderUnit = 0.0;
      this.gd_UseYn = string.Empty;
      this.GoodsHistoryInfo = (GoodsHistoryView) null;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsStoreInfoView();

    public override object Clone()
    {
      GoodsStoreInfoView goodsStoreInfoView = base.Clone() as GoodsStoreInfoView;
      goodsStoreInfoView.gd_GoodsName = this.gd_GoodsName;
      goodsStoreInfoView.gd_BarCode = this.gd_BarCode;
      goodsStoreInfoView.gd_GoodsSize = this.gd_GoodsSize;
      goodsStoreInfoView.gd_TaxDiv = this.gd_TaxDiv;
      goodsStoreInfoView.gd_SalesUnit = this.gd_SalesUnit;
      goodsStoreInfoView.gd_StockUnit = this.gd_StockUnit;
      goodsStoreInfoView.gd_PackUnit = this.gd_PackUnit;
      goodsStoreInfoView.gd_MinOrderUnit = this.gd_MinOrderUnit;
      goodsStoreInfoView.gd_Deposit = this.gd_Deposit;
      goodsStoreInfoView.gd_UseYn = this.gd_UseYn;
      goodsStoreInfoView.GoodsHistoryInfo = (GoodsHistoryView) null;
      if (this.GoodsHistoryInfo.gdh_GoodsCode > 0L)
        goodsStoreInfoView.GoodsHistoryInfo = this.GoodsHistoryInfo;
      goodsStoreInfoView.inEmpName = this.inEmpName;
      goodsStoreInfoView.modEmpName = this.modEmpName;
      return (object) goodsStoreInfoView;
    }

    public void PutData(GoodsStoreInfoView pSource)
    {
      this.PutData((TGoodsStoreInfo) pSource);
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_TaxDiv = pSource.gd_TaxDiv;
      this.gd_SalesUnit = pSource.gd_SalesUnit;
      this.gd_StockUnit = pSource.gd_StockUnit;
      this.gd_PackUnit = pSource.gd_PackUnit;
      this.gd_MinOrderUnit = pSource.gd_MinOrderUnit;
      this.gd_Deposit = pSource.gd_Deposit;
      this.gd_UseYn = pSource.gd_UseYn;
      this.GoodsHistoryInfo = (GoodsHistoryView) null;
      if (pSource.GoodsHistoryInfo.gdh_GoodsCode > 0L)
        this.GoodsHistoryInfo.PutData(pSource.GoodsHistoryInfo);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gdsh_SiteID == 0L)
      {
        this.message = "싸이트(gdsh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdsh_StoreCode == 0)
      {
        this.message = "지점코드(gdsh_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdsh_StoreCode != 0)
        return EnumDataCheck.Success;
      this.message = "지점코드(gdsh_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

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
          if (this.gdsh_SiteID == 0L)
            this.gdsh_SiteID = p_app_employee.emp_SiteID;
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
      GoodsStoreInfoView goodsStoreInfoView = this;
      try
      {
        goodsStoreInfoView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await goodsStoreInfoView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsStoreInfoView.gdsh_SiteID == 0L)
            goodsStoreInfoView.gdsh_SiteID = p_app_employee.emp_SiteID;
          if (!goodsStoreInfoView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsStoreInfoView.InsertAsync())
          throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsStoreInfoView.db_status = 4;
        goodsStoreInfoView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsStoreInfoView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsStoreInfoView.message = ex.Message;
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
      GoodsStoreInfoView goodsStoreInfoView = this;
      try
      {
        goodsStoreInfoView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await goodsStoreInfoView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsStoreInfoView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsStoreInfoView.UpdateAsync())
          throw new UniServiceException(goodsStoreInfoView.message, goodsStoreInfoView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsStoreInfoView.db_status = 4;
        goodsStoreInfoView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsStoreInfoView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsStoreInfoView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.GoodsHistoryInfo.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.GoodsHistoryInfo.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.GoodsHistoryInfo.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
      this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
      this.gd_TaxDiv = p_rs.GetFieldInt("gd_TaxDiv");
      this.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
      this.gd_SalesUnit = p_rs.GetFieldInt("gd_SalesUnit");
      this.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
      this.gd_StockUnit = p_rs.GetFieldInt("gd_StockUnit");
      this.gd_PackUnit = p_rs.GetFieldInt("gd_PackUnit");
      this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
      if (p_rs.IsFieldName("gdh_StartDate"))
      {
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
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.DeptInfo.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
        this.GoodsHistoryInfo.CategoryInfo.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        this.GoodsHistoryInfo.CategoryInfo.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        this.GoodsHistoryInfo.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
        this.GoodsHistoryInfo.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
        this.GoodsHistoryInfo.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      }
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GoodsStoreInfoView> SelectOneAsync(
      int p_gdsh_StoreCode,
      long p_gdsh_GoodsCode,
      long p_gdsh_SiteID = 0)
    {
      GoodsStoreInfoView goodsStoreInfoView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gdsh_StoreCode",
          (object) p_gdsh_StoreCode
        },
        {
          (object) "gdsh_GoodsCode",
          (object) p_gdsh_GoodsCode
        }
      };
      if (p_gdsh_SiteID > 0L)
        p_param.Add((object) "gdsh_SiteID", (object) p_gdsh_SiteID);
      return await goodsStoreInfoView.SelectOneTAsync<GoodsStoreInfoView>((object) p_param);
    }

    public async Task<IList<GoodsStoreInfoView>> SelectListAsync(object p_param)
    {
      GoodsStoreInfoView goodsStoreInfoView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsStoreInfoView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsStoreInfoView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsStoreInfoView1.GetSelectQuery(p_param)))
        {
          goodsStoreInfoView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsStoreInfoView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsStoreInfoView>) null;
        }
        IList<GoodsStoreInfoView> lt_list = (IList<GoodsStoreInfoView>) new List<GoodsStoreInfoView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsStoreInfoView goodsStoreInfoView2 = goodsStoreInfoView1.OleDB.Create<GoodsStoreInfoView>();
            if (goodsStoreInfoView2.GetFieldValues(rs))
            {
              goodsStoreInfoView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsStoreInfoView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsStoreInfoView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "_DT_DATE_") && hashtable[(object) "_DT_DATE_"].ToString().Length > 0)
        {
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
          if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", hashtable[(object) "su_Supplier"]));
          else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
          if (hashtable.ContainsKey((object) "su_SupplierType") && hashtable[(object) "su_SupplierType"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SupplierType", hashtable[(object) "su_SupplierType"]));
        }
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gd_GoodsName", hashtable[(object) "_KEY_WORD_"]));
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
        long num1 = 0;
        int num2 = 0;
        DateTime? nullable = new DateTime?();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gdsh_SiteID") && Convert.ToInt64(hashtable[(object) "gdsh_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "gdsh_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_DT_DATE_"))
            nullable = new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]);
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS (\n SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdsh_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdsh_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (\nSELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdsh_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "su_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (num2 > 0)
        {
          stringBuilder.Append(",T_BOOKMARK_GOODS AS (\n SELECT bgl_GoodsCode,bgl_SiteID" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n WHERE {0}={1}", (object) "bgl_GroupID", (object) num2));
          if (num1 > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) num1));
          stringBuilder.Append("\n GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        if (nullable.HasValue)
        {
          stringBuilder.Append(",T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dpt_lv3_ViewCode AS dpt_ViewCode,dpt_lv3_Name AS dpt_DeptName\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_lv3_ViewCode AS ctg_ViewCode,ctg_lv3_Name AS ctg_CategoryName" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n LEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("gdsh_SiteID"))
              p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gdsh_StoreCode"))
              p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gdsh_StoreCode_IN_"))
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gdsh_GoodsCode"))
              p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
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
            dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "gdh_SiteID"))
              p_param1.Add((object) "gdh_SiteID", (object) num1);
            stringBuilder.Append("\n");
            stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
          }
          else if (num1 > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_SiteID", (object) num1));
          stringBuilder.Append("\n");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(",T_GOODS AS (\nSELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_PackUnit,gd_UseYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdsh_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdsh_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
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
            p_param1.Add((object) "gd_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderType,gdsh_AutoOrderMonth,gdsh_OrderWeekDay,gdsh_AutoOrderMonths,gdsh_AutoOrderDays,gdsh_AutoOrderType,gdsh_AutoSafeQty,gdsh_AutoMinQty,gdsh_AutoMidQty,gdsh_AutoMaxQty,gdsh_StorageStockQty,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_AddProperty,gdsh_InDate,gdsh_InUser,gdsh_ModDate,gdsh_ModUser\n,si_StoreViewCode,si_StoreName,si_UseYn\n,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_Deposit,gd_SalesUnit,gd_MinOrderUnit,gd_StockUnit,gd_PackUnit,gd_UseYn");
        if (nullable.HasValue)
          stringBuilder.Append("\n,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dpt_ViewCode,dpt_DeptName,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_ViewCode,ctg_CategoryName,su_SupplierName,su_SupplierViewCode,su_SupplierType");
        stringBuilder.Append(",inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON gdsh_StoreCode=si_StoreCode AND gdsh_SiteID=si_SiteID\n INNER JOIN T_GOODS ON gdsh_GoodsCode=gd_GoodsCode AND gdsh_SiteID=gd_SiteID");
        if (nullable.HasValue)
          stringBuilder.Append("\n INNER JOIN T_HISTORY ON gdsh_StoreCode=gdh_StoreCode AND gdsh_GoodsCode=gdh_GoodsCode AND gdsh_SiteID=gdh_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND gdsh_SiteID=su_SiteID");
        stringBuilder.Append("\n LEFT OUTER JOIN T_EMPLOYEE_IN ON gdsh_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON gdsh_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gdsh_StoreCode");
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
      Log.Logger.DebugColor(" 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + string.Format("\n LINE : {0} 행", (object) new StackFrame(0, true).GetFileLineNumber()) + "\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------\n" + stringBuilder.ToString() + "\n{EnumTypes.LINE_ONE}");
      return stringBuilder.ToString();
    }
  }
}
