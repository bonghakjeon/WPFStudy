// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition.AutoOrderConitionView
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition
{
  public class AutoOrderConitionView : TAutoOrderConition<AutoOrderConitionView>
  {
    private string _si_StoreName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private string _ctg_ViewCode;
    private string _ctg_CategoryName;
    private string _inEmpName;
    private string _modEmpName;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = value;
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = value;
        this.Changed(nameof (ctg_ViewCode));
      }
    }

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = value;
        this.Changed(nameof (ctg_CategoryName));
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
      this.si_StoreName = string.Empty;
      this.su_SupplierName = string.Empty;
      this.su_SupplierViewCode = string.Empty;
      this.ctg_ViewCode = string.Empty;
      this.ctg_CategoryName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new AutoOrderConitionView();

    public override object Clone()
    {
      AutoOrderConitionView orderConitionView = base.Clone() as AutoOrderConitionView;
      orderConitionView.si_StoreName = this.si_StoreName;
      orderConitionView.su_SupplierName = this.su_SupplierName;
      orderConitionView.su_SupplierViewCode = this.su_SupplierViewCode;
      orderConitionView.ctg_ViewCode = this.ctg_ViewCode;
      orderConitionView.ctg_CategoryName = this.ctg_CategoryName;
      orderConitionView.inEmpName = this.inEmpName;
      orderConitionView.modEmpName = this.modEmpName;
      return (object) orderConitionView;
    }

    public void PutData(AutoOrderConitionView pSource)
    {
      this.PutData((TAutoOrderConition) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.ctg_ViewCode = pSource.ctg_ViewCode;
      this.ctg_CategoryName = pSource.ctg_CategoryName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.aoc_SiteID == 0L)
      {
        this.message = "싸이트(aoc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.aoc_StoreCode == 0)
      {
        this.message = "지점코드(aoc_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.aoc_Supplier == 0)
      {
        this.message = "코드(aoc_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.aoc_CategoryCodeTop != 0)
        return EnumDataCheck.Success;
      this.message = "대분류코드(aoc_CategoryCodeTop)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsSupplierSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(aoc_ID), 0)+1 AS aoc_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.aoc_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.aoc_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      AutoOrderConitionView orderConitionView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(orderConitionView.CreateCodeQuery()))
        {
          orderConitionView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + orderConitionView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          orderConitionView.aoc_ID = rs.GetFieldInt(0);
        return orderConitionView.aoc_ID > 0;
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
          if (this.aoc_SiteID == 0L)
            this.aoc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.aoc_ID == 0 && !this.CreateCode(p_db))
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
      AutoOrderConitionView orderConitionView = this;
      try
      {
        orderConitionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != orderConitionView.DataCheck(p_db))
            throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (orderConitionView.aoc_SiteID == 0L)
            orderConitionView.aoc_SiteID = p_app_employee.emp_SiteID;
          if (!orderConitionView.IsPermit(p_app_employee))
            throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (orderConitionView.aoc_ID == 0)
        {
          if (!await orderConitionView.CreateCodeAsync(p_db))
            throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await orderConitionView.InsertAsync())
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 등록 오류");
        orderConitionView.db_status = 4;
        orderConitionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        orderConitionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        orderConitionView.message = ex.Message;
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
        if (this.aoc_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 자동발주ID(aoc_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      AutoOrderConitionView orderConitionView = this;
      try
      {
        orderConitionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != orderConitionView.DataCheck(p_db))
            throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!orderConitionView.IsPermit(p_app_employee))
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (orderConitionView.aoc_ID == 0)
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 자동발주ID(aoc_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await orderConitionView.UpdateAsync())
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 변경 오류");
        orderConitionView.db_status = 4;
        orderConitionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        orderConitionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        orderConitionView.message = ex.Message;
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
        if (this.aoc_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 자동발주ID(aoc_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      AutoOrderConitionView orderConitionView = this;
      try
      {
        orderConitionView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != orderConitionView.DataCheck(p_db))
            throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!orderConitionView.IsPermit(p_app_employee))
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (orderConitionView.aoc_ID == 0)
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 자동발주ID(aoc_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await orderConitionView.DeleteAsync())
          throw new UniServiceException(orderConitionView.message, orderConitionView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        orderConitionView.db_status = 4;
        orderConitionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        orderConitionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        orderConitionView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
      this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<AutoOrderConitionView> SelectOneAsync(int p_aoc_ID, long p_aoc_SiteID = 0)
    {
      AutoOrderConitionView orderConitionView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "aoc_ID",
          (object) p_aoc_ID
        }
      };
      if (p_aoc_SiteID > 0L)
        p_param.Add((object) "aoc_SiteID", (object) p_aoc_SiteID);
      return await orderConitionView.SelectOneTAsync<AutoOrderConitionView>((object) p_param);
    }

    public async Task<IList<AutoOrderConitionView>> SelectListAsync(object p_param)
    {
      AutoOrderConitionView orderConitionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(orderConitionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, orderConitionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(orderConitionView1.GetSelectQuery(p_param)))
        {
          orderConitionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + orderConitionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<AutoOrderConitionView>) null;
        }
        IList<AutoOrderConitionView> lt_list = (IList<AutoOrderConitionView>) new List<AutoOrderConitionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            AutoOrderConitionView orderConitionView2 = orderConitionView1.OleDB.Create<AutoOrderConitionView>();
            if (orderConitionView2.GetFieldValues(rs))
            {
              orderConitionView2.row_number = lt_list.Count + 1;
              lt_list.Add(orderConitionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + orderConitionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_ViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_CategoryName", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "aoc_SiteID") && Convert.ToInt64(hashtable[(object) "aoc_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "aoc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_SupplierName,su_SupplierViewCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        Hashtable p_param1 = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("aoc_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("aoc_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        else if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS (SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_CTG_LV_1_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("aoc_SiteID"))
            p_param1.Add((object) "ctg_SiteID", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TCategory().GetSelectWhereAnd((object) p_param1));
        else if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  aoc_ID,aoc_SiteID,aoc_Supplier,aoc_StoreCode,aoc_CategoryCodeTop,aoc_DayofWeek,aoc_LeadTime,aoc_OrderCycle,aoc_StatementSeqType,aoc_AddProperty,aoc_InDate,aoc_InUser,aoc_ModDate,aoc_ModUser,si_StoreName,su_SupplierName,su_SupplierViewCode,ctg_ViewCode,ctg_CategoryName,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_SUPPLIER ON aoc_Supplier=su_Supplier AND aoc_SiteID=su_SiteID INNER JOIN T_STORE ON aoc_StoreCode=si_StoreCode AND aoc_SiteID=si_SiteID LEFT OUTER JOIN T_CTG_LV_1_NAME ON aoc_CategoryCodeTop=ctg_ID LEFT OUTER JOIN T_EMPLOYEE_IN ON aoc_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON aoc_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY aoc_Supplier,aoc_StoreCode,ctg_ViewCode");
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
