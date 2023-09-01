// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader.StoreGroupHeaderView
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
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader
{
  public class StoreGroupHeaderView : TStoreGroupHeader<StoreGroupHeaderView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private IList<StoreGroupDetailView> _Lt_Details;

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

    [JsonPropertyName("lt_details")]
    public IList<StoreGroupDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<StoreGroupDetailView>) new List<StoreGroupDetailView>());
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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Details = (IList<StoreGroupDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StoreGroupHeaderView();

    public override object Clone()
    {
      StoreGroupHeaderView storeGroupHeaderView = base.Clone() as StoreGroupHeaderView;
      storeGroupHeaderView.inEmpName = this.inEmpName;
      storeGroupHeaderView.modEmpName = this.modEmpName;
      storeGroupHeaderView.Lt_Details = (IList<StoreGroupDetailView>) null;
      if (this.Lt_Details.Count > 0)
      {
        foreach (StoreGroupDetailView ltDetail in (IEnumerable<StoreGroupDetailView>) this.Lt_Details)
          storeGroupHeaderView.Lt_Details.Add(ltDetail);
      }
      return (object) storeGroupHeaderView;
    }

    public void PutData(StoreGroupHeaderView pSource)
    {
      this.PutData((TStoreGroupHeader) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Details = (IList<StoreGroupDetailView>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (StoreGroupDetailView ltDetail in (IEnumerable<StoreGroupDetailView>) pSource.Lt_Details)
      {
        StoreGroupDetailView storeGroupDetailView = new StoreGroupDetailView();
        storeGroupDetailView.PutData(ltDetail);
        this.Lt_Details.Add(storeGroupDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.sgh_GroupType == 0)
      {
        this.message = "타입(sgh_GroupType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sgh_SiteID == 0L)
      {
        this.message = "싸이트(sgh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.sgh_GroupName))
        return EnumDataCheck.Success;
      this.message = "지점그룹명(sgh_GroupName)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (p_app_employee.IsStore)
        return true;
      this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
      return false;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(sgh_GroupCode), 0)+1 AS sgh_GroupCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.sgh_GroupCode = uniOleDbRecordset.GetFieldInt(0);
        return this.sgh_GroupCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(storeGroupHeaderView.CreateCodeQuery()))
        {
          storeGroupHeaderView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupHeaderView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          storeGroupHeaderView.sgh_GroupCode = rs.GetFieldInt(0);
        return storeGroupHeaderView.sgh_GroupCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.sgh_GroupCode != 0 || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) this.sgh_GroupCode));

    public override async Task<bool> InsertAsync()
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      if (storeGroupHeaderView.sgh_GroupCode == 0)
      {
        if (!await storeGroupHeaderView.CreateCodeAsync(storeGroupHeaderView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await storeGroupHeaderView.\u003C\u003En__0() && storeGroupHeaderView.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) storeGroupHeaderView.sgh_GroupCode));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.sgh_GroupCode));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeGroupHeaderView.\u003C\u003En__1(p_old) && storeGroupHeaderView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) storeGroupHeaderView.sgh_GroupCode));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.sgh_GroupCode));

    public override async Task<bool> UpdateExInsertAsync()
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeGroupHeaderView.\u003C\u003En__2() && storeGroupHeaderView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) storeGroupHeaderView.sgh_GroupCode));
    }

    public virtual bool InsertDetails(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_new,
      bool p_is_trans = false)
    {
      try
      {
        if (p_is_new)
        {
          int count = this.Lt_Details.Count;
        }
        if (this.Lt_Details.Count == 0)
          return true;
        if (p_is_trans)
          p_db.BeginTransaction();
        foreach (StoreGroupDetailView ltDetail in (IEnumerable<StoreGroupDetailView>) this.Lt_Details)
        {
          if (ltDetail.IsNew || ltDetail.IsUpdate)
          {
            ltDetail.sgd_GroupCode = this.sgh_GroupCode;
            ltDetail.sgd_SiteID = this.sgh_SiteID;
            if (ltDetail.IsNew)
            {
              if (!ltDetail.InsertData(p_db, p_app_employee, p_is_trans))
                throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 등록 오류");
            }
            else if (ltDetail.IsUpdate && !ltDetail.UpdateData(p_db, p_app_employee, p_is_trans))
              throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 변경 오류");
          }
        }
        if (p_is_trans)
          p_db.CommitTransaction();
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

    public virtual async Task<bool> InsertDetailsAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_new,
      bool p_is_trans = false)
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      try
      {
        if (p_is_new)
        {
          int count = storeGroupHeaderView.Lt_Details.Count;
        }
        if (storeGroupHeaderView.Lt_Details.Count == 0)
          return true;
        if (p_is_trans)
          p_db.BeginTransaction();
        foreach (StoreGroupDetailView detail in (IEnumerable<StoreGroupDetailView>) storeGroupHeaderView.Lt_Details)
        {
          if (detail.IsNew || detail.IsUpdate)
          {
            detail.sgd_GroupCode = storeGroupHeaderView.sgh_GroupCode;
            detail.sgd_SiteID = storeGroupHeaderView.sgh_SiteID;
            if (detail.IsNew)
            {
              if (!await detail.InsertDataAsync(p_db, p_app_employee, p_is_trans))
                throw new UniServiceException(detail.message, detail.TableCode.ToDescription() + " 등록 오류");
            }
            else if (detail.IsUpdate)
            {
              if (!await detail.UpdateDataAsync(p_db, p_app_employee, p_is_trans))
                throw new UniServiceException(detail.message, detail.TableCode.ToDescription() + " 변경 오류");
            }
          }
        }
        if (p_is_trans)
          p_db.CommitTransaction();
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        storeGroupHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        storeGroupHeaderView.message = ex.Message;
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
          if (this.sgh_SiteID == 0L)
            this.sgh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sgh_GroupCode == 0 && !this.CreateCode(p_db))
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
      StoreGroupHeaderView storeGroupHeaderView = this;
      try
      {
        storeGroupHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeGroupHeaderView.DataCheck(p_db))
            throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!storeGroupHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (storeGroupHeaderView.sgh_GroupCode == 0)
        {
          if (!await storeGroupHeaderView.CreateCodeAsync(p_db))
            throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await storeGroupHeaderView.InsertAsync())
          throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 등록 오류");
        storeGroupHeaderView.db_status = 4;
        storeGroupHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeGroupHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeGroupHeaderView.message = ex.Message;
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
        if (this.sgh_GroupCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 지점그룹 코드(sgh_GroupCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      StoreGroupHeaderView storeGroupHeaderView = this;
      try
      {
        storeGroupHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeGroupHeaderView.DataCheck(p_db))
            throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!storeGroupHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (storeGroupHeaderView.sgh_GroupCode == 0)
          throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 지점그룹 코드(sgh_GroupCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await storeGroupHeaderView.UpdateAsync())
          throw new UniServiceException(storeGroupHeaderView.message, storeGroupHeaderView.TableCode.ToDescription() + " 변경 오류");
        storeGroupHeaderView.db_status = 4;
        storeGroupHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeGroupHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeGroupHeaderView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<StoreGroupHeaderView> SelectOneAsync(int p_sgh_GroupCode, long p_sgh_SiteID = 0)
    {
      StoreGroupHeaderView storeGroupHeaderView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sgh_GroupCode",
          (object) p_sgh_GroupCode
        }
      };
      if (p_sgh_SiteID > 0L)
        p_param.Add((object) "sgh_SiteID", (object) p_sgh_SiteID);
      return await storeGroupHeaderView.SelectOneTAsync<StoreGroupHeaderView>((object) p_param);
    }

    public async Task<IList<StoreGroupHeaderView>> SelectListAsync(object p_param)
    {
      StoreGroupHeaderView storeGroupHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(storeGroupHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, storeGroupHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(storeGroupHeaderView1.GetSelectQuery(p_param)))
        {
          storeGroupHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StoreGroupHeaderView>) null;
        }
        IList<StoreGroupHeaderView> lt_list = (IList<StoreGroupHeaderView>) new List<StoreGroupHeaderView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StoreGroupHeaderView storeGroupHeaderView2 = storeGroupHeaderView1.OleDB.Create<StoreGroupHeaderView>();
            if (storeGroupHeaderView2.GetFieldValues(rs))
            {
              storeGroupHeaderView2.row_number = lt_list.Count + 1;
              lt_list.Add(storeGroupHeaderView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sgh_SiteID") && Convert.ToInt64(hashtable[(object) "sgh_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "sgh_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  sgh_GroupCode,sgh_SiteID,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn,sgh_InDate,sgh_InUser,sgh_ModDate,sgh_ModUser,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON sgh_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON sgh_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY sgh_GroupCode");
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
