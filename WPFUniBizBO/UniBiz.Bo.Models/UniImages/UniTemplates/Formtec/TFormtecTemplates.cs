// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Formtec.TFormtecTemplates
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

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Formtec
{
  public class TFormtecTemplates : UbModelBase<TFormtecTemplates>
  {
    private long _ftf_ID;
    private long _ftf_SiteID;
    private string _ftf_Title;
    private string _ftf_Url;
    private string _ftf_FileName;
    protected byte[] _ftf_ThumbData = new byte[0];
    protected byte[] _ftf_OriginData = new byte[0];
    private string _ftf_OriginHash;
    private DateTime? _ftf_InDate;
    private int _ftf_InUser;
    private DateTime? _ftf_ModDate;
    private int _ftf_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ftf_ID
    };

    public long ftf_ID
    {
      get => this._ftf_ID;
      set
      {
        this._ftf_ID = value;
        this.Changed(nameof (ftf_ID));
      }
    }

    public long ftf_SiteID
    {
      get => this._ftf_SiteID;
      set
      {
        this._ftf_SiteID = value;
        this.Changed(nameof (ftf_SiteID));
      }
    }

    public string ftf_Title
    {
      get => this._ftf_Title;
      set
      {
        this._ftf_Title = UbModelBase.LeftStr(value, 300).Replace("'", "´");
        this.Changed(nameof (ftf_Title));
      }
    }

    public string ftf_Url
    {
      get => this._ftf_Url;
      set
      {
        this._ftf_Url = UbModelBase.LeftStr(value, 300).Replace("'", "´");
        this.Changed(nameof (ftf_Url));
      }
    }

    public string ftf_FileName
    {
      get => this._ftf_FileName;
      set
      {
        this._ftf_FileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ftf_FileName));
      }
    }

    public byte[] ftf_ThumbData
    {
      get => this._ftf_ThumbData;
      set
      {
        this._ftf_ThumbData = value;
        this.Changed(nameof (ftf_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.ftf_ThumbData != null && this.ftf_ThumbData.Length != 0;

    public byte[] ftf_OriginData
    {
      get => this._ftf_OriginData;
      set
      {
        this._ftf_OriginData = value;
        this.Changed(nameof (ftf_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.ftf_OriginData != null && this.ftf_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        if (this.IsOriginData)
          return this.ftf_OriginData.ToBase64();
        return this.IsThumbData ? this.ftf_ThumbData.ToBase64() : (string) null;
      }
    }

    public string ftf_OriginHash
    {
      get => this._ftf_OriginHash;
      set
      {
        this._ftf_OriginHash = UbModelBase.LeftStr(value, 512).Replace("'", "´");
        this.Changed(nameof (ftf_OriginHash));
      }
    }

    public DateTime? ftf_InDate
    {
      get => this._ftf_InDate;
      set
      {
        this._ftf_InDate = value;
        this.Changed(nameof (ftf_InDate));
      }
    }

    public int ftf_InUser
    {
      get => this._ftf_InUser;
      set
      {
        this._ftf_InUser = value;
        this.Changed(nameof (ftf_InUser));
      }
    }

    public DateTime? ftf_ModDate
    {
      get => this._ftf_ModDate;
      set
      {
        this._ftf_ModDate = value;
        this.Changed(nameof (ftf_ModDate));
      }
    }

    public int ftf_ModUser
    {
      get => this._ftf_ModUser;
      set
      {
        this._ftf_ModUser = value;
        this.Changed(nameof (ftf_ModUser));
      }
    }

    public override DateTime? ModDate => this.ftf_ModDate ?? (this.ftf_ModDate = this.ftf_InDate);

    public TFormtecTemplates() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ftf_ID", new TTableColumn()
      {
        tc_orgin_name = "ftf_ID",
        tc_trans_name = "ID"
      });
      columnInfo.Add("ftf_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ftf_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ftf_Title", new TTableColumn()
      {
        tc_orgin_name = "ftf_Title",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("ftf_Url", new TTableColumn()
      {
        tc_orgin_name = "ftf_Url",
        tc_trans_name = "URL"
      });
      columnInfo.Add("ftf_FileName", new TTableColumn()
      {
        tc_orgin_name = "ftf_FileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("ftf_ThumbData", new TTableColumn()
      {
        tc_orgin_name = "ftf_ThumbData",
        tc_trans_name = "썸네일"
      });
      columnInfo.Add("ftf_OriginData", new TTableColumn()
      {
        tc_orgin_name = "ftf_OriginData",
        tc_trans_name = "템플릿"
      });
      columnInfo.Add("ftf_OriginHash", new TTableColumn()
      {
        tc_orgin_name = "ftf_OriginHash",
        tc_trans_name = "템플릿 Hash"
      });
      columnInfo.Add("ftf_InDate", new TTableColumn()
      {
        tc_orgin_name = "ftf_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ftf_InUser", new TTableColumn()
      {
        tc_orgin_name = "ftf_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ftf_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ftf_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ftf_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ftf_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.FormtecTemplates;
      this.ftf_ID = this.ftf_SiteID = 0L;
      this.ftf_Title = this.ftf_Url = this.ftf_FileName = string.Empty;
      this.ftf_ThumbData = new byte[0];
      this.ftf_OriginData = new byte[0];
      this.ftf_OriginHash = string.Empty;
      this.ftf_InDate = new DateTime?();
      this.ftf_InUser = 0;
      this.ftf_ModDate = new DateTime?();
      this.ftf_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TFormtecTemplates();

    public override object Clone()
    {
      TFormtecTemplates tformtecTemplates = base.Clone() as TFormtecTemplates;
      tformtecTemplates.ftf_ID = this.ftf_ID;
      tformtecTemplates.ftf_SiteID = this.ftf_SiteID;
      tformtecTemplates.ftf_Title = this.ftf_Title;
      tformtecTemplates.ftf_Url = this.ftf_Url;
      tformtecTemplates.ftf_FileName = this.ftf_FileName;
      tformtecTemplates.ftf_ThumbData = this.ftf_ThumbData;
      tformtecTemplates.ftf_OriginData = this.ftf_OriginData;
      tformtecTemplates.ftf_OriginHash = this.ftf_OriginHash;
      tformtecTemplates.ftf_InDate = this.ftf_InDate;
      tformtecTemplates.ftf_InUser = this.ftf_InUser;
      tformtecTemplates.ftf_ModDate = this.ftf_ModDate;
      tformtecTemplates.ftf_ModUser = this.ftf_ModUser;
      return (object) tformtecTemplates;
    }

    public void PutData(TFormtecTemplates pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ftf_ID = pSource.ftf_ID;
      this.ftf_SiteID = pSource.ftf_SiteID;
      this.ftf_Title = pSource.ftf_Title;
      this.ftf_Url = pSource.ftf_Url;
      this.ftf_FileName = pSource.ftf_FileName;
      this.ftf_ThumbData = pSource.ftf_ThumbData;
      this.ftf_OriginData = pSource.ftf_OriginData;
      this.ftf_OriginHash = pSource.ftf_OriginHash;
      this.ftf_InDate = pSource.ftf_InDate;
      this.ftf_ModDate = pSource.ftf_ModDate;
      this.ftf_InUser = pSource.ftf_InUser;
      this.ftf_ModUser = pSource.ftf_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ftf_ID = p_rs.GetFieldLong("ftf_ID");
        if (this.ftf_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ftf_SiteID = p_rs.GetFieldLong("ftf_SiteID");
        this.ftf_Title = p_rs.GetFieldString("ftf_Title");
        this.ftf_Url = p_rs.GetFieldString("ftf_Url");
        this.ftf_FileName = p_rs.GetFieldString("ftf_FileName");
        if (p_rs.IsFieldName("ftf_ThumbData"))
        {
          if (this.ftf_ThumbData != null)
            this.ftf_ThumbData = (byte[]) null;
          this.ftf_ThumbData = p_rs.GetFieldBytes("ftf_ThumbData");
        }
        if (p_rs.IsFieldName("ftf_OriginData"))
        {
          if (this.ftf_OriginData != null)
            this.ftf_OriginData = (byte[]) null;
          this.ftf_OriginData = p_rs.GetFieldBytes("ftf_OriginData");
        }
        this.ftf_OriginHash = p_rs.GetFieldString("ftf_OriginHash");
        this.ftf_InDate = p_rs.GetFieldDateTime("ftf_InDate");
        this.ftf_InUser = p_rs.GetFieldInt("ftf_InUser");
        this.ftf_ModDate = p_rs.GetFieldDateTime("ftf_ModDate");
        this.ftf_ModUser = p_rs.GetFieldInt("ftf_ModUser");
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
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ftf_OriginData=?,ftf_FileName=?");
        if (this.IsThumbData)
          stringBuilder.Append(",ftf_ThumbData=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ftf_ID", (object) this.ftf_ID) + string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) this.ftf_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@ftf_OriginData", OleDbType.LongVarBinary, this.ftf_OriginData.Length, "ftf_OriginData").Value = (object) this.ftf_OriginData;
          command.Parameters.Add("@ftf_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.ftf_FileName)).Value = (object) this.ftf_FileName;
          if (this.IsThumbData)
            command.Parameters.Add("@ftf_ThumbData", OleDbType.LongVarBinary, this.ftf_ThumbData.Length, "ftf_ThumbData").Value = (object) this.ftf_ThumbData;
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
      TFormtecTemplates tformtecTemplates = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!tformtecTemplates.IsOriginData)
          return false;
        db = new UniOleDatabase(tformtecTemplates.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tformtecTemplates.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) tformtecTemplates.TableCode) + " ftf_OriginData=?,ftf_FileName=?");
        if (tformtecTemplates.IsThumbData)
          stringBuilder.Append(",ftf_ThumbData=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ftf_ID", (object) tformtecTemplates.ftf_ID) + string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) tformtecTemplates.ftf_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@ftf_OriginData", OleDbType.LongVarBinary, tformtecTemplates.ftf_OriginData.Length, "ftf_OriginData").Value = (object) tformtecTemplates.ftf_OriginData;
          command.Parameters.Add("@ftf_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(tformtecTemplates.ftf_FileName)).Value = (object) tformtecTemplates.ftf_FileName;
          if (tformtecTemplates.IsThumbData)
            command.Parameters.Add("@ftf_ThumbData", OleDbType.LongVarBinary, tformtecTemplates.ftf_ThumbData.Length, "ftf_ThumbData").Value = (object) tformtecTemplates.ftf_ThumbData;
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return tformtecTemplates.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.ftf_InDate.HasValue)
        this.ftf_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ftf_ID,ftf_SiteID,ftf_Title,ftf_Url,ftf_InDate,ftf_InUser,ftf_ModDate,ftf_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ftf_ID) + string.Format(",{0}", (object) this.ftf_SiteID) + ",'" + this.ftf_Title + "','" + this.ftf_Url + "'" + string.Format(",{0},{1}", (object) this.ftf_InDate.GetDateToStrInNull(), (object) this.ftf_InUser) + string.Format(",{0},{1}", (object) this.ftf_ModDate.GetDateToStrInNull(), (object) this.ftf_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ftf_ID, (object) this.ftf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TFormtecTemplates tformtecTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tformtecTemplates.\u003C\u003En__0();
      if (await tformtecTemplates.OleDB.ExecuteAsync(tformtecTemplates.InsertQuery()))
        return true;
      tformtecTemplates.message = " " + tformtecTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tformtecTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tformtecTemplates.ftf_ID, (object) tformtecTemplates.ftf_SiteID) + " 내용 : " + tformtecTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tformtecTemplates.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ftf_Title='" + this.ftf_Title + "',ftf_Url='" + this.ftf_Url + "'" + string.Format(",{0}={1},{2}={3}", (object) "ftf_ModDate", (object) this.ftf_ModDate.GetDateToStrInNull(), (object) "ftf_ModUser", (object) this.ftf_ModUser) + string.Format(" WHERE {0}={1}", (object) "ftf_ID", (object) this.ftf_ID) + string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) this.ftf_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ftf_ID, (object) this.ftf_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TFormtecTemplates tformtecTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tformtecTemplates.\u003C\u003En__1();
      if (await tformtecTemplates.OleDB.ExecuteAsync(tformtecTemplates.UpdateQuery()))
        return true;
      tformtecTemplates.message = " " + tformtecTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tformtecTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tformtecTemplates.ftf_ID, (object) tformtecTemplates.ftf_SiteID) + " 내용 : " + tformtecTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tformtecTemplates.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ftf_ID", (object) this.ftf_ID) + string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) this.ftf_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ftf_ID, (object) this.ftf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TFormtecTemplates tformtecTemplates = this;
      // ISSUE: reference to a compiler-generated method
      tformtecTemplates.\u003C\u003En__0();
      if (await tformtecTemplates.OleDB.ExecuteAsync(tformtecTemplates.DeleteQuery()))
        return true;
      tformtecTemplates.message = " " + tformtecTemplates.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tformtecTemplates.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tformtecTemplates.ftf_ID, (object) tformtecTemplates.ftf_SiteID) + " 내용 : " + tformtecTemplates.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tformtecTemplates.message);
      return false;
    }

    public virtual string DeleteQuery(long p_ftf_ID, long p_ftf_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ftf_ID", (object) p_ftf_ID));
      if (p_ftf_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) p_ftf_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      long p_ftf_ID,
      long p_ftf_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      try
      {
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
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1},{2}) 검색됨", (object) this.ftf_FileName, (object) this.ftf_ID, (object) this.ftf_SiteID));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) p_ftf_ID, (object) p_ftf_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TFormtecTemplates>> SelectTListAsync(object p_param)
    {
      TFormtecTemplates tformtecTemplates1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(tformtecTemplates1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tformtecTemplates1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(tformtecTemplates1.GetSelectQuery(p_param)))
        {
          tformtecTemplates1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tformtecTemplates1.OleDB.LastErrorID) + " 내용 : " + tformtecTemplates1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TFormtecTemplates>) null;
        }
        IList<TFormtecTemplates> lt_list = (IList<TFormtecTemplates>) new List<TFormtecTemplates>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TFormtecTemplates tformtecTemplates2 = tformtecTemplates1.OleDB.Create<TFormtecTemplates>();
            if (tformtecTemplates2.GetFieldValues(rs))
            {
              tformtecTemplates2.row_number = lt_list.Count + 1;
              lt_list.Add(tformtecTemplates2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tformtecTemplates1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "ftf_SiteID") && Convert.ToInt64(hashtable[(object) "ftf_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ftf_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ftf_ID") && Convert.ToInt64(hashtable[(object) "ftf_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ftf_ID", hashtable[(object) "ftf_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ftf_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ftf_Title") && !string.IsNullOrEmpty(hashtable[(object) "ftf_Title"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ftf_Title", hashtable[(object) "ftf_Title"]));
        if (hashtable.ContainsKey((object) "ftf_FileName") && !string.IsNullOrEmpty(hashtable[(object) "ftf_FileName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ftf_FileName", hashtable[(object) "ftf_FileName"]));
        if (hashtable.ContainsKey((object) "ftf_OriginHash") && !string.IsNullOrEmpty(hashtable[(object) "ftf_OriginHash"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ftf_OriginHash", hashtable[(object) "ftf_OriginHash"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ftf_Title", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ftf_FileName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  ftf_ID,ftf_SiteID,ftf_Title,ftf_Url,ftf_FileName,ftf_OriginHash,ftf_InDate,ftf_InUser,ftf_ModDate,ftf_ModUser");
        if (flag1)
          stringBuilder.Append(",ftf_ThumbData");
        if (flag2)
          stringBuilder.Append(",ftf_OriginData");
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
