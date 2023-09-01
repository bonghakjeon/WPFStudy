// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.Basic.MemberInqBasicPointDayStatus
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniMembers.History.MemberPointHistory;
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Inq.Basic
{
  public class MemberInqBasicPointDayStatus : UbModelBase<MemberInqBasicPointDayStatus>
  {
    private DateTime? _mibpds_SaleDate;
    private long _mibpds_SiteID;
    private int _mibpds_AddPoint;
    private int _mibpds_AddMbrCnt;
    private int _mibpds_AfAddPoint;
    private int _mibpds_AfAddMbrCnt;
    private int _mibpds_MlAddPoint;
    private int _mibpds_MlAddMbrCnt;
    private int _mibpds_UsePoint;
    private int _mibpds_UseMbrCnt;
    private int _mibpds_ExtinctPoint;
    private int _mibpds_ExtinctMbrCnt;
    private int _mibpds_MlUsePoint;
    private int _mibpds_MlUseMbrCnt;

    public override object _Key => (object) new object[1]
    {
      (object) this.mibpds_SaleDate
    };

    public DateTime? mibpds_SaleDate
    {
      get => this._mibpds_SaleDate;
      set
      {
        this._mibpds_SaleDate = value;
        this.Changed(nameof (mibpds_SaleDate));
      }
    }

    public long mibpds_SiteID
    {
      get => this._mibpds_SiteID;
      set
      {
        this._mibpds_SiteID = value;
        this.Changed(nameof (mibpds_SiteID));
      }
    }

    public int mibpds_AddPoint
    {
      get => this._mibpds_AddPoint;
      set
      {
        this._mibpds_AddPoint = value;
        this.Changed(nameof (mibpds_AddPoint));
        this.Changed("mibpds_AddPointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_AddMbrCnt
    {
      get => this._mibpds_AddMbrCnt;
      set
      {
        this._mibpds_AddMbrCnt = value;
        this.Changed(nameof (mibpds_AddMbrCnt));
      }
    }

    public int mibpds_AfAddPoint
    {
      get => this._mibpds_AfAddPoint;
      set
      {
        this._mibpds_AfAddPoint = value;
        this.Changed(nameof (mibpds_AfAddPoint));
        this.Changed("mibpds_AddPointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_AfAddMbrCnt
    {
      get => this._mibpds_AfAddMbrCnt;
      set
      {
        this._mibpds_AfAddMbrCnt = value;
        this.Changed(nameof (mibpds_AfAddMbrCnt));
      }
    }

    public int mibpds_MlAddPoint
    {
      get => this._mibpds_MlAddPoint;
      set
      {
        this._mibpds_MlAddPoint = value;
        this.Changed(nameof (mibpds_MlAddPoint));
        this.Changed("mibpds_AddPointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_MlAddMbrCnt
    {
      get => this._mibpds_MlAddMbrCnt;
      set
      {
        this._mibpds_MlAddMbrCnt = value;
        this.Changed(nameof (mibpds_MlAddMbrCnt));
      }
    }

    public int mibpds_UsePoint
    {
      get => this._mibpds_UsePoint;
      set
      {
        this._mibpds_UsePoint = value;
        this.Changed(nameof (mibpds_UsePoint));
        this.Changed("mibpds_UsePointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_UseMbrCnt
    {
      get => this._mibpds_UseMbrCnt;
      set
      {
        this._mibpds_UseMbrCnt = value;
        this.Changed(nameof (mibpds_UseMbrCnt));
      }
    }

    public int mibpds_ExtinctPoint
    {
      get => this._mibpds_ExtinctPoint;
      set
      {
        this._mibpds_ExtinctPoint = value;
        this.Changed(nameof (mibpds_ExtinctPoint));
        this.Changed("mibpds_UsePointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_ExtinctMbrCnt
    {
      get => this._mibpds_ExtinctMbrCnt;
      set
      {
        this._mibpds_ExtinctMbrCnt = value;
        this.Changed(nameof (mibpds_ExtinctMbrCnt));
      }
    }

    public int mibpds_MlUsePoint
    {
      get => this._mibpds_MlUsePoint;
      set
      {
        this._mibpds_MlUsePoint = value;
        this.Changed(nameof (mibpds_MlUsePoint));
        this.Changed("mibpds_UsePointSum");
        this.Changed("mibpds_PointSum");
      }
    }

    public int mibpds_MlUseMbrCnt
    {
      get => this._mibpds_MlUseMbrCnt;
      set
      {
        this._mibpds_MlUseMbrCnt = value;
        this.Changed(nameof (mibpds_MlUseMbrCnt));
      }
    }

    public int mibpds_AddPointSum => this.mibpds_AddPoint + this.mibpds_AfAddPoint + this.mibpds_MlAddPoint;

    public int mibpds_UsePointSum => this.mibpds_UsePoint + this.mibpds_ExtinctPoint + this.mibpds_MlUsePoint;

    public int mibpds_PointSum => this.mibpds_AddPointSum - this.mibpds_UsePointSum;

    public MemberInqBasicPointDayStatus() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mibpds_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "mibpds_SaleDate",
        tc_trans_name = "영업일"
      });
      columnInfo.Add("mibpds_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mibpds_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mibpds_AddPoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_AddPoint",
        tc_trans_name = "적립포인트",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_AddMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_AddMbrCnt",
        tc_trans_name = "적립회원수",
        tc_parents_name = "포인트적립",
        tc_col_status = 2
      });
      columnInfo.Add("mibpds_AfAddPoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_AfAddPoint",
        tc_trans_name = "사후적립포인트",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_AfAddMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_AfAddMbrCnt",
        tc_trans_name = "사후적립회원수",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_MlAddPoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_MlAddPoint",
        tc_trans_name = "수기적립포인트",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_MlAddMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_MlAddMbrCnt",
        tc_trans_name = "수기적립회원수",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_AddPointSum", new TTableColumn()
      {
        tc_orgin_name = "mibpds_AddPointSum",
        tc_trans_name = "적립포인트소계",
        tc_parents_name = "포인트적립"
      });
      columnInfo.Add("mibpds_UsePoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_UsePoint",
        tc_trans_name = "사용포인트",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_UseMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_UseMbrCnt",
        tc_trans_name = "사용회원수",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_ExtinctPoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_ExtinctPoint",
        tc_trans_name = "소멸포인트",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_ExtinctMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_ExtinctMbrCnt",
        tc_trans_name = "소멸회원수",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_MlUsePoint", new TTableColumn()
      {
        tc_orgin_name = "mibpds_MlUsePoint",
        tc_trans_name = "수기차감포인트",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_MlUseMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mibpds_MlUseMbrCnt",
        tc_trans_name = "수기차감회원수",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_UsePointSum", new TTableColumn()
      {
        tc_orgin_name = "mibpds_UsePointSum",
        tc_trans_name = "사용포인트소계",
        tc_parents_name = "포인트사용"
      });
      columnInfo.Add("mibpds_PointSum", new TTableColumn()
      {
        tc_orgin_name = "mibpds_PointSum",
        tc_trans_name = "당일포인트합계"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.mibpds_SaleDate = new DateTime?();
      this.mibpds_SiteID = 0L;
      this.mibpds_AddPoint = this.mibpds_AddMbrCnt = this.mibpds_AfAddPoint = this.mibpds_AfAddMbrCnt = this.mibpds_MlAddPoint = this.mibpds_MlAddMbrCnt = 0;
      this.mibpds_UsePoint = this.mibpds_UseMbrCnt = this.mibpds_ExtinctPoint = this.mibpds_ExtinctMbrCnt = this.mibpds_MlUsePoint = this.mibpds_MlUseMbrCnt = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBasicPointDayStatus();

    public override object Clone()
    {
      MemberInqBasicPointDayStatus basicPointDayStatus = base.Clone() as MemberInqBasicPointDayStatus;
      basicPointDayStatus.mibpds_SaleDate = this.mibpds_SaleDate;
      basicPointDayStatus.mibpds_SiteID = this.mibpds_SiteID;
      basicPointDayStatus.mibpds_AddPoint = this.mibpds_AddPoint;
      basicPointDayStatus.mibpds_AddMbrCnt = this.mibpds_AddMbrCnt;
      basicPointDayStatus.mibpds_AfAddPoint = this.mibpds_AfAddPoint;
      basicPointDayStatus.mibpds_AfAddMbrCnt = this.mibpds_AfAddMbrCnt;
      basicPointDayStatus.mibpds_MlAddPoint = this.mibpds_MlAddPoint;
      basicPointDayStatus.mibpds_MlAddMbrCnt = this.mibpds_MlAddMbrCnt;
      basicPointDayStatus.mibpds_UsePoint = this.mibpds_UsePoint;
      basicPointDayStatus.mibpds_UseMbrCnt = this.mibpds_UseMbrCnt;
      basicPointDayStatus.mibpds_ExtinctPoint = this.mibpds_ExtinctPoint;
      basicPointDayStatus.mibpds_ExtinctMbrCnt = this.mibpds_ExtinctMbrCnt;
      basicPointDayStatus.mibpds_MlUsePoint = this.mibpds_MlUsePoint;
      basicPointDayStatus.mibpds_MlUseMbrCnt = this.mibpds_MlUseMbrCnt;
      return (object) basicPointDayStatus;
    }

    public void PutData(MemberInqBasicPointDayStatus pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mibpds_SaleDate = pSource.mibpds_SaleDate;
      this.mibpds_SiteID = pSource.mibpds_SiteID;
      this.mibpds_AddPoint = pSource.mibpds_AddPoint;
      this.mibpds_AddMbrCnt = pSource.mibpds_AddMbrCnt;
      this.mibpds_AfAddPoint = pSource.mibpds_AfAddPoint;
      this.mibpds_AfAddMbrCnt = pSource.mibpds_AfAddMbrCnt;
      this.mibpds_MlAddPoint = pSource.mibpds_MlAddPoint;
      this.mibpds_MlAddMbrCnt = pSource.mibpds_MlAddMbrCnt;
      this.mibpds_UsePoint = pSource.mibpds_UsePoint;
      this.mibpds_UseMbrCnt = pSource.mibpds_UseMbrCnt;
      this.mibpds_ExtinctPoint = pSource.mibpds_ExtinctPoint;
      this.mibpds_ExtinctMbrCnt = pSource.mibpds_ExtinctMbrCnt;
      this.mibpds_MlUsePoint = pSource.mibpds_MlUsePoint;
      this.mibpds_MlUseMbrCnt = pSource.mibpds_MlUseMbrCnt;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mibpds_SaleDate = p_rs.GetFieldDateTime("mibpds_SaleDate");
        this.mibpds_SiteID = p_rs.GetFieldLong("mibpds_SiteID");
        if (this.mibpds_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mibpds_AddPoint = p_rs.GetFieldInt("mibpds_AddPoint");
        this.mibpds_AddMbrCnt = p_rs.GetFieldInt("mibpds_AddMbrCnt");
        this.mibpds_AfAddPoint = p_rs.GetFieldInt("mibpds_AfAddPoint");
        this.mibpds_AfAddMbrCnt = p_rs.GetFieldInt("mibpds_AfAddMbrCnt");
        this.mibpds_MlAddPoint = p_rs.GetFieldInt("mibpds_MlAddPoint");
        this.mibpds_MlAddMbrCnt = p_rs.GetFieldInt("mibpds_MlAddMbrCnt");
        this.mibpds_UsePoint = p_rs.GetFieldInt("mibpds_UsePoint");
        this.mibpds_UseMbrCnt = p_rs.GetFieldInt("mibpds_UseMbrCnt");
        this.mibpds_ExtinctPoint = p_rs.GetFieldInt("mibpds_ExtinctPoint");
        this.mibpds_ExtinctMbrCnt = p_rs.GetFieldInt("mibpds_ExtinctMbrCnt");
        this.mibpds_MlUsePoint = p_rs.GetFieldInt("mibpds_MlUsePoint");
        this.mibpds_MlUseMbrCnt = p_rs.GetFieldInt("mibpds_MlUseMbrCnt");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<MemberInqBasicPointDayStatus>> SelectListAsync(object p_param)
    {
      MemberInqBasicPointDayStatus basicPointDayStatus1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(basicPointDayStatus1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, basicPointDayStatus1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(basicPointDayStatus1.GetSelectQuery(p_param)))
        {
          basicPointDayStatus1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + basicPointDayStatus1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBasicPointDayStatus>) null;
        }
        IList<MemberInqBasicPointDayStatus> lt_list = (IList<MemberInqBasicPointDayStatus>) new List<MemberInqBasicPointDayStatus>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBasicPointDayStatus basicPointDayStatus2 = basicPointDayStatus1.OleDB.Create<MemberInqBasicPointDayStatus>();
            if (basicPointDayStatus2.GetFieldValues(rs))
            {
              basicPointDayStatus2.row_number = lt_list.Count + 1;
              lt_list.Add(basicPointDayStatus2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + basicPointDayStatus1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBasicPointDayStatus> SelectEnumerableAsync(object p_param)
    {
      MemberInqBasicPointDayStatus basicPointDayStatus1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(basicPointDayStatus1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, basicPointDayStatus1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(basicPointDayStatus1.GetSelectQuery(p_param)))
        {
          basicPointDayStatus1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + basicPointDayStatus1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBasicPointDayStatus basicPointDayStatus2 = basicPointDayStatus1.OleDB.Create<MemberInqBasicPointDayStatus>();
            if (basicPointDayStatus2.GetFieldValues(rs))
            {
              basicPointDayStatus2.row_number = ++row_number;
              yield return basicPointDayStatus2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mibpds_SiteID") && Convert.ToInt64(hashtable[(object) "mibpds_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mibpds_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mibpds_SaleDate") && !string.IsNullOrEmpty(hashtable[(object) "mibpds_SaleDate"].ToString()))
          stringBuilder.Append(" AND mibpds_SaleDate<=" + new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mibpds_SaleDate>=" + new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mibpds_SaleDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mibpds_SaleDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mibpds_SaleDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mibpds_SaleDate_END_"].ToString()))
          stringBuilder.Append(" AND mibpds_SaleDate<=" + new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mibpds_SaleDate>=" + new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mibpds_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        string str1 = string.Empty;
        string str2 = string.Empty;
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mibpds_SiteID") && Convert.ToInt64(hashtable[(object) "mibpds_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "mibpds_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "mibpds_SaleDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mibpds_SaleDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mibpds_SaleDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mibpds_SaleDate_END_"].ToString()))
          {
            str1 = new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") ?? "";
            str2 = new DateTime?((DateTime) hashtable[(object) "mibpds_SaleDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") ?? "";
          }
        }
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
          throw new Exception("일자 구성 오류");
        stringBuilder.Append("WITH T_DATE AS (\nSELECT DATEADD(dd, RowNum - 1, " + str1 + ") AS mibpds_SaleDate, RowNum\nFROM (SELECT ROW_NUMBER() OVER (ORDER BY pm_MenuCode) AS RowNum" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenu, (object) DbQueryHelper.ToWithNolock()) + "\nWHERE RowNum <= DATEDIFF(dd, " + str1 + ", " + str2 + ") + 1)");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_MemberMntStore"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName,mbr_MemberType,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_SiteID=mbr_SiteID AND si_StoreCode=mbr_RegStore");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SiteID"))
            p_param1.Add((object) "mbr_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mbr_SiteID"))
            p_param1.Add((object) "mbr_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMember().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mbr_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_POINT_BASE AS (\nSELECT mph_SysDate\n,SUM(CASE WHEN mph_PointType<>2 AND mph_SysDate=mph_SaleDate THEN mph_TodayAddPoint ELSE 0 END) AS mibpds_AddPoint\n,COUNT(DISTINCT CASE WHEN mph_PointType<>2 AND mph_TodayAddPoint<>0 AND mph_SysDate=mph_SaleDate THEN mph_MemberNo ELSE NULL END) AS mibpds_AddMbrCnt\n,SUM(CASE WHEN mph_PointType<>2 AND mph_SysDate<>mph_SaleDate THEN mph_TodayAddPoint ELSE 0 END) AS mibpds_AfAddPoint\n,COUNT(DISTINCT CASE WHEN mph_PointType<>2 AND mph_TodayAddPoint<>0 AND mph_SysDate<>mph_SaleDate THEN mph_MemberNo ELSE NULL END) AS mibpds_AfAddMbrCnt\n,SUM(CASE WHEN mph_PointType=2 THEN mph_TodayAddPoint ELSE 0 END) AS mibpds_MlAddPoint\n,COUNT(DISTINCT CASE WHEN mph_PointType=2 AND mph_TodayAddPoint<>0 THEN mph_MemberNo ELSE NULL END) AS mibpds_MlAddMbrCnt\n,SUM(mph_TodayUsePoint) AS mibpds_UsePoint\n,COUNT(CASE WHEN mph_TodayUsePoint<>0 THEN mph_MemberNo ELSE NULL END) AS mibpds_UseMbrCnt\n,SUM(CASE WHEN mph_PointType=2 THEN mph_TodayUsePoint ELSE 0 END) AS mibpds_MlUsePoint\n,COUNT(CASE WHEN mph_PointType=2 AND mph_TodayUsePoint<>0 THEN mph_MemberNo ELSE NULL END) AS mibpds_MlUseMbrCnt" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberPointHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_SiteID=mph_SiteID AND si_StoreCode=mph_StoreCode");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SiteID"))
            p_param1.Add((object) "mph_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SaleDate_BEGIN_"))
            p_param1.Add((object) "mph_SysDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SaleDate_END_"))
            p_param1.Add((object) "mph_SysDate_END_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mph_SiteID"))
            p_param1.Add((object) "mph_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMemberPointHistory().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "mph_SiteID", (object) num));
        stringBuilder.Append("\nGROUP BY mph_SysDate");
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_POINT_EXTINCT AS (\nSELECT mpe_Date\n,SUM(mpe_ExtinctionPoint) AS mibpds_AddPoint\n,COUNT(DISTINCT mpe_MemberNo) AS mibpds_ExtinctMbrCnt" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberPointExtinction, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_MEMBER ON mpe_MemberNo=mbr_MemberNo AND mpe_SiteID=mbr_SiteID           AND a.mpe_Date BETWEEN '%s' AND '%s' -- 소멸예정일\n           AND a.mpe_ExtinctionPoint <> 0 -- 소멸포인트\n           AND a.mpe_SiteID = %d -- 사이트ID\n");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SiteID"))
            p_param1.Add((object) "mpe_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SaleDate_BEGIN_"))
            p_param1.Add((object) "mpe_Date_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mibpds_SaleDate_END_"))
            p_param1.Add((object) "mpe_Date_END_", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mpe_SiteID"))
            p_param1.Add((object) "mpe_SiteID", (object) num);
          if (!p_param1.ContainsKey((object) "mpe_ExtinctionPoint_IS_NOT_DATA_VALUE_ZERO_"))
            p_param1.Add((object) "mpe_ExtinctionPoint_IS_NOT_DATA_VALUE_ZERO_", (object) true);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMemberPointExtinction().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mpe_SiteID", (object) num));
        stringBuilder.Append("\nGROUP BY mpe_Date");
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mibpds_SaleDate\n,ISNULL(mibpds_AddPoint, 0) AS mibpds_AddPoint,ISNULL(mibpds_AddMbrCnt, 0) AS mibpds_AddMbrCnt,ISNULL(mibpds_AfAddPoint, 0) AS mibpds_AfAddPoint,ISNULL(mibpds_AfAddMbrCnt, 0) AS mibpds_AfAddMbrCnt,ISNULL(mibpds_MlAddPoint, 0) AS mibpds_MlAddPoint,ISNULL(mibpds_MlAddMbrCnt, 0) AS mibpds_MlAddMbrCnt\n,ISNULL(mibpds_UsePoint, 0) AS mibpds_UsePoint,ISNULL(mibpds_UseMbrCnt, 0) AS mibpds_UseMbrCnt,ISNULL(mibpds_ExtinctPoint, 0) AS mibpds_ExtinctPoint,ISNULL(mibpds_ExtinctMbrCnt, 0) AS mibpds_ExtinctMbrCnt,ISNULL(mibpds_MlUsePoint, 0) AS mibpds_MlUsePoint,ISNULL(mibpds_MlUseMbrCnt, 0) AS mibpds_MlUseMbrCnt\nFROM T_DATE\nLEFT OUTER JOIN T_POINT_BASE ON mibpds_SaleDate=mph_SysDate\nLEFT OUTER JOIN T_POINT_EXTINCT ON mibpds_SaleDate=mpe_Date");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mibpds_SaleDate");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
