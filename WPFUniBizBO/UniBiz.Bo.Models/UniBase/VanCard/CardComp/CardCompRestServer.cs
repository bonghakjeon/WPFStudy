// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.CardComp.CardCompRestServer
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

namespace UniBiz.Bo.Models.UniBase.VanCard.CardComp
{
  [UbRestModel("/Code/CardComp", TableCodeType.CardComp, HeaderPath = "")]
  public class CardCompRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<CardCompView>> GetCardCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cc_SiteID")] long cc_SiteID,
      [NameConvert("p_cc_ID")] int cc_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CardCompView>> cardCompGroup = new UniBizHttpRequest<UbRes<CardCompView>>(HttpMethod.Get);
      cardCompGroup.Resource = UbRestModelAttribute.GetBasePath<CardCompRestServer>() + "/{cc_SiteID}/{cc_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      cardCompGroup.Headers.Add("Send-Type", SendType);
      cardCompGroup.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, long>((Expression<Func<long>>) (() => cc_SiteID));
      cardCompGroup.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => cc_ID));
      cardCompGroup.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      cardCompGroup.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      cardCompGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CardCompView>>>(MethodBase.GetCurrentMethod());
      return cardCompGroup;
    }

    public static UniBizHttpRequest<UbRes<CardCompView>> PostCardCompGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cc_SiteID")] long cc_SiteID,
      [NameConvert("p_cc_ID")] int cc_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CardCompView pData)
    {
      UniBizHttpRequest<UbRes<CardCompView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CardCompView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CardCompRestServer>() + "/{cc_SiteID}/{cc_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, long>((Expression<Func<long>>) (() => cc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => cc_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CardCompView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CardCompView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CardCompView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CardCompView>>> GetCardCompList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_cc_SiteID")] long cc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_cc_ID")] int cc_ID = 0,
      [NameConvert("p_cc_Name")] string cc_Name = null,
      [NameConvert("p_cc_UseYn")] string cc_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CardCompView>>> cardCompList = new UniBizHttpRequest<UbRes<IList<CardCompView>>>(HttpMethod.Get);
      cardCompList.Resource = UbRestModelAttribute.GetBasePath<CardCompRestServer>() + "/{cc_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      cardCompList.Headers.Add("Send-Type", SendType);
      cardCompList.SetSegment<UniBizHttpRequest<UbRes<IList<CardCompView>>>, long>((Expression<Func<long>>) (() => cc_SiteID));
      cardCompList.SetSegment<UniBizHttpRequest<UbRes<IList<CardCompView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      cardCompList.SetSegment<UniBizHttpRequest<UbRes<IList<CardCompView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (cc_ID > 0)
        cardCompList.SetQuery<UniBizHttpRequest<UbRes<IList<CardCompView>>>, int>((Expression<Func<int>>) (() => cc_ID));
      if (!string.IsNullOrEmpty(cc_Name))
        cardCompList.SetQuery<UniBizHttpRequest<UbRes<IList<CardCompView>>>, string>((Expression<Func<string>>) (() => cc_Name));
      if (!string.IsNullOrEmpty(cc_UseYn))
        cardCompList.SetQuery<UniBizHttpRequest<UbRes<IList<CardCompView>>>, string>((Expression<Func<string>>) (() => cc_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        cardCompList.SetQuery<UniBizHttpRequest<UbRes<IList<CardCompView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      cardCompList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CardCompView>>>>(MethodBase.GetCurrentMethod());
      return cardCompList;
    }
  }
}
