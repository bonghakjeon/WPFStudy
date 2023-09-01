// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.TProfitLossSummary
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary
{
  public class TProfitLossSummary : UbModelBase<TProfitLossSummary>
  {
    private int _pls_YyyyMm;
    private int _pls_StoreCode;
    protected long _pls_GoodsCode;
    private long _pls_SiteID;
    private int _pls_Supplier;
    private int _pls_SupplierType;
    private int _pls_CategoryCode;
    private int _pls_TaxDiv;
    private int _pls_StockUnit;
    private int _pls_SalesUnit;
    private double _pls_BaseQty;
    private double _pls_BaseAvgCost;
    private double _pls_BaseCostAmt;
    private double _pls_BaseCostVatAmt;
    private double _pls_BasePrice;
    private double _pls_BasePriceAmt;
    private double _pls_BasePriceVatAmt;
    private double _pls_BasePriceCostAmt;
    private double _pls_BasePriceCostVatAmt;
    private double _pls_EndQty;
    private double _pls_EndAvgCost;
    private double _pls_EndCostAmt;
    private double _pls_EndCostVatAmt;
    private double _pls_EndPrice;
    private double _pls_EndPriceAmt;
    private double _pls_EndPriceVatAmt;
    private double _pls_EndPriceCostAmt;
    private double _pls_EndPriceCostVatAmt;
    private double _pls_SaleQty;
    private double _pls_TotalSaleAmt;
    private double _pls_SaleAmt;
    private double _pls_SaleVatAmt;
    private double _pls_SaleProfit;
    private double _pls_SalePriceProfit;
    private double _pls_EnurySlip;
    private double _pls_EnuryEnd;
    private double _pls_DcAmtManual;
    private double _pls_DcAmtEvent;
    private double _pls_DcAmtGoods;
    private double _pls_DcAmtCoupon;
    private double _pls_DcAmtPromotion;
    private double _pls_DcAmtMember;
    private double _pls_Customer;
    private double _pls_CustomerGoods;
    private double _pls_CustomerCategory;
    private double _pls_CustomerSupplier;
    private double _pls_BuyQty;
    private double _pls_BuyCostAmt;
    private double _pls_BuyCostVatAmt;
    private double _pls_BuyPriceAmt;
    private double _pls_BuyPriceVatAmt;
    private double _pls_ReturnQty;
    private double _pls_ReturnCostAmt;
    private double _pls_ReturnCostVatAmt;
    private double _pls_ReturnPriceAmt;
    private double _pls_ReturnPriceVatAmt;
    private double _pls_InnerMoveOutQty;
    private double _pls_InnerMoveOutCostAmt;
    private double _pls_InnerMoveOutCostVatAmt;
    private double _pls_InnerMoveOutPriceAmt;
    private double _pls_InnerMoveOutPriceVatAmt;
    private double _pls_InnerMoveInQty;
    private double _pls_InnerMoveInCostAmt;
    private double _pls_InnerMoveInCostVatAmt;
    private double _pls_InnerMoveInPriceAmt;
    private double _pls_InnerMoveInPriceVatAmt;
    private double _pls_OuterMoveOutQty;
    private double _pls_OuterMoveOutCostAmt;
    private double _pls_OuterMoveOutCostVatAmt;
    private double _pls_OuterMoveOutPriceAmt;
    private double _pls_OuterMoveOutPriceVatAmt;
    private double _pls_OuterMoveInQty;
    private double _pls_OuterMoveInCostAmt;
    private double _pls_OuterMoveInCostVatAmt;
    private double _pls_OuterMoveInPriceAmt;
    private double _pls_OuterMoveInPriceVatAmt;
    private double _pls_AdjustQty;
    private double _pls_AdjustCostAmt;
    private double _pls_AdjustCostVatAmt;
    private double _pls_AdjustPriceAmt;
    private double _pls_AdjustPriceVatAmt;
    private double _pls_AdjustPriceCostSumAmt;
    private double _pls_AdjustPriceCostVatAmt;
    private double _pls_DisuseQty;
    private double _pls_DisuseCostAmt;
    private double _pls_DisuseCostVatAmt;
    private double _pls_DisusePriceAmt;
    private double _pls_DisusePriceVatAmt;
    private double _pls_DisusePriceCostSumAmt;
    private double _pls_DisusePriceCostVatAmt;
    private double _pls_PriceUp;
    private double _pls_PriceUpVat;
    private double _pls_PriceDown;
    private double _pls_PriceDownVat;
    [JsonIgnore]
    public static string MainCol = ",pls_BaseQty,pls_BaseAvgCost,pls_BaseCostAmt,pls_BaseCostVatAmt,pls_BasePrice,pls_BasePriceCostAmt,pls_BasePriceCostVatAmt,pls_BasePriceAmt,pls_BasePriceVatAmt,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt,pls_SaleQty,pls_TotalSaleAmt,pls_SaleAmt,pls_SaleVatAmt,pls_SaleProfit,pls_SalePriceProfit,pls_EnurySlip,pls_EnuryEnd,pls_DcAmtManual,pls_DcAmtEvent,pls_DcAmtGoods,pls_DcAmtCoupon,pls_DcAmtPromotion,pls_DcAmtMember,pls_Customer,pls_CustomerGoods,pls_CustomerCategory,pls_CustomerSupplier,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_BuyPriceAmt,pls_BuyPriceVatAmt,pls_ReturnQty,pls_ReturnCostAmt,pls_ReturnCostVatAmt,pls_ReturnPriceAmt,pls_ReturnPriceVatAmt,pls_InnerMoveOutQty,pls_InnerMoveOutCostAmt,pls_InnerMoveOutCostVatAmt,pls_InnerMoveOutPriceAmt,pls_InnerMoveOutPriceVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_InnerMoveInPriceAmt,pls_InnerMoveInPriceVatAmt,pls_OuterMoveOutQty,pls_OuterMoveOutCostAmt,pls_OuterMoveOutCostVatAmt,pls_OuterMoveOutPriceAmt,pls_OuterMoveOutPriceVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt,pls_OuterMoveInPriceAmt,pls_OuterMoveInPriceVatAmt,pls_AdjustQty,pls_AdjustCostAmt,pls_AdjustCostVatAmt,pls_AdjustPriceAmt,pls_AdjustPriceVatAmt,pls_AdjustPriceCostSumAmt,pls_AdjustPriceCostVatAmt,pls_DisuseQty,pls_DisuseCostAmt,pls_DisuseCostVatAmt,pls_DisusePriceAmt,pls_DisusePriceVatAmt,pls_DisusePriceCostSumAmt,pls_DisusePriceCostVatAmt,pls_PriceUp,pls_PriceUpVat,pls_PriceDown,pls_PriceDownVat";
    [JsonIgnore]
    public static string SubCol = ",SUM(pls_BaseQty) AS pls_BaseQty,SUM(pls_BaseAvgCost) AS pls_BaseAvgCost,SUM(pls_BaseCostAmt) AS pls_BaseCostAmt,SUM(pls_BaseCostVatAmt) AS pls_BaseCostVatAmt,SUM(pls_BasePrice) AS pls_BasePrice,SUM(pls_BasePriceCostAmt) AS pls_BasePriceCostAmt,SUM(pls_BasePriceCostVatAmt) AS pls_BasePriceCostVatAmt,SUM(pls_BasePriceAmt) AS pls_BasePriceAmt,SUM(pls_BasePriceVatAmt) AS pls_BasePriceVatAmt,SUM(pls_EndQty) AS pls_EndQty,SUM(pls_EndAvgCost) AS pls_EndAvgCost,SUM(pls_EndCostAmt) AS pls_EndCostAmt,SUM(pls_EndCostVatAmt) AS pls_EndCostVatAmt,SUM(pls_EndPrice) AS pls_EndPrice,SUM(pls_EndPriceCostAmt) AS pls_EndPriceCostAmt,SUM(pls_EndPriceCostVatAmt) AS pls_EndPriceCostVatAmt,SUM(pls_EndPriceAmt) AS pls_EndPriceAmt,SUM(pls_EndPriceVatAmt) AS pls_EndPriceVatAmt,SUM(pls_SaleQty) AS pls_SaleQty,SUM(pls_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(pls_SaleAmt) AS pls_SaleAmt,SUM(pls_SaleVatAmt) AS pls_SaleVatAmt,SUM(pls_SaleProfit) AS pls_SaleProfit,SUM(pls_SalePriceProfit) AS pls_SalePriceProfit,SUM(pls_EnurySlip) AS pls_EnurySlip,SUM(pls_EnuryEnd) AS pls_EnuryEnd,SUM(pls_DcAmtManual) AS pls_DcAmtManual,SUM(pls_DcAmtEvent) AS pls_DcAmtEvent,SUM(pls_DcAmtGoods) AS pls_DcAmtGoods,SUM(pls_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(pls_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(pls_DcAmtMember) AS pls_DcAmtMember,SUM(pls_Customer) AS pls_Customer,SUM(pls_CustomerGoods) AS pls_CustomerGoods,SUM(pls_CustomerCategory) AS pls_CustomerCategory,SUM(pls_CustomerSupplier) AS pls_CustomerSupplier,SUM(pls_BuyQty) AS pls_BuyQty,SUM(pls_BuyCostAmt) AS pls_BuyCostAmt,SUM(pls_BuyCostVatAmt) AS pls_BuyCostVatAmt,SUM(pls_BuyPriceAmt) AS pls_BuyPriceAmt,SUM(pls_BuyPriceVatAmt) AS pls_BuyPriceVatAmt,SUM(pls_ReturnQty) AS pls_ReturnQty,SUM(pls_ReturnCostAmt) AS pls_ReturnCostAmt,SUM(pls_ReturnCostVatAmt) AS pls_ReturnCostVatAmt,SUM(pls_ReturnPriceAmt) AS pls_ReturnPriceAmt,SUM(pls_ReturnPriceVatAmt) AS pls_ReturnPriceVatAmt,SUM(pls_InnerMoveOutQty) AS pls_InnerMoveOutQty,SUM(pls_InnerMoveOutCostAmt) AS pls_InnerMoveOutCostAmt,SUM(pls_InnerMoveOutCostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(pls_InnerMoveOutPriceAmt) AS pls_InnerMoveOutPriceAmt,SUM(pls_InnerMoveOutPriceVatAmt) AS pls_InnerMoveOutPriceVatAmt,SUM(pls_InnerMoveInQty) AS pls_InnerMoveInQty,SUM(pls_InnerMoveInCostAmt) AS pls_InnerMoveInCostAmt,SUM(pls_InnerMoveInCostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(pls_InnerMoveInPriceAmt) AS pls_InnerMoveInPriceAmt,SUM(pls_InnerMoveInPriceVatAmt) AS pls_InnerMoveInPriceVatAmt,SUM(pls_OuterMoveOutQty) AS pls_OuterMoveOutQty,SUM(pls_OuterMoveOutCostAmt) AS pls_OuterMoveOutCostAmt,SUM(pls_OuterMoveOutCostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(pls_OuterMoveOutPriceAmt) AS pls_OuterMoveOutPriceAmt,SUM(pls_OuterMoveOutPriceVatAmt) AS pls_OuterMoveOutPriceVatAmt,SUM(pls_OuterMoveInQty) AS pls_OuterMoveInQty,SUM(pls_OuterMoveInCostAmt) AS pls_OuterMoveInCostAmt,SUM(pls_OuterMoveInCostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(pls_OuterMoveInPriceAmt) AS pls_OuterMoveInPriceAmt,SUM(pls_OuterMoveInPriceVatAmt) AS pls_OuterMoveInPriceVatAmt,SUM(pls_AdjustQty) AS pls_AdjustQty,SUM(pls_AdjustCostAmt) AS pls_AdjustCostAmt,SUM(pls_AdjustCostVatAmt) AS pls_AdjustCostVatAmt,SUM(pls_AdjustPriceAmt) AS pls_AdjustPriceAmt,SUM(pls_AdjustPriceVatAmt) AS pls_AdjustPriceVatAmt,SUM(pls_AdjustPriceCostSumAmt) AS pls_AdjustPriceCostSumAmt,SUM(pls_AdjustPriceCostVatAmt) AS pls_AdjustPriceCostVatAmt,SUM(pls_DisuseQty) AS pls_DisuseQty,SUM(pls_DisuseCostAmt) AS pls_DisuseCostAmt,SUM(pls_DisuseCostVatAmt) AS pls_DisuseCostVatAmt,SUM(pls_DisusePriceAmt) AS pls_DisusePriceAmt,SUM(pls_DisusePriceVatAmt) AS pls_DisusePriceVatAmt,SUM(pls_DisusePriceCostSumAmt) AS pls_DisusePriceCostSumAmt,SUM(pls_DisusePriceCostVatAmt) AS pls_DisusePriceCostVatAmt,SUM(pls_PriceUp) AS pls_PriceUp,SUM(pls_PriceUpVat) AS pls_PriceUpVat,SUM(pls_PriceDown) AS pls_PriceDown,SUM(pls_PriceDownVat) AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyStartTable = "기초";
    [JsonIgnore]
    public static string TBodyStartCol = ",pls_BaseQty,pls_BaseAvgCost,pls_BaseCostAmt,pls_BaseCostVatAmt,pls_BasePrice,pls_BasePriceCostAmt,pls_BasePriceCostVatAmt,pls_BasePriceAmt,pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TProfitLossSummaryStartSumCol = ",SUM(pls_BaseQty) AS pls_BaseQty,SUM(pls_BaseAvgCost) AS pls_BaseAvgCost,SUM(pls_BaseCostAmt) AS pls_BaseCostAmt,SUM(pls_BaseCostVatAmt) AS pls_BaseCostVatAmt,SUM(pls_BasePrice) AS pls_BasePrice,SUM(pls_BasePriceCostAmt) AS pls_BasePriceCostAmt,SUM(pls_BasePriceCostVatAmt) AS pls_BasePriceCostVatAmt,SUM(pls_BasePriceAmt) AS pls_BasePriceAmt,SUM(pls_BasePriceVatAmt) AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyMiddleTable = "기중";
    [JsonIgnore]
    public static string TProfitLossSummaryMiddleSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,SUM(pls_SaleQty) AS pls_SaleQty,SUM(pls_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(pls_SaleAmt) AS pls_SaleAmt,SUM(pls_SaleVatAmt) AS pls_SaleVatAmt,SUM(pls_SaleProfit) AS pls_SaleProfit,SUM(pls_SalePriceProfit) AS pls_SalePriceProfit,SUM(pls_EnurySlip) AS pls_EnurySlip,SUM(pls_EnuryEnd) AS pls_EnuryEnd,SUM(pls_DcAmtManual) AS pls_DcAmtManual,SUM(pls_DcAmtEvent) AS pls_DcAmtEvent,SUM(pls_DcAmtGoods) AS pls_DcAmtGoods,SUM(pls_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(pls_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(pls_DcAmtMember) AS pls_DcAmtMember,SUM(pls_Customer) AS pls_Customer,SUM(pls_CustomerGoods) AS pls_CustomerGoods,SUM(pls_CustomerCategory) AS pls_CustomerCategory,SUM(pls_CustomerSupplier) AS pls_CustomerSupplier,SUM(pls_BuyQty) AS pls_BuyQty,SUM(pls_BuyCostAmt) AS pls_BuyCostAmt,SUM(pls_BuyCostVatAmt) AS pls_BuyCostVatAmt,SUM(pls_BuyPriceAmt) AS pls_BuyPriceAmt,SUM(pls_BuyPriceVatAmt) AS pls_BuyPriceVatAmt,SUM(pls_ReturnQty) AS pls_ReturnQty,SUM(pls_ReturnCostAmt) AS pls_ReturnCostAmt,SUM(pls_ReturnCostVatAmt) AS pls_ReturnCostVatAmt,SUM(pls_ReturnPriceAmt) AS pls_ReturnPriceAmt,SUM(pls_ReturnPriceVatAmt) AS pls_ReturnPriceVatAmt,SUM(pls_InnerMoveOutQty) AS pls_InnerMoveOutQty,SUM(pls_InnerMoveOutCostAmt) AS pls_InnerMoveOutCostAmt,SUM(pls_InnerMoveOutCostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(pls_InnerMoveOutPriceAmt) AS pls_InnerMoveOutPriceAmt,SUM(pls_InnerMoveOutPriceVatAmt) AS pls_InnerMoveOutPriceVatAmt,SUM(pls_InnerMoveInQty) AS pls_InnerMoveInQty,SUM(pls_InnerMoveInCostAmt) AS pls_InnerMoveInCostAmt,SUM(pls_InnerMoveInCostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(pls_InnerMoveInPriceAmt) AS pls_InnerMoveInPriceAmt,SUM(pls_InnerMoveInPriceVatAmt) AS pls_InnerMoveInPriceVatAmt,SUM(pls_OuterMoveOutQty) AS pls_OuterMoveOutQty,SUM(pls_OuterMoveOutCostAmt) AS pls_OuterMoveOutCostAmt,SUM(pls_OuterMoveOutCostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(pls_OuterMoveOutPriceAmt) AS pls_OuterMoveOutPriceAmt,SUM(pls_OuterMoveOutPriceVatAmt) AS pls_OuterMoveOutPriceVatAmt,SUM(pls_OuterMoveInQty) AS pls_OuterMoveInQty,SUM(pls_OuterMoveInCostAmt) AS pls_OuterMoveInCostAmt,SUM(pls_OuterMoveInCostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(pls_OuterMoveInPriceAmt) AS pls_OuterMoveInPriceAmt,SUM(pls_OuterMoveInPriceVatAmt) AS pls_OuterMoveInPriceVatAmt,SUM(pls_AdjustQty) AS pls_AdjustQty,SUM(pls_AdjustCostAmt) AS pls_AdjustCostAmt,SUM(pls_AdjustCostVatAmt) AS pls_AdjustCostVatAmt,SUM(pls_AdjustPriceAmt) AS pls_AdjustPriceAmt,SUM(pls_AdjustPriceVatAmt) AS pls_AdjustPriceVatAmt,SUM(pls_AdjustPriceCostSumAmt) AS pls_AdjustPriceCostSumAmt,SUM(pls_AdjustPriceCostVatAmt) AS pls_AdjustPriceCostVatAmt,SUM(pls_DisuseQty) AS pls_DisuseQty,SUM(pls_DisuseCostAmt) AS pls_DisuseCostAmt,SUM(pls_DisuseCostVatAmt) AS pls_DisuseCostVatAmt,SUM(pls_DisusePriceAmt) AS pls_DisusePriceAmt,SUM(pls_DisusePriceVatAmt) AS pls_DisusePriceVatAmt,SUM(pls_DisusePriceCostSumAmt) AS pls_DisusePriceCostSumAmt,SUM(pls_DisusePriceCostVatAmt) AS pls_DisusePriceCostVatAmt,SUM(pls_PriceUp) AS pls_PriceUp,SUM(pls_PriceUpVat) AS pls_PriceUpVat,SUM(pls_PriceDown) AS pls_PriceDown,SUM(pls_PriceDownVat) AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyEndTable = "기말";
    [JsonIgnore]
    public static string TBodyEndCol = ",0,0,0,0,0,0,0,0,0,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    public static string TProfitLossSummaryOnlyEndSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,SUM(pls_EndQty) AS pls_EndQty,SUM(pls_EndAvgCost) AS pls_EndAvgCost,SUM(pls_EndCostAmt) AS pls_EndCostAmt,SUM(pls_EndCostVatAmt) AS pls_EndCostVatAmt,SUM(pls_EndPrice) AS pls_EndPrice,SUM(pls_EndPriceCostAmt) AS pls_EndPriceCostAmt,SUM(pls_EndPriceCostVatAmt) AS pls_EndPriceCostVatAmt,SUM(pls_EndPriceAmt) AS pls_EndPriceAmt,SUM(pls_EndPriceVatAmt) AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodySaleTable = "매출";
    [JsonIgnore]
    public const string TBodySaleSpeTable = "특정매출";
    [JsonIgnore]
    public const string TBodySaleLeaTable = "임대매출";
    [JsonIgnore]
    public static string TBodySaleCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_SaleQty,pls_TotalSaleAmt,pls_SaleAmt,pls_SaleVatAmt,pls_SaleProfit,pls_SalePriceProfit,pls_EnurySlip,pls_EnuryEnd,pls_DcAmtManual,pls_DcAmtEvent,pls_DcAmtGoods,pls_DcAmtCoupon,pls_DcAmtPromotion,pls_DcAmtMember,pls_Customer,pls_CustomerGoods,pls_CustomerCategory,pls_CustomerSupplier,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    public static string TSaleSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,SUM(sbd_SaleQty) AS pls_SaleQty,SUM(sbd_TotalSaleAmt) AS pls_TotalSaleAmt,SUM(sbd_SaleAmt) AS pls_SaleAmt,SUM(sbd_SaleVatAmt) AS pls_SaleVatAmt,SUM(sbd_ProfitAmt) AS pls_SaleProfit,SUM(sbd_PreTaxProfitAmt) AS pls_SalePriceProfit,SUM(sbd_EnurySlip) AS pls_EnurySlip,SUM(sbd_EnuryEnd) AS pls_EnuryEnd,SUM(sbd_DcAmtManual) AS pls_DcAmtManual,SUM(sbd_DcAmtEvent) AS pls_DcAmtEvent,SUM(sbd_DcAmtGoods) AS pls_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(sbd_DcAmtMember) AS pls_DcAmtMember,SUM(sbd_SlipCustomer) AS pls_Customer,SUM(sbd_GoodsCustomer) AS pls_CustomerGoods,SUM(sbd_CategoryCustomer) AS pls_CustomerCategory,SUM(sbd_SupplierCustomer) AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TSaleLeaSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,SUM(sbd_SaleQty) AS pls_SaleQty,SUM(sbd_TotalSaleAmt*gdh_ChargeRate)/100 AS pls_TotalSaleAmt,SUM(sbd_SaleAmt*gdh_ChargeRate)/100 AS pls_SaleAmt,SUM(sbd_SaleVatAmt*gdh_ChargeRate)/100 AS pls_SaleVatAmt,SUM(sbd_ProfitAmt*gdh_ChargeRate) AS pls_SaleProfit,SUM(sbd_PreTaxProfitAmt*gdh_ChargeRate) AS pls_SalePriceProfit,SUM(sbd_EnurySlip) AS pls_EnurySlip,SUM(sbd_EnuryEnd) AS pls_EnuryEnd,SUM(sbd_DcAmtManual) AS pls_DcAmtManual,SUM(sbd_DcAmtEvent) AS pls_DcAmtEvent,SUM(sbd_DcAmtGoods) AS pls_DcAmtGoods,SUM(sbd_DcAmtCoupon) AS pls_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS pls_DcAmtPromotion,SUM(sbd_DcAmtMember) AS pls_DcAmtMember,SUM(sbd_SlipCustomer) AS pls_Customer,SUM(sbd_GoodsCustomer) AS pls_CustomerGoods,SUM(sbd_CategoryCustomer) AS pls_CustomerCategory,SUM(sbd_SupplierCustomer) AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyBuyTable = "매입";
    [JsonIgnore]
    public const string TBodyBuySpeTable = "특정매입";
    [JsonIgnore]
    public static string TBodyBuyCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_BuyPriceAmt,pls_BuyPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    public static string TBuySumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,SUM(sd_BuyQty) AS pls_BuyQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_BuyCostAmt,SUM(sd_CostVatAmt) AS pls_BuyCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_BuyPriceAmt,SUM(sd_PriceVatAmt) AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyReturnTable = "반품";
    [JsonIgnore]
    public const string TBodyReturnSpeTable = "특정반품";
    [JsonIgnore]
    public static string TBodyReturnCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_ReturnQty,pls_ReturnCostAmt,pls_ReturnCostVatAmt,pls_ReturnPriceAmt,pls_ReturnPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    public static string TReturnSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,SUM(sd_BuyQty) AS pls_ReturnQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_ReturnCostAmt,SUM(sd_CostVatAmt) AS pls_ReturnCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_ReturnPriceAmt,SUM(sd_PriceVatAmt) AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    [JsonIgnore]
    public const string TBodyInnerMoveOutTable = "대출";
    [JsonIgnore]
    public static string TBodyInnerMoveOutCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_InnerMoveOutQty,pls_InnerMoveOutCostAmt,pls_InnerMoveOutCostVatAmt,pls_InnerMoveOutPriceAmt,pls_InnerMoveOutPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyInnerMoveInTable = "대입";
    [JsonIgnore]
    public static string TBodyInnerMoveInCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_InnerMoveInPriceAmt,pls_InnerMoveInPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyOuterMoveOutTable = "점풀";
    [JsonIgnore]
    public static string TBodyOuterMoveOutCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_OuterMoveOutQty,pls_OuterMoveOutCostAmt,pls_OuterMoveOutCostVatAmt,pls_OuterMoveOutPriceAmt,pls_OuterMoveOutPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyOuterMoveInTable = "점입";
    [JsonIgnore]
    public static string TBodyOuterMoveInCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt,pls_OuterMoveInPriceAmt,pls_OuterMoveInPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyAdjustTable = "재고조정";
    [JsonIgnore]
    public static string TBodyAdjustCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_AdjustQty,pls_AdjustCostAmt,pls_AdjustCostVatAmt,pls_AdjustPriceAmt,pls_AdjustPriceVatAmt,pls_AdjustPriceCostSumAmt,pls_AdjustPriceCostVatAmt,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyDisuseTable = "폐기";
    [JsonIgnore]
    public static string TBodyDisuseCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,pls_DisuseQty,pls_DisuseCostAmt,pls_DisuseCostVatAmt,pls_DisusePriceAmt,pls_DisusePriceVatAmt,pls_DisusePriceCostSumAmt,pls_DisusePriceCostVatAmt,0,0,0,0";

    public override object _Key => (object) new object[3]
    {
      (object) this.pls_YyyyMm,
      (object) this.pls_StoreCode,
      (object) this.pls_GoodsCode
    };

    public int pls_YyyyMm
    {
      get => this._pls_YyyyMm;
      set
      {
        this._pls_YyyyMm = value;
        this.Changed(nameof (pls_YyyyMm));
      }
    }

    public int pls_StoreCode
    {
      get => this._pls_StoreCode;
      set
      {
        this._pls_StoreCode = value;
        this.Changed(nameof (pls_StoreCode));
      }
    }

    public virtual long pls_GoodsCode
    {
      get => this._pls_GoodsCode;
      set
      {
        this._pls_GoodsCode = value;
        this.Changed(nameof (pls_GoodsCode));
      }
    }

    public long pls_SiteID
    {
      get => this._pls_SiteID;
      set
      {
        this._pls_SiteID = value;
        this.Changed(nameof (pls_SiteID));
      }
    }

    public int pls_Supplier
    {
      get => this._pls_Supplier;
      set
      {
        this._pls_Supplier = value;
        this.Changed(nameof (pls_Supplier));
      }
    }

    public int pls_SupplierType
    {
      get => this._pls_SupplierType;
      set
      {
        this._pls_SupplierType = value;
        this.Changed(nameof (pls_SupplierType));
      }
    }

    public int pls_CategoryCode
    {
      get => this._pls_CategoryCode;
      set
      {
        this._pls_CategoryCode = value;
        this.Changed(nameof (pls_CategoryCode));
      }
    }

    public int pls_TaxDiv
    {
      get => this._pls_TaxDiv;
      set
      {
        this._pls_TaxDiv = value;
        this.Changed(nameof (pls_TaxDiv));
        this.Changed("pls_TaxDivDesc");
        this.Changed("pls_IsTax");
      }
    }

    public string pls_TaxDivDesc => this.pls_TaxDiv != 0 ? Enum2StrConverter.ToTaxDiv(this.pls_TaxDiv).ToDescription() : string.Empty;

    public bool pls_IsTax => Enum2StrConverter.ToTaxDiv(this.pls_TaxDiv) == EnumTaxDiv.TAX;

    public int pls_StockUnit
    {
      get => this._pls_StockUnit;
      set
      {
        this._pls_StockUnit = value;
        this.Changed(nameof (pls_StockUnit));
        this.Changed("pls_StockUnitDesc");
        this.Changed("pls_IsStockUnitAmount");
      }
    }

    public string pls_StockUnitDesc => this.pls_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.pls_StockUnit).ToDescription() : string.Empty;

    public bool pls_IsStockUnitAmount => Enum2StrConverter.ToStockUnit(this.pls_StockUnit) == EnumStockUnit.AMOUNT;

    public int pls_SalesUnit
    {
      get => this._pls_SalesUnit;
      set
      {
        this._pls_SalesUnit = value;
        this.Changed(nameof (pls_SalesUnit));
        this.Changed("pls_SalesUnitDesc");
      }
    }

    public string pls_SalesUnitDesc => this.pls_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.pls_SalesUnit).ToDescription() : string.Empty;

    public double pls_BaseQty
    {
      get => this._pls_BaseQty;
      set
      {
        this._pls_BaseQty = value;
        this.Changed(nameof (pls_BaseQty));
      }
    }

    public double pls_BaseAvgCost
    {
      get => this._pls_BaseAvgCost;
      set
      {
        this._pls_BaseAvgCost = value;
        this.Changed(nameof (pls_BaseAvgCost));
      }
    }

    public double pls_BaseCostAmt
    {
      get => this._pls_BaseCostAmt;
      set
      {
        this._pls_BaseCostAmt = value;
        this.Changed(nameof (pls_BaseCostAmt));
        this.Changed("pls_BaseCostSumAmt");
      }
    }

    public double pls_BaseCostVatAmt
    {
      get => this._pls_BaseCostVatAmt;
      set
      {
        this._pls_BaseCostVatAmt = value;
        this.Changed(nameof (pls_BaseCostVatAmt));
        this.Changed("pls_BaseCostSumAmt");
      }
    }

    public double pls_BaseCostSumAmt => this.pls_BaseCostAmt + this.pls_BaseCostVatAmt;

    public double pls_BasePrice
    {
      get => this._pls_BasePrice;
      set
      {
        this._pls_BasePrice = value;
        this.Changed(nameof (pls_BasePrice));
      }
    }

    public double pls_BasePriceAmt
    {
      get => this._pls_BasePriceAmt;
      set
      {
        this._pls_BasePriceAmt = value;
        this.Changed(nameof (pls_BasePriceAmt));
        this.Changed("pls_BasePriceTaxFreeAmt");
      }
    }

    public double pls_BasePriceVatAmt
    {
      get => this._pls_BasePriceVatAmt;
      set
      {
        this._pls_BasePriceVatAmt = value;
        this.Changed(nameof (pls_BasePriceVatAmt));
        this.Changed("pls_BasePriceTaxFreeAmt");
      }
    }

    public double pls_BasePriceTaxFreeAmt => this.pls_BasePriceAmt - this.pls_BasePriceVatAmt;

    public double pls_BasePriceCostAmt
    {
      get => this._pls_BasePriceCostAmt;
      set
      {
        this._pls_BasePriceCostAmt = value;
        this.Changed(nameof (pls_BasePriceCostAmt));
        this.Changed("pls_BasePriceCostSumAmt");
      }
    }

    public double pls_BasePriceCostVatAmt
    {
      get => this._pls_BasePriceCostVatAmt;
      set
      {
        this._pls_BasePriceCostVatAmt = value;
        this.Changed(nameof (pls_BasePriceCostVatAmt));
        this.Changed("pls_BasePriceCostSumAmt");
      }
    }

    public double pls_BasePriceCostSumAmt => this.pls_BasePriceCostAmt + this.pls_BasePriceCostVatAmt;

    public double pls_EndQty
    {
      get => this._pls_EndQty;
      set
      {
        this._pls_EndQty = value;
        this.Changed(nameof (pls_EndQty));
      }
    }

    public double pls_EndAvgCost
    {
      get => this._pls_EndAvgCost;
      set
      {
        this._pls_EndAvgCost = value;
        this.Changed(nameof (pls_EndAvgCost));
      }
    }

    public void CalcEndAvgCost() => this.pls_EndAvgCost = CalcHelper.ToArgCost3(Math.Abs(this.pls_BaseCostAmt) + Math.Abs(this.pls_BuyCostAmt + this.pls_InnerMoveOutCostAmt + this.pls_InnerMoveInCostAmt + this.pls_OuterMoveInCostAmt), Math.Abs(this.pls_BaseCostAmt.IsZero() ? 0.0 : this.pls_BaseQty) + Math.Abs(this.pls_BuyQty + this.pls_InnerMoveInQty + this.pls_OuterMoveInQty));

    public double pls_EndCostAmt
    {
      get => this._pls_EndCostAmt;
      set
      {
        this._pls_EndCostAmt = value;
        this.Changed(nameof (pls_EndCostAmt));
        this.Changed("pls_EndCostSumAmt");
      }
    }

    public double pls_EndCostVatAmt
    {
      get => this._pls_EndCostVatAmt;
      set
      {
        this._pls_EndCostVatAmt = value;
        this.Changed(nameof (pls_EndCostVatAmt));
        this.Changed("pls_EndCostSumAmt");
      }
    }

    public double pls_EndCostSumAmt => this.pls_EndCostAmt + this.pls_EndCostVatAmt;

    public double pls_EndPrice
    {
      get => this._pls_EndPrice;
      set
      {
        this._pls_EndPrice = value;
        this.Changed(nameof (pls_EndPrice));
      }
    }

    public double pls_EndPriceAmt
    {
      get => this._pls_EndPriceAmt;
      set
      {
        this._pls_EndPriceAmt = value;
        this.Changed(nameof (pls_EndPriceAmt));
        this.Changed("pls_EndPriceTaxFreeAmt");
      }
    }

    public void CalcEndPriceAmt() => this.pls_EndPriceAmt = this.pls_EndPrice * this.pls_EndQty;

    public double pls_EndPriceVatAmt
    {
      get => this._pls_EndPriceVatAmt;
      set
      {
        this._pls_EndPriceVatAmt = value;
        this.Changed(nameof (pls_EndPriceVatAmt));
        this.Changed("pls_EndPriceTaxFreeAmt");
      }
    }

    public double pls_EndPriceTaxFreeAmt => this.pls_EndPriceAmt - this.pls_EndPriceVatAmt;

    public double pls_EndPriceCostAmt
    {
      get => this._pls_EndPriceCostAmt;
      set
      {
        this._pls_EndPriceCostAmt = value;
        this.Changed(nameof (pls_EndPriceCostAmt));
        this.Changed("pls_EndPriceCostSumAmt");
      }
    }

    public void CalcEndPriceCostAmt() => this.pls_EndPriceCostAmt = CalcHelper.CalcDoubleToFormatDouble(this.pls_EndPriceAmt * this.CalcEndPriceCostRate());

    public double pls_EndPriceCostVatAmt
    {
      get => this._pls_EndPriceCostVatAmt;
      set
      {
        this._pls_EndPriceCostVatAmt = value;
        this.Changed(nameof (pls_EndPriceCostVatAmt));
        this.Changed("pls_EndPriceCostSumAmt");
      }
    }

    public double pls_EndPriceCostSumAmt => this.pls_EndPriceCostAmt + this.pls_EndPriceCostVatAmt;

    public double CalcEndPriceCostRate()
    {
      double pVal1 = this.pls_BasePriceAmt + this.pls_BuyPriceAmt - this.pls_ReturnPriceAmt + this.pls_InnerMoveInPriceAmt - this.pls_InnerMoveOutPriceAmt + this.pls_OuterMoveInPriceAmt - this.pls_OuterMoveOutPriceAmt;
      return pVal1.IsZero() ? 0.0 : (this.pls_BasePriceCostAmt + this.pls_BuyCostAmt - this.pls_ReturnCostAmt + this.pls_InnerMoveInCostAmt - this.pls_InnerMoveOutCostAmt + this.pls_OuterMoveInCostAmt - this.pls_OuterMoveOutCostAmt) / pVal1;
    }

    public double pls_SaleQty
    {
      get => this._pls_SaleQty;
      set
      {
        this._pls_SaleQty = value;
        this.Changed(nameof (pls_SaleQty));
      }
    }

    public double pls_TotalSaleAmt
    {
      get => this._pls_TotalSaleAmt;
      set
      {
        this._pls_TotalSaleAmt = value;
        this.Changed(nameof (pls_TotalSaleAmt));
      }
    }

    public double pls_SaleAmt
    {
      get => this._pls_SaleAmt;
      set
      {
        this._pls_SaleAmt = value;
        this.Changed(nameof (pls_SaleAmt));
        this.Changed("pls_SaleTaxFreeAmt");
        this.Changed("pls_ProfitRule");
        this.Changed("pls_PriceProfitRule");
      }
    }

    public double pls_SaleVatAmt
    {
      get => this._pls_SaleVatAmt;
      set
      {
        this._pls_SaleVatAmt = value;
        this.Changed(nameof (pls_SaleVatAmt));
        this.Changed("pls_SaleTaxFreeAmt");
        this.Changed("pls_ProfitRule");
        this.Changed("pls_PriceProfitRule");
      }
    }

    public double pls_SaleTaxFreeAmt => this.pls_SaleAmt - this.pls_SaleVatAmt;

    public double pls_SaleProfit
    {
      get => this._pls_SaleProfit;
      set
      {
        this._pls_SaleProfit = value;
        this.Changed(nameof (pls_SaleProfit));
        this.Changed("pls_ProfitRule");
      }
    }

    public void CalcSaleProfit() => this.pls_SaleProfit = this.pls_SaleTaxFreeAmt - this.CalcBuyTaxFreeAmount();

    public double pls_ProfitRule => CalcHelper.ToSaleProfitMargin(this.pls_SaleProfit, this.pls_SaleTaxFreeAmt);

    public double pls_SalePriceProfit
    {
      get => this._pls_SalePriceProfit;
      set
      {
        this._pls_SalePriceProfit = value;
        this.Changed(nameof (pls_SalePriceProfit));
        this.Changed("pls_PriceProfitRule");
      }
    }

    public void CalcSalePriceProfit() => this.pls_SalePriceProfit = this.pls_SaleTaxFreeAmt - this.CalcBuyPriceTaxFreeAmount();

    public double pls_PriceProfitRule => CalcHelper.ToSaleProfitMargin(this.pls_SalePriceProfit, this.pls_SaleTaxFreeAmt);

    public double pls_EnurySlip
    {
      get => this._pls_EnurySlip;
      set
      {
        this._pls_EnurySlip = value;
        this.Changed(nameof (pls_EnurySlip));
      }
    }

    public double pls_EnuryEnd
    {
      get => this._pls_EnuryEnd;
      set
      {
        this._pls_EnuryEnd = value;
        this.Changed(nameof (pls_EnuryEnd));
      }
    }

    public double pls_DcAmtManual
    {
      get => this._pls_DcAmtManual;
      set
      {
        this._pls_DcAmtManual = value;
        this.Changed(nameof (pls_DcAmtManual));
      }
    }

    public double pls_DcAmtEvent
    {
      get => this._pls_DcAmtEvent;
      set
      {
        this._pls_DcAmtEvent = value;
        this.Changed(nameof (pls_DcAmtEvent));
      }
    }

    public double pls_DcAmtGoods
    {
      get => this._pls_DcAmtGoods;
      set
      {
        this._pls_DcAmtGoods = value;
        this.Changed(nameof (pls_DcAmtGoods));
      }
    }

    public double pls_DcAmtCoupon
    {
      get => this._pls_DcAmtCoupon;
      set
      {
        this._pls_DcAmtCoupon = value;
        this.Changed(nameof (pls_DcAmtCoupon));
      }
    }

    public double pls_DcAmtPromotion
    {
      get => this._pls_DcAmtPromotion;
      set
      {
        this._pls_DcAmtPromotion = value;
        this.Changed(nameof (pls_DcAmtPromotion));
      }
    }

    public double pls_DcAmtMember
    {
      get => this._pls_DcAmtMember;
      set
      {
        this._pls_DcAmtMember = value;
        this.Changed(nameof (pls_DcAmtMember));
      }
    }

    public double pls_Customer
    {
      get => this._pls_Customer;
      set
      {
        this._pls_Customer = value;
        this.Changed(nameof (pls_Customer));
      }
    }

    public double pls_CustomerGoods
    {
      get => this._pls_CustomerGoods;
      set
      {
        this._pls_CustomerGoods = value;
        this.Changed(nameof (pls_CustomerGoods));
      }
    }

    public double pls_CustomerCategory
    {
      get => this._pls_CustomerCategory;
      set
      {
        this._pls_CustomerCategory = value;
        this.Changed(nameof (pls_CustomerCategory));
      }
    }

    public double pls_CustomerSupplier
    {
      get => this._pls_CustomerSupplier;
      set
      {
        this._pls_CustomerSupplier = value;
        this.Changed(nameof (pls_CustomerSupplier));
      }
    }

    public double pls_BuyQty
    {
      get => this._pls_BuyQty;
      set
      {
        this._pls_BuyQty = value;
        this.Changed(nameof (pls_BuyQty));
      }
    }

    public double pls_BuyCostAmt
    {
      get => this._pls_BuyCostAmt;
      set
      {
        this._pls_BuyCostAmt = value;
        this.Changed(nameof (pls_BuyCostAmt));
        this.Changed("pls_BuyCostSumAmt");
        this.Changed("pls_BuyProfitRule");
      }
    }

    public double pls_BuyCostVatAmt
    {
      get => this._pls_BuyCostVatAmt;
      set
      {
        this._pls_BuyCostVatAmt = value;
        this.Changed(nameof (pls_BuyCostVatAmt));
        this.Changed("pls_BuyCostSumAmt");
      }
    }

    public double pls_BuyCostSumAmt => this.pls_BuyCostAmt + this.pls_BuyCostVatAmt;

    public double pls_BuyPriceAmt
    {
      get => this._pls_BuyPriceAmt;
      set
      {
        this._pls_BuyPriceAmt = value;
        this.Changed(nameof (pls_BuyPriceAmt));
        this.Changed("pls_BuyPriceTaxFreeAmt");
        this.Changed("pls_BuyProfitRule");
      }
    }

    public double pls_BuyPriceVatAmt
    {
      get => this._pls_BuyPriceVatAmt;
      set
      {
        this._pls_BuyPriceVatAmt = value;
        this.Changed(nameof (pls_BuyPriceVatAmt));
        this.Changed("pls_BuyPriceTaxFreeAmt");
      }
    }

    public double pls_BuyPriceTaxFreeAmt => this.pls_BuyPriceAmt - this.pls_BuyPriceVatAmt;

    public double pls_BuyProfitRule => CalcHelper.ToBuyProfitMargin(this.pls_BuyCostAmt, this.pls_BuyPriceAmt);

    public double pls_ReturnQty
    {
      get => this._pls_ReturnQty;
      set
      {
        this._pls_ReturnQty = value;
        this.Changed(nameof (pls_ReturnQty));
      }
    }

    public double pls_ReturnCostAmt
    {
      get => this._pls_ReturnCostAmt;
      set
      {
        this._pls_ReturnCostAmt = value;
        this.Changed(nameof (pls_ReturnCostAmt));
        this.Changed("pls_ReturnCostSumAmt");
      }
    }

    public double pls_ReturnCostVatAmt
    {
      get => this._pls_ReturnCostVatAmt;
      set
      {
        this._pls_ReturnCostVatAmt = value;
        this.Changed(nameof (pls_ReturnCostVatAmt));
        this.Changed("pls_ReturnCostSumAmt");
      }
    }

    public double pls_ReturnCostSumAmt => this.pls_ReturnCostAmt + this.pls_ReturnCostVatAmt;

    public double pls_ReturnPriceAmt
    {
      get => this._pls_ReturnPriceAmt;
      set
      {
        this._pls_ReturnPriceAmt = value;
        this.Changed(nameof (pls_ReturnPriceAmt));
        this.Changed("pls_ReturnPriceTaxFreeAmt");
      }
    }

    public double pls_ReturnPriceVatAmt
    {
      get => this._pls_ReturnPriceVatAmt;
      set
      {
        this._pls_ReturnPriceVatAmt = value;
        this.Changed(nameof (pls_ReturnPriceVatAmt));
        this.Changed("pls_ReturnPriceTaxFreeAmt");
      }
    }

    public double pls_ReturnPriceTaxFreeAmt => this.pls_ReturnPriceAmt - this.pls_ReturnPriceVatAmt;

    public double pls_InnerMoveOutQty
    {
      get => this._pls_InnerMoveOutQty;
      set
      {
        this._pls_InnerMoveOutQty = value;
        this.Changed(nameof (pls_InnerMoveOutQty));
      }
    }

    public double pls_InnerMoveOutCostAmt
    {
      get => this._pls_InnerMoveOutCostAmt;
      set
      {
        this._pls_InnerMoveOutCostAmt = value;
        this.Changed(nameof (pls_InnerMoveOutCostAmt));
        this.Changed("pls_InnerMoveOutCostSumAmt");
      }
    }

    public double pls_InnerMoveOutCostVatAmt
    {
      get => this._pls_InnerMoveOutCostVatAmt;
      set
      {
        this._pls_InnerMoveOutCostVatAmt = value;
        this.Changed(nameof (pls_InnerMoveOutCostVatAmt));
        this.Changed("pls_InnerMoveOutCostSumAmt");
      }
    }

    public double pls_InnerMoveOutCostSumAmt => this.pls_InnerMoveOutCostAmt + this.pls_InnerMoveOutCostVatAmt;

    public double pls_InnerMoveOutPriceAmt
    {
      get => this._pls_InnerMoveOutPriceAmt;
      set
      {
        this._pls_InnerMoveOutPriceAmt = value;
        this.Changed(nameof (pls_InnerMoveOutPriceAmt));
        this.Changed("pls_InnerMoveOutPriceTaxFreeAmt");
      }
    }

    public double pls_InnerMoveOutPriceVatAmt
    {
      get => this._pls_InnerMoveOutPriceVatAmt;
      set
      {
        this._pls_InnerMoveOutPriceVatAmt = value;
        this.Changed(nameof (pls_InnerMoveOutPriceVatAmt));
        this.Changed("pls_InnerMoveOutPriceTaxFreeAmt");
      }
    }

    public double pls_InnerMoveOutPriceTaxFreeAmt => this.pls_InnerMoveOutPriceAmt - this.pls_InnerMoveOutPriceVatAmt;

    public double pls_InnerMoveInQty
    {
      get => this._pls_InnerMoveInQty;
      set
      {
        this._pls_InnerMoveInQty = value;
        this.Changed(nameof (pls_InnerMoveInQty));
      }
    }

    public double pls_InnerMoveInCostAmt
    {
      get => this._pls_InnerMoveInCostAmt;
      set
      {
        this._pls_InnerMoveInCostAmt = value;
        this.Changed(nameof (pls_InnerMoveInCostAmt));
        this.Changed("pls_InnerMoveInCostSumAmt");
      }
    }

    public double pls_InnerMoveInCostVatAmt
    {
      get => this._pls_InnerMoveInCostVatAmt;
      set
      {
        this._pls_InnerMoveInCostVatAmt = value;
        this.Changed(nameof (pls_InnerMoveInCostVatAmt));
        this.Changed("pls_InnerMoveInCostSumAmt");
      }
    }

    public double pls_InnerMoveInCostSumAmt => this.pls_InnerMoveInCostAmt + this.pls_InnerMoveInCostVatAmt;

    public double pls_InnerMoveInPriceAmt
    {
      get => this._pls_InnerMoveInPriceAmt;
      set
      {
        this._pls_InnerMoveInPriceAmt = value;
        this.Changed(nameof (pls_InnerMoveInPriceAmt));
        this.Changed("pls_InnerMoveInPriceTaxFreeAmt");
      }
    }

    public double pls_InnerMoveInPriceVatAmt
    {
      get => this._pls_InnerMoveInPriceVatAmt;
      set
      {
        this._pls_InnerMoveInPriceVatAmt = value;
        this.Changed(nameof (pls_InnerMoveInPriceVatAmt));
        this.Changed("pls_InnerMoveInPriceTaxFreeAmt");
      }
    }

    public double pls_InnerMoveInPriceTaxFreeAmt => this.pls_InnerMoveInPriceAmt - this.pls_InnerMoveInPriceVatAmt;

    public double pls_OuterMoveOutQty
    {
      get => this._pls_OuterMoveOutQty;
      set
      {
        this._pls_OuterMoveOutQty = value;
        this.Changed(nameof (pls_OuterMoveOutQty));
      }
    }

    public double pls_OuterMoveOutCostAmt
    {
      get => this._pls_OuterMoveOutCostAmt;
      set
      {
        this._pls_OuterMoveOutCostAmt = value;
        this.Changed(nameof (pls_OuterMoveOutCostAmt));
        this.Changed("pls_OuterMoveOutCostSumAmt");
      }
    }

    public double pls_OuterMoveOutCostVatAmt
    {
      get => this._pls_OuterMoveOutCostVatAmt;
      set
      {
        this._pls_OuterMoveOutCostVatAmt = value;
        this.Changed(nameof (pls_OuterMoveOutCostVatAmt));
        this.Changed("pls_OuterMoveOutCostSumAmt");
      }
    }

    public double pls_OuterMoveOutCostSumAmt => this.pls_OuterMoveOutCostAmt + this.pls_OuterMoveOutCostVatAmt;

    public double pls_OuterMoveOutPriceAmt
    {
      get => this._pls_OuterMoveOutPriceAmt;
      set
      {
        this._pls_OuterMoveOutPriceAmt = value;
        this.Changed(nameof (pls_OuterMoveOutPriceAmt));
        this.Changed("pls_OuterMoveOutPriceTaxFreeAmt");
      }
    }

    public double pls_OuterMoveOutPriceVatAmt
    {
      get => this._pls_OuterMoveOutPriceVatAmt;
      set
      {
        this._pls_OuterMoveOutPriceVatAmt = value;
        this.Changed(nameof (pls_OuterMoveOutPriceVatAmt));
        this.Changed("pls_OuterMoveOutPriceTaxFreeAmt");
      }
    }

    public double pls_OuterMoveOutPriceTaxFreeAmt => this.pls_OuterMoveOutPriceAmt - this.pls_OuterMoveOutPriceVatAmt;

    public double pls_OuterMoveInQty
    {
      get => this._pls_OuterMoveInQty;
      set
      {
        this._pls_OuterMoveInQty = value;
        this.Changed(nameof (pls_OuterMoveInQty));
      }
    }

    public double pls_OuterMoveInCostAmt
    {
      get => this._pls_OuterMoveInCostAmt;
      set
      {
        this._pls_OuterMoveInCostAmt = value;
        this.Changed(nameof (pls_OuterMoveInCostAmt));
        this.Changed("pls_OuterMoveInCostSumAmt");
      }
    }

    public double pls_OuterMoveInCostVatAmt
    {
      get => this._pls_OuterMoveInCostVatAmt;
      set
      {
        this._pls_OuterMoveInCostVatAmt = value;
        this.Changed(nameof (pls_OuterMoveInCostVatAmt));
        this.Changed("pls_OuterMoveInCostSumAmt");
      }
    }

    public double pls_OuterMoveInCostSumAmt => this.pls_OuterMoveInCostAmt + this.pls_OuterMoveInCostVatAmt;

    public double pls_OuterMoveInPriceAmt
    {
      get => this._pls_OuterMoveInPriceAmt;
      set
      {
        this._pls_OuterMoveInPriceAmt = value;
        this.Changed(nameof (pls_OuterMoveInPriceAmt));
        this.Changed("pls_OuterMoveInPriceTaxFreeAmt");
      }
    }

    public double pls_OuterMoveInPriceVatAmt
    {
      get => this._pls_OuterMoveInPriceVatAmt;
      set
      {
        this._pls_OuterMoveInPriceVatAmt = value;
        this.Changed(nameof (pls_OuterMoveInPriceVatAmt));
        this.Changed("pls_OuterMoveInPriceTaxFreeAmt");
      }
    }

    public double pls_OuterMoveInPriceTaxFreeAmt => this.pls_OuterMoveInPriceAmt - this.pls_OuterMoveInPriceVatAmt;

    public double pls_AdjustQty
    {
      get => this._pls_AdjustQty;
      set
      {
        this._pls_AdjustQty = value;
        this.Changed(nameof (pls_AdjustQty));
      }
    }

    public double pls_AdjustCostAmt
    {
      get => this._pls_AdjustCostAmt;
      set
      {
        this._pls_AdjustCostAmt = value;
        this.Changed(nameof (pls_AdjustCostAmt));
        this.Changed("pls_AdjustCostSumAmt");
      }
    }

    public double pls_AdjustCostVatAmt
    {
      get => this._pls_AdjustCostVatAmt;
      set
      {
        this._pls_AdjustCostVatAmt = value;
        this.Changed(nameof (pls_AdjustCostVatAmt));
        this.Changed("pls_AdjustCostSumAmt");
      }
    }

    public double pls_AdjustCostSumAmt => this.pls_AdjustCostAmt + this.pls_AdjustCostVatAmt;

    public double pls_AdjustPriceAmt
    {
      get => this._pls_AdjustPriceAmt;
      set
      {
        this._pls_AdjustPriceAmt = value;
        this.Changed(nameof (pls_AdjustPriceAmt));
        this.Changed("pls_AdjustPriceTaxFreeAmt");
      }
    }

    public double pls_AdjustPriceVatAmt
    {
      get => this._pls_AdjustPriceVatAmt;
      set
      {
        this._pls_AdjustPriceVatAmt = value;
        this.Changed(nameof (pls_AdjustPriceVatAmt));
        this.Changed("pls_AdjustPriceTaxFreeAmt");
      }
    }

    public double pls_AdjustPriceTaxFreeAmt => this.pls_AdjustPriceAmt - this.pls_AdjustPriceVatAmt;

    public double pls_AdjustPriceCostSumAmt
    {
      get => this._pls_AdjustPriceCostSumAmt;
      set
      {
        this._pls_AdjustPriceCostSumAmt = value;
        this.Changed(nameof (pls_AdjustPriceCostSumAmt));
        this.Changed("pls_AdjustPriceCostAmt");
      }
    }

    public double pls_AdjustPriceCostVatAmt
    {
      get => this._pls_AdjustPriceCostVatAmt;
      set
      {
        this._pls_AdjustPriceCostVatAmt = value;
        this.Changed(nameof (pls_AdjustPriceCostVatAmt));
        this.Changed("pls_AdjustPriceCostAmt");
      }
    }

    public double pls_AdjustPriceCostAmt => this.pls_AdjustPriceCostSumAmt - this.pls_AdjustPriceCostVatAmt;

    public double pls_DisuseQty
    {
      get => this._pls_DisuseQty;
      set
      {
        this._pls_DisuseQty = value;
        this.Changed(nameof (pls_DisuseQty));
      }
    }

    public double pls_DisuseCostAmt
    {
      get => this._pls_DisuseCostAmt;
      set
      {
        this._pls_DisuseCostAmt = value;
        this.Changed(nameof (pls_DisuseCostAmt));
        this.Changed("pls_DisuseCostSumAmt");
      }
    }

    public double pls_DisuseCostVatAmt
    {
      get => this._pls_DisuseCostVatAmt;
      set
      {
        this._pls_DisuseCostVatAmt = value;
        this.Changed(nameof (pls_DisuseCostVatAmt));
        this.Changed("pls_DisuseCostSumAmt");
      }
    }

    public double pls_DisuseCostSumAmt => this.pls_DisuseCostAmt + this.pls_DisuseCostVatAmt;

    public double pls_DisusePriceAmt
    {
      get => this._pls_DisusePriceAmt;
      set
      {
        this._pls_DisusePriceAmt = value;
        this.Changed(nameof (pls_DisusePriceAmt));
        this.Changed("pls_DisusePriceTaxFreeAmt");
      }
    }

    public double pls_DisusePriceVatAmt
    {
      get => this._pls_DisusePriceVatAmt;
      set
      {
        this._pls_DisusePriceVatAmt = value;
        this.Changed(nameof (pls_DisusePriceVatAmt));
        this.Changed("pls_DisusePriceTaxFreeAmt");
      }
    }

    public double pls_DisusePriceTaxFreeAmt => this.pls_DisusePriceAmt - this.pls_DisusePriceVatAmt;

    public double pls_DisusePriceCostSumAmt
    {
      get => this._pls_DisusePriceCostSumAmt;
      set
      {
        this._pls_DisusePriceCostSumAmt = value;
        this.Changed(nameof (pls_DisusePriceCostSumAmt));
        this.Changed("pls_DisusePriceCostAmt");
      }
    }

    public double pls_DisusePriceCostVatAmt
    {
      get => this._pls_DisusePriceCostVatAmt;
      set
      {
        this._pls_DisusePriceCostVatAmt = value;
        this.Changed(nameof (pls_DisusePriceCostVatAmt));
        this.Changed("pls_DisusePriceCostAmt");
      }
    }

    public double pls_DisusePriceCostAmt => this.pls_DisusePriceCostSumAmt - this.pls_DisusePriceCostVatAmt;

    public double pls_PriceUp
    {
      get => this._pls_PriceUp;
      set
      {
        this._pls_PriceUp = value;
        this.Changed(nameof (pls_PriceUp));
        this.Changed("pls_PriceUpPriceCostAmt");
      }
    }

    public double pls_PriceUpVat
    {
      get => this._pls_PriceUpVat;
      set
      {
        this._pls_PriceUpVat = value;
        this.Changed(nameof (pls_PriceUpVat));
        this.Changed("pls_PriceUpPriceCostAmt");
      }
    }

    public double pls_PriceUpPriceCostAmt => this.pls_PriceUp - this.pls_PriceUpVat;

    public double pls_PriceDown
    {
      get => this._pls_PriceDown;
      set
      {
        this._pls_PriceDown = value;
        this.Changed(nameof (pls_PriceDown));
        this.Changed("pls_PriceDownPriceCostAmt");
      }
    }

    public double pls_PriceDownVat
    {
      get => this._pls_PriceDownVat;
      set
      {
        this._pls_PriceDownVat = value;
        this.Changed(nameof (pls_PriceDownVat));
        this.Changed("pls_PriceDownPriceCostAmt");
      }
    }

    public double pls_PriceDownPriceCostAmt => this.pls_PriceDown - this.pls_PriceDownVat;

    public void CalcSalePriceUpDown()
    {
      this.pls_PriceUp = this.pls_PriceDown = 0.0;
      if (this.pls_IsStockUnitAmount)
        return;
      double num = this.pls_EndPriceAmt - (this.pls_BasePriceAmt + this.pls_BuyPriceAmt - this.pls_ReturnPriceAmt + this.pls_InnerMoveInPriceAmt - this.pls_InnerMoveOutPriceAmt + this.pls_OuterMoveInPriceAmt - this.pls_OuterMoveOutPriceAmt + this.pls_AdjustPriceAmt - this.pls_SaleAmt);
      if (num > 0.0)
        this.pls_PriceUp = num;
      else
        this.pls_PriceDown = num * -1.0;
      if (this.pls_IsTax)
      {
        this.pls_PriceUpVat = this.pls_PriceUp.ToPriceVat();
        this.pls_PriceDownVat = this.pls_PriceDown.ToPriceVat();
      }
      else
      {
        this.pls_PriceUpVat = 0.0;
        this.pls_PriceDownVat = 0.0;
      }
    }

    public TProfitLossSummary() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pls_YyyyMm", new TTableColumn()
      {
        tc_orgin_name = "pls_YyyyMm",
        tc_trans_name = "년월"
      });
      columnInfo.Add("pls_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "pls_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("pls_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "pls_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("pls_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pls_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pls_Supplier", new TTableColumn()
      {
        tc_orgin_name = "pls_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("pls_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "pls_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("pls_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "pls_CategoryCode",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("pls_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "pls_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51
      });
      columnInfo.Add("pls_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "pls_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("pls_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "pls_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("pls_BaseQty", new TTableColumn()
      {
        tc_orgin_name = "pls_BaseQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_BaseAvgCost", new TTableColumn()
      {
        tc_orgin_name = "pls_BaseAvgCost",
        tc_trans_name = "평균원가"
      });
      columnInfo.Add("pls_BaseCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BaseCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_BaseCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BaseCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_BasePriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BasePriceAmt",
        tc_trans_name = "금액"
      });
      columnInfo.Add("pls_BasePriceCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BasePriceCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_BasePriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BasePriceCostVatAmt",
        tc_trans_name = "부가세액"
      });
      columnInfo.Add("pls_BasePrice", new TTableColumn()
      {
        tc_orgin_name = "pls_BasePrice",
        tc_trans_name = "매가"
      });
      columnInfo.Add("pls_BasePriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BasePriceVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_EndQty", new TTableColumn()
      {
        tc_orgin_name = "pls_EndQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_EndAvgCost", new TTableColumn()
      {
        tc_orgin_name = "pls_EndAvgCost",
        tc_trans_name = "평균원가"
      });
      columnInfo.Add("pls_EndCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndCostAmt",
        tc_trans_name = "원가금액"
      });
      columnInfo.Add("pls_EndCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_EndPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndPriceAmt",
        tc_trans_name = "금액"
      });
      columnInfo.Add("pls_EndPriceCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndPriceCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_EndPriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndPriceCostVatAmt",
        tc_trans_name = "부가세액"
      });
      columnInfo.Add("pls_EndPrice", new TTableColumn()
      {
        tc_orgin_name = "pls_EndPrice",
        tc_trans_name = "매가"
      });
      columnInfo.Add("pls_EndPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_EndPriceVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_TotalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_TotalSaleAmt",
        tc_trans_name = "총매출액"
      });
      columnInfo.Add("pls_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleAmt",
        tc_trans_name = "매출액"
      });
      columnInfo.Add("pls_SaleVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_SaleProfit", new TTableColumn()
      {
        tc_orgin_name = "pls_SaleProfit",
        tc_trans_name = "세제외이익",
        tc_col_hint = "[세제외이익 = 세제외매출 - 매출원가]"
      });
      columnInfo.Add("pls_SalePriceProfit", new TTableColumn()
      {
        tc_orgin_name = "pls_SalePriceProfit",
        tc_trans_name = "세제외이익",
        tc_col_hint = "[세제외이익 = 세제외매출 - 매출원가]"
      });
      columnInfo.Add("pls_EnurySlip", new TTableColumn()
      {
        tc_orgin_name = "pls_EnurySlip",
        tc_trans_name = "에누리"
      });
      columnInfo.Add("pls_EnuryEnd", new TTableColumn()
      {
        tc_orgin_name = "pls_EnuryEnd",
        tc_trans_name = "끝전에누리"
      });
      columnInfo.Add("pls_DcAmtManual", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtManual",
        tc_trans_name = "단품할인금액"
      });
      columnInfo.Add("pls_DcAmtEvent", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtEvent",
        tc_trans_name = "이벤트할인금액"
      });
      columnInfo.Add("pls_DcAmtGoods", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtGoods",
        tc_trans_name = "단품행사할인금액"
      });
      columnInfo.Add("pls_DcAmtCoupon", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtCoupon",
        tc_trans_name = "쿠폰할인금액"
      });
      columnInfo.Add("pls_DcAmtPromotion", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtPromotion",
        tc_trans_name = "프로모션할인금액"
      });
      columnInfo.Add("pls_DcAmtMember", new TTableColumn()
      {
        tc_orgin_name = "pls_DcAmtMember",
        tc_trans_name = "회원할인금액"
      });
      columnInfo.Add("pls_Customer", new TTableColumn()
      {
        tc_orgin_name = "pls_Customer",
        tc_trans_name = "고객수"
      });
      columnInfo.Add("pls_CustomerGoods", new TTableColumn()
      {
        tc_orgin_name = "pls_CustomerGoods",
        tc_trans_name = "상품객수"
      });
      columnInfo.Add("pls_CustomerCategory", new TTableColumn()
      {
        tc_orgin_name = "pls_CustomerCategory",
        tc_trans_name = "소분류객수"
      });
      columnInfo.Add("pls_CustomerSupplier", new TTableColumn()
      {
        tc_orgin_name = "pls_CustomerSupplier",
        tc_trans_name = "업체객수"
      });
      columnInfo.Add("pls_BuyQty", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_BuyCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_BuyCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_BuyPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyPriceAmt",
        tc_trans_name = "매입매가계"
      });
      columnInfo.Add("pls_BuyPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_BuyPriceVatAmt",
        tc_trans_name = "매입매가부가세"
      });
      columnInfo.Add("pls_ReturnQty", new TTableColumn()
      {
        tc_orgin_name = "pls_ReturnQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_ReturnCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_ReturnCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_ReturnCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_ReturnCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_ReturnPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_ReturnPriceAmt",
        tc_trans_name = "반품매가계"
      });
      columnInfo.Add("pls_ReturnPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_ReturnPriceVatAmt",
        tc_trans_name = "반품매가부가세"
      });
      columnInfo.Add("pls_InnerMoveOutQty", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveOutQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_InnerMoveOutCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveOutCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_InnerMoveOutCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveOutCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_InnerMoveOutPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveOutPriceAmt",
        tc_trans_name = "대출매가계"
      });
      columnInfo.Add("pls_InnerMoveOutPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveOutPriceVatAmt",
        tc_trans_name = "대출매가부가세"
      });
      columnInfo.Add("pls_InnerMoveInQty", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveInQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_InnerMoveInCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveInCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_InnerMoveInCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveInCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_InnerMoveInPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveInPriceAmt",
        tc_trans_name = "대입매가계"
      });
      columnInfo.Add("pls_InnerMoveInPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_InnerMoveInPriceVatAmt",
        tc_trans_name = "대입매가부가세"
      });
      columnInfo.Add("pls_OuterMoveOutQty", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveOutQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_OuterMoveOutCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveOutCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_OuterMoveOutCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveOutCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_OuterMoveOutPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveOutPriceAmt",
        tc_trans_name = "점출매가계"
      });
      columnInfo.Add("pls_OuterMoveOutPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveOutPriceVatAmt",
        tc_trans_name = "점출매가부가세"
      });
      columnInfo.Add("pls_OuterMoveInQty", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveInQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_OuterMoveInCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveInCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_OuterMoveInCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveInCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_OuterMoveInPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveInPriceAmt",
        tc_trans_name = "점입매가계"
      });
      columnInfo.Add("pls_OuterMoveInPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_OuterMoveInPriceVatAmt",
        tc_trans_name = "점입매가부가세"
      });
      columnInfo.Add("pls_AdjustQty", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_AdjustCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_AdjustCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_AdjustPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustPriceAmt",
        tc_trans_name = "조정매가계"
      });
      columnInfo.Add("pls_AdjustPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustPriceVatAmt",
        tc_trans_name = "조정매가부가세"
      });
      columnInfo.Add("pls_AdjustPriceCostSumAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustPriceCostSumAmt",
        tc_trans_name = "조정매가금액"
      });
      columnInfo.Add("pls_AdjustPriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_AdjustPriceCostVatAmt",
        tc_trans_name = "조정매가부가세"
      });
      columnInfo.Add("pls_DisuseQty", new TTableColumn()
      {
        tc_orgin_name = "pls_DisuseQty",
        tc_trans_name = "수량"
      });
      columnInfo.Add("pls_DisuseCostAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisuseCostAmt",
        tc_trans_name = "세제외금액"
      });
      columnInfo.Add("pls_DisuseCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisuseCostVatAmt",
        tc_trans_name = "부가세"
      });
      columnInfo.Add("pls_DisusePriceAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisusePriceAmt",
        tc_trans_name = "폐기매가계"
      });
      columnInfo.Add("pls_DisusePriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisusePriceVatAmt",
        tc_trans_name = "폐기매가부가세"
      });
      columnInfo.Add("pls_DisusePriceCostSumAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisusePriceCostSumAmt",
        tc_trans_name = "폐기금액"
      });
      columnInfo.Add("pls_DisusePriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "pls_DisusePriceCostVatAmt",
        tc_trans_name = "폐기부가세"
      });
      columnInfo.Add("pls_PriceUp", new TTableColumn()
      {
        tc_orgin_name = "pls_PriceUp",
        tc_trans_name = "매가인상금액"
      });
      columnInfo.Add("pls_PriceUpVat", new TTableColumn()
      {
        tc_orgin_name = "pls_PriceUpVat",
        tc_trans_name = "매가인상부가세"
      });
      columnInfo.Add("pls_PriceDown", new TTableColumn()
      {
        tc_orgin_name = "pls_PriceDown",
        tc_trans_name = "매가인하금액"
      });
      columnInfo.Add("pls_PriceDownVat", new TTableColumn()
      {
        tc_orgin_name = "pls_PriceDownVat",
        tc_trans_name = "매가인하부가세"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProfitLossSummary;
      this.pls_YyyyMm = this.pls_StoreCode = 0;
      this.pls_GoodsCode = 0L;
      this.pls_SiteID = 0L;
      this.pls_Supplier = this.pls_SupplierType = this.pls_CategoryCode = 0;
      this.pls_TaxDiv = 1;
      this.pls_StockUnit = 2;
      this.pls_SalesUnit = 1;
      this.pls_BaseQty = this.pls_BaseAvgCost = this.pls_BaseCostAmt = this.pls_BaseCostVatAmt = this.pls_BasePriceAmt = this.pls_BasePriceCostAmt = this.pls_BasePriceCostVatAmt = 0.0;
      this.pls_BasePrice = this.pls_BasePriceVatAmt = 0.0;
      this.pls_EndQty = this.pls_EndAvgCost = this.pls_EndCostAmt = this.pls_EndCostVatAmt = this.pls_EndPriceAmt = this.pls_EndPriceCostAmt = this.pls_EndPriceCostVatAmt = 0.0;
      this.pls_EndPrice = this.pls_EndPriceVatAmt = 0.0;
      this.pls_SaleQty = this.pls_TotalSaleAmt = this.pls_SaleAmt = this.pls_SaleVatAmt = this.pls_SaleProfit = this.pls_SalePriceProfit = 0.0;
      this.pls_EnurySlip = this.pls_EnuryEnd = this.pls_DcAmtManual = this.pls_DcAmtEvent = this.pls_DcAmtGoods = this.pls_DcAmtCoupon = this.pls_DcAmtPromotion = this.pls_DcAmtMember = 0.0;
      this.pls_Customer = this.pls_CustomerGoods = this.pls_CustomerCategory = this.pls_CustomerSupplier = 0.0;
      this.pls_BuyQty = this.pls_BuyCostAmt = this.pls_BuyCostVatAmt = this.pls_BuyPriceAmt = this.pls_BuyPriceVatAmt = 0.0;
      this.pls_ReturnQty = this.pls_ReturnCostAmt = this.pls_ReturnCostVatAmt = this.pls_ReturnPriceAmt = this.pls_ReturnPriceVatAmt = 0.0;
      this.pls_InnerMoveOutQty = this.pls_InnerMoveOutCostAmt = this.pls_InnerMoveOutCostVatAmt = this.pls_InnerMoveOutPriceAmt = this.pls_InnerMoveOutPriceVatAmt = 0.0;
      this.pls_InnerMoveInQty = this.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInPriceAmt = this.pls_InnerMoveInPriceVatAmt = 0.0;
      this.pls_OuterMoveOutQty = this.pls_OuterMoveOutCostAmt = this.pls_OuterMoveOutCostVatAmt = this.pls_OuterMoveOutPriceAmt = this.pls_OuterMoveOutPriceVatAmt = 0.0;
      this.pls_OuterMoveInQty = this.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInPriceAmt = this.pls_OuterMoveInPriceVatAmt = 0.0;
      this.pls_AdjustQty = this.pls_AdjustCostAmt = this.pls_AdjustCostVatAmt = this.pls_AdjustPriceAmt = this.pls_AdjustPriceVatAmt = 0.0;
      this.pls_AdjustPriceCostSumAmt = this.pls_AdjustPriceCostVatAmt = 0.0;
      this.pls_DisuseQty = this.pls_DisuseCostAmt = this.pls_DisuseCostVatAmt = this.pls_DisusePriceAmt = this.pls_DisusePriceVatAmt = 0.0;
      this.pls_DisusePriceCostSumAmt = this.pls_DisusePriceCostVatAmt = 0.0;
      this.pls_PriceUp = this.pls_PriceUpVat = this.pls_PriceDown = this.pls_PriceDownVat = 0.0;
    }

    public void CalcTaxVat()
    {
      if (this.pls_IsTax)
      {
        this.pls_BasePriceCostVatAmt = this.pls_BasePriceCostAmt.ToCostVat();
        this.pls_EndPriceVatAmt = this.pls_EndPriceAmt.ToPriceVat();
        this.pls_EndPriceCostVatAmt = this.pls_EndPriceCostAmt.ToCostVat();
        this.pls_BuyCostVatAmt = this.pls_BuyCostAmt.ToCostVat();
        this.pls_BuyPriceVatAmt = this.pls_BuyPriceAmt.ToPriceVat();
        this.pls_ReturnCostVatAmt = this.pls_ReturnCostAmt.ToCostVat();
        this.pls_ReturnPriceVatAmt = this.pls_ReturnPriceAmt.ToPriceVat();
        this.pls_InnerMoveOutCostVatAmt = this.pls_InnerMoveOutCostAmt.ToCostVat();
        this.pls_InnerMoveOutPriceVatAmt = this.pls_InnerMoveOutPriceAmt.ToPriceVat();
        this.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInCostAmt.ToCostVat();
        this.pls_InnerMoveInPriceVatAmt = this.pls_InnerMoveInPriceAmt.ToPriceVat();
        this.pls_OuterMoveOutCostVatAmt = this.pls_OuterMoveOutCostAmt.ToCostVat();
        this.pls_OuterMoveOutPriceVatAmt = this.pls_OuterMoveOutPriceAmt.ToPriceVat();
        this.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInCostAmt.ToCostVat();
        this.pls_OuterMoveInPriceVatAmt = this.pls_OuterMoveInPriceAmt.ToPriceVat();
        this.pls_AdjustCostVatAmt = this.pls_AdjustCostAmt.ToCostVat();
        this.pls_AdjustPriceVatAmt = this.pls_AdjustPriceAmt.ToPriceVat();
        this.pls_AdjustPriceCostVatAmt = this.pls_AdjustPriceCostSumAmt.ToPriceVat();
        this.pls_DisuseCostVatAmt = this.pls_DisuseCostAmt.ToCostVat();
        this.pls_DisusePriceVatAmt = this.pls_DisusePriceAmt.ToPriceVat();
        this.pls_DisusePriceCostVatAmt = this.pls_DisusePriceCostSumAmt.ToPriceVat();
        this.pls_PriceUpVat = this.pls_PriceUp.ToPriceVat();
        this.pls_PriceDownVat = this.pls_PriceDown.ToPriceVat();
      }
      else
      {
        this.pls_BasePriceCostVatAmt = 0.0;
        this.pls_EndPriceVatAmt = 0.0;
        this.pls_EndPriceCostVatAmt = 0.0;
        this.pls_BuyCostVatAmt = 0.0;
        this.pls_BuyPriceVatAmt = 0.0;
        this.pls_ReturnCostVatAmt = 0.0;
        this.pls_ReturnPriceVatAmt = 0.0;
        this.pls_InnerMoveOutCostVatAmt = 0.0;
        this.pls_InnerMoveOutPriceVatAmt = 0.0;
        this.pls_InnerMoveInCostVatAmt = 0.0;
        this.pls_InnerMoveInPriceVatAmt = 0.0;
        this.pls_OuterMoveOutCostVatAmt = 0.0;
        this.pls_OuterMoveOutPriceVatAmt = 0.0;
        this.pls_OuterMoveInCostVatAmt = 0.0;
        this.pls_OuterMoveInPriceVatAmt = 0.0;
        this.pls_AdjustCostVatAmt = 0.0;
        this.pls_AdjustPriceVatAmt = 0.0;
        this.pls_AdjustPriceCostVatAmt = 0.0;
        this.pls_DisuseCostVatAmt = 0.0;
        this.pls_DisusePriceVatAmt = 0.0;
        this.pls_DisusePriceCostVatAmt = 0.0;
        this.pls_PriceUpVat = 0.0;
        this.pls_PriceDownVat = 0.0;
      }
    }

    public double CalcBuyTaxFreeAmount() => this.pls_BaseCostAmt + this.pls_BuyCostAmt - this.pls_ReturnCostAmt + this.pls_OuterMoveInCostAmt - this.pls_OuterMoveOutCostAmt + this.pls_InnerMoveInCostAmt - this.pls_InnerMoveOutCostAmt - this.pls_EndCostAmt;

    public double CalcBuySumAmount() => this.pls_BaseCostSumAmt + this.pls_BuyCostSumAmt - this.pls_ReturnCostSumAmt + this.pls_OuterMoveInCostSumAmt - this.pls_OuterMoveOutCostSumAmt + this.pls_InnerMoveInCostSumAmt - this.pls_InnerMoveOutCostSumAmt - this.pls_EndCostSumAmt;

    public double CalcBuyPriceTaxFreeAmount() => this.pls_BasePriceCostAmt + this.pls_BuyCostAmt - this.pls_ReturnCostAmt + this.pls_OuterMoveInCostAmt - this.pls_OuterMoveOutCostAmt + this.pls_InnerMoveInCostAmt - this.pls_InnerMoveOutCostAmt - this.pls_EndPriceCostAmt;

    public double CalcBuyPriceSumAmount() => this.pls_BasePriceCostSumAmt + this.pls_BuyCostSumAmt - this.pls_ReturnCostSumAmt + this.pls_OuterMoveInCostSumAmt - this.pls_OuterMoveOutCostSumAmt + this.pls_InnerMoveInCostSumAmt - this.pls_InnerMoveOutCostSumAmt - this.pls_EndPriceCostSumAmt;

    public double CalcStockQty() => this.pls_BaseQty + this.pls_BuyQty - this.pls_ReturnQty - this.pls_SaleQty + this.pls_InnerMoveInQty - this.pls_InnerMoveOutQty + this.pls_OuterMoveInQty - this.pls_OuterMoveOutQty + this.pls_AdjustQty - this.pls_DisuseQty;

    public void CalcEndQty() => this.pls_EndQty = this.CalcStockQty();

    public double CalcAmount() => this.CalcStockQty() * this.pls_EndAvgCost;

    public double CalcSumAmount() => this.CalcAmount() + (this.pls_IsTax ? this.CalcAmount().ToCostVat() : 0.0);

    public double CalcTurnOver() => CalcHelper.ToTurnOverRate(this.pls_SaleTaxFreeAmt, this.pls_BaseCostAmt, this.pls_EndCostAmt);

    public double CalcTurnOverPrice() => CalcHelper.ToTurnOverRate(this.pls_SaleTaxFreeAmt, this.pls_BasePriceCostAmt, this.pls_EndPriceCostAmt);

    public double CalcCrossRate() => CalcHelper.ToCrossRate(this.pls_ProfitRule, this.CalcTurnOver());

    public double CalcCrossRatePrice() => CalcHelper.ToCrossRate(this.pls_PriceProfitRule, this.CalcTurnOverPrice());

    public double CalcLogisticsAmount() => this.pls_SaleTaxFreeAmt + this.pls_OuterMoveOutCostAmt;

    public double CalcLogisticsProfitRule() => CalcHelper.ToSaleProfitMargin(this.pls_SaleProfit, this.CalcLogisticsAmount());

    public double CalcLogisticsTurnOver() => CalcHelper.ToTurnOverRate(this.CalcLogisticsAmount(), this.pls_BaseCostAmt, this.pls_EndCostAmt);

    protected override UbModelBase CreateClone => (UbModelBase) new TProfitLossSummary();

    public override object Clone()
    {
      TProfitLossSummary tprofitLossSummary = base.Clone() as TProfitLossSummary;
      tprofitLossSummary.pls_YyyyMm = this.pls_YyyyMm;
      tprofitLossSummary.pls_StoreCode = this.pls_StoreCode;
      tprofitLossSummary.pls_GoodsCode = this.pls_GoodsCode;
      tprofitLossSummary.pls_SiteID = this.pls_SiteID;
      tprofitLossSummary.pls_Supplier = this.pls_Supplier;
      tprofitLossSummary.pls_SupplierType = this.pls_SupplierType;
      tprofitLossSummary.pls_CategoryCode = this.pls_CategoryCode;
      tprofitLossSummary.pls_TaxDiv = this.pls_TaxDiv;
      tprofitLossSummary.pls_StockUnit = this.pls_StockUnit;
      tprofitLossSummary.pls_SalesUnit = this.pls_SalesUnit;
      tprofitLossSummary.pls_BaseQty = this.pls_BaseQty;
      tprofitLossSummary.pls_BaseAvgCost = this.pls_BaseAvgCost;
      tprofitLossSummary.pls_BaseCostAmt = this.pls_BaseCostAmt;
      tprofitLossSummary.pls_BaseCostVatAmt = this.pls_BaseCostVatAmt;
      tprofitLossSummary.pls_BasePrice = this.pls_BasePrice;
      tprofitLossSummary.pls_BasePriceCostAmt = this.pls_BasePriceCostAmt;
      tprofitLossSummary.pls_BasePriceCostVatAmt = this.pls_BasePriceCostVatAmt;
      tprofitLossSummary.pls_BasePriceAmt = this.pls_BasePriceAmt;
      tprofitLossSummary.pls_BasePriceVatAmt = this.pls_BasePriceVatAmt;
      tprofitLossSummary.pls_EndQty = this.pls_EndQty;
      tprofitLossSummary.pls_EndAvgCost = this.pls_EndAvgCost;
      tprofitLossSummary.pls_EndCostAmt = this.pls_EndCostAmt;
      tprofitLossSummary.pls_EndCostVatAmt = this.pls_EndCostVatAmt;
      tprofitLossSummary.pls_EndPrice = this.pls_EndPrice;
      tprofitLossSummary.pls_EndPriceCostAmt = this.pls_EndPriceCostAmt;
      tprofitLossSummary.pls_EndPriceCostVatAmt = this.pls_EndPriceCostVatAmt;
      tprofitLossSummary.pls_EndPriceAmt = this.pls_EndPriceAmt;
      tprofitLossSummary.pls_EndPriceVatAmt = this.pls_EndPriceVatAmt;
      tprofitLossSummary.pls_SaleQty = this.pls_SaleQty;
      tprofitLossSummary.pls_TotalSaleAmt = this.pls_TotalSaleAmt;
      tprofitLossSummary.pls_SaleAmt = this.pls_SaleAmt;
      tprofitLossSummary.pls_SaleVatAmt = this.pls_SaleVatAmt;
      tprofitLossSummary.pls_SaleProfit = this.pls_SaleProfit;
      tprofitLossSummary.pls_SalePriceProfit = this.pls_SalePriceProfit;
      tprofitLossSummary.pls_EnurySlip = this.pls_EnurySlip;
      tprofitLossSummary.pls_EnuryEnd = this.pls_EnuryEnd;
      tprofitLossSummary.pls_DcAmtManual = this.pls_DcAmtManual;
      tprofitLossSummary.pls_DcAmtEvent = this.pls_DcAmtEvent;
      tprofitLossSummary.pls_DcAmtGoods = this.pls_DcAmtGoods;
      tprofitLossSummary.pls_DcAmtCoupon = this.pls_DcAmtCoupon;
      tprofitLossSummary.pls_DcAmtPromotion = this.pls_DcAmtPromotion;
      tprofitLossSummary.pls_DcAmtMember = this.pls_DcAmtMember;
      tprofitLossSummary.pls_Customer = this.pls_Customer;
      tprofitLossSummary.pls_CustomerGoods = this.pls_CustomerGoods;
      tprofitLossSummary.pls_CustomerCategory = this.pls_CustomerCategory;
      tprofitLossSummary.pls_CustomerSupplier = this.pls_CustomerSupplier;
      tprofitLossSummary.pls_BuyQty = this.pls_BuyQty;
      tprofitLossSummary.pls_BuyCostAmt = this.pls_BuyCostAmt;
      tprofitLossSummary.pls_BuyCostVatAmt = this.pls_BuyCostVatAmt;
      tprofitLossSummary.pls_BuyPriceAmt = this.pls_BuyPriceAmt;
      tprofitLossSummary.pls_BuyPriceVatAmt = this.pls_BuyPriceVatAmt;
      tprofitLossSummary.pls_ReturnQty = this.pls_ReturnQty;
      tprofitLossSummary.pls_ReturnCostAmt = this.pls_ReturnCostAmt;
      tprofitLossSummary.pls_ReturnCostVatAmt = this.pls_ReturnCostVatAmt;
      tprofitLossSummary.pls_ReturnPriceAmt = this.pls_ReturnPriceAmt;
      tprofitLossSummary.pls_ReturnPriceVatAmt = this.pls_ReturnPriceVatAmt;
      tprofitLossSummary.pls_InnerMoveOutQty = this.pls_InnerMoveOutQty;
      tprofitLossSummary.pls_InnerMoveOutCostAmt = this.pls_InnerMoveOutCostAmt;
      tprofitLossSummary.pls_InnerMoveOutCostVatAmt = this.pls_InnerMoveOutCostVatAmt;
      tprofitLossSummary.pls_InnerMoveOutPriceAmt = this.pls_InnerMoveOutPriceAmt;
      tprofitLossSummary.pls_InnerMoveOutPriceVatAmt = this.pls_InnerMoveOutPriceVatAmt;
      tprofitLossSummary.pls_InnerMoveInQty = this.pls_InnerMoveInQty;
      tprofitLossSummary.pls_InnerMoveInCostAmt = this.pls_InnerMoveInCostAmt;
      tprofitLossSummary.pls_InnerMoveInCostVatAmt = this.pls_InnerMoveInCostVatAmt;
      tprofitLossSummary.pls_InnerMoveInPriceAmt = this.pls_InnerMoveInPriceAmt;
      tprofitLossSummary.pls_InnerMoveInPriceVatAmt = this.pls_InnerMoveInPriceVatAmt;
      tprofitLossSummary.pls_OuterMoveOutQty = this.pls_OuterMoveOutQty;
      tprofitLossSummary.pls_OuterMoveOutCostAmt = this.pls_OuterMoveOutCostAmt;
      tprofitLossSummary.pls_OuterMoveOutCostVatAmt = this.pls_OuterMoveOutCostVatAmt;
      tprofitLossSummary.pls_OuterMoveOutPriceAmt = this.pls_OuterMoveOutPriceAmt;
      tprofitLossSummary.pls_OuterMoveOutPriceVatAmt = this.pls_OuterMoveOutPriceVatAmt;
      tprofitLossSummary.pls_OuterMoveInQty = this.pls_OuterMoveInQty;
      tprofitLossSummary.pls_OuterMoveInCostAmt = this.pls_OuterMoveInCostAmt;
      tprofitLossSummary.pls_OuterMoveInCostVatAmt = this.pls_OuterMoveInCostVatAmt;
      tprofitLossSummary.pls_OuterMoveInPriceAmt = this.pls_OuterMoveInPriceAmt;
      tprofitLossSummary.pls_OuterMoveInPriceVatAmt = this.pls_OuterMoveInPriceVatAmt;
      tprofitLossSummary.pls_AdjustQty = this.pls_AdjustQty;
      tprofitLossSummary.pls_AdjustCostAmt = this.pls_AdjustCostAmt;
      tprofitLossSummary.pls_AdjustCostVatAmt = this.pls_AdjustCostVatAmt;
      tprofitLossSummary.pls_AdjustPriceAmt = this.pls_AdjustPriceAmt;
      tprofitLossSummary.pls_AdjustPriceVatAmt = this.pls_AdjustPriceVatAmt;
      tprofitLossSummary.pls_AdjustPriceCostSumAmt = this.pls_AdjustPriceCostSumAmt;
      tprofitLossSummary.pls_AdjustPriceCostVatAmt = this.pls_AdjustPriceCostVatAmt;
      tprofitLossSummary.pls_DisuseQty = this.pls_DisuseQty;
      tprofitLossSummary.pls_DisuseCostAmt = this.pls_DisuseCostAmt;
      tprofitLossSummary.pls_DisuseCostVatAmt = this.pls_DisuseCostVatAmt;
      tprofitLossSummary.pls_DisusePriceAmt = this.pls_DisusePriceAmt;
      tprofitLossSummary.pls_DisusePriceVatAmt = this.pls_DisusePriceVatAmt;
      tprofitLossSummary.pls_DisusePriceCostSumAmt = this.pls_DisusePriceCostSumAmt;
      tprofitLossSummary.pls_DisusePriceCostVatAmt = this.pls_DisusePriceCostVatAmt;
      tprofitLossSummary.pls_PriceUp = this.pls_PriceUp;
      tprofitLossSummary.pls_PriceUpVat = this.pls_PriceUpVat;
      tprofitLossSummary.pls_PriceDown = this.pls_PriceDown;
      tprofitLossSummary.pls_PriceDownVat = this.pls_PriceDownVat;
      return (object) tprofitLossSummary;
    }

    public void PutData(TProfitLossSummary pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pls_YyyyMm = pSource.pls_YyyyMm;
      this.pls_StoreCode = pSource.pls_StoreCode;
      this.pls_GoodsCode = pSource.pls_GoodsCode;
      this.pls_SiteID = pSource.pls_SiteID;
      this.pls_Supplier = pSource.pls_Supplier;
      this.pls_SupplierType = pSource.pls_SupplierType;
      this.pls_CategoryCode = pSource.pls_CategoryCode;
      this.pls_TaxDiv = pSource.pls_TaxDiv;
      this.pls_StockUnit = pSource.pls_StockUnit;
      this.pls_SalesUnit = pSource.pls_SalesUnit;
      this.pls_BaseQty = pSource.pls_BaseQty;
      this.pls_BaseAvgCost = pSource.pls_BaseAvgCost;
      this.pls_BaseCostAmt = pSource.pls_BaseCostAmt;
      this.pls_BaseCostVatAmt = pSource.pls_BaseCostVatAmt;
      this.pls_BasePrice = pSource.pls_BasePrice;
      this.pls_BasePriceCostAmt = pSource.pls_BasePriceCostAmt;
      this.pls_BasePriceCostVatAmt = pSource.pls_BasePriceCostVatAmt;
      this.pls_BasePriceAmt = pSource.pls_BasePriceAmt;
      this.pls_BasePriceVatAmt = pSource.pls_BasePriceVatAmt;
      this.pls_EndQty = pSource.pls_EndQty;
      this.pls_EndAvgCost = pSource.pls_EndAvgCost;
      this.pls_EndCostAmt = pSource.pls_EndCostAmt;
      this.pls_EndCostVatAmt = pSource.pls_EndCostVatAmt;
      this.pls_EndPrice = pSource.pls_EndPrice;
      this.pls_EndPriceCostAmt = pSource.pls_EndPriceCostAmt;
      this.pls_EndPriceCostVatAmt = pSource.pls_EndPriceCostVatAmt;
      this.pls_EndPriceAmt = pSource.pls_EndPriceAmt;
      this.pls_EndPriceVatAmt = pSource.pls_EndPriceVatAmt;
      this.pls_SaleQty = pSource.pls_SaleQty;
      this.pls_TotalSaleAmt = pSource.pls_TotalSaleAmt;
      this.pls_SaleAmt = pSource.pls_SaleAmt;
      this.pls_SaleVatAmt = pSource.pls_SaleVatAmt;
      this.pls_SaleProfit = pSource.pls_SaleProfit;
      this.pls_SalePriceProfit = pSource.pls_SalePriceProfit;
      this.pls_EnurySlip = pSource.pls_EnurySlip;
      this.pls_EnuryEnd = pSource.pls_EnuryEnd;
      this.pls_DcAmtManual = pSource.pls_DcAmtManual;
      this.pls_DcAmtEvent = pSource.pls_DcAmtEvent;
      this.pls_DcAmtGoods = pSource.pls_DcAmtGoods;
      this.pls_DcAmtCoupon = pSource.pls_DcAmtCoupon;
      this.pls_DcAmtPromotion = pSource.pls_DcAmtPromotion;
      this.pls_DcAmtMember = pSource.pls_DcAmtMember;
      this.pls_Customer = pSource.pls_Customer;
      this.pls_CustomerGoods = pSource.pls_CustomerGoods;
      this.pls_CustomerCategory = pSource.pls_CustomerCategory;
      this.pls_CustomerSupplier = pSource.pls_CustomerSupplier;
      this.pls_BuyQty = pSource.pls_BuyQty;
      this.pls_BuyCostAmt = pSource.pls_BuyCostAmt;
      this.pls_BuyCostVatAmt = pSource.pls_BuyCostVatAmt;
      this.pls_BuyPriceAmt = pSource.pls_BuyPriceAmt;
      this.pls_BuyPriceVatAmt = pSource.pls_BuyPriceVatAmt;
      this.pls_ReturnQty = pSource.pls_ReturnQty;
      this.pls_ReturnCostAmt = pSource.pls_ReturnCostAmt;
      this.pls_ReturnCostVatAmt = pSource.pls_ReturnCostVatAmt;
      this.pls_ReturnPriceAmt = pSource.pls_ReturnPriceAmt;
      this.pls_ReturnPriceVatAmt = pSource.pls_ReturnPriceVatAmt;
      this.pls_InnerMoveOutQty = pSource.pls_InnerMoveOutQty;
      this.pls_InnerMoveOutCostAmt = pSource.pls_InnerMoveOutCostAmt;
      this.pls_InnerMoveOutCostVatAmt = pSource.pls_InnerMoveOutCostVatAmt;
      this.pls_InnerMoveOutPriceAmt = pSource.pls_InnerMoveOutPriceAmt;
      this.pls_InnerMoveOutPriceVatAmt = pSource.pls_InnerMoveOutPriceVatAmt;
      this.pls_InnerMoveInQty = pSource.pls_InnerMoveInQty;
      this.pls_InnerMoveInCostAmt = pSource.pls_InnerMoveInCostAmt;
      this.pls_InnerMoveInCostVatAmt = pSource.pls_InnerMoveInCostVatAmt;
      this.pls_InnerMoveInPriceAmt = pSource.pls_InnerMoveInPriceAmt;
      this.pls_InnerMoveInPriceVatAmt = pSource.pls_InnerMoveInPriceVatAmt;
      this.pls_OuterMoveOutQty = pSource.pls_OuterMoveOutQty;
      this.pls_OuterMoveOutCostAmt = pSource.pls_OuterMoveOutCostAmt;
      this.pls_OuterMoveOutCostVatAmt = pSource.pls_OuterMoveOutCostVatAmt;
      this.pls_OuterMoveOutPriceAmt = pSource.pls_OuterMoveOutPriceAmt;
      this.pls_OuterMoveOutPriceVatAmt = pSource.pls_OuterMoveOutPriceVatAmt;
      this.pls_OuterMoveInQty = pSource.pls_OuterMoveInQty;
      this.pls_OuterMoveInCostAmt = pSource.pls_OuterMoveInCostAmt;
      this.pls_OuterMoveInCostVatAmt = pSource.pls_OuterMoveInCostVatAmt;
      this.pls_OuterMoveInPriceAmt = pSource.pls_OuterMoveInPriceAmt;
      this.pls_OuterMoveInPriceVatAmt = pSource.pls_OuterMoveInPriceVatAmt;
      this.pls_AdjustQty = pSource.pls_AdjustQty;
      this.pls_AdjustCostAmt = pSource.pls_AdjustCostAmt;
      this.pls_AdjustCostVatAmt = pSource.pls_AdjustCostVatAmt;
      this.pls_AdjustPriceAmt = pSource.pls_AdjustPriceAmt;
      this.pls_AdjustPriceVatAmt = pSource.pls_AdjustPriceVatAmt;
      this.pls_AdjustPriceCostSumAmt = pSource.pls_AdjustPriceCostSumAmt;
      this.pls_AdjustPriceCostVatAmt = pSource.pls_AdjustPriceCostVatAmt;
      this.pls_DisuseQty = pSource.pls_DisuseQty;
      this.pls_DisuseCostAmt = pSource.pls_DisuseCostAmt;
      this.pls_DisuseCostVatAmt = pSource.pls_DisuseCostVatAmt;
      this.pls_DisusePriceAmt = pSource.pls_DisusePriceAmt;
      this.pls_DisusePriceVatAmt = pSource.pls_DisusePriceVatAmt;
      this.pls_DisusePriceCostSumAmt = pSource.pls_DisusePriceCostSumAmt;
      this.pls_DisusePriceCostVatAmt = pSource.pls_DisusePriceCostVatAmt;
      this.pls_PriceUp = pSource.pls_PriceUp;
      this.pls_PriceUpVat = pSource.pls_PriceUpVat;
      this.pls_PriceDown = pSource.pls_PriceDown;
      this.pls_PriceDownVat = pSource.pls_PriceDownVat;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pls_YyyyMm = p_rs.GetFieldInt("pls_YyyyMm");
        this.pls_StoreCode = p_rs.GetFieldInt("pls_StoreCode");
        if (this.pls_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pls_GoodsCode = p_rs.GetFieldLong("pls_GoodsCode");
        this.pls_SiteID = p_rs.GetFieldLong("pls_SiteID");
        this.pls_Supplier = p_rs.GetFieldInt("pls_Supplier");
        this.pls_SupplierType = p_rs.GetFieldInt("pls_SupplierType");
        this.pls_CategoryCode = p_rs.GetFieldInt("pls_CategoryCode");
        this.pls_TaxDiv = p_rs.GetFieldInt("pls_TaxDiv");
        this.pls_StockUnit = p_rs.GetFieldInt("pls_StockUnit");
        this.pls_SalesUnit = p_rs.GetFieldInt("pls_SalesUnit");
        this.pls_BaseQty = p_rs.GetFieldDouble("pls_BaseQty");
        this.pls_BaseAvgCost = p_rs.GetFieldDouble("pls_BaseAvgCost");
        this.pls_BaseCostAmt = p_rs.GetFieldDouble("pls_BaseCostAmt");
        this.pls_BaseCostVatAmt = p_rs.GetFieldDouble("pls_BaseCostVatAmt");
        this.pls_BasePriceAmt = p_rs.GetFieldDouble("pls_BasePriceAmt");
        this.pls_BasePriceCostAmt = p_rs.GetFieldDouble("pls_BasePriceCostAmt");
        this.pls_BasePriceCostVatAmt = p_rs.GetFieldDouble("pls_BasePriceCostVatAmt");
        this.pls_BasePrice = p_rs.GetFieldDouble("pls_BasePrice");
        this.pls_BasePriceVatAmt = p_rs.GetFieldDouble("pls_BasePriceVatAmt");
        this.pls_EndQty = p_rs.GetFieldDouble("pls_EndQty");
        this.pls_EndAvgCost = p_rs.GetFieldDouble("pls_EndAvgCost");
        this.pls_EndCostAmt = p_rs.GetFieldDouble("pls_EndCostAmt");
        this.pls_EndCostVatAmt = p_rs.GetFieldDouble("pls_EndCostVatAmt");
        this.pls_EndPriceAmt = p_rs.GetFieldDouble("pls_EndPriceAmt");
        this.pls_EndPriceCostAmt = p_rs.GetFieldDouble("pls_EndPriceCostAmt");
        this.pls_EndPriceCostVatAmt = p_rs.GetFieldDouble("pls_EndPriceCostVatAmt");
        this.pls_EndPrice = p_rs.GetFieldDouble("pls_EndPrice");
        this.pls_EndPriceVatAmt = p_rs.GetFieldDouble("pls_EndPriceVatAmt");
        this.pls_SaleQty = p_rs.GetFieldDouble("pls_SaleQty");
        this.pls_TotalSaleAmt = p_rs.GetFieldDouble("pls_TotalSaleAmt");
        this.pls_SaleAmt = p_rs.GetFieldDouble("pls_SaleAmt");
        this.pls_SaleVatAmt = p_rs.GetFieldDouble("pls_SaleVatAmt");
        this.pls_SaleProfit = p_rs.GetFieldDouble("pls_SaleProfit");
        this.pls_SalePriceProfit = p_rs.GetFieldDouble("pls_SalePriceProfit");
        this.pls_EnurySlip = p_rs.GetFieldDouble("pls_EnurySlip");
        this.pls_EnuryEnd = p_rs.GetFieldDouble("pls_EnuryEnd");
        this.pls_DcAmtManual = p_rs.GetFieldDouble("pls_DcAmtManual");
        this.pls_DcAmtEvent = p_rs.GetFieldDouble("pls_DcAmtEvent");
        this.pls_DcAmtGoods = p_rs.GetFieldDouble("pls_DcAmtGoods");
        this.pls_DcAmtCoupon = p_rs.GetFieldDouble("pls_DcAmtCoupon");
        this.pls_DcAmtPromotion = p_rs.GetFieldDouble("pls_DcAmtPromotion");
        this.pls_DcAmtMember = p_rs.GetFieldDouble("pls_DcAmtMember");
        this.pls_Customer = p_rs.GetFieldDouble("pls_Customer");
        this.pls_CustomerGoods = p_rs.GetFieldDouble("pls_CustomerGoods");
        this.pls_CustomerCategory = p_rs.GetFieldDouble("pls_CustomerCategory");
        this.pls_CustomerSupplier = p_rs.GetFieldDouble("pls_CustomerSupplier");
        this.pls_BuyQty = p_rs.GetFieldDouble("pls_BuyQty");
        this.pls_BuyCostAmt = p_rs.GetFieldDouble("pls_BuyCostAmt");
        this.pls_BuyCostVatAmt = p_rs.GetFieldDouble("pls_BuyCostVatAmt");
        this.pls_BuyPriceAmt = p_rs.GetFieldDouble("pls_BuyPriceAmt");
        this.pls_BuyPriceVatAmt = p_rs.GetFieldDouble("pls_BuyPriceVatAmt");
        this.pls_ReturnQty = p_rs.GetFieldDouble("pls_ReturnQty");
        this.pls_ReturnCostAmt = p_rs.GetFieldDouble("pls_ReturnCostAmt");
        this.pls_ReturnCostVatAmt = p_rs.GetFieldDouble("pls_ReturnCostVatAmt");
        this.pls_ReturnPriceAmt = p_rs.GetFieldDouble("pls_ReturnPriceAmt");
        this.pls_ReturnPriceVatAmt = p_rs.GetFieldDouble("pls_ReturnPriceVatAmt");
        this.pls_InnerMoveOutQty = p_rs.GetFieldDouble("pls_InnerMoveOutQty");
        this.pls_InnerMoveOutCostAmt = p_rs.GetFieldDouble("pls_InnerMoveOutCostAmt");
        this.pls_InnerMoveOutCostVatAmt = p_rs.GetFieldDouble("pls_InnerMoveOutCostVatAmt");
        this.pls_InnerMoveOutPriceAmt = p_rs.GetFieldDouble("pls_InnerMoveOutPriceAmt");
        this.pls_InnerMoveOutPriceVatAmt = p_rs.GetFieldDouble("pls_InnerMoveOutPriceVatAmt");
        this.pls_InnerMoveInQty = p_rs.GetFieldDouble("pls_InnerMoveInQty");
        this.pls_InnerMoveInCostAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostAmt");
        this.pls_InnerMoveInCostVatAmt = p_rs.GetFieldDouble("pls_InnerMoveInCostVatAmt");
        this.pls_InnerMoveInPriceAmt = p_rs.GetFieldDouble("pls_InnerMoveInPriceAmt");
        this.pls_InnerMoveInPriceVatAmt = p_rs.GetFieldDouble("pls_InnerMoveInPriceVatAmt");
        this.pls_OuterMoveOutQty = p_rs.GetFieldDouble("pls_OuterMoveOutQty");
        this.pls_OuterMoveOutCostAmt = p_rs.GetFieldDouble("pls_OuterMoveOutCostAmt");
        this.pls_OuterMoveOutCostVatAmt = p_rs.GetFieldDouble("pls_OuterMoveOutCostVatAmt");
        this.pls_OuterMoveOutPriceAmt = p_rs.GetFieldDouble("pls_OuterMoveOutPriceAmt");
        this.pls_OuterMoveOutPriceVatAmt = p_rs.GetFieldDouble("pls_OuterMoveOutPriceVatAmt");
        this.pls_OuterMoveInQty = p_rs.GetFieldDouble("pls_OuterMoveInQty");
        this.pls_OuterMoveInCostAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostAmt");
        this.pls_OuterMoveInCostVatAmt = p_rs.GetFieldDouble("pls_OuterMoveInCostVatAmt");
        this.pls_OuterMoveInPriceAmt = p_rs.GetFieldDouble("pls_OuterMoveInPriceAmt");
        this.pls_OuterMoveInPriceVatAmt = p_rs.GetFieldDouble("pls_OuterMoveInPriceVatAmt");
        this.pls_AdjustQty = p_rs.GetFieldDouble("pls_AdjustQty");
        this.pls_AdjustCostAmt = p_rs.GetFieldDouble("pls_AdjustCostAmt");
        this.pls_AdjustCostVatAmt = p_rs.GetFieldDouble("pls_AdjustCostVatAmt");
        this.pls_AdjustPriceAmt = p_rs.GetFieldDouble("pls_AdjustPriceAmt");
        this.pls_AdjustPriceVatAmt = p_rs.GetFieldDouble("pls_AdjustPriceVatAmt");
        this.pls_AdjustPriceCostSumAmt = p_rs.GetFieldDouble("pls_AdjustPriceCostSumAmt");
        this.pls_AdjustPriceCostVatAmt = p_rs.GetFieldDouble("pls_AdjustPriceCostVatAmt");
        this.pls_DisuseQty = p_rs.GetFieldDouble("pls_DisuseQty");
        this.pls_DisuseCostAmt = p_rs.GetFieldDouble("pls_DisuseCostAmt");
        this.pls_DisuseCostVatAmt = p_rs.GetFieldDouble("pls_DisuseCostVatAmt");
        this.pls_DisusePriceAmt = p_rs.GetFieldDouble("pls_DisusePriceAmt");
        this.pls_DisusePriceVatAmt = p_rs.GetFieldDouble("pls_DisusePriceVatAmt");
        this.pls_DisusePriceCostSumAmt = p_rs.GetFieldDouble("pls_DisusePriceCostSumAmt");
        this.pls_DisusePriceCostVatAmt = p_rs.GetFieldDouble("pls_DisusePriceCostVatAmt");
        this.pls_PriceUp = p_rs.GetFieldDouble("pls_PriceUp");
        this.pls_PriceUpVat = p_rs.GetFieldDouble("pls_PriceUpVat");
        this.pls_PriceDown = p_rs.GetFieldDouble("pls_PriceDown");
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

    public virtual bool CalcAddSum(TProfitLossSummary pSource)
    {
      if (pSource == null)
        return false;
      this.pls_BaseQty += pSource.pls_BaseQty;
      this.pls_BaseAvgCost = pSource.pls_BaseAvgCost;
      this.pls_BaseCostAmt += pSource.pls_BaseCostAmt;
      this.pls_BaseCostVatAmt += pSource.pls_BaseCostVatAmt;
      this.pls_BasePriceAmt += pSource.pls_BasePriceAmt;
      this.pls_BasePriceVatAmt += pSource.pls_BasePriceVatAmt;
      this.pls_BasePriceCostAmt += pSource.pls_BasePriceCostAmt;
      this.pls_BasePriceCostVatAmt += pSource.pls_BasePriceCostVatAmt;
      this.pls_EndQty += pSource.pls_EndQty;
      this.pls_EndAvgCost = pSource.pls_EndAvgCost;
      this.pls_EndCostAmt += pSource.pls_EndCostAmt;
      this.pls_EndCostVatAmt += pSource.pls_EndCostVatAmt;
      this.pls_EndPriceAmt += pSource.pls_EndPriceAmt;
      this.pls_EndPriceVatAmt += pSource.pls_EndPriceVatAmt;
      this.pls_EndPriceCostAmt += pSource.pls_EndPriceCostAmt;
      this.pls_EndPriceCostVatAmt += pSource.pls_EndPriceCostVatAmt;
      this.pls_SaleQty += pSource.pls_SaleQty;
      this.pls_TotalSaleAmt += pSource.pls_TotalSaleAmt;
      this.pls_SaleAmt += pSource.pls_SaleAmt;
      this.pls_SaleVatAmt += pSource.pls_SaleVatAmt;
      this.pls_SaleProfit += pSource.pls_SaleProfit;
      this.pls_EnurySlip += pSource.pls_EnurySlip;
      this.pls_EnuryEnd += pSource.pls_EnuryEnd;
      this.pls_DcAmtManual += pSource.pls_DcAmtManual;
      this.pls_DcAmtEvent += pSource.pls_DcAmtEvent;
      this.pls_DcAmtGoods += pSource.pls_DcAmtGoods;
      this.pls_DcAmtCoupon += pSource.pls_DcAmtCoupon;
      this.pls_DcAmtPromotion += pSource.pls_DcAmtPromotion;
      this.pls_DcAmtMember += pSource.pls_DcAmtMember;
      this.pls_Customer += pSource.pls_Customer;
      this.pls_CustomerGoods += pSource.pls_CustomerGoods;
      this.pls_CustomerCategory += pSource.pls_CustomerCategory;
      this.pls_CustomerSupplier += pSource.pls_CustomerSupplier;
      this.pls_BuyQty += pSource.pls_BuyQty;
      this.pls_BuyCostAmt += pSource.pls_BuyCostAmt;
      this.pls_BuyCostVatAmt += pSource.pls_BuyCostVatAmt;
      this.pls_BuyPriceAmt += pSource.pls_BuyPriceAmt;
      this.pls_BuyPriceVatAmt += pSource.pls_BuyPriceVatAmt;
      this.pls_ReturnQty += pSource.pls_ReturnQty;
      this.pls_ReturnCostAmt += pSource.pls_ReturnCostAmt;
      this.pls_ReturnCostVatAmt += pSource.pls_ReturnCostVatAmt;
      this.pls_ReturnPriceAmt += pSource.pls_ReturnPriceAmt;
      this.pls_ReturnPriceVatAmt += pSource.pls_ReturnPriceVatAmt;
      this.pls_InnerMoveOutQty += pSource.pls_InnerMoveOutQty;
      this.pls_InnerMoveOutCostAmt += pSource.pls_InnerMoveOutCostAmt;
      this.pls_InnerMoveOutCostVatAmt += pSource.pls_InnerMoveOutCostVatAmt;
      this.pls_InnerMoveOutPriceAmt += pSource.pls_InnerMoveOutPriceAmt;
      this.pls_InnerMoveOutPriceVatAmt += pSource.pls_InnerMoveOutPriceVatAmt;
      this.pls_InnerMoveInQty += pSource.pls_InnerMoveInQty;
      this.pls_InnerMoveInCostAmt += pSource.pls_InnerMoveInCostAmt;
      this.pls_InnerMoveInCostVatAmt += pSource.pls_InnerMoveInCostVatAmt;
      this.pls_InnerMoveInPriceAmt += pSource.pls_InnerMoveInPriceAmt;
      this.pls_InnerMoveInPriceVatAmt += pSource.pls_InnerMoveInPriceVatAmt;
      this.pls_OuterMoveOutQty += pSource.pls_OuterMoveOutQty;
      this.pls_OuterMoveOutCostAmt += pSource.pls_OuterMoveOutCostAmt;
      this.pls_OuterMoveOutCostVatAmt += pSource.pls_OuterMoveOutCostVatAmt;
      this.pls_OuterMoveOutPriceAmt += pSource.pls_OuterMoveOutPriceAmt;
      this.pls_OuterMoveOutPriceVatAmt += pSource.pls_OuterMoveOutPriceVatAmt;
      this.pls_OuterMoveInQty += pSource.pls_OuterMoveInQty;
      this.pls_OuterMoveInCostAmt += pSource.pls_OuterMoveInCostAmt;
      this.pls_OuterMoveInCostVatAmt += pSource.pls_OuterMoveInCostVatAmt;
      this.pls_OuterMoveInPriceAmt += pSource.pls_OuterMoveInPriceAmt;
      this.pls_OuterMoveInPriceVatAmt += pSource.pls_OuterMoveInPriceVatAmt;
      this.pls_AdjustQty += pSource.pls_AdjustQty;
      this.pls_AdjustCostAmt += pSource.pls_AdjustCostAmt;
      this.pls_AdjustCostVatAmt += pSource.pls_AdjustCostVatAmt;
      this.pls_AdjustPriceAmt += pSource.pls_AdjustPriceAmt;
      this.pls_AdjustPriceVatAmt += pSource.pls_AdjustPriceVatAmt;
      this.pls_AdjustPriceCostSumAmt += pSource.pls_AdjustPriceCostSumAmt;
      this.pls_AdjustPriceCostVatAmt += pSource.pls_AdjustPriceCostVatAmt;
      this.pls_DisuseQty += pSource.pls_DisuseQty;
      this.pls_DisuseCostAmt += pSource.pls_DisuseCostAmt;
      this.pls_DisuseCostVatAmt += pSource.pls_DisuseCostVatAmt;
      this.pls_DisusePriceAmt += pSource.pls_DisuseCostVatAmt;
      this.pls_DisusePriceVatAmt += pSource.pls_DisusePriceVatAmt;
      this.pls_DisusePriceCostSumAmt += pSource.pls_DisusePriceCostSumAmt;
      this.pls_DisusePriceCostVatAmt += pSource.pls_DisusePriceCostVatAmt;
      this.pls_PriceUp += pSource.pls_PriceUp;
      this.pls_PriceUpVat += pSource.pls_PriceUpVat;
      this.pls_PriceDown += pSource.pls_PriceDown;
      this.pls_PriceDownVat += pSource.pls_PriceDownVat;
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, TProfitLossSummary pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.pls_BaseQty.IsZero() && pSource.pls_EndQty.IsZero() && pSource.pls_SaleQty.IsZero() && pSource.pls_BuyQty.IsZero() && pSource.pls_ReturnQty.IsZero() && pSource.pls_InnerMoveOutQty.IsZero() && pSource.pls_InnerMoveInQty.IsZero() && pSource.pls_OuterMoveOutQty.IsZero() && pSource.pls_OuterMoveInQty.IsZero() && pSource.pls_AdjustQty.IsZero() && pSource.pls_DisuseQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.pls_BaseCostAmt.IsZero() && pSource.pls_BasePriceAmt.IsZero() && pSource.pls_EndCostAmt.IsZero() && pSource.pls_EndPriceAmt.IsZero() && pSource.pls_SaleAmt.IsZero() && pSource.pls_SaleProfit.IsZero() && pSource.pls_EnurySlip.IsZero() && pSource.pls_EnuryEnd.IsZero() && pSource.pls_DcAmtEvent.IsZero() && pSource.pls_DcAmtGoods.IsZero() && pSource.pls_DcAmtCoupon.IsZero() && pSource.pls_DcAmtPromotion.IsZero() && pSource.pls_DcAmtMember.IsZero() && pSource.pls_Customer.IsZero() && pSource.pls_CustomerGoods.IsZero() && pSource.pls_CustomerCategory.IsZero() && pSource.pls_CustomerSupplier.IsZero() && pSource.pls_BuyCostAmt.IsZero() && pSource.pls_ReturnCostAmt.IsZero() && pSource.pls_InnerMoveOutCostAmt.IsZero() && pSource.pls_InnerMoveInCostAmt.IsZero() && pSource.pls_OuterMoveOutCostAmt.IsZero() && pSource.pls_OuterMoveInCostAmt.IsZero() && pSource.pls_AdjustCostAmt.IsZero() && pSource.pls_AdjustPriceCostSumAmt.IsZero() && pSource.pls_DisuseCostAmt.IsZero() && pSource.pls_DisusePriceCostSumAmt.IsZero() && pSource.pls_PriceUp.IsZero() && pSource.pls_PriceDown.IsZero());

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public virtual bool ItemSave() => false;

    public virtual async Task<bool> ItemSaveAsync()
    {
      await Task.CompletedTask;
      return false;
    }

    public virtual string DataClearQuery(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        this.TableCode.ToString();
        if (!p_param.ContainsKey((object) "pls_YyyyMm") || Convert.ToInt32(p_param[(object) "pls_YyyyMm"].ToString()) == 0)
          throw new Exception("월 정보 데이터 부족.");
        stringBuilder.Append(string.Format(" UPDATE {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
        EnumDB enumDb = DbQueryHelper.DbTypeNotNull();
        if (enumDb == EnumDB.MYSQL)
          stringBuilder.Append(string.Format("\nINNER JOIN {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo) + " ON pls_StoreCode=si_StoreCode AND pls_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<pls_YyyyMm AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<pls_YyyyMm");
        stringBuilder.Append("\nSET  pls_BaseQty=0,pls_BaseAvgCost=0,pls_BaseCostAmt=0,pls_BaseCostVatAmt=0,pls_BasePrice=0,pls_BasePriceCostAmt=0,pls_BasePriceCostVatAmt=0,pls_BasePriceAmt=0,pls_BasePriceVatAmt=0,pls_EndQty=0,pls_EndAvgCost=0,pls_EndCostAmt=0,pls_EndCostVatAmt=0,pls_EndPrice=0,pls_EndPriceCostAmt=0,pls_EndPriceCostVatAmt=0,pls_EndPriceAmt=0,pls_EndPriceVatAmt=0,pls_SaleQty=0,pls_TotalSaleAmt=0,pls_SaleAmt=0,pls_SaleVatAmt=0,pls_SaleProfit=0,pls_SalePriceProfit=0,pls_EnurySlip=0,pls_EnuryEnd=0,pls_DcAmtManual=0,pls_DcAmtEvent=0,pls_DcAmtGoods=0,pls_DcAmtCoupon=0,pls_DcAmtPromotion=0,pls_DcAmtMember=0,pls_Customer=0,pls_CustomerGoods=0,pls_CustomerCategory=0,pls_CustomerSupplier=0,pls_BuyQty=0,pls_BuyCostAmt=0,pls_BuyCostVatAmt=0,pls_BuyPriceAmt=0,pls_BuyPriceVatAmt=0,pls_ReturnQty=0,pls_ReturnCostAmt=0,pls_ReturnCostVatAmt=0,pls_ReturnPriceAmt=0,pls_ReturnPriceVatAmt=0,pls_InnerMoveOutQty=0,pls_InnerMoveOutCostAmt=0,pls_InnerMoveOutCostVatAmt=0,pls_InnerMoveOutPriceAmt=0,pls_InnerMoveOutPriceVatAmt=0,pls_InnerMoveInQty=0,pls_InnerMoveInCostAmt=0,pls_InnerMoveInCostVatAmt=0,pls_InnerMoveInPriceAmt=0,pls_InnerMoveInPriceVatAmt=0,pls_OuterMoveOutQty=0,pls_OuterMoveOutCostAmt=0,pls_OuterMoveOutCostVatAmt=0,pls_OuterMoveOutPriceAmt=0,pls_OuterMoveOutPriceVatAmt=0,pls_OuterMoveInQty=0,pls_OuterMoveInCostAmt=0,pls_OuterMoveInCostVatAmt=0,pls_OuterMoveInPriceAmt=0,pls_OuterMoveInPriceVatAmt=0,pls_AdjustQty=0,pls_AdjustCostAmt=0,pls_AdjustCostVatAmt=0,pls_AdjustPriceAmt=0,pls_AdjustPriceVatAmt=0,pls_AdjustPriceCostSumAmt=0,pls_AdjustPriceCostVatAmt=0,pls_DisuseQty=0,pls_DisuseCostAmt=0,pls_DisuseCostVatAmt=0,pls_DisusePriceAmt=0,pls_DisusePriceVatAmt=0,pls_DisusePriceCostSumAmt=0,pls_DisusePriceCostVatAmt=0,pls_PriceUp=0,pls_PriceUpVat=0,pls_PriceDown=0,pls_PriceDownVat=0");
        if (enumDb == EnumDB.MSSQL)
          stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " ON pls_StoreCode=si_StoreCode AND pls_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<pls_YyyyMm AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<pls_YyyyMm");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pls_YyyyMm", p_param[(object) "pls_YyyyMm"]));
        if (p_param.ContainsKey((object) "pls_StoreCode") && Convert.ToInt32(p_param[(object) "pls_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_StoreCode", p_param[(object) "pls_StoreCode"]));
        else if (p_param.ContainsKey((object) "pls_StoreCode_IN_") && p_param[(object) "pls_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_StoreCode", p_param[(object) "pls_StoreCode_IN_"]));
        else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND pls_StoreCode > 0");
        if (p_param.ContainsKey((object) "pls_GoodsCode"))
        {
          if (Convert.ToInt64(p_param[(object) "pls_GoodsCode"].ToString()) > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_GoodsCode", p_param[(object) "pls_GoodsCode"]));
        }
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public virtual bool DataClear(Hashtable p_param)
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.DataClearQuery(p_param)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.pls_YyyyMm, (object) this.pls_StoreCode, (object) this.pls_GoodsCode, (object) this.pls_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> DataClearAsync(Hashtable p_param)
    {
      TProfitLossSummary tprofitLossSummary = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossSummary.\u003C\u003En__0();
      if (await tprofitLossSummary.OleDB.ExecuteAsync(tprofitLossSummary.DataClearQuery(p_param)))
        return true;
      tprofitLossSummary.message = " " + tprofitLossSummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossSummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossSummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tprofitLossSummary.pls_YyyyMm, (object) tprofitLossSummary.pls_StoreCode, (object) tprofitLossSummary.pls_GoodsCode, (object) tprofitLossSummary.pls_SiteID) + " 내용 : " + tprofitLossSummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossSummary.message);
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,pls_Supplier,pls_SupplierType,pls_CategoryCode,pls_TaxDiv,pls_StockUnit,pls_SalesUnit,pls_BaseQty,pls_BaseAvgCost,pls_BaseCostAmt,pls_BaseCostVatAmt,pls_BasePrice,pls_BasePriceCostAmt,pls_BasePriceCostVatAmt,pls_BasePriceAmt,pls_BasePriceVatAmt,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt,pls_SaleQty,pls_TotalSaleAmt,pls_SaleAmt,pls_SaleVatAmt,pls_SaleProfit,pls_SalePriceProfit,pls_EnurySlip,pls_EnuryEnd,pls_DcAmtManual,pls_DcAmtEvent,pls_DcAmtGoods,pls_DcAmtCoupon,pls_DcAmtPromotion,pls_DcAmtMember,pls_Customer,pls_CustomerGoods,pls_CustomerCategory,pls_CustomerSupplier,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_BuyPriceAmt,pls_BuyPriceVatAmt,pls_ReturnQty,pls_ReturnCostAmt,pls_ReturnCostVatAmt,pls_ReturnPriceAmt,pls_ReturnPriceVatAmt,pls_InnerMoveOutQty,pls_InnerMoveOutCostAmt,pls_InnerMoveOutCostVatAmt,pls_InnerMoveOutPriceAmt,pls_InnerMoveOutPriceVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_InnerMoveInPriceAmt,pls_InnerMoveInPriceVatAmt,pls_OuterMoveOutQty,pls_OuterMoveOutCostAmt,pls_OuterMoveOutCostVatAmt,pls_OuterMoveOutPriceAmt,pls_OuterMoveOutPriceVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt,pls_OuterMoveInPriceAmt,pls_OuterMoveInPriceVatAmt,pls_AdjustQty,pls_AdjustCostAmt,pls_AdjustCostVatAmt,pls_AdjustPriceAmt,pls_AdjustPriceVatAmt,pls_AdjustPriceCostSumAmt,pls_AdjustPriceCostVatAmt,pls_DisuseQty,pls_DisuseCostAmt,pls_DisuseCostVatAmt,pls_DisusePriceAmt,pls_DisusePriceVatAmt,pls_DisusePriceCostSumAmt,pls_DisusePriceCostVatAmt,pls_PriceUp,pls_PriceUpVat,pls_PriceDown,pls_PriceDownVat) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.pls_YyyyMm, (object) this.pls_StoreCode, (object) this.pls_GoodsCode) + string.Format(",{0}", (object) this.pls_SiteID) + string.Format(",{0},{1},{2}", (object) this.pls_Supplier, (object) this.pls_SupplierType, (object) this.pls_CategoryCode) + string.Format(",{0},{1},{2}", (object) this.pls_TaxDiv, (object) this.pls_StockUnit, (object) this.pls_SalesUnit) + "," + this.pls_BaseQty.FormatTo("{0:0.0000}") + "," + this.pls_BaseAvgCost.FormatTo("{0:0.0000}") + "," + this.pls_BaseCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_BaseCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_BasePrice.FormatTo("{0:0.0000}") + "," + this.pls_BasePriceCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_BasePriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_BasePriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndQty.FormatTo("{0:0.0000}") + "," + this.pls_EndAvgCost.FormatTo("{0:0.0000}") + "," + this.pls_EndCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndPrice.FormatTo("{0:0.0000}") + "," + this.pls_EndPriceCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_EndPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_SaleQty.FormatTo("{0:0.0000}") + "," + this.pls_TotalSaleAmt.FormatTo("{0:0.0000}") + "," + this.pls_SaleAmt.FormatTo("{0:0.0000}") + "," + this.pls_SaleVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_SaleProfit.FormatTo("{0:0.0000}") + "," + this.pls_SalePriceProfit.FormatTo("{0:0.0000}") + "," + this.pls_EnurySlip.FormatTo("{0:0.0000}") + "," + this.pls_EnuryEnd.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtManual.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtEvent.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtGoods.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtCoupon.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtPromotion.FormatTo("{0:0.0000}") + "," + this.pls_DcAmtMember.FormatTo("{0:0.0000}") + "," + this.pls_Customer.FormatTo("{0:0.0000}") + "," + this.pls_CustomerGoods.FormatTo("{0:0.0000}") + "," + this.pls_CustomerCategory.FormatTo("{0:0.0000}") + "," + this.pls_CustomerSupplier.FormatTo("{0:0.0000}") + "," + this.pls_BuyQty.FormatTo("{0:0.0000}") + "," + this.pls_BuyCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_BuyCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_BuyPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_BuyPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_ReturnQty.FormatTo("{0:0.0000}") + "," + this.pls_ReturnCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_ReturnCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_ReturnPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveOutQty.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveInQty.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveOutQty.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveInQty.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustQty.FormatTo("{0:0.0000}") + "," + this.pls_AdjustCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustPriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.pls_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisuseQty.FormatTo("{0:0.0000}") + "," + this.pls_DisuseCostAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisuseCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisusePriceAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisusePriceVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.pls_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.pls_PriceUp.FormatTo("{0:0.0000}") + "," + this.pls_PriceUpVat.FormatTo("{0:0.0000}") + "," + this.pls_PriceDown.FormatTo("{0:0.0000}") + "," + this.pls_PriceDownVat.FormatTo("{0:0.0000}") + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.pls_YyyyMm, (object) this.pls_StoreCode, (object) this.pls_GoodsCode, (object) this.pls_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProfitLossSummary tprofitLossSummary = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossSummary.\u003C\u003En__0();
      if (await tprofitLossSummary.OleDB.ExecuteAsync(tprofitLossSummary.InsertQuery()))
        return true;
      tprofitLossSummary.message = " " + tprofitLossSummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossSummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossSummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tprofitLossSummary.pls_YyyyMm, (object) tprofitLossSummary.pls_StoreCode, (object) tprofitLossSummary.pls_GoodsCode, (object) tprofitLossSummary.pls_SiteID) + " 내용 : " + tprofitLossSummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossSummary.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1},{2}={3},{4}={5}", (object) "pls_Supplier", (object) this.pls_Supplier, (object) "pls_SupplierType", (object) this.pls_SupplierType, (object) "pls_CategoryCode", (object) this.pls_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "pls_TaxDiv", (object) this.pls_TaxDiv, (object) "pls_StockUnit", (object) this.pls_StockUnit, (object) "pls_SalesUnit", (object) this.pls_SalesUnit) + ",pls_BaseQty=" + this.pls_BaseQty.FormatTo("{0:0.0000}") + ",pls_BaseAvgCost=" + this.pls_BaseAvgCost.FormatTo("{0:0.0000}") + ",pls_BaseCostAmt=" + this.pls_BaseCostAmt.FormatTo("{0:0.0000}") + ",pls_BaseCostVatAmt=" + this.pls_BaseCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BasePrice=" + this.pls_BasePrice.FormatTo("{0:0.0000}") + ",pls_BasePriceCostAmt=" + this.pls_BasePriceCostAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceCostVatAmt=" + this.pls_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceAmt=" + this.pls_BasePriceAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceVatAmt=" + this.pls_BasePriceVatAmt.FormatTo("{0:0.0000}") + ",pls_EndQty=" + this.pls_EndQty.FormatTo("{0:0.0000}") + ",pls_EndAvgCost=" + this.pls_EndAvgCost.FormatTo("{0:0.0000}") + ",pls_EndCostAmt=" + this.pls_EndCostAmt.FormatTo("{0:0.0000}") + ",pls_EndCostVatAmt=" + this.pls_EndCostVatAmt.FormatTo("{0:0.0000}") + ",pls_EndPrice=" + this.pls_EndPrice.FormatTo("{0:0.0000}") + ",pls_EndPriceCostAmt=" + this.pls_EndPriceCostAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceCostVatAmt=" + this.pls_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceAmt=" + this.pls_EndPriceAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceVatAmt=" + this.pls_EndPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_SaleQty=" + this.pls_SaleQty.FormatTo("{0:0.0000}") + ",pls_TotalSaleAmt=" + this.pls_TotalSaleAmt.FormatTo("{0:0.0000}") + ",pls_SaleAmt=" + this.pls_SaleAmt.FormatTo("{0:0.0000}") + ",pls_SaleVatAmt=" + this.pls_SaleVatAmt.FormatTo("{0:0.0000}") + ",pls_SaleProfit=" + this.pls_SaleProfit.FormatTo("{0:0.0000}") + ",pls_SalePriceProfit=" + this.pls_SalePriceProfit.FormatTo("{0:0.0000}") + ",pls_EnurySlip=" + this.pls_EnurySlip.FormatTo("{0:0.0000}") + ",pls_EnuryEnd=" + this.pls_EnuryEnd.FormatTo("{0:0.0000}") + ",pls_DcAmtManual=" + this.pls_DcAmtManual.FormatTo("{0:0.0000}") + ",pls_DcAmtEvent=" + this.pls_DcAmtEvent.FormatTo("{0:0.0000}") + ",pls_DcAmtGoods=" + this.pls_DcAmtGoods.FormatTo("{0:0.0000}") + ",pls_DcAmtCoupon=" + this.pls_DcAmtCoupon.FormatTo("{0:0.0000}") + ",pls_DcAmtPromotion=" + this.pls_DcAmtPromotion.FormatTo("{0:0.0000}") + ",pls_DcAmtMember=" + this.pls_DcAmtMember.FormatTo("{0:0.0000}") + ",pls_Customer=" + this.pls_Customer.FormatTo("{0:0.0000}") + ",pls_CustomerGoods=" + this.pls_CustomerGoods.FormatTo("{0:0.0000}") + ",pls_CustomerCategory=" + this.pls_CustomerCategory.FormatTo("{0:0.0000}") + ",pls_CustomerSupplier=" + this.pls_CustomerSupplier.FormatTo("{0:0.0000}") + ",pls_BuyQty=" + this.pls_BuyQty.FormatTo("{0:0.0000}") + ",pls_BuyCostAmt=" + this.pls_BuyCostAmt.FormatTo("{0:0.0000}") + ",pls_BuyCostVatAmt=" + this.pls_BuyCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BuyPriceAmt=" + this.pls_BuyPriceAmt.FormatTo("{0:0.0000}") + ",pls_BuyPriceVatAmt=" + this.pls_BuyPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_ReturnQty=" + this.pls_ReturnQty.FormatTo("{0:0.0000}") + ",pls_ReturnCostAmt=" + this.pls_ReturnCostAmt.FormatTo("{0:0.0000}") + ",pls_ReturnCostVatAmt=" + this.pls_ReturnCostVatAmt.FormatTo("{0:0.0000}") + ",pls_ReturnPriceAmt=" + this.pls_ReturnPriceAmt.FormatTo("{0:0.0000}") + ",pls_ReturnPriceVatAmt=" + this.pls_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutQty=" + this.pls_InnerMoveOutQty.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutCostAmt=" + this.pls_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutCostVatAmt=" + this.pls_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutPriceAmt=" + this.pls_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutPriceVatAmt=" + this.pls_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInQty=" + this.pls_InnerMoveInQty.FormatTo("{0:0.0000}") + ",pls_InnerMoveInCostAmt=" + this.pls_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInCostVatAmt=" + this.pls_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInPriceAmt=" + this.pls_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInPriceVatAmt=" + this.pls_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutQty=" + this.pls_OuterMoveOutQty.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutCostAmt=" + this.pls_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutCostVatAmt=" + this.pls_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutPriceAmt=" + this.pls_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutPriceVatAmt=" + this.pls_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInQty=" + this.pls_OuterMoveInQty.FormatTo("{0:0.0000}") + ",pls_OuterMoveInCostAmt=" + this.pls_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInCostVatAmt=" + this.pls_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInPriceAmt=" + this.pls_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInPriceVatAmt=" + this.pls_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustQty=" + this.pls_AdjustQty.FormatTo("{0:0.0000}") + ",pls_AdjustCostAmt=" + this.pls_AdjustCostAmt.FormatTo("{0:0.0000}") + ",pls_AdjustCostVatAmt=" + this.pls_AdjustCostVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceAmt=" + this.pls_AdjustPriceAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceVatAmt=" + this.pls_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceCostSumAmt=" + this.pls_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceCostVatAmt=" + this.pls_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_DisuseQty=" + this.pls_DisuseQty.FormatTo("{0:0.0000}") + ",pls_DisuseCostAmt=" + this.pls_DisuseCostAmt.FormatTo("{0:0.0000}") + ",pls_DisuseCostVatAmt=" + this.pls_DisuseCostVatAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceAmt=" + this.pls_DisusePriceAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceVatAmt=" + this.pls_DisusePriceVatAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceCostSumAmt=" + this.pls_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceCostVatAmt=" + this.pls_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_PriceUp=" + this.pls_PriceUp.FormatTo("{0:0.0000}") + ",pls_PriceUpVat=" + this.pls_PriceUpVat.FormatTo("{0:0.0000}") + ",pls_PriceDown=" + this.pls_PriceDown.FormatTo("{0:0.0000}") + ",pls_PriceDownVat=" + this.pls_PriceDownVat.FormatTo("{0:0.0000}") + string.Format(" WHERE {0}={1}", (object) "pls_YyyyMm", (object) this.pls_YyyyMm) + string.Format(" AND {0}={1}", (object) "pls_StoreCode", (object) this.pls_StoreCode) + string.Format(" AND {0}={1}", (object) "pls_GoodsCode", (object) this.pls_GoodsCode) + string.Format(" AND {0}={1}", (object) "pls_SiteID", (object) this.pls_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.pls_YyyyMm, (object) this.pls_StoreCode, (object) this.pls_GoodsCode, (object) this.pls_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProfitLossSummary tprofitLossSummary = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossSummary.\u003C\u003En__1();
      if (await tprofitLossSummary.OleDB.ExecuteAsync(tprofitLossSummary.UpdateQuery()))
        return true;
      tprofitLossSummary.message = " " + tprofitLossSummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossSummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossSummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tprofitLossSummary.pls_YyyyMm, (object) tprofitLossSummary.pls_StoreCode, (object) tprofitLossSummary.pls_GoodsCode, (object) tprofitLossSummary.pls_SiteID) + " 내용 : " + tprofitLossSummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossSummary.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(string.Format(" {0}={1},{2}={3},{4}={5}", (object) "pls_Supplier", (object) this.pls_Supplier, (object) "pls_SupplierType", (object) this.pls_SupplierType, (object) "pls_CategoryCode", (object) this.pls_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "pls_TaxDiv", (object) this.pls_TaxDiv, (object) "pls_StockUnit", (object) this.pls_StockUnit, (object) "pls_SalesUnit", (object) this.pls_SalesUnit) + ",pls_BaseQty=" + this.pls_BaseQty.FormatTo("{0:0.0000}") + ",pls_BaseAvgCost=" + this.pls_BaseAvgCost.FormatTo("{0:0.0000}") + ",pls_BaseCostAmt=" + this.pls_BaseCostAmt.FormatTo("{0:0.0000}") + ",pls_BaseCostVatAmt=" + this.pls_BaseCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BasePrice=" + this.pls_BasePrice.FormatTo("{0:0.0000}") + ",pls_BasePriceCostAmt=" + this.pls_BasePriceCostAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceCostVatAmt=" + this.pls_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceAmt=" + this.pls_BasePriceAmt.FormatTo("{0:0.0000}") + ",pls_BasePriceVatAmt=" + this.pls_BasePriceVatAmt.FormatTo("{0:0.0000}") + ",pls_EndQty=" + this.pls_EndQty.FormatTo("{0:0.0000}") + ",pls_EndAvgCost=" + this.pls_EndAvgCost.FormatTo("{0:0.0000}") + ",pls_EndCostAmt=" + this.pls_EndCostAmt.FormatTo("{0:0.0000}") + ",pls_EndCostVatAmt=" + this.pls_EndCostVatAmt.FormatTo("{0:0.0000}") + ",pls_EndPrice=" + this.pls_EndPrice.FormatTo("{0:0.0000}") + ",pls_EndPriceCostAmt=" + this.pls_EndPriceCostAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceCostVatAmt=" + this.pls_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceAmt=" + this.pls_EndPriceAmt.FormatTo("{0:0.0000}") + ",pls_EndPriceVatAmt=" + this.pls_EndPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_SaleQty=" + this.pls_SaleQty.FormatTo("{0:0.0000}") + ",pls_TotalSaleAmt=" + this.pls_TotalSaleAmt.FormatTo("{0:0.0000}") + ",pls_SaleAmt=" + this.pls_SaleAmt.FormatTo("{0:0.0000}") + ",pls_SaleVatAmt=" + this.pls_SaleVatAmt.FormatTo("{0:0.0000}") + ",pls_SaleProfit=" + this.pls_SaleProfit.FormatTo("{0:0.0000}") + ",pls_SalePriceProfit=" + this.pls_SalePriceProfit.FormatTo("{0:0.0000}") + ",pls_EnurySlip=" + this.pls_EnurySlip.FormatTo("{0:0.0000}") + ",pls_EnuryEnd=" + this.pls_EnuryEnd.FormatTo("{0:0.0000}") + ",pls_DcAmtManual=" + this.pls_DcAmtManual.FormatTo("{0:0.0000}") + ",pls_DcAmtEvent=" + this.pls_DcAmtEvent.FormatTo("{0:0.0000}") + ",pls_DcAmtGoods=" + this.pls_DcAmtGoods.FormatTo("{0:0.0000}") + ",pls_DcAmtCoupon=" + this.pls_DcAmtCoupon.FormatTo("{0:0.0000}") + ",pls_DcAmtPromotion=" + this.pls_DcAmtPromotion.FormatTo("{0:0.0000}") + ",pls_DcAmtMember=" + this.pls_DcAmtMember.FormatTo("{0:0.0000}") + ",pls_Customer=" + this.pls_Customer.FormatTo("{0:0.0000}") + ",pls_CustomerGoods=" + this.pls_CustomerGoods.FormatTo("{0:0.0000}") + ",pls_CustomerCategory=" + this.pls_CustomerCategory.FormatTo("{0:0.0000}") + ",pls_CustomerSupplier=" + this.pls_CustomerSupplier.FormatTo("{0:0.0000}") + ",pls_BuyQty=" + this.pls_BuyQty.FormatTo("{0:0.0000}") + ",pls_BuyCostAmt=" + this.pls_BuyCostAmt.FormatTo("{0:0.0000}") + ",pls_BuyCostVatAmt=" + this.pls_BuyCostVatAmt.FormatTo("{0:0.0000}") + ",pls_BuyPriceAmt=" + this.pls_BuyPriceAmt.FormatTo("{0:0.0000}") + ",pls_BuyPriceVatAmt=" + this.pls_BuyPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_ReturnQty=" + this.pls_ReturnQty.FormatTo("{0:0.0000}") + ",pls_ReturnCostAmt=" + this.pls_ReturnCostAmt.FormatTo("{0:0.0000}") + ",pls_ReturnCostVatAmt=" + this.pls_ReturnCostVatAmt.FormatTo("{0:0.0000}") + ",pls_ReturnPriceAmt=" + this.pls_ReturnPriceAmt.FormatTo("{0:0.0000}") + ",pls_ReturnPriceVatAmt=" + this.pls_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutQty=" + this.pls_InnerMoveOutQty.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutCostAmt=" + this.pls_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutCostVatAmt=" + this.pls_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutPriceAmt=" + this.pls_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveOutPriceVatAmt=" + this.pls_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInQty=" + this.pls_InnerMoveInQty.FormatTo("{0:0.0000}") + ",pls_InnerMoveInCostAmt=" + this.pls_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInCostVatAmt=" + this.pls_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInPriceAmt=" + this.pls_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + ",pls_InnerMoveInPriceVatAmt=" + this.pls_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutQty=" + this.pls_OuterMoveOutQty.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutCostAmt=" + this.pls_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutCostVatAmt=" + this.pls_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutPriceAmt=" + this.pls_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveOutPriceVatAmt=" + this.pls_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInQty=" + this.pls_OuterMoveInQty.FormatTo("{0:0.0000}") + ",pls_OuterMoveInCostAmt=" + this.pls_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInCostVatAmt=" + this.pls_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInPriceAmt=" + this.pls_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + ",pls_OuterMoveInPriceVatAmt=" + this.pls_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustQty=" + this.pls_AdjustQty.FormatTo("{0:0.0000}") + ",pls_AdjustCostAmt=" + this.pls_AdjustCostAmt.FormatTo("{0:0.0000}") + ",pls_AdjustCostVatAmt=" + this.pls_AdjustCostVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceAmt=" + this.pls_AdjustPriceAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceVatAmt=" + this.pls_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceCostSumAmt=" + this.pls_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",pls_AdjustPriceCostVatAmt=" + this.pls_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_DisuseQty=" + this.pls_DisuseQty.FormatTo("{0:0.0000}") + ",pls_DisuseCostAmt=" + this.pls_DisuseCostAmt.FormatTo("{0:0.0000}") + ",pls_DisuseCostVatAmt=" + this.pls_DisuseCostVatAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceAmt=" + this.pls_DisusePriceAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceVatAmt=" + this.pls_DisusePriceVatAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceCostSumAmt=" + this.pls_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + ",pls_DisusePriceCostVatAmt=" + this.pls_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + ",pls_PriceUp=" + this.pls_PriceUp.FormatTo("{0:0.0000}") + ",pls_PriceUpVat=" + this.pls_PriceUpVat.FormatTo("{0:0.0000}") + ",pls_PriceDown=" + this.pls_PriceDown.FormatTo("{0:0.0000}") + ",pls_PriceDownVat=" + this.pls_PriceDownVat.FormatTo("{0:0.0000}"));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.pls_YyyyMm, (object) this.pls_StoreCode, (object) this.pls_GoodsCode, (object) this.pls_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProfitLossSummary tprofitLossSummary = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossSummary.\u003C\u003En__1();
      if (await tprofitLossSummary.OleDB.ExecuteAsync(tprofitLossSummary.UpdateExInsertQuery()))
        return true;
      tprofitLossSummary.message = " " + tprofitLossSummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossSummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossSummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tprofitLossSummary.pls_YyyyMm, (object) tprofitLossSummary.pls_StoreCode, (object) tprofitLossSummary.pls_GoodsCode, (object) tprofitLossSummary.pls_SiteID) + " 내용 : " + tprofitLossSummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossSummary.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pls_SiteID") && Convert.ToInt64(hashtable[(object) "pls_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pls_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pls_YyyyMm") && Convert.ToInt32(hashtable[(object) "pls_YyyyMm"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_YyyyMm", hashtable[(object) "pls_YyyyMm"]));
        if (hashtable.ContainsKey((object) "pls_YyyyMm_BEGIN_") && Convert.ToInt32(hashtable[(object) "pls_YyyyMm_BEGIN_"].ToString()) > 0 && hashtable.ContainsKey((object) "pls_YyyyMm_END_") && Convert.ToInt32(hashtable[(object) "pls_YyyyMm_END_"].ToString()) > 0)
        {
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "pls_YyyyMm", hashtable[(object) "pls_YyyyMm_BEGIN_"]));
          stringBuilder.Append(string.Format(" AND {0}<={1}", (object) "pls_YyyyMm", hashtable[(object) "pls_YyyyMm_END_"]));
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "pls_StoreCode") && Convert.ToInt32(hashtable[(object) "pls_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_StoreCode", hashtable[(object) "pls_StoreCode"]));
        else if (hashtable.ContainsKey((object) "pls_StoreCode_IN_") && hashtable[(object) "pls_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_StoreCode", hashtable[(object) "pls_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_GoodsCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "gd_GoodsCode_IN_") && hashtable[(object) "gd_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_GoodsCode", hashtable[(object) "gd_GoodsCode_IN_"]));
        else if (hashtable.ContainsKey((object) "pls_GoodsCode") && Convert.ToInt64(hashtable[(object) "pls_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_GoodsCode", hashtable[(object) "pls_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "pls_GoodsCode_IN_") && hashtable[(object) "pls_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_GoodsCode", hashtable[(object) "pls_GoodsCode_IN_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "pls_Supplier") && Convert.ToInt32(hashtable[(object) "pls_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_Supplier", hashtable[(object) "pls_Supplier"]));
        else if (hashtable.ContainsKey((object) "pls_Supplier_IN_") && hashtable[(object) "pls_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_Supplier", hashtable[(object) "pls_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pls_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_Supplier", hashtable[(object) "su_SupplierType"]));
        else if (hashtable.ContainsKey((object) "pls_SupplierType") && Convert.ToInt32(hashtable[(object) "pls_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_SupplierType", hashtable[(object) "pls_SupplierType"]));
        if (hashtable.ContainsKey((object) "pls_CategoryCode") && Convert.ToInt32(hashtable[(object) "pls_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_CategoryCode", hashtable[(object) "pls_CategoryCode"]));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        else if (hashtable.ContainsKey((object) "pls_TaxDiv") && Convert.ToInt32(hashtable[(object) "pls_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_TaxDiv", hashtable[(object) "pls_TaxDiv"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_StockUnit", hashtable[(object) "gd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "pls_StockUnit") && Convert.ToInt32(hashtable[(object) "pls_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_StockUnit", hashtable[(object) "pls_StockUnit"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "pls_SalesUnit") && Convert.ToInt32(hashtable[(object) "pls_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pls_SalesUnit", hashtable[(object) "pls_SalesUnit"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  pls_YyyyMm,pls_StoreCode,pls_GoodsCode,pls_SiteID,pls_Supplier,pls_SupplierType,pls_CategoryCode,pls_TaxDiv,pls_StockUnit,pls_SalesUnit,pls_BaseQty,pls_BaseAvgCost,pls_BaseCostAmt,pls_BaseCostVatAmt,pls_BasePrice,pls_BasePriceCostAmt,pls_BasePriceCostVatAmt,pls_BasePriceAmt,pls_BasePriceVatAmt,pls_EndQty,pls_EndAvgCost,pls_EndCostAmt,pls_EndCostVatAmt,pls_EndPrice,pls_EndPriceCostAmt,pls_EndPriceCostVatAmt,pls_EndPriceAmt,pls_EndPriceVatAmt,pls_SaleQty,pls_TotalSaleAmt,pls_SaleAmt,pls_SaleVatAmt,pls_SaleProfit,pls_SalePriceProfit,pls_EnurySlip,pls_EnuryEnd,pls_DcAmtManual,pls_DcAmtEvent,pls_DcAmtGoods,pls_DcAmtCoupon,pls_DcAmtPromotion,pls_DcAmtMember,pls_Customer,pls_CustomerGoods,pls_CustomerCategory,pls_CustomerSupplier,pls_BuyQty,pls_BuyCostAmt,pls_BuyCostVatAmt,pls_BuyPriceAmt,pls_BuyPriceVatAmt,pls_ReturnQty,pls_ReturnCostAmt,pls_ReturnCostVatAmt,pls_ReturnPriceAmt,pls_ReturnPriceVatAmt,pls_InnerMoveOutQty,pls_InnerMoveOutCostAmt,pls_InnerMoveOutCostVatAmt,pls_InnerMoveOutPriceAmt,pls_InnerMoveOutPriceVatAmt,pls_InnerMoveInQty,pls_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt,pls_InnerMoveInPriceAmt,pls_InnerMoveInPriceVatAmt,pls_OuterMoveOutQty,pls_OuterMoveOutCostAmt,pls_OuterMoveOutCostVatAmt,pls_OuterMoveOutPriceAmt,pls_OuterMoveOutPriceVatAmt,pls_OuterMoveInQty,pls_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt,pls_OuterMoveInPriceAmt,pls_OuterMoveInPriceVatAmt,pls_AdjustQty,pls_AdjustCostAmt,pls_AdjustCostVatAmt,pls_AdjustPriceAmt,pls_AdjustPriceVatAmt,pls_AdjustPriceCostSumAmt,pls_AdjustPriceCostVatAmt,pls_DisuseQty,pls_DisuseCostAmt,pls_DisuseCostVatAmt,pls_DisusePriceAmt,pls_DisusePriceVatAmt,pls_DisusePriceCostSumAmt,pls_DisusePriceCostVatAmt,pls_PriceUp,pls_PriceUpVat,pls_PriceDown,pls_PriceDownVat");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public Hashtable SearchConditionProfitLossSummaryDefult(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
          hashtable.Add((object) "pls_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
    }

    public Hashtable SearchConditionProfitLossSummaryStart(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionProfitLossSummaryDefult(p_param);
      if (p_param.ContainsKey((object) "_DT_START_DATE_"))
      {
        DateTime p_day = (DateTime) p_param[(object) "_DT_START_DATE_"];
        hashtable.Add((object) "pls_YyyyMm", (object) p_day.ToIntFormat("yyyyMM"));
      }
      return hashtable;
    }

    public Hashtable SearchConditionProfitLossSummaryMiddle(Hashtable p_param, bool p_IsLastDay)
    {
      Hashtable hashtable = this.SearchConditionProfitLossSummaryDefult(p_param);
      if (p_param.ContainsKey((object) "_DT_START_DATE_"))
      {
        DateTime p_day = (DateTime) p_param[(object) "_DT_START_DATE_"];
        hashtable.Add((object) "pls_YyyyMm_BEGIN_", (object) p_day.ToIntFormat("yyyyMM"));
      }
      if (p_param.ContainsKey((object) "_DT_END_DATE_"))
      {
        DateTime dateAdd = (DateTime) p_param[(object) "_DT_END_DATE_"];
        if (!p_IsLastDay)
          dateAdd = dateAdd.GetDateAdd(0, -1, 0);
        hashtable.Add((object) "pls_YyyyMm_END_", (object) dateAdd.ToIntFormat("yyyyMM"));
      }
      return hashtable;
    }

    public Hashtable SearchConditionProfitLossSummaryEnd(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionProfitLossSummaryDefult(p_param);
      if (p_param.ContainsKey((object) "_DT_END_DATE_"))
      {
        DateTime p_day = (DateTime) p_param[(object) "_DT_END_DATE_"];
        hashtable.Add((object) "pls_YyyyMm", (object) p_day.ToIntFormat("yyyyMM"));
      }
      return hashtable;
    }

    public Hashtable SearchConditionDateSalesByDay(Hashtable p_param, bool p_IsDirect = true)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
          hashtable.Add((object) "sbd_SiteID", dictionaryEntry.Value);
        if (!p_IsDirect && dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
          hashtable.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
        {
          DateTime p_day = (DateTime) dictionaryEntry.Value;
          if (p_IsDirect)
            hashtable.Add((object) "sbd_SaleDate_BEGIN_", (object) p_day.ToFirstDateOfMonth());
          hashtable.Add((object) "sbd_SaleDate_END_", dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_StockUnit"))
          hashtable.Add((object) "sbd_StockUnit", dictionaryEntry.Value);
      }
      return hashtable;
    }

    public Hashtable SearchConditionDateStatement(Hashtable p_param, bool p_IsDirect = true)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
          hashtable.Add((object) "sh_SiteID", dictionaryEntry.Value);
        if (!p_IsDirect && dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
          hashtable.Add((object) "sbd_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
        {
          DateTime p_day = (DateTime) dictionaryEntry.Value;
          if (p_IsDirect)
            hashtable.Add((object) "sh_ConfirmDate_BEGIN_", (object) p_day.ToFirstDateOfMonth());
          hashtable.Add((object) "sh_ConfirmDate_END_", dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("pls_StockUnit"))
          hashtable.Add((object) "sd_StockUnit", dictionaryEntry.Value);
      }
      return hashtable;
    }

    public string ToStatementWhereAnd(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param.ContainsKey((object) "sh_SiteID") && Convert.ToInt64(p_param[(object) "sh_SiteID"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SiteID", (object) Convert.ToInt64(p_param[(object) "sh_SiteID"].ToString())));
      if (p_param.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(p_param[(object) "si_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", p_param[(object) "si_StoreCode"]));
      else if (p_param.ContainsKey((object) "si_StoreCode_IN_") && p_param[(object) "si_StoreCode_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "si_StoreCode_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
      }
      else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
      if (p_param.ContainsKey((object) "sh_StatementType") && Convert.ToInt32(p_param[(object) "sh_StatementType"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", p_param[(object) "sh_StatementType"]));
      else if (p_param.ContainsKey((object) "sh_StatementType_IN_") && p_param[(object) "sh_StatementType_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "sh_StatementType_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StatementType", p_param[(object) "sh_StatementType_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", p_param[(object) "sh_StatementType_IN_"]));
      }
      if (p_param.ContainsKey((object) "sh_ConfirmDate"))
      {
        stringBuilder.Append(" AND sh_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND sh_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "sh_ConfirmDate_BEGIN_") && p_param.ContainsKey((object) "sh_ConfirmDate_END_"))
      {
        stringBuilder.Append(" AND sh_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND sh_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "sh_ConfirmDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", (object) 1));
      if (p_param.ContainsKey((object) "sh_InOutDiv") && Convert.ToInt32(p_param[(object) "sh_InOutDiv"].ToString()) != 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", p_param[(object) "sh_InOutDiv"]));
      if (p_param.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(p_param[(object) "su_SupplierType"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", p_param[(object) "su_SupplierType"]));
      else if (p_param.ContainsKey((object) "su_SupplierType_IN_") && p_param[(object) "su_SupplierType_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_SupplierType_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_SupplierType", p_param[(object) "su_SupplierType_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", p_param[(object) "su_SupplierType_IN_"]));
      }
      if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", p_param[(object) "su_Supplier"]));
      else if (p_param.ContainsKey((object) "su_Supplier_IN_") && p_param[(object) "su_Supplier_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      else if (p_param.ContainsKey((object) "_SUPPLIER_AUTHS_") && p_param[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      if (p_param.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(p_param[(object) "gd_GoodsCode"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_BoxCode", p_param[(object) "gd_GoodsCode"]));
      else if (p_param.ContainsKey((object) "sd_BoxCode") && Convert.ToInt64(p_param[(object) "sd_BoxCode"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_GoodsCode", p_param[(object) "sd_BoxCode"]));
      if (p_param.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(p_param[(object) "gd_TaxDiv"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_TaxDiv", p_param[(object) "gd_TaxDiv"]));
      if (p_param.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(p_param[(object) "gd_SalesUnit"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_SalesUnit", p_param[(object) "gd_SalesUnit"]));
      else if (p_param.ContainsKey((object) "gd_SalesUnit_IN_") && p_param[(object) "gd_SalesUnit_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_SalesUnit", p_param[(object) "gd_SalesUnit_IN_"]));
      if (p_param.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(p_param[(object) "gd_StockUnit"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sd_StockUnit", p_param[(object) "gd_StockUnit"]));
      else if (p_param.ContainsKey((object) "gd_StockUnit_IN_") && p_param[(object) "gd_StockUnit_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sd_StockUnit", p_param[(object) "gd_StockUnit_IN_"]));
      stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4));
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV1_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV2_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV3_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_1_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_2_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_3_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryInvtQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_CATEGORY AS (SELECT ctg_ID,ctg_SiteID,ctg_DepositYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "ctg_SiteID", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "ctg_SiteID"))
            p_param1.Add((object) "ctg_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TCategory().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "TCategory", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_GOODS AS ( SELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_SalesUnit,gd_StockUnit,gd_BoxGoodsCode,gd_MakerCode,gd_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
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
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsHistoryQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_isStoreTotal = false)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_ChargeRate\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=gdh_Supplier AND su_SiteID=gdh_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("pls_GoodsCode"))
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
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          if (p_isStoreTotal && !p_param1.ContainsKey((object) "gdh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", (object) 1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithBookmarkGoodsQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      int p_bgg_GroupID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_bgg_GroupID > 0)
        {
          stringBuilder.Append("\n,T_BOOKMARK_GOODS AS ( SELECT bgl_GoodsCode,bgl_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) p_bgg_GroupID));
          if (p_SiteID > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) p_SiteID));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
        }
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
