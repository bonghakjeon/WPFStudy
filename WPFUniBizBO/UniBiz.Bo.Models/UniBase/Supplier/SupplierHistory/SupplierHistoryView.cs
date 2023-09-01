// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory.SupplierHistoryView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.PayContion;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory
{
  public class SupplierHistoryView : TSupplierHistory<SupplierHistoryView>
  {
    private string _su_SupplierName;
    private string _si_StoreName;
    private string _inEmpName;
    private string _modEmpName;
    private PayContionView _PayContion;
    private IList<SupplierAutoDeductionView> _Lt_AutoDeduction;

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
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

    [JsonPropertyName("payContion")]
    public PayContionView PayContion
    {
      get => this._PayContion ?? (this._PayContion = new PayContionView());
      set
      {
        this._PayContion = value;
        this.Changed(nameof (PayContion));
      }
    }

    [JsonPropertyName("lt_AutoDeduction")]
    public IList<SupplierAutoDeductionView> Lt_AutoDeduction
    {
      get => this._Lt_AutoDeduction ?? (this._Lt_AutoDeduction = (IList<SupplierAutoDeductionView>) new List<SupplierAutoDeductionView>());
      set
      {
        this._Lt_AutoDeduction = value;
        this.Changed(nameof (Lt_AutoDeduction));
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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.PayContion = (PayContionView) null;
      this.Lt_AutoDeduction = (IList<SupplierAutoDeductionView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SupplierHistoryView();

    public override object Clone()
    {
      SupplierHistoryView supplierHistoryView = base.Clone() as SupplierHistoryView;
      supplierHistoryView.inEmpName = this.inEmpName;
      supplierHistoryView.modEmpName = this.modEmpName;
      supplierHistoryView.PayContion = (PayContionView) null;
      if (this.PayContion.payc_ID > 0)
        supplierHistoryView.PayContion.PutData(this.PayContion);
      supplierHistoryView.Lt_AutoDeduction = (IList<SupplierAutoDeductionView>) null;
      if (this.Lt_AutoDeduction.Count > 0)
      {
        foreach (SupplierAutoDeductionView autoDeductionView in (IEnumerable<SupplierAutoDeductionView>) this.Lt_AutoDeduction)
          supplierHistoryView.Lt_AutoDeduction.Add(autoDeductionView);
      }
      return (object) supplierHistoryView;
    }

    public void PutData(SupplierHistoryView pSource)
    {
      this.PutData((TSupplierHistory) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.PayContion = (PayContionView) null;
      if (pSource.PayContion.payc_ID > 0)
        this.PayContion.PutData(pSource.PayContion);
      this.Lt_AutoDeduction = (IList<SupplierAutoDeductionView>) null;
      if (pSource.Lt_AutoDeduction.Count <= 0)
        return;
      foreach (SupplierAutoDeductionView pSource1 in (IEnumerable<SupplierAutoDeductionView>) pSource.Lt_AutoDeduction)
      {
        SupplierAutoDeductionView autoDeductionView = new SupplierAutoDeductionView();
        autoDeductionView.PutData(pSource1);
        this.Lt_AutoDeduction.Add(autoDeductionView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.suh_SiteID == 0L)
      {
        this.message = "싸이트(suh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.suh_Supplier == 0)
      {
        this.message = "코드(suh_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.suh_StoreCode == 0)
      {
        this.message = "지점코드(suh_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.suh_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일자(suh_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.suh_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일자(suh_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.suh_StartDate;
      DateTime? suhEndDate = this.suh_EndDate;
      if ((nullable.HasValue & suhEndDate.HasValue ? (nullable.GetValueOrDefault() > suhEndDate.GetValueOrDefault() ? 1 : 0) : 0) == 0)
        return EnumDataCheck.Success;
      this.message = "시작일자(suh_StartDate) > 종료일자(suh_EndDate)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (this.IsNew)
      {
        if (!p_app_employee.IsSupplierSave)
        {
          this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (!p_app_employee.IsPayment)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(suh_ID), 0)+1 AS suh_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.suh_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.suh_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      SupplierHistoryView supplierHistoryView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(supplierHistoryView.CreateCodeQuery()))
        {
          supplierHistoryView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierHistoryView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          supplierHistoryView.suh_ID = rs.GetFieldInt(0);
        return supplierHistoryView.suh_ID > 0;
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
          if (this.suh_SiteID == 0L)
            this.suh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.suh_ID == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(suh_ID) 생성 오류", 2);
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
      SupplierHistoryView supplierHistoryView = this;
      try
      {
        supplierHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != supplierHistoryView.DataCheck(p_db))
            throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (supplierHistoryView.suh_SiteID == 0L)
            supplierHistoryView.suh_SiteID = p_app_employee.emp_SiteID;
          if (!supplierHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (supplierHistoryView.suh_ID == 0)
        {
          if (!await supplierHistoryView.CreateCodeAsync(p_db))
            throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 코드(suh_ID) 생성 오류", 2);
        }
        if (!await supplierHistoryView.InsertAsync())
          throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 등록 오류");
        supplierHistoryView.db_status = 4;
        supplierHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        supplierHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        supplierHistoryView.message = ex.Message;
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
        if (this.suh_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 업체 결제 이력 KEY(suh_ID) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      SupplierHistoryView supplierHistoryView = this;
      try
      {
        supplierHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != supplierHistoryView.DataCheck(p_db))
            throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!supplierHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (supplierHistoryView.suh_ID == 0)
          throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 업체 결제 이력 KEY(suh_ID) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await supplierHistoryView.UpdateAsync())
          throw new UniServiceException(supplierHistoryView.message, supplierHistoryView.TableCode.ToDescription() + " 변경 오류");
        supplierHistoryView.db_status = 4;
        supplierHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        supplierHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        supplierHistoryView.message = ex.Message;
      }
      return false;
    }

    public bool InsertAutoDeduction(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      try
      {
        if (this.Lt_AutoDeduction.Count == 0)
          return true;
        this.SetAdoDatabase(p_db);
        foreach (SupplierAutoDeductionView autoDeductionView in (IEnumerable<SupplierAutoDeductionView>) this.Lt_AutoDeduction)
        {
          if (autoDeductionView.suad_SiteID == 0L)
            autoDeductionView.suad_SiteID = this.suh_SiteID;
          autoDeductionView.suad_SupplierHistory = this.suh_ID;
          if (autoDeductionView.suad_Seq == 0)
            throw new UniServiceException("공제항목(suad_Seq) " + EnumDataCheck.CodeZero.ToDescription(), autoDeductionView.TableCode.ToDescription() + " 유효성 검사 실패\n공제항목(suad_Seq)  " + EnumDataCheck.CodeZero.ToDescription());
          if (!autoDeductionView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(autoDeductionView.message, autoDeductionView.TableCode.ToDescription() + " 등록 실패");
        }
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

    public async Task<bool> InsertAutoDeductionAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      SupplierHistoryView supplierHistoryView = this;
      try
      {
        if (supplierHistoryView.Lt_AutoDeduction.Count == 0)
          return true;
        supplierHistoryView.SetAdoDatabase(p_db);
        foreach (SupplierAutoDeductionView item in (IEnumerable<SupplierAutoDeductionView>) supplierHistoryView.Lt_AutoDeduction)
        {
          if (item.suad_SiteID == 0L)
            item.suad_SiteID = supplierHistoryView.suh_SiteID;
          item.suad_SupplierHistory = supplierHistoryView.suh_ID;
          if (item.suad_Seq == 0)
            throw new UniServiceException("공제항목(suad_Seq) " + EnumDataCheck.CodeZero.ToDescription(), item.TableCode.ToDescription() + " 유효성 검사 실패\n공제항목(suad_Seq)  " + EnumDataCheck.CodeZero.ToDescription());
          if (!await item.InsertDataAsync(p_db, p_app_employee, false))
            throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 등록 실패");
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        supplierHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        supplierHistoryView.message = ex.Message;
      }
      return false;
    }

    public bool RegisterData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
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
          if (this.suh_SiteID == 0L)
            this.suh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.suh_ID == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(suh_ID) 생성 오류", 2);
        IList<StringBuilder> stringBuilderList = (IList<StringBuilder>) new List<StringBuilder>();
        stringBuilderList.Add(new StringBuilder());
        DataModLogView dataModLogView = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(this.suh_SiteID))
        {
          dataModLogView.dml_CodeInt = this.suh_Supplier;
          dataModLogView.dml_CodeStr = string.Format("{0}|{1}", (object) this.suh_Supplier, (object) this.suh_SiteID);
          dataModLogView.CreateCode(p_db);
        }
        foreach (SupplierHistoryView pSource in (IEnumerable<SupplierHistoryView>) p_db.Create<SupplierHistoryView>().SelectListE<SupplierHistoryView>((object) new Hashtable()
        {
          {
            (object) "suh_SiteID",
            (object) this.suh_SiteID
          },
          {
            (object) "suh_Supplier",
            (object) this.suh_Supplier
          },
          {
            (object) "suh_StoreCode",
            (object) this.suh_StoreCode
          },
          {
            (object) "_DT_START_DATE_",
            (object) this.suh_StartDate.Value
          },
          {
            (object) "_DT_END_DATE_",
            (object) this.suh_EndDate.Value
          }
        }))
        {
          if (this.suh_Supplier == pSource.suh_Supplier && this.suh_StoreCode == pSource.suh_StoreCode)
          {
            pSource.SetAdoDatabase(p_db);
            DateTime? nullable1;
            if (pSource.IntStartDate >= this.IntStartDate && pSource.IntEndDate <= this.IntEndDate)
            {
              if (pSource.IntStartDate == this.IntStartDate && pSource.IntEndDate == this.IntEndDate)
              {
                dataModLogView.Init(p_login_employee, this.TableCode, EnumEmpActionKind.UPDATE);
                nullable1 = pSource.suh_EndDate;
                DateTime dateTime1 = nullable1.Value;
                ref DateTime local = ref dateTime1;
                nullable1 = this.suh_EndDate;
                DateTime dateTime2 = nullable1.Value;
                if (!local.Equals(dateTime2))
                {
                  if (stringBuilderList[stringBuilderList.Count - 1].Length > 4000)
                    stringBuilderList.Add(new StringBuilder());
                  stringBuilderList[stringBuilderList.Count - 1].Append(dataModLogView.LogInfoQuery("suh_EndDate", "종료일자", pSource.suh_EndDate, this.suh_EndDate));
                  stringBuilderList[stringBuilderList.Count - 1].Append(";");
                }
                if (!pSource.suh_PayMethod.Equals(this.suh_PayMethod))
                {
                  if (stringBuilderList[stringBuilderList.Count - 1].Length > 4000)
                    stringBuilderList.Add(new StringBuilder());
                  stringBuilderList[stringBuilderList.Count - 1].Append(dataModLogView.LogInfoQuery("suh_PayMethod", "결제수단", pSource.suh_PayMethod, this.suh_PayMethod));
                  stringBuilderList[stringBuilderList.Count - 1].Append(";");
                }
                if (!pSource.suh_PayCondition.Equals(this.suh_PayCondition))
                {
                  if (stringBuilderList[stringBuilderList.Count - 1].Length > 4000)
                    stringBuilderList.Add(new StringBuilder());
                  stringBuilderList[stringBuilderList.Count - 1].Append(dataModLogView.LogInfoQuery("suh_PayCondition", "결제조건", pSource.suh_PayCondition, this.suh_PayCondition));
                  stringBuilderList[stringBuilderList.Count - 1].Append(";");
                }
              }
              else
              {
                dataModLogView.Init(p_login_employee, this.TableCode, EnumEmpActionKind.DELETE);
                stringBuilderList[stringBuilderList.Count - 1].Append(dataModLogView.LogInfoQuery("suh_ID|suh_Supplier|suh_StoreCode|suh_StartDate|suh_EndDate|suh_SiteID", "업체 결제 이력 KEY|코드|지점코드|시작일자|종료일자|싸이트", string.Format("{0}|{1}|{2}|{3}|{4}|{5}", (object) pSource.suh_ID, (object) pSource.suh_Supplier, (object) pSource.suh_StoreCode, (object) pSource.IntStartDate, (object) pSource.IntEndDate, (object) pSource.suh_SiteID), string.Empty));
              }
              p_db.Execute(new SupplierAutoDeductionView().DeleteQuery(this.suh_ID, 0, this.suh_SiteID));
              if (!pSource.Delete())
                throw new Exception(pSource.message);
            }
            else if (pSource.IntStartDate < this.IntStartDate && pSource.IntEndDate > this.IntEndDate)
            {
              SupplierHistoryView supplierHistoryView1 = p_db.Create<SupplierHistoryView>();
              supplierHistoryView1.PutData(pSource);
              supplierHistoryView1.Lt_AutoDeduction = p_db.Create<SupplierAutoDeductionView>().SelectListE<SupplierAutoDeductionView>((object) new Hashtable()
              {
                {
                  (object) "suad_SiteID",
                  (object) this.suh_SiteID
                },
                {
                  (object) "suad_SupplierHistory",
                  (object) this.suh_ID
                }
              });
              SupplierHistoryView supplierHistoryView2 = pSource;
              nullable1 = this.suh_StartDate;
              DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
              supplierHistoryView2.suh_EndDate = nullable2;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
              supplierHistoryView1.suh_ID = 0;
              SupplierHistoryView supplierHistoryView3 = supplierHistoryView1;
              nullable1 = this.suh_EndDate;
              DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
              supplierHistoryView3.suh_StartDate = nullable3;
              supplierHistoryView1.suh_SiteID = this.suh_SiteID;
              if (!supplierHistoryView1.CreateCode(p_db))
                throw new Exception(supplierHistoryView1.message);
              if (!supplierHistoryView1.Insert())
                throw new Exception(supplierHistoryView1.message);
              if (!supplierHistoryView1.InsertAutoDeduction(p_db, p_app_employee))
                throw new Exception(supplierHistoryView1.message);
            }
            else if (pSource.IntStartDate < this.IntStartDate && pSource.IntEndDate <= this.IntEndDate)
            {
              SupplierHistoryView supplierHistoryView = pSource;
              nullable1 = this.suh_StartDate;
              DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
              supplierHistoryView.suh_EndDate = nullable4;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
            }
            else if (pSource.IntStartDate >= this.IntStartDate && pSource.IntEndDate > this.IntEndDate)
            {
              SupplierHistoryView supplierHistoryView = pSource;
              nullable1 = this.suh_EndDate;
              DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
              supplierHistoryView.suh_StartDate = nullable5;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
            }
          }
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertAutoDeduction(p_db, p_app_employee))
          throw new Exception(this.message);
        if (stringBuilderList.Count > 0)
        {
          foreach (StringBuilder stringBuilder in (IEnumerable<StringBuilder>) stringBuilderList)
          {
            if (stringBuilder.Length > 0)
            {
              p_db.Execute(stringBuilder.ToString());
              stringBuilder.Clear();
            }
          }
          stringBuilderList.Clear();
        }
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

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      SupplierHistoryView supplierHistoryView1 = this;
      try
      {
        supplierHistoryView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != supplierHistoryView1.DataCheck(p_db))
            throw new UniServiceException(supplierHistoryView1.message, supplierHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (supplierHistoryView1.suh_SiteID == 0L)
            supplierHistoryView1.suh_SiteID = p_app_employee.emp_SiteID;
          if (!supplierHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(supplierHistoryView1.message, supplierHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (supplierHistoryView1.suh_ID == 0)
        {
          if (!await supplierHistoryView1.CreateCodeAsync(p_db))
            throw new UniServiceException(supplierHistoryView1.message, supplierHistoryView1.TableCode.ToDescription() + " 코드(suh_ID) 생성 오류", 2);
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(supplierHistoryView1.suh_SiteID))
        {
          logs.dml_CodeInt = supplierHistoryView1.suh_Supplier;
          logs.dml_CodeStr = string.Format("{0}|{1}", (object) supplierHistoryView1.suh_Supplier, (object) supplierHistoryView1.suh_SiteID);
          int num = await logs.CreateCodeAsync(p_db) ? 1 : 0;
        }
        Hashtable p_param = new Hashtable();
        p_param.Add((object) "suh_SiteID", (object) supplierHistoryView1.suh_SiteID);
        p_param.Add((object) "suh_Supplier", (object) supplierHistoryView1.suh_Supplier);
        p_param.Add((object) "suh_StoreCode", (object) supplierHistoryView1.suh_StoreCode);
        Hashtable hashtable1 = p_param;
        DateTime? nullable1 = supplierHistoryView1.suh_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_START_DATE_", (object) local1);
        Hashtable hashtable2 = p_param;
        nullable1 = supplierHistoryView1.suh_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_END_DATE_", (object) local2);
        foreach (SupplierHistoryView supplierHistoryView2 in (IEnumerable<SupplierHistoryView>) await p_db.Create<SupplierHistoryView>().SelectListAsync((object) p_param))
        {
          SupplierHistoryView item = supplierHistoryView2;
          if (supplierHistoryView1.suh_Supplier == item.suh_Supplier && supplierHistoryView1.suh_StoreCode == item.suh_StoreCode)
          {
            item.SetAdoDatabase(p_db);
            if (item.IntStartDate >= supplierHistoryView1.IntStartDate && item.IntEndDate <= supplierHistoryView1.IntEndDate)
            {
              if (item.IntStartDate == supplierHistoryView1.IntStartDate && item.IntEndDate == supplierHistoryView1.IntEndDate)
              {
                logs.Init(p_login_employee, supplierHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
                nullable1 = item.suh_EndDate;
                DateTime dateTime1 = nullable1.Value;
                ref DateTime local3 = ref dateTime1;
                nullable1 = supplierHistoryView1.suh_EndDate;
                DateTime dateTime2 = nullable1.Value;
                if (!local3.Equals(dateTime2))
                {
                  if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                    lt_sbLogs.Add(new StringBuilder());
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("suh_EndDate", "종료일자", item.suh_EndDate, supplierHistoryView1.suh_EndDate));
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
                }
                if (!item.suh_PayMethod.Equals(supplierHistoryView1.suh_PayMethod))
                {
                  if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                    lt_sbLogs.Add(new StringBuilder());
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("suh_PayMethod", "결제수단", item.suh_PayMethod, supplierHistoryView1.suh_PayMethod));
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
                }
                if (!item.suh_PayCondition.Equals(supplierHistoryView1.suh_PayCondition))
                {
                  if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                    lt_sbLogs.Add(new StringBuilder());
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("suh_PayCondition", "결제조건", item.suh_PayCondition, supplierHistoryView1.suh_PayCondition));
                  lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
                }
              }
              else
              {
                logs.Init(p_login_employee, supplierHistoryView1.TableCode, EnumEmpActionKind.DELETE);
                lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("suh_ID|suh_Supplier|suh_StoreCode|suh_StartDate|suh_EndDate|suh_SiteID", "업체 결제 이력 KEY|코드|지점코드|시작일자|종료일자|싸이트", string.Format("{0}|{1}|{2}|{3}|{4}|{5}", (object) item.suh_ID, (object) item.suh_Supplier, (object) item.suh_StoreCode, (object) item.IntStartDate, (object) item.IntEndDate, (object) item.suh_SiteID), string.Empty));
              }
              int num = await p_db.ExecuteAsync(new SupplierAutoDeductionView().DeleteQuery(supplierHistoryView1.suh_ID, 0, supplierHistoryView1.suh_SiteID)) ? 1 : 0;
              if (!await item.DeleteAsync())
                throw new Exception(item.message);
            }
            else if (item.IntStartDate < supplierHistoryView1.IntStartDate && item.IntEndDate > supplierHistoryView1.IntEndDate)
            {
              SupplierHistoryView next_data = p_db.Create<SupplierHistoryView>();
              next_data.PutData(item);
              SupplierHistoryView supplierHistoryView = next_data;
              SupplierAutoDeductionView autoDeductionView = p_db.Create<SupplierAutoDeductionView>();
              supplierHistoryView.Lt_AutoDeduction = await autoDeductionView.SelectListAsync((object) new Hashtable()
              {
                {
                  (object) "suad_SiteID",
                  (object) supplierHistoryView1.suh_SiteID
                },
                {
                  (object) "suad_SupplierHistory",
                  (object) supplierHistoryView1.suh_ID
                }
              });
              supplierHistoryView = (SupplierHistoryView) null;
              SupplierHistoryView supplierHistoryView3 = item;
              nullable1 = supplierHistoryView1.suh_StartDate;
              DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
              supplierHistoryView3.suh_EndDate = nullable2;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
              next_data.suh_ID = 0;
              SupplierHistoryView supplierHistoryView4 = next_data;
              nullable1 = supplierHistoryView1.suh_EndDate;
              DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
              supplierHistoryView4.suh_StartDate = nullable3;
              next_data.suh_SiteID = supplierHistoryView1.suh_SiteID;
              if (!await next_data.CreateCodeAsync(p_db))
                throw new Exception(next_data.message);
              if (!await next_data.InsertAsync())
                throw new Exception(next_data.message);
              if (!await next_data.InsertAutoDeductionAsync(p_db, p_app_employee))
                throw new Exception(next_data.message);
              next_data = (SupplierHistoryView) null;
            }
            else if (item.IntStartDate < supplierHistoryView1.IntStartDate && item.IntEndDate <= supplierHistoryView1.IntEndDate)
            {
              SupplierHistoryView supplierHistoryView5 = item;
              nullable1 = supplierHistoryView1.suh_StartDate;
              DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
              supplierHistoryView5.suh_EndDate = nullable4;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
            }
            else if (item.IntStartDate >= supplierHistoryView1.IntStartDate && item.IntEndDate > supplierHistoryView1.IntEndDate)
            {
              SupplierHistoryView supplierHistoryView6 = item;
              nullable1 = supplierHistoryView1.suh_EndDate;
              DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
              supplierHistoryView6.suh_StartDate = nullable5;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
            }
            item = (SupplierHistoryView) null;
          }
        }
        if (!await supplierHistoryView1.InsertAsync())
          throw new UniServiceException(supplierHistoryView1.message, supplierHistoryView1.TableCode.ToDescription() + " 등록 오류");
        if (!await supplierHistoryView1.InsertAutoDeductionAsync(p_db, p_app_employee))
          throw new Exception(supplierHistoryView1.message);
        if (lt_sbLogs.Count > 0)
        {
          foreach (StringBuilder item in (IEnumerable<StringBuilder>) lt_sbLogs)
          {
            if (item.Length > 0)
            {
              int num = await p_db.ExecuteAsync(item.ToString()) ? 1 : 0;
              item.Clear();
            }
          }
          lt_sbLogs.Clear();
        }
        supplierHistoryView1.db_status = 4;
        supplierHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        supplierHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        supplierHistoryView1.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.PayContion.payc_ID = p_rs.GetFieldInt("payc_ID");
      this.PayContion.payc_Turn = p_rs.GetFieldInt("payc_Turn");
      this.PayContion.payc_SiteID = p_rs.GetFieldLong("payc_SiteID");
      this.PayContion.payc_Round = p_rs.GetFieldInt("payc_Round");
      this.PayContion.payc_PaymentMonth = p_rs.GetFieldInt("payc_PaymentMonth");
      this.PayContion.payc_PaymentDay = p_rs.GetFieldInt("payc_PaymentDay");
      this.PayContion.payc_Memo = p_rs.GetFieldString("payc_Memo");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<SupplierHistoryView> SelectOneAsync(int p_suh_ID, long p_suh_SiteID = 0)
    {
      SupplierHistoryView supplierHistoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "suh_ID",
          (object) p_suh_ID
        }
      };
      if (p_suh_SiteID > 0L)
        p_param.Add((object) "suh_SiteID", (object) p_suh_SiteID);
      return await supplierHistoryView.SelectOneTAsync<SupplierHistoryView>((object) p_param);
    }

    public async Task<IList<SupplierHistoryView>> SelectListAsync(object p_param)
    {
      SupplierHistoryView supplierHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(supplierHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, supplierHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(supplierHistoryView1.GetSelectQuery(p_param)))
        {
          supplierHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SupplierHistoryView>) null;
        }
        IList<SupplierHistoryView> lt_list = (IList<SupplierHistoryView>) new List<SupplierHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SupplierHistoryView supplierHistoryView2 = supplierHistoryView1.OleDB.Create<SupplierHistoryView>();
            if (supplierHistoryView2.GetFieldValues(rs))
            {
              supplierHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(supplierHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        long num1 = 0;
        bool flag = false;
        int num2 = 0;
        if (p_param is Hashtable hashtable1)
        {
          if (hashtable1.ContainsKey((object) "DBMS") && hashtable1[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable1[(object) "DBMS"].ToString();
          if (hashtable1.ContainsKey((object) "table") && hashtable1[(object) "table"].ToString().Length > 0)
            str = hashtable1[(object) "table"].ToString();
          if (hashtable1.ContainsKey((object) "_ORDER_BY_COL_") && hashtable1[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable1[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable1.ContainsKey((object) "suh_SiteID") && Convert.ToInt64(hashtable1[(object) "suh_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable1[(object) "suh_SiteID"].ToString());
          if (hashtable1.ContainsKey((object) "_HEADER_CONDITION_"))
            flag = true;
          if (hashtable1.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable1[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable1[(object) "_ORDER_BY_TYPE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_SupplierName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        if (flag)
        {
          if (p_param is Hashtable hashtable2)
            stringBuilder.Append(new TSupplier().GetSelectWhereAnd(hashtable2[(object) "_HEADER_CONDITION_"]));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS (SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PAY_CONTION AS (SELECT payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,payc_Memo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.PayContion, (object) DbQueryHelper.ToWithNolock()));
        Hashtable p_param1 = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("suh_SiteID"))
            p_param1.Add((object) "payc_SiteID", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "payc_Turn"))
            p_param1.Add((object) "payc_Turn", (object) 1);
          stringBuilder.Append(new TPayContion().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
        {
          stringBuilder.Append(" WHERE payc_Turn=1");
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_SiteID", (object) num1));
        }
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  suh_ID,suh_SiteID,suh_Supplier,suh_StoreCode,suh_StartDate,suh_EndDate,suh_PayMethod,suh_PayCondition,suh_InDate,suh_InUser,suh_ModDate,suh_ModUser,su_SupplierName,si_StoreName,payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,payc_Memo,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_SUPPLIER ON suh_Supplier=su_Supplier AND suh_SiteID=su_SiteID INNER JOIN T_STORE ON suh_StoreCode=si_StoreCode AND suh_SiteID=si_SiteID LEFT OUTER JOIN T_PAY_CONTION ON suh_PayCondition=payc_ID AND suh_SiteID=payc_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON suh_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON suh_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num2 > 0)
        {
          switch (num2)
          {
            case 1:
              stringBuilder.Append(" ORDER BY suh_Supplier,suh_StoreCode,suh_StartDate DESC");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY suh_Supplier,suh_StoreCode,suh_StartDate");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY suh_Supplier,suh_StoreCode,suh_StartDate");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public async Task<bool> IsPamentAnyTimeAsync(
      long p_suh_SiteID,
      int p_suh_Supplier,
      int p_suh_StoreCode,
      DateTime p_Date)
    {
      SupplierHistoryView supplierHistoryView1 = this;
      if (p_suh_SiteID == 0L || p_suh_Supplier == 0 || p_suh_StoreCode == 0)
        return true;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "suh_SiteID",
          (object) p_suh_SiteID
        },
        {
          (object) "suh_Supplier",
          (object) p_suh_Supplier
        },
        {
          (object) "suh_StoreCode",
          (object) p_suh_StoreCode
        },
        {
          (object) "_DT_DATE_",
          (object) p_Date
        }
      };
      IList<SupplierHistoryView> supplierHistoryViewList = await supplierHistoryView1.SelectListEAsync<SupplierHistoryView>((object) p_param);
      if (supplierHistoryViewList == null || supplierHistoryViewList.Count != 1)
        return true;
      SupplierHistoryView supplierHistoryView2 = supplierHistoryViewList[0];
      return supplierHistoryView2 == null || supplierHistoryView2.suh_Supplier == 0 || supplierHistoryView2.PayContion.payc_ID == 9999;
    }

    public bool IsPamentAnyTime(
      long p_suh_SiteID,
      int p_suh_Supplier,
      int p_suh_StoreCode,
      DateTime p_Date)
    {
      if (p_suh_SiteID == 0L || p_suh_Supplier == 0 || p_suh_StoreCode == 0)
        return true;
      IList<SupplierHistoryView> supplierHistoryViewList = this.SelectListE<SupplierHistoryView>((object) new Hashtable()
      {
        {
          (object) "suh_SiteID",
          (object) p_suh_SiteID
        },
        {
          (object) "suh_Supplier",
          (object) p_suh_Supplier
        },
        {
          (object) "suh_StoreCode",
          (object) p_suh_StoreCode
        },
        {
          (object) "_DT_DATE_",
          (object) p_Date
        }
      });
      if (supplierHistoryViewList == null || supplierHistoryViewList.Count != 1)
        return true;
      SupplierHistoryView supplierHistoryView = supplierHistoryViewList[0];
      return supplierHistoryView == null || supplierHistoryView.suh_Supplier == 0 || supplierHistoryView.PayContion.payc_ID == 9999;
    }
  }
}
