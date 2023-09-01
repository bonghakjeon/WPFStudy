// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore.CampaignStoreView
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore
{
  public class CampaignStoreView : TCampaignStore<CampaignStoreView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private int _si_StoreType;
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
      columnInfo.Add("si_StoreType", new TTableColumn()
      {
        tc_orgin_name = "si_StoreType",
        tc_trans_name = "지점타입",
        tc_comm_code = 30,
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
      this.si_StoreType = 0;
      this.si_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CampaignStoreView();

    public override object Clone()
    {
      CampaignStoreView campaignStoreView = base.Clone() as CampaignStoreView;
      campaignStoreView.si_StoreName = this.si_StoreName;
      campaignStoreView.si_StoreViewCode = this.si_StoreViewCode;
      campaignStoreView.si_StoreType = this.si_StoreType;
      campaignStoreView.si_UseYn = this.si_UseYn;
      campaignStoreView.inEmpName = this.inEmpName;
      campaignStoreView.modEmpName = this.modEmpName;
      return (object) campaignStoreView;
    }

    public void PutData(CampaignStoreView pSource)
    {
      this.PutData((TCampaignStore) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_StoreType = pSource.si_StoreType;
      this.si_UseYn = pSource.si_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.cis_SiteID == 0L)
      {
        this.message = "싸이트(cis_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.cis_CampaignCode == 0L)
      {
        this.message = "캠페인코드(cis_CampaignCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.cis_StoreCode != 0)
        return EnumDataCheck.Success;
      this.message = "지점코드(cis_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsCampaignSave)
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
          if (this.cis_SiteID == 0L)
            this.cis_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
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
      CampaignStoreView campaignStoreView = this;
      try
      {
        campaignStoreView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await campaignStoreView.DataCheckAsync(p_db))
            throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (campaignStoreView.cis_SiteID == 0L)
            campaignStoreView.cis_SiteID = p_app_employee.emp_SiteID;
          if (!campaignStoreView.IsPermit(p_app_employee))
            throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await campaignStoreView.InsertAsync())
          throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        campaignStoreView.db_status = 4;
        campaignStoreView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignStoreView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignStoreView.message = ex.Message;
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
      CampaignStoreView campaignStoreView = this;
      try
      {
        campaignStoreView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await campaignStoreView.DataCheckAsync(p_db))
            throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!campaignStoreView.IsPermit(p_app_employee))
          throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await campaignStoreView.DeleteAsync())
          throw new UniServiceException(campaignStoreView.message, campaignStoreView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        campaignStoreView.db_status = 4;
        campaignStoreView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignStoreView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignStoreView.message = ex.Message;
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
      return true;
    }

    public async Task<CampaignStoreView> SelectOneAsync(
      long p_cis_CampaignCode,
      int p_cis_StoreCode,
      long p_cis_SiteID = 0)
    {
      CampaignStoreView campaignStoreView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cis_CampaignCode",
          (object) p_cis_CampaignCode
        },
        {
          (object) "cis_StoreCode",
          (object) p_cis_StoreCode
        }
      };
      if (p_cis_SiteID > 0L)
        p_param.Add((object) "cis_SiteID", (object) p_cis_SiteID);
      return await campaignStoreView.SelectOneTAsync<CampaignStoreView>((object) p_param);
    }

    public CampaignStoreView SelectOne(
      long p_cis_CampaignCode,
      int p_cis_StoreCode,
      long p_cis_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cis_CampaignCode",
          (object) p_cis_CampaignCode
        },
        {
          (object) "cis_StoreCode",
          (object) p_cis_StoreCode
        }
      };
      if (p_cis_SiteID > 0L)
        p_param.Add((object) "cis_SiteID", (object) p_cis_SiteID);
      return this.SelectOneT<CampaignStoreView>((object) p_param);
    }

    public async Task<IList<CampaignStoreView>> SelectListAsync(object p_param)
    {
      CampaignStoreView campaignStoreView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignStoreView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignStoreView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignStoreView1.GetSelectQuery(p_param)))
        {
          campaignStoreView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignStoreView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CampaignStoreView>) null;
        }
        IList<CampaignStoreView> lt_list = (IList<CampaignStoreView>) new List<CampaignStoreView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CampaignStoreView campaignStoreView2 = campaignStoreView1.OleDB.Create<CampaignStoreView>();
            if (campaignStoreView2.GetFieldValues(rs))
            {
              campaignStoreView2.row_number = lt_list.Count + 1;
              lt_list.Add(campaignStoreView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignStoreView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<CampaignStoreView> SelectEnumerableAsync(object p_param)
    {
      CampaignStoreView campaignStoreView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignStoreView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignStoreView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignStoreView1.GetSelectQuery(p_param)))
        {
          campaignStoreView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignStoreView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            CampaignStoreView campaignStoreView2 = campaignStoreView1.OleDB.Create<CampaignStoreView>();
            if (campaignStoreView2.GetFieldValues(rs))
            {
              campaignStoreView2.row_number = ++row_number;
              yield return campaignStoreView2;
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

    public async Task<IList<CampaignStoreView>> SelectListExistsAsync(object p_param)
    {
      CampaignStoreView campaignStoreView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignStoreView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignStoreView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignStoreView1.GetSelectQuery(p_param)))
        {
          campaignStoreView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignStoreView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CampaignStoreView>) null;
        }
        IList<CampaignStoreView> lt_list = (IList<CampaignStoreView>) new List<CampaignStoreView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CampaignStoreView campaignStoreView2 = campaignStoreView1.OleDB.Create<CampaignStoreView>();
            if (campaignStoreView2.GetFieldValues(rs))
            {
              campaignStoreView2.row_number = lt_list.Count + 1;
              lt_list.Add(campaignStoreView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignStoreView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
          if (hashtable.ContainsKey((object) "cis_SiteID") && Convert.ToInt64(hashtable[(object) "cis_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "cis_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreType,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  cis_CampaignCode,cis_StoreCode,cis_SiteID,cis_InDate,cis_InUser,cis_ModDate,cis_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON cis_StoreCode=si_StoreCode AND cis_SiteID=si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON cis_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON cis_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY cis_CampaignCode,cis_StoreCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY cis_CampaignCode,cis_StoreCode");
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
