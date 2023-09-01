// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.VanComp.VanCompRestServer
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

namespace UniBiz.Bo.Models.UniBase.VanCard.VanComp
{
  [UbRestModel("/Code/VanComp", TableCodeType.VanComp, HeaderPath = "")]
  public class VanCompRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<VanCompView>> GetVanCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_van_SiteID")] long van_SiteID,
      [NameConvert("p_van_ID")] int van_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<VanCompView>> vanCompGroup = new UniBizHttpRequest<UbRes<VanCompView>>(HttpMethod.Get);
      vanCompGroup.Resource = UbRestModelAttribute.GetBasePath<VanCompRestServer>() + "/{van_SiteID}/{van_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      vanCompGroup.Headers.Add("Send-Type", SendType);
      vanCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, long>((Expression<Func<long>>) (() => van_SiteID));
      vanCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => van_ID));
      vanCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      vanCompGroup.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      vanCompGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<VanCompView>>>(MethodBase.GetCurrentMethod());
      return vanCompGroup;
    }

    public static UniBizHttpRequest<UbRes<VanCompView>> PostVanCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_van_SiteID")] long van_SiteID,
      [NameConvert("p_van_ID")] int van_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      VanCompView pData)
    {
      UniBizHttpRequest<UbRes<VanCompView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<VanCompView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<VanCompRestServer>() + "/{van_SiteID}/{van_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, long>((Expression<Func<long>>) (() => van_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => van_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<VanCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<VanCompView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<VanCompView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<VanCompView>>> GetVanCompList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_van_SiteID")] long van_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_van_ID")] int van_ID = 0,
      [NameConvert("p_van_Name")] string van_Name = null,
      [NameConvert("p_van_UseYn")] string van_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<VanCompView>>> vanCompList = new UniBizHttpRequest<UbRes<IList<VanCompView>>>(HttpMethod.Get);
      vanCompList.Resource = UbRestModelAttribute.GetBasePath<VanCompRestServer>() + "/{van_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      vanCompList.Headers.Add("Send-Type", SendType);
      vanCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanCompView>>>, long>((Expression<Func<long>>) (() => van_SiteID));
      vanCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanCompView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      vanCompList.SetSegment<UniBizHttpRequest<UbRes<IList<VanCompView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (van_ID > 0)
        vanCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanCompView>>>, int>((Expression<Func<int>>) (() => van_ID));
      if (!string.IsNullOrEmpty(van_Name))
        vanCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanCompView>>>, string>((Expression<Func<string>>) (() => van_Name));
      if (!string.IsNullOrEmpty(van_UseYn))
        vanCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanCompView>>>, string>((Expression<Func<string>>) (() => van_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        vanCompList.SetQuery<UniBizHttpRequest<UbRes<IList<VanCompView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      vanCompList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<VanCompView>>>>(MethodBase.GetCurrentMethod());
      return vanCompList;
    }
  }
}
