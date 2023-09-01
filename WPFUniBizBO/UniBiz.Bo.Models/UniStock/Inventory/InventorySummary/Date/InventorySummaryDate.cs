// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.Date.InventorySummaryDate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.Date
{
  public class InventorySummaryDate : TInventorySummary<InventorySummaryDate>
  {
    private int _rowDataType;
    private int _ivts_Days;
    [JsonIgnore]
    public static string TProfitLossSummaryStartCol = ", pls_BaseQty AS ivts_BaseQty,pls_BaseAvgCost AS ivts_BaseAvgCost,pls_BaseCostAmt AS ivts_BaseCostAmt,pls_BaseCostVatAmt AS ivts_BaseCostVatAmt,pls_BasePrice AS ivts_BasePrice,pls_BasePriceCostAmt AS ivts_BasePriceCostAmt,pls_BasePriceCostVatAmt AS ivts_BasePriceCostVatAmt,pls_BasePriceAmt AS ivts_BasePriceAmt,pls_BasePriceVatAmt AS ivts_BasePriceVatAmt,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt,0 AS ivts_SaleQty,0 AS ivts_TotalSaleAmt,0 AS ivts_SaleAmt,0 AS ivts_SaleVatAmt,0 AS ivts_SaleProfit,0 AS ivts_SalePriceProfit,0 AS ivts_EnurySlip,0 AS ivts_EnuryEnd,0 AS ivts_DcAmtManual,0 AS ivts_DcAmtEvent,0 AS ivts_DcAmtGoods,0 AS ivts_DcAmtCoupon,0 AS ivts_DcAmtPromotion,0 AS ivts_DcAmtMember,0 AS ivts_Customer,0 AS ivts_CustomerGoods,0 AS ivts_CustomerCategory,0 AS ivts_CustomerSupplier,0 AS ivts_BuyQty,0 AS ivts_BuyCostAmt,0 AS ivts_BuyCostVatAmt,0 AS ivts_BuyPriceAmt,0 AS ivts_BuyPriceVatAmt,0 AS ivts_ReturnQty,0 AS ivts_ReturnCostAmt,0 AS ivts_ReturnCostVatAmt,0 AS ivts_ReturnPriceAmt,0 AS ivts_ReturnPriceVatAmt,0 AS ivts_InnerMoveOutQty,0 AS ivts_InnerMoveOutCostAmt,0 AS ivts_InnerMoveOutCostVatAmt,0 AS ivts_InnerMoveOutPriceAmt,0 AS ivts_InnerMoveOutPriceVatAmt,0 AS ivts_InnerMoveInQty,0 AS ivts_InnerMoveInCostAmt,0 AS ivts_InnerMoveInCostVatAmt,0 AS ivts_InnerMoveInPriceAmt,0 AS ivts_InnerMoveInPriceVatAmt,0 AS ivts_OuterMoveOutQty,0 AS ivts_OuterMoveOutCostAmt,0 AS ivts_OuterMoveOutCostVatAmt,0 AS ivts_OuterMoveOutPriceAmt,0 AS ivts_OuterMoveOutPriceVatAmt,0 AS ivts_OuterMoveInQty,0 AS ivts_OuterMoveInCostAmt,0 AS ivts_OuterMoveInCostVatAmt,0 AS ivts_OuterMoveInPriceAmt,0 AS ivts_OuterMoveInPriceVatAmt,0 AS ivts_PreAdjustQty,0 AS ivts_PreAdjustCostAmt,0 AS ivts_PreAdjustCostVatAmt,0 AS ivts_PreAdjustPriceAmt,0 AS ivts_PreAdjustPriceVatAmt,0 AS ivts_PreAdjustPriceCostSumAmt,0 AS ivts_PreAdjustPriceCostVatAmt,0 AS ivts_DisuseQty,0 AS ivts_DisuseCostAmt,0 AS ivts_DisuseCostVatAmt,0 AS ivts_DisusePriceAmt,0 AS ivts_DisusePriceVatAmt,0 AS ivts_DisusePriceCostSumAmt,0 AS ivts_DisusePriceCostVatAmt,0 AS ivts_PriceUp,0 AS ivts_PriceUpVat,0 AS ivts_PriceDown,0 AS ivts_PriceDownVat,0 AS ivts_InventoryQty,0 AS ivts_InventoryCostAmt,0 AS ivts_InventoryCostVatAmt,0 AS ivts_InventoryPriceAmt,0 AS ivts_InventoryPriceVatAmt,0 AS ivts_InventoryPriceCostSumAmt,0 AS ivts_InventoryPriceCostVatAmt,0 AS ivts_IsInventory,0 AS ivts_AdjustQty,0 AS ivts_AdjustCostAmt,0 AS ivts_AdjustCostVatAmt,0 AS ivts_AdjustPriceAmt,0 AS ivts_AdjustPriceVatAmt,0 AS ivts_AdjustPriceCostSumAmt,0 AS ivts_AdjustPriceCostVatAmt,0 AS ivts_LossQty,0 AS ivts_LossCostAmt,0 AS ivts_LossCostVatAmt,0 AS ivts_LossPriceAmt,0 AS ivts_LossPriceVatAmt,0 AS ivts_LossPriceCostSumAmt,0 AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public static string TProfitLossSummaryStartSumCol = ",SUM(pls_BaseQty) AS ivts_BaseQty,SUM(pls_BaseAvgCost) AS ivts_BaseAvgCost,SUM(pls_BaseCostAmt) AS ivts_BaseCostAmt,SUM(pls_BaseCostVatAmt) AS ivts_BaseCostVatAmt,SUM(pls_BasePrice) AS ivts_BasePrice,SUM(pls_BasePriceCostAmt) AS ivts_BasePriceCostAmt,SUM(pls_BasePriceCostVatAmt) AS ivts_BasePriceCostVatAmt,SUM(pls_BasePriceAmt) AS ivts_BasePriceAmt,SUM(pls_BasePriceVatAmt) AS ivts_BasePriceVatAmt,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt,0 AS ivts_SaleQty,0 AS ivts_TotalSaleAmt,0 AS ivts_SaleAmt,0 AS ivts_SaleVatAmt,0 AS ivts_SaleProfit,0 AS ivts_SalePriceProfit,0 AS ivts_EnurySlip,0 AS ivts_EnuryEnd,0 AS ivts_DcAmtManual,0 AS ivts_DcAmtEvent,0 AS ivts_DcAmtGoods,0 AS ivts_DcAmtCoupon,0 AS ivts_DcAmtPromotion,0 AS ivts_DcAmtMember,0 AS ivts_Customer,0 AS ivts_CustomerGoods,0 AS ivts_CustomerCategory,0 AS ivts_CustomerSupplier,0 AS ivts_BuyQty,0 AS ivts_BuyCostAmt,0 AS ivts_BuyCostVatAmt,0 AS ivts_BuyPriceAmt,0 AS ivts_BuyPriceVatAmt,0 AS ivts_ReturnQty,0 AS ivts_ReturnCostAmt,0 AS ivts_ReturnCostVatAmt,0 AS ivts_ReturnPriceAmt,0 AS ivts_ReturnPriceVatAmt,0 AS ivts_InnerMoveOutQty,0 AS ivts_InnerMoveOutCostAmt,0 AS ivts_InnerMoveOutCostVatAmt,0 AS ivts_InnerMoveOutPriceAmt,0 AS ivts_InnerMoveOutPriceVatAmt,0 AS ivts_InnerMoveInQty,0 AS ivts_InnerMoveInCostAmt,0 AS ivts_InnerMoveInCostVatAmt,0 AS ivts_InnerMoveInPriceAmt,0 AS ivts_InnerMoveInPriceVatAmt,0 AS ivts_OuterMoveOutQty,0 AS ivts_OuterMoveOutCostAmt,0 AS ivts_OuterMoveOutCostVatAmt,0 AS ivts_OuterMoveOutPriceAmt,0 AS ivts_OuterMoveOutPriceVatAmt,0 AS ivts_OuterMoveInQty,0 AS ivts_OuterMoveInCostAmt,0 AS ivts_OuterMoveInCostVatAmt,0 AS ivts_OuterMoveInPriceAmt,0 AS ivts_OuterMoveInPriceVatAmt,0 AS ivts_PreAdjustQty,0 AS ivts_PreAdjustCostAmt,0 AS ivts_PreAdjustCostVatAmt,0 AS ivts_PreAdjustPriceAmt,0 AS ivts_PreAdjustPriceVatAmt,0 AS ivts_PreAdjustPriceCostSumAmt,0 AS ivts_PreAdjustPriceCostVatAmt,0 AS ivts_DisuseQty,0 AS ivts_DisuseCostAmt,0 AS ivts_DisuseCostVatAmt,0 AS ivts_DisusePriceAmt,0 AS ivts_DisusePriceVatAmt,0 AS ivts_DisusePriceCostSumAmt,0 AS ivts_DisusePriceCostVatAmt,0 AS ivts_PriceUp,0 AS ivts_PriceUpVat,0 AS ivts_PriceDown,0 AS ivts_PriceDownVat,0 AS ivts_InventoryQty,0 AS ivts_InventoryCostAmt,0 AS ivts_InventoryCostVatAmt,0 AS ivts_InventoryPriceAmt,0 AS ivts_InventoryPriceVatAmt,0 AS ivts_InventoryPriceCostSumAmt,0 AS ivts_InventoryPriceCostVatAmt,0 AS ivts_IsInventory,0 AS ivts_AdjustQty,0 AS ivts_AdjustCostAmt,0 AS ivts_AdjustCostVatAmt,0 AS ivts_AdjustPriceAmt,0 AS ivts_AdjustPriceVatAmt,0 AS ivts_AdjustPriceCostSumAmt,0 AS ivts_AdjustPriceCostVatAmt,0 AS ivts_LossQty,0 AS ivts_LossCostAmt,0 AS ivts_LossCostVatAmt,0 AS ivts_LossPriceAmt,0 AS ivts_LossPriceVatAmt,0 AS ivts_LossPriceCostSumAmt,0 AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public const string TBodyMiddleTable = "기중";
    [JsonIgnore]
    public static string TProfitLossSummaryMiddleCol = ",0 AS ivts_BaseQty,0 AS ivts_BaseAvgCost,0 AS ivts_BaseCostAmt,0 AS ivts_BaseCostVatAmt,0 AS ivts_BasePrice,0 AS ivts_BasePriceCostAmt,0 AS ivts_BasePriceCostVatAmt,0 AS ivts_BasePriceAmt,0 AS ivts_BasePriceVatAmt,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt,pls_SaleQty AS ivts_SaleQty,pls_TotalSaleAmt AS ivts_TotalSaleAmt,pls_SaleAmt AS ivts_SaleAmt,pls_SaleVatAmt AS ivts_SaleVatAmt,pls_SaleProfit AS ivts_SaleProfit,pls_SalePriceProfit AS ivts_SalePriceProfit,pls_EnurySlip AS ivts_EnurySlip,pls_EnuryEnd AS ivts_EnuryEnd,pls_DcAmtManual AS ivts_DcAmtManual,pls_DcAmtEvent AS ivts_DcAmtEvent,pls_DcAmtGoods AS ivts_DcAmtGoods,pls_DcAmtCoupon AS ivts_DcAmtCoupon,pls_DcAmtPromotion AS ivts_DcAmtPromotion,pls_DcAmtMember AS ivts_DcAmtMember,pls_Customer AS ivts_Customer,pls_CustomerGoods AS ivts_CustomerGoods,pls_CustomerCategory AS ivts_CustomerCategory,pls_CustomerSupplier AS ivts_CustomerSupplier,pls_BuyQty AS ivts_BuyQty,pls_BuyCostAmt AS ivts_BuyCostAmt,pls_BuyCostVatAmt AS ivts_BuyCostVatAmt,pls_BuyPriceAmt AS ivts_BuyPriceAmt,pls_BuyPriceVatAmt AS ivts_BuyPriceVatAmt,pls_ReturnQty AS ivts_ReturnQty,pls_ReturnCostAmt AS ivts_ReturnCostAmt,pls_ReturnCostVatAmt AS ivts_ReturnCostVatAmt,pls_ReturnPriceAmt AS ivts_ReturnPriceAmt,pls_ReturnPriceVatAmt AS ivts_ReturnPriceVatAmt,pls_InnerMoveOutQty AS ivts_InnerMoveOutQty,pls_InnerMoveOutCostAmt AS ivts_InnerMoveOutCostAmt,pls_InnerMoveOutCostVatAmt AS ivts_InnerMoveOutCostVatAmt,pls_InnerMoveOutPriceAmt AS ivts_InnerMoveOutPriceAmt,pls_InnerMoveOutPriceVatAmt AS ivts_InnerMoveOutPriceVatAmt,pls_InnerMoveInQty AS ivts_InnerMoveInQty,pls_InnerMoveInCostAmt AS ivts_InnerMoveInCostAmt,pls_InnerMoveInCostVatAmt AS ivts_InnerMoveInCostVatAmt,pls_InnerMoveInPriceAmt AS ivts_InnerMoveInPriceAmt,pls_InnerMoveInPriceVatAmt AS ivts_InnerMoveInPriceVatAmt,pls_OuterMoveOutQty AS ivts_OuterMoveOutQty,pls_OuterMoveOutCostAmt AS ivts_OuterMoveOutCostAmt,pls_OuterMoveOutCostVatAmt AS ivts_OuterMoveOutCostVatAmt,pls_OuterMoveOutPriceAmt AS ivts_OuterMoveOutPriceAmt,pls_OuterMoveOutPriceVatAmt AS ivts_OuterMoveOutPriceVatAmt,pls_OuterMoveInQty AS ivts_OuterMoveInQty,pls_OuterMoveInCostAmt AS ivts_OuterMoveInCostAmt,pls_OuterMoveInCostVatAmt AS ivts_OuterMoveInCostVatAmt,pls_OuterMoveInPriceAmt AS ivts_OuterMoveInPriceAmt,pls_OuterMoveInPriceVatAmt AS ivts_OuterMoveInPriceVatAmt,pls_AdjustQty AS ivts_PreAdjustQty,pls_AdjustCostAmt AS ivts_PreAdjustCostAmt,pls_AdjustCostVatAmt AS ivts_PreAdjustCostVatAmt,pls_AdjustPriceAmt AS ivts_PreAdjustPriceAmt,pls_AdjustPriceVatAmt AS ivts_PreAdjustPriceVatAmt,pls_AdjustPriceCostSumAmt AS ivts_PreAdjustPriceCostSumAmt,pls_AdjustPriceCostVatAmt AS ivts_PreAdjustPriceCostVatAmt,pls_DisuseQty AS ivts_DisuseQty,pls_DisuseCostAmt AS ivts_DisuseCostAmt,pls_DisuseCostVatAmt AS ivts_DisuseCostVatAmt,pls_DisusePriceAmt AS ivts_DisusePriceAmt,pls_DisusePriceVatAmt AS ivts_DisusePriceVatAmt,pls_DisusePriceCostSumAmt AS ivts_DisusePriceCostSumAmt,pls_DisusePriceCostVatAmt AS ivts_DisusePriceCostVatAmt,pls_PriceUp AS ivts_PriceUp,pls_PriceUpVat AS ivts_PriceUpVat,pls_PriceDown AS ivts_PriceDown,pls_PriceDownVat AS ivts_PriceDownVat,0 AS ivts_InventoryQty,0 AS ivts_InventoryCostAmt,0 AS ivts_InventoryCostVatAmt,0 AS ivts_InventoryPriceAmt,0 AS ivts_InventoryPriceVatAmt,0 AS ivts_InventoryPriceCostSumAmt,0 AS ivts_InventoryPriceCostVatAmt,0 AS ivts_IsInventory,0 AS ivts_AdjustQty,0 AS ivts_AdjustCostAmt,0 AS ivts_AdjustCostVatAmt,0 AS ivts_AdjustPriceAmt,0 AS ivts_AdjustPriceVatAmt,0 AS ivts_AdjustPriceCostSumAmt,0 AS ivts_AdjustPriceCostVatAmt,0 AS ivts_LossQty,0 AS ivts_LossCostAmt,0 AS ivts_LossCostVatAmt,0 AS ivts_LossPriceAmt,0 AS ivts_LossPriceVatAmt,0 AS ivts_LossPriceCostSumAmt,0 AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public static string TProfitLossSummaryMiddleSumCol = ",0 AS ivts_BaseQty,0 AS ivts_BaseAvgCost,0 AS ivts_BaseCostAmt,0 AS ivts_BaseCostVatAmt,0 AS ivts_BasePrice,0 AS ivts_BasePriceCostAmt,0 AS ivts_BasePriceCostVatAmt,0 AS ivts_BasePriceAmt,0 AS ivts_BasePriceVatAmt,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt,SUM(pls_SaleQty) AS ivts_SaleQty,SUM(pls_TotalSaleAmt) AS ivts_TotalSaleAmt,SUM(pls_SaleAmt) AS ivts_SaleAmt,SUM(pls_SaleVatAmt) AS ivts_SaleVatAmt,SUM(pls_SaleProfit) AS ivts_SaleProfit,SUM(pls_SalePriceProfit) AS ivts_SalePriceProfit,SUM(pls_EnurySlip) AS ivts_EnurySlip,SUM(pls_EnuryEnd) AS ivts_EnuryEnd,SUM(pls_DcAmtManual) AS ivts_DcAmtManual,SUM(pls_DcAmtEvent) AS ivts_DcAmtEvent,SUM(pls_DcAmtGoods) AS ivts_DcAmtGoods,SUM(pls_DcAmtCoupon) AS ivts_DcAmtCoupon,SUM(pls_DcAmtPromotion) AS ivts_DcAmtPromotion,SUM(pls_DcAmtMember) AS ivts_DcAmtMember,SUM(pls_Customer) AS ivts_Customer,SUM(pls_CustomerGoods) AS ivts_CustomerGoods,SUM(pls_CustomerCategory) AS ivts_CustomerCategory,SUM(pls_CustomerSupplier) AS ivts_CustomerSupplier,SUM(pls_BuyQty) AS ivts_BuyQty,SUM(pls_BuyCostAmt) AS ivts_BuyCostAmt,SUM(pls_BuyCostVatAmt) AS ivts_BuyCostVatAmt,SUM(pls_BuyPriceAmt) AS ivts_BuyPriceAmt,SUM(pls_BuyPriceVatAmt) AS ivts_BuyPriceVatAmt,SUM(pls_ReturnQty) AS ivts_ReturnQty,SUM(pls_ReturnCostAmt) AS ivts_ReturnCostAmt,SUM(pls_ReturnCostVatAmt) AS ivts_ReturnCostVatAmt,SUM(pls_ReturnPriceAmt) AS ivts_ReturnPriceAmt,SUM(pls_ReturnPriceVatAmt) AS ivts_ReturnPriceVatAmt,SUM(pls_InnerMoveOutQty) AS ivts_InnerMoveOutQty,SUM(pls_InnerMoveOutCostAmt) AS ivts_InnerMoveOutCostAmt,SUM(pls_InnerMoveOutCostVatAmt) AS ivts_InnerMoveOutCostVatAmt,SUM(pls_InnerMoveOutPriceAmt) AS ivts_InnerMoveOutPriceAmt,SUM(pls_InnerMoveOutPriceVatAmt) AS ivts_InnerMoveOutPriceVatAmt,SUM(pls_InnerMoveInQty) AS ivts_InnerMoveInQty,SUM(pls_InnerMoveInCostAmt) AS ivts_InnerMoveInCostAmt,SUM(pls_InnerMoveInCostVatAmt) AS ivts_InnerMoveInCostVatAmt,SUM(pls_InnerMoveInPriceAmt) AS ivts_InnerMoveInPriceAmt,SUM(pls_InnerMoveInPriceVatAmt) AS ivts_InnerMoveInPriceVatAmt,SUM(pls_OuterMoveOutQty) AS ivts_OuterMoveOutQty,SUM(pls_OuterMoveOutCostAmt) AS ivts_OuterMoveOutCostAmt,SUM(pls_OuterMoveOutCostVatAmt) AS ivts_OuterMoveOutCostVatAmt,SUM(pls_OuterMoveOutPriceAmt) AS ivts_OuterMoveOutPriceAmt,SUM(pls_OuterMoveOutPriceVatAmt) AS ivts_OuterMoveOutPriceVatAmt,SUM(pls_OuterMoveInQty) AS ivts_OuterMoveInQty,SUM(pls_OuterMoveInCostAmt) AS ivts_OuterMoveInCostAmt,SUM(pls_OuterMoveInCostVatAmt) AS ivts_OuterMoveInCostVatAmt,SUM(pls_OuterMoveInPriceAmt) AS ivts_OuterMoveInPriceAmt,SUM(pls_OuterMoveInPriceVatAmt) AS ivts_OuterMoveInPriceVatAmt,SUM(pls_AdjustQty) AS ivts_PreAdjustQty,SUM(pls_AdjustCostAmt) AS ivts_PreAdjustCostAmt,SUM(pls_AdjustCostVatAmt) AS ivts_PreAdjustCostVatAmt,SUM(pls_AdjustPriceAmt) AS ivts_PreAdjustPriceAmt,SUM(pls_AdjustPriceVatAmt) AS ivts_PreAdjustPriceVatAmt,SUM(pls_AdjustPriceCostSumAmt) AS ivts_PreAdjustPriceCostSumAmt,SUM(pls_AdjustPriceCostVatAmt) AS ivts_PreAdjustPriceCostVatAmt,SUM(pls_DisuseQty) AS ivts_DisuseQty,SUM(pls_DisuseCostAmt) AS ivts_DisuseCostAmt,SUM(pls_DisuseCostVatAmt) AS ivts_DisuseCostVatAmt,SUM(pls_DisusePriceAmt) AS ivts_DisusePriceAmt,SUM(pls_DisusePriceVatAmt) AS ivts_DisusePriceVatAmt,SUM(pls_DisusePriceCostSumAmt) AS ivts_DisusePriceCostSumAmt,SUM(pls_DisusePriceCostVatAmt) AS ivts_DisusePriceCostVatAmt,SUM(pls_PriceUp) AS ivts_PriceUp,SUM(pls_PriceUpVat) AS ivts_PriceUpVat,SUM(pls_PriceDown) AS ivts_PriceDown,SUM(pls_PriceDownVat) AS ivts_PriceDownVat,0 AS ivts_InventoryQty,0 AS ivts_InventoryCostAmt,0 AS ivts_InventoryCostVatAmt,0 AS ivts_InventoryPriceAmt,0 AS ivts_InventoryPriceVatAmt,0 AS ivts_InventoryPriceCostSumAmt,0 AS ivts_InventoryPriceCostVatAmt,0 AS ivts_IsInventory,0 AS ivts_AdjustQty,0 AS ivts_AdjustCostAmt,0 AS ivts_AdjustCostVatAmt,0 AS ivts_AdjustPriceAmt,0 AS ivts_AdjustPriceVatAmt,0 AS ivts_AdjustPriceCostSumAmt,0 AS ivts_AdjustPriceCostVatAmt,0 AS ivts_LossQty,0 AS ivts_LossCostAmt,0 AS ivts_LossCostVatAmt,0 AS ivts_LossPriceAmt,0 AS ivts_LossPriceVatAmt,0 AS ivts_LossPriceCostSumAmt,0 AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public static string TInventorySummaryEndCol = ",0 AS ivts_BaseQty,0 AS ivts_BaseAvgCost,0 AS ivts_BaseCostAmt,0 AS ivts_BaseCostVatAmt,0 AS ivts_BasePrice,0 AS ivts_BasePriceCostAmt,0 AS ivts_BasePriceCostVatAmt,0 AS ivts_BasePriceAmt,0 AS ivts_BasePriceVatAmt,ivts_EndQty,ivts_EndAvgCost,ivts_EndCostAmt,ivts_EndCostVatAmt,ivts_EndPrice,ivts_EndPriceCostAmt,ivts_EndPriceCostVatAmt,ivts_EndPriceAmt,ivts_EndPriceVatAmt,ivts_SaleQty,ivts_TotalSaleAmt,ivts_SaleAmt,ivts_SaleVatAmt,ivts_SaleProfit,ivts_SalePriceProfit,ivts_EnurySlip,ivts_EnuryEnd,ivts_DcAmtManual,ivts_DcAmtEvent,ivts_DcAmtGoods,ivts_DcAmtCoupon,ivts_DcAmtPromotion,ivts_DcAmtMember,ivts_Customer,ivts_CustomerGoods,ivts_CustomerCategory,ivts_CustomerSupplier,ivts_BuyQty,ivts_BuyCostAmt,ivts_BuyCostVatAmt,ivts_BuyPriceAmt,ivts_BuyPriceVatAmt,ivts_ReturnQty,ivts_ReturnCostAmt,ivts_ReturnCostVatAmt,ivts_ReturnPriceAmt,ivts_ReturnPriceVatAmt,ivts_InnerMoveOutQty,ivts_InnerMoveOutCostAmt,ivts_InnerMoveOutCostVatAmt,ivts_InnerMoveOutPriceAmt,ivts_InnerMoveOutPriceVatAmt,ivts_InnerMoveInQty,ivts_InnerMoveInCostAmt,ivts_InnerMoveInCostVatAmt,ivts_InnerMoveInPriceAmt,ivts_InnerMoveInPriceVatAmt,ivts_OuterMoveOutQty,ivts_OuterMoveOutCostAmt,ivts_OuterMoveOutCostVatAmt,ivts_OuterMoveOutPriceAmt,ivts_OuterMoveOutPriceVatAmt,ivts_OuterMoveInQty,ivts_OuterMoveInCostAmt,ivts_OuterMoveInCostVatAmt,ivts_OuterMoveInPriceAmt,ivts_OuterMoveInPriceVatAmt,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,ivts_DisuseQty,ivts_DisuseCostAmt,ivts_DisuseCostVatAmt,ivts_DisusePriceAmt,ivts_DisusePriceVatAmt,ivts_DisusePriceCostSumAmt,ivts_DisusePriceCostVatAmt,ivts_PriceUp,ivts_PriceUpVat,ivts_PriceDown,ivts_PriceDownVat,ivts_InventoryQty,ivts_InventoryCostAmt,ivts_InventoryCostVatAmt,ivts_InventoryPriceAmt,ivts_InventoryPriceVatAmt,ivts_InventoryPriceCostSumAmt,ivts_InventoryPriceCostVatAmt,ivts_IsInventory,ivts_AdjustQty,ivts_AdjustCostAmt,ivts_AdjustCostVatAmt,ivts_AdjustPriceAmt,ivts_AdjustPriceVatAmt,ivts_AdjustPriceCostSumAmt,ivts_AdjustPriceCostVatAmt,ivts_LossQty,ivts_LossCostAmt,ivts_LossCostVatAmt,ivts_LossPriceAmt,ivts_LossPriceVatAmt,ivts_LossPriceCostSumAmt,ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public static string TInventorySummaryEndSumCol = ",0 AS ivts_BaseQty,0 AS ivts_BaseAvgCost,0 AS ivts_BaseCostAmt,0 AS ivts_BaseCostVatAmt,0 AS ivts_BasePrice,0 AS ivts_BasePriceCostAmt,0 AS ivts_BasePriceCostVatAmt,0 AS ivts_BasePriceAmt,0 AS ivts_BasePriceVatAmt,SUM(ivts_EndQty) AS ivts_EndQty,SUM(ivts_EndAvgCost) AS ivts_EndAvgCost,SUM(ivts_EndCostAmt) AS ivts_EndCostAmt,SUM(ivts_EndCostVatAmt) AS ivts_EndCostVatAmt,SUM(ivts_EndPrice) AS ivts_EndPrice,SUM(ivts_EndPriceCostAmt) AS ivts_EndPriceCostAmt,SUM(ivts_EndPriceCostVatAmt) AS ivts_EndPriceCostVatAmt,SUM(ivts_EndPriceAmt) AS ivts_EndPriceAmt,SUM(ivts_EndPriceVatAmt) AS ivts_EndPriceVatAmt,SUM(ivts_SaleQty) AS ivts_SaleQty,SUM(ivts_TotalSaleAmt) AS ivts_TotalSaleAmt,SUM(ivts_SaleAmt) AS ivts_SaleAmt,SUM(ivts_SaleVatAmt) AS ivts_SaleVatAmt,SUM(ivts_SaleProfit) AS ivts_SaleProfit,SUM(ivts_SalePriceProfit) AS ivts_SalePriceProfit,SUM(ivts_EnurySlip) AS ivts_EnurySlip,SUM(ivts_EnuryEnd) AS ivts_EnuryEnd,SUM(ivts_DcAmtManual) AS ivts_DcAmtManual,SUM(ivts_DcAmtEvent) AS ivts_DcAmtEvent,SUM(ivts_DcAmtGoods) AS ivts_DcAmtGoods,SUM(ivts_DcAmtCoupon) AS ivts_DcAmtCoupon,SUM(ivts_DcAmtPromotion) AS ivts_DcAmtPromotion,SUM(ivts_DcAmtMember) AS ivts_DcAmtMember,SUM(ivts_Customer) AS ivts_Customer,SUM(ivts_CustomerGoods) AS ivts_CustomerGoods,SUM(ivts_CustomerCategory) AS ivts_CustomerCategory,SUM(ivts_CustomerSupplier) AS ivts_CustomerSupplier,SUM(ivts_BuyQty) AS ivts_BuyQty,SUM(ivts_BuyCostAmt) AS ivts_BuyCostAmt,SUM(ivts_BuyCostVatAmt) AS ivts_BuyCostVatAmt,SUM(ivts_BuyPriceAmt) AS ivts_BuyPriceAmt,SUM(ivts_BuyPriceVatAmt) AS ivts_BuyPriceVatAmt,SUM(ivts_ReturnQty) AS ivts_ReturnQty,SUM(ivts_ReturnCostAmt) AS ivts_ReturnCostAmt,SUM(ivts_ReturnCostVatAmt) AS ivts_ReturnCostVatAmt,SUM(ivts_ReturnPriceAmt) AS ivts_ReturnPriceAmt,SUM(ivts_ReturnPriceVatAmt) AS ivts_ReturnPriceVatAmt,SUM(ivts_InnerMoveOutQty) AS ivts_InnerMoveOutQty,SUM(ivts_InnerMoveOutCostAmt) AS ivts_InnerMoveOutCostAmt,SUM(ivts_InnerMoveOutCostVatAmt) AS ivts_InnerMoveOutCostVatAmt,SUM(ivts_InnerMoveOutPriceAmt) AS ivts_InnerMoveOutPriceAmt,SUM(ivts_InnerMoveOutPriceVatAmt) AS ivts_InnerMoveOutPriceVatAmt,SUM(ivts_InnerMoveInQty) AS ivts_InnerMoveInQty,SUM(ivts_InnerMoveInCostAmt) AS ivts_InnerMoveInCostAmt,SUM(ivts_InnerMoveInCostVatAmt) AS ivts_InnerMoveInCostVatAmt,SUM(ivts_InnerMoveInPriceAmt) AS ivts_InnerMoveInPriceAmt,SUM(ivts_InnerMoveInPriceVatAmt) AS ivts_InnerMoveInPriceVatAmt,SUM(ivts_OuterMoveOutQty) AS ivts_OuterMoveOutQty,SUM(ivts_OuterMoveOutCostAmt) AS ivts_OuterMoveOutCostAmt,SUM(ivts_OuterMoveOutCostVatAmt) AS ivts_OuterMoveOutCostVatAmt,SUM(ivts_OuterMoveOutPriceAmt) AS ivts_OuterMoveOutPriceAmt,SUM(ivts_OuterMoveOutPriceVatAmt) AS ivts_OuterMoveOutPriceVatAmt,SUM(ivts_OuterMoveInQty) AS ivts_OuterMoveInQty,SUM(ivts_OuterMoveInCostAmt) AS ivts_OuterMoveInCostAmt,SUM(ivts_OuterMoveInCostVatAmt) AS ivts_OuterMoveInCostVatAmt,SUM(ivts_OuterMoveInPriceAmt) AS ivts_OuterMoveInPriceAmt,SUM(ivts_OuterMoveInPriceVatAmt) AS ivts_OuterMoveInPriceVatAmt,SUM(ivts_PreAdjustQty) AS ivts_PreAdjustQty,SUM(ivts_PreAdjustCostAmt) AS ivts_PreAdjustCostAmt,SUM(ivts_PreAdjustCostVatAmt) AS ivts_PreAdjustCostVatAmt,SUM(ivts_PreAdjustPriceAmt) AS ivts_PreAdjustPriceAmt,SUM(ivts_PreAdjustPriceVatAmt) AS ivts_PreAdjustPriceVatAmt,SUM(ivts_PreAdjustPriceCostSumAmt) AS ivts_PreAdjustPriceCostSumAmt,SUM(ivts_PreAdjustPriceCostVatAmt) AS ivts_PreAdjustPriceCostVatAmt,SUM(ivts_DisuseQty) AS ivts_DisuseQty,SUM(ivts_DisuseCostAmt) AS ivts_DisuseCostAmt,SUM(ivts_DisuseCostVatAmt) AS ivts_DisuseCostVatAmt,SUM(ivts_DisusePriceAmt) AS ivts_DisusePriceAmt,SUM(ivts_DisusePriceVatAmt) AS ivts_DisusePriceVatAmt,SUM(ivts_DisusePriceCostSumAmt) AS ivts_DisusePriceCostSumAmt,SUM(ivts_DisusePriceCostVatAmt) AS ivts_DisusePriceCostVatAmt,SUM(ivts_PriceUp) AS ivts_PriceUp,SUM(ivts_PriceUpVat) AS ivts_PriceUpVat,SUM(ivts_PriceDown) AS ivts_PriceDown,SUM(ivts_PriceDownVat) AS ivts_PriceDownVat,SUM(ivts_InventoryQty) AS ivts_InventoryQty,SUM(ivts_InventoryCostAmt) AS ivts_InventoryCostAmt,SUM(ivts_InventoryCostVatAmt) AS ivts_InventoryCostVatAmt,SUM(ivts_InventoryPriceAmt) AS ivts_InventoryPriceAmt,SUM(ivts_InventoryPriceVatAmt) AS ivts_InventoryPriceVatAmt,SUM(ivts_InventoryPriceCostSumAmt) AS ivts_InventoryPriceCostSumAmt,SUM(ivts_InventoryPriceCostVatAmt) AS ivts_InventoryPriceCostVatAmt,SUM(0) AS ivts_IsInventory,SUM(ivts_AdjustQty) AS ivts_AdjustQty,SUM(ivts_AdjustCostAmt) AS ivts_AdjustCostAmt,SUM(ivts_AdjustCostVatAmt) AS ivts_AdjustCostVatAmt,SUM(ivts_AdjustPriceAmt) AS ivts_AdjustPriceAmt,SUM(ivts_AdjustPriceVatAmt) AS ivts_AdjustPriceVatAmt,SUM(ivts_AdjustPriceCostSumAmt) AS ivts_AdjustPriceCostSumAmt,SUM(ivts_AdjustPriceCostVatAmt) AS ivts_AdjustPriceCostVatAmt,SUM(ivts_LossQty) AS ivts_LossQty,SUM(ivts_LossCostAmt) AS ivts_LossCostAmt,SUM(ivts_LossCostVatAmt) AS ivts_LossCostVatAmt,SUM(ivts_LossPriceAmt) AS ivts_LossPriceAmt,SUM(ivts_LossPriceVatAmt) AS ivts_LossPriceVatAmt,SUM(ivts_LossPriceCostSumAmt) AS ivts_LossPriceCostSumAmt,SUM(ivts_LossPriceCostVatAmt) AS ivts_LossPriceCostVatAmt";

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

    public int ivts_Days
    {
      get => this._ivts_Days;
      set
      {
        this._ivts_Days = value;
        this.Changed(nameof (ivts_Days));
      }
    }

    public double CalcTurnOverDay() => !this.CalcTurnOver().IsZero() ? NumberHelper.ToDiv((double) this.ivts_Days, this.CalcTurnOver()) : 0.0;

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.ivts_Days = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventorySummaryDate();

    public override object Clone()
    {
      InventorySummaryDate inventorySummaryDate = base.Clone() as InventorySummaryDate;
      inventorySummaryDate.rowDataType = this.rowDataType;
      inventorySummaryDate.ivts_Days = this.ivts_Days;
      return (object) inventorySummaryDate;
    }

    public void PutData(InventorySummaryDate pSource)
    {
      this.PutData((TInventorySummary) pSource);
      this.rowDataType = pSource.rowDataType;
      this.ivts_Days = pSource.ivts_Days;
    }

    public Hashtable SearchConditionProfitLossSummaryDefult(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
          hashtable.Add((object) "pls_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
          hashtable.Add((object) "pls_StoreCode", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
          hashtable.Add((object) "pls_StoreCode_IN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_TaxDiv"))
          hashtable.Add((object) "pls_TaxDiv", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StockUnit"))
          hashtable.Add((object) "pls_StockUnit", dictionaryEntry.Value);
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

    public Hashtable SearchConditionProfitLossSummaryMiddle(Hashtable p_param)
    {
      Hashtable hashtable = this.SearchConditionProfitLossSummaryDefult(p_param);
      if (p_param.ContainsKey((object) "_DT_START_DATE_"))
      {
        DateTime p_day = (DateTime) p_param[(object) "_DT_START_DATE_"];
        hashtable.Add((object) "pls_YyyyMm_BEGIN_", (object) p_day.ToIntFormat("yyyyMM"));
      }
      if (p_param.ContainsKey((object) "_DT_END_DATE_"))
      {
        DateTime p_day = (DateTime) p_param[(object) "_DT_END_DATE_"];
        hashtable.Add((object) "pls_YyyyMm_END_", (object) p_day.ToIntFormat("yyyyMM"));
      }
      return hashtable;
    }

    public Hashtable SearchConditionInventorySummary(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
        {
          DateTime p_day = (DateTime) dictionaryEntry.Value;
          hashtable.Add((object) "ivts_YyyyMm", (object) p_day.ToIntFormat("yyyyMM"));
          hashtable.Add((object) "ivts_Day", (object) p_day.Day);
        }
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ivts_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
    }
  }
}
