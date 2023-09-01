// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier.SalesByMonthHorizontalBySupplierCategoryMid
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier
{
  public class SalesByMonthHorizontalBySupplierCategoryMid : 
    SalesByMonthHorizontalBySupplierCategoryTop<SalesByMonthHorizontalBySupplierCategoryMid>
  {
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;

    public override string KeyCode => string.Format("{0}|{1}|{2}|{3}", (object) this.si_StoreCode, (object) this.sbd_Supplier, (object) this.ctg_lv1_ID, (object) this.ctg_lv2_ID);

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
        this.Changed("KeyCode");
      }
    }

    public string ctg_lv2_ViewCode
    {
      get => this._ctg_lv2_ViewCode;
      set
      {
        this._ctg_lv2_ViewCode = value;
        this.Changed(nameof (ctg_lv2_ViewCode));
      }
    }

    public string ctg_lv2_Name
    {
      get => this._ctg_lv2_Name;
      set
      {
        this._ctg_lv2_Name = value;
        this.Changed(nameof (ctg_lv2_Name));
      }
    }

    public override string ToString() => string.Format("{0} [{1}({2})][{3}>{4}] Count : {5}", (object) nameof (SalesByMonthHorizontalBySupplierCategoryMid), (object) this.su_SupplierName, (object) this.sbd_Supplier, (object) this.ctg_lv1_Name, (object) this.ctg_lv2_Name, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = string.Empty;
      this.ctg_lv2_Name = string.Empty;
    }

    public void PutInfo(
      SalesByMonthHorizontalBySupplierCategoryMid pSource)
    {
      this.PutInfo((SalesByMonthHorizontalBySupplierCategoryTop) pSource);
      this.ctg_lv2_ID = pSource.ctg_lv2_ID;
      this.ctg_lv2_ViewCode = pSource.ctg_lv2_ViewCode;
      this.ctg_lv2_Name = pSource.ctg_lv2_Name;
    }

    public void InitInfo(SalesByMonthHorizontalBySupplierCategoryMid pData, IList<DateTime> p_Days)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_StoreCode|sbd_Supplier|ctg_lv1_ID|ctg_lv2_ID] 이 KeyCode 와 다릅니다");
      this.PutInfo(pData);
      foreach (DateTime pDay in (IEnumerable<DateTime>) p_Days)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByMonthGoal salesByMonthGoal = new SalesByMonthGoal();
        salesByMonthGoal.sbd_SaleDate = new DateTime?(pDay);
        salesByMonthGoal.sbd_StoreCode = this.si_StoreCode;
        salesByMonthGoal.sbd_Supplier = this.sbd_Supplier;
        ltDetails.Add((SalesByDayGoal) salesByMonthGoal);
      }
    }

    public void Add(SalesByMonthHorizontalBySupplierCategoryMid item)
    {
      if (this.si_StoreCode == 0)
      {
        this.si_StoreCode = item.sbd_StoreCode;
        this.sbd_Supplier = item.sbd_Supplier;
        this.ctg_lv1_ID = item.ctg_lv1_ID;
        this.ctg_lv2_ID = item.ctg_lv2_ID;
      }
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 [sbd_StoreCode|sbd_Supplier|ctg_lv1_ID|ctg_lv2_ID] 이 KeyCode 와 다릅니다");
      this.CalcAddSum((SalesByMonthGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_SaleDate.Equals((object) item.sbd_SaleDate)));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(
      IList<SalesByMonthHorizontalBySupplierCategoryMid> infos)
    {
      foreach (SalesByMonthHorizontalBySupplierCategoryMid info in (IEnumerable<SalesByMonthHorizontalBySupplierCategoryMid>) infos)
        this.Add(info);
    }

    public bool IsZero(
      EnumZeroCheck pCheckType,
      SalesByMonthHorizontalBySupplierCategoryMid pSource)
    {
      return pSource == null || this.IsZero(pCheckType, (SalesByMonthHorizontalBySupplierCategoryTop) pSource);
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
        this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
        this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SalesByMonthHorizontalBySupplierCategoryMid>> SelectMonthHorizontalBySupplierCategoryMidListAsync(
      object p_param)
    {
      SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(supplierCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, supplierCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(supplierCategoryMid1.GetSelectQuery(p_param)))
        {
          supplierCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByMonthHorizontalBySupplierCategoryMid>) null;
        }
        IList<SalesByMonthHorizontalBySupplierCategoryMid> lt_list = (IList<SalesByMonthHorizontalBySupplierCategoryMid>) new List<SalesByMonthHorizontalBySupplierCategoryMid>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid2 = supplierCategoryMid1.OleDB.Create<SalesByMonthHorizontalBySupplierCategoryMid>();
            if (supplierCategoryMid2.GetFieldValues(rs))
            {
              supplierCategoryMid2.row_number = lt_list.Count + 1;
              lt_list.Add(supplierCategoryMid2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByMonthHorizontalBySupplierCategoryMid> SelectMonthHorizontalBySupplierCategoryMidEnumerableAsync(
      object p_param)
    {
      SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(supplierCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, supplierCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(supplierCategoryMid1.GetSelectQuery(p_param)))
        {
          supplierCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByMonthHorizontalBySupplierCategoryMid supplierCategoryMid2 = supplierCategoryMid1.OleDB.Create<SalesByMonthHorizontalBySupplierCategoryMid>();
            if (supplierCategoryMid2.GetFieldValues(rs))
            {
              supplierCategoryMid2.row_number = ++row_number;
              yield return supplierCategoryMid2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv2_Name", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv2_ViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        SaleByDayDateStore saleByDayDateStore = new SaleByDayDateStore();
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sbd_SiteID") && Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_IsGoalSelect_") && Convert.ToBoolean(hashtable[(object) "_IsGoalSelect_"].ToString()))
            Convert.ToBoolean(hashtable[(object) "_IsGoalSelect_"].ToString());
        }
        stringBuilder.Append(saleByDayDateStore.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(saleByDayDateStore.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(saleByDayDateStore.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(saleByDayDateStore.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(saleByDayDateStore.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(saleByDayDateStore.ToWithCategoryLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_BASE AS (SELECT");
        stringBuilder.Append(" " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM) + " AS sbd_SaleMonth");
        stringBuilder.Append(",");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(",gdh_Supplier AS sbd_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(SaleByDayDateStore.BaseColMaker);
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = saleByDayDateStore.SearchConditionDefault((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n,sbd_StoreCode");
        stringBuilder.Append(",gdh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECTNULL AS sbd_SaleDate,sbd_SaleMonth,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,sbd_Supplier,su_SupplierType AS sbd_SupplierType,0 AS sbd_CategoryCode,0 AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SaleByDayDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,su_SupplierName,su_SupplierViewCode,su_UseYn,su_HeadSupplier,su_SupplierType,su_SupplierKind");
        stringBuilder.Append(",ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name,ctg_lv2_ID,T_CTG_LV_2_NAME.ctg_ViewCode AS ctg_lv2_ViewCode,T_CTG_LV_2_NAME.ctg_CategoryName AS ctg_lv2_Name");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(SaleByDayDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(SaleByDayDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\nINNER JOIN T_SUPPLIER ON sbd_Supplier=su_Supplier" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_2_NAME ON ctg_lv2_ID=T_CTG_LV_2_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_2_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
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
      Log.Logger.DebugColor(" 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + string.Format("\n LINE : {0} 행", (object) new StackFrame(0, true).GetFileLineNumber()) + "\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------\n" + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------");
      return stringBuilder.ToString();
    }
  }
}
