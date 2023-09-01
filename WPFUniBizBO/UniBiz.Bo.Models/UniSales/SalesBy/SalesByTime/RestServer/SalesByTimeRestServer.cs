// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.RestServer.SalesByTimeRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Vertical;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.RestServer
{
  [UbRestModel("/Sales/SalesByTime", TableCodeType.SalesByTime, HeaderPath = "")]
  public class SalesByTimeRestServer
  {
    public static UniBizHttpRequest<UbRes<IList<SalesByTimeView>>> GetSalesByTimeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbt_SiteID")] long sbt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_searchType")] int searchType = 0,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SalesByTimeView>>> salesByTimeList = new UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>(HttpMethod.Get);
      salesByTimeList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbt_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      salesByTimeList.Headers.Add("Send-Type", SendType);
      salesByTimeList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, long>((Expression<Func<long>>) (() => sbt_SiteID));
      salesByTimeList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      salesByTimeList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (searchType > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => searchType));
      salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbt_SaleDate > 0L)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (si_StoreCode > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        salesByTimeList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      salesByTimeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByTimeView>>>>(MethodBase.GetCurrentMethod());
      return salesByTimeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>> GetSaleByTimeDateStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>> timeDateStoreList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>(HttpMethod.Get);
      timeDateStoreList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      timeDateStoreList.Headers.Add("Send-Type", SendType);
      timeDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      timeDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      timeDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        timeDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      timeDateStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateStore>>>>(MethodBase.GetCurrentMethod());
      return timeDateStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>> GetSaleByTimeDateTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>> timeDateTeamList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>(HttpMethod.Get);
      timeDateTeamList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      timeDateTeamList.Headers.Add("Send-Type", SendType);
      timeDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      timeDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      timeDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        timeDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      timeDateTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateTeam>>>>(MethodBase.GetCurrentMethod());
      return timeDateTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>> GetSaleByTimeDateDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>> timeDateDeptList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>(HttpMethod.Get);
      timeDateDeptList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      timeDateDeptList.Headers.Add("Send-Type", SendType);
      timeDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      timeDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      timeDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        timeDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      timeDateDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateDept>>>>(MethodBase.GetCurrentMethod());
      return timeDateDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>> GetSaleByTimeDateCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>> dateCategoryTopList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>(HttpMethod.Get);
      dateCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryTopList.Headers.Add("Send-Type", SendType);
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>> GetSaleByTimeDateCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>> dateCategoryMidList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>(HttpMethod.Get);
      dateCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryMidList.Headers.Add("Send-Type", SendType);
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>> GetSaleByTimeDateCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>> dateCategoryBotList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>(HttpMethod.Get);
      dateCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryBotList.Headers.Add("Send-Type", SendType);
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>> GetSaleByTimeDateGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsCumulative")] bool isCumulative = false,
      [NameConvert("p_IsCompositionRatio")] bool isCompositionRatio = false,
      [NameConvert("p_IsDailyAverage")] bool isDailyAverage = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>> timeDateGoodsList = new UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>(HttpMethod.Get);
      timeDateGoodsList.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      timeDateGoodsList.Headers.Add("Send-Type", SendType);
      timeDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      timeDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      timeDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, bool>((Expression<Func<bool>>) (() => isCumulative));
      timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, bool>((Expression<Func<bool>>) (() => isCompositionRatio));
      timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, bool>((Expression<Func<bool>>) (() => isDailyAverage));
      if (sbt_SaleDate > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        timeDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      timeDateGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByTimeDateGoods>>>>(MethodBase.GetCurrentMethod());
      return timeDateGoodsList;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>> GetSaleByTimeDateVerticalStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>> verticalStorePack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>(HttpMethod.Get);
      verticalStorePack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalStorePack.Headers.Add("Send-Type", SendType);
      verticalStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalStore>>>(MethodBase.GetCurrentMethod());
      return verticalStorePack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>> GetSaleByTimeDateVerticalTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>> verticalTeamPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>(HttpMethod.Get);
      verticalTeamPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalTeamPack.Headers.Add("Send-Type", SendType);
      verticalTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>>(MethodBase.GetCurrentMethod());
      return verticalTeamPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>> GetSaleByTimeDateVerticalDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>> verticalDeptPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>(HttpMethod.Get);
      verticalDeptPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalDeptPack.Headers.Add("Send-Type", SendType);
      verticalDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalDept>>>(MethodBase.GetCurrentMethod());
      return verticalDeptPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> GetSaleByTimeDateVerticalCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> verticalCategoryTopPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>(HttpMethod.Get);
      verticalCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalCategoryTopPack.Headers.Add("Send-Type", SendType);
      verticalCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>>(MethodBase.GetCurrentMethod());
      return verticalCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> GetSaleByTimeDateVerticalCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> verticalCategoryMidPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>(HttpMethod.Get);
      verticalCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalCategoryMidPack.Headers.Add("Send-Type", SendType);
      verticalCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>>(MethodBase.GetCurrentMethod());
      return verticalCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> GetSaleByTimeDateVerticalCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>> verticalCategoryBotPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>(HttpMethod.Get);
      verticalCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalCategoryBotPack.Headers.Add("Send-Type", SendType);
      verticalCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalCategory>>>(MethodBase.GetCurrentMethod());
      return verticalCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>> GetSaleByTimeDateVerticalGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsTimeHour24")] bool isTimeHour24 = false,
      [NameConvert("p_sbt_SaleDate")] long sbt_SaleDate = 0,
      [NameConvert("p_sbt_SaleDateBegin")] long sbt_SaleDateBegin = 0,
      [NameConvert("p_sbt_SaleDateEnd")] long sbt_SaleDateEnd = 0,
      [NameConvert("p_sbt_SaleDateBefore")] long sbt_SaleDateBefore = 0,
      [NameConvert("p_sbt_SaleDateBeforeBegin")] long sbt_SaleDateBeforeBegin = 0,
      [NameConvert("p_sbt_SaleDateBeforeEnd")] long sbt_SaleDateBeforeEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>> verticalGoodsPack = new UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>(HttpMethod.Get);
      verticalGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByTimeRestServer>() + "/{sbd_SiteID}/Vertical/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalGoodsPack.Headers.Add("Send-Type", SendType);
      verticalGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, bool>((Expression<Func<bool>>) (() => isTimeHour24));
      if (sbt_SaleDate > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDate));
      if (sbt_SaleDateBegin > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBegin));
      if (sbt_SaleDateEnd > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDateEnd));
      if (sbt_SaleDateBefore > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBefore));
      if (sbt_SaleDateBeforeBegin > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeBegin));
      if (sbt_SaleDateBeforeEnd > 0L)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, long>((Expression<Func<long>>) (() => sbt_SaleDateBeforeEnd));
      if (si_StoreCode > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByTimeDateVerticalGoods>>>(MethodBase.GetCurrentMethod());
      return verticalGoodsPack;
    }
  }
}
