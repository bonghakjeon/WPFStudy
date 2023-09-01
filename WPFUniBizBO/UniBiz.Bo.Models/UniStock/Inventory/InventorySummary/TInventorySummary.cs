// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventorySummary.TInventorySummary
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

namespace UniBiz.Bo.Models.UniStock.Inventory.InventorySummary
{
  public class TInventorySummary : UbModelBase<TInventorySummary>
  {
    private int _ivts_YyyyMm;
    private int _ivts_Day;
    private int _ivts_StoreCode;
    private long _ivts_GoodsCode;
    private long _ivts_SiteID;
    private int _ivts_Supplier;
    private int _ivts_SupplierType;
    private int _ivts_CategoryCode;
    private int _ivts_TaxDiv;
    private int _ivts_StockUnit;
    private int _ivts_SalesUnit;
    private double _ivts_BaseQty;
    private double _ivts_BaseAvgCost;
    private double _ivts_BaseCostAmt;
    private double _ivts_BaseCostVatAmt;
    private double _ivts_BasePrice;
    private double _ivts_BasePriceAmt;
    private double _ivts_BasePriceVatAmt;
    private double _ivts_BasePriceCostAmt;
    private double _ivts_BasePriceCostVatAmt;
    private double _ivts_EndQty;
    private double _ivts_EndAvgCost;
    private double _ivts_EndCostAmt;
    private double _ivts_EndCostVatAmt;
    private double _ivts_EndPrice;
    private double _ivts_EndPriceAmt;
    private double _ivts_EndPriceVatAmt;
    private double _ivts_EndPriceCostAmt;
    private double _ivts_EndPriceCostVatAmt;
    private double _ivts_SaleQty;
    private double _ivts_TotalSaleAmt;
    private double _ivts_SaleAmt;
    private double _ivts_SaleVatAmt;
    private double _ivts_SaleProfit;
    private double _ivts_SalePriceProfit;
    private double _ivts_EnurySlip;
    private double _ivts_EnuryEnd;
    private double _ivts_DcAmtManual;
    private double _ivts_DcAmtEvent;
    private double _ivts_DcAmtGoods;
    private double _ivts_DcAmtCoupon;
    private double _ivts_DcAmtPromotion;
    private double _ivts_DcAmtMember;
    private double _ivts_Customer;
    private double _ivts_CustomerGoods;
    private double _ivts_CustomerCategory;
    private double _ivts_CustomerSupplier;
    private double _ivts_BuyQty;
    private double _ivts_BuyCostAmt;
    private double _ivts_BuyCostVatAmt;
    private double _ivts_BuyPriceAmt;
    private double _ivts_BuyPriceVatAmt;
    private double _ivts_ReturnQty;
    private double _ivts_ReturnCostAmt;
    private double _ivts_ReturnCostVatAmt;
    private double _ivts_ReturnPriceAmt;
    private double _ivts_ReturnPriceVatAmt;
    private double _ivts_InnerMoveOutQty;
    private double _ivts_InnerMoveOutCostAmt;
    private double _ivts_InnerMoveOutCostVatAmt;
    private double _ivts_InnerMoveOutPriceAmt;
    private double _ivts_InnerMoveOutPriceVatAmt;
    private double _ivts_InnerMoveInQty;
    private double _ivts_InnerMoveInCostAmt;
    private double _ivts_InnerMoveInCostVatAmt;
    private double _ivts_InnerMoveInPriceAmt;
    private double _ivts_InnerMoveInPriceVatAmt;
    private double _ivts_OuterMoveOutQty;
    private double _ivts_OuterMoveOutCostAmt;
    private double _ivts_OuterMoveOutCostVatAmt;
    private double _ivts_OuterMoveOutPriceAmt;
    private double _ivts_OuterMoveOutPriceVatAmt;
    private double _ivts_OuterMoveInQty;
    private double _ivts_OuterMoveInCostAmt;
    private double _ivts_OuterMoveInCostVatAmt;
    private double _ivts_OuterMoveInPriceAmt;
    private double _ivts_OuterMoveInPriceVatAmt;
    private double _ivts_PreAdjustQty;
    private double _ivts_PreAdjustCostAmt;
    private double _ivts_PreAdjustCostVatAmt;
    private double _ivts_PreAdjustPriceAmt;
    private double _ivts_PreAdjustPriceVatAmt;
    private double _ivts_PreAdjustPriceCostSumAmt;
    private double _ivts_PreAdjustPriceCostVatAmt;
    private double _ivts_DisuseQty;
    private double _ivts_DisuseCostAmt;
    private double _ivts_DisuseCostVatAmt;
    private double _ivts_DisusePriceAmt;
    private double _ivts_DisusePriceVatAmt;
    private double _ivts_DisusePriceCostSumAmt;
    private double _ivts_DisusePriceCostVatAmt;
    private double _ivts_PriceUp;
    private double _ivts_PriceUpVat;
    private double _ivts_PriceDown;
    private double _ivts_PriceDownVat;
    private double _ivts_InventoryQty;
    private double _ivts_InventoryCostAmt;
    private double _ivts_InventoryCostVatAmt;
    private double _ivts_InventoryPriceAmt;
    private double _ivts_InventoryPriceVatAmt;
    private double _ivts_InventoryPriceCostSumAmt;
    private double _ivts_InventoryPriceCostVatAmt;
    private double _ivts_AdjustQty;
    private double _ivts_AdjustCostAmt;
    private double _ivts_AdjustCostVatAmt;
    private double _ivts_AdjustPriceAmt;
    private double _ivts_AdjustPriceVatAmt;
    private double _ivts_AdjustPriceCostSumAmt;
    private double _ivts_AdjustPriceCostVatAmt;
    private double _ivts_LossQty;
    private double _ivts_LossCostAmt;
    private double _ivts_LossCostVatAmt;
    private double _ivts_LossPriceAmt;
    private double _ivts_LossPriceVatAmt;
    private double _ivts_LossPriceCostSumAmt;
    private double _ivts_LossPriceCostVatAmt;
    private int _ivts_IsInventory;
    [JsonIgnore]
    public static string MainCol = ",ivts_BaseQty,ivts_BaseAvgCost,ivts_BaseCostAmt,ivts_BaseCostVatAmt,ivts_BasePrice,ivts_BasePriceCostAmt,ivts_BasePriceCostVatAmt,ivts_BasePriceAmt,ivts_BasePriceVatAmt,ivts_EndQty,ivts_EndAvgCost,ivts_EndCostAmt,ivts_EndCostVatAmt,ivts_EndPrice,ivts_EndPriceCostAmt,ivts_EndPriceCostVatAmt,ivts_EndPriceAmt,ivts_EndPriceVatAmt,ivts_SaleQty,ivts_TotalSaleAmt,ivts_SaleAmt,ivts_SaleVatAmt,ivts_SaleProfit,ivts_SalePriceProfit,ivts_EnurySlip,ivts_EnuryEnd,ivts_DcAmtManual,ivts_DcAmtEvent,ivts_DcAmtGoods,ivts_DcAmtCoupon,ivts_DcAmtPromotion,ivts_DcAmtMember,ivts_Customer,ivts_CustomerGoods,ivts_CustomerCategory,ivts_CustomerSupplier,ivts_BuyQty,ivts_BuyCostAmt,ivts_BuyCostVatAmt,ivts_BuyPriceAmt,ivts_BuyPriceVatAmt,ivts_ReturnQty,ivts_ReturnCostAmt,ivts_ReturnCostVatAmt,ivts_ReturnPriceAmt,ivts_ReturnPriceVatAmt,ivts_InnerMoveOutQty,ivts_InnerMoveOutCostAmt,ivts_InnerMoveOutCostVatAmt,ivts_InnerMoveOutPriceAmt,ivts_InnerMoveOutPriceVatAmt,ivts_InnerMoveInQty,ivts_InnerMoveInCostAmt,ivts_InnerMoveInCostVatAmt,ivts_InnerMoveInPriceAmt,ivts_InnerMoveInPriceVatAmt,ivts_OuterMoveOutQty,ivts_OuterMoveOutCostAmt,ivts_OuterMoveOutCostVatAmt,ivts_OuterMoveOutPriceAmt,ivts_OuterMoveOutPriceVatAmt,ivts_OuterMoveInQty,ivts_OuterMoveInCostAmt,ivts_OuterMoveInCostVatAmt,ivts_OuterMoveInPriceAmt,ivts_OuterMoveInPriceVatAmt,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,ivts_DisuseQty,ivts_DisuseCostAmt,ivts_DisuseCostVatAmt,ivts_DisusePriceAmt,ivts_DisusePriceVatAmt,ivts_DisusePriceCostSumAmt,ivts_DisusePriceCostVatAmt,ivts_PriceUp,ivts_PriceUpVat,ivts_PriceDown,ivts_PriceDownVat,ivts_InventoryQty,ivts_InventoryCostAmt,ivts_InventoryCostVatAmt,ivts_InventoryPriceAmt,ivts_InventoryPriceVatAmt,ivts_InventoryPriceCostSumAmt,ivts_InventoryPriceCostVatAmt,ivts_IsInventory,ivts_AdjustQty,ivts_AdjustCostAmt,ivts_AdjustCostVatAmt,ivts_AdjustPriceAmt,ivts_AdjustPriceVatAmt,ivts_AdjustPriceCostSumAmt,ivts_AdjustPriceCostVatAmt,ivts_LossQty,ivts_LossCostAmt,ivts_LossCostVatAmt,ivts_LossPriceAmt,ivts_LossPriceVatAmt,ivts_LossPriceCostSumAmt,ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public static string SubCol = ",SUM(ivts_BaseQty) AS ivts_BaseQty,SUM(ivts_BaseAvgCost) AS ivts_BaseAvgCost,SUM(ivts_BaseCostAmt) AS ivts_BaseCostAmt,SUM(ivts_BaseCostVatAmt) AS ivts_BaseCostVatAmt,SUM(ivts_BasePrice) AS ivts_BasePrice,SUM(ivts_BasePriceCostAmt) AS ivts_BasePriceCostAmt,SUM(ivts_BasePriceCostVatAmt) AS ivts_BasePriceCostVatAmt,SUM(ivts_BasePriceAmt) AS ivts_BasePriceAmt,SUM(ivts_BasePriceVatAmt) AS ivts_BasePriceVatAmt,SUM(ivts_EndQty) AS ivts_EndQty,SUM(ivts_EndAvgCost) AS ivts_EndAvgCost,SUM(ivts_EndCostAmt) AS ivts_EndCostAmt,SUM(ivts_EndCostVatAmt) AS ivts_EndCostVatAmt,SUM(ivts_EndPrice) AS ivts_EndPrice,SUM(ivts_EndPriceCostAmt) AS ivts_EndPriceCostAmt,SUM(ivts_EndPriceCostVatAmt) AS ivts_EndPriceCostVatAmt,SUM(ivts_EndPriceAmt) AS ivts_EndPriceAmt,SUM(ivts_EndPriceVatAmt) AS ivts_EndPriceVatAmt,SUM(ivts_SaleQty) AS ivts_SaleQty,SUM(ivts_TotalSaleAmt) AS ivts_TotalSaleAmt,SUM(ivts_SaleAmt) AS ivts_SaleAmt,SUM(ivts_SaleVatAmt) AS ivts_SaleVatAmt,SUM(ivts_SaleProfit) AS ivts_SaleProfit,SUM(ivts_SalePriceProfit) AS ivts_SalePriceProfit,SUM(ivts_EnurySlip) AS ivts_EnurySlip,SUM(ivts_EnuryEnd) AS ivts_EnuryEnd,SUM(ivts_DcAmtManual) AS ivts_DcAmtManual,SUM(ivts_DcAmtEvent) AS ivts_DcAmtEvent,SUM(ivts_DcAmtGoods) AS ivts_DcAmtGoods,SUM(ivts_DcAmtCoupon) AS ivts_DcAmtCoupon,SUM(ivts_DcAmtPromotion) AS ivts_DcAmtPromotion,SUM(ivts_DcAmtMember) AS ivts_DcAmtMember,SUM(ivts_Customer) AS ivts_Customer,SUM(ivts_CustomerGoods) AS ivts_CustomerGoods,SUM(ivts_CustomerCategory) AS ivts_CustomerCategory,SUM(ivts_CustomerSupplier) AS ivts_CustomerSupplier,SUM(ivts_BuyQty) AS ivts_BuyQty,SUM(ivts_BuyCostAmt) AS ivts_BuyCostAmt,SUM(ivts_BuyCostVatAmt) AS ivts_BuyCostVatAmt,SUM(ivts_BuyPriceAmt) AS ivts_BuyPriceAmt,SUM(ivts_BuyPriceVatAmt) AS ivts_BuyPriceVatAmt,SUM(ivts_ReturnQty) AS ivts_ReturnQty,SUM(ivts_ReturnCostAmt) AS ivts_ReturnCostAmt,SUM(ivts_ReturnCostVatAmt) AS ivts_ReturnCostVatAmt,SUM(ivts_ReturnPriceAmt) AS ivts_ReturnPriceAmt,SUM(ivts_ReturnPriceVatAmt) AS ivts_ReturnPriceVatAmt,SUM(ivts_InnerMoveOutQty) AS ivts_InnerMoveOutQty,SUM(ivts_InnerMoveOutCostAmt) AS ivts_InnerMoveOutCostAmt,SUM(ivts_InnerMoveOutCostVatAmt) AS ivts_InnerMoveOutCostVatAmt,SUM(ivts_InnerMoveOutPriceAmt) AS ivts_InnerMoveOutPriceAmt,SUM(ivts_InnerMoveOutPriceVatAmt) AS ivts_InnerMoveOutPriceVatAmt,SUM(ivts_InnerMoveInQty) AS ivts_InnerMoveInQty,SUM(ivts_InnerMoveInCostAmt) AS ivts_InnerMoveInCostAmt,SUM(ivts_InnerMoveInCostVatAmt) AS ivts_InnerMoveInCostVatAmt,SUM(ivts_InnerMoveInPriceAmt) AS ivts_InnerMoveInPriceAmt,SUM(ivts_InnerMoveInPriceVatAmt) AS ivts_InnerMoveInPriceVatAmt,SUM(ivts_OuterMoveOutQty) AS ivts_OuterMoveOutQty,SUM(ivts_OuterMoveOutCostAmt) AS ivts_OuterMoveOutCostAmt,SUM(ivts_OuterMoveOutCostVatAmt) AS ivts_OuterMoveOutCostVatAmt,SUM(ivts_OuterMoveOutPriceAmt) AS ivts_OuterMoveOutPriceAmt,SUM(ivts_OuterMoveOutPriceVatAmt) AS ivts_OuterMoveOutPriceVatAmt,SUM(ivts_OuterMoveInQty) AS ivts_OuterMoveInQty,SUM(ivts_OuterMoveInCostAmt) AS ivts_OuterMoveInCostAmt,SUM(ivts_OuterMoveInCostVatAmt) AS ivts_OuterMoveInCostVatAmt,SUM(ivts_OuterMoveInPriceAmt) AS ivts_OuterMoveInPriceAmt,SUM(ivts_OuterMoveInPriceVatAmt) AS ivts_OuterMoveInPriceVatAmt,SUM(ivts_PreAdjustQty) AS ivts_PreAdjustQty,SUM(ivts_PreAdjustCostAmt) AS ivts_PreAdjustCostAmt,SUM(ivts_PreAdjustCostVatAmt) AS ivts_PreAdjustCostVatAmt,SUM(ivts_PreAdjustPriceAmt) AS ivts_PreAdjustPriceAmt,SUM(ivts_PreAdjustPriceVatAmt) AS ivts_PreAdjustPriceVatAmt,SUM(ivts_PreAdjustPriceCostSumAmt) AS ivts_PreAdjustPriceCostSumAmt,SUM(ivts_PreAdjustPriceCostVatAmt) AS ivts_PreAdjustPriceCostVatAmt,SUM(ivts_DisuseQty) AS ivts_DisuseQty,SUM(ivts_DisuseCostAmt) AS ivts_DisuseCostAmt,SUM(ivts_DisuseCostVatAmt) AS ivts_DisuseCostVatAmt,SUM(ivts_DisusePriceAmt) AS ivts_DisusePriceAmt,SUM(ivts_DisusePriceVatAmt) AS ivts_DisusePriceVatAmt,SUM(ivts_DisusePriceCostSumAmt) AS ivts_DisusePriceCostSumAmt,SUM(ivts_DisusePriceCostVatAmt) AS ivts_DisusePriceCostVatAmt,SUM(ivts_PriceUp) AS ivts_PriceUp,SUM(ivts_PriceUpVat) AS ivts_PriceUpVat,SUM(ivts_PriceDown) AS ivts_PriceDown,SUM(ivts_PriceDownVat) AS ivts_PriceDownVat,SUM(ivts_InventoryQty) AS ivts_InventoryQty,SUM(ivts_InventoryCostAmt) AS ivts_InventoryCostAmt,SUM(ivts_InventoryCostVatAmt) AS ivts_InventoryCostVatAmt,SUM(ivts_InventoryPriceAmt) AS ivts_InventoryPriceAmt,SUM(ivts_InventoryPriceVatAmt) AS ivts_InventoryPriceVatAmt,SUM(ivts_InventoryPriceCostSumAmt) AS ivts_InventoryPriceCostSumAmt,SUM(ivts_InventoryPriceCostVatAmt) AS ivts_InventoryPriceCostVatAmt,SUM(ivts_IsInventory) AS ivts_IsInventory,SUM(ivts_AdjustQty) AS ivts_AdjustQty,SUM(ivts_AdjustCostAmt) AS ivts_AdjustCostAmt,SUM(ivts_AdjustCostVatAmt) AS ivts_AdjustCostVatAmt,SUM(ivts_AdjustPriceAmt) AS ivts_AdjustPriceAmt,SUM(ivts_AdjustPriceVatAmt) AS ivts_AdjustPriceVatAmt,SUM(ivts_AdjustPriceCostSumAmt) AS ivts_AdjustPriceCostSumAmt,SUM(ivts_AdjustPriceCostVatAmt) AS ivts_AdjustPriceCostVatAmt,SUM(ivts_LossQty) AS ivts_LossQty,SUM(ivts_LossCostAmt) AS ivts_LossCostAmt,SUM(ivts_LossCostVatAmt) AS ivts_LossCostVatAmt,SUM(ivts_LossPriceAmt) AS ivts_LossPriceAmt,SUM(ivts_LossPriceVatAmt) AS ivts_LossPriceVatAmt,SUM(ivts_LossPriceCostSumAmt) AS ivts_LossPriceCostSumAmt,SUM(ivts_LossPriceCostVatAmt) AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public const string TBodyStartTable = "기초";
    [JsonIgnore]
    public static string TBodyStartCol = ",ivts_BaseQty,ivts_BaseAvgCost,ivts_BaseCostAmt,ivts_BaseCostVatAmt,ivts_BasePrice,ivts_BasePriceCostAmt,ivts_BasePriceCostVatAmt,ivts_BasePriceAmt,ivts_BasePriceVatAmt,0 AS ivts_EndQty,0 AS ivts_EndAvgCost,0 AS ivts_EndCostAmt,0 AS ivts_EndCostVatAmt,0 AS ivts_EndPrice,0 AS ivts_EndPriceCostAmt,0 AS ivts_EndPriceCostVatAmt,0 AS ivts_EndPriceAmt,0 AS ivts_EndPriceVatAmt,0 AS ivts_SaleQty,0 AS ivts_TotalSaleAmt,0 AS ivts_SaleAmt,0 AS ivts_SaleVatAmt,0 AS ivts_SaleProfit,0 AS ivts_SalePriceProfit,0 AS ivts_EnurySlip,0 AS ivts_EnuryEnd,0 AS ivts_DcAmtManual,0 AS ivts_DcAmtEvent,0 AS ivts_DcAmtGoods,0 AS ivts_DcAmtCoupon,0 AS ivts_DcAmtPromotion,0 AS ivts_DcAmtMember,0 AS ivts_Customer,0 AS ivts_CustomerGoods,0 AS ivts_CustomerCategory,0 AS ivts_CustomerSupplier,0 AS ivts_BuyQty,0 AS ivts_BuyCostAmt,0 AS ivts_BuyCostVatAmt,0 AS ivts_BuyPriceAmt,0 AS ivts_BuyPriceVatAmt,0 AS ivts_ReturnQty,0 AS ivts_ReturnCostAmt,0 AS ivts_ReturnCostVatAmt,0 AS ivts_ReturnPriceAmt,0 AS ivts_ReturnPriceVatAmt,0 AS ivts_InnerMoveOutQty,0 AS ivts_InnerMoveOutCostAmt,0 AS ivts_InnerMoveOutCostVatAmt,0 AS ivts_InnerMoveOutPriceAmt,0 AS ivts_InnerMoveOutPriceVatAmt,0 AS ivts_InnerMoveInQty,0 AS ivts_InnerMoveInCostAmt,0 AS ivts_InnerMoveInCostVatAmt,0 AS ivts_InnerMoveInPriceAmt,0 AS ivts_InnerMoveInPriceVatAmt,0 AS ivts_OuterMoveOutQty,0 AS ivts_OuterMoveOutCostAmt,0 AS ivts_OuterMoveOutCostVatAmt,0 AS ivts_OuterMoveOutPriceAmt,0 AS ivts_OuterMoveOutPriceVatAmt,0 AS ivts_OuterMoveInQty,0 AS ivts_OuterMoveInCostAmt,0 AS ivts_OuterMoveInCostVatAmt,0 AS ivts_OuterMoveInPriceAmt,0 AS ivts_OuterMoveInPriceVatAmt,0 AS ivts_PreAdjustQty,0 AS ivts_PreAdjustCostAmt,0 AS ivts_PreAdjustCostVatAmt,0 AS ivts_PreAdjustPriceAmt,0 AS ivts_PreAdjustPriceVatAmt,0 AS ivts_PreAdjustPriceCostSumAmt,0 AS ivts_PreAdjustPriceCostVatAmt,0 AS ivts_DisuseQty,0 AS ivts_DisuseCostAmt,0 AS ivts_DisuseCostVatAmt,0 AS ivts_DisusePriceAmt,0 AS ivts_DisusePriceVatAmt,0 AS ivts_DisusePriceCostSumAmt,0 AS ivts_DisusePriceCostVatAmt,0 AS ivts_PriceUp,0 AS ivts_PriceUpVat,0 AS ivts_PriceDown,0 AS ivts_PriceDownVat,0 AS ivts_InventoryQty,0 AS ivts_InventoryCostAmt,0 AS ivts_InventoryCostVatAmt,0 AS ivts_InventoryPriceAmt,0 AS ivts_InventoryPriceVatAmt,0 AS ivts_InventoryPriceCostSumAmt,0 AS ivts_InventoryPriceCostVatAmt,0 AS ivts_IsInventory,0 AS ivts_AdjustQty,0 AS ivts_AdjustCostAmt,0 AS ivts_AdjustCostVatAmt,0 AS ivts_AdjustPriceAmt,0 AS ivts_AdjustPriceVatAmt,0 AS ivts_AdjustPriceCostSumAmt,0 AS ivts_AdjustPriceCostVatAmt,0 AS ivts_LossQty,0 AS ivts_LossCostAmt,0 AS ivts_LossCostVatAmt,0 AS ivts_LossPriceAmt,0 AS ivts_LossPriceVatAmt,0 AS ivts_LossPriceCostSumAmt,0 AS ivts_LossPriceCostVatAmt";
    [JsonIgnore]
    public const string TBodyEndTable = "기말";
    [JsonIgnore]
    public static string TBodyEndCol = ",0,0,0,0,0,0,0,0,0,ivts_EndQty,ivts_EndAvgCost,ivts_EndCostAmt,ivts_EndCostVatAmt,ivts_EndPrice,ivts_EndPriceCostAmt,ivts_EndPriceCostVatAmt,ivts_EndPriceAmt,ivts_EndPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodySaleTable = "매출";
    [JsonIgnore]
    public static string TBodySaleCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_SaleQty,ivts_TotalSaleAmt,ivts_SaleAmt,ivts_SaleVatAmt,ivts_SaleProfit,ivts_SalePriceProfit,ivts_EnurySlip,ivts_EnuryEnd,ivts_DcAmtManual,ivts_DcAmtEvent,ivts_DcAmtGoods,ivts_DcAmtCoupon,ivts_DcAmtPromotion,ivts_DcAmtMember,ivts_Customer,ivts_CustomerGoods,ivts_CustomerCategory,ivts_CustomerSupplier,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyBuyTable = "매입";
    [JsonIgnore]
    public static string TBodyBuyCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_BuyQty,ivts_BuyCostAmt,ivts_BuyCostVatAmt,ivts_BuyPriceAmt,ivts_BuyPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyReturnTable = "반품";
    [JsonIgnore]
    public static string TBodyReturnCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_ReturnQty,ivts_ReturnCostAmt,ivts_ReturnCostVatAmt,ivts_ReturnPriceAmt,ivts_ReturnPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyInnerMoveOutTable = "대출";
    [JsonIgnore]
    public static string TBodyInnerMoveOutCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_InnerMoveOutQty,ivts_InnerMoveOutCostAmt,ivts_InnerMoveOutCostVatAmt,ivts_InnerMoveOutPriceAmt,ivts_InnerMoveOutPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyInnerMoveInTable = "대입";
    [JsonIgnore]
    public static string TBodyInnerMoveInCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_InnerMoveInQty,ivts_InnerMoveInCostAmt,ivts_InnerMoveInCostVatAmt,ivts_InnerMoveInPriceAmt,ivts_InnerMoveInPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyOuterMoveOutTable = "점풀";
    [JsonIgnore]
    public static string TBodyOuterMoveOutCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_OuterMoveOutQty,ivts_OuterMoveOutCostAmt,ivts_OuterMoveOutCostVatAmt,ivts_OuterMoveOutPriceAmt,ivts_OuterMoveOutPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyOuterMoveInTable = "점입";
    [JsonIgnore]
    public static string TBodyOuterMoveInCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_OuterMoveInQty,ivts_OuterMoveInCostAmt,ivts_OuterMoveInCostVatAmt,ivts_OuterMoveInPriceAmt,ivts_OuterMoveInPriceVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyAdjustTable = "재고조정(수량,중량) 전일";
    [JsonIgnore]
    public const string TBodyAdjustDayTable = "재고조정(수량,중량) 당일";
    [JsonIgnore]
    public const string TBodyAdjustDayAmountTable = "재고조정(금액) 당일";
    [JsonIgnore]
    public static string TBodyAdjustCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyAdjustAmountTable = "재고조정(금액)";
    [JsonIgnore]
    public static string TBodyAdjustAmountCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyDisuseTable = "폐기";
    [JsonIgnore]
    public static string TBodyDisuseCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_DisuseQty,ivts_DisuseCostAmt,ivts_DisuseCostVatAmt,ivts_DisusePriceAmt,ivts_DisusePriceVatAmt,ivts_DisusePriceCostSumAmt,ivts_DisusePriceCostVatAmt,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
    [JsonIgnore]
    public const string TBodyInventoryTable = "재고조사";
    [JsonIgnore]
    public static string TBodyInventoryCol = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,ivts_InventoryQty,ivts_InventoryCostAmt,ivts_InventoryCostVatAmt,ivts_InventoryPriceAmt,ivts_InventoryPriceVatAmt,ivts_InventoryPriceCostSumAmt,ivts_InventoryPriceCostVatAmt,1 AS ivts_IsInventory,0,0,0,0,0,0,0,0,0,0,0,0,0,0";

