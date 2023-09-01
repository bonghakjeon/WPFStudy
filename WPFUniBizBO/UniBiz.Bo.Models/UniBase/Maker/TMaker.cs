// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Maker.TMaker
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

namespace UniBiz.Bo.Models.UniBase.Maker
{
  public class TMaker : UbModelBase<TMaker>
  {
    private int _mk_MakerCode;
    private long _mk_SiteID;
    private string _mk_MakerName;
    private string _mk_MakerFullName;
    private string _mk_UseYn;
    private string _mk_Memo;
    private DateTime? _mk_InDate;
    private int _mk_InUser;
    private DateTime? _mk_ModDate;
    private int _mk_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mk_MakerCode
    };

    public int mk_MakerCode
    {
      get => this._mk_MakerCode;
      set
      {
        this._mk_MakerCode = value;
        this.Changed(nameof (mk_MakerCode));
      }
    }

    public long mk_SiteID
    {
      get => this._mk_SiteID;
      set
      {
        this._mk_SiteID = value;
        this.Changed(nameof (mk_SiteID));
      }
    }

    public string mk_MakerName
    {
      get => this._mk_MakerName;
      set
      {
        this._mk_MakerName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mk_MakerName));
      }
    }

    public string mk_MakerFullName
    {
      get => this._mk_MakerFullName;
      set
      {
        this._mk_MakerFullName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mk_MakerFullName));
      }
    }

    public string mk_UseYn
    {
      get => this._mk_UseYn;
      set
      {
        this._mk_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mk_UseYn));
        this.Changed("mk_IsUseYn");
        this.Changed("mk_UseYnDesc");
      }
    }

    public bool mk_IsUseYn => "Y".Equals(this.mk_UseYn);

    public string mk_UseYnDesc => !"Y".Equals(this.mk_UseYn) ? "미사용" : "사용";

    public string mk_Memo
    {
      get => this._mk_Memo;
      set
      {
        this._mk_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mk_Memo));
        this.Changed("mk_MemoEnterSkip");
      }
    }

    public string mk_MemoEnterSkip => this.mk_Memo.Replace("\r\n", "↵").Replace("\n", "↵");

    public DateTime? mk_InDate
    {
      get => this._mk_InDate;
      set
      {
        this._mk_InDate = value;
        this.Changed(nameof (mk_InDate));
        this.Changed("ModDate");
      }
    }

    public int mk_InUser
    {
      get => this._mk_InUser;
      set
      {
        this._mk_InUser = value;
        this.Changed(nameof (mk_InUser));
      }
    }

    public DateTime? mk_ModDate
    {
      get => this._mk_ModDate;
      set
      {
        this._mk_ModDate = value;
        this.Changed(nameof (mk_ModDate));
        this.Changed("ModDate");
      }
    }

    public int mk_ModUser
    {
      get => this._mk_ModUser;
      set
      {
        this._mk_ModUser = value;
        this.Changed(nameof (mk_ModUser));
      }
    }

    public override DateTime? ModDate => !this.mk_ModDate.HasValue ? this.mk_InDate : this.mk_ModDate;

    public TMaker() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mk_MakerCode", new TTableColumn()
      {
        tc_orgin_name = "mk_MakerCode",
        tc_trans_name = "제조사코드"
      });
      columnInfo.Add("mk_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mk_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mk_MakerName", new TTableColumn()
      {
        tc_orgin_name = "mk_MakerName",
        tc_trans_name = "제조사명"
      });
      columnInfo.Add("mk_MakerFullName", new TTableColumn()
      {
        tc_orgin_name = "mk_MakerFullName",
        tc_trans_name = "제조사명(전체)"
      });
      columnInfo.Add("mk_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mk_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("mk_Memo", new TTableColumn()
      {
        tc_orgin_name = "mk_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("mk_InDate", new TTableColumn()
      {
        tc_orgin_name = "mk_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mk_InUser", new TTableColumn()
      {
        tc_orgin_name = "mk_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mk_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mk_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mk_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mk_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Maker;
      this.mk_MakerCode = 0;
      this.mk_SiteID = 0L;
      this.mk_MakerName = string.Empty;
      this.mk_MakerFullName = string.Empty;
      this.mk_UseYn = "Y";
      this.mk_Memo = string.Empty;
      this.mk_InDate = new DateTime?();
      this.mk_InUser = 0;
      this.mk_ModDate = new DateTime?();
      this.mk_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMaker();

    public override object Clone()
    {
      TMaker tmaker = base.Clone() as TMaker;
      tmaker.mk_MakerCode = this.mk_MakerCode;
      tmaker.mk_SiteID = this.mk_SiteID;
      tmaker.mk_MakerName = this.mk_MakerName;
      tmaker.mk_MakerFullName = this.mk_MakerFullName;
      tmaker.mk_UseYn = this.mk_UseYn;
      tmaker.mk_Memo = this.mk_Memo;
      tmaker.mk_InDate = this.mk_InDate;
      tmaker.mk_ModDate = this.mk_ModDate;
      tmaker.mk_InUser = this.mk_InUser;
      tmaker.mk_ModUser = this.mk_ModUser;
      return (object) tmaker;
    }

    public void PutData(TMaker pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mk_MakerCode = pSource.mk_MakerCode;
      this.mk_SiteID = pSource.mk_SiteID;
      this.mk_MakerName = pSource.mk_MakerName;
      this.mk_MakerFullName = pSource.mk_MakerFullName;
      this.mk_UseYn = pSource.mk_UseYn;
      this.mk_Memo = pSource.mk_Memo;
      this.mk_InDate = pSource.mk_InDate;
      this.mk_ModDate = pSource.mk_ModDate;
      this.mk_InUser = pSource.mk_InUser;
      this.mk_ModUser = pSource.mk_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mk_MakerCode = p_rs.GetFieldInt("mk_MakerCode");
        if (this.mk_MakerCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mk_SiteID = p_rs.GetFieldLong("mk_SiteID");
        this.mk_MakerName = p_rs.GetFieldString("mk_MakerName");
        this.mk_MakerFullName = p_rs.GetFieldString("mk_MakerFullName");
        this.mk_UseYn = p_rs.GetFieldString("mk_UseYn");
        this.mk_Memo = p_rs.GetFieldString("mk_Memo");
        this.mk_InDate = p_rs.GetFieldDateTime("mk_InDate");
        this.mk_InUser = p_rs.GetFieldInt("mk_InUser");
        this.mk_ModDate = p_rs.GetFieldDateTime("mk_ModDate");
        this.mk_ModUser = p_rs.GetFieldInt("mk_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " mk_MakerCode,mk_SiteID,mk_MakerName,mk_MakerFullName,mk_UseYn,mk_Memo,mk_InDate,mk_InUser,mk_ModDate,mk_ModUser) VALUES ( " + string.Format(" {0}", (object) this.mk_MakerCode) + string.Format(",{0}", (object) this.mk_SiteID) + ",'" + this.mk_MakerName + "','" + this.mk_MakerFullName + "','" + this.mk_UseYn + "','" + this.mk_Memo + "'" + string.Format(",{0},{1}", (object) this.mk_InDate.GetDateToStrInNull(), (object) this.mk_InUser) + string.Format(",{0},{1}", (object) this.mk_ModDate.GetDateToStrInNull(), (object) this.mk_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mk_MakerCode, (object) this.mk_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMaker tmaker = this;
      // ISSUE: reference to a compiler-generated method
      tmaker.\u003C\u003En__0();
      if (await tmaker.OleDB.ExecuteAsync(tmaker.InsertQuery()))
        return true;
      tmaker.message = " " + tmaker.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmaker.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmaker.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmaker.mk_MakerCode, (object) tmaker.mk_SiteID) + " 내용 : " + tmaker.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmaker.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " mk_MakerName='" + this.mk_MakerName + "',mk_MakerFullName='" + this.mk_MakerFullName + "',mk_UseYn='" + this.mk_UseYn + "',mk_Memo='" + this.mk_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "mk_ModDate", (object) this.mk_ModDate.GetDateToStrInNull(), (object) "mk_ModUser", (object) this.mk_ModUser) + string.Format(" WHERE {0}={1}", (object) "mk_MakerCode", (object) this.mk_MakerCode) + string.Format(" AND {0}={1}", (object) "mk_SiteID", (object) this.mk_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mk_MakerCode, (object) this.mk_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMaker tmaker = this;
      // ISSUE: reference to a compiler-generated method
      tmaker.\u003C\u003En__1();
      if (await tmaker.OleDB.ExecuteAsync(tmaker.UpdateQuery()))
        return true;
      tmaker.message = " " + tmaker.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmaker.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmaker.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmaker.mk_MakerCode, (object) tmaker.mk_SiteID) + " 내용 : " + tmaker.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmaker.message);
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
      stringBuilder.Append(" mk_MakerName='" + this.mk_MakerName + "',mk_MakerFullName='" + this.mk_MakerFullName + "',mk_UseYn='" + this.mk_UseYn + "',mk_Memo='" + this.mk_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "mk_ModDate", (object) this.mk_ModDate.GetDateToStrInNull(), (object) "mk_ModUser", (object) this.mk_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mk_MakerCode, (object) this.mk_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMaker tmaker = this;
      // ISSUE: reference to a compiler-generated method
      tmaker.\u003C\u003En__1();
      if (await tmaker.OleDB.ExecuteAsync(tmaker.UpdateExInsertQuery()))
        return true;
      tmaker.message = " " + tmaker.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmaker.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmaker.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmaker.mk_MakerCode, (object) tmaker.mk_SiteID) + " 내용 : " + tmaker.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmaker.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mk_SiteID") && Convert.ToInt64(hashtable[(object) "mk_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mk_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mk_MakerCode") && Convert.ToInt32(hashtable[(object) "mk_MakerCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mk_MakerCode", hashtable[(object) "mk_MakerCode"]));
        else
          stringBuilder.Append(" AND mk_MakerCode>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mk_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mk_MakerName") && hashtable[(object) "mk_MakerName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mk_MakerName", hashtable[(object) "mk_MakerName"]));
        if (hashtable.ContainsKey((object) "mk_UseYn") && hashtable[(object) "mk_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mk_UseYn", hashtable[(object) "mk_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mk_MakerName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mk_MakerFullName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mk_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  mk_MakerCode,mk_SiteID,mk_MakerName,mk_MakerFullName,mk_UseYn,mk_Memo,mk_InDate,mk_InUser,mk_ModDate,mk_ModUser");
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
