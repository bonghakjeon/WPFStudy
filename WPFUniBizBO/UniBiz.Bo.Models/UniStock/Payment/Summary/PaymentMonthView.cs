// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.PaymentMonthView
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

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public class PaymentMonthView : TPaymentMonth<PaymentMonthView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private int _su_HeadSupplier;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private int _su_PreTaxDiv;
    private int _su_MultiSuplierDiv;
    private int _su_DeductionDayDiv;

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

    public int su_HeadSupplier
    {
      get => this._su_HeadSupplier;
      set
      {
        this._su_HeadSupplier = value;
        this.Changed(nameof (su_HeadSupplier));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.su_HeadSupplier = 0;
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_PreTaxDiv = 0;
      this.su_MultiSuplierDiv = 0;
      this.su_DeductionDayDiv = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PaymentMonthView();

    public override object Clone()
    {
      PaymentMonthView paymentMonthView = base.Clone() as PaymentMonthView;
      paymentMonthView.si_StoreName = this.si_StoreName;
      paymentMonthView.si_StoreViewCode = this.si_StoreViewCode;
      paymentMonthView.si_UseYn = this.si_UseYn;
      paymentMonthView.si_StoreType = this.si_StoreType;
      paymentMonthView.su_HeadSupplier = this.su_HeadSupplier;
      paymentMonthView.su_SupplierName = this.su_SupplierName;
      paymentMonthView.su_SupplierViewCode = this.su_SupplierViewCode;
      paymentMonthView.su_SupplierType = this.su_SupplierType;
      paymentMonthView.su_SupplierKind = this.su_SupplierKind;
      paymentMonthView.su_UseYn = this.su_UseYn;
      paymentMonthView.su_PreTaxDiv = this.su_PreTaxDiv;
      paymentMonthView.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      paymentMonthView.su_DeductionDayDiv = this.su_DeductionDayDiv;
      return (object) paymentMonthView;
    }

    public void PutData(PaymentMonthView pSource)
    {
      this.PutData((TPaymentMonth) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.su_DeductionDayDiv = pSource.su_DeductionDayDiv;
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
      if (this.paym_StoreCode == 0)
      {
        this.message = "지점코드(paym_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.paym_Supplier != 0)
        return EnumDataCheck.Success;
      this.message = "코드(paym_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
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
          if (this.paym_SiteID == 0L)
            this.paym_SiteID = p_app_employee.emp_SiteID;
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
      PaymentMonthView paymentMonthView = this;
      try
      {
        paymentMonthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentMonthView.DataCheck(p_db))
            throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (paymentMonthView.paym_SiteID == 0L)
            paymentMonthView.paym_SiteID = p_app_employee.emp_SiteID;
          if (!paymentMonthView.IsPermit(p_app_employee))
            throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await paymentMonthView.InsertAsync())
          throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 등록 오류");
        paymentMonthView.db_status = 4;
        paymentMonthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentMonthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentMonthView.message = ex.Message;
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
      PaymentMonthView paymentMonthView = this;
      try
      {
        paymentMonthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != paymentMonthView.DataCheck(p_db))
            throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!paymentMonthView.IsPermit(p_app_employee))
          throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await paymentMonthView.UpdateAsync())
          throw new UniServiceException(paymentMonthView.message, paymentMonthView.TableCode.ToDescription() + " 변경 오류");
        paymentMonthView.db_status = 4;
        paymentMonthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        paymentMonthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        paymentMonthView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
      this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
      this.su_DeductionDayDiv = p_rs.GetFieldInt("su_DeductionDayDiv");
      return true;
    }

    public async Task<PaymentMonthView> SelectOneAsync(
      int p_paym_YyyyMm,
      int p_paym_StoreCode,
      int p_paym_Supplier,
      long p_paym_SiteID = 0)
    {
      PaymentMonthView paymentMonthView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "paym_YyyyMm",
          (object) p_paym_YyyyMm
        },
        {
          (object) "paym_StoreCode",
          (object) p_paym_StoreCode
        },
        {
          (object) "paym_Supplier",
          (object) p_paym_Supplier
        }
      };
      if (p_paym_SiteID > 0L)
        p_param.Add((object) "paym_SiteID", (object) p_paym_SiteID);
      return await paymentMonthView.SelectOneTAsync<PaymentMonthView>((object) p_param);
    }

    public async Task<IList<PaymentMonthView>> SelectListAsync(object p_param)
    {
      PaymentMonthView paymentMonthView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentMonthView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentMonthView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentMonthView1.GetSelectQuery(p_param)))
        {
          paymentMonthView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PaymentMonthView>) null;
        }
        IList<PaymentMonthView> lt_list = (IList<PaymentMonthView>) new List<PaymentMonthView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PaymentMonthView paymentMonthView2 = paymentMonthView1.OleDB.Create<PaymentMonthView>();
            if (paymentMonthView2.GetFieldValues(rs))
            {
              paymentMonthView2.row_number = lt_list.Count + 1;
              lt_list.Add(paymentMonthView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<PaymentMonthView> SelectEnumerableAsync(object p_param)
    {
      PaymentMonthView paymentMonthView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(paymentMonthView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, paymentMonthView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(paymentMonthView1.GetSelectQuery(p_param)))
        {
          paymentMonthView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + paymentMonthView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PaymentMonthView paymentMonthView2 = paymentMonthView1.OleDB.Create<PaymentMonthView>();
            if (paymentMonthView2.GetFieldValues(rs))
            {
              paymentMonthView2.row_number = ++row_number;
              yield return paymentMonthView2;
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
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num = 0;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "paym_SiteID") && Convert.ToInt64(hashtable[(object) "paym_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "paym_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\nSELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID,paym_BaseAmount,paym_BuyTax,paym_BuyVat,paym_BuyFree,paym_BuyReturnTax,paym_BuyReturnVat,paym_BuyReturnFree,paym_Deposit,paym_SaleTax,paym_SaleVat,paym_SaleFree,paym_DeductionAmount,paym_PayAmount,paym_AddAmount,paym_EndAmount,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON paym_StoreCode=si_StoreCode AND paym_SiteID=si_SiteID\n INNER JOIN T_SUPPLIER ON paym_Supplier=su_Supplier AND paym_SiteID=su_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append(" ORDER BY paym_YyyyMm,paym_StoreCode,paym_Supplier");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY paym_YyyyMm,paym_Supplier,paym_StoreCode");
              break;
            default:
              stringBuilder.Append(" ORDER BY paym_YyyyMm,paym_StoreCode,paym_Supplier");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY paym_YyyyMm,paym_StoreCode,paym_Supplier");
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
