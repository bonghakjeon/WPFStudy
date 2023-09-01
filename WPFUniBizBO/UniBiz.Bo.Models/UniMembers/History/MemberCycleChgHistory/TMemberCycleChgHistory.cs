// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberCycleChgHistory.TMemberCycleChgHistory
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

namespace UniBiz.Bo.Models.UniMembers.History.MemberCycleChgHistory
{
  public class TMemberCycleChgHistory : UbModelBase<TMemberCycleChgHistory>
  {
    private long _mcch_MemberNo;
    private DateTime? _mcch_ChgDate;
    private long _mcch_SiteID;
    private int _mcch_OldMemberCycle;
    private int _mcch_NewMemberCycle;
    private DateTime? _mcch_StartDate;
    private DateTime? _mcch_EndDate;
    private int _mcch_BuyCnt;
    private DateTime? _mcch_InDate;
    private int _mcch_InUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mcch_MemberNo,
      (object) this.mcch_ChgDate
    };

    public long mcch_MemberNo
    {
      get => this._mcch_MemberNo;
      set
      {
        this._mcch_MemberNo = value;
        this.Changed(nameof (mcch_MemberNo));
      }
    }

    public DateTime? mcch_ChgDate
    {
      get => this._mcch_ChgDate;
      set
      {
        this._mcch_ChgDate = value;
        this.Changed(nameof (mcch_ChgDate));
      }
    }

    public long mcch_SiteID
    {
      get => this._mcch_SiteID;
      set
      {
        this._mcch_SiteID = value;
        this.Changed(nameof (mcch_SiteID));
      }
    }

    public int mcch_OldMemberCycle
    {
      get => this._mcch_OldMemberCycle;
      set
      {
        this._mcch_OldMemberCycle = value;
        this.Changed(nameof (mcch_OldMemberCycle));
        this.Changed("mcch_OldMemberCycleDesc");
      }
    }

    public string mcch_OldMemberCycleDesc => this.mcch_OldMemberCycle != 0 ? Enum2StrConverter.ToMemberCalcCycleDiv(this.mcch_OldMemberCycle).ToDescription() : string.Empty;

    public int mcch_NewMemberCycle
    {
      get => this._mcch_NewMemberCycle;
      set
      {
        this._mcch_NewMemberCycle = value;
        this.Changed(nameof (mcch_NewMemberCycle));
        this.Changed("mcch_NewMemberCycleDesc");
      }
    }

    public string mcch_NewMemberCycleDesc => this.mcch_NewMemberCycle != 0 ? Enum2StrConverter.ToMemberCalcCycleDiv(this.mcch_NewMemberCycle).ToDescription() : string.Empty;

    public DateTime? mcch_StartDate
    {
      get => this._mcch_StartDate;
      set
      {
        this._mcch_StartDate = value;
        this.Changed(nameof (mcch_StartDate));
      }
    }

    public DateTime? mcch_EndDate
    {
      get => this._mcch_EndDate;
      set
      {
        this._mcch_EndDate = value;
        this.Changed(nameof (mcch_EndDate));
      }
    }

    public int mcch_BuyCnt
    {
      get => this._mcch_BuyCnt;
      set
      {
        this._mcch_BuyCnt = value;
        this.Changed(nameof (mcch_BuyCnt));
      }
    }

    public DateTime? mcch_InDate
    {
      get => this._mcch_InDate;
      set
      {
        this._mcch_InDate = value;
        this.Changed(nameof (mcch_InDate));
      }
    }

    public int mcch_InUser
    {
      get => this._mcch_InUser;
      set
      {
        this._mcch_InUser = value;
        this.Changed(nameof (mcch_InUser));
      }
    }

