// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.ProfitLossWorkCntView
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

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class ProfitLossWorkCntView : TProfitLossWorkCnt<ProfitLossWorkCntView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _emp_Name;
    private IList<ProfitLossWorkCntLogView> _Lt_History;

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
    public IList<ProfitLossWorkCntLogView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<ProfitLossWorkCntLogView>) new List<ProfitLossWorkCntLogView>());
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
      this.Lt_History = (IList<ProfitLossWorkCntLogView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossWorkCntView();

    public override object Clone()
    {
      ProfitLossWorkCntView profitLossWorkCntView = base.Clone() as ProfitLossWorkCntView;
      profitLossWorkCntView.si_StoreName = this.si_StoreName;
      profitLossWorkCntView.si_StoreViewCode = this.si_StoreViewCode;
      profitLossWorkCntView.si_UseYn = this.si_UseYn;
      profitLossWorkCntView.si_StoreType = this.si_StoreType;
      profitLossWorkCntView.emp_Name = this.emp_Name;
      profitLossWorkCntView.Lt_History = this.Lt_History;
      return (object) profitLossWorkCntView;
    }

    public void PutData(ProfitLossWorkCntView pSource)
    {
      this.PutData((TProfitLossWorkCnt) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.emp_Name = pSource.emp_Name;
      this.Lt_History = (IList<ProfitLossWorkCntLogView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (ProfitLossWorkCntLogView pSource1 in (IEnumerable<ProfitLossWorkCntLogView>) pSource.Lt_History)
      {
        ProfitLossWorkCntLogView lossWorkCntLogView = new ProfitLossWorkCntLogView();
        lossWorkCntLogView.PutData(pSource1);
        this.Lt_History.Add(lossWorkCntLogView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.plwc_SiteID == 0L)
      {
        this.message = "싸이트(plwc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwc_YyyyMm == 0)
      {
        this.message = "결산년월(plwc_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwc_StoreCode == 0)
      {
        this.message = "지점코드(plwc_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.plwc_WorkDate;
      if (!nullable.HasValue)
      {
        this.message = "작업일시(plwc_WorkDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.plwc_OriginDate;
      if (nullable.HasValue)
        return EnumDataCheck.Success;
      this.message = "작업 기준일자(plwc_OriginDate)  " + EnumDataCheck.NULL.ToDescription();
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
          if (this.plwc_SiteID == 0L)
            this.plwc_SiteID = p_app_employee.emp_SiteID;
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
      ProfitLossWorkCntView profitLossWorkCntView = this;
      try
      {
        profitLossWorkCntView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != profitLossWorkCntView.DataCheck(p_db))
            throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (profitLossWorkCntView.plwc_SiteID == 0L)
            profitLossWorkCntView.plwc_SiteID = p_app_employee.emp_SiteID;
          if (!profitLossWorkCntView.IsPermit(p_app_employee))
            throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await profitLossWorkCntView.InsertAsync())
          throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 등록 오류");
        int num = await profitLossWorkCntView.InsertLogAsync(p_db, p_app_employee) ? 1 : 0;
        profitLossWorkCntView.db_status = 4;
        profitLossWorkCntView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        profitLossWorkCntView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        profitLossWorkCntView.message = ex.Message;
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
      ProfitLossWorkCntView profitLossWorkCntView = this;
      try
      {
        profitLossWorkCntView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != profitLossWorkCntView.DataCheck(p_db))
            throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!profitLossWorkCntView.IsPermit(p_app_employee))
          throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await profitLossWorkCntView.UpdateAsync())
          throw new UniServiceException(profitLossWorkCntView.message, profitLossWorkCntView.TableCode.ToDescription() + " 변경 오류");
        int num = await profitLossWorkCntView.InsertLogAsync(p_db, p_app_employee) ? 1 : 0;
        profitLossWorkCntView.db_status = 4;
        profitLossWorkCntView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        profitLossWorkCntView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        profitLossWorkCntView.message = ex.Message;
      }
      return false;
    }

    public bool InsertLog(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      ProfitLossWorkCntLogView lossWorkCntLogView = new ProfitLossWorkCntLogView();
      lossWorkCntLogView.plwcl_SysDate = new DateTime?(DateTime.Now);
      lossWorkCntLogView.plwcl_YyyyMm = this.plwc_YyyyMm;
      lossWorkCntLogView.plwcl_Day = this.plwc_OriginDate.Value.Day;
      lossWorkCntLogView.plwcl_StoreCode = this.plwc_StoreCode;
      lossWorkCntLogView.plwcl_SiteID = this.plwc_SiteID;
      lossWorkCntLogView.plwcl_ApplyWorkYn = this.plwc_ApplyCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_AmountWorkYn = this.plwc_AmountWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_QtyWorkYn = this.plwc_QtyWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_WeightWorkYn = this.plwc_WeightWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_MinusToZeroWorkYn = this.plwc_MinusToZeroWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_PoorToZeroWorkYn = this.plwc_PoorToZeroWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_EmpCode = this.plwc_WorkEmployee;
      return lossWorkCntLogView.InsertData(p_db, p_app_employee, false);
    }

    public async Task<bool> InsertLogAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      ProfitLossWorkCntView profitLossWorkCntView = this;
      ProfitLossWorkCntLogView lossWorkCntLogView = new ProfitLossWorkCntLogView();
      lossWorkCntLogView.plwcl_SysDate = new DateTime?(DateTime.Now);
      lossWorkCntLogView.plwcl_YyyyMm = profitLossWorkCntView.plwc_YyyyMm;
      lossWorkCntLogView.plwcl_Day = profitLossWorkCntView.plwc_OriginDate.Value.Day;
      lossWorkCntLogView.plwcl_StoreCode = profitLossWorkCntView.plwc_StoreCode;
      lossWorkCntLogView.plwcl_SiteID = profitLossWorkCntView.plwc_SiteID;
      lossWorkCntLogView.plwcl_ApplyWorkYn = profitLossWorkCntView.plwc_ApplyCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_AmountWorkYn = profitLossWorkCntView.plwc_AmountWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_QtyWorkYn = profitLossWorkCntView.plwc_QtyWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_WeightWorkYn = profitLossWorkCntView.plwc_WeightWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_MinusToZeroWorkYn = profitLossWorkCntView.plwc_MinusToZeroWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_PoorToZeroWorkYn = profitLossWorkCntView.plwc_PoorToZeroWorkCnt > 0 ? "Y" : "N";
      lossWorkCntLogView.plwcl_EmpCode = profitLossWorkCntView.plwc_WorkEmployee;
      return await lossWorkCntLogView.InsertDataAsync(p_db, p_app_employee, false);
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

    public async Task<ProfitLossWorkCntView> SelectOneAsync(
      int p_plwc_YyyyMm,
      int p_plwc_StoreCode,
      long p_plwc_SiteID = 0)
    {
      ProfitLossWorkCntView profitLossWorkCntView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "plwc_YyyyMm",
          (object) p_plwc_YyyyMm
        },
        {
          (object) "plwc_StoreCode",
          (object) p_plwc_StoreCode
        }
      };
      if (p_plwc_SiteID > 0L)
        p_param.Add((object) "plwc_SiteID", (object) p_plwc_SiteID);
      return await profitLossWorkCntView.SelectOneTAsync<ProfitLossWorkCntView>((object) p_param);
    }

    public async Task<IList<ProfitLossWorkCntView>> SelectListAsync(object p_param)
    {
      ProfitLossWorkCntView profitLossWorkCntView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(profitLossWorkCntView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, profitLossWorkCntView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(profitLossWorkCntView1.GetSelectQuery(p_param)))
        {
          profitLossWorkCntView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossWorkCntView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossWorkCntView>) null;
        }
        IList<ProfitLossWorkCntView> lt_list = (IList<ProfitLossWorkCntView>) new List<ProfitLossWorkCntView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossWorkCntView profitLossWorkCntView2 = profitLossWorkCntView1.OleDB.Create<ProfitLossWorkCntView>();
            if (profitLossWorkCntView2.GetFieldValues(rs))
            {
              profitLossWorkCntView2.row_number = lt_list.Count + 1;
              lt_list.Add(profitLossWorkCntView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + profitLossWorkCntView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
          if (hashtable.ContainsKey((object) "plwc_SiteID") && Convert.ToInt64(hashtable[(object) "plwc_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "plwc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE AS ( SELECT emp_Code,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("plwc_SiteID"))
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
        stringBuilder.Append(" SELECT  plwc_YyyyMm,plwc_StoreCode,plwc_SiteID,plwc_WorkCnt,plwc_WorkDate,plwc_WorkEmployee,plwc_ApplyCnt,plwc_ApplyDate,plwc_AmountWorkCnt,plwc_AmountWorkDate,plwc_QtyWorkCnt,plwc_QtyWorkDate,plwc_WeightWorkCnt,plwc_WeightWorkDate,plwc_PoorToZeroWorkCnt,plwc_PoorToZeroWorkDate,plwc_MinusToZeroWorkCnt,plwc_MinusToZeroWorkDate,plwc_OriginDate\n,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType,emp_Name\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON plwc_StoreCode=si_StoreCode AND plwc_SiteID=si_SiteID\n LEFT OUTER JOIN T_EMPLOYEE ON plwc_WorkEmployee=emp_Code");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num2 > 0)
        {
          switch (num2)
          {
            case 1:
              stringBuilder.Append(" ORDER BY plwc_StoreCode,plwc_YyyyMm DESC");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY plwc_YyyyMm DESC,plwc_StoreCode");
              break;
            default:
              stringBuilder.Append(" ORDER BY plwc_StoreCode,plwc_YyyyMm DESC");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY plwc_StoreCode,plwc_YyyyMm DESC");
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
