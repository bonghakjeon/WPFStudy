// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup.TBookmarkGoodsGroup
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

namespace UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup
{
  public class TBookmarkGoodsGroup : UbModelBase<TBookmarkGoodsGroup>
  {
    private int _bgg_GroupID;
    private long _bgg_SiteID;
    private string _bgg_GroupName;
    private string _bgg_UseYn;
    private DateTime? _bgg_InDate;
    private int _bgg_InUser;
    private DateTime? _bgg_ModDate;
    private int _bgg_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.bgg_GroupID
    };

    public int bgg_GroupID
    {
      get => this._bgg_GroupID;
      set
      {
        this._bgg_GroupID = value;
        this.Changed(nameof (bgg_GroupID));
      }
    }

    public long bgg_SiteID
    {
      get => this._bgg_SiteID;
      set
      {
        this._bgg_SiteID = value;
        this.Changed(nameof (bgg_SiteID));
      }
    }

    public string bgg_GroupName
    {
      get => this._bgg_GroupName;
      set
      {
        this._bgg_GroupName = UbModelBase.LeftStr(value, 400).Replace("'", "´");
        this.Changed(nameof (bgg_GroupName));
      }
    }

    public string bgg_UseYn
    {
      get => this._bgg_UseYn;
      set
      {
        this._bgg_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (bgg_UseYn));
        this.Changed("bgg_IsUseYn");
        this.Changed("bgg_UseYnDesc");
      }
    }

    public bool bgg_IsUseYn => "Y".Equals(this.bgg_UseYn);

    public string bgg_UseYnDesc => !"Y".Equals(this.bgg_UseYn) ? "미사용" : "사용";

    public DateTime? bgg_InDate
    {
      get => this._bgg_InDate;
      set
      {
        this._bgg_InDate = value;
        this.Changed(nameof (bgg_InDate));
      }
    }

    public int bgg_InUser
    {
      get => this._bgg_InUser;
      set
      {
        this._bgg_InUser = value;
        this.Changed(nameof (bgg_InUser));
      }
    }

    public DateTime? bgg_ModDate
    {
      get => this._bgg_ModDate;
      set
      {
        this._bgg_ModDate = value;
        this.Changed(nameof (bgg_ModDate));
      }
    }

    public int bgg_ModUser
    {
      get => this._bgg_ModUser;
      set
      {
        this._bgg_ModUser = value;
        this.Changed(nameof (bgg_ModUser));
      }
    }

    public TBookmarkGoodsGroup() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("bgg_GroupID", new TTableColumn()
      {
        tc_orgin_name = "bgg_GroupID",
        tc_trans_name = "관심상품그룹"
      });
      columnInfo.Add("bgg_SiteID", new TTableColumn()
      {
        tc_orgin_name = "bgg_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("bgg_GroupName", new TTableColumn()
      {
        tc_orgin_name = "bgg_GroupName",
        tc_trans_name = "관심상품그룹명"
      });
      columnInfo.Add("bgg_UseYn", new TTableColumn()
      {
        tc_orgin_name = "bgg_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("bgg_InDate", new TTableColumn()
      {
        tc_orgin_name = "bgg_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("bgg_InUser", new TTableColumn()
      {
        tc_orgin_name = "bgg_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("bgg_ModDate", new TTableColumn()
      {
        tc_orgin_name = "bgg_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("bgg_ModUser", new TTableColumn()
      {
        tc_orgin_name = "bgg_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.BookmarkGoodsGroup;
      this.bgg_GroupID = 0;
      this.bgg_SiteID = 0L;
      this.bgg_GroupName = string.Empty;
      this.bgg_UseYn = "Y";
      this.bgg_InDate = new DateTime?();
      this.bgg_InUser = 0;
      this.bgg_ModDate = new DateTime?();
      this.bgg_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TBookmarkGoodsGroup();

    public override object Clone()
    {
      TBookmarkGoodsGroup tbookmarkGoodsGroup = base.Clone() as TBookmarkGoodsGroup;
      tbookmarkGoodsGroup.bgg_GroupID = this.bgg_GroupID;
      tbookmarkGoodsGroup.bgg_SiteID = this.bgg_SiteID;
      tbookmarkGoodsGroup.bgg_GroupName = this.bgg_GroupName;
      tbookmarkGoodsGroup.bgg_UseYn = this.bgg_UseYn;
      tbookmarkGoodsGroup.bgg_InDate = this.bgg_InDate;
      tbookmarkGoodsGroup.bgg_ModDate = this.bgg_ModDate;
      tbookmarkGoodsGroup.bgg_InUser = this.bgg_InUser;
      tbookmarkGoodsGroup.bgg_ModUser = this.bgg_ModUser;
      return (object) tbookmarkGoodsGroup;
    }

    public void PutData(TBookmarkGoodsGroup pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.bgg_GroupID = pSource.bgg_GroupID;
      this.bgg_SiteID = pSource.bgg_SiteID;
      this.bgg_GroupName = pSource.bgg_GroupName;
      this.bgg_UseYn = pSource.bgg_UseYn;
      this.bgg_InDate = pSource.bgg_InDate;
      this.bgg_ModDate = pSource.bgg_ModDate;
      this.bgg_InUser = pSource.bgg_InUser;
      this.bgg_ModUser = pSource.bgg_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.bgg_GroupID = p_rs.GetFieldInt("bgg_GroupID");
        if (this.bgg_GroupID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.bgg_SiteID = p_rs.GetFieldLong("bgg_SiteID");
        this.bgg_GroupName = p_rs.GetFieldString("bgg_GroupName");
        this.bgg_UseYn = p_rs.GetFieldString("bgg_UseYn");
        this.bgg_InDate = p_rs.GetFieldDateTime("bgg_InDate");
        this.bgg_InUser = p_rs.GetFieldInt("bgg_InUser");
        this.bgg_ModDate = p_rs.GetFieldDateTime("bgg_ModDate");
        this.bgg_ModUser = p_rs.GetFieldInt("bgg_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " bgg_GroupID,bgg_SiteID,bgg_GroupName,bgg_UseYn,bgg_InDate,bgg_InUser,bgg_ModDate,bgg_ModUser) VALUES ( " + string.Format(" {0}", (object) this.bgg_GroupID) + string.Format(",{0}", (object) this.bgg_SiteID) + ",'" + this.bgg_GroupName + "','" + this.bgg_UseYn + "'" + string.Format(",{0},{1}", (object) this.bgg_InDate.GetDateToStrInNull(), (object) this.bgg_InUser) + string.Format(",{0},{1}", (object) this.bgg_ModDate.GetDateToStrInNull(), (object) this.bgg_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.bgg_GroupID, (object) this.bgg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TBookmarkGoodsGroup tbookmarkGoodsGroup = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsGroup.\u003C\u003En__0();
      if (await tbookmarkGoodsGroup.OleDB.ExecuteAsync(tbookmarkGoodsGroup.InsertQuery()))
        return true;
      tbookmarkGoodsGroup.message = " " + tbookmarkGoodsGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbookmarkGoodsGroup.bgg_GroupID, (object) tbookmarkGoodsGroup.bgg_SiteID) + " 내용 : " + tbookmarkGoodsGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsGroup.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " bgg_GroupName='" + this.bgg_GroupName + "',bgg_UseYn='" + this.bgg_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "bgg_ModDate", (object) this.bgg_ModDate.GetDateToStrInNull(), (object) "bgg_ModUser", (object) this.bgg_ModUser) + string.Format(" WHERE {0}={1}", (object) "bgg_GroupID", (object) this.bgg_GroupID) + string.Format(" AND {0}={1}", (object) "bgg_SiteID", (object) this.bgg_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.bgg_GroupID, (object) this.bgg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TBookmarkGoodsGroup tbookmarkGoodsGroup = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsGroup.\u003C\u003En__1();
      if (await tbookmarkGoodsGroup.OleDB.ExecuteAsync(tbookmarkGoodsGroup.UpdateQuery()))
        return true;
      tbookmarkGoodsGroup.message = " " + tbookmarkGoodsGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbookmarkGoodsGroup.bgg_GroupID, (object) tbookmarkGoodsGroup.bgg_SiteID) + " 내용 : " + tbookmarkGoodsGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsGroup.message);
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
      stringBuilder.Append(" bgg_GroupName='" + this.bgg_GroupName + "',bgg_UseYn='" + this.bgg_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "bgg_ModDate", (object) this.bgg_ModDate.GetDateToStrInNull(), (object) "bgg_ModUser", (object) this.bgg_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.bgg_GroupID, (object) this.bgg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TBookmarkGoodsGroup tbookmarkGoodsGroup = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsGroup.\u003C\u003En__1();
      if (await tbookmarkGoodsGroup.OleDB.ExecuteAsync(tbookmarkGoodsGroup.UpdateExInsertQuery()))
        return true;
      tbookmarkGoodsGroup.message = " " + tbookmarkGoodsGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbookmarkGoodsGroup.bgg_GroupID, (object) tbookmarkGoodsGroup.bgg_SiteID) + " 내용 : " + tbookmarkGoodsGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsGroup.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "bgg_GroupID", (object) this.bgg_GroupID) + string.Format(" AND {0}={1}", (object) "bgg_SiteID", (object) this.bgg_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.bgg_GroupID, (object) this.bgg_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TBookmarkGoodsGroup tbookmarkGoodsGroup = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsGroup.\u003C\u003En__0();
      if (await tbookmarkGoodsGroup.OleDB.ExecuteAsync(tbookmarkGoodsGroup.DeleteQuery()))
        return true;
      tbookmarkGoodsGroup.message = " " + tbookmarkGoodsGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbookmarkGoodsGroup.bgg_GroupID, (object) tbookmarkGoodsGroup.bgg_SiteID) + " 내용 : " + tbookmarkGoodsGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsGroup.message);
      return false;
    }

    public virtual string DeleteQuery(int p_bgg_GroupID, long p_bgg_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "bgg_GroupID", (object) p_bgg_GroupID));
      if (p_bgg_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgg_SiteID", (object) p_bgg_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "bgg_SiteID") && Convert.ToInt64(hashtable[(object) "bgg_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "bgg_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgg_GroupID", hashtable[(object) "bgg_GroupID"]));
        else
          stringBuilder.Append(" AND bgg_GroupID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgg_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "bgg_GroupName") && hashtable[(object) "bgg_GroupName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "bgg_GroupName", hashtable[(object) "bgg_GroupName"]));
        if (hashtable.ContainsKey((object) "bgg_UseYn") && hashtable[(object) "bgg_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "bgg_UseYn", hashtable[(object) "bgg_UseYn"]));
        if (hashtable.ContainsKey((object) "bgg_InUser") && Convert.ToInt32(hashtable[(object) "bgg_InUser"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgg_InUser", hashtable[(object) "bgg_InUser"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "bgg_GroupName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  bgg_GroupID,bgg_SiteID,bgg_GroupName,bgg_UseYn,bgg_InDate,bgg_InUser,bgg_ModDate,bgg_ModUser");
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
