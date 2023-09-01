// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.PaymentMonthWork
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
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public class PaymentMonthWork : TPaymentMonth<PaymentMonthWork>
  {
    private DateTime? _WorkOriginDate;
    private int _paym_YyyyMmBefore;
    private string _WorkStoreCodeIn;
    private string _si_StoreName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private Action<string> _CallBackMessage;

    public DateTime? WorkOriginDate
    {
      get => this._WorkOriginDate;
      set
      {
        this._WorkOriginDate = value;
        this.Changed(nameof (WorkOriginDate));
        if (this._WorkOriginDate.HasValue)
        {
          DateTime dateTime = this._WorkOriginDate.Value;
          int num = dateTime.Year * 100;
          dateTime = this._WorkOriginDate.Value;
          int month = dateTime.Month;
          this.paym_YyyyMm = num + month;
          DateTime dateAdd = this._WorkOriginDate.Value.ToFirstDateOfMonth().GetDateAdd(0, 0, -1);
          this.paym_YyyyMmBefore = dateAdd.Year * 100 + dateAdd.Month;
        }
        this.Changed("WorkFirstDay");
        this.Changed("WorkLastDay");
      }
    }

    public DateTime? WorkFirstDay => this.WorkOriginDate.HasValue ? new DateTime?(this.WorkOriginDate.Value.ToFirstDateOfMonth()) : new DateTime?();

    public DateTime? WorkLastDay => this.WorkOriginDate.HasValue ? new DateTime?(this.WorkOriginDate.Value.ToLastDateOfMonth()) : new DateTime?();

    public int paym_YyyyMmBefore
    {
      get => this._paym_YyyyMmBefore;
      set
      {
        this._paym_YyyyMmBefore = value;
        this.Changed(nameof (paym_YyyyMmBefore));
      }
    }

    public string WorkStoreCodeIn
    {
      get => this._WorkStoreCodeIn;
      set
      {
        this._WorkStoreCodeIn = value;
        this.Changed(nameof (WorkStoreCodeIn));
      }
    }

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

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public PaymentMonthWork()
    {
    }

    public PaymentMonthWork(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.WorkOriginDate = new DateTime?();
      this.paym_YyyyMmBefore = 0;
      this.WorkStoreCodeIn = (string) null;
      this.si_StoreName = string.Empty;
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.paym_SiteID == 0L)
      {
        this.message = "싸이트(paym_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.paym_YyyyMm == 0)
      {
        this.message = "결제월(paym_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.paym_StoreCode == 0 && string.IsNullOrEmpty(this.WorkStoreCodeIn))
      {
        this.message = "지점코드(paym_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.WorkOriginDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "기준일자(WorkOriginDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    public override bool DataClear(Hashtable p_param)
    {
      this.InsertChecked();
      if (p_param == null || p_param.Count == 0)
      {
        if (p_param == null)
          p_param = new Hashtable();
        p_param.Add((object) "paym_SiteID", (object) this.paym_SiteID);
        p_param.Add((object) "paym_YyyyMm", (object) this.paym_YyyyMm);
        if (string.IsNullOrEmpty(this.WorkStoreCodeIn))
          p_param.Add((object) "paym_StoreCode", (object) this.paym_StoreCode);
        else
          p_param.Add((object) "paym_StoreCode_IN_", (object) this.WorkStoreCodeIn);
        if (this.paym_Supplier > 0)
          p_param.Add((object) "paym_Supplier", (object) this.paym_Supplier);
      }
      if (this.OleDB.Execute(this.DataClearQuery(p_param)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier, (object) this.paym_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> DataClearAsync(Hashtable p_param)
    {
      PaymentMonthWork paymentMonthWork = this;
      // ISSUE: reference to a compiler-generated method
      paymentMonthWork.\u003C\u003En__0();
      if (p_param == null || p_param.Count == 0)
      {
        if (p_param == null)
          p_param = new Hashtable();
        p_param.Add((object) "paym_SiteID", (object) paymentMonthWork.paym_SiteID);
        p_param.Add((object) "paym_YyyyMm", (object) paymentMonthWork.paym_YyyyMm);
        if (string.IsNullOrEmpty(paymentMonthWork.WorkStoreCodeIn))
          p_param.Add((object) "paym_StoreCode", (object) paymentMonthWork.paym_StoreCode);
        else
          p_param.Add((object) "paym_StoreCode_IN_", (object) paymentMonthWork.WorkStoreCodeIn);
        if (paymentMonthWork.paym_Supplier > 0)
          p_param.Add((object) "paym_Supplier", (object) paymentMonthWork.paym_Supplier);
      }
      if (await paymentMonthWork.OleDB.ExecuteAsync(paymentMonthWork.DataClearQuery(p_param)))
        return true;
      paymentMonthWork.message = " " + paymentMonthWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) paymentMonthWork.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) paymentMonthWork.paym_YyyyMm, (object) paymentMonthWork.paym_StoreCode, (object) paymentMonthWork.paym_Supplier, (object) paymentMonthWork.paym_SiteID) + " 내용 : " + paymentMonthWork.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(paymentMonthWork.message);
      return false;
    }

    public override bool ItemSave()
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

    public override async Task<bool> ItemSaveAsync()
    {
      PaymentMonthWork paymentMonthWork = this;
      try
      {
        if (paymentMonthWork.db_status == 0)
        {
          if (!await paymentMonthWork.InsertAsync())
            throw new UniServiceException(paymentMonthWork.message, paymentMonthWork.TableCode.ToDescription() + " 등록 오류");
        }
        else if (paymentMonthWork.db_status > 0)
        {
          if (!await paymentMonthWork.UpdateAsync((UbModelBase) null))
            throw new UniServiceException(paymentMonthWork.message, paymentMonthWork.TableCode.ToDescription() + " 등록 오류");
        }
        return true;
      }
      catch (Exception ex)
      {
        paymentMonthWork.message = " " + paymentMonthWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentMonthWork.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync()
    {
      PaymentMonthWork paymentMonthWork = this;
      try
      {
        if (!await paymentMonthWork.DataClearAsync((Hashtable) null))
          throw new Exception("작업 취소 처리.\n" + paymentMonthWork.message);
        IList<PaymentMonthWork> paymentMonthWorkList = await paymentMonthWork.SelectListAsync();
        if (paymentMonthWorkList == null)
          throw new Exception("조회에러.\n" + paymentMonthWork.message);
        foreach (PaymentMonthWork item in (IEnumerable<PaymentMonthWork>) paymentMonthWorkList)
        {
          item.CalcEndAAmount();
          if (!item.IsZero(EnumZeroCheck.ALL))
          {
            if (!await item.ItemSaveAsync())
              Log.Logger.ErrorColor("\n" + item.message);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        paymentMonthWork.message = " " + paymentMonthWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentMonthWork.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(JobEvtInfo pJobInfo, string pWorkDesc)
    {
      PaymentMonthWork paymentMonthWork = this;
      bool isMessage = paymentMonthWork._CallBackMessage != null && pJobInfo != null;
      try
      {
        Log.Logger.DebugColor("\n대금 " + pWorkDesc + " 결제 기초 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        if (!await paymentMonthWork.DataClearAsync((Hashtable) null))
          throw new Exception("작업 취소 처리.\n" + paymentMonthWork.message);
        IList<PaymentMonthWork> paymentMonthWorkList = await paymentMonthWork.SelectListAsync();
        if (paymentMonthWorkList == null)
          throw new Exception("조회에러.\n" + paymentMonthWork.message);
        int count = 0;
        int viewPro = 0;
        int total = paymentMonthWorkList.Count;
        foreach (PaymentMonthWork item in (IEnumerable<PaymentMonthWork>) paymentMonthWorkList)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          item.CalcEndAAmount();
          if (!item.IsZero(EnumZeroCheck.ALL))
          {
            if (!await item.ItemSaveAsync())
              Log.Logger.ErrorColor("\n" + item.message);
          }
          else
            Log.Logger.DebugColor(string.Format("\n[Supplier:{0}]-IsZero", (object) item.paym_Supplier));
          ++count;
          int num = count * 100 / total;
          if (viewPro != num)
          {
            viewPro = num;
            if (isMessage)
            {
              JobEvtProgressing jobEvtProgressing1 = new JobEvtProgressing();
              jobEvtProgressing1.SiteID = pJobInfo.SiteID;
              jobEvtProgressing1.Id = pJobInfo.Id;
              jobEvtProgressing1.JobId = pJobInfo.JobId;
              jobEvtProgressing1.Title = "지점" + item.si_StoreName + " 작업";
              jobEvtProgressing1.Msg = string.Format("[{0}] {1} 작업중 ({2}/{3})", (object) item.su_SupplierName, (object) viewPro, (object) count, (object) total);
              jobEvtProgressing1.ProgressValue = (double) viewPro / 100.0;
              JobEvtProgressing jobEvtProgressing2 = jobEvtProgressing1;
              paymentMonthWork._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        paymentMonthWork.message = " " + paymentMonthWork.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentMonthWork.message);
      }
      return false;
    }

    public async Task<bool> ProcNextAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      DateTime p_WorkOriginDate,
      int p_paym_StoreCode,
      int p_paym_Supplier,
      long p_paym_SiteID)
    {
      PaymentMonthWork paymentMonthWork1 = this;
      bool isMessage = paymentMonthWork1._CallBackMessage != null && pJobInfo != null;
      DateTime lastDay = DateTime.Now.ToLastDateOfMonth();
      try
      {
        paymentMonthWork1.WorkOriginDate = new DateTime?(p_WorkOriginDate);
        PaymentMonthWork paymentMonthWork2 = paymentMonthWork1;
        DateTime? workOriginDate = paymentMonthWork1.WorkOriginDate;
        int int32_1 = Convert.ToInt32(new DateTime?(workOriginDate.Value).GetDateToStr("yyyyMM"));
        paymentMonthWork2.paym_YyyyMm = int32_1;
        paymentMonthWork1.paym_StoreCode = p_paym_StoreCode;
        paymentMonthWork1.paym_Supplier = p_paym_Supplier;
        paymentMonthWork1.paym_SiteID = p_paym_SiteID;
        if (paymentMonthWork1.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + paymentMonthWork1.message);
        if (paymentMonthWork1.paym_Supplier == 0)
        {
          paymentMonthWork1.message = "코드(paym_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
          throw new Exception("작업 취소 처리.\n" + paymentMonthWork1.message);
        }
        while (true)
        {
          workOriginDate = paymentMonthWork1.WorkOriginDate;
          if (workOriginDate.Value <= lastDay)
          {
            PaymentMonthWork paymentMonthWork3 = paymentMonthWork1;
            workOriginDate = paymentMonthWork1.WorkOriginDate;
            int int32_2 = Convert.ToInt32(new DateTime?(workOriginDate.Value).GetDateToStr("yyyyMM"));
            paymentMonthWork3.paym_YyyyMm = int32_2;
            PaymentMonthWork paymentMonthWork4 = paymentMonthWork1;
            workOriginDate = paymentMonthWork1.WorkOriginDate;
            int int32_3 = Convert.ToInt32(new DateTime?(workOriginDate.Value.GetDateAdd(0, -1, 0)).GetDateToStr("yyyyMM"));
            paymentMonthWork4.paym_YyyyMmBefore = int32_3;
            if (await paymentMonthWork1.DataClearAsync((Hashtable) null))
            {
              IList<PaymentMonthWork> paymentMonthWorkList = await paymentMonthWork1.SelectListAsync();
              int count = 0;
              int viewPro = 0;
              int total = paymentMonthWorkList.Count;
              foreach (PaymentMonthWork item in (IEnumerable<PaymentMonthWork>) paymentMonthWorkList)
              {
                if (pJobInfo != null && pJobInfo.IsWorkCancel)
                  throw new Exception("작업 취소 처리.");
                item.CalcEndAAmount();
                if (!item.IsZero(EnumZeroCheck.ALL))
                {
                  if (!await item.ItemSaveAsync())
                    Log.Logger.ErrorColor("\n" + item.message);
                }
                else
                  Log.Logger.DebugColor(string.Format("\n[Supplier:{0}]-IsZero", (object) item.paym_Supplier));
                ++count;
                int num = count * 100 / total;
                if (viewPro != num)
                {
                  viewPro = num;
                  if (isMessage)
                  {
                    JobEvtProgressing jobEvtProgressing1 = new JobEvtProgressing();
                    jobEvtProgressing1.SiteID = pJobInfo.SiteID;
                    jobEvtProgressing1.Id = pJobInfo.Id;
                    jobEvtProgressing1.JobId = pJobInfo.JobId;
                    jobEvtProgressing1.Title = "지점" + item.si_StoreName + " 작업";
                    jobEvtProgressing1.Msg = string.Format("[{0}] {1} 작업중 ({2}/{3})", (object) item.su_SupplierName, (object) viewPro, (object) count, (object) total);
                    jobEvtProgressing1.ProgressValue = (double) viewPro / 100.0;
                    JobEvtProgressing jobEvtProgressing2 = jobEvtProgressing1;
                    paymentMonthWork1._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
                  }
                  else
                    Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
                }
              }
              paymentMonthWork1.WorkOriginDate = new DateTime?(paymentMonthWork1.WorkOriginDate.Value.GetDateAdd(0, 1, 0));
              paymentMonthWork1.WorkOriginDate = new DateTime?(paymentMonthWork1.WorkOriginDate.Value.ToLastDateOfMonth());
            }
            else
              break;
          }
          else
            goto label_27;
        }
        throw new Exception("작업 취소 처리.\n" + paymentMonthWork1.message);
label_27:
        return true;
      }
      catch (Exception ex)
      {
        paymentMonthWork1.message = " " + paymentMonthWork1.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentMonthWork1.message);
      }
      return false;
    }

    public bool ProcNext(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      DateTime p_WorkOriginDate,
      int p_paym_StoreCode,
      int p_paym_Supplier,
      long p_paym_SiteID)
    {
      bool flag = this._CallBackMessage != null && pJobInfo != null;
      DateTime lastDateOfMonth = DateTime.Now.ToLastDateOfMonth();
      try
      {
        this.WorkOriginDate = new DateTime?(p_WorkOriginDate);
        DateTime? workOriginDate = this.WorkOriginDate;
        this.paym_YyyyMm = Convert.ToInt32(new DateTime?(workOriginDate.Value).GetDateToStr("yyyyMM"));
        this.paym_StoreCode = p_paym_StoreCode;
        this.paym_Supplier = p_paym_Supplier;
        this.paym_SiteID = p_paym_SiteID;
        if (this.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + this.message);
        if (this.paym_Supplier == 0)
        {
          this.message = "코드(paym_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
          throw new Exception("작업 취소 처리.\n" + this.message);
        }
        while (true)
        {
          workOriginDate = this.WorkOriginDate;
          if (workOriginDate.Value <= lastDateOfMonth)
          {
            workOriginDate = this.WorkOriginDate;
            this.paym_YyyyMm = Convert.ToInt32(new DateTime?(workOriginDate.Value).GetDateToStr("yyyyMM"));
            workOriginDate = this.WorkOriginDate;
            this.paym_YyyyMmBefore = Convert.ToInt32(new DateTime?(workOriginDate.Value.GetDateAdd(0, -1, 0)).GetDateToStr("yyyyMM"));
            if (this.DataClear((Hashtable) null))
            {
              IList<PaymentMonthWork> paymentMonthWorkList = this.SelectList();
              int num1 = 0;
              int num2 = 0;
              int count = paymentMonthWorkList.Count;
              foreach (PaymentMonthWork paymentMonthWork in (IEnumerable<PaymentMonthWork>) paymentMonthWorkList)
              {
                if (pJobInfo != null && pJobInfo.IsWorkCancel)
                  throw new Exception("작업 취소 처리.");
                paymentMonthWork.CalcEndAAmount();
                if (!paymentMonthWork.IsZero(EnumZeroCheck.ALL))
                {
                  if (!paymentMonthWork.ItemSave())
                    Log.Logger.ErrorColor("\n" + paymentMonthWork.message);
                }
                else
                  Log.Logger.DebugColor(string.Format("\n[Supplier:{0}]-IsZero", (object) paymentMonthWork.paym_Supplier));
                ++num1;
                int num3 = num1 * 100 / count;
                if (num2 != num3)
                {
                  num2 = num3;
                  if (flag)
                  {
                    JobEvtProgressing jobEvtProgressing = new JobEvtProgressing();
                    jobEvtProgressing.SiteID = pJobInfo.SiteID;
                    jobEvtProgressing.Id = pJobInfo.Id;
                    jobEvtProgressing.JobId = pJobInfo.JobId;
                    jobEvtProgressing.Title = "지점" + paymentMonthWork.si_StoreName + " 작업";
                    jobEvtProgressing.Msg = string.Format("[{0}] {1} 작업중 ({2}/{3})", (object) paymentMonthWork.su_SupplierName, (object) num2, (object) num1, (object) count);
                    jobEvtProgressing.ProgressValue = (double) num2 / 100.0;
                    this._CallBackMessage(jobEvtProgressing.ToJson<JobEvtProgressing>());
                  }
                  else
                    Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
                }
              }
              this.WorkOriginDate = new DateTime?(this.WorkOriginDate.Value.GetDateAdd(0, 1, 0));
              workOriginDate = this.WorkOriginDate;
              this.WorkOriginDate = new DateTime?(workOriginDate.Value.ToLastDateOfMonth());
            }
            else
              break;
          }
          else
            goto label_25;
        }
        throw new Exception("작업 취소 처리.\n" + this.message);
label_25:
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<PaymentMonthWork>> SelectListAsync()
    {
      PaymentMonthWork paymentMonthWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentMonthWork1.OleDB.ConnectionUrl, pCommandTimeout: 180);
        rs = new UniOleDbRecordset(db, paymentMonthWork1.OleDB.CommandTimeout);
        if (paymentMonthWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + paymentMonthWork1.TableCode.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + paymentMonthWork1.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(paymentMonthWork1.message);
        }
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "paym_SiteID", (object) paymentMonthWork1.paym_SiteID);
        p_param.Add((object) "paym_YyyyMm", (object) paymentMonthWork1.paym_YyyyMm);
        if (string.IsNullOrEmpty(paymentMonthWork1.WorkStoreCodeIn))
          p_param.Add((object) "paym_StoreCode", (object) paymentMonthWork1.paym_StoreCode);
        else
          p_param.Add((object) "paym_StoreCode_IN_", (object) paymentMonthWork1.WorkStoreCodeIn);
        p_param.Add((object) "WorkOriginDate", (object) paymentMonthWork1.WorkOriginDate.Value);
        p_param.Add((object) "paym_YyyyMmBefore", (object) paymentMonthWork1.paym_YyyyMmBefore);
        if (paymentMonthWork1.paym_Supplier > 0)
          p_param.Add((object) "paym_Supplier", (object) paymentMonthWork1.paym_Supplier);
        if (!await rs.OpenAsync(paymentMonthWork1.GetSelectQuery((object) p_param)))
        {
          paymentMonthWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentMonthWork>) null;
        }
        IList<PaymentMonthWork> lt_list = (IList<PaymentMonthWork>) new List<PaymentMonthWork>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentMonthWork paymentMonthWork2 = paymentMonthWork1.OleDB.Create<PaymentMonthWork>();
            if (paymentMonthWork2.GetFieldValues(rs))
            {
              paymentMonthWork2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentMonthWork2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public IList<PaymentMonthWork> SelectList()
    {
      UniOleDbRecordset p_rs = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl, pCommandTimeout: 180);
        p_rs = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        if (this.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + this.TableCode.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + this.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(this.message);
        }
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "paym_SiteID", (object) this.paym_SiteID);
        p_param.Add((object) "paym_YyyyMm", (object) this.paym_YyyyMm);
        if (string.IsNullOrEmpty(this.WorkStoreCodeIn))
          p_param.Add((object) "paym_StoreCode", (object) this.paym_StoreCode);
        else
          p_param.Add((object) "paym_StoreCode_IN_", (object) this.WorkStoreCodeIn);
        p_param.Add((object) "WorkOriginDate", (object) this.WorkOriginDate.Value);
        p_param.Add((object) "paym_YyyyMmBefore", (object) this.paym_YyyyMmBefore);
        if (this.paym_Supplier > 0)
          p_param.Add((object) "paym_Supplier", (object) this.paym_Supplier);
        if (!p_rs.Open(this.GetSelectQuery((object) p_param)))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentMonthWork>) null;
        }
        List<PaymentMonthWork> paymentMonthWorkList = new List<PaymentMonthWork>();
        if (p_rs.IsDataRead())
        {
          do
          {
            PaymentMonthWork paymentMonthWork = this.OleDB.Create<PaymentMonthWork>();
            if (paymentMonthWork.GetFieldValues(p_rs))
            {
              paymentMonthWork.row_number = paymentMonthWorkList.Count + 1;
              paymentMonthWorkList.Add(paymentMonthWork);
            }
          }
          while (p_rs.IsDataRead());
        }
        return (IList<PaymentMonthWork>) paymentMonthWorkList;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        p_rs?.Close();
        pOleDB?.Close();
      }
    }

    public async IAsyncEnumerable<PaymentMonthWork> SelectEnumerableAsync()
    {
      PaymentMonthWork paymentMonthWork1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentMonthWork1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentMonthWork1.OleDB.CommandTimeout);
        if (paymentMonthWork1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + paymentMonthWork1.message + "\n--------------------------------------------------------------------------------------------------");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else
        {
          Hashtable p_param = new Hashtable();
          p_param.Add((object) "paym_SiteID", (object) paymentMonthWork1.paym_SiteID);
          p_param.Add((object) "paym_YyyyMm", (object) paymentMonthWork1.paym_YyyyMm);
          if (string.IsNullOrEmpty(paymentMonthWork1.WorkStoreCodeIn))
            p_param.Add((object) "paym_StoreCode", (object) paymentMonthWork1.paym_StoreCode);
          else
            p_param.Add((object) "paym_StoreCode_IN_", (object) paymentMonthWork1.WorkStoreCodeIn);
          p_param.Add((object) "WorkOriginDate", (object) paymentMonthWork1.WorkOriginDate.Value);
          p_param.Add((object) "paym_YyyyMmBefore", (object) paymentMonthWork1.paym_YyyyMmBefore);
          int paymSupplier = paymentMonthWork1.paym_Supplier;
          if (!await rs.OpenAsync(paymentMonthWork1.GetSelectQuery((object) p_param)))
          {
            paymentMonthWork1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthWork1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
            // ISSUE: reference to a compiler-generated field
            this.\u003C\u003Ew__disposeMode = true;
          }
          else if (await rs.IsDataReadAsync())
          {
            int row_number = 0;
            do
            {
              PaymentMonthWork paymentMonthWork2 = paymentMonthWork1.OleDB.Create<PaymentMonthWork>();
              if (paymentMonthWork2.GetFieldValues(rs))
              {
                paymentMonthWork2.row_number = ++row_number;
                yield return paymentMonthWork2;
              }
            }
            while (await rs.IsDataReadAsync());
          }
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.db_status = p_rs.GetFieldInt("db_status");
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
        this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
        this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
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
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "paym_SiteID") && Convert.ToInt64(hashtable2[(object) "paym_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "paym_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkStartQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkEndQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkBuyQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkReturnQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(this.ToWithWorkPaymetDetailQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append("\nSELECT paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.MainCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append("\n,su_SupplierName,su_SupplierViewCode,su_SupplierType");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.SubCol);
        stringBuilder.Append("\n,MAX(db_status) AS db_status");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.TBodyStartCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.TBodyEndCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyEndTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.TBodyBuyCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyBuyTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.TBodyReturnCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TBodyReturnTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID");
        stringBuilder.Append(TPaymentMonth.TPaymetDetailCol);
        stringBuilder.Append("\n,db_status");
        stringBuilder.Append("\nFROM TPaymetDetailTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY paym_YyyyMm,paym_StoreCode,paym_Supplier");
        stringBuilder.Append(",paym_SiteID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON paym_StoreCode=si_StoreCode AND paym_SiteID=si_SiteID\n INNER JOIN T_SUPPLIER ON paym_Supplier=su_Supplier AND paym_SiteID=su_SiteID");
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY paym_StoreCode,paym_Supplier,paym_YyyyMm");
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

    public string ToWithWorkStartQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyStartTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.paym_YyyyMm, (object) "paym_YyyyMm", (object) "paym_StoreCode", (object) "paym_Supplier") + ",paym_SiteID,paym_EndAmount AS paym_BaseAmount,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentMonth, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_YyyyMmBefore"))
            p_param1.Add((object) "paym_YyyyMm", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "paym_SiteID"))
            p_param1.Add((object) "paym_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "paym_YyyyMm"))
            p_param1.Add((object) "paym_YyyyMm", (object) this.paym_YyyyMmBefore);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && !p_param1.ContainsKey((object) "paym_StoreCode_IN_"))
            p_param1.Add((object) "paym_StoreCode", (object) this.paym_StoreCode);
          stringBuilder.Append(new TPaymentMonth().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "paym_YyyyMm", (object) this.paym_YyyyMmBefore));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "paym_StoreCode", (object) this.paym_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "paym_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkEndQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyEndTable AS (" + string.Format("\nSELECT {0} AS {1},{2},{3}", (object) this.paym_YyyyMm, (object) "paym_YyyyMm", (object) "paym_StoreCode", (object) "paym_Supplier") + ",paym_SiteID,paym_EndAmount" + string.Format(",{0} AS {1}", (object) 2, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentMonth, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_YyyyMm"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "paym_SiteID"))
            p_param1.Add((object) "paym_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "paym_YyyyMm"))
            p_param1.Add((object) "paym_YyyyMm", (object) this.paym_YyyyMm);
          if (!p_param1.ContainsKey((object) "paym_StoreCode") && !p_param1.ContainsKey((object) "paym_StoreCode_IN_"))
            p_param1.Add((object) "paym_StoreCode", (object) this.paym_StoreCode);
          stringBuilder.Append(new TPaymentMonth().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "paym_YyyyMm", (object) this.paym_YyyyMm));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "paym_StoreCode", (object) this.paym_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "paym_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkBuyQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyBuyTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.paym_YyyyMm, (object) "paym_YyyyMm") + ",sh_StoreCode AS paym_StoreCode,sh_Supplier AS paym_Supplier,sh_SiteID AS paym_SiteID,SUM(sh_CostTaxAmt) AS paym_BuyTax,SUM(sh_CostVatAmt) AS paym_BuyVat,SUM(sh_CostTaxFreeAmt) AS paym_BuyFree,SUM(sh_Deposit) AS paym_Deposit,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier_IN_"))
            p_param1.Add((object) "sh_Supplier_IN_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.paym_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sh_Supplier,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkReturnQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyReturnTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.paym_YyyyMm, (object) "paym_YyyyMm") + ",sh_StoreCode AS paym_StoreCode,sh_Supplier AS paym_Supplier,sh_SiteID AS paym_SiteID,SUM(sh_CostTaxAmt) AS paym_BuyReturnTax,SUM(sh_CostVatAmt) AS paym_BuyReturnVat,SUM(sh_CostTaxFreeAmt) AS paym_BuyReturnFree,SUM(sh_Deposit*-1) AS paym_Deposit,0 AS db_status" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier"))
            p_param1.Add((object) "sh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier_IN_"))
            p_param1.Add((object) "sh_Supplier_IN_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.paym_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_StoreCode,sh_Supplier,sh_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkPaymetDetailQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TPaymetDetailTable AS (" + string.Format("\nSELECT {0} AS {1}", (object) this.paym_YyyyMm, (object) "paym_YyyyMm") + ",pay_StoreCode AS paym_StoreCode,pay_Supplier AS paym_Supplier,pay_StoreCode AS paym_SiteID,SUM(pd_DeductAmount*pd_InOutDiv) AS paym_DeductionAmount,SUM(pd_PayAmount*pd_InOutDiv) AS paym_PayAmount" + string.Format(",{0} AS {1}", (object) 0, (object) "paym_AddAmount") + string.Format(",{0} AS {1}", (object) 0, (object) "db_status") + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PaymentDetail, (object) DbQueryHelper.ToWithNolock()) + " ON pay_Code=pd_PaymentID AND pay_SiteID=pd_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add((object) "pay_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add((object) "pay_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
            p_param1.Add((object) "pay_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier"))
            p_param1.Add((object) "pay_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_Supplier_IN_"))
            p_param1.Add((object) "pay_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkFirstDay"))
            p_param1.Add((object) "pd_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("WorkLastDay"))
            p_param1.Add((object) "pd_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pay_StoreCode") && !p_param1.ContainsKey((object) "pay_StoreCode_IN_"))
            p_param1.Add((object) "pay_StoreCode", (object) this.paym_StoreCode);
          if (!p_param1.ContainsKey((object) "pd_ConfirmDate_BEGIN_"))
            p_param1.Add((object) "pd_ConfirmDate_BEGIN_", (object) this.WorkFirstDay);
          if (!p_param1.ContainsKey((object) "pd_ConfirmDate_END_"))
            p_param1.Add((object) "pd_ConfirmDate_END_", (object) this.WorkLastDay);
          if (!p_param1.ContainsKey((object) "pd_ConfirmStatus"))
            p_param1.Add((object) "pd_ConfirmStatus", (object) 1);
          stringBuilder.Append(this.ToPaymentWhereAnd(p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY pay_StoreCode,pay_Supplier,pay_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
