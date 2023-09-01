// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.ProfitLossSummaryCreate
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.Interface;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary
{
  public class ProfitLossSummaryCreate : TProfitLossSummary, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ProfitLossSummaryCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ProfitLossSummaryCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossSummary) + " pls_YyyyMm INT NOT NULL,pls_StoreCode INT NOT NULL,pls_GoodsCode BIGINT NOT NULL,pls_SiteID BIGINT NOT NULL DEFAULT(0),pls_Supplier INT NOT NULL DEFAULT(0),pls_SupplierType INT NOT NULL DEFAULT(0),pls_CategoryCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pls_TaxDiv", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pls_StockUnit", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pls_SalesUnit", (object) 0) + ",pls_BaseQty MONEY NOT NULL DEFAULT(0.0),pls_BaseAvgCost MONEY NOT NULL DEFAULT(0.0),pls_BaseCostAmt MONEY NOT NULL DEFAULT(0.0),pls_BaseCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_BasePrice MONEY NOT NULL DEFAULT(0.0),pls_BasePriceCostAmt MONEY NOT NULL DEFAULT(0.0),pls_BasePriceCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_BasePriceAmt MONEY NOT NULL DEFAULT(0.0),pls_BasePriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_EndQty MONEY NOT NULL DEFAULT(0.0),pls_EndAvgCost MONEY NOT NULL DEFAULT(0.0),pls_EndCostAmt MONEY NOT NULL DEFAULT(0.0),pls_EndCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_EndPrice MONEY NOT NULL DEFAULT(0.0),pls_EndPriceCostAmt MONEY NOT NULL DEFAULT(0.0),pls_EndPriceCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_EndPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_EndPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_SaleQty MONEY NOT NULL DEFAULT(0.0),pls_TotalSaleAmt MONEY NOT NULL DEFAULT(0.0),pls_SaleAmt MONEY NOT NULL DEFAULT(0.0),pls_SaleVatAmt MONEY NOT NULL DEFAULT(0.0),pls_SaleProfit MONEY NOT NULL DEFAULT(0.0),pls_SalePriceProfit MONEY NOT NULL DEFAULT(0.0),pls_EnurySlip MONEY NOT NULL DEFAULT(0.0),pls_EnuryEnd MONEY NOT NULL DEFAULT(0.0),pls_DcAmtManual MONEY NOT NULL DEFAULT(0.0),pls_DcAmtEvent MONEY NOT NULL DEFAULT(0.0),pls_DcAmtGoods MONEY NOT NULL DEFAULT(0.0),pls_DcAmtCoupon MONEY NOT NULL DEFAULT(0.0),pls_DcAmtPromotion MONEY NOT NULL DEFAULT(0.0),pls_DcAmtMember MONEY NOT NULL DEFAULT(0.0),pls_Customer MONEY NOT NULL DEFAULT(0.0),pls_CustomerGoods MONEY NOT NULL DEFAULT(0.0),pls_CustomerCategory MONEY NOT NULL DEFAULT(0.0),pls_CustomerSupplier MONEY NOT NULL DEFAULT(0.0),pls_BuyQty MONEY NOT NULL DEFAULT(0.0),pls_BuyCostAmt MONEY NOT NULL DEFAULT(0.0),pls_BuyCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_BuyPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_BuyPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_ReturnQty MONEY NOT NULL DEFAULT(0.0),pls_ReturnCostAmt MONEY NOT NULL DEFAULT(0.0),pls_ReturnCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_ReturnPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_ReturnPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveOutQty MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveOutCostAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveOutCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveOutPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveOutPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveInQty MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveInCostAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveInCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveInPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_InnerMoveInPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveOutQty MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveOutCostAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveOutCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveOutPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveOutPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveInQty MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveInCostAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveInCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveInPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_OuterMoveInPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustQty MONEY NOT NULL DEFAULT(0.0),pls_AdjustCostAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustPriceAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustPriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustPriceCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_AdjustPriceCostSumAmt MONEY NOT NULL DEFAULT(0.0),pls_DisuseQty MONEY NOT NULL DEFAULT(0.0),pls_DisuseCostAmt MONEY NOT NULL DEFAULT(0.0),pls_DisuseCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_DisusePriceAmt MONEY NOT NULL DEFAULT(0.0),pls_DisusePriceVatAmt MONEY NOT NULL DEFAULT(0.0),pls_DisusePriceCostVatAmt MONEY NOT NULL DEFAULT(0.0),pls_DisusePriceCostSumAmt MONEY NOT NULL DEFAULT(0.0),pls_PriceUpVat MONEY NOT NULL DEFAULT(0.0),pls_PriceUp MONEY NOT NULL DEFAULT(0.0),pls_PriceDownVat MONEY NOT NULL DEFAULT(0.0),pls_PriceDown MONEY NOT NULL DEFAULT(0.0) PRIMARY KEY(pls_YyyyMm,pls_StoreCode,pls_GoodsCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossSummary) + " pls_YyyyMm INT NOT NULL,pls_StoreCode INT NOT NULL,pls_GoodsCode BIGINT NOT NULL,pls_SiteID BIGINT NOT NULL DEFAULT 0,pls_Supplier INT NOT NULL DEFAULT 0,pls_SupplierType INT NOT NULL DEFAULT 0,pls_CategoryCode INT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pls_TaxDiv", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pls_StockUnit", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pls_SalesUnit", (object) 0) + ",pls_BaseQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BaseAvgCost DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BaseCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BaseCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BasePrice DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BasePriceCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BasePriceCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BasePriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BasePriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndAvgCost DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndPrice DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndPriceCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndPriceCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EndPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_SaleQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_TotalSaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_SaleAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_SaleVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_SaleProfit DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_SalePriceProfit DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EnurySlip DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_EnuryEnd DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtManual DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtEvent DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtGoods DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtCoupon DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtPromotion DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DcAmtMember DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_Customer DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_CustomerGoods DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_CustomerCategory DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_CustomerSupplier DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BuyQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BuyCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BuyCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BuyPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_BuyPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_ReturnQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_ReturnCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_ReturnCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_ReturnPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_ReturnPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveOutQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveOutCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveOutCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveOutPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveOutPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveInQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveInCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveInCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveInPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_InnerMoveInPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveOutQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveOutCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveOutCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveOutPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveOutPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveInQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveInCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveInCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveInPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_OuterMoveInPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustPriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustPriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustPriceCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_AdjustPriceCostSumAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisuseQty DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisuseCostAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisuseCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisusePriceAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisusePriceVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisusePriceCostVatAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_DisusePriceCostSumAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_PriceUpVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_PriceUp DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_PriceDownVat DECIMAL(19,4) NOT NULL DEFAULT 0.0,pls_PriceDown DECIMAL(19,4) NOT NULL DEFAULT 0.0 PRIMARY KEY(pls_YyyyMm,pls_StoreCode,pls_GoodsCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ProfitLossSummaryCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_STOCK, (object) this.TableCode)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool CreateTableComment(string p_db_category)
    {
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MSSQL)
        return true;
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string str1 = "EXEC " + UbModelBase.UNI_STOCK + ".sys.sp_addextendedproperty N'MS_Description', N'";
        string str2 = "', N'schema', N'dbo', N'table', N'";
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.ProfitLossSummary.ToDescription(), (object) str2, (object) TableCodeType.ProfitLossSummary));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "년월", (object) str2, (object) TableCodeType.ProfitLossSummary, (object) "pls_YyyyMm"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_1 ON {1}.dbo.{2}", (object) TableCodeType.ProfitLossSummary, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossSummary) + " (pls_SiteID ASC,pls_YyyyMm ASC,pls_StoreCode ASC,pls_GoodsCode ASC)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX_2 ON {1}.dbo.{2}", (object) TableCodeType.ProfitLossSummary, (object) UbModelBase.UNI_STOCK, (object) TableCodeType.ProfitLossSummary) + " (pls_SiteID ASC,pls_YyyyMm ASC,pls_StoreCode ASC,pls_StockUnit ASC,pls_GoodsCode ASC)\n WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY] ;");
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return false;
    }

    public bool InitTable() => this.InitTable(1L);

    public bool InitTable(long pSiteID)
    {
      if (pSiteID == 0L)
        pSiteID = 1L;
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("pls_YyyyMm"))
          this.pls_YyyyMm = p_rs.GetFieldInt("pls_YyyyMm");
        if (p_rs.IsFieldName("pls_StoreCode"))
          this.pls_StoreCode = p_rs.GetFieldInt("pls_StoreCode");
        if (p_rs.IsFieldName("pls_GoodsCode"))
          this.pls_GoodsCode = p_rs.GetFieldLong("pls_GoodsCode");
        if (p_rs.IsFieldName("pls_SiteID"))
          this.pls_SiteID = p_rs.GetFieldLong("pls_SiteID");
        if (p_rs.IsFieldName("pls_Supplier"))
          this.pls_Supplier = p_rs.GetFieldInt("pls_Supplier");
        if (p_rs.IsFieldName("pls_SupplierType"))
          this.pls_SupplierType = p_rs.GetFieldInt("pls_SupplierType");
        if (p_rs.IsFieldName("pls_CategoryCode"))
          this.pls_CategoryCode = p_rs.GetFieldInt("pls_CategoryCode");
        if (p_rs.IsFieldName("pls_TaxDiv"))
          this.pls_TaxDiv = p_rs.GetFieldInt("pls_TaxDiv");
        if (p_rs.IsFieldName("pls_StockUnit"))
          this.pls_StockUnit = p_rs.GetFieldInt("pls_StockUnit");
        if (p_rs.IsFieldName("pls_SalesUnit"))
          this.pls_SalesUnit = p_rs.GetFieldInt("pls_SalesUnit");
        if (p_rs.IsFieldName("pls_BaseQty"))
          this.pls_BaseQty = p_rs.GetFieldDouble("pls_BaseQty");
        if (p_rs.IsFieldName("pls_BaseAvgCost"))
          this.pls_BaseAvgCost = p_rs.GetFieldDouble("pls_BaseAvgCost");
        if (p_rs.IsFieldName("pls_BaseCostAmt"))
          this.pls_BaseCostAmt = p_rs.GetFieldDouble("pls_BaseCostAmt");
        if (p_rs.IsFieldName("pls_BaseCostVatAmt"))
          this.pls_BaseCostVatAmt = p_rs.GetFieldDouble("pls_BaseCostVatAmt");
        if (p_rs.IsFieldName("pls_BasePriceAmt"))
          this.pls_BasePriceAmt = p_rs.GetFieldDouble("pls_BasePriceAmt");
        if (p_rs.IsFieldName("pls_BasePriceCostAmt"))
          this.pls_BasePriceCostAmt = p_rs.GetFieldDouble("pls_BasePriceCostAmt");
        if (p_rs.IsFieldName("pls_BasePriceCostVatAmt"))
          this.pls_BasePriceCostVatAmt = p_rs.GetFieldDouble("pls_BasePriceCostVatAmt");
        if (p_rs.IsFieldName("pls_BasePrice"))
          this.pls_BasePrice = p_rs.GetFieldDouble("pls_BasePrice");
        if (p_rs.IsFieldName("pls_BasePriceVatAmt"))
          this.pls_BasePriceVatAmt = p_rs.GetFieldDouble("pls_BasePriceVatAmt");
        if (p_rs.IsFieldName("pls_EndQty"))
          this.pls_EndQty = p_rs.GetFieldDouble("pls_EndQty");
        if (p_rs.IsFieldName("pls_EndAvgCost"))
          this.pls_EndAvgCost = p_rs.GetFieldDouble("pls_EndAvgCost");
        if (p_rs.IsFieldName("pls_EndCostAmt"))
          this.pls_EndCostAmt = p_rs.GetFieldDouble("pls_EndCostAmt");
        if (p_rs.IsFieldName("pls_EndCostVatAmt"))
          this.pls_EndCostVatAmt = p_rs.GetFieldDouble("pls_EndCostVatAmt");
        if (p_rs.IsFieldName("pls_EndPriceAmt"))
          this.pls_EndPriceAmt = p_rs.GetFieldDouble("pls_EndPriceAmt");
        if (p_rs.IsFieldName("pls_EndPriceCostAmt"))
          this.pls_EndPriceCostAmt = p_rs.GetFieldDouble("pls_EndPriceCostAmt");
        if (p_rs.IsFieldName("pls_EndPriceCostVatAmt"))
          this.pls_EndPriceCostVatAmt = p_rs.GetFieldDouble("pls_EndPriceCostVatAmt");
        if (p_rs.IsFieldName("pls_EndPrice"))
          this.pls_EndPrice = p_rs.GetFieldDouble("pls_EndPrice");
        if (p_rs.IsFieldName("pls_EndPriceVatAmt"))
          this.pls_EndPriceVatAmt = p_rs.GetFieldDouble("pls_EndPriceVatAmt");
        if (p_rs.IsFieldName("pls_SaleQty"))
          this.pls_SaleQty = p_rs.GetFieldDouble("pls_SaleQty");
        if (p_rs.IsFieldName("pls_TotalSaleAmt"))
          this.pls_TotalSaleAmt = p_rs.GetFieldDouble("pls_TotalSaleAmt");
        if (p_rs.IsFieldName("pls_SaleAmt"))
          this.pls_SaleAmt = p_rs.GetFieldDouble("pls_SaleAmt");
        if (p_rs.IsFieldName("pls_SaleVatAmt"))
          this.pls_SaleVatAmt = p_rs.GetFieldDouble("pls_SaleVatAmt");
        if (p_rs.IsFieldName("pls_SaleProfit"))
          this.pls_SaleProfit = p_rs.GetFieldDouble("pls_SaleProfit");
        if (p_rs.IsFieldName("pls_SalePriceProfit"))
          this.pls_SalePriceProfit = p_rs.GetFieldDouble("pls_SalePriceProfit");
        if (p_rs.IsFieldName("pls_EnurySlip"))
          this.pls_EnurySlip = p_rs.GetFieldDouble("pls_EnurySlip");
        if (p_rs.IsFieldName("pls_EnuryEnd"))
          this.pls_EnuryEnd = p_rs.GetFieldDouble("pls_EnuryEnd");
        if (p_rs.IsFieldName("pls_DcAmtManual"))
          this.pls_DcAmtManual = p_rs.GetFieldDouble("pls_DcAmtManual");
        if (p_rs.IsFieldName("pls_DcAmtEvent"))
          this.pls_DcAmtEvent = p_rs.GetFieldDouble("pls_DcAmtEvent");
        if (p_rs.IsFieldName("pls_DcAmtGoods"))
          this.pls_DcAmtGoods = p_rs.GetFieldDouble("pls_DcAmtGoods");
        if (p_rs.IsFieldName("pls_DcAmtCoupon"))
          this.pls_DcAmtCoupon = p_rs.GetFieldDouble("pls_DcAmtCoupon");
        if (p_rs.IsFieldName("pls_DcAmtPromotion"))
          this.pls_DcAmtPromotion = p_rs.GetFieldDouble("pls_DcAmtPromotion");
        if (p_rs.IsFieldName("pls_DcAmtMember"))
          this.pls_DcAmtMember = p_rs.GetFieldDouble("pls_DcAmtMember");
        if (p_rs.IsFieldName("pls_Customer"))
          this.pls_Customer = p_rs.GetFieldDouble("pls_Customer");
        if (p_rs.IsFieldName("pls_CustomerGoods"))
          this.pls_CustomerGoods = p_rs.GetFieldDouble("pls_CustomerGoods");
        if (p_rs.IsFieldName("pls_CustomerCategory"))
          this.pls_CustomerCategory = p_rs.GetFieldDouble("pls_CustomerCategory");
        if (p_rs.IsFieldName("pls_CustomerSupplier"))
          this.pls_CustomerSupplier = p_rs.GetFieldDouble("pls_CustomerSupplier");
        if (p_rs.IsFieldName("pls_BuyQty"))
          this.pls_BuyQty = p_rs.GetFieldDouble("pls_BuyQty");
        if (p_rs.IsFieldName("pls_BuyCostAmt"))
          this.pls_BuyCostAmt = p_rs.GetFieldDouble("pls_BuyCostAmt");
        if (p_rs.IsFieldName("pls_BuyCostVatAmt"))
          this.pls_BuyCostVatAmt = p_rs.GetFieldDouble("pls_BuyCostVatAmt");
        if (p_rs.IsFieldName("pls_BuyPriceAmt"))
          this.pls_BuyPriceAmt = p_rs.GetFieldDouble("pls_BuyPriceAmt");
        if (p_rs.IsFieldName("pls_BuyPriceVatAmt"))
          this.pls_BuyPriceVatAmt = p_rs.GetFieldDouble("pls_BuyPriceVatAmt");
        if (p_rs.IsFieldName("pls_ReturnQty"))
          this.pls_ReturnQty = p_rs.GetFieldDouble("pls_ReturnQty");
        if (p_rs.IsFieldName("pls_ReturnCostAmt"))
          this.pls_ReturnCostAmt = p_rs.GetFieldDouble("pls_ReturnCostAmt");
        if (p_rs.IsFieldName("pls_ReturnCostVatAmt"))
          this.pls_ReturnCostVatAmt = p_rs.GetFieldDouble("pls_ReturnCostVatAmt");
        if (p_rs.IsFieldName("pls_ReturnPriceAmt"))
          this.pls_ReturnPriceAmt = p_rs.GetFieldDouble("pls_ReturnPriceAmt");
        if (p_rs.IsFieldName("pls_ReturnPriceVatAmt"))
          this.pls_ReturnPriceVatAmt = p_rs.GetFieldDouble("pls_ReturnPriceVatAmt");
        if (p_rs.IsFieldName("pls_InnerMoveOutQty"))
          this.pls_InnerMoveOutQty = p_rs.GetFieldDouble("pls_InnerMoveOutQty");
        if (p_rs.IsFieldName("pls_InnerMoveOutCostAmt"))
          this.pls_InnerMoveOutCostAmt = p_rs.GetFieldDouble("pls_InnerMoveOutCostAmt");
        if (p_rs.IsFieldName("pls_InnerMoveOutCostVatAmt"))
          this.pls_InnerMoveOutCostVatAmt = p_rs.GetFieldDouble("pls_InnerMoveOutCostVatAmt");
        if (p_rs.IsFieldName("pls_InnerMoveOutPriceAmt"))
          this.pls_InnerMoveOutPriceAmt = p_rs.GetFieldDouble("pls_InnerMoveOutPriceAmt");
        if (p_rs.IsFieldName("pls_InnerMoveOutPriceVatAmt"))
          this.pls_InnerMoveOutPriceVatAmt = p_rs.GetFieldDouble("pls_InnerMoveOutPriceVatAmt");
        if (p_rs.IsFieldName("pls_InnerMoveInQty"))
          this.pls_InnerMoveInQty = p_rs.GetFieldDouble("pls_InnerMoveInQty");
        if (p_rs.IsFieldName("pls_InnerMoveInCostAmt"))
          this.pls_InnerMoveInCostAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostAmt");
        if (p_rs.IsFieldName("pls_InnerMoveInCostVatAmt"))
          this.pls_InnerMoveInCostVatAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostVatAmt");
        if (p_rs.IsFieldName("pls_InnerMoveInPriceAmt"))
          this.pls_InnerMoveInPriceAmt = p_rs.GetFieldDouble("pls_InnerMoveInPriceAmt");
        if (p_rs.IsFieldName("pls_InnerMoveInPriceVatAmt"))
          this.pls_InnerMoveInPriceVatAmt = p_rs.GetFieldDouble("pls_InnerMoveInPriceVatAmt");
        if (p_rs.IsFieldName("pls_OuterMoveOutQty"))
          this.pls_OuterMoveOutQty = p_rs.GetFieldDouble("pls_OuterMoveOutQty");
        if (p_rs.IsFieldName("pls_OuterMoveOutCostAmt"))
          this.pls_OuterMoveOutCostAmt = p_rs.GetFieldDouble("pls_OuterMoveOutCostAmt");
        if (p_rs.IsFieldName("pls_OuterMoveOutCostVatAmt"))
          this.pls_OuterMoveOutCostVatAmt = p_rs.GetFieldDouble("pls_OuterMoveOutCostVatAmt");
        if (p_rs.IsFieldName("pls_OuterMoveOutPriceAmt"))
          this.pls_OuterMoveOutPriceAmt = p_rs.GetFieldDouble("pls_OuterMoveOutPriceAmt");
        if (p_rs.IsFieldName("pls_OuterMoveOutPriceVatAmt"))
          this.pls_OuterMoveOutPriceVatAmt = p_rs.GetFieldDouble("pls_OuterMoveOutPriceVatAmt");
        if (p_rs.IsFieldName("pls_OuterMoveInQty"))
          this.pls_OuterMoveInQty = p_rs.GetFieldDouble("pls_OuterMoveInQty");
        if (p_rs.IsFieldName("pls_OuterMoveInCostAmt"))
          this.pls_OuterMoveInCostAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostAmt");
        if (p_rs.IsFieldName("pls_OuterMoveInCostVatAmt"))
          this.pls_OuterMoveInCostVatAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostVatAmt");
        if (p_rs.IsFieldName("pls_OuterMoveInPriceAmt"))
          this.pls_OuterMoveInPriceAmt = p_rs.GetFieldDouble("pls_OuterMoveInPriceAmt");
        if (p_rs.IsFieldName("pls_OuterMoveInPriceVatAmt"))
          this.pls_OuterMoveInPriceVatAmt = p_rs.GetFieldDouble("pls_OuterMoveInPriceVatAmt");
        if (p_rs.IsFieldName("pls_AdjustQty"))
          this.pls_AdjustQty = p_rs.GetFieldDouble("pls_AdjustQty");
        if (p_rs.IsFieldName("pls_AdjustCostAmt"))
          this.pls_AdjustCostAmt = p_rs.GetFieldDouble("pls_AdjustCostAmt");
        if (p_rs.IsFieldName("pls_AdjustCostVatAmt"))
          this.pls_AdjustCostVatAmt = p_rs.GetFieldDouble("pls_AdjustCostVatAmt");
        if (p_rs.IsFieldName("pls_AdjustPriceAmt"))
          this.pls_AdjustPriceAmt = p_rs.GetFieldDouble("pls_AdjustPriceAmt");
        if (p_rs.IsFieldName("pls_AdjustPriceVatAmt"))
          this.pls_AdjustPriceVatAmt = p_rs.GetFieldDouble("pls_AdjustPriceVatAmt");
        if (p_rs.IsFieldName("pls_AdjustPriceCostSumAmt"))
          this.pls_AdjustPriceCostSumAmt = p_rs.GetFieldDouble("pls_AdjustPriceCostSumAmt");
        if (p_rs.IsFieldName("pls_AdjustPriceCostVatAmt"))
          this.pls_AdjustPriceCostVatAmt = p_rs.GetFieldDouble("pls_AdjustPriceCostVatAmt");
        if (p_rs.IsFieldName("pls_DisuseQty"))
          this.pls_DisuseQty = p_rs.GetFieldDouble("pls_DisuseQty");
        if (p_rs.IsFieldName("pls_DisuseCostAmt"))
          this.pls_DisuseCostAmt = p_rs.GetFieldDouble("pls_DisuseCostAmt");
        if (p_rs.IsFieldName("pls_DisuseCostVatAmt"))
          this.pls_DisuseCostVatAmt = p_rs.GetFieldDouble("pls_DisuseCostVatAmt");
        if (p_rs.IsFieldName("pls_DisusePriceAmt"))
          this.pls_DisusePriceAmt = p_rs.GetFieldDouble("pls_DisusePriceAmt");
        if (p_rs.IsFieldName("pls_DisusePriceVatAmt"))
          this.pls_DisusePriceVatAmt = p_rs.GetFieldDouble("pls_DisusePriceVatAmt");
        if (p_rs.IsFieldName("pls_DisusePriceCostSumAmt"))
          this.pls_DisusePriceCostSumAmt = p_rs.GetFieldDouble("pls_DisusePriceCostSumAmt");
        if (p_rs.IsFieldName("pls_DisusePriceCostVatAmt"))
          this.pls_DisusePriceCostVatAmt = p_rs.GetFieldDouble("pls_DisusePriceCostVatAmt");
        if (p_rs.IsFieldName("pls_PriceUp"))
          this.pls_PriceUp = p_rs.GetFieldDouble("pls_PriceUp");
        if (p_rs.IsFieldName("pls_PriceUpVat"))
          this.pls_PriceUpVat = p_rs.GetFieldDouble("pls_PriceUpVat");
        if (p_rs.IsFieldName("pls_PriceDown"))
          this.pls_PriceDown = p_rs.GetFieldDouble("pls_PriceDown");
        if (p_rs.IsFieldName("pls_PriceDownVat"))
          this.pls_PriceDownVat = p_rs.GetFieldDouble("pls_PriceDownVat");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public bool ReCreateTable()
    {
      try
      {
        IList<ProfitLossSummaryCreate> lossSummaryCreateList = this.OleDB.Create<ProfitLossSummaryCreate>().SelectAllListE<ProfitLossSummaryCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_STOCK
          }
        });
        if (lossSummaryCreateList == null)
        {
          this.message = " " + this.TableCode.ToDescription() + " SELECT AND Serialize 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.DropTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Drop 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Create 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTableComment(string.Empty))
        {
          this.message = " " + this.TableCode.ToDescription() + " Create Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        int count = lossSummaryCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (lossSummaryCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ProfitLossSummary.ToDescription(), (object) TableCodeType.ProfitLossSummary) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ProfitLossSummaryCreate lossSummaryCreate in (IEnumerable<ProfitLossSummaryCreate>) lossSummaryCreateList)
        {
          stringBuilder.Append(lossSummaryCreate.InsertQuery());
          if (stringBuilder.Length > 4000)
          {
            if (!this.OleDB.Execute(stringBuilder.ToString()))
            {
              this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
              throw new Exception();
            }
            stringBuilder.Clear();
          }
          ++num1;
          num2 = num1 * 100 / count;
          if (num3 != num2)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
            num3 = num2;
          }
        }
        if (stringBuilder.Length > 0)
        {
          if (!this.OleDB.Execute(stringBuilder.ToString()))
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          stringBuilder.Clear();
        }
        if (lossSummaryCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ProfitLossSummary.ToDescription(), (object) TableCodeType.ProfitLossSummary) + "\n--------------------------------------------------------------------------------------------------");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.DebugColor(this.message);
        return false;
      }
      return true;
    }
  }
}
