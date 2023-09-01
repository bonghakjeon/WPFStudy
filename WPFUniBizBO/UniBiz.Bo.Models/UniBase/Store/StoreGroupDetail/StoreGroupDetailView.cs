// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail.StoreGroupDetailView
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

namespace UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail
{
  public class StoreGroupDetailView : TStoreGroupDetail<StoreGroupDetailView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private int _si_StoreType;
    private string _si_UseYn;
    private string _inEmpName;
    private string _modEmpName;
    private int _sgh_GroupType;
    private string _sgh_GroupName;
    private string _sgh_Memo;
    private int _sgh_SortNo;
    private string _sgh_UseYn;

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

    public int sgh_GroupType
    {
      get => this._sgh_GroupType;
      set
      {
        this._sgh_GroupType = value;
        this.Changed(nameof (sgh_GroupType));
        this.Changed("sgh_GroupTypeDesc");
      }
    }

    public string sgh_GroupTypeDesc => this.sgh_GroupType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.sgd_SiteID, EnumCommonCodeType.StoreGroupType, this.sgh_GroupType);

    public string sgh_GroupName
    {
      get => this._sgh_GroupName;
      set
      {
        this._sgh_GroupName = value;
        this.Changed(nameof (sgh_GroupName));
      }
    }

    public string sgh_Memo
    {
      get => this._sgh_Memo;
      set
      {
        this._sgh_Memo = value;
        this.Changed(nameof (sgh_Memo));
      }
    }

    public int sgh_SortNo
    {
      get => this._sgh_SortNo;
      set
      {
        this._sgh_SortNo = value;
        this.Changed(nameof (sgh_SortNo));
      }
    }

    public string sgh_UseYn
    {
      get => this._sgh_UseYn;
      set
      {
        this._sgh_UseYn = value;
        this.Changed(nameof (sgh_UseYn));
        this.Changed("sgh_IsUseYn");
        this.Changed("sgh_UseYnDesc");
      }
    }

    public bool sgh_IsUseYn => "Y".Equals(this.sgh_UseYn);

    public string sgh_UseYnDesc => !"Y".Equals(this.sgh_UseYn) ? "미사용" : "사용";

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
      columnInfo.Add("sgh_GroupType", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupType",
        tc_trans_name = "타입",
        tc_comm_code = 31
      });
      columnInfo.Add("sgh_GroupName", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupName",
        tc_trans_name = "지점그룹명"
      });
      columnInfo.Add("sgh_Memo", new TTableColumn()
      {
        tc_orgin_name = "sgh_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("sgh_SortNo", new TTableColumn()
      {
        tc_orgin_name = "sgh_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("sgh_UseYn", new TTableColumn()
      {
        tc_orgin_name = "sgh_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원"
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_StoreType = 0;
      this.si_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.sgh_GroupType = 0;
      this.sgh_GroupName = string.Empty;
      this.sgh_Memo = string.Empty;
      this.sgh_SortNo = 0;
      this.sgh_UseYn = "Y";
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StoreGroupDetailView();

    public override object Clone()
    {
      StoreGroupDetailView storeGroupDetailView = base.Clone() as StoreGroupDetailView;
      storeGroupDetailView.si_StoreName = this.si_StoreName;
      storeGroupDetailView.si_StoreViewCode = this.si_StoreViewCode;
      storeGroupDetailView.si_StoreType = this.si_StoreType;
      storeGroupDetailView.si_UseYn = this.si_UseYn;
      storeGroupDetailView.inEmpName = this.inEmpName;
      storeGroupDetailView.modEmpName = this.modEmpName;
      storeGroupDetailView.sgh_GroupType = this.sgh_GroupType;
      storeGroupDetailView.sgh_GroupName = this.sgh_GroupName;
      storeGroupDetailView.sgh_Memo = this.sgh_Memo;
      storeGroupDetailView.sgh_SortNo = this.sgh_SortNo;
      storeGroupDetailView.sgh_UseYn = this.sgh_UseYn;
      return (object) storeGroupDetailView;
    }

    public void PutData(StoreGroupDetailView pSource)
    {
      this.PutData((TStoreGroupDetail) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_StoreType = pSource.si_StoreType;
      this.si_UseYn = pSource.si_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.sgh_GroupType = pSource.sgh_GroupType;
      this.sgh_GroupName = pSource.sgh_GroupName;
      this.sgh_Memo = pSource.sgh_Memo;
      this.sgh_SortNo = pSource.sgh_SortNo;
      this.sgh_UseYn = pSource.sgh_UseYn;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.sgd_GroupCode == 0)
      {
        this.message = "지점그룹 코드(sgd_GroupCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sgd_StoreCode == 0)
      {
        this.message = "지점코드(sgd_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sgd_SiteID != 0L)
        return EnumDataCheck.Success;
      this.message = "싸이트(sgd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
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
      IList<StoreGroupDetailView> storeGroupDetailViewList = p_db.Create<StoreGroupDetailView>().SelectListE<StoreGroupDetailView>((object) new Hashtable()
      {
        {
          (object) "sgd_SiteID",
          (object) this.sgd_SiteID
        },
        {
          (object) "sgd_StoreCode",
          (object) this.sgd_StoreCode
        }
      });
      if (this.IsNew)
      {
        if (storeGroupDetailViewList != null && storeGroupDetailViewList.Count > 0)
        {
          this.message = "지점코드(sgd_StoreCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} 사용중.", (object) storeGroupDetailViewList[0].si_StoreName, (object) storeGroupDetailViewList[0].sgd_StoreCode, (object) EnumDataCheck.Exists.ToDescription());
          return EnumDataCheck.Exists;
        }
      }
      else if (this.IsUpdate)
      {
        if (storeGroupDetailViewList != null && storeGroupDetailViewList.Count == 0)
        {
          this.message = "지점코드(sgd_StoreCode) " + EnumDataCheck.NULL.ToDescription();
          return EnumDataCheck.NULL;
        }
        if (storeGroupDetailViewList != null && storeGroupDetailViewList.Count > 1)
        {
          this.message = "지점코드(sgd_StoreCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} {3}건 사용중.", (object) storeGroupDetailViewList[0].si_StoreName, (object) storeGroupDetailViewList[0].sgd_StoreCode, (object) EnumDataCheck.Exists.ToDescription(), (object) storeGroupDetailViewList.Count.ToString("n0"));
          return EnumDataCheck.Exists;
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
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (p_app_employee.IsStore)
        return true;
      this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
      return false;
    }

    public string CreateSortNoQuery() => " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(sgd_SortNo), 0)+1 AS sgd_SortNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "sgd_GroupCode", (object) this.sgd_GroupCode) + string.Format(" AND {0}={1}", (object) "sgd_StoreCode", (object) this.sgd_StoreCode);

    public bool CreateSortNo(UniOleDatabase p_db)
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
          this.sgd_SortNo = uniOleDbRecordset.GetFieldInt(0);
        return this.sgd_SortNo > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public async Task<bool> CreateSortNoAsync(UniOleDatabase p_db)
    {
      StoreGroupDetailView storeGroupDetailView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(storeGroupDetailView.CreateCodeQuery()))
        {
          storeGroupDetailView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupDetailView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          storeGroupDetailView.sgd_SortNo = rs.GetFieldInt(0);
        return storeGroupDetailView.sgd_SortNo > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode));

    public override async Task<bool> InsertAsync()
    {
      StoreGroupDetailView storeGroupDetailView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeGroupDetailView.\u003C\u003En__0() && storeGroupDetailView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) storeGroupDetailView.sgd_GroupCode, (object) storeGroupDetailView.sgd_StoreCode));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      StoreGroupDetailView storeGroupDetailView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeGroupDetailView.\u003C\u003En__1(p_old) && storeGroupDetailView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) storeGroupDetailView.sgd_GroupCode, (object) storeGroupDetailView.sgd_StoreCode));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode));

    public override async Task<bool> UpdateExInsertAsync()
    {
      StoreGroupDetailView storeGroupDetailView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeGroupDetailView.\u003C\u003En__2() && storeGroupDetailView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) storeGroupDetailView.sgd_GroupCode, (object) storeGroupDetailView.sgd_StoreCode));
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
          if (this.sgd_SiteID == 0L)
            this.sgd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sgd_SortNo == 0 && !this.CreateCode(p_db))
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
      StoreGroupDetailView storeGroupDetailView = this;
      try
      {
        storeGroupDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeGroupDetailView.DataCheck(p_db))
            throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (storeGroupDetailView.sgd_SiteID == 0L)
            storeGroupDetailView.sgd_SiteID = p_app_employee.emp_SiteID;
          if (!storeGroupDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (storeGroupDetailView.sgd_SortNo == 0)
        {
          if (!await storeGroupDetailView.CreateCodeAsync(p_db))
            throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await storeGroupDetailView.InsertAsync())
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 등록 오류");
        storeGroupDetailView.db_status = 4;
        storeGroupDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeGroupDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeGroupDetailView.message = ex.Message;
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
        if (this.sgd_SortNo == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 순서(sgd_SortNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      StoreGroupDetailView storeGroupDetailView = this;
      try
      {
        storeGroupDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeGroupDetailView.DataCheck(p_db))
            throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!storeGroupDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (storeGroupDetailView.sgd_SortNo == 0)
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 순서(sgd_SortNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await storeGroupDetailView.UpdateAsync())
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 변경 오류");
        storeGroupDetailView.db_status = 4;
        storeGroupDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeGroupDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeGroupDetailView.message = ex.Message;
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
      StoreGroupDetailView storeGroupDetailView = this;
      try
      {
        storeGroupDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != storeGroupDetailView.DataCheck(p_db))
            throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!storeGroupDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await storeGroupDetailView.DeleteAsync())
          throw new UniServiceException(storeGroupDetailView.message, storeGroupDetailView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        storeGroupDetailView.db_status = 4;
        storeGroupDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        storeGroupDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        storeGroupDetailView.message = ex.Message;
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
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.sgh_GroupType = p_rs.GetFieldInt("sgh_GroupType");
      this.sgh_GroupName = p_rs.GetFieldString("sgh_GroupName");
      this.sgh_Memo = p_rs.GetFieldString("sgh_Memo");
      this.sgh_SortNo = p_rs.GetFieldInt("sgh_SortNo");
      this.sgh_UseYn = p_rs.GetFieldString("sgh_UseYn");
      return true;
    }

    public async Task<StoreGroupDetailView> SelectOneAsync(
      int p_sgd_GroupCode,
      int p_sgd_StoreCode,
      long p_sgd_SiteID = 0)
    {
      StoreGroupDetailView storeGroupDetailView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sgd_GroupCode",
          (object) p_sgd_GroupCode
        },
        {
          (object) "sgd_StoreCode",
          (object) p_sgd_StoreCode
        }
      };
      if (p_sgd_SiteID > 0L)
        p_param.Add((object) "sgd_SiteID", (object) p_sgd_SiteID);
      return await storeGroupDetailView.SelectOneTAsync<StoreGroupDetailView>((object) p_param);
    }

    public async Task<IList<StoreGroupDetailView>> SelectListAsync(object p_param)
    {
      StoreGroupDetailView storeGroupDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(storeGroupDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, storeGroupDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(storeGroupDetailView1.GetSelectQuery(p_param)))
        {
          storeGroupDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StoreGroupDetailView>) null;
        }
        IList<StoreGroupDetailView> lt_list = (IList<StoreGroupDetailView>) new List<StoreGroupDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StoreGroupDetailView storeGroupDetailView2 = storeGroupDetailView1.OleDB.Create<StoreGroupDetailView>();
            if (storeGroupDetailView2.GetFieldValues(rs))
            {
              storeGroupDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(storeGroupDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeGroupDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "sgh_GroupCode") && Convert.ToInt32(hashtable[(object) "sgh_GroupCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgh_GroupCode", hashtable[(object) "sgh_GroupCode"]));
        if (hashtable.ContainsKey((object) "sgh_GroupType") && Convert.ToInt32(hashtable[(object) "sgh_GroupType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgh_GroupType", hashtable[(object) "sgh_GroupType"]));
        if (hashtable.ContainsKey((object) "sgh_UseYn") && hashtable[(object) "sgh_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sgh_UseYn", hashtable[(object) "sgh_UseYn"]));
        if (hashtable.ContainsKey((object) "si_UseYn") && hashtable[(object) "si_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "si_UseYn", hashtable[(object) "si_UseYn"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
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
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sgd_SiteID") && Convert.ToInt64(hashtable[(object) "sgd_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "sgd_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HEADER AS ( SELECT sgh_GroupCode,sgh_SiteID,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreGroupHeader, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "sgh_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  sgd_GroupCode,sgd_StoreCode,sgd_SiteID,sgd_SortNo,sgd_InDate,sgd_InUser,sgd_ModDate,sgd_ModUser,inEmpName,modEmpName,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_HEADER ON sgd_GroupCode=sgh_GroupCode AND sgd_SiteID=sgh_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON sgd_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON sgd_ModUser=emp_CodeMod LEFT OUTER JOIN T_STORE ON sgd_StoreCode=si_StoreCode");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY sgd_GroupCode,sgd_StoreCode");
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
