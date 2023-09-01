// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsRestServer
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
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup;
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.BookmarkGoods
{
  [UbRestModel("/Code/BookmarkGoods", TableCodeType.Unknown, HeaderPath = "")]
  public class BookmarkGoodsRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> GetBookmarkGoodsGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgg_SiteID")] long bgg_SiteID,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> bookmarkGoodsGroup = new UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>(HttpMethod.Get);
      bookmarkGoodsGroup.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/Group/{bgg_SiteID}/{bgg_GroupID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      bookmarkGoodsGroup.Headers.Add("Send-Type", SendType);
      bookmarkGoodsGroup.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, long>((Expression<Func<long>>) (() => bgg_SiteID));
      bookmarkGoodsGroup.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      bookmarkGoodsGroup.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      bookmarkGoodsGroup.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (si_StoreCode > 0)
        bookmarkGoodsGroup.SetQuery<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      bookmarkGoodsGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>>(MethodBase.GetCurrentMethod());
      return bookmarkGoodsGroup;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> PostBookmarkGoodsGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgg_SiteID")] long bgg_SiteID,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      BookmarkGoodsGroupView pData)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/Group/{bgg_SiteID}/{bgg_GroupID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, long>((Expression<Func<long>>) (() => bgg_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<BookmarkGoodsGroupView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> DeleteBookmarkGoodsGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgg_SiteID")] long bgg_SiteID,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/Group/{bgg_SiteID}/{bgg_GroupID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, long>((Expression<Func<long>>) (() => bgg_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> DeleteBookmarkGoodsGroupDetails(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgg_SiteID")] long bgg_SiteID,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/Group/{bgg_SiteID}/{bgg_GroupID}/Details/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, long>((Expression<Func<long>>) (() => bgg_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsGroupView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>> GetBookmarkGoodsGroupList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgg_SiteID")] long bgg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_bgg_GroupName")] string bgg_GroupName = null,
      [NameConvert("p_bgg_UseYn")] string bgg_UseYn = null,
      [NameConvert("p_emp_code")] int emp_code = 0,
      [NameConvert("p_order_by")] int order_by = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0)
    {
      UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>> bookmarkGoodsGroupList = new UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>(HttpMethod.Get);
      bookmarkGoodsGroupList.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/Group/{bgg_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      bookmarkGoodsGroupList.Headers.Add("Send-Type", SendType);
      bookmarkGoodsGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, long>((Expression<Func<long>>) (() => bgg_SiteID));
      bookmarkGoodsGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      bookmarkGoodsGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (bgg_GroupID > 0)
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (!string.IsNullOrEmpty(bgg_GroupName))
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, string>((Expression<Func<string>>) (() => bgg_GroupName));
      if (!string.IsNullOrEmpty(bgg_UseYn))
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, string>((Expression<Func<string>>) (() => bgg_UseYn));
      if (emp_code > 0)
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => emp_code));
      if (order_by > 0)
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => order_by));
      if (!string.IsNullOrEmpty(KeyWord))
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      if (si_StoreCode > 0)
        bookmarkGoodsGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      bookmarkGoodsGroupList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<BookmarkGoodsGroupView>>>>(MethodBase.GetCurrentMethod());
      return bookmarkGoodsGroupList;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsListView>> GetBookmarkGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_bgl_GroupID")] int bgl_GroupID,
      [NameConvert("p_bgl_GoodsCode")] long bgl_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsListView>> bookmarkGoodsList = new UniBizHttpRequest<UbRes<BookmarkGoodsListView>>(HttpMethod.Get);
      bookmarkGoodsList.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{bgl_GroupID}/{bgl_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      bookmarkGoodsList.Headers.Add("Send-Type", SendType);
      bookmarkGoodsList.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      bookmarkGoodsList.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => bgl_GroupID));
      bookmarkGoodsList.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_GoodsCode));
      bookmarkGoodsList.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      bookmarkGoodsList.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      bookmarkGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>>(MethodBase.GetCurrentMethod());
      return bookmarkGoodsList;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsListView>> PostBookmarkGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_bgl_GroupID")] int bgl_GroupID,
      [NameConvert("p_bgl_GoodsCode")] long bgl_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      BookmarkGoodsListView pData)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsListView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BookmarkGoodsListView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{bgl_GroupID}/{bgl_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => bgl_GroupID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<BookmarkGoodsListView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<BookmarkGoodsListView>> DeleteBookmarkGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_bgl_GroupID")] int bgl_GroupID,
      [NameConvert("p_bgl_GoodsCode")] long bgl_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<BookmarkGoodsListView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<BookmarkGoodsListView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{bgl_GroupID}/{bgl_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => bgl_GroupID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, long>((Expression<Func<long>>) (() => bgl_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<BookmarkGoodsListView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> GetBookmarkGoodsGroupListList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_bgl_GroupID")] int bgl_GroupID = 0,
      [NameConvert("p_bgl_GoodsCode")] long bgl_GoodsCode = 0,
      [NameConvert("p_bgg_UseYn")] string bgg_UseYn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null,
      [NameConvert("p_is_BeforeDetails")] bool is_BeforeDetails = false)
    {
      UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> goodsGroupListList = new UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>(HttpMethod.Get);
      goodsGroupListList.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      goodsGroupListList.Headers.Add("Send-Type", SendType);
      goodsGroupListList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      goodsGroupListList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      goodsGroupListList.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (bgl_GroupID > 0)
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => bgl_GroupID));
      if (bgl_GoodsCode > 0L)
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, long>((Expression<Func<long>>) (() => bgl_GoodsCode));
      if (!string.IsNullOrEmpty(bgg_UseYn))
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, string>((Expression<Func<string>>) (() => bgg_UseYn));
      if (si_StoreCode > 0)
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (dt_date > 0L)
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (!string.IsNullOrEmpty(KeyWord))
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      if (is_BeforeDetails)
        goodsGroupListList.SetQuery<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, bool>((Expression<Func<bool>>) (() => is_BeforeDetails));
      goodsGroupListList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>>(MethodBase.GetCurrentMethod());
      return goodsGroupListList;
    }

    public static UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> PostBookmarkGoodsGroupListList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<BookmarkGoodsListView> pList)
    {
      UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<BookmarkGoodsListView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> DeleteBookmarkGoodsGroupListList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_bgl_SiteID")] long bgl_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<BookmarkGoodsListView> pList)
    {
      UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BookmarkGoodsRestServer>() + "/List/{bgl_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, long>((Expression<Func<long>>) (() => bgl_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<BookmarkGoodsListView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<BookmarkGoodsListView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
