// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpImage.EmpImageView
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

namespace UniBiz.Bo.Models.UniBase.Employee.EmpImage
{
  public class EmpImageView : TEmpImage<EmpImageView>
  {
    private string _inEmpName;
    private string _modEmpName;

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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmpImageView();

    public override object Clone()
    {
      EmpImageView empImageView = base.Clone() as EmpImageView;
      empImageView.inEmpName = this.inEmpName;
      empImageView.modEmpName = this.modEmpName;
      return (object) empImageView;
    }

    public void PutData(EmpImageView pSource)
    {
      this.PutData((TEmpImage) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ei_EmpCode == 0)
      {
        this.message = "사원코드(ei_EmpCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ei_SiteID == 0L)
      {
        this.message = "싸이트(ei_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.IsExtensionImage(this.ei_ImgType))
        return EnumDataCheck.Success;
      this.message = "이미지타입(ei_ImgType)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (p_app_employee.emp_Code == this.ei_EmpCode || p_app_employee.IsEmployeeSave)
        return true;
      this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
      return false;
    }

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) this.ei_EmpCode));
    }

    public override async Task<bool> InsertAsync()
    {
      EmpImageView empImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await empImageView.\u003C\u003En__0())
        return false;
      if (empImageView.IsOriginData)
      {
        int num = await empImageView.UpdateFileAsync() ? 1 : 0;
      }
      return empImageView.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) empImageView.ei_EmpCode));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.ei_EmpCode));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      EmpImageView empImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await empImageView.\u003C\u003En__1(p_old))
        return false;
      if (empImageView.IsOriginData)
      {
        int num = await empImageView.UpdateFileAsync() ? 1 : 0;
      }
      return empImageView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) empImageView.ei_EmpCode));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.ei_EmpCode));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      EmpImageView empImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await empImageView.\u003C\u003En__2())
        return false;
      if (empImageView.IsOriginData)
      {
        int num = await empImageView.UpdateFileAsync() ? 1 : 0;
      }
      return empImageView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) empImageView.ei_EmpCode));
    }

    public override bool InsertData(
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
        else
        {
          if (this.ei_SiteID == 0L)
            this.ei_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
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

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      EmpImageView empImageView = this;
      try
      {
        empImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != empImageView.DataCheck(p_db))
            throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (empImageView.ei_SiteID == 0L)
            empImageView.ei_SiteID = p_app_employee.emp_SiteID;
          if (!empImageView.IsPermit(p_app_employee))
            throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await empImageView.InsertAsync())
          throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        empImageView.db_status = 4;
        empImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.Message;
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
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
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

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      EmpImageView empImageView = this;
      try
      {
        empImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != empImageView.DataCheck(p_db))
            throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!empImageView.IsPermit(p_app_employee))
          throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await empImageView.UpdateAsync())
          throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        empImageView.db_status = 4;
        empImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.Message;
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
      EmpImageView empImageView = this;
      try
      {
        empImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != empImageView.DataCheck(p_db))
            throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!empImageView.IsPermit(p_app_employee))
          throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await empImageView.DeleteAsync())
          throw new UniServiceException(empImageView.message, empImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        empImageView.db_status = 4;
        empImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        empImageView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<EmpImageView> SelectOneAsync(
      int p_ei_EmpCode,
      long p_ei_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      EmpImageView empImageView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ei_EmpCode",
          (object) p_ei_EmpCode
        },
        {
          (object) "IS_THUMB_IMAGE_VIEW",
          (object) p_is_thumb_data
        },
        {
          (object) "IS_FILE_IMAGE_VIEW",
          (object) p_is_file_data
        }
      };
      if (p_ei_SiteID > 0L)
        p_param.Add((object) "ei_SiteID", (object) p_ei_SiteID);
      return await empImageView.SelectOneTAsync<EmpImageView>((object) p_param);
    }

    public async Task<IList<EmpImageView>> SelectListAsync(object p_param)
    {
      EmpImageView empImageView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(empImageView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, empImageView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(empImageView1.GetSelectQuery(p_param)))
        {
          empImageView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<EmpImageView>) null;
        }
        IList<EmpImageView> lt_list = (IList<EmpImageView>) new List<EmpImageView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            EmpImageView empImageView2 = empImageView1.OleDB.Create<EmpImageView>();
            if (empImageView2.GetFieldValues(rs))
            {
              empImageView2.row_number = lt_list.Count + 1;
              lt_list.Add(empImageView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ei_EmpCode", hashtable[(object) "emp_Code"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ei_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
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
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ei_SiteID") && Convert.ToInt64(hashtable[(object) "ei_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ei_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  ei_EmpCode,ei_SiteID,ei_ImgFileName,ei_ImgType,ei_ThumbSize,ei_OriginSize,ei_InDate,ei_InUser,ei_ModDate,ei_ModUser,inEmpName,modEmpName");
        if (flag1)
          stringBuilder.Append(",ei_ThumbData");
        if (flag2)
          stringBuilder.Append(",ei_OriginData");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON ei_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON ei_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ei_EmpCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
