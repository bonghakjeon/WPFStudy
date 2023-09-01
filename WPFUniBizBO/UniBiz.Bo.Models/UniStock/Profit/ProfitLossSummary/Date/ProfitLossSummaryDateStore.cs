﻿// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date.ProfitLossSummaryDateStore
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
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date
{
  public class ProfitLossSummaryDateStore : ProfitLossSummaryDate<ProfitLossSummaryDateStore>
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

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryDateStore();

    public override object Clone()
    {
      ProfitLossSummaryDateStore summaryDateStore = base.Clone() as ProfitLossSummaryDateStore;
      summaryDateStore.si_StoreName = this.si_StoreName;
      summaryDateStore.si_StoreViewCode = this.si_StoreViewCode;
      summaryDateStore.si_UseYn = this.si_UseYn;
      summaryDateStore.si_StoreType = this.si_StoreType;
      return (object) summaryDateStore;
    }

    public void PutData(ProfitLossSummaryDateStore pSource)
    {
      this.PutData((ProfitLossSummaryDate) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
    }

    public bool CalcAddSum(ProfitLossSummaryDateStore pSource) => pSource != null && this.CalcAddSum((ProfitLossSummaryDate) pSource);

    public bool IsZero(EnumZeroCheck pCheckType, ProfitLossSummaryDateStore pSource) => pSource == null || this.IsZero(pCheckType, (ProfitLossSummaryDate) pSource);

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

    public async Task<IList<ProfitLossSummaryDateStore>> SelectDateStoreListAsync(object p_param)
    {
      ProfitLossSummaryDateStore summaryDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryDateStore1.GetSelectQuery(p_param)))
        {
          summaryDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryDateStore>) null;
        }
        IList<ProfitLossSummaryDateStore> lt_list = (IList<ProfitLossSummaryDateStore>) new List<ProfitLossSummaryDateStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryDateStore summaryDateStore2 = summaryDateStore1.OleDB.Create<ProfitLossSummaryDateStore>();
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

    public async IAsyncEnumerable<ProfitLossSummaryDateStore> SelectDateStoreEnumerableAsync(
      object p_param)
    {
      ProfitLossSummaryDateStore summaryDateStore1 = this;
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
            ProfitLossSummaryDateStore summaryDateStore2 = summaryDateStore1.OleDB.Create<ProfitLossSummaryDateStore>();
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
      StringBuilder stringBuilder1 = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        DateTime? nullable = new DateTime?();
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        TProfitLossSummary tprofitLossSummary = new TProfitLossSummary();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "pls_SiteID") && Convert.ToInt64(hashtable[(object) "pls_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "pls_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_DT_END_DATE_"))
            nullable = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]);
          if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          {
            switch (Enum2StrConverter.ToSupplierType(Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString())))
            {
              case EnumSupplierType.DIRECT:
                flag1 = true;
                break;
              case EnumSupplierType.SPE:
                flag2 = true;
                break;
              case EnumSupplierType.LEA:
                flag3 = true;
                break;
            }
          }
          else if (hashtable.ContainsKey((object) "su_SupplierType_IN_") && hashtable[(object) "su_SupplierType_IN_"].ToString().Length > 0)
          {
            string str = hashtable[(object) "su_SupplierType_IN_"].ToString();
            if (str.Contains(1.ToString()))
              flag1 = true;
            int num = 2;
            if (str.Contains(num.ToString()))
              flag2 = true;
            num = 3;
            if (str.Contains(num.ToString()))
              flag3 = true;
          }
        }
        if (!nullable.HasValue)
          throw new Exception("종료일자 정보 조건 부족.");
        if (!flag1 && !flag2 && !flag3)
        {
          flag1 = true;
          flag2 = true;
          flag3 = true;
        }
        DateTime lastDateOfMonth = nullable.Value.ToLastDateOfMonth();
        bool p_IsLastDay = nullable.Value.Day == lastDateOfMonth.Day;
        stringBuilder1.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder1.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder1.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder1.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder1.Append(this.ToWithWorkEndGoodsPriceQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID));
        string str1 = "pls_YyyyMm".ToStr(6).ToStrAdd("'01'").DateAdd(1, EnumDbAddType.MONTH).DateAdd(-1, EnumDbAddType.DAY);
        if (flag1)
        {
          stringBuilder1.Append("\n,TBodyStartTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 AS");
          stringBuilder1.Append(" pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(this.GetProfitLossSummaryStartSumCol(p_IsLastDay));
          stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_StoreCode=pls_StoreCode AND si_SiteID=pls_SiteID\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + str1 + " AND gdh_EndDate>=" + str1 + " AND pls_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON pls_GoodsCode=bgl_GoodsCode AND pls_SiteID=bgl_SiteID");
          if (!p_IsLastDay)
            stringBuilder1.Append("\nLEFT OUTER JOIN TBodyEndGoodsPriceTable ON pls_StoreCode=end_pls_StoreCode AND pls_GoodsCode=end_pls_GoodsCode AND pls_SiteID=end_pls_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionProfitLossSummaryStart((Hashtable) p_param);
          if (p_param1.Count <= 0)
            throw new Exception("기초TBodyStartTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(tprofitLossSummary.GetSelectWhereAnd((object) p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("pls_StoreCode,");
          stringBuilder1.Append("pls_SiteID");
          stringBuilder1.Append(" ) ");
          stringBuilder1.Append("\n,TBodyMiddleTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 AS");
          stringBuilder1.Append(" pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(this.GetProfitLossSummaryMiddleSumCol(p_IsLastDay));
          stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_StoreCode=pls_StoreCode AND si_SiteID=pls_SiteID\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + str1 + " AND gdh_EndDate>=" + str1 + " AND pls_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON pls_GoodsCode=bgl_GoodsCode AND pls_SiteID=bgl_SiteID");
          if (!p_IsLastDay)
            stringBuilder1.Append("\nLEFT OUTER JOIN TBodyEndGoodsPriceTable ON pls_StoreCode=end_pls_StoreCode AND pls_GoodsCode=end_pls_GoodsCode AND pls_SiteID=end_pls_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionProfitLossSummaryMiddle((Hashtable) p_param, p_IsLastDay);
          if (p_param1.Count <= 0)
            throw new Exception("기중TBodyMiddleTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(tprofitLossSummary.GetSelectWhereAnd((object) p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("pls_StoreCode,");
          stringBuilder1.Append("pls_SiteID");
          stringBuilder1.Append(" ) ");
          if (!p_IsLastDay)
          {
            stringBuilder1.Append("\n,TBodySaleTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sbd_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sbd_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTSaleSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=sbd_SaleDate AND gdh_EndDate>=sbd_SaleDate AND sbd_SiteID=gdh_SiteID");
            if (p_bgg_GroupID > 0)
              stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
            stringBuilder1.Append("\nLEFT OUTER JOIN TBodyEndGoodsPriceTable ON sbd_StoreCode=end_pls_StoreCode AND sbd_GoodsCode=end_pls_GoodsCode AND sbd_SiteID=end_pls_SiteID");
            p_param1.Clear();
            p_param1 = this.SearchConditionDateSalesByDay((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("매출TBodySaleTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sbd_SupplierType"))
              p_param1.Add((object) "sbd_SupplierType", (object) 1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sbd_StoreCode,");
            stringBuilder1.Append("sbd_SiteID");
            stringBuilder1.Append(" ) ");
            StringBuilder stringBuilder2 = new StringBuilder();
            stringBuilder2.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID\nINNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=sh_ConfirmDate AND gdh_EndDate>=sh_ConfirmDate AND sh_SiteID=gdh_SiteID");
            if (p_bgg_GroupID > 0)
              stringBuilder2.Append("\nINNER JOIN T_BOOKMARK_GOODS ON sd_GoodsCode=bgl_GoodsCode AND sh_SiteID=bgl_SiteID");
            stringBuilder2.Append("\nLEFT OUTER JOIN TBodyEndGoodsPriceTable ON sh_StoreCode=end_pls_StoreCode AND sd_GoodsCode=end_pls_GoodsCode AND sh_SiteID=end_pls_SiteID");
            stringBuilder1.Append("\n,TBodyBuyTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTBuySumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("매입TBodyBuyTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) 1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyReturnTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTReturnSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("반품TBodyReturnTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) -1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyInnerMoveInTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTInnerMoveInSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("대입TBodyInnerMoveInTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 3);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) 1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyInnerMoveOutTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTInnerMoveOutSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("대출TBodyInnerMoveOutTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 3);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) -1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyOuterMoveInTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTOuterMoveInSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("점입TBodyOuterMoveInTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 4);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) 1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyOuterMoveOutTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTOuterMoveOutSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("점풀TBodyOuterMoveOutTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 4);
            if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
              p_param1.Add((object) "sh_InOutDiv", (object) -1);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyAdjustTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTAdjustSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("재고조정TBodyAdjustTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 5);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
            stringBuilder1.Append("\n,TBodyDisuseTable AS (SELECT");
            if (p_isStoreTotal)
              stringBuilder1.Append(" 1 ");
            else
              stringBuilder1.Append(" sh_StoreCode");
            stringBuilder1.Append(" AS pls_StoreCode");
            stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
            stringBuilder1.Append(this.GetTDisuseSumColSumCol(p_IsLastDay));
            stringBuilder1.Append(stringBuilder2.ToString());
            p_param1.Clear();
            p_param1 = this.SearchConditionDateStatement((Hashtable) p_param);
            if (p_param1.Count <= 0)
              throw new Exception("폐기TBodyDisuseTable QUERY 정보 조건 부족.");
            if (!p_param1.ContainsKey((object) "sh_SiteID"))
              p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
            if (!p_param1.ContainsKey((object) "sh_SupplierType"))
              p_param1.Add((object) "sh_SupplierType", (object) 1);
            if (!p_param1.ContainsKey((object) "sh_StatementType"))
              p_param1.Add((object) "sh_StatementType", (object) 6);
            stringBuilder1.Append("\n");
            stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
            stringBuilder1.Append("\nGROUP BY ");
            if (!p_isStoreTotal)
              stringBuilder1.Append("sh_StoreCode,");
            stringBuilder1.Append("sh_SiteID");
            stringBuilder1.Append(" ) ");
          }
          stringBuilder1.Append("\n,TBodyEndTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 AS ");
          stringBuilder1.Append(" pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(this.GetProfitLossSummaryOnlyEndSumCol(p_IsLastDay));
          stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_StoreCode=pls_StoreCode AND si_SiteID=pls_SiteID\nINNER JOIN T_HISTORY ON pls_StoreCode=gdh_StoreCode AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=" + str1 + " AND gdh_EndDate>=" + str1 + " AND pls_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON pls_GoodsCode=bgl_GoodsCode AND pls_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionProfitLossSummaryEnd((Hashtable) p_param);
          if (p_param1.Count <= 0)
            throw new Exception("기말TBodyEndTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(tprofitLossSummary.GetSelectWhereAnd((object) p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("pls_StoreCode,");
          stringBuilder1.Append("pls_SiteID");
          stringBuilder1.Append(" ) ");
        }
        if (flag2)
        {
          stringBuilder1.Append("\n,TBodySaleSpeTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 ");
          else
            stringBuilder1.Append(" sbd_StoreCode");
          stringBuilder1.Append(" AS pls_StoreCode");
          stringBuilder1.Append(",sbd_SiteID AS pls_SiteID");
          stringBuilder1.Append(this.GetTSaleSumColSumCol(true));
          stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=sbd_SaleDate AND gdh_EndDate>=sbd_SaleDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionDateSalesByDay((Hashtable) p_param, false);
          if (p_param1.Count <= 0)
            throw new Exception("매출TBodySaleTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sbd_SupplierType"))
            p_param1.Add((object) "sbd_SupplierType", (object) 2);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("sbd_StoreCode,");
          stringBuilder1.Append("sbd_SiteID");
          stringBuilder1.Append(" ) ");
          StringBuilder stringBuilder3 = new StringBuilder();
          stringBuilder3.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID\nINNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=sh_ConfirmDate AND gdh_EndDate>=sh_ConfirmDate AND sh_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder3.Append("\nINNER JOIN T_BOOKMARK_GOODS ON sd_GoodsCode=bgl_GoodsCode AND sh_SiteID=bgl_SiteID");
          stringBuilder1.Append("\n,TBodyBuySpeTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 ");
          else
            stringBuilder1.Append(" sh_StoreCode");
          stringBuilder1.Append(" AS pls_StoreCode");
          stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
          stringBuilder1.Append(this.GetTBuySumColSumCol(true));
          stringBuilder1.Append(stringBuilder3.ToString());
          p_param1.Clear();
          p_param1 = this.SearchConditionDateStatement((Hashtable) p_param, false);
          if (p_param1.Count <= 0)
            throw new Exception("매입TBodyBuyTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 2);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("sh_StoreCode,");
          stringBuilder1.Append("sh_SiteID");
          stringBuilder1.Append(" ) ");
          stringBuilder1.Append("\n,TBodyReturnSpeTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 ");
          else
            stringBuilder1.Append(" sh_StoreCode");
          stringBuilder1.Append(" AS pls_StoreCode");
          stringBuilder1.Append(",sh_SiteID AS pls_SiteID");
          stringBuilder1.Append(this.GetTReturnSumColSumCol(true));
          stringBuilder1.Append(stringBuilder3.ToString());
          p_param1.Clear();
          p_param1 = this.SearchConditionDateStatement((Hashtable) p_param, false);
          if (p_param1.Count <= 0)
            throw new Exception("반품TBodyReturnTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 2);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(this.ToStatementWhereAnd(p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("sh_StoreCode,");
          stringBuilder1.Append("sh_SiteID");
          stringBuilder1.Append(" ) ");
        }
        if (flag3)
        {
          stringBuilder1.Append("\n,TBodySaleLeaTable AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder1.Append(" 1 ");
          else
            stringBuilder1.Append(" sbd_StoreCode");
          stringBuilder1.Append(" AS pls_StoreCode");
          stringBuilder1.Append(",sbd_SiteID AS pls_SiteID");
          stringBuilder1.Append(this.GetTSaleLeaSumColSumCol(true));
          stringBuilder1.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=sbd_SaleDate AND gdh_EndDate>=sbd_SaleDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder1.Append("\nINNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionDateSalesByDay((Hashtable) p_param, false);
          if (p_param1.Count <= 0)
            throw new Exception("매출TBodySaleTable QUERY 정보 조건 부족.");
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sbd_SupplierType"))
            p_param1.Add((object) "sbd_SupplierType", (object) 3);
          stringBuilder1.Append("\n");
          stringBuilder1.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          stringBuilder1.Append("\nGROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder1.Append("sbd_StoreCode,");
          stringBuilder1.Append("sbd_SiteID");
          stringBuilder1.Append(" ) ");
        }
        stringBuilder1.Append("\n");
        stringBuilder1.Append("\nSELECT 0 AS pls_YyyyMm,pls_StoreCode,0 AS pls_GoodsCode,pls_SiteID" + string.Format(",{0} AS {1}", (object) 0, (object) "pls_Supplier") + ",0 AS pls_SupplierType" + string.Format(",{0} AS {1}", (object) 0, (object) "pls_CategoryCode") + string.Format(",{0} AS {1},{2} AS {3}", (object) 0, (object) "pls_TaxDiv", (object) 0, (object) "pls_StockUnit") + string.Format(",{0} AS {1}", (object) 0, (object) "pls_SalesUnit"));
        stringBuilder1.Append(TProfitLossSummary.MainCol);
        stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
        if (p_isStoreTotal)
          stringBuilder1.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder1.Append("\n,si_StoreName");
        stringBuilder1.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder1.Append("\nFROM (");
        stringBuilder1.Append("\nSELECT pls_StoreCode");
        stringBuilder1.Append(",pls_SiteID");
        stringBuilder1.Append(TProfitLossSummary.SubCol);
        stringBuilder1.Append(",SUM(pls_CalcQty) AS pls_CalcQty,SUM(pls_CalcCostAmt) AS pls_CalcCostAmt,SUM(pls_CalcCostVatAmt) AS pls_CalcCostVatAmt,SUM(pls_CalcPriceAmt) AS pls_CalcPriceAmt,SUM(pls_CalcPriceVatAmt) AS pls_CalcPriceVatAmt,SUM(pls_CalcPriceCostAmt) AS pls_CalcPriceCostAmt,SUM(pls_CalcPriceCostVatAmt) AS pls_CalcPriceCostVatAmt");
        stringBuilder1.Append("\nFROM (");
        if (flag1)
        {
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodyStartTable");
          stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodyMiddleTable");
          if (!p_IsLastDay)
          {
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodySaleTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyBuyTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyReturnTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyInnerMoveInTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyInnerMoveOutTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyOuterMoveInTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyOuterMoveOutTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyAdjustTable");
            stringBuilder1.Append("\nUNION ALL");
            stringBuilder1.Append("\nSELECT pls_StoreCode");
            stringBuilder1.Append(",pls_SiteID");
            stringBuilder1.Append(TProfitLossSummary.MainCol);
            stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
            stringBuilder1.Append("\nFROM TBodyDisuseTable");
          }
          stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodyEndTable");
        }
        if (flag2)
        {
          if (flag1)
            stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodySaleSpeTable");
          stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodyBuySpeTable");
          stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodyReturnSpeTable");
        }
        if (flag3)
        {
          if (flag1 | flag2)
            stringBuilder1.Append("\nUNION ALL");
          stringBuilder1.Append("\nSELECT pls_StoreCode");
          stringBuilder1.Append(",pls_SiteID");
          stringBuilder1.Append(TProfitLossSummary.MainCol);
          stringBuilder1.Append(",pls_CalcQty,pls_CalcCostAmt,pls_CalcCostVatAmt,pls_CalcPriceAmt,pls_CalcPriceVatAmt,pls_CalcPriceCostAmt,pls_CalcPriceCostVatAmt");
          stringBuilder1.Append("\nFROM TBodySaleLeaTable");
        }
        stringBuilder1.Append("\n) SUB");
        stringBuilder1.Append("\nGROUP BY pls_StoreCode");
        stringBuilder1.Append(",pls_SiteID");
        stringBuilder1.Append("\n) MAIN");
        stringBuilder1.Append("\nINNER JOIN T_STORE ON pls_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder1.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder1.Append(" ORDER BY " + empty);
        else
          stringBuilder1.Append(" ORDER BY si_StoreViewCode,pls_StoreCode");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder1) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder1.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder1.ToString();
    }
  }
}