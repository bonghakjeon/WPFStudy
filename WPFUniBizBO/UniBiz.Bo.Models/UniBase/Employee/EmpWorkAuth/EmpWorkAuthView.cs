// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth.EmpWorkAuthView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth
{
  public class EmpWorkAuthView : TEmpWorkAuth<EmpWorkAuthView>
  {
    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new EmpWorkAuthView();

    public override object Clone() => (object) (base.Clone() as EmpWorkAuthView);

    public void PutData(EmpWorkAuthView pSource) => this.PutData((TEmpWorkAuth) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (this.emp_SiteID == 0L)
      {
        this.message = "싸이트(emp_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.emp_Code == 0)
      {
        this.message = "사원코드(emp_Code)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.emp_TypeNo != 0)
        return EnumDataCheck.Success;
      this.message = "작업 권한 타입(emp_TypeNo)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (!p_app_employee.IsEmployeePermitSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
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
          if (this.emp_SiteID == 0L)
            this.emp_SiteID = p_app_employee.emp_SiteID;
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
      EmpWorkAuthView empWorkAuthView = this;
      try
      {
        empWorkAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != empWorkAuthView.DataCheck(p_db))
            throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (empWorkAuthView.emp_SiteID == 0L)
            empWorkAuthView.emp_SiteID = p_app_employee.emp_SiteID;
          if (!empWorkAuthView.IsPermit(p_app_employee))
            throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await empWorkAuthView.InsertAsync())
          throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 등록 오류");
        empWorkAuthView.db_status = 4;
        empWorkAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        empWorkAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        empWorkAuthView.message = ex.Message;
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
      EmpWorkAuthView empWorkAuthView = this;
      try
      {
        empWorkAuthView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != empWorkAuthView.DataCheck(p_db))
            throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!empWorkAuthView.IsPermit(p_app_employee))
          throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await empWorkAuthView.DeleteAsync())
          throw new UniServiceException(empWorkAuthView.message, empWorkAuthView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        empWorkAuthView.db_status = 4;
        empWorkAuthView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empWorkAuthView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empWorkAuthView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);
  }
}
