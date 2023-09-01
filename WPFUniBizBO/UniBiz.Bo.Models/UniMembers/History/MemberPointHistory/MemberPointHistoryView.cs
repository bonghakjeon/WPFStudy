// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberPointHistory.MemberPointHistoryView
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

namespace UniBiz.Bo.Models.UniMembers.History.MemberPointHistory
{
  public class MemberPointHistoryView : TMemberPointHistory<MemberPointHistoryView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private string _inEmpName;
    private string _modEmpName;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

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
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드",
        tc_col_status = 1
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
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
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberPointHistoryView();

    public override object Clone()
    {
      MemberPointHistoryView pointHistoryView = base.Clone() as MemberPointHistoryView;
      pointHistoryView.si_StoreName = this.si_StoreName;
      pointHistoryView.si_StoreViewCode = this.si_StoreViewCode;
      pointHistoryView.si_UseYn = this.si_UseYn;
      pointHistoryView.inEmpName = this.inEmpName;
      pointHistoryView.modEmpName = this.modEmpName;
      return (object) pointHistoryView;
    }

    public void PutData(MemberPointHistoryView pSource)
    {
      this.PutData((TMemberPointHistory) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mph_SiteID == 0L)
      {
        this.message = "싸이트(mph_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.mph_SysDate;
      if (!nullable.HasValue)
      {
        this.message = "발생일자(시스템)(mph_SysDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.mph_MemberNo == 0L)
      {
        this.message = "회원번호(mph_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mph_StoreCode == 0)
      {
        this.message = "지점(mph_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mph_PointType == 0)
      {
        this.message = "적립구분(mph_PointType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      nullable = this.mph_SaleDate;
      if (nullable.HasValue)
        return EnumDataCheck.Success;
      this.message = "영업일자(mph_SaleDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      EnumDataCheck enumDataCheck = this.DataCheck();
      return enumDataCheck != EnumDataCheck.Success ? enumDataCheck : EnumDataCheck.Success;
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

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = this.mph_SaleDate.Value.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) this.mph_StoreCode);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(mph_Seq), " + str + ")+1 AS mph_Seq" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "mph_Seq", (object) intFormat) + string.Format(" AND (({0}%100000000)/10000)={1}", (object) "mph_Seq", (object) this.mph_StoreCode);
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
          this.mph_Seq = uniOleDbRecordset.GetFieldLong(0);
        return this.mph_Seq > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      MemberPointHistoryView pointHistoryView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(pointHistoryView.CreateCodeQuery()))
        {
          pointHistoryView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointHistoryView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          pointHistoryView.mph_Seq = rs.GetFieldLong(0);
        return pointHistoryView.mph_Seq > 0L;
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
          if (this.mph_SiteID == 0L)
            this.mph_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.mph_Seq == 0L && !this.CreateCode(p_db))
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
      MemberPointHistoryView pointHistoryView = this;
      try
      {
        pointHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != pointHistoryView.DataCheck(p_db))
            throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (pointHistoryView.mph_SiteID == 0L)
            pointHistoryView.mph_SiteID = p_app_employee.emp_SiteID;
          if (!pointHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (pointHistoryView.mph_Seq == 0L)
        {
          if (!await pointHistoryView.CreateCodeAsync(p_db))
            throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await pointHistoryView.InsertAsync())
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 등록 오류");
        pointHistoryView.db_status = 4;
        pointHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        pointHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        pointHistoryView.message = ex.Message;
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
        if (this.mph_Seq == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순번(mph_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      MemberPointHistoryView pointHistoryView = this;
      try
      {
        pointHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != pointHistoryView.DataCheck(p_db))
            throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!pointHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (pointHistoryView.mph_Seq == 0L)
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 순번(mph_Seq)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await pointHistoryView.UpdateAsync())
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 변경 오류");
        pointHistoryView.db_status = 4;
        pointHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        pointHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        pointHistoryView.message = ex.Message;
      }
      return false;
    }

    public override bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberPointHistoryView pointHistoryView = this;
      try
      {
        pointHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != pointHistoryView.DataCheck(p_db))
            throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!pointHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await pointHistoryView.DeleteAsync())
          throw new UniServiceException(pointHistoryView.message, pointHistoryView.TableCode.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        pointHistoryView.db_status = 4;
        pointHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        pointHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        pointHistoryView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<MemberPointHistoryView> SelectOneAsync(long p_mph_Seq, long p_mph_SiteID = 0)
    {
      MemberPointHistoryView pointHistoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mph_Seq",
          (object) p_mph_Seq
        }
      };
      if (p_mph_SiteID > 0L)
        p_param.Add((object) "mph_SiteID", (object) p_mph_SiteID);
      return await pointHistoryView.SelectOneTAsync<MemberPointHistoryView>((object) p_param);
    }

    public MemberPointHistoryView SelectOne(long p_mph_Seq, long p_mph_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mph_Seq",
          (object) p_mph_Seq
        }
      };
      if (p_mph_SiteID > 0L)
        p_param.Add((object) "mph_SiteID", (object) p_mph_SiteID);
      return this.SelectOneT<MemberPointHistoryView>((object) p_param);
    }

    public async Task<IList<MemberPointHistoryView>> SelectListAsync(object p_param)
    {
      MemberPointHistoryView pointHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(pointHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, pointHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(pointHistoryView1.GetSelectQuery(p_param)))
        {
          pointHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberPointHistoryView>) null;
        }
        IList<MemberPointHistoryView> lt_list = (IList<MemberPointHistoryView>) new List<MemberPointHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberPointHistoryView pointHistoryView2 = pointHistoryView1.OleDB.Create<MemberPointHistoryView>();
            if (pointHistoryView2.GetFieldValues(rs))
            {
              pointHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(pointHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberPointHistoryView> SelectEnumerableAsync(object p_param)
    {
      MemberPointHistoryView pointHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(pointHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, pointHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(pointHistoryView1.GetSelectQuery(p_param)))
        {
          pointHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberPointHistoryView pointHistoryView2 = pointHistoryView1.OleDB.Create<MemberPointHistoryView>();
            if (pointHistoryView2.GetFieldValues(rs))
            {
              pointHistoryView2.row_number = ++row_number;
              yield return pointHistoryView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mph_MemberCardNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mph_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num1 = 0;
        long num2 = 0;
        bool flag = false;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "mph_SiteID") && Convert.ToInt64(hashtable2[(object) "mph_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable2[(object) "mph_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "MemberType_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mph_Seq,mph_SiteID,mph_SysDate,mph_MemberNo,mph_StoreCode,mph_PointType,mph_SaleDate,mph_PosNo,mph_TransNo,mph_MemberCardNo,mph_SaleType,mph_SaleAmt,mph_TodayAddPoint,mph_TodayUsePoint,mph_TotalPoint,mph_UsePoint,mph_UsablePoint,mph_Memo,mph_ExtinctionDate,mph_TransmitYn,mph_TransmitDate,mph_InputDate,mph_InDate,mph_InUser,mph_ModDate,mph_ModUser\n,si_StoreName,si_StoreViewCode,si_UseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON mph_StoreCode=si_StoreCode AND mph_SiteID=si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mph_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mph_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY mph_StoreCode,mph_SaleDate");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mph_StoreCode,mph_SaleDate");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
