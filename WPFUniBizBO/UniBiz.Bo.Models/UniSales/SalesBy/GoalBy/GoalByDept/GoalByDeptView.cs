// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept.GoalByDeptView
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept
{
  public class GoalByDeptView : TGoalByDept<GoalByDeptView>
  {
    private EnumRowType _rowDataType;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;
    private string _dpt_lv3_ViewCode;
    private string _dpt_lv3_Name;
    private string _inEmpName;
    private string _modEmpName;

    public EnumRowType rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == EnumRowType.TotalSum;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public int dpt_lv1_ID
    {
      get => this._dpt_lv1_ID;
      set
      {
        this._dpt_lv1_ID = value;
        this.Changed(nameof (dpt_lv1_ID));
      }
    }

    public string dpt_lv1_ViewCode
    {
      get => this._dpt_lv1_ViewCode;
      set
      {
        this._dpt_lv1_ViewCode = value;
        this.Changed(nameof (dpt_lv1_ViewCode));
      }
    }

    public string dpt_lv1_Name
    {
      get => this._dpt_lv1_Name;
      set
      {
        this._dpt_lv1_Name = value;
        this.Changed(nameof (dpt_lv1_Name));
      }
    }

    public int dpt_lv2_ID
    {
      get => this._dpt_lv2_ID;
      set
      {
        this._dpt_lv2_ID = value;
        this.Changed(nameof (dpt_lv2_ID));
      }
    }

    public string dpt_lv2_ViewCode
    {
      get => this._dpt_lv2_ViewCode;
      set
      {
        this._dpt_lv2_ViewCode = value;
        this.Changed(nameof (dpt_lv2_ViewCode));
      }
    }

    public string dpt_lv2_Name
    {
      get => this._dpt_lv2_Name;
      set
      {
        this._dpt_lv2_Name = value;
        this.Changed(nameof (dpt_lv2_Name));
      }
    }

    public string dpt_lv3_ViewCode
    {
      get => this._dpt_lv3_ViewCode;
      set
      {
        this._dpt_lv3_ViewCode = value;
        this.Changed(nameof (dpt_lv3_ViewCode));
      }
    }

    public string dpt_lv3_Name
    {
      get => this._dpt_lv3_Name;
      set
      {
        this._dpt_lv3_Name = value;
        this.Changed(nameof (dpt_lv3_Name));
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
      this.rowDataType = EnumRowType.Normal;
      this.si_StoreName = this.si_StoreViewCode = string.Empty;
      this.dpt_lv1_ID = 0;
      this.dpt_lv1_ViewCode = this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ID = 0;
      this.dpt_lv2_ViewCode = this.dpt_lv2_Name = string.Empty;
      this.dpt_lv3_ViewCode = this.dpt_lv3_Name = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoalByDeptView();

    public override object Clone()
    {
      GoalByDeptView goalByDeptView = base.Clone() as GoalByDeptView;
      goalByDeptView.rowDataType = this.rowDataType;
      goalByDeptView.si_StoreName = this.si_StoreName;
      goalByDeptView.si_StoreViewCode = this.si_StoreViewCode;
      goalByDeptView.dpt_lv1_ID = this.dpt_lv1_ID;
      goalByDeptView.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      goalByDeptView.dpt_lv1_Name = this.dpt_lv1_Name;
      goalByDeptView.dpt_lv2_ID = this.dpt_lv2_ID;
      goalByDeptView.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      goalByDeptView.dpt_lv2_Name = this.dpt_lv2_Name;
      goalByDeptView.dpt_lv3_ViewCode = this.dpt_lv3_ViewCode;
      goalByDeptView.dpt_lv3_Name = this.dpt_lv3_Name;
      goalByDeptView.inEmpName = this.inEmpName;
      goalByDeptView.modEmpName = this.modEmpName;
      return (object) goalByDeptView;
    }

    public void PutData(GoalByDeptView pSource)
    {
      this.PutData((TGoalByDept) pSource);
      this.rowDataType = pSource.rowDataType;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.dpt_lv1_ID = pSource.dpt_lv1_ID;
      this.dpt_lv1_ViewCode = pSource.dpt_lv1_ViewCode;
      this.dpt_lv1_Name = pSource.dpt_lv1_Name;
      this.dpt_lv2_ID = pSource.dpt_lv2_ID;
      this.dpt_lv2_ViewCode = pSource.dpt_lv2_ViewCode;
      this.dpt_lv2_Name = pSource.dpt_lv2_Name;
      this.dpt_lv3_ViewCode = pSource.dpt_lv3_ViewCode;
      this.dpt_lv3_Name = pSource.dpt_lv3_Name;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gbd_SiteID == 0L)
      {
        this.message = "싸이트(gbd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gbd_StoreCode == 0)
      {
        this.message = "지점코드(gbd_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.gbd_SaleDate.HasValue)
      {
        this.message = "판매일자(gbd_SaleDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.gbd_DeptCode != 0)
        return EnumDataCheck.Success;
      this.message = "부서ID(gbd_DeptCode)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsSalesGoalSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
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
          if (this.gbd_SiteID == 0L)
            this.gbd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
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
      GoalByDeptView goalByDeptView = this;
      try
      {
        goalByDeptView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goalByDeptView.DataCheck(p_db))
            throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goalByDeptView.gbd_SiteID == 0L)
            goalByDeptView.gbd_SiteID = p_app_employee.emp_SiteID;
          if (!goalByDeptView.IsPermit(p_app_employee))
            throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await goalByDeptView.InsertAsync())
          throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 등록 오류");
        goalByDeptView.db_status = 4;
        goalByDeptView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goalByDeptView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goalByDeptView.message = ex.Message;
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
      GoalByDeptView goalByDeptView = this;
      try
      {
        goalByDeptView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goalByDeptView.DataCheck(p_db))
            throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goalByDeptView.IsPermit(p_app_employee))
          throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await goalByDeptView.UpdateAsync())
          throw new UniServiceException(goalByDeptView.message, goalByDeptView.TableCode.ToDescription() + " 변경 오류");
        goalByDeptView.db_status = 4;
        goalByDeptView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goalByDeptView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goalByDeptView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.dpt_lv3_ViewCode = p_rs.GetFieldString("dpt_lv3_ViewCode");
      this.dpt_lv3_Name = p_rs.GetFieldString("dpt_lv3_Name");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GoalByDeptView> SelectOneAsync(
      int p_gbd_StoreCode,
      DateTime p_gbd_SaleDate,
      int p_gbd_DeptCode,
      long p_gbd_SiteID = 0)
    {
      GoalByDeptView goalByDeptView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gbd_StoreCode",
          (object) p_gbd_StoreCode
        },
        {
          (object) "gbd_SaleDate",
          (object) p_gbd_SaleDate
        },
        {
          (object) "gbd_DeptCode",
          (object) p_gbd_DeptCode
        }
      };
      if (p_gbd_SiteID > 0L)
        p_param.Add((object) "gbd_SiteID", (object) p_gbd_SiteID);
      return await goalByDeptView.SelectOneTAsync<GoalByDeptView>((object) p_param);
    }

    public async Task<IList<GoalByDeptView>> SelectListAsync(object p_param)
    {
      GoalByDeptView goalByDeptView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goalByDeptView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goalByDeptView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goalByDeptView1.GetSelectQuery(p_param)))
        {
          goalByDeptView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goalByDeptView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoalByDeptView>) null;
        }
        IList<GoalByDeptView> lt_list = (IList<GoalByDeptView>) new List<GoalByDeptView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoalByDeptView goalByDeptView2 = goalByDeptView1.OleDB.Create<GoalByDeptView>();
            if (goalByDeptView2.GetFieldValues(rs))
            {
              goalByDeptView2.row_number = lt_list.Count + 1;
              lt_list.Add(goalByDeptView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goalByDeptView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "dpt_lv1_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv1_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_lv1_ID", hashtable[(object) "dpt_lv1_ID"]));
        if (hashtable.ContainsKey((object) "dpt_lv2_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv2_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_lv2_ID", hashtable[(object) "dpt_lv2_ID"]));
        if (hashtable.ContainsKey((object) "dpt_lv3_ID") && Convert.ToInt32(hashtable[(object) "dpt_lv3_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_DeptCode", hashtable[(object) "dpt_lv3_ID"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_DeptName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
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
          if (hashtable.ContainsKey((object) "gbd_SiteID") && Convert.ToInt64(hashtable[(object) "gbd_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "gbd_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gbd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gbd_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gbd_StoreCode,gbd_SaleDate,gbd_DeptCode,gbd_SiteID,gbd_GoalSaleAmt,gbd_GoalProfitAmt,gbd_InDate,gbd_InUser,gbd_ModDate,gbd_ModUser,si_StoreName,si_StoreViewCode,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode AS dpt_lv3_ViewCode,dpt_DeptName AS dpt_lv3_Name,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON gbd_StoreCode=si_StoreCode AND gbd_SiteID=si_SiteID\n INNER JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_dept_v1 " + DbQueryHelper.ToWithNolock() + " ON gbd_DeptCode=view_dept_v1.dept_code AND gbd_SiteID=view_dept_v1.dpt_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON gbd_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON gbd_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gbd_StoreCode,gbd_SaleDate,gbd_DeptCode");
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
