// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.PaymentDetailView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class PaymentDetailView : TPaymentDetail<PaymentDetailView>
  {
    private DateTime? _pd_ConfirmDateBefore;
    private int _pd_ConfirmStatusBefore;
    private DateTime? _pay_Date;
    protected int _pay_StoreCode;
    protected int _pay_Supplier;
    private DateTime? _pay_EndDate;
    private int _pay_ConfirmStatus;
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
    private int _su_DeductionDayDiv;
    private string _inEmpName;
    private string _modEmpName;
    private IList<PaymentDetailView> _Lt_History;

    [JsonIgnore]
    public DateTime? pd_ConfirmDateBefore
    {
      get => this._pd_ConfirmDateBefore;
      set
      {
        this._pd_ConfirmDateBefore = value;
        this.Changed(nameof (pd_ConfirmDateBefore));
      }
    }

    public int pd_ConfirmStatusBefore
    {
      get => this._pd_ConfirmStatusBefore;
      set
      {
        this._pd_ConfirmStatusBefore = value;
        this.Changed(nameof (pd_ConfirmStatusBefore));
        this.Changed("IsConfirmBefore");
        this.Changed("IsNotConfirmBefore");
        this.Changed("IsDeleteBefore");
      }
    }

    [JsonIgnore]
    public bool IsConfirmBefore => Enum2StrConverter.ToConfirmStatus(this.pd_ConfirmStatusBefore) == EnumConfirmStatus.CONFIRM;

    [JsonIgnore]
    public bool IsNotConfirmBefore => Enum2StrConverter.ToConfirmStatus(this.pd_ConfirmStatusBefore) == EnumConfirmStatus.NOTCONFIRM;

    [JsonIgnore]
    public bool IsDeleteBefore => Enum2StrConverter.ToStatementConfirmStatus(this.pd_ConfirmStatusBefore) == EnumStatementConfirmStatus.Delete;

    public DateTime? pay_Date
    {
      get => this._pay_Date;
      set
      {
        this._pay_Date = value;
        this.Changed(nameof (pay_Date));
      }
    }

    public virtual int pay_StoreCode
    {
      get => this._pay_StoreCode;
      set
      {
        this._pay_StoreCode = value;
        this.Changed(nameof (pay_StoreCode));
      }
    }

    public virtual int pay_Supplier
    {
      get => this._pay_Supplier;
      set
      {
        this._pay_Supplier = value;
        this.Changed(nameof (pay_Supplier));
      }
    }

    public DateTime? pay_EndDate
    {
      get => this._pay_EndDate;
      set
      {
        this._pay_EndDate = value;
        this.Changed(nameof (pay_EndDate));
      }
    }

    public int pay_ConfirmStatus
    {
      get => this._pay_ConfirmStatus;
      set
      {
        this._pay_ConfirmStatus = value;
        this.Changed(nameof (pay_ConfirmStatus));
        this.Changed("pay_ConfirmStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
      }
    }

    public string pay_ConfirmStatusDesc => this.pay_ConfirmStatus != 0 ? Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus).ToDescription() : string.Empty;

    public bool IsHeaderConfirm => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus) == EnumConfirmStatus.CONFIRM;

    public bool IsHeaderNotConfirm => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus) == EnumConfirmStatus.NOTCONFIRM;

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

    public int su_DeductionDayDiv
    {
      get => this._su_DeductionDayDiv;
      set
      {
        this._su_DeductionDayDiv = value;
        this.Changed(nameof (su_DeductionDayDiv));
      }
    }

    public string su_DeductionDayDivDesc => this.su_DeductionDayDiv != 0 ? Enum2StrConverter.ToSupplierDeductionDayType(this.su_DeductionDayDiv).ToDescription() : string.Empty;

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

    [JsonPropertyName("lt_History")]
    public IList<PaymentDetailView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<PaymentDetailView>) new List<PaymentDetailView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.pd_ConfirmDateBefore = new DateTime?();
      this.pd_ConfirmStatusBefore = 0;
      this.pay_Date = new DateTime?();
      this.pay_StoreCode = this.pay_Supplier = this.pay_ConfirmStatus = 0;
      this.pay_EndDate = new DateTime?();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = "N";
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_PreTaxDiv = this.su_MultiSuplierDiv = this.su_DeductionDayDiv = 0;
      this.inEmpName = this.modEmpName = string.Empty;
      this.Lt_History = (IList<PaymentDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PaymentDetailView();

    public override object Clone()
    {
      PaymentDetailView paymentDetailView = base.Clone() as PaymentDetailView;
      paymentDetailView.pd_ConfirmDateBefore = this.pd_ConfirmDateBefore;
      paymentDetailView.pd_ConfirmStatusBefore = this.pd_ConfirmStatusBefore;
      paymentDetailView.pay_Date = this.pay_Date;
      paymentDetailView.pay_StoreCode = this.pay_StoreCode;
      paymentDetailView.pay_Supplier = this.pay_Supplier;
      paymentDetailView.pay_EndDate = this.pay_EndDate;
      paymentDetailView.pay_ConfirmStatus = this.pay_ConfirmStatus;
      paymentDetailView.si_StoreName = this.si_StoreName;
      paymentDetailView.si_StoreViewCode = this.si_StoreViewCode;
      paymentDetailView.si_UseYn = this.si_UseYn;
      paymentDetailView.si_StoreType = this.si_StoreType;
      paymentDetailView.si_LocationUseYn = this.si_LocationUseYn;
      paymentDetailView.su_SupplierName = this.su_SupplierName;
      paymentDetailView.su_SupplierViewCode = this.su_SupplierViewCode;
      paymentDetailView.su_UseYn = this.su_UseYn;
      paymentDetailView.su_HeadSupplier = this.su_HeadSupplier;
      paymentDetailView.su_SupplierType = this.su_SupplierType;
      paymentDetailView.su_SupplierKind = this.su_SupplierKind;
      paymentDetailView.su_PreTaxDiv = this.su_PreTaxDiv;
      paymentDetailView.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      paymentDetailView.su_DeductionDayDiv = this.su_DeductionDayDiv;
      paymentDetailView.inEmpName = this.inEmpName;
      paymentDetailView.modEmpName = this.modEmpName;
      paymentDetailView.Lt_History = this.Lt_History;
      return (object) paymentDetailView;
    }

    public void PutData(PaymentDetailView pSource)
    {
      this.PutData((TPaymentDetail) pSource);
      this.pd_ConfirmDateBefore = pSource.pd_ConfirmDateBefore;
      this.pd_ConfirmStatusBefore = pSource.pd_ConfirmStatusBefore;
      this.pay_Date = pSource.pay_Date;
      this.pay_StoreCode = pSource.pay_StoreCode;
      this.pay_Supplier = pSource.pay_Supplier;
      this.pay_EndDate = pSource.pay_EndDate;
      this.pay_ConfirmStatus = pSource.pay_ConfirmStatus;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_UseYn = pSource.su_UseYn;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.su_DeductionDayDiv = pSource.su_DeductionDayDiv;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_History = (IList<PaymentDetailView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (PaymentDetailView pSource1 in (IEnumerable<PaymentDetailView>) pSource.Lt_History)
      {
        PaymentDetailView paymentDetailView = new PaymentDetailView();
        paymentDetailView.PutData(pSource1);
        this.Lt_History.Add(paymentDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pd_SiteID == 0L)
      {
        this.message = "싸이트(pd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pd_PaymentID == 0L)
      {
        this.message = "결제코드(pd_PaymentID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.pd_ConfirmDate.HasValue)
      {
        this.message = "확정일자(pd_ConfirmDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (Enum2StrConverter.ToStatementConfirmStatus(this.pd_ConfirmStatus) == EnumStatementConfirmStatus.None)
      {
        this.message = "확정타입(pd_ConfirmStatus) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToInOutDiv(this.pd_InOutDiv) == EnumInOutDiv.None)
      {
        this.message = "입출금(pd_InOutDiv) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToPaymentStatementDiv(this.pd_StatementType) == EnumPaymentStatementDiv.NONE)
      {
        this.message = "종목(pd_StatementType) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (this.pd_ReasonType == 0)
      {
        this.message = "타입(pd_ReasonType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pd_WriteType != 0)
        return EnumDataCheck.Success;
      this.message = "작성(pd_WriteType)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    public EnumDataCheck DataCheckOn(UniOleDatabase p_db) => this.DataCheck(p_db);

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
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pd_Seq), 0)+1 AS pd_Seq" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "pd_PaymentID", (object) this.pd_PaymentID);
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
          this.pd_Seq = uniOleDbRecordset.GetFieldInt(0);
        return this.pd_Seq > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      PaymentDetailView paymentDetailView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(paymentDetailView.CreateCodeQuery()))
        {
          paymentDetailView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentDetailView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          paymentDetailView.pd_Seq = rs.GetFieldInt(0);
        return paymentDetailView.pd_Seq > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public virtual void CalcSum()
    {
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
          if (this.pd_SiteID == 0L)
            this.pd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pd_Seq == 0 && !this.CreateCode(p_db))
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
      PaymentDetailView paymentDetailView = this;
      try
      {
        paymentDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentDetailView.DataCheck(p_db))
            throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (paymentDetailView.pd_SiteID == 0L)
            paymentDetailView.pd_SiteID = p_app_employee.emp_SiteID;
          if (!paymentDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (paymentDetailView.pd_Seq == 0)
        {
          if (!await paymentDetailView.CreateCodeAsync(p_db))
            throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await paymentDetailView.InsertAsync())
          throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 등록 오류");
        paymentDetailView.db_status = 4;
        paymentDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentDetailView.message = ex.Message;
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
        if (this.pd_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(pd_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      PaymentDetailView paymentDetailView = this;
      try
      {
        paymentDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentDetailView.DataCheck(p_db))
            throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!paymentDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (paymentDetailView.pd_Seq == 0)
          throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 순번(pd_Seq) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await paymentDetailView.UpdateAsync())
          throw new UniServiceException(paymentDetailView.message, paymentDetailView.TableCode.ToDescription() + " 변경 오류");
        paymentDetailView.db_status = 4;
        paymentDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentDetailView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pd_ConfirmDateBefore = p_rs.GetFieldDateTime("pd_ConfirmDate");
      this.pd_ConfirmStatusBefore = p_rs.GetFieldInt("pd_ConfirmStatus");
      this.pay_Date = p_rs.GetFieldDateTime("pay_Date");
      this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
      this.pay_Supplier = p_rs.GetFieldInt("pay_Supplier");
      this.pay_ConfirmStatus = p_rs.GetFieldInt("pay_ConfirmStatus");
      this.pay_EndDate = p_rs.GetFieldDateTime("pay_EndDate");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
      this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
      this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
      this.su_DeductionDayDiv = p_rs.GetFieldInt("su_DeductionDayDiv");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<PaymentDetailView> SelectOneAsync(
      long p_pd_PaymentID,
      int p_pd_Seq,
      long p_pd_SiteID = 0)
    {
      PaymentDetailView paymentDetailView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pd_PaymentID",
          (object) p_pd_PaymentID
        },
        {
          (object) "pd_Seq",
          (object) p_pd_Seq
        }
      };
      if (p_pd_SiteID > 0L)
        p_param.Add((object) "pd_SiteID", (object) p_pd_SiteID);
      return await paymentDetailView.SelectOneTAsync<PaymentDetailView>((object) p_param);
    }

    public async Task<IList<PaymentDetailView>> SelectListAsync(object p_param)
    {
      PaymentDetailView paymentDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentDetailView1.GetSelectQuery(p_param)))
        {
          paymentDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentDetailView>) null;
        }
        IList<PaymentDetailView> lt_list = (IList<PaymentDetailView>) new List<PaymentDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentDetailView paymentDetailView2 = paymentDetailView1.OleDB.Create<PaymentDetailView>();
            if (paymentDetailView2.GetFieldValues(rs))
            {
              paymentDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<PaymentDetailView> SelectEnumerableAsync(object p_param)
    {
      PaymentDetailView paymentDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentDetailView1.GetSelectQuery(p_param)))
        {
          paymentDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PaymentDetailView paymentDetailView2 = paymentDetailView1.OleDB.Create<PaymentDetailView>();
            if (paymentDetailView2.GetFieldValues(rs))
            {
              paymentDetailView2.row_number = ++row_number;
              yield return paymentDetailView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pd_Memo", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable2.ContainsKey((object) "pd_SiteID") && Convert.ToInt64(hashtable2[(object) "pd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pd_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeaderQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        stringBuilder.Append("\nSELECT  pd_PaymentID,pd_Seq,pd_SiteID,pd_ConfirmDate,pd_ConfirmStatus,pd_InOutDiv,pd_StatementType,pd_ReasonType,pd_WriteType,pd_Amount,pd_PayAmount,pd_DeductAmount,pd_Memo,pd_TransmitStatus,pd_TransmitDate,pd_InDate,pd_InUser,pd_ModDate,pd_ModUser\n,pay_Date,pay_StoreCode,pay_Supplier,pay_ConfirmStatus,pay_EndDate\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn\n,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON pd_PaymentID=pay_Code AND pd_SiteID=pay_SiteID\nINNER JOIN T_STORE ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=pay_Supplier AND pay_SiteID=gdh_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON pd_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON pd_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Supplier,pay_Date,pd_PaymentID,pd_Seq");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY pay_Supplier,pay_StoreCode,pay_Date,pd_PaymentID,pd_Seq");
              break;
            case 3:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Date,pay_Supplier,pd_PaymentID,pd_Seq");
              break;
            case 4:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Supplier,pay_Date DESC,pd_PaymentID,pd_Seq");
              break;
            case 5:
              stringBuilder.Append(" ORDER BY pay_Supplier,pay_StoreCode,pay_Date DESC,pd_PaymentID,pd_Seq");
              break;
            case 6:
              stringBuilder.Append(" ORDER BY pay_StoreCode,pay_Date DESC,pay_Supplier,pd_PaymentID,pd_Seq");
              break;
            default:
              stringBuilder.Append(" ORDER BY pd_PaymentID,pd_Seq");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pd_PaymentID,pd_Seq");
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
        stringBuilder.Append("WITH T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
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
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
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
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement,su_DeductionDayDiv,su_NewStatementYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pd_SiteID"))
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
          stringBuilder.Append("\n");
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
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
        stringBuilder.Append("\n,T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pd_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
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
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pd_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithHeaderQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HEADER AS (\nSELECT pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_StartDate,pay_EndDate" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Payment, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pd_SiteID"))
            p_param1.Add((object) "pay_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pd_PaymentID") && !p_param1.ContainsKey((object) "pay_Code"))
            p_param1.Add((object) "pay_Code", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Code") && !p_param1.ContainsKey((object) "pay_Code"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date_BEGIN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Date_END_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Type"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Type_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_PayMethod"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_PayMethod_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Round"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_Turn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_ConfirmStatus"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_ConfirmStatus_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_StatementStatus"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_StatementStatus_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_TypeCustom1"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pay_TypeCustom2"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pay_SiteID"))
            p_param1.Add((object) "pay_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TPayment().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pay_SiteID", (object) 0));
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
