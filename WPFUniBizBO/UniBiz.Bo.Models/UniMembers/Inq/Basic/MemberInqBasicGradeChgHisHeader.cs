// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.Basic.MemberInqBasicGradeChgHisHeader
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
  public class MemberInqBasicGradeChgHisHeader : UbModelBase<MemberInqBasicGradeChgHisHeader>
  {
    private DateTime? _mgch_ChgDate;
    private int _mgch_NewMemberGrade;
    private long _mgch_SiteID;
    private string _newMemberGradeName;
    private int _mbrCnt;
    private double _mbrCntRate;
    private int _upChgMbrCnt;
    private double _upChgRate;
    private int _noChgMbrCnt;
    private double _noChgRate;
    private int _downChgMbrCnt;
    private double _downChgRate;
    private IList<MemberInqBasicGradeChgHisDetail> _Lt_Details;

    public override object _Key => (object) new object[2]
    {
      (object) this.mgch_ChgDate,
      (object) this.mgch_NewMemberGrade
    };

    public DateTime? mgch_ChgDate
    {
      get => this._mgch_ChgDate;
      set
      {
        this._mgch_ChgDate = value;
        this.Changed(nameof (mgch_ChgDate));
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

    public long mgch_SiteID
    {
      get => this._mgch_SiteID;
      set
      {
        this._mgch_SiteID = value;
        this.Changed(nameof (mgch_SiteID));
      }
    }

    public string newMemberGradeName
    {
      get => this._newMemberGradeName;
      set
      {
        this._newMemberGradeName = value;
        this.Changed(nameof (newMemberGradeName));
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
    public IList<MemberInqBasicGradeChgHisDetail> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<MemberInqBasicGradeChgHisDetail>) new List<MemberInqBasicGradeChgHisDetail>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public MemberInqBasicGradeChgHisHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mgch_ChgDate", new TTableColumn()
      {
        tc_orgin_name = "mgch_ChgDate",
        tc_trans_name = "등급변경일자",
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("mgch_NewMemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mgch_NewMemberGrade",
        tc_trans_name = "신회원등급",
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("mgch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mgch_SiteID",
        tc_trans_name = "싸이트",
        tc_parents_name = "변경정보"
      });
      columnInfo.Add("newMemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "newMemberGradeName",
        tc_trans_name = "신회원등급명",
        tc_parents_name = "변경정보",
        tc_col_status = 2
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
      this.TableCode = TableCodeType.MemberGradeChgHistory;
      this.mgch_ChgDate = new DateTime?();
      this.mgch_NewMemberGrade = 0;
      this.mgch_SiteID = 0L;
      this.newMemberGradeName = string.Empty;
      this.mbrCnt = 0;
      this.mbrCntRate = 0.0;
      this.upChgMbrCnt = 0;
      this.upChgRate = 0.0;
      this.noChgMbrCnt = 0;
      this.noChgRate = 0.0;
      this.downChgMbrCnt = 0;
      this.downChgRate = 0.0;
      this.Lt_Details = (IList<MemberInqBasicGradeChgHisDetail>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBasicGradeChgHisHeader();

    public override object Clone()
    {
      MemberInqBasicGradeChgHisHeader gradeChgHisHeader = base.Clone() as MemberInqBasicGradeChgHisHeader;
      gradeChgHisHeader.mgch_ChgDate = this.mgch_ChgDate;
      gradeChgHisHeader.mgch_NewMemberGrade = this.mgch_NewMemberGrade;
      gradeChgHisHeader.mgch_SiteID = this.mgch_SiteID;
      gradeChgHisHeader.newMemberGradeName = this.newMemberGradeName;
      gradeChgHisHeader.mbrCnt = this.mbrCnt;
      gradeChgHisHeader.mbrCntRate = this.mbrCntRate;
      gradeChgHisHeader.upChgMbrCnt = this.upChgMbrCnt;
      gradeChgHisHeader.upChgRate = this.upChgRate;
      gradeChgHisHeader.noChgMbrCnt = this.noChgMbrCnt;
      gradeChgHisHeader.noChgRate = this.noChgRate;
      gradeChgHisHeader.downChgMbrCnt = this.downChgMbrCnt;
      gradeChgHisHeader.downChgRate = this.downChgRate;
      gradeChgHisHeader.Lt_Details = this.Lt_Details;
      return (object) gradeChgHisHeader;
    }

    public void PutData(MemberInqBasicGradeChgHisHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mgch_ChgDate = pSource.mgch_ChgDate;
      this.mgch_NewMemberGrade = pSource.mgch_NewMemberGrade;
      this.mgch_SiteID = pSource.mgch_SiteID;
      this.newMemberGradeName = pSource.newMemberGradeName;
      this.mbrCnt = pSource.mbrCnt;
      this.mbrCntRate = pSource.mbrCntRate;
      this.upChgMbrCnt = pSource.upChgMbrCnt;
      this.upChgRate = pSource.upChgRate;
      this.noChgMbrCnt = pSource.noChgMbrCnt;
      this.noChgRate = pSource.noChgRate;
      this.downChgMbrCnt = pSource.downChgMbrCnt;
      this.downChgRate = pSource.downChgRate;
      this.Lt_Details = (IList<MemberInqBasicGradeChgHisDetail>) null;
      foreach (MemberInqBasicGradeChgHisDetail ltDetail in (IEnumerable<MemberInqBasicGradeChgHisDetail>) pSource.Lt_Details)
      {
        MemberInqBasicGradeChgHisDetail gradeChgHisDetail = new MemberInqBasicGradeChgHisDetail();
        gradeChgHisDetail.PutData(ltDetail);
        this.Lt_Details.Add(gradeChgHisDetail);
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mgch_ChgDate = p_rs.GetFieldDateTime("mgch_ChgDate");
        this.mgch_NewMemberGrade = p_rs.GetFieldInt("mgch_NewMemberGrade");
        if (this.mgch_NewMemberGrade == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mgch_SiteID = p_rs.GetFieldLong("mgch_SiteID");
        this.mbrCnt = p_rs.GetFieldInt("mbrCnt");
        this.newMemberGradeName = p_rs.GetFieldString("newMemberGradeName");
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

    public async Task<IList<MemberInqBasicGradeChgHisHeader>> SelectListAsync(object p_param)
    {
      MemberInqBasicGradeChgHisHeader gradeChgHisHeader1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeChgHisHeader1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeChgHisHeader1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeChgHisHeader1.GetSelectQuery(p_param)))
        {
          gradeChgHisHeader1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBasicGradeChgHisHeader>) null;
        }
        IList<MemberInqBasicGradeChgHisHeader> lt_list = (IList<MemberInqBasicGradeChgHisHeader>) new List<MemberInqBasicGradeChgHisHeader>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBasicGradeChgHisHeader gradeChgHisHeader2 = gradeChgHisHeader1.OleDB.Create<MemberInqBasicGradeChgHisHeader>();
            if (gradeChgHisHeader2.GetFieldValues(rs))
            {
              gradeChgHisHeader2.row_number = lt_list.Count + 1;
              lt_list.Add(gradeChgHisHeader2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBasicGradeChgHisHeader> SelectEnumerableAsync(
      object p_param)
    {
      MemberInqBasicGradeChgHisHeader gradeChgHisHeader1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeChgHisHeader1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeChgHisHeader1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeChgHisHeader1.GetSelectQuery(p_param)))
        {
          gradeChgHisHeader1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisHeader1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBasicGradeChgHisHeader gradeChgHisHeader2 = gradeChgHisHeader1.OleDB.Create<MemberInqBasicGradeChgHisHeader>();
            if (gradeChgHisHeader2.GetFieldValues(rs))
            {
              gradeChgHisHeader2.row_number = ++row_number;
              yield return gradeChgHisHeader2;
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
        if (hashtable.ContainsKey((object) "mgch_SiteID") && Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString());
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mgch_NewMemberGrade") && Convert.ToInt32(hashtable[(object) "mgch_NewMemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgch_NewMemberGrade", hashtable[(object) "mgch_NewMemberGrade"]));
        if (hashtable.ContainsKey((object) "mgch_ChgDate") && !string.IsNullOrEmpty(hashtable[(object) "mgch_ChgDate"].ToString()))
          stringBuilder.Append(" AND mgch_ChgDate<=" + new DateTime?((DateTime) hashtable[(object) "mgch_ChgDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgch_ChgDate>=" + new DateTime?((DateTime) hashtable[(object) "mgch_ChgDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mgch_ChgDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_ChgDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mgch_ChgDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mgch_ChgDate_END_"].ToString()))
          stringBuilder.Append(" AND mgch_ChgDate<=" + new DateTime?((DateTime) hashtable[(object) "mgch_ChgDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgch_ChgDate>=" + new DateTime?((DateTime) hashtable[(object) "mgch_ChgDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "newMemberGradeName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
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
          if (hashtable.ContainsKey((object) "mgch_SiteID") && Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mgch_SiteID"))
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
        stringBuilder.Append("\n,T_MEMBER_GRADE_NEW AS (\nSELECT mgd_MemberGrade AS new_mgd_MemberGrade,mgd_SiteID AS new_mgd_SiteID,mgd_MemberGradeName AS new_mgd_MemberGradeName,mgd_SortNo AS new_mgd_SortNo" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num1) + ")");
        stringBuilder.Append("\n,T_MEMBER_GRADE_OLD AS (\nSELECT mgd_MemberGrade AS old_mgd_MemberGrade,mgd_SiteID AS old_mgd_SiteID,mgd_MemberGradeName AS old_mgd_MemberGradeName,mgd_SortNo AS old_mgd_SortNo" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num1) + ")");
        stringBuilder.Append("\n,T_BASE AS (\nSELECT mgch_ChgDate,mgch_NewMemberGrade,mgch_SiteID,SUM(1) AS mbrCnt,MAX(new_mgd_MemberGradeName) AS newMemberGradeName,SUM(CASE WHEN new_mgd_SortNo < old_mgd_SortNo THEN 1 ELSE 0 END) AS upChgMbrCnt,SUM(CASE WHEN new_mgd_SortNo = old_mgd_SortNo THEN 1 ELSE 0 END) AS noChgMbrCnt,SUM(CASE WHEN new_mgd_SortNo > old_mgd_SortNo THEN 1 ELSE 0 END) AS downChgMbrCnt" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGradeChgHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_MEMBER ON mgch_MemberNo=mbr_MemberNo AND mgch_SiteID=mbr_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE_NEW ON mgch_NewMemberGrade=new_mgd_MemberGrade AND mgch_SiteID=new_mgd_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE_OLD ON mgch_OldMemberGrade=old_mgd_MemberGrade AND mgch_SiteID=old_mgd_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        stringBuilder.Append("\nGROUP BY mgch_ChgDate,mgch_NewMemberGrade,mgch_SiteID");
        stringBuilder.Append(")");
        int num2 = 5;
        stringBuilder.Append("\nSELECT  mgch_ChgDate,mgch_NewMemberGrade,mgch_SiteID,newMemberGradeName,mbrCnt" + string.Format(",CASE SUM({0}) OVER(PARTITION BY {1}) WHEN 0 THEN 0 ELSE ROUND(({2} * 1.0)/SUM({3}) OVER(PARTITION BY {4}), {5}) * 100 END AS {6}", (object) "mbrCnt", (object) "mgch_ChgDate", (object) "mbrCnt", (object) "mbrCnt", (object) "mgch_ChgDate", (object) num2, (object) "mbrCntRate") + ",upChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "upChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "upChgRate") + ",noChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "noChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "noChgRate") + ",CASE downChgMbrCnt" + string.Format(",CASE {0} WHEN 0 THEN 0 ELSE ROUND(({1} * 1.0)/{2}, {3}) * 100 END AS {4}", (object) "mbrCnt", (object) "downChgMbrCnt", (object) "mbrCnt", (object) num2, (object) "downChgRate") + "\nFROM T_BASE");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mgch_ChgDate,mgch_NewMemberGrade");
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
