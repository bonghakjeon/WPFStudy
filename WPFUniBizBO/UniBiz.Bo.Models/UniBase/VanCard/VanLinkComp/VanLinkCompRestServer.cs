// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.VanLinkComp.VanLinkCompRestServer
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
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.VanCard.VanLinkComp
{
  [UbRestModel("/Code/VanLinkComp", TableCodeType.VanLinkComp, HeaderPath = "")]
  public class VanLinkCompRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<VanLinkCompView>> GetVanLinkCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_vlc_SiteID")] long vlc_SiteID,
      [NameConvert("p_vlc_VanID")] int vlc_VanID,
      [NameConvert("p_vlc_CardID")] int vlc_CardID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<VanLinkCompView>> vanLinkCompGroup = new UniBizHttpRequest<UbRes<VanLinkCompView>>(HttpMethod.Get);
      vanLinkCompGroup.Resource = UbRestModelAttribute.GetBasePath<VanLinkCompRestServer>() + "/{vlc_SiteID}/{vlc_VanID}/{vlc_CardID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      vanLinkCompGroup.Headers.Add("Send-Type", SendType);
      vanLinkCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, long>((Expression<Func<long>>) (() => vlc_SiteID));
      vanLinkCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => vlc_VanID));
      vanLinkCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => vlc_CardID));
      vanLinkCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      vanLinkCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      vanLinkCompGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<VanLinkCompView>>>(MethodBase.GetCurrentMethod());
      return vanLinkCompGroup;
    }

    public static UniBizHttpRequest<UbRes<VanLinkCompView>> PostVanLinkCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_vlc_SiteID")] long vlc_SiteID,
      [NameConvert("p_vlc_VanID")] int vlc_VanID,
      [NameConvert("p_vlc_CardID")] int vlc_CardID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      VanLinkCompView pData)
    {
      UniBizHttpRequest<UbRes<VanLinkCompView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<VanLinkCompView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<VanLinkCompRestServer>() + "/{vlc_SiteID}/{vlc_VanID}/{vlc_CardID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, long>((Expression<Func<long>>) (() => vlc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => vlc_VanID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => vlc_CardID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanLinkCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<VanLinkCompView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<VanLinkCompView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<VanLinkCompView>>> GetVanLinkCompList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_vlc_SiteID")] long vlc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_vlc_VanID")] int vlc_VanID = 0,
      [NameConvert("p_vlc_CardID")] int vlc_CardID = 0,
      [NameConvert("vlc_LinkComp")] string vlc_LinkComp = null,
      [NameConvert("p_vlc_UseYn")] string vlc_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<VanLinkCompView>>> vanLinkCompList = new UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>(HttpMethod.Get);
      vanLinkCompList.Resource = UbRestModelAttribute.GetBasePath<VanLinkCompRestServer>() + "/{vlc_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      vanLinkCompList.Headers.Add("Send-Type", SendType);
      vanLinkCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, long>((Expression<Func<long>>) (() => vlc_SiteID));
      vanLinkCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      vanLinkCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (vlc_VanID > 0)
        vanLinkCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, int>((Expression<Func<int>>) (() => vlc_VanID));
      if (vlc_CardID > 0)
        vanLinkCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, int>((Expression<Func<int>>) (() => vlc_CardID));
      if (!string.IsNullOrEmpty(vlc_LinkComp))
        vanLinkCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, string>((Expression<Func<string>>) (() => vlc_LinkComp));
      if (!string.IsNullOrEmpty(KeyWord))
        vanLinkCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      vanLinkCompList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<VanLinkCompView>>>>(MethodBase.GetCurrentMethod());
      return vanLinkCompList;
    }
  }
}
