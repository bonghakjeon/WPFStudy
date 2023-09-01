// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.Location.LocationView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Store.Location
{
  public class LocationView : TLocation<LocationView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private int _si_StoreType;
    private string _si_UseYn;
    private string _si_LocationUseYn;
    private string _inEmpName;
    private string _modEmpName;
    private IList<LocationView> _Lt_Detail;

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

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

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

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (si_LocationUseYn));
        this.Changed("si_IsLocationUseYn");
        this.Changed("si_LocationUseYnDesc");
      }
    }

    public bool si_IsLocationUseYn => "Y".Equals(this.si_LocationUseYn);

    public string si_LocationUseYnDesc => !"Y".Equals(this.si_LocationUseYn) ? "미사용" : "사용";

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

    [JsonPropertyName("lt_Detail")]
    public IList<LocationView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<LocationView>) new List<LocationView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명"
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드"
      });
      columnInfo.Add("si_StoreType", new TTableColumn()
      {
        tc_orgin_name = "si_StoreType",
        tc_trans_name = "지점타입",
        tc_comm_code = 30
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("si_LocationUseYn", new TTableColumn()
      {
        tc_orgin_name = "si_LocationUseYn",
        tc_trans_name = "로케이션 사용유무"
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
      this.si_StoreName = this.si_StoreViewCode = string.Empty;
      this.si_StoreType = 0;
      this.si_UseYn = "N";
      this.si_LocationUseYn = "N";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Detail = (IList<LocationView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new LocationView();

    public override object Clone()
    {
      LocationView locationView = base.Clone() as LocationView;
      locationView.si_StoreName = this.si_StoreName;
      locationView.si_StoreViewCode = this.si_StoreViewCode;
      locationView.si_StoreType = this.si_StoreType;
      locationView.si_UseYn = this.si_UseYn;
      locationView.si_LocationUseYn = this.si_LocationUseYn;
      locationView.inEmpName = this.inEmpName;
      locationView.modEmpName = this.modEmpName;
      locationView.Lt_Detail = this.Lt_Detail;
      return (object) locationView;
    }

    public void PutData(LocationView pSource)
    {
      this.PutData((TLocation) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_StoreType = pSource.si_StoreType;
      this.si_UseYn = pSource.si_UseYn;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Detail = (IList<LocationView>) null;
      foreach (LocationView pSource1 in (IEnumerable<LocationView>) pSource.Lt_Detail)
      {
        new LocationView().PutData(pSource1);
        this.Lt_Detail.Add(pSource1);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.loc_SiteID == 0L)
      {
        this.message = "싸이트(loc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.loc_StoreCode == 0)
      {
        this.message = "지점코드(loc_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.loc_LocationCode))
      {
        this.message = "로케이션코드(loc_LocationCode)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (string.IsNullOrEmpty(this.loc_LocationName))
      {
        this.message = "로케이션명(loc_LocationName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.loc_StorageDiv == 0)
      {
        this.message = "보관방법 [ETC_TYPE:57](1:상온,2:냉장,3:냉동)(loc_StorageDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToLocLocationType(this.loc_LocationType) == EnumLocLocationType.None)
      {
        this.message = "로케이션타입 [ETC_TYPE:61](1:일반,2:입출고,3:불량)(loc_LocationType)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToLocPermitDiv(this.loc_PermitDiv) == EnumLocPermitDiv.None)
      {
        this.message = "재고인정구분 [ETC_TYPE:62](1:인정,2:미인정)(loc_PermitDiv)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToLocLevel(this.loc_Level) == EnumLocLevel.None)
      {
        this.message = "단계 [ETC_TYPE:63](1:창고,2:지역,3:열,4:단<2:2:2:2, 1:층(F),2:곤도라,3:층,4:열>)(loc_Level)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToPackUnit(this.loc_PackUnit) != EnumPackUnit.NONE)
        return EnumDataCheck.Success;
      this.message = "묶음단위 [ETC_TYPE:54](1:EA,2:BUNDLE,3:BOX,4:BOM)(loc_PackUnit)  " + EnumDataCheck.Valid.ToDescription();
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
      if (!p_app_employee.IsAdmin)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(loc_LocationID), 0)+1 AS loc_LocationID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.loc_LocationID = uniOleDbRecordset.GetFieldInt(0);
        return this.loc_LocationID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      LocationView locationView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(locationView.CreateCodeQuery()))
        {
          locationView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + locationView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          locationView.loc_LocationID = rs.GetFieldInt(0);
        return locationView.loc_LocationID > 0;
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
          if (this.loc_SiteID == 0L)
            this.loc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.loc_LocationID == 0 && !this.CreateCode(p_db))
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
      LocationView locationView = this;
      try
      {
        locationView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != locationView.DataCheck(p_db))
            throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (locationView.loc_SiteID == 0L)
            locationView.loc_SiteID = p_app_employee.emp_SiteID;
          if (!locationView.IsPermit(p_app_employee))
            throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (locationView.loc_LocationID == 0)
        {
          if (!await locationView.CreateCodeAsync(p_db))
            throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await locationView.InsertAsync())
          throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 등록 오류");
        locationView.db_status = 4;
        locationView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        locationView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        locationView.message = ex.Message;
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
        if (this.loc_LocationID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 로케이션ID(loc_LocationID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      LocationView locationView = this;
      try
      {
        locationView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != locationView.DataCheck(p_db))
            throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!locationView.IsPermit(p_app_employee))
          throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 권한 검사 실패");
        if (locationView.loc_LocationID == 0)
          throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 로케이션ID(loc_LocationID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await locationView.UpdateAsync())
          throw new UniServiceException(locationView.message, locationView.TableCode.ToDescription() + " 변경 오류");
        locationView.db_status = 4;
        locationView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        locationView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        locationView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<LocationView> SelectOneAsync(int p_loc_LocationID, long p_loc_SiteID = 0)
    {
      LocationView locationView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "loc_LocationID",
          (object) p_loc_LocationID
        }
      };
      if (p_loc_SiteID > 0L)
        p_param.Add((object) "loc_SiteID", (object) p_loc_SiteID);
      return await locationView.SelectOneTAsync<LocationView>((object) p_param);
    }

    public async Task<IList<LocationView>> SelectListAsync(object p_param)
    {
      LocationView locationView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(locationView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, locationView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(locationView1.GetSelectQuery(p_param)))
        {
          locationView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + locationView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<LocationView>) null;
        }
        IList<LocationView> lt_list = (IList<LocationView>) new List<LocationView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            LocationView locationView2 = locationView1.OleDB.Create<LocationView>();
            if (locationView2.GetFieldValues(rs))
            {
              locationView2.row_number = lt_list.Count + 1;
              lt_list.Add(locationView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + locationView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<LocationView> SelectEnumerableAsync(object p_param)
    {
      LocationView locationView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(locationView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, locationView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(locationView1.GetSelectQuery(p_param)))
        {
          locationView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + locationView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            LocationView locationView2 = locationView1.OleDB.Create<LocationView>();
            if (locationView2.GetFieldValues(rs))
            {
              locationView2.row_number = ++row_number;
              yield return locationView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "loc_LocationName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "loc_LocationCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "loc_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
          if (hashtable.ContainsKey((object) "loc_SiteID") && Convert.ToInt64(hashtable[(object) "loc_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "loc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("loc_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("loc_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("loc_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  loc_LocationID,loc_SiteID,loc_StoreCode,loc_LocationCode,loc_LocationName,loc_StorageDiv,loc_SortNo,loc_EmpCode,loc_LocationType,loc_PermitDiv,loc_Level,loc_PackUnit,loc_Memo,loc_UseYn,loc_InDate,loc_InUser,loc_ModDate,loc_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_StoreType,si_UseYn,si_LocationUseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON loc_StoreCode=si_StoreCode AND loc_SiteID=si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON loc_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON loc_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY loc_LocationID");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY loc_LocationID");
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
