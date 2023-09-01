// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion.PromotionView
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionMix;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionStore;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion
{
  public class PromotionView : TPromotion<PromotionView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private IList<PromotionStoreView> _Lt_Store;
    private IList<PromotionTargetView> _Lt_Target;
    private IList<PromotionMixView> _Lt_Mix;
    private IList<CampaignPromotionView> _Lt_CampaignPromotion;

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

    [JsonPropertyName("lt_Store")]
    public IList<PromotionStoreView> Lt_Store
    {
      get => this._Lt_Store ?? (this._Lt_Store = (IList<PromotionStoreView>) new List<PromotionStoreView>());
      set
      {
        this._Lt_Store = value;
        this.Changed(nameof (Lt_Store));
      }
    }

    [JsonPropertyName("lt_Target")]
    public IList<PromotionTargetView> Lt_Target
    {
      get => this._Lt_Target ?? (this._Lt_Target = (IList<PromotionTargetView>) new List<PromotionTargetView>());
      set
      {
        this._Lt_Target = value;
        this.Changed(nameof (Lt_Target));
      }
    }

    [JsonPropertyName("lt_Mix")]
    public IList<PromotionMixView> Lt_Mix
    {
      get => this._Lt_Mix ?? (this._Lt_Mix = (IList<PromotionMixView>) new List<PromotionMixView>());
      set
      {
        this._Lt_Mix = value;
        this.Changed(nameof (Lt_Mix));
      }
    }

    [JsonPropertyName("lt_CampaignPromotion")]
    public IList<CampaignPromotionView> Lt_CampaignPromotion
    {
      get => this._Lt_CampaignPromotion ?? (this._Lt_CampaignPromotion = (IList<CampaignPromotionView>) new List<CampaignPromotionView>());
      set
      {
        this._Lt_CampaignPromotion = value;
        this.Changed(nameof (Lt_CampaignPromotion));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
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
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Store = (IList<PromotionStoreView>) null;
      this.Lt_Target = (IList<PromotionTargetView>) null;
      this.Lt_Mix = (IList<PromotionMixView>) null;
      this.Lt_CampaignPromotion = (IList<CampaignPromotionView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PromotionView();

    public override object Clone()
    {
      PromotionView promotionView = base.Clone() as PromotionView;
      promotionView.inEmpName = this.inEmpName;
      promotionView.modEmpName = this.modEmpName;
      promotionView.Lt_Store = this.Lt_Store;
      promotionView.Lt_Target = this.Lt_Target;
      promotionView.Lt_Mix = this.Lt_Mix;
      promotionView.Lt_CampaignPromotion = this.Lt_CampaignPromotion;
      return (object) promotionView;
    }

    public void PutData(PromotionView pSource)
    {
      this.PutData((TPromotion) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Store?.Clear();
      this.Lt_Store = (IList<PromotionStoreView>) null;
      foreach (PromotionStoreView pSource1 in (IEnumerable<PromotionStoreView>) pSource.Lt_Store)
      {
        PromotionStoreView promotionStoreView = new PromotionStoreView();
        promotionStoreView.PutData(pSource1);
        this.Lt_Store.Add(promotionStoreView);
      }
      this.Lt_Target?.Clear();
      this.Lt_Target = (IList<PromotionTargetView>) null;
      foreach (PromotionTargetView pSource2 in (IEnumerable<PromotionTargetView>) pSource.Lt_Target)
      {
        PromotionTargetView promotionTargetView = new PromotionTargetView();
        promotionTargetView.PutData(pSource2);
        this.Lt_Target.Add(promotionTargetView);
      }
      this.Lt_Mix?.Clear();
      this.Lt_Mix = (IList<PromotionMixView>) null;
      foreach (PromotionMixView pSource3 in (IEnumerable<PromotionMixView>) pSource.Lt_Mix)
      {
        PromotionMixView promotionMixView = new PromotionMixView();
        promotionMixView.PutData(pSource3);
        this.Lt_Mix.Add(promotionMixView);
      }
      this.Lt_CampaignPromotion?.Clear();
      this.Lt_CampaignPromotion = (IList<CampaignPromotionView>) null;
      foreach (CampaignPromotionView pSource4 in (IEnumerable<CampaignPromotionView>) pSource.Lt_CampaignPromotion)
      {
        CampaignPromotionView campaignPromotionView = new CampaignPromotionView();
        campaignPromotionView.PutData(pSource4);
        this.Lt_CampaignPromotion.Add(campaignPromotionView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pm_SiteID == 0L)
      {
        this.message = "싸이트(pm_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.pm_PromotionName))
      {
        this.message = "프로모션명(pm_PromotionName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (Enum2StrConverter.ToPromotionKind(this.pm_PromotionKind) == EnumPromotionKind.None)
      {
        this.message = "종류(pm_PromotionKind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToPromotionType(this.pm_PromotionType) == EnumPromotionType.None)
      {
        this.message = "유형(pm_PromotionType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToPromotionDiv(this.pm_PromotionDiv) == EnumPromotionDiv.None)
      {
        this.message = "구분(pm_PromotionDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToPromotionTargetGroup(this.pm_TargetGroup) == EnumPromotionTargetGroup.None)
      {
        this.message = "적용대상(pm_TargetGroup)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToOperatorAndOr(this.pm_MixOperator) == EnumOperatorAndOr.None)
      {
        this.message = "연산자(pm_MixOperator)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToApplyDiv(this.pm_ApplyDiv) == EnumApplyDiv.None)
      {
        this.message = "적용체크(pm_ApplyDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.pm_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일자(pm_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.pm_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일자(pm_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.pm_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.pm_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 > intFormat2)
      {
        this.message = "시작일자(pm_StartDate) > 종료일자(pm_EndDate)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (string.IsNullOrEmpty(this.pm_StartTime) || this.pm_StartTime.Length != 4)
      {
        this.message = "시작시간(pm_StartTime)[4자리] " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (string.IsNullOrEmpty(this.pm_EndTime) || this.pm_EndTime.Length != 4)
      {
        this.message = "종료시간(pm_EndTime)[4자리] " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Convert.ToInt32(this.pm_StartTime) > Convert.ToInt32(this.pm_EndTime))
      {
        this.message = "시작시간>종료시간 " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (this.IsNew)
      {
        if (this.Lt_Store.Count == 0)
        {
          this.message = "[작업 지점 카운터 0] " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
        if (this.pm_IsMix && this.Lt_Mix.Count == 0)
        {
          this.message = "[믹스 정보 카운터 0] " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
        if (Enum2StrConverter.ToPromotionTargetGroup(this.pm_TargetGroup) == EnumPromotionTargetGroup.Receipt)
        {
          if (this.Lt_Target.Count > 0)
          {
            this.message = "[작업 대상 카운터 " + this.Lt_Target.Count.ToString("n0") + "건 등록 오류] " + EnumDataCheck.Valid.ToDescription();
            return EnumDataCheck.Valid;
          }
        }
        else if (this.Lt_Target.Count == 0)
        {
          this.message = "[작업 대상 카운터 0] " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
      }
      return EnumDataCheck.Success;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsPromotionSave)
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
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pm_PromotionCode), " + str + ")+1 AS pm_PromotionCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "pm_PromotionCode", (object) intFormat);
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
          this.pm_PromotionCode = uniOleDbRecordset.GetFieldLong(0);
        return this.pm_PromotionCode > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      PromotionView promotionView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(promotionView.CreateCodeQuery()))
        {
          promotionView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          promotionView.pm_PromotionCode = rs.GetFieldLong(0);
        return promotionView.pm_PromotionCode > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    protected bool InsertStore(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Store.Count == 0)
        return true;
      foreach (PromotionStoreView promotionStoreView in (IEnumerable<PromotionStoreView>) this.Lt_Store)
      {
        promotionStoreView.pms_PromotionCode = this.pm_PromotionCode;
        promotionStoreView.pms_SiteID = this.pm_SiteID;
        if (promotionStoreView.IsNew)
        {
          promotionStoreView.pms_InUser = p_app_employee.emp_Code;
          if (!promotionStoreView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(promotionStoreView.message, promotionStoreView.TableCode.ToDescription() + " 신규 등록 에러");
        }
      }
      return true;
    }

    protected async Task<bool> InsertStoreAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      PromotionView promotionView = this;
      try
      {
        if (promotionView.Lt_Store.Count == 0)
          return true;
        foreach (PromotionStoreView item in (IEnumerable<PromotionStoreView>) promotionView.Lt_Store)
        {
          item.pms_PromotionCode = promotionView.pm_PromotionCode;
          item.pms_SiteID = promotionView.pm_SiteID;
          if (item.IsNew)
          {
            item.pms_InUser = p_app_employee.emp_Code;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 신규 등록 에러");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        promotionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        promotionView.message = ex.Message;
      }
      return false;
    }

    protected bool InsertTarget(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Target.Count == 0)
        return true;
      foreach (PromotionTargetView promotionTargetView in (IEnumerable<PromotionTargetView>) this.Lt_Target)
      {
        promotionTargetView.pmt_PromotionCode = this.pm_PromotionCode;
        promotionTargetView.pmt_SiteID = this.pm_SiteID;
        if (promotionTargetView.IsNew)
        {
          promotionTargetView.pmt_InUser = p_app_employee.emp_Code;
          if (!promotionTargetView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 신규 등록 에러");
        }
      }
      return true;
    }

    protected async Task<bool> InsertTargetAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      PromotionView promotionView = this;
      try
      {
        if (promotionView.Lt_Target.Count == 0)
          return true;
        foreach (PromotionTargetView item in (IEnumerable<PromotionTargetView>) promotionView.Lt_Target)
        {
          item.pmt_PromotionCode = promotionView.pm_PromotionCode;
          item.pmt_SiteID = promotionView.pm_SiteID;
          if (item.IsNew)
          {
            item.pmt_InUser = p_app_employee.emp_Code;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 신규 등록 에러");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        promotionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        promotionView.message = ex.Message;
      }
      return false;
    }

    protected bool InsertMix(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Mix.Count == 0)
        return true;
      foreach (PromotionMixView promotionMixView in (IEnumerable<PromotionMixView>) this.Lt_Mix)
      {
        promotionMixView.pmm_PromotionCode = this.pm_PromotionCode;
        promotionMixView.pmm_SiteID = this.pm_SiteID;
        if (promotionMixView.IsNew)
        {
          promotionMixView.pmm_InUser = p_app_employee.emp_Code;
          if (!promotionMixView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(promotionMixView.message, promotionMixView.TableCode.ToDescription() + " 신규 등록 에러");
        }
      }
      return true;
    }

    protected async Task<bool> InsertMixAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      PromotionView promotionView = this;
      try
      {
        if (promotionView.Lt_Mix.Count == 0)
          return true;
        foreach (PromotionMixView item in (IEnumerable<PromotionMixView>) promotionView.Lt_Mix)
        {
          item.pmm_PromotionCode = promotionView.pm_PromotionCode;
          item.pmm_SiteID = promotionView.pm_SiteID;
          if (item.IsNew)
          {
            item.pmm_InUser = p_app_employee.emp_Code;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 신규 등록 에러");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        promotionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        promotionView.message = ex.Message;
      }
      return false;
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
          if (this.pm_SiteID == 0L)
            this.pm_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.pm_PromotionCode == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertStore(p_db, p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertTarget(p_db, p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertMix(p_db, p_app_employee))
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
      PromotionView promotionView = this;
      try
      {
        promotionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != promotionView.DataCheck(p_db))
            throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (promotionView.pm_SiteID == 0L)
            promotionView.pm_SiteID = p_app_employee.emp_SiteID;
          if (!promotionView.IsPermit(p_app_employee))
            throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (promotionView.pm_PromotionCode == 0L)
        {
          if (!await promotionView.CreateCodeAsync(p_db))
            throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await promotionView.InsertAsync())
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 등록 오류");
        if (!await promotionView.InsertStoreAsync(p_db, p_app_employee))
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 등록 오류");
        if (!await promotionView.InsertTargetAsync(p_db, p_app_employee))
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 등록 오류");
        if (!await promotionView.InsertMixAsync(p_db, p_app_employee))
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        promotionView.db_status = 4;
        promotionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionView.message = ex.Message;
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
        if (this.pm_PromotionCode == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 프로모션코드(pm_PromotionCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      PromotionView promotionView = this;
      try
      {
        promotionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != promotionView.DataCheck(p_db))
            throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!promotionView.IsPermit(p_app_employee))
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (promotionView.pm_PromotionCode == 0L)
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 프로모션코드(pm_PromotionCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await promotionView.UpdateAsync())
          throw new UniServiceException(promotionView.message, promotionView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        promotionView.db_status = 4;
        promotionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<PromotionView> SelectOneAsync(long p_pm_PromotionCode, long p_pm_SiteID = 0)
    {
      PromotionView promotionView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pm_PromotionCode",
          (object) p_pm_PromotionCode
        }
      };
      if (p_pm_SiteID > 0L)
        p_param.Add((object) "pm_SiteID", (object) p_pm_SiteID);
      return await promotionView.SelectOneTAsync<PromotionView>((object) p_param);
    }

    public PromotionView SelectOne(long p_pm_PromotionCode, long p_pm_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pm_PromotionCode",
          (object) p_pm_PromotionCode
        }
      };
      if (p_pm_SiteID > 0L)
        p_param.Add((object) "pm_SiteID", (object) p_pm_SiteID);
      return this.SelectOneT<PromotionView>((object) p_param);
    }

    public async Task<IList<PromotionView>> SelectListAsync(object p_param)
    {
      PromotionView promotionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionView1.GetSelectQuery(p_param)))
        {
          promotionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PromotionView>) null;
        }
        IList<PromotionView> lt_list = (IList<PromotionView>) new List<PromotionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PromotionView promotionView2 = promotionView1.OleDB.Create<PromotionView>();
            if (promotionView2.GetFieldValues(rs))
            {
              promotionView2.row_number = lt_list.Count + 1;
              lt_list.Add(promotionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<PromotionView> SelectEnumerableAsync(object p_param)
    {
      PromotionView promotionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionView1.GetSelectQuery(p_param)))
        {
          promotionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PromotionView promotionView2 = promotionView1.OleDB.Create<PromotionView>();
            if (promotionView2.GetFieldValues(rs))
            {
              promotionView2.row_number = ++row_number;
              yield return promotionView2;
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

    public async Task<IList<PromotionView>> SelectListExistsAsync(object p_param)
    {
      PromotionView promotionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionView1.GetSelectQuery(p_param)))
        {
          promotionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PromotionView>) null;
        }
        IList<PromotionView> lt_list = (IList<PromotionView>) new List<PromotionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PromotionView promotionView2 = promotionView1.OleDB.Create<PromotionView>();
            if (promotionView2.GetFieldValues(rs))
            {
              promotionView2.row_number = lt_list.Count + 1;
              lt_list.Add(promotionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pm_PromotionName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_PromotionDesc", hashtable[(object) "_KEY_WORD_"]));
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
        int num3 = 0;
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
          if (hashtable.ContainsKey((object) "pm_SiteID") && Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
            num3 = Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        if (num3 > 0)
          stringBuilder.Append("\n,T_PROMOTION_STORE AS (\nSELECT pms_PromotionCode,pms_SiteID,pms_StoreCode" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) TableCodeType.PromotionStore, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "pms_SiteID", (object) num2) + string.Format(" AND {0}={1}", (object) "pms_StoreCode", (object) num3) + ")");
        stringBuilder.Append("\nSELECT  pm_PromotionCode,pm_SiteID,pm_PromotionName,pm_PromotionDesc,pm_PromotionKind,pm_PromotionType,pm_PromotionDiv,pm_TargetGroup,pm_DcValue,pm_MixYn,pm_MixOperator,pm_MixQty,pm_ApplyDiv,pm_ApplyPackQty,pm_ApplyMinQty,pm_ApplyMaxQty,pm_ApplyMinAmt,pm_ApplyMaxAmt,pm_ApplyAllYn,pm_EventReceiptID,pm_StartDate,pm_StartTime,pm_EndDate,pm_EndTime,pm_SunYn,pm_MonYn,pm_TueYn,pm_WedYn,pm_ThuYn,pm_FriYn,pm_SatYn,pm_DuplicationYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock());
        if (num3 > 0)
          stringBuilder.Append("\nINNER JOIN T_PROMOTION_STORE ON pm_PromotionCode=pms_PromotionCode AND pm_SiteID=pms_SiteID");
        stringBuilder.Append("\nLEFT OUTER JOIN T_EMPLOYEE_IN ON pm_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON pm_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY pm_PromotionCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY pm_PromotionCode");
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
