// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberInfoRestServer
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
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBiz.Bo.Models.UniMembers.Info.MemberCard;
using UniBiz.Bo.Models.UniMembers.Info.MemberGrade;
using UniBiz.Bo.Models.UniMembers.Info.MemberGroup;
using UniBiz.Bo.Models.UniMembers.Info.MemberType;
using UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniMembers.Info
{
  [UbRestModel("/Member/Info", TableCodeType.Member, HeaderPath = "")]
  public class MemberInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<MemberView>> GetMember(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbr_SiteID")] long mbr_SiteID,
      [NameConvert("p_mbr_MemberNo")] long mbr_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtMemberCard")] bool isLtMemberCard = false)
    {
      UniBizHttpRequest<UbRes<MemberView>> member = new UniBizHttpRequest<UbRes<MemberView>>(HttpMethod.Get);
      member.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbr_SiteID}/{mbr_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      member.Headers.Add("Send-Type", SendType);
      member.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, long>((Expression<Func<long>>) (() => mbr_SiteID));
      member.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, long>((Expression<Func<long>>) (() => mbr_MemberNo));
      member.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      member.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isLtMemberCard)
        member.SetQuery<UniBizHttpRequest<UbRes<MemberView>>, bool>((Expression<Func<bool>>) (() => isLtMemberCard));
      member.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberView>>>(MethodBase.GetCurrentMethod());
      return member;
    }

    public static UniBizHttpRequest<UbRes<MemberView>> PostMember(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbr_SiteID")] long mbr_SiteID,
      [NameConvert("p_mbr_MemberNo")] long mbr_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberView pData)
    {
      UniBizHttpRequest<UbRes<MemberView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbr_SiteID}/{mbr_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, long>((Expression<Func<long>>) (() => mbr_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, long>((Expression<Func<long>>) (() => mbr_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberView>>> GetMemberList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbr_SiteID")] long mbr_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mbr_MemberNo")] long mbr_MemberNo = 0,
      [NameConvert("p_mbr_MemberName")] string mbr_MemberName = null,
      [NameConvert("p_mbr_MemberType")] int mbr_MemberType = 0,
      [NameConvert("p_mbr_MemberCycle")] int mbr_MemberCycle = 0,
      [NameConvert("p_mbr_MemberGrade")] int mbr_MemberGrade = 0,
      [NameConvert("p_mbr_GroupCode")] string mbr_GroupCode = null,
      [NameConvert("p_mbr_Status")] int mbr_Status = 0,
      [NameConvert("p_mbr_CashReceiptDiv")] int mbr_CashReceiptDiv = 0,
      [NameConvert("p_si_MemberMntStore")] int si_MemberMntStore = 0,
      [NameConvert("p_mbr_RegStore")] int mbr_RegStore = 0,
      [NameConvert("p_mbr_LastVisitStore")] int mbr_LastVisitStore = 0,
      [NameConvert("p_mbr_LastVisitDateBegin")] long mbr_LastVisitDateBegin = 0,
      [NameConvert("p_mbr_LastVisitDateEnd")] long mbr_LastVisitDateEnd = 0,
      [NameConvert("p_mbr_SmsSendAgree")] int mbr_SmsSendAgree = 0,
      [NameConvert("p_mbr_SmsFailCntNext")] int mbr_SmsFailCntNext = 0,
      [NameConvert("p_mbr_LastSmsSendDateBegin")] long mbr_LastSmsSendDateBegin = 0,
      [NameConvert("p_mbr_LastSmsSendDateEnd")] long mbr_LastSmsSendDateEnd = 0,
      [NameConvert("p_mbr_ZipCode")] string mbr_ZipCode = null,
      [NameConvert("p_mbr_Gender")] int mbr_Gender = 0,
      [NameConvert("p_mbr_TaxBillYn")] string mbr_TaxBillYn = null,
      [NameConvert("p_mbr_IsCreditLimitAmt")] bool? mbr_IsCreditLimitAmt = null,
      [NameConvert("p_mbr_IsCreditAmt")] bool? mbr_IsCreditAmt = null,
      [NameConvert("p_mbr_InDateBegin")] long mbr_InDateBegin = 0,
      [NameConvert("p_mbr_InDateEnd")] long mbr_InDateEnd = 0,
      [NameConvert("p_mbr_ModDateBegin")] long mbr_ModDateBegin = 0,
      [NameConvert("p_mbr_ModDateEnd")] long mbr_ModDateEnd = 0,
      [NameConvert("p_MemberTypeHistoryDate")] long MemberTypeHistoryDate = 0,
      [NameConvert("p_IsMemberCardInclude")] bool IsMemberCardInclude = false,
      [NameConvert("p_IsMemberCardIMainnclude")] bool IsMemberCardIMainnclude = false,
      [NameConvert("p_mbrc_MemberCardNo")] string mbrc_MemberCardNo = null,
      [NameConvert("p_mbrc_CardType")] int mbrc_CardType = 0,
      [NameConvert("p_mbrc_UseYn")] string mbrc_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null,
      [NameConvert("p_isLtMemberCard")] bool isLtMemberCard = false)
    {
      UniBizHttpRequest<UbRes<IList<MemberView>>> memberList = new UniBizHttpRequest<UbRes<IList<MemberView>>>(HttpMethod.Get);
      memberList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbr_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberList.Headers.Add("Send-Type", SendType);
      memberList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_SiteID));
      memberList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mbr_MemberNo > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_MemberNo));
      if (!string.IsNullOrEmpty(mbr_MemberName))
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbr_MemberName));
      if (mbr_MemberType > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_MemberType));
      if (mbr_MemberCycle > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_MemberCycle));
      if (mbr_MemberGrade > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_MemberGrade));
      if (!string.IsNullOrEmpty(mbr_GroupCode))
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbr_GroupCode));
      if (mbr_Status > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_Status));
      if (mbr_CashReceiptDiv > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_CashReceiptDiv));
      if (si_MemberMntStore > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => si_MemberMntStore));
      if (mbr_RegStore > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_RegStore));
      if (mbr_LastVisitStore > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_LastVisitStore));
      if (mbr_LastVisitDateBegin > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_LastVisitDateBegin));
      if (mbr_LastVisitDateEnd > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_LastVisitDateEnd));
      if (mbr_SmsSendAgree > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_SmsSendAgree));
      if (mbr_SmsFailCntNext > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_SmsFailCntNext));
      if (mbr_LastSmsSendDateBegin > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_LastSmsSendDateBegin));
      if (mbr_LastSmsSendDateEnd > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_LastSmsSendDateEnd));
      if (!string.IsNullOrEmpty(mbr_ZipCode))
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbr_ZipCode));
      if (mbr_Gender > 0)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbr_Gender));
      if (!string.IsNullOrEmpty(mbr_TaxBillYn))
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbr_TaxBillYn));
      if (mbr_IsCreditLimitAmt.HasValue)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, bool?>((Expression<Func<bool?>>) (() => mbr_IsCreditLimitAmt));
      if (mbr_IsCreditAmt.HasValue)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, bool?>((Expression<Func<bool?>>) (() => mbr_IsCreditAmt));
      if (mbr_InDateBegin > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_InDateBegin));
      if (mbr_InDateEnd > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_InDateEnd));
      if (mbr_ModDateBegin > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_ModDateBegin));
      if (mbr_ModDateEnd > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => mbr_ModDateEnd));
      if (MemberTypeHistoryDate > 0L)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, long>((Expression<Func<long>>) (() => MemberTypeHistoryDate));
      if (IsMemberCardInclude)
      {
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, bool>((Expression<Func<bool>>) (() => IsMemberCardInclude));
        if (IsMemberCardIMainnclude)
          memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, bool>((Expression<Func<bool>>) (() => IsMemberCardIMainnclude));
        if (!string.IsNullOrEmpty(mbrc_MemberCardNo))
          memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbrc_MemberCardNo));
        if (mbrc_CardType > 0)
          memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, int>((Expression<Func<int>>) (() => mbrc_CardType));
        if (!string.IsNullOrEmpty(mbrc_UseYn))
          memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => mbrc_UseYn));
      }
      if (!string.IsNullOrEmpty(KeyWord))
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      if (isLtMemberCard)
        memberList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberView>>>, bool>((Expression<Func<bool>>) (() => isLtMemberCard));
      memberList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberView>>>>(MethodBase.GetCurrentMethod());
      return memberList;
    }

    public static UniBizHttpRequest<UbRes<MemberCardView>> GetMemberCard(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbrc_SiteID")] long mbrc_SiteID,
      [NameConvert("p_mbrc_MemberNo")] long mbrc_MemberNo,
      [NameConvert("p_mbrc_MemberCardNo")] string mbrc_MemberCardNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      string.IsNullOrEmpty(mbrc_MemberCardNo);
      UniBizHttpRequest<UbRes<MemberCardView>> memberCard = new UniBizHttpRequest<UbRes<MemberCardView>>(HttpMethod.Get);
      memberCard.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbrc_SiteID}/{mbrc_MemberNo}/Card/{mbrc_MemberCardNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCard.Headers.Add("Send-Type", SendType);
      memberCard.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, long>((Expression<Func<long>>) (() => mbrc_SiteID));
      memberCard.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, long>((Expression<Func<long>>) (() => mbrc_MemberNo));
      memberCard.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, string>((Expression<Func<string>>) (() => mbrc_MemberCardNo));
      memberCard.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCard.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberCard.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCardView>>>(MethodBase.GetCurrentMethod());
      return memberCard;
    }

    public static UniBizHttpRequest<UbRes<MemberCardView>> PostMemberCard(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbrc_SiteID")] long mbrc_SiteID,
      [NameConvert("p_mbrc_MemberNo")] long mbrc_MemberNo,
      [NameConvert("p_mbrc_MemberCardNo")] string mbrc_MemberCardNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberCardView pData)
    {
      UniBizHttpRequest<UbRes<MemberCardView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberCardView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbrc_SiteID}/{mbrc_MemberNo}/Card/{mbrc_MemberCardNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, long>((Expression<Func<long>>) (() => mbrc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, long>((Expression<Func<long>>) (() => mbrc_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, string>((Expression<Func<string>>) (() => mbrc_MemberCardNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCardView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberCardView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCardView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberCardView>>> GetMemberCardList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mbrc_SiteID")] long mbrc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mbrc_MemberNo")] long mbrc_MemberNo = 0,
      [NameConvert("p_mbrc_MemberCardNo")] string mbrc_MemberCardNo = null,
      [NameConvert("p_mbrc_CardType")] int mbrc_CardType = 0,
      [NameConvert("p_mbrc_UseYn")] string mbrc_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MemberCardView>>> memberCardList = new UniBizHttpRequest<UbRes<IList<MemberCardView>>>(HttpMethod.Get);
      memberCardList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mbrc_SiteID}/Card/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCardList.Headers.Add("Send-Type", SendType);
      memberCardList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, long>((Expression<Func<long>>) (() => mbrc_SiteID));
      memberCardList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCardList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mbrc_MemberNo > 0L)
        memberCardList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, long>((Expression<Func<long>>) (() => mbrc_MemberNo));
      if (!string.IsNullOrEmpty(mbrc_MemberCardNo))
        memberCardList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, string>((Expression<Func<string>>) (() => mbrc_MemberCardNo));
      if (mbrc_CardType > 0)
        memberCardList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, int>((Expression<Func<int>>) (() => mbrc_CardType));
      if (!string.IsNullOrEmpty(mbrc_UseYn))
        memberCardList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, string>((Expression<Func<string>>) (() => mbrc_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        memberCardList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCardView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      memberCardList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberCardView>>>>(MethodBase.GetCurrentMethod());
      return memberCardList;
    }

    public static UniBizHttpRequest<UbRes<MemberGradeView>> GetMemberGrade(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgd_SiteID")] long mgd_SiteID,
      [NameConvert("p_mgd_MemberGrade")] int mgd_MemberGrade,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberGradeView>> memberGrade = new UniBizHttpRequest<UbRes<MemberGradeView>>(HttpMethod.Get);
      memberGrade.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mgd_SiteID}/Grade/{mgd_MemberGrade}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGrade.Headers.Add("Send-Type", SendType);
      memberGrade.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, long>((Expression<Func<long>>) (() => mgd_SiteID));
      memberGrade.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => mgd_MemberGrade));
      memberGrade.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGrade.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberGrade.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGradeView>>>(MethodBase.GetCurrentMethod());
      return memberGrade;
    }

    public static UniBizHttpRequest<UbRes<MemberGradeView>> PostMemberGrade(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgd_SiteID")] long mgd_SiteID,
      [NameConvert("p_mgd_MemberGrade")] int mgd_MemberGrade,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberGradeView pData)
    {
      UniBizHttpRequest<UbRes<MemberGradeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberGradeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mgd_SiteID}/Grade/{mgd_MemberGrade}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, long>((Expression<Func<long>>) (() => mgd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => mgd_MemberGrade));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberGradeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGradeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberGradeView>>> GetMemberGradeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgd_SiteID")] long mgd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mgd_MemberGrade")] int mgd_MemberGrade = 0,
      [NameConvert("p_mgd_MemberGradeName")] string mgd_MemberGradeName = null,
      [NameConvert("p_mgd_UseYn")] string mgd_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MemberGradeView>>> memberGradeList = new UniBizHttpRequest<UbRes<IList<MemberGradeView>>>(HttpMethod.Get);
      memberGradeList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mgd_SiteID}/Grade/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGradeList.Headers.Add("Send-Type", SendType);
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, long>((Expression<Func<long>>) (() => mgd_SiteID));
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mgd_MemberGrade > 0)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, int>((Expression<Func<int>>) (() => mgd_MemberGrade));
      if (!string.IsNullOrEmpty(mgd_MemberGradeName))
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, string>((Expression<Func<string>>) (() => mgd_MemberGradeName));
      if (!string.IsNullOrEmpty(mgd_UseYn))
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, string>((Expression<Func<string>>) (() => mgd_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      memberGradeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberGradeView>>>>(MethodBase.GetCurrentMethod());
      return memberGradeList;
    }

    public static UniBizHttpRequest<UbRes<MemberGroupView>> GetMemberGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mg_SiteID")] long mg_SiteID,
      [NameConvert("p_mg_GroupCode")] string mg_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtDetail")] bool isLtDetail = false)
    {
      string.IsNullOrEmpty(mg_GroupCode);
      UniBizHttpRequest<UbRes<MemberGroupView>> memberGroup = new UniBizHttpRequest<UbRes<MemberGroupView>>(HttpMethod.Get);
      memberGroup.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mg_SiteID}/Group/{mg_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGroup.Headers.Add("Send-Type", SendType);
      memberGroup.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, long>((Expression<Func<long>>) (() => mg_SiteID));
      memberGroup.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, string>((Expression<Func<string>>) (() => mg_GroupCode));
      memberGroup.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGroup.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isLtDetail)
        memberGroup.SetQuery<UniBizHttpRequest<UbRes<MemberGroupView>>, bool>((Expression<Func<bool>>) (() => isLtDetail));
      memberGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGroupView>>>(MethodBase.GetCurrentMethod());
      return memberGroup;
    }

    public static UniBizHttpRequest<UbRes<MemberGroupView>> PostMemberGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mg_SiteID")] long mg_SiteID,
      [NameConvert("p_mg_GroupCode")] string mg_GroupCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberGroupView pData)
    {
      UniBizHttpRequest<UbRes<MemberGroupView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberGroupView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mg_SiteID}/Group/{mg_GroupCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, long>((Expression<Func<long>>) (() => mg_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, string>((Expression<Func<string>>) (() => mg_GroupCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGroupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberGroupView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGroupView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberGroupView>>> GetMemberGroupList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mg_SiteID")] long mg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mg_GroupCode")] string mg_GroupCode = null,
      [NameConvert("p_mg_GroupDepth")] int mg_GroupDepth = 0,
      [NameConvert("p_mg_UseYn")] string mg_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null,
      [NameConvert("p_isLtDetail")] bool isLtDetail = false)
    {
      UniBizHttpRequest<UbRes<IList<MemberGroupView>>> memberGroupList = new UniBizHttpRequest<UbRes<IList<MemberGroupView>>>(HttpMethod.Get);
      memberGroupList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mg_SiteID}/Group/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGroupList.Headers.Add("Send-Type", SendType);
      memberGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, long>((Expression<Func<long>>) (() => mg_SiteID));
      memberGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGroupList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(mg_GroupCode))
        memberGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, string>((Expression<Func<string>>) (() => mg_GroupCode));
      if (mg_GroupDepth > 0)
        memberGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, int>((Expression<Func<int>>) (() => mg_GroupDepth));
      if (!string.IsNullOrEmpty(mg_UseYn))
        memberGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, string>((Expression<Func<string>>) (() => mg_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        memberGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      if (isLtDetail)
        memberGroupList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>, bool>((Expression<Func<bool>>) (() => isLtDetail));
      memberGroupList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberGroupView>>>>(MethodBase.GetCurrentMethod());
      return memberGroupList;
    }

    public static UniBizHttpRequest<UbRes<MemberGroupLevel>> GetMemberGroupDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mg_SiteID")] long mg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mg_UseYn")] string mg_UseYn = null)
    {
      UniBizHttpRequest<UbRes<MemberGroupLevel>> memberGroupDepth = new UniBizHttpRequest<UbRes<MemberGroupLevel>>(HttpMethod.Get);
      memberGroupDepth.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mg_SiteID}/Group/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGroupDepth.Headers.Add("Send-Type", SendType);
      memberGroupDepth.SetSegment<UniBizHttpRequest<UbRes<MemberGroupLevel>>, long>((Expression<Func<long>>) (() => mg_SiteID));
      memberGroupDepth.SetSegment<UniBizHttpRequest<UbRes<MemberGroupLevel>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGroupDepth.SetSegment<UniBizHttpRequest<UbRes<MemberGroupLevel>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(mg_UseYn))
        memberGroupDepth.SetQuery<UniBizHttpRequest<UbRes<MemberGroupLevel>>, string>((Expression<Func<string>>) (() => mg_UseYn));
      memberGroupDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGroupLevel>>>(MethodBase.GetCurrentMethod());
      return memberGroupDepth;
    }

    public static UniBizHttpRequest<UbRes<MemberTypeView>> GetMemberType(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mt_SiteID")] long mt_SiteID,
      [NameConvert("p_mt_TypeCode")] int mt_TypeCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false)
    {
      UniBizHttpRequest<UbRes<MemberTypeView>> memberType = new UniBizHttpRequest<UbRes<MemberTypeView>>(HttpMethod.Get);
      memberType.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mt_SiteID}/Type/{mt_TypeCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberType.Headers.Add("Send-Type", SendType);
      memberType.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, long>((Expression<Func<long>>) (() => mt_SiteID));
      memberType.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => mt_TypeCode));
      memberType.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberType.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (isLtHistory)
        memberType.SetQuery<UniBizHttpRequest<UbRes<MemberTypeView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      memberType.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberTypeView>>>(MethodBase.GetCurrentMethod());
      return memberType;
    }

    public static UniBizHttpRequest<UbRes<MemberTypeView>> PostMemberType(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mt_SiteID")] long mt_SiteID,
      [NameConvert("p_mt_TypeCode")] int mt_TypeCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberTypeView pData)
    {
      UniBizHttpRequest<UbRes<MemberTypeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberTypeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mt_SiteID}/Type/{mt_TypeCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, long>((Expression<Func<long>>) (() => mt_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => mt_TypeCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberTypeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberTypeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberTypeView>>> GetMemberTypeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mt_SiteID")] long mt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mt_TypeCode")] int mt_TypeCode = 0,
      [NameConvert("p_mt_TypeName")] string mt_TypeName = null,
      [NameConvert("p_mt_UseYn")] string mt_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false)
    {
      UniBizHttpRequest<UbRes<IList<MemberTypeView>>> memberTypeList = new UniBizHttpRequest<UbRes<IList<MemberTypeView>>>(HttpMethod.Get);
      memberTypeList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mt_SiteID}/Type/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberTypeList.Headers.Add("Send-Type", SendType);
      memberTypeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, long>((Expression<Func<long>>) (() => mt_SiteID));
      memberTypeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberTypeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mt_TypeCode > 0)
        memberTypeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, int>((Expression<Func<int>>) (() => mt_TypeCode));
      if (!string.IsNullOrEmpty(mt_TypeName))
        memberTypeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, string>((Expression<Func<string>>) (() => mt_TypeName));
      if (!string.IsNullOrEmpty(mt_UseYn))
        memberTypeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, string>((Expression<Func<string>>) (() => mt_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        memberTypeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      if (isLtHistory)
        memberTypeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      memberTypeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberTypeView>>>>(MethodBase.GetCurrentMethod());
      return memberTypeList;
    }

    public static UniBizHttpRequest<UbRes<MemberTypeHistoryView>> GetMemberTypeHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mth_SiteID")] long mth_SiteID,
      [NameConvert("p_mth_StoreCode")] int mth_StoreCode,
      [NameConvert("p_mth_TypeCode")] int mth_TypeCode,
      [NameConvert("p_mth_StartDate")] long mth_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberTypeHistoryView>> memberTypeHistory = new UniBizHttpRequest<UbRes<MemberTypeHistoryView>>(HttpMethod.Get);
      memberTypeHistory.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mth_SiteID}/Type/{mth_TypeCode}/History/{mth_StoreCode}/{mth_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberTypeHistory.Headers.Add("Send-Type", SendType);
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, long>((Expression<Func<long>>) (() => mth_SiteID));
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => mth_TypeCode));
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => mth_StoreCode));
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, long>((Expression<Func<long>>) (() => mth_StartDate));
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberTypeHistory.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberTypeHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>>(MethodBase.GetCurrentMethod());
      return memberTypeHistory;
    }

    public static UniBizHttpRequest<UbRes<MemberTypeHistoryView>> PostMemberTypeHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mth_SiteID")] long mth_SiteID,
      [NameConvert("p_mth_StoreCode")] int mth_StoreCode,
      [NameConvert("p_mth_TypeCode")] int mth_TypeCode,
      [NameConvert("p_mth_StartDate")] long mth_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberTypeHistoryView pData)
    {
      UniBizHttpRequest<UbRes<MemberTypeHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberTypeHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mth_SiteID}/Type/{mth_TypeCode}/History/{mth_StoreCode}/{mth_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, long>((Expression<Func<long>>) (() => mth_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => mth_TypeCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => mth_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, long>((Expression<Func<long>>) (() => mth_StartDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberTypeHistoryView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberTypeHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>> GetMemberTypeHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mth_SiteID")] long mth_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mth_TypeCode")] int mth_TypeCode = 0,
      [NameConvert("p_mth_StoreCode")] int mth_StoreCode = 0,
      [NameConvert("p_mth_StoreCodeIn")] string mth_StoreCodeIn = null,
      [NameConvert("p_mth_StartDate")] long mth_StartDate = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_mt_UseYn")] string mt_UseYn = null,
      [NameConvert("p_OrderByType")] int OrderByType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>> memberTypeHistoryList = new UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>(HttpMethod.Get);
      memberTypeHistoryList.Resource = UbRestModelAttribute.GetBasePath<MemberInfoRestServer>() + "/{mth_SiteID}/Type/History/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberTypeHistoryList.Headers.Add("Send-Type", SendType);
      memberTypeHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, long>((Expression<Func<long>>) (() => mth_SiteID));
      memberTypeHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberTypeHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mth_TypeCode > 0)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, int>((Expression<Func<int>>) (() => mth_TypeCode));
      if (mth_StoreCode > 0)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, int>((Expression<Func<int>>) (() => mth_StoreCode));
      if (!string.IsNullOrEmpty(mth_StoreCodeIn))
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, string>((Expression<Func<string>>) (() => mth_StoreCodeIn));
      if (mth_StartDate > 0L)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, long>((Expression<Func<long>>) (() => mth_StartDate));
      if (dt_date > 0L)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (!string.IsNullOrEmpty(mt_UseYn))
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, string>((Expression<Func<string>>) (() => mt_UseYn));
      if (OrderByType > 0)
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      if (!string.IsNullOrEmpty(KeyWord))
        memberTypeHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      memberTypeHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberTypeHistoryView>>>>(MethodBase.GetCurrentMethod());
      return memberTypeHistoryList;
    }
  }
}
