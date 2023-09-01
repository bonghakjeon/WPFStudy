// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Label.LabelTemplateColsView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Label
{
  public class LabelTemplateColsView : TLabelTemplateCols<LabelTemplateColsView>
  {
    private string _ltf_Title;
    private string _ltf_FileName;
    private int _printQty;

    public string ltf_Title
    {
      get => this._ltf_Title;
      set
      {
        this._ltf_Title = value;
        this.Changed(nameof (ltf_Title));
      }
    }

    public string ltf_FileName
    {
      get => this._ltf_FileName;
      set
      {
        this._ltf_FileName = value;
        this.Changed(nameof (ltf_FileName));
      }
    }

    public int printQty
    {
      get => this._printQty;
      set
      {
        this._printQty = value;
        this.Changed(nameof (printQty));
      }
    }

    public override void Clear()
    {
      base.Clear();
      this.ltf_Title = this.ltf_FileName = string.Empty;
      this.printQty = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new LabelTemplateColsView();

    public override object Clone()
    {
      LabelTemplateColsView templateColsView = base.Clone() as LabelTemplateColsView;
      templateColsView.ltf_Title = this.ltf_Title;
      templateColsView.ltf_FileName = this.ltf_FileName;
      templateColsView.printQty = this.printQty;
      return (object) templateColsView;
    }

    public void PutData(LabelTemplateColsView pSource)
    {
      this.PutData((TLabelTemplateCols) pSource);
      this.ltf_Title = pSource.ltf_Title;
      this.ltf_FileName = pSource.ltf_FileName;
      this.printQty = pSource.printQty;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ltc_SiteID == 0L)
      {
        this.message = "싸이트(ltc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ltc_ID != 0L)
        return EnumDataCheck.Success;
      this.message = "컬럼ID(ltc_ID)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return string.Format(" SELECT {0}(MAX({1}), {2})+1 AS {3}", (object) DbQueryHelper.ToIsNULL(), (object) "ltc_Seq", (object) 0, (object) "ltc_Seq") + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "ltc_ID", (object) this.ltc_ID);
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
          this.ltc_Seq = uniOleDbRecordset.GetFieldInt(0);
        return this.ltc_Seq > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      LabelTemplateColsView templateColsView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(templateColsView.CreateCodeQuery()))
        {
          templateColsView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          templateColsView.ltc_Seq = rs.GetFieldInt(0);
        return templateColsView.ltc_Seq > 0;
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
          if (this.ltc_SiteID == 0L)
            this.ltc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ltc_Seq == 0 && !this.CreateCode(p_db))
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
      LabelTemplateColsView templateColsView = this;
      try
      {
        templateColsView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await templateColsView.DataCheckAsync(p_db))
            throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (templateColsView.ltc_SiteID == 0L)
            templateColsView.ltc_SiteID = p_app_employee.emp_SiteID;
          if (!templateColsView.IsPermit(p_app_employee))
            throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (templateColsView.ltc_Seq == 0 && !templateColsView.CreateCode(p_db))
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await templateColsView.InsertAsync())
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        templateColsView.db_status = 4;
        templateColsView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.Message;
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
        if (this.ltc_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(ltc_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      LabelTemplateColsView templateColsView = this;
      try
      {
        templateColsView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != templateColsView.DataCheck(p_db))
            throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!templateColsView.IsPermit(p_app_employee))
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 권한 검사 실패");
        if (templateColsView.ltc_Seq == 0)
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 순번(ltc_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await templateColsView.UpdateAsync())
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        templateColsView.db_status = 4;
        templateColsView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.Message;
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
        if (this.ltc_Seq == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(ltc_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      LabelTemplateColsView templateColsView = this;
      try
      {
        templateColsView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await templateColsView.DataCheckAsync(p_db))
            throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!templateColsView.IsPermit(p_app_employee))
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 권한 검사 실패");
        if (templateColsView.ltc_Seq == 0)
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 순번(ltc_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await templateColsView.DeleteAsync())
          throw new UniServiceException(templateColsView.message, templateColsView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        templateColsView.db_status = 4;
        templateColsView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        templateColsView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.ltf_Title = p_rs.GetFieldString("ltf_Title");
      this.ltf_FileName = p_rs.GetFieldString("ltf_FileName");
      return true;
    }

    public async Task<LabelTemplateColsView> SelectOneAsync(
      long p_ltc_ID,
      int p_ltc_Seq,
      long p_ltc_SiteID = 0)
    {
      LabelTemplateColsView templateColsView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ltc_ID",
          (object) p_ltc_ID
        },
        {
          (object) "ltc_Seq",
          (object) p_ltc_Seq
        }
      };
      if (p_ltc_SiteID > 0L)
        p_param.Add((object) "ltc_SiteID", (object) p_ltc_SiteID);
      return await templateColsView.SelectOneTAsync<LabelTemplateColsView>((object) p_param);
    }

    public LabelTemplateColsView SelectOne(long p_ltc_ID, int p_ltc_Seq, long p_ltc_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ltc_ID",
          (object) p_ltc_ID
        },
        {
          (object) "ltc_Seq",
          (object) p_ltc_Seq
        }
      };
      if (p_ltc_SiteID > 0L)
        p_param.Add((object) "ltc_SiteID", (object) p_ltc_SiteID);
      return this.SelectOneT<LabelTemplateColsView>((object) p_param);
    }

    public async Task<IList<LabelTemplateColsView>> SelectListAsync(object p_param)
    {
      LabelTemplateColsView templateColsView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(templateColsView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, templateColsView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(templateColsView1.GetSelectQuery(p_param)))
        {
          templateColsView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<LabelTemplateColsView>) null;
        }
        IList<LabelTemplateColsView> lt_list = (IList<LabelTemplateColsView>) new List<LabelTemplateColsView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            LabelTemplateColsView templateColsView2 = templateColsView1.OleDB.Create<LabelTemplateColsView>();
            if (templateColsView2.GetFieldValues(rs))
            {
              templateColsView2.row_number = lt_list.Count + 1;
              lt_list.Add(templateColsView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<LabelTemplateColsView> SelectEnumerableAsync(object p_param)
    {
      LabelTemplateColsView templateColsView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(templateColsView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, templateColsView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(templateColsView1.GetSelectQuery(p_param)))
        {
          templateColsView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            LabelTemplateColsView templateColsView2 = templateColsView1.OleDB.Create<LabelTemplateColsView>();
            if (templateColsView2.GetFieldValues(rs))
            {
              templateColsView2.row_number = ++row_number;
              yield return templateColsView2;
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

    public async Task<IList<LabelTemplateColsView>> SelectListExistsAsync(object p_param)
    {
      LabelTemplateColsView templateColsView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(templateColsView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, templateColsView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(templateColsView1.GetSelectQuery(p_param)))
        {
          templateColsView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<LabelTemplateColsView>) null;
        }
        IList<LabelTemplateColsView> lt_list = (IList<LabelTemplateColsView>) new List<LabelTemplateColsView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            LabelTemplateColsView templateColsView2 = templateColsView1.OleDB.Create<LabelTemplateColsView>();
            if (templateColsView2.GetFieldValues(rs))
            {
              templateColsView2.row_number = lt_list.Count + 1;
              lt_list.Add(templateColsView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + templateColsView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ltc_ColID", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ltc_FormatDataID", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ltf_FileName", hashtable[(object) "_KEY_WORD_"]));
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
        int num1 = 0;
        string empty = string.Empty;
        long num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ltc_SiteID") && Convert.ToInt64(hashtable[(object) "ltc_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "ltc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_HEADER AS (\nSELECT ltf_ID,ltf_SiteID,ltf_Title,ltf_FileName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) TableCodeType.LabelTemplates, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "ltf_SiteID", (object) num2) + ") ");
        stringBuilder.Append("\nSELECT  ltc_ID,ltc_Seq,ltc_SiteID,ltc_ColID,ltc_FormatDataID,ltc_Count,ltc_Point,ltc_InDate,ltc_ModDate,ltf_Title,ltf_FileName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON ltc_ID=ltf_ID AND ltc_SiteID=ltf_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY ltc_ID");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY ltc_ID");
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
