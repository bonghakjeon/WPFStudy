// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.CommonCodeView
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

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class CommonCodeView : TCommonCode<CommonCodeView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private IList<CommonCodeView> _Lt_Detail;

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

    [JsonPropertyName("lt_Detail")]
    public IList<CommonCodeView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<CommonCodeView>) new List<CommonCodeView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
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
      this.Lt_Detail = (IList<CommonCodeView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CommonCodeView();

    public override object Clone()
    {
      CommonCodeView commonCodeView1 = base.Clone() as CommonCodeView;
      commonCodeView1.inEmpName = this.inEmpName;
      commonCodeView1.modEmpName = this.modEmpName;
      commonCodeView1.Lt_Detail = (IList<CommonCodeView>) null;
      if (this.Lt_Detail.Count > 0)
      {
        foreach (CommonCodeView commonCodeView2 in (IEnumerable<CommonCodeView>) this.Lt_Detail)
          commonCodeView1.Lt_Detail.Add(commonCodeView2);
      }
      return (object) commonCodeView1;
    }

    public void PutData(CommonCodeView pSource)
    {
      this.PutData((TCommonCode) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Detail = (IList<CommonCodeView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (CommonCodeView pSource1 in (IEnumerable<CommonCodeView>) pSource.Lt_Detail)
      {
        CommonCodeView commonCodeView = new CommonCodeView();
        commonCodeView.PutData(pSource1);
        this.Lt_Detail.Add(commonCodeView);
      }
    }

    public CommonCodeView Apply(CommonCodeView pOrigin)
    {
      this.PutData((TCommonCode) pOrigin);
      foreach (CommonCodeView commonCodeView in (IEnumerable<CommonCodeView>) pOrigin.Lt_Detail)
        this.Lt_Detail.Add(commonCodeView);
      return this;
    }

    public CommonCodeView Apply(CommonCodeGroup pOrigin)
    {
      foreach (CommonCodeView commonCodeView in pOrigin.Items)
        this.Lt_Detail.Add(commonCodeView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.comm_Type == 0)
      {
        this.message = "타입(comm_Type)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.comm_TypeNo < 0)
      {
        this.message = "코드(comm_TypeNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.comm_SiteID == 0L)
      {
        this.message = "싸이트(comm_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.comm_TypeMemo))
      {
        this.message = "타입설명(comm_TypeMemo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.comm_TypeNoMemo))
        return EnumDataCheck.Success;
      this.message = "코드명(comm_TypeNoMemo)  " + EnumDataCheck.Empty.ToDescription();
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
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (Enum2StrConverter.IsCommonCodeFixedType(this.comm_Type))
      {
        if (!p_app_employee.IsSystem && !p_app_employee.IsAgent)
        {
          this.message = "고정코드 - " + p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (!p_app_employee.IsAdmin)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return true;
    }

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID));

    public override async Task<bool> InsertAsync()
    {
      CommonCodeView commonCodeView = this;
      // ISSUE: reference to a compiler-generated method
      return await commonCodeView.\u003C\u003En__0() && commonCodeView.SetSuccessInfo(string.Format("({0},{1},{2}) 등록됨.", (object) commonCodeView.comm_Type, (object) commonCodeView.comm_TypeNo, (object) commonCodeView.comm_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      CommonCodeView commonCodeView = this;
      // ISSUE: reference to a compiler-generated method
      return await commonCodeView.\u003C\u003En__1(p_old) && commonCodeView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) commonCodeView.comm_Type, (object) commonCodeView.comm_TypeNo, (object) commonCodeView.comm_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      CommonCodeView commonCodeView = this;
      // ISSUE: reference to a compiler-generated method
      return await commonCodeView.\u003C\u003En__2() && commonCodeView.SetSuccessInfo(string.Format("({0},{1},{2}) 변경됨.", (object) commonCodeView.comm_Type, (object) commonCodeView.comm_TypeNo, (object) commonCodeView.comm_SiteID));
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
          if (this.comm_SiteID == 0L)
            this.comm_SiteID = p_app_employee.emp_SiteID;
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
      CommonCodeView commonCodeView = this;
      try
      {
        commonCodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != commonCodeView.DataCheck(p_db))
            throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (commonCodeView.comm_SiteID == 0L)
            commonCodeView.comm_SiteID = p_app_employee.emp_SiteID;
          if (!commonCodeView.IsPermit(p_app_employee))
            throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await commonCodeView.InsertAsync())
          throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 등록 오류");
        commonCodeView.db_status = 4;
        commonCodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        commonCodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        commonCodeView.message = ex.Message;
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
        if (this.comm_TypeNo == 0)
          this.UpdateTypeNoMemo();
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
      CommonCodeView commonCodeView = this;
      try
      {
        commonCodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != commonCodeView.DataCheck(p_db))
            throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!commonCodeView.IsPermit(p_app_employee))
          throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await commonCodeView.UpdateAsync())
          throw new UniServiceException(commonCodeView.message, commonCodeView.TableCode.ToDescription() + " 변경 오류");
        if (commonCodeView.comm_TypeNo == 0)
        {
          int num = await commonCodeView.UpdateTypeNoMemoAsync() ? 1 : 0;
        }
        commonCodeView.db_status = 4;
        commonCodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        commonCodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        commonCodeView.message = ex.Message;
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

    public async Task<CommonCodeView> SelectOneAsync(
      int p_comm_Type,
      int p_comm_TypeNo,
      long p_comm_SiteID)
    {
      return await this.SelectOneTAsync<CommonCodeView>((object) new Hashtable()
      {
        {
          (object) "comm_Type",
          (object) p_comm_Type
        },
        {
          (object) "comm_TypeNo",
          (object) p_comm_TypeNo
        },
        {
          (object) "comm_SiteID",
          (object) p_comm_SiteID
        }
      });
    }

    public async Task<IList<CommonCodeView>> SelectListAsync(object p_param)
    {
      CommonCodeView commonCodeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(commonCodeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, commonCodeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(commonCodeView1.GetSelectQuery(p_param)))
        {
          commonCodeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + commonCodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CommonCodeView>) null;
        }
        IList<CommonCodeView> lt_list = (IList<CommonCodeView>) new List<CommonCodeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CommonCodeView commonCodeView2 = commonCodeView1.OleDB.Create<CommonCodeView>();
            if (commonCodeView2.GetFieldValues(rs))
            {
              commonCodeView2.row_number = lt_list.Count + 1;
              lt_list.Add(commonCodeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + commonCodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "comm_TypeMemo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "comm_TypeNoMemo", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "comm_SiteID") && Convert.ToInt64(hashtable[(object) "comm_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "comm_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  comm_Type,comm_TypeNo,comm_SiteID,comm_TypeMemo,comm_TypeNoMemo,comm_SortNo,comm_DataInt,comm_DataMoney,comm_DataString,comm_UseYn,comm_InDate,comm_InUser,comm_ModDate,comm_ModUser\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON comm_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON comm_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append("\nORDER BY comm_Type,comm_TypeNo");
              break;
            case 2:
              stringBuilder.Append("\nORDER BY comm_Type,comm_TypeNo DESC");
              break;
            case 3:
              stringBuilder.Append("\nORDER BY comm_Type,comm_SortNo,comm_TypeNo");
              break;
            case 4:
              stringBuilder.Append("\nORDER BY comm_Type,comm_SortNo DESC,comm_TypeNo");
              break;
            default:
              stringBuilder.Append("\nORDER BY comm_Type,comm_TypeNo");
              break;
          }
        }
        else if (empty != null && empty.Length > 0)
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY comm_SiteID,comm_Type,comm_TypeNo");
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
