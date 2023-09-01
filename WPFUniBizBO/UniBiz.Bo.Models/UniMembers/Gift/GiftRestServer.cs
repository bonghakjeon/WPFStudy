// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftRestServer
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
using UniBiz.Bo.Models.UniMembers.Gift.GiftItem;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniMembers.Gift
{
  [UbRestModel("/Member/Gift", TableCodeType.GiftItem, HeaderPath = "")]
  public class GiftRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<GiftItemView>> GetGiftItem(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GiftCode")] int gi_GiftCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GiftItemView>> giftItem = new UniBizHttpRequest<UbRes<GiftItemView>>(HttpMethod.Get);
      giftItem.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{gi_SiteID}/Item/{gi_GiftCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftItem.Headers.Add("Send-Type", SendType);
      giftItem.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      giftItem.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => gi_GiftCode));
      giftItem.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftItem.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      giftItem.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftItemView>>>(MethodBase.GetCurrentMethod());
      return giftItem;
    }

    public static UniBizHttpRequest<UbRes<GiftItemView>> PostGiftItem(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gi_SiteID")] long gi_SiteID,
      [NameConvert("p_gi_GiftCode")] int gi_GiftCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GiftItemView pData)
    {
      UniBizHttpRequest<UbRes<GiftItemView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GiftItemView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{gi_SiteID}/Item/{gi_GiftCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, long>((Expression<Func<long>>) (() => gi_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => gi_GiftCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftItemView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GiftItemView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftItemView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GiftItemView>>> GetGiftItemList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbr_SiteID")] long mbr_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gi_GiftCode")] int gi_GiftCode = 0,
      [NameConvert("p_gi_GiftName")] string gi_GiftName = null,
      [NameConvert("p_gi_UseYn")] string gi_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GiftItemView>>> giftItemList = new UniBizHttpRequest<UbRes<IList<GiftItemView>>>(HttpMethod.Get);
      giftItemList.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{mbr_SiteID}/Item/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftItemList.Headers.Add("Send-Type", SendType);
      giftItemList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, long>((Expression<Func<long>>) (() => mbr_SiteID));
      giftItemList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftItemList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gi_GiftCode > 0)
        giftItemList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, int>((Expression<Func<int>>) (() => gi_GiftCode));
      if (!string.IsNullOrEmpty(gi_GiftName))
        giftItemList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, string>((Expression<Func<string>>) (() => gi_GiftName));
      if (!string.IsNullOrEmpty(gi_UseYn))
        giftItemList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, string>((Expression<Func<string>>) (() => gi_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        giftItemList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftItemView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      giftItemList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GiftItemView>>>>(MethodBase.GetCurrentMethod());
      return giftItemList;
    }

    public static UniBizHttpRequest<UbRes<GiftGiveHistoryView>> GetGiftGiveHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ggh_SiteID")] long ggh_SiteID,
      [NameConvert("p_ggh_GiveNo")] long ggh_GiveNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GiftGiveHistoryView>> giftGiveHistory = new UniBizHttpRequest<UbRes<GiftGiveHistoryView>>(HttpMethod.Get);
      giftGiveHistory.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{ggh_SiteID}/GiveHistory/{ggh_GiveNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftGiveHistory.Headers.Add("Send-Type", SendType);
      giftGiveHistory.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, long>((Expression<Func<long>>) (() => ggh_SiteID));
      giftGiveHistory.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, long>((Expression<Func<long>>) (() => ggh_GiveNo));
      giftGiveHistory.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftGiveHistory.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      giftGiveHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>>(MethodBase.GetCurrentMethod());
      return giftGiveHistory;
    }

    public static UniBizHttpRequest<UbRes<GiftGiveHistoryView>> PostGiftGiveHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ggh_SiteID")] long ggh_SiteID,
      [NameConvert("p_ggh_GiveNo")] long ggh_GiveNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GiftGiveHistoryView pData)
    {
      UniBizHttpRequest<UbRes<GiftGiveHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GiftGiveHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{ggh_SiteID}/GiveHistory/{ggh_GiveNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, long>((Expression<Func<long>>) (() => ggh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, long>((Expression<Func<long>>) (() => ggh_GiveNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GiftGiveHistoryView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftGiveHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>> GetGiftGiveHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ggh_SiteID")] long ggh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ggh_GiveNo")] long ggh_GiveNo = 0,
      [NameConvert("p_ggh_RequestStore")] int ggh_RequestStore = 0,
      [NameConvert("p_ggh_RequestStoreIn")] string ggh_RequestStoreIn = null,
      [NameConvert("p_ggh_RequestDateBegin")] long ggh_RequestDateBegin = 0,
      [NameConvert("p_ggh_RequestDateEnd")] long ggh_RequestDateEnd = 0,
      [NameConvert("p_ggh_MemberNo")] long ggh_MemberNo = 0,
      [NameConvert("p_ggh_GiftCode")] int ggh_GiftCode = 0,
      [NameConvert("p_ggh_GiveStore")] int ggh_GiveStore = 0,
      [NameConvert("p_ggh_GiveStoreIn")] string ggh_GiveStoreIn = null,
      [NameConvert("p_ggh_GiveDateBegin")] long ggh_GiveDateBegin = 0,
      [NameConvert("p_ggh_GiveDateEnd")] long ggh_GiveDateEnd = 0,
      [NameConvert("p_ggh_Status")] int ggh_Status = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>> giftGiveHistoryList = new UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>(HttpMethod.Get);
      giftGiveHistoryList.Resource = UbRestModelAttribute.GetBasePath<GiftRestServer>() + "/{ggh_SiteID}/GiveHistory/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftGiveHistoryList.Headers.Add("Send-Type", SendType);
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_SiteID));
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftGiveHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ggh_GiveNo > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_GiveNo));
      if (ggh_RequestStore > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => ggh_RequestStore));
      if (!string.IsNullOrEmpty(ggh_RequestStoreIn))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => ggh_RequestStoreIn));
      if (ggh_RequestDateBegin > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_RequestDateBegin));
      if (ggh_RequestDateEnd > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_RequestDateEnd));
      if (ggh_MemberNo > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_MemberNo));
      if (ggh_GiftCode > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => ggh_GiftCode));
      if (ggh_GiveStore > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => ggh_GiveStore));
      if (!string.IsNullOrEmpty(ggh_GiveStoreIn))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => ggh_GiveStoreIn));
      if (ggh_GiveDateBegin > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_GiveDateBegin));
      if (ggh_GiveDateEnd > 0L)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, long>((Expression<Func<long>>) (() => ggh_GiveDateEnd));
      if (ggh_Status > 0)
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, int>((Expression<Func<int>>) (() => ggh_Status));
      if (!string.IsNullOrEmpty(KeyWord))
        giftGiveHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      giftGiveHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GiftGiveHistoryView>>>>(MethodBase.GetCurrentMethod());
      return giftGiveHistoryList;
    }
  }
}
