// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpActionLog.EmpActionLogView
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

namespace UniBiz.Bo.Models.UniBase.Employee.EmpActionLog
{
  public class EmpActionLogView : TEmpActionLog<EmpActionLogView>
  {
    private string _si_StoreName;
    private string _emp_Name;
    private string _pm_ProgTitle;
    private string _pm_ProgTitleParents;
    private string _pmp_ProgTitle;
    private int _pmp_TableID;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string emp_Name
    {
      get => this._emp_Name;
      set
      {
        this._emp_Name = value;
        this.Changed(nameof (emp_Name));
      }
    }

    public string pm_ProgTitle
    {
      get => this._pm_ProgTitle;
      set
      {
        this._pm_ProgTitle = value;
        this.Changed(nameof (pm_ProgTitle));
        this.Changed("eal_Title");
      }
    }

    public string pm_ProgTitleParents
    {
      get => this._pm_ProgTitleParents;
      set
      {
        this._pm_ProgTitleParents = value;
        this.Changed(nameof (pm_ProgTitleParents));
        this.Changed("eal_Title");
      }
    }

    public string pmp_ProgTitle
    {
      get => this._pmp_ProgTitle;
      set
      {
        this._pmp_ProgTitle = value;
        this.Changed(nameof (pmp_ProgTitle));
        this.Changed("eal_Title");
      }
    }

    public override string eal_Title => this.eal_MenuCode <= 0 ? this.pmp_ProgTitle : this.pm_ProgTitleParents + "|" + this.pm_ProgTitle;

    public int pmp_TableID
    {
      get => this._pmp_TableID;
      set
      {
        this._pmp_TableID = value;
        this.Changed(nameof (pmp_TableID));
        this.Changed("pmp_TableIDDesc");
      }
    }

