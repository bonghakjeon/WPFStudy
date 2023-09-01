// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardInfoRestServer
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
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard;
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo
{
  [UbRestModel("/Code/GiftCardInfo", TableCodeType.GiftCard, HeaderPath = "")]
  public class GiftCardInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<GiftCardView>> GetGiftCard(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gc_SiteID")] long gc_SiteID,
      [NameConvert("p_gc_GiftCardID")] long gc_GiftCardID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false)
    {
      UniBizHttpRequest<UbRes<GiftCardView>> giftCard = new UniBizHttpRequest<UbRes<GiftCardView>>(HttpMethod.Get);
      giftCard.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gc_SiteID}/{gc_GiftCardID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftCard.Headers.Add("Send-Type", SendType);
      giftCard.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, long>((Expression<Func<long>>) (() => gc_SiteID));
      giftCard.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, long>((Expression<Func<long>>) (() => gc_GiftCardID));
      giftCard.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftCard.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isLtHistory)
        giftCard.SetQuery<UniBizHttpRequest<UbRes<GiftCardView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      giftCard.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftCardView>>>(MethodBase.GetCurrentMethod());
      return giftCard;
    }

    public static UniBizHttpRequest<UbRes<GiftCardView>> PostGiftCard(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gc_SiteID")] long gc_SiteID,
      [NameConvert("p_gc_GiftCardID")] long gc_GiftCardID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GiftCardView pData)
    {
      UniBizHttpRequest<UbRes<GiftCardView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GiftCardView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gc_SiteID}/{gc_GiftCardID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, long>((Expression<Func<long>>) (() => gc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, long>((Expression<Func<long>>) (() => gc_GiftCardID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GiftCardView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftCardView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GiftCardView>>> GetGiftCardList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gc_SiteID")] long gc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gc_GiftCardID")] long gc_GiftCardID = 0,
      [NameConvert("p_gc_GiftCardName")] string gc_GiftCardName = null,
      [NameConvert("p_gc_FaceValue")] int gc_FaceValue = 0,
      [NameConvert("p_gc_FaceValueBegin")] int gc_FaceValueBegin = 0,
      [NameConvert("p_gc_FaceValueEnd")] int gc_FaceValueEnd = 0,
      [NameConvert("p_gc_ExchangeMinAmt")] int gc_ExchangeMinAmt = 0,
      [NameConvert("p_gc_ExpireDate")] long gc_ExpireDate = 0,
      [NameConvert("p_gc_ExpireDateBegin")] long gc_ExpireDateBegin = 0,
      [NameConvert("p_gc_ExpireDateEnd")] long gc_ExpireDateEnd = 0,
      [NameConvert("p_gc_BuyPoint")] int gc_BuyPoint = 0,
      [NameConvert("p_gc_CashReceiptYn")] string gc_CashReceiptYn = null,
      [NameConvert("p_gc_PayableStore")] int gc_PayableStore = 0,
      [NameConvert("p_gc_PayableStoreIn")] string gc_PayableStoreIn = null,
      [NameConvert("p_gc_GiftCardIssuer")] int gc_GiftCardIssuer = 0,
      [NameConvert("p_gc_GoodsCode")] long gc_GoodsCode = 0,
      [NameConvert("p_gc_UseYn")] string gc_UseYn = null,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GiftCardView>>> giftCardList = new UniBizHttpRequest<UbRes<IList<GiftCardView>>>(HttpMethod.Get);
      giftCardList.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gc_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftCardList.Headers.Add("Send-Type", SendType);
      giftCardList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_SiteID));
      giftCardList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftCardList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (gc_GiftCardID > 0L)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_GiftCardID));
      if (!string.IsNullOrEmpty(gc_GiftCardName))
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, string>((Expression<Func<string>>) (() => gc_GiftCardName));
      if (gc_FaceValue > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_FaceValue));
      if (gc_FaceValueBegin > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_FaceValueBegin));
      if (gc_FaceValueEnd > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_FaceValueEnd));
      if (gc_ExchangeMinAmt > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_ExchangeMinAmt));
      if (gc_ExpireDate > 0L)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_ExpireDate));
      if (gc_ExpireDateBegin > 0L)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_ExpireDateBegin));
      if (gc_ExpireDateEnd > 0L)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_ExpireDateEnd));
      if (gc_BuyPoint > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_BuyPoint));
      if (!string.IsNullOrEmpty(gc_CashReceiptYn))
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, string>((Expression<Func<string>>) (() => gc_CashReceiptYn));
      if (gc_PayableStore > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_PayableStore));
      if (!string.IsNullOrEmpty(gc_PayableStoreIn))
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, string>((Expression<Func<string>>) (() => gc_PayableStoreIn));
      if (gc_GiftCardIssuer > 0)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, int>((Expression<Func<int>>) (() => gc_GiftCardIssuer));
      if (gc_GoodsCode > 0L)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, long>((Expression<Func<long>>) (() => gc_GoodsCode));
      if (!string.IsNullOrEmpty(gc_UseYn))
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, string>((Expression<Func<string>>) (() => gc_UseYn));
      if (isLtHistory)
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      if (!string.IsNullOrEmpty(KeyWord))
        giftCardList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      giftCardList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GiftCardView>>>>(MethodBase.GetCurrentMethod());
      return giftCardList;
    }

    public static UniBizHttpRequest<UbRes<GiftCardHistoryView>> GetGiftCardHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gch_SiteID")] long gch_SiteID,
      [NameConvert("p_gch_GiftCardNo")] string gch_GiftCardNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<GiftCardHistoryView>> giftCardHistory = new UniBizHttpRequest<UbRes<GiftCardHistoryView>>(HttpMethod.Get);
      giftCardHistory.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gch_SiteID}/History/{gch_GiftCardNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftCardHistory.Headers.Add("Send-Type", SendType);
      giftCardHistory.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, long>((Expression<Func<long>>) (() => gch_SiteID));
      giftCardHistory.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, string>((Expression<Func<string>>) (() => gch_GiftCardNo));
      giftCardHistory.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftCardHistory.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      giftCardHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftCardHistoryView>>>(MethodBase.GetCurrentMethod());
      return giftCardHistory;
    }

    public static UniBizHttpRequest<UbRes<GiftCardHistoryView>> PostGiftCardHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gch_SiteID")] long gch_SiteID,
      [NameConvert("p_gch_GiftCardNo")] string gch_GiftCardNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      GiftCardView pData)
    {
      UniBizHttpRequest<UbRes<GiftCardHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<GiftCardHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gch_SiteID}/History/{gch_GiftCardNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, long>((Expression<Func<long>>) (() => gch_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, string>((Expression<Func<string>>) (() => gch_GiftCardNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<GiftCardHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<GiftCardView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<GiftCardHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>> GetGiftCardHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_gch_SiteID")] long gch_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_gch_GiftCardNo")] string gch_GiftCardNo = null,
      [NameConvert("p_gch_GiftCardID")] long gch_GiftCardID = 0,
      [NameConvert("p_gch_IssueDate")] long gch_IssueDate = 0,
      [NameConvert("p_gch_IssueDateBegin")] long gch_IssueDateBegin = 0,
      [NameConvert("p_gch_IssueDateEnd")] long gch_IssueDateEnd = 0,
      [NameConvert("p_gch_IssueStore")] int gch_IssueStore = 0,
      [NameConvert("p_gch_IssueStoreIn")] string gch_IssueStoreIn = null,
      [NameConvert("p_gch_FaceValue")] int gch_FaceValue = 0,
      [NameConvert("p_gch_FaceValueBegin")] int gch_FaceValueBegin = 0,
      [NameConvert("p_gch_FaceValueEnd")] int gch_FaceValueEnd = 0,
      [NameConvert("p_gch_ExpireDate")] long gch_ExpireDate = 0,
      [NameConvert("p_gch_ExpireDateBegin")] long gch_ExpireDateBegin = 0,
      [NameConvert("p_gch_ExpireDateEnd")] long gch_ExpireDateEnd = 0,
      [NameConvert("p_gch_SaleDate")] long gch_SaleDate = 0,
      [NameConvert("p_gch_SaleDateBegin")] long gch_SaleDateBegin = 0,
      [NameConvert("p_gch_SaleDateEnd")] long gch_SaleDateEnd = 0,
      [NameConvert("p_gch_SaleStore")] int gch_SaleStore = 0,
      [NameConvert("p_gch_SaleStoreIn")] string gch_SaleStoreIn = null,
      [NameConvert("p_gch_SalePosNo")] int gch_SalePosNo = 0,
      [NameConvert("p_gch_SaleTransNo")] int gch_SaleTransNo = 0,
      [NameConvert("p_gch_SaleEmpCode")] int gch_SaleEmpCode = 0,
      [NameConvert("p_gch_SaleMemberNo")] long gch_SaleMemberNo = 0,
      [NameConvert("p_gch_SaleKind")] int gch_SaleKind = 0,
      [NameConvert("p_gch_ReturnDate")] long gch_ReturnDate = 0,
      [NameConvert("p_gch_ReturnDateBegin")] long gch_ReturnDateBegin = 0,
      [NameConvert("p_gch_ReturnDateEnd")] long gch_ReturnDateEnd = 0,
      [NameConvert("p_gch_ReturnStore")] int gch_ReturnStore = 0,
      [NameConvert("p_gch_ReturnStoreIn")] string gch_ReturnStoreIn = null,
      [NameConvert("p_gch_ReturnPosNo")] int gch_ReturnPosNo = 0,
      [NameConvert("p_gch_ReturnTransNo")] int gch_ReturnTransNo = 0,
      [NameConvert("p_gch_ReturnMemberNo")] long gch_ReturnMemberNo = 0,
      [NameConvert("p_gch_DisuseYn")] string gch_DisuseYn = null,
      [NameConvert("p_gch_DisuseDate")] long gch_DisuseDate = 0,
      [NameConvert("p_gch_DisuseDateBegin")] long gch_DisuseDateBegin = 0,
      [NameConvert("p_gch_DisuseDateEnd")] long gch_DisuseDateEnd = 0,
      [NameConvert("p_gch_DisuseStatement")] long gch_DisuseStatement = 0,
      [NameConvert("p_gch_DisuseEmpCode")] int gch_DisuseEmpCode = 0,
      [NameConvert("p_gch_UseYn")] string gch_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>> giftCardHistoryList = new UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>(HttpMethod.Get);
      giftCardHistoryList.Resource = UbRestModelAttribute.GetBasePath<GiftCardInfoRestServer>() + "/{gch_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      giftCardHistoryList.Headers.Add("Send-Type", SendType);
      giftCardHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_SiteID));
      giftCardHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      giftCardHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(gch_GiftCardNo))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_GiftCardNo));
      if (gch_GiftCardID > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_GiftCardID));
      if (gch_IssueDate > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_IssueDate));
      if (gch_IssueDateBegin > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_IssueDateBegin));
      if (gch_IssueDateEnd > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_IssueDateEnd));
      if (gch_IssueStore > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_IssueStore));
      if (!string.IsNullOrEmpty(gch_IssueStoreIn))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_IssueStoreIn));
      if (gch_FaceValue > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_FaceValue));
      if (gch_FaceValueBegin > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_FaceValueBegin));
      if (gch_FaceValueEnd > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_FaceValueEnd));
      if (gch_ExpireDate > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ExpireDate));
      if (gch_ExpireDateBegin > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ExpireDateBegin));
      if (gch_ExpireDateEnd > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ExpireDateEnd));
      if (gch_SaleDate > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_SaleDate));
      if (gch_SaleDateBegin > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_SaleDateBegin));
      if (gch_SaleDateEnd > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_SaleDateEnd));
      if (gch_SaleStore > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_SaleStore));
      if (!string.IsNullOrEmpty(gch_SaleStoreIn))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_SaleStoreIn));
      if (gch_SalePosNo > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_SalePosNo));
      if (gch_SaleTransNo > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_SaleTransNo));
      if (gch_SaleEmpCode > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_SaleEmpCode));
      if (gch_SaleMemberNo > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_SaleMemberNo));
      if (gch_SaleKind > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_SaleKind));
      if (gch_ReturnDate > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ReturnDate));
      if (gch_ReturnDateBegin > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ReturnDateBegin));
      if (gch_ReturnDateEnd > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ReturnDateEnd));
      if (gch_ReturnStore > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_ReturnStore));
      if (!string.IsNullOrEmpty(gch_ReturnStoreIn))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_ReturnStoreIn));
      if (gch_ReturnPosNo > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_ReturnPosNo));
      if (gch_ReturnTransNo > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_ReturnTransNo));
      if (gch_ReturnMemberNo > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_ReturnMemberNo));
      if (!string.IsNullOrEmpty(gch_DisuseYn))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_DisuseYn));
      if (gch_DisuseDate > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_DisuseDate));
      if (gch_DisuseDateBegin > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_DisuseDateBegin));
      if (gch_DisuseDateEnd > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_DisuseDateEnd));
      if (gch_DisuseStatement > 0L)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, long>((Expression<Func<long>>) (() => gch_DisuseStatement));
      if (gch_DisuseEmpCode > 0)
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, int>((Expression<Func<int>>) (() => gch_DisuseEmpCode));
      if (!string.IsNullOrEmpty(gch_UseYn))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => gch_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        giftCardHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      giftCardHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GiftCardHistoryView>>>>(MethodBase.GetCurrentMethod());
      return giftCardHistoryList;
    }
  }
}
