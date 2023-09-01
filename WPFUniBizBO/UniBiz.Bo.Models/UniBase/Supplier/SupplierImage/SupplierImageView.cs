// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierImage.SupplierImageView
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
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierImage
{
  public class SupplierImageView : TSupplierImage<SupplierImageView>
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
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SupplierImageView();

    public override object Clone()
    {
      SupplierImageView supplierImageView = base.Clone() as SupplierImageView;
      supplierImageView.inEmpName = this.inEmpName;
      supplierImageView.modEmpName = this.modEmpName;
      return (object) supplierImageView;
    }

    public void PutData(SupplierImageView pSource)
    {
      this.PutData((TSupplierImage) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.sui_SiteID == 0L)
      {
        this.message = "싸이트(sui_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sui_Supplier == 0)
      {
        this.message = "코드(sui_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSupplierImageKind(this.sui_Kind) == EnumSupplierImageKind.NONE)
      {
        this.message = "이미지 종류(sui_Kind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.IsExtensionImage(this.sui_ImgType))
        return EnumDataCheck.Success;
      this.message = "파일 타입(sui_ImgType)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (!p_app_employee.IsSupplierSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(sui_ID), 0)+1 AS sui_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.sui_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.sui_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      SupplierImageView supplierImageView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(supplierImageView.CreateCodeQuery()))
        {
          supplierImageView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierImageView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          supplierImageView.sui_ID = rs.GetFieldInt(0);
        return supplierImageView.sui_ID > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 등록됨.", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind));
    }

    public override async Task<bool> InsertAsync()
    {
      SupplierImageView supplierImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await supplierImageView.\u003C\u003En__0())
        return false;
      if (supplierImageView.IsOriginData)
      {
        int num = await supplierImageView.UpdateFileAsync() ? 1 : 0;
      }
      return supplierImageView.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 등록됨.", (object) supplierImageView.sui_ID, (object) supplierImageView.sui_SiteID, (object) supplierImageView.sui_Supplier, (object) supplierImageView.sui_Kind));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 변경됨.", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      SupplierImageView supplierImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await supplierImageView.\u003C\u003En__1(p_old))
        return false;
      if (supplierImageView.IsOriginData)
      {
        int num = await supplierImageView.UpdateFileAsync() ? 1 : 0;
      }
      return supplierImageView.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 변경됨.", (object) supplierImageView.sui_ID, (object) supplierImageView.sui_SiteID, (object) supplierImageView.sui_Supplier, (object) supplierImageView.sui_Kind));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 변경됨.", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      SupplierImageView supplierImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await supplierImageView.\u003C\u003En__2())
        return false;
      if (supplierImageView.IsOriginData)
      {
        int num = await supplierImageView.UpdateFileAsync() ? 1 : 0;
      }
      return supplierImageView.SetSuccessInfo(string.Format("({0},{1},{2},{3}) 변경됨.", (object) supplierImageView.sui_ID, (object) supplierImageView.sui_SiteID, (object) supplierImageView.sui_Supplier, (object) supplierImageView.sui_Kind));
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
          if (this.sui_SiteID == 0L)
            this.sui_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sui_ID == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
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
      SupplierImageView supplierImageView = this;
      try
      {
        supplierImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != supplierImageView.DataCheck(p_db))
            throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (supplierImageView.sui_SiteID == 0L)
            supplierImageView.sui_SiteID = p_app_employee.emp_SiteID;
          if (!supplierImageView.IsPermit(p_app_employee))
            throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (supplierImageView.sui_ID == 0 && !supplierImageView.CreateCode(p_db))
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await supplierImageView.InsertAsync())
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        supplierImageView.db_status = 4;
        supplierImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.Message;
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
        if (this.sui_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 업체 이미지(sui_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      SupplierImageView supplierImageView = this;
      try
      {
        supplierImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != supplierImageView.DataCheck(p_db))
            throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!supplierImageView.IsPermit(p_app_employee))
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (supplierImageView.sui_ID == 0)
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 업체 이미지(sui_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await supplierImageView.UpdateAsync())
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        supplierImageView.db_status = 4;
        supplierImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.Message;
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
        if (this.sui_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 업체 이미지(sui_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      SupplierImageView supplierImageView = this;
      try
      {
        supplierImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != supplierImageView.DataCheck(p_db))
            throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!supplierImageView.IsPermit(p_app_employee))
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (supplierImageView.sui_ID == 0)
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 업체 이미지(sui_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await supplierImageView.DeleteAsync())
          throw new UniServiceException(supplierImageView.message, supplierImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        supplierImageView.db_status = 4;
        supplierImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierImageView.message = ex.Message;
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

    public async Task<SupplierImageView> SelectOneAsync(
      int p_sui_ID,
      long p_sui_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      SupplierImageView supplierImageView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sui_ID",
          (object) p_sui_ID
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
      if (p_sui_SiteID > 0L)
        p_param.Add((object) "sui_SiteID", (object) p_sui_SiteID);
      return await supplierImageView.SelectOneTAsync<SupplierImageView>((object) p_param);
    }

    public async Task<IList<SupplierImageView>> SelectListAsync(object p_param)
    {
      SupplierImageView supplierImageView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(supplierImageView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, supplierImageView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(supplierImageView1.GetSelectQuery(p_param)))
        {
          supplierImageView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SupplierImageView>) null;
        }
        IList<SupplierImageView> lt_list = (IList<SupplierImageView>) new List<SupplierImageView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SupplierImageView supplierImageView2 = supplierImageView1.OleDB.Create<SupplierImageView>();
            if (supplierImageView2.GetFieldValues(rs))
            {
              supplierImageView2.row_number = lt_list.Count + 1;
              lt_list.Add(supplierImageView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_Supplier", hashtable[(object) "su_Supplier"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sui_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag3 = false;
        if (p_param is Hashtable hashtable1)
        {
          if (hashtable1.ContainsKey((object) "DBMS") && hashtable1[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable1[(object) "DBMS"].ToString();
          if (hashtable1.ContainsKey((object) "table") && hashtable1[(object) "table"].ToString().Length > 0)
            str = hashtable1[(object) "table"].ToString();
          if (hashtable1.ContainsKey((object) "_ORDER_BY_COL_") && hashtable1[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable1[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable1.ContainsKey((object) "sui_SiteID") && Convert.ToInt64(hashtable1[(object) "sui_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable1[(object) "sui_SiteID"].ToString());
          if (hashtable1.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable1[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable1[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable1.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable1[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable1[(object) "IS_FILE_IMAGE_VIEW"].ToString());
          if (hashtable1.ContainsKey((object) "_HEADER_CONDITION_"))
            flag3 = true;
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        if (flag3)
        {
          stringBuilder.Append(",T_HEADER AS (");
          if (p_param is Hashtable hashtable2)
            stringBuilder.Append(new TSupplier().GetSelectQuery(hashtable2[(object) "_HEADER_CONDITION_"]));
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(" SELECT  sui_ID,sui_SiteID,sui_Supplier,sui_Kind,sui_ImgType,sui_ImgFileName,sui_ThumbSize,sui_OriginSize,sui_InDate,sui_InUser,sui_ModDate,sui_ModUser,inEmpName,modEmpName");
        if (flag1)
          stringBuilder.Append(",sui_ThumbData");
        if (flag2)
          stringBuilder.Append(",sui_OriginData");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (flag3)
          stringBuilder.Append(" INNER JOIN T_HEADER ON sui_Supplier=su_Supplier AND sui_SiteID=su_SiteID");
        stringBuilder.Append(" LEFT OUTER JOIN T_EMPLOYEE_IN ON sui_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON sui_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY sui_ID");
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
