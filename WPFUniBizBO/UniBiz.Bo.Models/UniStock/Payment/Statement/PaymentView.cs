// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentView
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
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniStock.Payment.Summary;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentView : TPayment<PaymentView>
  {
    private DateTime? _pay_DateBefore;
    private int _pay_ConfirmStatusBefore;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _si_LocationUseYn;
    private string _si_Email;
    private int _su_HeadSupplier;
    private string _su_HeadName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private string _su_EmailStatement;
    private int _su_PreTaxDiv;
    private int _su_MultiSuplierDiv;
    private string _inEmpName;
    private string _modEmpName;
    private IList<StatementHeaderForPayment> _Lt_Statement;
    private IList<PaymentDetailView> _Lt_Details;

    [JsonIgnore]
    public DateTime? pay_DateBefore
    {
      get => this._pay_DateBefore;
      set
      {
        this._pay_DateBefore = value;
        this.Changed(nameof (pay_DateBefore));
      }
    }

    public int pay_ConfirmStatusBefore
    {
      get => this._pay_ConfirmStatusBefore;
      set
      {
        this._pay_ConfirmStatusBefore = value;
        this.Changed(nameof (pay_ConfirmStatusBefore));
        this.Changed("IsConfirmBefore");
        this.Changed("IsNotConfirmBefore");
        this.Changed("IsDeleteBefore");
      }
    }

    [JsonIgnore]
    public bool IsConfirmBefore => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatusBefore) == EnumConfirmStatus.CONFIRM;

    [JsonIgnore]
    public bool IsNotConfirmBefore => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatusBefore) == EnumConfirmStatus.NOTCONFIRM;

    [JsonIgnore]
    public bool IsDeleteBefore => Enum2StrConverter.ToStatementConfirmStatus(this.pay_ConfirmStatusBefore) == EnumStatementConfirmStatus.Delete;

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

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = value;
        this.Changed(nameof (si_LocationUseYn));
      }
    }

    public string si_Email
    {
      get => this._si_Email;
      set
      {
        this._si_Email = value;
        this.Changed(nameof (si_Email));
      }
    }

    public int su_HeadSupplier
    {
      get => this._su_HeadSupplier;
      set
      {
        this._su_HeadSupplier = value;
        this.Changed(nameof (su_HeadSupplier));
      }
    }

    public string su_HeadName
    {
      get => this._su_HeadName;
      set
      {
        this._su_HeadName = value;
        this.Changed(nameof (su_HeadName));
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

    public int su_SupplierKind
    {
      get => this._su_SupplierKind;
      set
      {
        this._su_SupplierKind = value;
        this.Changed(nameof (su_SupplierKind));
      }
    }

    public string su_SupplierKindDesc => this.su_SupplierKind != 0 ? Enum2StrConverter.ToSupplierKind(this.su_SupplierKind).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = value;
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public string su_EmailStatement
    {
      get => this._su_EmailStatement;
      set
      {
        this._su_EmailStatement = value;
        this.Changed(nameof (su_EmailStatement));
      }
    }

    public int su_PreTaxDiv
    {
      get => this._su_PreTaxDiv;
      set
      {
        this._su_PreTaxDiv = value;
        this.Changed(nameof (su_PreTaxDiv));
      }
    }

    public string su_PreTaxDivDesc => this.su_PreTaxDiv != 0 ? Enum2StrConverter.ToStdPreTax(this.su_PreTaxDiv).ToDescription() : string.Empty;

    public int su_MultiSuplierDiv
    {
      get => this._su_MultiSuplierDiv;
      set
      {
        this._su_MultiSuplierDiv = value;
        this.Changed(nameof (su_MultiSuplierDiv));
      }
    }

    public string su_MultiSuplierDivDesc => this.su_MultiSuplierDiv != 0 ? Enum2StrConverter.ToSupplierMulti(this.su_MultiSuplierDiv).ToDescription() : string.Empty;

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

    [JsonPropertyName("lt_Statement")]
    public IList<StatementHeaderForPayment> Lt_Statement
    {
      get => this._Lt_Statement ?? (this._Lt_Statement = (IList<StatementHeaderForPayment>) new List<StatementHeaderForPayment>());
      set
      {
        this._Lt_Statement = value;
        this.Changed(nameof (Lt_Statement));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<PaymentDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<PaymentDetailView>) new List<PaymentDetailView>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.pay_DateBefore = new DateTime?();
      this.pay_ConfirmStatusBefore = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = string.Empty;
      this.si_Email = string.Empty;
      this.su_HeadSupplier = 0;
      this.su_HeadName = string.Empty;
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_EmailStatement = string.Empty;
      this.su_PreTaxDiv = this.su_MultiSuplierDiv = 0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Statement = (IList<StatementHeaderForPayment>) null;
      this.Lt_Details = (IList<PaymentDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PaymentView();

    public override object Clone()
    {
      PaymentView paymentView = base.Clone() as PaymentView;
      paymentView.pay_DateBefore = this.pay_DateBefore;
      paymentView.pay_ConfirmStatusBefore = this.pay_ConfirmStatusBefore;
      paymentView.si_StoreName = this.si_StoreName;
      paymentView.si_StoreViewCode = this.si_StoreViewCode;
      paymentView.si_UseYn = this.si_UseYn;
      paymentView.si_StoreType = this.si_StoreType;
      paymentView.si_LocationUseYn = this.si_LocationUseYn;
      paymentView.si_Email = this.si_Email;
      paymentView.su_HeadSupplier = this.su_HeadSupplier;
      paymentView.su_HeadName = this.su_HeadName;
      paymentView.su_SupplierName = this.su_SupplierName;
      paymentView.su_SupplierViewCode = this.su_SupplierViewCode;
      paymentView.su_SupplierType = this.su_SupplierType;
      paymentView.su_SupplierKind = this.su_SupplierKind;
      paymentView.su_UseYn = this.su_UseYn;
      paymentView.su_EmailStatement = this.su_EmailStatement;
      paymentView.su_PreTaxDiv = this.su_PreTaxDiv;
      paymentView.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      paymentView.inEmpName = this.inEmpName;
      paymentView.modEmpName = this.modEmpName;
      paymentView.Lt_Statement = (IList<StatementHeaderForPayment>) null;
      if (this.Lt_Statement.Count > 0)
        paymentView.Lt_Statement = this.Lt_Statement;
      paymentView.Lt_Details = (IList<PaymentDetailView>) null;
      if (this.Lt_Details.Count > 0)
        paymentView.Lt_Details = this.Lt_Details;
      return (object) paymentView;
    }

    public void PutData(PaymentView pSource)
    {
      this.PutData((TPayment) pSource);
      this.pay_DateBefore = pSource.pay_DateBefore;
      this.pay_ConfirmStatusBefore = pSource.pay_ConfirmStatusBefore;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.si_Email = pSource.si_Email;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_HeadName = pSource.su_HeadName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.su_EmailStatement = pSource.su_EmailStatement;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Statement = (IList<StatementHeaderForPayment>) null;
      if (pSource.Lt_Statement.Count > 0)
      {
        foreach (StatementHeaderForPayment pSource1 in (IEnumerable<StatementHeaderForPayment>) pSource.Lt_Statement)
        {
          StatementHeaderForPayment headerForPayment = new StatementHeaderForPayment();
          headerForPayment.PutData(pSource1);
          this.Lt_Statement.Add(headerForPayment);
        }
      }
      this.Lt_Details = (IList<PaymentDetailView>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (PaymentDetailView ltDetail in (IEnumerable<PaymentDetailView>) pSource.Lt_Details)
      {
        PaymentDetailView paymentDetailView = new PaymentDetailView();
        paymentDetailView.PutData(ltDetail);
        this.Lt_Details.Add(paymentDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pay_SiteID == 0L)
      {
        this.message = "싸이트(pay_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.pay_Date;
      if (!nullable.HasValue)
      {
        this.message = "결제일(pay_Date)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
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
      if (Enum2StrConverter.ToWriteType(this.pay_Type) == EnumWriteType.NONE)
      {
        this.message = "타입(pay_Type) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      nullable = this.pay_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일자(pay_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.pay_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일자(pay_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.pay_PayMethod == 0)
      {
        this.message = "결제수단(pay_PayMethod)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pay_Round == 0)
      {
        this.message = "회(pay_Round)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pay_Turn == 0)
      {
        this.message = "차(pay_Turn)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus) == EnumConfirmStatus.NONE)
      {
        this.message = "결제확정(pay_ConfirmStatus) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToPayStatementStatus(this.pay_StatementStatus) != EnumPayStatementStatus.None)
        return EnumDataCheck.Success;
      this.message = "전표확정(pay_StatementStatus) " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      EnumDataCheck enumDataCheck = this.DataCheck();
      return enumDataCheck != EnumDataCheck.Success ? enumDataCheck : EnumDataCheck.Success;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsPayment)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (this.IsConfirmBefore && !p_app_employee.IsPaymentConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 확정 결제 전표 변경 불가.";
        return false;
      }
      if (this.IsDeleteBefore && !p_app_employee.IsPaymentDelete)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 삭제 결제 전표 변경 불가.";
        return false;
      }
      if (this.IsConfirm && !p_app_employee.IsPaymentConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 결제 전표 확정  불가.";
        return false;
      }
      if (this.IsConfirmBefore && this.IsConfirm)
      {
        this.message = "결제 확정 상태 변경 불가.\n - 결제 미확정 변경 후 변경 가능.";
        return false;
      }
      if (!this.IsDeleteBefore || !this.IsConfirm)
        return true;
      this.message = "결제 삭제 상태 에서 확정 불가.\n -  결제 미확정 변경 후 확정 가능.";
      return false;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = this.pay_Date.Value.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) this.pay_StoreCode);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pay_Code), " + str + ")+1 AS pay_Code" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "pay_Code", (object) intFormat) + string.Format(" AND (({0}%100000000)/10000)={1}", (object) "pay_Code", (object) this.pay_StoreCode);
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
          this.pay_Code = uniOleDbRecordset.GetFieldLong(0);
        return this.pay_Code > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      PaymentView paymentView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(paymentView.CreateCodeQuery()))
        {
          paymentView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          paymentView.pay_Code = rs.GetFieldLong(0);
        return paymentView.pay_Code > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public void CalcSum(bool p_isCalcDetail)
    {
      if (this.Lt_Details.Count == 0)
        return;
      this.pay_PayAmount = 0.0;
      this.pay_DeductionAmount = 0.0;
      foreach (PaymentDetailView ltDetail in (IEnumerable<PaymentDetailView>) this.Lt_Details)
      {
        if (ltDetail.IsConfirm)
        {
          if (p_isCalcDetail)
            ltDetail.CalcSum();
          if (ltDetail.IsPayment)
            this.pay_PayAmount += ltDetail.pd_PayAmount;
          else if (ltDetail.IsDeduction)
            this.pay_DeductionAmount += ltDetail.pd_PayAmount;
        }
      }
      this.pay_PayAmount = CalcHelper.CalcDoubleToFormatDouble(this.pay_PayAmount);
      this.pay_DeductionAmount = CalcHelper.CalcDoubleToFormatDouble(this.pay_DeductionAmount);
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
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
          if (this.pay_SiteID == 0L)
            this.pay_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pay_Code == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        this.CalcSum(true);
        this.CalcEndAmount();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
        if (!this.InsertMonth(p_db, p_app_employee))
          throw new Exception(this.message);
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
      bool p_isFirstTime)
    {
      PaymentView paymentView = this;
      try
      {
        paymentView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentView.DataCheck(p_db))
            throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (paymentView.pay_SiteID == 0L)
            paymentView.pay_SiteID = p_app_employee.emp_SiteID;
          if (!paymentView.IsPermit(p_app_employee))
            throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (paymentView.pay_Code == 0L)
        {
          if (!await paymentView.CreateCodeAsync(p_db))
            throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        paymentView.CalcSum(true);
        paymentView.CalcEndAmount();
        if (!await paymentView.InsertAsync())
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 등록 오류");
        if (!await paymentView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(paymentView.message);
        if (!await paymentView.InsertMonthAsync(p_db, p_app_employee))
          throw new Exception(paymentView.message);
        paymentView.db_status = 4;
        paymentView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
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
        if (this.pay_Code == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 결제코드(pay_Code) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        this.CalcSum(true);
        this.CalcEndAmount();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
        if (!this.InsertMonth(p_db, p_app_employee))
          throw new Exception(this.message);
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
      bool p_isFirstTime)
    {
      PaymentView paymentView = this;
      try
      {
        paymentView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentView.DataCheck(p_db))
            throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!paymentView.IsPermit(p_app_employee))
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 권한 검사 실패");
        if (paymentView.pay_Code == 0L)
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 결제코드(pay_Code) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        paymentView.CalcSum(true);
        paymentView.CalcEndAmount();
        if (!await paymentView.UpdateAsync())
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 변경 오류");
        if (!await paymentView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(paymentView.message);
        if (!await paymentView.InsertMonthAsync(p_db, p_app_employee))
          throw new Exception(paymentView.message);
        paymentView.db_status = 4;
        paymentView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentView.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      PaymentView paymentView = this;
      try
      {
        paymentView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != paymentView.DataCheck(p_db))
            throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!paymentView.IsPermit(p_app_employee))
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 권한 검사 실패");
        if (paymentView.pay_Code == 0L)
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 결제코드(pay_Code) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await paymentView.DeleteAsync())
          throw new UniServiceException(paymentView.message, paymentView.TableCode.ToDescription() + " 삭제 오류");
        if (!await paymentView.ExecuteAsync(new TPaymentDetail().DeleteQuery(paymentView.pay_Code, 0, paymentView.pay_SiteID)))
          throw new UniServiceException(paymentView.message, TableCodeType.BookmarkGoodsList.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        paymentView.db_status = 4;
        paymentView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        paymentView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        paymentView.message = ex.Message;
      }
      return false;
    }

    public virtual bool InsertDetails(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Details.Count == 0)
        return true;
      int num = 1;
      foreach (PaymentDetailView ltDetail in (IEnumerable<PaymentDetailView>) this.Lt_Details)
      {
        if (this.pay_EndDate.Value.ToIntFormat() > ltDetail.pd_ConfirmDate.Value.ToIntFormat())
        {
          this.message = string.Format("{0}행", (object) ltDetail.pd_Seq) + " 확정일자[" + ltDetail.pd_ConfirmDate.GetDateToStr("yyyy-MM-dd") + "] < 마감일자[" + this.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "] 등록 에러";
          throw new Exception(this.message);
        }
        if (ltDetail.pd_SiteID == 0L)
          ltDetail.pd_SiteID = this.pay_SiteID;
        if (ltDetail.pd_Seq > 0)
        {
          if (num != ltDetail.pd_Seq)
            num = ltDetail.pd_Seq;
        }
        else
        {
          ltDetail.pd_Seq = num;
          ltDetail.db_status = 1;
        }
        if (ltDetail.pd_PaymentID == 0L)
        {
          ltDetail.pd_PaymentID = this.pay_Code;
          ltDetail.db_status = 1;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (ltDetail.IsNew)
            ltDetail.pd_InUser = p_app_employee.emp_Code;
          else if (ltDetail.IsUpdate)
            ltDetail.pd_ModUser = p_app_employee.emp_Code;
        }
        ltDetail.SetAdoDatabase(p_db);
        if (ltDetail.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          this.message = ltDetail.message;
          return false;
        }
        if (ltDetail.IsNew)
        {
          if (!ltDetail.Insert())
          {
            this.message = string.Format("{0}행 [메모:{1} - {2}] 신규등록 에러", (object) ltDetail.pd_Seq, (object) ltDetail.pd_Memo, (object) ltDetail.pd_Amount.ToString("n0"));
            throw new Exception(this.message);
          }
        }
        else if (ltDetail.IsUpdate && !ltDetail.Update((UbModelBase) null))
        {
          this.message = string.Format("{0}행 [메모:{1} - {2}] 데이터 변경 에러", (object) ltDetail.pd_Seq, (object) ltDetail.pd_Memo, (object) ltDetail.pd_Amount.ToString("n0"));
          throw new Exception(this.message);
        }
        ++num;
      }
      return true;
    }

    public virtual async Task<bool> InsertDetailsAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      PaymentView paymentView = this;
      if (paymentView.Lt_Details.Count == 0)
        return true;
      int nCount = 1;
      foreach (PaymentDetailView ltDetail in (IEnumerable<PaymentDetailView>) paymentView.Lt_Details)
      {
        PaymentDetailView item = ltDetail;
        DateTime? nullable = paymentView.pay_EndDate;
        int intFormat1 = nullable.Value.ToIntFormat();
        nullable = item.pd_ConfirmDate;
        int intFormat2 = nullable.Value.ToIntFormat();
        if (intFormat1 > intFormat2)
        {
          paymentView.message = string.Format("{0}행", (object) item.pd_Seq) + " 확정일자[" + item.pd_ConfirmDate.GetDateToStr("yyyy-MM-dd") + "] < 마감일자[" + paymentView.pay_EndDate.GetDateToStr("yyyy-MM-dd") + "] 등록 에러";
          throw new Exception(paymentView.message);
        }
        if (item.pd_SiteID == 0L)
          item.pd_SiteID = paymentView.pay_SiteID;
        if (item.pd_Seq > 0)
        {
          if (nCount != item.pd_Seq)
            nCount = item.pd_Seq;
        }
        else
        {
          item.pd_Seq = nCount;
          item.db_status = 1;
        }
        if (item.pd_PaymentID == 0L)
        {
          item.pd_PaymentID = paymentView.pay_Code;
          item.db_status = 1;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (item.IsNew)
            item.pd_InUser = p_app_employee.emp_Code;
          else if (item.IsUpdate)
            item.pd_ModUser = p_app_employee.emp_Code;
        }
        item.SetAdoDatabase(p_db);
        if (item.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          paymentView.message = item.message;
          return false;
        }
        if (item.IsNew)
        {
          if (!await item.InsertAsync())
          {
            paymentView.message = string.Format("{0}행 [메모:{1} - {2}] 신규등록 에러", (object) item.pd_Seq, (object) item.pd_Memo, (object) item.pd_Amount.ToString("n0"));
            throw new Exception(paymentView.message);
          }
        }
        else if (item.IsUpdate)
        {
          if (!await item.UpdateAsync((UbModelBase) null))
          {
            paymentView.message = string.Format("{0}행 [메모:{1} - {2}] 데이터 변경 에러", (object) item.pd_Seq, (object) item.pd_Memo, (object) item.pd_Amount.ToString("n0"));
            throw new Exception(paymentView.message);
          }
        }
        ++nCount;
        item = (PaymentDetailView) null;
      }
      return true;
    }

    public virtual bool InsertMonth(UniOleDatabase p_db, EmployeeView p_app_employee) => throw new Exception("월 결제 기초 등록 에러." + string.Format("\n[{0}],[{1}],[{2}],[{3}]", (object) new DateTime?(this.pay_EndDate.Value).GetDateToStr("yyyy-MM-dd"), (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_SiteID));

    public virtual async Task<bool> InsertMonthAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      PaymentView paymentView = this;
      PaymentMonthWork paymentMonthWork = p_db.Create<PaymentMonthWork>();
      DateTime? payEndDate = paymentView.pay_EndDate;
      DateTime p_WorkOriginDate = payEndDate.Value;
      int payStoreCode = paymentView.pay_StoreCode;
      int paySupplier = paymentView.pay_Supplier;
      long paySiteId = paymentView.pay_SiteID;
      if (!await paymentMonthWork.ProcNextAsync((JobEvtInfo) null, "월 결제 기초 등록", p_WorkOriginDate, payStoreCode, paySupplier, paySiteId))
      {
        object[] objArray = new object[4];
        payEndDate = paymentView.pay_EndDate;
        objArray[0] = (object) new DateTime?(payEndDate.Value).GetDateToStr("yyyy-MM-dd");
        objArray[1] = (object) paymentView.pay_StoreCode;
        objArray[2] = (object) paymentView.pay_Supplier;
        objArray[3] = (object) paymentView.pay_SiteID;
        throw new Exception("월 결제 기초 등록 에러." + string.Format("\n[{0}],[{1}],[{2}],[{3}]", objArray));
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pay_DateBefore = p_rs.GetFieldDateTime("pay_DateBefore");
      this.pay_ConfirmStatusBefore = p_rs.GetFieldInt("pay_ConfirmStatus");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.si_Email = p_rs.GetFieldString("si_Email");
      this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
      this.su_HeadName = p_rs.GetFieldString("su_HeadName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_EmailStatement = p_rs.GetFieldString("su_EmailStatement");
      this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
      this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<PaymentView> SelectOneAsync(long p_pay_Code, long p_pay_SiteID = 0)
    {
      PaymentView paymentView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pay_Code",
          (object) p_pay_Code
        }
      };
      if (p_pay_SiteID > 0L)
        p_param.Add((object) "pay_SiteID", (object) p_pay_SiteID);
      return await paymentView.SelectOneTAsync<PaymentView>((object) p_param);
    }

    public PaymentView SelectOne(long p_pay_Code, long p_pay_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pay_Code",
          (object) p_pay_Code
        }
      };
      if (p_pay_SiteID > 0L)
        p_param.Add((object) "pay_SiteID", (object) p_pay_SiteID);
      return this.SelectOneT<PaymentView>((object) p_param);
    }

    public async Task<IList<PaymentView>> SelectListAsync(object p_param)
    {
      PaymentView paymentView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentView1.GetSelectQuery(p_param)))
        {
          paymentView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentView>) null;
        }
        IList<PaymentView> lt_list = (IList<PaymentView>) new List<PaymentView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentView paymentView2 = paymentView1.OleDB.Create<PaymentView>();
            if (paymentView2.GetFieldValues(rs))
            {
              paymentView2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<PaymentView> SelectEnumerableAsync(object p_param)
    {
      PaymentView paymentView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentView1.GetSelectQuery(p_param)))
        {
          paymentView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PaymentView paymentView2 = paymentView1.OleDB.Create<PaymentView>();
            if (paymentView2.GetFieldValues(rs))
            {
              paymentView2.row_number = ++row_number;
              yield return paymentView2;
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

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num = 0;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pay_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeadSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n SELECT  pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_StartDate,pay_EndDate,pay_PayMethod,pay_Round,pay_Turn,pay_ConfirmStatus,pay_StatementStatus,pay_TypeCustom1,pay_TypeCustom2,pay_BaseAmount,pay_BuyAmount,pay_BuyTax,pay_BuyVat,pay_BuyFree,pay_BuyReturnAmount,pay_BuyReturnTax,pay_BuyReturnVat,pay_BuyReturnFree,pay_Deposit,pay_SaleAmount,pay_SaleTax,pay_SaleVat,pay_SaleFree,pay_DeductionAmount,pay_PayAmount,pay_AddAmount,pay_EndAmount,pay_InDate,pay_InUser,pay_ModDate,pay_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_Email,si_LocationUseYn\n,su_HeadSupplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement\n,inEmpName,modEmpName");
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n LEFT OUTER JOIN T_STORE ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON pay_Supplier=su_Supplier AND pay_SiteID=su_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON pay_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON pay_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Supplier,pay_Date");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY pay_Supplier,pay_StoreCode,pay_Date");
              break;
            case 3:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Date,pay_Supplier");
              break;
            case 4:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Supplier,pay_Date DESC");
              break;
            case 5:
              stringBuilder.Append(" ORDER BY pay_Supplier,pay_StoreCode,pay_Date DESC");
              break;
            case 6:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Date DESC,pay_Supplier");
              break;
            default:
              stringBuilder.Append(" ORDER BY pay_Code");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pay_Code");
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

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn,si_Email" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithHeadSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER_HEAD AS (SELECT su_Supplier AS head_su_Supplier,su_SiteID AS head_su_SiteID,su_SupplierViewCode AS head_su_SupplierViewCode,su_SupplierName AS head_su_SupplierName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeModQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pay_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithPayContionStatementQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      DateTime dt_sh_ConfirmDate)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        string dateToStr1 = new DateTime?(dt_sh_ConfirmDate.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
        string str1 = dateToStr1.DateAdd("-1", EnumDbAddType.DAY).DateAdd("payc_CalcStartDay", EnumDbAddType.DAY);
        string dateToStr2 = new DateTime?(dt_sh_ConfirmDate.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'");
        string str2 = dateToStr2.DateAdd("1", EnumDbAddType.MONTH).DateAdd("-1", EnumDbAddType.DAY);
        string str3 = dateToStr2.DateAdd("payc_CalcEndDay-1", EnumDbAddType.DAY);
        string str4 = dateToStr1.DateAdd("payc_CalcStartMonth*-1+1", EnumDbAddType.MONTH).DateAdd("-1", EnumDbAddType.DAY);
        string str5 = dateToStr1.DateAdd("payc_CalcStartMonth*-1", EnumDbAddType.MONTH).DateAdd("payc_PaymentDay-1", EnumDbAddType.DAY);
        stringBuilder.Append("\n,T_PAY_CONTION AS (\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay," + str1 + " AS pc_dt_start" + string.Format(",CASE WHEN {0}>{1} THEN ", (object) "payc_CalcEndDay", (object) 28) + " " + str2 + " ELSE  " + str3 + " END AS pc_dt_end," + str4 + " AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}!={1} AND {2}={3} AND {4}>{5}", (object) "payc_ID", (object) 9999, (object) "payc_SiteID", (object) p_SiteID, (object) "payc_PaymentDay", (object) 28) + "\nUNION ALL\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay," + str1 + " AS pc_dt_start" + string.Format(",CASE WHEN {0}>{1} THEN ", (object) "payc_CalcEndDay", (object) 28) + " " + str2 + " ELSE  " + str3 + " END AS pc_dt_end," + str5 + " AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}!={1} AND {2}={3} AND {4}<={5}", (object) "payc_ID", (object) 9999, (object) "payc_SiteID", (object) p_SiteID, (object) "payc_PaymentDay", (object) 28) + ")\n");
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
      DateTime dt_pay_Date)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string dateToStr1 = new DateTime?(dt_pay_Date.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
      string str1 = dateToStr1.DateAdd("payc_CalcStartMonth", EnumDbAddType.MONTH).DateAdd("payc_CalcStartDay-1", EnumDbAddType.DAY);
      string dateToStr2 = new DateTime?(dt_pay_Date.ToFirstDateOfMonth()).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'");
      string str2 = dateToStr2.DateAdd("payc_CalcStartMonth+1", EnumDbAddType.MONTH).DateAdd("-1", EnumDbAddType.DAY);
      string str3 = dateToStr2.DateAdd("payc_CalcEndMonth", EnumDbAddType.MONTH).DateAdd("payc_CalcEndDay-1", EnumDbAddType.DAY);
      string str4 = dateToStr1.DateAdd("1", EnumDbAddType.MONTH).DateAdd("-1", EnumDbAddType.DAY);
      string str5 = dateToStr1.DateAdd("payc_PaymentDay-1", EnumDbAddType.DAY);
      stringBuilder.Append("\n,T_PAY_CONTION AS (\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay," + str1 + " AS pc_dt_start" + string.Format(",CASE WHEN {0}>{1} THEN ", (object) "payc_CalcEndDay", (object) 28) + " " + str2 + " ELSE  " + str3 + " END AS pc_dt_end," + str4 + " AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}!={1} AND {2}={3} AND {4}>{5}", (object) "payc_ID", (object) 9999, (object) "payc_SiteID", (object) p_SiteID, (object) "payc_PaymentDay", (object) 28) + "\nUNION ALL\nSELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay," + str1 + " AS pc_dt_start" + string.Format(",CASE WHEN {0}>{1} THEN ", (object) "payc_CalcEndDay", (object) 28) + " " + str2 + " ELSE  " + str3 + " END AS pc_dt_end," + str5 + " AS pc_pay_day " + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}!={1} AND {2}={3} AND {4}<={5}", (object) "payc_ID", (object) 9999, (object) "payc_SiteID", (object) p_SiteID, (object) "payc_PaymentDay", (object) 28) + ")\n");
      return stringBuilder.ToString();
    }

    public string ToWithSupplierHistoryQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("\n,T_SUPPLIER_HISTORY AS (\nSELECT suh_ID,suh_SiteID,suh_Supplier,suh_StoreCode,suh_StartDate,suh_EndDate,suh_PayMethod,suh_PayCondition,pc_dt_start,pc_dt_end,pc_pay_day,CASE WHEN pc_dt_start>=suh_StartDate THEN pc_dt_start ELSE suh_StartDate END AS suph_dt_start,CASE WHEN pc_dt_end<=suh_EndDate THEN pc_dt_end ELSE suh_EndDate END AS suph_dt_end,su_SupplierType AS suph_su_SupplierType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SupplierHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SUPPLIER ON suh_Supplier=su_Supplier ON suh_SiteID=su_SiteID\nINNER JOIN T_PAY_CONTION ON suh_PayCondition=payc_ID AND suh_SiteID=payc_SiteID AND ( (pc_dt_start>=suh_StartDate AND pc_dt_start<=suh_EndDate)     OR (pc_dt_end>=suh_StartDate AND pc_dt_end<=suh_EndDate)     OR (pc_dt_start<=suh_StartDate AND pc_dt_end>=suh_EndDate) )");
      if (p_param.ContainsKey((object) "sh_ConfirmDate"))
      {
        string dateToStr = new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
        stringBuilder.Append(" AND (CASE WHEN pc_dt_start>=suh_StartDate THEN pc_dt_start ELSE suh_StartDate END)<=" + dateToStr + " AND (CASE WHEN pc_dt_end<=suh_EndDate THEN pc_dt_end ELSE suh_EndDate END)>=" + dateToStr);
      }
      if (p_param.ContainsKey((object) "pay_Date"))
      {
        new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
        stringBuilder.Append(" AND pc_pay_day>=" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND pc_pay_day<=" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
      }
      stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "suh_SiteID", (object) p_SiteID));
      if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_Supplier", p_param[(object) "pay_Supplier"]));
      if (p_param.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_StoreCode", p_param[(object) "pay_StoreCode"]));
      stringBuilder.Append(")\n");
      return stringBuilder.ToString();
    }
  }
}
