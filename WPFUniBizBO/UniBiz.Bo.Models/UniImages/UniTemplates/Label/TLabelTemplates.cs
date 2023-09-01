// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Label.TLabelTemplates
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Label
{
  public class TLabelTemplates : UbModelBase<TLabelTemplates>
  {
    private long _ltf_ID;
    private long _ltf_SiteID;
    private string _ltf_Title;
    private string _ltf_Url;
    private string _ltf_FileName;
    protected byte[] _ltf_ThumbData = new byte[0];
    protected byte[] _ltf_OriginData = new byte[0];
    private string _ltf_OriginHash;
    private DateTime? _ltf_InDate;
    private int _ltf_InUser;
    private DateTime? _ltf_ModDate;
    private int _ltf_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ltf_ID
    };

    public long ltf_ID
    {
      get => this._ltf_ID;
      set
      {
        this._ltf_ID = value;
        this.Changed(nameof (ltf_ID));
      }
    }

    public long ltf_SiteID
    {
      get => this._ltf_SiteID;
      set
      {
        this._ltf_SiteID = value;
        this.Changed(nameof (ltf_SiteID));
      }
    }

    public string ltf_Title
    {
      get => this._ltf_Title;
      set
      {
        this._ltf_Title = UbModelBase.LeftStr(value, 300).Replace("'", "´");
        this.Changed(nameof (ltf_Title));
      }
    }

    public string ltf_Url
    {
      get => this._ltf_Url;
      set
      {
        this._ltf_Url = UbModelBase.LeftStr(value, 300).Replace("'", "´");
        this.Changed(nameof (ltf_Url));
      }
    }

    public string ltf_FileName
    {
      get => this._ltf_FileName;
      set
      {
        this._ltf_FileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ltf_FileName));
        this.Changed("Base64Data");
      }
    }

    public byte[] ltf_ThumbData
    {
      get => this._ltf_ThumbData;
      set
      {
        this._ltf_ThumbData = value;
        this.Changed(nameof (ltf_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.ltf_ThumbData != null && this.ltf_ThumbData.Length != 0;

    public byte[] ltf_OriginData
    {
      get => this._ltf_OriginData;
      set
      {
        this._ltf_OriginData = value;
        this.Changed(nameof (ltf_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.ltf_OriginData != null && this.ltf_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        if (this.IsOriginData)
          return this.ltf_OriginData.ToBase64();
        if (!this.IsThumbData)
          return (string) null;
        EnumFileExtension enumFileExtension = string.IsNullOrEmpty(this.ltf_FileName) ? EnumFileExtension.FILE : Enum2StrConverter.GetFileExtensionType(this.ltf_FileName.ToRight(4));
        return "data:image/" + (enumFileExtension == EnumFileExtension.FILE ? "jpg" : enumFileExtension.ToString()) + ";base64," + this.ltf_ThumbData.ToBase64();
      }
    }

    public string ltf_OriginHash
    {
      get => this._ltf_OriginHash;
      set
      {
        this._ltf_OriginHash = UbModelBase.LeftStr(value, 512).Replace("'", "´");
        this.Changed(nameof (ltf_OriginHash));
      }
    }

    public DateTime? ltf_InDate
    {
      get => this._ltf_InDate;
      set
      {
        this._ltf_InDate = value;
        this.Changed(nameof (ltf_InDate));
      }
    }

    public int ltf_InUser
    {
      get => this._ltf_InUser;
      set
      {
        this._ltf_InUser = value;
        this.Changed(nameof (ltf_InUser));
      }
    }

    public DateTime? ltf_ModDate
    {
      get => this._ltf_ModDate;
      set
      {
        this._ltf_ModDate = value;
        this.Changed(nameof (ltf_ModDate));
      }
    }

    public int ltf_ModUser
    {
      get => this._ltf_ModUser;
      set
      {
        this._ltf_ModUser = value;
        this.Changed(nameof (ltf_ModUser));
      }
    }

    public override DateTime? ModDate => this.ltf_ModDate ?? (this.ltf_ModDate = this.ltf_InDate);

    public TLabelTemplates() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ltf_ID", new TTableColumn()
      {
        tc_orgin_name = "ltf_ID",
        tc_trans_name = "ID"
      });
      columnInfo.Add("ltf_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ltf_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ltf_Title", new TTableColumn()
      {
        tc_orgin_name = "ltf_Title",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("ltf_Url", new TTableColumn()
      {
        tc_orgin_name = "ltf_Url",
        tc_trans_name = "URL"
      });
      columnInfo.Add("ltf_FileName", new TTableColumn()
      {
        tc_orgin_name = "ltf_FileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("ltf_ThumbData", new TTableColumn()
      {
        tc_orgin_name = "ltf_ThumbData",
        tc_trans_name = "썸네일"
      });
      columnInfo.Add("ltf_OriginData", new TTableColumn()
      {
        tc_orgin_name = "ltf_OriginData",
        tc_trans_name = "템플릿"
      });
      columnInfo.Add("ltf_OriginHash", new TTableColumn()
      {
        tc_orgin_name = "ltf_OriginHash",
        tc_trans_name = "템플릿 Hash"
      });
      columnInfo.Add("ltf_InDate", new TTableColumn()
      {
        tc_orgin_name = "ltf_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ltf_InUser", new TTableColumn()
      {
        tc_orgin_name = "ltf_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ltf_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ltf_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ltf_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ltf_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.LabelTemplates;
      this.ltf_ID = this.ltf_SiteID = 0L;
      this.ltf_Title = this.ltf_Url = this.ltf_FileName = string.Empty;
      this.ltf_ThumbData = new byte[0];
      this.ltf_OriginData = new byte[0];
      this.ltf_OriginHash = string.Empty;
      this.ltf_InDate = new DateTime?();
      this.ltf_InUser = 0;
      this.ltf_ModDate = new DateTime?();
      this.ltf_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TLabelTemplates();

    public override object Clone()
    {
      TLabelTemplates tlabelTemplates = base.Clone() as TLabelTemplates;
      tlabelTemplates.ltf_ID = this.ltf_ID;
      tlabelTemplates.ltf_SiteID = this.ltf_SiteID;
      tlabelTemplates.ltf_Title = this.ltf_Title;
      tlabelTemplates.ltf_Url = this.ltf_Url;
      tlabelTemplates.ltf_FileName = this.ltf_FileName;
      tlabelTemplates.ltf_ThumbData = this.ltf_ThumbData;
      tlabelTemplates.ltf_OriginData = this.ltf_OriginData;
      tlabelTemplates.ltf_OriginHash = this.ltf_OriginHash;
      tlabelTemplates.ltf_InDate = this.ltf_InDate;
      tlabelTemplates.ltf_InUser = this.ltf_InUser;
      tlabelTemplates.ltf_ModDate = this.ltf_ModDate;
      tlabelTemplates.ltf_ModUser = this.ltf_ModUser;
      return (object) tlabelTemplates;
    }

    public void PutData(TLabelTemplates pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ltf_ID = pSource.ltf_ID;
      this.ltf_SiteID = pSource.ltf_SiteID;
      this.ltf_Title = pSource.ltf_Title;
      this.ltf_Url = pSource.ltf_Url;
      this.ltf_FileName = pSource.ltf_FileName;
      this.ltf_ThumbData = pSource.ltf_ThumbData;
      this.ltf_OriginData = pSource.ltf_OriginData;
      this.ltf_OriginHash = pSource.ltf_OriginHash;
      this.ltf_InDate = pSource.ltf_InDate;
      this.ltf_ModDate = pSource.ltf_ModDate;
      this.ltf_InUser = pSource.ltf_InUser;
      this.ltf_ModUser = pSource.ltf_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ltf_ID = p_rs.GetFieldLong("ltf_ID");
        if (this.ltf_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ltf_SiteID = p_rs.GetFieldLong("ltf_SiteID");
        this.ltf_Title = p_rs.GetFieldString("ltf_Title");
        this.ltf_Url = p_rs.GetFieldString("ltf_Url");
        this.ltf_FileName = p_rs.GetFieldString("ltf_FileName");
        if (p_rs.IsFieldName("ltf_ThumbData"))
        {
          if (this.ltf_ThumbData != null)
            this.ltf_ThumbData = (byte[]) null;
          this.ltf_ThumbData = p_rs.GetFieldBytes("ltf_ThumbData");
        }
        if (p_rs.IsFieldName("ltf_OriginData"))
        {
          if (this.ltf_OriginData != null)
            this.ltf_OriginData = (byte[]) null;
          this.ltf_OriginData = p_rs.GetFieldBytes("ltf_OriginData");
        }
        this.ltf_OriginHash = p_rs.GetFieldString("ltf_OriginHash");
        this.ltf_InDate = p_rs.GetFieldDateTime("ltf_InDate");
        this.ltf_InUser = p_rs.GetFieldInt("ltf_InUser");
        this.ltf_ModDate = p_rs.GetFieldDateTime("ltf_ModDate");
        this.ltf_ModUser = p_rs.GetFieldInt("ltf_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    protected bool UpdateFile()
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        if (!this.IsOriginData)
          return false;
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ltf_OriginData=?,ltf_FileName=?");
        if (this.IsThumbData)
          stringBuilder.Append(",ltf_ThumbData=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ltf_ID", (object) this.ltf_ID) + string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) this.ltf_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@ltf_OriginData", OleDbType.LongVarBinary, this.ltf_OriginData.Length, "ltf_OriginData").Value = (object) this.ltf_OriginData;
          command.Parameters.Add("@ltf_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.ltf_FileName)).Value = (object) this.ltf_FileName;
          if (this.IsThumbData)
            command.Parameters.Add("@ltf_ThumbData", OleDbType.LongVarBinary, this.ltf_ThumbData.Length, "ltf_ThumbData").Value = (object) this.ltf_ThumbData;
          command.CommandTimeout = 0;
          if (!uniOleDbRecordset.Update(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) uniOleDbRecordset.LastErrorID) + "     " + uniOleDbRecordset.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return this.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    protected async Task<bool> UpdateFileAsync()
    {
      TLabelTemplates tlabelTemplates = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!tlabelTemplates.IsOriginData)
          return false;
        db = new UniOleDatabase(tlabelTemplates.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tlabelTemplates.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) tlabelTemplates.TableCode) + " ltf_OriginData=?,ltf_FileName=?");
        if (tlabelTemplates.IsThumbData)
          stringBuilder.Append(",ltf_ThumbData=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ltf_ID", (object) tlabelTemplates.ltf_ID) + string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) tlabelTemplates.ltf_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@ltf_OriginData", OleDbType.LongVarBinary, tlabelTemplates.ltf_OriginData.Length, "ltf_OriginData").Value = (object) tlabelTemplates.ltf_OriginData;
          command.Parameters.Add("@ltf_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(tlabelTemplates.ltf_FileName)).Value = (object) tlabelTemplates.ltf_FileName;
          if (tlabelTemplates.IsThumbData)
            command.Parameters.Add("@ltf_ThumbData", OleDbType.LongVarBinary, tlabelTemplates.ltf_ThumbData.Length, "ltf_ThumbData").Value = (object) tlabelTemplates.ltf_ThumbData;
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return tlabelTemplates.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.ltf_InDate.HasValue)
        this.ltf_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ltf_ID,ltf_SiteID,ltf_Title,ltf_Url,ltf_InDate,ltf_InUser,ltf_ModDate,ltf_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ltf_ID) + string.Format(",{0}", (object) this.ltf_SiteID) + ",'" + this.ltf_Title + "','" + this.ltf_Url + "'" + string.Format(",{0},{1}", (object) this.ltf_InDate.GetDateToStrInNull(), (object) this.ltf_InUser) + string.Format(",{0},{1}", (object) this.ltf_ModDate.GetDateToStrInNull(), (object) this.ltf_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ltf_ID, (object) this.ltf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TLabelTemplates tlabelTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplates.\u003C\u003En__0();
      if (await tlabelTemplates.OleDB.ExecuteAsync(tlabelTemplates.InsertQuery()))
        return true;
      tlabelTemplates.message = " " + tlabelTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlabelTemplates.ltf_ID, (object) tlabelTemplates.ltf_SiteID) + " 내용 : " + tlabelTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplates.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ltf_Title='" + this.ltf_Title + "',ltf_Url='" + this.ltf_Url + "'" + string.Format(",{0}={1},{2}={3}", (object) "ltf_ModDate", (object) this.ltf_ModDate.GetDateToStrInNull(), (object) "ltf_ModUser", (object) this.ltf_ModUser) + string.Format(" WHERE {0}={1}", (object) "ltf_ID", (object) this.ltf_ID) + string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) this.ltf_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ltf_ID, (object) this.ltf_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TLabelTemplates tlabelTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplates.\u003C\u003En__1();
      if (await tlabelTemplates.OleDB.ExecuteAsync(tlabelTemplates.UpdateQuery()))
        return true;
      tlabelTemplates.message = " " + tlabelTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlabelTemplates.ltf_ID, (object) tlabelTemplates.ltf_SiteID) + " 내용 : " + tlabelTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplates.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ltf_ID", (object) this.ltf_ID) + string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) this.ltf_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ltf_ID, (object) this.ltf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TLabelTemplates tlabelTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplates.\u003C\u003En__0();
      if (await tlabelTemplates.OleDB.ExecuteAsync(tlabelTemplates.DeleteQuery()))
        return true;
      tlabelTemplates.message = " " + tlabelTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlabelTemplates.ltf_ID, (object) tlabelTemplates.ltf_SiteID) + " 내용 : " + tlabelTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplates.message);
      return false;
    }

    public virtual string DeleteQuery(long p_ltf_ID, long p_ltf_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ltf_ID", (object) p_ltf_ID));
      if (p_ltf_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) p_ltf_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      long p_ltf_ID,
      long p_ltf_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      try
      {
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
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1},{2}) 검색됨", (object) this.ltf_FileName, (object) this.ltf_ID, (object) this.ltf_SiteID));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) p_ltf_ID, (object) p_ltf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TLabelTemplates>> SelectTListAsync(object p_param)
    {
      TLabelTemplates tlabelTemplates1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(tlabelTemplates1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tlabelTemplates1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(tlabelTemplates1.GetSelectQuery(p_param)))
        {
          tlabelTemplates1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplates1.OleDB.LastErrorID) + " 내용 : " + tlabelTemplates1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TLabelTemplates>) null;
        }
        IList<TLabelTemplates> lt_list = (IList<TLabelTemplates>) new List<TLabelTemplates>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TLabelTemplates tlabelTemplates2 = tlabelTemplates1.OleDB.Create<TLabelTemplates>();
            if (tlabelTemplates2.GetFieldValues(rs))
            {
              tlabelTemplates2.row_number = lt_list.Count + 1;
              lt_list.Add(tlabelTemplates2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplates1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ltf_SiteID") && Convert.ToInt64(hashtable[(object) "ltf_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ltf_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ltf_ID") && Convert.ToInt64(hashtable[(object) "ltf_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltf_ID", hashtable[(object) "ltf_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltf_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ltf_Title") && !string.IsNullOrEmpty(hashtable[(object) "ltf_Title"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltf_Title", hashtable[(object) "ltf_Title"]));
        if (hashtable.ContainsKey((object) "ltf_FileName") && !string.IsNullOrEmpty(hashtable[(object) "ltf_FileName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltf_FileName", hashtable[(object) "ltf_FileName"]));
        if (hashtable.ContainsKey((object) "ltf_OriginHash") && !string.IsNullOrEmpty(hashtable[(object) "ltf_OriginHash"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltf_OriginHash", hashtable[(object) "ltf_OriginHash"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ltf_Title", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ltf_FileName", hashtable[(object) "_KEY_WORD_"]));
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
        string uniImages = UbModelBase.UNI_IMAGES;
        string str = this.TableCode.ToString();
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniImages = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append(" SELECT  ltf_ID,ltf_SiteID,ltf_Title,ltf_Url,ltf_FileName,ltf_OriginHash,ltf_InDate,ltf_InUser,ltf_ModDate,ltf_ModUser");
        if (flag1)
          stringBuilder.Append(",ltf_ThumbData");
        if (flag2)
          stringBuilder.Append(",ltf_OriginData");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniImages) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
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
