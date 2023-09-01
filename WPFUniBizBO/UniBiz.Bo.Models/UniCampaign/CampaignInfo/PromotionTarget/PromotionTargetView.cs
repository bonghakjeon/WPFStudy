// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget.PromotionTargetView
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget
{
  public class PromotionTargetView : TPromotionTarget<PromotionTargetView>
  {
    private int _pm_TargetGroup;
    private string _pmt_LinkViewCode;
    private string _pmt_LinkName;
    private string _pmt_LinkGoodsSize;
    private string _inEmpName;
    private string _modEmpName;

    public int pm_TargetGroup
    {
      get => this._pm_TargetGroup;
      set
      {
        this._pm_TargetGroup = value;
        this.Changed(nameof (pm_TargetGroup));
        this.Changed("pm_TargetGroupDesc");
      }
    }

    public string pm_TargetGroupDesc => this.pm_TargetGroup != 0 ? Enum2StrConverter.ToPromotionTargetGroup(this.pm_TargetGroup).ToDescription() : string.Empty;

    public string pmt_LinkViewCode
    {
      get => this._pmt_LinkViewCode;
      set
      {
        this._pmt_LinkViewCode = value;
        this.Changed(nameof (pmt_LinkViewCode));
      }
    }

    public string pmt_LinkName
    {
      get => this._pmt_LinkName;
      set
      {
        this._pmt_LinkName = value;
        this.Changed(nameof (pmt_LinkName));
      }
    }

    public string pmt_LinkGoodsSize
    {
      get => this._pmt_LinkGoodsSize;
      set
      {
        this._pmt_LinkGoodsSize = value;
        this.Changed(nameof (pmt_LinkGoodsSize));
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
      columnInfo.Add("pm_TargetGroup", new TTableColumn()
      {
        tc_orgin_name = "pm_TargetGroup",
        tc_trans_name = "적용대상",
        tc_comm_code = 224
      });
      columnInfo.Add("pmt_LinkViewCode", new TTableColumn()
      {
        tc_orgin_name = "pmt_LinkViewCode",
        tc_trans_name = "할인대상 코드"
      });
      columnInfo.Add("pmt_LinkName", new TTableColumn()
      {
        tc_orgin_name = "pmt_LinkName",
        tc_trans_name = "할인대상 명"
      });
      columnInfo.Add("pmt_LinkGoodsSize", new TTableColumn()
      {
        tc_orgin_name = "pmt_LinkGoodsSize",
        tc_trans_name = "규격/설명"
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
      this.pm_TargetGroup = 0;
      this.pmt_LinkViewCode = this.pmt_LinkName = this.pmt_LinkGoodsSize = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new PromotionTargetView();

    public override object Clone()
    {
      PromotionTargetView promotionTargetView = base.Clone() as PromotionTargetView;
      promotionTargetView.pm_TargetGroup = this.pm_TargetGroup;
      promotionTargetView.pmt_LinkViewCode = this.pmt_LinkViewCode;
      promotionTargetView.pmt_LinkName = this.pmt_LinkName;
      promotionTargetView.pmt_LinkGoodsSize = this.pmt_LinkGoodsSize;
      promotionTargetView.inEmpName = this.inEmpName;
      promotionTargetView.modEmpName = this.modEmpName;
      return (object) promotionTargetView;
    }

    public void PutData(PromotionTargetView pSource)
    {
      this.PutData((TPromotionTarget) pSource);
      this.pm_TargetGroup = pSource.pm_TargetGroup;
      this.pmt_LinkViewCode = pSource.pmt_LinkViewCode;
      this.pmt_LinkName = pSource.pmt_LinkName;
      this.pmt_LinkGoodsSize = pSource.pmt_LinkGoodsSize;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.pmt_SiteID == 0L)
      {
        this.message = "싸이트(pmt_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmt_PromotionCode == 0L)
      {
        this.message = "프로모션코드(pmt_PromotionCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.pmt_TargetCode != 0L)
        return EnumDataCheck.Success;
      this.message = "할인대상코드(pmt_TargetCode)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsPromotionSave)
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
          if (this.pmt_SiteID == 0L)
            this.pmt_SiteID = p_app_employee.emp_SiteID;
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
      PromotionTargetView promotionTargetView = this;
      try
      {
        promotionTargetView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await promotionTargetView.DataCheckAsync(p_db))
            throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (promotionTargetView.pmt_SiteID == 0L)
            promotionTargetView.pmt_SiteID = p_app_employee.emp_SiteID;
          if (!promotionTargetView.IsPermit(p_app_employee))
            throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await promotionTargetView.InsertAsync())
          throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        promotionTargetView.db_status = 4;
        promotionTargetView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionTargetView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionTargetView.message = ex.Message;
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
      PromotionTargetView promotionTargetView = this;
      try
      {
        promotionTargetView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await promotionTargetView.DataCheckAsync(p_db))
            throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!promotionTargetView.IsPermit(p_app_employee))
          throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await promotionTargetView.DeleteAsync())
          throw new UniServiceException(promotionTargetView.message, promotionTargetView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        promotionTargetView.db_status = 4;
        promotionTargetView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionTargetView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        promotionTargetView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.pm_TargetGroup = p_rs.GetFieldInt("pm_TargetGroup");
      this.pmt_LinkViewCode = p_rs.GetFieldString("pmt_LinkViewCode");
      this.pmt_LinkName = p_rs.GetFieldString("pmt_LinkName");
      this.pmt_LinkGoodsSize = p_rs.GetFieldString("pmt_LinkGoodsSize");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<PromotionTargetView> SelectOneAsync(
      long p_pmt_PromotionCode,
      long p_pmt_TargetCode,
      long p_pmt_SiteID = 0)
    {
      PromotionTargetView promotionTargetView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmt_PromotionCode",
          (object) p_pmt_PromotionCode
        },
        {
          (object) "pmt_TargetCode",
          (object) p_pmt_TargetCode
        }
      };
      if (p_pmt_SiteID > 0L)
        p_param.Add((object) "pmt_SiteID", (object) p_pmt_SiteID);
      return await promotionTargetView.SelectOneTAsync<PromotionTargetView>((object) p_param);
    }

    public PromotionTargetView SelectOne(
      long p_pmt_PromotionCode,
      long p_pmt_TargetCode,
      long p_pmt_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "pmt_PromotionCode",
          (object) p_pmt_PromotionCode
        },
        {
          (object) "pmt_TargetCode",
          (object) p_pmt_TargetCode
        }
      };
      if (p_pmt_SiteID > 0L)
        p_param.Add((object) "pmt_SiteID", (object) p_pmt_SiteID);
      return this.SelectOneT<PromotionTargetView>((object) p_param);
    }

    public async Task<IList<PromotionTargetView>> SelectListAsync(object p_param)
    {
      PromotionTargetView promotionTargetView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionTargetView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionTargetView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionTargetView1.GetSelectQuery(p_param)))
        {
          promotionTargetView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionTargetView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PromotionTargetView>) null;
        }
        IList<PromotionTargetView> lt_list = (IList<PromotionTargetView>) new List<PromotionTargetView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PromotionTargetView promotionTargetView2 = promotionTargetView1.OleDB.Create<PromotionTargetView>();
            if (promotionTargetView2.GetFieldValues(rs))
            {
              promotionTargetView2.row_number = lt_list.Count + 1;
              lt_list.Add(promotionTargetView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionTargetView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<PromotionTargetView> SelectEnumerableAsync(object p_param)
    {
      PromotionTargetView promotionTargetView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionTargetView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionTargetView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionTargetView1.GetSelectQuery(p_param)))
        {
          promotionTargetView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionTargetView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            PromotionTargetView promotionTargetView2 = promotionTargetView1.OleDB.Create<PromotionTargetView>();
            if (promotionTargetView2.GetFieldValues(rs))
            {
              promotionTargetView2.row_number = ++row_number;
              yield return promotionTargetView2;
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

    public async Task<IList<PromotionTargetView>> SelectListExistsAsync(object p_param)
    {
      PromotionTargetView promotionTargetView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(promotionTargetView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, promotionTargetView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(promotionTargetView1.GetSelectQuery(p_param)))
        {
          promotionTargetView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionTargetView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<PromotionTargetView>) null;
        }
        IList<PromotionTargetView> lt_list = (IList<PromotionTargetView>) new List<PromotionTargetView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            PromotionTargetView promotionTargetView2 = promotionTargetView1.OleDB.Create<PromotionTargetView>();
            if (promotionTargetView2.GetFieldValues(rs))
            {
              promotionTargetView2.row_number = lt_list.Count + 1;
              lt_list.Add(promotionTargetView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + promotionTargetView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
          if (hashtable.ContainsKey((object) "pmt_SiteID") && Convert.ToInt64(hashtable[(object) "pmt_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "pmt_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "Promotion_DEFULT_TABLE_") && Convert.ToBoolean(hashtable[(object) "Promotion_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "Promotion_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_PROMOTION AS (\nSELECT pm_PromotionCode,pm_SiteID,pm_PromotionName,pm_TargetGroup" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) TableCodeType.Promotion, (object) DbQueryHelper.ToWithNolock()));
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
            if (dictionaryEntry.Key.ToString().Equals("pmt_SiteID"))
              p_param1.Add((object) "pm_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("pmt_PromotionCode"))
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
        stringBuilder.Append("\n,T_LINK AS (\nSELECT gd_GoodsCode AS gd_GoodsCode,gd_SiteID AS gd_SiteID" + string.Format(",{0} AS link_{1}", (object) 2, (object) "pm_TargetGroup") + ",gd_BarCode AS pmt_LinkViewCode,gd_GoodsName AS pmt_LinkName,gd_GoodsSize AS pmt_LinkGoodsSize" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) num2));
        stringBuilder.Append("\nUNION ALL\nSELECT ctg_ID AS gd_GoodsCode,ctg_SiteID AS gd_SiteID" + string.Format(",{0} AS link_{1}", (object) 3, (object) "pm_TargetGroup") + ",ctg_ViewCode AS pmt_LinkViewCode,ctg_CategoryName AS pmt_LinkName,ctg_Memo AS pmt_LinkGoodsSize" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "ctg_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  pmt_PromotionCode,pmt_TargetCode,pmt_SiteID,pmt_InDate,pmt_InUser,pmt_ModDate,pmt_ModUser\n,pm_TargetGroup\n,pmt_LinkViewCode,pmt_LinkName,pmt_LinkGoodsSize\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_PROMOTION ON pmt_PromotionCode=pm_PromotionCode AND pmt_SiteID=pm_SiteID\nINNER JOIN T_LINK ON pmt_TargetCode=gd_GoodsCode AND pm_TargetGroup=link_pm_TargetGroup AND pmt_SiteID=gd_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON pmt_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON pmt_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY pmt_PromotionCode,pmt_TargetCode");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY pmt_PromotionCode,pmt_TargetCode");
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
