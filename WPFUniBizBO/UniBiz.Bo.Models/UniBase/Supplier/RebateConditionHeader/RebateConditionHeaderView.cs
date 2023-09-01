// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader.RebateConditionHeaderView
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
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader
{
  public class RebateConditionHeaderView : TRebateConditionHeader<RebateConditionHeaderView>
  {
    private string _si_StoreName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private string _inEmpName;
    private string _modEmpName;
    private IList<RebateConditionDetailView> _Lt_Details;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
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

    [JsonPropertyName("lt_Details")]
    public IList<RebateConditionDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<RebateConditionDetailView>) new List<RebateConditionDetailView>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
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
      this.si_StoreName = string.Empty;
      this.su_SupplierName = string.Empty;
      this.su_SupplierViewCode = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Details = (IList<RebateConditionDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new RebateConditionHeaderView();

    public override object Clone()
    {
      RebateConditionHeaderView conditionHeaderView = base.Clone() as RebateConditionHeaderView;
      conditionHeaderView.si_StoreName = this.si_StoreName;
      conditionHeaderView.su_SupplierName = this.su_SupplierName;
      conditionHeaderView.su_SupplierViewCode = this.su_SupplierViewCode;
      conditionHeaderView.inEmpName = this.inEmpName;
      conditionHeaderView.modEmpName = this.modEmpName;
      conditionHeaderView.Lt_Details = (IList<RebateConditionDetailView>) null;
      if (this.Lt_Details.Count > 0)
      {
        foreach (RebateConditionDetailView ltDetail in (IEnumerable<RebateConditionDetailView>) this.Lt_Details)
          conditionHeaderView.Lt_Details.Add(ltDetail);
      }
      return (object) conditionHeaderView;
    }

    public void PutData(RebateConditionHeaderView pSource)
    {
      this.PutData((TRebateConditionHeader) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Details = (IList<RebateConditionDetailView>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (RebateConditionDetailView ltDetail in (IEnumerable<RebateConditionDetailView>) pSource.Lt_Details)
      {
        RebateConditionDetailView conditionDetailView = new RebateConditionDetailView();
        conditionDetailView.PutData(ltDetail);
        this.Lt_Details.Add(conditionDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.rch_SiteID == 0L)
      {
        this.message = "싸이트(rch_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.rch_StoreCode == 0)
      {
        this.message = "지점코드(rch_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.rch_Supplier == 0)
      {
        this.message = "코드(rch_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.rch_ContractDate.HasValue)
      {
        this.message = "입점일(계약일)(rch_ContractDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (Enum2StrConverter.ToSupRebateStdDate(this.rch_CalcPeriodType) == EnumSupRebateStdDate.NONE)
      {
        this.message = "생성주기(rch_CalcPeriodType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSupRebateStdAmount(this.rch_StdAmtType) != EnumSupRebateStdAmount.NONE)
        return EnumDataCheck.Success;
      this.message = "기준금액유형(rch_StdAmtType)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (this.IsNew)
      {
        if (!p_app_employee.IsSupplierSave)
        {
          this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (!p_app_employee.IsPayment)
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
          if (this.rch_SiteID == 0L)
            this.rch_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InertDetail(p_db, p_app_employee))
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

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      RebateConditionHeaderView conditionHeaderView = this;
      try
      {
        conditionHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != conditionHeaderView.DataCheck(p_db))
            throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (conditionHeaderView.rch_SiteID == 0L)
            conditionHeaderView.rch_SiteID = p_app_employee.emp_SiteID;
          if (!conditionHeaderView.IsPermit(p_app_employee))
            throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await conditionHeaderView.InsertAsync())
          throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 등록 오류");
        if (!await conditionHeaderView.InertDetailAsync(p_db, p_app_employee))
          throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        conditionHeaderView.db_status = 4;
        conditionHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionHeaderView.message = ex.Message;
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
        if (!this.InertDetail(p_db, p_app_employee))
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
      RebateConditionHeaderView conditionHeaderView = this;
      try
      {
        conditionHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != conditionHeaderView.DataCheck(p_db))
            throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!conditionHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await conditionHeaderView.UpdateAsync())
          throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (!await conditionHeaderView.InertDetailAsync(p_db, p_app_employee))
          throw new UniServiceException(conditionHeaderView.message, conditionHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        conditionHeaderView.db_status = 4;
        conditionHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionHeaderView.message = ex.Message;
      }
      return false;
    }

    public bool InertDetail(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      try
      {
        if (this.Lt_Details.Count == 0)
          return true;
        this.SetAdoDatabase(p_db);
        foreach (RebateConditionDetailView ltDetail in (IEnumerable<RebateConditionDetailView>) this.Lt_Details)
        {
          if (ltDetail.rcd_SiteID == 0L)
            ltDetail.rcd_SiteID = this.rch_SiteID;
          if (ltDetail.IsNew)
          {
            ltDetail.rcd_StoreCode = this.rch_StoreCode;
            ltDetail.rcd_Supplier = this.rch_Supplier;
            ltDetail.rcd_InUser = this.rch_InUser;
            if (!ltDetail.InsertData(p_db, p_app_employee, false))
              throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 등록 실패");
          }
          else if (ltDetail.IsUpdate)
          {
            ltDetail.rcd_ModUser = this.rch_ModUser;
            if (!ltDetail.UpdateData(p_db, p_app_employee, false))
              throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 변경 실패");
          }
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

    public async Task<bool> InertDetailAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      RebateConditionHeaderView conditionHeaderView = this;
      try
      {
        if (conditionHeaderView.Lt_Details.Count == 0)
          return true;
        conditionHeaderView.SetAdoDatabase(p_db);
        foreach (RebateConditionDetailView item in (IEnumerable<RebateConditionDetailView>) conditionHeaderView.Lt_Details)
        {
          if (item.rcd_SiteID == 0L)
            item.rcd_SiteID = conditionHeaderView.rch_SiteID;
          if (item.IsNew)
          {
            item.rcd_StoreCode = conditionHeaderView.rch_StoreCode;
            item.rcd_Supplier = conditionHeaderView.rch_Supplier;
            item.rcd_InUser = conditionHeaderView.rch_InUser;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 등록 실패");
          }
          else if (item.IsUpdate)
          {
            item.rcd_ModUser = conditionHeaderView.rch_ModUser;
            if (!await item.UpdateDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 변경 실패");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        conditionHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        conditionHeaderView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<RebateConditionHeaderView> SelectOneAsync(
      int p_rch_StoreCode,
      int p_rch_Supplier,
      long p_rch_SiteID = 0)
    {
      RebateConditionHeaderView conditionHeaderView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "rch_StoreCode",
          (object) p_rch_StoreCode
        },
        {
          (object) "rch_Supplier",
          (object) p_rch_Supplier
        }
      };
      if (p_rch_SiteID > 0L)
        p_param.Add((object) "rch_SiteID", (object) p_rch_SiteID);
      return await conditionHeaderView.SelectOneTAsync<RebateConditionHeaderView>((object) p_param);
    }

    public async Task<IList<RebateConditionHeaderView>> SelectListAsync(object p_param)
    {
      RebateConditionHeaderView conditionHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(conditionHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, conditionHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(conditionHeaderView1.GetSelectQuery(p_param)))
        {
          conditionHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + conditionHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<RebateConditionHeaderView>) null;
        }
        IList<RebateConditionHeaderView> lt_list = (IList<RebateConditionHeaderView>) new List<RebateConditionHeaderView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            RebateConditionHeaderView conditionHeaderView2 = conditionHeaderView1.OleDB.Create<RebateConditionHeaderView>();
            if (conditionHeaderView2.GetFieldValues(rs))
            {
              conditionHeaderView2.row_number = lt_list.Count + 1;
              lt_list.Add(conditionHeaderView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + conditionHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        string empty = string.Empty;
        long num1 = 0;
        int num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "rch_SiteID") && Convert.ToInt64(hashtable[(object) "rch_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "rch_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_SupplierName,su_SupplierViewCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        Hashtable p_param1 = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("rch_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          else if (dictionaryEntry.Key.ToString().Contains("SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("rch_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS (SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  rch_StoreCode,rch_Supplier,rch_SiteID,rch_ContractDate,rch_CalcPeriodType,rch_StdAmtType,rch_UseYn,rch_AddProperty,rch_InDate,rch_InUser,rch_ModDate,rch_ModUser,si_StoreName,su_SupplierName,su_SupplierViewCode,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_SUPPLIER ON rch_Supplier=su_Supplier AND rch_SiteID=su_SiteID INNER JOIN T_STORE ON rch_StoreCode=si_StoreCode AND rch_SiteID=si_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON rch_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON rch_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num2 > 0)
          stringBuilder.Append(" ORDER BY rch_Supplier,rch_StoreCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY rch_Supplier,rch_StoreCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
