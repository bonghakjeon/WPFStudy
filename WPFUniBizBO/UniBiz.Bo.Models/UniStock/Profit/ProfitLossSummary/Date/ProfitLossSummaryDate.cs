// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date.ProfitLossSummaryDate
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date
{
  public class ProfitLossSummaryDate : TProfitLossSummary<ProfitLossSummaryDate>
  {
    private int _rowDataType;
    private int _pls_Days;
    private double _pls_CalcQty;
    private double _pls_CalcCostAmt;
    private double _pls_CalcCostVatAmt;
    private double _pls_CalcPriceAmt;
    private double _pls_CalcPriceVatAmt;
    private double _pls_CalcPriceCostAmt;
    private double _pls_CalcPriceCostVatAmt;
    [JsonIgnore]
    public const string TBodyStartAmountTable = "기초 금액";
    [JsonIgnore]
    public const string TBodyMiddleAmountTable = "기중 금액";
    [JsonIgnore]
    public const string TBodyEndAmountTable = "기말 금액";
    [JsonIgnore]
    public const string TBodyEndGoodsPriceTable = "마지막수불단가";
    public static string TInnerMoveInSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,SUM(sd_BuyQty) AS pls_InnerMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TInnerMoveOutSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,SUM(sd_BuyQty) AS pls_InnerMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_InnerMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_InnerMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_InnerMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TOuterMoveInSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,SUM(sd_BuyQty) AS pls_OuterMoveInQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveInCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveInCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveInPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TOuterMoveOutSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,SUM(sd_BuyQty) AS pls_OuterMoveOutQty,SUM(sd_CostTaxAmt+sd_CostTaxFreeAmt) AS pls_OuterMoveOutCostAmt,SUM(sd_CostVatAmt) AS pls_OuterMoveOutCostVatAmt,SUM(sd_PriceTaxAmt+sd_PriceTaxFreeAmt) AS pls_OuterMoveOutPriceAmt,SUM(sd_PriceVatAmt) AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TAdjustSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,SUM(sd_BuyQty*sh_InOutDiv) AS pls_AdjustQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv) AS pls_AdjustCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv) AS pls_AdjustPriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv) AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,0 AS pls_DisuseQty,0 AS pls_DisuseCostAmt,0 AS pls_DisuseCostVatAmt,0 AS pls_DisusePriceAmt,0 AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";
    public static string TDisuseSumCol = ",0 AS pls_BaseQty,0 AS pls_BaseAvgCost,0 AS pls_BaseCostAmt,0 AS pls_BaseCostVatAmt,0 AS pls_BasePrice,0 AS pls_BasePriceCostAmt,0 AS pls_BasePriceCostVatAmt,0 AS pls_BasePriceAmt,0 AS pls_BasePriceVatAmt,0 AS pls_EndQty,0 AS pls_EndAvgCost,0 AS pls_EndCostAmt,0 AS pls_EndCostVatAmt,0 AS pls_EndPrice,0 AS pls_EndPriceCostAmt,0 AS pls_EndPriceCostVatAmt,0 AS pls_EndPriceAmt,0 AS pls_EndPriceVatAmt,0 AS pls_SaleQty,0 AS pls_TotalSaleAmt,0 AS pls_SaleAmt,0 AS pls_SaleVatAmt,0 AS pls_SaleProfit,0 AS pls_SalePriceProfit,0 AS pls_EnurySlip,0 AS pls_EnuryEnd,0 AS pls_DcAmtManual,0 AS pls_DcAmtEvent,0 AS pls_DcAmtGoods,0 AS pls_DcAmtCoupon,0 AS pls_DcAmtPromotion,0 AS pls_DcAmtMember,0 AS pls_Customer,0 AS pls_CustomerGoods,0 AS pls_CustomerCategory,0 AS pls_CustomerSupplier,0 AS pls_BuyQty,0 AS pls_BuyCostAmt,0 AS pls_BuyCostVatAmt,0 AS pls_BuyPriceAmt,0 AS pls_BuyPriceVatAmt,0 AS pls_ReturnQty,0 AS pls_ReturnCostAmt,0 AS pls_ReturnCostVatAmt,0 AS pls_ReturnPriceAmt,0 AS pls_ReturnPriceVatAmt,0 AS pls_InnerMoveOutQty,0 AS pls_InnerMoveOutCostAmt,0 AS pls_InnerMoveOutCostVatAmt,0 AS pls_InnerMoveOutPriceAmt,0 AS pls_InnerMoveOutPriceVatAmt,0 AS pls_InnerMoveInQty,0 AS pls_InnerMoveInCostAmt,0 AS pls_InnerMoveInCostVatAmt,0 AS pls_InnerMoveInPriceAmt,0 AS pls_InnerMoveInPriceVatAmt,0 AS pls_OuterMoveOutQty,0 AS pls_OuterMoveOutCostAmt,0 AS pls_OuterMoveOutCostVatAmt,0 AS pls_OuterMoveOutPriceAmt,0 AS pls_OuterMoveOutPriceVatAmt,0 AS pls_OuterMoveInQty,0 AS pls_OuterMoveInCostAmt,0 AS pls_OuterMoveInCostVatAmt,0 AS pls_OuterMoveInPriceAmt,0 AS pls_OuterMoveInPriceVatAmt,0 AS pls_AdjustQty,0 AS pls_AdjustCostAmt,0 AS pls_AdjustCostVatAmt,0 AS pls_AdjustPriceAmt,0 AS pls_AdjustPriceVatAmt,0 AS pls_AdjustPriceCostSumAmt,0 AS pls_AdjustPriceCostVatAmt,SUM(sd_BuyQty*sh_InOutDiv*-1) AS pls_DisuseQty,SUM((sd_CostTaxAmt+sd_CostTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisuseCostAmt,SUM(sd_CostVatAmt*sh_InOutDiv*-1) AS pls_DisuseCostVatAmt,SUM((sd_PriceTaxAmt+sd_PriceTaxFreeAmt)*sh_InOutDiv*-1) AS pls_DisusePriceAmt,SUM(sd_PriceVatAmt*sh_InOutDiv*-1) AS pls_DisusePriceVatAmt,0 AS pls_DisusePriceCostSumAmt,0 AS pls_DisusePriceCostVatAmt,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat";

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

    public int pls_Days
    {
      get => this._pls_Days;
      set
      {
        this._pls_Days = value;
        this.Changed(nameof (pls_Days));
      }
    }

    public double CalcTurnOverDay() => !this.CalcTurnOver().IsZero() ? NumberHelper.ToDiv((double) this.pls_Days, this.CalcTurnOver()) : 0.0;

    public double pls_CalcQty
    {
      get => this._pls_CalcQty;
      set
      {
        this._pls_CalcQty = value;
        this.Changed(nameof (pls_CalcQty));
      }
    }

    public double pls_CalcCostAmt
    {
      get => this._pls_CalcCostAmt;
      set
      {
        this._pls_CalcCostAmt = value;
        this.Changed(nameof (pls_CalcCostAmt));
      }
    }

    public double pls_CalcCostVatAmt
    {
      get => this._pls_CalcCostVatAmt;
      set
      {
        this._pls_CalcCostVatAmt = value;
        this.Changed(nameof (pls_CalcCostVatAmt));
      }
    }

    public double pls_CalcPriceAmt
    {
      get => this._pls_CalcPriceAmt;
      set
      {
        this._pls_CalcPriceAmt = value;
        this.Changed(nameof (pls_CalcPriceAmt));
        this.Changed("pls_CalcPriceTaxFreeAmt");
      }
    }

    public double pls_CalcPriceVatAmt
    {
      get => this._pls_CalcPriceVatAmt;
      set
      {
        this._pls_CalcPriceVatAmt = value;
        this.Changed(nameof (pls_CalcPriceVatAmt));
        this.Changed("pls_CalcPriceTaxFreeAmt");
      }
    }

    public double pls_CalcPriceTaxFreeAmt => this.pls_CalcPriceAmt - this.pls_CalcPriceVatAmt;

    public double pls_CalcPriceCostAmt
    {
      get => this._pls_CalcPriceCostAmt;
      set
      {
        this._pls_CalcPriceCostAmt = value;
        this.Changed(nameof (pls_CalcPriceCostAmt));
        this.Changed("pls_CalcPriceCostSumAmt");
      }
    }

    public double pls_CalcPriceCostVatAmt
    {
      get => this._pls_CalcPriceCostVatAmt;
      set
      {
        this._pls_CalcPriceCostVatAmt = value;
        this.Changed(nameof (pls_CalcPriceCostVatAmt));
        this.Changed("pls_CalcPriceCostSumAmt");
      }
    }

    public double pls_CalcPriceCostSumAmt => this.pls_CalcPriceCostAmt + this.pls_CalcPriceCostVatAmt;

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.pls_Days = 0;
      this.pls_CalcQty = this.pls_CalcCostAmt = this.pls_CalcCostVatAmt = 0.0;
      this.pls_CalcPriceAmt = this.pls_CalcPriceVatAmt = this.pls_CalcPriceCostAmt = this.pls_CalcPriceCostVatAmt = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryDate();

    public override object Clone()
    {
      ProfitLossSummaryDate profitLossSummaryDate = base.Clone() as ProfitLossSummaryDate;
      profitLossSummaryDate.rowDataType = this.rowDataType;
      profitLossSummaryDate.pls_Days = this.pls_Days;
      profitLossSummaryDate.pls_CalcQty = this.pls_CalcQty;
      profitLossSummaryDate.pls_CalcCostAmt = this.pls_CalcCostAmt;
      profitLossSummaryDate.pls_CalcCostVatAmt = this.pls_CalcCostVatAmt;
      profitLossSummaryDate.pls_CalcPriceAmt = this.pls_CalcPriceAmt;
      profitLossSummaryDate.pls_CalcPriceVatAmt = this.pls_CalcPriceVatAmt;
      profitLossSummaryDate.pls_CalcPriceCostAmt = this.pls_CalcPriceCostAmt;
      profitLossSummaryDate.pls_CalcPriceCostVatAmt = this.pls_CalcPriceCostVatAmt;
      return (object) profitLossSummaryDate;
    }

    public void PutData(ProfitLossSummaryDate pSource)
    {
      this.PutData((TProfitLossSummary) pSource);
      this.rowDataType = pSource.rowDataType;
      this.pls_Days = pSource.pls_Days;
      this.pls_CalcQty = pSource.pls_CalcQty;
      this.pls_CalcCostAmt = pSource.pls_CalcCostAmt;
      this.pls_CalcCostVatAmt = pSource.pls_CalcCostVatAmt;
      this.pls_CalcPriceAmt = pSource.pls_CalcPriceAmt;
      this.pls_CalcPriceVatAmt = pSource.pls_CalcPriceVatAmt;
      this.pls_CalcPriceCostAmt = pSource.pls_CalcPriceCostAmt;
      this.pls_CalcPriceCostVatAmt = pSource.pls_CalcPriceCostVatAmt;
    }

    public bool CalcAddSum(ProfitLossSummaryDate pSource)
    {
      if (pSource == null || !this.CalcAddSum((TProfitLossSummary) pSource))
        return false;
      this.pls_CalcQty += pSource.pls_CalcQty;
      this.pls_CalcCostAmt += pSource.pls_CalcCostAmt;
      this.pls_CalcCostVatAmt += pSource.pls_CalcCostVatAmt;
      this.pls_CalcPriceAmt += pSource.pls_CalcPriceAmt;
      this.pls_CalcPriceVatAmt += pSource.pls_CalcPriceVatAmt;
      this.pls_CalcPriceCostAmt += pSource.pls_CalcPriceCostAmt;
      this.pls_CalcPriceCostVatAmt += pSource.pls_CalcPriceCostVatAmt;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, ProfitLossSummaryDate pSource) => pSource == null || this.IsZero(pCheckType, (TProfitLossSummary) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.pls_CalcQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.pls_CalcCostAmt.IsZero() && pSource.pls_CalcCostVatAmt.IsZero() && pSource.pls_CalcPriceAmt.IsZero() && pSource.pls_CalcPriceVatAmt.IsZero() && pSource.pls_CalcPriceCostAmt.IsZero() && pSource.pls_CalcPriceCostVatAmt.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        return base.GetFieldValues(p_rs);
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public string ToWithWorkEndGoodsPriceQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,TBodyEndGoodsPriceTable AS (\nSELECT pls_StoreCode AS end_pls_StoreCode,pls_GoodsCode AS end_pls_GoodsCode,pls_SiteID AS end_pls_SiteID,pls_EndAvgCost AS end_pls_EndAvgCost,pls_EndPrice AS end_pls_EndPrice" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.ProfitLossSummary, (object) DbQueryHelper.ToWithNolock()));
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("pls_SiteID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
          {
            DateTime dateTime = (DateTime) dictionaryEntry.Value;
            p_param1.Add((object) "pls_YyyyMm", (object) (dateTime.Year * 100 + dateTime.Month));
          }
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
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

    public string GetProfitLossSummaryStartSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TProfitLossSummaryStartSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(pls_BaseQty) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) "pls_BaseCostAmt") + " ELSE pls_BaseQty*end_pls_EndAvgCost END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) "pls_BaseCostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) "pls_BaseQty", (object) "pls_EndAvgCost") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) "pls_BasePriceAmt") + " ELSE pls_BaseQty*end_pls_EndPrice END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) "pls_BasePriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) "pls_BaseQty", (object) "pls_EndPrice") + " END) AS pls_CalcPriceVatAmt\n,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      return stringBuilder.ToString();
    }

    public string GetProfitLossSummaryMiddleSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TProfitLossSummaryMiddleSumCol);
      if (p_IsLastDay)
      {
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      }
      else
      {
        string str1 = string.Format("{0}-{1}+{2}-{3}-{4}+{5}-{6}+{7}+{8}-{9}", (object) 0, (object) "pls_SaleQty", (object) "pls_BuyQty", (object) "pls_ReturnQty", (object) "pls_InnerMoveOutQty", (object) "pls_InnerMoveInQty", (object) "pls_OuterMoveOutQty", (object) "pls_OuterMoveInQty", (object) "pls_AdjustQty", (object) "pls_DisuseQty");
        string str2 = string.Format("{0}-({1}-{2}-{3})+{4}-{5}-{6}+{7}-{8}+{9}+{10}-{11}", (object) 0, (object) "pls_SaleAmt", (object) "pls_SaleVatAmt", (object) "pls_SaleProfit", (object) "pls_BuyCostAmt", (object) "pls_ReturnCostAmt", (object) "pls_InnerMoveOutCostAmt", (object) "pls_InnerMoveInCostAmt", (object) "pls_OuterMoveOutCostAmt", (object) "pls_OuterMoveInCostAmt", (object) "pls_AdjustCostAmt", (object) "pls_DisuseCostAmt");
        string str3 = string.Format("{0}-{1}+{2}-{3}-{4}+{5}-{6}+{7}+{8}-{9}", (object) 0, (object) "pls_SaleAmt", (object) "pls_BuyPriceAmt", (object) "pls_ReturnPriceAmt", (object) "pls_InnerMoveOutPriceAmt", (object) "pls_InnerMoveInPriceAmt", (object) "pls_OuterMoveOutPriceAmt", (object) "pls_OuterMoveInPriceAmt", (object) "pls_AdjustPriceAmt", (object) "pls_DisusePriceAmt");
        stringBuilder.Append("\n,SUM(" + str1 + ") AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) str2) + " ELSE (" + str1 + ")*end_pls_EndAvgCost END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "pls_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN ({2})*0.1 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) str2) + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN ({2})*end_{3}*0.1 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) str1, (object) "pls_EndAvgCost") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "pls_StockUnit", (object) 1, (object) str3) + " ELSE (" + str1 + ")*end_pls_EndPrice END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "pls_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN ({2})*10/110 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) str3) + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN ({2})*end_{3}*10/110 ELSE 0 END", (object) "pls_TaxDiv", (object) 1, (object) str1, (object) "pls_EndPrice") + " END) AS pls_CalcPriceVatAmt\n,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      }
      return stringBuilder.ToString();
    }

    public string GetProfitLossSummaryOnlyEndSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TProfitLossSummaryOnlyEndSumCol);
      if (p_IsLastDay)
        stringBuilder.Append("\n,SUM(pls_EndQty) AS pls_CalcQty,SUM(pls_EndCostAmt) AS pls_CalcCostAmt,SUM(pls_EndCostVatAmt) AS pls_CalcCostVatAmt,SUM(pls_EndPriceAmt) AS pls_CalcPriceAmt,SUM(pls_EndPriceVatAmt) AS pls_CalcPriceVatAmt,SUM(pls_EndPriceCostAmt) AS pls_CalcPriceCostAmt,SUM(pls_EndPriceCostVatAmt) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(pls_BaseQty) AS pls_CalcQty,SUM(pls_BaseCostAmt) AS pls_CalcCostAmt,SUM(pls_BaseCostVatAmt) AS pls_CalcCostVatAmt,SUM(pls_BasePriceAmt) AS pls_CalcPriceAmt,SUM(pls_BasePriceVatAmt) AS pls_CalcPriceVatAmt,SUM(pls_BasePriceCostAmt) AS pls_CalcPriceCostAmt,SUM(pls_BasePriceCostVatAmt) AS pls_CalcPriceCostVatAmt");
      return stringBuilder.ToString();
    }

    public string GetTSaleSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TSaleSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append(string.Format("\n,SUM({0} - {1}) AS {2}", (object) 0, (object) "sbd_SaleQty", (object) "pls_CalcQty") + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2} - {3}", (object) "sbd_StockUnit", (object) 1, (object) "sbd_SaleAmt", (object) "sbd_SaleVatAmt") + " ELSE sbd_SaleQty*end_pls_EndAvgCost END)) AS pls_CalcCostAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sbd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleQty", (object) "pls_EndAvgCost") + " END)) AS pls_CalcCostVatAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "sbd_StockUnit", (object) 1, (object) "sbd_SaleAmt") + " ELSE sbd_SaleQty*end_pls_EndPrice END)) AS pls_CalcPriceAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sbd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleQty", (object) "pls_EndPrice") + " END)) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTSaleLeaSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TSaleLeaSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append(string.Format("\n,SUM({0} - {1}) AS {2}", (object) 0, (object) "sbd_SaleQty", (object) "pls_CalcQty") + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2} - {3}", (object) "sbd_StockUnit", (object) 1, (object) "sbd_SaleAmt", (object) "sbd_SaleVatAmt") + " ELSE sbd_SaleQty*end_pls_EndAvgCost END)) AS pls_CalcCostAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sbd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleQty", (object) "pls_EndAvgCost") + " END)) AS pls_CalcCostVatAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}", (object) "sbd_StockUnit", (object) 1, (object) "sbd_SaleAmt") + " ELSE sbd_SaleQty*end_pls_EndPrice END)) AS pls_CalcPriceAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sbd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sbd_TaxDiv", (object) 1, (object) "sbd_SaleQty", (object) "pls_EndPrice") + " END)) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTBuySumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TBuySumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(sd_BuyQty) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTReturnSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(TProfitLossSummary.TReturnSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append(string.Format("\n,SUM({0} - {1}) AS {2}", (object) 0, (object) "sd_BuyQty", (object) "pls_CalcQty") + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END)) AS pls_CalcCostAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END)) AS pls_CalcCostVatAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END)) AS pls_CalcPriceAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END)) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTInnerMoveInSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TInnerMoveInSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(sd_BuyQty) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTInnerMoveOutSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TInnerMoveOutSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append(string.Format("\n,SUM({0} - {1}) AS {2}", (object) 0, (object) "sd_BuyQty", (object) "pls_CalcQty") + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END)) AS pls_CalcCostAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END)) AS pls_CalcCostVatAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END)) AS pls_CalcPriceAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END)) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTOuterMoveInSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TOuterMoveInSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(sd_BuyQty) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTOuterMoveOutSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TOuterMoveOutSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append(string.Format("\n,SUM({0} - {1}) AS {2}", (object) 0, (object) "sd_BuyQty", (object) "pls_CalcQty") + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndAvgCost END)) AS pls_CalcCostAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost") + " END)) AS pls_CalcCostVatAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN {2}+{3}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt") + " ELSE sd_BuyQty*end_pls_EndPrice END)) AS pls_CalcPriceAmt" + string.Format("\n,SUM({0} - (", (object) 0) + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110 ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice") + " END)) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTAdjustSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TAdjustSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(sd_BuyQty*sh_InOutDiv) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN 0", (object) "sd_StockUnit", (object) 1) + " ELSE sd_BuyQty*end_pls_EndAvgCost*sh_InOutDiv END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\t{0}", (object) 0) + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1*{4} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost", (object) "sh_InOutDiv") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN 0", (object) "sd_StockUnit", (object) 1) + " ELSE sd_BuyQty*end_pls_EndPrice*sh_InOutDiv END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\t{0}", (object) 0) + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110*{4} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice", (object) "sh_InOutDiv") + " END) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }

    public string GetTDisuseSumColSumCol(bool p_IsLastDay)
    {
      StringBuilder stringBuilder = new StringBuilder(ProfitLossSummaryDate.TDisuseSumCol);
      if (p_IsLastDay)
        stringBuilder.Append(",SUM(0) AS pls_CalcQty,SUM(0) AS pls_CalcCostAmt,SUM(0) AS pls_CalcCostVatAmt,SUM(0) AS pls_CalcPriceAmt,SUM(0) AS pls_CalcPriceVatAmt,SUM(0) AS pls_CalcPriceCostAmt,SUM(0) AS pls_CalcPriceCostVatAmt");
      else
        stringBuilder.Append("\n,SUM(sd_BuyQty*sh_InOutDiv) AS pls_CalcQty\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ({2}+{3})*{4}", (object) "sd_StockUnit", (object) 1, (object) "sd_CostTaxAmt", (object) "sd_CostTaxFreeAmt", (object) "sh_InOutDiv") + " ELSE sd_BuyQty*end_pls_EndAvgCost*sh_InOutDiv END) AS pls_CalcCostAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2}*{3} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_CostVatAmt", (object) "sh_InOutDiv") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*0.1*{4} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndAvgCost", (object) "sh_InOutDiv") + " END) AS pls_CalcCostVatAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ({2}+{3})*{4}", (object) "sd_StockUnit", (object) 1, (object) "sd_PriceTaxAmt", (object) "sd_PriceTaxFreeAmt", (object) "sh_InOutDiv") + " ELSE sd_BuyQty*end_pls_EndPrice*sh_InOutDiv END) AS pls_CalcPriceAmt\n,SUM(" + string.Format(" CASE {0} WHEN {1} THEN ", (object) "sd_StockUnit", (object) 1) + string.Format("\tCASE {0} WHEN {1} THEN {2}*{3} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_PriceVatAmt", (object) "sh_InOutDiv") + " ELSE " + string.Format("\tCASE {0} WHEN {1} THEN {2}*end_{3}*10/110*{4} ELSE 0 END", (object) "sd_TaxDiv", (object) 1, (object) "sd_BuyQty", (object) "pls_EndPrice", (object) "sh_InOutDiv") + " END) AS pls_CalcPriceVatAmt" + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostAmt") + string.Format(",SUM({0}) AS {1}", (object) 0, (object) "pls_CalcPriceCostVatAmt"));
      return stringBuilder.ToString();
    }
  }
}
