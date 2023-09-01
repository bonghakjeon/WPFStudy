// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Day.ProfitLossSummaryDay
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBiz.Bo.Models.UniStock.Statement;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Day
{
  public class ProfitLossSummaryDay : TProfitLossSummary<ProfitLossSummaryDay>
  {
    private int _rowDataType;
    private DateTime? _pls_Date;

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == 3;

    public DateTime? pls_Date
    {
      get => this._pls_Date;
      set
      {
        this._pls_Date = value;
        this.Changed(nameof (pls_Date));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.pls_Date = new DateTime?();
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryDay();

    public override object Clone()
    {
      ProfitLossSummaryDay profitLossSummaryDay = base.Clone() as ProfitLossSummaryDay;
      profitLossSummaryDay.rowDataType = this.rowDataType;
      profitLossSummaryDay.pls_Date = this.pls_Date;
      return (object) profitLossSummaryDay;
    }

    public void PutData(ProfitLossSummaryDay pSource)
    {
      this.PutData((TProfitLossSummary) pSource);
      this.rowDataType = pSource.rowDataType;
      this.pls_Date = pSource.pls_Date;
    }

    public string ToWithGoodsCodeQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOOD_CODE AS (\nSELECT gdp_GoodsCode,gdp_SubGoodsCode,gdp_StockConvQty,gdp_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsPack, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}!={1}", (object) "gd_PackUnit", (object) 4) + string.Format("\nWHERE {0}={1}", (object) "gdp_SiteID", (object) p_SiteID) + " AND gdp_StockConvQty > 0\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1,gd_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 1) + "\nUNION ALL\nSELECT gd_GoodsCode,gd_GoodsCode,1,gd_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4) + ")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkGoods(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_GOODS AS ( SELECT  gd_GoodsCode,gd_SiteID,gd_TaxDiv,gd_SalesUnit,gd_StockUnit" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          p_param1.Add((object) "gd_PackUnit", (object) 1);
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "gd_PackUnit", (object) 1));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkGoodsHistoryQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_StoreCode=gdh_StoreCode AND si_SiteID=gdh_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TGoodsHistory().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkStartQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyStartTable AS (\nSELECT " + "pls_YyyyMm".ToStr(6).ToStrAdd("'01'").DateAdd(0, EnumDbAddType.DAY) + " AS pls_Date,pls_GoodsCode" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "pls_StoreCode" : (object) 0, (object) "pls_Supplier") + ",pls_SiteID,pls_BaseQty,pls_BaseAvgCost,pls_BaseCostAmt,pls_BaseCostVatAmt,pls_BasePrice,pls_BasePriceCostAmt,pls_BasePriceCostVatAmt,pls_BasePriceAmt,pls_BasePriceVatAmt,pls_EndAvgCost" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_CODE ON pls_GoodsCode=gdp_SubGoodsCode AND pls_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND pls_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=pls_StoreCode AND si_SiteID=pls_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
          {
            DateTime dateTime = (DateTime) dictionaryEntry.Value;
            p_param1.Add((object) "pls_YyyyMm_BEGIN_", (object) (dateTime.Year * 100 + dateTime.Month));
          }
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
          {
            DateTime dateTime = (DateTime) dictionaryEntry.Value;
            p_param1.Add((object) "pls_YyyyMm_END_", (object) (dateTime.Year * 100 + dateTime.Month));
          }
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "pls_SiteID"))
            p_param1.Add((object) "pls_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "pls_YyyyMm"))
            p_param1.Add((object) "pls_YyyyMm", (object) 0);
          if (!p_param1.ContainsKey((object) "pls_StoreCode") && !p_param1.ContainsKey((object) "pls_StoreCode_IN_"))
            p_param1.Add((object) "pls_StoreCode", (object) this.pls_StoreCode);
          stringBuilder.Append(new TProfitLossSummary().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
        {
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "pls_YyyyMm", (object) 0));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_StoreCode", (object) this.pls_StoreCode));
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "pls_SiteID", (object) p_SiteID));
        }
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkSaleQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodySaleTable AS (\nSELECT sbd_SaleDate AS pls_Date,sbd_GoodsCode AS pls_GoodsCode,sbd_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sbd_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sbd_SaleQty) AS pls_SaleQty,SUM(sbd_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(sbd_SaleAmt) AS pls_SaleAmt,SUM(sbd_SaleVatAmt) AS pls_SaleVatAmt,SUM(sbd_ProfitAmt) AS pls_SaleProfit,SUM(sbd_PreTaxProfitAmt) AS pls_SalePriceProfit,SUM(sbd_EnurySlip) AS pls_EnurySlip,SUM(sbd_EnuryEnd) AS pls_EnuryEnd,SUM(sbd_DcAmtManual) AS pls_DcAmtManual,SUM(sbd_DcAmtEvent) AS pls_DcAmtEvent,SUM(sbd_DcAmtGoods) AS pls_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(sbd_DcAmtMember) AS pls_DcAmtMember,SUM(sbd_SlipCustomer) AS pls_Customer,SUM(sbd_GoodsCustomer) AS pls_CustomerGoods,SUM(sbd_CategoryCustomer) AS pls_CustomerCategory,SUM(sbd_SupplierCustomer) AS pls_CustomerSupplier" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOOD_CODE ON sbd_GoodsCode=gdp_SubGoodsCode AND sbd_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sbd_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sbd_StoreCode AND si_SiteID=sbd_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sbd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sbd_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sbd_SaleDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sbd_StoreCode") && !p_param1.ContainsKey((object) "sbd_StoreCode_IN_"))
            p_param1.Add((object) "sbd_StoreCode", (object) this.pls_StoreCode);
          stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sbd_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sbd_SaleDate,sbd_GoodsCode,sbd_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sbd_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkBuyQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyBuyTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_BuyQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_BuyCostAmt,SUM(sd_CostVatAmt) AS pls_BuyCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_BuyPriceAmt,SUM(sd_PriceVatAmt) AS pls_BuyPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkReturnQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyReturnTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_ReturnQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_ReturnCostAmt,SUM(sd_CostVatAmt) AS pls_ReturnCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_ReturnPriceAmt,SUM(sd_PriceVatAmt) AS pls_ReturnPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_SupplierType"))
            p_param1.Add((object) "sh_SupplierType", (object) 1);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkInnerMoveOutQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyInnerMoveOutTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_InnerMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveOutPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 3);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkInnerMoveInQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyInnerMoveInTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_InnerMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveInPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 3);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkOuterMoveOutQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyOuterMoveOutTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_OuterMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveOutPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) -1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 4);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkOuterMoveInQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyOuterMoveInTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty) AS pls_OuterMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveInPriceVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_InOutDiv"))
            p_param1.Add((object) "sh_InOutDiv", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 4);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkAdjustQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyAdjustTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty*sh_InOutDiv) AS pls_AdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS pls_AdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS pls_AdjustPriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv END) AS pls_AdjustPriceCostSumAmt,SUM(0) AS pls_AdjustPriceCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 5);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithWorkDisuseQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_IsSupplierView)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyDisuseTable AS (\nSELECT sh_ConfirmDate AS pls_Date,sd_GoodsCode AS pls_GoodsCode,sh_SiteID AS pls_SiteID" + string.Format(",{0} AS {1}", p_IsSupplierView ? (object) "sh_Supplier" : (object) 0, (object) "pls_Supplier") + ",SUM(sd_BuyQty*sh_InOutDiv*-1) AS pls_DisuseQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisuseCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv*-1) AS pls_DisuseCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisusePriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv*-1) AS pls_DisusePriceVatAmt" + string.Format(",SUM(CASE WHEN {0}={1}", (object) "sd_StockUnit", (object) 2) + " THEN sd_BuyQty*sh_InOutDiv*-1*gdh_SalePrice ELSE (sd_PriceTaxAmt+sd_PriceTaxFreeAmt+sd_PriceVatAmt)*sh_InOutDiv*-1 END) AS pls_DisusePriceCostSumAmt,SUM(0) AS pls_DisusePriceCostVatAmt" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\nINNER JOIN T_GOOD_CODE ON sd_GoodsCode=gdp_SubGoodsCode AND sh_SiteID=gdp_SiteID\nINNER JOIN T_GOODS ON gdp_GoodsCode=gd_GoodsCode AND sh_SiteID=gd_SiteID\nINNER JOIN T_STORE ON si_StoreCode=sh_StoreCode AND si_SiteID=sh_SiteID" + string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StoreCode=gdh_StoreCode AND sd_GoodsCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID");
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "sh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "sh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          if (!p_param1.ContainsKey((object) "sh_StoreCode") && !p_param1.ContainsKey((object) "sh_StoreCode_IN_"))
            p_param1.Add((object) "sh_StoreCode", (object) this.pls_StoreCode);
          if (!p_param1.ContainsKey((object) "sh_ConfirmStatus"))
            p_param1.Add((object) "sh_ConfirmStatus", (object) 1);
          if (!p_param1.ContainsKey((object) "sh_StatementType"))
            p_param1.Add((object) "sh_StatementType", (object) 6);
          stringBuilder.Append(new TStatementHeader().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sh_SiteID", (object) 0));
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sd_GoodsCode,sh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
