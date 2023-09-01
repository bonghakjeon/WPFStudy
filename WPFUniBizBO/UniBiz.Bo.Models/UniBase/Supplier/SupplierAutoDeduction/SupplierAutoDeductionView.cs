// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction.SupplierAutoDeductionView
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

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction
{
  public class SupplierAutoDeductionView : TSupplierAutoDeduction<SupplierAutoDeductionView>
  {
    private string _inEmpName;
    private string _modEmpName;

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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SupplierAutoDeductionView();

    public override object Clone()
    {
      SupplierAutoDeductionView autoDeductionView = base.Clone() as SupplierAutoDeductionView;
      autoDeductionView.inEmpName = this.inEmpName;
      autoDeductionView.modEmpName = this.modEmpName;
      return (object) autoDeductionView;
    }

    public void PutData(SupplierAutoDeductionView pSource)
    {
      this.PutData((TSupplierAutoDeduction) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.suad_SiteID == 0L)
      {
        this.message = "싸이트(suad_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.suad_SupplierHistory == 0)
      {
        this.message = "업체 결제 이력 KEY(suad_SupplierHistory)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToDeductionAutoType(this.suad_Seq) == EnumDeductionAutoType.NONE)
      {
        this.message = "공제항목(suad_Seq)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToDeductionAutoCalc(this.suad_CalcType) == EnumDeductionAutoCalc.NONE)
      {
        this.message = "계산방법(suad_CalcType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToStdPreTax(this.suad_StdPriceType) != EnumStdPreTax.None)
        return EnumDataCheck.Success;
      this.message = "기준단가(suad_StdPriceType)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (this.IsNew)
      {
        if (!p_app_employee.IsSupplierSave)
        {
          this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (!p_app_employee.IsPayment)
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
          if (this.suad_SiteID == 0L)
            this.suad_SiteID = p_app_employee.emp_SiteID;
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
      SupplierAutoDeductionView autoDeductionView = this;
      try
      {
        autoDeductionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != autoDeductionView.DataCheck(p_db))
            throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (autoDeductionView.suad_SiteID == 0L)
            autoDeductionView.suad_SiteID = p_app_employee.emp_SiteID;
          if (!autoDeductionView.IsPermit(p_app_employee))
            throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await autoDeductionView.InsertAsync())
          throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 등록 오류");
        autoDeductionView.db_status = 4;
        autoDeductionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        autoDeductionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        autoDeductionView.message = ex.Message;
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
      SupplierAutoDeductionView autoDeductionView = this;
      try
      {
        autoDeductionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != autoDeductionView.DataCheck(p_db))
            throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!autoDeductionView.IsPermit(p_app_employee))
          throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await autoDeductionView.UpdateAsync())
          throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 변경 오류");
        autoDeductionView.db_status = 4;
        autoDeductionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        autoDeductionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        autoDeductionView.message = ex.Message;
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
      SupplierAutoDeductionView autoDeductionView = this;
      try
      {
        autoDeductionView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != autoDeductionView.DataCheck(p_db))
            throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!autoDeductionView.IsPermit(p_app_employee))
          throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await autoDeductionView.DeleteAsync())
          throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        autoDeductionView.db_status = 4;
        autoDeductionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        autoDeductionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        autoDeductionView.message = ex.Message;
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

    public async Task<SupplierAutoDeductionView> SelectOneAsync(
      int p_suad_SupplierHistory,
      int p_suad_Seq,
      long p_suad_SiteID = 0)
    {
      SupplierAutoDeductionView autoDeductionView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "suad_SupplierHistory",
          (object) p_suad_SupplierHistory
        },
        {
          (object) "suad_Seq",
          (object) p_suad_Seq
        }
      };
      if (p_suad_SiteID > 0L)
        p_param.Add((object) "suad_SiteID", (object) p_suad_SiteID);
      return await autoDeductionView.SelectOneTAsync<SupplierAutoDeductionView>((object) p_param);
    }

    public async Task<IList<SupplierAutoDeductionView>> SelectListAsync(object p_param)
    {
      SupplierAutoDeductionView autoDeductionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(autoDeductionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, autoDeductionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(autoDeductionView1.GetSelectQuery(p_param)))
        {
          autoDeductionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + autoDeductionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SupplierAutoDeductionView>) null;
        }
        IList<SupplierAutoDeductionView> lt_list = (IList<SupplierAutoDeductionView>) new List<SupplierAutoDeductionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SupplierAutoDeductionView autoDeductionView2 = autoDeductionView1.OleDB.Create<SupplierAutoDeductionView>();
            if (autoDeductionView2.GetFieldValues(rs))
            {
              autoDeductionView2.row_number = lt_list.Count + 1;
              lt_list.Add(autoDeductionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + autoDeductionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "suh_ID") && Convert.ToInt32(hashtable[(object) "suh_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_SupplierHistory", hashtable[(object) "suh_ID"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "suad_SiteID") && Convert.ToInt64(hashtable[(object) "suad_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "suad_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  suad_SupplierHistory,suad_Seq,suad_SiteID,suad_CalcType,suad_StdPriceType,suad_StdValue,suad_Value,suad_AddProperty,suad_InDate,suad_InUser,suad_ModDate,suad_ModUser,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON suad_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON suad_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
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
