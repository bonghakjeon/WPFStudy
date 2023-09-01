// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentWork
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
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentWork : PaymentView<PaymentWork>
  {
    private bool _IsWorkDateType = true;
    private int _pay_ConfirmAfterCount;
    private int _pay_StatementConfirmAfterCount;
    private int _suh_PayCondition;
    private string _PaymentStoreSuplierDate;
    private string _WorkStoreCodeIn;
    private Action<string> _CallBackMessage;
    [JsonIgnore]
    public static string MainCol = ",pay_ConfirmStatus,pay_StatementStatus,pay_TypeCustom1,pay_TypeCustom2,pay_BaseAmount,pay_BuyAmount,pay_BuyTax,pay_BuyVat,pay_BuyFree,pay_BuyReturnAmount,pay_BuyReturnTax,pay_BuyReturnVat,pay_BuyReturnFree,pay_Deposit,pay_SaleAmount,pay_SaleTax,pay_SaleVat,pay_SaleFree,pay_DeductionAmount,pay_PayAmount,pay_AddAmount,pay_EndAmount\n,pay_ConfirmAfterCount,pay_StatementConfirmAfterCount\n,db_status";
    [JsonIgnore]
    public static string SubCol = ",SUM(pay_ConfirmStatus) AS pay_ConfirmStatus,SUM(pay_StatementStatus) AS pay_StatementStatus,SUM(pay_TypeCustom1) AS pay_TypeCustom1,SUM(pay_TypeCustom2) AS pay_TypeCustom2,SUM(pay_BaseAmount) AS pay_BaseAmount ,SUM(pay_BuyAmount) AS  pay_BuyAmount,SUM(pay_BuyTax) AS pay_BuyTax,SUM(pay_BuyVat) AS pay_BuyVat,SUM(pay_BuyFree) AS pay_BuyFree,SUM(pay_BuyReturnAmount) AS pay_BuyReturnAmount,SUM(pay_BuyReturnTax) AS pay_BuyReturnTax,SUM(pay_BuyReturnVat) AS pay_BuyReturnVat,SUM(pay_BuyReturnFree) AS pay_BuyReturnFree,SUM(pay_Deposit) AS pay_Deposit,SUM(pay_SaleAmount) AS pay_SaleAmount,SUM(pay_SaleTax) AS pay_SaleTax,SUM(pay_SaleVat) AS pay_SaleVat,SUM(pay_SaleFree) AS pay_SaleFree,SUM(pay_DeductionAmount) AS pay_DeductionAmount,SUM(pay_PayAmount) AS pay_PayAmount,SUM(pay_AddAmount) AS pay_AddAmount,SUM(pay_EndAmount) AS pay_EndAmount\n,SUM(pay_ConfirmAfterCount) AS pay_ConfirmAfterCount,SUM(pay_StatementConfirmAfterCount) AS pay_StatementConfirmAfterCount\n,SUM(db_status) AS db_status";

    public string AlternateKeyCode => string.Format("{0}|{1}|{2}", (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_Date.Value.ToIntFormat());

    public string AutoDeductionKeyCode => string.Format("{0}|{1}|{2}|{3}", (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_Date.Value.ToIntFormat(), (object) this.pay_EndDate.Value.ToIntFormat());

    public override int pay_StoreCode
    {
      get => this._pay_StoreCode;
      set
      {
        this._pay_StoreCode = value;
        this.Changed(nameof (pay_StoreCode));
        this.Changed("AlternateKeyCode");
        this.Changed("AutoDeductionKeyCode");
      }
    }

    public override int pay_Supplier
    {
      get => this._pay_Supplier;
      set
      {
        this._pay_Supplier = value;
        this.Changed(nameof (pay_Supplier));
        this.Changed("AlternateKeyCode");
        this.Changed("AutoDeductionKeyCode");
      }
    }

    public override DateTime? pay_Date
    {
      get => this._pay_Date;
      set
      {
        this._pay_Date = value;
        this.Changed(nameof (pay_Date));
        this.Changed("AlternateKeyCode");
        this.Changed("AutoDeductionKeyCode");
      }
    }

    public override DateTime? pay_EndDate
    {
      get => this._pay_EndDate;
      set
      {
        this._pay_EndDate = value;
        this.Changed(nameof (pay_EndDate));
        this.Changed("AutoDeductionKeyCode");
      }
    }

    [JsonPropertyName("isWorkDateType")]
    public bool IsWorkDateType
    {
      get => this._IsWorkDateType;
      set
      {
        this._IsWorkDateType = value;
        this.Changed(nameof (IsWorkDateType));
      }
    }

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

    public PaymentWork()
    {
    }

    public PaymentWork(Action<string> p_Callback)
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
      PaymentWork paymentWork1 = this;
      bool isMessage = paymentWork1._CallBackMessage != null && pJobInfo != null;
      try
      {
        if (paymentWork1.pay_SiteID == 0L && pJobInfo != null && pJobInfo.SiteID > 0L)
          paymentWork1.pay_SiteID = pJobInfo.SiteID;
        PaymentDetailAutoDeductionView ProcAutoDeduction = new PaymentDetailAutoDeductionView(new Action<string>(paymentWork1.JobWorkMessage));
        ProcAutoDeduction.SetAdoDatabase(paymentWork1.OleDB);
        if (!await ProcAutoDeduction.ProcApplyAsync(pJobInfo, pWorkDate, pStoreCode, pStoreCodeIn, pSupplier, pIsDayWork, pEmployee))
          throw new Exception("자동 공제 전표 작업 에러.\n" + ProcAutoDeduction.message);
        ProcAutoDeduction = (PaymentDetailAutoDeductionView) null;
        Hashtable param = new Hashtable();
        param.Add((object) "pay_SiteID", (object) paymentWork1.pay_SiteID);
        param.Add((object) "pay_Date", (object) pWorkDate);
        if (!pIsDayWork)
          param.Add((object) "_INIT_", (object) true);
        if (pStoreCode > 0)
          param.Add((object) "pay_StoreCode", (object) pStoreCode);
        if (!string.IsNullOrEmpty(pStoreCodeIn))
          param.Add((object) "pay_StoreCode_IN_", (object) pStoreCodeIn);
        if (pSupplier > 0)
          param.Add((object) "pay_Supplier", (object) pSupplier);
        param.Add((object) "pay_Type", (object) 1);
        if (!await paymentWork1.DataClearAsync(param))
          throw new Exception("월 대금 기초 초기화 실패. 작업 취소 처리.\n" + paymentWork1.message);
        param.Clear();
        param.Add((object) "pay_SiteID", (object) paymentWork1.pay_SiteID);
        if (pStoreCode > 0)
          param.Add((object) "pay_StoreCode", (object) pStoreCode);
        else if (!string.IsNullOrEmpty(pStoreCodeIn))
          param.Add((object) "pay_StoreCode_IN_", (object) pStoreCodeIn);
        if (pSupplier > 0)
          param.Add((object) "pay_Supplier", (object) pSupplier);
        param.Add((object) "_DT_BASE_", (object) pWorkDate);
        PaymentWorkByAlternateKeyDic list_orign = new PaymentWorkByAlternateKeyDic();
        PaymentWorkByAlternateKeyDic list_duplicate = new PaymentWorkByAlternateKeyDic();
        foreach (PaymentWork pInfo in (IEnumerable<PaymentWork>) await paymentWork1.SelectDuplicateCheckListAsync(param))
        {
          if (!list_orign.ContainsKey(pInfo.AlternateKeyCode))
            list_orign.AddOrigin(pInfo);
          else if (!list_duplicate.ContainsKey(pInfo.AlternateKeyCode))
            list_duplicate.AddOrigin(pInfo);
        }
        param.Clear();
        param.Add((object) "pay_SiteID", (object) paymentWork1.pay_SiteID);
        if (pStoreCode > 0)
          param.Add((object) "pay_StoreCode", (object) pStoreCode);
        else if (!string.IsNullOrEmpty(pStoreCodeIn))
          param.Add((object) "pay_StoreCode_IN_", (object) pStoreCodeIn);
        if (pSupplier > 0)
          param.Add((object) "pay_Supplier", (object) pSupplier);
        param.Add((object) "_DT_BASE_", (object) pWorkDate);
        if (pIsDayWork)
          param.Add((object) "pay_Date", (object) pWorkDate);
        IList<PaymentWork> paymentWorkList = await paymentWork1.SelectWorkListAsync(param);
        if (paymentWorkList == null)
          throw new Exception("조회에러.\n" + paymentWork1.message);
        int num1 = 0;
        int num2 = 0;
        foreach (PaymentWork paymentWork2 in (IEnumerable<PaymentWork>) paymentWorkList)
        {
          if (paymentWork2.pay_SiteID == 0L)
            paymentWork2.pay_SiteID = paymentWork1.pay_SiteID;
          if (paymentWork2.pay_StoreCode == 0 || paymentWork2.pay_Supplier == 0)
            ++num2;
          else if (list_duplicate.ContainsKey(paymentWork2.AlternateKeyCode))
          {
            ++num2;
            string messageTemplate = "결제일자 중복 에러.\n--------------------------------------------------------------------------------------------------\n[" + paymentWork2.pay_Date.GetDateToStr("yyyy-MM-dd") + "]" + paymentWork2.si_StoreName + "|" + paymentWork2.su_SupplierName + "\n" + paymentWork2.pay_StartDate.GetDateToStr("yyyy-MM-dd") + "~" + paymentWork2.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "\n--------------------------------------------------------------------------------------------------";
            if (isMessage)
            {
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage1 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
              jobEvtMessage1.SiteID = pJobInfo.SiteID;
              jobEvtMessage1.Id = pJobInfo.Id;
              jobEvtMessage1.JobId = pJobInfo.JobId;
              jobEvtMessage1.Msg = paymentWork1.TableCode.ToDescription() + "/n" + messageTemplate;
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage2 = jobEvtMessage1;
              paymentWork1._CallBackMessage(jobEvtMessage2.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
            }
            else
              Log.Logger.ErrorColor(messageTemplate);
          }
          else if (paymentWork2.IsConfirm)
          {
            ++num2;
            string messageTemplate = "결제일자 확정\n--------------------------------------------------------------------------------------------------\n[" + paymentWork2.pay_Date.GetDateToStr("yyyy-MM-dd") + "]" + paymentWork2.si_StoreName + "|" + paymentWork2.su_SupplierName + "\n" + paymentWork2.pay_StartDate.GetDateToStr("yyyy-MM-dd") + "~" + paymentWork2.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "\n--------------------------------------------------------------------------------------------------";
            if (isMessage)
            {
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage3 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
              jobEvtMessage3.SiteID = pJobInfo.SiteID;
              jobEvtMessage3.Id = pJobInfo.Id;
              jobEvtMessage3.JobId = pJobInfo.JobId;
              jobEvtMessage3.Msg = paymentWork1.TableCode.ToDescription() + "/n" + messageTemplate;
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage4 = jobEvtMessage3;
              paymentWork1._CallBackMessage(jobEvtMessage4.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
            }
            else
              Log.Logger.ErrorColor(messageTemplate);
          }
          else if (paymentWork2.suh_PayCondition == 9999)
            ++num2;
          else if (paymentWork2.pay_ConfirmAfterCount > 0)
          {
            ++num2;
            string messageTemplate = "결제일자 이후 확정\n--------------------------------------------------------------------------------------------------\n[" + paymentWork2.pay_Date.GetDateToStr("yyyy-MM-dd") + "]" + paymentWork2.si_StoreName + "|" + paymentWork2.su_SupplierName + "\n" + paymentWork2.pay_StartDate.GetDateToStr("yyyy-MM-dd") + "~" + paymentWork2.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "\n--------------------------------------------------------------------------------------------------";
            if (isMessage)
            {
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage5 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
              jobEvtMessage5.SiteID = pJobInfo.SiteID;
              jobEvtMessage5.Id = pJobInfo.Id;
              jobEvtMessage5.JobId = pJobInfo.JobId;
              jobEvtMessage5.Msg = paymentWork1.TableCode.ToDescription() + "/n" + messageTemplate;
              UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage6 = jobEvtMessage5;
              paymentWork1._CallBackMessage(jobEvtMessage6.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
            }
            else
              Log.Logger.ErrorColor(messageTemplate);
          }
          else
          {
            paymentWork2.pay_Type = 1;
            if (paymentWork2.pay_ConfirmStatus == 0)
              paymentWork2.pay_ConfirmStatus = 1;
            if (paymentWork2.pay_StatementStatus == 0)
              paymentWork2.pay_StatementStatus = 2;
            if (paymentWork2.pay_TypeCustom1 == 0)
              paymentWork2.pay_TypeCustom1 = 1;
            if (paymentWork2.pay_TypeCustom2 == 0)
              paymentWork2.pay_TypeCustom2 = 1;
            paymentWork2.CalcEndAmount();
            if (pEmployee != null && pEmployee.emp_Code > 0)
            {
              paymentWork2.pay_InUser = pEmployee.emp_Code;
              paymentWork2.pay_ModUser = pEmployee.emp_Code;
            }
            if (paymentWork2.db_status == 0 && paymentWork2.IsZero(EnumZeroCheck.ALL))
              ++num2;
            else if (paymentWork2.pay_Code > 2999123100000000L)
            {
              ++num2;
              string messageTemplate = "결제일자 중복 에러\n--------------------------------------------------------------------------------------------------\n[" + paymentWork2.pay_Date.GetDateToStr("yyyy-MM-dd") + "]" + paymentWork2.si_StoreName + "|" + paymentWork2.su_SupplierName + "\n" + paymentWork2.pay_StartDate.GetDateToStr("yyyy-MM-dd") + "~" + paymentWork2.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "\n--------------------------------------------------------------------------------------------------";
              if (isMessage)
              {
                UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage7 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
                jobEvtMessage7.SiteID = pJobInfo.SiteID;
                jobEvtMessage7.Id = pJobInfo.Id;
                jobEvtMessage7.JobId = pJobInfo.JobId;
                jobEvtMessage7.Msg = paymentWork1.TableCode.ToDescription() + "/n" + messageTemplate;
                UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage8 = jobEvtMessage7;
                paymentWork1._CallBackMessage(jobEvtMessage8.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
              }
              else
                Log.Logger.ErrorColor(messageTemplate);
            }
            else
            {
              if (!paymentWork2.ItemSave())
                return false;
              ++num1;
              int num3 = num1 % 100;
            }
          }
        }
        int count = paymentWorkList.Count;
        if (isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage9 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage9.SiteID = pJobInfo.SiteID;
          jobEvtMessage9.Id = pJobInfo.Id;
          jobEvtMessage9.JobId = pJobInfo.JobId;
          jobEvtMessage9.Msg = paymentWork1.TableCode.ToDescription() + "\n[" + new DateTime?(pWorkDate).GetDateToStr("yyyy-MM-dd") + "] " + num2.ToString("n0") + "건 SKIP, " + num1.ToString("n0") + "건 등록";
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage10 = jobEvtMessage9;
          paymentWork1._CallBackMessage(jobEvtMessage10.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        else
          Log.Logger.ErrorColor("[" + new DateTime?(pWorkDate).GetDateToStr("yyyy-MM-dd") + "] " + num2.ToString("n0") + "건 SKIP, " + num1.ToString("n0") + "건 등록");
        param = (Hashtable) null;
        return true;
      }
      catch (Exception ex)
      {
        paymentWork1.message = " " + paymentWork1.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        if (isMessage)
        {
          JobEvtMessageErr jobEvtMessageErr1 = new JobEvtMessageErr();
          jobEvtMessageErr1.SiteID = pJobInfo.SiteID;
          jobEvtMessageErr1.Id = pJobInfo.Id;
          jobEvtMessageErr1.JobId = pJobInfo.JobId;
          jobEvtMessageErr1.Msg = paymentWork1.TableCode.ToDescription() + "/n" + ex.Message;
          JobEvtMessageErr jobEvtMessageErr2 = jobEvtMessageErr1;
          paymentWork1._CallBackMessage(jobEvtMessageErr2.ToJson<JobEvtMessageErr>());
        }
        else
          Log.Logger.ErrorColor(paymentWork1.message);
      }
      return false;
    }

    public async Task<IList<PaymentWork>> SelectWorkListAsync(Hashtable pParam)
    {
      PaymentWork paymentWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(paymentWork1.GetSelectQuery((object) pParam)))
        {
          paymentWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentWork>) null;
        }
        IList<PaymentWork> lt_list = (IList<PaymentWork>) new List<PaymentWork>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentWork paymentWork2 = paymentWork1.OleDB.Create<PaymentWork>();
            if (paymentWork2.GetFieldValues(rs))
            {
              paymentWork2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentWork2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async Task<IList<PaymentWork>> SelectDuplicateCheckListAsync(Hashtable pParam)
    {
      PaymentWork paymentWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(paymentWork1.GetDuplicateCheckQuery((object) pParam)))
        {
          paymentWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentWork>) null;
        }
        IList<PaymentWork> lt_list = (IList<PaymentWork>) new List<PaymentWork>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentWork paymentWork2 = paymentWork1.OleDB.Create<PaymentWork>();
            if (paymentWork2.GetDuplicateCheckFieldValues(rs))
            {
              paymentWork2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentWork2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      this.suh_PayCondition = p_rs.GetFieldInt("suh_PayCondition");
      this.db_status = p_rs.GetFieldInt("db_status");
      this.PaymentStoreSuplierDate = string.Format("{0}|{1}|{2}", (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_Date.GetDateToStr("yyyy-MM-dd"));
      return true;
    }

    public bool GetDuplicateCheckFieldValues(UniOleDbRecordset p_rs)
    {
      this.pay_Date = p_rs.GetFieldDateTime("pay_Date");
      this.pay_SiteID = p_rs.GetFieldLong("pay_SiteID");
      this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
      this.pay_Supplier = p_rs.GetFieldInt("pay_Supplier");
      this.pay_SupplierType = p_rs.GetFieldInt("pay_SupplierType");
      this.pay_Type = p_rs.GetFieldInt("pay_Type");
      this.pay_StartDate = p_rs.GetFieldDateTime("pay_StartDate");
      this.pay_EndDate = p_rs.GetFieldDateTime("pay_EndDate");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.suh_PayCondition = p_rs.GetFieldInt("suh_PayCondition");
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
        DateTime? nullable1 = new DateTime?();
        DateTime? nullable2 = new DateTime?();
        DateTime? nullable3 = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Date") && hashtable2[(object) "pay_Date"].ToString().Length > 0)
            nullable1 = new DateTime?((DateTime) hashtable2[(object) "pay_Date"]);
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate") && Convert.ToInt32(hashtable2[(object) "sh_ConfirmDate"].ToString()) > 0)
            nullable2 = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate"]);
          if (hashtable2.ContainsKey((object) "_DT_BASE_") && Convert.ToInt32(hashtable2[(object) "_DT_BASE_"].ToString()) > 0)
            nullable3 = new DateTime?((DateTime) hashtable2[(object) "_DT_BASE_"]);
        }
        if (!nullable3.HasValue && nullable1.HasValue)
          nullable3 = nullable1;
        if (!nullable3.HasValue && !nullable1.HasValue && !nullable2.HasValue)
        {
          Exception exception = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (nullable2.HasValue)
          stringBuilder.Append(this.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable2.Value));
        else if (nullable3.HasValue)
          stringBuilder.Append(this.ToWithPayContionPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable3.Value));
        stringBuilder.Append(this.ToWithSupplierHistoryQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentExistQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentDateAfterConfirmQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentAfterStatementQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentMonthQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithMonthInitStatementBuyQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithMonthInitSalesLeaChargeRateNotZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithMonthInitSalesLeaChargeRateZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithMonthInitPaymetDetailQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithStatementBuyQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithSalesLeaChargeRateNotZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithSalesLeaChargeRateZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithStatementReturnQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithSalesQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(this.ToWithPaymentQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append("\nSELECT\nSELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,su_SupplierType AS pay_SupplierType" + string.Format(",{0} AS {1},suph_dt_start AS {2},suph_dt_end AS {3}", (object) 1, (object) "pay_Type", (object) "pay_StartDate", (object) "pay_EndDate") + ",suh_PayMethod AS pay_PayMethod,payc_Round AS pay_Round,payc_Turn AS pay_Turn" + string.Format(",{0}", (object) this.suh_PayCondition));
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

    public string GetDuplicateCheckQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        DateTime? nullable1 = new DateTime?();
        DateTime? nullable2 = new DateTime?();
        DateTime? nullable3 = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "pay_StoreCode"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "pay_Supplier"].ToString());
          if (hashtable2.ContainsKey((object) "pay_Date") && Convert.ToInt32(hashtable2[(object) "pay_Date"].ToString()) > 0)
            nullable1 = new DateTime?((DateTime) hashtable2[(object) "pay_Date"]);
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate") && Convert.ToInt32(hashtable2[(object) "sh_ConfirmDate"].ToString()) > 0)
            nullable2 = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate"]);
          if (hashtable2.ContainsKey((object) "_DT_BASE_") && Convert.ToInt32(hashtable2[(object) "_DT_BASE_"].ToString()) > 0)
            nullable3 = new DateTime?((DateTime) hashtable2[(object) "_DT_BASE_"]);
        }
        if (!nullable3.HasValue && nullable1.HasValue)
          nullable3 = nullable1;
        if (!nullable3.HasValue && !nullable1.HasValue && !nullable2.HasValue)
        {
          Exception exception = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (nullable2.HasValue)
          stringBuilder.Append(this.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable2.Value));
        else if (nullable3.HasValue)
          stringBuilder.Append(this.ToWithPayContionPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable3.Value));
        stringBuilder.Append(this.ToWithSupplierHistoryQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append("\nSELECT pc_pay_day AS pay_Date,suh_SiteID AS pay_SiteID,suh_StoreCode AS pay_StoreCode,suh_Supplier AS pay_Supplier,suph_su_SupplierType AS pay_SupplierType,1 AS pay_Type,suph_dt_start AS pay_StartDate,suph_dt_end AS pay_EndDate,si_StoreName,si_StoreViewCode,si_LocationUseYn,si_UseYn,su_SupplierViewCode,su_SupplierName,T_SUPPLIER.su_SupplierType AS su_SupplierType,su_UseYn,suh_PayCondition\nFROM T_SUPPLIER_HISTORY\nINNER JOIN T_STORE ON suh_StoreCode=si_StoreCode AND suh_SiteID=si_SiteID\nINNER JOIN T_SUPPLIER ON suh_Supplier=su_Supplier AND suh_SiteID=su_SiteID");
        stringBuilder.Append("\nORDER BY suh_StoreCode,suh_Supplier,pc_pay_day,suph_dt_start,suph_dt_end");
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

    public string ToPaymentWhereAnd(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param.ContainsKey((object) "pay_Code") && Convert.ToInt64(p_param[(object) "pay_Code"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Code", p_param[(object) "pay_Code"]));
      if (p_param.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(p_param[(object) "pay_SiteID"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) Convert.ToInt64(p_param[(object) "pay_SiteID"].ToString())));
      if (p_param.ContainsKey((object) "pay_Date"))
      {
        stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pay_Date_BEGIN_") && p_param.ContainsKey((object) "pay_Date_END_"))
      {
        stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) p_param[(object) "pay_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) p_param[(object) "pay_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(p_param[(object) "si_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "si_StoreCode"]));
      else if (p_param.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode"]));
      else if (p_param.ContainsKey((object) "si_StoreCode_IN_") && p_param[(object) "si_StoreCode_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "si_StoreCode_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
      }
      else if (p_param.ContainsKey((object) "pay_StoreCode_IN_") && p_param[(object) "pay_StoreCode_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode_IN_"]));
      else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
      if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier"]));
      else if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "pay_Supplier"]));
      else if (p_param.ContainsKey((object) "su_Supplier_IN_") && p_param[(object) "su_Supplier_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      else if (p_param.ContainsKey((object) "pay_Supplier_IN_") && p_param[(object) "pay_Supplier_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "pay_Supplier_IN_"]));
      else if (p_param.ContainsKey((object) "_SUPPLIER_AUTHS_") && p_param[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      if (p_param.ContainsKey((object) "pay_ConfirmStatus") && Convert.ToInt32(p_param[(object) "pay_ConfirmStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus"]));
      else if (p_param.ContainsKey((object) "pay_ConfirmStatus_IN_") && p_param[(object) "pay_ConfirmStatus_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "pay_ConfirmStatus_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus_IN_"]));
      }
      if (p_param.ContainsKey((object) "pay_StatementStatus") && Convert.ToInt32(p_param[(object) "pay_StatementStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus"]));
      else if (p_param.ContainsKey((object) "pay_StatementStatus_IN_") && p_param[(object) "pay_StatementStatus_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "pay_StatementStatus_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus_IN_"]));
      }
      if (p_param.ContainsKey((object) "pd_ConfirmDate"))
      {
        stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pd_ConfirmDate_BEGIN_") && p_param.ContainsKey((object) "pd_ConfirmDate_END_"))
      {
        stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pd_ConfirmStatus") && Convert.ToInt32(p_param[(object) "pd_ConfirmStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_ConfirmStatus", p_param[(object) "pd_ConfirmStatus"]));
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public string ToWithPaymentExistQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT_EXIST AS (SELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_PayMethod,pay_Round,pay_Turn,pay_ConfirmStatus,pay_StatementStatus,pay_TypeCustom1,pay_TypeCustom2,0 AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount,0 AS pay_ConfirmAfterCount, 0 AS pay_StatementConfirmAfterCount" + string.Format(",{0} AS {1}", (object) 2, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND pay_Date=pc_pay_day AND pay_StoreCode=suh_StoreCode AND pay_Supplier=suh_Supplier");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "pay_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pay_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPaymentDateAfterConfirmQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT_DATE_AFTER_CONFIRM AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 1, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND pay_Date=pc_pay_day AND pay_StoreCode=suh_StoreCode AND pay_Supplier=suh_Supplier");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date"))
            p_param1.Add((object) "pay_Date_OUTER_NEXT_", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "pay_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pay_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pay_ConfirmStatus"))
            p_param1.Add((object) "pay_ConfirmStatus", (object) 2);
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
            stringBuilder.Append(" AND pay_Date>pc_pay_day");
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPaymentAfterStatementQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT_DATE_AFTER_STATEMENT AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 1, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND pay_Date=pc_pay_day AND pay_StoreCode=suh_StoreCode AND pay_Supplier=suh_Supplier");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date"))
            p_param1.Add((object) "pay_Date_OUTER_NEXT_", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "pay_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pay_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pay_ConfirmStatus"))
            p_param1.Add((object) "pay_StatementStatus", (object) 1);
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
            stringBuilder.Append(" AND pay_Date>pc_pay_day");
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPaymentMonthQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT_MONTH AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,paym_StoreCode AS pay_StoreCode,paym_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,paym_BaseAmount AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentMonth, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND paym_YyyyMm=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND paym_StoreCode=suh_StoreCode AND paym_Supplier=suh_Supplier");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "paym_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add((object) "paym_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "paym_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "paym_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "paym_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "paym_SiteID"))
            p_param1.Add((object) "paym_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithMonthInitStatementBuyQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_MONTH_INIT_STATEMENT_BUY AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sh_StoreCode AS pay_StoreCode,sh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,SUM((sh_CostTaxAmt+sh_CostVatAmt+sh_CostTaxFreeAmt+sh_Deposit)*sh_InOutDiv) AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sh_SiteID=suh_SiteID AND " + "sh_ConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND sh_ConfirmDate<suph_dt_start AND sh_StoreCode=suh_StoreCode AND sh_Supplier=suh_Supplier");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sh_SiteID,sh_StoreCode,sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithMonthInitSalesLeaChargeRateNotZeroQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_MONTH_INIT_SALES_LEA_CHARGE_NOT_ZERO AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,SUM((sbd_SaleAmt*gdh_ChargeRate/100) AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sbd_SiteID=suh_SiteID AND " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND sbd_SaleDate<suph_dt_start AND sbd_StoreCode=suh_StoreCode" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SiteID=gdh_SiteID AND sbd_SaleDate<=gdh_EndDate AND gdh_ChargeRate!=0");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "pay_Supplier"]));
          if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "su_Supplier"]));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sbd_SiteID,sbd_StoreCode,gdh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithMonthInitSalesLeaChargeRateZeroQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_MONTH_INIT_SALES_LEA_CHARGE_ZERO AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,SUM(CASE WHEN gdh_EventCost>0 THEN gdh_EventCost+gdh_EventVat ELSE gdh_BuyCost+gdh_BuyVat END * sbd_SaleQty) AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sbd_SiteID=suh_SiteID AND " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND sbd_SaleDate<suph_dt_start AND sbd_StoreCode=suh_StoreCode" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SiteID=gdh_SiteID AND sbd_SaleDate<=gdh_EndDate AND gdh_ChargeRate==0");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "pay_Supplier"]));
          if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "su_Supplier"]));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sbd_SiteID,sbd_StoreCode,gdh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithMonthInitPaymetDetailQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_MONTH_INIT_PAYMENT_DETAIL AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,pay_StoreCode AS pay_StoreCode,pay_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,SUM((pd_Amount*pd_InOutDiv*-1) AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentDetail, (object) DbQueryHelper.ToWithNolock()) + " ON pay_Code=pd_PaymentID AND pay_SiteID=pd_SiteID\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND pay_Supplier=suh_Supplier AND pay_StoreCode=suh_StoreCode AND " + "pd_ConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND pd_ConfirmDate<suph_dt_start");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "pay_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "pay_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pd_ConfirmStatus"))
            p_param1.Add((object) "pd_ConfirmStatus", (object) 1);
          stringBuilder.Append(this.ToPaymentWhereAnd(p_param1));
          stringBuilder.Append(" AND pc_pay_day!=pay_Date");
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY pc_pay_day,pay_StoreCode,pay_Supplier,pay_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithStatementBuyQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STATEMENT_BUY AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sh_StoreCode AS pay_StoreCode,sh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,SUM(sh_CostTaxAmt+sh_CostVatAmt+sh_CostTaxFreeAmt) AS pay_BuyAmount,SUM(sh_CostTaxAmt) AS pay_BuyTax,SUM(sh_CostVatAmt) AS pay_BuyVat,SUM(sh_CostTaxFreeAmt) AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,SUM(sh_Deposit) AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sh_SiteID=suh_SiteID AND sh_ConfirmDate>=suph_dt_start AND sh_ConfirmDate<=suph_dt_end AND sh_StoreCode=suh_StoreCode AND sh_Supplier=suh_Supplier");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          p_param1.Add((object) "sh_StatementType", (object) 1);
          p_param1.Add((object) "sh_InOutDiv", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sh_SiteID,sh_StoreCode,sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSalesLeaChargeRateNotZeroQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SALES_LEA_CHARGE_NOT_ZERO AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,SUM((sbd_SaleAmt*gdh_ChargeRate/100) AS pay_BuyAmount" + string.Format(",SUM(CASE WHEN {0}={1} THEN {2}-{3} ELSE 0 END * {4}/100) AS {5}", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleAmt", (object) "sbd_SaleVatAmt", (object) "gdh_ChargeRate", (object) "pay_BuyTax") + ",SUM((sbd_SaleVatAmt*gdh_ChargeRate/100) AS pay_BuyVat" + string.Format(",SUM(CASE WHEN {0}!={1} THEN {2} ELSE 0 END * {3}/100) AS {4}", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleAmt", (object) "gdh_ChargeRate", (object) "pay_BuyFree") + ",0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sbd_SiteID=suh_SiteID AND sbd_SaleDate>=suph_dt_start AND sbd_SaleDate<=suph_dt_end AND sbd_StoreCode=suh_StoreCode" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SiteID=gdh_SiteID AND sbd_SaleDate<=gdh_EndDate AND gdh_ChargeRate!=0");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "pay_Supplier"]));
          if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "su_Supplier"]));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sbd_SiteID,sbd_StoreCode,gdh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSalesLeaChargeRateZeroQuery(
      Hashtable p_param,
      string p_dbms,
      long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SALES_LEA_CHARGE_ZERO AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,SUM(CASE WHEN gdh_EventCost>0 THEN gdh_EventCost+gdh_EventVat ELSE gdh_BuyCost+gdh_BuyVat END * sbd_SaleQty) AS pay_BuyAmount" + string.Format(",SUM(CASE WHEN {0}={1} THEN ", (object) "sbd_TaxDiv", (object) 1) + " CASE WHEN gdh_EventCost>0 THEN gdh_EventCost ELSE gdh_BuyCost END ELSE 0 END * sbd_SaleQty) AS pay_BuyTax" + string.Format(",SUM(CASE WHEN {0}={1} THEN ", (object) "sbd_TaxDiv", (object) 1) + " CASE WHEN gdh_EventVat>0 THEN gdh_EventVat ELSE gdh_BuyVat END ELSE 0 END * sbd_SaleQty) AS pay_BuyVat" + string.Format(",SUM(CASE WHEN {0}!={1} THEN ", (object) "sbd_TaxDiv", (object) 1) + " CASE WHEN gdh_EventCost>0 THEN gdh_EventCost ELSE gdh_BuyCost END ELSE 0 END * sbd_SaleQty) AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sbd_SiteID=suh_SiteID AND " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "=" + "suph_dt_start".DateToStr(EnumDbDateType.YYYYMM).ToInt() + " AND sbd_SaleDate<suph_dt_start AND sbd_StoreCode=suh_StoreCode" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SiteID=gdh_SiteID AND sbd_SaleDate<=gdh_EndDate AND gdh_ChargeRate=0");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "pay_Supplier"]));
          if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "su_Supplier"]));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sbd_SiteID,sbd_StoreCode,gdh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithStatementReturnQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_STATEMENT_RETURN AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sh_StoreCode AS pay_StoreCode,sh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,SUM(sh_CostTaxAmt+sh_CostVatAmt+sh_CostTaxFreeAmt) AS pay_BuyReturnAmount,SUM(sh_CostTaxAmt) AS pay_BuyReturnTax,SUM(sh_CostVatAmt) AS pay_BuyReturnVat,SUM(sh_CostTaxFreeAmt) AS pay_BuyReturnFree,SUM(sh_Deposit) AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sh_SiteID=suh_SiteID AND sh_ConfirmDate>=suph_dt_start AND sh_ConfirmDate<=suph_dt_end AND sh_StoreCode=suh_StoreCode AND sh_Supplier=suh_Supplier");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          p_param1.Add((object) "sh_StatementType", (object) 1);
          p_param1.Add((object) "sh_InOutDiv", (object) -1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sh_SiteID,sh_StoreCode,sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSalesQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SALES AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,0 AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,SUM(sbd_SaleAmt) AS pay_SaleAmount" + string.Format(",SUM(CASE WHEN {0}={1} THEN {2}-{3} ELSE 0 END) AS {4}", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleAmt", (object) "sbd_SaleVatAmt", (object) "pay_SaleTax") + ",SUM((sbd_SaleVatAmt) AS pay_SaleVat" + string.Format(",SUM(CASE WHEN {0}!={1} THEN {2} ELSE 0 END) AS {3}", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleAmt", (object) "pay_SaleFree") + ",0 AS pay_DeductionAmount,0 AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON sbd_SiteID=suh_SiteID AND sbd_SaleDate>=suph_dt_start AND sbd_SaleDate<=suph_dt_end AND sbd_StoreCode=suh_StoreCode" + string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SiteID=gdh_SiteID AND sbd_SaleDate<=gdh_EndDate");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "pay_Supplier"]));
          if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", p_param[(object) "su_Supplier"]));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append(" GROUP BY pc_pay_day,sbd_SiteID,sbd_StoreCode,gdh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPaymentQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_PAYMENT_STATEMENT AS (" + string.Format("SELECT 0 AS {0},{1} AS {2}", (object) "pay_Code", (object) p_SiteID, (object) "pay_SiteID") + ",pc_pay_day AS pay_Date,paym_StoreCode AS pay_StoreCode,paym_Supplier AS pay_Supplier,0 AS pay_SupplierType,0 AS pay_Type,0 AS pay_PayMethod,0 AS pay_Round,0 AS pay_Turn,0 AS pay_ConfirmStatus,0 AS pay_StatementStatus,0 AS pay_TypeCustom1,0 AS pay_TypeCustom2,paym_BaseAmount AS pay_BaseAmount,0 AS pay_BuyAmount,0 AS pay_BuyTax,0 AS pay_BuyVat,0 AS pay_BuyFree,0 AS pay_BuyReturnAmount,0 AS pay_BuyReturnTax,0 AS pay_BuyReturnVat,0 AS pay_BuyReturnFree,0 AS pay_Deposit,0 AS pay_SaleAmount,0 AS pay_SaleTax,0 AS pay_SaleVat,0 AS pay_SaleFree,SUM(pd_DeductAmount) AS pay_DeductionAmount,SUM(pd_PayAmount) AS pay_PayAmount,0 AS pay_AddAmount,0 AS pay_EndAmount" + string.Format(",{0} AS {1}, {2} AS {3}", (object) 0, (object) "pay_ConfirmAfterCount", (object) 0, (object) "pay_StatementConfirmAfterCount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentDetail, (object) DbQueryHelper.ToWithNolock()) + " ON pay_Code=pd_PaymentID AND pay_SiteID=pd_SiteID" + string.Format(" AND {0}={1}", (object) "pd_ConfirmStatus", (object) 1) + "\nINNER JOIN T_SUPPLIER_HISTORY ON pay_SiteID=suh_SiteID AND pay_StoreCode=suh_StoreCode AND pay_Supplier=suh_Supplier AND pay_Date=pc_pay_day");
        foreach (DictionaryEntry dictionaryEntry in p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "paym_SiteID", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_Supplier") && dictionaryEntry.Key.ToString().Equals("pay_Supplier"))
            p_param1.Add((object) "paym_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_Supplier") && dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "paym_Supplier", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "paym_StoreCode", dictionaryEntry.Value);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "paym_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "paym_SiteID"))
            p_param1.Add((object) "paym_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
          if (!p_param1.ContainsKey((object) "pay_Date"))
          {
            string dateToStr = new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
            stringBuilder.Append(" AND pc_pay_day>=" + dateToStr);
            stringBuilder.Append(" AND pc_pay_day<=" + dateToStr);
          }
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY pc_pay_day,pay_SiteID,pay_StoreCode,pay_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public void JobWorkMessage(string pMessage)
    {
      if (this._CallBackMessage == null)
        return;
      this._CallBackMessage(pMessage);
    }
  }
}
