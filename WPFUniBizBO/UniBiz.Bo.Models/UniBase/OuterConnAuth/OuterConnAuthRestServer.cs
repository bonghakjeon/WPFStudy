// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.OuterConnAuthRestServer
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

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class OuterConnAuthRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<OuterConnAuthView>> GetOuterConnAuth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_oca_SiteID")] long oca_SiteID,
      [NameConvert("p_oca_ID")] int oca_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<OuterConnAuthView>> outerConnAuth = new UniBizHttpRequest<UbRes<OuterConnAuthView>>(HttpMethod.Get);
      outerConnAuth.Resource = UbRestModelAttribute.GetBasePath<OuterConnAuthRestServer>() + "/OuterConnAuth/{oca_SiteID}/{oca_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      outerConnAuth.Headers.Add("Send-Type", SendType);
      outerConnAuth.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, long>((Expression<Func<long>>) (() => oca_SiteID));
      outerConnAuth.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => oca_ID));
      outerConnAuth.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      outerConnAuth.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      outerConnAuth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<OuterConnAuthView>>>(MethodBase.GetCurrentMethod());
      return outerConnAuth;
    }

    public static UniBizHttpRequest<UbRes<OuterConnAuthView>> PostOuterConnAuthDeviceKey(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_oca_SiteID")] long oca_SiteID,
      [NameConvert("p_oca_ID")] int oca_ID,
      [NameConvert("p_oca_ProgKind")] int oca_ProgKind,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_oca_DeviceKey)
    {
      UniBizHttpRequest<UbRes<OuterConnAuthView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<OuterConnAuthView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<OuterConnAuthRestServer>() + "/OuterConnAuth/{oca_SiteID}/{oca_ID}/{oca_ProgKind}/Auth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, long>((Expression<Func<long>>) (() => oca_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => oca_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => oca_ProgKind));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_oca_DeviceKey, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<OuterConnAuthView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>> GetOuterConnAuthList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_oca_SiteID")] long oca_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_oca_ID")] int oca_ID = 0,
      [NameConvert("p_oca_ProgKind")] int oca_ProgKind = 0,
      [NameConvert("p_oca_Status")] int oca_Status = 0,
      [NameConvert("p_oca_DeviceKey")] string oca_DeviceKey = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>> outerConnAuthList = new UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>(HttpMethod.Get);
      outerConnAuthList.Resource = UbRestModelAttribute.GetBasePath<OuterConnAuthRestServer>() + "/OuterConnAuth/{oca_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      outerConnAuthList.Headers.Add("Send-Type", SendType);
      outerConnAuthList.SetSegment<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, long>((Expression<Func<long>>) (() => oca_SiteID));
      outerConnAuthList.SetSegment<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      outerConnAuthList.SetSegment<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (oca_ID > 0)
        outerConnAuthList.SetQuery<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, int>((Expression<Func<int>>) (() => oca_ID));
      if (oca_ProgKind > 0)
        outerConnAuthList.SetQuery<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, int>((Expression<Func<int>>) (() => oca_ProgKind));
      if (oca_Status > 0)
        outerConnAuthList.SetQuery<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, int>((Expression<Func<int>>) (() => oca_Status));
      if (!string.IsNullOrEmpty(oca_DeviceKey))
        outerConnAuthList.SetQuery<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, string>((Expression<Func<string>>) (() => oca_DeviceKey));
      if (!string.IsNullOrEmpty(KeyWord))
        outerConnAuthList.SetQuery<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      outerConnAuthList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<OuterConnAuthView>>>>(MethodBase.GetCurrentMethod());
      return outerConnAuthList;
    }

    public static UniBizHttpRequest<UbRes<OuterConnAuthView>> PostOuterConnAuth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_oca_SiteID")] long oca_SiteID,
      [NameConvert("p_oca_ID")] int oca_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      OuterConnAuthView pData)
    {
      UniBizHttpRequest<UbRes<OuterConnAuthView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<OuterConnAuthView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<OuterConnAuthRestServer>() + "/OuterConnAuth/{oca_SiteID}/{oca_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, long>((Expression<Func<long>>) (() => oca_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => oca_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<OuterConnAuthView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<OuterConnAuthView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<OuterConnAuthView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
