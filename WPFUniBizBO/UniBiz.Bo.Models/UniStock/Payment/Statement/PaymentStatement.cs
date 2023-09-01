// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentStatement
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentStatement : PaymentView<PaymentStatement>
  {
    private DateTime? _sh_ConfirmDate;
    private int _pay_ConfirmAfterCount;
    private int _pay_StatementConfirmAfterCount;
    private Action<string> _CallBackMessage;

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
        this.Changed("MonthFirstDay");
        this.Changed("MonthLastDay");
      }
    }

    public DateTime? MonthFirstDay => this.sh_ConfirmDate.HasValue ? new DateTime?(this.sh_ConfirmDate.Value.ToFirstDateOfMonth()) : new DateTime?();

    public DateTime? MonthLastDay => this.sh_ConfirmDate.HasValue ? new DateTime?(this.sh_ConfirmDate.Value.ToLastDateOfMonth()) : new DateTime?();

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

    public PaymentStatement()
    {
    }

    public PaymentStatement(Action<string> p_Callback)
      : this()
    {
      this._CallBackMessage = p_Callback;
    }

    public override void Clear()
    {
      base.Clear();
      this.sh_ConfirmDate = new DateTime?();
      this.pay_ConfirmAfterCount = this.pay_StatementConfirmAfterCount = 0;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pay_SiteID == 0L)
      {
        this.message = "싸이트(pay_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pay_StoreCode == 0)
      {
        this.message = "지점코드(pay_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pay_Supplier == 0)
      {
        this.message = "코드(pay_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sh_ConfirmDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "확정일(sh_ConfirmDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
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

    public async Task<bool> ItemSaveAsync()
    {
      PaymentStatement paymentStatement = this;
      try
      {
        if (paymentStatement.db_status == 0)
        {
          if (!await paymentStatement.InsertAsync())
            throw new UniServiceException(paymentStatement.message, paymentStatement.TableCode.ToDescription() + " 등록 오류");
        }
        else if (paymentStatement.db_status > 0)
        {
          if (!await paymentStatement.UpdateAsync((UbModelBase) null))
            throw new UniServiceException(paymentStatement.message, paymentStatement.TableCode.ToDescription() + " 등록 오류");
        }
        return true;
      }
      catch (Exception ex)
      {
        paymentStatement.message = " " + paymentStatement.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentStatement.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentStatement.message);
      }
      return false;
    }

    public async Task<bool> ProcApplyAsync(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      int p_sh_Supplier,
      DateTime p_sh_ConfirmDate,
      EmployeeView pEmployee)
    {
      PaymentStatement paymentStatement1 = this;
      bool isMessage = paymentStatement1._CallBackMessage != null && pJobInfo != null;
      try
      {
        paymentStatement1.pay_SiteID = p_sh_SiteID;
        paymentStatement1.pay_StoreCode = p_sh_StoreCode;
        paymentStatement1.pay_Supplier = p_sh_Supplier;
        paymentStatement1.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate);
        if (paymentStatement1.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + paymentStatement1.message);
        Log.Logger.DebugColor("\n전표 결제 마감 " + pWorkDesc + " 해당 결제 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<PaymentStatement> paymentStatementList = await paymentStatement1.SelectStatementListAsync();
        if (paymentStatementList == null)
          throw new Exception("조회에러.\n" + paymentStatement1.message);
        int count = 0;
        int viewPro = 0;
        int total = paymentStatementList.Count;
        foreach (PaymentStatement paymentStatement2 in (IEnumerable<PaymentStatement>) paymentStatementList)
        {
          PaymentStatement item = paymentStatement2;
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          item.SetAdoDatabase(paymentStatement1.OleDB);
          if (item.pay_SiteID == 0L)
            item.pay_SiteID = paymentStatement1.pay_SiteID;
          if (item.IsConfirm)
            throw new UniServiceException(paymentStatement1.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(item.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 [결제]마감 [" + item.su_SupplierName + "]거래처 입니다.");
          if (item.IsStatementConfirm)
            throw new UniServiceException(paymentStatement1.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(item.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 [매입전표]마감 [" + item.su_SupplierName + "]거래처 입니다.");
          if (item.pay_ConfirmAfterCount > 0)
            throw new UniServiceException(paymentStatement1.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(item.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 이후 [결제]마감 " + item.pay_ConfirmAfterCount.ToString("n0") + "건 등록된 [" + item.su_SupplierName + "]거래처 입니다.");
          if (item.pay_StatementConfirmAfterCount > 0)
            throw new UniServiceException(paymentStatement1.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(item.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 이후 [매입전표]마감 " + item.pay_StatementConfirmAfterCount.ToString("n0") + "건 등록된 [" + item.su_SupplierName + "]거래처 입니다.");
          item.pay_Type = 1;
          if (item.pay_ConfirmStatus == 0)
            item.pay_ConfirmStatus = 1;
          if (item.pay_StatementStatus == 0)
            item.pay_StatementStatus = 2;
          if (item.pay_TypeCustom1 == 0)
            item.pay_TypeCustom1 = 1;
          if (item.pay_TypeCustom2 == 0)
            item.pay_TypeCustom2 = 1;
          item.CalcEndAmount();
          if (pEmployee != null && pEmployee.emp_Code > 0)
          {
            item.pay_InUser = pEmployee.emp_Code;
            item.pay_ModUser = pEmployee.emp_Code;
          }
          if (item.db_status != 0 || item.db_status == 0 && item.IsZero(EnumZeroCheck.ALL))
          {
            if (!await item.ItemSaveAsync())
              return false;
          }
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
              jobEvtProgressing1.Msg = string.Format("[{0}({1})] {2} 작업중 ({3}/{4})", (object) item.su_SupplierName, (object) item.pay_Supplier, (object) viewPro, (object) count, (object) total);
              jobEvtProgressing1.ProgressValue = (double) viewPro / 100.0;
              JobEvtProgressing jobEvtProgressing2 = jobEvtProgressing1;
              paymentStatement1._CallBackMessage(jobEvtProgressing2.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) viewPro));
          }
          item = (PaymentStatement) null;
        }
        return true;
      }
      catch (Exception ex)
      {
        paymentStatement1.message = " " + paymentStatement1.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(paymentStatement1.message);
      }
      return false;
    }

    public bool ProcApply(
      JobEvtInfo pJobInfo,
      string pWorkDesc,
      long p_sh_SiteID,
      int p_sh_StoreCode,
      int p_sh_Supplier,
      DateTime p_sh_ConfirmDate,
      EmployeeView pEmployee)
    {
      bool flag = this._CallBackMessage != null && pJobInfo != null;
      try
      {
        this.pay_SiteID = p_sh_SiteID;
        this.pay_StoreCode = p_sh_StoreCode;
        this.pay_Supplier = p_sh_Supplier;
        this.sh_ConfirmDate = new DateTime?(p_sh_ConfirmDate);
        if (this.DataCheck() != EnumDataCheck.Success)
          throw new Exception("작업 취소 처리.\n" + this.message);
        Log.Logger.DebugColor("\n전표 결제 마감 " + pWorkDesc + " 해당 결제 데이터 검색중 잠시만 ......\n시간이 오래 걸리는 작업 입니다.");
        IList<PaymentStatement> paymentStatementList = this.SelectStatementList();
        if (paymentStatementList == null)
          throw new Exception("조회에러.\n" + this.message);
        int num1 = 0;
        int num2 = 0;
        int count = paymentStatementList.Count;
        foreach (PaymentStatement paymentStatement in (IEnumerable<PaymentStatement>) paymentStatementList)
        {
          if (pJobInfo != null && pJobInfo.IsWorkCancel)
            throw new Exception("작업 취소 처리.");
          paymentStatement.SetAdoDatabase(this.OleDB);
          if (paymentStatement.pay_SiteID == 0L)
            paymentStatement.pay_SiteID = this.pay_SiteID;
          if (paymentStatement.IsConfirm)
            throw new UniServiceException(this.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(paymentStatement.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 [결제]마감 [" + paymentStatement.su_SupplierName + "]거래처 입니다.");
          if (paymentStatement.IsStatementConfirm)
            throw new UniServiceException(this.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(paymentStatement.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 [매입전표]마감 [" + paymentStatement.su_SupplierName + "]거래처 입니다.");
          if (paymentStatement.pay_ConfirmAfterCount > 0)
            throw new UniServiceException(this.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(paymentStatement.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 이후 [결제]마감 " + paymentStatement.pay_ConfirmAfterCount.ToString("n0") + "건 등록된 [" + paymentStatement.su_SupplierName + "]거래처 입니다.");
          if (paymentStatement.pay_StatementConfirmAfterCount > 0)
            throw new UniServiceException(this.TableCode.ToDescription() + " 재고 마감 오류", "[결제일자:" + new DateTime?(paymentStatement.pay_Date.Value).GetDateToStr("yyyy-MM-dd") + "]일 이후 [매입전표]마감 " + paymentStatement.pay_StatementConfirmAfterCount.ToString("n0") + "건 등록된 [" + paymentStatement.su_SupplierName + "]거래처 입니다.");
          paymentStatement.pay_Type = 1;
          if (paymentStatement.pay_ConfirmStatus == 0)
            paymentStatement.pay_ConfirmStatus = 1;
          if (paymentStatement.pay_StatementStatus == 0)
            paymentStatement.pay_StatementStatus = 2;
          if (paymentStatement.pay_TypeCustom1 == 0)
            paymentStatement.pay_TypeCustom1 = 1;
          if (paymentStatement.pay_TypeCustom2 == 0)
            paymentStatement.pay_TypeCustom2 = 1;
          paymentStatement.CalcEndAmount();
          if (pEmployee != null && pEmployee.emp_Code > 0)
          {
            paymentStatement.pay_InUser = pEmployee.emp_Code;
            paymentStatement.pay_ModUser = pEmployee.emp_Code;
          }
          if ((paymentStatement.db_status != 0 || paymentStatement.db_status == 0 && paymentStatement.IsZero(EnumZeroCheck.ALL)) && !paymentStatement.ItemSave())
            return false;
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
              jobEvtProgressing.Title = "지점" + paymentStatement.si_StoreName + " 작업";
              jobEvtProgressing.Msg = string.Format("[{0}({1})] {2} 작업중 ({3}/{4})", (object) paymentStatement.su_SupplierName, (object) paymentStatement.pay_Supplier, (object) num2, (object) num1, (object) count);
              jobEvtProgressing.ProgressValue = (double) num2 / 100.0;
              this._CallBackMessage(jobEvtProgressing.ToJson<JobEvtProgressing>());
            }
            else
              Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<PaymentStatement>> SelectStatementListAsync()
    {
      PaymentStatement paymentStatement1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentStatement1.OleDB.ConnectionUrl, pCommandTimeout: 180);
        rs = new UniOleDbRecordset(db, paymentStatement1.OleDB.CommandTimeout);
        if (paymentStatement1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + paymentStatement1.TableCode.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + paymentStatement1.message + "\n--------------------------------------------------------------------------------------------------");
          Exception exception = new Exception(paymentStatement1.message);
        }
        if (!await rs.OpenAsync(paymentStatement1.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pay_SiteID",
            (object) paymentStatement1.pay_SiteID
          },
          {
            (object) "pay_StoreCode",
            (object) paymentStatement1.pay_StoreCode
          },
          {
            (object) "pay_Supplier",
            (object) paymentStatement1.pay_Supplier
          },
          {
            (object) "sh_ConfirmDate",
            (object) paymentStatement1.sh_ConfirmDate.Value.ToLastDateOfMonth()
          }
        })))
        {
          paymentStatement1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentStatement>) null;
        }
        List<PaymentStatement> lt_list = new List<PaymentStatement>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentStatement paymentStatement2 = paymentStatement1.OleDB.Create<PaymentStatement>();
            if (paymentStatement2.GetFieldValues(rs))
            {
              paymentStatement2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentStatement2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return (IList<PaymentStatement>) lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public IList<PaymentStatement> SelectStatementList()
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
        if (!p_rs.Open(this.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pay_SiteID",
            (object) this.pay_SiteID
          },
          {
            (object) "pay_StoreCode",
            (object) this.pay_StoreCode
          },
          {
            (object) "pay_Supplier",
            (object) this.pay_Supplier
          },
          {
            (object) "sh_ConfirmDate",
            (object) this.sh_ConfirmDate.Value.ToLastDateOfMonth()
          }
        })))
        {
          this.SetErrorInfo(p_rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) p_rs.LastErrorID) + " 내용 : " + p_rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentStatement>) null;
        }
        List<PaymentStatement> paymentStatementList = new List<PaymentStatement>();
        if (p_rs.IsDataRead())
        {
          do
          {
            PaymentStatement paymentStatement = this.OleDB.Create<PaymentStatement>();
            if (paymentStatement.GetFieldValues(p_rs))
            {
              paymentStatement.row_number = paymentStatementList.Count + 1;
              paymentStatementList.Add(paymentStatement);
            }
          }
          while (p_rs.IsDataRead());
        }
        return (IList<PaymentStatement>) paymentStatementList;
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

    public async IAsyncEnumerable<PaymentStatement> SelectStatementEnumerableAsync()
    {
      PaymentStatement paymentStatement1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentStatement1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentStatement1.OleDB.CommandTimeout);
        if (paymentStatement1.DataCheck() != EnumDataCheck.Success)
        {
          Log.Logger.ErrorColor("\n-" + TableCodeType.ProfitLossWorkCnt.ToDescription() + " 작업 데이터 체크\n--------------------------------------------------------------------------------------------------\n" + paymentStatement1.message + "\n--------------------------------------------------------------------------------------------------");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (!await rs.OpenAsync(paymentStatement1.GetSelectQuery((object) new Hashtable()
        {
          {
            (object) "pay_SiteID",
            (object) paymentStatement1.pay_SiteID
          },
          {
            (object) "pay_StoreCode",
            (object) paymentStatement1.pay_StoreCode
          },
          {
            (object) "pay_Supplier",
            (object) paymentStatement1.pay_Supplier
          },
          {
            (object) "sh_ConfirmDate",
            (object) paymentStatement1.sh_ConfirmDate.Value.ToLastDateOfMonth()
          }
        })))
        {
          paymentStatement1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentStatement1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PaymentStatement paymentStatement2 = paymentStatement1.OleDB.Create<PaymentStatement>();
            if (paymentStatement2.GetFieldValues(rs))
            {
              paymentStatement2.row_number = ++row_number;
              yield return paymentStatement2;
            }
          }
          while (await rs.IsDataReadAsync());
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
        this.pay_ConfirmAfterCount = p_rs.GetFieldInt("pay_ConfirmAfterCount");
        this.pay_StatementConfirmAfterCount = p_rs.GetFieldInt("pay_StatementConfirmAfterCount");
        this.db_status = p_rs.GetFieldInt("db_status");
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
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
        DateTime? nullable = new DateTime?();
        PaymentWork paymentWork = new PaymentWork();
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
          if (hashtable2.ContainsKey((object) "sh_ConfirmDate") && Convert.ToInt32(hashtable2[(object) "sh_ConfirmDate"].ToString()) > 0)
            nullable = new DateTime?((DateTime) hashtable2[(object) "sh_ConfirmDate"]);
        }
        if (!nullable.HasValue)
        {
          Exception exception = new Exception("일자 정보 부족");
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (nullable.HasValue)
          stringBuilder.Append(this.ToWithPayContionStatementQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, nullable.Value));
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
        stringBuilder.Append(paymentWork.ToWithSalesLeaChargeRateNotZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithSalesLeaChargeRateZeroQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithStatementReturnQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithSalesQuery((Hashtable) p_param, UbModelBase.UNI_SALES, p_SiteID));
        stringBuilder.Append(paymentWork.ToWithPaymentQuery((Hashtable) p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append("\nSELECT\nSELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,su_SupplierType AS pay_SupplierType" + string.Format(",{0} AS {1},suph_dt_start AS {2},suph_dt_end AS {3}", (object) 1, (object) "pay_Type", (object) "pay_StartDate", (object) "pay_EndDate") + ",suh_PayMethod AS pay_PayMethod,payc_Round AS pay_Round,payc_Turn AS pay_Turn,si_StoreName");
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
  }
}
