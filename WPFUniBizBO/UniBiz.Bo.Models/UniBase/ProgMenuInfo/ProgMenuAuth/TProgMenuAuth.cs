// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth.TProgMenuAuth
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth
{
  public class TProgMenuAuth : UbModelBase<TProgMenuAuth>
  {
    private int _pmA_MenuGroupID;
    private int _pmA_MenuCode;
    private long _pmA_SiteID;

    public override object _Key => (object) new object[2]
    {
      (object) this.pmA_MenuGroupID,
      (object) this.pmA_MenuCode
    };

    public int pmA_MenuGroupID
    {
      get => this._pmA_MenuGroupID;
      set
      {
        this._pmA_MenuGroupID = value;
        this.Changed(nameof (pmA_MenuGroupID));
      }
    }

    public int pmA_MenuCode
    {
      get => this._pmA_MenuCode;
      set
      {
        this._pmA_MenuCode = value;
        this.Changed(nameof (pmA_MenuCode));
      }
    }

    public long pmA_SiteID
    {
      get => this._pmA_SiteID;
      set
      {
        this._pmA_SiteID = value;
        this.Changed(nameof (pmA_SiteID));
      }
    }

    public TProgMenuAuth() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmA_MenuGroupID", new TTableColumn()
      {
        tc_orgin_name = "pmA_MenuGroupID",
        tc_trans_name = "화면권한ID"
      });
      columnInfo.Add("pmA_MenuCode", new TTableColumn()
      {
        tc_orgin_name = "pmA_MenuCode",
        tc_trans_name = "메뉴코드"
      });
      columnInfo.Add("pmA_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmA_SiteID",
        tc_trans_name = "싸이트"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgMenuAuth;
      this.pmA_MenuGroupID = this.pmA_MenuCode = 0;
      this.pmA_SiteID = 0L;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgMenuAuth();

    public override object Clone()
    {
      TProgMenuAuth tprogMenuAuth = base.Clone() as TProgMenuAuth;
      tprogMenuAuth.pmA_MenuGroupID = this.pmA_MenuGroupID;
      tprogMenuAuth.pmA_MenuCode = this.pmA_MenuCode;
      tprogMenuAuth.pmA_SiteID = this.pmA_SiteID;
      return (object) tprogMenuAuth;
    }

    public void PutData(TProgMenuAuth pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmA_MenuGroupID = pSource.pmA_MenuGroupID;
      this.pmA_MenuCode = pSource.pmA_MenuCode;
      this.pmA_SiteID = pSource.pmA_SiteID;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmA_MenuGroupID = p_rs.GetFieldInt("pmA_MenuGroupID");
        if (this.pmA_MenuGroupID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmA_MenuCode = p_rs.GetFieldInt("pmA_MenuCode");
        this.pmA_SiteID = p_rs.GetFieldLong("pmA_SiteID");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pmA_MenuGroupID,pmA_MenuCode,pmA_SiteID) VALUES ( " + string.Format(" {0},{1}", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode) + string.Format(",{0}", (object) this.pmA_SiteID) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode, (object) this.pmA_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgMenuAuth tprogMenuAuth = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuAuth.\u003C\u003En__0();
      if (await tprogMenuAuth.OleDB.ExecuteAsync(tprogMenuAuth.InsertQuery()))
        return true;
      tprogMenuAuth.message = " " + tprogMenuAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogMenuAuth.pmA_MenuGroupID, (object) tprogMenuAuth.pmA_MenuCode, (object) tprogMenuAuth.pmA_SiteID) + " 내용 : " + tprogMenuAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuAuth.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pmA_MenuGroupID", (object) this.pmA_MenuGroupID) + string.Format(" AND {0}={1}", (object) "pmA_MenuCode", (object) this.pmA_MenuCode) + string.Format(" AND {0}={1}", (object) "pmA_SiteID", (object) this.pmA_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmA_MenuGroupID, (object) this.pmA_MenuCode, (object) this.pmA_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TProgMenuAuth tprogMenuAuth = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuAuth.\u003C\u003En__0();
      if (await tprogMenuAuth.OleDB.ExecuteAsync(tprogMenuAuth.DeleteQuery()))
        return true;
      tprogMenuAuth.message = " " + tprogMenuAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogMenuAuth.pmA_MenuGroupID, (object) tprogMenuAuth.pmA_MenuCode, (object) tprogMenuAuth.pmA_SiteID) + " 내용 : " + tprogMenuAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuAuth.message);
      return false;
    }

    public virtual string DeleteQuery(int p_pmA_MenuGroupID, int p_pmA_MenuCode, long p_pmA_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmA_MenuGroupID", (object) p_pmA_MenuGroupID));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmA_MenuCode", (object) p_pmA_MenuCode));
      if (p_pmA_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmA_SiteID", (object) p_pmA_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmA_SiteID") && Convert.ToInt64(hashtable[(object) "pmA_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmA_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmA_MenuGroupID") && Convert.ToInt32(hashtable[(object) "pmA_MenuGroupID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmA_MenuGroupID", hashtable[(object) "pmA_MenuGroupID"]));
        if (hashtable.ContainsKey((object) "pmA_MenuCode") && Convert.ToInt32(hashtable[(object) "pmA_MenuCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmA_MenuCode", hashtable[(object) "pmA_MenuCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmA_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  pmA_MenuGroupID,pmA_MenuCode,pmA_SiteID");
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
