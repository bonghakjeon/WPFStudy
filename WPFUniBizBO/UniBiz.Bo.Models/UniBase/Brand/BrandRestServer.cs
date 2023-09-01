// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Brand.BrandRestServer
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

namespace UniBiz.Bo.Models.UniBase.Brand
{
  [UbRestModel("/Code/Brand", TableCodeType.Brand, HeaderPath = "")]
  public class BrandRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<BrandView>> GetBrandGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_br_SiteID")] long br_SiteID,
      [NameConvert("p_br_BrandCode")] int br_BrandCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<BrandView>> brandGroup = new UniBizHttpRequest<UbRes<BrandView>>(HttpMethod.Get);
      brandGroup.Resource = UbRestModelAttribute.GetBasePath<BrandRestServer>() + "/{br_SiteID}/{br_BrandCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      brandGroup.Headers.Add("Send-Type", SendType);
      brandGroup.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, long>((Expression<Func<long>>) (() => br_SiteID));
      brandGroup.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      brandGroup.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      brandGroup.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      brandGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BrandView>>>(MethodBase.GetCurrentMethod());
      return brandGroup;
    }

    public static UniBizHttpRequest<UbRes<BrandView>> PostBrandGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_br_SiteID")] long br_SiteID,
      [NameConvert("p_br_BrandCode")] int br_BrandCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      BrandView pData)
    {
      UniBizHttpRequest<UbRes<BrandView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BrandView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BrandRestServer>() + "/{br_SiteID}/{br_BrandCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, long>((Expression<Func<long>>) (() => br_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BrandView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<BrandView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BrandView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<BrandView>>> GetBrandList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_br_SiteID")] long br_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandName")] string br_BrandName = null,
      [NameConvert("p_br_UseYn")] string br_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<BrandView>>> brandList = new UniBizHttpRequest<UbRes<IList<BrandView>>>(HttpMethod.Get);
      brandList.Resource = UbRestModelAttribute.GetBasePath<BrandRestServer>() + "/{br_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      brandList.Headers.Add("Send-Type", SendType);
      brandList.SetSegment<UniBizHttpRequest<UbRes<IList<BrandView>>>, long>((Expression<Func<long>>) (() => br_SiteID));
      brandList.SetSegment<UniBizHttpRequest<UbRes<IList<BrandView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      brandList.SetSegment<UniBizHttpRequest<UbRes<IList<BrandView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (br_BrandCode > 0)
        brandList.SetQuery<UniBizHttpRequest<UbRes<IList<BrandView>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandName))
        brandList.SetQuery<UniBizHttpRequest<UbRes<IList<BrandView>>>, string>((Expression<Func<string>>) (() => br_BrandName));
      if (!string.IsNullOrEmpty(br_UseYn))
        brandList.SetQuery<UniBizHttpRequest<UbRes<IList<BrandView>>>, string>((Expression<Func<string>>) (() => br_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        brandList.SetQuery<UniBizHttpRequest<UbRes<IList<BrandView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      brandList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<BrandView>>>>(MethodBase.GetCurrentMethod());
      return brandList;
    }
  }
}
