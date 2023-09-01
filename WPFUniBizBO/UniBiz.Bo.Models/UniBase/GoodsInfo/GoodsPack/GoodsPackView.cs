// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack.GoodsPackView
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack
{
  public class GoodsPackView : TGoodsPack<GoodsPackView>
  {
    private GoodsView _EaInfo;
    private double _eah_PointRate;
    private GoodsView _SetInfo;
    private double _seth_PointRate;
    private string _inEmpName;
    private string _modEmpName;

    [JsonPropertyName("eaInfo")]
    public GoodsView EaInfo
    {
      get => this._EaInfo ?? (this._EaInfo = new GoodsView());
      set
      {
        this._EaInfo = value;
        this.Changed(nameof (EaInfo));
      }
    }

    public double eah_PointRate
    {
      get => this._eah_PointRate;
      set
      {
        this._eah_PointRate = value;
        this.Changed(nameof (eah_PointRate));
      }
    }

    [JsonPropertyName("setInfo")]
    public GoodsView SetInfo
    {
      get => this._SetInfo ?? (this._SetInfo = new GoodsView());
      set
      {
        this._SetInfo = value;
        this.Changed(nameof (SetInfo));
      }
    }

    public double seth_PointRate
    {
      get => this._seth_PointRate;
      set
      {
        this._seth_PointRate = value;
        this.Changed(nameof (seth_PointRate));
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
      this.EaInfo = (GoodsView) null;
      this.eah_PointRate = 0.0;
      this.SetInfo = (GoodsView) null;
      this.seth_PointRate = 0.0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsPackView();

    public override object Clone()
    {
      GoodsPackView goodsPackView = base.Clone() as GoodsPackView;
      goodsPackView.EaInfo = (GoodsView) null;
      if (this.EaInfo.gd_GoodsCode > 0L)
        goodsPackView.EaInfo = this.EaInfo;
      goodsPackView.eah_PointRate = this.eah_PointRate;
      goodsPackView.SetInfo = (GoodsView) null;
      if (this.SetInfo.gd_GoodsCode > 0L)
        goodsPackView.SetInfo = this.SetInfo;
      goodsPackView.seth_PointRate = this.seth_PointRate;
      goodsPackView.inEmpName = this.inEmpName;
      goodsPackView.modEmpName = this.modEmpName;
      return (object) goodsPackView;
    }

    public void PutData(GoodsPackView pSource)
    {
      this.PutData((TGoodsPack) pSource);
      this.EaInfo = (GoodsView) null;
      if (pSource.EaInfo.gd_GoodsCode > 0L)
        this.EaInfo.PutData(pSource.EaInfo);
      this.eah_PointRate = pSource.eah_PointRate;
      this.SetInfo = (GoodsView) null;
      if (pSource.SetInfo.gd_GoodsCode > 0L)
        this.SetInfo.PutData(pSource.SetInfo);
      this.seth_PointRate = pSource.seth_PointRate;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gdp_SiteID == 0L)
      {
        this.message = "싸이트(gdp_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdp_GoodsCode == 0L)
      {
        this.message = "세트 상품(gdp_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gdp_SubGoodsCode == 0L)
      {
        this.message = "구성 상품(gdp_SubGoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.gdp_StockConvQty.IsZero())
        return EnumDataCheck.Success;
      this.message = "구성 입수량(gdp_StockConvQty)  " + EnumDataCheck.CodeZero.ToDescription();
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
      if (!p_app_employee.IsGoodsSave)
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
          if (this.gdp_SiteID == 0L)
            this.gdp_SiteID = p_app_employee.emp_SiteID;
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
      GoodsPackView goodsPackView = this;
      try
      {
        goodsPackView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsPackView.DataCheck(p_db))
            throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsPackView.gdp_SiteID == 0L)
            goodsPackView.gdp_SiteID = p_app_employee.emp_SiteID;
          if (!goodsPackView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await goodsPackView.InsertAsync())
          throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 등록 오류");
        goodsPackView.db_status = 4;
        goodsPackView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsPackView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsPackView.message = ex.Message;
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
      GoodsPackView goodsPackView = this;
      try
      {
        goodsPackView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != goodsPackView.DataCheck(p_db))
            throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsPackView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await goodsPackView.UpdateAsync())
          throw new UniServiceException(goodsPackView.message, goodsPackView.TableCode.ToDescription() + " 변경 오류");
        goodsPackView.db_status = 4;
        goodsPackView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        goodsPackView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        goodsPackView.message = ex.Message;
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

    public async Task<GoodsPackView> SelectOneAsync(
      long p_gdp_GoodsCode,
      long p_gdp_SubGoodsCode,
      long p_gdp_SiteID = 0)
    {
      GoodsPackView goodsPackView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gdp_GoodsCode",
          (object) p_gdp_GoodsCode
        },
        {
          (object) "gdp_SubGoodsCode",
          (object) p_gdp_SubGoodsCode
        }
      };
      if (p_gdp_SiteID > 0L)
        p_param.Add((object) "gdp_SiteID", (object) p_gdp_SiteID);
      return await goodsPackView.SelectOneTAsync<GoodsPackView>((object) p_param);
    }

    public async Task<IList<GoodsPackView>> SelectListAsync(object p_param)
    {
      GoodsPackView goodsPackView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsPackView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsPackView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsPackView1.GetSelectQuery(p_param)))
        {
          goodsPackView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsPackView>) null;
        }
        IList<GoodsPackView> lt_list = (IList<GoodsPackView>) new List<GoodsPackView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsPackView goodsPackView2 = goodsPackView1.OleDB.Create<GoodsPackView>();
            if (goodsPackView2.GetFieldValues(rs))
            {
              goodsPackView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsPackView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "_IsSupplierNotEqual_") && Convert.ToBoolean(hashtable[(object) "_IsSupplierNotEqual_"].ToString()))
          stringBuilder.Append(" AND seth_gdh_Supplier != eah_gdh_Supplier");
        if (hashtable.ContainsKey((object) "_IsCategoryNotEqual_") && Convert.ToBoolean(hashtable[(object) "_IsCategoryNotEqual_"].ToString()))
          stringBuilder.Append(" AND seth_gdh_GoodsCategory != eah_gdh_GoodsCategory");
        if (hashtable.ContainsKey((object) "_IsPriceNotEqual_") && Convert.ToBoolean(hashtable[(object) "_IsPriceNotEqual_"].ToString()))
        {
          stringBuilder.Append(" AND (seth_gdh_BuyCost != eah_gdh_BuyCost*gdp_StockConvQty");
          stringBuilder.Append(" OR seth_gdh_SalePrice != eah_gdh_SalePrice*gdp_StockConvQty");
          stringBuilder.Append(")");
        }
        if (hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
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
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gdp_SiteID") && Convert.ToInt64(hashtable[(object) "gdp_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "gdp_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
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
        stringBuilder.Append(",T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) num1);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SET_CODE AS (\nSELECT gdp_GoodsCode AS setc_GoodsCode,gdp_SiteID AS setc_SiteID" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()));
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdp_SiteID", (object) num1));
        stringBuilder.Append("\nGROUP BY gdp_GoodsCode,gdp_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EA_CODE AS (\nSELECT gdp_SubGoodsCode AS eac_GoodsCode,gdp_SiteID AS eac_SiteID" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()));
        if (num1 > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdp_SiteID", (object) num1));
        stringBuilder.Append("\nGROUP BY gdp_SubGoodsCode,gdp_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (num2 > 0)
        {
          stringBuilder.Append(",T_BOOKMARK_GOODS AS ( SELECT bgl_GoodsCode,bgl_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) num2));
          if (num1 > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) num1));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append(",T_SET_INFO AS (SELECT gd_GoodsCode AS set_gd_GoodsCode,gd_SiteID AS set_gd_SiteID,gd_GoodsName AS set_gd_GoodsName,gd_BarCode AS set_gd_BarCode,gd_GoodsSize AS set_gd_GoodsSize,gd_TaxDiv AS set_gd_TaxDiv,gd_MakerCode AS set_gd_MakerCode,gd_BrandCode AS set_gd_BrandCode,gd_BoxGoodsCode AS set_gd_BoxGoodsCode,gd_BoxPackQty AS set_gd_BoxPackQty,gd_Deposit AS set_gd_Deposit,gd_SalesUnit AS set_gd_SalesUnit,gd_MinOrderUnit AS set_gd_MinOrderUnit,gd_StockUnit AS set_gd_StockUnit,gd_StockConvQty AS set_gd_StockConvQty,gd_PackUnit AS set_gd_PackUnit,gd_AbcValue AS set_gd_AbcValue,gd_StorageDiv AS set_gd_StorageDiv,gd_EachDeliveryYn AS set_gd_EachDeliveryYn,gd_VolumeTotal AS set_gd_VolumeTotal,gd_VolumeUnit AS set_gd_VolumeUnit,gd_AddedProperty AS set_gd_AddedProperty,gd_Memo AS set_gd_Memo,gd_UseYn AS set_gd_UseYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_SET_CODE ON gd_GoodsCode=setc_GoodsCode");
        if (num2 > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdp_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add((object) "gd_MakerCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add((object) "gd_MakerCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add((object) "gd_BrandCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add((object) "gd_BrandCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_PackUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_AbcValue"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_UseYn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num1);
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SET_HISTORY AS ( SELECT gdh_StoreCode AS seth_gdh_StoreCode,gdh_GoodsCode AS seth_gdh_GoodsCode,gdh_StartDate AS seth_gdh_StartDate,gdh_SiteID AS seth_gdh_SiteID,gdh_EndDate AS seth_gdh_EndDate,gdh_GoodsCategory AS seth_gdh_GoodsCategory,gdh_Supplier AS seth_gdh_Supplier,gdh_ChargeRate AS seth_gdh_ChargeRate,gdh_BuyCost AS seth_gdh_BuyCost,gdh_BuyVat AS seth_gdh_BuyVat,gdh_SalePrice AS seth_gdh_SalePrice,gdh_EventCost AS seth_gdh_EventCost,gdh_EventVat AS seth_gdh_EventVat,gdh_EventPrice AS seth_gdh_EventPrice,gdh_MemberPrice1 AS seth_gdh_MemberPrice1,gdh_MemberPrice2 AS seth_gdh_MemberPrice2,gdh_MemberPrice3 AS seth_gdh_MemberPrice3,gdh_PointRate AS seth_gdh_PointRate,dpt_lv1_ID AS seth_dpt_lv1_ID,dpt_lv1_ViewCode AS seth_dpt_lv1_ViewCode,dpt_lv1_Name AS seth_dpt_lv1_Name,dpt_lv2_ID AS seth_dpt_lv2_ID,dpt_lv2_ViewCode AS seth_dpt_lv2_ViewCode,dpt_lv2_Name AS seth_dpt_lv2_Name,dept_code AS seth_dept_code,dept_code AS seth_dpt_lv3_ID,dpt_lv3_ViewCode AS seth_dpt_lv3_ViewCode,dpt_lv3_Name AS seth_dpt_lv3_Name,ctg_lv1_ID AS seth_ctg_lv1_ID,ctg_lv1_ViewCode AS seth_ctg_lv1_ViewCode,ctg_lv1_Name AS seth_ctg_lv1_Name,ctg_lv2_ID AS seth_ctg_lv2_ID,ctg_lv2_ViewCode AS seth_ctg_lv2_ViewCode,ctg_lv2_Name AS seth_ctg_lv2_Name,ctg_code AS seth_ctg_code,ctg_code AS seth_ctg_lv3_ID,ctg_lv3_ViewCode AS seth_ctg_lv3_ViewCode,ctg_lv3_Name AS seth_ctg_lv3_Name,su_SupplierName AS seth_su_SupplierName,su_SupplierType AS seth_su_SupplierType,su_SupplierKind AS seth_su_SupplierKind,su_SupplierViewCode AS seth_su_SupplierViewCode" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_SET_INFO ON gdh_GoodsCode=set_gd_GoodsCode\n AND gdh_SiteID=set_gd_SiteID\n LEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND gdh_SiteID=su_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdp_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "gdh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add((object) "gdh_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_GoodsHistoryDiv_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) num1);
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdh_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EA_INFO AS (SELECT gd_GoodsCode AS ea_gd_GoodsCode,gd_SiteID AS ea_gd_SiteID,gd_GoodsName AS ea_gd_GoodsName,gd_BarCode AS ea_gd_BarCode,gd_GoodsSize AS ea_gd_GoodsSize,gd_TaxDiv AS ea_gd_TaxDiv,gd_MakerCode AS ea_gd_MakerCode,gd_BrandCode AS ea_gd_BrandCode,gd_BoxGoodsCode AS ea_gd_BoxGoodsCode,gd_BoxPackQty AS ea_gd_BoxPackQty,gd_Deposit AS ea_gd_Deposit,gd_SalesUnit AS ea_gd_SalesUnit,gd_MinOrderUnit AS ea_gd_MinOrderUnit,gd_StockUnit AS ea_gd_StockUnit,gd_StockConvQty AS ea_gd_StockConvQty,gd_PackUnit AS ea_gd_PackUnit,gd_AbcValue AS ea_gd_AbcValue,gd_StorageDiv AS ea_gd_StorageDiv,gd_EachDeliveryYn AS ea_gd_EachDeliveryYn,gd_VolumeTotal AS ea_gd_VolumeTotal,gd_VolumeUnit AS ea_gd_VolumeUnit,gd_AddedProperty AS ea_gd_AddedProperty,gd_Memo AS ea_gd_Memo,gd_UseYn AS ea_gd_UseYn" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_EA_CODE ON gd_GoodsCode=eac_GoodsCode");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add((object) "gd_MakerCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add((object) "gd_MakerCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add((object) "gd_BrandCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add((object) "gd_BrandCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_PackUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_AbcValue"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_UseYn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num1);
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EA_HISTORY AS ( SELECT gdh_StoreCode AS eah_gdh_StoreCode,gdh_GoodsCode AS eah_gdh_GoodsCode,gdh_StartDate AS eah_gdh_StartDate,gdh_SiteID AS eah_gdh_SiteID,gdh_EndDate AS eah_gdh_EndDate,gdh_GoodsCategory AS eah_gdh_GoodsCategory,gdh_Supplier AS eah_gdh_Supplier,gdh_ChargeRate AS eah_gdh_ChargeRate,gdh_BuyCost AS eah_gdh_BuyCost,gdh_BuyVat AS eah_gdh_BuyVat,gdh_SalePrice AS eah_gdh_SalePrice,gdh_EventCost AS eah_gdh_EventCost,gdh_EventVat AS eah_gdh_EventVat,gdh_EventPrice AS eah_gdh_EventPrice,gdh_MemberPrice1 AS eah_gdh_MemberPrice1,gdh_MemberPrice2 AS eah_gdh_MemberPrice2,gdh_MemberPrice3 AS eah_gdh_MemberPrice3,gdh_PointRate AS eah_gdh_PointRate,dpt_lv1_ID AS eah_dpt_lv1_ID,dpt_lv1_ViewCode AS eah_dpt_lv1_ViewCode,dpt_lv1_Name AS eah_dpt_lv1_Name,dpt_lv2_ID AS eah_dpt_lv2_ID,dpt_lv2_ViewCode AS eah_dpt_lv2_ViewCode,dpt_lv2_Name AS eah_dpt_lv2_Name,dept_code AS eah_dept_code,dept_code AS eah_dpt_lv3_ID,dpt_lv3_ViewCode AS eah_dpt_lv3_ViewCode,dpt_lv3_Name AS eah_dpt_lv3_Name,ctg_lv1_ID AS eah_ctg_lv1_ID,ctg_lv1_ViewCode AS eah_ctg_lv1_ViewCode,ctg_lv1_Name AS eah_ctg_lv1_Name,ctg_lv2_ID AS eah_ctg_lv2_ID,ctg_lv2_ViewCode AS eah_ctg_lv2_ViewCode,ctg_lv2_Name AS eah_ctg_lv2_Name,ctg_code AS eah_ctg_code,ctg_code AS eah_ctg_lv3_ID,ctg_lv3_ViewCode AS eah_ctg_lv3_ViewCode,ctg_lv3_Name AS eah_ctg_lv3_Name,su_SupplierName AS eah_su_SupplierName,su_SupplierType AS eah_su_SupplierType,su_SupplierKind AS eah_su_SupplierKind,su_SupplierViewCode AS eah_su_SupplierViewCode" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_EA_INFO ON gdh_GoodsCode=ea_gd_GoodsCode\n AND gdh_SiteID=ea_gd_SiteID\n LEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND gdh_SiteID=su_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gdp_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "gdh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add((object) "gdh_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_GoodsHistoryDiv_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) num1);
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdh_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gdp_GoodsCode,gdp_SubGoodsCode,gdp_SiteID,gdp_StockConvQty,gdp_InDate,gdp_InUser,gdp_ModDate,gdp_ModUser\n,set_gd_GoodsName,set_gd_BarCode,set_gd_GoodsSize,set_gd_TaxDiv,set_gd_MakerCode,set_gd_BrandCode,set_gd_Deposit,set_gd_SalesUnit,set_gd_MinOrderUnit,set_gd_StockUnit,set_gd_StockConvQty,set_gd_PackUnit,set_gd_AbcValue,set_gd_StorageDiv,set_gd_EachDeliveryYn,set_gd_VolumeTotal,set_gd_VolumeUnit,set_gd_AddedProperty,set_gd_UseYn\n,seth_gdh_StoreCode,seth_gdh_StartDate,seth_gdh_EndDate,seth_gdh_GoodsCategory,seth_gdh_Supplier,seth_gdh_ChargeRate,seth_gdh_BuyCost,seth_gdh_BuyVat,seth_gdh_SalePrice,seth_gdh_EventCost,seth_gdh_EventVat,seth_gdh_EventPrice,seth_gdh_MemberPrice1,seth_gdh_MemberPrice2,seth_gdh_MemberPrice3,seth_gdh_PointRate\n,seth_dpt_lv1_ID,seth_dpt_lv1_ViewCode,seth_dpt_lv1_Name,seth_dpt_lv2_ID,seth_dpt_lv2_ViewCode,seth_dpt_lv2_Name,seth_dpt_lv3_ID,seth_dpt_lv3_ViewCode,seth_dpt_lv3_Name\n,seth_ctg_lv1_ID,seth_ctg_lv1_ViewCode,seth_ctg_lv1_Name,seth_ctg_lv2_ID,seth_ctg_lv2_ViewCode,seth_ctg_lv2_Name,seth_ctg_lv3_ID,seth_ctg_lv3_ViewCode,seth_ctg_lv3_Name\n,seth_su_SupplierName,seth_su_SupplierType,seth_su_SupplierViewCode\n,ea_gd_GoodsName,ea_gd_BarCode,ea_gd_GoodsSize,ea_gd_TaxDiv,ea_gd_MakerCode,ea_gd_BrandCode,ea_gd_Deposit,ea_gd_SalesUnit,ea_gd_MinOrderUnit,ea_gd_StockUnit,ea_gd_StockConvQty,ea_gd_PackUnit,ea_gd_AbcValue,ea_gd_StorageDiv,ea_gd_EachDeliveryYn,ea_gd_VolumeTotal,ea_gd_VolumeUnit,ea_gd_AddedProperty,ea_gd_UseYn\n,eah_gdh_StoreCode,eah_gdh_StartDate,eah_gdh_EndDate,eah_gdh_GoodsCategory,eah_gdh_Supplier,eah_gdh_ChargeRate,eah_gdh_BuyCost,eah_gdh_BuyVat,eah_gdh_SalePrice,eah_gdh_EventCost,eah_gdh_EventVat,eah_gdh_EventPrice,eah_gdh_MemberPrice1,eah_gdh_MemberPrice2,eah_gdh_MemberPrice3,eah_gdh_PointRate\n,eah_dpt_lv1_ID,eah_dpt_lv1_ViewCode,eah_dpt_lv1_Name,eah_dpt_lv2_ID,eah_dpt_lv2_ViewCode,eah_dpt_lv2_Name,eah_dpt_lv3_ID,eah_dpt_lv3_ViewCode,eah_dpt_lv3_Name\n,eah_ctg_lv1_ID,eah_ctg_lv1_ViewCode,eah_ctg_lv1_Name,eah_ctg_lv2_ID,eah_ctg_lv2_ViewCode,eah_ctg_lv2_Name,eah_ctg_lv3_ID,eah_ctg_lv3_ViewCode,eah_ctg_lv3_Name\n,eah_su_SupplierName,eah_su_SupplierType,eah_su_SupplierViewCode\n,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_SET_INFO ON gdp_GoodsCode=T_SET_INFO.set_gd_GoodsCode AND gdp_SiteID=set_gd_SiteID\n INNER JOIN T_SET_HISTORY ON gdp_GoodsCode=seth_gdh_GoodsCode AND gdp_SiteID=seth_gdh_SiteID\n INNER JOIN T_STORE ON seth_gdh_StoreCode=si_StoreCode\n INNER JOIN T_EA_INFO ON gdp_SubGoodsCode=T_EA_INFO.ea_gd_GoodsCode AND gdp_SiteID=ea_gd_SiteID\n INNER JOIN T_EA_HISTORY ON seth_gdh_StoreCode=eah_gdh_StoreCode AND gdp_SubGoodsCode=eah_gdh_GoodsCode AND gdp_SiteID=eah_gdh_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON gdp_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON gdp_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gdp_GoodsCode,gdp_SubGoodsCode");
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
