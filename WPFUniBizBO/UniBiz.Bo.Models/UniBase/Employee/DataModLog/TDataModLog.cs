// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.DataModLog.TDataModLog
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.DataModLog
{
  public class TDataModLog : UbModelBase<TDataModLog>
  {
    private long _dml_ID;
    private long _dml_SiteID;
    private DateTime? _dml_SysDate;
    private int _dml_StoreCode;
    private int _dml_EmpCode;
    private int _dml_CodeInt;
    private long _dml_CodeLong;
    private string _dml_CodeStr;
    private int _dml_ActionKind;
    private string _dml_ActionType;
    private int _dml_TableSeq;
    private string _dml_ModColumn;
    private string _dml_ModColumnDesc;
    private string _dml_BeforeValue;
    private string _dml_AfterValue;
    private string _dml_DeviceKey;
    private string _dml_DeviceName;

    public override object _Key => (object) new object[1]
    {
      (object) this.dml_ID
    };

    public long dml_ID
    {
      get => this._dml_ID;
      set
      {
        this._dml_ID = value;
        this.Changed(nameof (dml_ID));
      }
    }

    public long dml_SiteID
    {
      get => this._dml_SiteID;
      set
      {
        this._dml_SiteID = value;
        this.Changed(nameof (dml_SiteID));
      }
    }

    public DateTime? dml_SysDate
    {
      get => this._dml_SysDate;
      set
      {
        this._dml_SysDate = value;
        this.Changed(nameof (dml_SysDate));
      }
    }

    public int dml_StoreCode
    {
      get => this._dml_StoreCode;
      set
      {
        this._dml_StoreCode = value;
        this.Changed(nameof (dml_StoreCode));
      }
    }

    public int dml_EmpCode
    {
      get => this._dml_EmpCode;
      set
      {
        this._dml_EmpCode = value;
        this.Changed(nameof (dml_EmpCode));
      }
    }

    public int dml_CodeInt
    {
      get => this._dml_CodeInt;
      set
      {
        this._dml_CodeInt = value;
        this.Changed(nameof (dml_CodeInt));
      }
    }

    public long dml_CodeLong
    {
      get => this._dml_CodeLong;
      set
      {
        this._dml_CodeLong = value;
        this.Changed(nameof (dml_CodeLong));
      }
    }

    public string dml_CodeStr
    {
      get => this._dml_CodeStr;
      set
      {
        this._dml_CodeStr = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (dml_CodeStr));
      }
    }

    public int dml_ActionKind
    {
      get => this._dml_ActionKind;
      set
      {
        this._dml_ActionKind = value;
        this.Changed(nameof (dml_ActionKind));
        this.Changed("dml_ActionKindDesc");
      }
    }

    public string dml_ActionKindDesc => this.dml_ActionKind != 0 ? Enum2StrConverter.ToEmpActionKind(this.dml_ActionKind).ToDescription() : string.Empty;

    public string dml_ActionType
    {
      get => this._dml_ActionType;
      set
      {
        this._dml_ActionType = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (dml_ActionType));
      }
    }

    public int dml_TableSeq
    {
      get => this._dml_TableSeq;
      set
      {
        this._dml_TableSeq = value;
        this.Changed(nameof (dml_TableSeq));
        this.Changed("dml_TableSeqDesc");
      }
    }

    public string dml_TableSeqDesc => this.dml_TableSeq != 0 ? Enum2StrConverter.ToTableType(this.dml_TableSeq).ToDescription() : string.Empty;

    public string dml_ModColumn
    {
      get => this._dml_ModColumn;
      set
      {
        this._dml_ModColumn = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (dml_ModColumn));
      }
    }

    public string dml_ModColumnDesc
    {
      get => this._dml_ModColumnDesc;
      set
      {
        this._dml_ModColumnDesc = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (dml_ModColumnDesc));
      }
    }

    public string dml_BeforeValue
    {
      get => this._dml_BeforeValue;
      set
      {
        this._dml_BeforeValue = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (dml_BeforeValue));
      }
    }

    public string dml_AfterValue
    {
      get => this._dml_AfterValue;
      set
      {
        this._dml_AfterValue = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (dml_AfterValue));
      }
    }

    public string dml_DeviceKey
    {
      get => this._dml_DeviceKey;
      set
      {
        this._dml_DeviceKey = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (dml_DeviceKey));
      }
    }

    public string dml_DeviceName
    {
      get => this._dml_DeviceName;
      set
      {
        this._dml_DeviceName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (dml_DeviceName));
      }
    }

    public TDataModLog() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("dml_ID", new TTableColumn()
      {
        tc_orgin_name = "dml_ID",
        tc_trans_name = "ID (Key)"
      });
      columnInfo.Add("dml_SiteID", new TTableColumn()
      {
        tc_orgin_name = "dml_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("dml_SysDate", new TTableColumn()
      {
        tc_orgin_name = "dml_SysDate",
        tc_trans_name = "변경일시"
      });
      columnInfo.Add("dml_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "dml_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("dml_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "dml_EmpCode",
        tc_trans_name = "사용자코드"
      });
      columnInfo.Add("dml_CodeInt", new TTableColumn()
      {
        tc_orgin_name = "dml_CodeInt",
        tc_trans_name = "키값"
      });
      columnInfo.Add("dml_CodeLong", new TTableColumn()
      {
        tc_orgin_name = "dml_CodeLong",
        tc_trans_name = "키값2"
      });
      columnInfo.Add("dml_CodeStr", new TTableColumn()
      {
        tc_orgin_name = "dml_CodeStr",
        tc_trans_name = "키값3"
      });
      columnInfo.Add("dml_ActionKind", new TTableColumn()
      {
        tc_orgin_name = "dml_ActionKind",
        tc_trans_name = "변경유형"
      });
      columnInfo.Add("dml_TableSeq", new TTableColumn()
      {
        tc_orgin_name = "dml_TableSeq",
        tc_trans_name = "변경테이블"
      });
      columnInfo.Add("dml_ModColumn", new TTableColumn()
      {
        tc_orgin_name = "dml_ModColumn",
        tc_trans_name = "변경컬럼"
      });
      columnInfo.Add("dml_ModColumnDesc", new TTableColumn()
      {
        tc_orgin_name = "dml_ModColumnDesc",
        tc_trans_name = "변경컬럼설명"
      });
      columnInfo.Add("dml_BeforeValue", new TTableColumn()
      {
        tc_orgin_name = "dml_BeforeValue",
        tc_trans_name = "변경전Data"
      });
      columnInfo.Add("dml_AfterValue", new TTableColumn()
      {
        tc_orgin_name = "dml_AfterValue",
        tc_trans_name = "변경후Data"
      });
      columnInfo.Add("dml_DeviceKey", new TTableColumn()
      {
        tc_orgin_name = "dml_DeviceKey",
        tc_trans_name = "디바이스ID코드"
      });
      columnInfo.Add("dml_DeviceName", new TTableColumn()
      {
        tc_orgin_name = "dml_DeviceName",
        tc_trans_name = "디바이스명"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.DataModLog;
      this.dml_ID = 0L;
      this.dml_SiteID = 0L;
      this.dml_SysDate = new DateTime?();
      this.dml_StoreCode = this.dml_EmpCode = this.dml_CodeInt = 0;
      this.dml_CodeLong = 0L;
      this.dml_CodeStr = string.Empty;
      this.dml_ActionKind = 0;
      this.dml_ActionType = string.Empty;
      this.dml_TableSeq = 0;
      this.dml_ModColumn = this.dml_ModColumnDesc = this.dml_BeforeValue = this.dml_AfterValue = string.Empty;
      this.dml_DeviceKey = this.dml_DeviceName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TDataModLog();

    public override object Clone()
    {
      TDataModLog tdataModLog = base.Clone() as TDataModLog;
      tdataModLog.dml_ID = this.dml_ID;
      tdataModLog.dml_SiteID = this.dml_SiteID;
      tdataModLog.dml_SysDate = this.dml_SysDate;
      tdataModLog.dml_StoreCode = this.dml_StoreCode;
      tdataModLog.dml_EmpCode = this.dml_EmpCode;
      tdataModLog.dml_CodeInt = this.dml_CodeInt;
      tdataModLog.dml_CodeLong = this.dml_CodeLong;
      tdataModLog.dml_CodeStr = this.dml_CodeStr;
      tdataModLog.dml_ActionKind = this.dml_ActionKind;
      tdataModLog.dml_ActionType = this.dml_ActionType;
      tdataModLog.dml_TableSeq = this.dml_TableSeq;
      tdataModLog.dml_ModColumn = this.dml_ModColumn;
      tdataModLog.dml_ModColumnDesc = this.dml_ModColumnDesc;
      tdataModLog.dml_BeforeValue = this.dml_BeforeValue;
      tdataModLog.dml_AfterValue = this.dml_AfterValue;
      tdataModLog.dml_DeviceKey = this.dml_DeviceKey;
      tdataModLog.dml_DeviceName = this.dml_DeviceName;
      return (object) tdataModLog;
    }

    public void PutData(TDataModLog pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.dml_ID = pSource.dml_ID;
      this.dml_SiteID = pSource.dml_SiteID;
      this.dml_SysDate = pSource.dml_SysDate;
      this.dml_StoreCode = pSource.dml_StoreCode;
      this.dml_EmpCode = pSource.dml_EmpCode;
      this.dml_CodeInt = pSource.dml_CodeInt;
      this.dml_CodeLong = pSource.dml_CodeLong;
      this.dml_CodeStr = pSource.dml_CodeStr;
      this.dml_ActionKind = pSource.dml_ActionKind;
      this.dml_ActionType = pSource.dml_ActionType;
      this.dml_TableSeq = pSource.dml_TableSeq;
      this.dml_ModColumn = pSource.dml_ModColumn;
      this.dml_ModColumnDesc = pSource.dml_ModColumnDesc;
      this.dml_BeforeValue = pSource.dml_BeforeValue;
      this.dml_AfterValue = pSource.dml_AfterValue;
      this.dml_DeviceKey = pSource.dml_DeviceKey;
      this.dml_DeviceName = pSource.dml_DeviceName;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.dml_ID = p_rs.GetFieldLong("dml_ID");
        if (this.dml_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.dml_SiteID = p_rs.GetFieldLong("dml_SiteID");
        this.dml_SysDate = p_rs.GetFieldDateTime("dml_SysDate");
        this.dml_StoreCode = p_rs.GetFieldInt("dml_StoreCode");
        this.dml_EmpCode = p_rs.GetFieldInt("dml_EmpCode");
        this.dml_CodeInt = p_rs.GetFieldInt("dml_CodeInt");
        this.dml_CodeLong = p_rs.GetFieldLong("dml_CodeLong");
        this.dml_CodeStr = p_rs.GetFieldString("dml_CodeStr");
        this.dml_ActionKind = p_rs.GetFieldInt("dml_ActionKind");
        this.dml_ActionType = p_rs.GetFieldString("dml_ActionType");
        this.dml_TableSeq = p_rs.GetFieldInt("dml_TableSeq");
        this.dml_ModColumn = p_rs.GetFieldString("dml_ModColumn");
        this.dml_ModColumnDesc = p_rs.GetFieldString("dml_ModColumnDesc");
        this.dml_BeforeValue = p_rs.GetFieldString("dml_BeforeValue");
        this.dml_AfterValue = p_rs.GetFieldString("dml_AfterValue");
        this.dml_DeviceKey = p_rs.GetFieldString("dml_DeviceKey");
        this.dml_DeviceName = p_rs.GetFieldString("dml_DeviceName");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery()
    {
      if (!this.dml_SysDate.HasValue)
        this.dml_SysDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " dml_ID,dml_SiteID,dml_SysDate,dml_StoreCode,dml_EmpCode,dml_CodeInt,dml_CodeLong,dml_CodeStr,dml_ActionKind,dml_ActionType,dml_TableSeq,dml_ModColumn,dml_ModColumnDesc,dml_BeforeValue,dml_AfterValue,dml_DeviceKey,dml_DeviceName) VALUES ( " + string.Format(" {0}", (object) this.dml_ID) + string.Format(",{0},{1}", (object) this.dml_SiteID, (object) this.dml_SysDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.dml_StoreCode, (object) this.dml_EmpCode) + string.Format(",{0},{1},'{2}'", (object) this.dml_CodeInt, (object) this.dml_CodeLong, (object) this.dml_CodeStr) + string.Format(",{0},'{1}',{2}", (object) this.dml_ActionKind, (object) this.dml_ActionType, (object) this.dml_TableSeq) + ",'" + this.dml_ModColumn + "','" + this.dml_ModColumnDesc + "','" + this.dml_BeforeValue + "','" + this.dml_AfterValue + "','" + this.dml_DeviceKey + "','" + this.dml_DeviceName + "')";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.dml_ID, (object) this.dml_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TDataModLog tdataModLog = this;
      // ISSUE: reference to a compiler-generated method
      tdataModLog.\u003C\u003En__0();
      if (await tdataModLog.OleDB.ExecuteAsync(tdataModLog.InsertQuery()))
        return true;
      tdataModLog.message = " " + tdataModLog.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tdataModLog.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tdataModLog.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tdataModLog.dml_ID, (object) tdataModLog.dml_SiteID) + " 내용 : " + tdataModLog.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tdataModLog.message);
      return false;
    }

    public override async Task<bool> InsertQueryExecuteAsync(string p_Query)
    {
      TDataModLog tdataModLog = this;
      // ISSUE: reference to a compiler-generated method
      tdataModLog.\u003C\u003En__0();
      if (await tdataModLog.OleDB.ExecuteAsync(p_Query))
        return true;
      tdataModLog.message = " " + tdataModLog.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tdataModLog.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tdataModLog.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tdataModLog.dml_ID, (object) tdataModLog.dml_SiteID) + " 내용 : " + tdataModLog.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tdataModLog.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "dml_SiteID") && Convert.ToInt64(hashtable[(object) "dml_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "dml_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "dml_ID") && Convert.ToInt64(hashtable[(object) "dml_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_ID", hashtable[(object) "dml_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "dml_SysDate"))
        {
          stringBuilder.Append(" AND dml_SysDate >='" + new DateTime?((DateTime) hashtable[(object) "dml_SysDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND dml_SysDate <='" + new DateTime?((DateTime) hashtable[(object) "dml_SysDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "dml_SysDate_BEGIN_") && hashtable.ContainsKey((object) "dml_SysDate_END_"))
        {
          stringBuilder.Append(" AND dml_SysDate >='" + new DateTime?((DateTime) hashtable[(object) "dml_SysDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND dml_SysDate <='" + new DateTime?((DateTime) hashtable[(object) "dml_SysDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "dml_StoreCode") && Convert.ToInt32(hashtable[(object) "dml_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_StoreCode", hashtable[(object) "dml_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN") && hashtable[(object) "si_StoreCode_IN"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "dml_StoreCode", hashtable[(object) "si_StoreCode_IN"]));
        else if (hashtable.ContainsKey((object) "dml_StoreCode_IN") && hashtable[(object) "dml_StoreCode_IN"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "dml_StoreCode", hashtable[(object) "dml_StoreCode_IN"]));
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_EmpCode", hashtable[(object) "emp_Code"]));
        else if (hashtable.ContainsKey((object) "dml_EmpCode") && Convert.ToInt32(hashtable[(object) "dml_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_EmpCode", hashtable[(object) "dml_EmpCode"]));
        if (hashtable.ContainsKey((object) "dml_CodeInt") && Convert.ToInt32(hashtable[(object) "dml_CodeInt"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_CodeInt", hashtable[(object) "dml_CodeInt"]));
        if (hashtable.ContainsKey((object) "dml_CodeLong") && Convert.ToInt64(hashtable[(object) "dml_CodeLong"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_CodeLong", hashtable[(object) "dml_CodeLong"]));
        if (hashtable.ContainsKey((object) "dml_CodeStr") && hashtable[(object) "dml_CodeStr"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "dml_CodeStr", hashtable[(object) "dml_CodeStr"]));
        if (hashtable.ContainsKey((object) "dml_ActionKind") && Convert.ToInt32(hashtable[(object) "dml_ActionKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_ActionKind", hashtable[(object) "dml_ActionKind"]));
        if (hashtable.ContainsKey((object) "dml_TableSeq") && Convert.ToInt32(hashtable[(object) "dml_TableSeq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dml_TableSeq", hashtable[(object) "dml_TableSeq"]));
        if (hashtable.ContainsKey((object) "dml_ModColumn") && hashtable[(object) "dml_ModColumn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "dml_ModColumn", hashtable[(object) "dml_ModColumn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "dml_ModColumn", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dml_ModColumnDesc", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  dml_ID,dml_SiteID,dml_SysDate,dml_StoreCode,dml_EmpCode,dml_CodeInt,dml_CodeLong,dml_CodeStr,dml_ActionKind,dml_ActionType,dml_TableSeq,dml_ModColumn,dml_ModColumnDesc,dml_BeforeValue,dml_AfterValue,dml_DeviceKey,dml_DeviceName");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
