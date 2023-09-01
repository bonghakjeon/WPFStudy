// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberCard.MemberCardView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberCard
{
  public class MemberCardView : TMemberCard<MemberCardView>
  {
    private int _mbr_RegStore;
    private string _inEmpName;
    private string _modEmpName;

    public int mbr_RegStore
    {
      get => this._mbr_RegStore;
      set
      {
        this._mbr_RegStore = value;
        this.Changed(nameof (mbr_RegStore));
      }
    }

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_RegStore", new TTableColumn()
      {
        tc_orgin_name = "mbr_RegStore",
        tc_trans_name = "등록지점코드"
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.mbr_RegStore = 0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberCardView();

    public override object Clone()
    {
      MemberCardView memberCardView = base.Clone() as MemberCardView;
      memberCardView.mbr_RegStore = this.mbr_RegStore;
      memberCardView.inEmpName = this.inEmpName;
      memberCardView.modEmpName = this.modEmpName;
      return (object) memberCardView;
    }

    public void PutData(MemberCardView pSource)
    {
      this.PutData((TMemberCard) pSource);
      this.mbr_RegStore = pSource.mbr_RegStore;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mbrc_SiteID == 0L)
      {
        this.message = "싸이트(mbrc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mbrc_MemberNo == 0L)
      {
        this.message = "회원코드(mbrc_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.mbrc_MemberCardNo))
      {
        this.message = "카드번호(mbrc_MemberCardNo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.mbrc_CardType != 0)
        return EnumDataCheck.Success;
      this.message = "카드유형(mbrc_CardType)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      Hashtable p_param = new Hashtable();
      if (this.mbrc_CardType == 1)
      {
        p_param.Clear();
        p_param.Add((object) "mbrc_SiteID", (object) this.mbrc_SiteID);
        p_param.Add((object) "mbrc_MemberNo", (object) this.mbrc_MemberNo);
        foreach (MemberCardView memberCardView in (IEnumerable<MemberCardView>) p_db.Create<MemberCardView>().SelectListE<MemberCardView>((object) p_param))
        {
          if (!this.mbrc_MemberCardNo.Equals(memberCardView.mbrc_MemberCardNo) && memberCardView.mbrc_CardType == 1)
          {
            this.message = "카드유형(mbrc_MemberCardNo) " + EnumDataCheck.Exists.ToDescription() + "\n - " + memberCardView.mbrc_MemberCardNo + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
            return EnumDataCheck.Exists;
          }
        }
      }
      if (this.mbr_RegStore == 0)
      {
        p_param.Clear();
        p_param.Add((object) "mbr_SiteID", (object) this.mbrc_SiteID);
        p_param.Add((object) "mbr_MemberNo", (object) this.mbrc_MemberNo);
        TMember tmember = p_db.Create<TMember>().SelectOneT<TMember>((object) p_param);
        if (tmember == null || tmember.mbr_MemberNo == 0L)
        {
          this.message = "회원코드(mbr_MemberNo) " + EnumDataCheck.NULL.ToDescription() + "\n - 1.등록 지점 조회 에러.";
          return EnumDataCheck.NULL;
        }
        this.mbr_RegStore = tmember.mbr_RegStore;
      }
      if (this.mbr_RegStore == 0)
      {
        this.message = "회원코드(mbr_MemberNo) " + EnumDataCheck.NULL.ToDescription() + "\n - 2.등록 지점 조회 에러.";
        return EnumDataCheck.NULL;
      }
      p_param.Clear();
      p_param.Add((object) "mbrc_SiteID", (object) this.mbrc_SiteID);
      p_param.Add((object) "mbrc_MemberNo_EXCEPT_", (object) this.mbrc_MemberNo);
      p_param.Add((object) "mbrc_MemberCardNo", (object) this.mbrc_MemberCardNo);
      p_param.Add((object) "mbr_RegStore_EXISTS_", (object) this.mbr_RegStore);
      if (p_db.Create<MemberCardView>().SelectListE<MemberCardView>((object) p_param).Count <= 0)
        return EnumDataCheck.Success;
      this.message = "카드유형(mbrc_MemberCardNo) " + EnumDataCheck.Exists.ToDescription() + "\n - " + this.mbrc_MemberCardNo + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
      return EnumDataCheck.Exists;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.mbrc_SiteID == 0L)
            this.mbrc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberCardView memberCardView = this;
      try
      {
        memberCardView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCardView.DataCheck(p_db))
            throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberCardView.mbrc_SiteID == 0L)
            memberCardView.mbrc_SiteID = p_app_employee.emp_SiteID;
          if (!memberCardView.IsPermit(p_app_employee))
            throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await memberCardView.InsertAsync())
          throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 등록 오류");
        memberCardView.db_status = 4;
        memberCardView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCardView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCardView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberCardView memberCardView = this;
      try
      {
        memberCardView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCardView.DataCheck(p_db))
            throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberCardView.IsPermit(p_app_employee))
          throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await memberCardView.UpdateAsync())
          throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 변경 오류");
        memberCardView.db_status = 4;
        memberCardView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCardView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCardView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<MemberCardView> SelectOneAsync(
      long p_mbrc_MemberNo,
      string p_mbrc_MemberCardNo,
      long p_mbrc_SiteID = 0)
    {
      MemberCardView memberCardView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbrc_MemberNo",
          (object) p_mbrc_MemberNo
        },
        {
          (object) "mbrc_MemberCardNo",
          (object) p_mbrc_MemberCardNo
        }
      };
      if (p_mbrc_SiteID > 0L)
        p_param.Add((object) "mbrc_SiteID", (object) p_mbrc_SiteID);
      return await memberCardView.SelectOneTAsync<MemberCardView>((object) p_param);
    }

    public MemberCardView SelectOne(
      long p_mbrc_MemberNo,
      string p_mbrc_MemberCardNo,
      long p_mbrc_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbrc_MemberNo",
          (object) p_mbrc_MemberNo
        },
        {
          (object) "mbrc_MemberCardNo",
          (object) p_mbrc_MemberCardNo
        }
      };
      if (p_mbrc_SiteID > 0L)
        p_param.Add((object) "mbrc_SiteID", (object) p_mbrc_SiteID);
      return this.SelectOneT<MemberCardView>((object) p_param);
    }

    public async Task<IList<MemberCardView>> SelectListAsync(object p_param)
    {
      MemberCardView memberCardView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCardView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCardView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCardView1.GetSelectQuery(p_param)))
        {
          memberCardView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberCardView>) null;
        }
        IList<MemberCardView> lt_list = (IList<MemberCardView>) new List<MemberCardView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberCardView memberCardView2 = memberCardView1.OleDB.Create<MemberCardView>();
            if (memberCardView2.GetFieldValues(rs))
            {
              memberCardView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberCardView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberCardView> SelectEnumerableAsync(object p_param)
    {
      MemberCardView memberCardView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCardView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCardView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCardView1.GetSelectQuery(p_param)))
        {
          memberCardView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberCardView memberCardView2 = memberCardView1.OleDB.Create<MemberCardView>();
            if (memberCardView2.GetFieldValues(rs))
            {
              memberCardView2.row_number = ++row_number;
              yield return memberCardView2;
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

    public async Task<IList<MemberCardView>> SelectListExistsAsync(object p_param)
    {
      MemberCardView memberCardView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCardView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCardView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCardView1.GetSelectQuery(p_param)))
        {
          memberCardView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberCardView>) null;
        }
        IList<MemberCardView> lt_list = (IList<MemberCardView>) new List<MemberCardView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberCardView memberCardView2 = memberCardView1.OleDB.Create<MemberCardView>();
            if (memberCardView2.GetFieldValues(rs))
            {
              memberCardView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberCardView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbrc_MemberCardNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        int num1 = 0;
        string empty = string.Empty;
        long num2 = 0;
        int num3 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mbrc_SiteID") && Convert.ToInt64(hashtable[(object) "mbrc_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "mbrc_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "mbr_RegStore_EXISTS_") && Convert.ToInt32(hashtable[(object) "mbr_RegStore_EXISTS_"].ToString()) > 0)
            num3 = Convert.ToInt32(hashtable[(object) "mbr_RegStore_EXISTS_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        if (num3 > 0)
        {
          stringBuilder.Append("\n,T_SITE_MEMBER AS (\nSELECT si_MemberMntStore AS mbr_si_MemberMntStore,si_SiteID AS mbr_si_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2) + string.Format(" AND {0}={1}", (object) "si_StoreCode", (object) num3) + ")");
          stringBuilder.Append("\n,T_STORE_EXISTS AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_SITE_MEMBER ON si_SiteID=mbr_si_SiteID AND si_MemberMntStore=mbr_si_MemberMntStore)");
          stringBuilder.Append("\n,T_MEMBER_EXISTS AS (\nSELECT mbr_MemberNo AS exists_mbr_MemberNo,mbr_SiteID AS exists_mbr_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE_EXISTS ON si_SiteID=mbr_SiteID AND si_StoreCode=mbr_RegStore)");
        }
        stringBuilder.Append("\nSELECT  mbrc_MemberNo,mbrc_MemberCardNo,mbrc_SiteID,mbrc_CardType,mbrc_Memo,mbrc_UseYn,mbrc_InDate,mbrc_InUser,mbrc_ModDate,mbrc_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mbrc_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mbrc_ModUser=emp_CodeMod");
        if (num3 > 0)
          stringBuilder.Append("\nINNER JOIN T_MEMBER_EXISTS ON mbrc_MemberNo=exists_mbr_MemberNo AND mbrc_SiteID=exists_mbr_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY mbrc_MemberNo,mbrc_MemberCardNo");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mbrc_MemberNo,mbrc_MemberCardNo");
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
