// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpActionLog.TEmpActionLog
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

namespace UniBiz.Bo.Models.UniBase.Employee.EmpActionLog
{
  public class TEmpActionLog : UbModelBase<TEmpActionLog>
  {
    private long _eal_ID;
    private long _eal_SiteID;
    private DateTime? _eal_SysDate;
    private int _eal_StoreCode;
    private int _eal_EmpCode;
    protected int _eal_MenuCode;
    private int _eal_SubProgID;
    private int _eal_ApplyRowCnt;
    private int _eal_ActionKind;
    private string _eal_LocalIP;
    private string _eal_PublicIP;
    private string _eal_DeviceName;
    private string _eal_Memo;
    private string _eal_Memo2;
    private int _eal_ProgKind;

    public override object _Key => (object) new object[1]
    {
      (object) this.eal_ID
    };

    public long eal_ID
    {
      get => this._eal_ID;
      set
      {
        this._eal_ID = value;
        this.Changed(nameof (eal_ID));
      }
    }

    public long eal_SiteID
    {
      get => this._eal_SiteID;
      set
      {
        this._eal_SiteID = value;
        this.Changed(nameof (eal_SiteID));
      }
    }

    public DateTime? eal_SysDate
    {
      get => this._eal_SysDate;
      set
      {
        this._eal_SysDate = value;
        this.Changed(nameof (eal_SysDate));
      }
    }

    public int eal_StoreCode
    {
      get => this._eal_StoreCode;
      set
      {
        this._eal_StoreCode = value;
        this.Changed(nameof (eal_StoreCode));
      }
    }

    public int eal_EmpCode
    {
      get => this._eal_EmpCode;
      set
      {
        this._eal_EmpCode = value;
        this.Changed(nameof (eal_EmpCode));
      }
    }

    public int eal_MenuCode
    {
      get => this._eal_MenuCode;
      set
      {
        this._eal_MenuCode = value;
        this.Changed(nameof (eal_MenuCode));
        this.Changed("eal_WorkTableDesc");
        this.Changed("eal_Title");
      }
    }

    public int eal_SubProgID
    {
      get => this._eal_SubProgID;
      set
      {
        this._eal_SubProgID = value;
        this.Changed(nameof (eal_SubProgID));
        this.Changed("eal_WorkTableDesc");
        this.Changed("eal_Title");
      }
    }

    public string eal_WorkTableDesc => this.eal_MenuCode <= 0 ? string.Empty : string.Empty;

    public virtual string eal_Title => this.eal_MenuCode <= 0 ? string.Empty : string.Empty;

    public int eal_ApplyRowCnt
    {
      get => this._eal_ApplyRowCnt;
      set
      {
        this._eal_ApplyRowCnt = value;
        this.Changed(nameof (eal_ApplyRowCnt));
      }
    }

    public int eal_ActionKind
    {
      get => this._eal_ActionKind;
      set
      {
        this._eal_ActionKind = value;
        this.Changed(nameof (eal_ActionKind));
        this.Changed("eal_ActionKindDesc");
      }
    }

    public string eal_ActionKindDesc => this.eal_ActionKind != 0 ? Enum2StrConverter.ToEmpActionKind(this.eal_ActionKind).ToDescription() : string.Empty;

    public string eal_LocalIP
    {
      get => this._eal_LocalIP;
      set
      {
        this._eal_LocalIP = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (eal_LocalIP));
      }
    }

