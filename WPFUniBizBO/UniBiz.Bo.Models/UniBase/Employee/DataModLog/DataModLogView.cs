// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.DataModLog.DataModLogView
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

namespace UniBiz.Bo.Models.UniBase.Employee.DataModLog
{
  public class DataModLogView : TDataModLog<DataModLogView>
  {
    private string _si_StoreName;
    private string _emp_Name;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

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
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
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
      this.si_StoreName = string.Empty;
      this.emp_Name = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new DataModLogView();

    public override object Clone()
    {
      DataModLogView dataModLogView = base.Clone() as DataModLogView;
      dataModLogView.si_StoreName = this.si_StoreName;
      dataModLogView.emp_Name = this.emp_Name;
      return (object) dataModLogView;
    }

    public void PutData(DataModLogView pSource)
    {
      this.PutData((TDataModLog) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.emp_Name = pSource.emp_Name;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.dml_SiteID != 0L)
        return EnumDataCheck.Success;
      this.message = "싸이트(dml_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee != null)
        return true;
      this.message = "사용자 정보 NULL.";
      return false;
    }

    public void Init(LogInSmallPack p_login_employee)
    {
      if (p_login_employee == null || p_login_employee.employee == null)
        return;
      this.dml_EmpCode = p_login_employee.employee.emp_Code;
      if (p_login_employee.DeviceKey > 0)
        this.dml_DeviceKey = p_login_employee.DeviceKey.ToString();
      this.dml_DeviceName = p_login_employee.DeviceName;
      this.dml_SiteID = p_login_employee.employee.emp_SiteID;
    }

    public void Init(
      LogInSmallPack p_login_employee,
      TableCodeType pTableID,
      EnumEmpActionKind pEmpActionKind)
    {
      this.Init(p_login_employee);
      this.dml_TableSeq = (int) pTableID;
      this.dml_ActionKind = (int) pEmpActionKind;
    }

    public void Init(
      LogInSmallPack p_login_employee,
      TableCodeType pTableID,
      EnumEmpActionKind pEmpActionKind,
      int pStoreCode)
    {
      this.Init(p_login_employee, pTableID, pEmpActionKind);
      this.dml_StoreCode = pStoreCode;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      string nowTime = DateHelper.GetNowTime("yyyyMMdd");
      string str = string.Format("{0}{1:D4}0000", (object) nowTime, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(dml_ID), " + str + ")+1 AS dml_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE CONVERT(INT,(dml_ID/100000000))=" + nowTime;
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
          this.dml_ID = uniOleDbRecordset.GetFieldLong(0);
        return this.dml_ID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      DataModLogView dataModLogView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(dataModLogView.CreateCodeQuery()))
        {
          dataModLogView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dataModLogView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          dataModLogView.dml_ID = rs.GetFieldLong(0);
        return dataModLogView.dml_ID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.dml_ID != 0L || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.dml_ID, (object) this.dml_SiteID));

