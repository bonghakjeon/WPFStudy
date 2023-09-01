// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpAuthority.EmpAuthorityView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpAuthority
{
  public class EmpAuthorityView : TEmpAuthority<EmpAuthorityView>
  {
    private string _emp_Name;

    public string emp_Name
    {
      get => this._emp_Name;
      set
      {
        this._emp_Name = value;
        this.Changed(nameof (emp_Name));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("emp_Name", new TTableColumn()
      {
        tc_orgin_name = "emp_Name",
        tc_trans_name = "사원명",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.emp_Name = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmpAuthorityView();

    public override object Clone()
    {
      EmpAuthorityView empAuthorityView = base.Clone() as EmpAuthorityView;
      empAuthorityView.emp_Name = this.emp_Name;
      return (object) empAuthorityView;
    }

    public void PutData(EmpAuthorityView pSource)
    {
      this.PutData((TEmpAuthority) pSource);
      this.emp_Name = pSource.emp_Name;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ea_AuthType == 0)
      {
        this.message = "타입(지점,분류,거래처)(ea_AuthType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ea_EmpCode == 0)
      {
        this.message = "사원코드(ea_EmpCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ea_AuthValue))
      {
        this.message = "허용코드(ea_AuthValue)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.ea_SiteID != 0L)
        return EnumDataCheck.Success;
      this.message = "싸이트(ea_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (!p_app_employee.IsEmployeePermitSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      return this.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 등록됨.", (object) this.ea_AuthType, (object) this.ea_EmpCode, (object) this.ea_AuthValue, (object) this.ea_SiteID));
    }

    public override async Task<bool> InsertAsync()
    {
      EmpAuthorityView empAuthorityView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await empAuthorityView.\u003C\u003En__0())
        return false;
      return empAuthorityView.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 등록됨.", (object) empAuthorityView.ea_AuthType, (object) empAuthorityView.ea_EmpCode, (object) empAuthorityView.ea_AuthValue, (object) empAuthorityView.ea_SiteID));
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
          if (this.ea_SiteID == 0L)
            this.ea_SiteID = p_app_employee.emp_SiteID;
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
      EmpAuthorityView empAuthorityView = this;
      try
      {
        empAuthorityView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != empAuthorityView.DataCheck(p_db))
            throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (empAuthorityView.ea_SiteID == 0L)
            empAuthorityView.ea_SiteID = p_app_employee.emp_SiteID;
          if (!empAuthorityView.IsPermit(p_app_employee))
            throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await empAuthorityView.InsertAsync())
          throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 등록 오류");
        empAuthorityView.db_status = 4;
        empAuthorityView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        empAuthorityView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        empAuthorityView.message = ex.Message;
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
      EmpAuthorityView empAuthorityView = this;
      try
      {
        empAuthorityView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != empAuthorityView.DataCheck(p_db))
            throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!empAuthorityView.IsPermit(p_app_employee))
          throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await empAuthorityView.UpdateAsync())
          throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 변경 오류");
        empAuthorityView.db_status = 4;
        empAuthorityView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        empAuthorityView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        empAuthorityView.message = ex.Message;
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
      EmpAuthorityView empAuthorityView = this;
      try
      {
        empAuthorityView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != empAuthorityView.DataCheck(p_db))
            throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!empAuthorityView.IsPermit(p_app_employee))
          throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await empAuthorityView.DeleteAsync())
          throw new UniServiceException(empAuthorityView.message, empAuthorityView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        empAuthorityView.db_status = 4;
        empAuthorityView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empAuthorityView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empAuthorityView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      return true;
    }

    public async Task<EmpAuthorityView> SelectOneAsync(
      int p_ea_EmpCode,
      int p_ea_AuthType,
      string p_ea_AuthValue,
      long p_ea_SiteID = 0)
    {
      EmpAuthorityView empAuthorityView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ea_EmpCode",
          (object) p_ea_EmpCode
        },
        {
          (object) "ea_AuthType",
          (object) p_ea_AuthType
        },
        {
          (object) "ea_AuthValue",
          (object) p_ea_AuthValue
        }
      };
      if (p_ea_SiteID > 0L)
        p_param.Add((object) "ea_SiteID", (object) p_ea_SiteID);
      return await empAuthorityView.SelectOneTAsync<EmpAuthorityView>((object) p_param);
    }

    public async Task<IList<EmpAuthorityView>> SelectListAsync(object p_param)
    {
      EmpAuthorityView empAuthorityView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(empAuthorityView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, empAuthorityView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(empAuthorityView1.GetSelectQuery(p_param)))
        {
          empAuthorityView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empAuthorityView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<EmpAuthorityView>) null;
        }
        IList<EmpAuthorityView> lt_list = (IList<EmpAuthorityView>) new List<EmpAuthorityView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            EmpAuthorityView empAuthorityView2 = empAuthorityView1.OleDB.Create<EmpAuthorityView>();
            if (empAuthorityView2.GetFieldValues(rs))
            {
              empAuthorityView2.row_number = lt_list.Count + 1;
              lt_list.Add(empAuthorityView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empAuthorityView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "emp_Name", hashtable[(object) "_KEY_WORD_"]));
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ea_SiteID") && Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code,emp_SiteID,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  ea_EmpCode,ea_AuthType,ea_AuthValue,ea_SiteID,ea_InputYn,ea_PrintYn,emp_Name");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON ea_EmpCode=emp_Code AND ea_SiteID=emp_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ea_EmpCode,ea_AuthType,ea_AuthValue");
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
