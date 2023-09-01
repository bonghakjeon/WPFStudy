// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.InventoryWorkCntView
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

namespace UniBiz.Bo.Models.UniStock.Inventory.InventoryWork
{
  public class InventoryWorkCntView : TInventoryWorkCnt<InventoryWorkCntView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _emp_Name;
    private IList<InventoryWorkCntLogView> _Lt_History;

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
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

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

    public string emp_Name
    {
      get => this._emp_Name;
      set
      {
        this._emp_Name = value;
        this.Changed(nameof (emp_Name));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<InventoryWorkCntLogView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<InventoryWorkCntLogView>) new List<InventoryWorkCntLogView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("emp_Name", new TTableColumn()
      {
        tc_orgin_name = "emp_Name",
        tc_trans_name = "등록사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.emp_Name = string.Empty;
      this.Lt_History = (IList<InventoryWorkCntLogView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventoryWorkCntView();

    public override object Clone()
    {
      InventoryWorkCntView inventoryWorkCntView = base.Clone() as InventoryWorkCntView;
      inventoryWorkCntView.si_StoreName = this.si_StoreName;
      inventoryWorkCntView.si_StoreViewCode = this.si_StoreViewCode;
      inventoryWorkCntView.si_UseYn = this.si_UseYn;
      inventoryWorkCntView.si_StoreType = this.si_StoreType;
      inventoryWorkCntView.emp_Name = this.emp_Name;
      inventoryWorkCntView.Lt_History = (IList<InventoryWorkCntLogView>) null;
      if (this.Lt_History.Count > 0)
      {
        foreach (InventoryWorkCntLogView inventoryWorkCntLogView in (IEnumerable<InventoryWorkCntLogView>) this.Lt_History)
          inventoryWorkCntView.Lt_History.Add(inventoryWorkCntLogView);
      }
      return (object) inventoryWorkCntView;
    }

    public void PutData(InventoryWorkCntView pSource)
    {
      this.PutData((TInventoryWorkCnt) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.emp_Name = pSource.emp_Name;
      this.Lt_History = (IList<InventoryWorkCntLogView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (InventoryWorkCntLogView pSource1 in (IEnumerable<InventoryWorkCntLogView>) pSource.Lt_History)
      {
        InventoryWorkCntLogView inventoryWorkCntLogView = new InventoryWorkCntLogView();
        inventoryWorkCntLogView.PutData(pSource1);
        this.Lt_History.Add(inventoryWorkCntLogView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.iwc_SiteID == 0L)
      {
        this.message = "싸이트(iwc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.iwc_InventoryDate;
      if (!nullable.HasValue)
      {
        this.message = "재고조사일자(iwc_InventoryDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.iwc_StoreCode == 0)
      {
        this.message = "지점코드(iwc_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      nullable = this.iwc_WorkDate;
      if (nullable.HasValue)
        return EnumDataCheck.Success;
      this.message = "작업일자(iwc_WorkDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsInvtClosed)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 작업 불가.";
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
          if (this.iwc_SiteID == 0L)
            this.iwc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.InsertLog(p_db, p_app_employee);
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
      InventoryWorkCntView inventoryWorkCntView = this;
      try
      {
        inventoryWorkCntView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryWorkCntView.DataCheck(p_db))
            throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (inventoryWorkCntView.iwc_SiteID == 0L)
            inventoryWorkCntView.iwc_SiteID = p_app_employee.emp_SiteID;
          if (!inventoryWorkCntView.IsPermit(p_app_employee))
            throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await inventoryWorkCntView.InsertAsync())
          throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 등록 오류");
        int num = await inventoryWorkCntView.InsertLogAsync(p_db, p_app_employee) ? 1 : 0;
        inventoryWorkCntView.db_status = 4;
        inventoryWorkCntView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryWorkCntView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryWorkCntView.message = ex.Message;
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
        this.InsertLog(p_db, p_app_employee);
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
      InventoryWorkCntView inventoryWorkCntView = this;
      try
      {
        inventoryWorkCntView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryWorkCntView.DataCheck(p_db))
            throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!inventoryWorkCntView.IsPermit(p_app_employee))
          throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await inventoryWorkCntView.UpdateAsync())
          throw new UniServiceException(inventoryWorkCntView.message, inventoryWorkCntView.TableCode.ToDescription() + " 변경 오류");
        int num = await inventoryWorkCntView.InsertLogAsync(p_db, p_app_employee) ? 1 : 0;
        inventoryWorkCntView.db_status = 4;
        inventoryWorkCntView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryWorkCntView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryWorkCntView.message = ex.Message;
      }
      return false;
    }

    public bool InsertLog(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      InventoryWorkCntLogView inventoryWorkCntLogView = new InventoryWorkCntLogView();
      inventoryWorkCntLogView.iwcl_SysDate = new DateTime?(DateTime.Now);
      inventoryWorkCntLogView.iwcl_InventoryDate = this.iwc_InventoryDate;
      inventoryWorkCntLogView.iwcl_StoreCode = this.iwc_StoreCode;
      inventoryWorkCntLogView.iwcl_SiteID = this.iwc_SiteID;
      inventoryWorkCntLogView.iwcl_AmountWorkYn = this.iwc_AmountWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_QtyWorkYn = this.iwc_QtyWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_WeightWorkYn = this.iwc_WeightWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_AllWorkYn = this.iwc_AllWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_MinusToZeroWorkYn = this.iwc_MinusToZeroWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_PoorToZeroWorkYn = this.iwc_PoorToZeroWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_EmpCode = this.iwc_WorkEmployee;
      return inventoryWorkCntLogView.InsertData(p_db, p_app_employee, false);
    }

    public async Task<bool> InsertLogAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      InventoryWorkCntView inventoryWorkCntView = this;
      InventoryWorkCntLogView inventoryWorkCntLogView = new InventoryWorkCntLogView();
      inventoryWorkCntLogView.iwcl_SysDate = new DateTime?(DateTime.Now);
      inventoryWorkCntLogView.iwcl_InventoryDate = inventoryWorkCntView.iwc_InventoryDate;
      inventoryWorkCntLogView.iwcl_StoreCode = inventoryWorkCntView.iwc_StoreCode;
      inventoryWorkCntLogView.iwcl_SiteID = inventoryWorkCntView.iwc_SiteID;
      inventoryWorkCntLogView.iwcl_AmountWorkYn = inventoryWorkCntView.iwc_AmountWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_QtyWorkYn = inventoryWorkCntView.iwc_QtyWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_WeightWorkYn = inventoryWorkCntView.iwc_WeightWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_AllWorkYn = inventoryWorkCntView.iwc_AllWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_MinusToZeroWorkYn = inventoryWorkCntView.iwc_MinusToZeroWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_PoorToZeroWorkYn = inventoryWorkCntView.iwc_PoorToZeroWorkCnt > 0 ? "Y" : "N";
      inventoryWorkCntLogView.iwcl_EmpCode = inventoryWorkCntView.iwc_WorkEmployee;
      return await inventoryWorkCntLogView.InsertDataAsync(p_db, p_app_employee, false);
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      return true;
    }

    public async Task<InventoryWorkCntView> SelectOneAsync(
      DateTime p_iwc_InventoryDate,
      int p_iwc_StoreCode,
      long p_iwc_SiteID = 0)
    {
      InventoryWorkCntView inventoryWorkCntView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "iwc_InventoryDate",
          (object) p_iwc_InventoryDate
        },
        {
          (object) "iwc_StoreCode",
          (object) p_iwc_StoreCode
        }
      };
      if (p_iwc_SiteID > 0L)
        p_param.Add((object) "iwc_SiteID", (object) p_iwc_SiteID);
      return await inventoryWorkCntView.SelectOneTAsync<InventoryWorkCntView>((object) p_param);
    }

    public async Task<IList<InventoryWorkCntView>> SelectListAsync(object p_param)
    {
      InventoryWorkCntView inventoryWorkCntView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryWorkCntView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryWorkCntView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryWorkCntView1.GetSelectQuery(p_param)))
        {
          inventoryWorkCntView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryWorkCntView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventoryWorkCntView>) null;
        }
        IList<InventoryWorkCntView> lt_list = (IList<InventoryWorkCntView>) new List<InventoryWorkCntView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventoryWorkCntView inventoryWorkCntView2 = inventoryWorkCntView1.OleDB.Create<InventoryWorkCntView>();
            if (inventoryWorkCntView2.GetFieldValues(rs))
            {
              inventoryWorkCntView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventoryWorkCntView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryWorkCntView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        string empty = string.Empty;
        long num1 = 0;
        int num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "iwc_SiteID") && Convert.ToInt64(hashtable[(object) "iwc_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "iwc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE AS ( SELECT emp_Code,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("iwc_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num1);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  iwc_InventoryDate,iwc_StoreCode,iwc_SiteID,iwc_WorkCnt,iwc_WorkDate,iwc_WorkEmployee,iwc_AmountWorkCnt,iwc_AmountWorkDate,iwc_QtyWorkCnt,iwc_QtyWorkDate,iwc_WeightWorkCnt,iwc_WeightWorkDate,iwc_AllWorkCnt,iwc_AllWorkDate,iwc_MinusToZeroWorkCnt,iwc_MinusToZeroWorkDate,iwc_PoorToZeroWorkCnt,iwc_PoorToZeroWorkDate,iwc_UnRegToZeroWorkCnt,iwc_UnRegToZeroWorkDate\n,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType,emp_Name\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON iwc_StoreCode=si_StoreCode AND iwc_SiteID=si_SiteID\n LEFT OUTER JOIN T_EMPLOYEE ON iwc_WorkEmployee=emp_Code");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num2 > 0)
        {
          switch (num2)
          {
            case 1:
              stringBuilder.Append(" ORDER BY iwc_StoreCode,iwc_InventoryDate DESC");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY iwc_InventoryDate DESC,iwc_StoreCode");
              break;
            default:
              stringBuilder.Append(" ORDER BY iwc_StoreCode,iwc_InventoryDate DESC");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY iwc_StoreCode,iwc_InventoryDate DESC");
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
