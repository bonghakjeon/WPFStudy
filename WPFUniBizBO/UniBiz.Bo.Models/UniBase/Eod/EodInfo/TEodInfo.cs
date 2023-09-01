// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodInfo.TEodInfo
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

namespace UniBiz.Bo.Models.UniBase.Eod.EodInfo
{
  public class TEodInfo : UbModelBase<TEodInfo>
  {
    private int _eod_ID;
    private long _eod_SiteID;
    private DateTime? _eod_Date;
    private int _eod_Type;
    private int _eod_Status;
    private int _eod_Count;
    private DateTime? _eod_StartDate;
    private DateTime? _eod_EndDate;
    private int _eod_Success;
    private string _eod_Message;
    private int _eod_EmpCode;

    public override object _Key => (object) new object[1]
    {
      (object) this.eod_ID
    };

    public int eod_ID
    {
      get => this._eod_ID;
      set
      {
        this._eod_ID = value;
        this.Changed(nameof (eod_ID));
      }
    }

    public long eod_SiteID
    {
      get => this._eod_SiteID;
      set
      {
        this._eod_SiteID = value;
        this.Changed(nameof (eod_SiteID));
      }
    }

    public DateTime? eod_Date
    {
      get => this._eod_Date;
      set
      {
        this._eod_Date = value;
        this.Changed(nameof (eod_Date));
      }
    }

    public int eod_Type
    {
      get => this._eod_Type;
      set
      {
        this._eod_Type = value;
        this.Changed(nameof (eod_Type));
        this.Changed("eod_TypeDesc");
      }
    }

    public string eod_TypeDesc => this.eod_Type != 0 ? Enum2StrConverter.ToEodInfoType(this.eod_Type).ToDescription() : string.Empty;

    public int eod_Status
    {
      get => this._eod_Status;
      set
      {
        this._eod_Status = value;
        this.Changed(nameof (eod_Status));
        this.Changed("eod_StatusDesc");
      }
    }

    public string eod_StatusDesc => this.eod_Status != 0 ? Enum2StrConverter.ToEodInfoStatus(this.eod_Status).ToDescription() : string.Empty;

    public int eod_Count
    {
      get => this._eod_Count;
      set
      {
        this._eod_Count = value;
        this.Changed(nameof (eod_Count));
      }
    }

    public DateTime? eod_StartDate
    {
      get => this._eod_StartDate;
      set
      {
        this._eod_StartDate = value;
        this.Changed(nameof (eod_StartDate));
      }
    }

    public DateTime? eod_EndDate
    {
      get => this._eod_EndDate;
      set
      {
        this._eod_EndDate = value;
        this.Changed(nameof (eod_EndDate));
        this.Changed("eod_WorkSeconds");
      }
    }

    public int eod_WorkSeconds => this.eod_EndDate.ToDeffSeconds(this.eod_StartDate);

    public int eod_Success
    {
      get => this._eod_Success;
      set
      {
        this._eod_Success = value;
        this.Changed(nameof (eod_Success));
        this.Changed("eod_IsSuccess");
      }
    }

    public bool eod_IsSuccess => this.eod_Success > 0;

    public string eod_Message
    {
      get => this._eod_Message;
      set
      {
        this._eod_Message = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (eod_Message));
      }
    }

    public int eod_EmpCode
    {
      get => this._eod_EmpCode;
      set
      {
        this._eod_EmpCode = value;
        this.Changed(nameof (eod_EmpCode));
      }
    }

