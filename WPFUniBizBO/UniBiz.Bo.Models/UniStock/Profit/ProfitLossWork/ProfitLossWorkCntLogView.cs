// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.ProfitLossWorkCntLogView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class ProfitLossWorkCntLogView : TProfitLossWorkCntLog<ProfitLossWorkCntLogView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _emp_Name;

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
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossWorkCntLogView();

    public override object Clone()
    {
      ProfitLossWorkCntLogView lossWorkCntLogView = base.Clone() as ProfitLossWorkCntLogView;
      lossWorkCntLogView.si_StoreName = this.si_StoreName;
      lossWorkCntLogView.si_StoreViewCode = this.si_StoreViewCode;
      lossWorkCntLogView.si_UseYn = this.si_UseYn;
      lossWorkCntLogView.si_StoreType = this.si_StoreType;
      lossWorkCntLogView.emp_Name = this.emp_Name;
      return (object) lossWorkCntLogView;
    }

    public void PutData(ProfitLossWorkCntLogView pSource)
    {
      this.PutData((TProfitLossWorkCntLog) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.emp_Name = pSource.emp_Name;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.plwcl_SiteID == 0L)
      {
        this.message = "싸이트(plwcl_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwcl_YyyyMm == 0)
      {
        this.message = "결산년월(plwcl_YyyyMm)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwcl_Day == 0)
      {
        this.message = "일자(plwcl_Day)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwcl_StoreCode == 0)
      {
        this.message = "지점코드(plwcl_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.plwcl_SysDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "작업일시(plwcl_SysDate)  " + EnumDataCheck.NULL.ToDescription();
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
          if (this.plwcl_SiteID == 0L)
            this.plwcl_SiteID = p_app_employee.emp_SiteID;
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
      ProfitLossWorkCntLogView lossWorkCntLogView = this;
      try
      {
        lossWorkCntLogView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != lossWorkCntLogView.DataCheck(p_db))
            throw new UniServiceException(lossWorkCntLogView.message, lossWorkCntLogView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (lossWorkCntLogView.plwcl_SiteID == 0L)
            lossWorkCntLogView.plwcl_SiteID = p_app_employee.emp_SiteID;
          if (!lossWorkCntLogView.IsPermit(p_app_employee))
            throw new UniServiceException(lossWorkCntLogView.message, lossWorkCntLogView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await lossWorkCntLogView.InsertAsync())
          throw new UniServiceException(lossWorkCntLogView.message, lossWorkCntLogView.TableCode.ToDescription() + " 등록 오류");
        lossWorkCntLogView.db_status = 4;
        lossWorkCntLogView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        lossWorkCntLogView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        lossWorkCntLogView.message = ex.Message;
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
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.emp_Name = p_rs.GetFieldString("emp_Name");
      return true;
    }

    public async Task<ProfitLossWorkCntLogView> SelectOneAsync(
      DateTime p_plwcl_SysDate,
      int p_plwcl_YyyyMm,
      int p_plwcl_Day,
      int p_plwcl_StoreCode,
      long p_plwcl_SiteID = 0)
    {
      ProfitLossWorkCntLogView lossWorkCntLogView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "plwcl_SysDate",
          (object) p_plwcl_SysDate
        },
        {
          (object) "plwcl_YyyyMm",
          (object) p_plwcl_YyyyMm
        },
        {
          (object) "plwcl_Day",
          (object) p_plwcl_Day
        },
        {
          (object) "plwcl_StoreCode",
          (object) p_plwcl_StoreCode
        }
      };
      if (p_plwcl_SiteID > 0L)
        p_param.Add((object) "plwcl_SiteID", (object) p_plwcl_SiteID);
      return await lossWorkCntLogView.SelectOneTAsync<ProfitLossWorkCntLogView>((object) p_param);
    }

    public async Task<IList<ProfitLossWorkCntLogView>> SelectListAsync(object p_param)
    {
      ProfitLossWorkCntLogView lossWorkCntLogView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(lossWorkCntLogView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, lossWorkCntLogView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(lossWorkCntLogView1.GetSelectQuery(p_param)))
        {
          lossWorkCntLogView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + lossWorkCntLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossWorkCntLogView>) null;
        }
        IList<ProfitLossWorkCntLogView> lt_list = (IList<ProfitLossWorkCntLogView>) new List<ProfitLossWorkCntLogView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossWorkCntLogView lossWorkCntLogView2 = lossWorkCntLogView1.OleDB.Create<ProfitLossWorkCntLogView>();
            if (lossWorkCntLogView2.GetFieldValues(rs))
            {
              lossWorkCntLogView2.row_number = lt_list.Count + 1;
              lt_list.Add(lossWorkCntLogView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + lossWorkCntLogView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        long num = 0;
        bool flag = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "plwcl_SiteID") && Convert.ToInt64(hashtable[(object) "plwcl_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "plwcl_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "ProfitLossWorkCnt_DEFULT_TABLE_") && Convert.ToBoolean(hashtable[(object) "ProfitLossWorkCnt_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "ProfitLossWorkCnt_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE AS (\nSELECT emp_Code,emp_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("plwcl_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num));
        if (flag)
        {
          stringBuilder.Append("\n,T_HEADER AS ( SELECT plwc_YyyyMm,plwc_StoreCode,plwc_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossWorkCnt, (object) DbQueryHelper.ToWithNolock()));
          stringBuilder.Append("\n");
          stringBuilder.Append(new ProfitLossWorkCntView().GetSelectWhereAnd(p_param));
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECT  plwcl_SysDate,plwcl_YyyyMm,plwcl_Day,plwcl_StoreCode,plwcl_SiteID,plwcl_ApplyWorkYn,plwcl_AmountWorkYn,plwcl_QtyWorkYn,plwcl_WeightWorkYn,plwcl_MinusToZeroWorkYn,plwcl_PoorToZeroWorkYn,plwcl_EmpCode\n,si_StoreName,si_StoreViewCode,si_UseYn,si_StoreType\n,emp_Name\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock());
        if (flag)
          stringBuilder.Append("\nINNER JOIN T_HEADER ON plwc_YyyyMm=plwcl_YyyyMm AND plwc_StoreCode=plwcl_StoreCode AND plwc_SiteID=plwcl_SiteID");
        stringBuilder.Append("\nINNER JOIN T_STORE ON plwcl_StoreCode=si_StoreCode AND plwcl_SiteID=si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE ON plwcl_EmpCode=emp_Code");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY plwcl_SysDate DESC,plwcl_StoreCode,plwcl_YyyyMm DESC,plwcl_Day");
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
