// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth.ProgMenuAuthView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth
{
  public class ProgMenuAuthView : TProgMenuAuth<ProgMenuAuthView>
  {
    private ProgMenuView _ProgMenuInfo;
    private IList<ProgMenuAuthView> _Lt_Detail;

    [JsonPropertyName("progMenuInfo")]
    public ProgMenuView ProgMenuInfo
    {
      get => this._ProgMenuInfo ?? (this._ProgMenuInfo = new ProgMenuView());
      set
      {
        this._ProgMenuInfo = value;
        this.Changed(nameof (ProgMenuInfo));
        this.Changed("pm_SiteID");
        this.Changed("pm_ProgKind");
        this.Changed("pm_MenuSortNo");
        this.Changed("pm_MenuName");
        this.Changed("pm_GroupID");
        this.Changed("pm_ProgID");
        this.Changed("pm_ProgTitle");
        this.Changed("pm_ViewType");
        this.Changed("pm_ViewTypeDesc");
        this.Changed("pm_MenuDepth");
        this.Changed("pm_MenuDepthDesc");
        this.Changed("pm_IconUrl");
      }
    }

    public long pm_SiteID => this.ProgMenuInfo.pm_SiteID;

    public int pm_ProgKind => this.ProgMenuInfo.pm_ProgKind;

    public string pm_MenuSortNo => this.ProgMenuInfo.pm_MenuSortNo;

    public string pm_MenuName => this.ProgMenuInfo.pm_MenuName;

    public int pm_GroupID => this.ProgMenuInfo.pm_GroupID;

    public string pm_ProgID => this.ProgMenuInfo.pm_ProgID;

    public string pm_ProgTitle => this.ProgMenuInfo.pm_ProgTitle;

    public int pm_ViewType => this.ProgMenuInfo.pm_ViewType;

    public string pm_ViewTypeDesc => this.ProgMenuInfo.pm_ViewTypeDesc;

    public int pm_MenuDepth => this.ProgMenuInfo.pm_MenuDepth;

    public string pm_MenuDepthDesc => this.ProgMenuInfo.pm_MenuDepthDesc;

    public string pm_IconUrl => this.ProgMenuInfo.pm_IconUrl;

    [JsonPropertyName("lt_Detail")]
    public IList<ProgMenuAuthView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<ProgMenuAuthView>) new List<ProgMenuAuthView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public int pm_MenuCode => this.ProgMenuInfo.pm_MenuCode;

    public override void Clear()
    {
      base.Clear();
      this.ProgMenuInfo = (ProgMenuView) null;
      this.Lt_Detail = (IList<ProgMenuAuthView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProgMenuAuthView();

    public override object Clone()
    {
      ProgMenuAuthView progMenuAuthView = base.Clone() as ProgMenuAuthView;
      progMenuAuthView.ProgMenuInfo = (ProgMenuView) null;
      if (this.ProgMenuInfo.pm_MenuCode > 0)
        progMenuAuthView.ProgMenuInfo = this.ProgMenuInfo;
      return (object) progMenuAuthView;
    }

    public void PutData(ProgMenuAuthView pSource)
    {
      this.PutData((TProgMenuAuth) pSource);
      this.ProgMenuInfo = (ProgMenuView) null;
      if (pSource.ProgMenuInfo.pm_MenuCode > 0)
        this.ProgMenuInfo.PutData(pSource.ProgMenuInfo);
      this.Lt_Detail = (IList<ProgMenuAuthView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (ProgMenuAuthView pSource1 in (IEnumerable<ProgMenuAuthView>) pSource.Lt_Detail)
      {
        ProgMenuAuthView progMenuAuthView = new ProgMenuAuthView();
        progMenuAuthView.PutData(pSource1);
        this.Lt_Detail.Add(progMenuAuthView);
      }
    }

    public ProgMenuAuthView Apply(ProgMenuAuthView pOrigin)
    {
      this.PutData((TProgMenuAuth) pOrigin);
      foreach (ProgMenuAuthView progMenuAuthView in (IEnumerable<ProgMenuAuthView>) pOrigin.Lt_Detail)
        this.Lt_Detail.Add(progMenuAuthView);
      return this;
    }

    public ProgMenuAuthView Apply(ProgMenuAuthLevel pOrigin)
    {
      foreach (ProgMenuAuthView progMenuAuthView in pOrigin.Items)
        this.Lt_Detail.Add(progMenuAuthView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pmA_MenuGroupID == 0)
      {
        this.message = "화면권한ID(pmA_MenuGroupID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmA_MenuCode == 0)
      {
        this.message = "메뉴코드(pmA_MenuCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmA_SiteID != 0L)
        return EnumDataCheck.Success;
      this.message = "싸이트(pmA_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsAdmin)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode, (object) this.pmA_SiteID));

    public override async Task<bool> InsertAsync()
    {
      ProgMenuAuthView progMenuAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuAuthView.\u003C\u003En__0() && progMenuAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) progMenuAuthView.pmA_MenuGroupID, (object) progMenuAuthView.pmA_MenuCode, (object) progMenuAuthView.pmA_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode, (object) this.pmA_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      ProgMenuAuthView progMenuAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuAuthView.\u003C\u003En__1(p_old) && progMenuAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) progMenuAuthView.pmA_MenuGroupID, (object) progMenuAuthView.pmA_MenuCode, (object) progMenuAuthView.pmA_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode, (object) this.pmA_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      ProgMenuAuthView progMenuAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuAuthView.\u003C\u003En__2() && progMenuAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) progMenuAuthView.pmA_MenuGroupID, (object) progMenuAuthView.pmA_MenuCode, (object) progMenuAuthView.pmA_SiteID));
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
          if (this.pmA_SiteID == 0L)
            this.pmA_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, TableCodeType.CommonCode.ToDescription() + " 등록 오류");
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
      ProgMenuAuthView progMenuAuthView = this;
      try
      {
        progMenuAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != progMenuAuthView.DataCheck(p_db))
            throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (progMenuAuthView.pmA_SiteID == 0L)
            progMenuAuthView.pmA_SiteID = p_app_employee.emp_SiteID;
          if (!progMenuAuthView.IsPermit(p_app_employee))
            throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await progMenuAuthView.InsertAsync())
          throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 등록 오류");
        progMenuAuthView.db_status = 4;
        progMenuAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        progMenuAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        progMenuAuthView.message = ex.Message;
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
      ProgMenuAuthView progMenuAuthView = this;
      try
      {
        progMenuAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != progMenuAuthView.DataCheck(p_db))
            throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!progMenuAuthView.IsPermit(p_app_employee))
          throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await progMenuAuthView.DeleteAsync())
          throw new UniServiceException(progMenuAuthView.message, progMenuAuthView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        progMenuAuthView.db_status = 4;
        progMenuAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        progMenuAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        progMenuAuthView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.ProgMenuInfo.pm_MenuCode = p_rs.GetFieldInt("pm_MenuCode");
      this.ProgMenuInfo.pm_SiteID = p_rs.GetFieldLong("pm_SiteID");
      this.ProgMenuInfo.pm_ProgKind = p_rs.GetFieldInt("pm_ProgKind");
      this.ProgMenuInfo.pm_MenuSortNo = p_rs.GetFieldString("pm_MenuSortNo");
      this.ProgMenuInfo.pm_MenuName = p_rs.GetFieldString("pm_MenuName");
      this.ProgMenuInfo.pm_GroupID = p_rs.GetFieldInt("pm_GroupID");
      this.ProgMenuInfo.pm_ProgID = p_rs.GetFieldString("pm_ProgID");
      this.ProgMenuInfo.pm_ProgTitle = p_rs.GetFieldString("pm_ProgTitle");
      this.ProgMenuInfo.pm_ViewType = p_rs.GetFieldInt("pm_ViewType");
      this.ProgMenuInfo.pm_MenuDepth = p_rs.GetFieldInt("pm_MenuDepth");
      this.ProgMenuInfo.pm_IconUrl = p_rs.GetFieldString("pm_IconUrl");
      this.ProgMenuInfo.pm_UseYn = p_rs.GetFieldString("pm_UseYn");
      this.ProgMenuInfo.pm_InDate = p_rs.GetFieldDateTime("pm_InDate");
      this.ProgMenuInfo.pm_InUser = p_rs.GetFieldInt("pm_InUser");
      this.ProgMenuInfo.pm_ModDate = p_rs.GetFieldDateTime("pm_ModDate");
      this.ProgMenuInfo.pm_ModUser = p_rs.GetFieldInt("pm_ModUser");
      return true;
    }

    public async Task<ProgMenuAuthView> SelectOneAsync(
      int p_pmA_MenuGroupID,
      int p_pmA_MenuCode,
      long p_pmA_SiteID = 0)
    {
      ProgMenuAuthView progMenuAuthView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmA_MenuGroupID",
          (object) p_pmA_MenuGroupID
        },
        {
          (object) "pmA_MenuCode",
          (object) p_pmA_MenuCode
        }
      };
      if (p_pmA_SiteID > 0L)
        p_param.Add((object) "pmA_SiteID", (object) p_pmA_SiteID);
      return await progMenuAuthView.SelectOneTAsync<ProgMenuAuthView>((object) p_param);
    }

    public async Task<IList<ProgMenuAuthView>> SelectListAsync(object p_param)
    {
      ProgMenuAuthView progMenuAuthView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(progMenuAuthView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, progMenuAuthView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(progMenuAuthView1.GetSelectQuery(p_param)))
        {
          progMenuAuthView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuAuthView>) null;
        }
        IList<ProgMenuAuthView> lt_list = (IList<ProgMenuAuthView>) new List<ProgMenuAuthView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuAuthView progMenuAuthView2 = progMenuAuthView1.OleDB.Create<ProgMenuAuthView>();
            if (progMenuAuthView2.GetFieldValues(rs))
            {
              progMenuAuthView2.row_number = lt_list.Count + 1;
              lt_list.Add(progMenuAuthView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "pm_MenuCode") && Convert.ToInt32(hashtable[(object) "pm_MenuCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MenuCode", hashtable[(object) "pm_MenuCode"]));
        if (hashtable.ContainsKey((object) "pm_MenuCodeIn") && hashtable[(object) "pm_MenuCodeIn"].ToString().Trim().Length > 0)
          stringBuilder.Append(" AND pm_MenuCode IN (" + hashtable[(object) "pm_MenuCodeIn"].ToString() + ")");
        if (hashtable.ContainsKey((object) "pm_ProgKind") && Convert.ToInt32(hashtable[(object) "pm_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_ProgKind", hashtable[(object) "pm_ProgKind"]));
        if (hashtable.ContainsKey((object) "pm_GroupID") && Convert.ToInt32(hashtable[(object) "pm_GroupID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_GroupID", hashtable[(object) "pm_GroupID"]));
        if (hashtable.ContainsKey((object) "pm_UseYn") && hashtable[(object) "pm_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_UseYn", hashtable[(object) "pm_UseYn"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pm_MenuName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgID", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(") ");
        }
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
        if (p_param is Hashtable hashtable1)
        {
          if (hashtable1.ContainsKey((object) "DBMS") && hashtable1[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable1[(object) "DBMS"].ToString();
          if (hashtable1.ContainsKey((object) "table") && hashtable1[(object) "table"].ToString().Length > 0)
            str = hashtable1[(object) "table"].ToString();
          if (hashtable1.ContainsKey((object) "_ORDER_BY_COL_") && hashtable1[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable1[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable1.ContainsKey((object) "pmA_SiteID") && Convert.ToInt64(hashtable1[(object) "pmA_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable1[(object) "pmA_SiteID"].ToString());
          if (hashtable1.ContainsKey((object) "pmA_MenuCode") && Convert.ToInt32(hashtable1[(object) "pmA_MenuCode"].ToString()) > 0)
            Convert.ToInt32(hashtable1[(object) "pmA_MenuCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PROG_MENU AS ( SELECT  pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuSortNo,pm_MenuName,pm_GroupID,pm_ProgID,pm_ProgTitle,pm_ViewType,pm_MenuDepth,pm_IconUrl,pm_UseYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser,inEmpName,modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenu, (object) DbQueryHelper.ToWithNolock()) + " LEFT OUTER JOIN T_EMPLOYEE_IN ON pm_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON pm_ModUser=emp_CodeMod");
        if (p_param is Hashtable hashtable2)
        {
          Hashtable p_param1 = new Hashtable();
          foreach (DictionaryEntry dictionaryEntry in hashtable2)
          {
            if (dictionaryEntry.Key.ToString().Equals("pmA_SiteID"))
              p_param1.Add((object) "pm_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("pmA_MenuCode"))
              p_param1.Add((object) "pm_MenuCode", dictionaryEntry.Value);
            if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          }
          if (p_param1.Count > 0)
            stringBuilder.Append(new ProgMenuView().GetSelectWhereAnd((object) p_param1));
        }
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  pmA_MenuGroupID,pmA_MenuCode,pmA_SiteID,pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuSortNo,pm_MenuName,pm_GroupID,pm_ProgID,pm_ProgTitle,pm_ViewType,pm_MenuDepth,pm_IconUrl,pm_UseYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser,inEmpName,modEmpName");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_PROG_MENU ON pmA_MenuCode=pm_MenuCode AND pmA_SiteID=pm_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (empty != null && empty.Length > 0)
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pmA_MenuGroupID,pm_ProgKind,pm_MenuSortNo");
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