    public TEodInfo() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("eod_ID", new TTableColumn()
      {
        tc_orgin_name = "eod_ID",
        tc_trans_name = "EOD ID"
      });
      columnInfo.Add("eod_SiteID", new TTableColumn()
      {
        tc_orgin_name = "eod_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("eod_Date", new TTableColumn()
      {
        tc_orgin_name = "eod_Date",
        tc_trans_name = "일자"
      });
      columnInfo.Add("eod_Type", new TTableColumn()
      {
        tc_orgin_name = "eod_Type",
        tc_trans_name = "타입",
        tc_comm_code = 211
      });
      columnInfo.Add("eod_Status", new TTableColumn()
      {
        tc_orgin_name = "eod_Status",
        tc_trans_name = "상태",
        tc_comm_code = 212
      });
      columnInfo.Add("eod_Count", new TTableColumn()
      {
        tc_orgin_name = "eod_Count",
        tc_trans_name = "건수"
      });
      columnInfo.Add("eod_StartDate", new TTableColumn()
      {
        tc_orgin_name = "eod_StartDate",
        tc_trans_name = "시작"
      });
      columnInfo.Add("eod_EndDate", new TTableColumn()
      {
        tc_orgin_name = "eod_EndDate",
        tc_trans_name = "종료"
      });
      columnInfo.Add("eod_Success", new TTableColumn()
      {
        tc_orgin_name = "eod_Success",
        tc_trans_name = "응답"
      });
      columnInfo.Add("eod_Message", new TTableColumn()
      {
        tc_orgin_name = "eod_Message",
        tc_trans_name = "메세지"
      });
      columnInfo.Add("eod_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "eod_EmpCode",
        tc_trans_name = "사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.EodInfo;
      this.eod_ID = 0;
      this.eod_SiteID = 0L;
      this.eod_Date = new DateTime?();
      this.eod_Type = 0;
      this.eod_Status = 0;
      this.eod_Count = 0;
      this.eod_StartDate = new DateTime?();
      this.eod_EndDate = new DateTime?();
      this.eod_Success = 0;
      this.eod_Message = string.Empty;
      this.eod_EmpCode = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEodInfo();

    public override object Clone()
    {
      TEodInfo teodInfo = base.Clone() as TEodInfo;
      teodInfo.eod_ID = this.eod_ID;
      teodInfo.eod_SiteID = this.eod_SiteID;
      teodInfo.eod_Date = this.eod_Date;
      teodInfo.eod_Type = this.eod_Type;
      teodInfo.eod_Status = this.eod_Status;
      teodInfo.eod_Count = this.eod_Count;
      teodInfo.eod_StartDate = this.eod_StartDate;
      teodInfo.eod_EndDate = this.eod_EndDate;
      teodInfo.eod_Success = this.eod_Success;
      teodInfo.eod_Message = this.eod_Message;
      teodInfo.eod_EmpCode = this.eod_EmpCode;
      return (object) teodInfo;
    }

    public void PutData(TEodInfo pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.eod_ID = pSource.eod_ID;
      this.eod_SiteID = pSource.eod_SiteID;
      this.eod_Date = pSource.eod_Date;
      this.eod_Type = pSource.eod_Type;
      this.eod_Status = pSource.eod_Status;
      this.eod_Count = pSource.eod_Count;
      this.eod_StartDate = pSource.eod_StartDate;
      this.eod_EndDate = pSource.eod_EndDate;
      this.eod_Success = pSource.eod_Success;
      this.eod_Message = pSource.eod_Message;
      this.eod_EmpCode = pSource.eod_EmpCode;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.eod_ID = p_rs.GetFieldInt("eod_ID");
        if (this.eod_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.eod_SiteID = p_rs.GetFieldLong("eod_SiteID");
        this.eod_Date = p_rs.GetFieldDateTime("eod_Date");
        this.eod_Type = p_rs.GetFieldInt("eod_Type");
        this.eod_Status = p_rs.GetFieldInt("eod_Status");
        this.eod_Count = p_rs.GetFieldInt("eod_Count");
        this.eod_StartDate = p_rs.GetFieldDateTime("eod_StartDate");
        this.eod_EndDate = p_rs.GetFieldDateTime("eod_EndDate");
        this.eod_Success = p_rs.GetFieldInt("eod_Success");
        this.eod_Message = p_rs.GetFieldString("eod_Message");
        this.eod_EmpCode = p_rs.GetFieldInt("eod_EmpCode");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " eod_ID,eod_SiteID,eod_Date,eod_Type,eod_Status,eod_Count,eod_StartDate,eod_EndDate,eod_Success,eod_Message,eod_EmpCode) VALUES ( " + string.Format(" {0}", (object) this.eod_ID) + string.Format(",{0}", (object) this.eod_SiteID) + "," + this.eod_Date.GetDateToStrInNull() + string.Format(",{0},{1},{2}", (object) this.eod_Type, (object) this.eod_Status, (object) this.eod_Count) + "," + this.eod_StartDate.GetDateToStrInNull() + "," + this.eod_EndDate.GetDateToStrInNull() + string.Format(",{0},'{1}',{2}", (object) this.eod_Success, (object) this.eod_Message, (object) this.eod_EmpCode) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eod_ID, (object) this.eod_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEodInfo teodInfo = this;
      // ISSUE: reference to a compiler-generated method
      teodInfo.\u003C\u003En__0();
      if (await teodInfo.OleDB.ExecuteAsync(teodInfo.InsertQuery()))
        return true;
      teodInfo.message = " " + teodInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodInfo.eod_ID, (object) teodInfo.eod_SiteID) + " 내용 : " + teodInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodInfo.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " eod_Date=" + this.eod_Date.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "eod_Type", (object) this.eod_Type, (object) "eod_Status", (object) this.eod_Status, (object) "eod_Count", (object) this.eod_Count) + ",eod_StartDate=" + this.eod_StartDate.GetDateToStrInNull() + ",eod_EndDate=" + this.eod_EndDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}='{3}',{4}={5}", (object) "eod_Success", (object) this.eod_Success, (object) "eod_Message", (object) this.eod_Message, (object) "eod_EmpCode", (object) this.eod_EmpCode) + string.Format(" WHERE {0}={1}", (object) "eod_ID", (object) this.eod_ID) + string.Format(" AND {0}={1}", (object) "eod_SiteID", (object) this.eod_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eod_ID, (object) this.eod_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TEodInfo teodInfo = this;
      // ISSUE: reference to a compiler-generated method
      teodInfo.\u003C\u003En__1();
      if (await teodInfo.OleDB.ExecuteAsync(teodInfo.UpdateQuery()))
        return true;
      teodInfo.message = " " + teodInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodInfo.eod_ID, (object) teodInfo.eod_SiteID) + " 내용 : " + teodInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodInfo.message);
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
      stringBuilder.Append(" eod_Date=" + this.eod_Date.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "eod_Type", (object) this.eod_Type, (object) "eod_Status", (object) this.eod_Status, (object) "eod_Count", (object) this.eod_Count) + ",eod_StartDate=" + this.eod_StartDate.GetDateToStrInNull() + ",eod_EndDate=" + this.eod_EndDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}='{3}',{4}={5}", (object) "eod_Success", (object) this.eod_Success, (object) "eod_Message", (object) this.eod_Message, (object) "eod_EmpCode", (object) this.eod_EmpCode));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.eod_ID, (object) this.eod_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TEodInfo teodInfo = this;
      // ISSUE: reference to a compiler-generated method
      teodInfo.\u003C\u003En__1();
      if (await teodInfo.OleDB.ExecuteAsync(teodInfo.UpdateExInsertQuery()))
        return true;
      teodInfo.message = " " + teodInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + teodInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) teodInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) teodInfo.eod_ID, (object) teodInfo.eod_SiteID) + " 내용 : " + teodInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(teodInfo.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "eod_SiteID") && Convert.ToInt64(hashtable[(object) "eod_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "eod_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "eod_ID") && Convert.ToInt32(hashtable[(object) "eod_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eod_ID", hashtable[(object) "eod_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eod_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "eod_Date"))
        {
          stringBuilder.Append(" AND eod_Date >='" + new DateTime?((DateTime) hashtable[(object) "eod_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eod_Date <='" + new DateTime?((DateTime) hashtable[(object) "eod_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "eod_Date_BEGIN_") && hashtable.ContainsKey((object) "eod_Date_END_"))
        {
          stringBuilder.Append(" AND eod_Date >='" + new DateTime?((DateTime) hashtable[(object) "eod_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND eod_Date <='" + new DateTime?((DateTime) hashtable[(object) "eod_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "eod_Type") && Convert.ToInt32(hashtable[(object) "eod_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eod_Type", hashtable[(object) "eod_Type"]));
        if (hashtable.ContainsKey((object) "eod_Status") && Convert.ToInt32(hashtable[(object) "eod_Status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eod_Status", hashtable[(object) "eod_Status"]));
        if (hashtable.ContainsKey((object) "eod_Success") && Convert.ToInt32(hashtable[(object) "eod_Success"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "eod_Success", hashtable[(object) "eod_Success"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "eod_Message", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  eod_ID,eod_SiteID,eod_Date,eod_Type,eod_Status,eod_Count,eod_StartDate,eod_EndDate,eod_Success,eod_Message,eod_EmpCode");
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