    public override object _Key => (object) new object[4]
    {
      (object) this.ivts_YyyyMm,
      (object) this.ivts_Day,
      (object) this.ivts_StoreCode,
      (object) this.ivts_GoodsCode
    };

    public int ivts_YyyyMm
    {
      get => this._ivts_YyyyMm;
      set
      {
        this._ivts_YyyyMm = value;
        this.Changed(nameof (ivts_YyyyMm));
      }
    }

    public int ivts_Day
    {
      get => this._ivts_Day;
      set
      {
        this._ivts_Day = value;
        this.Changed(nameof (ivts_Day));
      }
    }

    public int ivts_StoreCode
    {
      get => this._ivts_StoreCode;
      set
      {
        this._ivts_StoreCode = value;
        this.Changed(nameof (ivts_StoreCode));
      }
    }

    public long ivts_GoodsCode
    {
      get => this._ivts_GoodsCode;
      set
      {
        this._ivts_GoodsCode = value;
        this.Changed(nameof (ivts_GoodsCode));
      }
    }

    public long ivts_SiteID
    {
      get => this._ivts_SiteID;
      set
      {
        this._ivts_SiteID = value;
        this.Changed(nameof (ivts_SiteID));
      }
    }

    public int ivts_Supplier
    {
      get => this._ivts_Supplier;
      set
      {
        this._ivts_Supplier = value;
        this.Changed(nameof (ivts_Supplier));
      }
    }

    public int ivts_SupplierType
    {
      get => this._ivts_SupplierType;
      set
      {
        this._ivts_SupplierType = value;
        this.Changed(nameof (ivts_SupplierType));
      }
    }

    public int ivts_CategoryCode
    {
      get => this._ivts_CategoryCode;
      set
      {
        this._ivts_CategoryCode = value;
        this.Changed(nameof (ivts_CategoryCode));
      }
    }

    public int ivts_TaxDiv
    {
      get => this._ivts_TaxDiv;
      set
      {
        this._ivts_TaxDiv = value;
        this.Changed(nameof (ivts_TaxDiv));
        this.Changed("ivts_TaxDivDesc");
        this.Changed("ivts_IsTax");
      }
    }

    public string ivts_TaxDivDesc => this.ivts_TaxDiv != 0 ? Enum2StrConverter.ToTaxDiv(this.ivts_TaxDiv).ToDescription() : string.Empty;

    public bool ivts_IsTax => Enum2StrConverter.ToTaxDiv(this.ivts_TaxDiv) == EnumTaxDiv.TAX;

    public int ivts_StockUnit
    {
      get => this._ivts_StockUnit;
      set
      {
        this._ivts_StockUnit = value;
        this.Changed(nameof (ivts_StockUnit));
        this.Changed("ivts_StockUnitDesc");
        this.Changed("ivts_IsStockUnitAmount");
        this.Changed("ivts_IsStockUnitQty");
        this.Changed("ivts_IsStockUnitWeight");
      }
    }

    public string ivts_StockUnitDesc => this.ivts_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.ivts_StockUnit).ToDescription() : string.Empty;

    public bool ivts_IsStockUnitAmount => Enum2StrConverter.ToStockUnit(this.ivts_StockUnit) == EnumStockUnit.AMOUNT;

    public bool ivts_IsStockUnitQty => Enum2StrConverter.ToStockUnit(this.ivts_StockUnit) == EnumStockUnit.QTY;

    public bool ivts_IsStockUnitWeight => Enum2StrConverter.ToStockUnit(this.ivts_StockUnit) == EnumStockUnit.WEIGHT;

    public int ivts_SalesUnit
    {
      get => this._ivts_SalesUnit;
      set
      {
        this._ivts_SalesUnit = value;
        this.Changed(nameof (ivts_SalesUnit));
        this.Changed("ivts_SalesUnitDesc");
      }
    }

