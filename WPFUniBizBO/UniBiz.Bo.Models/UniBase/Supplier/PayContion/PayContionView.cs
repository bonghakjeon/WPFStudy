// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.PayContion.PayContionView
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

namespace UniBiz.Bo.Models.UniBase.Supplier.PayContion
{
  public class PayContionView : TPayContion<PayContionView>
  {
    private DateTime? _dt_Start;
    private DateTime? _dt_End;
    private int _sup_count;
    private int _pay_count;
    private string _inEmpName;
    private string _modEmpName;

    public DateTime? dt_Start
    {
      get => this._dt_Start;
      set
      {
        this._dt_Start = value;
        this.Changed(nameof (dt_Start));
      }
    }

    public DateTime? dt_End
    {
      get => this._dt_End;
      set
      {
        this._dt_End = value;
        this.Changed(nameof (dt_End));
      }
    }

    public int sup_count
    {
      get => this._sup_count;
      set
      {
        this._sup_count = value;
        this.Changed(nameof (sup_count));
      }
    }

    public int pay_count
    {
      get => this._pay_count;
      set
      {
        this._pay_count = value;
        this.Changed(nameof (pay_count));
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
      this.dt_Start = new DateTime?();
      this.dt_End = new DateTime?();
      this.sup_count = this.pay_count = 0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PayContionView();

    public override object Clone()
    {
      PayContionView payContionView = base.Clone() as PayContionView;
      payContionView.dt_Start = this.dt_Start;
      payContionView.dt_End = this.dt_End;
      payContionView.sup_count = this.sup_count;
      payContionView.pay_count = this.pay_count;
      payContionView.inEmpName = this.inEmpName;
      payContionView.modEmpName = this.modEmpName;
      return (object) payContionView;
    }

    public void PutData(PayContionView pSource)
    {
      this.PutData((TPayContion) pSource);
      this.dt_Start = pSource.dt_Start;
      this.dt_End = pSource.dt_End;
      this.sup_count = pSource.sup_count;
      this.pay_count = pSource.pay_count;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.payc_SiteID == 0L)
      {
        this.message = "싸이트(payc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.payc_Round == 0)
      {
        this.message = "회(payc_Round)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.payc_CalcStartDay == 99)
      {
        this.message = "조회 시작일(payc_CalcStartDay)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.payc_PaymentDay != 0)
        return EnumDataCheck.Success;
      this.message = "조회 시작일(payc_CalcStartDay)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(payc_ID), 0)+1 AS payc_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "payc_SiteID", (object) this.payc_SiteID);
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
          this.payc_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.payc_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      PayContionView payContionView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(payContionView.CreateCodeQuery()))
        {
          payContionView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + payContionView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          payContionView.payc_ID = rs.GetFieldInt(0);
        return payContionView.payc_ID > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public string CreateTurnQuery() => " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(payc_Turn), 0)+1 AS payc_Turn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "payc_ID", (object) this.payc_ID) + string.Format(" AND {0}={1}", (object) "payc_SiteID", (object) this.payc_SiteID);

    public bool CreateTurn(UniOleDatabase p_db)
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
          this.payc_Turn = uniOleDbRecordset.GetFieldInt(0);
        return this.payc_Turn > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public async Task<bool> CreateTurnAsync(UniOleDatabase p_db)
    {
      PayContionView payContionView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(payContionView.CreateCodeQuery()))
        {
          payContionView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + payContionView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          payContionView.payc_Turn = rs.GetFieldInt(0);
        return payContionView.payc_Turn > 0;
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
          if (this.payc_SiteID == 0L)
            this.payc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.payc_ID == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(payc_ID) 생성 오류", 2);
        if (this.payc_Turn == 0 && !this.CreateTurn(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(payc_Turn) 생성 오류", 2);
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
      PayContionView payContionView = this;
      try
      {
        payContionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != payContionView.DataCheck(p_db))
            throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (payContionView.payc_SiteID == 0L)
            payContionView.payc_SiteID = p_app_employee.emp_SiteID;
          if (!payContionView.IsPermit(p_app_employee))
            throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (payContionView.payc_ID == 0)
        {
          if (!await payContionView.CreateCodeAsync(p_db))
            throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 코드(payc_ID) 생성 오류", 2);
        }
        if (payContionView.payc_Turn == 0)
        {
          if (!await payContionView.CreateTurnAsync(p_db))
            throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 코드(payc_Turn) 생성 오류", 2);
        }
        if (!await payContionView.InsertAsync())
          throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 등록 오류");
        payContionView.db_status = 4;
        payContionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        payContionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        payContionView.message = ex.Message;
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
        if (this.payc_ID == 0 || this.payc_Turn == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 결제조건 ID(payc_ID) OR 차(payc_Turn) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      PayContionView payContionView = this;
      try
      {
        payContionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != payContionView.DataCheck(p_db))
            throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!payContionView.IsPermit(p_app_employee))
          throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (payContionView.payc_ID == 0 || payContionView.payc_Turn == 0)
          throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 결제조건 ID(payc_ID) OR 차(payc_Turn) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await payContionView.UpdateAsync())
          throw new UniServiceException(payContionView.message, payContionView.TableCode.ToDescription() + " 변경 오류");
        payContionView.db_status = 4;
        payContionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        payContionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        payContionView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.sup_count = p_rs.GetFieldInt("sup_count");
      this.dt_Start = p_rs.GetFieldDateTime("dt_Start");
      this.dt_End = p_rs.GetFieldDateTime("dt_End");
      return true;
    }

    public async Task<PayContionView> SelectOneAsync(
      int p_payc_ID,
      int p_payc_Turn,
      long p_payc_SiteID)
    {
      return await this.SelectOneTAsync<PayContionView>((object) new Hashtable()
      {
        {
          (object) "payc_ID",
          (object) p_payc_ID
        },
        {
          (object) "payc_Turn",
          (object) p_payc_Turn
        },
        {
          (object) "payc_SiteID",
          (object) p_payc_SiteID
        }
      });
    }

    public async Task<IList<PayContionView>> SelectListAsync(object p_param)
    {
      PayContionView payContionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(payContionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, payContionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(payContionView1.GetSelectQuery(p_param)))
        {
          payContionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + payContionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PayContionView>) null;
        }
        IList<PayContionView> lt_list = (IList<PayContionView>) new List<PayContionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PayContionView payContionView2 = payContionView1.OleDB.Create<PayContionView>();
            if (payContionView2.GetFieldValues(rs))
            {
              payContionView2.row_number = lt_list.Count + 1;
              lt_list.Add(payContionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + payContionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_"))
      {
        int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str1 = this.TableCode.ToString();
        string empty = string.Empty;
        long num = 0;
        DateTime firstDateOfMonth = DateTime.Now.ToFirstDateOfMonth();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str1 = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "payc_SiteID") && Convert.ToInt64(hashtable[(object) "payc_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "payc_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "_DT_DATE_"))
            firstDateOfMonth = ((DateTime) hashtable[(object) "_DT_DATE_"]).ToFirstDateOfMonth();
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUP_COUNT AS ( SELECT suh_PayCondition,suh_SiteID,count(*) AS  sup_count" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.SupplierHistory, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "suh_SiteID", (object) num));
        stringBuilder.Append(" GROUP BY suh_PayCondition,suh_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        string str2 = new DateTime?(firstDateOfMonth).GetDateToStr("\\'yyyy-MM-dd\\'").DateAdd("payc_CalcStartMonth", EnumDbAddType.MONTH).DateAdd("payc_CalcStartDay-1", EnumDbAddType.DAY);
        string str3 = "CASE WHEN payc_CalcEndDay=99 THEN " + new DateTime?(firstDateOfMonth).GetDateToStr("\\'yyyy-MM-dd\\'").DateAdd("payc_CalcEndMonth", EnumDbAddType.MONTH).DateAdd(1, EnumDbAddType.MONTH).DateAdd(-1, EnumDbAddType.DAY) + " ELSE " + new DateTime?(firstDateOfMonth).GetDateToStr("\\'yyyy-MM-dd\\'").DateAdd("payc_CalcEndMonth", EnumDbAddType.MONTH).DateAdd("payc_CalcEndDay-1", EnumDbAddType.DAY) + " END";
        stringBuilder.Append(" SELECT  payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,payc_CalcStartMonth,payc_CalcStartDay,payc_CalcEndMonth,payc_CalcEndDay,payc_Memo,payc_InDate,payc_InUser,payc_ModDate,payc_ModUser," + str2 + " AS dt_Start," + str3 + " AS dt_End,sup_count,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON payc_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON payc_ModUser=emp_CodeMod LEFT OUTER JOIN T_SUP_COUNT ON payc_ID=suh_PayCondition AND payc_SiteID=suh_SiteID");
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
