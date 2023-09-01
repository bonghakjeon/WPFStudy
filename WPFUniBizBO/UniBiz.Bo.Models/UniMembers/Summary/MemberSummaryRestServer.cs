// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberSummaryRestServer
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
using UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum;
using UniBiz.Bo.Models.UniMembers.Summary.MemberGoodsSum;
using UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniMembers.Summary
{
  [UbRestModel("/Member/Summary", TableCodeType.Member, HeaderPath = "")]
  public class MemberSummaryRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<MemberPointExtinctionView>> GetMemberPointExtinction(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mpe_SiteID")] long mpe_SiteID,
      [NameConvert("p_mpe_Date")] long mpe_Date,
      [NameConvert("p_mpe_MemberNo")] long mpe_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberPointExtinctionView>> memberPointExtinction = new UniBizHttpRequest<UbRes<MemberPointExtinctionView>>(HttpMethod.Get);
      memberPointExtinction.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mpe_SiteID}/PointExtinction/{mpe_Date}/{mpe_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberPointExtinction.Headers.Add("Send-Type", SendType);
      memberPointExtinction.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_SiteID));
      memberPointExtinction.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_Date));
      memberPointExtinction.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_MemberNo));
      memberPointExtinction.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberPointExtinction.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberPointExtinction.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>>(MethodBase.GetCurrentMethod());
      return memberPointExtinction;
    }

    public static UniBizHttpRequest<UbRes<MemberPointExtinctionView>> PostMemberPointExtinction(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mpe_SiteID")] long mpe_SiteID,
      [NameConvert("p_mpe_Date")] long mpe_Date,
      [NameConvert("p_mpe_MemberNo")] long mpe_MemberNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberPointExtinctionView pData)
    {
      UniBizHttpRequest<UbRes<MemberPointExtinctionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberPointExtinctionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mpe_SiteID}/PointExtinction/{mpe_Date}/{mpe_MemberNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_Date));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, long>((Expression<Func<long>>) (() => mpe_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberPointExtinctionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberPointExtinctionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>> GetMemberGradeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mpe_SiteID")] long mpe_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mpe_Date")] long mpe_Date = 0,
      [NameConvert("p_mpe_MemberNo")] long mpe_MemberNo = 0,
      [NameConvert("p_mpe_DateBegin")] long mpe_DateBegin = 0,
      [NameConvert("p_mpe_DateEnd")] long mpe_DateEnd = 0,
      [NameConvert("p_mpe_ExtinctionPointIsZero")] bool? mpe_ExtinctionPointIsZero = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>> memberGradeList = new UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>(HttpMethod.Get);
      memberGradeList.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mpe_SiteID}/PointExtinction/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGradeList.Headers.Add("Send-Type", SendType);
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, long>((Expression<Func<long>>) (() => mpe_SiteID));
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGradeList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mpe_Date > 0L)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, long>((Expression<Func<long>>) (() => mpe_Date));
      if (mpe_MemberNo > 0L)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, long>((Expression<Func<long>>) (() => mpe_MemberNo));
      if (mpe_DateBegin > 0L)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, long>((Expression<Func<long>>) (() => mpe_DateBegin));
      if (mpe_DateEnd > 0L)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, long>((Expression<Func<long>>) (() => mpe_DateEnd));
      if (mpe_ExtinctionPointIsZero.HasValue)
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, bool?>((Expression<Func<bool?>>) (() => mpe_ExtinctionPointIsZero));
      if (!string.IsNullOrEmpty(KeyWord))
        memberGradeList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      memberGradeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberPointExtinctionView>>>>(MethodBase.GetCurrentMethod());
      return memberGradeList;
    }

    public static UniBizHttpRequest<UbRes<MemberDaySumView>> GetMemberDaySum(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mds_SiteID")] long mds_SiteID,
      [NameConvert("p_mds_SysDate")] long mds_SysDate,
      [NameConvert("p_mds_MemberNo")] long mds_MemberNo,
      [NameConvert("p_mds_StoreCode")] int mds_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberDaySumView>> memberDaySum = new UniBizHttpRequest<UbRes<MemberDaySumView>>(HttpMethod.Get);
      memberDaySum.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mds_SiteID}/DaySum/{mds_SysDate}/{mds_MemberNo}/{mds_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberDaySum.Headers.Add("Send-Type", SendType);
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_SiteID));
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_SysDate));
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_MemberNo));
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => mds_StoreCode));
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberDaySum.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberDaySum.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberDaySumView>>>(MethodBase.GetCurrentMethod());
      return memberDaySum;
    }

    public static UniBizHttpRequest<UbRes<MemberDaySumView>> PostMemberDaySum(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mds_SiteID")] long mds_SiteID,
      [NameConvert("p_mds_SysDate")] long mds_SysDate,
      [NameConvert("p_mds_MemberNo")] long mds_MemberNo,
      [NameConvert("p_mds_StoreCode")] int mds_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberDaySumView pData)
    {
      UniBizHttpRequest<UbRes<MemberDaySumView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberDaySumView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mds_SiteID}/DaySum/{mds_SysDate}/{mds_MemberNo}/{mds_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_SysDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, long>((Expression<Func<long>>) (() => mds_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => mds_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberDaySumView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberDaySumView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberDaySumView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberDaySumView>>> GetMemberDaySumList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mds_SiteID")] long mds_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mds_SysDate")] long mds_SysDate = 0,
      [NameConvert("p_mds_MemberNo")] long mds_MemberNo = 0,
      [NameConvert("p_mds_StoreCode")] int mds_StoreCode = 0,
      [NameConvert("p_mds_SysDateBegin")] long mds_SysDateBegin = 0,
      [NameConvert("p_mds_SysDateEnd")] long mds_SysDateEnd = 0)
    {
      UniBizHttpRequest<UbRes<IList<MemberDaySumView>>> memberDaySumList = new UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>(HttpMethod.Get);
      memberDaySumList.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mds_SiteID}/DaySum/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberDaySumList.Headers.Add("Send-Type", SendType);
      memberDaySumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, long>((Expression<Func<long>>) (() => mds_SiteID));
      memberDaySumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberDaySumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mds_SysDate > 0L)
        memberDaySumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, long>((Expression<Func<long>>) (() => mds_SysDate));
      if (mds_MemberNo > 0L)
        memberDaySumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, long>((Expression<Func<long>>) (() => mds_MemberNo));
      if (mds_StoreCode > 0)
        memberDaySumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, int>((Expression<Func<int>>) (() => mds_StoreCode));
      if (mds_SysDateBegin > 0L)
        memberDaySumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, long>((Expression<Func<long>>) (() => mds_SysDateBegin));
      if (mds_SysDateEnd > 0L)
        memberDaySumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>, long>((Expression<Func<long>>) (() => mds_SysDateEnd));
      memberDaySumList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberDaySumView>>>>(MethodBase.GetCurrentMethod());
      return memberDaySumList;
    }

    public static UniBizHttpRequest<UbRes<MemberGoodsSumView>> GetMemberGoodsSum(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgs_SiteID")] long mgs_SiteID,
      [NameConvert("p_mgs_SysDate")] long mgs_SysDate,
      [NameConvert("p_mgs_MemberNo")] long mgs_MemberNo,
      [NameConvert("p_mgs_StoreCode")] int mgs_StoreCode,
      [NameConvert("p_mgs_GoodsCode")] long mgs_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberGoodsSumView>> memberGoodsSum = new UniBizHttpRequest<UbRes<MemberGoodsSumView>>(HttpMethod.Get);
      memberGoodsSum.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mgs_SiteID}/GoodsSum/{mgs_SysDate}/{mgs_MemberNo}/{mgs_StoreCode}/{mgs_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGoodsSum.Headers.Add("Send-Type", SendType);
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_SiteID));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_SysDate));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_MemberNo));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => mgs_StoreCode));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_GoodsCode));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGoodsSum.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberGoodsSum.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGoodsSumView>>>(MethodBase.GetCurrentMethod());
      return memberGoodsSum;
    }

    public static UniBizHttpRequest<UbRes<MemberGoodsSumView>> PostMemberGoodsSum(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgs_SiteID")] long mgs_SiteID,
      [NameConvert("p_mgs_SysDate")] long mgs_SysDate,
      [NameConvert("p_mgs_MemberNo")] long mgs_MemberNo,
      [NameConvert("p_mgs_StoreCode")] int mgs_StoreCode,
      [NameConvert("p_mgs_GoodsCode")] long mgs_GoodsCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberGoodsSumView pData)
    {
      UniBizHttpRequest<UbRes<MemberGoodsSumView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberGoodsSumView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mgs_SiteID}/GoodsSum/{mgs_SysDate}/{mgs_MemberNo}/{mgs_StoreCode}/{mgs_GoodsCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_SysDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_MemberNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => mgs_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, long>((Expression<Func<long>>) (() => mgs_GoodsCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGoodsSumView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberGoodsSumView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGoodsSumView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>> GetMemberGoodsSumList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgs_SiteID")] long mgs_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mgs_SysDate")] long mgs_SysDate = 0,
      [NameConvert("p_mgs_MemberNo")] long mgs_MemberNo = 0,
      [NameConvert("p_mgs_StoreCode")] int mgs_StoreCode = 0,
      [NameConvert("p_mgs_GoodsCode")] long mgs_GoodsCode = 0,
      [NameConvert("p_mgs_SysDateBegin")] long mgs_SysDateBegin = 0,
      [NameConvert("p_mgs_SysDateEnd")] long mgs_SysDateEnd = 0)
    {
      UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>> memberGoodsSumList = new UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>(HttpMethod.Get);
      memberGoodsSumList.Resource = UbRestModelAttribute.GetBasePath<MemberSummaryRestServer>() + "/{mgs_SiteID}/GoodsSum/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGoodsSumList.Headers.Add("Send-Type", SendType);
      memberGoodsSumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_SiteID));
      memberGoodsSumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGoodsSumList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mgs_SysDate > 0L)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_SysDate));
      if (mgs_MemberNo > 0L)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_MemberNo));
      if (mgs_StoreCode > 0)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, int>((Expression<Func<int>>) (() => mgs_StoreCode));
      if (mgs_GoodsCode > 0L)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_GoodsCode));
      if (mgs_SysDateBegin > 0L)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_SysDateBegin));
      if (mgs_SysDateEnd > 0L)
        memberGoodsSumList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>, long>((Expression<Func<long>>) (() => mgs_SysDateEnd));
      memberGoodsSumList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberGoodsSumView>>>>(MethodBase.GetCurrentMethod());
      return memberGoodsSumList;
    }
  }
}
