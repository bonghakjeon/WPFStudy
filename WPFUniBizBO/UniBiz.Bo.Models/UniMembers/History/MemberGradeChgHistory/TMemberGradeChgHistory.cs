// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberGradeChgHistory.TMemberGradeChgHistory
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

namespace UniBiz.Bo.Models.UniMembers.History.MemberGradeChgHistory
{
  public class TMemberGradeChgHistory : UbModelBase<TMemberGradeChgHistory>
  {
    private long _mgch_MemberNo;
    private DateTime? _mgch_ChgDate;
    private long _mgch_SiteID;
    private int _mgch_OldMemberGrade;
    private int _mgch_NewMemberGrade;
    private DateTime? _mgch_StartDate;
    private DateTime? _mgch_EndDate;
    private int _mgch_BuyCnt;
    private double _mgch_BuyAmt;
    private DateTime? _mgch_InDate;
    private int _mgch_InUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mgch_MemberNo,
      (object) this.mgch_ChgDate
    };

    public long mgch_MemberNo
    {
      get => this._mgch_MemberNo;
      set
      {
        this._mgch_MemberNo = value;
        this.Changed(nameof (mgch_MemberNo));
      }
    }

    public DateTime? mgch_ChgDate
    {
      get => this._mgch_ChgDate;
      set
      {
        this._mgch_ChgDate = value;
        this.Changed(nameof (mgch_ChgDate));
      }
    }

    public long mgch_SiteID
    {
      get => this._mgch_SiteID;
      set
      {
        this._mgch_SiteID = value;
        this.Changed(nameof (mgch_SiteID));
      }
    }

    public int mgch_OldMemberGrade
    {
      get => this._mgch_OldMemberGrade;
      set
      {
        this._mgch_OldMemberGrade = value;
        this.Changed(nameof (mgch_OldMemberGrade));
      }
    }

    public int mgch_NewMemberGrade
    {
      get => this._mgch_NewMemberGrade;
      set
      {
        this._mgch_NewMemberGrade = value;
        this.Changed(nameof (mgch_NewMemberGrade));
      }
    }

    public DateTime? mgch_StartDate
    {
      get => this._mgch_StartDate;
      set
      {
        this._mgch_StartDate = value;
        this.Changed(nameof (mgch_StartDate));
      }
    }

    public DateTime? mgch_EndDate
    {
      get => this._mgch_EndDate;
      set
      {
        this._mgch_EndDate = value;
        this.Changed(nameof (mgch_EndDate));
      }
    }

    public int mgch_BuyCnt
    {
      get => this._mgch_BuyCnt;
      set
      {
        this._mgch_BuyCnt = value;
        this.Changed(nameof (mgch_BuyCnt));
      }
    }

    public double mgch_BuyAmt
    {
      get => this._mgch_BuyAmt;
      set
      {
        this._mgch_BuyAmt = value;
        this.Changed(nameof (mgch_BuyAmt));
      }
    }

    public DateTime? mgch_InDate
    {
      get => this._mgch_InDate;
      set
      {
        this._mgch_InDate = value;
        this.Changed(nameof (mgch_InDate));
      }
    }

    public int mgch_InUser
    {
      get => this._mgch_InUser;
      set
      {
        this._mgch_InUser = value;
        this.Changed(nameof (mgch_InUser));
      }
    }

