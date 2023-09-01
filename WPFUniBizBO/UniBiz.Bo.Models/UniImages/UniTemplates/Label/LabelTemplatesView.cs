// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Label.LabelTemplatesView
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

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Label
{
  public class LabelTemplatesView : TLabelTemplates<LabelTemplatesView>
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

    protected override UbModelBase CreateClone => (UbModelBase) new LabelTemplatesView();

    public override object Clone()
    {
      LabelTemplatesView labelTemplatesView = base.Clone() as LabelTemplatesView;
      labelTemplatesView.inEmpName = this.inEmpName;
      labelTemplatesView.modEmpName = this.modEmpName;
      return (object) labelTemplatesView;
    }

    public void PutData(LabelTemplatesView pSource)
    {
      this.PutData((TLabelTemplates) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ltf_SiteID == 0L)
      {
        this.message = "싸이트(ltf_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ltf_Title))
      {
        this.message = "타이틀(ltf_Title)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.ltf_FileName))
        return EnumDataCheck.Success;
      this.message = "파일명(ltf_FileName)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ltf_ID), " + str + ")+1 AS ltf_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ltf_ID", (object) intFormat);
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
          this.ltf_ID = uniOleDbRecordset.GetFieldLong(0);
        return this.ltf_ID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      LabelTemplatesView labelTemplatesView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(labelTemplatesView.CreateCodeQuery()))
        {
          labelTemplatesView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + labelTemplatesView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          labelTemplatesView.ltf_ID = rs.GetFieldLong(0);
        return labelTemplatesView.ltf_ID > 0L;
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
          this.ltf_ThumbData = new byte[length];
          Array.Copy((Array) pByteValue, sourceIndex, (Array) this.ltf_ThumbData, 0, length);
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
      return this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.ltf_ID, (object) this.ltf_SiteID));
    }

    public override async Task<bool> InsertAsync()
    {
      LabelTemplatesView labelTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await labelTemplatesView.\u003C\u003En__0())
        return false;
      if (labelTemplatesView.IsOriginData)
      {
        int num = await labelTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return labelTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) labelTemplatesView.ltf_ID, (object) labelTemplatesView.ltf_SiteID));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ltf_ID, (object) this.ltf_SiteID));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      LabelTemplatesView labelTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await labelTemplatesView.\u003C\u003En__1(p_old))
        return false;
      if (labelTemplatesView.IsOriginData)
      {
        int num = await labelTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return labelTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) labelTemplatesView.ltf_ID, (object) labelTemplatesView.ltf_SiteID));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.ltf_ID, (object) this.ltf_SiteID));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      LabelTemplatesView labelTemplatesView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await labelTemplatesView.\u003C\u003En__2())
        return false;
      if (labelTemplatesView.IsOriginData)
      {
        int num = await labelTemplatesView.UpdateFileAsync() ? 1 : 0;
      }
      return labelTemplatesView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) labelTemplatesView.ltf_ID, (object) labelTemplatesView.ltf_SiteID));
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
          if (this.ltf_SiteID == 0L)
            this.ltf_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ltf_ID == 0L && !this.CreateCode(p_db))
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
      LabelTemplatesView labelTemplatesView = this;
      try
      {
        labelTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != labelTemplatesView.DataCheck(p_db))
            throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (labelTemplatesView.ltf_SiteID == 0L)
            labelTemplatesView.ltf_SiteID = p_app_employee.emp_SiteID;
          if (!labelTemplatesView.IsPermit(p_app_employee))
            throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (labelTemplatesView.ltf_ID == 0L)
        {
          if (!await labelTemplatesView.CreateCodeAsync(p_db))
            throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await labelTemplatesView.InsertAsync())
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        labelTemplatesView.db_status = 4;
        labelTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.Message;
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
        if (this.ltf_ID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID(ltf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      LabelTemplatesView labelTemplatesView = this;
      try
      {
        labelTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != labelTemplatesView.DataCheck(p_db))
            throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!labelTemplatesView.IsPermit(p_app_employee))
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (labelTemplatesView.ltf_ID == 0L)
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " ID(ltf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await labelTemplatesView.UpdateAsync())
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        labelTemplatesView.db_status = 4;
        labelTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.Message;
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
        if (this.ltf_ID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID(ltf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      LabelTemplatesView labelTemplatesView = this;
      try
      {
        labelTemplatesView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != labelTemplatesView.DataCheck(p_db))
            throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!labelTemplatesView.IsPermit(p_app_employee))
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 권한 검사 실패");
        if (labelTemplatesView.ltf_ID == 0L)
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " ID(ltf_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await labelTemplatesView.DeleteAsync())
          throw new UniServiceException(labelTemplatesView.message, labelTemplatesView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        labelTemplatesView.db_status = 4;
        labelTemplatesView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        labelTemplatesView.message = ex.Message;
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

    public async Task<LabelTemplatesView> SelectOneAsync(
      long p_ltf_ID,
      long p_ltf_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      LabelTemplatesView labelTemplatesView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ltf_ID",
          (object) p_ltf_ID
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
      if (p_ltf_SiteID > 0L)
        p_param.Add((object) "ltf_SiteID", (object) p_ltf_SiteID);
      return await labelTemplatesView.SelectOneTAsync<LabelTemplatesView>((object) p_param);
    }

    public async Task<IList<LabelTemplatesView>> SelectListAsync(object p_param)
    {
      LabelTemplatesView labelTemplatesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(labelTemplatesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, labelTemplatesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(labelTemplatesView1.GetSelectQuery(p_param)))
        {
          labelTemplatesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + labelTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<LabelTemplatesView>) null;
        }
        IList<LabelTemplatesView> lt_list = (IList<LabelTemplatesView>) new List<LabelTemplatesView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            LabelTemplatesView labelTemplatesView2 = labelTemplatesView1.OleDB.Create<LabelTemplatesView>();
            if (labelTemplatesView2.GetFieldValues(rs))
            {
              labelTemplatesView2.row_number = lt_list.Count + 1;
              lt_list.Add(labelTemplatesView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + labelTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<LabelTemplatesView> SelectEnumerableAsync(object p_param)
    {
      LabelTemplatesView labelTemplatesView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(labelTemplatesView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, labelTemplatesView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(labelTemplatesView1.GetSelectQuery(p_param)))
        {
          labelTemplatesView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + labelTemplatesView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            LabelTemplatesView labelTemplatesView2 = labelTemplatesView1.OleDB.Create<LabelTemplatesView>();
            if (labelTemplatesView2.GetFieldValues(rs))
            {
              labelTemplatesView2.row_number = ++row_number;
              yield return labelTemplatesView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ltf_Title", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "ltf_SiteID") && Convert.ToInt64(hashtable[(object) "ltf_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ltf_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IDS_THUMB_IMAGE") && Convert.ToBoolean(hashtable[(object) "IDS_THUMB_IMAGE"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IDS_THUMB_IMAGE"].ToString());
          if (hashtable.ContainsKey((object) "IDS_ORIGIN_IMAGE") && Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  ltf_ID,ltf_SiteID,ltf_Title,ltf_Url,ltf_FileName,ltf_OriginHash,ltf_InDate,ltf_InUser,ltf_ModDate,ltf_ModUser");
        if (flag1)
          stringBuilder.Append(",ltf_ThumbData");
        if (flag2)
          stringBuilder.Append(",ltf_OriginData");
        stringBuilder.Append("\n,inEmpName,modEmpName");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ltf_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ltf_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY ltf_ID");
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
