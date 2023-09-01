// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentDetailAutoDeductionView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentDetailAutoDeductionView : PaymentDetailView<PaymentDetailAutoDeductionView>
  {
    private TSupplierAutoDeduction _AutoDeductionInfo;
    private double _pd_BuyAmount;
    private double _pd_BuyVatAmount;
    private double _pd_SaleAmount;
    private double _pd_SaleVatAmount;
    private double _pd_SalePayCash;
    private double _pd_SalePayCard;
    private Action<string> _CallBackMessage;

    public string AlternateKeyCode => string.Format("{0}|{1}", (object) this.pay_StoreCode, (object) this.pay_Supplier) + string.Format("|{0}|{1}|{2}", (object) this.pd_ConfirmDate.Value.ToIntFormat(), (object) this.pd_WriteType, (object) this.pd_ReasonType);

    public override int pay_StoreCode
    {
      get => this._pay_StoreCode;
      set
      {
        this._pay_StoreCode = value;
        this.Changed(nameof (pay_StoreCode));
        this.Changed("AlternateKeyCode");
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
      }
    }

    public override DateTime? pd_ConfirmDate
    {
      get => this._pd_ConfirmDate;
      set
      {
        this._pd_ConfirmDate = value;
        this.Changed(nameof (pd_ConfirmDate));
        this.Changed("AlternateKeyCode");
      }
    }

    public override int pd_WriteType
    {
      get => this._pd_WriteType;
      set
      {
        this._pd_WriteType = value;
        this.Changed(nameof (pd_WriteType));
        this.Changed("pd_WriteTypeDesc");
        this.Changed("pd_IsWriteTypeAuto");
        this.Changed("AlternateKeyCode");
      }
    }

    public override int pd_ReasonType
    {
      get => this._pd_ReasonType;
      set
      {
        this._pd_ReasonType = value;
        this.Changed(nameof (pd_ReasonType));
        this.Changed("pd_ReasonTypeDesc");
        this.Changed("AlternateKeyCode");
      }
    }

    public TSupplierAutoDeduction AutoDeductionInfo
    {
      get => this._AutoDeductionInfo ?? (this._AutoDeductionInfo = new TSupplierAutoDeduction());
      set
      {
        this._AutoDeductionInfo = value;
        this.Changed(nameof (AutoDeductionInfo));
      }
    }

    public double pd_BuyAmount
    {
      get => this._pd_BuyAmount;
      set
      {
        this._pd_BuyAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_BuyAmount));
      }
    }

    public double pd_BuyVatAmount
    {
      get => this._pd_BuyVatAmount;
      set
      {
        this._pd_BuyVatAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_BuyVatAmount));
      }
    }

    public double pd_SaleAmount
    {
      get => this._pd_SaleAmount;
      set
      {
        this._pd_SaleAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_SaleAmount));
      }
    }

    public double pd_SaleVatAmount
    {
      get => this._pd_SaleVatAmount;
      set
      {
        this._pd_SaleVatAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_SaleVatAmount));
      }
    }

    public double pd_SalePayCash
    {
      get => this._pd_SalePayCash;
      set
      {
        this._pd_SalePayCash = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_SalePayCash));
      }
    }

    public double pd_SalePayCard
    {
      get => this._pd_SalePayCard;
      set
      {
        this._pd_SalePayCard = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_SalePayCard));
      }
    }

    public PaymentDetailAutoDeductionView()
    {
    }

    public PaymentDetailAutoDeductionView(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.AutoDeductionInfo = (TSupplierAutoDeduction) null;
      this.pd_BuyAmount = this.pd_BuyVatAmount = this.pd_SaleAmount = this.pd_SaleVatAmount = this.pd_SalePayCash = this.pd_SalePayCard = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PaymentDetailAutoDeductionView();

    public override object Clone()
    {
      PaymentDetailAutoDeductionView autoDeductionView = base.Clone() as PaymentDetailAutoDeductionView;
      autoDeductionView.pd_BuyAmount = this.pd_BuyAmount;
      autoDeductionView.pd_BuyVatAmount = this.pd_BuyVatAmount;
      autoDeductionView.pd_SaleAmount = this.pd_SaleAmount;
      autoDeductionView.pd_SaleVatAmount = this.pd_SaleVatAmount;
      autoDeductionView.pd_SalePayCash = this.pd_SalePayCash;
      autoDeductionView.pd_SalePayCard = this.pd_SalePayCard;
      autoDeductionView.AutoDeductionInfo = (TSupplierAutoDeduction) null;
      if (this.AutoDeductionInfo.suad_Seq > 0)
        autoDeductionView.AutoDeductionInfo.PutData(this.AutoDeductionInfo);
      return (object) autoDeductionView;
    }

    public void PutData(PaymentDetailAutoDeductionView pSource)
    {
      this.PutData((PaymentDetailView) pSource);
      this.pd_BuyAmount = pSource.pd_BuyAmount;
      this.pd_BuyVatAmount = pSource.pd_BuyVatAmount;
      this.pd_SaleAmount = pSource.pd_SaleAmount;
      this.pd_SaleVatAmount = pSource.pd_SaleVatAmount;
      this.pd_SalePayCash = pSource.pd_SalePayCash;
      this.pd_SalePayCard = pSource.pd_SalePayCard;
      this.AutoDeductionInfo = (TSupplierAutoDeduction) null;
      if (pSource.AutoDeductionInfo.suad_Seq <= 0)
        return;
      this.AutoDeductionInfo.PutData(pSource.AutoDeductionInfo);
    }

    public bool IsAutoDeductionZero(PaymentDetailAutoDeductionView pSource) => pSource == null || pSource.pd_BuyAmount.IsZero() && pSource.pd_BuyVatAmount.IsZero() && pSource.pd_SaleAmount.IsZero() && pSource.pd_SaleVatAmount.IsZero() && pSource.pd_SalePayCash.IsZero() && pSource.pd_SalePayCard.IsZero();

    public bool IsAutoDeductionZero() => this.IsAutoDeductionZero(this);

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      DateTime pWorkDate,
      int pStoreCode,
      string pStoreCodeIn,
      int pSupplier,
      bool pIsDayWork,
      EmployeeView pEmployee)
    {
      PaymentDetailAutoDeductionView autoDeductionView = this;
      bool isMessage = autoDeductionView._CallBackMessage != null && pJobInfo != null;
      try
      {
        if (pJobInfo.SiteID != 0L && autoDeductionView.pd_SiteID == 0L)
          autoDeductionView.pd_SiteID = pJobInfo.SiteID;
        if (autoDeductionView.pd_SiteID == 0L)
          throw new Exception("사이트 ID 정보 오류.");
        if (string.IsNullOrEmpty(pStoreCodeIn) && pStoreCode == 0)
          throw new Exception("지점정보 오류.");
        Hashtable param = new Hashtable();
        param.Add((object) "pay_SiteID", (object) autoDeductionView.pd_SiteID);
        if (pStoreCode > 0)
          param.Add((object) "pay_StoreCode", (object) pStoreCode);
        if (pSupplier > 0)
          param.Add((object) "pay_Supplier", (object) pSupplier);
        param.Add((object) "pay_Date", (object) pWorkDate);
        if (pIsDayWork)
          param.Add((object) "_DT_BASE_", (object) pWorkDate);
        IList<PaymentWork> list_header = await autoDeductionView.OleDB.Create<PaymentWork>().SelectWorkListAsync(param);
        PaymentWorkByAlternateKeyDic headerDic = new PaymentWorkByAlternateKeyDic();
        headerDic.AddRangeOriginAutoDeduction(list_header);
        IList<PaymentDetailAutoDeductionView> list_detail = await autoDeductionView.OleDB.Create<PaymentDetailAutoDeductionView>().SelectDetailListAsync(param);
        PaymentDetailAutoDeductionByAlternateKeyDic detail_input_AutoDeductionDic = new PaymentDetailAutoDeductionByAlternateKeyDic();
        detail_input_AutoDeductionDic.AddRangeOrigin((IList<PaymentDetailAutoDeductionView>) list_detail.Where<PaymentDetailAutoDeductionView>((Func<PaymentDetailAutoDeductionView, bool>) (it => it.pd_IsWriteTypeAuto)).ToList<PaymentDetailAutoDeductionView>());
        IList<PaymentDetailAutoDeductionView> list_WorkData = await autoDeductionView.OleDB.Create<PaymentDetailAutoDeductionView>().SelectWorkApplyListAsync(param);
        int n_count = 0;
        PaymentWork paymentWork1 = (PaymentWork) null;
        foreach (PaymentDetailAutoDeductionView pSource in (IEnumerable<PaymentDetailAutoDeductionView>) list_WorkData)
        {
          object[] objArray = new object[4]
          {
            (object) pSource.pay_StoreCode,
            (object) pSource.pay_Supplier,
            null,
            null
          };
          DateTime? nullable = pSource.pay_Date;
          objArray[2] = (object) nullable.Value.ToIntFormat();
          nullable = pSource.pd_ConfirmDate;
          objArray[3] = (object) nullable.Value.ToIntFormat();
          string pKey = string.Format("{0}|{1}|{2}|{3}", objArray);
          if (!headerDic.ContainsKey(pKey))
          {
            paymentWork1 = (PaymentWork) null;
            if (!pSource.IsAutoDeductionZero())
              Log.Logger.ErrorColor("\n Header ID[" + pKey + "] IS NULL.");
          }
          else
          {
            PaymentWork paymentWork2 = headerDic[pKey];
            if (paymentWork2 == null)
              Log.Logger.ErrorColor("\n Header ID[" + pKey + "] IS NULL.");
            else if (pSource.AutoDeductionInfo.suad_Seq == 0)
            {
              Log.Logger.ErrorColor("\n 업체 공제 데이터 정보 IS NULL.");
            }
            else
            {
              double num = 0.0;
              bool flag = false;
              switch (Enum2StrConverter.ToDeductionAutoType(pSource.AutoDeductionInfo.suad_Seq))
              {
                case EnumDeductionAutoType.REBATE_DOWN:
                  switch (Enum2StrConverter.ToStdPreTax(pSource.AutoDeductionInfo.suad_StdPriceType))
                  {
                    case EnumStdPreTax.TAX:
                      num = pSource.pd_BuyAmount + pSource.pd_BuyVatAmount;
                      break;
                    case EnumStdPreTax.PRE_TAX:
                      num = pSource.pd_BuyAmount;
                      break;
                  }
                  if (num < pSource.AutoDeductionInfo.suad_StdValue)
                  {
                    pSource.pd_ConfirmStatus = 1;
                    pSource.pd_StatementType = 2;
                    pSource.pd_ReasonType = pSource.AutoDeductionInfo.suad_Seq;
                    pSource.pd_WriteType = 1;
                    switch (Enum2StrConverter.ToDeductionAutoCalc(pSource.AutoDeductionInfo.suad_CalcType))
                    {
                      case EnumDeductionAutoCalc.RATE:
                        if (num >= 0.0)
                        {
                          pSource.pd_Memo = string.Format("비율={0:F2}%", (object) pSource.AutoDeductionInfo.suad_Value);
                          pSource.pd_Amount = num * pSource.AutoDeductionInfo.suad_Value / 100.0;
                          pSource.pd_DeductAmount = pSource.pd_Amount;
                        }
                        else
                        {
                          pSource.pd_Amount = 0.0;
                          pSource.pd_DeductAmount = 0.0;
                        }
                        flag = true;
                        break;
                      case EnumDeductionAutoCalc.AMOUNT:
                        if (num >= 0.0)
                        {
                          pSource.pd_Amount = pSource.AutoDeductionInfo.suad_Value;
                          pSource.pd_DeductAmount = pSource.pd_Amount;
                        }
                        else
                        {
                          pSource.pd_Amount = 0.0;
                          pSource.pd_DeductAmount = 0.0;
                        }
                        flag = true;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case EnumDeductionAutoType.REBATE_UP:
                  switch (Enum2StrConverter.ToStdPreTax(pSource.AutoDeductionInfo.suad_StdPriceType))
                  {
                    case EnumStdPreTax.TAX:
                      num = pSource.pd_BuyAmount + pSource.pd_BuyVatAmount;
                      break;
                    case EnumStdPreTax.PRE_TAX:
                      num = pSource.pd_BuyAmount;
                      break;
                  }
                  if (num >= pSource.AutoDeductionInfo.suad_StdValue)
                  {
                    pSource.pd_ConfirmStatus = 1;
                    pSource.pd_StatementType = 2;
                    pSource.pd_ReasonType = pSource.AutoDeductionInfo.suad_Seq;
                    pSource.pd_WriteType = 1;
                    switch (Enum2StrConverter.ToDeductionAutoCalc(pSource.AutoDeductionInfo.suad_CalcType))
                    {
                      case EnumDeductionAutoCalc.RATE:
                        pSource.pd_Memo = string.Format("비율={0:F2}%", (object) pSource.AutoDeductionInfo.suad_Value);
                        pSource.pd_Amount = num * pSource.AutoDeductionInfo.suad_Value / 100.0;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                      case EnumDeductionAutoCalc.AMOUNT:
                        pSource.pd_Amount = pSource.AutoDeductionInfo.suad_Value;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case EnumDeductionAutoType.REBATE_PERFORMANCE:
                  switch (Enum2StrConverter.ToStdPreTax(pSource.AutoDeductionInfo.suad_StdPriceType))
                  {
                    case EnumStdPreTax.TAX:
                      num = pSource.pd_BuyAmount + pSource.pd_BuyVatAmount;
                      break;
                    case EnumStdPreTax.PRE_TAX:
                      num = pSource.pd_BuyAmount;
                      break;
                  }
                  if (num >= pSource.AutoDeductionInfo.suad_StdValue)
                  {
                    pSource.pd_ConfirmStatus = 1;
                    pSource.pd_StatementType = 2;
                    pSource.pd_ReasonType = pSource.AutoDeductionInfo.suad_Seq;
                    pSource.pd_WriteType = 1;
                    switch (Enum2StrConverter.ToDeductionAutoCalc(pSource.AutoDeductionInfo.suad_CalcType))
                    {
                      case EnumDeductionAutoCalc.RATE:
                        pSource.pd_Memo = string.Format("비율={0:F2}%", (object) pSource.AutoDeductionInfo.suad_Value);
                        pSource.pd_Amount = num * pSource.AutoDeductionInfo.suad_Value / 100.0;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                      case EnumDeductionAutoCalc.AMOUNT:
                        pSource.pd_Amount = pSource.AutoDeductionInfo.suad_Value;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                    }
                  }
                  else
                    break;
                  break;
                case EnumDeductionAutoType.RENT_AMOUNT:
                  if (paymentWork2.pay_Turn == 1 && Enum2StrConverter.ToDeductionAutoCalc(pSource.AutoDeductionInfo.suad_CalcType) == EnumDeductionAutoCalc.AMOUNT)
                  {
                    pSource.pd_ConfirmStatus = 1;
                    pSource.pd_StatementType = 2;
                    pSource.pd_ReasonType = pSource.AutoDeductionInfo.suad_Seq;
                    pSource.pd_WriteType = 1;
                    pSource.pd_Amount = pSource.AutoDeductionInfo.suad_Value;
                    pSource.pd_DeductAmount = pSource.pd_Amount;
                    flag = true;
                    break;
                  }
                  break;
                case EnumDeductionAutoType.CARD:
                  double pdSalePayCard = pSource.pd_SalePayCard;
                  if (pdSalePayCard >= pSource.AutoDeductionInfo.suad_StdValue)
                  {
                    pSource.pd_ConfirmStatus = 1;
                    pSource.pd_StatementType = 2;
                    pSource.pd_ReasonType = pSource.AutoDeductionInfo.suad_Seq;
                    pSource.pd_WriteType = 1;
                    switch (Enum2StrConverter.ToDeductionAutoCalc(pSource.AutoDeductionInfo.suad_CalcType))
                    {
                      case EnumDeductionAutoCalc.RATE:
                        pSource.pd_Memo = string.Format("비율={0:F2}%", (object) pSource.AutoDeductionInfo.suad_Value);
                        pSource.pd_Amount = pdSalePayCard * pSource.AutoDeductionInfo.suad_Value / 100.0;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                      case EnumDeductionAutoCalc.AMOUNT:
                        pSource.pd_Amount = pSource.AutoDeductionInfo.suad_Value;
                        pSource.pd_DeductAmount = pSource.pd_Amount;
                        flag = true;
                        break;
                    }
                  }
                  else
                    break;
                  break;
              }
              if (flag)
              {
                if (!detail_input_AutoDeductionDic.ContainsKey(pSource.AlternateKeyCode))
                {
                  if (!pSource.pd_Amount.IsZero())
                  {
                    pSource.db_status = 1;
                    paymentWork2.Lt_Details.Add((PaymentDetailView) pSource);
                    paymentWork2.db_status = 4;
                  }
                }
                else if (pSource.pd_Amount.IsEqual(detail_input_AutoDeductionDic[pSource.AlternateKeyCode].pd_Amount))
                {
                  detail_input_AutoDeductionDic[pSource.AlternateKeyCode].db_status = 4;
                  paymentWork2.db_status = 4;
                }
                else
                {
                  long pdPaymentId = detail_input_AutoDeductionDic[pSource.AlternateKeyCode].pd_PaymentID;
                  int pdSeq = detail_input_AutoDeductionDic[pSource.AlternateKeyCode].pd_Seq;
                  detail_input_AutoDeductionDic[pSource.AlternateKeyCode].PutData(pSource);
                  detail_input_AutoDeductionDic[pSource.AlternateKeyCode].pd_PaymentID = pdPaymentId;
                  detail_input_AutoDeductionDic[pSource.AlternateKeyCode].pd_Seq = pdSeq;
                  detail_input_AutoDeductionDic[pSource.AlternateKeyCode].db_status = 2;
                  paymentWork2.db_status = 4;
                }
              }
            }
          }
        }
        n_count = 0;
        foreach (PaymentWork item in (IEnumerable<PaymentWork>) list_header)
        {
          if (item.IsSaved)
          {
            foreach (PaymentDetailView ltDetail in (IEnumerable<PaymentDetailView>) item.Lt_Details)
            {
              if (ltDetail.pd_WriteType == 1)
              {
                if (ltDetail.IsNone)
                {
                  ltDetail.pd_ConfirmStatus = 3;
                  ltDetail.db_status = 2;
                }
                else if (ltDetail.IsSaved)
                {
                  ltDetail.db_status = 2;
                }
                else
                {
                  int num = ltDetail.IsNew ? 1 : 0;
                }
              }
            }
            if (item.pay_Code == 0L)
            {
              if (!await item.InsertDataAsync(autoDeductionView.OleDB, pEmployee, true))
                throw new Exception(item.TableCode.ToDescription() + " 신규 등록 에러\n" + item.message);
            }
            else if (!await item.UpdateDataAsync(autoDeductionView.OleDB, pEmployee, true))
              throw new Exception(item.TableCode.ToDescription() + " 등록 변경 에러\n" + item.message);
          }
          if (item.IsUpdate)
            ++n_count;
        }
        if (list_header.Count > 0 && isMessage)
        {
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage1 = new UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage();
          jobEvtMessage1.SiteID = list_header[0].pay_SiteID;
          jobEvtMessage1.Id = pJobInfo.Id;
          jobEvtMessage1.JobId = pJobInfo.JobId;
          jobEvtMessage1.Msg = "[" + new DateTime?(pWorkDate).GetDateToStr("yyyy-MM-dd") + "] " + n_count.ToString("n0") + "건 등록" + string.Format(" >> {0:000}%", (object) (n_count * 100 / list_header.Count));
          UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage jobEvtMessage2 = jobEvtMessage1;
          autoDeductionView._CallBackMessage(jobEvtMessage2.ToJson<UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage>());
        }
        list_header.Clear();
        headerDic.Clear();
        list_detail.Clear();
        detail_input_AutoDeductionDic.Clear();
        list_WorkData.Clear();
        return true;
      }
      catch (Exception ex)
      {
        autoDeductionView.message = " " + autoDeductionView.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + autoDeductionView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(autoDeductionView.message);
      }
      return false;
    }

    public async Task<IList<PaymentDetailAutoDeductionView>> SelectDetailListAsync(Hashtable pParam)
    {
      PaymentDetailAutoDeductionView autoDeductionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(autoDeductionView1.GetSelectQuery((object) pParam)))
        {
          autoDeductionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + autoDeductionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentDetailAutoDeductionView>) null;
        }
        IList<PaymentDetailAutoDeductionView> lt_list = (IList<PaymentDetailAutoDeductionView>) new List<PaymentDetailAutoDeductionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentDetailAutoDeductionView autoDeductionView2 = autoDeductionView1.OleDB.Create<PaymentDetailAutoDeductionView>();
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

    public async Task<IList<PaymentDetailAutoDeductionView>> SelectWorkApplyListAsync(
      Hashtable pParam)
    {
      PaymentDetailAutoDeductionView autoDeductionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!await rs.OpenAsync(autoDeductionView1.GetWorkApplyQuery((object) pParam)))
        {
          autoDeductionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + autoDeductionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentDetailAutoDeductionView>) null;
        }
        IList<PaymentDetailAutoDeductionView> lt_list = (IList<PaymentDetailAutoDeductionView>) new List<PaymentDetailAutoDeductionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentDetailAutoDeductionView autoDeductionView2 = autoDeductionView1.OleDB.Create<PaymentDetailAutoDeductionView>();
            if (autoDeductionView2.GetFieldWorkApplyValues(rs))
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

    public bool GetFieldWorkApplyValues(UniOleDbRecordset p_rs)
    {
      this.pd_ConfirmDate = p_rs.GetFieldDateTime("pd_ConfirmDate");
      this.pd_SiteID = p_rs.GetFieldLong("pd_SiteID");
      this.pay_Date = p_rs.GetFieldDateTime("pay_Date");
      this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
      this.pay_Supplier = p_rs.GetFieldInt("pay_Supplier");
      this.AutoDeductionInfo.suad_Seq = p_rs.GetFieldInt("suad_Seq");
      this.AutoDeductionInfo.suad_CalcType = p_rs.GetFieldInt("suad_CalcType");
      this.AutoDeductionInfo.suad_StdPriceType = p_rs.GetFieldInt("suad_StdPriceType");
      this.AutoDeductionInfo.suad_StdValue = (double) p_rs.GetFieldInt("suad_StdValue");
      this.AutoDeductionInfo.suad_Value = (double) p_rs.GetFieldInt("suad_Value");
      this.pd_BuyAmount = p_rs.GetFieldDouble("pd_BuyAmount");
      this.pd_BuyVatAmount = p_rs.GetFieldDouble("pd_BuyVatAmount");
      this.pd_SaleAmount = p_rs.GetFieldDouble("pd_SaleAmount");
      this.pd_SaleVatAmount = p_rs.GetFieldDouble("pd_SaleVatAmount");
      this.pd_SalePayCash = p_rs.GetFieldDouble("pd_SalePayCash");
      this.pd_SalePayCard = p_rs.GetFieldDouble("pd_SalePayCard");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      return true;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      PaymentView paymentView = new PaymentView();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        long p_SiteID = 0;
        DateTime? nullable1 = new DateTime?();
        DateTime? nullable2 = new DateTime?();
        DateTime? nullable3 = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
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
        if (!nullable1.HasValue || !nullable2.HasValue)
        {
          Exception exception = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeaderQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        if (nullable2.HasValue)
          stringBuilder.Append(paymentView.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable2.Value));
        else if (nullable3.HasValue)
          stringBuilder.Append(paymentView.ToWithPayContionPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable3.Value));
        stringBuilder.Append(paymentView.ToWithSupplierHistoryQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append("\nSELECT  pd_PaymentID,pd_Seq,pd_SiteID,pd_ConfirmDate,pd_ConfirmStatus,pd_InOutDiv,pd_StatementType,pd_ReasonType,pd_WriteType,pd_Amount,pd_PayAmount,pd_DeductAmount,pd_Memo,pd_TransmitStatus,pd_TransmitDate,pd_InDate,pd_InUser,pd_ModDate,pd_ModUser\n,pay_Date,pay_StoreCode,pay_Supplier,pay_ConfirmStatus\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv\n,'' AS inEmpName,'' AS modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON pd_PaymentID=pay_Code AND pd_SiteID=pay_SiteID\nINNER JOIN T_STORE ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID\nINNER JOIN T_SUPPLIER_HISTORY ON pay_Date=pc_pay_day AND pd_SiteID=suh_SiteID AND pay_StoreCode=suh_StoreCode AND pay_Supplier=suh_Supplier\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=pay_Supplier AND pay_SiteID=gdh_SiteID");
        stringBuilder.Append("\nORDER BY pay_StoreCode,pay_Supplier,pd_PaymentID,pd_Seq,pd_ConfirmDate");
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

    public string GetWorkApplyQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      PaymentView paymentView = new PaymentView();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
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
        if (!nullable1.HasValue || !nullable2.HasValue)
        {
          Exception exception = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeaderQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        if (nullable2.HasValue)
          stringBuilder.Append(paymentView.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable2.Value));
        else if (nullable3.HasValue)
          stringBuilder.Append(paymentView.ToWithPayContionPaymentQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable3.Value));
        stringBuilder.Append(paymentView.ToWithSupplierHistoryQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_AUTO_DEDUCTION AS (\nSELECT suad_SupplierHistory,suad_Seq,suad_SiteID,suad_CalcType,suad_StdPriceType,suad_StdValue,suad_Value\n,suh_Supplier,suh_StoreCode,pc_pay_day,suph_dt_start,suph_dt_end,su_SupplierType AS auto_su_SupplierType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.SupplierAutoDeduction, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER_HISTORY ON suad_SupplierHistory=suh_ID AND suad_SiteID=suh_SiteID) ");
        stringBuilder.Append("\n,T_BUY AS (\nSELECT suph_dt_end AS pd_ConfirmDate,sh_SiteID AS pd_SiteID,sh_StoreCode AS pay_StoreCode,sh_Supplier AS pay_Supplier,SUM((sh_CostTaxAmt+sh_CostTaxFreeAmt) * sh_InOutDiv) AS pd_BuyAmount,SUM(sh_CostVatAmt * sh_InOutDiv) AS pd_BuyVatAmount" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_AUTO_DEDUCTION ON sh_SiteID=suad_SiteID AND sh_StoreCode=suh_StoreCode AND sh_ConfirmDate>=suph_dt_start AND sh_ConfirmDate<=suph_dt_end AND sh_Supplier=suh_Supplier" + string.Format("\nWHERE {0}={1}", (object) "sh_ConfirmStatus", (object) 1) + string.Format("\nAND {0}={1}", (object) "sh_StatementType", (object) 1) + "\nGROUP BY suph_dt_end,sh_SiteID,sh_StoreCode,sh_Supplier) ");
        stringBuilder.Append("\n,T_BUY_SALES_LEA_CHARGE AS (\nSELECT suph_dt_end AS pd_ConfirmDate,sbd_SiteID AS pd_SiteID,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,SUM((sbd_SaleAmt-sbd_SaleVatAmt) * gdh_ChargeRate/100) AS pd_BuyAmount,SUM(sbd_SaleVatAmt * gdh_ChargeRate / 100) AS pd_BuyVatAmount" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_AUTO_DEDUCTION ON sbd_SaleDate>=suph_dt_start AND sbd_SaleDate<=suph_dt_start AND sbd_StoreCode=suh_StoreCode AND sbd_SiteID=suad_SiteID" + string.Format(" AND auto_{0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID AND suh_Supplier=gdh_Supplier AND gdh_ChargeRate!=0\nGROUP BY suph_dt_end,sbd_StoreCode,sbd_SiteID,gdh_Supplier) ");
        stringBuilder.Append(",\nT_BUY_SALES_LEA_PRICE AS (\nSELECT suph_dt_end AS pd_ConfirmDate,sbd_SiteID AS pd_SiteID,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,SUM(CASE WHEN gdh_EventCost>0 THEN gdh_EventCost ELSE gdh_BuyCost END * sbd_SaleQty) AS pd_BuyAmount,SUM(CASE WHEN gdh_EventVat>0 THEN gdh_EventVat ELSE gdh_BuyVat END * sbd_SaleQty) AS pd_BuyVatAmount" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_AUTO_DEDUCTION ON sbd_SaleDate>=suph_dt_start AND sbd_SaleDate<=suph_dt_start AND sbd_StoreCode=suh_StoreCode AND sbd_SiteID=suad_SiteID" + string.Format(" AND auto_{0}={1}", (object) "su_SupplierType", (object) 3) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID AND suh_Supplier=gdh_Supplier AND gdh_ChargeRate=0\nGROUP BY suph_dt_end,sbd_StoreCode,sbd_SiteID,gdh_Supplier) ");
        stringBuilder.Append("\n,T_BUY_SUM AS (\nSELECT pd_ConfirmDate,pd_SiteID,pay_StoreCode,pay_Supplier,SUM(pd_BuyAmount) AS pd_BuyAmount, SUM(pd_BuyVatAmount) AS pd_BuyVatAmount\nFROM (\nSELECT pd_ConfirmDate,pd_SiteID,pay_StoreCode,pay_Supplier,pd_BuyAmount,pd_BuyVatAmount FROM T_BUY\nUNION ALL \nSELECT pd_ConfirmDate,pd_SiteID,pay_StoreCode,pay_Supplier,pd_BuyAmount,pd_BuyVatAmount FROM T_BUY_SALES_LEA_CHARGE\nUNION ALL \nSELECT pd_ConfirmDate,pd_SiteID,pay_StoreCode,pay_Supplier,pd_BuyAmount,pd_BuyVatAmount FROM T_BUY_SALES_LEA_PRICE\n) SUB \nGROUP BY pd_ConfirmDate,pd_SiteID,pay_StoreCode,pay_Supplier)");
        stringBuilder.Append("\n,T_SALES AS (\nSELECT suph_dt_end AS pd_ConfirmDate,sbd_SiteID AS pd_SiteID,sbd_StoreCode AS pay_StoreCode,gdh_Supplier AS pay_Supplier,SUM(sbd_SaleAmt) AS pd_SaleAmount,SUM(sbd_SaleVatAmt) AS pd_SaleVatAmount,SUM(sbd_PayCash) AS pd_SalePayCash,SUM(sbd_PayCard) AS pd_SalePayCard" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_AUTO_DEDUCTION ON sbd_SaleDate>=suph_dt_start AND sbd_SaleDate<=suph_dt_start AND sbd_StoreCode=suh_StoreCode AND sbd_SiteID=suad_SiteID" + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID AND suh_Supplier=gdh_Supplier\nGROUP BY suph_dt_end,sbd_StoreCode,sbd_SiteID,gdh_Supplier) ");
        stringBuilder.Append("\nSELECT suph_dt_end AS pd_ConfirmDate,suad_SiteID AS pd_SiteID,pc_pay_day AS pay_Date,suh_StoreCode AS pay_StoreCode,suh_Supplier AS pay_Supplier,suad_Seq,suad_CalcType,suad_StdPriceType,suad_StdValue,suad_Value,pd_BuyAmount,pd_BuyVatAmount,pd_SaleAmount,pd_SaleVatAmount,pd_SalePayCash,pd_SalePayCard,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn\nFROM T_AUTO_DEDUCTION\nINNER JOIN T_SUPPLIER ON suh_Supplier=su_Supplier AND suad_SiteID=su_SiteID\nLEFT OUTER JOIN T_BUY_SUM ON suph_dt_end=T_BUY_SUM.pd_ConfirmDate AND suh_StoreCode=T_BUY_SUM.pay_StoreCode AND suh_Supplier=T_BUY_SUM.pay_Supplier AND suad_SiteID=T_BUY_SUM.pd_SiteID\nLEFT OUTER JOIN T_SALES ON suph_dt_end=T_SALES.pd_ConfirmDate AND suh_StoreCode=T_SALES.pay_StoreCode AND suh_Supplier=T_SALES.pay_Supplier AND suad_SiteID=T_SALES.pd_SiteID");
        stringBuilder.Append("\nORDER BY suh_StoreCode,suh_Supplier,suph_dt_end,suad_Seq");
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
  }
}
