// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth.ProgMenuPropAuthView
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
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth
{
  public class ProgMenuPropAuthView : TProgMenuPropAuth<ProgMenuPropAuthView>
  {
    private ProgMenuPropView _ProgMenuPropInfo;
    private IList<ProgMenuPropAuthView> _Lt_Detail;

    [JsonPropertyName("progMenuPropInfo")]
    public ProgMenuPropView ProgMenuPropInfo
    {
      get => this._ProgMenuPropInfo ?? (this._ProgMenuPropInfo = new ProgMenuPropView());
      set
      {
        this._ProgMenuPropInfo = value;
        this.Changed(nameof (ProgMenuPropInfo));
        this.Changed("pmp_SiteID");
        this.Changed("pmp_ProgKind");
        this.Changed("pmp_ProgKindDesc");
        this.Changed("pmp_SortNo");
        this.Changed("pmp_PropName");
        this.Changed("pmp_TableID");
        this.Changed("pmp_TableIDDesc");
        this.Changed("pmp_ProgID");
        this.Changed("pmp_ProgTitle");
        this.Changed("pmp_PropType");
        this.Changed("pmp_PropTypeDesc");
        this.Changed("pmp_PropDepth");
        this.Changed("pmp_PropDepthDesc");
        this.Changed("pmp_IconUrl");
      }
    }

    public long pmp_SiteID => this.ProgMenuPropInfo.pmp_SiteID;

    public int pmp_ProgKind => this.ProgMenuPropInfo.pmp_ProgKind;

    public string pmp_ProgKindDesc => this.ProgMenuPropInfo.pmp_ProgKindDesc;

    public int pmp_SortNo => this.ProgMenuPropInfo.pmp_SortNo;

    public string pmp_PropName => this.ProgMenuPropInfo.pmp_PropName;

    public int pmp_TableID => this.ProgMenuPropInfo.pmp_TableID;

    public string pmp_TableIDDesc => this.ProgMenuPropInfo.pmp_TableIDDesc;

    public string pmp_ProgID => this.ProgMenuPropInfo.pmp_ProgID;

    public string pmp_ProgTitle => this.ProgMenuPropInfo.pmp_ProgTitle;

    public int pmp_PropType => this.ProgMenuPropInfo.pmp_PropType;

    public string pmp_PropTypeDesc => this.ProgMenuPropInfo.pmp_PropTypeDesc;

    public int pmp_PropDepth => this.ProgMenuPropInfo.pmp_PropDepth;

    public string pmp_PropDepthDesc => this.ProgMenuPropInfo.pmp_PropDepthDesc;

    public string pmp_IconUrl => this.ProgMenuPropInfo.pmp_IconUrl;

    [JsonPropertyName("lt_Detail")]
    public IList<ProgMenuPropAuthView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<ProgMenuPropAuthView>) new List<ProgMenuPropAuthView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override void Clear()
    {
      base.Clear();
      this.ProgMenuPropInfo = (ProgMenuPropView) null;
      this.Lt_Detail = (IList<ProgMenuPropAuthView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProgMenuPropAuthView();

    public override object Clone()
    {
      ProgMenuPropAuthView menuPropAuthView = base.Clone() as ProgMenuPropAuthView;
      menuPropAuthView.ProgMenuPropInfo = (ProgMenuPropView) null;
      if (this.ProgMenuPropInfo.pmp_PropCode > 0)
        menuPropAuthView.ProgMenuPropInfo = this.ProgMenuPropInfo;
      return (object) menuPropAuthView;
    }

    public void PutData(ProgMenuPropAuthView pSource)
    {
      this.PutData((TProgMenuPropAuth) pSource);
      this.ProgMenuPropInfo = (ProgMenuPropView) null;
      if (pSource.ProgMenuPropInfo.pmp_PropCode > 0)
        this.ProgMenuPropInfo.PutData(pSource.ProgMenuPropInfo);
      this.Lt_Detail = (IList<ProgMenuPropAuthView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (ProgMenuPropAuthView pSource1 in (IEnumerable<ProgMenuPropAuthView>) pSource.Lt_Detail)
      {
        ProgMenuPropAuthView menuPropAuthView = new ProgMenuPropAuthView();
        menuPropAuthView.PutData(pSource1);
        this.Lt_Detail.Add(menuPropAuthView);
      }
    }

    public ProgMenuPropAuthView Apply(ProgMenuPropAuthView pOrigin)
    {
      this.PutData((TProgMenuPropAuth) pOrigin);
      foreach (ProgMenuPropAuthView menuPropAuthView in (IEnumerable<ProgMenuPropAuthView>) pOrigin.Lt_Detail)
        this.Lt_Detail.Add(menuPropAuthView);
      return this;
    }

    public ProgMenuPropAuthView Apply(ProgMenuPropAuthLevel pOrigin)
    {
      foreach (ProgMenuPropAuthView menuPropAuthView in pOrigin.Items)
        this.Lt_Detail.Add(menuPropAuthView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pmpA_MenuGroupID == 0)
      {
        this.message = "화면권한ID(pmpA_MenuGroupID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmpA_PropCode == 0)
      {
        this.message = "팝업 코드(pmpA_PropCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmpA_SiteID != 0L)
        return EnumDataCheck.Success;
      this.message = "싸이트(pmpA_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode, (object) this.pmpA_SiteID));

    public override async Task<bool> InsertAsync()
    {
      ProgMenuPropAuthView menuPropAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await menuPropAuthView.\u003C\u003En__0() && menuPropAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) menuPropAuthView.pmpA_MenuGroupID, (object) menuPropAuthView.pmpA_PropCode, (object) menuPropAuthView.pmpA_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode, (object) this.pmpA_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      ProgMenuPropAuthView menuPropAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await menuPropAuthView.\u003C\u003En__1(p_old) && menuPropAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) menuPropAuthView.pmpA_MenuGroupID, (object) menuPropAuthView.pmpA_PropCode, (object) menuPropAuthView.pmpA_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode, (object) this.pmpA_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      ProgMenuPropAuthView menuPropAuthView = this;
      // ISSUE: reference to a compiler-generated method
      return await menuPropAuthView.\u003C\u003En__2() && menuPropAuthView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) menuPropAuthView.pmpA_MenuGroupID, (object) menuPropAuthView.pmpA_PropCode, (object) menuPropAuthView.pmpA_SiteID));
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
          if (this.pmpA_SiteID == 0L)
            this.pmpA_SiteID = p_app_employee.emp_SiteID;
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
      ProgMenuPropAuthView menuPropAuthView = this;
      try
      {
        menuPropAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != menuPropAuthView.DataCheck(p_db))
            throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (menuPropAuthView.pmpA_SiteID == 0L)
            menuPropAuthView.pmpA_SiteID = p_app_employee.emp_SiteID;
          if (!menuPropAuthView.IsPermit(p_app_employee))
            throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await menuPropAuthView.InsertAsync())
          throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 등록 오류");
        menuPropAuthView.db_status = 4;
        menuPropAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        menuPropAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        menuPropAuthView.message = ex.Message;
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
      ProgMenuPropAuthView menuPropAuthView = this;
      try
      {
        menuPropAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != menuPropAuthView.DataCheck(p_db))
            throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!menuPropAuthView.IsPermit(p_app_employee))
          throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await menuPropAuthView.DeleteAsync())
          throw new UniServiceException(menuPropAuthView.message, menuPropAuthView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        menuPropAuthView.db_status = 4;
        menuPropAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuPropAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuPropAuthView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.ProgMenuPropInfo.pmp_PropCode = p_rs.GetFieldInt("pmp_PropCode");
      this.ProgMenuPropInfo.pmp_SiteID = p_rs.GetFieldLong("pmp_SiteID");
      this.ProgMenuPropInfo.pmp_ProgKind = p_rs.GetFieldInt("pmp_ProgKind");
      this.ProgMenuPropInfo.pmp_SortNo = p_rs.GetFieldInt("pmp_SortNo");
      this.ProgMenuPropInfo.pmp_PropName = p_rs.GetFieldString("pmp_PropName");
      this.ProgMenuPropInfo.pmp_TableID = p_rs.GetFieldInt("pmp_TableID");
      this.ProgMenuPropInfo.pmp_ProgID = p_rs.GetFieldString("pmp_ProgID");
      this.ProgMenuPropInfo.pmp_ProgTitle = p_rs.GetFieldString("pmp_ProgTitle");
      this.ProgMenuPropInfo.pmp_PropType = p_rs.GetFieldInt("pmp_PropType");
      this.ProgMenuPropInfo.pmp_PropDepth = p_rs.GetFieldInt("pmp_PropDepth");
      this.ProgMenuPropInfo.pmp_IconUrl = p_rs.GetFieldString("pmp_IconUrl");
      this.ProgMenuPropInfo.pmp_UseYn = p_rs.GetFieldString("pmp_UseYn");
      this.ProgMenuPropInfo.pmp_InDate = p_rs.GetFieldDateTime("pmp_InDate");
      this.ProgMenuPropInfo.pmp_InUser = p_rs.GetFieldInt("pmp_InUser");
      this.ProgMenuPropInfo.pmp_ModDate = p_rs.GetFieldDateTime("pmp_ModDate");
      this.ProgMenuPropInfo.pmp_ModUser = p_rs.GetFieldInt("pmp_ModUser");
      return true;
    }

    public async Task<ProgMenuPropAuthView> SelectOneAsync(
      int p_pmpA_MenuGroupID,
      int p_pmpA_PropCode,
      long p_pmpA_SiteID = 0)
    {
      ProgMenuPropAuthView menuPropAuthView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmpA_MenuGroupID",
          (object) p_pmpA_MenuGroupID
        },
        {
          (object) "pmpA_PropCode",
          (object) p_pmpA_PropCode
        }
      };
      if (p_pmpA_SiteID > 0L)
        p_param.Add((object) "pmpA_SiteID", (object) p_pmpA_SiteID);
      return await menuPropAuthView.SelectOneTAsync<ProgMenuPropAuthView>((object) p_param);
    }

    public async Task<IList<ProgMenuPropAuthView>> SelectListAsync(object p_param)
    {
      ProgMenuPropAuthView menuPropAuthView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(menuPropAuthView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, menuPropAuthView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(menuPropAuthView1.GetSelectQuery(p_param)))
        {
          menuPropAuthView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuPropAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuPropAuthView>) null;
        }
        IList<ProgMenuPropAuthView> lt_list = (IList<ProgMenuPropAuthView>) new List<ProgMenuPropAuthView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuPropAuthView menuPropAuthView2 = menuPropAuthView1.OleDB.Create<ProgMenuPropAuthView>();
            if (menuPropAuthView2.GetFieldValues(rs))
            {
              menuPropAuthView2.row_number = lt_list.Count + 1;
              lt_list.Add(menuPropAuthView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuPropAuthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "pmp_PropCode") && Convert.ToInt32(hashtable[(object) "pmp_PropCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_PropCode", hashtable[(object) "pmp_PropCode"]));
        if (hashtable.ContainsKey((object) "pmp_PropCodeIn") && hashtable[(object) "pmp_PropCodeIn"].ToString().Trim().Length > 0)
          stringBuilder.Append(" AND pmp_PropCode IN (" + hashtable[(object) "pmp_PropCodeIn"].ToString() + ")");
        if (hashtable.ContainsKey((object) "pmp_ProgKind") && Convert.ToInt32(hashtable[(object) "pmp_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_ProgKind", hashtable[(object) "pmp_ProgKind"]));
        if (hashtable.ContainsKey((object) "pmp_UseYn") && hashtable[(object) "pmp_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pmp_UseYn", hashtable[(object) "pmp_UseYn"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pmp_PropName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgID", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable1.ContainsKey((object) "pmpA_SiteID") && Convert.ToInt64(hashtable1[(object) "pmpA_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable1[(object) "pmpA_SiteID"].ToString());
          if (hashtable1.ContainsKey((object) "pmpA_PropCode") && Convert.ToInt32(hashtable1[(object) "pmpA_PropCode"].ToString()) > 0)
            Convert.ToInt32(hashtable1[(object) "pmpA_PropCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PROG_MENU_PROP AS ( SELECT  pmp_PropCode,pmp_SiteID,pmp_ProgKind,pmp_SortNo,pmp_PropName,pmp_TableID,pmp_ProgID,pmp_ProgTitle,pmp_PropType,pmp_PropDepth,pmp_IconUrl,pmp_UseYn,pmp_InDate,pmp_InUser,pmp_ModDate,pmp_ModUser,inEmpName,modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenuProp, (object) DbQueryHelper.ToWithNolock()) + " LEFT OUTER JOIN T_EMPLOYEE_IN ON pmp_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON pmp_ModUser=emp_CodeMod");
        if (p_param is Hashtable hashtable2)
        {
          Hashtable p_param1 = new Hashtable();
          foreach (DictionaryEntry dictionaryEntry in hashtable2)
          {
            if (dictionaryEntry.Key.ToString().Equals("pmpA_SiteID"))
              p_param1.Add((object) "pmp_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("pmpA_PropCode"))
              p_param1.Add((object) "pmp_PropCode", dictionaryEntry.Value);
            if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          }
          if (p_param1.Count > 0)
            stringBuilder.Append(new ProgMenuView().GetSelectWhereAnd((object) p_param1));
        }
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  pmpA_MenuGroupID,pmpA_PropCode,pmpA_SiteID,pmp_PropCode,pmp_SiteID,pmp_ProgKind,pmp_SortNo,pmp_PropName,pmp_TableID,pmp_ProgID,pmp_ProgTitle,pmp_PropType,pmp_PropDepth,pmp_IconUrl,pmp_UseYn,pmp_InDate,pmp_InUser,pmp_ModDate,pmp_ModUser,inEmpName,modEmpName");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_PROG_MENU_PROP ON pmpA_PropCode=pmp_PropCode AND pmpA_SiteID=pmp_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        stringBuilder.Append("\n");
        if (empty != null && empty.Length > 0)
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pmpA_MenuGroupID,pmp_ProgKind,pmp_TableID,pmp_SortNo");
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
