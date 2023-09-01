// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd.MemberCycleStdView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd
{
  public class MemberCycleStdView : TMemberCycleStd<MemberCycleStdView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private string _inEmpName;
    private string _modEmpName;
    private string _arrStrStoreCode;
    private IList<MemberCycleStdView> _Lt_History;

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

    public string arrStrStoreCode
    {
      get => this._arrStrStoreCode ?? (this._arrStrStoreCode = string.Empty);
      set
      {
        this._arrStrStoreCode = value;
        this.Changed(nameof (arrStrStoreCode));
      }
    }

    [JsonPropertyName("lt_history")]
    public IList<MemberCycleStdView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<MemberCycleStdView>) new List<MemberCycleStdView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
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
      this.arrStrStoreCode = string.Empty;
      this.Lt_History = (IList<MemberCycleStdView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberCycleStdView();

    public override object Clone()
    {
      MemberCycleStdView memberCycleStdView = base.Clone() as MemberCycleStdView;
      memberCycleStdView.si_StoreName = this.si_StoreName;
      memberCycleStdView.si_StoreViewCode = this.si_StoreViewCode;
      memberCycleStdView.si_UseYn = this.si_UseYn;
      memberCycleStdView.inEmpName = this.inEmpName;
      memberCycleStdView.modEmpName = this.modEmpName;
      memberCycleStdView.arrStrStoreCode = this.arrStrStoreCode;
      memberCycleStdView.Lt_History = this.Lt_History;
      return (object) memberCycleStdView;
    }

    public void PutData(MemberCycleStdView pSource)
    {
      this.PutData((TMemberCycleStd) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.arrStrStoreCode = pSource.arrStrStoreCode;
      this.Lt_History = (IList<MemberCycleStdView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (MemberCycleStdView pSource1 in (IEnumerable<MemberCycleStdView>) pSource.Lt_History)
      {
        MemberCycleStdView memberCycleStdView = new MemberCycleStdView();
        memberCycleStdView.PutData(pSource1);
        this.Lt_History.Add(memberCycleStdView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mcs_SiteID == 0L)
      {
        this.message = "싸이트(mcs_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      IList<ProgOptionView> progOptionList = Enum2StrConverter.ToProgOptionList(this.mcs_SiteID, EnumOptionType.opt_OnlySiteMember);
      if (progOptionList != null && progOptionList.Count > 0)
      {
        if (Convert.ToInt32(progOptionList[0].opt_Value) != 0)
        {
          if (this.mcs_StoreCode == 0)
          {
            this.message = "지점코드(mcs_StoreCode) " + EnumDataCheck.Empty.ToDescription();
            return EnumDataCheck.Empty;
          }
        }
        else if (this.mcs_StoreCode > 0)
        {
          this.message = "지점코드(mcs_StoreCode) " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
      }
      DateTime? nullable = this.mcs_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(mcs_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mcs_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(mcs_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mcs_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.mcs_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 <= intFormat2)
        return EnumDataCheck.Success;
      this.message = "시작일(mcs_StartDate) > 종료일(mcs_EndDate)  " + EnumDataCheck.Valid.ToDescription();
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
      if (!p_app_employee.IsMemberStdSave)
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
          if (this.mcs_SiteID == 0L)
            this.mcs_SiteID = p_app_employee.emp_SiteID;
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
      MemberCycleStdView memberCycleStdView = this;
      try
      {
        memberCycleStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCycleStdView.DataCheck(p_db))
            throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberCycleStdView.mcs_SiteID == 0L)
            memberCycleStdView.mcs_SiteID = p_app_employee.emp_SiteID;
          if (!memberCycleStdView.IsPermit(p_app_employee))
            throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await memberCycleStdView.InsertAsync())
          throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 등록 오류");
        memberCycleStdView.db_status = 4;
        memberCycleStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCycleStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCycleStdView.message = ex.Message;
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
      MemberCycleStdView memberCycleStdView = this;
      try
      {
        memberCycleStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCycleStdView.DataCheck(p_db))
            throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberCycleStdView.IsPermit(p_app_employee))
          throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await memberCycleStdView.UpdateAsync())
          throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 변경 오류");
        memberCycleStdView.db_status = 4;
        memberCycleStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCycleStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCycleStdView.message = ex.Message;
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
      MemberCycleStdView memberCycleStdView = this;
      try
      {
        memberCycleStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != memberCycleStdView.DataCheck(p_db))
            throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberCycleStdView.IsPermit(p_app_employee))
          throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await memberCycleStdView.DeleteAsync())
          throw new UniServiceException(memberCycleStdView.message, memberCycleStdView.TableCode.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        memberCycleStdView.db_status = 4;
        memberCycleStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberCycleStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberCycleStdView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      MemberCycleStdView memberCycleStdView1 = this;
      try
      {
        memberCycleStdView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberCycleStdView1.DataCheck(p_db))
            throw new UniServiceException(memberCycleStdView1.message, memberCycleStdView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberCycleStdView1.mcs_SiteID == 0L)
            memberCycleStdView1.mcs_SiteID = p_app_employee.emp_SiteID;
          if (!memberCycleStdView1.IsPermit(p_app_employee))
            throw new UniServiceException(memberCycleStdView1.message, memberCycleStdView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        DateTime? nullable1;
        if (Enum2StrConverter.IsDataModLog(memberCycleStdView1.mcs_SiteID))
        {
          logs.dml_CodeInt = memberCycleStdView1.mcs_StoreCode;
          DataModLogView dataModLogView1 = logs;
          nullable1 = memberCycleStdView1.mcs_StartDate;
          long num = nullable1.Value.ToLong();
          dataModLogView1.dml_CodeLong = num;
          DataModLogView dataModLogView2 = logs;
          // ISSUE: variable of a boxed type
          __Boxed<int> mcsStoreCode = (ValueType) memberCycleStdView1.mcs_StoreCode;
          nullable1 = memberCycleStdView1.mcs_StartDate;
          // ISSUE: variable of a boxed type
          __Boxed<int> intFormat = (ValueType) nullable1.Value.ToIntFormat();
          // ISSUE: variable of a boxed type
          __Boxed<long> mcsSiteId = (ValueType) memberCycleStdView1.mcs_SiteID;
          string str = string.Format("{0}|{1}|{2}", (object) mcsStoreCode, (object) intFormat, (object) mcsSiteId);
          dataModLogView2.dml_CodeStr = str;
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(memberCycleStdView1.arrStrStoreCode))
          memberCycleStdView1.arrStrStoreCode = memberCycleStdView1.mcs_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "mcs_StoreCode_IN_", (object) memberCycleStdView1.arrStrStoreCode);
        Hashtable hashtable1 = param;
        nullable1 = memberCycleStdView1.mcs_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_START_DATE_", (object) local1);
        Hashtable hashtable2 = param;
        nullable1 = memberCycleStdView1.mcs_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_END_DATE_", (object) local2);
        IList<MemberCycleStdView> infos = await p_db.Create<MemberCycleStdView>().SelectListAsync((object) param);
        MemberCycleStdByStoreDic dic_Store = new MemberCycleStdByStoreDic();
        dic_Store.AddOriginRange((IEnumerable<MemberCycleStdView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(memberCycleStdView1.message, memberCycleStdView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "mcs_StoreCode_IN_", (object) memberCycleStdView1.arrStrStoreCode);
        Hashtable hashtable3 = param;
        nullable1 = memberCycleStdView1.mcs_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local3 = (ValueType) nullable1.Value;
        hashtable3.Add((object) "_DT_DATE_", (object) local3);
        IList<MemberCycleStdView> memberCycleStdViewList = await p_db.Create<MemberCycleStdView>().SelectListAsync((object) param);
        List<MemberCycleStdView> lt_origin_insert = new List<MemberCycleStdView>();
        MemberCycleStdView origin_start = (MemberCycleStdView) null;
        MemberCycleStdView origin_end = (MemberCycleStdView) null;
        foreach (MemberCycleStdView memberCycleStdView2 in (IEnumerable<MemberCycleStdView>) memberCycleStdViewList)
        {
          MemberCycleStdView item = memberCycleStdView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store.ContainsKey(item.mcs_StoreCode))
          {
            logs.Init(p_login_employee, memberCycleStdView1.TableCode, EnumEmpActionKind.UPDATE);
            nullable1 = item.mcs_EndDate;
            if (nullable1.HasValue)
            {
              nullable1 = item.mcs_EndDate;
              if (!nullable1.Equals((object) memberCycleStdView1.mcs_EndDate))
              {
                if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                  lt_sbLogs.Add(new StringBuilder());
                lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_EndDate", "종료일", item.mcs_EndDate, memberCycleStdView1.mcs_EndDate));
                lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
              }
            }
            if (!item.mcs_NewStdQty.Equals(memberCycleStdView1.mcs_NewStdQty))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_NewStdQty", "신규기준횟수", item.mcs_NewStdQty, memberCycleStdView1.mcs_NewStdQty));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mcs_Cycle1MinBuyCnt.Equals(memberCycleStdView1.mcs_Cycle1MinBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_Cycle1MinBuyCnt", "주기1최소횟수", item.mcs_Cycle1MinBuyCnt, memberCycleStdView1.mcs_Cycle1MinBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mcs_Cycle1MaxBuyCnt.Equals(memberCycleStdView1.mcs_Cycle1MaxBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_Cycle1MaxBuyCnt", "주기1최대구매횟수", item.mcs_Cycle1MaxBuyCnt, memberCycleStdView1.mcs_Cycle1MaxBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mcs_Cycle2MinBuyCnt.Equals(memberCycleStdView1.mcs_Cycle2MinBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_Cycle2MinBuyCnt", "주기2최소횟수", item.mcs_Cycle2MinBuyCnt, memberCycleStdView1.mcs_Cycle2MinBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mcs_Cycle2MaxBuyCnt.Equals(memberCycleStdView1.mcs_Cycle2MaxBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_Cycle2MaxBuyCnt", "주기2최대구매횟수", item.mcs_Cycle2MaxBuyCnt, memberCycleStdView1.mcs_Cycle2MaxBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mcs_DormancyPeriod.Equals(memberCycleStdView1.mcs_DormancyPeriod))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mcs_DormancyPeriod", "휴면산정기간", item.mcs_DormancyPeriod, memberCycleStdView1.mcs_DormancyPeriod));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.mcs_StartDate = memberCycleStdView1.mcs_StartDate;
            item.mcs_SiteID = memberCycleStdView1.mcs_SiteID;
            item.mcs_EndDate = memberCycleStdView1.mcs_EndDate;
            item.mcs_NewStdQty = memberCycleStdView1.mcs_NewStdQty;
            item.mcs_Cycle1MinBuyCnt = memberCycleStdView1.mcs_Cycle1MinBuyCnt;
            item.mcs_Cycle1MaxBuyCnt = memberCycleStdView1.mcs_Cycle1MaxBuyCnt;
            item.mcs_Cycle2MinBuyCnt = memberCycleStdView1.mcs_Cycle2MinBuyCnt;
            item.mcs_Cycle2MaxBuyCnt = memberCycleStdView1.mcs_Cycle2MaxBuyCnt;
            item.mcs_DormancyPeriod = memberCycleStdView1.mcs_DormancyPeriod;
            item.mcs_InUser = p_app_employee.emp_Code;
            item.mcs_ModUser = p_app_employee.emp_Code;
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<MemberCycleStdView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            foreach (MemberCycleStdView history in (IEnumerable<MemberCycleStdView>) dic_Store[item.mcs_StoreCode].Lt_History)
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                    lt_origin_insert[0].mcs_EndDate = history.mcs_EndDate;
                  else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                  {
                    MemberCycleStdView memberCycleStdView3 = lt_origin_insert[0];
                    nullable1 = history.mcs_StartDate;
                    DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                    memberCycleStdView3.mcs_EndDate = nullable2;
                  }
                }
                if (history.IntStartDate == item.IntStartDate)
                {
                  if (!await history.DeleteAsync())
                    throw new Exception(history.message);
                }
                else if (!await history.UpdateAsync((UbModelBase) null))
                  throw new Exception(history.message);
                if (item.IntEndDate > history.IntEndDate)
                {
                  if (lt_origin_insert.Count == 1)
                  {
                    if (origin_end == null)
                      origin_end = p_db.Create<MemberCycleStdView>();
                    else
                      origin_end.Clear();
                    origin_end.PutData(item);
                    lt_origin_insert.Add(origin_end);
                  }
                  MemberCycleStdView memberCycleStdView4 = lt_origin_insert[1];
                  nullable1 = history.mcs_EndDate;
                  DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                  memberCycleStdView4.mcs_StartDate = nullable3;
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberCycleStdView next_data = p_db.Create<MemberCycleStdView>();
                next_data.PutData(history);
                MemberCycleStdView memberCycleStdView5 = history;
                nullable1 = item.mcs_StartDate;
                DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                memberCycleStdView5.mcs_EndDate = nullable4;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                MemberCycleStdView memberCycleStdView6 = next_data;
                nullable1 = item.mcs_EndDate;
                DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                memberCycleStdView6.mcs_StartDate = nullable5;
                next_data.mcs_SiteID = memberCycleStdView1.mcs_SiteID;
                next_data = await next_data.InsertAsync() ? (MemberCycleStdView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                MemberCycleStdView memberCycleStdView7 = history;
                nullable1 = item.mcs_StartDate;
                DateTime? nullable6 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                memberCycleStdView7.mcs_EndDate = nullable6;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberCycleStdView memberCycleStdView8 = history;
                int mcsStoreCode = history.mcs_StoreCode;
                nullable1 = history.mcs_StartDate;
                DateTime p_mcs_StartDate = nullable1.Value;
                nullable1 = item.mcs_EndDate;
                DateTime dateAdd = nullable1.Value.GetDateAdd(0, 0, 1);
                long mcsSiteId = history.mcs_SiteID;
                if (!await memberCycleStdView8.UpdateStartDateAsync(mcsStoreCode, p_mcs_StartDate, dateAdd, mcsSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_origin_insert.Count == 2)
            {
              foreach (MemberCycleStdView memberCycleStdView9 in (IEnumerable<MemberCycleStdView>) dic_Store[item.mcs_StoreCode].Lt_History)
              {
                if (memberCycleStdView9.IntStartDate == lt_origin_insert[1].IntStartDate)
                {
                  int num = await memberCycleStdView9.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (MemberCycleStdView memberCycleStdView10 in lt_origin_insert)
            {
              if (memberCycleStdView10.IntStartDate <= memberCycleStdView10.IntEndDate)
              {
                if (!await memberCycleStdView10.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (MemberCycleStdView) null;
          }
        }
        memberCycleStdView1.db_status = 4;
        memberCycleStdView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberCycleStdView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberCycleStdView1.message = ex.Message;
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

    public async Task<MemberCycleStdView> SelectOneAsync(
      int p_mcs_StoreCode,
      DateTime p_mcs_StartDate,
      long p_mcs_SiteID = 0)
    {
      MemberCycleStdView memberCycleStdView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mcs_StoreCode",
          (object) p_mcs_StoreCode
        },
        {
          (object) "mcs_StartDate",
          (object) p_mcs_StartDate
        }
      };
      if (p_mcs_SiteID > 0L)
        p_param.Add((object) "mcs_SiteID", (object) p_mcs_SiteID);
      return await memberCycleStdView.SelectOneTAsync<MemberCycleStdView>((object) p_param);
    }

    public async Task<IList<MemberCycleStdView>> SelectListAsync(object p_param)
    {
      MemberCycleStdView memberCycleStdView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCycleStdView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCycleStdView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCycleStdView1.GetSelectQuery(p_param)))
        {
          memberCycleStdView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCycleStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberCycleStdView>) null;
        }
        IList<MemberCycleStdView> lt_list = (IList<MemberCycleStdView>) new List<MemberCycleStdView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberCycleStdView memberCycleStdView2 = memberCycleStdView1.OleDB.Create<MemberCycleStdView>();
            if (memberCycleStdView2.GetFieldValues(rs))
            {
              memberCycleStdView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberCycleStdView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCycleStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberCycleStdView> SelectEnumerableAsync(object p_param)
    {
      MemberCycleStdView memberCycleStdView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberCycleStdView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberCycleStdView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberCycleStdView1.GetSelectQuery(p_param)))
        {
          memberCycleStdView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberCycleStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberCycleStdView memberCycleStdView2 = memberCycleStdView1.OleDB.Create<MemberCycleStdView>();
            if (memberCycleStdView2.GetFieldValues(rs))
            {
              memberCycleStdView2.row_number = ++row_number;
              yield return memberCycleStdView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_"))
        string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
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
          if (hashtable2.ContainsKey((object) "mcs_SiteID") && Convert.ToInt64(hashtable2[(object) "mcs_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable2[(object) "mcs_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "MemberType_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mcs_StoreCode,mcs_StartDate,mcs_SiteID,mcs_EndDate,mcs_NewStdQty,mcs_Cycle1MinBuyCnt,mcs_Cycle1MaxBuyCnt,mcs_Cycle2MinBuyCnt,mcs_Cycle2MaxBuyCnt,mcs_DormancyPeriod,mcs_InDate,mcs_InUser,mcs_ModDate,mcs_ModUser\n,si_StoreName,si_StoreViewCode,si_UseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON mcs_StoreCode=si_StoreCode AND mcs_SiteID=si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mcs_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mcs_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
        {
          if (num1 == 1)
            stringBuilder.Append("\nORDER BY mcs_StoreCode,mcs_StartDate DESC");
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mcs_StoreCode,mcs_StartDate");
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
