// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth.TProgMenuPropAuth
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth
{
  public class TProgMenuPropAuth : UbModelBase<TProgMenuPropAuth>
  {
    private int _pmpA_MenuGroupID;
    private int _pmpA_PropCode;
    private long _pmpA_SiteID;

    public override object _Key => (object) new object[2]
    {
      (object) this.pmpA_MenuGroupID,
      (object) this.pmpA_PropCode
    };

    public int pmpA_MenuGroupID
    {
      get => this._pmpA_MenuGroupID;
      set
      {
        this._pmpA_MenuGroupID = value;
        this.Changed(nameof (pmpA_MenuGroupID));
      }
    }

    public int pmpA_PropCode
    {
      get => this._pmpA_PropCode;
      set
      {
        this._pmpA_PropCode = value;
        this.Changed(nameof (pmpA_PropCode));
      }
    }

    public long pmpA_SiteID
    {
      get => this._pmpA_SiteID;
      set
      {
        this._pmpA_SiteID = value;
        this.Changed(nameof (pmpA_SiteID));
      }
    }

    public TProgMenuPropAuth() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmpA_MenuGroupID", new TTableColumn()
      {
        tc_orgin_name = "pmpA_MenuGroupID",
        tc_trans_name = "화면권한ID"
      });
      columnInfo.Add("pmpA_PropCode", new TTableColumn()
      {
        tc_orgin_name = "pmpA_PropCode",
        tc_trans_name = "팝업 코드"
      });
      columnInfo.Add("pmpA_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmpA_SiteID",
        tc_trans_name = "싸이트"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgMenuPropAuth;
      this.pmpA_MenuGroupID = this.pmpA_PropCode = 0;
      this.pmpA_SiteID = 0L;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgMenuPropAuth();

    public override object Clone()
    {
      TProgMenuPropAuth tprogMenuPropAuth = base.Clone() as TProgMenuPropAuth;
      tprogMenuPropAuth.pmpA_MenuGroupID = this.pmpA_MenuGroupID;
      tprogMenuPropAuth.pmpA_PropCode = this.pmpA_PropCode;
      tprogMenuPropAuth.pmpA_SiteID = this.pmpA_SiteID;
      return (object) tprogMenuPropAuth;
    }

    public void PutData(TProgMenuPropAuth pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmpA_MenuGroupID = pSource.pmpA_MenuGroupID;
      this.pmpA_PropCode = pSource.pmpA_PropCode;
      this.pmpA_SiteID = pSource.pmpA_SiteID;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmpA_MenuGroupID = p_rs.GetFieldInt("pmpA_MenuGroupID");
        if (this.pmpA_MenuGroupID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmpA_PropCode = p_rs.GetFieldInt("pmpA_PropCode");
        this.pmpA_SiteID = p_rs.GetFieldLong("pmpA_SiteID");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pmpA_MenuGroupID,pmpA_PropCode,pmpA_SiteID) VALUES ( " + string.Format(" {0},{1}", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode) + string.Format(",{0}", (object) this.pmpA_SiteID) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode, (object) this.pmpA_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgMenuPropAuth tprogMenuPropAuth = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuPropAuth.\u003C\u003En__0();
      if (await tprogMenuPropAuth.OleDB.ExecuteAsync(tprogMenuPropAuth.InsertQuery()))
        return true;
      tprogMenuPropAuth.message = " " + tprogMenuPropAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuPropAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuPropAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogMenuPropAuth.pmpA_MenuGroupID, (object) tprogMenuPropAuth.pmpA_PropCode, (object) tprogMenuPropAuth.pmpA_SiteID) + " 내용 : " + tprogMenuPropAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuPropAuth.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pmpA_MenuGroupID", (object) this.pmpA_MenuGroupID) + string.Format(" AND {0}={1}", (object) "pmpA_PropCode", (object) this.pmpA_PropCode) + string.Format(" AND {0}={1}", (object) "pmpA_SiteID", (object) this.pmpA_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmpA_MenuGroupID, (object) this.pmpA_PropCode, (object) this.pmpA_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TProgMenuPropAuth tprogMenuPropAuth = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuPropAuth.\u003C\u003En__0();
      if (await tprogMenuPropAuth.OleDB.ExecuteAsync(tprogMenuPropAuth.DeleteQuery()))
        return true;
      tprogMenuPropAuth.message = " " + tprogMenuPropAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuPropAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuPropAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogMenuPropAuth.pmpA_MenuGroupID, (object) tprogMenuPropAuth.pmpA_PropCode, (object) tprogMenuPropAuth.pmpA_SiteID) + " 내용 : " + tprogMenuPropAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuPropAuth.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_pmpA_MenuGroupID,
      int p_pmpA_PropCode,
      long p_pmpA_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmpA_MenuGroupID", (object) p_pmpA_MenuGroupID));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmpA_PropCode", (object) p_pmpA_PropCode));
      if (p_pmpA_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmpA_SiteID", (object) p_pmpA_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmpA_SiteID") && Convert.ToInt64(hashtable[(object) "pmpA_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmpA_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmpA_MenuGroupID") && Convert.ToInt32(hashtable[(object) "pmpA_MenuGroupID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmpA_MenuGroupID", hashtable[(object) "pmpA_MenuGroupID"]));
        if (hashtable.ContainsKey((object) "pmpA_PropCode") && Convert.ToInt32(hashtable[(object) "pmpA_PropCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmpA_PropCode", hashtable[(object) "pmpA_PropCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmpA_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  pmpA_MenuGroupID,pmpA_PropCode,pmpA_SiteID");
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
