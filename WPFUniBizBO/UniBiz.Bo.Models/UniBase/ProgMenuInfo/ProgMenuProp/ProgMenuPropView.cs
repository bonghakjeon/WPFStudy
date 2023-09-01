// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp.ProgMenuPropView
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp
{
  public class ProgMenuPropView : TProgMenuProp<ProgMenuPropView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private int _pmpA_MenuGroupID;
    private int _pmpA_PropCode;
    private IList<ProgMenuPropView> _Lt_Detail;

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

    public int pmpA_MenuGroupID
    {
      get => this._pmpA_MenuGroupID;
      set
      {
        this._pmpA_MenuGroupID = value;
        this.Changed(nameof (pmpA_MenuGroupID));
      }
    }

    public int pmpA_PropCode
    {
      get => this._pmpA_PropCode;
      set
      {
        this._pmpA_PropCode = value;
        this.Changed(nameof (pmpA_PropCode));
      }
    }

    [JsonPropertyName("lt_Detail")]
    public IList<ProgMenuPropView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<ProgMenuPropView>) new List<ProgMenuPropView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmpA_MenuGroupID", new TTableColumn()
      {
        tc_orgin_name = "pmpA_MenuGroupID",
        tc_trans_name = "화면권한ID"
      });
      columnInfo.Add("pmpA_PropCode", new TTableColumn()
      {
        tc_orgin_name = "pmpA_PropCode",
        tc_trans_name = "팝업 코드"
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
      this.pmpA_MenuGroupID = 0;
      this.pmpA_PropCode = 0;
      this.Lt_Detail = (IList<ProgMenuPropView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProgMenuPropView();

    public override object Clone()
    {
      ProgMenuPropView progMenuPropView1 = base.Clone() as ProgMenuPropView;
      progMenuPropView1.inEmpName = this.inEmpName;
      progMenuPropView1.modEmpName = this.modEmpName;
      progMenuPropView1.pmpA_MenuGroupID = this.pmpA_MenuGroupID;
      progMenuPropView1.pmpA_PropCode = this.pmpA_PropCode;
      progMenuPropView1.Lt_Detail = (IList<ProgMenuPropView>) null;
      if (this.Lt_Detail.Count > 0)
      {
        foreach (ProgMenuPropView progMenuPropView2 in (IEnumerable<ProgMenuPropView>) this.Lt_Detail)
          progMenuPropView1.Lt_Detail.Add(progMenuPropView2);
      }
      return (object) progMenuPropView1;
    }

    public void PutData(ProgMenuPropView pSource)
    {
      this.PutData((TProgMenuProp) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.pmpA_MenuGroupID = pSource.pmpA_MenuGroupID;
      this.pmpA_PropCode = pSource.pmpA_PropCode;
      this.Lt_Detail = (IList<ProgMenuPropView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (ProgMenuPropView progMenuPropView in (IEnumerable<ProgMenuPropView>) pSource.Lt_Detail)
        this.Lt_Detail.Add(progMenuPropView);
    }

    public ProgMenuPropView Apply(ProgMenuPropView pOrigin)
    {
      this.PutData((TProgMenuProp) pOrigin);
      foreach (ProgMenuPropView progMenuPropView in (IEnumerable<ProgMenuPropView>) pOrigin.Lt_Detail)
        this.Lt_Detail.Add(progMenuPropView);
      return this;
    }

    public ProgMenuPropView Apply(ProgMenuPropLevel pOrigin)
    {
      foreach (ProgMenuPropView progMenuPropView in pOrigin.Items)
        this.Lt_Detail.Add(progMenuPropView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pmp_SiteID == 0L)
      {
        this.message = "싸이트(pmp_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToAppType(this.pmp_ProgKind) == EnumAppType.NONE)
      {
        this.message = "프로그램 종류(pmp_ProgKind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToTableType(this.pmp_TableID) == TableCodeType.Unknown)
      {
        this.message = "테이블 ID(pmp_TableID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuPropType(this.pmp_PropType) == EnumMenuPropType.None)
      {
        this.message = "타입(pmp_PropType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuPropDepth(this.pmp_PropDepth) == EnumMenuPropDepth.None)
      {
        this.message = "단계(pmp_PropDepth)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmp_SortNo == 0)
      {
        this.message = "순서(pmp_SortNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.pmp_PropName))
      {
        this.message = "팝업명(pmp_PropName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.pmp_ProgTitle))
        return EnumDataCheck.Success;
      this.message = "타이틀(pmp_ProgTitle)  " + EnumDataCheck.Empty.ToDescription();
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

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.pmp_PropCode, (object) this.pmp_SiteID));

    public override async Task<bool> InsertAsync()
    {
      ProgMenuPropView progMenuPropView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuPropView.\u003C\u003En__0() && progMenuPropView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) progMenuPropView.pmp_PropCode, (object) progMenuPropView.pmp_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.pmp_PropCode, (object) this.pmp_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      ProgMenuPropView progMenuPropView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuPropView.\u003C\u003En__1(p_old) && progMenuPropView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) progMenuPropView.pmp_PropCode, (object) progMenuPropView.pmp_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.pmp_PropCode, (object) this.pmp_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      ProgMenuPropView progMenuPropView = this;
      // ISSUE: reference to a compiler-generated method
      return await progMenuPropView.\u003C\u003En__2() && progMenuPropView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) progMenuPropView.pmp_PropCode, (object) progMenuPropView.pmp_SiteID));
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
          if (this.pmp_SiteID == 0L)
            this.pmp_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pmp_PropCode == 0 && !this.CreateCode(p_db))
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
      ProgMenuPropView progMenuPropView = this;
      try
      {
        progMenuPropView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != progMenuPropView.DataCheck(p_db))
            throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (progMenuPropView.pmp_SiteID == 0L)
            progMenuPropView.pmp_SiteID = p_app_employee.emp_SiteID;
          if (!progMenuPropView.IsPermit(p_app_employee))
            throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (progMenuPropView.pmp_PropCode == 0)
        {
          if (!await progMenuPropView.CreateCodeAsync(p_db))
            throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await progMenuPropView.InsertAsync())
          throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 등록 오류");
        progMenuPropView.db_status = 4;
        progMenuPropView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        progMenuPropView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        progMenuPropView.message = ex.Message;
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
        if (this.pmp_PropCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 팝업 코드(pmp_PropCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      ProgMenuPropView progMenuPropView = this;
      try
      {
        progMenuPropView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != progMenuPropView.DataCheck(p_db))
            throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!progMenuPropView.IsPermit(p_app_employee))
          throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 권한 검사 실패");
        if (progMenuPropView.pmp_PropCode == 0)
          throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 팝업 코드(pmp_PropCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await progMenuPropView.UpdateAsync())
          throw new UniServiceException(progMenuPropView.message, progMenuPropView.TableCode.ToDescription() + " 변경 오류");
        progMenuPropView.db_status = 4;
        progMenuPropView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        progMenuPropView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        progMenuPropView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.pmpA_MenuGroupID = p_rs.GetFieldInt("pmpA_MenuGroupID");
      this.pmpA_PropCode = p_rs.GetFieldInt("pmpA_PropCode");
      return true;
    }

    public async Task<ProgMenuPropView> SelectOneAsync(int p_pmp_PropCode, long p_pmp_SiteID = 0)
    {
      ProgMenuPropView progMenuPropView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmp_PropCode",
          (object) p_pmp_PropCode
        }
      };
      if (p_pmp_SiteID > 0L)
        p_param.Add((object) "pmp_SiteID", (object) p_pmp_SiteID);
      return await progMenuPropView.SelectOneTAsync<ProgMenuPropView>((object) p_param);
    }

    public async Task<IList<ProgMenuPropView>> SelectListAsync(object p_param)
    {
      ProgMenuPropView progMenuPropView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(progMenuPropView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, progMenuPropView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(progMenuPropView1.GetSelectQuery(p_param)))
        {
          progMenuPropView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuPropView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuPropView>) null;
        }
        IList<ProgMenuPropView> lt_list = (IList<ProgMenuPropView>) new List<ProgMenuPropView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuPropView progMenuPropView2 = progMenuPropView1.OleDB.Create<ProgMenuPropView>();
            if (progMenuPropView2.GetFieldValues(rs))
            {
              progMenuPropView2.row_number = lt_list.Count + 1;
              lt_list.Add(progMenuPropView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + progMenuPropView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pmp_PropName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgID", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "pmp_SiteID") && Convert.ToInt64(hashtable[(object) "pmp_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "pmp_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "pmpA_MenuGroupID") && Convert.ToInt32(hashtable[(object) "pmpA_MenuGroupID"].ToString()) > 0)
            num = Convert.ToInt32(hashtable[(object) "pmpA_MenuGroupID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        if (num > 0)
        {
          stringBuilder.Append(",T_PROG_MENU_AUTH AS ( SELECT pmpA_MenuGroupID,pmpA_PropCode " + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenuPropAuth, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "pmpA_MenuGroupID", (object) num) + ") ");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(" SELECT  pmp_PropCode,pmp_SiteID,pmp_ProgKind,pmp_SortNo,pmp_PropName,pmp_TableID,pmp_ProgID,pmp_ProgTitle,pmp_PropType,pmp_PropDepth,pmp_IconUrl,pmp_UseYn,pmp_InDate,pmp_InUser,pmp_ModDate,pmp_ModUser,inEmpName,modEmpName");
        if (num > 0)
          stringBuilder.Append(",pmpA_MenuGroupID,pmpA_PropCode ");
        else
          stringBuilder.Append(",0 AS pmpA_MenuGroupID, 1 AS pmpA_PropCode ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON pmp_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON pmp_ModUser=emp_CodeMod");
        if (num > 0)
          stringBuilder.Append(" LEFT OUTER JOIN T_PROG_MENU_AUTH ON pmp_PropCode=pmpA_PropCode");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (empty != null && empty.Length > 0)
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pmp_ProgKind,pmp_TableID,pmp_PropDepth,pmp_SortNo");
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