    public TMemberGradeChgHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mgch_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mgch_MemberNo",
        tc_trans_name = "회원번호",
        tc_col_status = 4
      });
      columnInfo.Add("mgch_ChgDate", new TTableColumn()
      {
        tc_orgin_name = "mgch_ChgDate",
        tc_trans_name = "등급변경일자",
        tc_col_status = 4
      });
      columnInfo.Add("mgch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mgch_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mgch_OldMemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mgch_OldMemberGrade",
        tc_trans_name = "구회원등급"
      });
      columnInfo.Add("mgch_NewMemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mgch_NewMemberGrade",
        tc_trans_name = "신회원등급"
      });
      columnInfo.Add("mgch_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mgch_StartDate",
        tc_trans_name = "시작일(등급산정기간)"
      });
      columnInfo.Add("mgch_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mgch_EndDate",
        tc_trans_name = "종료일(등급산정기간)"
      });
      columnInfo.Add("mgch_BuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mgch_BuyCnt",
        tc_trans_name = "산정기간 구매횟수"
      });
      columnInfo.Add("mgch_BuyAmt", new TTableColumn()
      {
        tc_orgin_name = "mgch_BuyAmt",
        tc_trans_name = "산정기간 구매금액"
      });
      columnInfo.Add("mgch_InDate", new TTableColumn()
      {
        tc_orgin_name = "mgch_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mgch_InUser", new TTableColumn()
      {
        tc_orgin_name = "mgch_InUser",
        tc_trans_name = "등록인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberGradeChgHistory;
      this.mgch_MemberNo = 0L;
      this.mgch_ChgDate = new DateTime?();
      this.mgch_SiteID = 0L;
      this.mgch_OldMemberGrade = 0;
      this.mgch_NewMemberGrade = 0;
      this.mgch_StartDate = new DateTime?();
      this.mgch_EndDate = new DateTime?();
      this.mgch_BuyCnt = 0;
      this.mgch_BuyAmt = 0.0;
      this.mgch_InDate = new DateTime?();
      this.mgch_InUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberGradeChgHistory();

    public override object Clone()
    {
      TMemberGradeChgHistory tmemberGradeChgHistory = base.Clone() as TMemberGradeChgHistory;
      tmemberGradeChgHistory.mgch_MemberNo = this.mgch_MemberNo;
      tmemberGradeChgHistory.mgch_ChgDate = this.mgch_ChgDate;
      tmemberGradeChgHistory.mgch_OldMemberGrade = this.mgch_OldMemberGrade;
      tmemberGradeChgHistory.mgch_NewMemberGrade = this.mgch_NewMemberGrade;
      tmemberGradeChgHistory.mgch_StartDate = this.mgch_StartDate;
      tmemberGradeChgHistory.mgch_EndDate = this.mgch_EndDate;
      tmemberGradeChgHistory.mgch_BuyCnt = this.mgch_BuyCnt;
      tmemberGradeChgHistory.mgch_BuyAmt = this.mgch_BuyAmt;
      tmemberGradeChgHistory.mgch_InDate = this.mgch_InDate;
      tmemberGradeChgHistory.mgch_InUser = this.mgch_InUser;
      return (object) tmemberGradeChgHistory;
    }

    public void PutData(TMemberGradeChgHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mgch_MemberNo = pSource.mgch_MemberNo;
      this.mgch_ChgDate = pSource.mgch_ChgDate;
      this.mgch_OldMemberGrade = pSource.mgch_OldMemberGrade;
      this.mgch_NewMemberGrade = pSource.mgch_NewMemberGrade;
      this.mgch_StartDate = pSource.mgch_StartDate;
      this.mgch_EndDate = pSource.mgch_EndDate;
      this.mgch_BuyCnt = pSource.mgch_BuyCnt;
      this.mgch_BuyAmt = pSource.mgch_BuyAmt;
      this.mgch_InDate = pSource.mgch_InDate;
      this.mgch_InUser = pSource.mgch_InUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mgch_MemberNo = (long) p_rs.GetFieldInt("mgch_MemberNo");
        if (this.mgch_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mgch_ChgDate = p_rs.GetFieldDateTime("mgch_ChgDate");
        this.mgch_SiteID = p_rs.GetFieldLong("mgch_SiteID");
        this.mgch_OldMemberGrade = p_rs.GetFieldInt("mgch_OldMemberGrade");
        this.mgch_NewMemberGrade = p_rs.GetFieldInt("mgch_NewMemberGrade");
        this.mgch_StartDate = p_rs.GetFieldDateTime("mgch_StartDate");
        this.mgch_EndDate = p_rs.GetFieldDateTime("mgch_EndDate");
        this.mgch_BuyCnt = p_rs.GetFieldInt("mgch_BuyCnt");
        this.mgch_BuyAmt = p_rs.GetFieldDouble("mgch_BuyAmt");
        this.mgch_InDate = p_rs.GetFieldDateTime("mgch_InDate");
        this.mgch_InUser = p_rs.GetFieldInt("mgch_InUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgch_MemberNo,mgch_ChgDate,mgch_SiteID,mgch_OldMemberGrade,mgch_NewMemberGrade,mgch_StartDate,mgch_EndDate,mgch_BuyCnt,mgch_BuyAmt,mgch_InDate,mgch_InUser\n) VALUES (\n" + string.Format(" {0},{1}", (object) this.mgch_MemberNo, (object) this.mgch_ChgDate.GetDateToStr()) + string.Format(",{0}", (object) this.mgch_SiteID) + string.Format(",{0},{1}", (object) this.mgch_OldMemberGrade, (object) this.mgch_NewMemberGrade) + "," + this.mgch_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.mgch_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1}", (object) this.mgch_BuyCnt, (object) this.mgch_BuyAmt.FormatTo("{0:0.0000}")) + string.Format(",{0},{1}", (object) this.mgch_InDate.GetDateToStrInNull(), (object) this.mgch_InUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mgch_MemberNo, (object) this.mgch_ChgDate, (object) this.mgch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberGradeChgHistory tmemberGradeChgHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeChgHistory.\u003C\u003En__0();
      if (await tmemberGradeChgHistory.OleDB.ExecuteAsync(tmemberGradeChgHistory.InsertQuery()))
        return true;
      tmemberGradeChgHistory.message = " " + tmemberGradeChgHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeChgHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeChgHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberGradeChgHistory.mgch_MemberNo, (object) tmemberGradeChgHistory.mgch_ChgDate, (object) tmemberGradeChgHistory.mgch_SiteID) + " 내용 : " + tmemberGradeChgHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeChgHistory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mgch_SiteID") && Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mgch_MemberNo") && Convert.ToInt64(hashtable[(object) "mgch_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_MemberNo", hashtable[(object) "mgch_MemberNo"]));
        if (hashtable.ContainsKey((object) "mgch_ChgDate") && !string.IsNullOrEmpty(hashtable[(object) "mgch_ChgDate"].ToString()))
          stringBuilder.Append(" AND mgch_ChgDate==" + new DateTime?((DateTime) hashtable[(object) "mgch_ChgDate"]).GetDateToStr());
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mgch_OldMemberGrade") && Convert.ToInt32(hashtable[(object) "mgch_OldMemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_OldMemberGrade", hashtable[(object) "mgch_OldMemberGrade"]));
        if (hashtable.ContainsKey((object) "mgch_NewMemberGrade") && Convert.ToInt32(hashtable[(object) "mgch_NewMemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_NewMemberGrade", hashtable[(object) "mgch_NewMemberGrade"]));
        if (hashtable.ContainsKey((object) "mgch_StartDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_StartDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mgch_StartDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_StartDate_END_"].ToString()))
          stringBuilder.Append(" AND mgch_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mgch_StartDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgch_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mgch_StartDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mgch_EndDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_EndDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mgch_EndDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_EndDate_END_"].ToString()))
          stringBuilder.Append(" AND mgch_EndDate<=" + new DateTime?((DateTime) hashtable[(object) "mgch_EndDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgch_EndDate>=" + new DateTime?((DateTime) hashtable[(object) "mgch_EndDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mgch_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mgch_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
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
        stringBuilder.Append(" SELECT  mgch_MemberNo,mgch_ChgDate,mgch_SiteID,mgch_OldMemberGrade,mgch_NewMemberGrade,mgch_StartDate,mgch_EndDate,mgch_BuyCnt,mgch_BuyAmt,mgch_InDate,mgch_InUser");
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
