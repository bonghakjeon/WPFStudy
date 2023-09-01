// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList.TBookmarkGoodsList
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

namespace UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList
{
  public class TBookmarkGoodsList : UbModelBase<TBookmarkGoodsList>
  {
    private int _bgl_GroupID;
    private long _bgl_GoodsCode;
    private long _bgl_SiteID;
    private string _bgl_UseYn;
    private DateTime? _bgl_InDate;
    private int _bgl_InUser;
    private DateTime? _bgl_ModDate;
    private int _bgl_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.bgl_GroupID,
      (object) this.bgl_GoodsCode
    };

    public int bgl_GroupID
    {
      get => this._bgl_GroupID;
      set
      {
        this._bgl_GroupID = value;
        this.Changed(nameof (bgl_GroupID));
      }
    }

    public long bgl_GoodsCode
    {
      get => this._bgl_GoodsCode;
      set
      {
        this._bgl_GoodsCode = value;
        this.Changed(nameof (bgl_GoodsCode));
      }
    }

    public long bgl_SiteID
    {
      get => this._bgl_SiteID;
      set
      {
        this._bgl_SiteID = value;
        this.Changed(nameof (bgl_SiteID));
      }
    }

    public string bgl_UseYn
    {
      get => this._bgl_UseYn;
      set
      {
        this._bgl_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (bgl_UseYn));
        this.Changed("bgl_IsUseYn");
        this.Changed("bgl_UseYnDesc");
      }
    }

    public bool bgl_IsUseYn => "Y".Equals(this.bgl_UseYn);

    public string bgl_UseYnDesc => !"Y".Equals(this.bgl_UseYn) ? "미사용" : "사용";

    public DateTime? bgl_InDate
    {
      get => this._bgl_InDate;
      set
      {
        this._bgl_InDate = value;
        this.Changed(nameof (bgl_InDate));
      }
    }

    public int bgl_InUser
    {
      get => this._bgl_InUser;
      set
      {
        this._bgl_InUser = value;
        this.Changed(nameof (bgl_InUser));
      }
    }

    public DateTime? bgl_ModDate
    {
      get => this._bgl_ModDate;
      set
      {
        this._bgl_ModDate = value;
        this.Changed(nameof (bgl_ModDate));
      }
    }

    public int bgl_ModUser
    {
      get => this._bgl_ModUser;
      set
      {
        this._bgl_ModUser = value;
        this.Changed(nameof (bgl_ModUser));
      }
    }

    public TBookmarkGoodsList() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("bgl_GroupID", new TTableColumn()
      {
        tc_orgin_name = "bgl_GroupID",
        tc_trans_name = "관심상품그룹"
      });
      columnInfo.Add("bgl_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "bgl_GoodsCode",
        tc_trans_name = "관심상품코드"
      });
      columnInfo.Add("bgl_SiteID", new TTableColumn()
      {
        tc_orgin_name = "bgl_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("bgl_UseYn", new TTableColumn()
      {
        tc_orgin_name = "bgl_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("bgl_InDate", new TTableColumn()
      {
        tc_orgin_name = "bgl_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("bgl_InUser", new TTableColumn()
      {
        tc_orgin_name = "bgl_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("bgl_ModDate", new TTableColumn()
      {
        tc_orgin_name = "bgl_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("bgl_ModUser", new TTableColumn()
      {
        tc_orgin_name = "bgl_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.BookmarkGoodsList;
      this.bgl_GroupID = 0;
      this.bgl_GoodsCode = 0L;
      this.bgl_SiteID = 0L;
      this.bgl_UseYn = "Y";
      this.bgl_InDate = new DateTime?();
      this.bgl_InUser = 0;
      this.bgl_ModDate = new DateTime?();
      this.bgl_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TBookmarkGoodsList();

    public override object Clone()
    {
      TBookmarkGoodsList tbookmarkGoodsList = base.Clone() as TBookmarkGoodsList;
      tbookmarkGoodsList.bgl_GroupID = this.bgl_GroupID;
      tbookmarkGoodsList.bgl_GoodsCode = this.bgl_GoodsCode;
      tbookmarkGoodsList.bgl_SiteID = this.bgl_SiteID;
      tbookmarkGoodsList.bgl_UseYn = this.bgl_UseYn;
      tbookmarkGoodsList.bgl_InDate = this.bgl_InDate;
      tbookmarkGoodsList.bgl_ModDate = this.bgl_ModDate;
      tbookmarkGoodsList.bgl_InUser = this.bgl_InUser;
      tbookmarkGoodsList.bgl_ModUser = this.bgl_ModUser;
      return (object) tbookmarkGoodsList;
    }

    public void PutData(TBookmarkGoodsList pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.bgl_GroupID = pSource.bgl_GroupID;
      this.bgl_GoodsCode = pSource.bgl_GoodsCode;
      this.bgl_SiteID = pSource.bgl_SiteID;
      this.bgl_UseYn = pSource.bgl_UseYn;
      this.bgl_InDate = pSource.bgl_InDate;
      this.bgl_ModDate = pSource.bgl_ModDate;
      this.bgl_InUser = pSource.bgl_InUser;
      this.bgl_ModUser = pSource.bgl_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.bgl_GroupID = p_rs.GetFieldInt("bgl_GroupID");
        if (this.bgl_GroupID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.bgl_GoodsCode = p_rs.GetFieldLong("bgl_GoodsCode");
        this.bgl_SiteID = p_rs.GetFieldLong("bgl_SiteID");
        this.bgl_UseYn = p_rs.GetFieldString("bgl_UseYn");
        this.bgl_InDate = p_rs.GetFieldDateTime("bgl_InDate");
        this.bgl_InUser = p_rs.GetFieldInt("bgl_InUser");
        this.bgl_ModDate = p_rs.GetFieldDateTime("bgl_ModDate");
        this.bgl_ModUser = p_rs.GetFieldInt("bgl_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " bgl_GroupID,bgl_GoodsCode,bgl_SiteID,bgl_UseYn,bgl_InDate,bgl_InUser,bgl_ModDate,bgl_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.bgl_GroupID, (object) this.bgl_GoodsCode) + string.Format(",{0}", (object) this.bgl_SiteID) + ",'" + this.bgl_UseYn + "'" + string.Format(",{0},{1}", (object) this.bgl_InDate.GetDateToStrInNull(), (object) this.bgl_InUser) + string.Format(",{0},{1}", (object) this.bgl_ModDate.GetDateToStrInNull(), (object) this.bgl_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.bgl_GroupID, (object) this.bgl_GoodsCode, (object) this.bgl_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TBookmarkGoodsList tbookmarkGoodsList = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsList.\u003C\u003En__0();
      if (await tbookmarkGoodsList.OleDB.ExecuteAsync(tbookmarkGoodsList.InsertQuery()))
        return true;
      tbookmarkGoodsList.message = " " + tbookmarkGoodsList.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsList.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsList.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tbookmarkGoodsList.bgl_GroupID, (object) tbookmarkGoodsList.bgl_GoodsCode, (object) tbookmarkGoodsList.bgl_SiteID) + " 내용 : " + tbookmarkGoodsList.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsList.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " bgl_UseYn='" + this.bgl_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "bgl_ModDate", (object) this.bgl_ModDate.GetDateToStrInNull(), (object) "bgl_ModUser", (object) this.bgl_ModUser) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) this.bgl_GroupID) + string.Format(" AND {0}={1}", (object) "bgl_GoodsCode", (object) this.bgl_GoodsCode) + string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) this.bgl_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.bgl_GroupID, (object) this.bgl_GoodsCode, (object) this.bgl_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TBookmarkGoodsList tbookmarkGoodsList = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsList.\u003C\u003En__1();
      if (await tbookmarkGoodsList.OleDB.ExecuteAsync(tbookmarkGoodsList.UpdateQuery()))
        return true;
      tbookmarkGoodsList.message = " " + tbookmarkGoodsList.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsList.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsList.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tbookmarkGoodsList.bgl_GroupID, (object) tbookmarkGoodsList.bgl_GoodsCode, (object) tbookmarkGoodsList.bgl_SiteID) + " 내용 : " + tbookmarkGoodsList.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsList.message);
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
      stringBuilder.Append(" bgl_UseYn='" + this.bgl_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "bgl_ModDate", (object) this.bgl_ModDate.GetDateToStrInNull(), (object) "bgl_ModUser", (object) this.bgl_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.bgl_GroupID, (object) this.bgl_GoodsCode, (object) this.bgl_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TBookmarkGoodsList tbookmarkGoodsList = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsList.\u003C\u003En__1();
      if (await tbookmarkGoodsList.OleDB.ExecuteAsync(tbookmarkGoodsList.UpdateExInsertQuery()))
        return true;
      tbookmarkGoodsList.message = " " + tbookmarkGoodsList.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsList.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsList.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tbookmarkGoodsList.bgl_GroupID, (object) tbookmarkGoodsList.bgl_GoodsCode, (object) tbookmarkGoodsList.bgl_SiteID) + " 내용 : " + tbookmarkGoodsList.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsList.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) this.bgl_GroupID) + string.Format(" AND {0}={1}", (object) "bgl_GoodsCode", (object) this.bgl_GoodsCode) + string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) this.bgl_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.bgl_GroupID, (object) this.bgl_GoodsCode, (object) this.bgl_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TBookmarkGoodsList tbookmarkGoodsList = this;
      // ISSUE: reference to a compiler-generated method
      tbookmarkGoodsList.\u003C\u003En__0();
      if (await tbookmarkGoodsList.OleDB.ExecuteAsync(tbookmarkGoodsList.DeleteQuery()))
        return true;
      tbookmarkGoodsList.message = " " + tbookmarkGoodsList.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbookmarkGoodsList.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbookmarkGoodsList.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tbookmarkGoodsList.bgl_GroupID, (object) tbookmarkGoodsList.bgl_GoodsCode, (object) tbookmarkGoodsList.bgl_SiteID) + " 내용 : " + tbookmarkGoodsList.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbookmarkGoodsList.message);
      return false;
    }

    public virtual string DeleteQuery(int p_bgl_GroupID, long p_bgl_GoodsCode, long p_bgl_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) p_bgl_GroupID));
      if (p_bgl_GoodsCode > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_GoodsCode", (object) p_bgl_GoodsCode));
      if (p_bgl_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) p_bgl_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "bgl_SiteID") && Convert.ToInt64(hashtable[(object) "bgl_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "bgl_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "bgl_GroupID") && Convert.ToInt32(hashtable[(object) "bgl_GroupID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_GroupID", hashtable[(object) "bgl_GroupID"]));
        if (hashtable.ContainsKey((object) "bgl_GoodsCode") && Convert.ToInt64(hashtable[(object) "bgl_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_GoodsCode", hashtable[(object) "bgl_GoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "bgl_UseYn") && hashtable[(object) "bgl_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "bgl_UseYn", hashtable[(object) "bgl_UseYn"]));
        if (hashtable.ContainsKey((object) "bgl_InUser") && Convert.ToInt32(hashtable[(object) "bgl_InUser"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_InUser", hashtable[(object) "bgl_InUser"]));
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
        stringBuilder.Append(" SELECT  bgl_GroupID,bgl_GoodsCode,bgl_SiteID,bgl_UseYn,bgl_InDate,bgl_InUser,bgl_ModDate,bgl_ModUser");
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
