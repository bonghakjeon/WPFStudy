// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Formtec.FormtecTemplatesView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniImages.UniTemplates.Common;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Formtec
{
  public class FormtecTemplatesView : TFormtecTemplates<FormtecTemplatesView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private PaperMetadata _PerperData;

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

    [JsonIgnore]
    public PaperMetadata PerperData
    {
      get => this._PerperData;
      set
      {
        this._PerperData = value;
        this.Changed(nameof (PerperData));
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

    protected override UbModelBase CreateClone => (UbModelBase) new FormtecTemplatesView();

    public override object Clone()
    {
      FormtecTemplatesView formtecTemplatesView = base.Clone() as FormtecTemplatesView;
      formtecTemplatesView.inEmpName = this.inEmpName;
      formtecTemplatesView.modEmpName = this.modEmpName;
      return (object) formtecTemplatesView;
    }

    public void PutData(FormtecTemplatesView pSource)
    {
      this.PutData((TFormtecTemplates) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ftf_SiteID == 0L)
      {
        this.message = "싸이트(ftf_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ftf_Title))
      {
        this.message = "타이틀(ftf_Title)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.ftf_FileName))
        return EnumDataCheck.Success;
      this.message = "파일명(ftf_FileName)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ftf_ID), " + str + ")+1 AS ftf_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ftf_ID", (object) intFormat);
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
          this.ftf_ID = uniOleDbRecordset.GetFieldLong(0);
        return this.ftf_ID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      FormtecTemplatesView formtecTemplatesView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(formtecTemplatesView.CreateCodeQuery()))
        {
          formtecTemplatesView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + formtecTemplatesView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          formtecTemplatesView.ftf_ID = rs.GetFieldLong(0);
        return formtecTemplatesView.ftf_ID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public bool SetThumbData(byte[] pByteValue)
    {
      if (pByteValue == null)
        return false;
      StringBuilder stringBuilder = new StringBuilder();
      int p_value = 0;
      int num1 = 0;
      foreach (byte num2 in pByteValue)
      {
        if (num2 == (byte) 0)
          ++p_value;
        if (UniTemplatesConverter.ToUniTemplateDiv(p_value) == EnumUniTemplateDiv.HEAD_LENGTH)
        {
          if (!UniTemplatesConverter.IsSignatureText(stringBuilder.ToString()))
            return false;
          int index1 = num1 + 1;
          int num3 = NumberHelper.ToInt(NumberHelper.ToReverse(((IEnumerable<byte>) pByteValue).ToList<byte>().GetRange(index1, index1 + 4).ToArray()));
          int index2 = index1 + 4 + num3;
          int num4 = NumberHelper.ToInt(NumberHelper.ToReverse(((IEnumerable<byte>) pByteValue).ToList<byte>().GetRange(index2, index2 + 4).ToArray()));
          int index3 = index2 + 4;
          string json = ((IEnumerable<byte>) pByteValue).ToList<byte>().GetRange(index3, index3 + num4).ToArray().ToString(EnumEncodingCodePage.UTF_8);
          if (!string.IsNullOrEmpty(json))
            this.PerperData = JsonSerializer.Deserialize<PaperMetadata>(json);
          int index4 = index3 + num4;
          int num5 = NumberHelper.ToInt(NumberHelper.ToReverse(((IEnumerable<byte>) pByteValue).ToList<byte>().GetRange(index4, index4 + 4).ToArray()));
          int index5 = index4 + 4 + num5;
          int length = NumberHelper.ToInt(NumberHelper.ToReverse(((IEnumerable<byte>) pByteValue).ToList<byte>().GetRange(index5, index5 + 4).ToArray()));
          int sourceIndex = index5 + 4;
          this.ftf_ThumbData = new byte[length];
          Array.Copy((Array) pByteValue, sourceIndex, (Array) this.ftf_ThumbData, 0, length);
          int num6 = sourceIndex + length;
          break;
        }
        if (UniTemplatesConverter.ToUniTemplateDiv(p_value) == EnumUniTemplateDiv.SIGNATURE)
          stringBuilder.Append(string.Format("%c", (object) (char) num2));
        ++num1;
        if (num1 > 50 && UniTemplatesConverter.ToUniTemplateDiv(p_value) == EnumUniTemplateDiv.SIGNATURE)
          return false;
      }
      return true;
    }

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.ftf_ID, (object) this.ftf_SiteID));
    }

    public override async Task<bool> InsertAsync()
    {
      FormtecTemplatesView formtecTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await formtecTemplatesView.\u003C\u003En__0())
        return false;
      if (formtecTemplatesView.IsOriginData)
      {
        int num = await formtecTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return formtecTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) formtecTemplatesView.ftf_ID, (object) formtecTemplatesView.ftf_SiteID));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ftf_ID, (object) this.ftf_SiteID));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      FormtecTemplatesView formtecTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await formtecTemplatesView.\u003C\u003En__1(p_old))
        return false;
      if (formtecTemplatesView.IsOriginData)
      {
        int num = await formtecTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return formtecTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) formtecTemplatesView.ftf_ID, (object) formtecTemplatesView.ftf_SiteID));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ftf_ID, (object) this.ftf_SiteID));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      FormtecTemplatesView formtecTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await formtecTemplatesView.\u003C\u003En__2())
        return false;
      if (formtecTemplatesView.IsOriginData)
      {
        int num = await formtecTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return formtecTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) formtecTemplatesView.ftf_ID, (object) formtecTemplatesView.ftf_SiteID));
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
          if (this.ftf_SiteID == 0L)
            this.ftf_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ftf_ID == 0L && !this.CreateCode(p_db))
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
      FormtecTemplatesView formtecTemplatesView = this;
      try
      {
        formtecTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != formtecTemplatesView.DataCheck(p_db))
            throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (formtecTemplatesView.ftf_SiteID == 0L)
            formtecTemplatesView.ftf_SiteID = p_app_employee.emp_SiteID;
          if (!formtecTemplatesView.IsPermit(p_app_employee))
            throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (formtecTemplatesView.ftf_ID == 0L)
        {
          if (!await formtecTemplatesView.CreateCodeAsync(p_db))
            throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await formtecTemplatesView.InsertAsync())
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        formtecTemplatesView.db_status = 4;
        formtecTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.Message;
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
        if (this.ftf_ID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID(ftf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      FormtecTemplatesView formtecTemplatesView = this;
      try
      {
        formtecTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != formtecTemplatesView.DataCheck(p_db))
            throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!formtecTemplatesView.IsPermit(p_app_employee))
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (formtecTemplatesView.ftf_ID == 0L)
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " ID(ftf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await formtecTemplatesView.UpdateAsync())
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        formtecTemplatesView.db_status = 4;
        formtecTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.Message;
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
        if (this.ftf_ID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID(ftf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      FormtecTemplatesView formtecTemplatesView = this;
      try
      {
        formtecTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != formtecTemplatesView.DataCheck(p_db))
            throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!formtecTemplatesView.IsPermit(p_app_employee))
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (formtecTemplatesView.ftf_ID == 0L)
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " ID(ftf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await formtecTemplatesView.DeleteAsync())
          throw new UniServiceException(formtecTemplatesView.message, formtecTemplatesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        formtecTemplatesView.db_status = 4;
        formtecTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        formtecTemplatesView.message = ex.Message;
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

    public async Task<FormtecTemplatesView> SelectOneAsync(
      long p_ftf_ID,
      long p_ftf_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      FormtecTemplatesView formtecTemplatesView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ftf_ID",
          (object) p_ftf_ID
        },
        {
          (object) "IDS_THUMB_IMAGE",
          (object) p_is_thumb_data
        },
        {
          (object) "IDS_ORIGIN_IMAGE",
          (object) p_is_file_data
        }
      };
      if (p_ftf_SiteID > 0L)
        p_param.Add((object) "ftf_SiteID", (object) p_ftf_SiteID);
      return await formtecTemplatesView.SelectOneTAsync<FormtecTemplatesView>((object) p_param);
    }

    public async Task<IList<FormtecTemplatesView>> SelectListAsync(object p_param)
    {
      FormtecTemplatesView formtecTemplatesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(formtecTemplatesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, formtecTemplatesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(formtecTemplatesView1.GetSelectQuery(p_param)))
        {
          formtecTemplatesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + formtecTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<FormtecTemplatesView>) null;
        }
        IList<FormtecTemplatesView> lt_list = (IList<FormtecTemplatesView>) new List<FormtecTemplatesView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            FormtecTemplatesView formtecTemplatesView2 = formtecTemplatesView1.OleDB.Create<FormtecTemplatesView>();
            if (formtecTemplatesView2.GetFieldValues(rs))
            {
              formtecTemplatesView2.row_number = lt_list.Count + 1;
              lt_list.Add(formtecTemplatesView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + formtecTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<FormtecTemplatesView> SelectEnumerableAsync(object p_param)
    {
      FormtecTemplatesView formtecTemplatesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(formtecTemplatesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, formtecTemplatesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(formtecTemplatesView1.GetSelectQuery(p_param)))
        {
          formtecTemplatesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + formtecTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            FormtecTemplatesView formtecTemplatesView2 = formtecTemplatesView1.OleDB.Create<FormtecTemplatesView>();
            if (formtecTemplatesView2.GetFieldValues(rs))
            {
              formtecTemplatesView2.row_number = ++row_number;
              yield return formtecTemplatesView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ftf_Title", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ftf_FileName", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "ftf_SiteID") && Convert.ToInt64(hashtable[(object) "ftf_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ftf_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IDS_THUMB_IMAGE") && Convert.ToBoolean(hashtable[(object) "IDS_THUMB_IMAGE"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IDS_THUMB_IMAGE"].ToString());
          if (hashtable.ContainsKey((object) "IDS_ORIGIN_IMAGE") && Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  ftf_ID,ftf_SiteID,ftf_Title,ftf_Url,ftf_FileName,ftf_OriginHash,ftf_InDate,ftf_InUser,ftf_ModDate,ftf_ModUser");
        if (flag1)
          stringBuilder.Append(",ftf_ThumbData");
        if (flag2)
          stringBuilder.Append(",ftf_OriginData");
        stringBuilder.Append("\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ftf_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ftf_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY ftf_ID");
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
