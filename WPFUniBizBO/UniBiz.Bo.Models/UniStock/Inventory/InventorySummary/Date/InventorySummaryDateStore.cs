// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.Date.InventorySummaryDateStore
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
  public class InventorySummaryDateStore : InventorySummaryDate<InventorySummaryDateStore>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;

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
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventorySummaryDateStore();

    public override object Clone()
    {
      InventorySummaryDateStore summaryDateStore = base.Clone() as InventorySummaryDateStore;
      summaryDateStore.si_StoreName = this.si_StoreName;
      summaryDateStore.si_StoreViewCode = this.si_StoreViewCode;
      summaryDateStore.si_UseYn = this.si_UseYn;
      summaryDateStore.si_StoreType = this.si_StoreType;
      return (object) summaryDateStore;
    }

    public void PutData(InventorySummaryDateStore pSource)
    {
      this.PutData((InventorySummaryDate) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
    }

    public bool CalcAddSum(InventorySummaryDateStore pSource) => pSource != null && this.CalcAddSum((TInventorySummary) pSource);

    public bool IsZero(EnumZeroCheck pCheckType, InventorySummaryDateStore pSource) => pSource == null || this.IsZero(pCheckType, (TInventorySummary) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<InventorySummaryDateStore>> SelectDateStoreListAsync(object p_param)
    {
      InventorySummaryDateStore summaryDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryDateStore1.GetSelectQuery(p_param)))
        {
          summaryDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventorySummaryDateStore>) null;
        }
        IList<InventorySummaryDateStore> lt_list = (IList<InventorySummaryDateStore>) new List<InventorySummaryDateStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventorySummaryDateStore summaryDateStore2 = summaryDateStore1.OleDB.Create<InventorySummaryDateStore>();
            if (summaryDateStore2.GetFieldValues(rs))
            {
              summaryDateStore2.row_number = lt_list.Count + 1;
              lt_list.Add(summaryDateStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventorySummaryDateStore> SelectDateStoreEnumerableAsync(
      object p_param)
    {
      InventorySummaryDateStore summaryDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryDateStore1.GetSelectQuery(p_param)))
        {
          summaryDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            InventorySummaryDateStore summaryDateStore2 = summaryDateStore1.OleDB.Create<InventorySummaryDateStore>();
            if (summaryDateStore2.GetFieldValues(rs))
            {
              summaryDateStore2.row_number = ++row_number;
              yield return summaryDateStore2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append("\n,TBodyStartTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" pls_StoreCode AS ivts_StoreCode");
        stringBuilder.Append(",pls_SiteID AS ivts_SiteID");
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
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\n,TBodyMiddleTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" pls_StoreCode AS ivts_StoreCode");
        stringBuilder.Append(",pls_SiteID AS ivts_SiteID");
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
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\n,TBodyEndTable AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS ivts_StoreCode");
        else
          stringBuilder.Append(" ivts_StoreCode");
        stringBuilder.Append(",ivts_SiteID");
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
        stringBuilder.Append(" ) ");
        stringBuilder.Append("\nSELECT 0 AS ivts_YyyyMm,0 AS ivts_Day,ivts_StoreCode,0 AS ivts_GoodsCode" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "ivts_SiteID") + ",0 AS ivts_Supplier,0 AS ivts_SupplierType,0 AS ivts_CategoryCode,0 AS ivts_TaxDiv,0 AS ivts_StockUnit,0 AS ivts_SalesUnit");
        stringBuilder.Append(TInventorySummary.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(TInventorySummary.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyMiddleTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT ivts_StoreCode");
        stringBuilder.Append(TInventorySummary.MainCol);
        stringBuilder.Append("\nFROM TBodyEndTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY ivts_StoreCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON ivts_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreViewCode,ivts_StoreCode");
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
