// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.UniSite.UniSiteRestServer
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
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.UniSite
{
  [UbRestModel("/Code/UniSite", TableCodeType.UniSite, HeaderPath = "")]
  public class UniSiteRestServer : UniSiteView
  {
    public static UniBizHttpRequest<UbRes<UniSiteView>> Get([NameConvert("Send-Type")] string SendType, [NameConvert("p_uis_SiteID")] long uis_SiteID)
    {
      UniBizHttpRequest<UbRes<UniSiteView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<UniSiteView>>(HttpMethod.Get);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniSiteRestServer>() + "/{uis_SiteID}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<UniSiteView>>, long>((Expression<Func<long>>) (() => uis_SiteID));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<UniSiteView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<UniSiteView>> Post(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_uis_SiteID")] long uis_SiteID,
      UniSiteView pData)
    {
      UniBizHttpRequest<UbRes<UniSiteView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<UniSiteView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniSiteRestServer>() + "/{uis_SiteID}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<UniSiteView>>, long>((Expression<Func<long>>) (() => uis_SiteID));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<UniSiteView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<UniSiteView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<TUniSite>>> GetTList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_uis_SiteType")] int uis_SiteType = 0)
    {
      UniBizHttpRequest<UbRes<IList<TUniSite>>> tlist = new UniBizHttpRequest<UbRes<IList<TUniSite>>>(HttpMethod.Get);
      tlist.Resource = UbRestModelAttribute.GetBasePath<UniSiteRestServer>() + "/TUniSite";
      tlist.Headers.Add("Send-Type", SendType);
      if (uis_SiteType > 0)
        tlist.SetQuery<UniBizHttpRequest<UbRes<IList<TUniSite>>>, int>((Expression<Func<int>>) (() => uis_SiteType));
      tlist.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<TUniSite>>>>(MethodBase.GetCurrentMethod());
      return tlist;
    }

    public static UniBizHttpRequest<UbRes<IList<UniSiteView>>> GetList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_uis_SiteID")] long uis_SiteID = 0,
      [NameConvert("p_uis_SiteType")] int uis_SiteType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<UniSiteView>>> list = new UniBizHttpRequest<UbRes<IList<UniSiteView>>>(HttpMethod.Get);
      list.Resource = UbRestModelAttribute.GetBasePath<UniSiteRestServer>();
      list.Headers.Add("Send-Type", SendType);
      if (uis_SiteID > 0L)
        list.SetQuery<UniBizHttpRequest<UbRes<IList<UniSiteView>>>, long>((Expression<Func<long>>) (() => uis_SiteID));
      if (uis_SiteType > 0)
        list.SetQuery<UniBizHttpRequest<UbRes<IList<UniSiteView>>>, int>((Expression<Func<int>>) (() => uis_SiteType));
      if (KeyWord != null && KeyWord.Length > 0)
        list.SetQuery<UniBizHttpRequest<UbRes<IList<UniSiteView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      list.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<UniSiteView>>>>(MethodBase.GetCurrentMethod());
      return list;
    }
  }
}