    public string pmp_TableIDDesc => this.pmp_TableID != 0 ? Enum2StrConverter.ToTableType(this.pmp_TableID).ToDescription() : string.Empty;

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
      columnInfo.Add("emp_Name", new TTableColumn()
      {
        tc_orgin_name = "emp_Name",
        tc_trans_name = "사원명",
        tc_col_status = 1
      });
      columnInfo.Add("pm_ProgTitle", new TTableColumn()
      {
        tc_orgin_name = "pm_ProgTitle",
        tc_trans_name = "타이틀",
        tc_col_status = 1
      });
      columnInfo.Add("pmp_ProgTitle", new TTableColumn()
      {
        tc_orgin_name = "pmp_ProgTitle",
        tc_trans_name = "타이틀",
        tc_col_status = 1
      });
      columnInfo.Add("pmp_TableID", new TTableColumn()
      {
        tc_orgin_name = "pmp_TableID",
        tc_trans_name = "테이블 ID",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.emp_Name = string.Empty;
      this.pm_ProgTitle = string.Empty;
      this.pm_ProgTitleParents = string.Empty;
      this.pmp_ProgTitle = string.Empty;
      this.pmp_TableID = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmpActionLogView();

    public override object Clone()
    {
      EmpActionLogView empActionLogView = base.Clone() as EmpActionLogView;
      empActionLogView.si_StoreName = this.si_StoreName;
      empActionLogView.emp_Name = this.emp_Name;
      empActionLogView.pm_ProgTitle = this.pm_ProgTitle;
      empActionLogView.pm_ProgTitleParents = this.pm_ProgTitleParents;
      empActionLogView.pmp_ProgTitle = this.pmp_ProgTitle;
      empActionLogView.pmp_TableID = this.pmp_TableID;
      return (object) empActionLogView;
    }

    public void PutData(EmpActionLogView pSource)
    {
      this.PutData((TEmpActionLog) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.emp_Name = pSource.emp_Name;
      this.pm_ProgTitle = pSource.pm_ProgTitle;
      this.pm_ProgTitleParents = pSource.pm_ProgTitleParents;
      this.pmp_ProgTitle = pSource.pmp_ProgTitle;
      this.pmp_TableID = pSource.pmp_TableID;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.eal_SiteID == 0L)
      {
        this.message = "싸이트(eal_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToAppType(this.eal_ProgKind) != EnumAppType.NONE)
        return EnumDataCheck.Success;
      this.message = "프로그램 종류(eal_ProgKind)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee != null)
        return true;
      this.message = "사용자 정보 NULL.";
      return false;
    }

    public void Init(
      int p_eal_MenuCode,
      int p_eal_SubProgID,
      int p_eal_StoreCode,
      LogInSmallPack p_login_employee)
    {
      this.eal_MenuCode = p_eal_MenuCode;
      this.eal_SubProgID = p_eal_SubProgID;
      if (p_eal_StoreCode > 0)
        this.eal_StoreCode = p_eal_StoreCode;
      if (p_login_employee == null)
        return;
      this.eal_ProgKind = Convert.ToInt32(p_login_employee.appID);
      this.eal_EmpCode = p_login_employee.employee.emp_Code;
      this.eal_SiteID = p_login_employee.employee.emp_SiteID;
      this.eal_LocalIP = p_login_employee.LocalIP;
      this.eal_PublicIP = p_login_employee.PublicIP;
      this.eal_DeviceName = p_login_employee.DeviceName;
      if (this.eal_StoreCode != 0)
        return;
      this.eal_StoreCode = p_login_employee.employee.emp_BaseStore;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      string nowTime = DateHelper.GetNowTime("yyyyMMdd");
      string str = string.Format("{0}{1:D4}0000", (object) nowTime, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(eal_ID), " + str + ")+1 AS eal_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE CONVERT(INT,(eal_ID/100000000))=" + nowTime;
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
          this.eal_ID = uniOleDbRecordset.GetFieldLong(0);
        return this.eal_ID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      EmpActionLogView empActionLogView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(empActionLogView.CreateCodeQuery()))
        {
          empActionLogView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empActionLogView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          empActionLogView.eal_ID = rs.GetFieldLong(0);
        return empActionLogView.eal_ID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.eal_ID != 0L || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.eal_ID, (object) this.eal_SiteID));

    public override async Task<bool> InsertAsync()
    {
      EmpActionLogView empActionLogView = this;
      if (empActionLogView.eal_ID == 0L)
      {
        if (!await empActionLogView.CreateCodeAsync(empActionLogView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await empActionLogView.\u003C\u003En__0() && empActionLogView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) empActionLogView.eal_ID, (object) empActionLogView.eal_SiteID));
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
          if (this.eal_SiteID == 0L)
            this.eal_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.eal_ID == 0L && !this.CreateCode(p_db))
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
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != empActionLogView.DataCheck(p_db))
            throw new UniServiceException(empActionLogView.message, empActionLogView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (empActionLogView.eal_SiteID == 0L)
            empActionLogView.eal_SiteID = p_app_employee.emp_SiteID;
          if (!empActionLogView.IsPermit(p_app_employee))
            throw new UniServiceException(empActionLogView.message, empActionLogView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (empActionLogView.eal_ID == 0L)
        {
          if (!await empActionLogView.CreateCodeAsync(p_db))
            throw new UniServiceException(empActionLogView.message, empActionLogView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!empActionLogView.eal_SysDate.HasValue)
          empActionLogView.eal_SysDate = new DateTime?(DateTime.Now);
        if (!await empActionLogView.InsertAsync())
          throw new UniServiceException(empActionLogView.message, empActionLogView.TableCode.ToDescription() + " 등록 오류");
        empActionLogView.db_status = 4;
        empActionLogView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        empActionLogView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> LogInAsync(UniOleDatabase p_db, string p_eal_Memo, string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 8;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> LogOutAsync(UniOleDatabase p_db, string p_eal_Memo, string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 8;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> SearchAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 4;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> DeleteAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 3;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> InsertAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 1;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> UpdateAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 2;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> ExcelAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 10;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> PrintAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 11;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> PdfAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 12;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> EmailAsync(
      UniOleDatabase p_db,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = 13;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> ActionAsync(
      UniOleDatabase p_db,
      EnumEmpActionKind p_eal_ActionKind,
      int p_eal_ApplyRowCnt,
      string p_eal_Memo,
      string p_eal_Memo2)
    {
      EmpActionLogView empActionLogView = this;
      try
      {
        empActionLogView.eal_ActionKind = (int) p_eal_ActionKind;
        empActionLogView.eal_ApplyRowCnt = p_eal_ApplyRowCnt;
        empActionLogView.eal_Memo = p_eal_Memo;
        empActionLogView.eal_Memo2 = p_eal_Memo2;
        return await empActionLogView.InsertDataAsync(p_db, (EmployeeView) null, false);
      }
      catch (Exception ex)
      {
        empActionLogView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      this.pm_ProgTitle = p_rs.GetFieldString("pm_ProgTitle");
      this.pm_ProgTitleParents = p_rs.GetFieldString("pm_ProgTitleParents");
      this.pmp_ProgTitle = p_rs.GetFieldString("pmp_ProgTitle");
      this.pmp_TableID = p_rs.GetFieldInt("pmp_TableID");
      return true;
    }

    public async Task<EmpActionLogView> SelectOneAsync(long p_eal_ID, long p_eal_SiteID = 0)
    {
      EmpActionLogView empActionLogView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "eal_ID",
          (object) p_eal_ID
        }
      };
      if (p_eal_SiteID > 0L)
        p_param.Add((object) "eal_SiteID", (object) p_eal_SiteID);
      return await empActionLogView.SelectOneTAsync<EmpActionLogView>((object) p_param);
    }

    public async Task<IList<EmpActionLogView>> SelectListAsync(object p_param)
    {
      EmpActionLogView empActionLogView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(empActionLogView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, empActionLogView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(empActionLogView1.GetSelectQuery(p_param)))
        {
          empActionLogView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empActionLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<EmpActionLogView>) null;
        }
        IList<EmpActionLogView> lt_list = (IList<EmpActionLogView>) new List<EmpActionLogView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            EmpActionLogView empActionLogView2 = empActionLogView1.OleDB.Create<EmpActionLogView>();
            if (empActionLogView2.GetFieldValues(rs))
            {
              empActionLogView2.row_number = lt_list.Count + 1;
              lt_list.Add(empActionLogView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empActionLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      Hashtable hashtable = p_param as Hashtable;
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
          if (hashtable.ContainsKey((object) "eal_SiteID") && Convert.ToInt64(hashtable[(object) "eal_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "eal_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code,emp_SiteID,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_UNI_SITE AS ( SELECT uis_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.UniSite, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "uis_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_MENU AS ( SELECT pm_MenuCode,pm_SiteID,pm_ProgTitle,pm_GroupID");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenu, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pm_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_MENU_PROP AS ( SELECT pmp_PropCode,pmp_SiteID,pmp_ProgTitle,pmp_TableID");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenuProp, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pmp_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  eal_ID,eal_SiteID,eal_SysDate,eal_StoreCode,eal_EmpCode,eal_MenuCode,eal_SubProgID,eal_ApplyRowCnt,eal_ActionKind,eal_LocalIP,eal_PublicIP,eal_DeviceName,eal_Memo,eal_Memo2,eal_ProgKind,emp_Name,si_StoreName,pm_ProgTitle,'' AS pm_ProgTitleParents,pmp_ProgTitle,pmp_TableID");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON eal_EmpCode=emp_Code AND eal_SiteID=emp_SiteID LEFT OUTER JOIN T_STORE ON eal_StoreCode=si_StoreCode AND eal_SiteID=si_SiteID LEFT OUTER JOIN T_MENU ON eal_MenuCode=pm_MenuCode AND eal_SiteID=pm_SiteID LEFT OUTER JOIN T_MENU_PROP ON eal_SubProgID=pmp_PropCode AND eal_SiteID=pmp_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY eal_ID");
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
