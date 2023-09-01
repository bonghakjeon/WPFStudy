// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.Basic.MemberInqBasicCycleChgHisDetail
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
using UniBiz.Bo.Models.UniMembers.History.MemberCycleChgHistory;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Inq.Basic
{
  public class MemberInqBasicCycleChgHisDetail : 
    TMemberCycleChgHistory<MemberInqBasicCycleChgHisDetail>
  {
    private string _mbr_MemberName;
    private DateTime? _mbr_Birthday;
    private string _mbr_MobileNo;
    private string _mbr_MobileNoEnc;
    private int _mbr_SmsSendAgree;
    private int _upDownDiv;

    public string mbr_MemberName
    {
      get => this._mbr_MemberName;
      set
      {
        this._mbr_MemberName = value;
        this.Changed(nameof (mbr_MemberName));
      }
    }

    [JsonIgnore]
    public DateTime? mbr_Birthday
    {
      get => this._mbr_Birthday;
      set
      {
        this._mbr_Birthday = value;
        this.Changed(nameof (mbr_Birthday));
        this.Changed("mbr_Age");
      }
    }

    public int mbr_Age => this.mbr_Birthday.HasValue ? DateHelper.ToAge(this.mbr_Birthday) : 0;

    public string mbr_MobileNo
    {
      get => this._mbr_MobileNo;
      set
      {
        this._mbr_MobileNo = value;
        this.Changed(nameof (mbr_MobileNo));
      }
    }

    public string mbr_MobileNoEnc
    {
      get => this._mbr_MobileNoEnc;
      set
      {
        this._mbr_MobileNoEnc = value;
        this.Changed(nameof (mbr_MobileNoEnc));
      }
    }

    public int mbr_SmsSendAgree
    {
      get => this._mbr_SmsSendAgree;
      set
      {
        this._mbr_SmsSendAgree = value;
        this.Changed(nameof (mbr_SmsSendAgree));
        this.Changed("mbr_SmsSendAgreeDesc");
      }
    }

    public string mbr_SmsSendAgreeDesc => this.mbr_SmsSendAgree != 0 ? Enum2StrConverter.ToSmsSendAgree(this.mbr_SmsSendAgree).ToDescription() : string.Empty;

    public int upDownDiv
    {
      get => this._upDownDiv;
      set
      {
        this._upDownDiv = value;
        this.Changed(nameof (upDownDiv));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_MemberName", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberName",
        tc_trans_name = "회원명",
        tc_parents_name = TableCodeType.Member.ToDescription(),
        tc_col_status = 1
      });
      columnInfo.Add("mbr_Age", new TTableColumn()
      {
        tc_orgin_name = "mbr_Age",
        tc_trans_name = "나이",
        tc_parents_name = TableCodeType.Member.ToDescription(),
        tc_col_status = 1
      });
      columnInfo.Add("mbr_MobileNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_MobileNo",
        tc_trans_name = "모바일",
        tc_parents_name = TableCodeType.Member.ToDescription(),
        tc_col_status = 1
      });
      columnInfo.Add("mbr_MobileNoEnc", new TTableColumn()
      {
        tc_orgin_name = "mbr_MobileNoEnc",
        tc_trans_name = "모바일",
        tc_parents_name = TableCodeType.Member.ToDescription(),
        tc_col_status = 1
      });
      columnInfo.Add("mbr_SmsSendAgree", new TTableColumn()
      {
        tc_orgin_name = "mbr_SmsSendAgree",
        tc_trans_name = "SMS 허용",
        tc_parents_name = TableCodeType.Member.ToDescription(),
        tc_col_status = 1
      });
      columnInfo.Add("upDownDiv", new TTableColumn()
      {
        tc_orgin_name = "upDownDiv",
        tc_trans_name = "Up/Down",
        tc_parents_name = "변경정보",
        tc_col_status = 2
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.mbr_MemberName = string.Empty;
      this.mbr_Birthday = new DateTime?();
      this.mbr_MobileNo = string.Empty;
      this.mbr_MobileNoEnc = string.Empty;
      this.mbr_SmsSendAgree = 0;
      this.upDownDiv = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBasicCycleChgHisDetail();

    public override object Clone()
    {
      MemberInqBasicCycleChgHisDetail cycleChgHisDetail = base.Clone() as MemberInqBasicCycleChgHisDetail;
      cycleChgHisDetail.mbr_MemberName = this.mbr_MemberName;
      cycleChgHisDetail.mbr_Birthday = this.mbr_Birthday;
      cycleChgHisDetail.mbr_MobileNo = this.mbr_MobileNo;
      cycleChgHisDetail.mbr_MobileNoEnc = this.mbr_MobileNoEnc;
      cycleChgHisDetail.mbr_SmsSendAgree = this.mbr_SmsSendAgree;
      cycleChgHisDetail.upDownDiv = this.upDownDiv;
      return (object) cycleChgHisDetail;
    }

    public void PutData(MemberInqBasicCycleChgHisDetail pSource)
    {
      this.PutData((TMemberCycleChgHistory) pSource);
      this.mbr_MemberName = pSource.mbr_MemberName;
      this.mbr_Birthday = pSource.mbr_Birthday;
      this.mbr_MobileNo = pSource.mbr_MobileNo;
      this.mbr_MobileNoEnc = pSource.mbr_MobileNoEnc;
      this.mbr_SmsSendAgree = pSource.mbr_SmsSendAgree;
      this.upDownDiv = pSource.upDownDiv;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.mbr_MemberName = p_rs.GetFieldString("mbr_MemberName");
      this.mbr_Birthday = p_rs.GetFieldDateTime("mbr_Birthday");
      this.mbr_MobileNo = p_rs.GetFieldString("mbr_MobileNo");
      this.mbr_MobileNoEnc = p_rs.GetFieldString("mbr_MobileNoEnc");
      this.mbr_SmsSendAgree = p_rs.GetFieldInt("mbr_SmsSendAgree");
      this.upDownDiv = p_rs.GetFieldInt("upDownDiv");
      return true;
    }

    public async Task<MemberInqBasicCycleChgHisDetail> SelectOneAsync(
      long p_mcch_MemberNo,
      DateTime p_mcch_ChgDate,
      long p_mcch_SiteID = 0)
    {
      MemberInqBasicCycleChgHisDetail cycleChgHisDetail = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mcch_MemberNo",
          (object) p_mcch_MemberNo
        },
        {
          (object) "mcch_ChgDate",
          (object) p_mcch_ChgDate
        }
      };
      if (p_mcch_SiteID > 0L)
        p_param.Add((object) "mcch_SiteID", (object) p_mcch_SiteID);
      return await cycleChgHisDetail.SelectOneTAsync<MemberInqBasicCycleChgHisDetail>((object) p_param);
    }

    public MemberInqBasicCycleChgHisDetail SelectOne(
      long p_mcch_MemberNo,
      DateTime p_mcch_ChgDate,
      long p_mcch_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mcch_MemberNo",
          (object) p_mcch_MemberNo
        },
        {
          (object) "mcch_ChgDate",
          (object) p_mcch_ChgDate
        }
      };
      if (p_mcch_SiteID > 0L)
        p_param.Add((object) "mcch_SiteID", (object) p_mcch_SiteID);
      return this.SelectOneT<MemberInqBasicCycleChgHisDetail>((object) p_param);
    }

    public async Task<IList<MemberInqBasicCycleChgHisDetail>> SelectListAsync(object p_param)
    {
      MemberInqBasicCycleChgHisDetail cycleChgHisDetail1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(cycleChgHisDetail1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, cycleChgHisDetail1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(cycleChgHisDetail1.GetSelectQuery(p_param)))
        {
          cycleChgHisDetail1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBasicCycleChgHisDetail>) null;
        }
        IList<MemberInqBasicCycleChgHisDetail> lt_list = (IList<MemberInqBasicCycleChgHisDetail>) new List<MemberInqBasicCycleChgHisDetail>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBasicCycleChgHisDetail cycleChgHisDetail2 = cycleChgHisDetail1.OleDB.Create<MemberInqBasicCycleChgHisDetail>();
            if (cycleChgHisDetail2.GetFieldValues(rs))
            {
              cycleChgHisDetail2.row_number = lt_list.Count + 1;
              lt_list.Add(cycleChgHisDetail2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBasicCycleChgHisDetail> SelectEnumerableAsync(
      object p_param)
    {
      MemberInqBasicCycleChgHisDetail cycleChgHisDetail1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(cycleChgHisDetail1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, cycleChgHisDetail1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(cycleChgHisDetail1.GetSelectQuery(p_param)))
        {
          cycleChgHisDetail1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + cycleChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBasicCycleChgHisDetail cycleChgHisDetail2 = cycleChgHisDetail1.OleDB.Create<MemberInqBasicCycleChgHisDetail>();
            if (cycleChgHisDetail2.GetFieldValues(rs))
            {
              cycleChgHisDetail2.row_number = ++row_number;
              yield return cycleChgHisDetail2;
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

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_"))
      {
        int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long num1 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
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
        stringBuilder.Append("\nSELECT  mcch_MemberNo,mcch_ChgDate,mcch_SiteID,mcch_OldMemberCycle,mcch_NewMemberCycle,mcch_StartDate,mcch_EndDate,mcch_BuyCnt,mcch_InDate,mcch_InUser" + string.Format("\n,CASE WHEN CASE {0} WHEN {1} THEN -1 ELSE {2} END > CASE {3} WHEN {4} THEN -1 ELSE {5} END THEN 1", (object) "mcch_NewMemberCycle", (object) num2, (object) "mcch_NewMemberCycle", (object) "mcch_OldMemberCycle", (object) num2, (object) "mcch_OldMemberCycle") + string.Format("\n            WHEN CASE {0} WHEN {1} THEN -1 ELSE {2} END < CASE {3} WHEN {4} THEN -1 ELSE {5} END THEN -1", (object) "mcch_NewMemberCycle", (object) num2, (object) "mcch_NewMemberCycle", (object) "mcch_OldMemberCycle", (object) num2, (object) "mcch_OldMemberCycle") + "\n            ELSE 0 END AS upDownDiv\n,mbr_MemberName,mbr_Birthday,mbr_MobileNo,mbr_MobileNoEnc,mbr_SmsSendAgree\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_MEMBER ON mcch_MemberNo=mbr_MemberNo AND mcch_SiteID=mbr_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mcch_MemberNo");
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
