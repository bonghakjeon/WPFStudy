// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory.MemberTypeHistoryView
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
using UniBiz.Bo.Models.UniMembers.Info.MemberType;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory
{
  public class MemberTypeHistoryView : TMemberTypeHistory<MemberTypeHistoryView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private string _inEmpName;
    private string _modEmpName;
    private string _mt_TypeName;
    private string _mt_Memo;
    private string _mt_UseYn;
    private string _arrStrStoreCode;
    private IList<MemberTypeHistoryView> _Lt_History;

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

    public string mt_TypeName
    {
      get => this._mt_TypeName;
      set
      {
        this._mt_TypeName = value;
        this.Changed(nameof (mt_TypeName));
      }
    }

    public string mt_Memo
    {
      get => this._mt_Memo;
      set
      {
        this._mt_Memo = value;
        this.Changed(nameof (mt_Memo));
      }
    }

    public string mt_UseYn
    {
      get => this._mt_UseYn;
      set
      {
        this._mt_UseYn = value;
        this.Changed(nameof (mt_UseYn));
        this.Changed("mt_IsUse");
        this.Changed("mt_UseYnDesc");
      }
    }

    public bool mt_IsUse => "Y".Equals(this.mt_UseYn);

    public string mt_UseYnDesc => !"Y".Equals(this.mt_UseYn) ? "미사용" : "사용";

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
    public IList<MemberTypeHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<MemberTypeHistoryView>) new List<MemberTypeHistoryView>());
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
      columnInfo.Add("mt_TypeName", new TTableColumn()
      {
        tc_orgin_name = "mt_TypeName",
        tc_trans_name = "회원유형명",
        tc_col_status = 1
      });
      columnInfo.Add("mt_Memo", new TTableColumn()
      {
        tc_orgin_name = "mt_Memo",
        tc_trans_name = "메모",
        tc_col_status = 1
      });
      columnInfo.Add("mt_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mt_UseYn",
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
      this.mt_TypeName = string.Empty;
      this.mt_Memo = string.Empty;
      this.mt_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_History = (IList<MemberTypeHistoryView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberTypeHistoryView();

    public override object Clone()
    {
      MemberTypeHistoryView memberTypeHistoryView = base.Clone() as MemberTypeHistoryView;
      memberTypeHistoryView.si_StoreName = this.si_StoreName;
      memberTypeHistoryView.si_StoreViewCode = this.si_StoreViewCode;
      memberTypeHistoryView.si_UseYn = this.si_UseYn;
      memberTypeHistoryView.mt_TypeName = this.mt_TypeName;
      memberTypeHistoryView.mt_Memo = this.mt_Memo;
      memberTypeHistoryView.mt_UseYn = this.mt_UseYn;
      memberTypeHistoryView.inEmpName = this.inEmpName;
      memberTypeHistoryView.modEmpName = this.modEmpName;
      memberTypeHistoryView.Lt_History = this.Lt_History;
      return (object) memberTypeHistoryView;
    }

    public void PutData(MemberTypeHistoryView pSource)
    {
      this.PutData((TMemberTypeHistory) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.mt_TypeName = pSource.mt_TypeName;
      this.mt_Memo = pSource.mt_Memo;
      this.mt_UseYn = pSource.mt_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_History = (IList<MemberTypeHistoryView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (MemberTypeHistoryView pSource1 in (IEnumerable<MemberTypeHistoryView>) pSource.Lt_History)
      {
        MemberTypeHistoryView memberTypeHistoryView = new MemberTypeHistoryView();
        memberTypeHistoryView.PutData(pSource1);
        this.Lt_History.Add(memberTypeHistoryView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mth_StoreCode == 0)
      {
        this.message = "지점(mth_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mth_TypeCode == 0)
      {
        this.message = "회원유형코드(mth_TypeCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.mth_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(mth_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.mth_SiteID == 0L)
      {
        this.message = "싸이트(mth_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      nullable = this.mth_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(mth_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mth_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.mth_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 <= intFormat2)
        return EnumDataCheck.Success;
      this.message = "시작일(mth_StartDate) > 종료일(mth_EndDate)  " + EnumDataCheck.Valid.ToDescription();
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
      if (!p_app_employee.IsMemberTypeSave)
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
          if (this.mth_SiteID == 0L)
            this.mth_SiteID = p_app_employee.emp_SiteID;
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
      MemberTypeHistoryView memberTypeHistoryView = this;
      try
      {
        memberTypeHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberTypeHistoryView.DataCheck(p_db))
            throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberTypeHistoryView.mth_SiteID == 0L)
            memberTypeHistoryView.mth_SiteID = p_app_employee.emp_SiteID;
          if (!memberTypeHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await memberTypeHistoryView.InsertAsync())
          throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 등록 오류");
        memberTypeHistoryView.db_status = 4;
        memberTypeHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberTypeHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberTypeHistoryView.message = ex.Message;
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
      MemberTypeHistoryView memberTypeHistoryView = this;
      try
      {
        memberTypeHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberTypeHistoryView.DataCheck(p_db))
            throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberTypeHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await memberTypeHistoryView.UpdateAsync())
          throw new UniServiceException(memberTypeHistoryView.message, memberTypeHistoryView.TableCode.ToDescription() + " 변경 오류");
        memberTypeHistoryView.db_status = 4;
        memberTypeHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberTypeHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberTypeHistoryView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      MemberTypeHistoryView memberTypeHistoryView1 = this;
      try
      {
        memberTypeHistoryView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberTypeHistoryView1.DataCheck(p_db))
            throw new UniServiceException(memberTypeHistoryView1.message, memberTypeHistoryView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberTypeHistoryView1.mth_SiteID == 0L)
            memberTypeHistoryView1.mth_SiteID = p_app_employee.emp_SiteID;
          if (!memberTypeHistoryView1.IsPermit(p_app_employee))
            throw new UniServiceException(memberTypeHistoryView1.message, memberTypeHistoryView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        if (Enum2StrConverter.IsDataModLog(memberTypeHistoryView1.mth_SiteID))
        {
          logs.dml_CodeInt = memberTypeHistoryView1.mth_StoreCode;
          logs.dml_CodeLong = (long) memberTypeHistoryView1.mth_TypeCode;
          logs.dml_CodeStr = string.Format("{0}|{1}|{2}|{3}", (object) memberTypeHistoryView1.mth_StoreCode, (object) memberTypeHistoryView1.mth_TypeCode, (object) memberTypeHistoryView1.mth_StartDate.Value.ToIntFormat(), (object) memberTypeHistoryView1.mth_SiteID);
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(memberTypeHistoryView1.arrStrStoreCode))
          memberTypeHistoryView1.arrStrStoreCode = memberTypeHistoryView1.mth_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "mth_TypeCode", (object) memberTypeHistoryView1.mth_TypeCode);
        param.Add((object) "mth_StoreCode_IN_", (object) memberTypeHistoryView1.arrStrStoreCode);
        param.Add((object) "_DT_START_DATE_", (object) memberTypeHistoryView1.mth_StartDate.Value);
        param.Add((object) "_DT_END_DATE_", (object) memberTypeHistoryView1.mth_EndDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<MemberTypeHistoryView> infos = await p_db.Create<MemberTypeHistoryView>().SelectListAsync((object) param);
        MemberTypeHistoryByStoreDic dic_Store = new MemberTypeHistoryByStoreDic();
        dic_Store.AddOriginRange((IEnumerable<MemberTypeHistoryView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(memberTypeHistoryView1.message, memberTypeHistoryView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "mth_TypeCode", (object) memberTypeHistoryView1.mth_TypeCode);
        param.Add((object) "mth_StoreCode_IN_", (object) memberTypeHistoryView1.arrStrStoreCode);
        param.Add((object) "_DT_DATE_", (object) memberTypeHistoryView1.mth_StartDate.Value);
        param.Add((object) "_ORDER_BY_TYPE_", (object) 2);
        IList<MemberTypeHistoryView> memberTypeHistoryViewList = await p_db.Create<MemberTypeHistoryView>().SelectListAsync((object) param);
        List<MemberTypeHistoryView> lt_origin_insert = new List<MemberTypeHistoryView>();
        MemberTypeHistoryView origin_start = (MemberTypeHistoryView) null;
        MemberTypeHistoryView origin_end = (MemberTypeHistoryView) null;
        foreach (MemberTypeHistoryView memberTypeHistoryView2 in (IEnumerable<MemberTypeHistoryView>) memberTypeHistoryViewList)
        {
          MemberTypeHistoryView item = memberTypeHistoryView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store.ContainsKey(item.mth_StoreCode))
          {
            logs.Init(p_login_employee, memberTypeHistoryView1.TableCode, EnumEmpActionKind.UPDATE);
            if (!item.mth_MemberPrice.Equals(memberTypeHistoryView1.mth_MemberPrice))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_MemberPrice", "회원가적용", item.mth_MemberPrice, memberTypeHistoryView1.mth_MemberPrice));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_CreditYn.Equals(memberTypeHistoryView1.mth_CreditYn))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_CreditYn", "외상가능여부", item.mth_CreditYn, memberTypeHistoryView1.mth_CreditYn));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointAddYn.Equals(memberTypeHistoryView1.mth_PointAddYn))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointAddYn", "적립율사용여부", item.mth_PointAddYn, memberTypeHistoryView1.mth_PointAddYn));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_EnurySlipRate.Equals(memberTypeHistoryView1.mth_EnurySlipRate))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_EnurySlipRate", "에누리율", item.mth_EnurySlipRate, memberTypeHistoryView1.mth_EnurySlipRate));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_EnurySlipStdAmt.Equals(memberTypeHistoryView1.mth_EnurySlipStdAmt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_EnurySlipStdAmt", "에누리최소금액", item.mth_EnurySlipStdAmt, memberTypeHistoryView1.mth_EnurySlipStdAmt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRateCash.Equals(memberTypeHistoryView1.mth_PointRateCash))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateCash", "현금적립율", item.mth_PointRateCash, memberTypeHistoryView1.mth_PointRateCash));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRateCard.Equals(memberTypeHistoryView1.mth_PointRateCard))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateCard", "카드적립율", item.mth_PointRateCard, memberTypeHistoryView1.mth_PointRateCard));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRateInnerGift.Equals(memberTypeHistoryView1.mth_PointRateInnerGift))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateInnerGift", "자사상품권적립율", item.mth_PointRateInnerGift, memberTypeHistoryView1.mth_PointRateInnerGift));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRateOuterGift.Equals(memberTypeHistoryView1.mth_PointRateOuterGift))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateOuterGift", "타사상품권적립율", item.mth_PointRateOuterGift, memberTypeHistoryView1.mth_PointRateOuterGift));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRatePoint.Equals(memberTypeHistoryView1.mth_PointRatePoint))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRatePoint", "포인트사용적립율", item.mth_PointRatePoint, memberTypeHistoryView1.mth_PointRatePoint));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRatePoint.Equals(memberTypeHistoryView1.mth_PointRateCredit))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateCredit", "외상적립율", item.mth_PointRateCredit, memberTypeHistoryView1.mth_PointRateCredit));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRatePoint.Equals(memberTypeHistoryView1.mth_PointRateSocial))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateSocial", "소셜/Pay적립율", item.mth_PointRateSocial, memberTypeHistoryView1.mth_PointRateSocial));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mth_PointRateEtc.Equals(memberTypeHistoryView1.mth_PointRateEtc))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mth_PointRateEtc", "기타적립율", item.mth_PointRateEtc, memberTypeHistoryView1.mth_PointRateEtc));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.mth_StartDate = memberTypeHistoryView1.mth_StartDate;
            item.mth_EndDate = memberTypeHistoryView1.mth_EndDate;
            item.mth_SiteID = memberTypeHistoryView1.mth_SiteID;
            item.mth_MemberPrice = memberTypeHistoryView1.mth_MemberPrice;
            item.mth_CreditYn = memberTypeHistoryView1.mth_CreditYn;
            item.mth_PointAddYn = memberTypeHistoryView1.mth_PointAddYn;
            item.mth_EnurySlipRate = memberTypeHistoryView1.mth_EnurySlipRate;
            item.mth_EnurySlipStdAmt = memberTypeHistoryView1.mth_EnurySlipStdAmt;
            item.mth_PointRateCash = memberTypeHistoryView1.mth_PointRateCash;
            item.mth_PointRateCard = memberTypeHistoryView1.mth_PointRateCard;
            item.mth_PointRateInnerGift = memberTypeHistoryView1.mth_PointRateInnerGift;
            item.mth_PointRateOuterGift = memberTypeHistoryView1.mth_PointRateOuterGift;
            item.mth_PointRatePoint = memberTypeHistoryView1.mth_PointRatePoint;
            item.mth_PointRateCredit = memberTypeHistoryView1.mth_PointRateCredit;
            item.mth_PointRateSocial = memberTypeHistoryView1.mth_PointRateSocial;
            item.mth_PointRateEtc = memberTypeHistoryView1.mth_PointRateEtc;
            item.mth_InUser = p_app_employee.emp_Code;
            item.mth_ModUser = p_app_employee.emp_Code;
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<MemberTypeHistoryView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            foreach (MemberTypeHistoryView history in (IEnumerable<MemberTypeHistoryView>) dic_Store[item.mth_StoreCode].Lt_History)
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                    lt_origin_insert[0].mth_EndDate = history.mth_EndDate;
                  else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                    lt_origin_insert[0].mth_EndDate = new DateTime?(history.mth_StartDate.Value.GetDateAdd(0, 0, -1));
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
                      origin_end = p_db.Create<MemberTypeHistoryView>();
                    else
                      origin_end.Clear();
                    origin_end.PutData(item);
                    lt_origin_insert.Add(origin_end);
                  }
                  lt_origin_insert[1].mth_StartDate = new DateTime?(history.mth_EndDate.Value.GetDateAdd(0, 0, 1));
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberTypeHistoryView next_data = p_db.Create<MemberTypeHistoryView>();
                next_data.PutData(history);
                history.mth_EndDate = new DateTime?(item.mth_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                next_data.mth_StartDate = new DateTime?(item.mth_EndDate.Value.GetDateAdd(0, 0, 1));
                next_data.mth_SiteID = memberTypeHistoryView1.mth_SiteID;
                next_data = await next_data.InsertAsync() ? (MemberTypeHistoryView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                history.mth_EndDate = new DateTime?(item.mth_StartDate.Value.GetDateAdd(0, 0, -1));
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberTypeHistoryView memberTypeHistoryView3 = history;
                int mthStoreCode = history.mth_StoreCode;
                int mthTypeCode = history.mth_TypeCode;
                DateTime? nullable = history.mth_StartDate;
                DateTime p_mth_StartDate = nullable.Value;
                nullable = item.mth_EndDate;
                DateTime dateAdd = nullable.Value.GetDateAdd(0, 0, 1);
                long mthSiteId = history.mth_SiteID;
                if (!await memberTypeHistoryView3.UpdateStartDateAsync(mthStoreCode, mthTypeCode, p_mth_StartDate, dateAdd, mthSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_origin_insert.Count == 2)
            {
              foreach (MemberTypeHistoryView memberTypeHistoryView4 in (IEnumerable<MemberTypeHistoryView>) dic_Store[item.mth_StoreCode].Lt_History)
              {
                if (memberTypeHistoryView4.IntStartDate == lt_origin_insert[1].IntStartDate)
                {
                  int num = await memberTypeHistoryView4.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (MemberTypeHistoryView memberTypeHistoryView5 in lt_origin_insert)
            {
              if (memberTypeHistoryView5.IntStartDate <= memberTypeHistoryView5.IntEndDate)
              {
                if (!await memberTypeHistoryView5.InsertAsync())
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
            item = (MemberTypeHistoryView) null;
          }
        }
        memberTypeHistoryView1.db_status = 4;
        memberTypeHistoryView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        memberTypeHistoryView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        memberTypeHistoryView1.message = ex.Message;
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
      this.mt_TypeName = p_rs.GetFieldString("mt_TypeName");
      this.mt_Memo = p_rs.GetFieldString("mt_Memo");
      this.mt_UseYn = p_rs.GetFieldString("mt_UseYn");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<MemberTypeHistoryView> SelectOneAsync(
      int p_mth_StoreCode,
      int p_mth_TypeCode,
      DateTime p_mth_StartDate,
      long p_mth_SiteID = 0)
    {
      MemberTypeHistoryView memberTypeHistoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mth_StoreCode",
          (object) p_mth_StoreCode
        },
        {
          (object) "mth_TypeCode",
          (object) p_mth_TypeCode
        },
        {
          (object) "mth_StartDate",
          (object) p_mth_StartDate
        }
      };
      if (p_mth_SiteID > 0L)
        p_param.Add((object) "mth_SiteID", (object) p_mth_SiteID);
      return await memberTypeHistoryView.SelectOneTAsync<MemberTypeHistoryView>((object) p_param);
    }

    public async Task<IList<MemberTypeHistoryView>> SelectListAsync(object p_param)
    {
      MemberTypeHistoryView memberTypeHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberTypeHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberTypeHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberTypeHistoryView1.GetSelectQuery(p_param)))
        {
          memberTypeHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberTypeHistoryView>) null;
        }
        IList<MemberTypeHistoryView> lt_list = (IList<MemberTypeHistoryView>) new List<MemberTypeHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberTypeHistoryView memberTypeHistoryView2 = memberTypeHistoryView1.OleDB.Create<MemberTypeHistoryView>();
            if (memberTypeHistoryView2.GetFieldValues(rs))
            {
              memberTypeHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberTypeHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberTypeHistoryView> SelectEnumerableAsync(object p_param)
    {
      MemberTypeHistoryView memberTypeHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberTypeHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberTypeHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberTypeHistoryView1.GetSelectQuery(p_param)))
        {
          memberTypeHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberTypeHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberTypeHistoryView memberTypeHistoryView2 = memberTypeHistoryView1.OleDB.Create<MemberTypeHistoryView>();
            if (memberTypeHistoryView2.GetFieldValues(rs))
            {
              memberTypeHistoryView2.row_number = ++row_number;
              yield return memberTypeHistoryView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mt_TypeName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
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
          if (hashtable2.ContainsKey((object) "mth_SiteID") && Convert.ToInt64(hashtable2[(object) "mth_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable2[(object) "mth_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "MemberType_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_HEADER AS (\nSELECT mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberType, (object) DbQueryHelper.ToWithNolock()));
        if (flag)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new MemberTypeView().GetSelectWhereAnd(p_param));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mt_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mth_StoreCode,mth_TypeCode,mth_StartDate,mth_SiteID,mth_EndDate,mth_MemberPrice,mth_CreditYn,mth_PointAddYn,mth_EnurySlipRate,mth_EnurySlipStdAmt,mth_PointRateCash,mth_PointRateCard,mth_PointRateInnerGift,mth_PointRateOuterGift,mth_PointRatePoint,mth_PointRateCredit,mth_PointRateSocial,mth_PointRateEtc,mth_InDate,mth_InUser,mth_ModDate,mth_ModUser\n,si_StoreName,si_StoreViewCode,si_UseYn\n,mt_TypeName,mt_Memo,mt_UseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON mth_StoreCode=si_StoreCode AND mth_SiteID=si_SiteID\nINNER JOIN T_HEADER ON mth_TypeCode=mt_TypeCode AND mth_SiteID=mt_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mth_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mth_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
        {
          switch (num1)
          {
            case 1:
              stringBuilder.Append(" ORDER BY mth_StoreCode,mth_TypeCode,mth_StartDate DESC");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY mth_StoreCode,mth_TypeCode,mth_StartDate");
              break;
            case 3:
              stringBuilder.Append(" ORDER BY mth_TypeCode,mth_StoreCode,mth_StartDate DESC");
              break;
            case 4:
              stringBuilder.Append(" ORDER BY mth_TypeCode,mth_StoreCode,mth_StartDate");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mth_StoreCode,mth_TypeCode,mth_StartDate");
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
