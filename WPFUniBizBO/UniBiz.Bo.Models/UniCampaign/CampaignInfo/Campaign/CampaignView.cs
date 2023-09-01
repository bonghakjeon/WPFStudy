// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign.CampaignView
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignGoods;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignMember;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign
{
  public class CampaignView : TCampaign<CampaignView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private IList<CampaignPromotionView> _Lt_Promotion;
    private IList<CampaignStoreView> _Lt_Store;
    private IList<CampaignMemberView> _Lt_Member;
    private IList<CampaignGoodsView> _Lt_Goods;

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

    [JsonPropertyName("lt_Promotion")]
    public IList<CampaignPromotionView> Lt_Promotion
    {
      get => this._Lt_Promotion ?? (this._Lt_Promotion = (IList<CampaignPromotionView>) new List<CampaignPromotionView>());
      set
      {
        this._Lt_Promotion = value;
        this.Changed(nameof (Lt_Promotion));
      }
    }

    [JsonPropertyName("lt_Store")]
    public IList<CampaignStoreView> Lt_Store
    {
      get => this._Lt_Store ?? (this._Lt_Store = (IList<CampaignStoreView>) new List<CampaignStoreView>());
      set
      {
        this._Lt_Store = value;
        this.Changed(nameof (Lt_Store));
      }
    }

    [JsonPropertyName("lt_Member")]
    public IList<CampaignMemberView> Lt_Member
    {
      get => this._Lt_Member ?? (this._Lt_Member = (IList<CampaignMemberView>) new List<CampaignMemberView>());
      set
      {
        this._Lt_Member = value;
        this.Changed(nameof (Lt_Member));
      }
    }

    [JsonPropertyName("lt_Goods")]
    public IList<CampaignGoodsView> Lt_Goods
    {
      get => this._Lt_Goods ?? (this._Lt_Goods = (IList<CampaignGoodsView>) new List<CampaignGoodsView>());
      set
      {
        this._Lt_Goods = value;
        this.Changed(nameof (Lt_Goods));
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
      this.Lt_Promotion = (IList<CampaignPromotionView>) null;
      this.Lt_Store = (IList<CampaignStoreView>) null;
      this.Lt_Member = (IList<CampaignMemberView>) null;
      this.Lt_Goods = (IList<CampaignGoodsView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CampaignView();

    public override object Clone()
    {
      CampaignView campaignView = base.Clone() as CampaignView;
      campaignView.inEmpName = this.inEmpName;
      campaignView.modEmpName = this.modEmpName;
      campaignView.Lt_Promotion = this.Lt_Promotion;
      campaignView.Lt_Store = this.Lt_Store;
      campaignView.Lt_Member = this.Lt_Member;
      campaignView.Lt_Goods = this.Lt_Goods;
      return (object) campaignView;
    }

    public void PutData(CampaignView pSource)
    {
      this.PutData((TCampaign) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Promotion?.Clear();
      this.Lt_Promotion = (IList<CampaignPromotionView>) null;
      foreach (CampaignPromotionView pSource1 in (IEnumerable<CampaignPromotionView>) pSource.Lt_Promotion)
      {
        CampaignPromotionView campaignPromotionView = new CampaignPromotionView();
        campaignPromotionView.PutData(pSource1);
        this.Lt_Promotion.Add(campaignPromotionView);
      }
      this.Lt_Store?.Clear();
      this.Lt_Store = (IList<CampaignStoreView>) null;
      foreach (CampaignStoreView pSource2 in (IEnumerable<CampaignStoreView>) pSource.Lt_Store)
      {
        CampaignStoreView campaignStoreView = new CampaignStoreView();
        campaignStoreView.PutData(pSource2);
        this.Lt_Store.Add(campaignStoreView);
      }
      this.Lt_Member?.Clear();
      this.Lt_Member = (IList<CampaignMemberView>) null;
      foreach (CampaignMemberView pSource3 in (IEnumerable<CampaignMemberView>) pSource.Lt_Member)
      {
        CampaignMemberView campaignMemberView = new CampaignMemberView();
        campaignMemberView.PutData(pSource3);
        this.Lt_Member.Add(campaignMemberView);
      }
      this.Lt_Goods?.Clear();
      this.Lt_Goods = (IList<CampaignGoodsView>) null;
      foreach (CampaignGoodsView ltGood in (IEnumerable<CampaignGoodsView>) pSource.Lt_Goods)
      {
        CampaignGoodsView campaignGoodsView = new CampaignGoodsView();
        campaignGoodsView.PutData(ltGood);
        this.Lt_Goods.Add(campaignGoodsView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ci_SiteID == 0L)
      {
        this.message = "싸이트(ci_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ci_CampaignName))
      {
        this.message = "캠페인명(ci_CampaignName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      DateTime? nullable = this.ci_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(ci_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.ci_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(ci_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.ci_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.ci_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 > intFormat2)
      {
        this.message = "시작일(ci_StartDate) > 종료일(ci_EndDate)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToCampaignType(this.ci_CampaignType) != EnumCampaignType.None)
        return EnumDataCheck.Success;
      this.message = "캠페인유형(ci_CampaignType)  " + EnumDataCheck.CodeZero.ToDescription();
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

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ci_CampaignCode), " + str + ")+1 AS ci_CampaignCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ci_CampaignCode", (object) intFormat);
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
          this.ci_CampaignCode = uniOleDbRecordset.GetFieldLong(0);
        return this.ci_CampaignCode > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      CampaignView campaignView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(campaignView.CreateCodeQuery()))
        {
          campaignView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          campaignView.ci_CampaignCode = rs.GetFieldLong(0);
        return campaignView.ci_CampaignCode > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    protected bool InsertPromotion(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Promotion.Count == 0)
        return true;
      foreach (CampaignPromotionView campaignPromotionView in (IEnumerable<CampaignPromotionView>) this.Lt_Promotion)
      {
        campaignPromotionView.cip_CampaignCode = this.ci_CampaignCode;
        campaignPromotionView.cip_SiteID = this.ci_SiteID;
        if (campaignPromotionView.IsNew)
        {
          campaignPromotionView.cip_InUser = p_app_employee.emp_Code;
          if (!campaignPromotionView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(campaignPromotionView.message, campaignPromotionView.TableCode.ToDescription() + " 신규 등록 에러");
        }
      }
      return true;
    }

    protected async Task<bool> InsertPromotionAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      CampaignView campaignView = this;
      try
      {
        if (campaignView.Lt_Promotion.Count == 0)
          return true;
        foreach (CampaignPromotionView item in (IEnumerable<CampaignPromotionView>) campaignView.Lt_Promotion)
        {
          item.cip_CampaignCode = campaignView.ci_CampaignCode;
          item.cip_SiteID = campaignView.ci_SiteID;
          if (item.IsNew)
          {
            item.cip_InUser = p_app_employee.emp_Code;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 신규 등록 에러");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        campaignView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        campaignView.message = ex.Message;
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
          if (this.ci_SiteID == 0L)
            this.ci_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ci_CampaignCode == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertPromotion(p_db, p_app_employee))
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
      CampaignView campaignView = this;
      try
      {
        campaignView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != campaignView.DataCheck(p_db))
            throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (campaignView.ci_SiteID == 0L)
            campaignView.ci_SiteID = p_app_employee.emp_SiteID;
          if (!campaignView.IsPermit(p_app_employee))
            throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (campaignView.ci_CampaignCode == 0L)
        {
          if (!await campaignView.CreateCodeAsync(p_db))
            throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await campaignView.InsertAsync())
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 등록 오류");
        if (!await campaignView.InsertPromotionAsync(p_db, p_app_employee))
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        campaignView.db_status = 4;
        campaignView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignView.message = ex.Message;
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
        if (this.ci_CampaignCode == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 캠페인코드(ci_CampaignCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertPromotion(p_db, p_app_employee))
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

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      CampaignView campaignView = this;
      try
      {
        campaignView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != campaignView.DataCheck(p_db))
            throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!campaignView.IsPermit(p_app_employee))
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 권한 검사 실패");
        if (campaignView.ci_CampaignCode == 0L)
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 캠페인코드(ci_CampaignCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await campaignView.UpdateAsync())
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 변경 오류");
        if (!await campaignView.InsertPromotionAsync(p_db, p_app_employee))
          throw new UniServiceException(campaignView.message, campaignView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        campaignView.db_status = 4;
        campaignView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        campaignView.message = ex.Message;
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

    public async Task<CampaignView> SelectOneAsync(long p_ci_CampaignCode, long p_ci_SiteID = 0)
    {
      CampaignView campaignView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ci_CampaignCode",
          (object) p_ci_CampaignCode
        }
      };
      if (p_ci_SiteID > 0L)
        p_param.Add((object) "ci_SiteID", (object) p_ci_SiteID);
      return await campaignView.SelectOneTAsync<CampaignView>((object) p_param);
    }

    public CampaignView SelectOne(long p_ci_CampaignCode, long p_ci_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ci_CampaignCode",
          (object) p_ci_CampaignCode
        }
      };
      if (p_ci_SiteID > 0L)
        p_param.Add((object) "ci_SiteID", (object) p_ci_SiteID);
      return this.SelectOneT<CampaignView>((object) p_param);
    }

    public async Task<IList<CampaignView>> SelectListAsync(object p_param)
    {
      CampaignView campaignView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignView1.GetSelectQuery(p_param)))
        {
          campaignView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CampaignView>) null;
        }
        IList<CampaignView> lt_list = (IList<CampaignView>) new List<CampaignView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CampaignView campaignView2 = campaignView1.OleDB.Create<CampaignView>();
            if (campaignView2.GetFieldValues(rs))
            {
              campaignView2.row_number = lt_list.Count + 1;
              lt_list.Add(campaignView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<CampaignView> SelectEnumerableAsync(object p_param)
    {
      CampaignView campaignView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignView1.GetSelectQuery(p_param)))
        {
          campaignView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            CampaignView campaignView2 = campaignView1.OleDB.Create<CampaignView>();
            if (campaignView2.GetFieldValues(rs))
            {
              campaignView2.row_number = ++row_number;
              yield return campaignView2;
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

    public async Task<IList<CampaignView>> SelectListExistsAsync(object p_param)
    {
      CampaignView campaignView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(campaignView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, campaignView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(campaignView1.GetSelectQuery(p_param)))
        {
          campaignView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CampaignView>) null;
        }
        IList<CampaignView> lt_list = (IList<CampaignView>) new List<CampaignView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CampaignView campaignView2 = campaignView1.OleDB.Create<CampaignView>();
            if (campaignView2.GetFieldValues(rs))
            {
              campaignView2.row_number = lt_list.Count + 1;
              lt_list.Add(campaignView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + campaignView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ci_CampaignName", hashtable[(object) "_KEY_WORD_"]));
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
        int num = 0;
        string empty = string.Empty;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ci_SiteID") && Convert.ToInt64(hashtable[(object) "ci_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "ci_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  ci_CampaignCode,ci_SiteID,ci_CampaignName,ci_StartDate,ci_EndDate,ci_CampaignType,ci_CampaignMember,ci_CampaignGoods,ci_InDate,ci_InUser,ci_ModDate,ci_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ci_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ci_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num > 0)
          stringBuilder.Append("\nORDER BY ci_CampaignCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY ci_CampaignCode");
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
