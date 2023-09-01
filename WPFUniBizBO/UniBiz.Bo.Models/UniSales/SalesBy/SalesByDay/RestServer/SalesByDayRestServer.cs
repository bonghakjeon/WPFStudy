// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.RestServer.SalesByDayRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.Supplier;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Vertical;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Diff;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.Supplier;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Vertical;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.RestServer
{
  [UbRestModel("/Sales/SalesByDay", TableCodeType.SalesByDay, HeaderPath = "")]
  public class SalesByDayRestServer
  {
    public static UniBizHttpRequest<UbRes<IList<SalesByDayView>>> GetSalesByDayList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_searchType")] int searchType = 0,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayView>>> salesByDayList = new UniBizHttpRequest<UbRes<IList<SalesByDayView>>>(HttpMethod.Get);
      salesByDayList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      salesByDayList.Headers.Add("Send-Type", SendType);
      salesByDayList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      salesByDayList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      salesByDayList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (searchType > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => searchType));
      salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        salesByDayList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      salesByDayList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayView>>>>(MethodBase.GetCurrentMethod());
      return salesByDayList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>> GetSaleByDayDateStoreBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>> dateStoreBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>(HttpMethod.Get);
      dateStoreBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Store/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateStoreBeforeList.Headers.Add("Send-Type", SendType);
      dateStoreBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateStoreBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateStoreBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateStoreBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateStoreBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateStoreBefore>>>>(MethodBase.GetCurrentMethod());
      return dateStoreBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>> GetSaleByDayDateTeamBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>> dateTeamBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>(HttpMethod.Get);
      dateTeamBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Team/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateTeamBeforeList.Headers.Add("Send-Type", SendType);
      dateTeamBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateTeamBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateTeamBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateTeamBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateTeamBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeamBefore>>>>(MethodBase.GetCurrentMethod());
      return dateTeamBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>> GetSaleByDayDateDeptBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>> dateDeptBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>(HttpMethod.Get);
      dateDeptBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Dept/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateDeptBeforeList.Headers.Add("Send-Type", SendType);
      dateDeptBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateDeptBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateDeptBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateDeptBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateDeptBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateDeptBefore>>>>(MethodBase.GetCurrentMethod());
      return dateDeptBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>> GetSaleByDayDateCategoryTopBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>> categoryTopBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>(HttpMethod.Get);
      categoryTopBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryTop/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      categoryTopBeforeList.Headers.Add("Send-Type", SendType);
      categoryTopBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      categoryTopBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      categoryTopBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        categoryTopBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      categoryTopBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTopBefore>>>>(MethodBase.GetCurrentMethod());
      return categoryTopBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>> GetSaleByDayDateCategoryMidBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>> categoryMidBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>(HttpMethod.Get);
      categoryMidBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryMid/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      categoryMidBeforeList.Headers.Add("Send-Type", SendType);
      categoryMidBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      categoryMidBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      categoryMidBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        categoryMidBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      categoryMidBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMidBefore>>>>(MethodBase.GetCurrentMethod());
      return categoryMidBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>> GetSaleByDayDateCategoryBotBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>> categoryBotBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>(HttpMethod.Get);
      categoryBotBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryBot/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      categoryBotBeforeList.Headers.Add("Send-Type", SendType);
      categoryBotBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      categoryBotBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      categoryBotBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        categoryBotBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      categoryBotBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBotBefore>>>>(MethodBase.GetCurrentMethod());
      return categoryBotBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>> GetSaleByDayDateGoodsBeforeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>> dateGoodsBeforeList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>(HttpMethod.Get);
      dateGoodsBeforeList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Goods/Before/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateGoodsBeforeList.Headers.Add("Send-Type", SendType);
      dateGoodsBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateGoodsBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateGoodsBeforeList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateGoodsBeforeList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateGoodsBeforeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoodsBefore>>>>(MethodBase.GetCurrentMethod());
      return dateGoodsBeforeList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>> GetSaleByDayDateStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>> dayDateStoreList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>(HttpMethod.Get);
      dayDateStoreList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dayDateStoreList.Headers.Add("Send-Type", SendType);
      dayDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dayDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dayDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dayDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dayDateStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateStore>>>>(MethodBase.GetCurrentMethod());
      return dayDateStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>> GetSaleByDayDateTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>> byDayDateTeamList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>(HttpMethod.Get);
      byDayDateTeamList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byDayDateTeamList.Headers.Add("Send-Type", SendType);
      byDayDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byDayDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byDayDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byDayDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      byDayDateTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateTeam>>>>(MethodBase.GetCurrentMethod());
      return byDayDateTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>> GetSaleByDayDateDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>> byDayDateDeptList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>(HttpMethod.Get);
      byDayDateDeptList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byDayDateDeptList.Headers.Add("Send-Type", SendType);
      byDayDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byDayDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byDayDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byDayDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      byDayDateDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateDept>>>>(MethodBase.GetCurrentMethod());
      return byDayDateDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>> GetSaleByDayDateCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>> dateCategoryTopList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>(HttpMethod.Get);
      dateCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryTopList.Headers.Add("Send-Type", SendType);
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>> GetSaleByDayDateCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>> dateCategoryMidList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>(HttpMethod.Get);
      dateCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryMidList.Headers.Add("Send-Type", SendType);
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>> GetSaleByDayDateCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>> dateCategoryBotList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>(HttpMethod.Get);
      dateCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryBotList.Headers.Add("Send-Type", SendType);
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>> GetSaleByDayDateGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>> dayDateGoodsList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>(HttpMethod.Get);
      dayDateGoodsList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dayDateGoodsList.Headers.Add("Send-Type", SendType);
      dayDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dayDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dayDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dayDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dayDateGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateGoods>>>>(MethodBase.GetCurrentMethod());
      return dayDateGoodsList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>> GetSaleByDayDiffStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>> dayDiffStoreList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>(HttpMethod.Get);
      dayDiffStoreList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dayDiffStoreList.Headers.Add("Send-Type", SendType);
      dayDiffStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dayDiffStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dayDiffStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isDay));
      dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dayDiffStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dayDiffStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffStore>>>>(MethodBase.GetCurrentMethod());
      return dayDiffStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>> GetSaleByDayDiffTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>> byDayDiffTeamList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>(HttpMethod.Get);
      byDayDiffTeamList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byDayDiffTeamList.Headers.Add("Send-Type", SendType);
      byDayDiffTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byDayDiffTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byDayDiffTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isDay));
      byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byDayDiffTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      byDayDiffTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffTeam>>>>(MethodBase.GetCurrentMethod());
      return byDayDiffTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>> GetSaleByDayDiffDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>> byDayDiffDeptList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>(HttpMethod.Get);
      byDayDiffDeptList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byDayDiffDeptList.Headers.Add("Send-Type", SendType);
      byDayDiffDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byDayDiffDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byDayDiffDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isDay));
      byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byDayDiffDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      byDayDiffDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffDept>>>>(MethodBase.GetCurrentMethod());
      return byDayDiffDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>> GetSaleByDayDiffCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>> diffCategoryTopList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>(HttpMethod.Get);
      diffCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      diffCategoryTopList.Headers.Add("Send-Type", SendType);
      diffCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      diffCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      diffCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isDay));
      diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        diffCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      diffCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return diffCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>> GetSaleByDayDiffCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>> diffCategoryMidList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>(HttpMethod.Get);
      diffCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      diffCategoryMidList.Headers.Add("Send-Type", SendType);
      diffCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      diffCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      diffCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isDay));
      diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        diffCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      diffCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return diffCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>> GetSaleByDayDiffCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>> diffCategoryBotList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>(HttpMethod.Get);
      diffCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      diffCategoryBotList.Headers.Add("Send-Type", SendType);
      diffCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      diffCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      diffCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isDay));
      diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        diffCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      diffCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return diffCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>> GetSaleByDayDiffGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_IsDay")] bool isDay = false,
      [NameConvert("p_IsWeek")] bool isWeek = false,
      [NameConvert("p_IsMonth")] bool isMonth = false,
      [NameConvert("p_IsYear")] bool isYear = false,
      [NameConvert("p_ConditionDayBeforeType")] int conditionDayBeforeType = 0,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>> dayDiffGoodsList = new UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>(HttpMethod.Get);
      dayDiffGoodsList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Diff/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dayDiffGoodsList.Headers.Add("Send-Type", SendType);
      dayDiffGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dayDiffGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dayDiffGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isDay));
      dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isWeek));
      dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isMonth));
      dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isYear));
      if (conditionDayBeforeType > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => conditionDayBeforeType));
      if (sbd_SaleDate > 0L)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dayDiffGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dayDiffGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SalesByDayDiffGoods>>>>(MethodBase.GetCurrentMethod());
      return dayDiffGoodsList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>> GetSaleByDayDateSupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>> dateSupplierList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>(HttpMethod.Get);
      dateSupplierList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Date/Supplier/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateSupplierList.Headers.Add("Send-Type", SendType);
      dateSupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      dateSupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateSupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        dateSupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateSupplierList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplier>>>>(MethodBase.GetCurrentMethod());
      return dateSupplierList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>> GetSaleByDayDateSupplierCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>> supplierCategoryTopList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>(HttpMethod.Get);
      supplierCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Date/Supplier/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryTopList.Headers.Add("Send-Type", SendType);
      supplierCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>> GetSaleByDayDateSupplierCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>> supplierCategoryMidList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>(HttpMethod.Get);
      supplierCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Date/Supplier/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryMidList.Headers.Add("Send-Type", SendType);
      supplierCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>> GetSaleByDayDateSupplierCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>> supplierCategoryBotList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>(HttpMethod.Get);
      supplierCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Date/Supplier/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryBotList.Headers.Add("Send-Type", SendType);
      supplierCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>> GetSaleByDayDateSupplierGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDate")] long sbd_SaleDate = 0,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>> supplierGoodsList = new UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>(HttpMethod.Get);
      supplierGoodsList.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Date/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsList.Headers.Add("Send-Type", SendType);
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDate > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDate));
      if (sbd_SaleDateBegin > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SaleByDayDateSupplierGoods>>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsList;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>> GetSaleByDayHorizontalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>> horizontalByStorePack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>(HttpMethod.Get);
      horizontalByStorePack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByStorePack.Headers.Add("Send-Type", SendType);
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByStorePack>>>(MethodBase.GetCurrentMethod());
      return horizontalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>> GetSaleByDayHorizontalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>> horizontalByTeamPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>(HttpMethod.Get);
      horizontalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByTeamPack.Headers.Add("Send-Type", SendType);
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>> GetSaleByDayHorizontalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>> horizontalByDeptPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>(HttpMethod.Get);
      horizontalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByDeptPack.Headers.Add("Send-Type", SendType);
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>> GetSaleByDayHorizontalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>> GetSaleByDayHorizontalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>> GetSaleByDayHorizontalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>> GetSaleByDayHorizontalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>> horizontalByGoodsPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>(HttpMethod.Get);
      horizontalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByGoodsPack.Headers.Add("Send-Type", SendType);
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>> GetSaleByDayHorizontalBySupplierPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>> horizontalBySupplierPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>(HttpMethod.Get);
      horizontalBySupplierPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Supplier/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalBySupplierPack.Headers.Add("Send-Type", SendType);
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalBySupplierPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierPack>>>(MethodBase.GetCurrentMethod());
      return horizontalBySupplierPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>> GetSaleByDayHorizontalBySupplierCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>> supplierCategoryTopPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>(HttpMethod.Get);
      supplierCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Supplier/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryTopPack.Headers.Add("Send-Type", SendType);
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>> GetSaleByDayHorizontalBySupplierCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>> supplierCategoryMidPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>(HttpMethod.Get);
      supplierCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Supplier/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryMidPack.Headers.Add("Send-Type", SendType);
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>> GetSaleByDayHorizontalBySupplierCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>> supplierCategoryBotPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>(HttpMethod.Get);
      supplierCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Supplier/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryBotPack.Headers.Add("Send-Type", SendType);
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>> GetSaleByDayHorizontalBySupplierGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>> supplierGoodsPack = new UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>(HttpMethod.Get);
      supplierGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Horizontal/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsPack.Headers.Add("Send-Type", SendType);
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByDayHorizontalBySupplierGoodsPack>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>> GetSaleByDayVerticalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>> verticalByStorePack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>(HttpMethod.Get);
      verticalByStorePack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByStorePack.Headers.Add("Send-Type", SendType);
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByStorePack>>>(MethodBase.GetCurrentMethod());
      return verticalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>> GetSaleByDayVerticalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>> verticalByTeamPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>(HttpMethod.Get);
      verticalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByTeamPack.Headers.Add("Send-Type", SendType);
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return verticalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>> GetSaleByDayVerticalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>> verticalByDeptPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>(HttpMethod.Get);
      verticalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByDeptPack.Headers.Add("Send-Type", SendType);
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return verticalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>> GetSaleByDayVerticalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>> GetSaleByDayVerticalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>> GetSaleByDayVerticalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>> GetSaleByDayVerticalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>> verticalByGoodsPack = new UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>(HttpMethod.Get);
      verticalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Day/Vertical/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByGoodsPack.Headers.Add("Send-Type", SendType);
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByDayVerticalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return verticalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>> GetSaleByMonthHorizontalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>> horizontalByStorePack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>(HttpMethod.Get);
      horizontalByStorePack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByStorePack.Headers.Add("Send-Type", SendType);
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByStorePack>>>(MethodBase.GetCurrentMethod());
      return horizontalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>> GetSaleByMonthHorizontalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>> horizontalByTeamPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>(HttpMethod.Get);
      horizontalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByTeamPack.Headers.Add("Send-Type", SendType);
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>> GetSaleByMonthHorizontalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>> horizontalByDeptPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>(HttpMethod.Get);
      horizontalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByDeptPack.Headers.Add("Send-Type", SendType);
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>> GetSaleByMonthHorizontalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>> GetSaleByMonthHorizontalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>> GetSaleByMonthHorizontalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>> GetSaleByMonthHorizontalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>> horizontalByGoodsPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>(HttpMethod.Get);
      horizontalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByGoodsPack.Headers.Add("Send-Type", SendType);
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>> GetSaleByMonthHorizontalBySupplierPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>> horizontalBySupplierPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>(HttpMethod.Get);
      horizontalBySupplierPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Supplier/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalBySupplierPack.Headers.Add("Send-Type", SendType);
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalBySupplierPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierPack>>>(MethodBase.GetCurrentMethod());
      return horizontalBySupplierPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>> GetSaleByMonthHorizontalBySupplierCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>> supplierCategoryTopPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>(HttpMethod.Get);
      supplierCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Supplier/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryTopPack.Headers.Add("Send-Type", SendType);
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>> GetSaleByMonthHorizontalBySupplierCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>> supplierCategoryMidPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>(HttpMethod.Get);
      supplierCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Supplier/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryMidPack.Headers.Add("Send-Type", SendType);
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>> GetSaleByMonthHorizontalBySupplierCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>> supplierCategoryBotPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>(HttpMethod.Get);
      supplierCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Supplier/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCategoryBotPack.Headers.Add("Send-Type", SendType);
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return supplierCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>> GetSaleByMonthHorizontalBySupplierGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
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
      UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>> supplierGoodsPack = new UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>(HttpMethod.Get);
      supplierGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Horizontal/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsPack.Headers.Add("Send-Type", SendType);
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      if (si_StoreCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SalesByMonthHorizontalBySupplierGoodsPack>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>> GetSaleByMonthVerticalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>> verticalByStorePack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>(HttpMethod.Get);
      verticalByStorePack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByStorePack.Headers.Add("Send-Type", SendType);
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByStorePack>>>(MethodBase.GetCurrentMethod());
      return verticalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>> GetSaleByMonthVerticalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>> verticalByTeamPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>(HttpMethod.Get);
      verticalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByTeamPack.Headers.Add("Send-Type", SendType);
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return verticalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>> GetSaleByMonthVerticalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>> verticalByDeptPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>(HttpMethod.Get);
      verticalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByDeptPack.Headers.Add("Send-Type", SendType);
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return verticalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>> GetSaleByMonthVerticalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>> GetSaleByMonthVerticalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>> GetSaleByMonthVerticalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>> GetSaleByMonthVerticalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sbd_SiteID")] long sbd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sbd_SaleDateBegin")] long sbd_SaleDateBegin = 0,
      [NameConvert("p_sbd_SaleDateEnd")] long sbd_SaleDateEnd = 0,
      [NameConvert("p_IsGoalSelect")] bool isGoalSelect = false,
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
      UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>> verticalByGoodsPack = new UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>(HttpMethod.Get);
      verticalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<SalesByDayRestServer>() + "/{sbd_SiteID}/Month/Vertical/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByGoodsPack.Headers.Add("Send-Type", SendType);
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SiteID));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sbd_SaleDateBegin > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateBegin));
      if (sbd_SaleDateEnd > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sbd_SaleDateEnd));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isGoalSelect));
      if (si_StoreCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SaleByMonthVerticalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return verticalByGoodsPack;
    }
  }
}
