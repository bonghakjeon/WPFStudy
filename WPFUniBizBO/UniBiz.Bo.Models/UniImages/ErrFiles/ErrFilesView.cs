// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.ErrFiles.ErrFilesView
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

namespace UniBiz.Bo.Models.UniImages.ErrFiles
{
  public class ErrFilesView : TErrFiles<ErrFilesView>
  {
    private string _inEmpName;
    private string _modEmpName;

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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ErrFilesView();

    public override object Clone()
    {
      ErrFilesView errFilesView = base.Clone() as ErrFilesView;
      errFilesView.inEmpName = this.inEmpName;
      errFilesView.modEmpName = this.modEmpName;
      return (object) errFilesView;
    }

    public void PutData(ErrFilesView pSource)
    {
      this.PutData((TErrFiles) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ef_SiteID == 0L)
      {
        this.message = "싸이트(ef_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.ef_FileName))
        return EnumDataCheck.Success;
      this.message = "파일명(ef_FileName)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ef_UUID), " + str + ")+1 AS ef_UUID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ef_UUID", (object) intFormat);
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
          this.ef_UUID = uniOleDbRecordset.GetFieldLong(0);
        return this.ef_UUID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      ErrFilesView errFilesView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(errFilesView.CreateCodeQuery()))
        {
          errFilesView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errFilesView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          errFilesView.ef_UUID = rs.GetFieldLong(0);
        return errFilesView.ef_UUID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.ef_UUID, (object) this.ef_SiteID));
    }

    public override async Task<bool> InsertAsync()
    {
      ErrFilesView errFilesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await errFilesView.\u003C\u003En__0())
        return false;
      if (errFilesView.IsOriginData)
      {
        int num = await errFilesView.UpdateFileAsync() ? 1 : 0;
      }
      return errFilesView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) errFilesView.ef_UUID, (object) errFilesView.ef_SiteID));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ef_UUID, (object) this.ef_SiteID));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      ErrFilesView errFilesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await errFilesView.\u003C\u003En__1(p_old))
        return false;
      if (errFilesView.IsOriginData)
      {
        int num = await errFilesView.UpdateFileAsync() ? 1 : 0;
      }
      return errFilesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) errFilesView.ef_UUID, (object) errFilesView.ef_SiteID));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ef_UUID, (object) this.ef_SiteID));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      ErrFilesView errFilesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await errFilesView.\u003C\u003En__2())
        return false;
      if (errFilesView.IsOriginData)
      {
        int num = await errFilesView.UpdateFileAsync() ? 1 : 0;
      }
      return errFilesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) errFilesView.ef_UUID, (object) errFilesView.ef_SiteID));
    }

    public override bool InsertData(
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
        else
        {
          if (this.ef_SiteID == 0L)
            this.ef_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ef_UUID == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
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
      ErrFilesView errFilesView = this;
      try
      {
        errFilesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != errFilesView.DataCheck(p_db))
            throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (errFilesView.ef_SiteID == 0L)
            errFilesView.ef_SiteID = p_app_employee.emp_SiteID;
          if (!errFilesView.IsPermit(p_app_employee))
            throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (errFilesView.ef_UUID == 0L)
        {
          if (!await errFilesView.CreateCodeAsync(p_db))
            throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await errFilesView.InsertAsync())
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        errFilesView.db_status = 4;
        errFilesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.Message;
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
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.ef_UUID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " UUID(ef_UUID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      ErrFilesView errFilesView = this;
      try
      {
        errFilesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != errFilesView.DataCheck(p_db))
            throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!errFilesView.IsPermit(p_app_employee))
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (errFilesView.ef_UUID == 0L)
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " UUID(ef_UUID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await errFilesView.UpdateAsync())
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        errFilesView.db_status = 4;
        errFilesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.Message;
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
        if (this.ef_UUID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " UUID(ef_UUID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      ErrFilesView errFilesView = this;
      try
      {
        errFilesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != errFilesView.DataCheck(p_db))
            throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!errFilesView.IsPermit(p_app_employee))
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (errFilesView.ef_UUID == 0L)
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " UUID(ef_UUID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await errFilesView.DeleteAsync())
          throw new UniServiceException(errFilesView.message, errFilesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        errFilesView.db_status = 4;
        errFilesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        errFilesView.message = ex.Message;
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

    public async Task<ErrFilesView> SelectOneAsync(
      long p_ef_UUID,
      long p_ef_SiteID = 0,
      bool p_is_file_data = false)
    {
      ErrFilesView errFilesView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ef_UUID",
          (object) p_ef_UUID
        },
        {
          (object) "IDS_ORIGIN_IMAGE",
          (object) p_is_file_data
        }
      };
      if (p_ef_SiteID > 0L)
        p_param.Add((object) "ef_SiteID", (object) p_ef_SiteID);
      return await errFilesView.SelectOneTAsync<ErrFilesView>((object) p_param);
    }

    public async Task<IList<ErrFilesView>> SelectListAsync(object p_param)
    {
      ErrFilesView errFilesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(errFilesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, errFilesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(errFilesView1.GetSelectQuery(p_param)))
        {
          errFilesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errFilesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ErrFilesView>) null;
        }
        IList<ErrFilesView> lt_list = (IList<ErrFilesView>) new List<ErrFilesView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ErrFilesView errFilesView2 = errFilesView1.OleDB.Create<ErrFilesView>();
            if (errFilesView2.GetFieldValues(rs))
            {
              errFilesView2.row_number = lt_list.Count + 1;
              lt_list.Add(errFilesView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errFilesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ErrFilesView> SelectEnumerableAsync(object p_param)
    {
      ErrFilesView errFilesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(errFilesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, errFilesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(errFilesView1.GetSelectQuery(p_param)))
        {
          errFilesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + errFilesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ErrFilesView errFilesView2 = errFilesView1.OleDB.Create<ErrFilesView>();
            if (errFilesView2.GetFieldValues(rs))
            {
              errFilesView2.row_number = ++row_number;
              yield return errFilesView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ef_FileName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ef_Remark", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ef_SiteID") && Convert.ToInt64(hashtable[(object) "ef_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ef_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IDS_ORIGIN_IMAGE") && Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  ef_UUID,ef_SiteID,ef_FileName,ef_Type,ef_Remark,ef_OriginSize,ef_InDate,ef_InUser,ef_ModDate,ef_ModUser");
        if (flag)
          stringBuilder.Append(",ef_OriginData");
        stringBuilder.Append("\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ef_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ef_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ef_UUID");
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
