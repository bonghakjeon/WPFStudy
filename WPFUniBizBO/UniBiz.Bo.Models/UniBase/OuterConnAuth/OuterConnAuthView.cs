// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.OuterConnAuthView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class OuterConnAuthView : TOuterConnAuth<OuterConnAuthView>
  {
    private bool _is_ver_checked_update;
    private string _si_StoreName;
    private string _inEmpName;
    private string _modEmpName;

    [JsonIgnore]
    public bool is_ver_checked_update
    {
      get => this._is_ver_checked_update;
      set
      {
        this._is_ver_checked_update = value;
        this.Changed(nameof (is_ver_checked_update));
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
      this.is_ver_checked_update = false;
      this.si_StoreName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new OuterConnAuthView();

    public override object Clone()
    {
      OuterConnAuthView outerConnAuthView = base.Clone() as OuterConnAuthView;
      outerConnAuthView.si_StoreName = this.si_StoreName;
      outerConnAuthView.inEmpName = this.inEmpName;
      outerConnAuthView.modEmpName = this.modEmpName;
      return (object) outerConnAuthView;
    }

    public void PutData(OuterConnAuthView pSource)
    {
      this.PutData((TOuterConnAuth) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.oca_SiteID == 0L)
      {
        this.message = "싸이트(oca_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.oca_ProgKind == 0)
      {
        this.message = "APP ID(oca_ProgKind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.oca_Status == 0)
      {
        this.message = "허용 상태(oca_Status)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.oca_DeviceKey))
        return EnumDataCheck.Success;
      this.message = "장치키(oca_DeviceKey)  " + EnumDataCheck.Empty.ToDescription();
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
      if (this.IsNew)
      {
        if (!p_app_employee.IsAdmin && !this.oca_IsStatusRequest)
        {
          this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (!p_app_employee.IsAdmin && !this.is_ver_checked_update)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(oca_ID), 0)+1 AS oca_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.oca_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.oca_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      OuterConnAuthView outerConnAuthView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(outerConnAuthView.CreateCodeQuery()))
        {
          outerConnAuthView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + outerConnAuthView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          outerConnAuthView.oca_ID = rs.GetFieldInt(0);
        return outerConnAuthView.oca_ID > 0;
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
          if (this.oca_SiteID == 0L)
            this.oca_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.oca_ID == 0 && !this.CreateCode(p_db))
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
      OuterConnAuthView outerConnAuthView = this;
      try
      {
        outerConnAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != outerConnAuthView.DataCheck(p_db))
            throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (outerConnAuthView.oca_SiteID == 0L)
            outerConnAuthView.oca_SiteID = p_app_employee.emp_SiteID;
          if (!outerConnAuthView.IsPermit(p_app_employee))
            throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (outerConnAuthView.oca_ID == 0)
        {
          if (!await outerConnAuthView.CreateCodeAsync(p_db))
            throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await outerConnAuthView.InsertAsync())
          throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 등록 오류");
        outerConnAuthView.db_status = 4;
        outerConnAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        outerConnAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        outerConnAuthView.message = ex.Message;
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
        if (this.oca_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 장치 코드(oca_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      OuterConnAuthView outerConnAuthView = this;
      try
      {
        outerConnAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != outerConnAuthView.DataCheck(p_db))
            throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!outerConnAuthView.IsPermit(p_app_employee))
          throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        if (outerConnAuthView.oca_ID == 0)
          throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 장치 코드(oca_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await outerConnAuthView.UpdateAsync())
          throw new UniServiceException(outerConnAuthView.message, outerConnAuthView.TableCode.ToDescription() + " 변경 오류");
        outerConnAuthView.db_status = 4;
        outerConnAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        outerConnAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        outerConnAuthView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<OuterConnAuthView> SelectOneAsync(int p_oca_ID, long p_oca_SiteID = 0)
    {
      OuterConnAuthView outerConnAuthView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "oca_ID",
          (object) p_oca_ID
        }
      };
      if (p_oca_SiteID > 0L)
        p_param.Add((object) "oca_SiteID", (object) p_oca_SiteID);
      return await outerConnAuthView.SelectOneTAsync<OuterConnAuthView>((object) p_param);
    }

    public async Task<IList<OuterConnAuthView>> SelectListAsync(object p_param)
    {
      OuterConnAuthView outerConnAuthView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(outerConnAuthView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, outerConnAuthView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(outerConnAuthView1.GetSelectQuery(p_param)))
        {
          outerConnAuthView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + outerConnAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<OuterConnAuthView>) null;
        }
        IList<OuterConnAuthView> lt_list = (IList<OuterConnAuthView>) new List<OuterConnAuthView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            OuterConnAuthView outerConnAuthView2 = outerConnAuthView1.OleDB.Create<OuterConnAuthView>();
            if (outerConnAuthView2.GetFieldValues(rs))
            {
              outerConnAuthView2.row_number = lt_list.Count + 1;
              lt_list.Add(outerConnAuthView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + outerConnAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "oca_DeviceName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_DeviceKey", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_RealIp4", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "oca_SiteID") && Convert.ToInt64(hashtable[(object) "oca_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "oca_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        if (p_param != null)
        {
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("oca_SiteID"))
              p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
              p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("oca_StoreCode"))
              p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
            dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
          }
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append(new StoreInfoView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  oca_ID,oca_SiteID,oca_ProgKind,oca_ProgVer,oca_StoreCode,oca_DeviceName,oca_DeviceKey,oca_DeviceIpInfo,oca_RealIp4,oca_Gateway,oca_DevicePort,oca_BaseUrl,oca_Count,oca_Status,oca_ExpireDate,oca_Memo,oca_OsType,oca_OsVersion,oca_AddProperty,oca_InDate,oca_InUser,oca_ModDate,oca_ModUser,si_StoreName,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n LEFT OUTER JOIN T_STORE ON oca_StoreCode=si_StoreCode AND oca_SiteID=si_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON oca_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON oca_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY oca_ID");
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
