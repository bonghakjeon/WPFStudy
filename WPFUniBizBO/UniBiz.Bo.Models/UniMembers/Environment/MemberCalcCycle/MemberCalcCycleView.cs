// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle.MemberCalcCycleView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle
{
  public class MemberCalcCycleView : TMemberCalcCycle<MemberCalcCycleView>
  {
    private string _inEmpName;
    private string _modEmpName;

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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberCalcCycleView();

    public override object Clone()
    {
      MemberCalcCycleView memberCalcCycleView = base.Clone() as MemberCalcCycleView;
      memberCalcCycleView.inEmpName = this.inEmpName;
      memberCalcCycleView.modEmpName = this.modEmpName;
      return (object) memberCalcCycleView;
    }

    public void PutData(MemberCalcCycleView pSource)
    {
      this.PutData((TMemberCalcCycle) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mcc_SiteID == 0L)
      {
        this.message = "싸이트(mcc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mcc_CalcCycleDiv == 0)
      {
        this.message = "산정주기구분(mcc_CalcCycleDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.mcc_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(mcc_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mcc_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(mcc_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mcc_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.mcc_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 <= intFormat2)
        return EnumDataCheck.Success;
      this.message = "시작일(mcc_StartDate) > 종료일(mcc_EndDate)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsMemberStdSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
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
          if (this.mcc_SiteID == 0L)
            this.mcc_SiteID = p_app_employee.emp_SiteID;
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
      MemberCalcCycleView memberCalcCycleView = this;
      try
      {
        memberCalcCycleView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCalcCycleView.DataCheck(p_db))
            throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberCalcCycleView.mcc_SiteID == 0L)
            memberCalcCycleView.mcc_SiteID = p_app_employee.emp_SiteID;
          if (!memberCalcCycleView.IsPermit(p_app_employee))
            throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await memberCalcCycleView.InsertAsync())
          throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 등록 오류");
        memberCalcCycleView.db_status = 4;
        memberCalcCycleView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCalcCycleView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCalcCycleView.message = ex.Message;
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
      MemberCalcCycleView memberCalcCycleView = this;
      try
      {
        memberCalcCycleView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCalcCycleView.DataCheck(p_db))
            throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberCalcCycleView.IsPermit(p_app_employee))
          throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await memberCalcCycleView.UpdateAsync())
          throw new UniServiceException(memberCalcCycleView.message, memberCalcCycleView.TableCode.ToDescription() + " 변경 오류");
        memberCalcCycleView.db_status = 4;
        memberCalcCycleView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCalcCycleView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCalcCycleView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      MemberCalcCycleView pSource = this;
      try
      {
        pSource.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != pSource.DataCheck(p_db))
            throw new UniServiceException(pSource.message, pSource.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (pSource.mcc_SiteID == 0L)
            pSource.mcc_SiteID = p_app_employee.emp_SiteID;
          if (!pSource.IsPermit(p_app_employee))
            throw new UniServiceException(pSource.message, pSource.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView dataModLogView = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(pSource.mcc_SiteID))
        {
          dataModLogView.dml_CodeInt = pSource.mcc_CalcCycleDiv;
          dataModLogView.dml_CodeLong = pSource.mcc_StartDate.Value.ToLong();
          dataModLogView.dml_CodeStr = string.Format("{0}|{1}|{2}", (object) pSource.mcc_CalcCycleDiv, (object) pSource.mcc_StartDate.Value.ToIntFormat(), (object) pSource.mcc_SiteID);
          dataModLogView.CreateCode(p_db);
        }
        Hashtable p_param = new Hashtable();
        p_param.Clear();
        p_param.Add((object) "mcc_SiteID", (object) pSource.mcc_SiteID);
        p_param.Add((object) "mcc_CalcCycleDiv", (object) pSource.mcc_CalcCycleDiv);
        p_param.Add((object) "_DT_START_DATE_", (object) pSource.mcc_StartDate);
        p_param.Add((object) "_DT_END_DATE_", (object) pSource.mcc_EndDate);
        IList<MemberCalcCycleView> memberCalcCycleViewList = await p_db.Create<MemberCalcCycleView>().SelectListAsync((object) p_param);
        List<MemberCalcCycleView> lt_origin_insert = new List<MemberCalcCycleView>();
        MemberCalcCycleView origin_start = (MemberCalcCycleView) null;
        MemberCalcCycleView origin_end = (MemberCalcCycleView) null;
        MemberCalcCycleView item = new MemberCalcCycleView();
        item.PutData(pSource);
        foreach (MemberCalcCycleView memberCalcCycleView1 in (IEnumerable<MemberCalcCycleView>) memberCalcCycleViewList)
        {
          MemberCalcCycleView history = memberCalcCycleView1;
          if (history.mcc_CalcCycleDiv == pSource.mcc_CalcCycleDiv)
          {
            history.SetAdoDatabase(p_db);
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<MemberCalcCycleView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
            {
              if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
              {
                if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                  lt_origin_insert[0].mcc_EndDate = history.mcc_EndDate;
                else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                  lt_origin_insert[0].mcc_EndDate = new DateTime?(history.mcc_StartDate.Value.GetDateAdd(0, 0, -1));
              }
              if (history.IntStartDate == item.IntStartDate)
              {
                if (!await history.DeleteAsync())
                  throw new Exception(history.message);
              }
              else if (!await history.UpdateAsync((UbModelBase) null))
                throw new Exception(history.message);
              if (item.IntEndDate > history.IntEndDate)
              {
                if (lt_origin_insert.Count == 1)
                {
                  if (origin_end == null)
                    origin_end = p_db.Create<MemberCalcCycleView>();
                  else
                    origin_end.Clear();
                  origin_end.PutData(item);
                  lt_origin_insert.Add(origin_end);
                }
                lt_origin_insert[1].mcc_StartDate = new DateTime?(history.mcc_EndDate.Value.GetDateAdd(0, 0, 1));
              }
            }
            else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
            {
              MemberCalcCycleView next_data = p_db.Create<MemberCalcCycleView>();
              next_data.PutData(history);
              history.mcc_EndDate = new DateTime?(item.mcc_StartDate.Value.GetDateAdd(0, 0, -1));
              if (!await history.UpdateEndDateAsync())
                throw new Exception(history.message);
              next_data.mcc_StartDate = new DateTime?(item.mcc_EndDate.Value.GetDateAdd(0, 0, 1));
              next_data.mcc_SiteID = pSource.mcc_SiteID;
              next_data = await next_data.InsertAsync() ? (MemberCalcCycleView) null : throw new Exception(next_data.message);
            }
            else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
            {
              history.mcc_EndDate = new DateTime?(item.mcc_StartDate.Value.GetDateAdd(0, 0, -1));
              if (!await history.UpdateEndDateAsync())
                throw new Exception(history.message);
            }
            else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
            {
              MemberCalcCycleView memberCalcCycleView2 = history;
              long mccSiteId = history.mcc_SiteID;
              int mccCalcCycleDiv = history.mcc_CalcCycleDiv;
              DateTime? nullable = history.mcc_StartDate;
              DateTime p_mcc_StartDate = nullable.Value;
              nullable = item.mcc_EndDate;
              DateTime dateAdd = nullable.Value.GetDateAdd(0, 0, 1);
              if (!await memberCalcCycleView2.UpdateStartDateAsync(mccSiteId, mccCalcCycleDiv, p_mcc_StartDate, dateAdd))
                throw new Exception(history.message);
            }
            if (lt_origin_insert.Count == 2 && history.IntStartDate == lt_origin_insert[1].IntStartDate)
            {
              int num1 = await history.DeleteAsync() ? 1 : 0;
            }
            foreach (MemberCalcCycleView memberCalcCycleView3 in lt_origin_insert)
            {
              if (memberCalcCycleView3.IntStartDate <= memberCalcCycleView3.IntEndDate)
              {
                if (!await memberCalcCycleView3.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num2 = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            history = (MemberCalcCycleView) null;
          }
        }
        pSource.db_status = 4;
        pSource.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        pSource.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        pSource.message = ex.Message;
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

    public async Task<MemberCalcCycleView> SelectOneAsync(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate)
    {
      MemberCalcCycleView memberCalcCycleView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mcc_SiteID",
          (object) memberCalcCycleView.mcc_SiteID
        },
        {
          (object) "mcc_CalcCycleDiv",
          (object) p_mcc_CalcCycleDiv
        },
        {
          (object) "mcc_StartDate",
          (object) p_mcc_StartDate
        }
      };
      return await memberCalcCycleView.SelectOneTAsync<MemberCalcCycleView>((object) p_param);
    }

    public MemberCalcCycleView SelectOne(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate)
    {
      return this.SelectOneT<MemberCalcCycleView>((object) new Hashtable()
      {
        {
          (object) "mcc_SiteID",
          (object) this.mcc_SiteID
        },
        {
          (object) "mcc_CalcCycleDiv",
          (object) p_mcc_CalcCycleDiv
        },
        {
          (object) "mcc_StartDate",
          (object) p_mcc_StartDate
        }
      });
    }

    public async Task<IList<MemberCalcCycleView>> SelectListAsync(object p_param)
    {
      MemberCalcCycleView memberCalcCycleView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCalcCycleView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCalcCycleView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCalcCycleView1.GetSelectQuery(p_param)))
        {
          memberCalcCycleView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCalcCycleView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberCalcCycleView>) null;
        }
        IList<MemberCalcCycleView> lt_list = (IList<MemberCalcCycleView>) new List<MemberCalcCycleView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberCalcCycleView memberCalcCycleView2 = memberCalcCycleView1.OleDB.Create<MemberCalcCycleView>();
            if (memberCalcCycleView2.GetFieldValues(rs))
            {
              memberCalcCycleView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberCalcCycleView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCalcCycleView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberCalcCycleView> SelectEnumerableAsync(object p_param)
    {
      MemberCalcCycleView memberCalcCycleView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCalcCycleView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCalcCycleView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCalcCycleView1.GetSelectQuery(p_param)))
        {
          memberCalcCycleView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCalcCycleView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberCalcCycleView memberCalcCycleView2 = memberCalcCycleView1.OleDB.Create<MemberCalcCycleView>();
            if (memberCalcCycleView2.GetFieldValues(rs))
            {
              memberCalcCycleView2.row_number = ++row_number;
              yield return memberCalcCycleView2;
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
        string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mcc_SiteID") && Convert.ToInt64(hashtable[(object) "mcc_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "mcc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  mcc_SiteID,mcc_CalcCycleDiv,mcc_StartDate,mcc_EndDate,mcc_CalcCycle,mcc_CalcPeriod,mcc_InDate,mcc_InUser,mcc_ModDate,mcc_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mcc_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mcc_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mcc_SiteID,mcc_CalcCycleDiv,mcc_StartDate");
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
