// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu.ProgMenuView
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu
{
  public class ProgMenuView : TProgMenu<ProgMenuView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private int _pmA_MenuGroupID;
    private int _pmA_MenuCode;
    private IList<ProgMenuView> _Lt_Detail;

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

    public int pmA_MenuGroupID
    {
      get => this._pmA_MenuGroupID;
      set
      {
        this._pmA_MenuGroupID = value;
        this.Changed(nameof (pmA_MenuGroupID));
      }
    }

    public int pmA_MenuCode
    {
      get => this._pmA_MenuCode;
      set
      {
        this._pmA_MenuCode = value;
        this.Changed(nameof (pmA_MenuCode));
      }
    }

    [JsonPropertyName("lt_Detail")]
    public IList<ProgMenuView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<ProgMenuView>) new List<ProgMenuView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmA_MenuGroupID", new TTableColumn()
      {
        tc_orgin_name = "pmA_MenuGroupID",
        tc_trans_name = "화면권한ID"
      });
      columnInfo.Add("pmA_MenuCode", new TTableColumn()
      {
        tc_orgin_name = "pmA_MenuCode",
        tc_trans_name = "메뉴코드"
      });
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
      this.pmA_MenuGroupID = 0;
      this.pmA_MenuCode = 0;
      this.Lt_Detail = (IList<ProgMenuView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProgMenuView();

    public override object Clone()
    {
      ProgMenuView progMenuView1 = base.Clone() as ProgMenuView;
      progMenuView1.inEmpName = this.inEmpName;
      progMenuView1.modEmpName = this.modEmpName;
      progMenuView1.pmA_MenuGroupID = this.pmA_MenuGroupID;
      progMenuView1.pmA_MenuCode = this.pmA_MenuCode;
      progMenuView1.Lt_Detail = (IList<ProgMenuView>) null;
      if (this.Lt_Detail.Count > 0)
      {
        foreach (ProgMenuView progMenuView2 in (IEnumerable<ProgMenuView>) this.Lt_Detail)
          progMenuView1.Lt_Detail.Add(progMenuView2);
      }
      return (object) progMenuView1;
    }

    public void PutData(ProgMenuView pSource)
    {
      this.PutData((TProgMenu) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.pmA_MenuGroupID = pSource.pmA_MenuGroupID;
      this.pmA_MenuCode = pSource.pmA_MenuCode;
      this.Lt_Detail = (IList<ProgMenuView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (ProgMenuView progMenuView in (IEnumerable<ProgMenuView>) pSource.Lt_Detail)
        this.Lt_Detail.Add(progMenuView);
    }

    public ProgMenuView Apply(ProgMenuView pOrigin)
    {
      this.PutData((TProgMenu) pOrigin);
      foreach (ProgMenuView progMenuView in (IEnumerable<ProgMenuView>) pOrigin.Lt_Detail)
        this.Lt_Detail.Add(progMenuView);
      return this;
    }

    public ProgMenuView Apply(ProgMenuLevel pOrigin)
    {
      foreach (ProgMenuView progMenuView in pOrigin.Items)
        this.Lt_Detail.Add(progMenuView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pm_SiteID == 0L)
      {
        this.message = "싸이트(pm_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToAppType(this.pm_ProgKind) == EnumAppType.NONE)
      {
        this.message = "프로그램 종류(pm_ProgKind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuType(this.pm_ViewType) == EnumMenuType.None)
      {
        this.message = "뷰타입(pm_ViewType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuDepth(this.pm_MenuDepth) == EnumMenuDepth.None)
      {
        this.message = "단계(pm_MenuDepth)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.pm_MenuSortNo))
      {
        this.message = "프로그램 순위(pm_MenuSortNo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (string.IsNullOrEmpty(this.pm_MenuName))
      {
        this.message = "메뉴명(pm_MenuName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.pm_ProgTitle))
        return EnumDataCheck.Success;
      this.message = "타이틀(pm_ProgTitle)  " + EnumDataCheck.Empty.ToDescription();
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

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.pm_MenuCode, (object) this.pm_SiteID));

    public override async Task<bool> InsertAsync()
    {
      ProgMenuView progMenuView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuView.\u003C\u003En__0() && progMenuView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) progMenuView.pm_MenuCode, (object) progMenuView.pm_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.pm_MenuCode, (object) this.pm_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      ProgMenuView progMenuView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuView.\u003C\u003En__1(p_old) && progMenuView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) progMenuView.pm_MenuCode, (object) progMenuView.pm_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.pm_MenuCode, (object) this.pm_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      ProgMenuView progMenuView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuView.\u003C\u003En__2() && progMenuView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) progMenuView.pm_MenuCode, (object) progMenuView.pm_SiteID));
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
          if (this.pm_SiteID == 0L)
            this.pm_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pm_MenuCode == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
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
      ProgMenuView progMenuView = this;
      try
      {
        progMenuView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != progMenuView.DataCheck(p_db))
            throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (progMenuView.pm_SiteID == 0L)
            progMenuView.pm_SiteID = p_app_employee.emp_SiteID;
          if (!progMenuView.IsPermit(p_app_employee))
            throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (progMenuView.pm_MenuCode == 0)
        {
          if (!await progMenuView.CreateCodeAsync(p_db))
            throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await progMenuView.InsertAsync())
          throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 등록 오류");
        progMenuView.db_status = 4;
        progMenuView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        progMenuView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        progMenuView.message = ex.Message;
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
        if (this.pm_MenuCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 메뉴코드(pm_MenuCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      ProgMenuView progMenuView = this;
      try
      {
        progMenuView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != progMenuView.DataCheck(p_db))
            throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!progMenuView.IsPermit(p_app_employee))
          throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 권한 검사 실패");
        if (progMenuView.pm_MenuCode == 0)
          throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 메뉴코드(pm_MenuCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await progMenuView.UpdateAsync())
          throw new UniServiceException(progMenuView.message, progMenuView.TableCode.ToDescription() + " 변경 오류");
        progMenuView.db_status = 4;
        progMenuView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        progMenuView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        progMenuView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.pmA_MenuGroupID = p_rs.GetFieldInt("pmA_MenuGroupID");
      this.pmA_MenuCode = p_rs.GetFieldInt("pmA_MenuCode");
      return true;
    }

    public async Task<ProgMenuView> SelectOneAsync(int p_pm_MenuCode, long p_pm_SiteID = 0)
    {
      ProgMenuView progMenuView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pm_MenuCode",
          (object) p_pm_MenuCode
        }
      };
      if (p_pm_SiteID > 0L)
        p_param.Add((object) "pm_SiteID", (object) p_pm_SiteID);
      return await progMenuView.SelectOneTAsync<ProgMenuView>((object) p_param);
    }

    public async Task<IList<ProgMenuView>> SelectListAsync(object p_param)
    {
      ProgMenuView progMenuView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(progMenuView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, progMenuView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(progMenuView1.GetSelectQuery(p_param)))
        {
          progMenuView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuView>) null;
        }
        IList<ProgMenuView> lt_list = (IList<ProgMenuView>) new List<ProgMenuView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuView progMenuView2 = progMenuView1.OleDB.Create<ProgMenuView>();
            if (progMenuView2.GetFieldValues(rs))
            {
              progMenuView2.row_number = lt_list.Count + 1;
              lt_list.Add(progMenuView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pm_MenuName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgID", hashtable[(object) "_KEY_WORD_"]));
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
        int num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "pm_SiteID") && Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "pmA_MenuGroupID") && Convert.ToInt32(hashtable[(object) "pmA_MenuGroupID"].ToString()) > 0)
            num = Convert.ToInt32(hashtable[(object) "pmA_MenuGroupID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        if (num > 0)
        {
          stringBuilder.Append(",T_PROG_MENU_AUTH AS ( SELECT pmA_MenuGroupID,pmA_MenuCode " + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenuAuth, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "pmA_MenuGroupID", (object) num) + ") ");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(" SELECT  pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuSortNo,pm_MenuName,pm_GroupID,pm_ProgID,pm_ProgTitle,pm_ViewType,pm_MenuDepth,pm_IconUrl,pm_UseYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser,inEmpName,modEmpName");
        if (num > 0)
          stringBuilder.Append(",pmA_MenuGroupID,pmA_MenuCode ");
        else
          stringBuilder.Append(",0 AS pmA_MenuGroupID, 1 AS pmA_MenuCode ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON pm_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON pm_ModUser=emp_CodeMod");
        if (num > 0)
          stringBuilder.Append(" LEFT OUTER JOIN T_PROG_MENU_AUTH ON pm_MenuCode=pmA_MenuCode");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (empty != null && empty.Length > 0)
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pm_ProgKind,pm_MenuSortNo");
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
