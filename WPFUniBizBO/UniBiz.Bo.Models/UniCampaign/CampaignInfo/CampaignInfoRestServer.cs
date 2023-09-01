// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignInfoRestServer
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
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignGoods;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignMember;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo
{
  [UbRestModel("/Campaign/Info", TableCodeType.Campaign, HeaderPath = "")]
  public class CampaignInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<CampaignView>> GetCampaign(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ci_SiteID")] long ci_SiteID,
      [NameConvert("p_ci_CampaignCode")] long ci_CampaignCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isDetails")] bool isDetails = false)
    {
      UniBizHttpRequest<UbRes<CampaignView>> campaign = new UniBizHttpRequest<UbRes<CampaignView>>(HttpMethod.Get);
      campaign.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{ci_SiteID}/Campaign/{ci_CampaignCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaign.Headers.Add("Send-Type", SendType);
      campaign.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, long>((Expression<Func<long>>) (() => ci_SiteID));
      campaign.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, long>((Expression<Func<long>>) (() => ci_CampaignCode));
      campaign.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaign.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isDetails)
        campaign.SetQuery<UniBizHttpRequest<UbRes<CampaignView>>, bool>((Expression<Func<bool>>) (() => isDetails));
      campaign.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignView>>>(MethodBase.GetCurrentMethod());
      return campaign;
    }

    public static UniBizHttpRequest<UbRes<CampaignView>> PostCampaign(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ci_SiteID")] long ci_SiteID,
      [NameConvert("p_ci_CampaignCode")] long ci_CampaignCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CampaignView pData)
    {
      UniBizHttpRequest<UbRes<CampaignView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{ci_SiteID}/Campaign/{ci_CampaignCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, long>((Expression<Func<long>>) (() => ci_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, long>((Expression<Func<long>>) (() => ci_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CampaignView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CampaignView>>> GetCampaignList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ci_SiteID")] long ci_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ci_CampaignCode")] long ci_CampaignCode = 0,
      [NameConvert("p_ci_CampaignName")] string ci_CampaignName = null,
      [NameConvert("p_ci_StartDate")] long ci_StartDate = 0,
      [NameConvert("p_ci_EndDate")] long ci_EndDate = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_ci_CampaignType")] int ci_CampaignType = 0,
      [NameConvert("p_ci_IsCampaignMemberALL")] bool? IsCampaignMemberALL = null,
      [NameConvert("p_ci_CampaignMember")] long ci_CampaignMember = 0,
      [NameConvert("p_ci_IsCampaignGoodsALL")] bool? IsCampaignGoodsALL = null,
      [NameConvert("p_ci_CampaignGoods")] long ci_CampaignGoods = 0,
      [NameConvert("p_isDetails")] bool isDetails = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CampaignView>>> campaignList = new UniBizHttpRequest<UbRes<IList<CampaignView>>>(HttpMethod.Get);
      campaignList.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{ci_SiteID}/Campaign/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignList.Headers.Add("Send-Type", SendType);
      campaignList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_SiteID));
      campaignList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ci_CampaignCode > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_CampaignCode));
      if (!string.IsNullOrEmpty(ci_CampaignName))
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, string>((Expression<Func<string>>) (() => ci_CampaignName));
      if (ci_StartDate > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_StartDate));
      if (ci_EndDate > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_EndDate));
      if (dt_date > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (ci_CampaignType > 0)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, int>((Expression<Func<int>>) (() => ci_CampaignType));
      if (IsCampaignMemberALL.HasValue)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, bool?>((Expression<Func<bool?>>) (() => IsCampaignMemberALL));
      if (ci_CampaignMember > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_CampaignMember));
      if (IsCampaignGoodsALL.HasValue)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, bool?>((Expression<Func<bool?>>) (() => IsCampaignGoodsALL));
      if (ci_CampaignGoods > 0L)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, long>((Expression<Func<long>>) (() => ci_CampaignGoods));
      if (isDetails)
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, bool>((Expression<Func<bool>>) (() => isDetails));
      if (!string.IsNullOrEmpty(KeyWord))
        campaignList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      campaignList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CampaignView>>>>(MethodBase.GetCurrentMethod());
      return campaignList;
    }

    public static UniBizHttpRequest<UbRes<CampaignGoodsView>> GetCampaignGoods(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cig_SiteID")] long cig_SiteID,
      [NameConvert("p_cig_CampaignCode")] long cig_CampaignCode,
      [NameConvert("p_cig_CodeType")] int cig_CodeType,
      [NameConvert("p_cig_GoodsCode")] long cig_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignGoodsView>> campaignGoods = new UniBizHttpRequest<UbRes<CampaignGoodsView>>(HttpMethod.Get);
      campaignGoods.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cig_SiteID}/Campaign/{cig_CampaignCode}/Goods/{cig_CodeType}/{cig_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignGoods.Headers.Add("Send-Type", SendType);
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_SiteID));
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_CampaignCode));
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => cig_CodeType));
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_GoodsCode));
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignGoods.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      campaignGoods.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignGoodsView>>>(MethodBase.GetCurrentMethod());
      return campaignGoods;
    }

    public static UniBizHttpRequest<UbRes<CampaignGoodsView>> PostCampaignGoods(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cig_SiteID")] long cig_SiteID,
      [NameConvert("p_cig_CampaignCode")] long cig_CampaignCode,
      [NameConvert("p_cig_CodeType")] int cig_CodeType,
      [NameConvert("p_cig_GoodsCode")] long cig_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CampaignGoodsView pData)
    {
      UniBizHttpRequest<UbRes<CampaignGoodsView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignGoodsView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cig_SiteID}/Campaign/{cig_CampaignCode}/Goods/{cig_CodeType}/{cig_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => cig_CodeType));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CampaignGoodsView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignGoodsView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<CampaignGoodsView>> DeleteCampaignGoods(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cig_SiteID")] long cig_SiteID,
      [NameConvert("p_cig_CampaignCode")] long cig_CampaignCode,
      [NameConvert("p_cig_CodeType")] int cig_CodeType,
      [NameConvert("p_cig_GoodsCode")] long cig_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignGoodsView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignGoodsView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cig_SiteID}/Campaign/{cig_CampaignCode}/Goods/{cig_CodeType}/{cig_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => cig_CodeType));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, long>((Expression<Func<long>>) (() => cig_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignGoodsView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignGoodsView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>> GetCampaignGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cig_SiteID")] long cig_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cig_CampaignCode")] long cig_CampaignCode = 0,
      [NameConvert("p_cig_CodeType")] int cig_CodeType = 0,
      [NameConvert("p_cig_GoodsCode")] long cig_GoodsCode = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>> campaignGoodsList = new UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>(HttpMethod.Get);
      campaignGoodsList.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cig_SiteID}/Campaign/{cig_CampaignCode}/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignGoodsList.Headers.Add("Send-Type", SendType);
      campaignGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, long>((Expression<Func<long>>) (() => cig_SiteID));
      campaignGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, long>((Expression<Func<long>>) (() => cig_CampaignCode));
      campaignGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cig_CodeType > 0)
        campaignGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, int>((Expression<Func<int>>) (() => cig_CodeType));
      if (cig_GoodsCode > 0L)
        campaignGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, long>((Expression<Func<long>>) (() => cig_GoodsCode));
      if (!string.IsNullOrEmpty(KeyWord))
        campaignGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      campaignGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CampaignGoodsView>>>>(MethodBase.GetCurrentMethod());
      return campaignGoodsList;
    }

    public static UniBizHttpRequest<UbRes<CampaignMemberView>> GetCampaignMember(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cim_SiteID")] long cim_SiteID,
      [NameConvert("p_cim_CampaignCode")] long cim_CampaignCode,
      [NameConvert("p_cim_MemberNo")] long cim_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignMemberView>> campaignMember = new UniBizHttpRequest<UbRes<CampaignMemberView>>(HttpMethod.Get);
      campaignMember.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cim_SiteID}/Campaign/{cim_CampaignCode}/Member/{cim_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignMember.Headers.Add("Send-Type", SendType);
      campaignMember.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_SiteID));
      campaignMember.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_CampaignCode));
      campaignMember.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_MemberNo));
      campaignMember.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignMember.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      campaignMember.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignMemberView>>>(MethodBase.GetCurrentMethod());
      return campaignMember;
    }

    public static UniBizHttpRequest<UbRes<CampaignMemberView>> PostCampaignMember(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cim_SiteID")] long cim_SiteID,
      [NameConvert("p_cim_CampaignCode")] long cim_CampaignCode,
      [NameConvert("p_cim_MemberNo")] long cim_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CampaignMemberView pData)
    {
      UniBizHttpRequest<UbRes<CampaignMemberView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignMemberView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cim_SiteID}/Campaign/{cim_CampaignCode}/Member/{cim_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CampaignMemberView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignMemberView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<CampaignMemberView>> DeleteCampaignMember(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cim_SiteID")] long cim_SiteID,
      [NameConvert("p_cim_CampaignCode")] long cim_CampaignCode,
      [NameConvert("p_cim_MemberNo")] long cim_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignMemberView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignMemberView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cim_SiteID}/Campaign/{cim_CampaignCode}/Member/{cim_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, long>((Expression<Func<long>>) (() => cim_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignMemberView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignMemberView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CampaignMemberView>>> GetCampaignMemberList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cim_SiteID")] long cim_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cim_CampaignCode")] long cim_CampaignCode = 0,
      [NameConvert("p_cim_MemberNo")] long cim_MemberNo = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CampaignMemberView>>> campaignMemberList = new UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>(HttpMethod.Get);
      campaignMemberList.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cim_SiteID}/Campaign/{cim_CampaignCode}/Member/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignMemberList.Headers.Add("Send-Type", SendType);
      campaignMemberList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, long>((Expression<Func<long>>) (() => cim_SiteID));
      campaignMemberList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, long>((Expression<Func<long>>) (() => cim_CampaignCode));
      campaignMemberList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignMemberList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cim_MemberNo > 0L)
        campaignMemberList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, long>((Expression<Func<long>>) (() => cim_MemberNo));
      if (!string.IsNullOrEmpty(KeyWord))
        campaignMemberList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      campaignMemberList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CampaignMemberView>>>>(MethodBase.GetCurrentMethod());
      return campaignMemberList;
    }

    public static UniBizHttpRequest<UbRes<CampaignPromotionView>> GetCampaignPromotion(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cip_SiteID")] long cip_SiteID,
      [NameConvert("p_cip_CampaignCode")] long cip_CampaignCode,
      [NameConvert("p_cip_PromotionCode")] long cip_PromotionCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignPromotionView>> campaignPromotion = new UniBizHttpRequest<UbRes<CampaignPromotionView>>(HttpMethod.Get);
      campaignPromotion.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cip_SiteID}/Campaign/{cip_CampaignCode}/Promotion/{cip_PromotionCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignPromotion.Headers.Add("Send-Type", SendType);
      campaignPromotion.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_SiteID));
      campaignPromotion.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_CampaignCode));
      campaignPromotion.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_PromotionCode));
      campaignPromotion.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignPromotion.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      campaignPromotion.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignPromotionView>>>(MethodBase.GetCurrentMethod());
      return campaignPromotion;
    }

    public static UniBizHttpRequest<UbRes<CampaignPromotionView>> PostCampaignPromotion(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cip_SiteID")] long cip_SiteID,
      [NameConvert("p_cip_CampaignCode")] long cip_CampaignCode,
      [NameConvert("p_cip_PromotionCode")] long cip_PromotionCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CampaignPromotionView pData)
    {
      UniBizHttpRequest<UbRes<CampaignPromotionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignPromotionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cip_SiteID}/Campaign/{cip_CampaignCode}/Promotion/{cip_PromotionCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_PromotionCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CampaignPromotionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignPromotionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<CampaignPromotionView>> DeleteCampaignPromotion(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cip_SiteID")] long cip_SiteID,
      [NameConvert("p_cip_CampaignCode")] long cip_CampaignCode,
      [NameConvert("p_cip_PromotionCode")] long cip_PromotionCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignPromotionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignPromotionView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cip_SiteID}/Campaign/{cip_CampaignCode}/Promotion/{cip_PromotionCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, long>((Expression<Func<long>>) (() => cip_PromotionCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignPromotionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignPromotionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>> GetCampaignPromotionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cip_SiteID")] long cip_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cip_CampaignCode")] long cip_CampaignCode = 0,
      [NameConvert("p_cip_PromotionCode")] long cip_PromotionCode = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>> campaignPromotionList = new UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>(HttpMethod.Get);
      campaignPromotionList.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cip_SiteID}/Campaign/{cip_CampaignCode}/Promotion/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignPromotionList.Headers.Add("Send-Type", SendType);
      campaignPromotionList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, long>((Expression<Func<long>>) (() => cip_SiteID));
      campaignPromotionList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, long>((Expression<Func<long>>) (() => cip_CampaignCode));
      campaignPromotionList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignPromotionList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cip_PromotionCode > 0L)
        campaignPromotionList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, long>((Expression<Func<long>>) (() => cip_PromotionCode));
      if (!string.IsNullOrEmpty(KeyWord))
        campaignPromotionList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      campaignPromotionList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CampaignPromotionView>>>>(MethodBase.GetCurrentMethod());
      return campaignPromotionList;
    }

    public static UniBizHttpRequest<UbRes<CampaignStoreView>> GetCampaignStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cis_SiteID")] long cis_SiteID,
      [NameConvert("p_cis_CampaignCode")] long cis_CampaignCode,
      [NameConvert("p_cis_StoreCode")] int cis_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignStoreView>> campaignStore = new UniBizHttpRequest<UbRes<CampaignStoreView>>(HttpMethod.Get);
      campaignStore.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cis_SiteID}/Campaign/{cis_CampaignCode}/Store/{cis_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignStore.Headers.Add("Send-Type", SendType);
      campaignStore.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_SiteID));
      campaignStore.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_CampaignCode));
      campaignStore.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => cis_StoreCode));
      campaignStore.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignStore.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      campaignStore.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignStoreView>>>(MethodBase.GetCurrentMethod());
      return campaignStore;
    }

    public static UniBizHttpRequest<UbRes<CampaignStoreView>> PostCampaignStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cis_SiteID")] long cis_SiteID,
      [NameConvert("p_cis_CampaignCode")] long cis_CampaignCode,
      [NameConvert("p_cis_StoreCode")] int cis_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CampaignStoreView pData)
    {
      UniBizHttpRequest<UbRes<CampaignStoreView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignStoreView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cis_SiteID}/Campaign/{cis_CampaignCode}/Store/{cis_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => cis_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CampaignStoreView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignStoreView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<CampaignStoreView>> DeleteCampaignStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cis_SiteID")] long cis_SiteID,
      [NameConvert("p_cis_CampaignCode")] long cis_CampaignCode,
      [NameConvert("p_cis_StoreCode")] int cis_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CampaignStoreView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CampaignStoreView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cis_SiteID}/Campaign/{cis_CampaignCode}/Store/{cis_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, long>((Expression<Func<long>>) (() => cis_CampaignCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => cis_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CampaignStoreView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CampaignStoreView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CampaignStoreView>>> GetCampaignStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cis_SiteID")] long cis_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cis_CampaignCode")] long cis_CampaignCode = 0,
      [NameConvert("p_cis_StoreCode")] int cis_StoreCode = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CampaignStoreView>>> campaignStoreList = new UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>(HttpMethod.Get);
      campaignStoreList.Resource = UbRestModelAttribute.GetBasePath<CampaignInfoRestServer>() + "/{cis_SiteID}/Campaign/{cis_CampaignCode}/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      campaignStoreList.Headers.Add("Send-Type", SendType);
      campaignStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, long>((Expression<Func<long>>) (() => cis_SiteID));
      campaignStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, long>((Expression<Func<long>>) (() => cis_CampaignCode));
      campaignStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      campaignStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cis_StoreCode > 0)
        campaignStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, int>((Expression<Func<int>>) (() => cis_StoreCode));
      if (!string.IsNullOrEmpty(KeyWord))
        campaignStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      campaignStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CampaignStoreView>>>>(MethodBase.GetCurrentMethod());
      return campaignStoreList;
    }
  }
}
