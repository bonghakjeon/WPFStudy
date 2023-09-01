// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.RestServer.ProfitRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Day;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Summary;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniStock.Profit.RestServer
{
  [UbRestModel("/Stock", TableCodeType.Unknown, HeaderPath = "")]
  public class ProfitRestServer
  {
    public static UniBizHttpRequest<UbRes<JobEvtProfitWork>> PostProfitLossWork(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_plwc_SiteID")] long plwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtProfitWork pData)
    {
      UniBizHttpRequest<UbRes<JobEvtProfitWork>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtProfitWork>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/Profit/{plwc_SiteID}/ProfitLossWork/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtProfitWork>>, long>((Expression<Func<long>>) (() => plwc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtProfitWork>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtProfitWork>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtProfitWork>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtProfitWork>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteProfitLossWork(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_plwc_SiteID")] long plwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/Profit/{plwc_SiteID}/ProfitLossWork/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => plwc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<ProfitLossWorkCntView>> GetProfitLossWorkCount(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_plwc_SiteID")] long plwc_SiteID,
      [NameConvert("p_plwc_YyyyMm")] int plwc_YyyyMm,
      [NameConvert("p_plwc_StoreCode")] int plwc_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false)
    {
      UniBizHttpRequest<UbRes<ProfitLossWorkCntView>> profitLossWorkCount = new UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>(HttpMethod.Get);
      profitLossWorkCount.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/Profit/{plwc_SiteID}/ProfitLossWork/Count/{plwc_YyyyMm}/{plwc_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      profitLossWorkCount.Headers.Add("Send-Type", SendType);
      profitLossWorkCount.SetSegment<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, long>((Expression<Func<long>>) (() => plwc_SiteID));
      profitLossWorkCount.SetSegment<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, int>((Expression<Func<int>>) (() => plwc_YyyyMm));
      profitLossWorkCount.SetSegment<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, int>((Expression<Func<int>>) (() => plwc_StoreCode));
      profitLossWorkCount.SetSegment<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      profitLossWorkCount.SetSegment<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      profitLossWorkCount.SetQuery<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      profitLossWorkCount.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProfitLossWorkCntView>>>(MethodBase.GetCurrentMethod());
      return profitLossWorkCount;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>> GetProfitLossWorkCountList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_plwc_SiteID")] long plwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_plwc_YyyyMm")] int plwc_YyyyMm = 0,
      [NameConvert("p_plwc_YyyyMmBegin")] int plwc_YyyyMmBegin = 0,
      [NameConvert("p_plwc_YyyyMmEnd")] int plwc_YyyyMmEnd = 0,
      [NameConvert("p_plwc_YyyyMmNext")] int plwc_YyyyMmNext = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_isLtHistory")] bool isLtHistory = true)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>> lossWorkCountList = new UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>(HttpMethod.Get);
      lossWorkCountList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/Profit/{plwc_SiteID}/ProfitLossWork/Count/{work_pm_MenuCode}/{work_pmp_PropCode}";
      lossWorkCountList.Headers.Add("Send-Type", SendType);
      lossWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, long>((Expression<Func<long>>) (() => plwc_SiteID));
      lossWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      lossWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (plwc_YyyyMm > 0)
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => plwc_YyyyMm));
      if (plwc_YyyyMmBegin > 0)
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => plwc_YyyyMmBegin));
      if (plwc_YyyyMmEnd > 0)
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => plwc_YyyyMmEnd));
      if (plwc_YyyyMmNext > 0)
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => plwc_YyyyMmNext));
      if (si_StoreCode > 0)
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      lossWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      lossWorkCountList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntView>>>>(MethodBase.GetCurrentMethod());
      return lossWorkCountList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>> GetProfitLossWorkCountLogList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_plwcl_SiteID")] long plwcl_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_plwcl_SysDateBegin")] long plwcl_SysDateBegin = 0,
      [NameConvert("p_plwcl_SysDateEnd")] long plwcl_SysDateEnd = 0,
      [NameConvert("p_plwcl_YyyyMm")] int plwcl_YyyyMm = 0,
      [NameConvert("p_plwcl_YyyyMmBegin")] int plwcl_YyyyMmBegin = 0,
      [NameConvert("p_plwcl_YyyyMmEnd")] int plwcl_YyyyMmEnd = 0,
      [NameConvert("p_plwcl_YyyyMmNext")] int plwcl_YyyyMmNext = 0,
      [NameConvert("p_plwcl_Day")] int plwcl_Day = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>> workCountLogList = new UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>(HttpMethod.Get);
      workCountLogList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/Profit/{plwcl_SiteID}/ProfitLossWork/Count/Log/{work_pm_MenuCode}/{work_pmp_PropCode}";
      workCountLogList.Headers.Add("Send-Type", SendType);
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, long>((Expression<Func<long>>) (() => plwcl_SiteID));
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (plwcl_SysDateBegin > 0L)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, long>((Expression<Func<long>>) (() => plwcl_SysDateBegin));
      if (plwcl_SysDateEnd > 0L)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, long>((Expression<Func<long>>) (() => plwcl_SysDateEnd));
      if (plwcl_YyyyMm > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => plwcl_YyyyMm));
      if (plwcl_YyyyMmBegin > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => plwcl_YyyyMmBegin));
      if (plwcl_YyyyMmEnd > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => plwcl_YyyyMmEnd));
      if (plwcl_YyyyMmNext > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => plwcl_YyyyMmNext));
      if (plwcl_Day > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => plwcl_Day));
      if (si_StoreCode > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      workCountLogList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossWorkCntLogView>>>>(MethodBase.GetCurrentMethod());
      return workCountLogList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>> GetProfitLossSummaryDateStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>> summaryDateStoreList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>(HttpMethod.Get);
      summaryDateStoreList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryDateStoreList.Headers.Add("Send-Type", SendType);
      summaryDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryDateStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateStore>>>>(MethodBase.GetCurrentMethod());
      return summaryDateStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>> GetProfitLossSummaryDateTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>> summaryDateTeamList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>(HttpMethod.Get);
      summaryDateTeamList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryDateTeamList.Headers.Add("Send-Type", SendType);
      summaryDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryDateTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateTeam>>>>(MethodBase.GetCurrentMethod());
      return summaryDateTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>> GetProfitLossSummaryDateDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>> summaryDateDeptList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>(HttpMethod.Get);
      summaryDateDeptList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryDateDeptList.Headers.Add("Send-Type", SendType);
      summaryDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryDateDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateDept>>>>(MethodBase.GetCurrentMethod());
      return summaryDateDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>> GetProfitLossSummaryDateCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>> dateCategoryTopList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>(HttpMethod.Get);
      dateCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryTopList.Headers.Add("Send-Type", SendType);
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>> GetProfitLossSummaryDateCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>> dateCategoryMidList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>(HttpMethod.Get);
      dateCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryMidList.Headers.Add("Send-Type", SendType);
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>> GetProfitLossSummaryDateCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>> dateCategoryBotList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>(HttpMethod.Get);
      dateCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryBotList.Headers.Add("Send-Type", SendType);
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>> GetProfitLossSummaryDateGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>> summaryDateGoodsList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>(HttpMethod.Get);
      summaryDateGoodsList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Date/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryDateGoodsList.Headers.Add("Send-Type", SendType);
      summaryDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryDateGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDateGoods>>>>(MethodBase.GetCurrentMethod());
      return summaryDateGoodsList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>> GetProfitLossSummaryDayGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_pls_GoodsCode")] long pls_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsSupplierView")] bool isSupplierView = false)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>> summaryDayGoodsList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>(HttpMethod.Get);
      summaryDayGoodsList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Day/Goods/{pls_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryDayGoodsList.Headers.Add("Send-Type", SendType);
      summaryDayGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryDayGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, long>((Expression<Func<long>>) (() => pls_GoodsCode));
      summaryDayGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryDayGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      summaryDayGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>, bool>((Expression<Func<bool>>) (() => isSupplierView));
      summaryDayGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDayGoods>>>>(MethodBase.GetCurrentMethod());
      return summaryDayGoodsList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>> GetProfitLossSummaryMonthGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_pls_GoodsCode")] long pls_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsSupplierView")] bool isSupplierView = false)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>> summaryMonthGoodsList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>(HttpMethod.Get);
      summaryMonthGoodsList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Month/Goods/{pls_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryMonthGoodsList.Headers.Add("Send-Type", SendType);
      summaryMonthGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryMonthGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, long>((Expression<Func<long>>) (() => pls_GoodsCode));
      summaryMonthGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryMonthGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      summaryMonthGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>, bool>((Expression<Func<bool>>) (() => isSupplierView));
      summaryMonthGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryMonthGoods>>>>(MethodBase.GetCurrentMethod());
      return summaryMonthGoodsList;
    }

    public static UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>> GetProfitLossSummaryGoodsByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>> goodsByStorePack = new UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>(HttpMethod.Get);
      goodsByStorePack.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/GoodsBy/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsByStorePack.Headers.Add("Send-Type", SendType);
      goodsByStorePack.SetSegment<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      goodsByStorePack.SetSegment<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsByStorePack.SetSegment<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsByStorePack.SetQuery<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProfitLossSummaryGoodsByStorePack>>>(MethodBase.GetCurrentMethod());
      return goodsByStorePack;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>> GetProfitLossSummaryStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>> summaryStoreList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>(HttpMethod.Get);
      summaryStoreList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryStoreList.Headers.Add("Send-Type", SendType);
      summaryStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryStore>>>>(MethodBase.GetCurrentMethod());
      return summaryStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>> GetProfitLossSummaryTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>> lossSummaryTeamList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>(HttpMethod.Get);
      lossSummaryTeamList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      lossSummaryTeamList.Headers.Add("Send-Type", SendType);
      lossSummaryTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      lossSummaryTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      lossSummaryTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        lossSummaryTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      lossSummaryTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryTeam>>>>(MethodBase.GetCurrentMethod());
      return lossSummaryTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>> GetProfitLossSummaryDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>> lossSummaryDeptList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>(HttpMethod.Get);
      lossSummaryDeptList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      lossSummaryDeptList.Headers.Add("Send-Type", SendType);
      lossSummaryDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      lossSummaryDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      lossSummaryDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        lossSummaryDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      lossSummaryDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryDept>>>>(MethodBase.GetCurrentMethod());
      return lossSummaryDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>> GetProfitLossSummaryCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>> summaryCategoryTopList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>(HttpMethod.Get);
      summaryCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryCategoryTopList.Headers.Add("Send-Type", SendType);
      summaryCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return summaryCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>> GetProfitLossSummaryCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>> summaryCategoryMidList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>(HttpMethod.Get);
      summaryCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryCategoryMidList.Headers.Add("Send-Type", SendType);
      summaryCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return summaryCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>> GetProfitLossSummaryCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>> summaryCategoryBotList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>(HttpMethod.Get);
      summaryCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryCategoryBotList.Headers.Add("Send-Type", SendType);
      summaryCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return summaryCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>> GetProfitLossSummaryGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pls_SiteID")] long pls_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_DateBegin")] long dateBegin = 0,
      [NameConvert("p_DateEnd")] long dateEnd = 0,
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
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>> summaryGoodsList = new UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>(HttpMethod.Get);
      summaryGoodsList.Resource = UbRestModelAttribute.GetBasePath<ProfitRestServer>() + "/ProfitLossSummary/{pls_SiteID}/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      summaryGoodsList.Headers.Add("Send-Type", SendType);
      summaryGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, long>((Expression<Func<long>>) (() => pls_SiteID));
      summaryGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      summaryGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (dateBegin > 0L)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, long>((Expression<Func<long>>) (() => dateBegin));
      if (dateEnd > 0L)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, long>((Expression<Func<long>>) (() => dateEnd));
      if (si_StoreCode > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        summaryGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      summaryGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProfitLossSummaryGoods>>>>(MethodBase.GetCurrentMethod());
      return summaryGoodsList;
    }
  }
}
