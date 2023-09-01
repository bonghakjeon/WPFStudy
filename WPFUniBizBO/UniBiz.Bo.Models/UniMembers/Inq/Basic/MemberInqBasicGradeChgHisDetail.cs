// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.Basic.MemberInqBasicGradeChgHisDetail
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
using UniBiz.Bo.Models.UniMembers.History.MemberGradeChgHistory;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Inq.Basic
{
  public class MemberInqBasicGradeChgHisDetail : 
    TMemberGradeChgHistory<MemberInqBasicGradeChgHisDetail>
  {
    private string _mbr_MemberName;
    private DateTime? _mbr_Birthday;
    private string _mbr_MobileNo;
    private string _mbr_MobileNoEnc;
    private int _mbr_SmsSendAgree;
    private int _upDownDiv;
    private string _newMemberGradeName;
    private string _oldMemberGradeName;

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

    public string newMemberGradeName
    {
      get => this._newMemberGradeName;
      set
      {
        this._newMemberGradeName = value;
        this.Changed(nameof (newMemberGradeName));
      }
    }

    public string oldMemberGradeName
    {
      get => this._oldMemberGradeName;
      set
      {
        this._oldMemberGradeName = value;
        this.Changed(nameof (oldMemberGradeName));
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
      columnInfo.Add("newMemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "newMemberGradeName",
        tc_trans_name = "신회원등급명",
        tc_parents_name = "변경정보",
        tc_col_status = 2
      });
      columnInfo.Add("oldMemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "oldMemberGradeName",
        tc_trans_name = "구회원등급명",
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
      this.newMemberGradeName = string.Empty;
      this.oldMemberGradeName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBasicGradeChgHisDetail();

    public override object Clone()
    {
      MemberInqBasicGradeChgHisDetail gradeChgHisDetail = base.Clone() as MemberInqBasicGradeChgHisDetail;
      gradeChgHisDetail.mbr_MemberName = this.mbr_MemberName;
      gradeChgHisDetail.mbr_Birthday = this.mbr_Birthday;
      gradeChgHisDetail.mbr_MobileNo = this.mbr_MobileNo;
      gradeChgHisDetail.mbr_MobileNoEnc = this.mbr_MobileNoEnc;
      gradeChgHisDetail.mbr_SmsSendAgree = this.mbr_SmsSendAgree;
      gradeChgHisDetail.upDownDiv = this.upDownDiv;
      gradeChgHisDetail.newMemberGradeName = this.newMemberGradeName;
      gradeChgHisDetail.oldMemberGradeName = this.oldMemberGradeName;
      return (object) gradeChgHisDetail;
    }

    public void PutData(MemberInqBasicGradeChgHisDetail pSource)
    {
      this.PutData((TMemberGradeChgHistory) pSource);
      this.mbr_MemberName = pSource.mbr_MemberName;
      this.mbr_Birthday = pSource.mbr_Birthday;
      this.mbr_MobileNo = pSource.mbr_MobileNo;
      this.mbr_MobileNoEnc = pSource.mbr_MobileNoEnc;
      this.mbr_SmsSendAgree = pSource.mbr_SmsSendAgree;
      this.upDownDiv = pSource.upDownDiv;
      this.newMemberGradeName = pSource.newMemberGradeName;
      this.oldMemberGradeName = pSource.oldMemberGradeName;
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
      this.newMemberGradeName = p_rs.GetFieldString("newMemberGradeName");
      this.oldMemberGradeName = p_rs.GetFieldString("oldMemberGradeName");
      return true;
    }

    public async Task<MemberInqBasicGradeChgHisDetail> SelectOneAsync(
      long p_mgch_MemberNo,
      DateTime p_mgch_ChgDate,
      long p_mgch_SiteID = 0)
    {
      MemberInqBasicGradeChgHisDetail gradeChgHisDetail = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mgch_MemberNo",
          (object) p_mgch_MemberNo
        },
        {
          (object) "mgch_ChgDate",
          (object) p_mgch_ChgDate
        }
      };
      if (p_mgch_SiteID > 0L)
        p_param.Add((object) "mgch_SiteID", (object) p_mgch_SiteID);
      return await gradeChgHisDetail.SelectOneTAsync<MemberInqBasicGradeChgHisDetail>((object) p_param);
    }

    public MemberInqBasicGradeChgHisDetail SelectOne(
      long p_mgch_MemberNo,
      DateTime p_mgch_ChgDate,
      long p_mgch_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mgch_MemberNo",
          (object) p_mgch_MemberNo
        },
        {
          (object) "mgch_ChgDate",
          (object) p_mgch_ChgDate
        }
      };
      if (p_mgch_SiteID > 0L)
        p_param.Add((object) "mgch_SiteID", (object) p_mgch_SiteID);
      return this.SelectOneT<MemberInqBasicGradeChgHisDetail>((object) p_param);
    }

    public async Task<IList<MemberInqBasicGradeChgHisDetail>> SelectListAsync(object p_param)
    {
      MemberInqBasicGradeChgHisDetail gradeChgHisDetail1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeChgHisDetail1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeChgHisDetail1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeChgHisDetail1.GetSelectQuery(p_param)))
        {
          gradeChgHisDetail1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBasicGradeChgHisDetail>) null;
        }
        IList<MemberInqBasicGradeChgHisDetail> lt_list = (IList<MemberInqBasicGradeChgHisDetail>) new List<MemberInqBasicGradeChgHisDetail>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBasicGradeChgHisDetail gradeChgHisDetail2 = gradeChgHisDetail1.OleDB.Create<MemberInqBasicGradeChgHisDetail>();
            if (gradeChgHisDetail2.GetFieldValues(rs))
            {
              gradeChgHisDetail2.row_number = lt_list.Count + 1;
              lt_list.Add(gradeChgHisDetail2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBasicGradeChgHisDetail> SelectEnumerableAsync(
      object p_param)
    {
      MemberInqBasicGradeChgHisDetail gradeChgHisDetail1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeChgHisDetail1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeChgHisDetail1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeChgHisDetail1.GetSelectQuery(p_param)))
        {
          gradeChgHisDetail1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeChgHisDetail1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBasicGradeChgHisDetail gradeChgHisDetail2 = gradeChgHisDetail1.OleDB.Create<MemberInqBasicGradeChgHisDetail>();
            if (gradeChgHisDetail2.GetFieldValues(rs))
            {
              gradeChgHisDetail2.row_number = ++row_number;
              yield return gradeChgHisDetail2;
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
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mgch_SiteID") && Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "mgch_SiteID"].ToString());
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
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName,mbr_Birthday,mbr_MobileNo,mbr_MobileNoEnc,mbr_SmsSendAgree,mbr_RegStore" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_SiteID=mbr_SiteID AND si_StoreCode=mbr_RegStore)");
        stringBuilder.Append("\n,T_MEMBER_GRADE_NEW AS (\nSELECT mgd_MemberGrade AS new_mgd_MemberGrade,mgd_SiteID AS new_mgd_SiteID,mgd_MemberGradeName AS new_mgd_MemberGradeName,mgd_SortNo AS new_mgd_SortNo" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_MEMBER_GRADE_OLD AS (\nSELECT mgd_MemberGrade AS old_mgd_MemberGrade,mgd_SiteID AS old_mgd_SiteID,mgd_MemberGradeName AS old_mgd_MemberGradeName,mgd_SortNo AS old_mgd_SortNo" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num) + ")");
        stringBuilder.Append("\nSELECT  mgch_MemberNo,mgch_ChgDate,mgch_SiteID,mgch_OldMemberGrade,mgch_NewMemberGrade,mgch_StartDate,mgch_EndDate,mgch_BuyCnt,mgch_BuyAmt,mgch_InDate,mgch_InUser\n,new_mgd_MemberGradeName AS newMemberGradeName,old_mgd_MemberGradeName AS oldMemberGradeName\n,CASE WHEN new_mgd_SortNo < old_mgd_SortNo THEN 1\n      WHEN new_mgd_SortNo > old_mgd_SortNo THEN -1\n      ELSE 0 END AS upDownDiv\n,mbr_MemberName,mbr_Birthday,mbr_MobileNo,mbr_MobileNoEnc,mbr_SmsSendAgree\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_MEMBER ON mgch_MemberNo=mbr_MemberNo AND mgch_SiteID=mbr_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE_NEW ON mgch_NewMemberGrade=new_mgd_MemberGrade AND mgch_SiteID=new_mgd_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE_OLD ON mgch_OldMemberGrade=old_mgd_MemberGrade AND mgch_SiteID=old_mgd_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mgch_MemberNo");
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
