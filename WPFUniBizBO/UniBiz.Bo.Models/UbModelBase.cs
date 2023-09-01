// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbModelBase
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models
{
  public class UbModelBase : UniClass, ICloneable, IUbModelBase
  {
    public static string UNI_BASE = DBHelper.UNI_BASE;
    public static string UNI_SALES = DBHelper.UNI_SALES;
    public static string UNI_TR_DATA = DBHelper.UNI_TR_DATA;
    public static string UNI_STOCK = DBHelper.UNI_STOCK;
    public static string UNI_MEMBERS = DBHelper.UNI_MEMBERS;
    public static string UNI_INTERFACE = DBHelper.UNI_INTERFACE;
    public static string UNI_SMS = DBHelper.UNI_SMS;
    public static string UNI_POP = DBHelper.UNI_POP;
    public static string UNI_IMAGES = DBHelper.UNI_IMAGES;
    public static string UNI_CAMPANIGN = DBHelper.UNI_CAMPANIGN;
    protected static string UNI_POS = "UniPos";
    private int _row_number;
    private int _db_status;
    private int _RowStatus = 1;
    private EnumRowStatus _RowErrorStatus = EnumRowStatus.Success;
    private TableCodeType _TableCode;

    public int row_number
    {
      get => this._row_number;
      set
      {
        this._row_number = value;
        this.Changed(nameof (row_number));
      }
    }

    public virtual DateTime? ModDate => new DateTime?();

    public virtual string EmpName => (string) null;

    public string message { get; set; }

    public string GetMessage(string value) => this.message != null && this.message.Length != 0 ? this.message : value;

    public virtual object _Key { get; }

    public int db_status
    {
      get => this._db_status;
      set
      {
        this._db_status = value;
        this.Changed(nameof (db_status));
        this.Changed("DB_STATUS");
      }
    }

    [JsonIgnore]
    public EnumDBStatus DB_STATUS
    {
      get => (EnumDBStatus) this.db_status;
      set
      {
        this.db_status = (int) value;
        this.Changed(nameof (DB_STATUS));
        this.Changed("IsNone");
        this.Changed("IsNew");
        this.Changed("IsNewNot");
        this.Changed("IsUpdate");
        this.Changed("IsDeleteStatus");
        this.Changed("IsSaved");
      }
    }

    public bool IsNone => this.DB_STATUS == EnumDBStatus.NONE;

    public bool IsNew => this.DB_STATUS == EnumDBStatus.NEW;

    public bool IsNewNot => this.DB_STATUS != EnumDBStatus.NEW;

    public bool IsUpdate => this.DB_STATUS == EnumDBStatus.UPDATE;

    public bool IsDeleteStatus => this.DB_STATUS == EnumDBStatus.DELETE;

    public bool IsSaved => this.DB_STATUS == EnumDBStatus.SAVED;

    public int RowStatus
    {
      get => this._RowStatus;
      set
      {
        this._RowStatus = value;
        this.Changed(nameof (RowStatus));
        this.Changed("RowErrorStatus");
      }
    }

    [JsonIgnore]
    public EnumRowStatus RowErrorStatus
    {
      get => this._RowErrorStatus;
      set => this._RowErrorStatus = value;
    }

    [JsonIgnore]
    public TableCodeType TableCode
    {
      get => this._TableCode;
      set => this._TableCode = value;
    }

    public bool isError => this.RowStatus != 1;

    public bool isSuccess => this.RowStatus == 1;

    [JsonIgnore]
    public ModelSatus RowCheckStatus { get; } = new ModelSatus();

    protected static string _ClassName => MethodBase.GetCurrentMethod().ReflectedType.Name;

    protected static string GetAsyncMethodName([CallerMemberName] string name = null) => name;

    protected virtual UbModelBase CreateClone => new UbModelBase();

    public virtual object Clone()
    {
      UbModelBase createClone = this.CreateClone;
      createClone.row_number = this.row_number;
      createClone.db_status = this.db_status;
      createClone.SetAdoDatabase(this.OleDB);
      return (object) createClone;
    }

    public virtual void PutData(UbModelBase pSource)
    {
      this.row_number = pSource.row_number;
      this.db_status = pSource.db_status;
      this.SetAdoDatabase(pSource.OleDB);
    }

    public virtual void Clear()
    {
      this.row_number = 0;
      this.DB_STATUS = EnumDBStatus.NONE;
      this._RowErrorStatus = EnumRowStatus.Success;
      this.message = string.Empty;
    }

    public virtual Dictionary<string, TTableColumn> ToColumnInfo() => new Dictionary<string, TTableColumn>()
    {
      {
        "row_number",
        new TTableColumn()
        {
          tc_orgin_name = "row_number",
          tc_trans_name = "No"
        }
      },
      {
        "ModDate",
        new TTableColumn()
        {
          tc_orgin_name = "ModDate",
          tc_trans_name = "수정일"
        }
      },
      {
        "EmpName",
        new TTableColumn()
        {
          tc_orgin_name = "EmpName",
          tc_trans_name = "수정사원"
        }
      }
    };

    protected virtual EnumDataCheck DataCheck() => EnumDataCheck.Success;

    protected virtual EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      int num = this.IsNew ? 1 : 0;
      return EnumDataCheck.Success;
    }

    protected virtual async Task<EnumDataCheck> DataCheckAsync(UniOleDatabase p_db)
    {
      object obj = (object) null;
      int num = 0;
      EnumDataCheck enumDataCheck;
      try
      {
        EnumDataCheck enumDataCheck1 = this.DataCheck();
        if (enumDataCheck1 != EnumDataCheck.Success)
          enumDataCheck = enumDataCheck1;
        else if (p_db == null)
        {
          this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
          enumDataCheck = EnumDataCheck.NULL;
        }
        else
        {
          int num1 = this.IsNew ? 1 : 0;
          enumDataCheck = EnumDataCheck.Success;
        }
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return enumDataCheck;
      obj = (object) null;
      EnumDataCheck enumDataCheck2;
      return enumDataCheck2;
    }

    protected virtual bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public bool SetErrorInfo(long p_dwError, string p_lpszErrorMsg1)
    {
      this.message = " 테이블 : " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 에러 : \n" + string.Format(" 코드 : {0}\n", (object) p_dwError) + " 내용 : " + p_lpszErrorMsg1 + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public bool SetSuccessInfo(string p_lpszMsg)
    {
      this.message = " 테이블 : " + this.TableCode.ToDescription() + " 성공\n--------------------------------------------------------------------------------------------------\n 내용 : " + p_lpszMsg + "\n--------------------------------------------------------------------------------------------------\n";
      return true;
    }

    public bool SetSuccessInfo(string format, object[] parameters)
    {
      this.message = " 테이블 : " + this.TableCode.ToDescription() + " 성공\n--------------------------------------------------------------------------------------------------\n 내용 : " + string.Format(format, parameters).Substring(0, 4096) + "\n--------------------------------------------------------------------------------------------------\n";
      return true;
    }

    public virtual string CreateCodeQuery() => string.Empty;

    public virtual bool CreateCode(UniOleDatabase p_db) => this.CreateCodeChecked();

    public virtual async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      object obj = (object) null;
      int num = 0;
      bool codeChecked;
      try
      {
        codeChecked = this.CreateCodeChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return codeChecked;
      obj = (object) null;
      bool codeAsync;
      return codeAsync;
    }

    protected virtual bool CreateCodeChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual bool GetFieldValues(UniOleDbRecordset p_rs) => true;

    public virtual string InsertQuery() => string.Empty;

    public virtual bool Insert() => this.InsertChecked();

    public virtual bool Insert(string p_Query) => this.InsertChecked();

    public virtual async Task<bool> InsertQueryExecuteAsync(string p_Query)
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.InsertChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.Yield();
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    public virtual async Task<bool> InsertAsync()
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.InsertChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    protected virtual bool InsertChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual string TruncateQuery() => string.Empty;

    public virtual bool Truncate() => this.TruncateChecked();

    protected virtual bool TruncateChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual string UpdateQuery() => string.Empty;

    public virtual bool Update() => this.Update((UbModelBase) null);

    public virtual bool Update(UbModelBase p_old = null) => this.UpdateChecked();

    public virtual async Task<bool> UpdateQueryExecuteAsync(string p_Query)
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.UpdateChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    public virtual async Task<bool> UpdateAsync()
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = await this.UpdateAsync((UbModelBase) null);
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    public virtual async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.UpdateChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    protected virtual bool UpdateChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual string UpdateExInsertQuery()
    {
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          return this.UpdateExInsertMsSQLQuery();
        case EnumDB.MYSQL:
          return this.UpdateExInsertMySQLQuery();
        default:
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (UpdateExInsertQuery)) + " 미지원 서비스.");
      }
    }

    public virtual string UpdateExInsertMsSQLQuery() => " " + this.UpdateQuery() + "  IF @@ROWCOUNT = 0  " + this.InsertQuery();

    public virtual string UpdateExInsertMySQLQuery() => throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (UpdateExInsertMySQLQuery)) + " 미지원 서비스.");

    public virtual bool UpdateExInsert() => this.UpdateChecked();

    public virtual async Task<bool> UpdateExInsertAsync()
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.UpdateChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    public virtual string DeleteQuery() => string.Empty;

    public virtual bool Delete() => this.DeleteChecked();

    public virtual async Task<bool> DeleteAsync()
    {
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        flag = this.UpdateChecked();
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      bool flag1;
      return flag1;
    }

    protected virtual bool DeleteChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual bool Execute(string p_Query)
    {
      this.CheckAdoDatabase();
      if (string.IsNullOrEmpty(p_Query))
        return false;
      if (!this.OleDB.Execute(p_Query))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 쿼리 : [" + p_Query + "]\n 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> ExecuteAsync(string p_Query)
    {
      UbModelBase ubModelBase = this;
      ubModelBase.CheckAdoDatabase();
      if (string.IsNullOrEmpty(p_Query))
        return false;
      if (await ubModelBase.OleDB.ExecuteAsync(p_Query))
        return true;
      ubModelBase.message = " " + ubModelBase.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ubModelBase.OleDB.LastErrorID) + " 쿼리 : [" + p_Query + "]\n 내용 : " + ubModelBase.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(ubModelBase.message);
      return false;
    }

    public virtual bool Save()
    {
      this.SaveChecked();
      if (this.IsNew)
        return this.Insert();
      if (this.IsUpdate)
        return this.Update((UbModelBase) null);
      throw new Exception(this.TableCode.ToDescription() + " SAVE 작업 안함.");
    }

    public virtual async Task<bool> SaveAsync()
    {
      this.SaveChecked();
      if (this.IsNew)
        return await this.InsertAsync();
      if (this.IsUpdate)
        return await this.UpdateAsync((UbModelBase) null);
      throw new Exception(this.TableCode.ToDescription() + " SAVE 작업 안함.");
    }

    protected virtual bool SaveChecked()
    {
      this.CheckAdoDatabase();
      return true;
    }

    public virtual bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (InsertData)) + " 미지원 서비스.");
    }

    public virtual async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      await Task.CompletedTask;
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (InsertDataAsync)) + " 미지원 서비스.");
    }

    public virtual bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (UpdateData)) + " 미지원 서비스.");
    }

    public virtual async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      await Task.CompletedTask;
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (UpdateDataAsync)) + " 미지원 서비스.");
    }

    public virtual bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (DeleteData)) + " 미지원 서비스.");
    }

    public virtual async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      await Task.CompletedTask;
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " " + UbModelBase.GetAsyncMethodName(nameof (DeleteDataAsync)) + " 미지원 서비스.");
    }

    public virtual T SelectOneT<T>(object p_param) where T : UbModelBase, new()
    {
      UniOleDbRecordset p_rs = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        p_rs = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (!p_rs.Open(this.GetSelectQuery(p_param)))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n QUERY : " + p_rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + p_rs.LastQuery);
          return default (T);
        }
        IList<T> objList = (IList<T>) new List<T>();
        if (p_rs.IsDataRead())
        {
          T obj = this.OleDB.Create<T>();
          if (obj.GetFieldValues(p_rs))
          {
            obj.row_number = objList.Count + 1;
            return obj;
          }
        }
        return default (T);
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        p_rs?.Close();
        pOleDB?.Close();
      }
    }

    public virtual IList<E> SelectListE<E>(object p_param) where E : UbModelBase, new()
    {
      UniOleDbRecordset p_rs = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        p_rs = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (!p_rs.Open(this.GetSelectQuery(p_param)))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n QUERY : " + p_rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + p_rs.LastQuery);
          return (IList<E>) null;
        }
        IList<E> eList = (IList<E>) new List<E>();
        if (p_rs.IsDataRead())
        {
          do
          {
            E e1 = this.OleDB.Create<E>();
            if (e1.GetFieldValues(p_rs))
            {
              e1.row_number = eList.Count + 1;
              eList.Add(e1);
            }
            E e2 = default (E);
          }
          while (p_rs.IsDataRead());
        }
        return eList;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        p_rs?.Close();
        pOleDB?.Close();
      }
    }

    public virtual IList<E> SelectAllListE<E>(object p_param) where E : UbModelBase, new()
    {
      UniOleDbRecordset p_rs = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        p_rs = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (!p_rs.Open(this.GetSelectQueryAll(p_param)))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n QUERY : " + p_rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + p_rs.LastQuery);
          return (IList<E>) null;
        }
        IList<E> eList = (IList<E>) new List<E>();
        if (p_rs.IsDataRead())
        {
          do
          {
            E e1 = this.OleDB.Create<E>();
            if (e1.GetFieldValues(p_rs))
            {
              e1.row_number = eList.Count + 1;
              eList.Add(e1);
            }
            E e2 = default (E);
          }
          while (p_rs.IsDataRead());
        }
        return eList;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        p_rs?.Close();
        pOleDB?.Close();
      }
    }

    public virtual IEnumerable<E> SelectAllEnumerableE<E>(object p_param) where E : UbModelBase, new()
    {
      UbModelBase ubModelBase = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(ubModelBase.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, ubModelBase.OleDB.CommandTimeout);
        if (!rs.Open(ubModelBase.GetSelectQueryAll(p_param)))
        {
          ubModelBase.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
        }
        else if (rs.IsDataRead())
        {
          int row_number = 0;
          do
          {
            E e = ubModelBase.OleDB.Create<E>();
            if (e.GetFieldValues(rs))
            {
              e.row_number = ++row_number;
              yield return e;
            }
          }
          while (rs.IsDataRead());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual async Task<T> SelectOneTAsync<T>(object p_param) where T : UbModelBase, new()
    {
      UbModelBase ubModelBase = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(ubModelBase.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, ubModelBase.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(ubModelBase.GetSelectQuery(p_param)))
        {
          ubModelBase.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
          return default (T);
        }
        IList<T> lt_list = (IList<T>) new List<T>();
        if (await rs.IsDataReadAsync())
        {
          T obj = ubModelBase.OleDB.Create<T>();
          if (obj.GetFieldValues(rs))
          {
            obj.row_number = lt_list.Count + 1;
            return obj;
          }
        }
        return default (T);
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual async Task<IList<E>> SelectListEAsync<E>(object p_param) where E : UbModelBase, new()
    {
      UbModelBase ubModelBase = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(ubModelBase.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, ubModelBase.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(ubModelBase.GetSelectQuery(p_param)))
        {
          ubModelBase.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
          return (IList<E>) null;
        }
        IList<E> lt_list = (IList<E>) new List<E>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            E e1 = ubModelBase.OleDB.Create<E>();
            if (e1.GetFieldValues(rs))
            {
              e1.row_number = lt_list.Count + 1;
              lt_list.Add(e1);
            }
            E e2 = default (E);
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + " IP : " + ubModelBase.OleDB.ConnectionIP + "\n--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual async IAsyncEnumerable<E> SelectEnumerableEAsync<E>(object p_param) where E : UbModelBase, new()
    {
      UbModelBase ubModelBase = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(ubModelBase.GetSelectQuery(p_param)))
        {
          ubModelBase.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            E e = ubModelBase.OleDB.Create<E>();
            if (e.GetFieldValues(rs))
            {
              e.row_number = ++row_number;
              yield return e;
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

    public virtual int SelectCountE<E>(object p_param) where E : UbModelBase
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (!uniOleDbRecordset.Open(this.GetSelectQueryCount(p_param)))
        {
          this.SetErrorInfo(uniOleDbRecordset.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) uniOleDbRecordset.LastErrorID) + " 내용 : " + uniOleDbRecordset.LastErrorMessage + "\n QUERY : " + uniOleDbRecordset.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
          Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + uniOleDbRecordset.LastQuery);
          return 0;
        }
        return uniOleDbRecordset.IsDataRead() ? uniOleDbRecordset.GetFieldInt(0) : 0;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public virtual async Task<int> SelectCountEAsync<E>(object p_param) where E : UbModelBase
    {
      UbModelBase ubModelBase = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(ubModelBase.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, ubModelBase.OleDB.CommandTimeout);
        if (await rs.OpenAsync(ubModelBase.GetSelectQueryCount(p_param)))
          return !await rs.IsDataReadAsync() ? 0 : rs.GetFieldInt(0);
        ubModelBase.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n QUERY : " + rs.LastQuery + "\n--------------------------------------------------------------------------------------------------\n");
        Log.Logger.DebugColor("검색 오류 - SQL OPEN 실패 \n QUERY :" + rs.LastQuery);
        return 0;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + ubModelBase.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + " IP : " + ubModelBase.OleDB.ConnectionIP + "\n--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual string GetSelectWhereAnd(object p_param) => this.GetSelectWhereAnd(p_param, true);

    public virtual string GetSelectWhereAnd(object p_param, bool p_isKeyWord) => string.Empty;

    public virtual string GetSelectQuery(object p_param) => string.Empty;

    public virtual string GetSelectQueryCount(object p_param) => string.Empty;

    public virtual string GetSelectQueryAll(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniPos = UbModelBase.UNI_POS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable1)
        {
          if (hashtable1.ContainsKey((object) "DBMS") && hashtable1[(object) "DBMS"].ToString().Length > 0)
            uniPos = hashtable1[(object) "DBMS"].ToString();
          if (hashtable1.ContainsKey((object) "table") && hashtable1[(object) "table"].ToString().Length > 0)
            str = hashtable1[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT * FROM " + DbQueryHelper.ToDBNameBridge(uniPos) + str + " " + DbQueryHelper.ToWithNolock());
        Hashtable hashtable2 = p_param as Hashtable;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public static string LeftStr(string p_str, int p_len) => p_str.ToLeftByte(p_len, false);

    public static async Task<bool> IsDatabaseAsync(UniOleDatabase pDB, string dbms)
    {
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        string empty = string.Empty;
        db = new UniOleDatabase(pDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, pDB.CommandTimeout);
        if (!rs.Open("SELECT * FROM sys.sysdatabases WITH (NOLOCK) WHERE name='" + dbms + "'"))
          throw new UniServiceException(rs.LastErrorMessage, "데이터베이스 SELECT ERROR.", 2);
        IList<string> lt_list = (IList<string>) new List<string>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            lt_list.Add(rs.GetFieldString(0));
          }
          while (rs.IsDataRead());
        }
        return lt_list.Count > 0;
      }
      catch (UniServiceException ex)
      {
        Log.Logger.ErrorColor("\n-----------------\n 데이터베이스 조회 에러\n - error = " + ex.UserMessage + "\n" + ex.Message + "\n-----------------");
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n-----------------\n 데이터베이스 조회 에러\n - error = " + ex.Message + "\n-----------------");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
      return false;
    }
  }
}
