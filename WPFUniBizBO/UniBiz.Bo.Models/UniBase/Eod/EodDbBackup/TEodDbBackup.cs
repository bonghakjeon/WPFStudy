// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodDbBackup.TEodDbBackup
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Eod.EodDbBackup
{
  public class TEodDbBackup : UbModelBase<TEodDbBackup>
  {
    private int _eodb_code;
    private long _eodb_SiteID;
    private DateTime? _eodb_date;
    private int _eodb_db_name_type;
    private string _eodb_file_url;
    private string _eodb_file_name;
    private int _eodb_file_size;
    private DateTime? _eodb_udate;
    private int _eodb_emp;
    private int _eodb_status;

    public override object _Key => (object) new object[1]
    {
      (object) this.eodb_code
    };

    public int eodb_code
    {
      get => this._eodb_code;
      set
      {
        this._eodb_code = value;
        this.Changed(nameof (eodb_code));
      }
    }

    public long eodb_SiteID
    {
      get => this._eodb_SiteID;
      set
      {
        this._eodb_SiteID = value;
        this.Changed(nameof (eodb_SiteID));
      }
    }

    public DateTime? eodb_date
    {
      get => this._eodb_date;
      set
      {
        this._eodb_date = value;
        this.Changed(nameof (eodb_date));
      }
    }

    public int eodb_db_name_type
    {
      get => this._eodb_db_name_type;
      set
      {
        this._eodb_db_name_type = value;
        this.Changed(nameof (eodb_db_name_type));
      }
    }

    public string eodb_db_name_typeDesc => this.eodb_db_name_type != 0 ? Enum2StrConverter.ToDbNameType(this.eodb_db_name_type).ToDescription() : string.Empty;

    public string eodb_file_url
    {
      get => this._eodb_file_url;
      set
      {
        this._eodb_file_url = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (eodb_file_url));
      }
    }

    public string eodb_file_name
    {
      get => this._eodb_file_name;
      set
      {
        this._eodb_file_name = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (eodb_file_name));
      }
    }

    [JsonIgnore]
    public string FullFileName
    {
      get
      {
        string.IsNullOrEmpty(this.eodb_file_name);
        return string.Empty;
      }
    }

    public int eodb_file_size
    {
      get => this._eodb_file_size;
      set
      {
        this._eodb_file_size = value;
        this.Changed(nameof (eodb_file_size));
      }
    }

    public DateTime? eodb_udate
    {
      get => this._eodb_udate;
      set
      {
        this._eodb_udate = value;
        this.Changed(nameof (eodb_udate));
      }
    }

    public int eodb_emp
    {
      get => this._eodb_emp;
      set
      {
        this._eodb_emp = value;
        this.Changed(nameof (eodb_emp));
      }
    }

    public int eodb_status
    {
      get => this._eodb_status;
      set
      {
        this._eodb_status = value;
        this.Changed(nameof (eodb_status));
      }
    }

    public TEodDbBackup() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("eodb_code", new TTableColumn()
      {
        tc_orgin_name = "eodb_code",
        tc_trans_name = "코드"
      });
      columnInfo.Add("eodb_SiteID", new TTableColumn()
      {
        tc_orgin_name = "eodb_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("eodb_date", new TTableColumn()
      {
        tc_orgin_name = "eodb_date",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("eodb_db_name_type", new TTableColumn()
      {
        tc_orgin_name = "eodb_db_name_type",
        tc_trans_name = "디비명",
        tc_comm_code = 213
      });
      columnInfo.Add("eodb_file_url", new TTableColumn()
      {
        tc_orgin_name = "eodb_file_url",
        tc_trans_name = "FILE URL"
      });
      columnInfo.Add("eodb_file_name", new TTableColumn()
      {
        tc_orgin_name = "eodb_file_name",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("eodb_file_size", new TTableColumn()
      {
        tc_orgin_name = "eodb_file_size",
        tc_trans_name = "파일크기"
      });
      columnInfo.Add("eodb_udate", new TTableColumn()
      {
        tc_orgin_name = "eodb_udate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("eodb_emp", new TTableColumn()
      {
        tc_orgin_name = "eodb_emp",
        tc_trans_name = "사원"
      });
      columnInfo.Add("eodb_status", new TTableColumn()
      {
        tc_orgin_name = "eodb_status",
        tc_trans_name = "상태"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.EodDbBackup;
      this.eodb_code = 0;
      this.eodb_SiteID = 0L;
      this.eodb_date = new DateTime?();
      this.eodb_db_name_type = 0;
      this.eodb_file_url = string.Empty;
      this.eodb_file_name = string.Empty;
      this.eodb_file_size = 0;
      this.eodb_udate = new DateTime?();
      this.eodb_emp = 0;
      this.eodb_status = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEodDbBackup();

    public override object Clone()
    {
      TEodDbBackup teodDbBackup = base.Clone() as TEodDbBackup;
      teodDbBackup.eodb_code = this.eodb_code;
      teodDbBackup.eodb_SiteID = this.eodb_SiteID;
      teodDbBackup.eodb_date = this.eodb_date;
      teodDbBackup.eodb_db_name_type = this.eodb_db_name_type;
      teodDbBackup.eodb_file_url = this.eodb_file_url;
      teodDbBackup.eodb_file_name = this.eodb_file_name;
      teodDbBackup.eodb_file_size = this.eodb_file_size;
      teodDbBackup.eodb_udate = this.eodb_udate;
      teodDbBackup.eodb_emp = this.eodb_emp;
      teodDbBackup.eodb_status = this.eodb_status;
      return (object) teodDbBackup;
    }

    public void PutData(TEodDbBackup pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.eodb_code = pSource.eodb_code;
      this.eodb_SiteID = pSource.eodb_SiteID;
      this.eodb_date = pSource.eodb_date;
      this.eodb_db_name_type = pSource.eodb_db_name_type;
      this.eodb_file_url = pSource.eodb_file_url;
      this.eodb_file_name = pSource.eodb_file_name;
      this.eodb_file_size = pSource.eodb_file_size;
      this.eodb_udate = pSource.eodb_udate;
      this.eodb_emp = pSource.eodb_emp;
      this.eodb_status = pSource.eodb_status;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.eodb_code = p_rs.GetFieldInt("eodb_code");
        if (this.eodb_code == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.eodb_SiteID = p_rs.GetFieldLong("eodb_SiteID");
        this.eodb_date = p_rs.GetFieldDateTime("eodb_date");
        this.eodb_db_name_type = p_rs.GetFieldInt("eodb_db_name_type");
        this.eodb_file_url = p_rs.GetFieldString("eodb_file_url");
        this.eodb_file_name = p_rs.GetFieldString("eodb_file_name");
        this.eodb_file_size = p_rs.GetFieldInt("eodb_file_size");
        this.eodb_udate = p_rs.GetFieldDateTime("eodb_udate");
        this.eodb_emp = p_rs.GetFieldInt("eodb_emp");
        this.eodb_status = p_rs.GetFieldInt("eodb_status");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " eodb_code,eodb_SiteID,eodb_date,eodb_db_name_type,eodb_file_url,eodb_file_name,eodb_file_size,eodb_udate,eodb_emp,eodb_status) VALUES ( " + string.Format(" {0}", (object) this.eodb_code) + string.Format(",{0}", (object) this.eodb_SiteID) + "," + this.eodb_date.GetDateToStrInNull() + string.Format(",{0},'{1}','{2}',{3}", (object) this.eodb_db_name_type, (object) this.eodb_file_url, (object) this.eodb_file_name, (object) this.eodb_file_size) + "," + this.eodb_udate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.eodb_emp, (object) this.eodb_status) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__0();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.InsertQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " eodb_date=" + this.eodb_date.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "eodb_db_name_type", (object) this.eodb_db_name_type) + ",eodb_file_url='" + this.eodb_file_url + "',eodb_file_name='" + this.eodb_file_name + "'" + string.Format(",{0}={1}", (object) "eodb_file_size", (object) this.eodb_file_size) + ",eodb_udate=" + this.eodb_udate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "eodb_emp", (object) this.eodb_emp, (object) "eodb_status", (object) this.eodb_status) + string.Format(" WHERE {0}={1}", (object) "eodb_code", (object) this.eodb_code) + string.Format(" AND {0}={1}", (object) "eodb_SiteID", (object) this.eodb_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__1();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.UpdateQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(" eodb_date=" + this.eodb_date.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "eodb_db_name_type", (object) this.eodb_db_name_type) + ",eodb_file_url='" + this.eodb_file_url + "',eodb_file_name='" + this.eodb_file_name + "'" + string.Format(",{0}={1}", (object) "eodb_file_size", (object) this.eodb_file_size) + ",eodb_udate=" + this.eodb_udate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "eodb_emp", (object) this.eodb_emp, (object) "eodb_status", (object) this.eodb_status));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__1();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.UpdateExInsertQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "eodb_code", (object) this.eodb_code) + string.Format(" AND {0}={1}", (object) "eodb_SiteID", (object) this.eodb_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__0();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.DeleteQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public virtual string DeleteQuery(int p_eodb_code, long p_eodb_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "eodb_code", (object) p_eodb_code));
      if (p_eodb_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_SiteID", (object) p_eodb_SiteID));
      return stringBuilder.ToString();
    }

    public string LogTruncateQuery()
    {
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MSSQL)
        return string.Empty;
      string str = string.Empty;
      switch (Enum2StrConverter.ToDbNameType(this.eodb_db_name_type))
      {
        case EnumDbNameType.UniBase:
          str = UbModelBase.UNI_BASE;
          break;
        case EnumDbNameType.UniSales:
          str = UbModelBase.UNI_SALES;
          break;
        case EnumDbNameType.UniTrData:
          str = UbModelBase.UNI_TR_DATA;
          break;
        case EnumDbNameType.UniStock:
          str = UbModelBase.UNI_STOCK;
          break;
        case EnumDbNameType.UniMembers:
          str = UbModelBase.UNI_MEMBERS;
          break;
        case EnumDbNameType.UniInterface:
          str = UbModelBase.UNI_INTERFACE;
          break;
        case EnumDbNameType.UniSMS:
          str = UbModelBase.UNI_SMS;
          break;
        case EnumDbNameType.UniPop:
          str = UbModelBase.UNI_POP;
          break;
        case EnumDbNameType.UniCampaign:
          str = UbModelBase.UNI_CAMPANIGN;
          break;
      }
      if (string.IsNullOrEmpty(str))
        return string.Empty;
      return " ALTER DATABASE " + str + " SET RECOVERY SIMPLE;\n DBCC SHRINKFILE (" + str + "_log, 10);";
    }

    public bool LogTruncate()
    {
      this.InsertChecked();
      string pStrExec = this.LogTruncateQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public async Task<bool> LogTruncateAsync()
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__0();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.LogTruncateQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public string BackupQuery()
    {
      string str = string.Empty;
      switch (Enum2StrConverter.ToDbNameType(this.eodb_db_name_type))
      {
        case EnumDbNameType.UniBase:
          str = UbModelBase.UNI_BASE;
          break;
        case EnumDbNameType.UniSales:
          str = UbModelBase.UNI_SALES;
          break;
        case EnumDbNameType.UniTrData:
          str = UbModelBase.UNI_TR_DATA;
          break;
        case EnumDbNameType.UniStock:
          str = UbModelBase.UNI_STOCK;
          break;
        case EnumDbNameType.UniMembers:
          str = UbModelBase.UNI_MEMBERS;
          break;
        case EnumDbNameType.UniInterface:
          str = UbModelBase.UNI_INTERFACE;
          break;
        case EnumDbNameType.UniSMS:
          str = UbModelBase.UNI_SMS;
          break;
        case EnumDbNameType.UniPop:
          str = UbModelBase.UNI_POP;
          break;
        case EnumDbNameType.UniCampaign:
          str = UbModelBase.UNI_CAMPANIGN;
          break;
      }
      if (string.IsNullOrEmpty(str))
        return string.Empty;
      if (DbQueryHelper.DbTypeNotNull() == EnumDB.MSSQL)
        return "BACKUP DATABASE\n " + str + " to disk='" + this.eodb_file_url + this.eodb_file_name + ".bak' WITH INIT;";
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MYSQL)
        return string.Empty;
      return "mysqldump -uroot -p패스워드 --databases " + str + " > " + this.FullFileName + " ";
    }

    public bool Backup()
    {
      this.InsertChecked();
      string pStrExec = this.BackupQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eodb_code, (object) this.eodb_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public async Task<bool> BackupAsync()
    {
      TEodDbBackup teodDbBackup = this;
      // ISSUE: reference to a compiler-generated method
      teodDbBackup.\u003C\u003En__0();
      if (await teodDbBackup.OleDB.ExecuteAsync(teodDbBackup.BackupQuery()))
        return true;
      teodDbBackup.message = " " + teodDbBackup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodDbBackup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodDbBackup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodDbBackup.eodb_code, (object) teodDbBackup.eodb_SiteID) + " 내용 : " + teodDbBackup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodDbBackup.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "eodb_SiteID") && Convert.ToInt64(hashtable[(object) "eodb_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "eodb_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "eodb_code") && Convert.ToInt32(hashtable[(object) "eodb_code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_code", hashtable[(object) "eodb_code"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "eodb_date"))
        {
          stringBuilder.Append(" AND eodb_date >='" + new DateTime?((DateTime) hashtable[(object) "eodb_date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eodb_date <='" + new DateTime?((DateTime) hashtable[(object) "eodb_date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "eodb_date_BEGIN_") && hashtable.ContainsKey((object) "eodb_date_END_"))
        {
          stringBuilder.Append(" AND eodb_date >='" + new DateTime?((DateTime) hashtable[(object) "eodb_date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eodb_date <='" + new DateTime?((DateTime) hashtable[(object) "eodb_date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "eodb_db_name_type") && Convert.ToInt32(hashtable[(object) "eodb_db_name_type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_db_name_type", hashtable[(object) "eodb_db_name_type"]));
        if (hashtable.ContainsKey((object) "eodb_emp") && Convert.ToInt32(hashtable[(object) "eodb_emp"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_emp", hashtable[(object) "eodb_emp"]));
        if (hashtable.ContainsKey((object) "eodb_status") && Convert.ToInt32(hashtable[(object) "eodb_status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eodb_status", hashtable[(object) "eodb_status"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "eodb_file_url", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "eodb_file_name", hashtable[(object) "_KEY_WORD_"]));
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  eodb_code,eodb_SiteID,eodb_date,eodb_db_name_type,eodb_file_url,eodb_file_name,eodb_file_size,eodb_udate,eodb_emp,eodb_status");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
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
