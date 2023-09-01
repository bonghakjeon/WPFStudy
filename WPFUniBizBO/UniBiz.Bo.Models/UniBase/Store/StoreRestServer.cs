// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Store.Location;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.Store
{
  [UbRestModel("/Code", TableCodeType.Unknown, HeaderPath = "")]
  public class StoreRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<StoreInfoView>> GetStoreInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_si_SiteID")] long si_SiteID,
      [NameConvert("p_si_StoreCode")] int si_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<StoreInfoView>> storeInfo = new UniBizHttpRequest<UbRes<StoreInfoView>>(HttpMethod.Get);
      storeInfo.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{si_SiteID}/{si_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeInfo.Headers.Add("Send-Type", SendType);
      storeInfo.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, long>((Expression<Func<long>>) (() => si_SiteID));
      storeInfo.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      storeInfo.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeInfo.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      storeInfo.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreInfoView>>>(MethodBase.GetCurrentMethod());
      return storeInfo;
    }

    public static UniBizHttpRequest<UbRes<StoreInfoView>> PostStoreInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_si_SiteID")] long si_SiteID,
      [NameConvert("p_si_StoreCode")] int si_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StoreInfoView pData)
    {
      UniBizHttpRequest<UbRes<StoreInfoView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StoreInfoView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{si_SiteID}/{si_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, long>((Expression<Func<long>>) (() => si_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StoreInfoView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreInfoView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StoreInfoView>>> GetStoreInfoList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_si_SiteID")] long si_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_si_UseYn")] string si_UseYn = null,
      [NameConvert("p_is_MemberMntStore")] bool is_MemberMntStore = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StoreInfoView>>> storeInfoList = new UniBizHttpRequest<UbRes<IList<StoreInfoView>>>(HttpMethod.Get);
      storeInfoList.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{si_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeInfoList.Headers.Add("Send-Type", SendType);
      storeInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, long>((Expression<Func<long>>) (() => si_SiteID));
      storeInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (si_StoreCode > 0)
        storeInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        storeInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (!string.IsNullOrEmpty(si_UseYn))
        storeInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, string>((Expression<Func<string>>) (() => si_UseYn));
      if (is_MemberMntStore)
        storeInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, bool>((Expression<Func<bool>>) (() => is_MemberMntStore));
      if (!string.IsNullOrEmpty(KeyWord))
        storeInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      storeInfoList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StoreInfoView>>>>(MethodBase.GetCurrentMethod());
      return storeInfoList;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupHeaderView>> GetStoreGroupHeader(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgh_SiteID")] long sgh_SiteID,
      [NameConvert("p_sgh_GroupCode")] int sgh_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<StoreGroupHeaderView>> storeGroupHeader = new UniBizHttpRequest<UbRes<StoreGroupHeaderView>>(HttpMethod.Get);
      storeGroupHeader.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgh_SiteID}/GroupHeader/{sgh_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeGroupHeader.Headers.Add("Send-Type", SendType);
      storeGroupHeader.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, long>((Expression<Func<long>>) (() => sgh_SiteID));
      storeGroupHeader.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => sgh_GroupCode));
      storeGroupHeader.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeGroupHeader.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      storeGroupHeader.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>>(MethodBase.GetCurrentMethod());
      return storeGroupHeader;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupHeaderView>> PostStoreGroupHeader(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgh_SiteID")] long sgh_SiteID,
      [NameConvert("p_sgh_GroupCode")] int sgh_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StoreGroupHeaderView pData)
    {
      UniBizHttpRequest<UbRes<StoreGroupHeaderView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StoreGroupHeaderView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgh_SiteID}/GroupHeader/{sgh_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, long>((Expression<Func<long>>) (() => sgh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => sgh_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StoreGroupHeaderView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupHeaderView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>> GetStoreGroupHeaderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgh_SiteID")] long sgh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sgh_GroupCode")] int sgh_GroupCode = 0,
      [NameConvert("p_sgh_GroupType")] int sgh_GroupType = 0,
      [NameConvert("p_sgh_UseYn")] string sgh_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>> storeGroupHeaderList = new UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>(HttpMethod.Get);
      storeGroupHeaderList.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgh_SiteID}/GroupHeader/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeGroupHeaderList.Headers.Add("Send-Type", SendType);
      storeGroupHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, long>((Expression<Func<long>>) (() => sgh_SiteID));
      storeGroupHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeGroupHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (sgh_GroupCode > 0)
        storeGroupHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, int>((Expression<Func<int>>) (() => sgh_GroupCode));
      if (sgh_GroupType > 0)
        storeGroupHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, int>((Expression<Func<int>>) (() => sgh_GroupType));
      if (!string.IsNullOrEmpty(sgh_UseYn))
        storeGroupHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, string>((Expression<Func<string>>) (() => sgh_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        storeGroupHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      storeGroupHeaderList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StoreGroupHeaderView>>>>(MethodBase.GetCurrentMethod());
      return storeGroupHeaderList;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupDepth>> GetStoreGroupDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgh_SiteID")] long sgh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sgh_GroupCode")] int sgh_GroupCode = 0,
      [NameConvert("p_sgh_GroupType")] int sgh_GroupType = 0,
      [NameConvert("p_sgh_UseYn")] string sgh_UseYn = null,
      [NameConvert("p_si_UseYn")] string si_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StoreGroupDepth>> storeGroupDepth = new UniBizHttpRequest<UbRes<StoreGroupDepth>>(HttpMethod.Get);
      storeGroupDepth.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgh_SiteID}/Group/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeGroupDepth.Headers.Add("Send-Type", SendType);
      storeGroupDepth.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDepth>>, long>((Expression<Func<long>>) (() => sgh_SiteID));
      storeGroupDepth.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDepth>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeGroupDepth.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDepth>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (sgh_GroupCode > 0)
        storeGroupDepth.SetQuery<UniBizHttpRequest<UbRes<StoreGroupDepth>>, int>((Expression<Func<int>>) (() => sgh_GroupCode));
      if (sgh_GroupType > 0)
        storeGroupDepth.SetQuery<UniBizHttpRequest<UbRes<StoreGroupDepth>>, int>((Expression<Func<int>>) (() => sgh_GroupType));
      if (!string.IsNullOrEmpty(sgh_UseYn))
        storeGroupDepth.SetQuery<UniBizHttpRequest<UbRes<StoreGroupDepth>>, string>((Expression<Func<string>>) (() => sgh_UseYn));
      if (!string.IsNullOrEmpty(si_UseYn))
        storeGroupDepth.SetQuery<UniBizHttpRequest<UbRes<StoreGroupDepth>>, string>((Expression<Func<string>>) (() => si_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        storeGroupDepth.SetQuery<UniBizHttpRequest<UbRes<StoreGroupDepth>>, string>((Expression<Func<string>>) (() => KeyWord));
      storeGroupDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupDepth>>>(MethodBase.GetCurrentMethod());
      return storeGroupDepth;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupDetailView>> GetStoreGroupDetail(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_StoreCode")] int sgd_StoreCode,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<StoreGroupDetailView>> storeGroupDetail = new UniBizHttpRequest<UbRes<StoreGroupDetailView>>(HttpMethod.Get);
      storeGroupDetail.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/{sgd_StoreCode}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeGroupDetail.Headers.Add("Send-Type", SendType);
      storeGroupDetail.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      storeGroupDetail.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_StoreCode));
      storeGroupDetail.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      storeGroupDetail.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeGroupDetail.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      storeGroupDetail.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupDetailView>>>(MethodBase.GetCurrentMethod());
      return storeGroupDetail;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupDetailView>> PostStoreGroupDetail(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_StoreCode")] int sgd_StoreCode,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StoreGroupDetailView pData)
    {
      UniBizHttpRequest<UbRes<StoreGroupDetailView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StoreGroupDetailView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/{sgd_StoreCode}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StoreGroupDetailView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupDetailView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<StoreGroupDetailView>> DeleteStoreGroupDetail(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_StoreCode")] int sgd_StoreCode,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<StoreGroupDetailView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StoreGroupDetailView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/{sgd_StoreCode}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StoreGroupDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StoreGroupDetailView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> GetStoreGroupDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sgd_StoreCode")] int sgd_StoreCode = 0,
      [NameConvert("p_sgh_GroupType")] int sgh_GroupType = 0,
      [NameConvert("p_si_UseYn")] string si_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> storeGroupDetailList = new UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>(HttpMethod.Get);
      storeGroupDetailList.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      storeGroupDetailList.Headers.Add("Send-Type", SendType);
      storeGroupDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      storeGroupDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      storeGroupDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      storeGroupDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (sgd_StoreCode > 0)
        storeGroupDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => sgd_StoreCode));
      if (sgh_GroupType > 0)
        storeGroupDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => sgh_GroupType));
      if (!string.IsNullOrEmpty(si_UseYn))
        storeGroupDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, string>((Expression<Func<string>>) (() => si_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        storeGroupDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      storeGroupDetailList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>>(MethodBase.GetCurrentMethod());
      return storeGroupDetailList;
    }

    public static UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> PostStoreGroupDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<StoreGroupDetailView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<StoreGroupDetailView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> DeleteStoreGroupDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sgd_SiteID")] long sgd_SiteID,
      [NameConvert("p_sgd_GroupCode")] int sgd_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<StoreGroupDetailView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{sgd_SiteID}/GroupDetail/{sgd_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, long>((Expression<Func<long>>) (() => sgd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => sgd_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<StoreGroupDetailView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StoreGroupDetailView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<LocationView>> GetLocation(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_loc_SiteID")] long loc_SiteID,
      [NameConvert("p_loc_LocationID")] int loc_LocationID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtDetail")] bool isLtDetail = false)
    {
      UniBizHttpRequest<UbRes<LocationView>> location = new UniBizHttpRequest<UbRes<LocationView>>(HttpMethod.Get);
      location.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{loc_SiteID}/Location/{loc_LocationID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      location.Headers.Add("Send-Type", SendType);
      location.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, long>((Expression<Func<long>>) (() => loc_SiteID));
      location.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => loc_LocationID));
      location.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      location.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isLtDetail)
        location.SetQuery<UniBizHttpRequest<UbRes<LocationView>>, bool>((Expression<Func<bool>>) (() => isLtDetail));
      location.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LocationView>>>(MethodBase.GetCurrentMethod());
      return location;
    }

    public static UniBizHttpRequest<UbRes<LocationView>> PostLocation(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_loc_SiteID")] long loc_SiteID,
      [NameConvert("p_loc_LocationID")] int loc_LocationID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      LocationView pData)
    {
      UniBizHttpRequest<UbRes<LocationView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LocationView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{loc_SiteID}/Location/{loc_LocationID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, long>((Expression<Func<long>>) (() => loc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => loc_LocationID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LocationView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<LocationView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LocationView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<LocationView>>> GetLocationList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_loc_SiteID")] long loc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_loc_LocationID")] int loc_LocationID = 0,
      [NameConvert("p_loc_StoreCode")] int loc_StoreCode = 0,
      [NameConvert("p_loc_LocationCode")] string loc_LocationCode = null,
      [NameConvert("p_loc_LocationName")] string loc_LocationName = null,
      [NameConvert("p_loc_StorageDiv")] int loc_StorageDiv = 0,
      [NameConvert("p_loc_EmpCode")] int loc_EmpCode = 0,
      [NameConvert("p_loc_LocationType")] int loc_LocationType = 0,
      [NameConvert("p_loc_PermitDiv")] int loc_PermitDiv = 0,
      [NameConvert("p_loc_Level")] int loc_Level = 0,
      [NameConvert("p_loc_PackUnit")] int loc_PackUnit = 0,
      [NameConvert("p_loc_UseYn")] string loc_UseYn = null,
      [NameConvert("p_isLtDetail")] bool isLtDetail = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<LocationView>>> locationList = new UniBizHttpRequest<UbRes<IList<LocationView>>>(HttpMethod.Get);
      locationList.Resource = UbRestModelAttribute.GetBasePath<StoreRestServer>() + "/StoreInfo/{loc_SiteID}/Location/{work_pm_MenuCode}/{work_pmp_PropCode}";
      locationList.Headers.Add("Send-Type", SendType);
      locationList.SetSegment<UniBizHttpRequest<UbRes<IList<LocationView>>>, long>((Expression<Func<long>>) (() => loc_SiteID));
      locationList.SetSegment<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      locationList.SetSegment<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (loc_LocationID > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_LocationID));
      if (loc_StoreCode > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_StoreCode));
      if (!string.IsNullOrEmpty(loc_LocationCode))
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, string>((Expression<Func<string>>) (() => loc_LocationCode));
      if (!string.IsNullOrEmpty(loc_LocationName))
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, string>((Expression<Func<string>>) (() => loc_LocationName));
      if (loc_StorageDiv > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_StorageDiv));
      if (loc_EmpCode > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_EmpCode));
      if (loc_LocationType > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_LocationType));
      if (loc_PermitDiv > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_PermitDiv));
      if (loc_Level > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_Level));
      if (loc_PackUnit > 0)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, int>((Expression<Func<int>>) (() => loc_PackUnit));
      if (!string.IsNullOrEmpty(loc_UseYn))
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, string>((Expression<Func<string>>) (() => loc_UseYn));
      if (isLtDetail)
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, bool>((Expression<Func<bool>>) (() => isLtDetail));
      if (!string.IsNullOrEmpty(KeyWord))
        locationList.SetQuery<UniBizHttpRequest<UbRes<IList<LocationView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      locationList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<LocationView>>>>(MethodBase.GetCurrentMethod());
      return locationList;
    }
  }
}