    public string eal_PublicIP
    {
      get => this._eal_PublicIP;
      set
      {
        this._eal_PublicIP = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (eal_PublicIP));
      }
    }

    public string eal_DeviceName
    {
      get => this._eal_DeviceName;
      set
      {
        this._eal_DeviceName = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (eal_DeviceName));
      }
    }

    public string eal_Memo
    {
      get => this._eal_Memo;
      set
      {
        this._eal_Memo = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (eal_Memo));
      }
    }

    public string eal_Memo2
    {
      get => this._eal_Memo2;
      set
      {
        this._eal_Memo2 = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (eal_Memo2));
      }
    }

    public int eal_ProgKind
    {
      get => this._eal_ProgKind;
      set
      {
        this._eal_ProgKind = value;
        this.Changed(nameof (eal_ProgKind));
        this.Changed("eal_ProgKindDesc");
      }
    }

    public string eal_ProgKindDesc => this.eal_ProgKind != 0 ? Enum2StrConverter.ToAppType(this.eal_ProgKind).ToDescription() : string.Empty;

    public TEmpActionLog() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("eal_ID", new TTableColumn()
      {
        tc_orgin_name = "eal_ID",
        tc_trans_name = "ID (Key)"
      });
      columnInfo.Add("eal_SiteID", new TTableColumn()
      {
        tc_orgin_name = "eal_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("eal_SysDate", new TTableColumn()
      {
        tc_orgin_name = "eal_SysDate",
        tc_trans_name = "사용일시"
      });
      columnInfo.Add("eal_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "eal_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("eal_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "eal_EmpCode",
        tc_trans_name = "사용자코드"
      });
      columnInfo.Add("eal_MenuCode", new TTableColumn()
      {
        tc_orgin_name = "eal_MenuCode",
        tc_trans_name = "메뉴코드"
      });
      columnInfo.Add("eal_SubProgID", new TTableColumn()
      {
        tc_orgin_name = "eal_SubProgID",
        tc_trans_name = "Sub화면 ID"
      });
      columnInfo.Add("eal_ApplyRowCnt", new TTableColumn()
      {
        tc_orgin_name = "eal_ApplyRowCnt",
        tc_trans_name = "데이터수"
      });
      columnInfo.Add("eal_ActionKind", new TTableColumn()
      {
        tc_orgin_name = "eal_ActionKind",
        tc_trans_name = "작업유형"
      });
      columnInfo.Add("eal_LocalIP", new TTableColumn()
      {
        tc_orgin_name = "eal_LocalIP",
        tc_trans_name = "내부 IP"
      });
      columnInfo.Add("eal_PublicIP", new TTableColumn()
      {
        tc_orgin_name = "eal_PublicIP",
        tc_trans_name = "접속 IP"
      });
      columnInfo.Add("eal_DeviceName", new TTableColumn()
      {
        tc_orgin_name = "eal_DeviceName",
        tc_trans_name = "디바이스명"
      });
      columnInfo.Add("eal_Memo", new TTableColumn()
      {
        tc_orgin_name = "eal_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("eal_Memo2", new TTableColumn()
      {
        tc_orgin_name = "eal_Memo2",
        tc_trans_name = "메모2"
      });
      columnInfo.Add("eal_ProgKind", new TTableColumn()
      {
        tc_orgin_name = "eal_ProgKind",
        tc_trans_name = "프로그램 종류",
        tc_comm_code = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.EmpActionLog;
      this.eal_ID = 0L;
      this.eal_SiteID = 0L;
      this.eal_SysDate = new DateTime?();
      this.eal_StoreCode = this.eal_EmpCode = this.eal_MenuCode = this.eal_SubProgID = this.eal_ApplyRowCnt = 0;
      this.eal_ActionKind = 0;
      this.eal_LocalIP = this.eal_PublicIP = string.Empty;
      this.eal_DeviceName = this.eal_Memo = this.eal_Memo2 = string.Empty;
      this.eal_ProgKind = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEmpActionLog();

    public override object Clone()
    {
      TEmpActionLog tempActionLog = base.Clone() as TEmpActionLog;
      tempActionLog.eal_ID = this.eal_ID;
      tempActionLog.eal_SiteID = this.eal_SiteID;
      tempActionLog.eal_SysDate = this.eal_SysDate;
      tempActionLog.eal_StoreCode = this.eal_StoreCode;
      tempActionLog.eal_EmpCode = this.eal_EmpCode;
      tempActionLog.eal_MenuCode = this.eal_MenuCode;
      tempActionLog.eal_SubProgID = this.eal_SubProgID;
      tempActionLog.eal_ApplyRowCnt = this.eal_ApplyRowCnt;
      tempActionLog.eal_ActionKind = this.eal_ActionKind;
      tempActionLog.eal_LocalIP = this.eal_LocalIP;
      tempActionLog.eal_PublicIP = this.eal_PublicIP;
      tempActionLog.eal_DeviceName = this.eal_DeviceName;
      tempActionLog.eal_Memo = this.eal_Memo;
      tempActionLog.eal_Memo2 = this.eal_Memo2;
      tempActionLog.eal_ProgKind = this.eal_ProgKind;
      return (object) tempActionLog;
    }

    public void PutData(TEmpActionLog pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.eal_ID = pSource.eal_ID;
      this.eal_SiteID = pSource.eal_SiteID;
      this.eal_SysDate = pSource.eal_SysDate;
      this.eal_StoreCode = pSource.eal_StoreCode;
      this.eal_EmpCode = pSource.eal_EmpCode;
      this.eal_MenuCode = pSource.eal_MenuCode;
      this.eal_SubProgID = pSource.eal_SubProgID;
      this.eal_ApplyRowCnt = pSource.eal_ApplyRowCnt;
      this.eal_ActionKind = pSource.eal_ActionKind;
      this.eal_LocalIP = pSource.eal_LocalIP;
      this.eal_PublicIP = pSource.eal_PublicIP;
      this.eal_DeviceName = pSource.eal_DeviceName;
      this.eal_Memo = pSource.eal_Memo;
      this.eal_Memo2 = pSource.eal_Memo2;
      this.eal_ProgKind = pSource.eal_ProgKind;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.eal_ID = p_rs.GetFieldLong("eal_ID");
        if (this.eal_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.eal_SiteID = p_rs.GetFieldLong("eal_SiteID");
        this.eal_SysDate = p_rs.GetFieldDateTime("eal_SysDate");
        this.eal_StoreCode = p_rs.GetFieldInt("eal_StoreCode");
        this.eal_EmpCode = p_rs.GetFieldInt("eal_EmpCode");
        this.eal_MenuCode = p_rs.GetFieldInt("eal_MenuCode");
        this.eal_SubProgID = p_rs.GetFieldInt("eal_SubProgID");
        this.eal_ApplyRowCnt = p_rs.GetFieldInt("eal_ApplyRowCnt");
        this.eal_ActionKind = p_rs.GetFieldInt("eal_ActionKind");
        this.eal_LocalIP = p_rs.GetFieldString("eal_LocalIP");
        this.eal_PublicIP = p_rs.GetFieldString("eal_PublicIP");
        this.eal_DeviceName = p_rs.GetFieldString("eal_DeviceName");
        this.eal_Memo = p_rs.GetFieldString("eal_Memo");
        this.eal_Memo2 = p_rs.GetFieldString("eal_Memo2");
        this.eal_ProgKind = p_rs.GetFieldInt("eal_ProgKind");
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
      if (!this.eal_SysDate.HasValue)
        this.eal_SysDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " eal_ID,eal_SiteID,eal_SysDate,eal_StoreCode,eal_EmpCode,eal_MenuCode,eal_SubProgID,eal_ApplyRowCnt,eal_ActionKind,eal_LocalIP,eal_PublicIP,eal_DeviceName,eal_Memo,eal_Memo2,eal_ProgKind) VALUES ( " + string.Format(" {0}", (object) this.eal_ID) + string.Format(",{0},{1}", (object) this.eal_SiteID, (object) this.eal_SysDate.GetDateToStrInNull()) + string.Format(",{0},{1},{2},{3}", (object) this.eal_StoreCode, (object) this.eal_EmpCode, (object) this.eal_MenuCode, (object) this.eal_SubProgID) + string.Format(",{0},{1}", (object) this.eal_ApplyRowCnt, (object) this.eal_ActionKind) + ",'" + this.eal_LocalIP + "','" + this.eal_PublicIP + "','" + this.eal_DeviceName + "'" + string.Format(",'{0}','{1}',{2}", (object) this.eal_Memo, (object) this.eal_Memo2, (object) this.eal_ProgKind) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eal_ID, (object) this.eal_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEmpActionLog tempActionLog = this;
      // ISSUE: reference to a compiler-generated method
      tempActionLog.\u003C\u003En__0();
      if (await tempActionLog.OleDB.ExecuteAsync(tempActionLog.InsertQuery()))
        return true;
      tempActionLog.message = " " + tempActionLog.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempActionLog.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempActionLog.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tempActionLog.eal_ID, (object) tempActionLog.eal_SiteID) + " 내용 : " + tempActionLog.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempActionLog.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "eal_SiteID") && Convert.ToInt64(hashtable[(object) "eal_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "eal_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "eal_ID") && Convert.ToInt64(hashtable[(object) "eal_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_ID", hashtable[(object) "eal_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "eal_SysDate"))
        {
          stringBuilder.Append(" AND eal_SysDate >='" + new DateTime?((DateTime) hashtable[(object) "eal_SysDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eal_SysDate <='" + new DateTime?((DateTime) hashtable[(object) "eal_SysDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "eal_SysDate_BEGIN_") && hashtable.ContainsKey((object) "eal_SysDate_END_"))
        {
          stringBuilder.Append(" AND eal_SysDate >='" + new DateTime?((DateTime) hashtable[(object) "eal_SysDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eal_SysDate <='" + new DateTime?((DateTime) hashtable[(object) "eal_SysDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "eal_StoreCode") && Convert.ToInt32(hashtable[(object) "eal_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_StoreCode", hashtable[(object) "eal_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN") && hashtable[(object) "si_StoreCode_IN"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "eal_StoreCode", hashtable[(object) "si_StoreCode_IN"]));
        else if (hashtable.ContainsKey((object) "eal_StoreCode_IN") && hashtable[(object) "eal_StoreCode_IN"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "eal_StoreCode", hashtable[(object) "eal_StoreCode_IN"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "eal_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_EmpCode", hashtable[(object) "emp_Code"]));
        else if (hashtable.ContainsKey((object) "eal_EmpCode") && Convert.ToInt32(hashtable[(object) "eal_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_EmpCode", hashtable[(object) "eal_EmpCode"]));
        if (hashtable.ContainsKey((object) "eal_ActionKind") && Convert.ToInt32(hashtable[(object) "eal_ActionKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_ActionKind", hashtable[(object) "eal_ActionKind"]));
        if (hashtable.ContainsKey((object) "eal_ProgKind") && Convert.ToInt32(hashtable[(object) "eal_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eal_ProgKind", hashtable[(object) "eal_ProgKind"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        stringBuilder.Append(" SELECT  eal_ID,eal_SiteID,eal_SysDate,eal_StoreCode,eal_EmpCode,eal_MenuCode,eal_SubProgID,eal_ApplyRowCnt,eal_ActionKind,eal_LocalIP,eal_PublicIP,eal_DeviceName,eal_Memo,eal_Memo2,eal_ProgKind");
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