    public string ivts_SalesUnitDesc => this.ivts_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.ivts_SalesUnit).ToDescription() : string.Empty;

    public double ivts_BaseQty
    {
      get => this._ivts_BaseQty;
      set
      {
        this._ivts_BaseQty = value;
        this.Changed(nameof (ivts_BaseQty));
      }
    }

    public double ivts_BaseAvgCost
    {
      get => this._ivts_BaseAvgCost;
      set
      {
        this._ivts_BaseAvgCost = value;
        this.Changed(nameof (ivts_BaseAvgCost));
      }
    }

    public double ivts_BaseCostAmt
    {
      get => this._ivts_BaseCostAmt;
      set
      {
        this._ivts_BaseCostAmt = value;
        this.Changed(nameof (ivts_BaseCostAmt));
        this.Changed("ivts_BaseCostSumAmt");
      }
    }

    public double ivts_BaseCostVatAmt
    {
      get => this._ivts_BaseCostVatAmt;
      set
      {
        this._ivts_BaseCostVatAmt = value;
        this.Changed(nameof (ivts_BaseCostVatAmt));
        this.Changed("ivts_BaseCostSumAmt");
      }
    }

    public double ivts_BaseCostSumAmt => this.ivts_BaseCostAmt + this.ivts_BaseCostVatAmt;

    public double ivts_BasePrice
    {
      get => this._ivts_BasePrice;
      set
      {
        this._ivts_BasePrice = value;
        this.Changed(nameof (ivts_BasePrice));
      }
    }

    public double ivts_BasePriceAmt
    {
      get => this._ivts_BasePriceAmt;
      set
      {
        this._ivts_BasePriceAmt = value;
        this.Changed(nameof (ivts_BasePriceAmt));
        this.Changed("ivts_BasePriceTaxFreeAmt");
      }
    }

    public double ivts_BasePriceVatAmt
    {
      get => this._ivts_BasePriceVatAmt;
      set
      {
        this._ivts_BasePriceVatAmt = value;
        this.Changed(nameof (ivts_BasePriceVatAmt));
        this.Changed("ivts_BasePriceTaxFreeAmt");
      }
    }

    public double ivts_BasePriceTaxFreeAmt => this.ivts_BasePriceAmt - this.ivts_BasePriceVatAmt;

    public double ivts_BasePriceCostAmt
    {
      get => this._ivts_BasePriceCostAmt;
      set
      {
        this._ivts_BasePriceCostAmt = value;
        this.Changed(nameof (ivts_BasePriceCostAmt));
        this.Changed("ivts_BasePriceCostSumAmt");
      }
    }

    public double ivts_BasePriceCostVatAmt
    {
      get => this._ivts_BasePriceCostVatAmt;
      set
      {
        this._ivts_BasePriceCostVatAmt = value;
        this.Changed(nameof (ivts_BasePriceCostVatAmt));
        this.Changed("ivts_BasePriceCostSumAmt");
      }
    }

    public double ivts_BasePriceCostSumAmt => this.ivts_BasePriceCostAmt + this.ivts_BasePriceCostVatAmt;

    public double ivts_EndQty
    {
      get => this._ivts_EndQty;
      set
      {
        this._ivts_EndQty = value;
        this.Changed(nameof (ivts_EndQty));
      }
    }

    public double ivts_EndAvgCost
    {
      get => this._ivts_EndAvgCost;
      set
      {
        this._ivts_EndAvgCost = value;
        this.Changed(nameof (ivts_EndAvgCost));
      }
    }

    public void CalcEndAvgCost() => this.ivts_EndAvgCost = CalcHelper.ToArgCost3(Math.Abs(this.ivts_BaseCostAmt) + Math.Abs(this.ivts_BuyCostAmt + this.ivts_InnerMoveOutCostAmt + this.ivts_InnerMoveInCostAmt + this.ivts_OuterMoveInCostAmt), Math.Abs(this.ivts_BaseCostAmt.IsZero() ? 0.0 : this.ivts_BaseQty) + Math.Abs(this.ivts_BuyQty + this.ivts_InnerMoveInQty + this.ivts_OuterMoveInQty));

    public double ivts_EndCostAmt
    {
      get => this._ivts_EndCostAmt;
      set
      {
        this._ivts_EndCostAmt = value;
        this.Changed(nameof (ivts_EndCostAmt));
        this.Changed("ivts_EndCostSumAmt");
      }
    }

    public double ivts_EndCostVatAmt
    {
      get => this._ivts_EndCostVatAmt;
      set
      {
        this._ivts_EndCostVatAmt = value;
        this.Changed(nameof (ivts_EndCostVatAmt));
        this.Changed("ivts_EndCostSumAmt");
      }
    }

    public double ivts_EndCostSumAmt => this.ivts_EndCostAmt + this.ivts_EndCostVatAmt;

    public double ivts_EndPrice
    {
      get => this._ivts_EndPrice;
      set
      {
        this._ivts_EndPrice = value;
        this.Changed(nameof (ivts_EndPrice));
      }
    }

    public double ivts_EndPriceAmt
    {
      get => this._ivts_EndPriceAmt;
      set
      {
        this._ivts_EndPriceAmt = value;
        this.Changed(nameof (ivts_EndPriceAmt));
        this.Changed("ivts_EndPriceTaxFreeAmt");
      }
    }

    public void CalcEndPriceAmt() => this.ivts_EndPriceAmt = this.ivts_EndPrice * this.ivts_EndQty;

    public double ivts_EndPriceVatAmt
    {
      get => this._ivts_EndPriceVatAmt;
      set
      {
        this._ivts_EndPriceVatAmt = value;
        this.Changed(nameof (ivts_EndPriceVatAmt));
        this.Changed("ivts_EndPriceTaxFreeAmt");
      }
    }

    public double ivts_EndPriceTaxFreeAmt => this.ivts_EndPriceAmt - this.ivts_EndPriceVatAmt;

    public double ivts_EndPriceCostAmt
    {
      get => this._ivts_EndPriceCostAmt;
      set
      {
        this._ivts_EndPriceCostAmt = value;
        this.Changed(nameof (ivts_EndPriceCostAmt));
        this.Changed("ivts_EndPriceCostSumAmt");
      }
    }

    public void CalcEndPriceCostAmt() => this.ivts_EndPriceCostAmt = CalcHelper.CalcDoubleToFormatDouble(this.ivts_EndPriceAmt * this.CalcEndPriceCostRate());

    public double ivts_EndPriceCostVatAmt
    {
      get => this._ivts_EndPriceCostVatAmt;
      set
      {
        this._ivts_EndPriceCostVatAmt = value;
        this.Changed(nameof (ivts_EndPriceCostVatAmt));
        this.Changed("ivts_EndPriceCostSumAmt");
      }
    }

    public double ivts_EndPriceCostSumAmt => this.ivts_EndPriceCostAmt + this.ivts_EndPriceCostVatAmt;

    public double CalcEndPriceCostRate()
    {
      double pVal1 = this.ivts_BasePriceAmt + this.ivts_BuyPriceAmt - this.ivts_ReturnPriceAmt + this.ivts_InnerMoveInPriceAmt - this.ivts_InnerMoveOutPriceAmt + this.ivts_OuterMoveInPriceAmt - this.ivts_OuterMoveOutPriceAmt;
      return pVal1.IsZero() ? 0.0 : (this.ivts_BasePriceCostAmt + this.ivts_BuyCostAmt - this.ivts_ReturnCostAmt + this.ivts_InnerMoveInCostAmt - this.ivts_InnerMoveOutCostAmt + this.ivts_OuterMoveInCostAmt - this.ivts_OuterMoveOutCostAmt) / pVal1;
    }

    public double ivts_SaleQty
    {
      get => this._ivts_SaleQty;
      set
      {
        this._ivts_SaleQty = value;
        this.Changed(nameof (ivts_SaleQty));
      }
    }

    public double ivts_TotalSaleAmt
    {
      get => this._ivts_TotalSaleAmt;
      set
      {
        this._ivts_TotalSaleAmt = value;
        this.Changed(nameof (ivts_TotalSaleAmt));
      }
    }

    public double ivts_SaleAmt
    {
      get => this._ivts_SaleAmt;
      set
      {
        this._ivts_SaleAmt = value;
        this.Changed(nameof (ivts_SaleAmt));
        this.Changed("ivts_SaleTaxFreeAmt");
        this.Changed("ivts_ProfitRule");
        this.Changed("ivts_PriceProfitRule");
        this.Changed("ivts_LossRule");
        this.Changed("ivts_PriceLossRule");
      }
    }

    public double ivts_SaleVatAmt
    {
      get => this._ivts_SaleVatAmt;
      set
      {
        this._ivts_SaleVatAmt = value;
        this.Changed(nameof (ivts_SaleVatAmt));
        this.Changed("ivts_SaleTaxFreeAmt");
        this.Changed("ivts_ProfitRule");
        this.Changed("ivts_PriceProfitRule");
        this.Changed("ivts_LossRule");
      }
    }

    public double ivts_SaleTaxFreeAmt => this.ivts_SaleAmt - this.ivts_SaleVatAmt;

    public double ivts_SaleProfit
    {
      get => this._ivts_SaleProfit;
      set
      {
        this._ivts_SaleProfit = value;
        this.Changed(nameof (ivts_SaleProfit));
        this.Changed("ivts_ProfitRule");
      }
    }

    public void CalcSaleProfit() => this.ivts_SaleProfit = this.ivts_SaleTaxFreeAmt - this.CalcBuyTaxFreeAmount();

    public double ivts_ProfitRule => CalcHelper.ToSaleProfitMargin(this.ivts_SaleProfit, this.ivts_SaleTaxFreeAmt);

    public double ivts_SalePriceProfit
    {
      get => this._ivts_SalePriceProfit;
      set
      {
        this._ivts_SalePriceProfit = value;
        this.Changed(nameof (ivts_SalePriceProfit));
        this.Changed("ivts_PriceProfitRule");
      }
    }

    public void CalcSalePriceProfit() => this.ivts_SalePriceProfit = this.ivts_SaleTaxFreeAmt - this.CalcBuyPriceTaxFreeAmount();

    public double ivts_PriceProfitRule => CalcHelper.ToSaleProfitMargin(this.ivts_SalePriceProfit, this.ivts_SaleTaxFreeAmt);

    public double ivts_EnurySlip
    {
      get => this._ivts_EnurySlip;
      set
      {
        this._ivts_EnurySlip = value;
        this.Changed(nameof (ivts_EnurySlip));
      }
    }

    public double ivts_EnuryEnd
    {
      get => this._ivts_EnuryEnd;
      set
      {
        this._ivts_EnuryEnd = value;
        this.Changed(nameof (ivts_EnuryEnd));
      }
    }

    public double ivts_DcAmtManual
    {
      get => this._ivts_DcAmtManual;
      set
      {
        this._ivts_DcAmtManual = value;
        this.Changed(nameof (ivts_DcAmtManual));
      }
    }

    public double ivts_DcAmtEvent
    {
      get => this._ivts_DcAmtEvent;
      set
      {
        this._ivts_DcAmtEvent = value;
        this.Changed(nameof (ivts_DcAmtEvent));
      }
    }

    public double ivts_DcAmtGoods
    {
      get => this._ivts_DcAmtGoods;
      set
      {
        this._ivts_DcAmtGoods = value;
        this.Changed(nameof (ivts_DcAmtGoods));
      }
    }

    public double ivts_DcAmtCoupon
    {
      get => this._ivts_DcAmtCoupon;
      set
      {
        this._ivts_DcAmtCoupon = value;
        this.Changed(nameof (ivts_DcAmtCoupon));
      }
    }

    public double ivts_DcAmtPromotion
    {
      get => this._ivts_DcAmtPromotion;
      set
      {
        this._ivts_DcAmtPromotion = value;
        this.Changed(nameof (ivts_DcAmtPromotion));
      }
    }

    public double ivts_DcAmtMember
    {
      get => this._ivts_DcAmtMember;
      set
      {
        this._ivts_DcAmtMember = value;
        this.Changed(nameof (ivts_DcAmtMember));
      }
    }

    public double ivts_Customer
    {
      get => this._ivts_Customer;
      set
      {
        this._ivts_Customer = value;
        this.Changed(nameof (ivts_Customer));
      }
    }

    public double ivts_CustomerGoods
    {
      get => this._ivts_CustomerGoods;
      set
      {
        this._ivts_CustomerGoods = value;
        this.Changed(nameof (ivts_CustomerGoods));
      }
    }

    public double ivts_CustomerCategory
    {
      get => this._ivts_CustomerCategory;
      set
      {
        this._ivts_CustomerCategory = value;
        this.Changed(nameof (ivts_CustomerCategory));
      }
    }

    public double ivts_CustomerSupplier
    {
      get => this._ivts_CustomerSupplier;
      set
      {
        this._ivts_CustomerSupplier = value;
        this.Changed(nameof (ivts_CustomerSupplier));
      }
    }

    public double ivts_BuyQty
    {
      get => this._ivts_BuyQty;
      set
      {
        this._ivts_BuyQty = value;
        this.Changed(nameof (ivts_BuyQty));
      }
    }

    public double ivts_BuyCostAmt
    {
      get => this._ivts_BuyCostAmt;
      set
      {
        this._ivts_BuyCostAmt = value;
        this.Changed(nameof (ivts_BuyCostAmt));
        this.Changed("ivts_BuyCostSumAmt");
        this.Changed("ivts_BuyProfitRule");
      }
    }

    public double ivts_BuyCostVatAmt
    {
      get => this._ivts_BuyCostVatAmt;
      set
      {
        this._ivts_BuyCostVatAmt = value;
        this.Changed(nameof (ivts_BuyCostVatAmt));
        this.Changed("ivts_BuyCostSumAmt");
      }
    }

    public double ivts_BuyCostSumAmt => this.ivts_BuyCostAmt + this.ivts_BuyCostVatAmt;

    public double ivts_BuyPriceAmt
    {
      get => this._ivts_BuyPriceAmt;
      set
      {
        this._ivts_BuyPriceAmt = value;
        this.Changed(nameof (ivts_BuyPriceAmt));
        this.Changed("ivts_BuyPriceTaxFreeAmt");
        this.Changed("ivts_BuyProfitRule");
      }
    }

    public double ivts_BuyPriceVatAmt
    {
      get => this._ivts_BuyPriceVatAmt;
      set
      {
        this._ivts_BuyPriceVatAmt = value;
        this.Changed(nameof (ivts_BuyPriceVatAmt));
        this.Changed("ivts_BuyPriceTaxFreeAmt");
      }
    }

    public double ivts_BuyPriceTaxFreeAmt => this.ivts_BuyPriceAmt - this.ivts_BuyPriceVatAmt;

    public double ivts_BuyProfitRule => CalcHelper.ToBuyProfitMargin(this.ivts_BuyCostAmt, this.ivts_BuyPriceAmt);

    public double ivts_ReturnQty
    {
      get => this._ivts_ReturnQty;
      set
      {
        this._ivts_ReturnQty = value;
        this.Changed(nameof (ivts_ReturnQty));
      }
    }

    public double ivts_ReturnCostAmt
    {
      get => this._ivts_ReturnCostAmt;
      set
      {
        this._ivts_ReturnCostAmt = value;
        this.Changed(nameof (ivts_ReturnCostAmt));
        this.Changed("ivts_ReturnCostSumAmt");
      }
    }

    public double ivts_ReturnCostVatAmt
    {
      get => this._ivts_ReturnCostVatAmt;
      set
      {
        this._ivts_ReturnCostVatAmt = value;
        this.Changed(nameof (ivts_ReturnCostVatAmt));
        this.Changed("ivts_ReturnCostSumAmt");
      }
    }

    public double ivts_ReturnCostSumAmt => this.ivts_ReturnCostAmt + this.ivts_ReturnCostVatAmt;

    public double ivts_ReturnPriceAmt
    {
      get => this._ivts_ReturnPriceAmt;
      set
      {
        this._ivts_ReturnPriceAmt = value;
        this.Changed(nameof (ivts_ReturnPriceAmt));
        this.Changed("ivts_ReturnPriceTaxFreeAmt");
      }
    }

    public double ivts_ReturnPriceVatAmt
    {
      get => this._ivts_ReturnPriceVatAmt;
      set
      {
        this._ivts_ReturnPriceVatAmt = value;
        this.Changed(nameof (ivts_ReturnPriceVatAmt));
        this.Changed("ivts_ReturnPriceTaxFreeAmt");
      }
    }

    public double ivts_ReturnPriceTaxFreeAmt => this.ivts_ReturnPriceAmt - this.ivts_ReturnPriceVatAmt;

    public double ivts_InnerMoveOutQty
    {
      get => this._ivts_InnerMoveOutQty;
      set
      {
        this._ivts_InnerMoveOutQty = value;
        this.Changed(nameof (ivts_InnerMoveOutQty));
      }
    }

    public double ivts_InnerMoveOutCostAmt
    {
      get => this._ivts_InnerMoveOutCostAmt;
      set
      {
        this._ivts_InnerMoveOutCostAmt = value;
        this.Changed(nameof (ivts_InnerMoveOutCostAmt));
        this.Changed("ivts_InnerMoveOutCostSumAmt");
      }
    }

    public double ivts_InnerMoveOutCostVatAmt
    {
      get => this._ivts_InnerMoveOutCostVatAmt;
      set
      {
        this._ivts_InnerMoveOutCostVatAmt = value;
        this.Changed(nameof (ivts_InnerMoveOutCostVatAmt));
        this.Changed("ivts_InnerMoveOutCostSumAmt");
      }
    }

    public double ivts_InnerMoveOutCostSumAmt => this.ivts_InnerMoveOutCostAmt + this.ivts_InnerMoveOutCostVatAmt;

    public double ivts_InnerMoveOutPriceAmt
    {
      get => this._ivts_InnerMoveOutPriceAmt;
      set
      {
        this._ivts_InnerMoveOutPriceAmt = value;
        this.Changed(nameof (ivts_InnerMoveOutPriceAmt));
        this.Changed("ivts_InnerMoveOutPriceTaxFreeAmt");
      }
    }

    public double ivts_InnerMoveOutPriceVatAmt
    {
      get => this._ivts_InnerMoveOutPriceVatAmt;
      set
      {
        this._ivts_InnerMoveOutPriceVatAmt = value;
        this.Changed(nameof (ivts_InnerMoveOutPriceVatAmt));
        this.Changed("ivts_InnerMoveOutPriceTaxFreeAmt");
      }
    }

    public double ivts_InnerMoveOutPriceTaxFreeAmt => this.ivts_InnerMoveOutPriceAmt - this.ivts_InnerMoveOutPriceVatAmt;

    public double ivts_InnerMoveInQty
    {
      get => this._ivts_InnerMoveInQty;
      set
      {
        this._ivts_InnerMoveInQty = value;
        this.Changed(nameof (ivts_InnerMoveInQty));
      }
    }

    public double ivts_InnerMoveInCostAmt
    {
      get => this._ivts_InnerMoveInCostAmt;
      set
      {
        this._ivts_InnerMoveInCostAmt = value;
        this.Changed(nameof (ivts_InnerMoveInCostAmt));
        this.Changed("ivts_InnerMoveInCostSumAmt");
      }
    }

    public double ivts_InnerMoveInCostVatAmt
    {
      get => this._ivts_InnerMoveInCostVatAmt;
      set
      {
        this._ivts_InnerMoveInCostVatAmt = value;
        this.Changed(nameof (ivts_InnerMoveInCostVatAmt));
        this.Changed("ivts_InnerMoveInCostSumAmt");
      }
    }

    public double ivts_InnerMoveInCostSumAmt => this.ivts_InnerMoveInCostAmt + this.ivts_InnerMoveInCostVatAmt;

    public double ivts_InnerMoveInPriceAmt
    {
      get => this._ivts_InnerMoveInPriceAmt;
      set
      {
        this._ivts_InnerMoveInPriceAmt = value;
        this.Changed(nameof (ivts_InnerMoveInPriceAmt));
        this.Changed("ivts_InnerMoveInPriceTaxFreeAmt");
      }
    }

    public double ivts_InnerMoveInPriceVatAmt
    {
      get => this._ivts_InnerMoveInPriceVatAmt;
      set
      {
        this._ivts_InnerMoveInPriceVatAmt = value;
        this.Changed(nameof (ivts_InnerMoveInPriceVatAmt));
        this.Changed("ivts_InnerMoveInPriceTaxFreeAmt");
      }
    }

    public double ivts_InnerMoveInPriceTaxFreeAmt => this.ivts_InnerMoveInPriceAmt - this.ivts_InnerMoveInPriceVatAmt;

    public double ivts_OuterMoveOutQty
    {
      get => this._ivts_OuterMoveOutQty;
      set
      {
        this._ivts_OuterMoveOutQty = value;
        this.Changed(nameof (ivts_OuterMoveOutQty));
      }
    }

    public double ivts_OuterMoveOutCostAmt
    {
      get => this._ivts_OuterMoveOutCostAmt;
      set
      {
        this._ivts_OuterMoveOutCostAmt = value;
        this.Changed(nameof (ivts_OuterMoveOutCostAmt));
        this.Changed("ivts_OuterMoveOutCostSumAmt");
      }
    }

    public double ivts_OuterMoveOutCostVatAmt
    {
      get => this._ivts_OuterMoveOutCostVatAmt;
      set
      {
        this._ivts_OuterMoveOutCostVatAmt = value;
        this.Changed(nameof (ivts_OuterMoveOutCostVatAmt));
        this.Changed("ivts_OuterMoveOutCostSumAmt");
      }
    }

    public double ivts_OuterMoveOutCostSumAmt => this.ivts_OuterMoveOutCostAmt + this.ivts_OuterMoveOutCostVatAmt;

    public double ivts_OuterMoveOutPriceAmt
    {
      get => this._ivts_OuterMoveOutPriceAmt;
      set
      {
        this._ivts_OuterMoveOutPriceAmt = value;
        this.Changed(nameof (ivts_OuterMoveOutPriceAmt));
        this.Changed("ivts_OuterMoveOutPriceTaxFreeAmt");
      }
    }

    public double ivts_OuterMoveOutPriceVatAmt
    {
      get => this._ivts_OuterMoveOutPriceVatAmt;
      set
      {
        this._ivts_OuterMoveOutPriceVatAmt = value;
        this.Changed(nameof (ivts_OuterMoveOutPriceVatAmt));
        this.Changed("ivts_OuterMoveOutPriceTaxFreeAmt");
      }
    }

    public double ivts_OuterMoveOutPriceTaxFreeAmt => this.ivts_OuterMoveOutPriceAmt - this.ivts_OuterMoveOutPriceVatAmt;

    public double ivts_OuterMoveInQty
    {
      get => this._ivts_OuterMoveInQty;
      set
      {
        this._ivts_OuterMoveInQty = value;
        this.Changed(nameof (ivts_OuterMoveInQty));
      }
    }

    public double ivts_OuterMoveInCostAmt
    {
      get => this._ivts_OuterMoveInCostAmt;
      set
      {
        this._ivts_OuterMoveInCostAmt = value;
        this.Changed(nameof (ivts_OuterMoveInCostAmt));
        this.Changed("ivts_OuterMoveInCostSumAmt");
      }
    }

    public double ivts_OuterMoveInCostVatAmt
    {
      get => this._ivts_OuterMoveInCostVatAmt;
      set
      {
        this._ivts_OuterMoveInCostVatAmt = value;
        this.Changed(nameof (ivts_OuterMoveInCostVatAmt));
        this.Changed("ivts_OuterMoveInCostSumAmt");
      }
    }

    public double ivts_OuterMoveInCostSumAmt => this.ivts_OuterMoveInCostAmt + this.ivts_OuterMoveInCostVatAmt;

    public double ivts_OuterMoveInPriceAmt
    {
      get => this._ivts_OuterMoveInPriceAmt;
      set
      {
        this._ivts_OuterMoveInPriceAmt = value;
        this.Changed(nameof (ivts_OuterMoveInPriceAmt));
        this.Changed("ivts_OuterMoveInPriceTaxFreeAmt");
      }
    }

    public double ivts_OuterMoveInPriceVatAmt
    {
      get => this._ivts_OuterMoveInPriceVatAmt;
      set
      {
        this._ivts_OuterMoveInPriceVatAmt = value;
        this.Changed(nameof (ivts_OuterMoveInPriceVatAmt));
        this.Changed("ivts_OuterMoveInPriceTaxFreeAmt");
      }
    }

    public double ivts_OuterMoveInPriceTaxFreeAmt => this.ivts_OuterMoveInPriceAmt - this.ivts_OuterMoveInPriceVatAmt;

    public double ivts_PreAdjustQty
    {
      get => this._ivts_PreAdjustQty;
      set
      {
        this._ivts_PreAdjustQty = value;
        this.Changed(nameof (ivts_PreAdjustQty));
      }
    }

    public double ivts_PreAdjustCostAmt
    {
      get => this._ivts_PreAdjustCostAmt;
      set
      {
        this._ivts_PreAdjustCostAmt = value;
        this.Changed(nameof (ivts_PreAdjustCostAmt));
        this.Changed("ivts_PreAdjustCostSumAmt");
      }
    }

    public double ivts_PreAdjustCostVatAmt
    {
      get => this._ivts_PreAdjustCostVatAmt;
      set
      {
        this._ivts_PreAdjustCostVatAmt = value;
        this.Changed(nameof (ivts_PreAdjustCostVatAmt));
        this.Changed("ivts_PreAdjustCostSumAmt");
      }
    }

    public double ivts_PreAdjustCostSumAmt => this.ivts_PreAdjustCostAmt + this.ivts_PreAdjustCostVatAmt;

    public double ivts_PreAdjustPriceAmt
    {
      get => this._ivts_PreAdjustPriceAmt;
      set
      {
        this._ivts_PreAdjustPriceAmt = value;
        this.Changed(nameof (ivts_PreAdjustPriceAmt));
        this.Changed("ivts_PreAdjustPriceTaxFreeAmt");
      }
    }

    public double ivts_PreAdjustPriceVatAmt
    {
      get => this._ivts_PreAdjustPriceVatAmt;
      set
      {
        this._ivts_PreAdjustPriceVatAmt = value;
        this.Changed(nameof (ivts_PreAdjustPriceVatAmt));
        this.Changed("ivts_PreAdjustPriceTaxFreeAmt");
      }
    }

    public double ivts_PreAdjustPriceTaxFreeAmt => this.ivts_PreAdjustPriceAmt - this.ivts_PreAdjustPriceVatAmt;

    public double ivts_PreAdjustPriceCostSumAmt
    {
      get => this._ivts_PreAdjustPriceCostSumAmt;
      set
      {
        this._ivts_PreAdjustPriceCostSumAmt = value;
        this.Changed(nameof (ivts_PreAdjustPriceCostSumAmt));
        this.Changed("ivts_PreAdjustPriceCostAmt");
      }
    }

    public double ivts_PreAdjustPriceCostVatAmt
    {
      get => this._ivts_PreAdjustPriceCostVatAmt;
      set
      {
        this._ivts_PreAdjustPriceCostVatAmt = value;
        this.Changed(nameof (ivts_PreAdjustPriceCostVatAmt));
        this.Changed("ivts_PreAdjustPriceCostAmt");
      }
    }

    public double ivts_PreAdjustPriceCostAmt => this.ivts_PreAdjustPriceCostSumAmt - this.ivts_PreAdjustPriceCostVatAmt;

    public double ivts_DisuseQty
    {
      get => this._ivts_DisuseQty;
      set
      {
        this._ivts_DisuseQty = value;
        this.Changed(nameof (ivts_DisuseQty));
      }
    }

    public double ivts_DisuseCostAmt
    {
      get => this._ivts_DisuseCostAmt;
      set
      {
        this._ivts_DisuseCostAmt = value;
        this.Changed(nameof (ivts_DisuseCostAmt));
        this.Changed("ivts_DisuseCostSumAmt");
      }
    }

    public double ivts_DisuseCostVatAmt
    {
      get => this._ivts_DisuseCostVatAmt;
      set
      {
        this._ivts_DisuseCostVatAmt = value;
        this.Changed(nameof (ivts_DisuseCostVatAmt));
        this.Changed("ivts_DisuseCostSumAmt");
      }
    }

    public double ivts_DisuseCostSumAmt => this.ivts_DisuseCostAmt + this.ivts_DisuseCostVatAmt;

    public double ivts_DisusePriceAmt
    {
      get => this._ivts_DisusePriceAmt;
      set
      {
        this._ivts_DisusePriceAmt = value;
        this.Changed(nameof (ivts_DisusePriceAmt));
        this.Changed("ivts_DisusePriceTaxFreeAmt");
      }
    }

    public double ivts_DisusePriceVatAmt
    {
      get => this._ivts_DisusePriceVatAmt;
      set
      {
        this._ivts_DisusePriceVatAmt = value;
        this.Changed(nameof (ivts_DisusePriceVatAmt));
        this.Changed("ivts_DisusePriceTaxFreeAmt");
      }
    }

    public double ivts_DisusePriceTaxFreeAmt => this.ivts_DisusePriceAmt - this.ivts_DisusePriceVatAmt;

    public double ivts_DisusePriceCostSumAmt
    {
      get => this._ivts_DisusePriceCostSumAmt;
      set
      {
        this._ivts_DisusePriceCostSumAmt = value;
        this.Changed(nameof (ivts_DisusePriceCostSumAmt));
        this.Changed("ivts_DisusePriceCostAmt");
      }
    }

    public double ivts_DisusePriceCostVatAmt
    {
      get => this._ivts_DisusePriceCostVatAmt;
      set
      {
        this._ivts_DisusePriceCostVatAmt = value;
        this.Changed(nameof (ivts_DisusePriceCostVatAmt));
        this.Changed("ivts_DisusePriceCostAmt");
      }
    }

    public double ivts_DisusePriceCostAmt => this.ivts_DisusePriceCostSumAmt - this.ivts_DisusePriceCostVatAmt;

    public double ivts_PriceUp
    {
      get => this._ivts_PriceUp;
      set
      {
        this._ivts_PriceUp = value;
        this.Changed(nameof (ivts_PriceUp));
        this.Changed("ivts_PriceUpPriceCostAmt");
      }
    }

    public double ivts_PriceUpVat
    {
      get => this._ivts_PriceUpVat;
      set
      {
        this._ivts_PriceUpVat = value;
        this.Changed(nameof (ivts_PriceUpVat));
        this.Changed("ivts_PriceUpPriceCostAmt");
      }
    }

    public double ivts_PriceUpPriceCostAmt => this.ivts_PriceUp - this.ivts_PriceUpVat;

    public double ivts_PriceDown
    {
      get => this._ivts_PriceDown;
      set
      {
        this._ivts_PriceDown = value;
        this.Changed(nameof (ivts_PriceDown));
        this.Changed("ivts_PriceDownPriceCostAmt");
      }
    }

    public double ivts_PriceDownVat
    {
      get => this._ivts_PriceDownVat;
      set
      {
        this._ivts_PriceDownVat = value;
        this.Changed(nameof (ivts_PriceDownVat));
        this.Changed("ivts_PriceDownPriceCostAmt");
      }
    }

    public double ivts_PriceDownPriceCostAmt => this.ivts_PriceDown - this.ivts_PriceDownVat;

    public void CalcSalePriceUpDown()
    {
      this.ivts_PriceUp = this.ivts_PriceDown = 0.0;
      if (this.ivts_IsStockUnitAmount)
        return;
      double num = this.ivts_EndPriceAmt - (this.ivts_BasePriceAmt + this.ivts_BuyPriceAmt - this.ivts_ReturnPriceAmt + this.ivts_InnerMoveInPriceAmt - this.ivts_InnerMoveOutPriceAmt + this.ivts_OuterMoveInPriceAmt - this.ivts_OuterMoveOutPriceAmt + this.ivts_PreAdjustPriceAmt - this.ivts_SaleAmt);
      if (num > 0.0)
        this.ivts_PriceUp = num;
      else
        this.ivts_PriceDown = num * -1.0;
      if (this.ivts_IsTax)
      {
        this.ivts_PriceUpVat = this.ivts_PriceUp.ToPriceVat();
        this.ivts_PriceDownVat = this.ivts_PriceDown.ToPriceVat();
      }
      else
      {
        this.ivts_PriceUpVat = 0.0;
        this.ivts_PriceDownVat = 0.0;
      }
    }

    public double ivts_InventoryQty
    {
      get => this._ivts_InventoryQty;
      set
      {
        this._ivts_InventoryQty = value;
        this.Changed(nameof (ivts_InventoryQty));
      }
    }

    public double ivts_InventoryCostAmt
    {
      get => this._ivts_InventoryCostAmt;
      set
      {
        this._ivts_InventoryCostAmt = value;
        this.Changed(nameof (ivts_InventoryCostAmt));
        this.Changed("ivts_InventoryCostSumAmt");
      }
    }

    public double ivts_InventoryCostVatAmt
    {
      get => this._ivts_InventoryCostVatAmt;
      set
      {
        this._ivts_InventoryCostVatAmt = value;
        this.Changed(nameof (ivts_InventoryCostVatAmt));
        this.Changed("ivts_InventoryCostSumAmt");
      }
    }

    public double ivts_InventoryCostSumAmt => this.ivts_InventoryCostAmt + this.ivts_InventoryCostVatAmt;

    public double ivts_InventoryPriceAmt
    {
      get => this._ivts_InventoryPriceAmt;
      set
      {
        this._ivts_InventoryPriceAmt = value;
        this.Changed(nameof (ivts_InventoryPriceAmt));
        this.Changed("ivts_InventoryPriceTaxFreeAmt");
      }
    }

    public double ivts_InventoryPriceVatAmt
    {
      get => this._ivts_InventoryPriceVatAmt;
      set
      {
        this._ivts_InventoryPriceVatAmt = value;
        this.Changed(nameof (ivts_InventoryPriceVatAmt));
        this.Changed("ivts_InventoryPriceTaxFreeAmt");
      }
    }

    public double ivts_InventoryPriceTaxFreeAmt => this.ivts_InventoryPriceAmt - this.ivts_InventoryPriceVatAmt;

    public double ivts_InventoryPriceCostSumAmt
    {
      get => this._ivts_InventoryPriceCostSumAmt;
      set
      {
        this._ivts_InventoryPriceCostSumAmt = value;
        this.Changed(nameof (ivts_InventoryPriceCostSumAmt));
        this.Changed("ivts_InventoryPriceCostAmt");
      }
    }

    public double ivts_InventoryPriceCostVatAmt
    {
      get => this._ivts_InventoryPriceCostVatAmt;
      set
      {
        this._ivts_InventoryPriceCostVatAmt = value;
        this.Changed(nameof (ivts_InventoryPriceCostVatAmt));
        this.Changed("ivts_InventoryPriceCostAmt");
      }
    }

    public double ivts_InventoryPriceCostAmt => this.ivts_InventoryPriceCostSumAmt - this.ivts_InventoryPriceCostVatAmt;

    public double ivts_AdjustQty
    {
      get => this._ivts_AdjustQty;
      set
      {
        this._ivts_AdjustQty = value;
        this.Changed(nameof (ivts_AdjustQty));
      }
    }

    public double ivts_AdjustCostAmt
    {
      get => this._ivts_AdjustCostAmt;
      set
      {
        this._ivts_AdjustCostAmt = value;
        this.Changed(nameof (ivts_AdjustCostAmt));
        this.Changed("ivts_AdjustCostSumAmt");
      }
    }

    public double ivts_AdjustCostVatAmt
    {
      get => this._ivts_AdjustCostVatAmt;
      set
      {
        this._ivts_AdjustCostVatAmt = value;
        this.Changed(nameof (ivts_AdjustCostVatAmt));
        this.Changed("ivts_AdjustCostSumAmt");
      }
    }

    public double ivts_AdjustCostSumAmt => this.ivts_AdjustCostAmt + this.ivts_AdjustCostVatAmt;

    public double ivts_AdjustPriceAmt
    {
      get => this._ivts_AdjustPriceAmt;
      set
      {
        this._ivts_AdjustPriceAmt = value;
        this.Changed(nameof (ivts_AdjustPriceAmt));
        this.Changed("ivts_AdjustPriceTaxFreeAmt");
      }
    }

    public double ivts_AdjustPriceVatAmt
    {
      get => this._ivts_AdjustPriceVatAmt;
      set
      {
        this._ivts_AdjustPriceVatAmt = value;
        this.Changed(nameof (ivts_AdjustPriceVatAmt));
        this.Changed("ivts_AdjustPriceTaxFreeAmt");
      }
    }

    public double ivts_AdjustPriceTaxFreeAmt => this.ivts_AdjustPriceAmt - this.ivts_AdjustPriceVatAmt;

    public double ivts_AdjustPriceCostSumAmt
    {
      get => this._ivts_AdjustPriceCostSumAmt;
      set
      {
        this._ivts_AdjustPriceCostSumAmt = value;
        this.Changed(nameof (ivts_AdjustPriceCostSumAmt));
        this.Changed("ivts_AdjustPriceCostAmt");
      }
    }

    public double ivts_AdjustPriceCostVatAmt
    {
      get => this._ivts_AdjustPriceCostVatAmt;
      set
      {
        this._ivts_AdjustPriceCostVatAmt = value;
        this.Changed(nameof (ivts_AdjustPriceCostVatAmt));
        this.Changed("ivts_AdjustPriceCostAmt");
      }
    }

    public double ivts_AdjustPriceCostAmt => this.ivts_AdjustPriceCostSumAmt - this.ivts_AdjustPriceCostVatAmt;

    public double ivts_LossQty
    {
      get => this._ivts_LossQty;
      set
      {
        this._ivts_LossQty = value;
        this.Changed(nameof (ivts_LossQty));
      }
    }

    public double ivts_LossCostAmt
    {
      get => this._ivts_LossCostAmt;
      set
      {
        this._ivts_LossCostAmt = value;
        this.Changed(nameof (ivts_LossCostAmt));
        this.Changed("ivts_LossCostSumAmt");
        this.Changed("ivts_LossRule");
        this.Changed("ivts_PriceLossRule");
      }
    }

    public double ivts_LossCostVatAmt
    {
      get => this._ivts_LossCostVatAmt;
      set
      {
        this._ivts_LossCostVatAmt = value;
        this.Changed(nameof (ivts_LossCostVatAmt));
        this.Changed("ivts_LossCostSumAmt");
        this.Changed("ivts_LossRule");
        this.Changed("ivts_PriceLossRule");
      }
    }

    public double ivts_LossCostSumAmt => this.ivts_LossCostAmt + this.ivts_LossCostVatAmt;

    public double ivts_LossPriceAmt
    {
      get => this._ivts_LossPriceAmt;
      set
      {
        this._ivts_LossPriceAmt = value;
        this.Changed(nameof (ivts_LossPriceAmt));
        this.Changed("ivts_LossPriceTaxFreeAmt");
      }
    }

    public double ivts_LossPriceVatAmt
    {
      get => this._ivts_LossPriceVatAmt;
      set
      {
        this._ivts_LossPriceVatAmt = value;
        this.Changed(nameof (ivts_LossPriceVatAmt));
        this.Changed("ivts_LossPriceTaxFreeAmt");
      }
    }

    public double ivts_LossPriceTaxFreeAmt => this.ivts_LossPriceAmt - this.ivts_LossPriceVatAmt;

    public double ivts_LossRule => CalcHelper.ToLossRate(this.ivts_LossCostSumAmt, this.ivts_SaleAmt - this.ivts_SaleVatAmt);

    public double ivts_PriceLossRule => CalcHelper.ToLossRate(this.ivts_LossPriceAmt, this.ivts_SaleAmt);

    public double ivts_LossPriceCostSumAmt
    {
      get => this._ivts_LossPriceCostSumAmt;
      set
      {
        this._ivts_LossPriceCostSumAmt = value;
        this.Changed(nameof (ivts_LossPriceCostSumAmt));
        this.Changed("ivts_LossPriceCostAmt");
      }
    }

    public double ivts_LossPriceCostVatAmt
    {
      get => this._ivts_LossPriceCostVatAmt;
      set
      {
        this._ivts_LossPriceCostVatAmt = value;
        this.Changed(nameof (ivts_LossPriceCostVatAmt));
        this.Changed("ivts_LossPriceCostAmt");
      }
    }

    public double ivts_LossPriceCostAmt => this.ivts_LossPriceCostSumAmt - this.ivts_LossPriceCostVatAmt;

    public int ivts_IsInventory
    {
      get => this._ivts_IsInventory;
      set
      {
        this._ivts_IsInventory = value;
        this.Changed(nameof (ivts_IsInventory));
      }
    }

    public TInventorySummary() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ivts_YyyyMm", new TTableColumn()
      {
        tc_orgin_name = "ivts_YyyyMm",
        tc_trans_name = "마감년월"
      });
      columnInfo.Add("ivts_Day", new TTableColumn()
      {
        tc_orgin_name = "ivts_Day",
        tc_trans_name = "일자"
      });
      columnInfo.Add("ivts_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "ivts_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("ivts_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "ivts_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("ivts_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ivts_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ivts_Supplier", new TTableColumn()
      {
        tc_orgin_name = "ivts_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("ivts_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "ivts_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("ivts_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "ivts_CategoryCode",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("ivts_TaxDiv", new TTableColumn()
      {
        tc_orgin_name = "ivts_TaxDiv",
        tc_trans_name = "과면세",
        tc_comm_code = 51
      });
      columnInfo.Add("ivts_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "ivts_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("ivts_SalesUnit", new TTableColumn()
      {
        tc_orgin_name = "ivts_SalesUnit",
        tc_trans_name = "판매단위",
        tc_comm_code = 52
      });
      columnInfo.Add("ivts_BaseQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_BaseQty",
        tc_trans_name = "기초수량"
      });
      columnInfo.Add("ivts_BaseAvgCost", new TTableColumn()
      {
        tc_orgin_name = "ivts_BaseAvgCost",
        tc_trans_name = "기초평균원가"
      });
      columnInfo.Add("ivts_BaseCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BaseCostAmt",
        tc_trans_name = "기초원가금액"
      });
      columnInfo.Add("ivts_BaseCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BaseCostVatAmt",
        tc_trans_name = "기초부가세"
      });
      columnInfo.Add("ivts_BasePriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BasePriceAmt",
        tc_trans_name = "기초매가금액"
      });
      columnInfo.Add("ivts_BasePriceCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BasePriceCostAmt",
        tc_trans_name = "기초매가원가"
      });
      columnInfo.Add("ivts_BasePriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BasePriceCostVatAmt",
        tc_trans_name = "기초매가VAT"
      });
      columnInfo.Add("ivts_BasePrice", new TTableColumn()
      {
        tc_orgin_name = "ivts_BasePrice",
        tc_trans_name = "기초매단가"
      });
      columnInfo.Add("ivts_BasePriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BasePriceVatAmt",
        tc_trans_name = "기초매가부가세"
      });
      columnInfo.Add("ivts_EndQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndQty",
        tc_trans_name = "기말수량"
      });
      columnInfo.Add("ivts_EndAvgCost", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndAvgCost",
        tc_trans_name = "기말평균원가"
      });
      columnInfo.Add("ivts_EndCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndCostAmt",
        tc_trans_name = "기말원가금액"
      });
      columnInfo.Add("ivts_EndCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndCostVatAmt",
        tc_trans_name = "기말부가세"
      });
      columnInfo.Add("ivts_EndPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndPriceAmt",
        tc_trans_name = "기말매가금액"
      });
      columnInfo.Add("ivts_EndPriceCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndPriceCostAmt",
        tc_trans_name = "기말매가원가"
      });
      columnInfo.Add("ivts_EndPriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndPriceCostVatAmt",
        tc_trans_name = "기말매가VAT"
      });
      columnInfo.Add("ivts_EndPrice", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndPrice",
        tc_trans_name = "기말매단가"
      });
      columnInfo.Add("ivts_EndPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_EndPriceVatAmt",
        tc_trans_name = "기말매가부가세"
      });
      columnInfo.Add("ivts_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_SaleQty",
        tc_trans_name = "매출수량"
      });
      columnInfo.Add("ivts_TotalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_TotalSaleAmt",
        tc_trans_name = "총매출액(보증금미포함)"
      });
      columnInfo.Add("ivts_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_SaleAmt",
        tc_trans_name = "순매출액 (총매출액-할인금액)"
      });
      columnInfo.Add("ivts_SaleVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_SaleVatAmt",
        tc_trans_name = "매출부가세"
      });
      columnInfo.Add("ivts_SaleProfit", new TTableColumn()
      {
        tc_orgin_name = "ivts_SaleProfit",
        tc_trans_name = "세제외이익",
        tc_col_hint = "[세제외이익 = 세제외매출 - 매출원가]"
      });
      columnInfo.Add("ivts_SalePriceProfit", new TTableColumn()
      {
        tc_orgin_name = "ivts_SalePriceProfit",
        tc_trans_name = "세제외이익(매가관리)",
        tc_col_hint = "[세제외이익(매가관리) = 세제외매출 - 매출원가]"
      });
      columnInfo.Add("ivts_EnurySlip", new TTableColumn()
      {
        tc_orgin_name = "ivts_EnurySlip",
        tc_trans_name = "에누리"
      });
      columnInfo.Add("ivts_EnuryEnd", new TTableColumn()
      {
        tc_orgin_name = "ivts_EnuryEnd",
        tc_trans_name = "끝전에누리"
      });
      columnInfo.Add("ivts_DcAmtManual", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtManual",
        tc_trans_name = "단품할인금액"
      });
      columnInfo.Add("ivts_DcAmtEvent", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtEvent",
        tc_trans_name = "이벤트할인금액"
      });
      columnInfo.Add("ivts_DcAmtGoods", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtGoods",
        tc_trans_name = "단품행사할인금액"
      });
      columnInfo.Add("ivts_DcAmtCoupon", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtCoupon",
        tc_trans_name = "쿠폰할인금액"
      });
      columnInfo.Add("ivts_DcAmtPromotion", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtPromotion",
        tc_trans_name = "프로모션할인금액"
      });
      columnInfo.Add("ivts_DcAmtMember", new TTableColumn()
      {
        tc_orgin_name = "ivts_DcAmtMember",
        tc_trans_name = "회원할인금액"
      });
      columnInfo.Add("ivts_Customer", new TTableColumn()
      {
        tc_orgin_name = "ivts_Customer",
        tc_trans_name = "고객수"
      });
      columnInfo.Add("ivts_CustomerGoods", new TTableColumn()
      {
        tc_orgin_name = "ivts_CustomerGoods",
        tc_trans_name = "상품객수"
      });
      columnInfo.Add("ivts_CustomerCategory", new TTableColumn()
      {
        tc_orgin_name = "ivts_CustomerCategory",
        tc_trans_name = "소분류객수"
      });
      columnInfo.Add("ivts_CustomerSupplier", new TTableColumn()
      {
        tc_orgin_name = "ivts_CustomerSupplier",
        tc_trans_name = "업체객수"
      });
      columnInfo.Add("ivts_BuyQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_BuyQty",
        tc_trans_name = "매입수량"
      });
      columnInfo.Add("ivts_BuyCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BuyCostAmt",
        tc_trans_name = "매입원가계"
      });
      columnInfo.Add("ivts_BuyCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BuyCostVatAmt",
        tc_trans_name = "매입부가세계"
      });
      columnInfo.Add("ivts_BuyPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BuyPriceAmt",
        tc_trans_name = "매입매가계"
      });
      columnInfo.Add("ivts_BuyPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_BuyPriceVatAmt",
        tc_trans_name = "매입매가부가세"
      });
      columnInfo.Add("ivts_ReturnQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_ReturnQty",
        tc_trans_name = "반품수량"
      });
      columnInfo.Add("ivts_ReturnCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_ReturnCostAmt",
        tc_trans_name = "반품원가계"
      });
      columnInfo.Add("ivts_ReturnCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_ReturnCostVatAmt",
        tc_trans_name = "반품부가세계"
      });
      columnInfo.Add("ivts_ReturnPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_ReturnPriceAmt",
        tc_trans_name = "반품매가계"
      });
      columnInfo.Add("ivts_ReturnPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_ReturnPriceVatAmt",
        tc_trans_name = "반품매가부가세"
      });
      columnInfo.Add("ivts_InnerMoveOutQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveOutQty",
        tc_trans_name = "대출수량"
      });
      columnInfo.Add("ivts_InnerMoveOutCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveOutCostAmt",
        tc_trans_name = "대출원가계"
      });
      columnInfo.Add("ivts_InnerMoveOutCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveOutCostVatAmt",
        tc_trans_name = "대출부가세계"
      });
      columnInfo.Add("ivts_InnerMoveOutPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveOutPriceAmt",
        tc_trans_name = "대출매가계"
      });
      columnInfo.Add("ivts_InnerMoveOutPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveOutPriceVatAmt",
        tc_trans_name = "대출매가부가세"
      });
      columnInfo.Add("ivts_InnerMoveInQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveInQty",
        tc_trans_name = "대입수량"
      });
      columnInfo.Add("ivts_InnerMoveInCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveInCostAmt",
        tc_trans_name = "대입원가계"
      });
      columnInfo.Add("ivts_InnerMoveInCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveInCostVatAmt",
        tc_trans_name = "대입부가세계"
      });
      columnInfo.Add("ivts_InnerMoveInPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveInPriceAmt",
        tc_trans_name = "대입매가계"
      });
      columnInfo.Add("ivts_InnerMoveInPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_InnerMoveInPriceVatAmt",
        tc_trans_name = "대입매가부가세"
      });
      columnInfo.Add("ivts_OuterMoveOutQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveOutQty",
        tc_trans_name = "점출수량"
      });
      columnInfo.Add("ivts_OuterMoveOutCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveOutCostAmt",
        tc_trans_name = "점출원가계"
      });
      columnInfo.Add("ivts_OuterMoveOutCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveOutCostVatAmt",
        tc_trans_name = "점출부가세계"
      });
      columnInfo.Add("ivts_OuterMoveOutPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveOutPriceAmt",
        tc_trans_name = "점출매가계"
      });
      columnInfo.Add("ivts_OuterMoveOutPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveOutPriceVatAmt",
        tc_trans_name = "점출매가부가세"
      });
      columnInfo.Add("ivts_OuterMoveInQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveInQty",
        tc_trans_name = "점입수량"
      });
      columnInfo.Add("ivts_OuterMoveInCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveInCostAmt",
        tc_trans_name = "점입원가계"
      });
      columnInfo.Add("ivts_OuterMoveInCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveInCostVatAmt",
        tc_trans_name = "점입부가세계"
      });
      columnInfo.Add("ivts_OuterMoveInPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveInPriceAmt",
        tc_trans_name = "점입매가계"
      });
      columnInfo.Add("ivts_OuterMoveInPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_OuterMoveInPriceVatAmt",
        tc_trans_name = "점입매가부가세"
      });
      columnInfo.Add("ivts_PreAdjustQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustQty",
        tc_trans_name = "전 조정수량"
      });
      columnInfo.Add("ivts_PreAdjustCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustCostAmt",
        tc_trans_name = "전 조정원가계"
      });
      columnInfo.Add("ivts_PreAdjustCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustCostVatAmt",
        tc_trans_name = "전 조정부가세계"
      });
      columnInfo.Add("ivts_PreAdjustPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustPriceAmt",
        tc_trans_name = "전 조정매가계"
      });
      columnInfo.Add("ivts_PreAdjustPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustPriceVatAmt",
        tc_trans_name = "전 조정매가부가세"
      });
      columnInfo.Add("ivts_PreAdjustPriceCostSumAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustPriceCostSumAmt",
        tc_trans_name = "전 조정매가합계"
      });
      columnInfo.Add("ivts_PreAdjustPriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_PreAdjustPriceCostVatAmt",
        tc_trans_name = "전 조정매가부가세계"
      });
      columnInfo.Add("ivts_DisuseQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisuseQty",
        tc_trans_name = "폐기수량"
      });
      columnInfo.Add("ivts_DisuseCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisuseCostAmt",
        tc_trans_name = "폐기원가계"
      });
      columnInfo.Add("ivts_DisuseCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisuseCostVatAmt",
        tc_trans_name = "폐기부가세계"
      });
      columnInfo.Add("ivts_DisusePriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisusePriceAmt",
        tc_trans_name = "폐기매가계"
      });
      columnInfo.Add("ivts_DisusePriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisusePriceVatAmt",
        tc_trans_name = "폐기매가부가세"
      });
      columnInfo.Add("ivts_DisusePriceCostSumAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisusePriceCostSumAmt",
        tc_trans_name = "폐기매가합계"
      });
      columnInfo.Add("ivts_DisusePriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_DisusePriceCostVatAmt",
        tc_trans_name = "폐기원가VAT"
      });
      columnInfo.Add("ivts_PriceUp", new TTableColumn()
      {
        tc_orgin_name = "ivts_PriceUp",
        tc_trans_name = "매가인상금액"
      });
      columnInfo.Add("ivts_PriceUpVat", new TTableColumn()
      {
        tc_orgin_name = "ivts_PriceUpVat",
        tc_trans_name = "매가인상VAT금액"
      });
      columnInfo.Add("ivts_PriceDown", new TTableColumn()
      {
        tc_orgin_name = "ivts_PriceDown",
        tc_trans_name = "매가인하금액"
      });
      columnInfo.Add("ivts_PriceDownVat", new TTableColumn()
      {
        tc_orgin_name = "ivts_PriceDownVat",
        tc_trans_name = "매가인하VAT금액"
      });
      columnInfo.Add("ivts_AdjustQty", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustQty",
        tc_trans_name = "재고조정 수량"
      });
      columnInfo.Add("ivts_AdjustCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustCostAmt",
        tc_trans_name = "재고조정 원가계"
      });
      columnInfo.Add("ivts_AdjustCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustCostVatAmt",
        tc_trans_name = "재고조정 부가세계"
      });
      columnInfo.Add("ivts_AdjustPriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustPriceAmt",
        tc_trans_name = "재고조정 매가계"
      });
      columnInfo.Add("ivts_AdjustPriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustPriceVatAmt",
        tc_trans_name = "재고조정 매가부가세"
      });
      columnInfo.Add("ivts_AdjustPriceCostSumAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustPriceCostSumAmt",
        tc_trans_name = "재고조정 매가합계"
      });
      columnInfo.Add("ivts_AdjustPriceCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ivts_AdjustPriceCostVatAmt",
        tc_trans_name = "재고조정 매가합계VAT"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.InventorySummary;
      this.ivts_YyyyMm = this.ivts_StoreCode = 0;
      this.ivts_GoodsCode = 0L;
      this.ivts_SiteID = 0L;
      this.ivts_Supplier = this.ivts_SupplierType = this.ivts_CategoryCode = 0;
      this.ivts_TaxDiv = 1;
      this.ivts_StockUnit = 2;
      this.ivts_SalesUnit = 1;
      this.ivts_BaseQty = this.ivts_BaseAvgCost = this.ivts_BaseCostAmt = this.ivts_BaseCostVatAmt = this.ivts_BasePriceAmt = this.ivts_BasePriceCostAmt = this.ivts_BasePriceCostVatAmt = 0.0;
      this.ivts_BasePrice = this.ivts_BasePriceVatAmt = 0.0;
      this.ivts_EndQty = this.ivts_EndAvgCost = this.ivts_EndCostAmt = this.ivts_EndCostVatAmt = this.ivts_EndPriceAmt = this.ivts_EndPriceCostAmt = this.ivts_EndPriceCostVatAmt = 0.0;
      this.ivts_EndPrice = this.ivts_EndPriceVatAmt = 0.0;
      this.ivts_SaleQty = this.ivts_TotalSaleAmt = this.ivts_SaleAmt = this.ivts_SaleVatAmt = this.ivts_SaleProfit = this.ivts_SalePriceProfit = 0.0;
      this.ivts_EnurySlip = this.ivts_EnuryEnd = this.ivts_DcAmtManual = this.ivts_DcAmtEvent = this.ivts_DcAmtGoods = this.ivts_DcAmtCoupon = this.ivts_DcAmtPromotion = this.ivts_DcAmtMember = 0.0;
      this.ivts_Customer = this.ivts_CustomerGoods = this.ivts_CustomerCategory = this.ivts_CustomerSupplier = 0.0;
      this.ivts_BuyQty = this.ivts_BuyCostAmt = this.ivts_BuyCostVatAmt = this.ivts_BuyPriceAmt = this.ivts_BuyPriceVatAmt = 0.0;
      this.ivts_ReturnQty = this.ivts_ReturnCostAmt = this.ivts_ReturnCostVatAmt = this.ivts_ReturnPriceAmt = this.ivts_ReturnPriceVatAmt = 0.0;
      this.ivts_InnerMoveOutQty = this.ivts_InnerMoveOutCostAmt = this.ivts_InnerMoveOutCostVatAmt = this.ivts_InnerMoveOutPriceAmt = this.ivts_InnerMoveOutPriceVatAmt = 0.0;
      this.ivts_InnerMoveInQty = this.ivts_InnerMoveInCostAmt = this.ivts_InnerMoveInCostVatAmt = this.ivts_InnerMoveInPriceAmt = this.ivts_InnerMoveInPriceVatAmt = 0.0;
      this.ivts_OuterMoveOutQty = this.ivts_OuterMoveOutCostAmt = this.ivts_OuterMoveOutCostVatAmt = this.ivts_OuterMoveOutPriceAmt = this.ivts_OuterMoveOutPriceVatAmt = 0.0;
      this.ivts_OuterMoveInQty = this.ivts_OuterMoveInCostAmt = this.ivts_OuterMoveInCostVatAmt = this.ivts_OuterMoveInPriceAmt = this.ivts_OuterMoveInPriceVatAmt = 0.0;
      this.ivts_PreAdjustQty = this.ivts_PreAdjustCostAmt = this.ivts_PreAdjustCostVatAmt = this.ivts_PreAdjustPriceAmt = this.ivts_PreAdjustPriceVatAmt = 0.0;
      this.ivts_AdjustPriceCostSumAmt = this.ivts_AdjustPriceCostVatAmt = 0.0;
      this.ivts_DisuseQty = this.ivts_DisuseCostAmt = this.ivts_DisuseCostVatAmt = this.ivts_DisusePriceAmt = this.ivts_DisusePriceVatAmt = 0.0;
      this.ivts_DisusePriceCostSumAmt = this.ivts_DisusePriceCostVatAmt = 0.0;
      this.ivts_PriceUp = this.ivts_PriceUpVat = this.ivts_PriceDown = this.ivts_PriceDownVat = 0.0;
      this.ivts_InventoryQty = this.ivts_InventoryCostAmt = this.ivts_InventoryCostVatAmt = this.ivts_InventoryPriceAmt = this.ivts_InventoryPriceVatAmt = 0.0;
      this.ivts_AdjustQty = this.ivts_AdjustCostAmt = this.ivts_AdjustCostVatAmt = this.ivts_AdjustPriceAmt = this.ivts_AdjustPriceVatAmt = 0.0;
      this.ivts_LossQty = this.ivts_LossCostAmt = this.ivts_LossCostVatAmt = this.ivts_LossPriceAmt = this.ivts_LossPriceVatAmt = 0.0;
      this.ivts_IsInventory = 0;
    }

    public void CalcTaxVat()
    {
      if (this.ivts_IsTax)
      {
        this.ivts_BasePriceCostVatAmt = this.ivts_BasePriceCostAmt.ToCostVat();
        this.ivts_EndPriceVatAmt = this.ivts_EndPriceAmt.ToPriceVat();
        this.ivts_EndPriceCostVatAmt = this.ivts_EndPriceCostAmt.ToCostVat();
        this.ivts_BuyCostVatAmt = this.ivts_BuyCostAmt.ToCostVat();
        this.ivts_BuyPriceVatAmt = this.ivts_BuyPriceAmt.ToPriceVat();
        this.ivts_ReturnCostVatAmt = this.ivts_ReturnCostAmt.ToCostVat();
        this.ivts_ReturnPriceVatAmt = this.ivts_ReturnPriceAmt.ToPriceVat();
        this.ivts_InnerMoveOutCostVatAmt = this.ivts_InnerMoveOutCostAmt.ToCostVat();
        this.ivts_InnerMoveOutPriceVatAmt = this.ivts_InnerMoveOutPriceAmt.ToPriceVat();
        this.ivts_InnerMoveInCostVatAmt = this.ivts_InnerMoveInCostAmt.ToCostVat();
        this.ivts_InnerMoveInPriceVatAmt = this.ivts_InnerMoveInPriceAmt.ToPriceVat();
        this.ivts_OuterMoveOutCostVatAmt = this.ivts_OuterMoveOutCostAmt.ToCostVat();
        this.ivts_OuterMoveOutPriceVatAmt = this.ivts_OuterMoveOutPriceAmt.ToPriceVat();
        this.ivts_OuterMoveInCostVatAmt = this.ivts_OuterMoveInCostAmt.ToCostVat();
        this.ivts_OuterMoveInPriceVatAmt = this.ivts_OuterMoveInPriceAmt.ToPriceVat();
        this.ivts_PreAdjustCostVatAmt = this.ivts_PreAdjustCostAmt.ToCostVat();
        this.ivts_PreAdjustPriceVatAmt = this.ivts_PreAdjustPriceAmt.ToPriceVat();
        this.ivts_PreAdjustPriceCostVatAmt = this.ivts_PreAdjustPriceCostSumAmt.ToPriceVat();
        this.ivts_DisuseCostVatAmt = this.ivts_DisuseCostAmt.ToCostVat();
        this.ivts_DisusePriceVatAmt = this.ivts_DisusePriceAmt.ToPriceVat();
        this.ivts_DisusePriceCostVatAmt = this.ivts_DisusePriceCostSumAmt.ToPriceVat();
        this.ivts_PriceUpVat = this.ivts_PriceUp.ToPriceVat();
        this.ivts_PriceDownVat = this.ivts_PriceDown.ToPriceVat();
        this.ivts_InventoryCostVatAmt = this.ivts_InventoryCostAmt.ToCostVat();
        this.ivts_InventoryPriceVatAmt = this.ivts_InventoryPriceAmt.ToPriceVat();
        this.ivts_InventoryPriceCostVatAmt = this.ivts_InventoryPriceCostAmt.ToPriceVat();
        this.ivts_AdjustCostVatAmt = this.ivts_AdjustCostAmt.ToCostVat();
        this.ivts_AdjustPriceVatAmt = this.ivts_AdjustPriceAmt.ToPriceVat();
        this.ivts_AdjustPriceCostVatAmt = this.ivts_AdjustPriceCostSumAmt.ToPriceVat();
        this.ivts_LossCostVatAmt = this.ivts_LossCostAmt.ToCostVat();
        this.ivts_LossPriceVatAmt = this.ivts_LossPriceAmt.ToPriceVat();
        this.ivts_LossPriceCostVatAmt = this.ivts_LossPriceCostAmt.ToPriceVat();
      }
      else
      {
        this.ivts_BasePriceCostVatAmt = 0.0;
        this.ivts_EndPriceVatAmt = 0.0;
        this.ivts_EndPriceCostVatAmt = 0.0;
        this.ivts_BuyCostVatAmt = 0.0;
        this.ivts_BuyPriceVatAmt = 0.0;
        this.ivts_ReturnCostVatAmt = 0.0;
        this.ivts_ReturnPriceVatAmt = 0.0;
        this.ivts_InnerMoveOutCostVatAmt = 0.0;
        this.ivts_InnerMoveOutPriceVatAmt = 0.0;
        this.ivts_InnerMoveInCostVatAmt = 0.0;
        this.ivts_InnerMoveInPriceVatAmt = 0.0;
        this.ivts_OuterMoveOutCostVatAmt = 0.0;
        this.ivts_OuterMoveOutPriceVatAmt = 0.0;
        this.ivts_OuterMoveInCostVatAmt = 0.0;
        this.ivts_OuterMoveInPriceVatAmt = 0.0;
        this.ivts_PreAdjustCostVatAmt = 0.0;
        this.ivts_PreAdjustPriceVatAmt = 0.0;
        this.ivts_PreAdjustPriceCostVatAmt = 0.0;
        this.ivts_DisuseCostVatAmt = 0.0;
        this.ivts_DisusePriceVatAmt = 0.0;
        this.ivts_DisusePriceCostVatAmt = 0.0;
        this.ivts_PriceUpVat = 0.0;
        this.ivts_PriceDownVat = 0.0;
        this.ivts_InventoryCostVatAmt = 0.0;
        this.ivts_InventoryPriceVatAmt = 0.0;
        this.ivts_InventoryPriceCostVatAmt = 0.0;
        this.ivts_AdjustCostVatAmt = 0.0;
        this.ivts_AdjustPriceVatAmt = 0.0;
        this.ivts_AdjustPriceCostVatAmt = 0.0;
        this.ivts_LossCostVatAmt = 0.0;
        this.ivts_LossPriceVatAmt = 0.0;
        this.ivts_LossPriceCostVatAmt = 0.0;
      }
    }

    public double CalcBuyTaxFreeAmount() => this.ivts_BaseCostAmt + this.ivts_BuyCostAmt - this.ivts_ReturnCostAmt + this.ivts_OuterMoveInCostAmt - this.ivts_OuterMoveOutCostAmt + this.ivts_InnerMoveInCostAmt - this.ivts_InnerMoveOutCostAmt - this.ivts_EndCostAmt;

    public double CalcBuySumAmount() => this.ivts_BaseCostSumAmt + this.ivts_BuyCostSumAmt - this.ivts_ReturnCostSumAmt + this.ivts_OuterMoveInCostSumAmt - this.ivts_OuterMoveOutCostSumAmt + this.ivts_InnerMoveInCostSumAmt - this.ivts_InnerMoveOutCostSumAmt - this.ivts_EndCostSumAmt;

    public double CalcBuyPriceTaxFreeAmount() => this.ivts_BasePriceCostAmt + this.ivts_BuyCostAmt - this.ivts_ReturnCostAmt + this.ivts_OuterMoveInCostAmt - this.ivts_OuterMoveOutCostAmt + this.ivts_InnerMoveInCostAmt - this.ivts_InnerMoveOutCostAmt - this.ivts_EndPriceCostAmt;

    public double CalcBuyPriceSumAmount() => this.ivts_BasePriceCostSumAmt + this.ivts_BuyCostSumAmt - this.ivts_ReturnCostSumAmt + this.ivts_OuterMoveInCostSumAmt - this.ivts_OuterMoveOutCostSumAmt + this.ivts_InnerMoveInCostSumAmt - this.ivts_InnerMoveOutCostSumAmt - this.ivts_EndPriceCostSumAmt;

    public double CalcStockQty() => this.ivts_BaseQty + this.ivts_BuyQty - this.ivts_ReturnQty - this.ivts_SaleQty + this.ivts_InnerMoveInQty - this.ivts_InnerMoveOutQty + this.ivts_OuterMoveInQty - this.ivts_OuterMoveOutQty + this.ivts_PreAdjustQty + this.ivts_AdjustQty - this.ivts_DisuseQty;

    public void CalcEndQty() => this.ivts_EndQty = this.CalcStockQty();

    public double CalcAmount() => this.CalcStockQty() * this.ivts_EndAvgCost;

    public double CalcSumAmount() => this.CalcAmount() + (this.ivts_IsTax ? this.CalcAmount().ToCostVat() : 0.0);

    public double CalcTurnOver() => CalcHelper.ToTurnOverRate(this.ivts_SaleTaxFreeAmt, this.ivts_BaseCostAmt, this.ivts_EndCostAmt);

    public double CalcTurnOverPrice() => CalcHelper.ToTurnOverRate(this.ivts_SaleTaxFreeAmt, this.ivts_BasePriceCostAmt, this.ivts_EndPriceCostAmt);

    public double CalcCrossRate() => CalcHelper.ToCrossRate(this.ivts_ProfitRule, this.CalcTurnOver());

    public double CalcCrossRatePrice() => CalcHelper.ToCrossRate(this.ivts_PriceProfitRule, this.CalcTurnOverPrice());

    public double CalcLogisticsAmount() => this.ivts_SaleTaxFreeAmt + this.ivts_OuterMoveOutCostAmt;

    public double CalcLogisticsProfitRule() => CalcHelper.ToSaleProfitMargin(this.ivts_SaleProfit, this.CalcLogisticsAmount());

    public double CalcLogisticsTurnOver() => CalcHelper.ToTurnOverRate(this.CalcLogisticsAmount(), this.ivts_BaseCostAmt, this.ivts_EndCostAmt);

    protected override UbModelBase CreateClone => (UbModelBase) new TInventorySummary();

    public override object Clone()
    {
      TInventorySummary tinventorySummary = base.Clone() as TInventorySummary;
      tinventorySummary.ivts_YyyyMm = this.ivts_YyyyMm;
      tinventorySummary.ivts_Day = this.ivts_Day;
      tinventorySummary.ivts_StoreCode = this.ivts_StoreCode;
      tinventorySummary.ivts_GoodsCode = this.ivts_GoodsCode;
      tinventorySummary.ivts_SiteID = this.ivts_SiteID;
      tinventorySummary.ivts_Supplier = this.ivts_Supplier;
      tinventorySummary.ivts_SupplierType = this.ivts_SupplierType;
      tinventorySummary.ivts_CategoryCode = this.ivts_CategoryCode;
      tinventorySummary.ivts_TaxDiv = this.ivts_TaxDiv;
      tinventorySummary.ivts_StockUnit = this.ivts_StockUnit;
      tinventorySummary.ivts_SalesUnit = this.ivts_SalesUnit;
      tinventorySummary.ivts_BaseQty = this.ivts_BaseQty;
      tinventorySummary.ivts_BaseAvgCost = this.ivts_BaseAvgCost;
      tinventorySummary.ivts_BaseCostAmt = this.ivts_BaseCostAmt;
      tinventorySummary.ivts_BaseCostVatAmt = this.ivts_BaseCostVatAmt;
      tinventorySummary.ivts_BasePrice = this.ivts_BasePrice;
      tinventorySummary.ivts_BasePriceCostAmt = this.ivts_BasePriceCostAmt;
      tinventorySummary.ivts_BasePriceCostVatAmt = this.ivts_BasePriceCostVatAmt;
      tinventorySummary.ivts_BasePriceAmt = this.ivts_BasePriceAmt;
      tinventorySummary.ivts_BasePriceVatAmt = this.ivts_BasePriceVatAmt;
      tinventorySummary.ivts_EndQty = this.ivts_EndQty;
      tinventorySummary.ivts_EndAvgCost = this.ivts_EndAvgCost;
      tinventorySummary.ivts_EndCostAmt = this.ivts_EndCostAmt;
      tinventorySummary.ivts_EndCostVatAmt = this.ivts_EndCostVatAmt;
      tinventorySummary.ivts_EndPrice = this.ivts_EndPrice;
      tinventorySummary.ivts_EndPriceCostAmt = this.ivts_EndPriceCostAmt;
      tinventorySummary.ivts_EndPriceCostVatAmt = this.ivts_EndPriceCostVatAmt;
      tinventorySummary.ivts_EndPriceAmt = this.ivts_EndPriceAmt;
      tinventorySummary.ivts_EndPriceVatAmt = this.ivts_EndPriceVatAmt;
      tinventorySummary.ivts_SaleQty = this.ivts_SaleQty;
      tinventorySummary.ivts_TotalSaleAmt = this.ivts_TotalSaleAmt;
      tinventorySummary.ivts_SaleAmt = this.ivts_SaleAmt;
      tinventorySummary.ivts_SaleVatAmt = this.ivts_SaleVatAmt;
      tinventorySummary.ivts_SaleProfit = this.ivts_SaleProfit;
      tinventorySummary.ivts_SalePriceProfit = this.ivts_SalePriceProfit;
      tinventorySummary.ivts_EnurySlip = this.ivts_EnurySlip;
      tinventorySummary.ivts_EnuryEnd = this.ivts_EnuryEnd;
      tinventorySummary.ivts_DcAmtManual = this.ivts_DcAmtManual;
      tinventorySummary.ivts_DcAmtEvent = this.ivts_DcAmtEvent;
      tinventorySummary.ivts_DcAmtGoods = this.ivts_DcAmtGoods;
      tinventorySummary.ivts_DcAmtCoupon = this.ivts_DcAmtCoupon;
      tinventorySummary.ivts_DcAmtPromotion = this.ivts_DcAmtPromotion;
      tinventorySummary.ivts_DcAmtMember = this.ivts_DcAmtMember;
      tinventorySummary.ivts_Customer = this.ivts_Customer;
      tinventorySummary.ivts_CustomerGoods = this.ivts_CustomerGoods;
      tinventorySummary.ivts_CustomerCategory = this.ivts_CustomerCategory;
      tinventorySummary.ivts_CustomerSupplier = this.ivts_CustomerSupplier;
      tinventorySummary.ivts_BuyQty = this.ivts_BuyQty;
      tinventorySummary.ivts_BuyCostAmt = this.ivts_BuyCostAmt;
      tinventorySummary.ivts_BuyCostVatAmt = this.ivts_BuyCostVatAmt;
      tinventorySummary.ivts_BuyPriceAmt = this.ivts_BuyPriceAmt;
      tinventorySummary.ivts_BuyPriceVatAmt = this.ivts_BuyPriceVatAmt;
      tinventorySummary.ivts_ReturnQty = this.ivts_ReturnQty;
      tinventorySummary.ivts_ReturnCostAmt = this.ivts_ReturnCostAmt;
      tinventorySummary.ivts_ReturnCostVatAmt = this.ivts_ReturnCostVatAmt;
      tinventorySummary.ivts_ReturnPriceAmt = this.ivts_ReturnPriceAmt;
      tinventorySummary.ivts_ReturnPriceVatAmt = this.ivts_ReturnPriceVatAmt;
      tinventorySummary.ivts_InnerMoveOutQty = this.ivts_InnerMoveOutQty;
      tinventorySummary.ivts_InnerMoveOutCostAmt = this.ivts_InnerMoveOutCostAmt;
      tinventorySummary.ivts_InnerMoveOutCostVatAmt = this.ivts_InnerMoveOutCostVatAmt;
      tinventorySummary.ivts_InnerMoveOutPriceAmt = this.ivts_InnerMoveOutPriceAmt;
      tinventorySummary.ivts_InnerMoveOutPriceVatAmt = this.ivts_InnerMoveOutPriceVatAmt;
      tinventorySummary.ivts_InnerMoveInQty = this.ivts_InnerMoveInQty;
      tinventorySummary.ivts_InnerMoveInCostAmt = this.ivts_InnerMoveInCostAmt;
      tinventorySummary.ivts_InnerMoveInCostVatAmt = this.ivts_InnerMoveInCostVatAmt;
      tinventorySummary.ivts_InnerMoveInPriceAmt = this.ivts_InnerMoveInPriceAmt;
      tinventorySummary.ivts_InnerMoveInPriceVatAmt = this.ivts_InnerMoveInPriceVatAmt;
      tinventorySummary.ivts_OuterMoveOutQty = this.ivts_OuterMoveOutQty;
      tinventorySummary.ivts_OuterMoveOutCostAmt = this.ivts_OuterMoveOutCostAmt;
      tinventorySummary.ivts_OuterMoveOutCostVatAmt = this.ivts_OuterMoveOutCostVatAmt;
      tinventorySummary.ivts_OuterMoveOutPriceAmt = this.ivts_OuterMoveOutPriceAmt;
      tinventorySummary.ivts_OuterMoveOutPriceVatAmt = this.ivts_OuterMoveOutPriceVatAmt;
      tinventorySummary.ivts_OuterMoveInQty = this.ivts_OuterMoveInQty;
      tinventorySummary.ivts_OuterMoveInCostAmt = this.ivts_OuterMoveInCostAmt;
      tinventorySummary.ivts_OuterMoveInCostVatAmt = this.ivts_OuterMoveInCostVatAmt;
      tinventorySummary.ivts_OuterMoveInPriceAmt = this.ivts_OuterMoveInPriceAmt;
      tinventorySummary.ivts_OuterMoveInPriceVatAmt = this.ivts_OuterMoveInPriceVatAmt;
      tinventorySummary.ivts_PreAdjustQty = this.ivts_PreAdjustQty;
      tinventorySummary.ivts_PreAdjustCostAmt = this.ivts_PreAdjustCostAmt;
      tinventorySummary.ivts_PreAdjustCostVatAmt = this.ivts_PreAdjustCostVatAmt;
      tinventorySummary.ivts_PreAdjustPriceAmt = this.ivts_PreAdjustPriceAmt;
      tinventorySummary.ivts_PreAdjustPriceVatAmt = this.ivts_PreAdjustPriceVatAmt;
      tinventorySummary.ivts_PreAdjustPriceCostSumAmt = this.ivts_PreAdjustPriceCostSumAmt;
      tinventorySummary.ivts_PreAdjustPriceCostVatAmt = this.ivts_PreAdjustPriceCostVatAmt;
      tinventorySummary.ivts_DisuseQty = this.ivts_DisuseQty;
      tinventorySummary.ivts_DisuseCostAmt = this.ivts_DisuseCostAmt;
      tinventorySummary.ivts_DisuseCostVatAmt = this.ivts_DisuseCostVatAmt;
      tinventorySummary.ivts_DisusePriceAmt = this.ivts_DisusePriceAmt;
      tinventorySummary.ivts_DisusePriceVatAmt = this.ivts_DisusePriceVatAmt;
      tinventorySummary.ivts_DisusePriceCostSumAmt = this.ivts_DisusePriceCostSumAmt;
      tinventorySummary.ivts_DisusePriceCostVatAmt = this.ivts_DisusePriceCostVatAmt;
      tinventorySummary.ivts_PriceUp = this.ivts_PriceUp;
      tinventorySummary.ivts_PriceUpVat = this.ivts_PriceUpVat;
      tinventorySummary.ivts_PriceDown = this.ivts_PriceDown;
      tinventorySummary.ivts_PriceDownVat = this.ivts_PriceDownVat;
      tinventorySummary.ivts_InventoryQty = this.ivts_InventoryQty;
      tinventorySummary.ivts_InventoryCostAmt = this.ivts_InventoryCostAmt;
      tinventorySummary.ivts_InventoryCostVatAmt = this.ivts_InventoryCostVatAmt;
      tinventorySummary.ivts_InventoryPriceAmt = this.ivts_InventoryPriceAmt;
      tinventorySummary.ivts_InventoryPriceVatAmt = this.ivts_InventoryPriceVatAmt;
      tinventorySummary.ivts_InventoryPriceCostSumAmt = this.ivts_InventoryPriceCostSumAmt;
      tinventorySummary.ivts_InventoryPriceCostVatAmt = this.ivts_InventoryPriceCostVatAmt;
      tinventorySummary.ivts_AdjustQty = this.ivts_AdjustQty;
      tinventorySummary.ivts_AdjustCostAmt = this.ivts_AdjustCostAmt;
      tinventorySummary.ivts_AdjustCostVatAmt = this.ivts_AdjustCostVatAmt;
      tinventorySummary.ivts_AdjustPriceAmt = this.ivts_AdjustPriceAmt;
      tinventorySummary.ivts_AdjustPriceVatAmt = this.ivts_AdjustPriceVatAmt;
      tinventorySummary.ivts_AdjustPriceCostSumAmt = this.ivts_AdjustPriceCostSumAmt;
      tinventorySummary.ivts_AdjustPriceCostVatAmt = this.ivts_AdjustPriceCostVatAmt;
      tinventorySummary.ivts_LossQty = this.ivts_LossQty;
      tinventorySummary.ivts_LossCostAmt = this.ivts_LossCostAmt;
      tinventorySummary.ivts_LossCostVatAmt = this.ivts_LossCostVatAmt;
      tinventorySummary.ivts_LossPriceAmt = this.ivts_LossPriceAmt;
      tinventorySummary.ivts_LossPriceVatAmt = this.ivts_LossPriceVatAmt;
      tinventorySummary.ivts_LossPriceCostSumAmt = this.ivts_LossPriceCostSumAmt;
      tinventorySummary.ivts_LossPriceCostVatAmt = this.ivts_LossPriceCostVatAmt;
      return (object) tinventorySummary;
    }

    public void PutData(TInventorySummary pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ivts_YyyyMm = pSource.ivts_YyyyMm;
      this.ivts_Day = pSource.ivts_Day;
      this.ivts_StoreCode = pSource.ivts_StoreCode;
      this.ivts_GoodsCode = pSource.ivts_GoodsCode;
      this.ivts_SiteID = pSource.ivts_SiteID;
      this.ivts_Supplier = pSource.ivts_Supplier;
      this.ivts_SupplierType = pSource.ivts_SupplierType;
      this.ivts_CategoryCode = pSource.ivts_CategoryCode;
      this.ivts_TaxDiv = pSource.ivts_TaxDiv;
      this.ivts_StockUnit = pSource.ivts_StockUnit;
      this.ivts_SalesUnit = pSource.ivts_SalesUnit;
      this.ivts_BaseQty = pSource.ivts_BaseQty;
      this.ivts_BaseAvgCost = pSource.ivts_BaseAvgCost;
      this.ivts_BaseCostAmt = pSource.ivts_BaseCostAmt;
      this.ivts_BaseCostVatAmt = pSource.ivts_BaseCostVatAmt;
      this.ivts_BasePrice = pSource.ivts_BasePrice;
      this.ivts_BasePriceCostAmt = pSource.ivts_BasePriceCostAmt;
      this.ivts_BasePriceCostVatAmt = pSource.ivts_BasePriceCostVatAmt;
      this.ivts_BasePriceAmt = pSource.ivts_BasePriceAmt;
      this.ivts_BasePriceVatAmt = pSource.ivts_BasePriceVatAmt;
      this.ivts_EndQty = pSource.ivts_EndQty;
      this.ivts_EndAvgCost = pSource.ivts_EndAvgCost;
      this.ivts_EndCostAmt = pSource.ivts_EndCostAmt;
      this.ivts_EndCostVatAmt = pSource.ivts_EndCostVatAmt;
      this.ivts_EndPrice = pSource.ivts_EndPrice;
      this.ivts_EndPriceCostAmt = pSource.ivts_EndPriceCostAmt;
      this.ivts_EndPriceCostVatAmt = pSource.ivts_EndPriceCostVatAmt;
      this.ivts_EndPriceAmt = pSource.ivts_EndPriceAmt;
      this.ivts_EndPriceVatAmt = pSource.ivts_EndPriceVatAmt;
      this.ivts_SaleQty = pSource.ivts_SaleQty;
      this.ivts_TotalSaleAmt = pSource.ivts_TotalSaleAmt;
      this.ivts_SaleAmt = pSource.ivts_SaleAmt;
      this.ivts_SaleVatAmt = pSource.ivts_SaleVatAmt;
      this.ivts_SaleProfit = pSource.ivts_SaleProfit;
      this.ivts_SalePriceProfit = pSource.ivts_SalePriceProfit;
      this.ivts_EnurySlip = pSource.ivts_EnurySlip;
      this.ivts_EnuryEnd = pSource.ivts_EnuryEnd;
      this.ivts_DcAmtManual = pSource.ivts_DcAmtManual;
      this.ivts_DcAmtEvent = pSource.ivts_DcAmtEvent;
      this.ivts_DcAmtGoods = pSource.ivts_DcAmtGoods;
      this.ivts_DcAmtCoupon = pSource.ivts_DcAmtCoupon;
      this.ivts_DcAmtPromotion = pSource.ivts_DcAmtPromotion;
      this.ivts_DcAmtMember = pSource.ivts_DcAmtMember;
      this.ivts_Customer = pSource.ivts_Customer;
      this.ivts_CustomerGoods = pSource.ivts_CustomerGoods;
      this.ivts_CustomerCategory = pSource.ivts_CustomerCategory;
      this.ivts_CustomerSupplier = pSource.ivts_CustomerSupplier;
      this.ivts_BuyQty = pSource.ivts_BuyQty;
      this.ivts_BuyCostAmt = pSource.ivts_BuyCostAmt;
      this.ivts_BuyCostVatAmt = pSource.ivts_BuyCostVatAmt;
      this.ivts_BuyPriceAmt = pSource.ivts_BuyPriceAmt;
      this.ivts_BuyPriceVatAmt = pSource.ivts_BuyPriceVatAmt;
      this.ivts_ReturnQty = pSource.ivts_ReturnQty;
      this.ivts_ReturnCostAmt = pSource.ivts_ReturnCostAmt;
      this.ivts_ReturnCostVatAmt = pSource.ivts_ReturnCostVatAmt;
      this.ivts_ReturnPriceAmt = pSource.ivts_ReturnPriceAmt;
      this.ivts_ReturnPriceVatAmt = pSource.ivts_ReturnPriceVatAmt;
      this.ivts_InnerMoveOutQty = pSource.ivts_InnerMoveOutQty;
      this.ivts_InnerMoveOutCostAmt = pSource.ivts_InnerMoveOutCostAmt;
      this.ivts_InnerMoveOutCostVatAmt = pSource.ivts_InnerMoveOutCostVatAmt;
      this.ivts_InnerMoveOutPriceAmt = pSource.ivts_InnerMoveOutPriceAmt;
      this.ivts_InnerMoveOutPriceVatAmt = pSource.ivts_InnerMoveOutPriceVatAmt;
      this.ivts_InnerMoveInQty = pSource.ivts_InnerMoveInQty;
      this.ivts_InnerMoveInCostAmt = pSource.ivts_InnerMoveInCostAmt;
      this.ivts_InnerMoveInCostVatAmt = pSource.ivts_InnerMoveInCostVatAmt;
      this.ivts_InnerMoveInPriceAmt = pSource.ivts_InnerMoveInPriceAmt;
      this.ivts_InnerMoveInPriceVatAmt = pSource.ivts_InnerMoveInPriceVatAmt;
      this.ivts_OuterMoveOutQty = pSource.ivts_OuterMoveOutQty;
      this.ivts_OuterMoveOutCostAmt = pSource.ivts_OuterMoveOutCostAmt;
      this.ivts_OuterMoveOutCostVatAmt = pSource.ivts_OuterMoveOutCostVatAmt;
      this.ivts_OuterMoveOutPriceAmt = pSource.ivts_OuterMoveOutPriceAmt;
      this.ivts_OuterMoveOutPriceVatAmt = pSource.ivts_OuterMoveOutPriceVatAmt;
      this.ivts_OuterMoveInQty = pSource.ivts_OuterMoveInQty;
      this.ivts_OuterMoveInCostAmt = pSource.ivts_OuterMoveInCostAmt;
      this.ivts_OuterMoveInCostVatAmt = pSource.ivts_OuterMoveInCostVatAmt;
      this.ivts_OuterMoveInPriceAmt = pSource.ivts_OuterMoveInPriceAmt;
      this.ivts_OuterMoveInPriceVatAmt = pSource.ivts_OuterMoveInPriceVatAmt;
      this.ivts_PreAdjustQty = pSource.ivts_PreAdjustQty;
      this.ivts_PreAdjustCostAmt = pSource.ivts_PreAdjustCostAmt;
      this.ivts_PreAdjustCostVatAmt = pSource.ivts_PreAdjustCostVatAmt;
      this.ivts_PreAdjustPriceAmt = pSource.ivts_PreAdjustPriceAmt;
      this.ivts_PreAdjustPriceVatAmt = pSource.ivts_PreAdjustPriceVatAmt;
      this.ivts_PreAdjustPriceCostSumAmt = pSource.ivts_PreAdjustPriceCostSumAmt;
      this.ivts_PreAdjustPriceCostVatAmt = pSource.ivts_PreAdjustPriceCostVatAmt;
      this.ivts_DisuseQty = pSource.ivts_DisuseQty;
      this.ivts_DisuseCostAmt = pSource.ivts_DisuseCostAmt;
      this.ivts_DisuseCostVatAmt = pSource.ivts_DisuseCostVatAmt;
      this.ivts_DisusePriceAmt = pSource.ivts_DisusePriceAmt;
      this.ivts_DisusePriceVatAmt = pSource.ivts_DisusePriceVatAmt;
      this.ivts_DisusePriceCostSumAmt = pSource.ivts_DisusePriceCostSumAmt;
      this.ivts_DisusePriceCostVatAmt = pSource.ivts_DisusePriceCostVatAmt;
      this.ivts_PriceUp = pSource.ivts_PriceUp;
      this.ivts_PriceUpVat = pSource.ivts_PriceUpVat;
      this.ivts_PriceDown = pSource.ivts_PriceDown;
      this.ivts_PriceDownVat = pSource.ivts_PriceDownVat;
      this.ivts_InventoryQty = pSource.ivts_InventoryQty;
      this.ivts_InventoryCostAmt = pSource.ivts_InventoryCostAmt;
      this.ivts_InventoryCostVatAmt = pSource.ivts_InventoryCostVatAmt;
      this.ivts_InventoryPriceAmt = pSource.ivts_InventoryPriceAmt;
      this.ivts_InventoryPriceVatAmt = pSource.ivts_InventoryPriceVatAmt;
      this.ivts_InventoryPriceCostSumAmt = pSource.ivts_InventoryPriceCostSumAmt;
      this.ivts_InventoryPriceCostVatAmt = pSource.ivts_InventoryPriceCostVatAmt;
      this.ivts_AdjustQty = pSource.ivts_AdjustQty;
      this.ivts_AdjustCostAmt = pSource.ivts_AdjustCostAmt;
      this.ivts_AdjustCostVatAmt = pSource.ivts_AdjustCostVatAmt;
      this.ivts_AdjustPriceAmt = pSource.ivts_AdjustPriceAmt;
      this.ivts_AdjustPriceVatAmt = pSource.ivts_AdjustPriceVatAmt;
      this.ivts_AdjustPriceCostSumAmt = pSource.ivts_AdjustPriceCostSumAmt;
      this.ivts_AdjustPriceCostVatAmt = pSource.ivts_AdjustPriceCostVatAmt;
      this.ivts_LossQty = pSource.ivts_LossQty;
      this.ivts_LossCostAmt = pSource.ivts_LossCostAmt;
      this.ivts_LossCostVatAmt = pSource.ivts_LossCostVatAmt;
      this.ivts_LossPriceAmt = pSource.ivts_LossPriceAmt;
      this.ivts_LossPriceVatAmt = pSource.ivts_LossPriceVatAmt;
      this.ivts_LossPriceCostSumAmt = pSource.ivts_LossPriceCostSumAmt;
      this.ivts_LossPriceCostVatAmt = pSource.ivts_LossPriceCostVatAmt;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ivts_YyyyMm = p_rs.GetFieldInt("ivts_YyyyMm");
        this.ivts_Day = p_rs.GetFieldInt("ivts_Day");
        this.ivts_StoreCode = p_rs.GetFieldInt("ivts_StoreCode");
        if (this.ivts_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ivts_GoodsCode = p_rs.GetFieldLong("ivts_GoodsCode");
        this.ivts_SiteID = p_rs.GetFieldLong("ivts_SiteID");
        this.ivts_Supplier = p_rs.GetFieldInt("ivts_Supplier");
        this.ivts_SupplierType = p_rs.GetFieldInt("ivts_SupplierType");
        this.ivts_CategoryCode = p_rs.GetFieldInt("ivts_CategoryCode");
        this.ivts_TaxDiv = p_rs.GetFieldInt("ivts_TaxDiv");
        this.ivts_StockUnit = p_rs.GetFieldInt("ivts_StockUnit");
        this.ivts_SalesUnit = p_rs.GetFieldInt("ivts_SalesUnit");
        this.ivts_BaseQty = p_rs.GetFieldDouble("ivts_BaseQty");
        this.ivts_BaseAvgCost = p_rs.GetFieldDouble("ivts_BaseAvgCost");
        this.ivts_BaseCostAmt = p_rs.GetFieldDouble("ivts_BaseCostAmt");
        this.ivts_BaseCostVatAmt = p_rs.GetFieldDouble("ivts_BaseCostVatAmt");
        this.ivts_BasePriceAmt = p_rs.GetFieldDouble("ivts_BasePriceAmt");
        this.ivts_BasePriceCostAmt = p_rs.GetFieldDouble("ivts_BasePriceCostAmt");
        this.ivts_BasePriceCostVatAmt = p_rs.GetFieldDouble("ivts_BasePriceCostVatAmt");
        this.ivts_BasePrice = p_rs.GetFieldDouble("ivts_BasePrice");
        this.ivts_BasePriceVatAmt = p_rs.GetFieldDouble("ivts_BasePriceVatAmt");
        this.ivts_EndQty = p_rs.GetFieldDouble("ivts_EndQty");
        this.ivts_EndAvgCost = p_rs.GetFieldDouble("ivts_EndAvgCost");
        this.ivts_EndCostAmt = p_rs.GetFieldDouble("ivts_EndCostAmt");
        this.ivts_EndCostVatAmt = p_rs.GetFieldDouble("ivts_EndCostVatAmt");
        this.ivts_EndPriceAmt = p_rs.GetFieldDouble("ivts_EndPriceAmt");
        this.ivts_EndPriceCostAmt = p_rs.GetFieldDouble("ivts_EndPriceCostAmt");
        this.ivts_EndPriceCostVatAmt = p_rs.GetFieldDouble("ivts_EndPriceCostVatAmt");
        this.ivts_EndPrice = p_rs.GetFieldDouble("ivts_EndPrice");
        this.ivts_EndPriceVatAmt = p_rs.GetFieldDouble("ivts_EndPriceVatAmt");
        this.ivts_SaleQty = p_rs.GetFieldDouble("ivts_SaleQty");
        this.ivts_TotalSaleAmt = p_rs.GetFieldDouble("ivts_TotalSaleAmt");
        this.ivts_SaleAmt = p_rs.GetFieldDouble("ivts_SaleAmt");
        this.ivts_SaleVatAmt = p_rs.GetFieldDouble("ivts_SaleVatAmt");
        this.ivts_SaleProfit = p_rs.GetFieldDouble("ivts_SaleProfit");
        this.ivts_SalePriceProfit = p_rs.GetFieldDouble("ivts_SalePriceProfit");
        this.ivts_EnurySlip = p_rs.GetFieldDouble("ivts_EnurySlip");
        this.ivts_EnuryEnd = p_rs.GetFieldDouble("ivts_EnuryEnd");
        this.ivts_DcAmtManual = p_rs.GetFieldDouble("ivts_DcAmtManual");
        this.ivts_DcAmtEvent = p_rs.GetFieldDouble("ivts_DcAmtEvent");
        this.ivts_DcAmtGoods = p_rs.GetFieldDouble("ivts_DcAmtGoods");
        this.ivts_DcAmtCoupon = p_rs.GetFieldDouble("ivts_DcAmtCoupon");
        this.ivts_DcAmtPromotion = p_rs.GetFieldDouble("ivts_DcAmtPromotion");
        this.ivts_DcAmtMember = p_rs.GetFieldDouble("ivts_DcAmtMember");
        this.ivts_Customer = p_rs.GetFieldDouble("ivts_Customer");
        this.ivts_CustomerGoods = p_rs.GetFieldDouble("ivts_CustomerGoods");
        this.ivts_CustomerCategory = p_rs.GetFieldDouble("ivts_CustomerCategory");
        this.ivts_CustomerSupplier = p_rs.GetFieldDouble("ivts_CustomerSupplier");
        this.ivts_BuyQty = p_rs.GetFieldDouble("ivts_BuyQty");
        this.ivts_BuyCostAmt = p_rs.GetFieldDouble("ivts_BuyCostAmt");
        this.ivts_BuyCostVatAmt = p_rs.GetFieldDouble("ivts_BuyCostVatAmt");
        this.ivts_BuyPriceAmt = p_rs.GetFieldDouble("ivts_BuyPriceAmt");
        this.ivts_BuyPriceVatAmt = p_rs.GetFieldDouble("ivts_BuyPriceVatAmt");
        this.ivts_ReturnQty = p_rs.GetFieldDouble("ivts_ReturnQty");
        this.ivts_ReturnCostAmt = p_rs.GetFieldDouble("ivts_ReturnCostAmt");
        this.ivts_ReturnCostVatAmt = p_rs.GetFieldDouble("ivts_ReturnCostVatAmt");
        this.ivts_ReturnPriceAmt = p_rs.GetFieldDouble("ivts_ReturnPriceAmt");
        this.ivts_ReturnPriceVatAmt = p_rs.GetFieldDouble("ivts_ReturnPriceVatAmt");
        this.ivts_InnerMoveOutQty = p_rs.GetFieldDouble("ivts_InnerMoveOutQty");
        this.ivts_InnerMoveOutCostAmt = p_rs.GetFieldDouble("ivts_InnerMoveOutCostAmt");
        this.ivts_InnerMoveOutCostVatAmt = p_rs.GetFieldDouble("ivts_InnerMoveOutCostVatAmt");
        this.ivts_InnerMoveOutPriceAmt = p_rs.GetFieldDouble("ivts_InnerMoveOutPriceAmt");
        this.ivts_InnerMoveOutPriceVatAmt = p_rs.GetFieldDouble("ivts_InnerMoveOutPriceVatAmt");
        this.ivts_InnerMoveInQty = p_rs.GetFieldDouble("ivts_InnerMoveInQty");
        this.ivts_InnerMoveInCostAmt = p_rs.GetFieldDouble("ivts_InnerMoveInCostAmt");
        this.ivts_InnerMoveInCostVatAmt = p_rs.GetFieldDouble("ivts_InnerMoveInCostVatAmt");
        this.ivts_InnerMoveInPriceAmt = p_rs.GetFieldDouble("ivts_InnerMoveInPriceAmt");
        this.ivts_InnerMoveInPriceVatAmt = p_rs.GetFieldDouble("ivts_InnerMoveInPriceVatAmt");
        this.ivts_OuterMoveOutQty = p_rs.GetFieldDouble("ivts_OuterMoveOutQty");
        this.ivts_OuterMoveOutCostAmt = p_rs.GetFieldDouble("ivts_OuterMoveOutCostAmt");
        this.ivts_OuterMoveOutCostVatAmt = p_rs.GetFieldDouble("ivts_OuterMoveOutCostVatAmt");
        this.ivts_OuterMoveOutPriceAmt = p_rs.GetFieldDouble("ivts_OuterMoveOutPriceAmt");
        this.ivts_OuterMoveOutPriceVatAmt = p_rs.GetFieldDouble("ivts_OuterMoveOutPriceVatAmt");
        this.ivts_OuterMoveInQty = p_rs.GetFieldDouble("ivts_OuterMoveInQty");
        this.ivts_OuterMoveInCostAmt = p_rs.GetFieldDouble("ivts_OuterMoveInCostAmt");
        this.ivts_OuterMoveInCostVatAmt = p_rs.GetFieldDouble("ivts_OuterMoveInCostVatAmt");
        this.ivts_OuterMoveInPriceAmt = p_rs.GetFieldDouble("ivts_OuterMoveInPriceAmt");
        this.ivts_OuterMoveInPriceVatAmt = p_rs.GetFieldDouble("ivts_OuterMoveInPriceVatAmt");
        this.ivts_PreAdjustQty = p_rs.GetFieldDouble("ivts_PreAdjustQty");
        this.ivts_PreAdjustCostAmt = p_rs.GetFieldDouble("ivts_PreAdjustCostAmt");
        this.ivts_PreAdjustCostVatAmt = p_rs.GetFieldDouble("ivts_PreAdjustCostVatAmt");
        this.ivts_PreAdjustPriceAmt = p_rs.GetFieldDouble("ivts_PreAdjustPriceAmt");
        this.ivts_PreAdjustPriceVatAmt = p_rs.GetFieldDouble("ivts_PreAdjustPriceVatAmt");
        this.ivts_PreAdjustPriceCostSumAmt = p_rs.GetFieldDouble("ivts_PreAdjustPriceCostSumAmt");
        this.ivts_PreAdjustPriceCostVatAmt = p_rs.GetFieldDouble("ivts_PreAdjustPriceCostVatAmt");
        this.ivts_DisuseQty = p_rs.GetFieldDouble("ivts_DisuseQty");
        this.ivts_DisuseCostAmt = p_rs.GetFieldDouble("ivts_DisuseCostAmt");
        this.ivts_DisuseCostVatAmt = p_rs.GetFieldDouble("ivts_DisuseCostVatAmt");
        this.ivts_DisusePriceAmt = p_rs.GetFieldDouble("ivts_DisusePriceAmt");
        this.ivts_DisusePriceVatAmt = p_rs.GetFieldDouble("ivts_DisusePriceVatAmt");
        this.ivts_DisusePriceCostSumAmt = p_rs.GetFieldDouble("ivts_DisusePriceCostSumAmt");
        this.ivts_DisusePriceCostVatAmt = p_rs.GetFieldDouble("ivts_DisusePriceCostVatAmt");
        this.ivts_PriceUp = p_rs.GetFieldDouble("ivts_PriceUp");
        this.ivts_PriceUpVat = p_rs.GetFieldDouble("ivts_PriceUpVat");
        this.ivts_PriceDown = p_rs.GetFieldDouble("ivts_PriceDown");
        this.ivts_PriceDownVat = p_rs.GetFieldDouble("ivts_PriceDownVat");
        this.ivts_InventoryQty = p_rs.GetFieldDouble("ivts_InventoryQty");
        this.ivts_InventoryCostAmt = p_rs.GetFieldDouble("ivts_InventoryCostAmt");
        this.ivts_InventoryCostVatAmt = p_rs.GetFieldDouble("ivts_InventoryCostVatAmt");
        this.ivts_InventoryPriceAmt = p_rs.GetFieldDouble("ivts_InventoryPriceAmt");
        this.ivts_InventoryPriceVatAmt = p_rs.GetFieldDouble("ivts_InventoryPriceVatAmt");
        this.ivts_InventoryPriceCostSumAmt = p_rs.GetFieldDouble("ivts_InventoryPriceCostSumAmt");
        this.ivts_InventoryPriceCostVatAmt = p_rs.GetFieldDouble("ivts_InventoryPriceCostVatAmt");
        this.ivts_AdjustQty = p_rs.GetFieldDouble("ivts_AdjustQty");
        this.ivts_AdjustCostAmt = p_rs.GetFieldDouble("ivts_AdjustCostAmt");
        this.ivts_AdjustCostVatAmt = p_rs.GetFieldDouble("ivts_AdjustCostVatAmt");
        this.ivts_AdjustPriceAmt = p_rs.GetFieldDouble("ivts_AdjustPriceAmt");
        this.ivts_AdjustPriceVatAmt = p_rs.GetFieldDouble("ivts_AdjustPriceVatAmt");
        this.ivts_AdjustPriceCostSumAmt = p_rs.GetFieldDouble("ivts_AdjustPriceCostSumAmt");
        this.ivts_AdjustPriceCostVatAmt = p_rs.GetFieldDouble("ivts_AdjustPriceCostVatAmt");
        this.ivts_LossQty = p_rs.GetFieldDouble("ivts_LossQty");
        this.ivts_LossCostAmt = p_rs.GetFieldDouble("ivts_LossCostAmt");
        this.ivts_LossCostVatAmt = p_rs.GetFieldDouble("ivts_LossCostVatAmt");
        this.ivts_LossPriceAmt = p_rs.GetFieldDouble("ivts_LossPriceAmt");
        this.ivts_LossPriceVatAmt = p_rs.GetFieldDouble("ivts_LossPriceVatAmt");
        this.ivts_LossPriceCostSumAmt = p_rs.GetFieldDouble("ivts_LossPriceCostSumAmt");
        this.ivts_LossPriceCostVatAmt = p_rs.GetFieldDouble("ivts_LossPriceCostVatAmt");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public virtual bool CalcAddSum(TInventorySummary pSource)
    {
      if (pSource == null)
        return false;
      this.ivts_BaseQty += pSource.ivts_BaseQty;
      this.ivts_BaseAvgCost = pSource.ivts_BaseAvgCost;
      this.ivts_BaseCostAmt += pSource.ivts_BaseCostAmt;
      this.ivts_BaseCostVatAmt += pSource.ivts_BaseCostVatAmt;
      this.ivts_BasePriceAmt += pSource.ivts_BasePriceAmt;
      this.ivts_BasePriceVatAmt += pSource.ivts_BasePriceVatAmt;
      this.ivts_BasePriceCostAmt += pSource.ivts_BasePriceCostAmt;
      this.ivts_BasePriceCostVatAmt += pSource.ivts_BasePriceCostVatAmt;
      this.ivts_EndQty += pSource.ivts_EndQty;
      this.ivts_EndAvgCost = pSource.ivts_EndAvgCost;
      this.ivts_EndCostAmt += pSource.ivts_EndCostAmt;
      this.ivts_EndCostVatAmt += pSource.ivts_EndCostVatAmt;
      this.ivts_EndPriceAmt += pSource.ivts_EndPriceAmt;
      this.ivts_EndPriceVatAmt += pSource.ivts_EndPriceVatAmt;
      this.ivts_EndPriceCostAmt += pSource.ivts_EndPriceCostAmt;
      this.ivts_EndPriceCostVatAmt += pSource.ivts_EndPriceCostVatAmt;
      this.ivts_SaleQty += pSource.ivts_SaleQty;
      this.ivts_TotalSaleAmt += pSource.ivts_TotalSaleAmt;
      this.ivts_SaleAmt += pSource.ivts_SaleAmt;
      this.ivts_SaleVatAmt += pSource.ivts_SaleVatAmt;
      this.ivts_SaleProfit += pSource.ivts_SaleProfit;
      this.ivts_EnurySlip += pSource.ivts_EnurySlip;
      this.ivts_EnuryEnd += pSource.ivts_EnuryEnd;
      this.ivts_DcAmtManual += pSource.ivts_DcAmtManual;
      this.ivts_DcAmtEvent += pSource.ivts_DcAmtEvent;
      this.ivts_DcAmtGoods += pSource.ivts_DcAmtGoods;
      this.ivts_DcAmtCoupon += pSource.ivts_DcAmtCoupon;
      this.ivts_DcAmtPromotion += pSource.ivts_DcAmtPromotion;
      this.ivts_DcAmtMember += pSource.ivts_DcAmtMember;
      this.ivts_Customer += pSource.ivts_Customer;
      this.ivts_CustomerGoods += pSource.ivts_CustomerGoods;
      this.ivts_CustomerCategory += pSource.ivts_CustomerCategory;
      this.ivts_CustomerSupplier += pSource.ivts_CustomerSupplier;
      this.ivts_BuyQty += pSource.ivts_BuyQty;
      this.ivts_BuyCostAmt += pSource.ivts_BuyCostAmt;
      this.ivts_BuyCostVatAmt += pSource.ivts_BuyCostVatAmt;
      this.ivts_BuyPriceAmt += pSource.ivts_BuyPriceAmt;
      this.ivts_BuyPriceVatAmt += pSource.ivts_BuyPriceVatAmt;
      this.ivts_ReturnQty += pSource.ivts_ReturnQty;
      this.ivts_ReturnCostAmt += pSource.ivts_ReturnCostAmt;
      this.ivts_ReturnCostVatAmt += pSource.ivts_ReturnCostVatAmt;
      this.ivts_ReturnPriceAmt += pSource.ivts_ReturnPriceAmt;
      this.ivts_ReturnPriceVatAmt += pSource.ivts_ReturnPriceVatAmt;
      this.ivts_InnerMoveOutQty += pSource.ivts_InnerMoveOutQty;
      this.ivts_InnerMoveOutCostAmt += pSource.ivts_InnerMoveOutCostAmt;
      this.ivts_InnerMoveOutCostVatAmt += pSource.ivts_InnerMoveOutCostVatAmt;
      this.ivts_InnerMoveOutPriceAmt += pSource.ivts_InnerMoveOutPriceAmt;
      this.ivts_InnerMoveOutPriceVatAmt += pSource.ivts_InnerMoveOutPriceVatAmt;
      this.ivts_InnerMoveInQty += pSource.ivts_InnerMoveInQty;
      this.ivts_InnerMoveInCostAmt += pSource.ivts_InnerMoveInCostAmt;
      this.ivts_InnerMoveInCostVatAmt += pSource.ivts_InnerMoveInCostVatAmt;
      this.ivts_InnerMoveInPriceAmt += pSource.ivts_InnerMoveInPriceAmt;
      this.ivts_InnerMoveInPriceVatAmt += pSource.ivts_InnerMoveInPriceVatAmt;
      this.ivts_OuterMoveOutQty += pSource.ivts_OuterMoveOutQty;
      this.ivts_OuterMoveOutCostAmt += pSource.ivts_OuterMoveOutCostAmt;
      this.ivts_OuterMoveOutCostVatAmt += pSource.ivts_OuterMoveOutCostVatAmt;
      this.ivts_OuterMoveOutPriceAmt += pSource.ivts_OuterMoveOutPriceAmt;
      this.ivts_OuterMoveOutPriceVatAmt += pSource.ivts_OuterMoveOutPriceVatAmt;
      this.ivts_OuterMoveInQty += pSource.ivts_OuterMoveInQty;
      this.ivts_OuterMoveInCostAmt += pSource.ivts_OuterMoveInCostAmt;
      this.ivts_OuterMoveInCostVatAmt += pSource.ivts_OuterMoveInCostVatAmt;
      this.ivts_OuterMoveInPriceAmt += pSource.ivts_OuterMoveInPriceAmt;
      this.ivts_OuterMoveInPriceVatAmt += pSource.ivts_OuterMoveInPriceVatAmt;
      this.ivts_PreAdjustQty += pSource.ivts_PreAdjustQty;
      this.ivts_PreAdjustCostAmt += pSource.ivts_PreAdjustCostAmt;
      this.ivts_PreAdjustCostVatAmt += pSource.ivts_PreAdjustCostVatAmt;
      this.ivts_PreAdjustPriceAmt += pSource.ivts_PreAdjustPriceAmt;
      this.ivts_PreAdjustPriceVatAmt += pSource.ivts_PreAdjustPriceVatAmt;
      this.ivts_PreAdjustPriceCostSumAmt += pSource.ivts_PreAdjustPriceCostSumAmt;
      this.ivts_PreAdjustPriceCostVatAmt += pSource.ivts_PreAdjustPriceCostVatAmt;
      this.ivts_DisuseQty += pSource.ivts_DisuseQty;
      this.ivts_DisuseCostAmt += pSource.ivts_DisuseCostAmt;
      this.ivts_DisuseCostVatAmt += pSource.ivts_DisuseCostVatAmt;
      this.ivts_DisusePriceAmt += pSource.ivts_DisuseCostVatAmt;
      this.ivts_DisusePriceVatAmt += pSource.ivts_DisusePriceVatAmt;
      this.ivts_DisusePriceCostSumAmt += pSource.ivts_DisusePriceCostSumAmt;
      this.ivts_DisusePriceCostVatAmt += pSource.ivts_DisusePriceCostVatAmt;
      this.ivts_PriceUp += pSource.ivts_PriceUp;
      this.ivts_PriceUpVat += pSource.ivts_PriceUpVat;
      this.ivts_PriceDown += pSource.ivts_PriceDown;
      this.ivts_PriceDownVat += pSource.ivts_PriceDownVat;
      this.ivts_InventoryQty += pSource.ivts_InventoryQty;
      this.ivts_InventoryCostAmt += pSource.ivts_InventoryCostAmt;
      this.ivts_InventoryCostVatAmt += pSource.ivts_InventoryCostVatAmt;
      this.ivts_InventoryPriceAmt += pSource.ivts_InventoryPriceAmt;
      this.ivts_InventoryPriceVatAmt += pSource.ivts_InventoryPriceVatAmt;
      this.ivts_InventoryPriceCostSumAmt += pSource.ivts_InventoryPriceCostSumAmt;
      this.ivts_InventoryPriceCostVatAmt += pSource.ivts_InventoryPriceCostVatAmt;
      this.ivts_AdjustQty += pSource.ivts_AdjustQty;
      this.ivts_AdjustCostAmt += pSource.ivts_AdjustCostAmt;
      this.ivts_AdjustCostVatAmt += pSource.ivts_AdjustCostVatAmt;
      this.ivts_AdjustPriceAmt += pSource.ivts_AdjustPriceAmt;
      this.ivts_AdjustPriceVatAmt += pSource.ivts_AdjustPriceVatAmt;
      this.ivts_AdjustPriceCostSumAmt += pSource.ivts_AdjustPriceCostSumAmt;
      this.ivts_AdjustPriceCostVatAmt += pSource.ivts_AdjustPriceCostVatAmt;
      this.ivts_LossQty += pSource.ivts_LossQty;
      this.ivts_LossCostAmt += pSource.ivts_LossCostAmt;
      this.ivts_LossCostVatAmt += pSource.ivts_LossCostVatAmt;
      this.ivts_LossPriceAmt += pSource.ivts_LossPriceAmt;
      this.ivts_LossPriceVatAmt += pSource.ivts_LossPriceVatAmt;
      this.ivts_LossPriceCostSumAmt += pSource.ivts_LossPriceCostSumAmt;
      this.ivts_LossPriceCostVatAmt += pSource.ivts_LossPriceCostVatAmt;
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, TInventorySummary pSource) => pSource == null || (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.ivts_BaseQty.IsZero() && pSource.ivts_EndQty.IsZero() && pSource.ivts_SaleQty.IsZero() && pSource.ivts_BuyQty.IsZero() && pSource.ivts_ReturnQty.IsZero() && pSource.ivts_InnerMoveOutQty.IsZero() && pSource.ivts_InnerMoveInQty.IsZero() && pSource.ivts_OuterMoveOutQty.IsZero() && pSource.ivts_OuterMoveInQty.IsZero() && pSource.ivts_PreAdjustQty.IsZero() && pSource.ivts_DisuseQty.IsZero() && pSource.ivts_InventoryQty.IsZero() && pSource.ivts_AdjustQty.IsZero() && pSource.ivts_LossQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.ivts_BaseCostAmt.IsZero() && pSource.ivts_BasePriceAmt.IsZero() && pSource.ivts_EndCostAmt.IsZero() && pSource.ivts_EndPriceAmt.IsZero() && pSource.ivts_SaleAmt.IsZero() && pSource.ivts_SaleProfit.IsZero() && pSource.ivts_EnurySlip.IsZero() && pSource.ivts_EnuryEnd.IsZero() && pSource.ivts_DcAmtEvent.IsZero() && pSource.ivts_DcAmtGoods.IsZero() && pSource.ivts_DcAmtCoupon.IsZero() && pSource.ivts_DcAmtPromotion.IsZero() && pSource.ivts_DcAmtMember.IsZero() && pSource.ivts_Customer.IsZero() && pSource.ivts_CustomerGoods.IsZero() && pSource.ivts_CustomerCategory.IsZero() && pSource.ivts_CustomerSupplier.IsZero() && pSource.ivts_BuyCostAmt.IsZero() && pSource.ivts_ReturnCostAmt.IsZero() && pSource.ivts_InnerMoveOutCostAmt.IsZero() && pSource.ivts_InnerMoveInCostAmt.IsZero() && pSource.ivts_OuterMoveOutCostAmt.IsZero() && pSource.ivts_OuterMoveInCostAmt.IsZero() && pSource.ivts_PreAdjustCostAmt.IsZero() && pSource.ivts_PreAdjustPriceCostSumAmt.IsZero() && pSource.ivts_DisuseCostAmt.IsZero() && pSource.ivts_DisusePriceCostSumAmt.IsZero() && pSource.ivts_PriceUp.IsZero() && pSource.ivts_PriceDown.IsZero() && pSource.ivts_InventoryCostAmt.IsZero() && pSource.ivts_InventoryPriceCostSumAmt.IsZero() && pSource.ivts_AdjustCostAmt.IsZero() && pSource.ivts_AdjustPriceCostSumAmt.IsZero() && pSource.ivts_LossCostAmt.IsZero() && pSource.ivts_LossPriceCostSumAmt.IsZero());

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
        if (!p_param.ContainsKey((object) "ivts_YyyyMm") || Convert.ToInt32(p_param[(object) "ivts_YyyyMm"].ToString()) == 0)
          throw new Exception("월 정보 데이터 부족.");
        if (!p_param.ContainsKey((object) "ivts_Day") || Convert.ToInt32(p_param[(object) "ivts_Day"].ToString()) == 0)
          throw new Exception("일 정보 데이터 부족.");
        stringBuilder.Append(string.Format(" UPDATE {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
        EnumDB enumDb = DbQueryHelper.DbTypeNotNull();
        if (enumDb == EnumDB.MYSQL)
          stringBuilder.Append(string.Format("\nINNER JOIN {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo) + " ON ivts_StoreCode=si_StoreCode AND ivts_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<ivts_YyyyMm*100 + ivts_Day AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<ivts_YyyyMm*100 + ivts_Day");
        stringBuilder.Append("\nSET  ivts_BaseQty=0,ivts_BaseAvgCost=0,ivts_BaseCostAmt=0,ivts_BaseCostVatAmt=0,ivts_BasePrice=0,ivts_BasePriceCostAmt=0,ivts_BasePriceCostVatAmt=0,ivts_BasePriceAmt=0,ivts_BasePriceVatAmt=0,ivts_EndQty=0,ivts_EndAvgCost=0,ivts_EndCostAmt=0,ivts_EndCostVatAmt=0,ivts_EndPrice=0,ivts_EndPriceCostAmt=0,ivts_EndPriceCostVatAmt=0,ivts_EndPriceAmt=0,ivts_EndPriceVatAmt=0,ivts_SaleQty=0,ivts_TotalSaleAmt=0,ivts_SaleAmt=0,ivts_SaleVatAmt=0,ivts_SaleProfit=0,ivts_SalePriceProfit=0,ivts_EnurySlip=0,ivts_EnuryEnd=0,ivts_DcAmtManual=0,ivts_DcAmtEvent=0,ivts_DcAmtGoods=0,ivts_DcAmtCoupon=0,ivts_DcAmtPromotion=0,ivts_DcAmtMember=0,ivts_Customer=0,ivts_CustomerGoods=0,ivts_CustomerCategory=0,ivts_CustomerSupplier=0,ivts_BuyQty=0,ivts_BuyCostAmt=0,ivts_BuyCostVatAmt=0,ivts_BuyPriceAmt=0,ivts_BuyPriceVatAmt=0,ivts_ReturnQty=0,ivts_ReturnCostAmt=0,ivts_ReturnCostVatAmt=0,ivts_ReturnPriceAmt=0,ivts_ReturnPriceVatAmt=0,ivts_InnerMoveOutQty=0,ivts_InnerMoveOutCostAmt=0,ivts_InnerMoveOutCostVatAmt=0,ivts_InnerMoveOutPriceAmt=0,ivts_InnerMoveOutPriceVatAmt=0,ivts_InnerMoveInQty=0,ivts_InnerMoveInCostAmt=0,ivts_InnerMoveInCostVatAmt=0,ivts_InnerMoveInPriceAmt=0,ivts_InnerMoveInPriceVatAmt=0,ivts_OuterMoveOutQty=0,ivts_OuterMoveOutCostAmt=0,ivts_OuterMoveOutCostVatAmt=0,ivts_OuterMoveOutPriceAmt=0,ivts_OuterMoveOutPriceVatAmt=0,ivts_OuterMoveInQty=0,ivts_OuterMoveInCostAmt=0,ivts_OuterMoveInCostVatAmt=0,ivts_OuterMoveInPriceAmt=0,ivts_OuterMoveInPriceVatAmt=0,ivts_PreAdjustQty=0,ivts_PreAdjustCostAmt=0,ivts_PreAdjustCostVatAmt=0,ivts_PreAdjustPriceAmt=0,ivts_PreAdjustPriceVatAmt=0,ivts_PreAdjustPriceCostSumAmt=0,ivts_PreAdjustPriceCostVatAmt=0,ivts_DisuseQty=0,ivts_DisuseCostAmt=0,ivts_DisuseCostVatAmt=0,ivts_DisusePriceAmt=0,ivts_DisusePriceVatAmt=0,ivts_DisusePriceCostSumAmt=0,ivts_DisusePriceCostVatAmt=0,ivts_PriceUp=0,ivts_PriceUpVat=0,ivts_PriceDown=0,ivts_PriceDownVat=0,ivts_InventoryQty=0,ivts_InventoryCostAmt=0,ivts_InventoryCostVatAmt=0,ivts_InventoryPriceAmt=0,ivts_InventoryPriceVatAmt=0,ivts_InventoryPriceCostSumAmt=0,ivts_InventoryPriceCostVatAmt=0,ivts_AdjustQty=0,ivts_AdjustCostAmt=0,ivts_AdjustCostVatAmt=0,ivts_AdjustPriceAmt=0,ivts_AdjustPriceVatAmt=0,ivts_AdjustPriceCostSumAmt=0,ivts_AdjustPriceCostVatAmt=0,ivts_LossQty=0,ivts_LossCostAmt=0,ivts_LossCostVatAmt=0,ivts_LossPriceAmt=0,ivts_LossPriceVatAmt=0,ivts_LossPriceCostSumAmt=0,ivts_LossPriceCostVatAmt=0");
        if (enumDb == EnumDB.MSSQL)
          stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " ON ivts_StoreCode=si_StoreCode AND ivts_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<ivts_YyyyMm*100+ivts_Day AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<ivts_YyyyMm*100+ivts_Day");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "ivts_YyyyMm", p_param[(object) "ivts_YyyyMm"]));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Day", p_param[(object) "ivts_Day"]));
        if (p_param.ContainsKey((object) "ivts_StoreCode") && Convert.ToInt32(p_param[(object) "ivts_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StoreCode", p_param[(object) "ivts_StoreCode"]));
        else if (p_param.ContainsKey((object) "ivts_StoreCode_IN_") && p_param[(object) "ivts_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_StoreCode", p_param[(object) "ivts_StoreCode_IN_"]));
        else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND ivts_StoreCode > 0");
        if (p_param.ContainsKey((object) "ivts_GoodsCode"))
        {
          if (Convert.ToInt64(p_param[(object) "ivts_GoodsCode"].ToString()) > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_GoodsCode", p_param[(object) "ivts_GoodsCode"]));
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
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.ivts_YyyyMm, (object) this.ivts_StoreCode, (object) this.ivts_GoodsCode, (object) this.ivts_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> DataClearAsync(Hashtable p_param)
    {
      TInventorySummary tinventorySummary = this;
      // ISSUE: reference to a compiler-generated method
      tinventorySummary.\u003C\u003En__0();
      if (await tinventorySummary.OleDB.ExecuteAsync(tinventorySummary.DataClearQuery(p_param)))
        return true;
      tinventorySummary.message = " " + tinventorySummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventorySummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventorySummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tinventorySummary.ivts_YyyyMm, (object) tinventorySummary.ivts_StoreCode, (object) tinventorySummary.ivts_GoodsCode, (object) tinventorySummary.ivts_SiteID) + " 내용 : " + tinventorySummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventorySummary.message);
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " ivts_YyyyMm,ivts_Day,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID,ivts_Supplier,ivts_SupplierType,ivts_CategoryCode,ivts_TaxDiv,ivts_StockUnit,ivts_SalesUnit,ivts_BaseQty,ivts_BaseAvgCost,ivts_BaseCostAmt,ivts_BaseCostVatAmt,ivts_BasePrice,ivts_BasePriceCostAmt,ivts_BasePriceCostVatAmt,ivts_BasePriceAmt,ivts_BasePriceVatAmt,ivts_EndQty,ivts_EndAvgCost,ivts_EndCostAmt,ivts_EndCostVatAmt,ivts_EndPrice,ivts_EndPriceCostAmt,ivts_EndPriceCostVatAmt,ivts_EndPriceAmt,ivts_EndPriceVatAmt,ivts_SaleQty,ivts_TotalSaleAmt,ivts_SaleAmt,ivts_SaleVatAmt,ivts_SaleProfit,ivts_SalePriceProfit,ivts_EnurySlip,ivts_EnuryEnd,ivts_DcAmtManual,ivts_DcAmtEvent,ivts_DcAmtGoods,ivts_DcAmtCoupon,ivts_DcAmtPromotion,ivts_DcAmtMember,ivts_Customer,ivts_CustomerGoods,ivts_CustomerCategory,ivts_CustomerSupplier,ivts_BuyQty,ivts_BuyCostAmt,ivts_BuyCostVatAmt,ivts_BuyPriceAmt,ivts_BuyPriceVatAmt,ivts_ReturnQty,ivts_ReturnCostAmt,ivts_ReturnCostVatAmt,ivts_ReturnPriceAmt,ivts_ReturnPriceVatAmt,ivts_InnerMoveOutQty,ivts_InnerMoveOutCostAmt,ivts_InnerMoveOutCostVatAmt,ivts_InnerMoveOutPriceAmt,ivts_InnerMoveOutPriceVatAmt,ivts_InnerMoveInQty,ivts_InnerMoveInCostAmt,ivts_InnerMoveInCostVatAmt,ivts_InnerMoveInPriceAmt,ivts_InnerMoveInPriceVatAmt,ivts_OuterMoveOutQty,ivts_OuterMoveOutCostAmt,ivts_OuterMoveOutCostVatAmt,ivts_OuterMoveOutPriceAmt,ivts_OuterMoveOutPriceVatAmt,ivts_OuterMoveInQty,ivts_OuterMoveInCostAmt,ivts_OuterMoveInCostVatAmt,ivts_OuterMoveInPriceAmt,ivts_OuterMoveInPriceVatAmt,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,ivts_DisuseQty,ivts_DisuseCostAmt,ivts_DisuseCostVatAmt,ivts_DisusePriceAmt,ivts_DisusePriceVatAmt,ivts_DisusePriceCostSumAmt,ivts_DisusePriceCostVatAmt,ivts_PriceUp,ivts_PriceUpVat,ivts_PriceDown,ivts_PriceDownVat,ivts_InventoryQty,ivts_InventoryCostAmt,ivts_InventoryCostVatAmt,ivts_InventoryPriceAmt,ivts_InventoryPriceVatAmt,ivts_InventoryPriceCostSumAmt,ivts_InventoryPriceCostVatAmt,ivts_AdjustQty,ivts_AdjustCostAmt,ivts_AdjustCostVatAmt,ivts_AdjustPriceAmt,ivts_AdjustPriceVatAmt,ivts_AdjustPriceCostSumAmt,ivts_AdjustPriceCostVatAmt,ivts_LossQty,ivts_LossCostAmt,ivts_LossCostVatAmt,ivts_LossPriceAmt,ivts_LossPriceVatAmt,ivts_LossPriceCostSumAmt,ivts_LossPriceCostVatAmt) VALUES ( " + string.Format(" {0},{1},{2},{3}", (object) this.ivts_YyyyMm, (object) this.ivts_Day, (object) this.ivts_StoreCode, (object) this.ivts_GoodsCode) + string.Format(",{0}", (object) this.ivts_SiteID) + string.Format(",{0},{1},{2}", (object) this.ivts_Supplier, (object) this.ivts_SupplierType, (object) this.ivts_CategoryCode) + string.Format(",{0},{1},{2}", (object) this.ivts_TaxDiv, (object) this.ivts_StockUnit, (object) this.ivts_SalesUnit) + "," + this.ivts_BaseQty.FormatTo("{0:0.0000}") + "," + this.ivts_BaseAvgCost.FormatTo("{0:0.0000}") + "," + this.ivts_BaseCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BaseCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BasePrice.FormatTo("{0:0.0000}") + "," + this.ivts_BasePriceCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BasePriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BasePriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndQty.FormatTo("{0:0.0000}") + "," + this.ivts_EndAvgCost.FormatTo("{0:0.0000}") + "," + this.ivts_EndCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndPrice.FormatTo("{0:0.0000}") + "," + this.ivts_EndPriceCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_EndPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_SaleQty.FormatTo("{0:0.0000}") + "," + this.ivts_TotalSaleAmt.FormatTo("{0:0.0000}") + "," + this.ivts_SaleAmt.FormatTo("{0:0.0000}") + "," + this.ivts_SaleVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_SaleProfit.FormatTo("{0:0.0000}") + "," + this.ivts_SalePriceProfit.FormatTo("{0:0.0000}") + "," + this.ivts_EnurySlip.FormatTo("{0:0.0000}") + "," + this.ivts_EnuryEnd.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtManual.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtEvent.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtGoods.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtCoupon.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtPromotion.FormatTo("{0:0.0000}") + "," + this.ivts_DcAmtMember.FormatTo("{0:0.0000}") + "," + this.ivts_Customer.FormatTo("{0:0.0000}") + "," + this.ivts_CustomerGoods.FormatTo("{0:0.0000}") + "," + this.ivts_CustomerCategory.FormatTo("{0:0.0000}") + "," + this.ivts_CustomerSupplier.FormatTo("{0:0.0000}") + "," + this.ivts_BuyQty.FormatTo("{0:0.0000}") + "," + this.ivts_BuyCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BuyCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BuyPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_BuyPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_ReturnQty.FormatTo("{0:0.0000}") + "," + this.ivts_ReturnCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_ReturnCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_ReturnPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveOutQty.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveInQty.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveOutQty.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveInQty.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustQty.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PreAdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisuseQty.FormatTo("{0:0.0000}") + "," + this.ivts_DisuseCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisuseCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisusePriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisusePriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.ivts_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_PriceUp.FormatTo("{0:0.0000}") + "," + this.ivts_PriceUpVat.FormatTo("{0:0.0000}") + "," + this.ivts_PriceDown.FormatTo("{0:0.0000}") + "," + this.ivts_PriceDownVat.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryQty.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryPriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.ivts_InventoryPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustQty.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.ivts_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossQty.FormatTo("{0:0.0000}") + "," + this.ivts_LossCostAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossPriceAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossPriceVatAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossPriceCostSumAmt.FormatTo("{0:0.0000}") + "," + this.ivts_LossPriceCostVatAmt.FormatTo("{0:0.0000}") + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.ivts_YyyyMm, (object) this.ivts_Day, (object) this.ivts_StoreCode, (object) this.ivts_GoodsCode, (object) this.ivts_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TInventorySummary tinventorySummary = this;
      // ISSUE: reference to a compiler-generated method
      tinventorySummary.\u003C\u003En__0();
      if (await tinventorySummary.OleDB.ExecuteAsync(tinventorySummary.InsertQuery()))
        return true;
      tinventorySummary.message = " " + tinventorySummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventorySummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventorySummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tinventorySummary.ivts_YyyyMm, (object) tinventorySummary.ivts_Day, (object) tinventorySummary.ivts_StoreCode, (object) tinventorySummary.ivts_GoodsCode, (object) tinventorySummary.ivts_SiteID) + " 내용 : " + tinventorySummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventorySummary.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1},{2}={3},{4}={5}", (object) "ivts_Supplier", (object) this.ivts_Supplier, (object) "ivts_SupplierType", (object) this.ivts_SupplierType, (object) "ivts_CategoryCode", (object) this.ivts_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ivts_TaxDiv", (object) this.ivts_TaxDiv, (object) "ivts_StockUnit", (object) this.ivts_StockUnit, (object) "ivts_SalesUnit", (object) this.ivts_SalesUnit) + ",ivts_BaseQty=" + this.ivts_BaseQty.FormatTo("{0:0.0000}") + ",ivts_BaseAvgCost=" + this.ivts_BaseAvgCost.FormatTo("{0:0.0000}") + ",ivts_BaseCostAmt=" + this.ivts_BaseCostAmt.FormatTo("{0:0.0000}") + ",ivts_BaseCostVatAmt=" + this.ivts_BaseCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BasePrice=" + this.ivts_BasePrice.FormatTo("{0:0.0000}") + ",ivts_BasePriceCostAmt=" + this.ivts_BasePriceCostAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceCostVatAmt=" + this.ivts_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceAmt=" + this.ivts_BasePriceAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceVatAmt=" + this.ivts_BasePriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndQty=" + this.ivts_EndQty.FormatTo("{0:0.0000}") + ",ivts_EndAvgCost=" + this.ivts_EndAvgCost.FormatTo("{0:0.0000}") + ",ivts_EndCostAmt=" + this.ivts_EndCostAmt.FormatTo("{0:0.0000}") + ",ivts_EndCostVatAmt=" + this.ivts_EndCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndPrice=" + this.ivts_EndPrice.FormatTo("{0:0.0000}") + ",ivts_EndPriceCostAmt=" + this.ivts_EndPriceCostAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceCostVatAmt=" + this.ivts_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceAmt=" + this.ivts_EndPriceAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceVatAmt=" + this.ivts_EndPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_SaleQty=" + this.ivts_SaleQty.FormatTo("{0:0.0000}") + ",ivts_TotalSaleAmt=" + this.ivts_TotalSaleAmt.FormatTo("{0:0.0000}") + ",ivts_SaleAmt=" + this.ivts_SaleAmt.FormatTo("{0:0.0000}") + ",ivts_SaleVatAmt=" + this.ivts_SaleVatAmt.FormatTo("{0:0.0000}") + ",ivts_SaleProfit=" + this.ivts_SaleProfit.FormatTo("{0:0.0000}") + ",ivts_SalePriceProfit=" + this.ivts_SalePriceProfit.FormatTo("{0:0.0000}") + ",ivts_EnurySlip=" + this.ivts_EnurySlip.FormatTo("{0:0.0000}") + ",ivts_EnuryEnd=" + this.ivts_EnuryEnd.FormatTo("{0:0.0000}") + ",ivts_DcAmtManual=" + this.ivts_DcAmtManual.FormatTo("{0:0.0000}") + ",ivts_DcAmtEvent=" + this.ivts_DcAmtEvent.FormatTo("{0:0.0000}") + ",ivts_DcAmtGoods=" + this.ivts_DcAmtGoods.FormatTo("{0:0.0000}") + ",ivts_DcAmtCoupon=" + this.ivts_DcAmtCoupon.FormatTo("{0:0.0000}") + ",ivts_DcAmtPromotion=" + this.ivts_DcAmtPromotion.FormatTo("{0:0.0000}") + ",ivts_DcAmtMember=" + this.ivts_DcAmtMember.FormatTo("{0:0.0000}") + ",ivts_Customer=" + this.ivts_Customer.FormatTo("{0:0.0000}") + ",ivts_CustomerGoods=" + this.ivts_CustomerGoods.FormatTo("{0:0.0000}") + ",ivts_CustomerCategory=" + this.ivts_CustomerCategory.FormatTo("{0:0.0000}") + ",ivts_CustomerSupplier=" + this.ivts_CustomerSupplier.FormatTo("{0:0.0000}") + ",ivts_BuyQty=" + this.ivts_BuyQty.FormatTo("{0:0.0000}") + ",ivts_BuyCostAmt=" + this.ivts_BuyCostAmt.FormatTo("{0:0.0000}") + ",ivts_BuyCostVatAmt=" + this.ivts_BuyCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BuyPriceAmt=" + this.ivts_BuyPriceAmt.FormatTo("{0:0.0000}") + ",ivts_BuyPriceVatAmt=" + this.ivts_BuyPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnQty=" + this.ivts_ReturnQty.FormatTo("{0:0.0000}") + ",ivts_ReturnCostAmt=" + this.ivts_ReturnCostAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnCostVatAmt=" + this.ivts_ReturnCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnPriceAmt=" + this.ivts_ReturnPriceAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnPriceVatAmt=" + this.ivts_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutQty=" + this.ivts_InnerMoveOutQty.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutCostAmt=" + this.ivts_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutCostVatAmt=" + this.ivts_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutPriceAmt=" + this.ivts_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutPriceVatAmt=" + this.ivts_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInQty=" + this.ivts_InnerMoveInQty.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInCostAmt=" + this.ivts_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInCostVatAmt=" + this.ivts_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInPriceAmt=" + this.ivts_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInPriceVatAmt=" + this.ivts_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutQty=" + this.ivts_OuterMoveOutQty.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutCostAmt=" + this.ivts_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutCostVatAmt=" + this.ivts_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutPriceAmt=" + this.ivts_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutPriceVatAmt=" + this.ivts_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInQty=" + this.ivts_OuterMoveInQty.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInCostAmt=" + this.ivts_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInCostVatAmt=" + this.ivts_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInPriceAmt=" + this.ivts_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInPriceVatAmt=" + this.ivts_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustQty=" + this.ivts_PreAdjustQty.FormatTo("{0:0.0000}") + ",ivts_PreAdjustCostAmt=" + this.ivts_PreAdjustCostAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustCostVatAmt=" + this.ivts_PreAdjustCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceAmt=" + this.ivts_PreAdjustPriceAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceVatAmt=" + this.ivts_PreAdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceCostSumAmt=" + this.ivts_PreAdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceCostVatAmt=" + this.ivts_PreAdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisuseQty=" + this.ivts_DisuseQty.FormatTo("{0:0.0000}") + ",ivts_DisuseCostAmt=" + this.ivts_DisuseCostAmt.FormatTo("{0:0.0000}") + ",ivts_DisuseCostVatAmt=" + this.ivts_DisuseCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceAmt=" + this.ivts_DisusePriceAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceVatAmt=" + this.ivts_DisusePriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceCostSumAmt=" + this.ivts_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceCostVatAmt=" + this.ivts_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_PriceUp=" + this.ivts_PriceUp.FormatTo("{0:0.0000}") + ",ivts_PriceUpVat=" + this.ivts_PriceUpVat.FormatTo("{0:0.0000}") + ",ivts_PriceDown=" + this.ivts_PriceDown.FormatTo("{0:0.0000}") + ",ivts_PriceDownVat=" + this.ivts_PriceDownVat.FormatTo("{0:0.0000}") + ",ivts_InventoryQty=" + this.ivts_InventoryQty.FormatTo("{0:0.0000}") + ",ivts_InventoryCostAmt=" + this.ivts_InventoryCostAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryCostVatAmt=" + this.ivts_InventoryCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceAmt=" + this.ivts_InventoryPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceVatAmt=" + this.ivts_InventoryPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceCostSumAmt=" + this.ivts_InventoryPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceCostVatAmt=" + this.ivts_InventoryPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustQty=" + this.ivts_AdjustQty.FormatTo("{0:0.0000}") + ",ivts_AdjustCostAmt=" + this.ivts_AdjustCostAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustCostVatAmt=" + this.ivts_AdjustCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceAmt=" + this.ivts_AdjustPriceAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceVatAmt=" + this.ivts_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceCostSumAmt=" + this.ivts_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceCostVatAmt=" + this.ivts_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossQty=" + this.ivts_LossQty.FormatTo("{0:0.0000}") + ",ivts_LossCostAmt=" + this.ivts_LossCostAmt.FormatTo("{0:0.0000}") + ",ivts_LossCostVatAmt=" + this.ivts_LossCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceAmt=" + this.ivts_LossPriceAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceVatAmt=" + this.ivts_LossPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceCostSumAmt=" + this.ivts_LossPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceCostVatAmt=" + this.ivts_LossPriceCostVatAmt.FormatTo("{0:0.0000}") + string.Format(" WHERE {0}={1}", (object) "ivts_YyyyMm", (object) this.ivts_YyyyMm) + string.Format(" AND {0}={1}", (object) "ivts_Day", (object) this.ivts_Day) + string.Format(" AND {0}={1}", (object) "ivts_StoreCode", (object) this.ivts_StoreCode) + string.Format(" AND {0}={1}", (object) "ivts_GoodsCode", (object) this.ivts_GoodsCode) + string.Format(" AND {0}={1}", (object) "ivts_SiteID", (object) this.ivts_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.ivts_YyyyMm, (object) this.ivts_Day, (object) this.ivts_StoreCode, (object) this.ivts_GoodsCode, (object) this.ivts_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TInventorySummary tinventorySummary = this;
      // ISSUE: reference to a compiler-generated method
      tinventorySummary.\u003C\u003En__1();
      if (await tinventorySummary.OleDB.ExecuteAsync(tinventorySummary.UpdateQuery()))
        return true;
      tinventorySummary.message = " " + tinventorySummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventorySummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventorySummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tinventorySummary.ivts_YyyyMm, (object) tinventorySummary.ivts_Day, (object) tinventorySummary.ivts_StoreCode, (object) tinventorySummary.ivts_GoodsCode, (object) tinventorySummary.ivts_SiteID) + " 내용 : " + tinventorySummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventorySummary.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3},{4}={5}", (object) "ivts_Supplier", (object) this.ivts_Supplier, (object) "ivts_SupplierType", (object) this.ivts_SupplierType, (object) "ivts_CategoryCode", (object) this.ivts_CategoryCode) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ivts_TaxDiv", (object) this.ivts_TaxDiv, (object) "ivts_StockUnit", (object) this.ivts_StockUnit, (object) "ivts_SalesUnit", (object) this.ivts_SalesUnit) + ",ivts_BaseQty=" + this.ivts_BaseQty.FormatTo("{0:0.0000}") + ",ivts_BaseAvgCost=" + this.ivts_BaseAvgCost.FormatTo("{0:0.0000}") + ",ivts_BaseCostAmt=" + this.ivts_BaseCostAmt.FormatTo("{0:0.0000}") + ",ivts_BaseCostVatAmt=" + this.ivts_BaseCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BasePrice=" + this.ivts_BasePrice.FormatTo("{0:0.0000}") + ",ivts_BasePriceCostAmt=" + this.ivts_BasePriceCostAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceCostVatAmt=" + this.ivts_BasePriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceAmt=" + this.ivts_BasePriceAmt.FormatTo("{0:0.0000}") + ",ivts_BasePriceVatAmt=" + this.ivts_BasePriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndQty=" + this.ivts_EndQty.FormatTo("{0:0.0000}") + ",ivts_EndAvgCost=" + this.ivts_EndAvgCost.FormatTo("{0:0.0000}") + ",ivts_EndCostAmt=" + this.ivts_EndCostAmt.FormatTo("{0:0.0000}") + ",ivts_EndCostVatAmt=" + this.ivts_EndCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndPrice=" + this.ivts_EndPrice.FormatTo("{0:0.0000}") + ",ivts_EndPriceCostAmt=" + this.ivts_EndPriceCostAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceCostVatAmt=" + this.ivts_EndPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceAmt=" + this.ivts_EndPriceAmt.FormatTo("{0:0.0000}") + ",ivts_EndPriceVatAmt=" + this.ivts_EndPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_SaleQty=" + this.ivts_SaleQty.FormatTo("{0:0.0000}") + ",ivts_TotalSaleAmt=" + this.ivts_TotalSaleAmt.FormatTo("{0:0.0000}") + ",ivts_SaleAmt=" + this.ivts_SaleAmt.FormatTo("{0:0.0000}") + ",ivts_SaleVatAmt=" + this.ivts_SaleVatAmt.FormatTo("{0:0.0000}") + ",ivts_SaleProfit=" + this.ivts_SaleProfit.FormatTo("{0:0.0000}") + ",ivts_SalePriceProfit=" + this.ivts_SalePriceProfit.FormatTo("{0:0.0000}") + ",ivts_EnurySlip=" + this.ivts_EnurySlip.FormatTo("{0:0.0000}") + ",ivts_EnuryEnd=" + this.ivts_EnuryEnd.FormatTo("{0:0.0000}") + ",ivts_DcAmtManual=" + this.ivts_DcAmtManual.FormatTo("{0:0.0000}") + ",ivts_DcAmtEvent=" + this.ivts_DcAmtEvent.FormatTo("{0:0.0000}") + ",ivts_DcAmtGoods=" + this.ivts_DcAmtGoods.FormatTo("{0:0.0000}") + ",ivts_DcAmtCoupon=" + this.ivts_DcAmtCoupon.FormatTo("{0:0.0000}") + ",ivts_DcAmtPromotion=" + this.ivts_DcAmtPromotion.FormatTo("{0:0.0000}") + ",ivts_DcAmtMember=" + this.ivts_DcAmtMember.FormatTo("{0:0.0000}") + ",ivts_Customer=" + this.ivts_Customer.FormatTo("{0:0.0000}") + ",ivts_CustomerGoods=" + this.ivts_CustomerGoods.FormatTo("{0:0.0000}") + ",ivts_CustomerCategory=" + this.ivts_CustomerCategory.FormatTo("{0:0.0000}") + ",ivts_CustomerSupplier=" + this.ivts_CustomerSupplier.FormatTo("{0:0.0000}") + ",ivts_BuyQty=" + this.ivts_BuyQty.FormatTo("{0:0.0000}") + ",ivts_BuyCostAmt=" + this.ivts_BuyCostAmt.FormatTo("{0:0.0000}") + ",ivts_BuyCostVatAmt=" + this.ivts_BuyCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_BuyPriceAmt=" + this.ivts_BuyPriceAmt.FormatTo("{0:0.0000}") + ",ivts_BuyPriceVatAmt=" + this.ivts_BuyPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnQty=" + this.ivts_ReturnQty.FormatTo("{0:0.0000}") + ",ivts_ReturnCostAmt=" + this.ivts_ReturnCostAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnCostVatAmt=" + this.ivts_ReturnCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnPriceAmt=" + this.ivts_ReturnPriceAmt.FormatTo("{0:0.0000}") + ",ivts_ReturnPriceVatAmt=" + this.ivts_ReturnPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutQty=" + this.ivts_InnerMoveOutQty.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutCostAmt=" + this.ivts_InnerMoveOutCostAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutCostVatAmt=" + this.ivts_InnerMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutPriceAmt=" + this.ivts_InnerMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveOutPriceVatAmt=" + this.ivts_InnerMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInQty=" + this.ivts_InnerMoveInQty.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInCostAmt=" + this.ivts_InnerMoveInCostAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInCostVatAmt=" + this.ivts_InnerMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInPriceAmt=" + this.ivts_InnerMoveInPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InnerMoveInPriceVatAmt=" + this.ivts_InnerMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutQty=" + this.ivts_OuterMoveOutQty.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutCostAmt=" + this.ivts_OuterMoveOutCostAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutCostVatAmt=" + this.ivts_OuterMoveOutCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutPriceAmt=" + this.ivts_OuterMoveOutPriceAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveOutPriceVatAmt=" + this.ivts_OuterMoveOutPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInQty=" + this.ivts_OuterMoveInQty.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInCostAmt=" + this.ivts_OuterMoveInCostAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInCostVatAmt=" + this.ivts_OuterMoveInCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInPriceAmt=" + this.ivts_OuterMoveInPriceAmt.FormatTo("{0:0.0000}") + ",ivts_OuterMoveInPriceVatAmt=" + this.ivts_OuterMoveInPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustQty=" + this.ivts_PreAdjustQty.FormatTo("{0:0.0000}") + ",ivts_PreAdjustCostAmt=" + this.ivts_PreAdjustCostAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustCostVatAmt=" + this.ivts_PreAdjustCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceAmt=" + this.ivts_PreAdjustPriceAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceVatAmt=" + this.ivts_PreAdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceCostSumAmt=" + this.ivts_PreAdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_PreAdjustPriceCostVatAmt=" + this.ivts_PreAdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisuseQty=" + this.ivts_DisuseQty.FormatTo("{0:0.0000}") + ",ivts_DisuseCostAmt=" + this.ivts_DisuseCostAmt.FormatTo("{0:0.0000}") + ",ivts_DisuseCostVatAmt=" + this.ivts_DisuseCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceAmt=" + this.ivts_DisusePriceAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceVatAmt=" + this.ivts_DisusePriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceCostSumAmt=" + this.ivts_DisusePriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_DisusePriceCostVatAmt=" + this.ivts_DisusePriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_PriceUp=" + this.ivts_PriceUp.FormatTo("{0:0.0000}") + ",ivts_PriceUpVat=" + this.ivts_PriceUpVat.FormatTo("{0:0.0000}") + ",ivts_PriceDown=" + this.ivts_PriceDown.FormatTo("{0:0.0000}") + ",ivts_PriceDownVat=" + this.ivts_PriceDownVat.FormatTo("{0:0.0000}") + ",ivts_InventoryQty=" + this.ivts_InventoryQty.FormatTo("{0:0.0000}") + ",ivts_InventoryCostAmt=" + this.ivts_InventoryCostAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryCostVatAmt=" + this.ivts_InventoryCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceAmt=" + this.ivts_InventoryPriceAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceVatAmt=" + this.ivts_InventoryPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceCostSumAmt=" + this.ivts_InventoryPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_InventoryPriceCostVatAmt=" + this.ivts_InventoryPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustQty=" + this.ivts_AdjustQty.FormatTo("{0:0.0000}") + ",ivts_AdjustCostAmt=" + this.ivts_AdjustCostAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustCostVatAmt=" + this.ivts_AdjustCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceAmt=" + this.ivts_AdjustPriceAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceVatAmt=" + this.ivts_AdjustPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceCostSumAmt=" + this.ivts_AdjustPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_AdjustPriceCostVatAmt=" + this.ivts_AdjustPriceCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossQty=" + this.ivts_LossQty.FormatTo("{0:0.0000}") + ",ivts_LossCostAmt=" + this.ivts_LossCostAmt.FormatTo("{0:0.0000}") + ",ivts_LossCostVatAmt=" + this.ivts_LossCostVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceAmt=" + this.ivts_LossPriceAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceVatAmt=" + this.ivts_LossPriceVatAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceCostSumAmt=" + this.ivts_LossPriceCostSumAmt.FormatTo("{0:0.0000}") + ",ivts_LossPriceCostVatAmt=" + this.ivts_LossPriceCostVatAmt.FormatTo("{0:0.0000}"));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.ivts_YyyyMm, (object) this.ivts_Day, (object) this.ivts_StoreCode, (object) this.ivts_GoodsCode, (object) this.ivts_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TInventorySummary tinventorySummary = this;
      // ISSUE: reference to a compiler-generated method
      tinventorySummary.\u003C\u003En__1();
      if (await tinventorySummary.OleDB.ExecuteAsync(tinventorySummary.UpdateExInsertQuery()))
        return true;
      tinventorySummary.message = " " + tinventorySummary.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventorySummary.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventorySummary.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tinventorySummary.ivts_YyyyMm, (object) tinventorySummary.ivts_Day, (object) tinventorySummary.ivts_StoreCode, (object) tinventorySummary.ivts_GoodsCode, (object) tinventorySummary.ivts_SiteID) + " 내용 : " + tinventorySummary.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventorySummary.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ivts_SiteID") && Convert.ToInt64(hashtable[(object) "ivts_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ivts_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ivts_YyyyMm") && Convert.ToInt32(hashtable[(object) "ivts_YyyyMm"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_YyyyMm", hashtable[(object) "ivts_YyyyMm"]));
        if (hashtable.ContainsKey((object) "ivts_YyyyMm_BEGIN_") && Convert.ToInt32(hashtable[(object) "ivts_YyyyMm_BEGIN_"].ToString()) > 0 && hashtable.ContainsKey((object) "ivts_YyyyMm_END_") && Convert.ToInt32(hashtable[(object) "ivts_YyyyMm_END_"].ToString()) > 0)
        {
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "ivts_YyyyMm", hashtable[(object) "ivts_YyyyMm_BEGIN_"]));
          stringBuilder.Append(string.Format(" AND {0}<={1}", (object) "ivts_YyyyMm", hashtable[(object) "ivts_YyyyMm_END_"]));
        }
        if (hashtable.ContainsKey((object) "ivts_Day") && Convert.ToInt32(hashtable[(object) "ivts_Day"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Day", hashtable[(object) "ivts_Day"]));
        if (hashtable.ContainsKey((object) "_DT_DATE_"))
        {
          DateTime dateTime = (DateTime) hashtable[(object) "_DT_DATE_"];
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_YyyyMm", (object) (dateTime.Year * 100 + dateTime.Month)));
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Day", (object) dateTime.Day));
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "ivts_StoreCode") && Convert.ToInt32(hashtable[(object) "ivts_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StoreCode", hashtable[(object) "ivts_StoreCode"]));
        else if (hashtable.ContainsKey((object) "ivts_StoreCode_IN_") && hashtable[(object) "ivts_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_StoreCode", hashtable[(object) "ivts_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gd_GoodsCode") && Convert.ToInt64(hashtable[(object) "gd_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_GoodsCode", hashtable[(object) "gd_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "gd_GoodsCode_IN_") && hashtable[(object) "gd_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_GoodsCode", hashtable[(object) "gd_GoodsCode_IN_"]));
        else if (hashtable.ContainsKey((object) "ivts_GoodsCode") && Convert.ToInt64(hashtable[(object) "ivts_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_GoodsCode", hashtable[(object) "ivts_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "ivts_GoodsCode_IN_") && hashtable[(object) "ivts_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_GoodsCode", hashtable[(object) "ivts_GoodsCode_IN_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "ivts_Supplier") && Convert.ToInt32(hashtable[(object) "ivts_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Supplier", hashtable[(object) "ivts_Supplier"]));
        else if (hashtable.ContainsKey((object) "ivts_Supplier_IN_") && hashtable[(object) "ivts_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_Supplier", hashtable[(object) "ivts_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ivts_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_Supplier", hashtable[(object) "su_SupplierType"]));
        else if (hashtable.ContainsKey((object) "ivts_SupplierType") && Convert.ToInt32(hashtable[(object) "ivts_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_SupplierType", hashtable[(object) "ivts_SupplierType"]));
        if (hashtable.ContainsKey((object) "ivts_CategoryCode") && Convert.ToInt32(hashtable[(object) "ivts_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_CategoryCode", hashtable[(object) "ivts_CategoryCode"]));
        if (hashtable.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(hashtable[(object) "gd_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_TaxDiv", hashtable[(object) "gd_TaxDiv"]));
        else if (hashtable.ContainsKey((object) "ivts_TaxDiv") && Convert.ToInt32(hashtable[(object) "ivts_TaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_TaxDiv", hashtable[(object) "ivts_TaxDiv"]));
        if (hashtable.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(hashtable[(object) "gd_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StockUnit", hashtable[(object) "gd_StockUnit"]));
        else if (hashtable.ContainsKey((object) "ivts_StockUnit") && Convert.ToInt32(hashtable[(object) "ivts_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_StockUnit", hashtable[(object) "ivts_StockUnit"]));
        if (hashtable.ContainsKey((object) "gd_SalesUnit") && Convert.ToInt32(hashtable[(object) "gd_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_SalesUnit", hashtable[(object) "gd_SalesUnit"]));
        else if (hashtable.ContainsKey((object) "ivts_SalesUnit") && Convert.ToInt32(hashtable[(object) "ivts_SalesUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ivts_SalesUnit", hashtable[(object) "ivts_SalesUnit"]));
        if (hashtable.ContainsKey((object) "_IS_NOT_DATA_VALUE_ZERO_") && Convert.ToBoolean(hashtable[(object) "_IS_NOT_DATA_VALUE_ZERO_"].ToString()))
          stringBuilder.Append(" AND (ivts_InventoryQty!=0 OR ivts_InventoryCostAmt!=0 OR ivts_InventoryCostVatAmt!=0 OR ivts_InventoryPriceAmt!=0 OR ivts_InventoryPriceVatAmt!=0)");
        if (hashtable.ContainsKey((object) "ivts_AdjustQty_IS_NOT_DATA_VALUE_ZERO_") && Convert.ToBoolean(hashtable[(object) "ivts_AdjustQty_IS_NOT_DATA_VALUE_ZERO_"].ToString()))
          stringBuilder.Append(" AND ivts_AdjustQty != 0");
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
        stringBuilder.Append(" SELECT  ivts_YyyyMm,ivts_Day,ivts_StoreCode,ivts_GoodsCode,ivts_SiteID,ivts_Supplier,ivts_SupplierType,ivts_CategoryCode,ivts_TaxDiv,ivts_StockUnit,ivts_SalesUnit,ivts_BaseQty,ivts_BaseAvgCost,ivts_BaseCostAmt,ivts_BaseCostVatAmt,ivts_BasePrice,ivts_BasePriceCostAmt,ivts_BasePriceCostVatAmt,ivts_BasePriceAmt,ivts_BasePriceVatAmt,ivts_EndQty,ivts_EndAvgCost,ivts_EndCostAmt,ivts_EndCostVatAmt,ivts_EndPrice,ivts_EndPriceCostAmt,ivts_EndPriceCostVatAmt,ivts_EndPriceAmt,ivts_EndPriceVatAmt,ivts_SaleQty,ivts_TotalSaleAmt,ivts_SaleAmt,ivts_SaleVatAmt,ivts_SaleProfit,ivts_SalePriceProfit,ivts_EnurySlip,ivts_EnuryEnd,ivts_DcAmtManual,ivts_DcAmtEvent,ivts_DcAmtGoods,ivts_DcAmtCoupon,ivts_DcAmtPromotion,ivts_DcAmtMember,ivts_Customer,ivts_CustomerGoods,ivts_CustomerCategory,ivts_CustomerSupplier,ivts_BuyQty,ivts_BuyCostAmt,ivts_BuyCostVatAmt,ivts_BuyPriceAmt,ivts_BuyPriceVatAmt,ivts_ReturnQty,ivts_ReturnCostAmt,ivts_ReturnCostVatAmt,ivts_ReturnPriceAmt,ivts_ReturnPriceVatAmt,ivts_InnerMoveOutQty,ivts_InnerMoveOutCostAmt,ivts_InnerMoveOutCostVatAmt,ivts_InnerMoveOutPriceAmt,ivts_InnerMoveOutPriceVatAmt,ivts_InnerMoveInQty,ivts_InnerMoveInCostAmt,ivts_InnerMoveInCostVatAmt,ivts_InnerMoveInPriceAmt,ivts_InnerMoveInPriceVatAmt,ivts_OuterMoveOutQty,ivts_OuterMoveOutCostAmt,ivts_OuterMoveOutCostVatAmt,ivts_OuterMoveOutPriceAmt,ivts_OuterMoveOutPriceVatAmt,ivts_OuterMoveInQty,ivts_OuterMoveInCostAmt,ivts_OuterMoveInCostVatAmt,ivts_OuterMoveInPriceAmt,ivts_OuterMoveInPriceVatAmt,ivts_PreAdjustQty,ivts_PreAdjustCostAmt,ivts_PreAdjustCostVatAmt,ivts_PreAdjustPriceAmt,ivts_PreAdjustPriceVatAmt,ivts_PreAdjustPriceCostSumAmt,ivts_PreAdjustPriceCostVatAmt,ivts_DisuseQty,ivts_DisuseCostAmt,ivts_DisuseCostVatAmt,ivts_DisusePriceAmt,ivts_DisusePriceVatAmt,ivts_DisusePriceCostSumAmt,ivts_DisusePriceCostVatAmt,ivts_PriceUp,ivts_PriceUpVat,ivts_PriceDown,ivts_PriceDownVat,ivts_InventoryQty,ivts_InventoryCostAmt,ivts_InventoryCostVatAmt,ivts_InventoryPriceAmt,ivts_InventoryPriceVatAmt,ivts_InventoryPriceCostSumAmt,ivts_InventoryPriceCostVatAmt,ivts_AdjustQty,ivts_AdjustCostAmt,ivts_AdjustCostVatAmt,ivts_AdjustPriceAmt,ivts_AdjustPriceVatAmt,ivts_AdjustPriceCostSumAmt,ivts_AdjustPriceCostVatAmt,ivts_LossQty,ivts_LossCostAmt,ivts_LossCostVatAmt,ivts_LossPriceAmt,ivts_LossPriceVatAmt,ivts_LossPriceCostSumAmt,ivts_LossPriceCostVatAmt");
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_GoodsCode"))
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
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ivts_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ivts_StoreCode_IN_"))
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
          if (dictionaryEntry.Key.ToString().Equals("ivts_GoodsCode"))
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
