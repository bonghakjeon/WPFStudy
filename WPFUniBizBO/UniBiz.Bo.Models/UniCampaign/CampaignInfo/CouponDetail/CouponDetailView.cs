// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail.CouponDetailView
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail
{
  public class CouponDetailView : TCouponDetail<CouponDetailView>
  {
    private int _cp_CouponType;
    private string _cpd_MemberName;
    private string _inEmpName;
    private string _modEmpName;

    public int cp_CouponType
    {
      get => this._cp_CouponType;
      set
      {
        this._cp_CouponType = value;
        this.Changed(nameof (cp_CouponType));
        this.Changed("cp_CouponTypeDesc");
      }
    }

    public string cp_CouponTypeDesc => this.cp_CouponType != 0 ? Enum2StrConverter.ToCouponType(this.cp_CouponType).ToDescription() : string.Empty;

    public string cpd_MemberName
    {
      get => this._cpd_MemberName;
      set
      {
        this._cpd_MemberName = value;
        this.Changed(nameof (cpd_MemberName));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cp_CouponType", new TTableColumn()
      {
        tc_orgin_name = "cp_CouponType",
        tc_trans_name = "쿠폰구분",
        tc_comm_code = 227
      });
      columnInfo.Add("cpd_MemberName", new TTableColumn()
      {
        tc_orgin_name = "cpd_MemberName",
        tc_trans_name = "회원(회원유형)명"
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
      this.cp_CouponType = 0;
      this.cpd_MemberName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CouponDetailView();

    public override object Clone()
    {
      CouponDetailView couponDetailView = base.Clone() as CouponDetailView;
      couponDetailView.cp_CouponType = this.cp_CouponType;
      couponDetailView.cpd_MemberName = this.cpd_MemberName;
      couponDetailView.inEmpName = this.inEmpName;
      couponDetailView.modEmpName = this.modEmpName;
      return (object) couponDetailView;
    }

    public void PutData(CouponDetailView pSource)
    {
      this.PutData((TCouponDetail) pSource);
      this.cp_CouponType = pSource.cp_CouponType;
      this.cpd_MemberName = pSource.cpd_MemberName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.cpd_SiteID == 0L)
      {
        this.message = "싸이트(cpd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.cpd_CouponNo))
      {
        this.message = "쿠폰번호(cpd_CouponNo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.cpd_CouponID == 0L)
      {
        this.message = "쿠폰ID(cpd_CouponID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToCouponApplyDiv(this.cpd_ApplyDiv) == EnumCouponApplyDiv.None)
      {
        this.message = "적용구분(cpd_ApplyDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.cpd_ApplyDiv <= 1 || this.cpd_MemberNo != 0L)
        return EnumDataCheck.Success;
      this.message = "회원(회원유형)(cpd_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = base.DataCheck(p_db);
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (this.IsNew)
      {
        IList<CouponDetailView> couponDetailViewList = p_db.Create<CouponDetailView>().SelectListE<CouponDetailView>((object) new Hashtable()
        {
          {
            (object) "cpd_SiteID",
            (object) this.cpd_SiteID
          },
          {
            (object) "cpd_CouponNo",
            (object) this.cpd_CouponNo
          }
        });
        if (couponDetailViewList != null && couponDetailViewList.Count > 0)
        {
          this.message = "쿠폰번호(cpd_CouponNo) " + EnumDataCheck.Exists.ToDescription() + "\n - " + couponDetailViewList[0].cpd_CouponNo + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
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
      if (!p_app_employee.IsCouponSave)
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
          if (this.cpd_SiteID == 0L)
            this.cpd_SiteID = p_app_employee.emp_SiteID;
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
      CouponDetailView couponDetailView = this;
      try
      {
        couponDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != couponDetailView.DataCheck(p_db))
            throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (couponDetailView.cpd_SiteID == 0L)
            couponDetailView.cpd_SiteID = p_app_employee.emp_SiteID;
          if (!couponDetailView.IsPermit(p_app_employee))
            throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await couponDetailView.InsertAsync())
          throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        couponDetailView.db_status = 4;
        couponDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponDetailView.message = ex.Message;
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
      CouponDetailView couponDetailView = this;
      try
      {
        couponDetailView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != couponDetailView.DataCheck(p_db))
            throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!couponDetailView.IsPermit(p_app_employee))
          throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await couponDetailView.UpdateAsync())
          throw new UniServiceException(couponDetailView.message, couponDetailView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        couponDetailView.db_status = 4;
        couponDetailView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponDetailView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        couponDetailView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.cp_CouponType = p_rs.GetFieldInt("cp_CouponType");
      this.cpd_MemberName = p_rs.GetFieldString("cpd_MemberName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<CouponDetailView> SelectOneAsync(
      string p_cpd_CouponNo,
      long p_cpd_GiftCardID,
      long p_cpd_CouponID,
      long p_cpd_SiteID = 0)
    {
      CouponDetailView couponDetailView = this;
      if (string.IsNullOrEmpty(p_cpd_CouponNo))
        return (CouponDetailView) null;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cpd_CouponNo",
          (object) p_cpd_CouponNo
        },
        {
          (object) "cpd_GiftCardID",
          (object) p_cpd_GiftCardID
        },
        {
          (object) "cpd_CouponID",
          (object) p_cpd_CouponID
        }
      };
      if (p_cpd_SiteID > 0L)
        p_param.Add((object) "cpd_SiteID", (object) p_cpd_SiteID);
      return await couponDetailView.SelectOneTAsync<CouponDetailView>((object) p_param);
    }

    public CouponDetailView SelectOne(
      string p_cpd_CouponNo,
      long p_cpd_GiftCardID,
      long p_cpd_CouponID,
      long p_cpd_SiteID = 0)
    {
      if (string.IsNullOrEmpty(p_cpd_CouponNo))
        return (CouponDetailView) null;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "cpd_CouponNo",
          (object) p_cpd_CouponNo
        },
        {
          (object) "cpd_GiftCardID",
          (object) p_cpd_GiftCardID
        },
        {
          (object) "cpd_CouponID",
          (object) p_cpd_CouponID
        }
      };
      if (p_cpd_SiteID > 0L)
        p_param.Add((object) "cpd_SiteID", (object) p_cpd_SiteID);
      return this.SelectOneT<CouponDetailView>((object) p_param);
    }

    public async Task<IList<CouponDetailView>> SelectListAsync(object p_param)
    {
      CouponDetailView couponDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponDetailView1.GetSelectQuery(p_param)))
        {
          couponDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CouponDetailView>) null;
        }
        IList<CouponDetailView> lt_list = (IList<CouponDetailView>) new List<CouponDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CouponDetailView couponDetailView2 = couponDetailView1.OleDB.Create<CouponDetailView>();
            if (couponDetailView2.GetFieldValues(rs))
            {
              couponDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(couponDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<CouponDetailView> SelectEnumerableAsync(object p_param)
    {
      CouponDetailView couponDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponDetailView1.GetSelectQuery(p_param)))
        {
          couponDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            CouponDetailView couponDetailView2 = couponDetailView1.OleDB.Create<CouponDetailView>();
            if (couponDetailView2.GetFieldValues(rs))
            {
              couponDetailView2.row_number = ++row_number;
              yield return couponDetailView2;
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

    public async Task<IList<CouponDetailView>> SelectListExistsAsync(object p_param)
    {
      CouponDetailView couponDetailView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(couponDetailView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, couponDetailView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(couponDetailView1.GetSelectQuery(p_param)))
        {
          couponDetailView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CouponDetailView>) null;
        }
        IList<CouponDetailView> lt_list = (IList<CouponDetailView>) new List<CouponDetailView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CouponDetailView couponDetailView2 = couponDetailView1.OleDB.Create<CouponDetailView>();
            if (couponDetailView2.GetFieldValues(rs))
            {
              couponDetailView2.row_number = lt_list.Count + 1;
              lt_list.Add(couponDetailView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + couponDetailView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cpd_MobileNo", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "cpd_SiteID") && Convert.ToInt64(hashtable[(object) "cpd_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "cpd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "Coupon_DEFULT_TABLE_") && Convert.ToBoolean(hashtable[(object) "Coupon_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "Coupon_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_HEADER AS (\nSELECT cp_GiftCardID,cp_CouponID,cp_SiteID,cp_CouponType" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) TableCodeType.Coupon, (object) DbQueryHelper.ToWithNolock()));
        if (flag)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new TCoupon().GetSelectWhereAnd(p_param));
        }
        else
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("cpd_SiteID"))
              p_param1.Add((object) "cp_SiteID", dictionaryEntry.Value);
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "cp_SiteID"))
              p_param1.Add((object) "cp_SiteID", (object) num2);
            stringBuilder.Append("\n");
            stringBuilder.Append(new TCoupon().GetSelectWhereAnd((object) p_param1));
          }
          else if (num2 > 0L)
            stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "cp_SiteID", (object) num2));
        }
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER AS (" + string.Format("\nSELECT {0} AS {1}", (object) 81, (object) "mbr_MemberType") + ",mt_TypeCode AS mbr_MemberNo,mt_SiteID AS mbr_SiteID,mt_TypeName AS mbr_MemberName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberType, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mt_SiteID", (object) num2));
        stringBuilder.Append("\nUNION ALL" + string.Format("\nSELECT {0} AS {1}", (object) 84, (object) "mbr_MemberType") + ",mbr_MemberNo,mbr_SiteID,mbr_MemberName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mbr_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  cpd_CouponNo,cpd_GiftCardID,cpd_CouponID,cpd_SiteID,cpd_ApplyDiv,cpd_MemberNo,cpd_MobileNo,cpd_UseCnt,cpd_StopYn,cpd_InDate,cpd_InUser,cpd_ModDate,cpd_ModUser,\n,cp_CouponType\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON cpd_GiftCardID=cp_GiftCardID AND cpd_CouponID=cp_CouponID AND cpd_SiteID=cp_SiteID\nLEFT OUTER JOIN T_MEMBER ON cpd_ApplyDiv=mbr_MemberType AND cpd_MemberNo=mbr_MemberNo AND cpd_SiteID=mbr_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON cpd_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON cpd_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY cpd_CouponNo,cpd_GiftCardID,cpd_CouponID");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY cpd_CouponNo,cpd_GiftCardID,cpd_CouponID");
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
