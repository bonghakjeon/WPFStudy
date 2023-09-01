// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail.RebateConditionDetailView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail
{
  public class RebateConditionDetailView : TRebateConditionDetail<RebateConditionDetailView>
  {
    private string _si_StoreName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private string _inEmpName;
    private string _modEmpName;
    private RebateConditionHeaderView _HeaderInfo;

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

    public RebateConditionHeaderView HeaderInfo
    {
      get => this._HeaderInfo ?? (this._HeaderInfo = new RebateConditionHeaderView());
      set
      {
        this._HeaderInfo = value;
        this.Changed(nameof (HeaderInfo));
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
      this.si_StoreName = string.Empty;
      this.su_SupplierName = string.Empty;
      this.su_SupplierViewCode = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.HeaderInfo = (RebateConditionHeaderView) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new RebateConditionDetailView();

    public override object Clone()
    {
      RebateConditionDetailView conditionDetailView = base.Clone() as RebateConditionDetailView;
      conditionDetailView.si_StoreName = this.si_StoreName;
      conditionDetailView.su_SupplierName = this.su_SupplierName;
      conditionDetailView.su_SupplierViewCode = this.su_SupplierViewCode;
      conditionDetailView.inEmpName = this.inEmpName;
      conditionDetailView.modEmpName = this.modEmpName;
      conditionDetailView.HeaderInfo = (RebateConditionHeaderView) null;
      if (this.HeaderInfo.rch_Supplier > 0)
        conditionDetailView.HeaderInfo = this.HeaderInfo;
      return (object) conditionDetailView;
    }

    public void PutData(RebateConditionDetailView pSource)
    {
      this.PutData((TRebateConditionDetail) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.HeaderInfo = (RebateConditionHeaderView) null;
      if (pSource.HeaderInfo.rch_Supplier <= 0)
        return;
      this.HeaderInfo.PutData(pSource.HeaderInfo);
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.rcd_SiteID == 0L)
      {
        this.message = "싸이트(rcd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.rcd_StoreCode == 0)
      {
        this.message = "지점코드(rcd_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.rcd_Supplier == 0)
      {
        this.message = "코드(rcd_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.rcd_StdAmtFrom <= this.rcd_StdAmtTo)
        return EnumDataCheck.Success;
      this.message = "기준금액 (이상)(rcd_StdAmtFrom)>기준금액 (미만)(rcd_StdAmtTo) 수치  " + EnumDataCheck.Valid.ToDescription();
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
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(rcd_Seq), 0)+1 AS rcd_Seq" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.rcd_Seq = uniOleDbRecordset.GetFieldInt(0);
        return this.rcd_Seq > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      RebateConditionDetailView conditionDetailView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(conditionDetailView.CreateCodeQuery()))
        {
          conditionDetailView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + conditionDetailView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          conditionDetailView.rcd_Seq = rs.GetFieldInt(0);
        return conditionDetailView.rcd_Seq > 0;
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
          if (this.rcd_SiteID == 0L)
            this.rcd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.rcd_Seq == 0 && !this.CreateCode(p_db))
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
      RebateConditionDetailView conditionDetailView = this;
      try
      {
        conditionDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != conditionDetailView.DataCheck(p_db))
            throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (conditionDetailView.rcd_SiteID == 0L)
            conditionDetailView.rcd_SiteID = p_app_employee.emp_SiteID;
          if (!conditionDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (conditionDetailView.rcd_Seq == 0)
        {
          if (!await conditionDetailView.CreateCodeAsync(p_db))
            throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await conditionDetailView.InsertAsync())
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 등록 오류");
        conditionDetailView.db_status = 4;
        conditionDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        conditionDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        conditionDetailView.message = ex.Message;
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
        if (this.rcd_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(rcd_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      RebateConditionDetailView conditionDetailView = this;
      try
      {
        conditionDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != conditionDetailView.DataCheck(p_db))
            throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!conditionDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (conditionDetailView.rcd_Seq == 0)
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 순번(rcd_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await conditionDetailView.UpdateAsync())
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 변경 오류");
        conditionDetailView.db_status = 4;
        conditionDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        conditionDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        conditionDetailView.message = ex.Message;
      }
      return false;
    }

    public override bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.rcd_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(rcd_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      RebateConditionDetailView conditionDetailView = this;
      try
      {
        conditionDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != conditionDetailView.DataCheck(p_db))
            throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!conditionDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (conditionDetailView.rcd_Seq == 0)
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 순번(rcd_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await conditionDetailView.DeleteAsync())
          throw new UniServiceException(conditionDetailView.message, conditionDetailView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        conditionDetailView.db_status = 4;
        conditionDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        conditionDetailView.message = ex.Message;
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
          if (this.rcd_SiteID == 0L)
            this.rcd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> stringBuilderList = (IList<StringBuilder>) new List<StringBuilder>();
        stringBuilderList.Add(new StringBuilder());
        DataModLogView dataModLogView = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(this.rcd_SiteID))
        {
          dataModLogView.dml_CodeInt = this.rcd_StoreCode;
          dataModLogView.dml_CodeLong = (long) this.rcd_Supplier;
          dataModLogView.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq, (object) this.rcd_SiteID);
          dataModLogView.CreateCode(p_db);
        }
        bool flag = false;
        foreach (RebateConditionDetailView pSource in (IEnumerable<RebateConditionDetailView>) p_db.Create<RebateConditionDetailView>().SelectListE<RebateConditionDetailView>((object) new Hashtable()
        {
          {
            (object) "rcd_StoreCode",
            (object) this.rcd_StoreCode
          },
          {
            (object) "rcd_Supplier",
            (object) this.rcd_Supplier
          },
          {
            (object) "_BEGIN_",
            (object) this.rcd_StdAmtFrom
          },
          {
            (object) "_END_",
            (object) this.rcd_StdAmtTo
          }
        }))
        {
          if (this.rcd_Supplier == pSource.rcd_Supplier && this.rcd_StoreCode == pSource.rcd_StoreCode)
          {
            if (pSource.rcd_StdAmtFrom >= this.rcd_StdAmtFrom && pSource.rcd_StdAmtTo <= this.rcd_StdAmtTo)
            {
              if (pSource.rcd_Seq == this.rcd_Seq)
                flag = true;
              if (!pSource.Delete())
                throw new Exception(pSource.message);
            }
            else if (pSource.rcd_StdAmtFrom < this.rcd_StdAmtFrom && pSource.rcd_StdAmtTo > this.rcd_StdAmtTo)
            {
              RebateConditionDetailView conditionDetailView = p_db.Create<RebateConditionDetailView>();
              conditionDetailView.PutData(pSource);
              pSource.rcd_StdAmtTo = this.rcd_StdAmtFrom;
              pSource.rcd_ModUser = p_app_employee.emp_Code;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
              conditionDetailView.rcd_Seq = 0;
              conditionDetailView.rcd_StdAmtFrom = this.rcd_StdAmtTo;
              if (!conditionDetailView.CreateCode(p_db))
                throw new Exception(conditionDetailView.message);
              conditionDetailView.rcd_InUser = p_app_employee.emp_Code;
              if (!conditionDetailView.Insert())
                throw new Exception(conditionDetailView.message);
            }
            else if (pSource.rcd_StdAmtFrom < this.rcd_StdAmtFrom && pSource.rcd_StdAmtTo <= this.rcd_StdAmtTo)
            {
              pSource.rcd_StdAmtTo = this.rcd_StdAmtFrom;
              pSource.rcd_ModUser = p_app_employee.emp_Code;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
            }
            else if (pSource.rcd_StdAmtFrom >= this.rcd_StdAmtFrom && pSource.rcd_StdAmtTo > this.rcd_StdAmtTo)
            {
              pSource.rcd_StdAmtFrom = this.rcd_StdAmtTo;
              pSource.rcd_ModUser = p_app_employee.emp_Code;
              if (!pSource.Update((UbModelBase) null))
                throw new Exception(pSource.message);
            }
          }
        }
        if (this.rcd_Seq == 0 | flag)
        {
          if (this.rcd_Seq == 0 && !this.CreateCode(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(rcd_Seq) 생성 오류", 2);
          if (!this.Insert())
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        }
        else if (!this.Update((UbModelBase) null))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
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
      RebateConditionDetailView conditionDetailView1 = this;
      try
      {
        conditionDetailView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != conditionDetailView1.DataCheck(p_db))
            throw new UniServiceException(conditionDetailView1.message, conditionDetailView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (conditionDetailView1.rcd_SiteID == 0L)
            conditionDetailView1.rcd_SiteID = p_app_employee.emp_SiteID;
          if (!conditionDetailView1.IsPermit(p_app_employee))
            throw new UniServiceException(conditionDetailView1.message, conditionDetailView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView dataModLogView = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(conditionDetailView1.rcd_SiteID))
        {
          dataModLogView.dml_CodeInt = conditionDetailView1.rcd_StoreCode;
          dataModLogView.dml_CodeLong = (long) conditionDetailView1.rcd_Supplier;
          dataModLogView.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) conditionDetailView1.rcd_StoreCode, (object) conditionDetailView1.rcd_Supplier, (object) conditionDetailView1.rcd_Seq, (object) conditionDetailView1.rcd_SiteID);
          int num = await dataModLogView.CreateCodeAsync(p_db) ? 1 : 0;
        }
        bool is_delete = false;
        foreach (RebateConditionDetailView conditionDetailView2 in (IEnumerable<RebateConditionDetailView>) await p_db.Create<RebateConditionDetailView>().SelectListAsync((object) new Hashtable()
        {
          {
            (object) "rcd_StoreCode",
            (object) conditionDetailView1.rcd_StoreCode
          },
          {
            (object) "rcd_Supplier",
            (object) conditionDetailView1.rcd_Supplier
          },
          {
            (object) "_BEGIN_",
            (object) conditionDetailView1.rcd_StdAmtFrom
          },
          {
            (object) "_END_",
            (object) conditionDetailView1.rcd_StdAmtTo
          }
        }))
        {
          RebateConditionDetailView item = conditionDetailView2;
          if (conditionDetailView1.rcd_Supplier == item.rcd_Supplier && conditionDetailView1.rcd_StoreCode == item.rcd_StoreCode)
          {
            if (item.rcd_StdAmtFrom >= conditionDetailView1.rcd_StdAmtFrom && item.rcd_StdAmtTo <= conditionDetailView1.rcd_StdAmtTo)
            {
              if (item.rcd_Seq == conditionDetailView1.rcd_Seq)
                is_delete = true;
              if (!await item.DeleteAsync())
                throw new Exception(item.message);
            }
            else if (item.rcd_StdAmtFrom < conditionDetailView1.rcd_StdAmtFrom && item.rcd_StdAmtTo > conditionDetailView1.rcd_StdAmtTo)
            {
              RebateConditionDetailView next_data = p_db.Create<RebateConditionDetailView>();
              next_data.PutData(item);
              item.rcd_StdAmtTo = conditionDetailView1.rcd_StdAmtFrom;
              item.rcd_ModUser = p_app_employee.emp_Code;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
              next_data.rcd_Seq = 0;
              next_data.rcd_StdAmtFrom = conditionDetailView1.rcd_StdAmtTo;
              if (!await next_data.CreateCodeAsync(p_db))
                throw new Exception(next_data.message);
              next_data.rcd_InUser = p_app_employee.emp_Code;
              next_data = await next_data.InsertAsync() ? (RebateConditionDetailView) null : throw new Exception(next_data.message);
            }
            else if (item.rcd_StdAmtFrom < conditionDetailView1.rcd_StdAmtFrom && item.rcd_StdAmtTo <= conditionDetailView1.rcd_StdAmtTo)
            {
              item.rcd_StdAmtTo = conditionDetailView1.rcd_StdAmtFrom;
              item.rcd_ModUser = p_app_employee.emp_Code;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
            }
            else if (item.rcd_StdAmtFrom >= conditionDetailView1.rcd_StdAmtFrom && item.rcd_StdAmtTo > conditionDetailView1.rcd_StdAmtTo)
            {
              item.rcd_StdAmtFrom = conditionDetailView1.rcd_StdAmtTo;
              item.rcd_ModUser = p_app_employee.emp_Code;
              if (!await item.UpdateAsync((UbModelBase) null))
                throw new Exception(item.message);
            }
            item = (RebateConditionDetailView) null;
          }
        }
        if (conditionDetailView1.rcd_Seq == 0 | is_delete)
        {
          if (conditionDetailView1.rcd_Seq == 0)
          {
            if (!await conditionDetailView1.CreateCodeAsync(p_db))
              throw new UniServiceException(conditionDetailView1.message, conditionDetailView1.TableCode.ToDescription() + " 코드(rcd_Seq) 생성 오류", 2);
          }
          if (!await conditionDetailView1.InsertAsync())
            throw new UniServiceException(conditionDetailView1.message, conditionDetailView1.TableCode.ToDescription() + " 등록 오류");
        }
        else if (!await conditionDetailView1.UpdateAsync((UbModelBase) null))
          throw new UniServiceException(conditionDetailView1.message, conditionDetailView1.TableCode.ToDescription() + " 등록 오류");
        if (lt_sbLogs.Count > 0)
        {
          foreach (StringBuilder stringBuilder in (IEnumerable<StringBuilder>) lt_sbLogs)
          {
            if (stringBuilder.Length > 0)
            {
              p_db.Execute(stringBuilder.ToString());
              stringBuilder.Clear();
            }
          }
          lt_sbLogs.Clear();
        }
        conditionDetailView1.db_status = 4;
        conditionDetailView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        conditionDetailView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        conditionDetailView1.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.HeaderInfo.rch_StoreCode = p_rs.GetFieldInt("rch_StoreCode");
      this.HeaderInfo.rch_Supplier = p_rs.GetFieldInt("rch_Supplier");
      this.HeaderInfo.rch_SiteID = p_rs.GetFieldLong("rch_SiteID");
      this.HeaderInfo.rch_ContractDate = p_rs.GetFieldDateTime("rch_ContractDate");
      this.HeaderInfo.rch_CalcPeriodType = p_rs.GetFieldInt("rch_CalcPeriodType");
      this.HeaderInfo.rch_StdAmtType = p_rs.GetFieldInt("rch_StdAmtType");
      this.HeaderInfo.rch_UseYn = p_rs.GetFieldString("rch_UseYn");
      this.HeaderInfo.rch_AddProperty = p_rs.GetFieldInt("rch_AddProperty");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<RebateConditionDetailView> SelectOneAsync(
      int p_rcd_StoreCode,
      int p_rcd_Supplier,
      int p_rcd_Seq,
      long p_rcd_SiteID = 0)
    {
      RebateConditionDetailView conditionDetailView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "rcd_StoreCode",
          (object) p_rcd_StoreCode
        },
        {
          (object) "rcd_Supplier",
          (object) p_rcd_Supplier
        },
        {
          (object) "rcd_Seq",
          (object) p_rcd_Seq
        }
      };
      if (p_rcd_SiteID > 0L)
        p_param.Add((object) "rcd_SiteID", (object) p_rcd_SiteID);
      return await conditionDetailView.SelectOneTAsync<RebateConditionDetailView>((object) p_param);
    }

    public async Task<IList<RebateConditionDetailView>> SelectListAsync(object p_param)
    {
      RebateConditionDetailView conditionDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(conditionDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, conditionDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(conditionDetailView1.GetSelectQuery(p_param)))
        {
          conditionDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + conditionDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<RebateConditionDetailView>) null;
        }
        IList<RebateConditionDetailView> lt_list = (IList<RebateConditionDetailView>) new List<RebateConditionDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            RebateConditionDetailView conditionDetailView2 = conditionDetailView1.OleDB.Create<RebateConditionDetailView>();
            if (conditionDetailView2.GetFieldValues(rs))
            {
              conditionDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(conditionDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + conditionDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "rcd_SiteID") && Convert.ToInt64(hashtable[(object) "rcd_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "rcd_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_SupplierName,su_SupplierViewCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        Hashtable p_param1 = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("rcd_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("rcd_Supplier"))
            p_param1.Add((object) "su_Supplier", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        else if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS (SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HEADER AS (SELECT rch_StoreCode,rch_Supplier,rch_SiteID,rch_ContractDate,rch_CalcPeriodType,rch_StdAmtType,rch_UseYn,rch_AddProperty" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.RebateConditionHeader, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("rcd_SiteID"))
            p_param1.Add((object) "rch_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("rcd_StoreCode"))
            p_param1.Add((object) "rch_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("rcd_Supplier"))
            p_param1.Add((object) "rch_Supplier", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TRebateConditionHeader().GetSelectWhereAnd((object) p_param1));
        else if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "rch_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  rcd_StoreCode,rcd_Supplier,rcd_Seq,rcd_SiteID,rcd_StdAmtFrom,rcd_StdAmtTo,rcd_RebateRate,rcd_AddProperty,rcd_InDate,rcd_InUser,rcd_ModDate,rcd_ModUser,rch_StoreCode,rch_Supplier,rch_SiteID,rch_ContractDate,rch_CalcPeriodType,rch_StdAmtType,rch_UseYn,rch_AddProperty,si_StoreName,su_SupplierName,su_SupplierViewCode,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_SUPPLIER ON rcd_Supplier=su_Supplier AND rcd_SiteID=su_SiteID INNER JOIN T_STORE ON rcd_StoreCode=si_StoreCode AND rcd_SiteID=si_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON rcd_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON rcd_ModUser=emp_CodeMod");
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
