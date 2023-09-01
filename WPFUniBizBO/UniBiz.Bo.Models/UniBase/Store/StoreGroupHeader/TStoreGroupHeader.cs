// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader.TStoreGroupHeader
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader
{
  public class TStoreGroupHeader : UbModelBase<TStoreGroupHeader>
  {
    private int _sgh_GroupCode;
    private long _sgh_SiteID;
    private int _sgh_GroupType;
    private string _sgh_GroupName;
    private string _sgh_Memo;
    private int _sgh_SortNo;
    private string _sgh_UseYn;
    private DateTime? _sgh_InDate;
    private int _sgh_InUser;
    private DateTime? _sgh_ModDate;
    private int _sgh_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.sgh_GroupCode
    };

    public int sgh_GroupCode
    {
      get => this._sgh_GroupCode;
      set
      {
        this._sgh_GroupCode = value;
        this.Changed(nameof (sgh_GroupCode));
      }
    }

    public long sgh_SiteID
    {
      get => this._sgh_SiteID;
      set
      {
        this._sgh_SiteID = value;
        this.Changed(nameof (sgh_SiteID));
      }
    }

    public int sgh_GroupType
    {
      get => this._sgh_GroupType;
      set
      {
        this._sgh_GroupType = value;
        this.Changed(nameof (sgh_GroupType));
        this.Changed("sgh_GroupTypeDesc");
      }
    }

    public string sgh_GroupTypeDesc => this.sgh_GroupType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.sgh_SiteID, EnumCommonCodeType.StoreGroupType, this.sgh_GroupType);

    public string sgh_GroupName
    {
      get => this._sgh_GroupName;
      set
      {
        this._sgh_GroupName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (sgh_GroupName));
      }
    }

    public string sgh_Memo
    {
      get => this._sgh_Memo;
      set
      {
        this._sgh_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (sgh_Memo));
      }
    }

    [JsonIgnore]
    public string sgh_MemoEnterSkip => this.sgh_Memo.Replace("\r\n", "↵").Replace("\n", "↵");

    public int sgh_SortNo
    {
      get => this._sgh_SortNo;
      set
      {
        this._sgh_SortNo = value;
        this.Changed(nameof (sgh_SortNo));
      }
    }

    public string sgh_UseYn
    {
      get => this._sgh_UseYn;
      set
      {
        this._sgh_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (sgh_UseYn));
        this.Changed("sgh_IsUseYn");
        this.Changed("sgh_UseYnDesc");
      }
    }

    public bool sgh_IsUseYn => "Y".Equals(this.sgh_UseYn);

    public string sgh_UseYnDesc => !"Y".Equals(this.sgh_UseYn) ? "미사용" : "사용";

    public DateTime? sgh_InDate
    {
      get => this._sgh_InDate;
      set
      {
        this._sgh_InDate = value;
        this.Changed(nameof (sgh_InDate));
      }
    }

    public int sgh_InUser
    {
      get => this._sgh_InUser;
      set
      {
        this._sgh_InUser = value;
        this.Changed(nameof (sgh_InUser));
      }
    }

    public DateTime? sgh_ModDate
    {
      get => this._sgh_ModDate;
      set
      {
        this._sgh_ModDate = value;
        this.Changed(nameof (sgh_ModDate));
      }
    }

    public int sgh_ModUser
    {
      get => this._sgh_ModUser;
      set
      {
        this._sgh_ModUser = value;
        this.Changed(nameof (sgh_ModUser));
      }
    }

    public TStoreGroupHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sgh_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupCode",
        tc_trans_name = "지점그룹 코드"
      });
      columnInfo.Add("sgh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sgh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sgh_GroupType", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupType",
        tc_trans_name = "타입",
        tc_comm_code = 31
      });
      columnInfo.Add("sgh_GroupName", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupName",
        tc_trans_name = "지점그룹명"
      });
      columnInfo.Add("sgh_Memo", new TTableColumn()
      {
        tc_orgin_name = "sgh_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("sgh_SortNo", new TTableColumn()
      {
        tc_orgin_name = "sgh_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("sgh_UseYn", new TTableColumn()
      {
        tc_orgin_name = "sgh_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("sgh_InDate", new TTableColumn()
      {
        tc_orgin_name = "sgh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("sgh_InUser", new TTableColumn()
      {
        tc_orgin_name = "sgh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("sgh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "sgh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("sgh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "sgh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.StoreGroupHeader;
      this.sgh_GroupCode = 0;
      this.sgh_SiteID = 0L;
      this.sgh_GroupType = 0;
      this.sgh_GroupName = string.Empty;
      this.sgh_Memo = string.Empty;
      this.sgh_SortNo = 0;
      this.sgh_UseYn = "Y";
      this.sgh_InDate = new DateTime?();
      this.sgh_ModDate = new DateTime?();
      this.sgh_InUser = this.sgh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TStoreGroupHeader();

    public override object Clone()
    {
      TStoreGroupHeader tstoreGroupHeader = base.Clone() as TStoreGroupHeader;
      tstoreGroupHeader.sgh_GroupCode = this.sgh_GroupCode;
      tstoreGroupHeader.sgh_SiteID = this.sgh_SiteID;
      tstoreGroupHeader.sgh_GroupType = this.sgh_GroupType;
      tstoreGroupHeader.sgh_GroupName = this.sgh_GroupName;
      tstoreGroupHeader.sgh_Memo = this.sgh_Memo;
      tstoreGroupHeader.sgh_SortNo = this.sgh_SortNo;
      tstoreGroupHeader.sgh_UseYn = this.sgh_UseYn;
      tstoreGroupHeader.sgh_InDate = this.sgh_InDate;
      tstoreGroupHeader.sgh_ModDate = this.sgh_ModDate;
      tstoreGroupHeader.sgh_InUser = this.sgh_InUser;
      tstoreGroupHeader.sgh_ModUser = this.sgh_ModUser;
      return (object) tstoreGroupHeader;
    }

    public void PutData(TStoreGroupHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sgh_GroupCode = pSource.sgh_GroupCode;
      this.sgh_SiteID = pSource.sgh_SiteID;
      this.sgh_GroupType = pSource.sgh_GroupType;
      this.sgh_GroupName = pSource.sgh_GroupName;
      this.sgh_Memo = pSource.sgh_Memo;
      this.sgh_SortNo = pSource.sgh_SortNo;
      this.sgh_UseYn = pSource.sgh_UseYn;
      this.sgh_InDate = pSource.sgh_InDate;
      this.sgh_ModDate = pSource.sgh_ModDate;
      this.sgh_InUser = pSource.sgh_InUser;
      this.sgh_ModUser = pSource.sgh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sgh_GroupCode = p_rs.GetFieldInt("sgh_GroupCode");
        if (this.sgh_GroupCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sgh_SiteID = p_rs.GetFieldLong("sgh_SiteID");
        this.sgh_GroupType = p_rs.GetFieldInt("sgh_GroupType");
        this.sgh_GroupName = p_rs.GetFieldString("sgh_GroupName");
        this.sgh_Memo = p_rs.GetFieldString("sgh_Memo");
        this.sgh_SortNo = p_rs.GetFieldInt("sgh_SortNo");
        this.sgh_UseYn = p_rs.GetFieldString("sgh_UseYn");
        this.sgh_InDate = p_rs.GetFieldDateTime("sgh_InDate");
        this.sgh_InUser = p_rs.GetFieldInt("sgh_InUser");
        this.sgh_ModDate = p_rs.GetFieldDateTime("sgh_ModDate");
        this.sgh_ModUser = p_rs.GetFieldInt("sgh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " sgh_GroupCode,sgh_SiteID,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn,sgh_InDate,sgh_InUser) VALUES ( " + string.Format(" {0}", (object) this.sgh_GroupCode) + string.Format(",{0},{1}", (object) this.sgh_SiteID, (object) this.sgh_GroupType) + string.Format(",'{0}','{1}',{2},'{3}'", (object) this.sgh_GroupName, (object) this.sgh_Memo, (object) this.sgh_SortNo, (object) this.sgh_UseYn) + string.Format(",{0},{1}", (object) this.sgh_InDate.GetDateToStrInNull(), (object) this.sgh_InUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) this.sgh_GroupCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TStoreGroupHeader tstoreGroupHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupHeader.\u003C\u003En__0();
      if (await tstoreGroupHeader.OleDB.ExecuteAsync(tstoreGroupHeader.InsertQuery()))
        return true;
      tstoreGroupHeader.message = " " + tstoreGroupHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) tstoreGroupHeader.sgh_GroupCode) + " 내용 : " + tstoreGroupHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupHeader.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "sgh_GroupType", (object) this.sgh_GroupType) + ",sgh_GroupName='" + this.sgh_GroupName + "',sgh_Memo='" + this.sgh_Memo + "'" + string.Format(",{0}={1}", (object) "sgh_SortNo", (object) this.sgh_SortNo) + ",sgh_UseYn='" + this.sgh_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "sgh_ModDate", (object) this.sgh_ModDate.GetDateToStrInNull(), (object) "sgh_ModUser", (object) this.sgh_ModUser) + string.Format(" WHERE {0}={1}", (object) "sgh_GroupCode", (object) this.sgh_GroupCode);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) this.sgh_GroupCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TStoreGroupHeader tstoreGroupHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupHeader.\u003C\u003En__1();
      if (await tstoreGroupHeader.OleDB.ExecuteAsync(tstoreGroupHeader.UpdateQuery()))
        return true;
      tstoreGroupHeader.message = " " + tstoreGroupHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) tstoreGroupHeader.sgh_GroupCode) + " 내용 : " + tstoreGroupHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupHeader.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "sgh_GroupType", (object) this.sgh_GroupType) + ",sgh_GroupName='" + this.sgh_GroupName + "',sgh_Memo='" + this.sgh_Memo + "'" + string.Format(",{0}={1}", (object) "sgh_SortNo", (object) this.sgh_SortNo) + ",sgh_UseYn='" + this.sgh_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "sgh_ModDate", (object) this.sgh_ModDate.GetDateToStrInNull(), (object) "sgh_ModUser", (object) this.sgh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) this.sgh_GroupCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TStoreGroupHeader tstoreGroupHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupHeader.\u003C\u003En__1();
      if (await tstoreGroupHeader.OleDB.ExecuteAsync(tstoreGroupHeader.UpdateExInsertQuery()))
        return true;
      tstoreGroupHeader.message = " " + tstoreGroupHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0})\n", (object) tstoreGroupHeader.sgh_GroupCode) + " 내용 : " + tstoreGroupHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupHeader.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "sgh_SiteID") && Convert.ToInt64(hashtable[(object) "sgh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sgh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sgh_GroupCode") && Convert.ToInt32(hashtable[(object) "sgh_GroupCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgh_GroupCode", hashtable[(object) "sgh_GroupCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgh_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "sgh_GroupType") && Convert.ToInt32(hashtable[(object) "sgh_GroupType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgh_GroupType", hashtable[(object) "sgh_GroupType"]));
        if (hashtable.ContainsKey((object) "sgh_UseYn") && hashtable[(object) "sgh_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sgh_UseYn", hashtable[(object) "sgh_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sgh_GroupName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%')", (object) "sgh_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  sgh_GroupCode,sgh_SiteID,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn,sgh_InDate,sgh_InUser,sgh_ModDate,sgh_ModUser");
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
