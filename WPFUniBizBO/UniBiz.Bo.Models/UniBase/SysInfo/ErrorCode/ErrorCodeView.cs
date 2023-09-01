// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode.ErrorCodeView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode
{
  public class ErrorCodeView : TErrorCode<ErrorCodeView>
  {
    protected override EnumDataCheck DataCheck()
    {
      if (this.err_SiteID == 0L)
      {
        this.message = "싸이트(err_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.err_ViewCode))
        return EnumDataCheck.Success;
      this.message = "ErrorCode(err_ViewCode)  " + EnumDataCheck.Empty.ToDescription();
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
      if (!p_app_employee.IsAdmin)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(err_ID), 0)+1 AS err_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.err_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.err_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      ErrorCodeView errorCodeView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(errorCodeView.CreateCodeQuery()))
        {
          errorCodeView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errorCodeView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          errorCodeView.err_ID = rs.GetFieldInt(0);
        return errorCodeView.err_ID > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
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
          if (this.err_SiteID == 0L)
            this.err_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.err_ID == 0 && !this.CreateCode(p_db))
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
      ErrorCodeView errorCodeView = this;
      try
      {
        errorCodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != errorCodeView.DataCheck(p_db))
            throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (errorCodeView.err_SiteID == 0L)
            errorCodeView.err_SiteID = p_app_employee.emp_SiteID;
          if (!errorCodeView.IsPermit(p_app_employee))
            throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (errorCodeView.err_ID == 0)
        {
          if (!await errorCodeView.CreateCodeAsync(p_db))
            throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await errorCodeView.InsertAsync())
          throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 등록 오류");
        errorCodeView.db_status = 4;
        errorCodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        errorCodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        errorCodeView.message = ex.Message;
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
        if (this.err_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID (Key)(err_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      ErrorCodeView errorCodeView = this;
      try
      {
        errorCodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != errorCodeView.DataCheck(p_db))
            throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!errorCodeView.IsPermit(p_app_employee))
          throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (errorCodeView.err_ID == 0)
          throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " ID (Key)(err_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await errorCodeView.UpdateAsync())
          throw new UniServiceException(errorCodeView.message, errorCodeView.TableCode.ToDescription() + " 변경 오류");
        errorCodeView.db_status = 4;
        errorCodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        errorCodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        errorCodeView.message = ex.Message;
      }
      return false;
    }

    public async Task<ErrorCodeView> SelectOneAsync(int p_err_ID, long p_err_SiteID = 0)
    {
      ErrorCodeView errorCodeView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "err_ID",
          (object) p_err_ID
        }
      };
      if (p_err_SiteID > 0L)
        p_param.Add((object) "err_SiteID", (object) p_err_SiteID);
      return await errorCodeView.SelectOneTAsync<ErrorCodeView>((object) p_param);
    }

    public async Task<IList<ErrorCodeView>> SelectListAsync(object p_param)
    {
      ErrorCodeView errorCodeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(errorCodeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, errorCodeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(errorCodeView1.GetSelectQuery(p_param)))
        {
          errorCodeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errorCodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ErrorCodeView>) null;
        }
        IList<ErrorCodeView> lt_list = (IList<ErrorCodeView>) new List<ErrorCodeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ErrorCodeView errorCodeView2 = errorCodeView1.OleDB.Create<ErrorCodeView>();
            if (errorCodeView2.GetFieldValues(rs))
            {
              errorCodeView2.row_number = lt_list.Count + 1;
              lt_list.Add(errorCodeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errorCodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ErrorCodeView> SelectEnumerableAsync(object p_param)
    {
      ErrorCodeView errorCodeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(errorCodeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, errorCodeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(errorCodeView1.GetSelectQuery(p_param)))
        {
          errorCodeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errorCodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ErrorCodeView errorCodeView2 = errorCodeView1.OleDB.Create<ErrorCodeView>();
            if (errorCodeView2.GetFieldValues(rs))
            {
              errorCodeView2.row_number = ++row_number;
              yield return errorCodeView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "err_ViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }
  }
}
