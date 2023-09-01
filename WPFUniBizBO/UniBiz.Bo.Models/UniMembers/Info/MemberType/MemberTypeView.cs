// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberType.MemberTypeView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberType
{
  public class MemberTypeView : TMemberType<MemberTypeView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private IList<MemberTypeHistoryView> _Lt_History;

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

    [JsonPropertyName("lt_history")]
    public IList<MemberTypeHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<MemberTypeHistoryView>) new List<MemberTypeHistoryView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_History = (IList<MemberTypeHistoryView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberTypeView();

    public override object Clone()
    {
      MemberTypeView memberTypeView = base.Clone() as MemberTypeView;
      memberTypeView.inEmpName = this.inEmpName;
      memberTypeView.modEmpName = this.modEmpName;
      memberTypeView.Lt_History = this.Lt_History;
      return (object) memberTypeView;
    }

    public void PutData(MemberTypeView pSource)
    {
      this.PutData((TMemberType) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_History = (IList<MemberTypeHistoryView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (MemberTypeHistoryView pSource1 in (IEnumerable<MemberTypeHistoryView>) pSource.Lt_History)
      {
        MemberTypeHistoryView memberTypeHistoryView = new MemberTypeHistoryView();
        memberTypeHistoryView.PutData(pSource1);
        this.Lt_History.Add(memberTypeHistoryView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mt_SiteID == 0L)
      {
        this.message = "싸이트(mt_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.mt_TypeName))
        return EnumDataCheck.Success;
      this.message = "회원유형명(mt_TypeName)  " + EnumDataCheck.Empty.ToDescription();
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
      if (!p_app_employee.IsMemberTypeSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(mt_TypeCode), 0)+1 AS mt_TypeCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.mt_TypeCode = uniOleDbRecordset.GetFieldInt(0);
        return this.mt_TypeCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      MemberTypeView memberTypeView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(memberTypeView.CreateCodeQuery()))
        {
          memberTypeView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          memberTypeView.mt_TypeCode = rs.GetFieldInt(0);
        return memberTypeView.mt_TypeCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    protected bool InsertHistory(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_History.Count == 0)
        return true;
      throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 이력 등록 미 구현. 등록 실패.");
    }

    protected async Task<bool> InsertHistoryAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      MemberTypeView memberTypeView = this;
      try
      {
        if (memberTypeView.Lt_History.Count == 0)
          return true;
        foreach (MemberTypeHistoryView memberTypeHistoryView in (IEnumerable<MemberTypeHistoryView>) memberTypeView.Lt_History)
        {
          MemberTypeHistoryView history = memberTypeHistoryView;
          if (history.mth_StoreCode != 0)
          {
            if (history.IsNew || history.IsUpdate)
            {
              if (history.mth_TypeCode == 0)
                history.mth_TypeCode = memberTypeView.mt_TypeCode;
              if (history.mth_SiteID == 0L)
                history.mth_SiteID = memberTypeView.mt_SiteID;
              if (!await history.RegisterDataAsync(p_db, p_app_employee, (LogInSmallPack) null))
                throw new Exception(history.message);
            }
            history = (MemberTypeHistoryView) null;
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        memberTypeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberTypeView.message = ex.Message;
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
          if (this.mt_SiteID == 0L)
            this.mt_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.mt_TypeCode == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertHistory(p_db, p_app_employee))
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
      MemberTypeView memberTypeView = this;
      try
      {
        memberTypeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberTypeView.DataCheck(p_db))
            throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberTypeView.mt_SiteID == 0L)
            memberTypeView.mt_SiteID = p_app_employee.emp_SiteID;
          if (!memberTypeView.IsPermit(p_app_employee))
            throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (memberTypeView.mt_TypeCode == 0)
        {
          if (!await memberTypeView.CreateCodeAsync(p_db))
            throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await memberTypeView.InsertAsync())
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 등록 오류");
        if (!await memberTypeView.InsertHistoryAsync(p_db, p_app_employee))
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        memberTypeView.db_status = 4;
        memberTypeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberTypeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberTypeView.message = ex.Message;
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
        if (this.mt_TypeCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 회원유형코드(mt_TypeCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertHistory(p_db, p_app_employee))
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

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberTypeView memberTypeView = this;
      try
      {
        memberTypeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberTypeView.DataCheck(p_db))
            throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberTypeView.IsPermit(p_app_employee))
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (memberTypeView.mt_TypeCode == 0)
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 회원유형코드(mt_TypeCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await memberTypeView.UpdateAsync())
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 변경 오류");
        if (!await memberTypeView.InsertHistoryAsync(p_db, p_app_employee))
          throw new UniServiceException(memberTypeView.message, memberTypeView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        memberTypeView.db_status = 4;
        memberTypeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberTypeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberTypeView.message = ex.Message;
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

    public async Task<MemberTypeView> SelectOneAsync(int p_mt_TypeCode, long p_mt_SiteID = 0)
    {
      MemberTypeView memberTypeView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mt_TypeCode",
          (object) p_mt_TypeCode
        }
      };
      if (p_mt_SiteID > 0L)
        p_param.Add((object) "mt_SiteID", (object) p_mt_SiteID);
      return await memberTypeView.SelectOneTAsync<MemberTypeView>((object) p_param);
    }

    public MemberTypeView SelectOne(int p_mt_TypeCode, long p_mt_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mt_TypeCode",
          (object) p_mt_TypeCode
        }
      };
      if (p_mt_SiteID > 0L)
        p_param.Add((object) "mt_SiteID", (object) p_mt_SiteID);
      return this.SelectOneT<MemberTypeView>((object) p_param);
    }

    public async Task<IList<MemberTypeView>> SelectListAsync(object p_param)
    {
      MemberTypeView memberTypeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberTypeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberTypeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberTypeView1.GetSelectQuery(p_param)))
        {
          memberTypeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberTypeView>) null;
        }
        IList<MemberTypeView> lt_list = (IList<MemberTypeView>) new List<MemberTypeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberTypeView memberTypeView2 = memberTypeView1.OleDB.Create<MemberTypeView>();
            if (memberTypeView2.GetFieldValues(rs))
            {
              memberTypeView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberTypeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberTypeView> SelectEnumerableAsync(object p_param)
    {
      MemberTypeView memberTypeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberTypeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberTypeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberTypeView1.GetSelectQuery(p_param)))
        {
          memberTypeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberTypeView memberTypeView2 = memberTypeView1.OleDB.Create<MemberTypeView>();
            if (memberTypeView2.GetFieldValues(rs))
            {
              memberTypeView2.row_number = ++row_number;
              yield return memberTypeView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mt_TypeName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mt_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        int num = 0;
        string empty = string.Empty;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mt_SiteID") && Convert.ToInt64(hashtable[(object) "mt_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "mt_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn,mt_InDate,mt_InUser,mt_ModDate,mt_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mt_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mt_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num > 0)
          stringBuilder.Append("\nORDER BY mt_TypeCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mt_TypeCode");
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