    public TMemberCycleChgHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mcch_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mcch_MemberNo",
        tc_trans_name = "회원번호",
        tc_col_status = 4
      });
      columnInfo.Add("mcch_ChgDate", new TTableColumn()
      {
        tc_orgin_name = "mcch_ChgDate",
        tc_trans_name = "주기변경일자",
        tc_col_status = 4
      });
      columnInfo.Add("mcch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mcch_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mcch_OldMemberCycle", new TTableColumn()
      {
        tc_orgin_name = "mcch_OldMemberCycle",
        tc_trans_name = "구회원주기",
        tc_comm_code = 191
      });
      columnInfo.Add("mcch_NewMemberCycle", new TTableColumn()
      {
        tc_orgin_name = "mcch_NewMemberCycle",
        tc_trans_name = "신회원주기",
        tc_comm_code = 191
      });
      columnInfo.Add("mcch_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mcch_StartDate",
        tc_trans_name = "시작일(주기산정기간)"
      });
      columnInfo.Add("mcch_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mcch_EndDate",
        tc_trans_name = "종료일(주기산정기간)"
      });
      columnInfo.Add("mcch_BuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mcch_BuyCnt",
        tc_trans_name = "산정기간 구매횟수"
      });
      columnInfo.Add("mcch_InDate", new TTableColumn()
      {
        tc_orgin_name = "mcch_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mcch_InUser", new TTableColumn()
      {
        tc_orgin_name = "mcch_InUser",
        tc_trans_name = "등록인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCycleChgHistory;
      this.mcch_MemberNo = 0L;
      this.mcch_ChgDate = new DateTime?();
      this.mcch_SiteID = 0L;
      this.mcch_OldMemberCycle = 0;
      this.mcch_NewMemberCycle = 0;
      this.mcch_StartDate = new DateTime?();
      this.mcch_EndDate = new DateTime?();
      this.mcch_BuyCnt = 0;
      this.mcch_InDate = new DateTime?();
      this.mcch_InUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberCycleChgHistory();

    public override object Clone()
    {
      TMemberCycleChgHistory tmemberCycleChgHistory = base.Clone() as TMemberCycleChgHistory;
      tmemberCycleChgHistory.mcch_MemberNo = this.mcch_MemberNo;
      tmemberCycleChgHistory.mcch_ChgDate = this.mcch_ChgDate;
      tmemberCycleChgHistory.mcch_OldMemberCycle = this.mcch_OldMemberCycle;
      tmemberCycleChgHistory.mcch_NewMemberCycle = this.mcch_NewMemberCycle;
      tmemberCycleChgHistory.mcch_StartDate = this.mcch_StartDate;
      tmemberCycleChgHistory.mcch_EndDate = this.mcch_EndDate;
      tmemberCycleChgHistory.mcch_BuyCnt = this.mcch_BuyCnt;
      tmemberCycleChgHistory.mcch_InDate = this.mcch_InDate;
      tmemberCycleChgHistory.mcch_InUser = this.mcch_InUser;
      return (object) tmemberCycleChgHistory;
    }

    public void PutData(TMemberCycleChgHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mcch_MemberNo = pSource.mcch_MemberNo;
      this.mcch_ChgDate = pSource.mcch_ChgDate;
      this.mcch_OldMemberCycle = pSource.mcch_OldMemberCycle;
      this.mcch_NewMemberCycle = pSource.mcch_NewMemberCycle;
      this.mcch_StartDate = pSource.mcch_StartDate;
      this.mcch_EndDate = pSource.mcch_EndDate;
      this.mcch_BuyCnt = pSource.mcch_BuyCnt;
      this.mcch_InDate = pSource.mcch_InDate;
      this.mcch_InUser = pSource.mcch_InUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mcch_MemberNo = (long) p_rs.GetFieldInt("mcch_MemberNo");
        if (this.mcch_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mcch_ChgDate = p_rs.GetFieldDateTime("mcch_ChgDate");
        this.mcch_SiteID = p_rs.GetFieldLong("mcch_SiteID");
        this.mcch_OldMemberCycle = p_rs.GetFieldInt("mcch_OldMemberCycle");
        this.mcch_NewMemberCycle = p_rs.GetFieldInt("mcch_NewMemberCycle");
        this.mcch_StartDate = p_rs.GetFieldDateTime("mcch_StartDate");
        this.mcch_EndDate = p_rs.GetFieldDateTime("mcch_EndDate");
        this.mcch_BuyCnt = p_rs.GetFieldInt("mcch_BuyCnt");
        this.mcch_InDate = p_rs.GetFieldDateTime("mcch_InDate");
        this.mcch_InUser = p_rs.GetFieldInt("mcch_InUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcch_MemberNo,mcch_ChgDate,mcch_SiteID,mcch_OldMemberCycle,mcch_NewMemberCycle,mcch_StartDate,mcch_EndDate,mcch_BuyCnt,mcch_InDate,mcch_InUser\n) VALUES (\n" + string.Format(" {0},{1}", (object) this.mcch_MemberNo, (object) this.mcch_ChgDate.GetDateToStr()) + string.Format(",{0}", (object) this.mcch_SiteID) + string.Format(",{0},{1}", (object) this.mcch_OldMemberCycle, (object) this.mcch_NewMemberCycle) + "," + this.mcch_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.mcch_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}", (object) this.mcch_BuyCnt) + string.Format(",{0},{1}", (object) this.mcch_InDate.GetDateToStrInNull(), (object) this.mcch_InUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcch_MemberNo, (object) this.mcch_ChgDate, (object) this.mcch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberCycleChgHistory tmemberCycleChgHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleChgHistory.\u003C\u003En__0();
      if (await tmemberCycleChgHistory.OleDB.ExecuteAsync(tmemberCycleChgHistory.InsertQuery()))
        return true;
      tmemberCycleChgHistory.message = " " + tmemberCycleChgHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleChgHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleChgHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleChgHistory.mcch_MemberNo, (object) tmemberCycleChgHistory.mcch_ChgDate, (object) tmemberCycleChgHistory.mcch_SiteID) + " 내용 : " + tmemberCycleChgHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleChgHistory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mcch_SiteID") && Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mcch_MemberNo") && Convert.ToInt64(hashtable[(object) "mcch_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_MemberNo", hashtable[(object) "mcch_MemberNo"]));
        if (hashtable.ContainsKey((object) "mcch_ChgDate") && !string.IsNullOrEmpty(hashtable[(object) "mcch_ChgDate"].ToString()))
          stringBuilder.Append(" AND mcch_ChgDate==" + new DateTime?((DateTime) hashtable[(object) "mcch_ChgDate"]).GetDateToStr());
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mcch_OldMemberCycle") && Convert.ToInt32(hashtable[(object) "mcch_OldMemberCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_OldMemberCycle", hashtable[(object) "mcch_OldMemberCycle"]));
        if (hashtable.ContainsKey((object) "mcch_NewMemberCycle") && Convert.ToInt32(hashtable[(object) "mcch_NewMemberCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_NewMemberCycle", hashtable[(object) "mcch_NewMemberCycle"]));
        if (hashtable.ContainsKey((object) "mcch_StartDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_StartDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mcch_StartDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_StartDate_END_"].ToString()))
          stringBuilder.Append(" AND mcch_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mcch_StartDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcch_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mcch_StartDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mcch_EndDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_EndDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mcch_EndDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_EndDate_END_"].ToString()))
          stringBuilder.Append(" AND mcch_EndDate<=" + new DateTime?((DateTime) hashtable[(object) "mcch_EndDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcch_EndDate>=" + new DateTime?((DateTime) hashtable[(object) "mcch_EndDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mcch_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mcch_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
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
        stringBuilder.Append(" SELECT  mcch_MemberNo,mcch_ChgDate,mcch_SiteID,mcch_OldMemberCycle,mcch_NewMemberCycle,mcch_StartDate,mcch_EndDate,mcch_BuyCnt,mcch_InDate,mcch_InUser");
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
