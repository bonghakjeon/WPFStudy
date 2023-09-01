// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentWorkByManual
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentWorkByManual : PaymentView<PaymentWorkByManual>
  {
    private int _pay_ConfirmAfterCount;
    private int _pay_StatementConfirmAfterCount;
    private int _suh_PayCondition;
    private string _PaymentStoreSuplierDate;
    private string _WorkStoreCodeIn;
    private Action<string> _CallBackMessage;

    public int pay_ConfirmAfterCount
    {
      get => this._pay_ConfirmAfterCount;
      set
      {
        this._pay_ConfirmAfterCount = value;
        this.Changed(nameof (pay_ConfirmAfterCount));
      }
    }

    public int pay_StatementConfirmAfterCount
    {
      get => this._pay_StatementConfirmAfterCount;
      set
      {
        this._pay_StatementConfirmAfterCount = value;
        this.Changed(nameof (pay_StatementConfirmAfterCount));
      }
    }

    public int suh_PayCondition
    {
      get => this._suh_PayCondition;
      set
      {
        this._suh_PayCondition = value;
        this.Changed(nameof (suh_PayCondition));
      }
    }

    public string PaymentStoreSuplierDate
    {
      get => this._PaymentStoreSuplierDate;
      set
      {
        this._PaymentStoreSuplierDate = value;
        this.Changed(nameof (PaymentStoreSuplierDate));
      }
    }

    [JsonIgnore]
    public string WorkStoreCodeIn
    {
      get => this._WorkStoreCodeIn;
      set
      {
        this._WorkStoreCodeIn = value;
        this.Changed(nameof (WorkStoreCodeIn));
      }
    }

    public PaymentWorkByManual()
    {
    }

    public PaymentWorkByManual(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.pay_ConfirmAfterCount = this.pay_StatementConfirmAfterCount = 0;
      this.suh_PayCondition = 0;
    }

    public bool ItemSave()
    {
      try
      {
        if (this.db_status == 0)
        {
          if (!this.Insert())
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        }
        else if (this.db_status > 0 && !this.Update((UbModelBase) null))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      DateTime pWorkDate,
      int pStoreCode,
      string pStoreCodeIn,
      int pSupplier,
      bool pIsDayWork,
      EmployeeView pEmployee)
    {
      PaymentWorkByManual paymentWorkByManual = this;
      bool flag1 = paymentWorkByManual._CallBackMessage != null && pJobInfo != null;
      object obj = (object) null;
      int num = 0;
      bool flag;
      try
      {
        try
        {
          flag = true;
        }
        catch (Exception ex)
        {
          paymentWorkByManual.message = " " + paymentWorkByManual.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWorkByManual.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
          if (flag1)
          {
            JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
            jobEvtMessageErr1.SiteID = pJobInfo.SiteID;
            jobEvtMessageErr1.Id = pJobInfo.Id;
            jobEvtMessageErr1.JobId = pJobInfo.JobId;
            jobEvtMessageErr1.Msg = paymentWorkByManual.TableCode.ToDescription() + "/n" + ex.Message;
            JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
            paymentWorkByManual._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
            goto label_7;
          }
          else
          {
            Log.Logger.ErrorColor(paymentWorkByManual.message);
            goto label_7;
          }
        }
        num = 1;
      }
      catch (object ex)
      {
        obj = ex;
      }
label_7:
      await Task.CompletedTask;
      object obj1 = obj;
      if (obj1 != null)
      {
        if (!(obj1 is Exception source))
          throw obj1;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      if (num == 1)
        return flag;
      obj = (object) null;
      return false;
    }

    public async Task<IList<PaymentWorkByManual>> SelectWorkListAsync(Hashtable pParam)
    {
      PaymentWorkByManual paymentWorkByManual1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(paymentWorkByManual1.GetSelectQuery((object) pParam)))
        {
          paymentWorkByManual1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWorkByManual1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentWorkByManual>) null;
        }
        IList<PaymentWorkByManual> lt_list = (IList<PaymentWorkByManual>) new List<PaymentWorkByManual>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentWorkByManual paymentWorkByManual2 = paymentWorkByManual1.OleDB.Create<PaymentWorkByManual>();
            if (paymentWorkByManual2.GetFieldValues(rs))
            {
              paymentWorkByManual2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentWorkByManual2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWorkByManual1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pay_ConfirmAfterCount = p_rs.GetFieldInt("pay_ConfirmAfterCount");
      this.pay_StatementConfirmAfterCount = p_rs.GetFieldInt("pay_StatementConfirmAfterCount");
      this.PaymentStoreSuplierDate = string.Format("{0}|{1}|{2}", (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_Date.GetDateToStr("yyyy-MM-dd"));
      return true;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_StoreCode = 0;
        int p_Supplier = 0;
        PaymentWork paymentWork = new PaymentWork();
        DateTime? nullable1 = new DateTime?();
        DateTime? nullable2 = new DateTime?();
        DateTime? nullable3 = new DateTime?();
        DateTime? nullable4 = new DateTime?();
        DateTime? nullable5 = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString()) > 0)
            p_StoreCode = Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString()) > 0)
            p_Supplier = Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Date") && hashtable2[(object) "pay_Date"].ToString().Length > 0)
            nullable1 = new DateTime?((DateTime) hashtable2[(object) "pay_Date"]);
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate") && Convert.ToInt32(hashtable2[(object) "sh_ConfirmDate"].ToString()) > 0)
            nullable2 = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate"]);
          if (hashtable2.ContainsKey((object) "_DT_BASE_") && Convert.ToInt32(hashtable2[(object) "_DT_BASE_"].ToString()) > 0)
            nullable3 = new DateTime?((DateTime) hashtable2[(object) "_DT_BASE_"]);
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate_BEGIN_") && hashtable2[(object) "sh_ConfirmDate_BEGIN_"].ToString().Length > 0)
            nullable4 = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate_BEGIN_"]);
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate_END_") && hashtable2[(object) "sh_ConfirmDate_END_"].ToString().Length > 0)
            nullable5 = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate_END_"]);
        }
        if (!nullable3.HasValue && nullable1.HasValue)
          nullable3 = nullable1;
        if (!nullable3.HasValue && !nullable1.HasValue && !nullable2.HasValue)
        {
          Exception exception1 = new Exception("일자 정보 부족");
        }
        if (!nullable4.HasValue && !nullable5.HasValue)
        {
          Exception exception2 = new Exception("매입 일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (nullable2.HasValue)
          stringBuilder.Append(this.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_StoreCode, p_Supplier, nullable2.Value));
        else if (nullable3.HasValue)
          stringBuilder.Append(this.ToWithPayContionPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable3.Value, nullable4.Value, nullable5.Value));
        stringBuilder.Append(this.ToWithSupplierHistoryQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentExistQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentDateAfterConfirmQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentAfterStatementQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentMonthQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithMonthInitStatementBuyQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithMonthInitSalesLeaChargeRateNotZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithMonthInitSalesLeaChargeRateZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithMonthInitPaymetDetailQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithStatementBuyQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithSalesLeaChargeRateZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithStatementReturnQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithSalesQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append("\nSELECT\nSELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,su_SupplierType AS pay_SupplierType" + string.Format(",{0} AS {1},suph_dt_start AS {2},suph_dt_end AS {3}", (object) 2, (object) "pay_Type", (object) "pay_StartDate", (object) "pay_EndDate") + ",suh_PayMethod AS pay_PayMethod,payc_Round AS pay_Round,payc_Turn AS pay_Turn" + string.Format(",{0}", (object) this.suh_PayCondition));
        stringBuilder.Append(PaymentWork.MainCol);
        stringBuilder.Append(",NULL AS pay_InDate,0 AS pay_InUser,NULL As pay_ModDate,0 AS pay_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_Email,si_LocationUseYn\n,su_HeadSupplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement\n,'' AS inEmpName,'' AS modEmpName");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT SUM(pay_Code) AS pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier");
        stringBuilder.Append(PaymentWork.SubCol);
        stringBuilder.Append("\nFROM (");
        string str = "\nSELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier\n" + PaymentWork.MainCol;
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_PAYMENT_EXIST");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_PAYMENT_DATE_AFTER_CONFIRM");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_PAYMENT_DATE_AFTER_STATEMENT");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_PAYMENT_MONTH");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_MONTH_INIT_STATEMENT_BUY");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_MONTH_INIT_SALES_LEA_CHARGE_NOT_ZERO");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_MONTH_INIT_SALES_LEA_CHARGE_ZERO");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_MONTH_INIT_PAYMENT_DETAIL");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_STATEMENT_BUY");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_SALES_LEA_CHARGE_NOT_ZERO");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_SALES_LEA_CHARGE_ZERO");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_STATEMENT_RETURN");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_SALES");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append(str);
        stringBuilder.Append("\nFROM T_PAYMENT_STATEMENT");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID\n INNER JOIN T_SUPPLIER ON pay_Supplier=su_Supplier AND pay_SiteID=su_SiteID");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY pay_SiteID,pay_StoreCode,pay_Date,pay_Supplier,pay_Code");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPayContionStatementQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      int p_StoreCode,
      int p_Supplier,
      DateTime p_sh_ConfirmDate)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string dateToStr1 = new DateTime?(p_sh_ConfirmDate.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
        string dateToStr2 = new DateTime?(p_sh_ConfirmDate.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'");
        stringBuilder.Append("\n,T_PAY_CONTION AS (\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,pay_StartDate AS pc_dt_start,pay_EndDate AS pc_dt_end,pay_Date AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format(" ON {0}={1} AND {2}={3}", (object) "payc_ID", (object) 9999, (object) "payc_SiteID", (object) p_SiteID) + string.Format("\nWHERE {0}={1}", (object) "pay_SiteID", (object) p_SiteID) + "\n AND pay_StartDate<=" + dateToStr1 + " AND pay_EndDate>=" + dateToStr2 + string.Format("\n AND {0}={1}", (object) "pay_StoreCode", (object) p_StoreCode) + string.Format(" AND {0}={1}", (object) "pay_Supplier", (object) p_Supplier) + ")\n");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPayContionPaymentQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      DateTime dt_pay_Date,
      DateTime p_sh_ConfirmDateBegin,
      DateTime p_sh_ConfirmDateEnd)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string dateToStr1 = new DateTime?(dt_pay_Date).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
      string dateToStr2 = new DateTime?(p_sh_ConfirmDateBegin).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
      string dateToStr3 = new DateTime?(p_sh_ConfirmDateEnd).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'");
      stringBuilder.Append("\n,T_PAY_CONTION AS (\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay," + dateToStr2 + " AS pc_dt_start," + dateToStr3 + " AS pc_dt_end," + dateToStr1 + " AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "payc_ID", (object) 9999) + string.Format("\nAND {0}={1}", (object) "payc_SiteID", (object) p_SiteID) + ")\n");
      return stringBuilder.ToString();
    }
  }
}
