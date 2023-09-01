// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon.CouponView
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon
{
  public class CouponView : TCoupon<CouponView>
  {
    private string _pm_PromotionName;
    private string _assignUserName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<CouponDetailView> _Lt_Details;

    public string pm_PromotionName
    {
      get => this._pm_PromotionName;
      set
      {
        this._pm_PromotionName = value;
        this.Changed(nameof (pm_PromotionName));
      }
    }

    public string assignUserName
    {
      get => this._assignUserName;
      set
      {
        this._assignUserName = value;
        this.Changed(nameof (assignUserName));
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

    [JsonPropertyName("lt_Details")]
    public IList<CouponDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<CouponDetailView>) new List<CouponDetailView>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pm_PromotionName", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionName",
        tc_trans_name = "프로모션명",
        tc_col_status = 1
      });
      columnInfo.Add("assignUserName", new TTableColumn()
      {
        tc_orgin_name = "assignUserName",
        tc_trans_name = "담당자",
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
      this.pm_PromotionName = string.Empty;
      this.assignUserName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Details = (IList<CouponDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CouponView();

    public override object Clone()
    {
      CouponView couponView = base.Clone() as CouponView;
      couponView.pm_PromotionName = this.pm_PromotionName;
      couponView.assignUserName = this.assignUserName;
      couponView.inEmpName = this.inEmpName;
      couponView.modEmpName = this.modEmpName;
      couponView.Lt_Details = this.Lt_Details;
      return (object) couponView;
    }

    public void PutData(CouponView pSource)
    {
      this.PutData((TCoupon) pSource);
      this.pm_PromotionName = pSource.pm_PromotionName;
      this.assignUserName = pSource.assignUserName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Details?.Clear();
      this.Lt_Details = (IList<CouponDetailView>) null;
      foreach (CouponDetailView ltDetail in (IEnumerable<CouponDetailView>) pSource.Lt_Details)
      {
        CouponDetailView couponDetailView = new CouponDetailView();
        couponDetailView.PutData(ltDetail);
        this.Lt_Details.Add(couponDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.cp_SiteID == 0L)
      {
        this.message = "싸이트(cp_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToCouponType(this.cp_CouponType) == EnumCouponType.None)
      {
        this.message = "쿠폰구분(cp_CouponType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToCouponApply(this.cp_Apply) == EnumCouponApply.None)
      {
        this.message = "회원인증시 적용(cp_Apply)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.cp_EmpCode == 0)
      {
        this.message = "담당자코드(cp_EmpCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.cp_Title))
      {
        this.message = "타이틀(cp_Title)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.cp_PromotionID == 0L)
      {
        this.message = "프로모션ID(cp_PromotionID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToCouponStatus(this.cp_Status) != EnumCouponStatus.None)
        return EnumDataCheck.Success;
      this.message = "상태(cp_Status)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = base.DataCheck(p_db);
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      IList<PromotionView> promotionViewList = p_db.Create<PromotionView>().SelectListE<PromotionView>((object) new Hashtable()
      {
        {
          (object) "pm_SiteID",
          (object) this.cp_SiteID
        },
        {
          (object) "pm_PromotionCode",
          (object) this.cp_PromotionID
        }
      });
      if (promotionViewList.Count == 0)
      {
        this.message = "프로모션ID(cp_PromotionID) " + EnumDataCheck.NULL.ToDescription() + "\n - 데이터 NULL.";
        return EnumDataCheck.NULL;
      }
      if (promotionViewList.Count > 1)
      {
        this.message = "프로모션ID(cp_PromotionID) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}[{1}건] {2} 사용중.", (object) promotionViewList[0].pm_PromotionCode, (object) promotionViewList.Count.ToString("n0"), (object) EnumDataCheck.Exists.ToDescription());
        return EnumDataCheck.Exists;
      }
      EnumPromotionKind promotionKind = Enum2StrConverter.ToPromotionKind(promotionViewList[0].pm_PromotionKind);
      if (promotionKind == EnumPromotionKind.Coupon)
        return EnumDataCheck.Success;
      this.message = "프로모션ID(cp_PromotionID) " + EnumDataCheck.Valid.ToDescription() + "\n - 쿠폰 타입 " + promotionKind.ToDescription() + " " + EnumDataCheck.Valid.ToDescription() + " 오류.";
      return EnumDataCheck.Valid;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsCouponSave)
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
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(cp_CouponID), " + str + ")+1 AS cp_CouponID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "cp_CouponID", (object) intFormat);
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
          this.cp_CouponID = uniOleDbRecordset.GetFieldLong(0);
        return this.cp_CouponID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      CouponView couponView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(couponView.CreateCodeQuery()))
        {
          couponView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          couponView.cp_CouponID = rs.GetFieldLong(0);
        return couponView.cp_CouponID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    protected bool InsertDetails(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Details.Count == 0)
        return true;
      foreach (CouponDetailView ltDetail in (IEnumerable<CouponDetailView>) this.Lt_Details)
      {
        ltDetail.cpd_GiftCardID = this.cp_GiftCardID;
        ltDetail.cpd_CouponID = this.cp_CouponID;
        ltDetail.cpd_SiteID = this.cp_SiteID;
        if (ltDetail.IsNew)
        {
          ltDetail.cpd_InUser = p_app_employee.emp_Code;
          if (!ltDetail.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 신규 등록 에러");
        }
        else if (ltDetail.IsUpdate)
        {
          ltDetail.cpd_ModUser = p_app_employee.emp_Code;
          if (!ltDetail.UpdateData(p_db, p_app_employee, false))
            throw new UniServiceException(ltDetail.message, ltDetail.TableCode.ToDescription() + " 데이터 변경 에러");
        }
      }
      return true;
    }

    protected async Task<bool> InsertDetailsAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      CouponView couponView = this;
      try
      {
        if (couponView.Lt_Details.Count == 0)
          return true;
        foreach (CouponDetailView item in (IEnumerable<CouponDetailView>) couponView.Lt_Details)
        {
          item.cpd_GiftCardID = couponView.cp_GiftCardID;
          item.cpd_CouponID = couponView.cp_CouponID;
          item.cpd_SiteID = couponView.cp_SiteID;
          if (item.IsNew)
          {
            item.cpd_InUser = p_app_employee.emp_Code;
            if (!await item.InsertDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 신규 등록 에러");
          }
          else if (item.IsUpdate)
          {
            item.cpd_ModUser = p_app_employee.emp_Code;
            if (!await item.UpdateDataAsync(p_db, p_app_employee, false))
              throw new UniServiceException(item.message, item.TableCode.ToDescription() + " 데이터 변경 에러");
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        couponView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        couponView.message = ex.Message;
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
          if (this.cp_SiteID == 0L)
            this.cp_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.cp_CouponID == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
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
      CouponView couponView = this;
      try
      {
        couponView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != couponView.DataCheck(p_db))
            throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (couponView.cp_SiteID == 0L)
            couponView.cp_SiteID = p_app_employee.emp_SiteID;
          if (!couponView.IsPermit(p_app_employee))
            throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (couponView.cp_CouponID == 0L)
        {
          if (!await couponView.CreateCodeAsync(p_db))
            throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await couponView.InsertAsync())
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 등록 오류");
        if (!await couponView.InsertDetailsAsync(p_db, p_app_employee))
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        couponView.db_status = 4;
        couponView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponView.message = ex.Message;
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
        if (this.cp_CouponID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 쿠폰ID(cp_CouponID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
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
      CouponView couponView = this;
      try
      {
        couponView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != couponView.DataCheck(p_db))
            throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!couponView.IsPermit(p_app_employee))
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 권한 검사 실패");
        if (couponView.cp_CouponID == 0L)
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 쿠폰ID(cp_CouponID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await couponView.UpdateAsync())
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 변경 오류");
        if (!await couponView.InsertDetailsAsync(p_db, p_app_employee))
          throw new UniServiceException(couponView.message, couponView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        couponView.db_status = 4;
        couponView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pm_PromotionName = p_rs.GetFieldString("pm_PromotionName");
      this.assignUserName = p_rs.GetFieldString("assignUserName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<CouponView> SelectOneAsync(
      long p_cp_GiftCardID,
      long p_cp_CouponID,
      long p_cp_SiteID = 0)
    {
      CouponView couponView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cp_GiftCardID",
          (object) p_cp_GiftCardID
        },
        {
          (object) "cp_CouponID",
          (object) p_cp_CouponID
        }
      };
      if (p_cp_SiteID > 0L)
        p_param.Add((object) "cp_SiteID", (object) p_cp_SiteID);
      return await couponView.SelectOneTAsync<CouponView>((object) p_param);
    }

    public CouponView SelectOne(long p_cp_GiftCardID, long p_cp_CouponID, long p_cp_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cp_GiftCardID",
          (object) p_cp_GiftCardID
        },
        {
          (object) "cp_CouponID",
          (object) p_cp_CouponID
        }
      };
      if (p_cp_SiteID > 0L)
        p_param.Add((object) "cp_SiteID", (object) p_cp_SiteID);
      return this.SelectOneT<CouponView>((object) p_param);
    }

    public async Task<IList<CouponView>> SelectListAsync(object p_param)
    {
      CouponView couponView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponView1.GetSelectQuery(p_param)))
        {
          couponView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CouponView>) null;
        }
        IList<CouponView> lt_list = (IList<CouponView>) new List<CouponView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CouponView couponView2 = couponView1.OleDB.Create<CouponView>();
            if (couponView2.GetFieldValues(rs))
            {
              couponView2.row_number = lt_list.Count + 1;
              lt_list.Add(couponView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<CouponView> SelectEnumerableAsync(object p_param)
    {
      CouponView couponView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponView1.GetSelectQuery(p_param)))
        {
          couponView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            CouponView couponView2 = couponView1.OleDB.Create<CouponView>();
            if (couponView2.GetFieldValues(rs))
            {
              couponView2.row_number = ++row_number;
              yield return couponView2;
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

    public async Task<IList<CouponView>> SelectListExistsAsync(object p_param)
    {
      CouponView couponView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponView1.GetSelectQuery(p_param)))
        {
          couponView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CouponView>) null;
        }
        IList<CouponView> lt_list = (IList<CouponView>) new List<CouponView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CouponView couponView2 = couponView1.OleDB.Create<CouponView>();
            if (couponView2.GetFieldValues(rs))
            {
              couponView2.row_number = lt_list.Count + 1;
              lt_list.Add(couponView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cp_Title", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_Url", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_Desc", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_LMSKey", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag = false;
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
          if (hashtable.ContainsKey((object) "cp_SiteID") && Convert.ToInt64(hashtable[(object) "cp_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "cp_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "Promotion_DEFULT_TABLE_") && Convert.ToBoolean(hashtable[(object) "Promotion_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "Promotion_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_ASSIGN_USER AS (\nSELECT emp_Code AS emp_CodeAssignUser,emp_Name AS assignUserName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_PROMOTION AS (\nSELECT pm_PromotionCode,pm_SiteID,pm_PromotionName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) TableCodeType.Promotion, (object) DbQueryHelper.ToWithNolock()));
        if (flag)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new TPromotion().GetSelectWhereAnd(p_param));
        }
        else
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("cp_SiteID"))
              p_param1.Add((object) "pm_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("cp_PromotionID"))
              p_param1.Add((object) "pm_PromotionCode", dictionaryEntry.Value);
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "pm_SiteID"))
              p_param1.Add((object) "pm_SiteID", (object) num2);
            stringBuilder.Append("\n");
            stringBuilder.Append(new TPromotion().GetSelectWhereAnd((object) p_param1));
          }
          else if (num2 > 0L)
            stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pm_SiteID", (object) num2));
        }
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  cp_GiftCardID,cp_CouponID,cp_SiteID,cp_CouponType,cp_Apply,cp_EmpCode,cp_Title,cp_Url,cp_Desc,cp_LMSKey,cp_IssueCnt,cp_UsableCnt,cp_CampaignCode,cp_PromotionID,cp_Status,cp_ApprovalDate,cp_SendDate,cp_InDate,cp_InUser,cp_ModDate,cp_ModUser\n,pm_PromotionName\n,assignUserName,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_PROMOTION ON cp_PromotionID=pm_PromotionCode AND cp_SiteID=pm_SiteID\nLEFT OUTER JOIN T_ASSIGN_USER ON cp_EmpCode=emp_CodeAssignUser\nLEFT OUTER JOIN T_EMPLOYEE_IN ON cp_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON cp_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY cp_GiftCardID,cp_CouponID");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY cp_GiftCardID,cp_CouponID");
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
