// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsInfoRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo
{
  [UbRestModel("/Code", TableCodeType.Unknown, HeaderPath = "")]
  public class GoodsInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<GoodsView>> GetGoods(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gd_SiteID")] long gd_SiteID,
      [NameConvert("p_gd_GoodsCode")] long gd_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false,
      [NameConvert("p_isDicGoodsHistoryByStore")] bool isDicGoodsHistoryByStore = false,
      [NameConvert("p_isLtOldBarcode")] bool isLtOldBarcode = false,
      [NameConvert("p_isLtGoodsPack")] bool isLtGoodsPack = false,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<GoodsView>> goods = new UniBizHttpRequest<UbRes<GoodsView>>(HttpMethod.Get);
      goods.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gd_SiteID}/{gd_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goods.Headers.Add("Send-Type", SendType);
      goods.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_SiteID));
      goods.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_GoodsCode));
      goods.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goods.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (si_StoreCode > 0)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (dt_date > 0L)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => dt_date));
      if (isLtHistory)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      if (isDicGoodsHistoryByStore)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => isDicGoodsHistoryByStore));
      if (isLtOldBarcode)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => isLtOldBarcode));
      if (isLtGoodsPack)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => isLtGoodsPack));
      if (is_thumb_image)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        goods.SetQuery<UniBizHttpRequest<UbRes<GoodsView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      goods.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsView>>>(MethodBase.GetCurrentMethod());
      return goods;
    }

    public static UniBizHttpRequest<UbRes<GoodsView>> PostGoods(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gd_SiteID")] long gd_SiteID,
      [NameConvert("p_gd_GoodsCode")] long gd_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GoodsView pData)
    {
      UniBizHttpRequest<UbRes<GoodsView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gd_SiteID}/{gd_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GoodsView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsView>>> GetGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gd_SiteID")] long gd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gd_GoodsCode")] long gd_GoodsCode = 0,
      [NameConvert("p_gd_BarCode")] string gd_BarCode = null,
      [NameConvert("p_BarCodeALL")] string BarCodeALL = null,
      [NameConvert("p_gd_UseYn")] string gd_UseYn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_PackUnit")] int gd_PackUnit = 0,
      [NameConvert("p_gd_AbcValue")] int gd_AbcValue = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_isRepresentativeIncludeSupplier")] bool isRepresentativeIncludeSupplier = false,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_GoodsHistoryDiv")] int GoodsHistoryDiv = 0,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false,
      [NameConvert("p_isDicGoodsHistoryByStore")] bool isDicGoodsHistoryByStore = false,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_isOrderLive")] bool isOrderLive = true,
      [NameConvert("p_isOrderEnd")] bool isOrderEnd = true,
      [NameConvert("p_isSaleLive")] bool isSaleLive = true,
      [NameConvert("p_isSaleEnd")] bool isSaleEnd = true,
      [NameConvert("p_isGoodsOldBarcode")] bool isGoodsOldBarcode = false,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GoodsView>>> goodsList = new UniBizHttpRequest<UbRes<IList<GoodsView>>>(HttpMethod.Get);
      goodsList.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gd_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsList.Headers.Add("Send-Type", SendType);
      goodsList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsView>>>, long>((Expression<Func<long>>) (() => gd_SiteID));
      goodsList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gd_GoodsCode > 0L)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, long>((Expression<Func<long>>) (() => gd_GoodsCode));
      if (!string.IsNullOrEmpty(gd_BarCode))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => gd_BarCode));
      if (!string.IsNullOrEmpty(BarCodeALL))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => BarCodeALL));
      if (!string.IsNullOrEmpty(gd_UseYn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => gd_UseYn));
      if (gd_TaxDiv > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (gd_PackUnit > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => gd_PackUnit));
      if (gd_AbcValue > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => gd_AbcValue));
      if (si_StoreCode > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (isRepresentativeIncludeSupplier)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isRepresentativeIncludeSupplier));
      if (dt_date > 0L)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (GoodsHistoryDiv > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => GoodsHistoryDiv));
      if (isLtHistory)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      if (isDicGoodsHistoryByStore)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isDicGoodsHistoryByStore));
      if (dpt_lv1_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isOrderLive));
      goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isOrderEnd));
      goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isSaleLive));
      goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isSaleEnd));
      if (isGoodsOldBarcode)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => isGoodsOldBarcode));
      if (bgg_GroupID > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (is_thumb_image)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_thumb_image)
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsView>>>>(MethodBase.GetCurrentMethod());
      return goodsList;
    }

    public static UniBizHttpRequest<UbRes<GoodsView>> PutGoodsSendOldBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gd_SiteID")] long gd_SiteID,
      [NameConvert("p_gd_GoodsCode")] long gd_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsView>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gd_SiteID}/{gd_GoodsCode}/Send/OldBarcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, long>((Expression<Func<long>>) (() => gd_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsHistoryView>> GetGoodsHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdh_SiteID")] long gdh_SiteID,
      [NameConvert("p_gdh_GoodsCode")] long gdh_GoodsCode,
      [NameConvert("p_gdh_StoreCode")] int gdh_StoreCode,
      [NameConvert("p_gdh_StartDate")] long gdh_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsHistoryView>> goodsHistory = new UniBizHttpRequest<UbRes<GoodsHistoryView>>(HttpMethod.Get);
      goodsHistory.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdh_SiteID}/{gdh_GoodsCode}/GoodsHistory/{gdh_StoreCode}/{gdh_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsHistory.Headers.Add("Send-Type", SendType);
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_SiteID));
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_GoodsCode));
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => gdh_StoreCode));
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_StartDate));
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsHistory.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsHistoryView>>>(MethodBase.GetCurrentMethod());
      return goodsHistory;
    }

    public static UniBizHttpRequest<UbRes<GoodsHistoryView>> PostGoodsHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdh_SiteID")] long gdh_SiteID,
      [NameConvert("p_gdh_GoodsCode")] long gdh_GoodsCode,
      [NameConvert("p_gdh_StoreCode")] int gdh_StoreCode,
      [NameConvert("p_gdh_StartDate")] long gdh_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GoodsHistoryView pData)
    {
      UniBizHttpRequest<UbRes<GoodsHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdh_SiteID}/{gdh_GoodsCode}/GoodsHistory/{gdh_StoreCode}/{gdh_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => gdh_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, long>((Expression<Func<long>>) (() => gdh_StartDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GoodsHistoryView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>> GetGoodsHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdh_SiteID")] long gdh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gdh_GoodsCode")] long gdh_GoodsCode = 0,
      [NameConvert("p_gdh_StoreCode")] int gdh_StoreCode = 0,
      [NameConvert("p_gdh_StoreCodeIn")] string gdh_StoreCodeIn = null,
      [NameConvert("p_gdh_StartDate")] long gdh_StartDate = 0,
      [NameConvert("p_gdh_GoodsCategory")] int gdh_GoodsCategory = 0,
      [NameConvert("p_gdh_GoodsCategoryIn")] string gdh_GoodsCategoryIn = null,
      [NameConvert("p_gdh_Supplier")] int gdh_Supplier = 0,
      [NameConvert("p_gdh_SupplierIn")] string gdh_SupplierIn = null,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0,
      [NameConvert("p_LinkStdGoodsCode")] long LinkStdGoodsCode = 0,
      [NameConvert("p_GoodsHistoryDiv")] int GoodsHistoryDiv = 0,
      [NameConvert("p_gd_BarCode")] string gd_BarCode = null,
      [NameConvert("p_gd_UseYn")] string gd_UseYn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_PackUnit")] int gd_PackUnit = 0,
      [NameConvert("p_gd_AbcValue")] int gd_AbcValue = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>> goodsHistoryList = new UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>(HttpMethod.Get);
      goodsHistoryList.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdh_SiteID}/GoodsHistory/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsHistoryList.Headers.Add("Send-Type", SendType);
      goodsHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => gdh_SiteID));
      goodsHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gdh_GoodsCode > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => gdh_GoodsCode));
      if (gdh_StoreCode > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gdh_StoreCode));
      if (!string.IsNullOrEmpty(gdh_StoreCodeIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => gdh_StoreCodeIn));
      if (gdh_StartDate > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => gdh_StartDate));
      if (gdh_GoodsCategory > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gdh_GoodsCategory));
      if (!string.IsNullOrEmpty(gdh_GoodsCategoryIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => gdh_GoodsCategoryIn));
      if (gdh_Supplier > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gdh_Supplier));
      if (!string.IsNullOrEmpty(gdh_SupplierIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => gdh_SupplierIn));
      if (dt_date > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (OrderByType > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      if (LinkStdGoodsCode > 0L)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, long>((Expression<Func<long>>) (() => LinkStdGoodsCode));
      if (GoodsHistoryDiv > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => GoodsHistoryDiv));
      if (!string.IsNullOrEmpty(gd_BarCode))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => gd_BarCode));
      if (!string.IsNullOrEmpty(gd_UseYn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => gd_UseYn));
      if (gd_TaxDiv > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (gd_PackUnit > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gd_PackUnit));
      if (gd_AbcValue > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => gd_AbcValue));
      if (ctg_lv1_ID > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (su_SupplierType > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (bgg_GroupID > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsHistoryView>>>>(MethodBase.GetCurrentMethod());
      return goodsHistoryList;
    }

    public static UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>> PostGoodsHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdh_SiteID")] long gdh_SiteID,
      [NameConvert("p_workType")] int workType,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<GoodsHistoryView> p_list)
    {
      UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdh_SiteID}/GoodsHistory/{workType}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>, long>((Expression<Func<long>>) (() => gdh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>, int>((Expression<Func<int>>) (() => workType));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<GoodsHistoryView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtGoodsHistoryRegister>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteWorkStopGoodsHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdh_SiteID")] long gdh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdh_SiteID}/GoodsHistory/WorkStop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => gdh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> GetGoodsOldBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_gdob_BarCode")] string gdob_BarCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> goodsOldBarcode = new UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>(HttpMethod.Get);
      goodsOldBarcode.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{gdob_BarCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsOldBarcode.Headers.Add("Send-Type", SendType);
      goodsOldBarcode.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      goodsOldBarcode.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      goodsOldBarcode.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, string>((Expression<Func<string>>) (() => gdob_BarCode));
      goodsOldBarcode.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsOldBarcode.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsOldBarcode.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>>(MethodBase.GetCurrentMethod());
      return goodsOldBarcode;
    }

    public static UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> PostGoodsOldBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_gdob_BarCode")] string gdob_BarCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GoodsOldBarcodeView pData)
    {
      UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{gdob_BarCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, string>((Expression<Func<string>>) (() => gdob_BarCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GoodsOldBarcodeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> DeleteGoodsOldBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_gdob_BarCode")] string gdob_BarCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsOldBarcodeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{gdob_BarCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, string>((Expression<Func<string>>) (() => gdob_BarCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsOldBarcodeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> GetGoodsOldBarcodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gdob_BarCode")] string gdob_BarCode = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> goodsOldBarcodeList = new UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>(HttpMethod.Get);
      goodsOldBarcodeList.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsOldBarcodeList.Headers.Add("Send-Type", SendType);
      goodsOldBarcodeList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      goodsOldBarcodeList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      goodsOldBarcodeList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsOldBarcodeList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(gdob_BarCode))
        goodsOldBarcodeList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, string>((Expression<Func<string>>) (() => gdob_BarCode));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsOldBarcodeList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsOldBarcodeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>>(MethodBase.GetCurrentMethod());
      return goodsOldBarcodeList;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> PostGoodsOldBarcodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<GoodsOldBarcodeView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<GoodsOldBarcodeView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> DeleteGoodsOldBarcodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdob_SiteID")] long gdob_SiteID,
      [NameConvert("p_gdob_GoodsCode")] long gdob_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<GoodsOldBarcodeView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdob_SiteID}/{gdob_GoodsCode}/GoodsOldBarcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, long>((Expression<Func<long>>) (() => gdob_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<GoodsOldBarcodeView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsOldBarcodeView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsPackView>> GetGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdp_SiteID")] long gdp_SiteID,
      [NameConvert("p_gdp_GoodsCode")] long gdp_GoodsCode,
      [NameConvert("p_gdp_SubGoodsCode")] long gdp_SubGoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsPackView>> goodsPack = new UniBizHttpRequest<UbRes<GoodsPackView>>(HttpMethod.Get);
      goodsPack.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdp_SiteID}/{gdp_GoodsCode}/GoodsPack/{gdp_SubGoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsPack.Headers.Add("Send-Type", SendType);
      goodsPack.SetSegment<UniBizHttpRequest<UbRes<GoodsPackView>>, long>((Expression<Func<long>>) (() => gdp_SiteID));
      goodsPack.SetSegment<UniBizHttpRequest<UbRes<GoodsPackView>>, long>((Expression<Func<long>>) (() => gdp_GoodsCode));
      goodsPack.SetSegment<UniBizHttpRequest<UbRes<GoodsPackView>>, long>((Expression<Func<long>>) (() => gdp_SubGoodsCode));
      goodsPack.SetSegment<UniBizHttpRequest<UbRes<GoodsPackView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsPack.SetSegment<UniBizHttpRequest<UbRes<GoodsPackView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsPackView>>>(MethodBase.GetCurrentMethod());
      return goodsPack;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsPackView>>> GetGoodsPackList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdp_SiteID")] long gdp_SiteID,
      [NameConvert("p_gdp_GoodsCode")] long gdp_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gdp_SubGoodsCode")] long gdp_SubGoodsCode = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_gd_BarCode")] string gd_BarCode = null,
      [NameConvert("p_gd_UseYn")] string gd_UseYn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_PackUnit")] int gd_PackUnit = 0,
      [NameConvert("p_gd_AbcValue")] int gd_AbcValue = 0,
      [NameConvert("p_GoodsHistoryDiv")] int GoodsHistoryDiv = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_IsSupplierNotEqual")] bool IsSupplierNotEqual = false,
      [NameConvert("p_IsCategoryNotEqual")] bool IsCategoryNotEqual = false,
      [NameConvert("p_IsPriceNotEqual")] bool IsPriceNotEqual = false,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GoodsPackView>>> goodsPackList = new UniBizHttpRequest<UbRes<IList<GoodsPackView>>>(HttpMethod.Get);
      goodsPackList.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdp_SiteID}/{gdp_GoodsCode}/GoodsPack/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsPackList.Headers.Add("Send-Type", SendType);
      goodsPackList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, long>((Expression<Func<long>>) (() => gdp_SiteID));
      goodsPackList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, long>((Expression<Func<long>>) (() => gdp_GoodsCode));
      goodsPackList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsPackList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gdp_SubGoodsCode > 0L)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, long>((Expression<Func<long>>) (() => gdp_SubGoodsCode));
      if (si_StoreCode > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (!string.IsNullOrEmpty(gd_BarCode))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => gd_BarCode));
      if (!string.IsNullOrEmpty(gd_UseYn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => gd_UseYn));
      if (gd_TaxDiv > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (gd_PackUnit > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => gd_PackUnit));
      if (gd_AbcValue > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => gd_AbcValue));
      if (GoodsHistoryDiv > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => GoodsHistoryDiv));
      if (dt_date > 0L)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (IsSupplierNotEqual)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, bool>((Expression<Func<bool>>) (() => IsSupplierNotEqual));
      if (IsCategoryNotEqual)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, bool>((Expression<Func<bool>>) (() => IsCategoryNotEqual));
      if (IsPriceNotEqual)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, bool>((Expression<Func<bool>>) (() => IsPriceNotEqual));
      if (ctg_lv1_ID > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (su_Supplier > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (bgg_GroupID > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsPackList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsPackList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsPackView>>>>(MethodBase.GetCurrentMethod());
      return goodsPackList;
    }

    public static UniBizHttpRequest<UbRes<GoodsStoreInfoView>> GetGoodsStoreInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdsh_SiteID")] long gdsh_SiteID,
      [NameConvert("p_gdsh_GoodsCode")] long gdsh_GoodsCode,
      [NameConvert("p_gdsh_StoreCode")] int gdsh_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsStoreInfoView>> goodsStoreInfo = new UniBizHttpRequest<UbRes<GoodsStoreInfoView>>(HttpMethod.Get);
      goodsStoreInfo.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdsh_SiteID}/{gdsh_GoodsCode}/GoodsStoreInfo/{gdsh_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsStoreInfo.Headers.Add("Send-Type", SendType);
      goodsStoreInfo.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, long>((Expression<Func<long>>) (() => gdsh_SiteID));
      goodsStoreInfo.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, long>((Expression<Func<long>>) (() => gdsh_GoodsCode));
      goodsStoreInfo.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => gdsh_StoreCode));
      goodsStoreInfo.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsStoreInfo.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsStoreInfo.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>>(MethodBase.GetCurrentMethod());
      return goodsStoreInfo;
    }

    public static UniBizHttpRequest<UbRes<GoodsStoreInfoView>> PostGoodsStoreInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdsh_SiteID")] long gdsh_SiteID,
      [NameConvert("p_gdsh_GoodsCode")] long gdsh_GoodsCode,
      [NameConvert("p_gdsh_StoreCode")] int gdsh_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GoodsStoreInfoView pData)
    {
      UniBizHttpRequest<UbRes<GoodsStoreInfoView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsStoreInfoView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdsh_SiteID}/{gdsh_GoodsCode}/GoodsStoreInfo/{gdsh_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, long>((Expression<Func<long>>) (() => gdsh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, long>((Expression<Func<long>>) (() => gdsh_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => gdsh_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GoodsStoreInfoView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsStoreInfoView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>> GetGoodsStoreInfoList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gdsh_SiteID")] long gdsh_SiteID,
      [NameConvert("p_gdsh_GoodsCode")] long gdsh_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gdsh_StoreCode")] int gdsh_StoreCode = 0,
      [NameConvert("p_gdsh_StoreCodeIn")] string gdsh_StoreCodeIn = null,
      [NameConvert("p_gd_UseYn")] string gd_UseYn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_PackUnit")] int gd_PackUnit = 0,
      [NameConvert("p_gd_AbcValue")] int gd_AbcValue = 0,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
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
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>> goodsStoreInfoList = new UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>(HttpMethod.Get);
      goodsStoreInfoList.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gdsh_SiteID}/{gdsh_GoodsCode}/GoodsStoreInfo/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsStoreInfoList.Headers.Add("Send-Type", SendType);
      goodsStoreInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, long>((Expression<Func<long>>) (() => gdsh_SiteID));
      goodsStoreInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, long>((Expression<Func<long>>) (() => gdsh_GoodsCode));
      goodsStoreInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsStoreInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gdsh_StoreCode > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gdsh_StoreCode));
      if (!string.IsNullOrEmpty(gdsh_StoreCodeIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => gdsh_StoreCodeIn));
      if (!string.IsNullOrEmpty(gd_UseYn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => gd_UseYn));
      if (gd_TaxDiv > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (gd_PackUnit > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gd_PackUnit));
      if (gd_AbcValue > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => gd_AbcValue));
      if (su_Supplier > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (ctg_lv1_ID > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (dt_date > 0L)
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsStoreInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      goodsStoreInfoList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsStoreInfoView>>>>(MethodBase.GetCurrentMethod());
      return goodsStoreInfoList;
    }

    public static UniBizHttpRequest<UbRes<GoodsImageView>> GetGoodsImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<GoodsImageView>> goodsImage = new UniBizHttpRequest<UbRes<GoodsImageView>>(HttpMethod.Get);
      goodsImage.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsImage.Headers.Add("Send-Type", SendType);
      goodsImage.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      goodsImage.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      goodsImage.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsImage.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsImage.SetQuery<UniBizHttpRequest<UbRes<GoodsImageView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      goodsImage.SetQuery<UniBizHttpRequest<UbRes<GoodsImageView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      goodsImage.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsImageView>>>(MethodBase.GetCurrentMethod());
      return goodsImage;
    }

    public static UniBizHttpRequest<UbRes<GoodsImageView>> DeleteGoodsImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GoodsImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsImageView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsImageView>> PostGoodsImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<GoodsImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<GoodsImageView>> PostGoodsImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<GoodsImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GoodsImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GoodsImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GoodsImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetGoodsImageThumb(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest goodsImageThumb = new UniBizHttpRequest(HttpMethod.Get);
      goodsImageThumb.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/Thumb/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsImageThumb.Headers.Add("Send-Type", SendType);
      goodsImageThumb.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_SiteID));
      goodsImageThumb.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      goodsImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsImageThumb.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return goodsImageThumb;
    }

    public static UniBizHttpRequest GetGoodsImageOrigin(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest goodsImageOrigin = new UniBizHttpRequest(HttpMethod.Get);
      goodsImageOrigin.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/Origin/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsImageOrigin.Headers.Add("Send-Type", SendType);
      goodsImageOrigin.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_SiteID));
      goodsImageOrigin.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      goodsImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsImageOrigin.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return goodsImageOrigin;
    }

    public static UniBizHttpRequest GetGoodsImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GoodsCode")] long gi_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest goodsImageFile = new UniBizHttpRequest(HttpMethod.Get);
      goodsImageFile.Resource = UbRestModelAttribute.GetBasePath<GoodsInfoRestServer>() + "/Goods/{gi_SiteID}/{gi_GoodsCode}/Image/File/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsImageFile.Headers.Add("Send-Type", SendType);
      goodsImageFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_SiteID));
      goodsImageFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => gi_GoodsCode));
      goodsImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      goodsImageFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return goodsImageFile;
    }
  }
}
