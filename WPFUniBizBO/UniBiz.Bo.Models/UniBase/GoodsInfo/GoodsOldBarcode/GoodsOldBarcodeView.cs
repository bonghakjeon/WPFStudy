// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode.GoodsOldBarcodeView
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode
{
  public class GoodsOldBarcodeView : TGoodsOldBarcode<GoodsOldBarcodeView>
  {
    private string _inEmpName;
    private string _modEmpName;

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
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원"
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsOldBarcodeView();

    public override object Clone()
    {
      GoodsOldBarcodeView goodsOldBarcodeView = base.Clone() as GoodsOldBarcodeView;
      goodsOldBarcodeView.inEmpName = this.inEmpName;
      goodsOldBarcodeView.modEmpName = this.modEmpName;
      return (object) goodsOldBarcodeView;
    }

    public void PutData(GoodsOldBarcodeView pSource)
    {
      this.PutData((TGoodsOldBarcode) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gdob_SiteID == 0L)
      {
        this.message = "싸이트(gdob_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdob_GoodsCode == 0L)
      {
        this.message = "지점코드(gdob_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.gdob_BarCode))
        return EnumDataCheck.Success;
      this.message = "구 바코드(gdob_BarCode)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      Hashtable p_param = new Hashtable();
      p_param.Add((object) "gd_SiteID", (object) this.gdob_SiteID);
      p_param.Add((object) "gd_BarCode", (object) this.gdob_BarCode);
      IList<GoodsView> goodsViewList = p_db.Create<GoodsView>().SelectListE<GoodsView>((object) p_param);
      if (goodsViewList != null && goodsViewList.Count > 0)
      {
        this.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsViewList[0].gd_GoodsName + "(" + goodsViewList[0].gd_BarCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
        return EnumDataCheck.Exists;
      }
      p_param.Clear();
      p_param.Add((object) "gdob_SiteID", (object) this.gdob_SiteID);
      p_param.Add((object) "gdob_BarCode", (object) this.gdob_BarCode);
      IList<GoodsOldBarcodeView> goodsOldBarcodeViewList = p_db.Create<GoodsOldBarcodeView>().SelectListE<GoodsOldBarcodeView>((object) p_param);
      if (goodsOldBarcodeViewList != null && goodsOldBarcodeViewList.Count > 0)
      {
        if (this.IsNew)
        {
          this.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsOldBarcodeViewList[0].gdob_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
          return EnumDataCheck.Exists;
        }
        if (this.IsUpdate)
        {
          foreach (GoodsOldBarcodeView goodsOldBarcodeView in (IEnumerable<GoodsOldBarcodeView>) goodsOldBarcodeViewList)
          {
            if (!goodsOldBarcodeView.gdob_BarCode.Equals(this.gdob_BarCode))
            {
              this.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsOldBarcodeView.gdob_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
              return EnumDataCheck.Exists;
            }
          }
        }
      }
      return EnumDataCheck.Success;
    }

    protected override async Task<EnumDataCheck> DataCheckAsync(UniOleDatabase p_db)
    {
      GoodsOldBarcodeView goodsOldBarcodeView1 = this;
      EnumDataCheck enumDataCheck = goodsOldBarcodeView1.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        goodsOldBarcodeView1.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      Hashtable param = new Hashtable();
      param.Add((object) "gd_SiteID", (object) goodsOldBarcodeView1.gdob_SiteID);
      param.Add((object) "gd_BarCode", (object) goodsOldBarcodeView1.gdob_BarCode);
      IList<GoodsView> goodsViewList = await p_db.Create<GoodsView>().SelectListEAsync<GoodsView>((object) param);
      if (goodsViewList != null && goodsViewList.Count > 0)
      {
        goodsOldBarcodeView1.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsViewList[0].gd_GoodsName + "(" + goodsViewList[0].gd_BarCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
        return EnumDataCheck.Exists;
      }
      param.Clear();
      param.Add((object) "gdob_SiteID", (object) goodsOldBarcodeView1.gdob_SiteID);
      param.Add((object) "gdob_BarCode", (object) goodsOldBarcodeView1.gdob_BarCode);
      IList<GoodsOldBarcodeView> goodsOldBarcodeViewList = await p_db.Create<GoodsOldBarcodeView>().SelectListAsync((object) param);
      if (goodsOldBarcodeViewList != null && goodsOldBarcodeViewList.Count > 0)
      {
        if (goodsOldBarcodeView1.IsNew)
        {
          goodsOldBarcodeView1.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsOldBarcodeViewList[0].gdob_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
          return EnumDataCheck.Exists;
        }
        if (goodsOldBarcodeView1.IsUpdate)
        {
          foreach (GoodsOldBarcodeView goodsOldBarcodeView2 in (IEnumerable<GoodsOldBarcodeView>) goodsOldBarcodeViewList)
          {
            if (!goodsOldBarcodeView2.gdob_BarCode.Equals(goodsOldBarcodeView1.gdob_BarCode))
            {
              goodsOldBarcodeView1.message = "구 바코드(gdob_BarCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + goodsOldBarcodeView2.gdob_BarCode + " " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
              return EnumDataCheck.Exists;
            }
          }
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
      if (!p_app_employee.IsGoodsSave && !p_app_employee.IsGoodsSavePriceExcept)
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
          if (this.gdob_SiteID == 0L)
            this.gdob_SiteID = p_app_employee.emp_SiteID;
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
      GoodsOldBarcodeView goodsOldBarcodeView = this;
      try
      {
        goodsOldBarcodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await goodsOldBarcodeView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsOldBarcodeView.gdob_SiteID == 0L)
            goodsOldBarcodeView.gdob_SiteID = p_app_employee.emp_SiteID;
          if (!goodsOldBarcodeView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await goodsOldBarcodeView.InsertAsync())
          throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 등록 오류");
        goodsOldBarcodeView.db_status = 4;
        goodsOldBarcodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsOldBarcodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsOldBarcodeView.message = ex.Message;
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
      GoodsOldBarcodeView goodsOldBarcodeView = this;
      try
      {
        goodsOldBarcodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != await goodsOldBarcodeView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsOldBarcodeView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await goodsOldBarcodeView.UpdateAsync())
          throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 변경 오류");
        goodsOldBarcodeView.db_status = 4;
        goodsOldBarcodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsOldBarcodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsOldBarcodeView.message = ex.Message;
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
      GoodsOldBarcodeView goodsOldBarcodeView = this;
      try
      {
        goodsOldBarcodeView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != await goodsOldBarcodeView.DataCheckAsync(p_db))
            throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsOldBarcodeView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsOldBarcodeView.DeleteAsync())
          throw new UniServiceException(goodsOldBarcodeView.message, goodsOldBarcodeView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsOldBarcodeView.db_status = 4;
        goodsOldBarcodeView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsOldBarcodeView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsOldBarcodeView.message = ex.Message;
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

    public async Task<GoodsOldBarcodeView> SelectOneAsync(
      long p_gdob_GoodsCode,
      string p_gdob_BarCode,
      long p_gdob_SiteID = 0)
    {
      GoodsOldBarcodeView goodsOldBarcodeView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gdob_GoodsCode",
          (object) p_gdob_GoodsCode
        },
        {
          (object) "gdob_BarCode",
          (object) p_gdob_BarCode
        }
      };
      if (p_gdob_SiteID > 0L)
        p_param.Add((object) "gdob_SiteID", (object) p_gdob_SiteID);
      return await goodsOldBarcodeView.SelectOneTAsync<GoodsOldBarcodeView>((object) p_param);
    }

    public async Task<IList<GoodsOldBarcodeView>> SelectListAsync(object p_param)
    {
      GoodsOldBarcodeView goodsOldBarcodeView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsOldBarcodeView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsOldBarcodeView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsOldBarcodeView1.GetSelectQuery(p_param)))
        {
          goodsOldBarcodeView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsOldBarcodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsOldBarcodeView>) null;
        }
        IList<GoodsOldBarcodeView> lt_list = (IList<GoodsOldBarcodeView>) new List<GoodsOldBarcodeView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsOldBarcodeView goodsOldBarcodeView2 = goodsOldBarcodeView1.OleDB.Create<GoodsOldBarcodeView>();
            if (goodsOldBarcodeView2.GetFieldValues(rs))
            {
              goodsOldBarcodeView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsOldBarcodeView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsOldBarcodeView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gdob_BarCode", hashtable[(object) "_KEY_WORD_"]));
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
        string empty = string.Empty;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gdob_SiteID") && Convert.ToInt64(hashtable[(object) "gdob_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "gdob_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gdob_GoodsCode,gdob_BarCode,gdob_SiteID,gdob_AddProperty,gdob_InDate,gdob_InUser,gdob_ModDate,gdob_ModUser,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON gdob_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON gdob_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gdob_GoodsCode,gdob_BarCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      Log.Logger.DebugColor(" 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + string.Format("\n LINE : {0} 행", (object) new StackFrame(0, true).GetFileLineNumber()) + "\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------\n" + stringBuilder.ToString() + "\n{EnumTypes.LINE_ONE}");
      return stringBuilder.ToString();
    }
  }
}
