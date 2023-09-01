// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.Date.InventorySummaryDateCategoryBot
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
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.Date
{
  public class InventorySummaryDateCategoryBot : 
    InventorySummaryDateCategoryMid<InventorySummaryDateCategoryBot>
  {
    private string _ctg_ViewCode;
    private string _ctg_CategoryName;

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = value;
        this.Changed(nameof (ctg_ViewCode));
        this.Changed("ctg_lv3_ViewCode");
      }
    }

    public string ctg_lv3_ViewCode => this.ctg_ViewCode;

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = value;
        this.Changed(nameof (ctg_CategoryName));
        this.Changed("ctg_lv3_Name");
      }
    }

    public string ctg_lv3_Name => this.ctg_CategoryName;

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.ctg_ViewCode = string.Empty;
      this.ctg_CategoryName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventorySummaryDateCategoryBot();

    public override object Clone()
    {
      InventorySummaryDateCategoryBot summaryDateCategoryBot = base.Clone() as InventorySummaryDateCategoryBot;
      summaryDateCategoryBot.ctg_ViewCode = this.ctg_ViewCode;
      summaryDateCategoryBot.ctg_CategoryName = this.ctg_CategoryName;
      return (object) summaryDateCategoryBot;
    }

    public void PutData(InventorySummaryDateCategoryBot pSource)
    {
      this.PutData((InventorySummaryDateCategoryMid) pSource);
      this.ctg_ViewCode = pSource.ctg_ViewCode;
      this.ctg_CategoryName = pSource.ctg_CategoryName;
    }

    public bool IsZero(EnumZeroCheck pCheckType, InventorySummaryDateCategoryBot pSource) => pSource == null || this.IsZero(pCheckType, (InventorySummaryDateCategoryMid) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<InventorySummaryDateCategoryBot>> SelectDateCategoryBotListAsync(
      object p_param)
    {
      InventorySummaryDateCategoryBot summaryDateCategoryBot1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryDateCategoryBot1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryDateCategoryBot1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryDateCategoryBot1.GetSelectQuery(p_param)))
        {
          summaryDateCategoryBot1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventorySummaryDateCategoryBot>) null;
        }
        IList<InventorySummaryDateCategoryBot> lt_list = (IList<InventorySummaryDateCategoryBot>) new List<InventorySummaryDateCategoryBot>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventorySummaryDateCategoryBot summaryDateCategoryBot2 = summaryDateCategoryBot1.OleDB.Create<InventorySummaryDateCategoryBot>();
            if (summaryDateCategoryBot2.GetFieldValues(rs))
            {
              summaryDateCategoryBot2.row_number = lt_list.Count + 1;
              lt_list.Add(summaryDateCategoryBot2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventorySummaryDateCategoryBot> SelectDateCategoryBotEnumerableAsync(
      object p_param)
    {
      InventorySummaryDateCategoryBot summaryDateCategoryBot1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryDateCategoryBot1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryDateCategoryBot1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryDateCategoryBot1.GetSelectQuery(p_param)))
        {
          summaryDateCategoryBot1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateCategoryBot1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            InventorySummaryDateCategoryBot summaryDateCategoryBot2 = summaryDateCategoryBot1.OleDB.Create<InventorySummaryDateCategoryBot>();
            if (summaryDateCategoryBot2.GetFieldValues(rs))
            {
              summaryDateCategoryBot2.row_number = ++row_number;
              yield return summaryDateCategoryBot2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_ViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_CategoryName", hashtable[(object) "_KEY_WORD_"]));
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
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        DateTime? p_day = new DateTime?();
        TProfitLossSummary tprofitLossSummary = new TProfitLossSummary();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ivts_SiteID") && Convert.ToInt64(hashtable[(object) "ivts_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "ivts_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_DT_END_DATE_"))
            p_day = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]);
        }
        if (!p_day.HasValue)
          throw new Exception("종료일자 정보 조건 부족.");
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(this.ToWithDeptLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,TBodyStartTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" pls_StoreCode AS ivts_StoreCode");
        stringBuilder.Append(",pls_SiteID AS ivts_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(InventorySummaryDate.TProfitLossSummaryStartSumCol);
        string str = "pls_YyyyMm".ToStr(6).ToStrAdd("'01'").DateAdd(1, EnumDbAddType.MONTH).DateAdd(-1, EnumDbAddType.DAY);
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + str + " AND gdh_EndDate>=" + str + " AND pls_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\nINNER JOIN T_BOOKMARK_GOODS ON pls_GoodsCode=bgl_GoodsCode AND pls_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionProfitLossSummaryStart((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(tprofitLossSummary.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) 0));
        else
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY ");
        if (!p_isStoreTotal)
          stringBuilder.Append("pls_StoreCode,");
        stringBuilder.Append("pls_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\n,TBodyMiddleTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" pls_StoreCode AS ivts_StoreCode");
        stringBuilder.Append(",pls_SiteID AS ivts_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(InventorySummaryDate.TProfitLossSummaryMiddleSumCol);
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + str + " AND gdh_EndDate>=" + str + " AND pls_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\nINNER JOIN T_BOOKMARK_GOODS ON pls_GoodsCode=bgl_GoodsCode AND pls_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionProfitLossSummaryMiddle((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(tprofitLossSummary.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) 0));
        else
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "pls_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY ");
        if (!p_isStoreTotal)
          stringBuilder.Append("pls_StoreCode,");
        stringBuilder.Append("pls_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\n,TBodyEndTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" ivts_StoreCode");
        stringBuilder.Append(",ivts_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(InventorySummaryDate.TInventorySummaryEndSumCol);
        string dateToStr = p_day.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");
        stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.InventorySummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON ivts_StoreCode=gdh_StoreCode AND ivts_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + dateToStr + " AND gdh_EndDate>=" + dateToStr + " AND ivts_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\nINNER JOIN T_BOOKMARK_GOODS ON ivts_GoodsCode=bgl_GoodsCode AND ivts_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionInventorySummary((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "ivts_SiteID"))
            p_param1.Add((object) "ivts_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TInventorySummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "ivts_SiteID", (object) 0));
        else
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "ivts_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY ");
        if (!p_isStoreTotal)
          stringBuilder.Append("ivts_StoreCode,");
        stringBuilder.Append("ivts_SiteID");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\nSELECT 0 AS ivts_YyyyMm,0 AS ivts_Day,ivts_StoreCode,0 AS ivts_GoodsCode" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "ivts_SiteID") + ",0 AS ivts_Supplier,0 AS ivts_SupplierType,ctg_code AS ivts_CategoryCode,0 AS ivts_TaxDiv,0 AS ivts_StockUnit,0 AS ivts_SalesUnit");
        stringBuilder.Append(TInventorySummary.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name,dept_code AS dpt_ID,T_DEPT_LV3_NAME.dpt_ViewCode AS dpt_ViewCode,T_DEPT_LV3_NAME.dpt_DeptName AS dpt_DeptName,ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name,ctg_lv2_ID,T_CTG_LV_2_NAME.ctg_ViewCode AS ctg_lv2_ViewCode,T_CTG_LV_2_NAME.ctg_CategoryName AS ctg_lv2_Name,ctg_code,T_CTG_LV_3_NAME.ctg_ViewCode AS ctg_ViewCode,T_CTG_LV_3_NAME.ctg_CategoryName AS ctg_CategoryName");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(TInventorySummary.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyMiddleTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyEndTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY ivts_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON ivts_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV3_NAME ON dept_code=T_DEPT_LV3_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV3_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_2_NAME ON ctg_lv2_ID=T_CTG_LV_2_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_2_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_3_NAME ON ctg_code=T_CTG_LV_3_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_3_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append(" ORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append(" ORDER BY si_StoreViewCode,ivts_StoreCode");
          stringBuilder.Append(",T_DEPT_LV1_NAME.dpt_ViewCode,T_DEPT_LV2_NAME.dpt_ViewCode");
          stringBuilder.Append(",T_DEPT_LV3_NAME.dpt_ViewCode");
          stringBuilder.Append(",T_CTG_LV_1_NAME.ctg_ViewCode");
          stringBuilder.Append(",T_CTG_LV_2_NAME.ctg_ViewCode");
          stringBuilder.Append(",T_CTG_LV_3_NAME.ctg_ViewCode");
        }
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
