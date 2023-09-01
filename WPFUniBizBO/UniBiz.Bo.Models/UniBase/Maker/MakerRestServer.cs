// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Maker.MakerRestServer
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

namespace UniBiz.Bo.Models.UniBase.Maker
{
  [UbRestModel("/Code/Maker", TableCodeType.Maker, HeaderPath = "")]
  public class MakerRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<MakerView>> GetMaker(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mk_SiteID")] long mk_SiteID,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MakerView>> maker = new UniBizHttpRequest<UbRes<MakerView>>(HttpMethod.Get);
      maker.Resource = UbRestModelAttribute.GetBasePath<MakerRestServer>() + "/{mk_SiteID}/{mk_MakerCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      maker.Headers.Add("Send-Type", SendType);
      maker.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, long>((Expression<Func<long>>) (() => mk_SiteID));
      maker.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      maker.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      maker.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      maker.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MakerView>>>(MethodBase.GetCurrentMethod());
      return maker;
    }

    public static UniBizHttpRequest<UbRes<MakerView>> PostMaker(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mk_SiteID")] long mk_SiteID,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MakerView pData)
    {
      UniBizHttpRequest<UbRes<MakerView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MakerView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MakerRestServer>() + "/{mk_SiteID}/{mk_MakerCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, long>((Expression<Func<long>>) (() => mk_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MakerView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MakerView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MakerView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MakerView>>> GetMakerList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mk_SiteID")] long mk_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerName")] string mk_MakerName = null,
      [NameConvert("p_mk_UseYn")] string mk_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MakerView>>> makerList = new UniBizHttpRequest<UbRes<IList<MakerView>>>(HttpMethod.Get);
      makerList.Resource = UbRestModelAttribute.GetBasePath<MakerRestServer>() + "/{mk_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      makerList.Headers.Add("Send-Type", SendType);
      makerList.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, long>((Expression<Func<long>>) (() => mk_SiteID));
      makerList.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      makerList.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mk_MakerCode > 0)
        makerList.SetQuery<UniBizHttpRequest<UbRes<IList<MakerView>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerName))
        makerList.SetQuery<UniBizHttpRequest<UbRes<IList<MakerView>>>, string>((Expression<Func<string>>) (() => mk_MakerName));
      if (!string.IsNullOrEmpty(mk_UseYn))
        makerList.SetQuery<UniBizHttpRequest<UbRes<IList<MakerView>>>, string>((Expression<Func<string>>) (() => mk_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        makerList.SetQuery<UniBizHttpRequest<UbRes<IList<MakerView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      makerList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MakerView>>>>(MethodBase.GetCurrentMethod());
      return makerList;
    }

    public static UniBizHttpRequest<UbRes<IList<MakerView>>> PostMakerList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mk_SiteID")] long mk_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<MakerView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<MakerView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<MakerView>>>(HttpMethod.Get);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MakerRestServer>() + "/{mk_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, long>((Expression<Func<long>>) (() => mk_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<MakerView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<MakerView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MakerView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
