// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode.TErrorCode
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

namespace UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode
{
  public class TErrorCode : UbModelBase<TErrorCode>
  {
    private int _err_ID;
    private long _err_SiteID;
    private string _err_ViewCode;
    private string _err_Msg1;
    private string _err_Msg2;

    public override object _Key => (object) new object[1]
    {
      (object) this.err_ID
    };

    public int err_ID
    {
      get => this._err_ID;
      set
      {
        this._err_ID = value;
        this.Changed(nameof (err_ID));
      }
    }

    public long err_SiteID
    {
      get => this._err_SiteID;
      set
      {
        this._err_SiteID = value;
        this.Changed(nameof (err_SiteID));
      }
    }

    public string err_ViewCode
    {
      get => this._err_ViewCode;
      set
      {
        this._err_ViewCode = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (err_ViewCode));
      }
    }

    public string err_Msg1
    {
      get => this._err_Msg1;
      set
      {
        this._err_Msg1 = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (err_Msg1));
      }
    }

    public string err_Msg2
    {
      get => this._err_Msg2;
      set
      {
        this._err_Msg2 = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (err_Msg2));
      }
    }

    public TErrorCode() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("err_ID", new TTableColumn()
      {
        tc_orgin_name = "err_ID",
        tc_trans_name = "ID (Key)"
      });
      columnInfo.Add("err_SiteID", new TTableColumn()
      {
        tc_orgin_name = "err_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("err_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "err_ViewCode",
        tc_trans_name = "ErrorCode"
      });
      columnInfo.Add("err_Msg1", new TTableColumn()
      {
        tc_orgin_name = "err_Msg1",
        tc_trans_name = "ErrorMessage"
      });
      columnInfo.Add("err_Msg2", new TTableColumn()
      {
        tc_orgin_name = "err_Msg2",
        tc_trans_name = "추가 설명"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ErrorCode;
      this.err_ID = 0;
      this.err_SiteID = 0L;
      this.err_ViewCode = this.err_Msg1 = this.err_Msg2 = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TErrorCode();

    public override object Clone()
    {
      TErrorCode terrorCode = base.Clone() as TErrorCode;
      terrorCode.err_ID = this.err_ID;
      terrorCode.err_SiteID = this.err_SiteID;
      terrorCode.err_ViewCode = this.err_ViewCode;
      terrorCode.err_Msg1 = this.err_Msg1;
      terrorCode.err_Msg2 = this.err_Msg2;
      return (object) terrorCode;
    }

    public void PutData(TErrorCode pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.err_ID = pSource.err_ID;
      this.err_SiteID = pSource.err_SiteID;
      this.err_ViewCode = pSource.err_ViewCode;
      this.err_Msg1 = pSource.err_Msg1;
      this.err_Msg2 = pSource.err_Msg2;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.err_ID = p_rs.GetFieldInt("err_ID");
        if (this.err_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.err_SiteID = p_rs.GetFieldLong("err_SiteID");
        this.err_ViewCode = p_rs.GetFieldString("err_ViewCode");
        this.err_Msg1 = p_rs.GetFieldString("err_Msg1");
        this.err_Msg2 = p_rs.GetFieldString("err_Msg2");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " err_ID,err_SiteID,err_ViewCode,err_Msg1,err_Msg2) VALUES ( " + string.Format(" {0}", (object) this.err_ID) + string.Format(",{0}", (object) this.err_SiteID) + ",'" + this.err_ViewCode + "','" + this.err_Msg1 + "','" + this.err_Msg2 + "')";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.err_ID, (object) this.err_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TErrorCode terrorCode = this;
      // ISSUE: reference to a compiler-generated method
      terrorCode.\u003C\u003En__0();
      if (await terrorCode.OleDB.ExecuteAsync(terrorCode.InsertQuery()))
        return true;
      terrorCode.message = " " + terrorCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrorCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrorCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrorCode.err_ID, (object) terrorCode.err_SiteID) + " 내용 : " + terrorCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrorCode.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " err_ViewCode='" + this.err_ViewCode + "',err_Msg1='" + this.err_Msg1 + "',err_Msg2='" + this.err_Msg2 + "'" + string.Format(" WHERE {0}={1}", (object) "err_ID", (object) this.err_ID) + string.Format(" AND {0}={1}", (object) "err_SiteID", (object) this.err_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.err_ID, (object) this.err_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TErrorCode terrorCode = this;
      // ISSUE: reference to a compiler-generated method
      terrorCode.\u003C\u003En__1();
      if (await terrorCode.OleDB.ExecuteAsync(terrorCode.UpdateQuery()))
        return true;
      terrorCode.message = " " + terrorCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrorCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrorCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrorCode.err_ID, (object) terrorCode.err_SiteID) + " 내용 : " + terrorCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrorCode.message);
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
      stringBuilder.Append(" err_ViewCode='" + this.err_ViewCode + "',err_Msg1='" + this.err_Msg1 + "',err_Msg2='" + this.err_Msg2 + "'");
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.err_ID, (object) this.err_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TErrorCode terrorCode = this;
      // ISSUE: reference to a compiler-generated method
      terrorCode.\u003C\u003En__1();
      if (await terrorCode.OleDB.ExecuteAsync(terrorCode.UpdateExInsertQuery()))
        return true;
      terrorCode.message = " " + terrorCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + terrorCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) terrorCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) terrorCode.err_ID, (object) terrorCode.err_SiteID) + " 내용 : " + terrorCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(terrorCode.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "err_SiteID") && Convert.ToInt64(hashtable[(object) "err_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "err_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "err_ID") && Convert.ToInt32(hashtable[(object) "err_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "err_ID", hashtable[(object) "err_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "err_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "err_ViewCode") && hashtable[(object) "err_ViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "err_ViewCode", hashtable[(object) "err_ViewCode"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "err_ViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  err_ID,err_SiteID,err_ViewCode,err_Msg1,err_Msg2");
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
