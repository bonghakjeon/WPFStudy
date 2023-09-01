// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.Basic.MemberInqBasicCycleChgHisHeader
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Inq.Basic
{
  public class MemberInqBasicCycleChgHisHeader : UbModelBase<MemberInqBasicCycleChgHisHeader>
  {
    private DateTime? _mcch_ChgDate;
    private int _mcch_NewMemberCycle;
    private long _mcch_SiteID;
    private int _mbrCnt;
    private double _mbrCntRate;
    private int _upChgMbrCnt;
    private double _upChgRate;
    private int _noChgMbrCnt;
    private double _noChgRate;
    private int _downChgMbrCnt;
    private double _downChgRate;
    private IList<MemberInqBasicCycleChgHisDetail> _Lt_Details;

    public override object _Key => (object) new object[2]
    {
      (object) this.mcch_ChgDate,
      (object) this.mcch_NewMemberCycle
    };

    public DateTime? mcch_ChgDate
    {
      get => this._mcch_ChgDate;
      set
      {
        this._mcch_ChgDate = value;
        this.Changed(nameof (mcch_ChgDate));
      }
    }

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

    public long mcch_SiteID
    {
      get => this._mcch_SiteID;
      set
      {
        this._mcch_SiteID = value;
        this.Changed(nameof (mcch_SiteID));
      }
    }

    public int mbrCnt
    {
      get => this._mbrCnt;
      set
      {
        this._mbrCnt = value;
        this.Changed(nameof (mbrCnt));
      }
    }

    public double mbrCntRate
    {
      get => this._mbrCntRate;
      set
      {
        this._mbrCntRate = value;
        this.Changed(nameof (mbrCntRate));
      }
    }

    public int upChgMbrCnt
    {
      get => this._upChgMbrCnt;
      set
      {
        this._upChgMbrCnt = value;
        this.Changed(nameof (upChgMbrCnt));
      }
    }

    public double upChgRate
    {
      get => this._upChgRate;
      set
      {
        this._upChgRate = value;
        this.Changed(nameof (upChgRate));
      }
    }

    public int noChgMbrCnt
    {
      get => this._noChgMbrCnt;
      set
      {
        this._noChgMbrCnt = value;
        this.Changed(nameof (noChgMbrCnt));
      }
    }

    public double noChgRate
    {
      get => this._noChgRate;
      set
      {
        this._noChgRate = value;
        this.Changed(nameof (noChgRate));
      }
    }

    public int downChgMbrCnt
    {
      get => this._downChgMbrCnt;
      set
      {
        this._downChgMbrCnt = value;
        this.Changed(nameof (downChgMbrCnt));
      }
    }

    public double downChgRate
    {
      get => this._downChgRate;
      set
      {
        this._downChgRate = value;
        this.Changed(nameof (downChgRate));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<MemberInqBasicCycleChgHisDetail> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<MemberInqBasicCycleChgHisDetail>) new List<MemberInqBasicCycleChgHisDetail>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public MemberInqBasicCycleChgHisHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mcch_ChgDate", new TTableColumn()
      {
        tc_orgin_name = "mcch_ChgDate",
        tc_trans_name = "주기변경일자",
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("mcch_NewMemberCycle", new TTableColumn()
      {
        tc_orgin_name = "mcch_NewMemberCycle",
        tc_trans_name = "신회원주기",
        tc_comm_code = 191,
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("mcch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mcch_SiteID",
        tc_trans_name = "싸이트",
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("mbrCnt", new TTableColumn()
      {
        tc_orgin_name = "mbrCnt",
        tc_trans_name = "회원수",
        tc_parents_name = "합계"
      });
      columnInfo.Add("mbrCntRate", new TTableColumn()
      {
        tc_orgin_name = "mbrCntRate",
        tc_trans_name = "구성비",
        tc_parents_name = "합계"
      });
      columnInfo.Add("upChgMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "upChgMbrCnt",
        tc_trans_name = "Up회원수",
        tc_parents_name = "구성상세"
      });
      columnInfo.Add("upChgRate", new TTableColumn()
      {
        tc_orgin_name = "upChgRate",
        tc_trans_name = "비율",
        tc_parents_name = "구성상세"
      });
      columnInfo.Add("noChgMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "noChgMbrCnt",
        tc_trans_name = "유지회원수",
        tc_parents_name = "구성상세"
      });
      columnInfo.Add("noChgRate", new TTableColumn()
      {
        tc_orgin_name = "noChgRate",
        tc_trans_name = "비율",
        tc_parents_name = "구성상세"
      });
      columnInfo.Add("downChgMbrCnt", new TTableColumn()
      {
        tc_orgin_name = "downChgMbrCnt",
        tc_trans_name = "Down회원수",
        tc_parents_name = "구성상세"
      });
      columnInfo.Add("downChgRate", new TTableColumn()
      {
        tc_orgin_name = "downChgRate",
        tc_trans_name = "비율",
        tc_parents_name = "구성상세"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCycleChgHistory;
      this.mcch_ChgDate = new DateTime?();
      this.mcch_NewMemberCycle = 0;
      this.mcch_SiteID = 0L;
      this.mbrCnt = 0;
      this.mbrCntRate = 0.0;
      this.upChgMbrCnt = 0;
      this.upChgRate = 0.0;
      this.noChgMbrCnt = 0;
      this.noChgRate = 0.0;
      this.downChgMbrCnt = 0;
      this.downChgRate = 0.0;
      this.Lt_Details = (IList<MemberInqBasicCycleChgHisDetail>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBasicCycleChgHisHeader();

    public override object Clone()
    {
      MemberInqBasicCycleChgHisHeader cycleChgHisHeader = base.Clone() as MemberInqBasicCycleChgHisHeader;
      cycleChgHisHeader.mcch_ChgDate = this.mcch_ChgDate;
      cycleChgHisHeader.mcch_NewMemberCycle = this.mcch_NewMemberCycle;
      cycleChgHisHeader.mcch_SiteID = this.mcch_SiteID;
      cycleChgHisHeader.mbrCnt = this.mbrCnt;
      cycleChgHisHeader.mbrCntRate = this.mbrCntRate;
      cycleChgHisHeader.upChgMbrCnt = this.upChgMbrCnt;
      cycleChgHisHeader.upChgRate = this.upChgRate;
      cycleChgHisHeader.noChgMbrCnt = this.noChgMbrCnt;
      cycleChgHisHeader.noChgRate = this.noChgRate;
      cycleChgHisHeader.downChgMbrCnt = this.downChgMbrCnt;
      cycleChgHisHeader.downChgRate = this.downChgRate;
      cycleChgHisHeader.Lt_Details = this.Lt_Details;
      return (object) cycleChgHisHeader;
    }

    public void PutData(MemberInqBasicCycleChgHisHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mcch_ChgDate = pSource.mcch_ChgDate;
      this.mcch_NewMemberCycle = pSource.mcch_NewMemberCycle;
      this.mcch_SiteID = pSource.mcch_SiteID;
      this.mbrCnt = pSource.mbrCnt;
      this.mbrCntRate = pSource.mbrCntRate;
      this.upChgMbrCnt = pSource.upChgMbrCnt;
      this.upChgRate = pSource.upChgRate;
      this.noChgMbrCnt = pSource.noChgMbrCnt;
      this.noChgRate = pSource.noChgRate;
      this.downChgMbrCnt = pSource.downChgMbrCnt;
      this.downChgRate = pSource.downChgRate;
      this.Lt_Details = (IList<MemberInqBasicCycleChgHisDetail>) null;
      foreach (MemberInqBasicCycleChgHisDetail ltDetail in (IEnumerable<MemberInqBasicCycleChgHisDetail>) pSource.Lt_Details)
      {
        MemberInqBasicCycleChgHisDetail cycleChgHisDetail = new MemberInqBasicCycleChgHisDetail();
        cycleChgHisDetail.PutData(ltDetail);
        this.Lt_Details.Add(cycleChgHisDetail);
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mcch_ChgDate = p_rs.GetFieldDateTime("mcch_ChgDate");
        this.mcch_NewMemberCycle = p_rs.GetFieldInt("mcch_NewMemberCycle");
        if (this.mcch_NewMemberCycle == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mcch_SiteID = p_rs.GetFieldLong("mcch_SiteID");
        this.mbrCnt = p_rs.GetFieldInt("mbrCnt");
        this.mbrCntRate = p_rs.GetFieldDouble("mbrCntRate");
        this.upChgMbrCnt = p_rs.GetFieldInt("upChgMbrCnt");
        this.upChgRate = p_rs.GetFieldDouble("upChgRate");
        this.noChgMbrCnt = p_rs.GetFieldInt("noChgMbrCnt");
        this.noChgRate = p_rs.GetFieldDouble("noChgRate");
        this.downChgMbrCnt = p_rs.GetFieldInt("downChgMbrCnt");
        this.downChgRate = p_rs.GetFieldDouble("downChgRate");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<MemberInqBasicCycleChgHisHeader>> SelectListAsync(object p_param)
    {
      MemberInqBasicCycleChgHisHeader cycleChgHisHeader1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(cycleChgHisHeader1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, cycleChgHisHeader1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(cycleChgHisHeader1.GetSelectQuery(p_param)))
        {
          cycleChgHisHeader1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBasicCycleChgHisHeader>) null;
        }
        IList<MemberInqBasicCycleChgHisHeader> lt_list = (IList<MemberInqBasicCycleChgHisHeader>) new List<MemberInqBasicCycleChgHisHeader>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBasicCycleChgHisHeader cycleChgHisHeader2 = cycleChgHisHeader1.OleDB.Create<MemberInqBasicCycleChgHisHeader>();
            if (cycleChgHisHeader2.GetFieldValues(rs))
            {
              cycleChgHisHeader2.row_number = lt_list.Count + 1;
              lt_list.Add(cycleChgHisHeader2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBasicCycleChgHisHeader> SelectEnumerableAsync(
      object p_param)
    {
      MemberInqBasicCycleChgHisHeader cycleChgHisHeader1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(cycleChgHisHeader1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, cycleChgHisHeader1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(cycleChgHisHeader1.GetSelectQuery(p_param)))
        {
          cycleChgHisHeader1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBasicCycleChgHisHeader cycleChgHisHeader2 = cycleChgHisHeader1.OleDB.Create<MemberInqBasicCycleChgHisHeader>();
            if (cycleChgHisHeader2.GetFieldValues(rs))
            {
              cycleChgHisHeader2.row_number = ++row_number;
              yield return cycleChgHisHeader2;
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
        if (hashtable.ContainsKey((object) "mcch_SiteID") && Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString());
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mcch_NewMemberCycle") && Convert.ToInt32(hashtable[(object) "mcch_NewMemberCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcch_NewMemberCycle", hashtable[(object) "mcch_NewMemberCycle"]));
        if (hashtable.ContainsKey((object) "mcch_ChgDate") && !string.IsNullOrEmpty(hashtable[(object) "mcch_ChgDate"].ToString()))
          stringBuilder.Append(" AND mcch_ChgDate<=" + new DateTime?((DateTime) hashtable[(object) "mcch_ChgDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcch_ChgDate>=" + new DateTime?((DateTime) hashtable[(object) "mcch_ChgDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mcch_ChgDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_ChgDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mcch_ChgDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mcch_ChgDate_END_"].ToString()))
          stringBuilder.Append(" AND mcch_ChgDate<=" + new DateTime?((DateTime) hashtable[(object) "mcch_ChgDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcch_ChgDate>=" + new DateTime?((DateTime) hashtable[(object) "mcch_ChgDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
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
        long num1 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mcch_SiteID") && Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "mcch_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mcch_SiteID"))
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
            p_param1.Add((object) "si_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName,mbr_Birthday,mbr_MobileNo,mbr_MobileNoEnc,mbr_SmsSendAgree,mbr_RegStore" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_SiteID=mbr_SiteID AND si_StoreCode=mbr_RegStore)");
        int num2 = 5;
        stringBuilder.Append("\n,T_BASE AS (\nSELECT mcch_ChgDate,mcch_NewMemberCycle,mcch_SiteID,SUM(1) AS mbrCnt" + string.Format(",SUM(CASE WHEN CASE {0} WHEN {1} THEN -1 ELSE {2} END > CASE {3} WHEN {4} THEN -1 ELSE {5} END THEN 1 ELSE 0 END)", (object) "mcch_NewMemberCycle", (object) num2, (object) "mcch_NewMemberCycle", (object) "mcch_OldMemberCycle", (object) num2, (object) "mcch_OldMemberCycle") + " AS upChgMbrCnt,SUM(CASE WHEN mcch_NewMemberCycle=mcch_OldMemberCycle THEN 1 ELSE 0 END) AS noChgMbrCnt" + string.Format(",SUM(CASE WHEN CASE {0} WHEN {1} THEN -1 ELSE {2} END < CASE a.mcch_OldMemberCycle WHEN 5 THEN -1 ELSE a.mcch_OldMemberCycle END THEN 1 ELSE 0 END)", (object) "mcch_NewMemberCycle", (object) num2, (object) "mcch_NewMemberCycle") + " AS downChgMbrCnt" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberCycleChgHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_MEMBER ON mcch_MemberNo=mbr_MemberNo AND mcch_SiteID=mbr_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        stringBuilder.Append("\nGROUP BY mcch_ChgDate,mcch_NewMemberCycle,mcch_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mcch_ChgDate,mcch_NewMemberCycle,mcch_SiteID,mbrCnt" + string.Format(",CASE SUM({0}) OVER(PARTITION BY {1}) WHEN 0 THEN 0 ELSE ROUND(({2} * 1.0)/SUM({3}) OVER(PARTITION BY {4}), {5}) * 100 END AS {6}", (object) "mbrCnt", (object) "mcch_ChgDate", (object) "mbrCnt", (object) "mbrCnt", (object) "mcch_ChgDate", (object) num2, (object) "mbrCntRate") + ",upChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "upChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "upChgRate") + ",noChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "noChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "noChgRate") + ",CASE downChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "downChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "downChgRate") + "\nFROM T_BASE");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mcch_ChgDate,mcch_NewMemberCycle");
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
