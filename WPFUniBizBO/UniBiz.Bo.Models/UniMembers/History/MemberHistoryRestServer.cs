// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberHistoryRestServer
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
using UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory;
using UniBiz.Bo.Models.UniMembers.History.MemberPointHistory;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniMembers.History
{
  [UbRestModel("/Member/History", TableCodeType.GiftItem, HeaderPath = "")]
  public class MemberHistoryRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<MemberPointHistoryView>> GetMemberPointHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mph_SiteID")] long mph_SiteID,
      [NameConvert("p_mph_Seq")] long mph_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberPointHistoryView>> memberPointHistory = new UniBizHttpRequest<UbRes<MemberPointHistoryView>>(HttpMethod.Get);
      memberPointHistory.Resource = UbRestModelAttribute.GetBasePath<MemberHistoryRestServer>() + "/{mph_SiteID}/PointHistory/{mph_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberPointHistory.Headers.Add("Send-Type", SendType);
      memberPointHistory.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, long>((Expression<Func<long>>) (() => mph_SiteID));
      memberPointHistory.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, long>((Expression<Func<long>>) (() => mph_Seq));
      memberPointHistory.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberPointHistory.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberPointHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberPointHistoryView>>>(MethodBase.GetCurrentMethod());
      return memberPointHistory;
    }

    public static UniBizHttpRequest<UbRes<MemberPointHistoryView>> PostGiftGiveHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mph_SiteID")] long mph_SiteID,
      [NameConvert("p_mph_Seq")] long mph_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberPointHistoryView pData)
    {
      UniBizHttpRequest<UbRes<MemberPointHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberPointHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberHistoryRestServer>() + "/{mph_SiteID}/PointHistory/{mph_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, long>((Expression<Func<long>>) (() => mph_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, long>((Expression<Func<long>>) (() => mph_Seq));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberPointHistoryView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberPointHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>> GetGiftGiveHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mph_SiteID")] long mph_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mph_Seq")] long mph_Seq = 0,
      [NameConvert("p_mph_SaleDateBegin")] long mph_SaleDateBegin = 0,
      [NameConvert("p_mph_SaleDateEnd")] long mph_SaleDateEnd = 0,
      [NameConvert("p_mph_StoreCode")] int mph_StoreCode = 0,
      [NameConvert("p_mph_StoreCodeIn")] string mph_StoreCodeIn = null,
      [NameConvert("p_mph_MemberNo")] long mph_MemberNo = 0,
      [NameConvert("p_mph_MemberCardNo")] string mph_MemberCardNo = null,
      [NameConvert("p_mph_PointType")] int mph_PointType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>> giftGiveHistoryList = new UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>(HttpMethod.Get);
      giftGiveHistoryList.Resource = UbRestModelAttribute.GetBasePath<MemberHistoryRestServer>() + "/{mph_SiteID}/PointHistory/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftGiveHistoryList.Headers.Add("Send-Type", SendType);
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => mph_SiteID));
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mph_Seq > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => mph_Seq));
      if (mph_SaleDateBegin > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => mph_SaleDateBegin));
      if (mph_SaleDateEnd > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => mph_SaleDateEnd));
      if (mph_StoreCode > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => mph_StoreCode));
      if (!string.IsNullOrEmpty(mph_StoreCodeIn))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => mph_StoreCodeIn));
      if (mph_MemberNo > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => mph_MemberNo));
      if (!string.IsNullOrEmpty(mph_MemberCardNo))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => mph_MemberCardNo));
      if (mph_PointType > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => mph_PointType));
      if (!string.IsNullOrEmpty(KeyWord))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      giftGiveHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>>(MethodBase.GetCurrentMethod());
      return giftGiveHistoryList;
    }
  }
}
