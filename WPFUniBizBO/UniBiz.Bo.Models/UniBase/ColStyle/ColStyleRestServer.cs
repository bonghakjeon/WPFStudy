// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ColStyle.ColStyleRestServer
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

namespace UniBiz.Bo.Models.UniBase.ColStyle
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class ColStyleRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<ColStyleView>> GetColStyle(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cs_SiteID")] long cs_SiteID,
      [NameConvert("p_cs_Code")] int cs_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ColStyleView>> colStyle = new UniBizHttpRequest<UbRes<ColStyleView>>(HttpMethod.Get);
      colStyle.Resource = UbRestModelAttribute.GetBasePath<ColStyleRestServer>() + "/ColStyle/{cs_SiteID}/{cs_Code}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      colStyle.Headers.Add("Send-Type", SendType);
      colStyle.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, long>((Expression<Func<long>>) (() => cs_SiteID));
      colStyle.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => cs_Code));
      colStyle.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      colStyle.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      colStyle.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ColStyleView>>>(MethodBase.GetCurrentMethod());
      return colStyle;
    }

    public static UniBizHttpRequest<UbRes<ColStyleView>> PostColStyle(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cs_SiteID")] long cs_SiteID,
      [NameConvert("p_cs_Code")] int cs_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ColStyleView pData)
    {
      UniBizHttpRequest<UbRes<ColStyleView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ColStyleView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ColStyleRestServer>() + "/ColStyle/{cs_SiteID}/{cs_Code}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, long>((Expression<Func<long>>) (() => cs_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => cs_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ColStyleView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ColStyleView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ColStyleView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ColStyleView>>> GetColStyleList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cs_SiteID")] long cs_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cs_Code")] int cs_Code = 0,
      [NameConvert("p_cs_UseYn")] string cs_UseYn = null,
      [NameConvert("p_cs_Align")] int cs_Align = 0,
      [NameConvert("p_cs_Bold")] int cs_Bold = 0,
      [NameConvert("p_cs_Italic")] int cs_Italic = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ColStyleView>>> colStyleList = new UniBizHttpRequest<UbRes<IList<ColStyleView>>>(HttpMethod.Get);
      colStyleList.Resource = UbRestModelAttribute.GetBasePath<ColStyleRestServer>() + "/ColStyle/{cs_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      colStyleList.Headers.Add("Send-Type", SendType);
      colStyleList.SetSegment<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, long>((Expression<Func<long>>) (() => cs_SiteID));
      colStyleList.SetSegment<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      colStyleList.SetSegment<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cs_Code > 0)
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => cs_Code));
      if (!string.IsNullOrEmpty(cs_UseYn))
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, string>((Expression<Func<string>>) (() => cs_UseYn));
      if (cs_Align > 0)
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => cs_Align));
      if (cs_Bold > 0)
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => cs_Bold));
      if (cs_Italic > 0)
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, int>((Expression<Func<int>>) (() => cs_Italic));
      if (!string.IsNullOrEmpty(KeyWord))
        colStyleList.SetQuery<UniBizHttpRequest<UbRes<IList<ColStyleView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      colStyleList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ColStyleView>>>>(MethodBase.GetCurrentMethod());
      return colStyleList;
    }
  }
}
