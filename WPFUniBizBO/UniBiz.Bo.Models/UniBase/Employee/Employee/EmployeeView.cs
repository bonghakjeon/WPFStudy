// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.Employee.EmployeeView
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
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.Employee
{
  public class EmployeeView : TEmployee<EmployeeView>
  {
    private string _si_StoreName;
    private int _si_MemberMntStore;
    private string _si_MemberMntStoreName;
    private string _inEmpName;
    private string _modEmpName;
    private int _emp_BaseSupplier;
    private string _su_SupplierName;
    private string _ei_UseYnImage;
    private int _ei_ImgType;
    protected byte[] _ei_ThumbData = new byte[0];
    private int _ei_OriginSize;
    protected byte[] _ei_OriginData = new byte[0];
    private string _uis_SiteViewCode;
    private string _uis_SiteName;
    private string _emp_pwd_before;
    private string _emp_pwd_after;
    private int _emp_pos_pwd_changed;
    private int _emp_email_pwd_changed;
    private IList<StoreGroupHeaderView> _Lt_StoreGroup;

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public int si_MemberMntStore
    {
      get => this._si_MemberMntStore;
      set
      {
        this._si_MemberMntStore = value;
        this.Changed(nameof (si_MemberMntStore));
      }
    }

    public string si_MemberMntStoreName
    {
      get => this._si_MemberMntStoreName;
      set
      {
        this._si_MemberMntStoreName = value;
        this.Changed(nameof (si_MemberMntStoreName));
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

    public int emp_BaseSupplier
    {
      get => this._emp_BaseSupplier;
      set
      {
        this._emp_BaseSupplier = value;
        this.Changed(nameof (emp_BaseSupplier));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string ei_UseYnImage
    {
      get => this._ei_UseYnImage;
      set
      {
        this._ei_UseYnImage = value;
        this.Changed(nameof (ei_UseYnImage));
      }
    }

    public int ei_ImgType
    {
      get => this._ei_ImgType;
      set
      {
        this._ei_ImgType = value;
        this.Changed(nameof (ei_ImgType));
      }
    }

    public byte[] ei_ThumbData
    {
      get => this._ei_ThumbData;
      set
      {
        this._ei_ThumbData = value;
        this.Changed(nameof (ei_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.ei_ThumbData != null && this.ei_ThumbData.Length != 0;

    public int ei_OriginSize
    {
      get => this._ei_OriginSize;
      set
      {
        this._ei_OriginSize = value;
        this.Changed(nameof (ei_OriginSize));
      }
    }

    public byte[] ei_OriginData
    {
      get => this._ei_OriginData;
      set
      {
        this._ei_OriginData = value;
        this.Changed(nameof (ei_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.ei_OriginData != null && this.ei_OriginData.Length != 0;

    [JsonPropertyName("base64Data")]
    public string Base64Data
    {
      get
      {
        string fileExtensionName = Enum2StrConverter.ToImageFileExtensionName(this.ei_ImgType);
        if (this.IsOriginData)
          return "data:image/" + fileExtensionName + ";base64," + this.ei_OriginData.ToBase64();
        return this.IsThumbData ? "data:image/" + fileExtensionName + ";base64," + this.ei_ThumbData.ToBase64() : (string) null;
      }
    }

    [JsonPropertyName("base64DataSize")]
    public int Base64DataSize
    {
      get
      {
        if (this.IsOriginData)
          return this.ei_OriginData.Length;
        return !this.IsThumbData ? 0 : this.ei_ThumbData.Length;
      }
    }

    public string uis_SiteViewCode
    {
      get => this._uis_SiteViewCode;
      set
      {
        this._uis_SiteViewCode = value;
        this.Changed(nameof (uis_SiteViewCode));
      }
    }

    public string uis_SiteName
    {
      get => this._uis_SiteName;
      set
      {
        this._uis_SiteName = value;
        this.Changed(nameof (uis_SiteName));
      }
    }

    public string emp_pwd_before
    {
      get => this._emp_pwd_before;
      set
      {
        this._emp_pwd_before = value;
        this.Changed(nameof (emp_pwd_before));
      }
    }

    public string emp_pwd_after
    {
      get => this._emp_pwd_after;
      set
      {
        this._emp_pwd_after = value;
        this.Changed(nameof (emp_pwd_after));
      }
    }

    public int emp_pos_pwd_changed
    {
      get => this._emp_pos_pwd_changed;
      set
      {
        this._emp_pos_pwd_changed = value;
        this.Changed(nameof (emp_pos_pwd_changed));
      }
    }

    public int emp_email_pwd_changed
    {
      get => this._emp_email_pwd_changed;
      set
      {
        this._emp_email_pwd_changed = value;
        this.Changed(nameof (emp_email_pwd_changed));
      }
    }

    [JsonPropertyName("lt_store_group")]
    public IList<StoreGroupHeaderView> Lt_StoreGroup
    {
      get => this._Lt_StoreGroup ?? (this._Lt_StoreGroup = (IList<StoreGroupHeaderView>) new List<StoreGroupHeaderView>());
      set
      {
        this._Lt_StoreGroup = value;
        this.Changed(nameof (Lt_StoreGroup));
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
      columnInfo.Add("si_MemberMntStoreName", new TTableColumn()
      {
        tc_orgin_name = "si_MemberMntStoreName",
        tc_trans_name = "포인트 지점명",
        tc_col_status = 1
      });
      columnInfo.Add("si_MemberMntStore", new TTableColumn()
      {
        tc_orgin_name = "si_MemberMntStore",
        tc_trans_name = "포인트 지점",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명",
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
      this.si_MemberMntStoreName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.si_MemberMntStore = 0;
      this.emp_BaseSupplier = 0;
      this.su_SupplierName = string.Empty;
      this.ei_UseYnImage = "N";
      this.emp_pwd_before = string.Empty;
      this.emp_pwd_after = string.Empty;
      this.emp_pos_pwd_changed = 0;
      this.emp_email_pwd_changed = 0;
      this.Lt_StoreGroup = (IList<StoreGroupHeaderView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmployeeView();

    public override object Clone()
    {
      EmployeeView employeeView = base.Clone() as EmployeeView;
      employeeView.si_StoreName = this.si_StoreName;
      employeeView.si_MemberMntStoreName = this.si_MemberMntStoreName;
      employeeView.inEmpName = this.inEmpName;
      employeeView.modEmpName = this.modEmpName;
      employeeView.si_MemberMntStore = this.si_MemberMntStore;
      employeeView.emp_BaseSupplier = this.emp_BaseSupplier;
      employeeView.su_SupplierName = this.su_SupplierName;
      employeeView.ei_UseYnImage = this.ei_UseYnImage;
      employeeView.Lt_StoreGroup = (IList<StoreGroupHeaderView>) null;
      if (this.Lt_StoreGroup.Count > 0)
      {
        foreach (StoreGroupHeaderView storeGroupHeaderView in (IEnumerable<StoreGroupHeaderView>) this.Lt_StoreGroup)
          employeeView.Lt_StoreGroup.Add(storeGroupHeaderView);
      }
      return (object) employeeView;
    }

    public void PutData(EmployeeView pSource)
    {
      this.PutData((TEmployee) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_MemberMntStoreName = pSource.si_MemberMntStoreName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.si_MemberMntStore = pSource.si_MemberMntStore;
      this.emp_BaseSupplier = pSource.emp_BaseSupplier;
      this.su_SupplierName = pSource.su_SupplierName;
      this.ei_UseYnImage = pSource.ei_UseYnImage;
      this.Lt_StoreGroup = (IList<StoreGroupHeaderView>) null;
      if (pSource.Lt_StoreGroup.Count <= 0)
        return;
      foreach (StoreGroupHeaderView pSource1 in (IEnumerable<StoreGroupHeaderView>) pSource.Lt_StoreGroup)
      {
        StoreGroupHeaderView storeGroupHeaderView = new StoreGroupHeaderView();
        storeGroupHeaderView.PutData(pSource1);
        this.Lt_StoreGroup.Add(storeGroupHeaderView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.emp_SiteID == 0L)
      {
        this.message = "싸이트(emp_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.emp_BaseStore == 0)
      {
        this.message = "시작지점(emp_BaseStore)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.emp_MenuGroupID == 0)
      {
        this.message = "화면권한ID(emp_MenuGroupID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.emp_Name))
      {
        this.message = "사원명(emp_Name)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.emp_ID))
        return EnumDataCheck.Success;
      this.message = "ID (emp_ID)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      IList<EmployeeView> employeeViewList = p_db.Create<EmployeeView>().SelectListE<EmployeeView>((object) new Hashtable()
      {
        {
          (object) "emp_SiteID",
          (object) this.emp_SiteID
        },
        {
          (object) "emp_ID",
          (object) this.emp_ID
        }
      });
      if (this.IsNew)
      {
        if (employeeViewList != null && employeeViewList.Count > 0)
        {
          using (IEnumerator<EmployeeView> enumerator = employeeViewList.GetEnumerator())
          {
            if (enumerator.MoveNext())
            {
              EmployeeView current = enumerator.Current;
              this.message = "ID (emp_ID) " + EnumDataCheck.Exists.ToDescription() + "\n - " + current.emp_Name + "(" + current.emp_ID + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
              return EnumDataCheck.Exists;
            }
          }
        }
      }
      else if (this.IsUpdate && employeeViewList != null && employeeViewList.Count > 0)
      {
        foreach (EmployeeView employeeView in (IEnumerable<EmployeeView>) employeeViewList)
        {
          if (employeeView.emp_Code != this.emp_Code)
          {
            this.message = "ID (emp_ID) " + EnumDataCheck.Exists.ToDescription() + "\n - " + employeeView.emp_Name + "(" + employeeView.emp_ID + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
            return EnumDataCheck.Exists;
          }
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
      if (!p_app_employee.IsEmployeeSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (!p_app_employee.IsSystem && !p_app_employee.IsAgent && (this.IsSystem || this.IsAgent))
      {
        this.message = "개발사 공급사 ID 변경 불가";
        return false;
      }
      if (!string.IsNullOrEmpty(this.emp_PosID))
      {
        IList<EmployeeView> employeeViewList = this.OleDB.Create<EmployeeView>().SelectListE<EmployeeView>((object) new Hashtable()
        {
          {
            (object) "emp_SiteID",
            (object) this.emp_SiteID
          },
          {
            (object) "emp_PosID",
            (object) this.emp_PosID
          }
        });
        if (this.IsNew)
        {
          if (employeeViewList != null && employeeViewList.Count > 0)
          {
            using (IEnumerator<EmployeeView> enumerator = employeeViewList.GetEnumerator())
            {
              if (enumerator.MoveNext())
              {
                EmployeeView current = enumerator.Current;
                this.message = "포스 ID(emp_PosID) " + EnumDataCheck.Exists.ToDescription() + "\n - " + current.emp_Name + "(" + current.emp_PosID + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
                return false;
              }
            }
          }
        }
        else if (this.IsUpdate && employeeViewList != null && employeeViewList.Count > 0)
        {
          foreach (EmployeeView employeeView in (IEnumerable<EmployeeView>) employeeViewList)
          {
            if (employeeView.emp_Code != this.emp_Code)
            {
              this.message = "포스 ID(emp_PosID) " + EnumDataCheck.Exists.ToDescription() + "\n - " + employeeView.emp_Name + "(" + employeeView.emp_PosID + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
              return false;
            }
          }
        }
      }
      return true;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(emp_Code), 0)+1 AS emp_Code" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.emp_Code = uniOleDbRecordset.GetFieldInt(0);
        return this.emp_Code > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      EmployeeView employeeView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(employeeView.CreateCodeQuery()))
        {
          employeeView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + employeeView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          employeeView.emp_Code = rs.GetFieldInt(0);
        return employeeView.emp_Code > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.emp_Code != 0 || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) this.emp_Code));

    public override async Task<bool> InsertAsync()
    {
      EmployeeView employeeView = this;
      if (employeeView.emp_Code == 0)
      {
        if (!await employeeView.CreateCodeAsync(employeeView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await employeeView.\u003C\u003En__0() && employeeView.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) employeeView.emp_Code));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.emp_Code));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      EmployeeView employeeView = this;
      // ISSUE: reference to a compiler-generated method
      return await employeeView.\u003C\u003En__1(p_old) && employeeView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) employeeView.emp_Code));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.emp_Code));

    public override async Task<bool> UpdateExInsertAsync()
    {
      EmployeeView employeeView = this;
      // ISSUE: reference to a compiler-generated method
      return await employeeView.\u003C\u003En__2() && employeeView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) employeeView.emp_Code));
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
          if (this.emp_SiteID == 0L)
            this.emp_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.emp_Code == 0 && !this.CreateCode(p_db))
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
      EmployeeView employeeView = this;
      try
      {
        employeeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != employeeView.DataCheck(p_db))
            throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (employeeView.emp_SiteID == 0L)
            employeeView.emp_SiteID = p_app_employee.emp_SiteID;
          if (!employeeView.IsPermit(p_app_employee))
            throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (employeeView.emp_Code == 0)
        {
          if (!await employeeView.CreateCodeAsync(p_db))
            throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await employeeView.InsertAsync())
          throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 등록 오류");
        employeeView.db_status = 4;
        employeeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        employeeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        employeeView.message = ex.Message;
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
        if (this.emp_Code == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 사원코드(emp_Code)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      EmployeeView employeeView = this;
      try
      {
        employeeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != employeeView.DataCheck(p_db))
            throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!employeeView.IsPermit(p_app_employee))
          throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (employeeView.emp_Code == 0)
          throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 사원코드(emp_Code)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await employeeView.UpdateAsync())
          throw new UniServiceException(employeeView.message, employeeView.TableCode.ToDescription() + " 변경 오류");
        employeeView.db_status = 4;
        employeeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        employeeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        employeeView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.ei_UseYnImage = p_rs.GetFieldString("ei_UseYnImage");
      if (p_rs.IsFieldName("ei_ImgType"))
        this.ei_ImgType = p_rs.GetFieldInt("ei_ImgType");
      if (p_rs.IsFieldName("ei_ThumbData"))
      {
        if (this.ei_ThumbData != null)
          this.ei_ThumbData = (byte[]) null;
        this.ei_ThumbData = p_rs.GetFieldBytes("ei_ThumbData");
      }
      if (p_rs.IsFieldName("ei_OriginData"))
      {
        if (this.ei_OriginData != null)
          this.ei_OriginData = (byte[]) null;
        this.ei_OriginData = p_rs.GetFieldBytes("ei_OriginData");
      }
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_MemberMntStore = p_rs.GetFieldInt("si_MemberMntStore");
      this.si_MemberMntStoreName = p_rs.GetFieldString("si_MemberMntStoreName");
      this.uis_SiteViewCode = p_rs.GetFieldString("uis_SiteViewCode");
      this.uis_SiteName = p_rs.GetFieldString("uis_SiteName");
      return true;
    }

    public async Task<EmployeeView> SelectOneAsync(
      int p_emp_Code,
      long p_emp_SiteID = 0,
      bool p_is_thumb_image = true,
      bool p_is_origin_image = false)
    {
      EmployeeView employeeView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "emp_Code",
          (object) p_emp_Code
        },
        {
          (object) "IS_THUMB_IMAGE_VIEW",
          (object) p_is_thumb_image
        },
        {
          (object) "IS_FILE_IMAGE_VIEW",
          (object) p_is_origin_image
        }
      };
      if (p_emp_SiteID > 0L)
        p_param.Add((object) "emp_SiteID", (object) p_emp_SiteID);
      return await employeeView.SelectOneTAsync<EmployeeView>((object) p_param);
    }

    public async Task<IList<EmployeeView>> SelectListAsync(object p_param)
    {
      EmployeeView employeeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(employeeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, employeeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(employeeView1.GetSelectQuery(p_param)))
        {
          employeeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + employeeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<EmployeeView>) null;
        }
        IList<EmployeeView> lt_list = (IList<EmployeeView>) new List<EmployeeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            EmployeeView employeeView2 = employeeView1.OleDB.Create<EmployeeView>();
            if (employeeView2.GetFieldValues(rs))
            {
              employeeView2.row_number = lt_list.Count + 1;
              lt_list.Add(employeeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + employeeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "uis_SiteViewCode") && hashtable[(object) "uis_SiteViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "uis_SiteViewCode", hashtable[(object) "uis_SiteViewCode"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "emp_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "emp_ID", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "emp_Tel", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "uis_SiteName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(") ");
        }
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
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "emp_SiteID") && Convert.ToInt64(hashtable[(object) "emp_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "emp_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_UNI_SITE AS ( SELECT uis_SiteID,uis_SiteViewCode,uis_SiteName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.UniSite, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "uis_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_MemberMntStore" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_MEMBERMNT_STORE AS ( SELECT si_StoreCode AS si_StoreCodeMnt,si_StoreName AS si_MemberMntStoreName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMP_IMAGE AS ( SELECT ei_EmpCode,'Y' AS ei_UseYnImage,ei_ImgType");
        if (flag1)
          stringBuilder.Append(",ei_ThumbData");
        if (flag2)
          stringBuilder.Append(",ei_OriginData");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.EmpImage, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "ei_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  emp_Code,emp_SiteID,emp_BaseStore,emp_Position,emp_Name,emp_Dept,emp_ID,emp_ProgPwd,emp_PosID,emp_PosPwd,emp_UseYn,emp_Tel,emp_Mobile,emp_EnterDate,emp_RegidentNo,emp_Email,emp_EmailPwd,emp_Zipcode,emp_Addr1,emp_Addr2,emp_Gender,emp_BirthType,emp_Birthday,emp_Anniversary,emp_MenuGroupID,emp_ProgAuth1,emp_ProgAuth2,emp_ProgAuth3,emp_LoginLimitDate,emp_PwdLimitDate,emp_LoginDeny,emp_ResignationStatus,emp_ResignationDate,emp_Job,emp_ExtensionNumber,emp_InDate,emp_InUser,emp_ModDate,emp_ModUser,inEmpName,modEmpName,ei_UseYnImage,ei_ImgType");
        if (flag1)
          stringBuilder.Append(",ei_ThumbData");
        if (flag2)
          stringBuilder.Append(",ei_OriginData");
        stringBuilder.Append(",si_StoreName,si_MemberMntStore,si_MemberMntStoreName,uis_SiteViewCode,uis_SiteName");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_UNI_SITE ON emp_SiteID=uis_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON emp_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON emp_ModUser=emp_CodeMod LEFT OUTER JOIN T_EMP_IMAGE ON emp_Code=ei_EmpCode  LEFT OUTER JOIN T_STORE ON emp_BaseStore=si_StoreCode LEFT OUTER JOIN T_MEMBERMNT_STORE ON si_MemberMntStore=si_StoreCodeMnt");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY emp_Code");
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
