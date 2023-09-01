// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory.GiftGiveHistoryView
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory
{
  public class GiftGiveHistoryView : TGiftGiveHistory<GiftGiveHistoryView>
  {
    private string _ggh_RequestStoreName;
    private string _ggh_GiveStoreName;
    private string _inEmpName;
    private string _modEmpName;

    public string ggh_RequestStoreName
    {
      get => this._ggh_RequestStoreName;
      set
      {
        this._ggh_RequestStoreName = value;
        this.Changed(nameof (ggh_RequestStoreName));
      }
    }

    public string ggh_GiveStoreName
    {
      get => this._ggh_GiveStoreName;
      set
      {
        this._ggh_GiveStoreName = value;
        this.Changed(nameof (ggh_GiveStoreName));
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
      columnInfo.Add("ggh_RequestStoreName", new TTableColumn()
      {
        tc_orgin_name = "ggh_RequestStoreName",
        tc_trans_name = "요청 지점명"
      });
      columnInfo.Add("ggh_GiveStoreName", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveStoreName",
        tc_trans_name = "지급 지점명"
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
      this.ggh_RequestStoreName = string.Empty;
      this.ggh_GiveStoreName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GiftGiveHistoryView();

    public override object Clone()
    {
      GiftGiveHistoryView giftGiveHistoryView = base.Clone() as GiftGiveHistoryView;
      giftGiveHistoryView.ggh_RequestStoreName = this.ggh_RequestStoreName;
      giftGiveHistoryView.ggh_GiveStoreName = this.ggh_GiveStoreName;
      giftGiveHistoryView.inEmpName = this.inEmpName;
      giftGiveHistoryView.modEmpName = this.modEmpName;
      return (object) giftGiveHistoryView;
    }

    public void PutData(GiftGiveHistoryView pSource)
    {
      this.PutData((TGiftGiveHistory) pSource);
      this.ggh_RequestStoreName = pSource.ggh_RequestStoreName;
      this.ggh_GiveStoreName = pSource.ggh_GiveStoreName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ggh_SiteID == 0L)
      {
        this.message = "싸이트(ggh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.ggh_RequestDate;
      if (!nullable.HasValue)
      {
        this.message = "요청일(ggh_RequestDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.ggh_GiveDate;
      if (!nullable.HasValue)
        this.ggh_GiveDate = this.ggh_RequestDate;
      if (this.ggh_RequestEmpCode == 0)
      {
        this.message = "요청사원(ggh_RequestEmpCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ggh_MemberNo == 0L)
      {
        this.message = "회원코드(ggh_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ggh_RecipientTelNo))
      {
        this.message = "수령인 연락처(ggh_RecipientTelNo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.ggh_GiftCode == 0)
      {
        this.message = "사은품코드(ggh_GiftCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ggh_Status != 0)
        return EnumDataCheck.Success;
      this.message = "사용상태(ggh_Status)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = this.ggh_RequestDate.Value.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) this.ggh_RequestStore);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ggh_GiveNo), " + str + ")+1 AS ggh_GiveNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ggh_GiveNo", (object) intFormat) + string.Format(" AND (({0}%100000000)/10000)={1}", (object) "ggh_GiveNo", (object) this.ggh_RequestStore);
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.ggh_GiveNo = uniOleDbRecordset.GetFieldLong(0);
        return this.ggh_GiveNo > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      GiftGiveHistoryView giftGiveHistoryView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(giftGiveHistoryView.CreateCodeQuery()))
        {
          giftGiveHistoryView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftGiveHistoryView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          giftGiveHistoryView.ggh_GiveNo = rs.GetFieldLong(0);
        return giftGiveHistoryView.ggh_GiveNo > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
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
          if (this.ggh_SiteID == 0L)
            this.ggh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ggh_GiveNo == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
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
      GiftGiveHistoryView giftGiveHistoryView = this;
      try
      {
        giftGiveHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftGiveHistoryView.DataCheck(p_db))
            throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (giftGiveHistoryView.ggh_SiteID == 0L)
            giftGiveHistoryView.ggh_SiteID = p_app_employee.emp_SiteID;
          if (!giftGiveHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (giftGiveHistoryView.ggh_GiveNo == 0L)
        {
          if (!await giftGiveHistoryView.CreateCodeAsync(p_db))
            throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await giftGiveHistoryView.InsertAsync())
          throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 등록 오류");
        giftGiveHistoryView.db_status = 4;
        giftGiveHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftGiveHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftGiveHistoryView.message = ex.Message;
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
        if (this.ggh_GiveNo == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 지급No(ggh_GiveNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      GiftGiveHistoryView giftGiveHistoryView = this;
      try
      {
        giftGiveHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftGiveHistoryView.DataCheck(p_db))
            throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!giftGiveHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (giftGiveHistoryView.ggh_GiveNo == 0L)
          throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 지급No(ggh_GiveNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await giftGiveHistoryView.UpdateAsync())
          throw new UniServiceException(giftGiveHistoryView.message, giftGiveHistoryView.TableCode.ToDescription() + " 변경 오류");
        giftGiveHistoryView.db_status = 4;
        giftGiveHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftGiveHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftGiveHistoryView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.ggh_RequestStoreName = p_rs.GetFieldString("ggh_RequestStoreName");
      this.ggh_GiveStoreName = p_rs.GetFieldString("ggh_GiveStoreName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GiftGiveHistoryView> SelectOneAsync(long p_ggh_GiveNo, long p_ggh_SiteID = 0)
    {
      GiftGiveHistoryView giftGiveHistoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ggh_GiveNo",
          (object) p_ggh_GiveNo
        }
      };
      if (p_ggh_SiteID > 0L)
        p_param.Add((object) "ggh_SiteID", (object) p_ggh_SiteID);
      return await giftGiveHistoryView.SelectOneTAsync<GiftGiveHistoryView>((object) p_param);
    }

    public GiftGiveHistoryView SelectOne(long p_ggh_GiveNo, long p_ggh_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ggh_GiveNo",
          (object) p_ggh_GiveNo
        }
      };
      if (p_ggh_SiteID > 0L)
        p_param.Add((object) "ggh_SiteID", (object) p_ggh_SiteID);
      return this.SelectOneT<GiftGiveHistoryView>((object) p_param);
    }

    public async Task<IList<GiftGiveHistoryView>> SelectListAsync(object p_param)
    {
      GiftGiveHistoryView giftGiveHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftGiveHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftGiveHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftGiveHistoryView1.GetSelectQuery(p_param)))
        {
          giftGiveHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftGiveHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GiftGiveHistoryView>) null;
        }
        IList<GiftGiveHistoryView> lt_list = (IList<GiftGiveHistoryView>) new List<GiftGiveHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GiftGiveHistoryView giftGiveHistoryView2 = giftGiveHistoryView1.OleDB.Create<GiftGiveHistoryView>();
            if (giftGiveHistoryView2.GetFieldValues(rs))
            {
              giftGiveHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(giftGiveHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftGiveHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GiftGiveHistoryView> SelectEnumerableAsync(object p_param)
    {
      GiftGiveHistoryView giftGiveHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftGiveHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftGiveHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftGiveHistoryView1.GetSelectQuery(p_param)))
        {
          giftGiveHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftGiveHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GiftGiveHistoryView giftGiveHistoryView2 = giftGiveHistoryView1.OleDB.Create<GiftGiveHistoryView>();
            if (giftGiveHistoryView2.GetFieldValues(rs))
            {
              giftGiveHistoryView2.row_number = ++row_number;
              yield return giftGiveHistoryView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ggh_MemberName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_RecipientTelNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_GiftName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_RequestEmpName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_GiveEmpName", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "ggh_SiteID") && Convert.ToInt64(hashtable[(object) "ggh_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "ggh_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE_REQUEST AS (\nSELECT si_StoreCode AS req_si_StoreCode,si_SiteID AS req_si_SiteID,si_StoreName AS req_si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_STORE_GIVE AS (\nSELECT si_StoreCode AS give_si_StoreCode,si_SiteID AS give_si_SiteID,si_StoreName AS give_si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  ggh_GiveNo,ggh_SiteID,ggh_RequestDate,ggh_RequestStore,ggh_RequestEmpCode,ggh_RequestEmpName,ggh_MemberNo,ggh_MemberName,ggh_RecipientTelNo,ggh_GiftCode,ggh_GiftName,ggh_GiftPrice,ggh_DeductionPoint,ggh_Memo,ggh_GiveStore,ggh_GiveEmpCode,ggh_GiveEmpName,ggh_GiveDate,ggh_Status,ggh_InDate,ggh_InUser,ggh_ModDate,ggh_ModUser,req_si_StoreName AS ggh_RequestStoreName,give_si_StoreName AS ggh_GiveStoreName,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_STORE_REQUEST ON ggh_RequestStore=req_si_StoreCode AND ggh_SiteID=req_si_SiteID\nLEFT OUTER JOIN T_STORE_GIVE ON ggh_RequestStore=give_si_StoreCode AND ggh_SiteID=give_si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ggh_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ggh_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY ggh_GiveNo");
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
