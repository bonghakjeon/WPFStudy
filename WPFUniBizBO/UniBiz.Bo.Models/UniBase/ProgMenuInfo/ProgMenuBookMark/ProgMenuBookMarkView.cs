// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark.ProgMenuBookMarkView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark
{
  public class ProgMenuBookMarkView : TProgMenuBookMark<ProgMenuBookMarkView>
  {
    private string _emp_Name;
    private int _lv3_pm_MenuCode;
    private string _lv3_pm_ProgID;
    private string _pm_MenuName;
    private string _pm_ProgTitle;
    private string _pm_IconUrl;
    private int _pm_GroupID;
    private IList<ProgMenuBookMarkView> _Lt_Detail;

    public string emp_Name
    {
      get => this._emp_Name;
      set
      {
        this._emp_Name = value;
        this.Changed(nameof (emp_Name));
      }
    }

    public int lv3_pm_MenuCode
    {
      get => this._lv3_pm_MenuCode;
      set
      {
        this._lv3_pm_MenuCode = value;
        this.Changed(nameof (lv3_pm_MenuCode));
      }
    }

    public string lv3_pm_ProgID
    {
      get => this._lv3_pm_ProgID;
      set
      {
        this._lv3_pm_ProgID = value;
        this.Changed(nameof (lv3_pm_ProgID));
      }
    }

    public string pm_MenuName
    {
      get => this._pm_MenuName;
      set
      {
        this._pm_MenuName = value;
        this.Changed(nameof (pm_MenuName));
      }
    }

    public string pm_ProgTitle
    {
      get => this._pm_ProgTitle;
      set
      {
        this._pm_ProgTitle = value;
        this.Changed(nameof (pm_ProgTitle));
      }
    }

    public string pm_IconUrl
    {
      get => this._pm_IconUrl;
      set
      {
        this._pm_IconUrl = value;
        this.Changed(nameof (pm_IconUrl));
      }
    }

    public int pm_GroupID
    {
      get => this._pm_GroupID;
      set
      {
        this._pm_GroupID = value;
        this.Changed(nameof (pm_GroupID));
      }
    }

    [JsonPropertyName("lt_Detail")]
    public IList<ProgMenuBookMarkView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<ProgMenuBookMarkView>) new List<ProgMenuBookMarkView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("emp_Name", new TTableColumn()
      {
        tc_orgin_name = "emp_Name",
        tc_trans_name = "사원명"
      });
      columnInfo.Add("pm_MenuName", new TTableColumn()
      {
        tc_orgin_name = "pm_MenuName",
        tc_trans_name = "메뉴명"
      });
      columnInfo.Add("pm_ProgTitle", new TTableColumn()
      {
        tc_orgin_name = "pm_ProgTitle",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("pm_IconUrl", new TTableColumn()
      {
        tc_orgin_name = "pm_IconUrl",
        tc_trans_name = "이미지 URL"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.emp_Name = string.Empty;
      this.lv3_pm_MenuCode = 0;
      this.lv3_pm_ProgID = string.Empty;
      this.pm_MenuName = this.pm_ProgTitle = this.pm_IconUrl = string.Empty;
      this.pm_GroupID = 0;
      this.Lt_Detail = (IList<ProgMenuBookMarkView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProgMenuBookMarkView();

    public override object Clone()
    {
      ProgMenuBookMarkView menuBookMarkView = base.Clone() as ProgMenuBookMarkView;
      menuBookMarkView.emp_Name = this.emp_Name;
      menuBookMarkView.lv3_pm_MenuCode = this.lv3_pm_MenuCode;
      menuBookMarkView.lv3_pm_ProgID = this.lv3_pm_ProgID;
      menuBookMarkView.pm_MenuName = this.pm_MenuName;
      menuBookMarkView.pm_ProgTitle = this.pm_ProgTitle;
      menuBookMarkView.pm_IconUrl = this.pm_IconUrl;
      menuBookMarkView.pm_GroupID = this.pm_GroupID;
      menuBookMarkView.Lt_Detail = this.Lt_Detail;
      return (object) menuBookMarkView;
    }

    public void PutData(ProgMenuBookMarkView pSource)
    {
      this.PutData((TProgMenuBookMark) pSource);
      this.emp_Name = pSource.emp_Name;
      this.lv3_pm_MenuCode = pSource.lv3_pm_MenuCode;
      this.lv3_pm_ProgID = pSource.lv3_pm_ProgID;
      this.pm_MenuName = pSource.pm_MenuName;
      this.pm_ProgTitle = pSource.pm_ProgTitle;
      this.pm_IconUrl = pSource.pm_IconUrl;
      this.pm_GroupID = pSource.pm_GroupID;
      this.Lt_Detail = (IList<ProgMenuBookMarkView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (ProgMenuBookMarkView menuBookMarkView in (IEnumerable<ProgMenuBookMarkView>) pSource.Lt_Detail)
        this.Lt_Detail.Add(menuBookMarkView);
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pmbm_SiteID == 0L)
      {
        this.message = "싸이트(pmbm_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToAppType(this.pmbm_AppType) == EnumAppType.NONE)
      {
        this.message = "프로그램 종류(pmbm_AppType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuType(this.pmbm_ViewType) == EnumMenuType.None)
      {
        this.message = "뷰타입(pmbm_ViewType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmbm_EmpCode == 0)
      {
        this.message = "사용자 코드(pmbm_EmpCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmbm_MenuCode == 0 && this.pmbm_ViewType != 1)
      {
        this.message = "메뉴 코드(pmbm_MenuCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMenuDepth(this.pmbm_Depth) == EnumMenuDepth.None)
      {
        this.message = "단계(pmbm_Depth)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmbm_Depth > 1 && this.pmbm_Parent == 0L)
      {
        this.message = "부모(pmbm_Parent)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.pmbm_Title))
        return EnumDataCheck.Success;
      this.message = "즐겨찿기(pmbm_Title)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = base.DataCheck(p_db);
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (this.IsDeleteStatus && Enum2StrConverter.ToMenuType(this.pmbm_ViewType) == EnumMenuType.Menu)
      {
        if (p_db.Create<ProgMenuBookMarkView>().SelectListE<ProgMenuBookMarkView>((object) new Hashtable()
        {
          {
            (object) "pmbm_SiteID",
            (object) this.pmbm_SiteID
          },
          {
            (object) "pmbm_Parent",
            (object) this.pmbm_ID
          },
          {
            (object) "pmbm_ViewType",
            (object) 1
          }
        }).Count > 0)
        {
          this.message = "뷰타입(pmbm_ViewType) " + EnumDataCheck.Valid.ToDescription() + "\n - 하위 " + EnumMenuType.Menu.ToDescription() + "타입 삭제 후 삭제 가능." + EnumDataCheck.Valid.ToDescription() + " 오류.";
          return EnumDataCheck.Valid;
        }
      }
      return EnumDataCheck.Success;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsAdmin && p_app_employee.emp_Code != this.pmbm_EmpCode)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pmbm_ID), " + str + ")+1 AS pmbm_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "pmbm_ID", (object) intFormat);
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
          this.pmbm_ID = uniOleDbRecordset.GetFieldLong(0);
        return this.pmbm_ID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      ProgMenuBookMarkView menuBookMarkView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(menuBookMarkView.CreateCodeQuery()))
        {
          menuBookMarkView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          menuBookMarkView.pmbm_ID = rs.GetFieldLong(0);
        return menuBookMarkView.pmbm_ID > 0L;
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
          if (this.pmbm_SiteID == 0L)
            this.pmbm_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pmbm_ID == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
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

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      ProgMenuBookMarkView menuBookMarkView = this;
      try
      {
        menuBookMarkView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != menuBookMarkView.DataCheck(p_db))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (menuBookMarkView.pmbm_SiteID == 0L)
            menuBookMarkView.pmbm_SiteID = p_app_employee.emp_SiteID;
          if (!menuBookMarkView.IsPermit(p_app_employee))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (menuBookMarkView.pmbm_ID == 0L)
        {
          if (!await menuBookMarkView.CreateCodeAsync(p_db))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await menuBookMarkView.InsertAsync())
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        menuBookMarkView.db_status = 4;
        menuBookMarkView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.Message;
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
        if (this.pmbm_ID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " ID(pmbm_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
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

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      ProgMenuBookMarkView menuBookMarkView = this;
      try
      {
        menuBookMarkView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != menuBookMarkView.DataCheck(p_db))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!menuBookMarkView.IsPermit(p_app_employee))
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 권한 검사 실패");
        if (menuBookMarkView.pmbm_ID == 0L)
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " ID(pmbm_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await menuBookMarkView.UpdateAsync())
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        menuBookMarkView.db_status = 4;
        menuBookMarkView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.Message;
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
        if (Enum2StrConverter.ToMenuType(this.pmbm_ViewType) == EnumMenuType.Menu && !this.Execute(this.DeleteQuery(0L, this.pmbm_EmpCode, this.pmbm_ID, this.pmbm_SiteID)))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 하위 삭제 오류");
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
      ProgMenuBookMarkView menuBookMarkView = this;
      try
      {
        menuBookMarkView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await menuBookMarkView.DataCheckAsync(p_db))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!menuBookMarkView.IsPermit(p_app_employee))
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (Enum2StrConverter.ToMenuType(menuBookMarkView.pmbm_ViewType) == EnumMenuType.Menu)
        {
          if (!await menuBookMarkView.ExecuteAsync(menuBookMarkView.DeleteQuery(0L, menuBookMarkView.pmbm_EmpCode, menuBookMarkView.pmbm_ID, menuBookMarkView.pmbm_SiteID)))
            throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 하위 삭제 오류");
        }
        if (!await menuBookMarkView.DeleteAsync())
          throw new UniServiceException(menuBookMarkView.message, menuBookMarkView.TableCode.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        menuBookMarkView.db_status = 4;
        menuBookMarkView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        menuBookMarkView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      this.lv3_pm_MenuCode = p_rs.GetFieldInt("lv3_pm_MenuCode");
      this.lv3_pm_ProgID = p_rs.GetFieldString("lv3_pm_ProgID");
      this.pm_MenuName = p_rs.GetFieldString("pm_MenuName");
      this.pm_ProgTitle = p_rs.GetFieldString("pm_ProgTitle");
      this.pm_IconUrl = p_rs.GetFieldString("pm_IconUrl");
      this.pm_GroupID = p_rs.GetFieldInt("pm_GroupID");
      return true;
    }

    public async Task<ProgMenuBookMarkView> SelectOneAsync(long p_pmbm_ID, long p_pmbm_SiteID = 0)
    {
      ProgMenuBookMarkView menuBookMarkView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmbm_ID",
          (object) p_pmbm_ID
        }
      };
      if (p_pmbm_SiteID > 0L)
        p_param.Add((object) "pmbm_SiteID", (object) p_pmbm_SiteID);
      return await menuBookMarkView.SelectOneTAsync<ProgMenuBookMarkView>((object) p_param);
    }

    public ProgMenuBookMarkView SelectOne(long p_pmbm_ID, long p_pmbm_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmbm_ID",
          (object) p_pmbm_ID
        }
      };
      if (p_pmbm_SiteID > 0L)
        p_param.Add((object) "pmbm_SiteID", (object) p_pmbm_SiteID);
      return this.SelectOneT<ProgMenuBookMarkView>((object) p_param);
    }

    public async Task<IList<ProgMenuBookMarkView>> SelectListAsync(object p_param)
    {
      ProgMenuBookMarkView menuBookMarkView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(menuBookMarkView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, menuBookMarkView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(menuBookMarkView1.GetSelectQuery(p_param)))
        {
          menuBookMarkView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuBookMarkView>) null;
        }
        IList<ProgMenuBookMarkView> lt_list = (IList<ProgMenuBookMarkView>) new List<ProgMenuBookMarkView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuBookMarkView menuBookMarkView2 = menuBookMarkView1.OleDB.Create<ProgMenuBookMarkView>();
            if (menuBookMarkView2.GetFieldValues(rs))
            {
              menuBookMarkView2.row_number = lt_list.Count + 1;
              lt_list.Add(menuBookMarkView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ProgMenuBookMarkView> SelectEnumerableAsync(object p_param)
    {
      ProgMenuBookMarkView menuBookMarkView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(menuBookMarkView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, menuBookMarkView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(menuBookMarkView1.GetSelectQuery(p_param)))
        {
          menuBookMarkView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ProgMenuBookMarkView menuBookMarkView2 = menuBookMarkView1.OleDB.Create<ProgMenuBookMarkView>();
            if (menuBookMarkView2.GetFieldValues(rs))
            {
              menuBookMarkView2.row_number = ++row_number;
              yield return menuBookMarkView2;
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

    public async Task<IList<ProgMenuBookMarkView>> SelectListExistsAsync(object p_param)
    {
      ProgMenuBookMarkView menuBookMarkView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(menuBookMarkView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, menuBookMarkView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(menuBookMarkView1.GetSelectQuery(p_param)))
        {
          menuBookMarkView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProgMenuBookMarkView>) null;
        }
        IList<ProgMenuBookMarkView> lt_list = (IList<ProgMenuBookMarkView>) new List<ProgMenuBookMarkView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProgMenuBookMarkView menuBookMarkView2 = menuBookMarkView1.OleDB.Create<ProgMenuBookMarkView>();
            if (menuBookMarkView2.GetFieldValues(rs))
            {
              menuBookMarkView2.row_number = lt_list.Count + 1;
              lt_list.Add(menuBookMarkView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + menuBookMarkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pmbm_Title", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_MenuName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "pmbm_SiteID") && Convert.ToInt64(hashtable[(object) "pmbm_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "pmbm_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE AS (\nSELECT emp_Code,emp_SiteID,emp_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_PROGMENU_LV3 AS (\nSELECT pm_MenuCode AS lv3_pm_MenuCode,pm_SiteID AS lv3_pm_SiteID,pm_ProgKind AS lv3_pm_ProgKind,pm_MenuSortNo AS lv3_pm_MenuSortNo,pm_GroupID AS lv3_pm_GroupID,pm_ProgID AS lv3_pm_ProgID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenu, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
        {
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pm_SiteID", (object) num2));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MenuDepth", (object) 3));
        }
        else
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pm_MenuDepth", (object) 3));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_PROGMENU AS (\nSELECT pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuName,pm_ProgTitle,pm_IconUrl,pm_GroupID,lv3_pm_MenuCode,lv3_pm_ProgID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.ProgMenu, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_PROGMENU_LV3 ON lv3_pm_SiteID=pm_SiteID AND lv3_pm_ProgKind=pm_ProgKind AND lv3_pm_GroupID=pm_GroupID");
        if (num2 > 0L)
        {
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pm_SiteID", (object) num2));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MenuDepth", (object) 4));
        }
        else
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pm_MenuDepth", (object) 4));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  pmbm_ID,pmbm_SiteID,pmbm_Parent,pmbm_AppType,pmbm_ViewType,pmbm_EmpCode,pmbm_MenuCode,pmbm_Order,pmbm_Depth,pmbm_Title,pmbm_Desc,pmbm_InDate,pmbm_ModDate\n,emp_Name\n,lv3_pm_MenuCode,lv3_pm_ProgID\n,pm_MenuName,pm_ProgTitle,pm_IconUrl,pm_GroupID\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_EMPLOYEE ON pmbm_EmpCode=emp_Code AND pmbm_SiteID=emp_SiteID\nLEFT OUTER JOIN T_PROGMENU ON pmbm_MenuCode=pm_MenuCode AND pmbm_SiteID=pm_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY pmbm_Depth,pmbm_Parent,pmbm_Order");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY pmbm_Depth,pmbm_Parent,pmbm_Order");
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
