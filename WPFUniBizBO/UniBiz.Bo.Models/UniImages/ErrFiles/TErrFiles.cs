// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.ErrFiles.TErrFiles
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

namespace UniBiz.Bo.Models.UniImages.ErrFiles
{
  public class TErrFiles : UbModelBase<TErrFiles>
  {
    private long _ef_UUID;
    private long _ef_SiteID;
    private string _ef_FileName;
    private int _ef_Type;
    private string _ef_Remark;
    private int _ef_OriginSize;
    protected byte[] _ef_OriginData = new byte[0];
    private DateTime? _ef_InDate;
    private int _ef_InUser;
    private DateTime? _ef_ModDate;
    private int _ef_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ef_UUID
    };

    public long ef_UUID
    {
      get => this._ef_UUID;
      set
      {
        this._ef_UUID = value;
        this.Changed(nameof (ef_UUID));
      }
    }

    public long ef_SiteID
    {
      get => this._ef_SiteID;
      set
      {
        this._ef_SiteID = value;
        this.Changed(nameof (ef_SiteID));
      }
    }

    public string ef_FileName
    {
      get => this._ef_FileName;
      set
      {
        this._ef_FileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ef_FileName));
      }
    }

    public int ef_Type
    {
      get => this._ef_Type;
      set
      {
        this._ef_Type = value;
        this.Changed(nameof (ef_Type));
      }
    }

    public string ef_Remark
    {
      get => this._ef_Remark;
      set
      {
        this._ef_Remark = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (ef_Remark));
      }
    }

    public int ef_OriginSize
    {
      get => this._ef_OriginSize;
      set
      {
        this._ef_OriginSize = value;
        this.Changed(nameof (ef_OriginSize));
      }
    }

    public byte[] ef_OriginData
    {
      get => this._ef_OriginData;
      set
      {
        this._ef_OriginData = value;
        if (this._ef_OriginData != null)
          this.ef_OriginSize = this._ef_OriginData.Length;
        this.Changed(nameof (ef_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.ef_OriginData != null && this.ef_OriginData.Length != 0;

    public string Base64Data => this.IsOriginData ? this.ef_OriginData.ToBase64() : (string) null;

    public DateTime? ef_InDate
    {
      get => this._ef_InDate;
      set
      {
        this._ef_InDate = value;
        this.Changed(nameof (ef_InDate));
      }
    }

    public int ef_InUser
    {
      get => this._ef_InUser;
      set
      {
        this._ef_InUser = value;
        this.Changed(nameof (ef_InUser));
      }
    }

    public DateTime? ef_ModDate
    {
      get => this._ef_ModDate;
      set
      {
        this._ef_ModDate = value;
        this.Changed(nameof (ef_ModDate));
      }
    }

    public int ef_ModUser
    {
      get => this._ef_ModUser;
      set
      {
        this._ef_ModUser = value;
        this.Changed(nameof (ef_ModUser));
      }
    }

    public override DateTime? ModDate => this.ef_ModDate ?? (this.ef_ModDate = this.ef_InDate);

    public TErrFiles() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ef_UUID", new TTableColumn()
      {
        tc_orgin_name = "ef_UUID",
        tc_trans_name = "UUID"
      });
      columnInfo.Add("ef_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ef_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ef_FileName", new TTableColumn()
      {
        tc_orgin_name = "ef_FileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("ef_Type", new TTableColumn()
      {
        tc_orgin_name = "ef_Type",
        tc_trans_name = "타입"
      });
      columnInfo.Add("ef_Remark", new TTableColumn()
      {
        tc_orgin_name = "ErrFilesConverter",
        tc_trans_name = "비고"
      });
      columnInfo.Add("ef_OriginSize", new TTableColumn()
      {
        tc_orgin_name = "ef_OriginSize",
        tc_trans_name = "크기"
      });
      columnInfo.Add("ef_OriginData", new TTableColumn()
      {
        tc_orgin_name = "ef_OriginData",
        tc_trans_name = "데이터"
      });
      columnInfo.Add("ef_InDate", new TTableColumn()
      {
        tc_orgin_name = "ef_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ef_InUser", new TTableColumn()
      {
        tc_orgin_name = "ef_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ef_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ef_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ef_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ef_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ErrFiles;
      this.ef_UUID = 0L;
      this.ef_SiteID = 0L;
      this.ef_FileName = string.Empty;
      this.ef_Type = 0;
      this.ef_Remark = string.Empty;
      this.ef_OriginSize = 0;
      this.ef_OriginData = new byte[0];
      this.ef_InDate = new DateTime?();
      this.ef_InUser = 0;
      this.ef_ModDate = new DateTime?();
      this.ef_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TErrFiles();

    public override object Clone()
    {
      TErrFiles terrFiles = base.Clone() as TErrFiles;
      terrFiles.ef_UUID = this.ef_UUID;
      terrFiles.ef_SiteID = this.ef_SiteID;
      terrFiles.ef_FileName = this.ef_FileName;
      terrFiles.ef_Type = this.ef_Type;
      terrFiles.ef_Remark = this.ef_Remark;
      terrFiles.ef_OriginSize = this.ef_OriginSize;
      terrFiles.ef_OriginData = this.ef_OriginData;
      terrFiles.ef_InDate = this.ef_InDate;
      terrFiles.ef_InUser = this.ef_InUser;
      terrFiles.ef_ModDate = this.ef_ModDate;
      terrFiles.ef_ModUser = this.ef_ModUser;
      return (object) terrFiles;
    }

    public void PutData(TErrFiles pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ef_UUID = pSource.ef_UUID;
      this.ef_SiteID = pSource.ef_SiteID;
      this.ef_FileName = pSource.ef_FileName;
      this.ef_Type = pSource.ef_Type;
      this.ef_Remark = pSource.ef_Remark;
      this.ef_OriginSize = pSource.ef_OriginSize;
      this.ef_OriginData = pSource.ef_OriginData;
      this.ef_InDate = pSource.ef_InDate;
      this.ef_ModDate = pSource.ef_ModDate;
      this.ef_InUser = pSource.ef_InUser;
      this.ef_ModUser = pSource.ef_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ef_UUID = p_rs.GetFieldLong("ef_UUID");
        if (this.ef_UUID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ef_SiteID = p_rs.GetFieldLong("ef_SiteID");
        this.ef_FileName = p_rs.GetFieldString("ef_FileName");
        this.ef_Type = p_rs.GetFieldInt("ef_Type");
        this.ef_Remark = p_rs.GetFieldString("ef_Remark");
        this.ef_OriginSize = p_rs.GetFieldInt("ef_OriginSize");
        if (p_rs.IsFieldName("ef_OriginData"))
        {
          if (this.ef_OriginData != null)
            this.ef_OriginData = (byte[]) null;
          this.ef_OriginData = p_rs.GetFieldBytes("ef_OriginData");
        }
        this.ef_InDate = p_rs.GetFieldDateTime("ef_InDate");
        this.ef_InUser = p_rs.GetFieldInt("ef_InUser");
        this.ef_ModDate = p_rs.GetFieldDateTime("ef_ModDate");
        this.ef_ModUser = p_rs.GetFieldInt("ef_ModUser");
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
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ef_OriginData=?,ef_FileName=?,ef_OriginSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ef_UUID", (object) this.ef_UUID) + string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) this.ef_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@ef_OriginData", OleDbType.LongVarBinary, this.ef_OriginData.Length, "ef_OriginData").Value = (object) this.ef_OriginData;
          command.Parameters.Add("@ef_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.ef_FileName)).Value = (object) this.ef_FileName;
          command.Parameters.Add("@ef_OriginSize", OleDbType.Integer).Value = (object) this.ef_OriginSize;
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
      TErrFiles terrFiles = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!terrFiles.IsOriginData)
          return false;
        db = new UniOleDatabase(terrFiles.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, terrFiles.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) terrFiles.TableCode) + " ef_OriginData=?,ef_FileName=?,ef_OriginSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ef_UUID", (object) terrFiles.ef_UUID) + string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) terrFiles.ef_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@ef_OriginData", OleDbType.LongVarBinary, terrFiles.ef_OriginData.Length, "ef_OriginData").Value = (object) terrFiles.ef_OriginData;
          command.Parameters.Add("@ef_FileName", OleDbType.VarChar, Encoding.Default.GetByteCount(terrFiles.ef_FileName)).Value = (object) terrFiles.ef_FileName;
          command.Parameters.Add("@ef_OriginSize", OleDbType.Integer).Value = (object) terrFiles.ef_OriginSize;
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return terrFiles.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.ef_InDate.HasValue)
        this.ef_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ef_UUID,ef_SiteID,ef_Type,ef_Remark,ef_InDate,ef_InUser,ef_ModDate,ef_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ef_UUID) + string.Format(",{0}", (object) this.ef_SiteID) + string.Format(",{0}", (object) this.ef_Type) + ",'" + this.ef_Remark + "'" + string.Format(",{0},{1}", (object) this.ef_InDate.GetDateToStrInNull(), (object) this.ef_InUser) + string.Format(",{0},{1}", (object) this.ef_ModDate.GetDateToStrInNull(), (object) this.ef_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ef_UUID, (object) this.ef_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TErrFiles terrFiles = this;
      // ISSUE: reference to a compiler-generated method
      terrFiles.\u003C\u003En__0();
      if (await terrFiles.OleDB.ExecuteAsync(terrFiles.InsertQuery()))
        return true;
      terrFiles.message = " " + terrFiles.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrFiles.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrFiles.ef_UUID, (object) terrFiles.ef_SiteID) + " 내용 : " + terrFiles.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrFiles.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" {0}={1}", (object) "ef_Type", (object) this.ef_Type) + ",ef_Remark='" + this.ef_Remark + "'" + string.Format(",{0}={1},{2}={3}", (object) "ef_ModDate", (object) this.ef_ModDate.GetDateToStrInNull(), (object) "ef_ModUser", (object) this.ef_ModUser) + string.Format(" WHERE {0}={1}", (object) "ef_UUID", (object) this.ef_UUID) + string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) this.ef_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ef_UUID, (object) this.ef_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TErrFiles terrFiles = this;
      // ISSUE: reference to a compiler-generated method
      terrFiles.\u003C\u003En__1();
      if (await terrFiles.OleDB.ExecuteAsync(terrFiles.UpdateQuery()))
        return true;
      terrFiles.message = " " + terrFiles.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrFiles.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrFiles.ef_UUID, (object) terrFiles.ef_SiteID) + " 내용 : " + terrFiles.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrFiles.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ef_UUID", (object) this.ef_UUID) + string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) this.ef_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ef_UUID, (object) this.ef_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TErrFiles terrFiles = this;
      // ISSUE: reference to a compiler-generated method
      terrFiles.\u003C\u003En__0();
      if (await terrFiles.OleDB.ExecuteAsync(terrFiles.DeleteQuery()))
        return true;
      terrFiles.message = " " + terrFiles.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrFiles.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrFiles.ef_UUID, (object) terrFiles.ef_SiteID) + " 내용 : " + terrFiles.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrFiles.message);
      return false;
    }

    public virtual string DeleteQuery(long p_ef_UUID, long p_ef_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ef_UUID", (object) p_ef_UUID));
      if (p_ef_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) p_ef_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      long p_ef_UUID,
      long p_ef_SiteID = 0,
      bool p_is_file_data = false)
    {
      try
      {
        Hashtable p_param = new Hashtable()
        {
          {
            (object) "ef_UUID",
            (object) p_ef_UUID
          },
          {
            (object) "IDS_ORIGIN_IMAGE",
            (object) p_is_file_data
          }
        };
        if (p_ef_SiteID > 0L)
          p_param.Add((object) "ef_SiteID", (object) p_ef_SiteID);
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1},{2}) 검색됨", (object) this.ef_FileName, (object) this.ef_UUID, (object) this.ef_SiteID));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.ef_UUID, (object) this.ef_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TErrFiles>> SelectTListAsync(object p_param)
    {
      TErrFiles terrFiles1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(terrFiles1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, terrFiles1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(terrFiles1.GetSelectQuery(p_param)))
        {
          terrFiles1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrFiles1.OleDB.LastErrorID) + " 내용 : " + terrFiles1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TErrFiles>) null;
        }
        IList<TErrFiles> lt_list = (IList<TErrFiles>) new List<TErrFiles>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TErrFiles terrFiles2 = terrFiles1.OleDB.Create<TErrFiles>();
            if (terrFiles2.GetFieldValues(rs))
            {
              terrFiles2.row_number = lt_list.Count + 1;
              lt_list.Add(terrFiles2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrFiles1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "ef_SiteID") && Convert.ToInt64(hashtable[(object) "ef_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ef_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ef_UUID") && Convert.ToInt64(hashtable[(object) "ef_UUID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ef_UUID", hashtable[(object) "ef_UUID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ef_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ef_FileName") && hashtable[(object) "ef_FileName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ef_FileName", hashtable[(object) "ef_FileName"]));
        if (hashtable.ContainsKey((object) "ef_Type") && Convert.ToInt32(hashtable[(object) "ef_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ef_Type", hashtable[(object) "ef_Type"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ef_FileName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ef_Remark", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniImages = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "IDS_ORIGIN_IMAGE") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "IDS_ORIGIN_IMAGE"].ToString());
        }
        stringBuilder.Append(" SELECT  ef_UUID,ef_SiteID,ef_FileName,ef_Type,ef_Remark,ef_OriginSize,ef_InDate,ef_InUser,ef_ModDate,ef_ModUser");
        if (flag)
          stringBuilder.Append(",ef_OriginData");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(uniImages) + str + " " + DbQueryHelper.ToWithNolock());
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
