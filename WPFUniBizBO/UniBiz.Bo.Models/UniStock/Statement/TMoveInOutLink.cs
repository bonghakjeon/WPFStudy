// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.TMoveInOutLink
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

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class TMoveInOutLink : UbModelBase<TMoveInOutLink>
  {
    private long _mio_OuterStatementNo;
    private long _mio_InnerStatementNo;
    private long _mio_SiteID;

    public override object _Key => (object) new object[2]
    {
      (object) this.mio_OuterStatementNo,
      (object) this.mio_InnerStatementNo
    };

    public long mio_OuterStatementNo
    {
      get => this._mio_OuterStatementNo;
      set
      {
        this._mio_OuterStatementNo = value;
        this.Changed(nameof (mio_OuterStatementNo));
      }
    }

    public long mio_InnerStatementNo
    {
      get => this._mio_InnerStatementNo;
      set
      {
        this._mio_InnerStatementNo = value;
        this.Changed(nameof (mio_InnerStatementNo));
      }
    }

    public long mio_SiteID
    {
      get => this._mio_SiteID;
      set
      {
        this._mio_SiteID = value;
        this.Changed(nameof (mio_SiteID));
      }
    }

    public TMoveInOutLink() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MoveInOutLink;
      this.mio_OuterStatementNo = this.mio_InnerStatementNo = 0L;
      this.mio_SiteID = 0L;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMoveInOutLink();

    public override object Clone()
    {
      TMoveInOutLink tmoveInOutLink = base.Clone() as TMoveInOutLink;
      tmoveInOutLink.mio_OuterStatementNo = this.mio_OuterStatementNo;
      tmoveInOutLink.mio_InnerStatementNo = this.mio_InnerStatementNo;
      tmoveInOutLink.mio_SiteID = this.mio_SiteID;
      return (object) tmoveInOutLink;
    }

    public void PutData(TMoveInOutLink pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mio_OuterStatementNo = pSource.mio_OuterStatementNo;
      this.mio_InnerStatementNo = pSource.mio_InnerStatementNo;
      this.mio_SiteID = pSource.mio_SiteID;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mio_OuterStatementNo = p_rs.GetFieldLong("mio_OuterStatementNo");
        if (this.mio_OuterStatementNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mio_InnerStatementNo = p_rs.GetFieldLong("mio_InnerStatementNo");
        this.mio_SiteID = p_rs.GetFieldLong("mio_SiteID");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " mio_OuterStatementNo,mio_InnerStatementNo,mio_SiteID) VALUES ( " + string.Format(" {0},{1}", (object) this.mio_OuterStatementNo, (object) this.mio_InnerStatementNo) + string.Format(",{0}", (object) this.mio_SiteID) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mio_OuterStatementNo, (object) this.mio_InnerStatementNo, (object) this.mio_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMoveInOutLink tmoveInOutLink = this;
      // ISSUE: reference to a compiler-generated method
      tmoveInOutLink.\u003C\u003En__0();
      if (await tmoveInOutLink.OleDB.ExecuteAsync(tmoveInOutLink.InsertQuery()))
        return true;
      tmoveInOutLink.message = " " + tmoveInOutLink.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmoveInOutLink.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmoveInOutLink.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmoveInOutLink.mio_OuterStatementNo, (object) tmoveInOutLink.mio_InnerStatementNo, (object) tmoveInOutLink.mio_SiteID) + " 내용 : " + tmoveInOutLink.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmoveInOutLink.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mio_SiteID") && Convert.ToInt64(hashtable[(object) "mio_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mio_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mio_OuterStatementNo") && Convert.ToInt64(hashtable[(object) "mio_OuterStatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mio_OuterStatementNo", hashtable[(object) "mio_OuterStatementNo"]));
        if (hashtable.ContainsKey((object) "mio_InnerStatementNo") && Convert.ToInt64(hashtable[(object) "mio_InnerStatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mio_InnerStatementNo", hashtable[(object) "mio_InnerStatementNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mio_SiteID", (object) num));
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
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mio_OuterStatementNo,mio_InnerStatementNo,mio_SiteID");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
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