    public override async Task<bool> InsertAsync()
    {
      DataModLogView dataModLogView = this;
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      if (!dataModLogView.dml_SysDate.HasValue)
        dataModLogView.dml_SysDate = new DateTime?(DateTime.Now);
      // ISSUE: reference to a compiler-generated method
      return await dataModLogView.\u003C\u003En__0() && dataModLogView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) dataModLogView.dml_ID, (object) dataModLogView.dml_SiteID));
    }

    public async Task<bool> LogInfoAsync(
      UniOleDatabase p_db,
      string p_ModColumn,
      string p_ModColumnDesc,
      string p_BeforeValue,
      string p_AfterValue)
    {
      DataModLogView dataModLogView = this;
      dataModLogView.SetAdoDatabase(p_db);
      dataModLogView.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        dataModLogView.dml_ModColumnDesc = p_ModColumn;
      else
        dataModLogView.dml_ModColumnDesc = p_ModColumnDesc;
      dataModLogView.dml_BeforeValue = p_BeforeValue;
      dataModLogView.dml_AfterValue = p_AfterValue;
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      return await dataModLogView.InsertAsync();
    }

    public string LogInfoQuery(
      string p_ModColumn,
      string p_ModColumnDesc,
      string p_BeforeValue,
      string p_AfterValue)
    {
      this.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        this.dml_ModColumnDesc = p_ModColumn;
      else
        this.dml_ModColumnDesc = p_ModColumnDesc;
      this.dml_BeforeValue = p_BeforeValue;
      this.dml_AfterValue = p_AfterValue;
      return this.InsertQuery();
    }

    public async Task<bool> LogInfoAsync(
      UniOleDatabase p_db,
      string p_ModColumn,
      string p_ModColumnDesc,
      int p_BeforeValue,
      int p_AfterValue)
    {
      DataModLogView dataModLogView = this;
      dataModLogView.SetAdoDatabase(p_db);
      dataModLogView.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        dataModLogView.dml_ModColumnDesc = p_ModColumn;
      else
        dataModLogView.dml_ModColumnDesc = p_ModColumnDesc;
      dataModLogView.dml_BeforeValue = p_BeforeValue.ToString();
      dataModLogView.dml_AfterValue = p_AfterValue.ToString();
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      return await dataModLogView.InsertAsync();
    }

    public string LogInfoQuery(
      string p_ModColumn,
      string p_ModColumnDesc,
      int p_BeforeValue,
      int p_AfterValue)
    {
      this.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        this.dml_ModColumnDesc = p_ModColumn;
      else
        this.dml_ModColumnDesc = p_ModColumnDesc;
      this.dml_BeforeValue = p_BeforeValue.ToString();
      this.dml_AfterValue = p_AfterValue.ToString();
      return this.InsertQuery();
    }

    public async Task<bool> LogInfoAsync(
      UniOleDatabase p_db,
      string p_ModColumn,
      string p_ModColumnDesc,
      long p_BeforeValue,
      long p_AfterValue)
    {
      DataModLogView dataModLogView = this;
      dataModLogView.SetAdoDatabase(p_db);
      dataModLogView.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        dataModLogView.dml_ModColumnDesc = p_ModColumn;
      else
        dataModLogView.dml_ModColumnDesc = p_ModColumnDesc;
      dataModLogView.dml_BeforeValue = p_BeforeValue.ToString();
      dataModLogView.dml_AfterValue = p_AfterValue.ToString();
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      return await dataModLogView.InsertAsync();
    }

    public string LogInfoQuery(
      string p_ModColumn,
      string p_ModColumnDesc,
      long p_BeforeValue,
      long p_AfterValue)
    {
      this.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        this.dml_ModColumnDesc = p_ModColumn;
      else
        this.dml_ModColumnDesc = p_ModColumnDesc;
      this.dml_BeforeValue = p_BeforeValue.ToString();
      this.dml_AfterValue = p_AfterValue.ToString();
      return this.InsertQuery();
    }

    public async Task<bool> LogInfoAsync(
      UniOleDatabase p_db,
      string p_ModColumn,
      string p_ModColumnDesc,
      double p_BeforeValue,
      double p_AfterValue)
    {
      DataModLogView dataModLogView = this;
      dataModLogView.SetAdoDatabase(p_db);
      dataModLogView.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        dataModLogView.dml_ModColumnDesc = p_ModColumn;
      else
        dataModLogView.dml_ModColumnDesc = p_ModColumnDesc;
      dataModLogView.dml_BeforeValue = p_BeforeValue.ToString();
      dataModLogView.dml_AfterValue = p_AfterValue.ToString();
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      return await dataModLogView.InsertAsync();
    }

    public string LogInfoQuery(
      string p_ModColumn,
      string p_ModColumnDesc,
      double p_BeforeValue,
      double p_AfterValue)
    {
      this.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        this.dml_ModColumnDesc = p_ModColumn;
      else
        this.dml_ModColumnDesc = p_ModColumnDesc;
      this.dml_BeforeValue = p_BeforeValue.ToString();
      this.dml_AfterValue = p_AfterValue.ToString();
      return this.InsertQuery();
    }

    public async Task<bool> LogInfoAsync(
      UniOleDatabase p_db,
      string p_ModColumn,
      string p_ModColumnDesc,
      DateTime? p_BeforeValue,
      DateTime? p_AfterValue)
    {
      DataModLogView dataModLogView = this;
      dataModLogView.SetAdoDatabase(p_db);
      dataModLogView.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        dataModLogView.dml_ModColumnDesc = p_ModColumn;
      else
        dataModLogView.dml_ModColumnDesc = p_ModColumnDesc;
      dataModLogView.dml_BeforeValue = p_BeforeValue.GetDateToStrInNull();
      dataModLogView.dml_AfterValue = p_AfterValue.GetDateToStrInNull();
      if (dataModLogView.dml_ID == 0L)
      {
        if (!await dataModLogView.CreateCodeAsync(dataModLogView.OleDB))
          return false;
      }
      return await dataModLogView.InsertAsync();
    }

    public string LogInfoQuery(
      string p_ModColumn,
      string p_ModColumnDesc,
      DateTime? p_BeforeValue,
      DateTime? p_AfterValue)
    {
      this.dml_ModColumn = p_ModColumn;
      if (string.IsNullOrEmpty(p_ModColumnDesc))
        this.dml_ModColumnDesc = p_ModColumn;
      else
        this.dml_ModColumnDesc = p_ModColumnDesc;
      this.dml_BeforeValue = p_BeforeValue.GetDateToStrInNull();
      this.dml_AfterValue = p_AfterValue.GetDateToStrInNull();
      return this.InsertQuery();
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      return true;
    }

    public async Task<DataModLogView> SelectOneAsync(long p_dml_ID, long p_dml_SiteID = 0)
    {
      DataModLogView dataModLogView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "dml_ID",
          (object) p_dml_ID
        }
      };
      if (p_dml_SiteID > 0L)
        p_param.Add((object) "dml_SiteID", (object) p_dml_SiteID);
      return await dataModLogView.SelectOneTAsync<DataModLogView>((object) p_param);
    }

    public async Task<IList<DataModLogView>> SelectListAsync(object p_param)
    {
      DataModLogView dataModLogView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dataModLogView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dataModLogView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dataModLogView1.GetSelectQuery(p_param)))
        {
          dataModLogView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dataModLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<DataModLogView>) null;
        }
        IList<DataModLogView> lt_list = (IList<DataModLogView>) new List<DataModLogView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            DataModLogView dataModLogView2 = dataModLogView1.OleDB.Create<DataModLogView>();
            if (dataModLogView2.GetFieldValues(rs))
            {
              dataModLogView2.row_number = lt_list.Count + 1;
              lt_list.Add(dataModLogView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dataModLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "dml_ModColumn", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dml_ModColumnDesc", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(") ");
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
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "dml_SiteID") && Convert.ToInt64(hashtable[(object) "dml_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "dml_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code,emp_SiteID,emp_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_UNI_SITE AS (\nSELECT uis_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.UniSite, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "uis_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  dml_ID,dml_SiteID,dml_SysDate,dml_StoreCode,dml_EmpCode,dml_CodeInt,dml_CodeLong,dml_CodeStr,dml_ActionKind,dml_ActionType,dml_TableSeq,dml_ModColumn,dml_ModColumnDesc,dml_BeforeValue,dml_AfterValue,dml_DeviceKey,dml_DeviceName\n,emp_Name\n,si_StoreName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON dml_EmpCode=emp_Code AND dml_SiteID=emp_SiteID\nLEFT OUTER JOIN T_STORE ON dml_StoreCode=si_StoreCode AND dml_SiteID=si_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY dml_ID");
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
