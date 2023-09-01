// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberCard.TMemberCard
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberCard
{
  public class TMemberCard : UbModelBase<TMemberCard>
  {
    private long _mbrc_MemberNo;
    private string _mbrc_MemberCardNo;
    private long _mbrc_SiteID;
    private int _mbrc_CardType;
    private string _mbrc_Memo;
    private string _mbrc_UseYn;
    private DateTime? _mbrc_InDate;
    private int _mbrc_InUser;
    private DateTime? _mbrc_ModDate;
    private int _mbrc_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mbrc_MemberNo,
      (object) this.mbrc_MemberCardNo
    };

    public long mbrc_MemberNo
    {
      get => this._mbrc_MemberNo;
      set
      {
        this._mbrc_MemberNo = value;
        this.Changed(nameof (mbrc_MemberNo));
      }
    }

    public string mbrc_MemberCardNo
    {
      get => this._mbrc_MemberCardNo;
      set
      {
        this._mbrc_MemberCardNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (mbrc_MemberCardNo));
      }
    }

    public long mbrc_SiteID
    {
      get => this._mbrc_SiteID;
      set
      {
        this._mbrc_SiteID = value;
        this.Changed(nameof (mbrc_SiteID));
      }
    }

    public int mbrc_CardType
    {
      get => this._mbrc_CardType;
      set
      {
        this._mbrc_CardType = value;
        this.Changed(nameof (mbrc_CardType));
        this.Changed("mbrc_CardTypeDesc");
      }
    }

    public string mbrc_CardTypeDesc => this.mbrc_CardType != 0 ? Enum2StrConverter.ToMemberCardType(this.mbrc_CardType).ToDescription() : string.Empty;

    public string mbrc_Memo
    {
      get => this._mbrc_Memo;
      set
      {
        this._mbrc_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbrc_Memo));
      }
    }

    public string mbrc_UseYn
    {
      get => this._mbrc_UseYn;
      set
      {
        this._mbrc_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mbrc_UseYn));
        this.Changed("mbrc_IsUse");
        this.Changed("mbrc_UseYnDesc");
      }
    }

    public bool mbrc_IsUse => "Y".Equals(this.mbrc_UseYn);

    public string mbrc_UseYnDesc => !"Y".Equals(this.mbrc_UseYn) ? "미사용" : "사용";

    public DateTime? mbrc_InDate
    {
      get => this._mbrc_InDate;
      set
      {
        this._mbrc_InDate = value;
        this.Changed(nameof (mbrc_InDate));
      }
    }

    public int mbrc_InUser
    {
      get => this._mbrc_InUser;
      set
      {
        this._mbrc_InUser = value;
        this.Changed(nameof (mbrc_InUser));
      }
    }

    public DateTime? mbrc_ModDate
    {
      get => this._mbrc_ModDate;
      set
      {
        this._mbrc_ModDate = value;
        this.Changed(nameof (mbrc_ModDate));
      }
    }

    public int mbrc_ModUser
    {
      get => this._mbrc_ModUser;
      set
      {
        this._mbrc_ModUser = value;
        this.Changed(nameof (mbrc_ModUser));
      }
    }

    public override DateTime? ModDate => this.mbrc_ModDate ?? (this.mbrc_ModDate = this.mbrc_InDate);

    public TMemberCard() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbrc_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mbrc_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mbrc_MemberCardNo", new TTableColumn()
      {
        tc_orgin_name = "mbrc_MemberCardNo",
        tc_trans_name = "카드번호"
      });
      columnInfo.Add("mbrc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mbrc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mbrc_CardType", new TTableColumn()
      {
        tc_orgin_name = "mbrc_CardType",
        tc_trans_name = "카드유형",
        tc_comm_code = 185
      });
      columnInfo.Add("mbrc_Memo", new TTableColumn()
      {
        tc_orgin_name = "mbrc_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("mbrc_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mbrc_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("mbrc_InDate", new TTableColumn()
      {
        tc_orgin_name = "mbrc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mbrc_InUser", new TTableColumn()
      {
        tc_orgin_name = "mbrc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mbrc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mbrc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mbrc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mbrc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCard;
      this.mbrc_MemberNo = 0L;
      this.mbrc_MemberCardNo = string.Empty;
      this.mbrc_SiteID = 0L;
      this.mbrc_CardType = 0;
      this.mbrc_Memo = string.Empty;
      this.mbrc_UseYn = "Y";
      this.mbrc_InDate = new DateTime?();
      this.mbrc_InUser = 0;
      this.mbrc_ModDate = new DateTime?();
      this.mbrc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberCard();

    public override object Clone()
    {
      TMemberCard tmemberCard = base.Clone() as TMemberCard;
      tmemberCard.mbrc_MemberNo = this.mbrc_MemberNo;
      tmemberCard.mbrc_MemberCardNo = this.mbrc_MemberCardNo;
      tmemberCard.mbrc_SiteID = this.mbrc_SiteID;
      tmemberCard.mbrc_CardType = this.mbrc_CardType;
      tmemberCard.mbrc_Memo = this.mbrc_Memo;
      tmemberCard.mbrc_UseYn = this.mbrc_UseYn;
      tmemberCard.mbrc_InDate = this.mbrc_InDate;
      tmemberCard.mbrc_InUser = this.mbrc_InUser;
      tmemberCard.mbrc_ModDate = this.mbrc_ModDate;
      tmemberCard.mbrc_ModUser = this.mbrc_ModUser;
      return (object) tmemberCard;
    }

    public void PutData(TMemberCard pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mbrc_MemberNo = pSource.mbrc_MemberNo;
      this.mbrc_MemberCardNo = pSource.mbrc_MemberCardNo;
      this.mbrc_SiteID = pSource.mbrc_SiteID;
      this.mbrc_CardType = pSource.mbrc_CardType;
      this.mbrc_Memo = pSource.mbrc_Memo;
      this.mbrc_UseYn = pSource.mbrc_UseYn;
      this.mbrc_InDate = pSource.mbrc_InDate;
      this.mbrc_InUser = pSource.mbrc_InUser;
      this.mbrc_ModDate = pSource.mbrc_ModDate;
      this.mbrc_ModUser = pSource.mbrc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mbrc_MemberNo = p_rs.GetFieldLong("mbrc_MemberNo");
        if (this.mbrc_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mbrc_MemberCardNo = p_rs.GetFieldString("mbrc_MemberCardNo");
        this.mbrc_SiteID = p_rs.GetFieldLong("mbrc_SiteID");
        this.mbrc_CardType = p_rs.GetFieldInt("mbrc_CardType");
        this.mbrc_Memo = p_rs.GetFieldString("mbrc_Memo");
        this.mbrc_UseYn = p_rs.GetFieldString("mbrc_UseYn");
        this.mbrc_InDate = p_rs.GetFieldDateTime("mbrc_InDate");
        this.mbrc_InUser = p_rs.GetFieldInt("mbrc_InUser");
        this.mbrc_ModDate = p_rs.GetFieldDateTime("mbrc_ModDate");
        this.mbrc_ModUser = p_rs.GetFieldInt("mbrc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mbrc_MemberNo,mbrc_MemberCardNo,mbrc_SiteID,mbrc_CardType,mbrc_Memo,mbrc_UseYn,mbrc_InDate,mbrc_InUser,mbrc_ModDate,mbrc_ModUser) VALUES ( " + string.Format(" {0},'{1}'", (object) this.mbrc_MemberNo, (object) this.mbrc_MemberCardNo) + string.Format(",{0}", (object) this.mbrc_SiteID) + string.Format(",{0},'{1}','{2}'", (object) this.mbrc_CardType, (object) this.mbrc_Memo, (object) this.mbrc_UseYn) + string.Format(",{0},{1}", (object) this.mbrc_InDate.GetDateToStrInNull(), (object) this.mbrc_InUser) + string.Format(",{0},{1}", (object) this.mbrc_ModDate.GetDateToStrInNull(), (object) this.mbrc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mbrc_MemberNo, (object) this.mbrc_MemberCardNo, (object) this.mbrc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberCard tmemberCard = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCard.\u003C\u003En__0();
      if (await tmemberCard.OleDB.ExecuteAsync(tmemberCard.InsertQuery()))
        return true;
      tmemberCard.message = " " + tmemberCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCard.mbrc_MemberNo, (object) tmemberCard.mbrc_MemberCardNo, (object) tmemberCard.mbrc_SiteID) + " 내용 : " + tmemberCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCard.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}", (object) "mbrc_CardType", (object) this.mbrc_CardType) + ",mbrc_Memo='" + this.mbrc_Memo + "',mbrc_UseYn='" + this.mbrc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mbrc_ModDate", (object) this.mbrc_ModDate.GetDateToStrInNull(), (object) "mbrc_ModUser", (object) this.mbrc_ModUser) + string.Format(" WHERE {0}={1}", (object) "mbrc_MemberNo", (object) this.mbrc_MemberNo) + " AND mbrc_MemberCardNo='" + this.mbrc_MemberCardNo + "'" + string.Format(" AND {0}={1}", (object) "mbrc_SiteID", (object) this.mbrc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mbrc_MemberNo, (object) this.mbrc_MemberCardNo, (object) this.mbrc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberCard tmemberCard = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCard.\u003C\u003En__1();
      if (await tmemberCard.OleDB.ExecuteAsync(tmemberCard.UpdateQuery()))
        return true;
      tmemberCard.message = " " + tmemberCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCard.mbrc_MemberNo, (object) tmemberCard.mbrc_MemberCardNo, (object) tmemberCard.mbrc_SiteID) + " 내용 : " + tmemberCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCard.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "mbrc_CardType", (object) this.mbrc_CardType) + ",mbrc_Memo='" + this.mbrc_Memo + "',mbrc_UseYn='" + this.mbrc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mbrc_ModDate", (object) this.mbrc_ModDate.GetDateToStrInNull(), (object) "mbrc_ModUser", (object) this.mbrc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mbrc_MemberNo, (object) this.mbrc_MemberCardNo, (object) this.mbrc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberCard tmemberCard = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCard.\u003C\u003En__1();
      if (await tmemberCard.OleDB.ExecuteAsync(tmemberCard.UpdateExInsertQuery()))
        return true;
      tmemberCard.message = " " + tmemberCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCard.mbrc_MemberNo, (object) tmemberCard.mbrc_MemberCardNo, (object) tmemberCard.mbrc_SiteID) + " 내용 : " + tmemberCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCard.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mbrc_SiteID") && Convert.ToInt64(hashtable[(object) "mbrc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mbrc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mbrc_MemberNo") && Convert.ToInt64(hashtable[(object) "mbrc_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrc_MemberNo", hashtable[(object) "mbrc_MemberNo"]));
        else if (hashtable.ContainsKey((object) "mbrc_MemberNo_EXCEPT_") && Convert.ToInt64(hashtable[(object) "mbrc_MemberNo_EXCEPT_"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "mbrc_MemberNo", hashtable[(object) "mbrc_MemberNo"]));
        if (hashtable.ContainsKey((object) "mbrc_MemberCardNo") && !string.IsNullOrEmpty(hashtable[(object) "mbrc_MemberCardNo"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbrc_MemberCardNo", hashtable[(object) "mbrc_MemberCardNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mbrc_CardType") && Convert.ToInt32(hashtable[(object) "mbrc_CardType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrc_CardType", hashtable[(object) "mbrc_CardType"]));
        if (hashtable.ContainsKey((object) "mbrc_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "mbrc_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbrc_UseYn", hashtable[(object) "mbrc_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbrc_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mbrc_MemberNo,mbrc_MemberCardNo,mbrc_SiteID,mbrc_CardType,mbrc_Memo,mbrc_UseYn,mbrc_InDate,mbrc_InUser,mbrc_ModDate,mbrc_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniMembers) + str + " " + DbQueryHelper.ToWithNolock());
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
