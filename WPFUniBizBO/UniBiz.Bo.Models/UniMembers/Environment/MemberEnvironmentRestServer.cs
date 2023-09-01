// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberEnvironmentRestServer
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
using UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle;
using UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd;
using UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniMembers.Environment
{
  [UbRestModel("/Member/Envi", TableCodeType.Member, HeaderPath = "")]
  public class MemberEnvironmentRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<MemberCalcCycleView>> GetMemberCalcCycle(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcc_SiteID")] long mcc_SiteID,
      [NameConvert("p_mcc_CalcCycleDiv")] int mcc_CalcCycleDiv,
      [NameConvert("p_mcc_StartDate")] long mcc_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberCalcCycleView>> memberCalcCycle = new UniBizHttpRequest<UbRes<MemberCalcCycleView>>(HttpMethod.Get);
      memberCalcCycle.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcc_SiteID}/CalcCycle/{mcc_CalcCycleDiv}/{mcc_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCalcCycle.Headers.Add("Send-Type", SendType);
      memberCalcCycle.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, long>((Expression<Func<long>>) (() => mcc_SiteID));
      memberCalcCycle.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => mcc_CalcCycleDiv));
      memberCalcCycle.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, long>((Expression<Func<long>>) (() => mcc_StartDate));
      memberCalcCycle.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCalcCycle.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberCalcCycle.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCalcCycleView>>>(MethodBase.GetCurrentMethod());
      return memberCalcCycle;
    }

    public static UniBizHttpRequest<UbRes<MemberCalcCycleView>> PostMemberCalcCycle(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcc_SiteID")] long mcc_SiteID,
      [NameConvert("p_mcc_CalcCycleDiv")] int mcc_CalcCycleDiv,
      [NameConvert("p_mcc_StartDate")] long mcc_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberCalcCycleView pData)
    {
      UniBizHttpRequest<UbRes<MemberCalcCycleView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberCalcCycleView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcc_SiteID}/CalcCycle/{mcc_CalcCycleDiv}/{mcc_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, long>((Expression<Func<long>>) (() => mcc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => mcc_CalcCycleDiv));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, long>((Expression<Func<long>>) (() => mcc_StartDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCalcCycleView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberCalcCycleView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCalcCycleView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>> GetMemberCalcCycleList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcc_SiteID")] long mcc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mcc_CalcCycleDiv")] int mcc_CalcCycleDiv = 0,
      [NameConvert("p_mcc_StartDate")] long mcc_StartDate = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_mcc_CalcCycle")] int mcc_CalcCycle = 0,
      [NameConvert("p_mcc_CalcPeriod")] int mcc_CalcPeriod = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0)
    {
      UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>> memberCalcCycleList = new UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>(HttpMethod.Get);
      memberCalcCycleList.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcc_SiteID}/CalcCycle/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCalcCycleList.Headers.Add("Send-Type", SendType);
      memberCalcCycleList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, long>((Expression<Func<long>>) (() => mcc_SiteID));
      memberCalcCycleList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCalcCycleList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mcc_CalcCycleDiv > 0)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => mcc_CalcCycleDiv));
      if (mcc_StartDate > 0L)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, long>((Expression<Func<long>>) (() => mcc_StartDate));
      if (dt_date > 0L)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (mcc_CalcCycle > 0)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => mcc_CalcCycle));
      if (mcc_CalcPeriod > 0)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => mcc_CalcPeriod));
      if (OrderByType > 0)
        memberCalcCycleList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      memberCalcCycleList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberCalcCycleView>>>>(MethodBase.GetCurrentMethod());
      return memberCalcCycleList;
    }

    public static UniBizHttpRequest<UbRes<MemberCycleStdView>> GetMemberCycleStd(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcs_SiteID")] long mcs_SiteID,
      [NameConvert("p_mcs_StoreCode")] int mcs_StoreCode,
      [NameConvert("p_mcs_StartDate")] long mcs_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberCycleStdView>> memberCycleStd = new UniBizHttpRequest<UbRes<MemberCycleStdView>>(HttpMethod.Get);
      memberCycleStd.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcs_SiteID}/CycleStd/{mcs_StoreCode}/{mcs_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCycleStd.Headers.Add("Send-Type", SendType);
      memberCycleStd.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, long>((Expression<Func<long>>) (() => mcs_SiteID));
      memberCycleStd.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => mcs_StoreCode));
      memberCycleStd.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, long>((Expression<Func<long>>) (() => mcs_StartDate));
      memberCycleStd.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCycleStd.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberCycleStd.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCycleStdView>>>(MethodBase.GetCurrentMethod());
      return memberCycleStd;
    }

    public static UniBizHttpRequest<UbRes<MemberCycleStdView>> PostMemberCycleStd(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcs_SiteID")] long mcs_SiteID,
      [NameConvert("p_mcs_StoreCode")] int mcs_StoreCode,
      [NameConvert("p_mcs_StartDate")] long mcs_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberCycleStdView pData)
    {
      UniBizHttpRequest<UbRes<MemberCycleStdView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberCycleStdView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcs_SiteID}/CycleStd/{mcs_StoreCode}/{mcs_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, long>((Expression<Func<long>>) (() => mcs_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => mcs_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, long>((Expression<Func<long>>) (() => mcs_StartDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberCycleStdView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberCycleStdView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberCycleStdView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>> GetMemberCycleStdList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mcs_SiteID")] long mcs_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mcs_StoreCode")] int mcs_StoreCode = 0,
      [NameConvert("p_mcs_StartDate")] long mcs_StartDate = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0)
    {
      UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>> memberCycleStdList = new UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>(HttpMethod.Get);
      memberCycleStdList.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mcs_SiteID}/CycleStd/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberCycleStdList.Headers.Add("Send-Type", SendType);
      memberCycleStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, long>((Expression<Func<long>>) (() => mcs_SiteID));
      memberCycleStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberCycleStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mcs_StoreCode > 0)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, int>((Expression<Func<int>>) (() => mcs_StoreCode));
      if (mcs_StartDate > 0L)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, long>((Expression<Func<long>>) (() => mcs_StartDate));
      if (dt_date > 0L)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (OrderByType > 0)
        memberCycleStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      memberCycleStdList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberCycleStdView>>>>(MethodBase.GetCurrentMethod());
      return memberCycleStdList;
    }

    public static UniBizHttpRequest<UbRes<MemberGradeCalcStdView>> GetMemberGradeCalcStd(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgcs_SiteID")] long mgcs_SiteID,
      [NameConvert("p_mgcs_StoreCode")] int mgcs_StoreCode,
      [NameConvert("p_mgcs_MemberGrade")] int mgcs_MemberGrade,
      [NameConvert("p_mgcs_StartDate")] long mgcs_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<MemberGradeCalcStdView>> memberGradeCalcStd = new UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>(HttpMethod.Get);
      memberGradeCalcStd.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mgcs_SiteID}/GradeCalcStd/{mgcs_StoreCode}/{mgcs_MemberGrade}/{mgcs_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      memberGradeCalcStd.Headers.Add("Send-Type", SendType);
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, long>((Expression<Func<long>>) (() => mgcs_SiteID));
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => mgcs_StoreCode));
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => mgcs_MemberGrade));
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, long>((Expression<Func<long>>) (() => mgcs_StartDate));
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      memberGradeCalcStd.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      memberGradeCalcStd.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>>(MethodBase.GetCurrentMethod());
      return memberGradeCalcStd;
    }

    public static UniBizHttpRequest<UbRes<MemberGradeCalcStdView>> PostMemberGradeCalcStd(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgcs_SiteID")] long mgcs_SiteID,
      [NameConvert("p_mgcs_StoreCode")] int mgcs_StoreCode,
      [NameConvert("p_mgcs_MemberGrade")] int mgcs_MemberGrade,
      [NameConvert("p_mgcs_StartDate")] long mgcs_StartDate,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      MemberGradeCalcStdView pData)
    {
      UniBizHttpRequest<UbRes<MemberGradeCalcStdView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mgcs_SiteID}/GradeCalcStd/{mgcs_StoreCode}/{mgcs_MemberGrade}/{mgcs_StartDate}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, long>((Expression<Func<long>>) (() => mgcs_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => mgcs_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => mgcs_MemberGrade));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, long>((Expression<Func<long>>) (() => mgcs_StartDate));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<MemberGradeCalcStdView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<MemberGradeCalcStdView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>> GetMemberGradeCalcStdList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_mgcs_SiteID")] long mgcs_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_mgcs_StoreCode")] int mgcs_StoreCode = 0,
      [NameConvert("p_mgcs_MemberGrade")] int mgcs_MemberGrade = 0,
      [NameConvert("p_mgcs_StartDate")] long mgcs_StartDate = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_start")] long dt_start = 0,
      [NameConvert("p_dt_end")] long dt_end = 0,
      [NameConvert("p_mgd_UseYn")] string mgd_UseYn = null,
      [NameConvert("p_OrderByType")] int OrderByType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>> gradeCalcStdList = new UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>(HttpMethod.Get);
      gradeCalcStdList.Resource = UbRestModelAttribute.GetBasePath<MemberEnvironmentRestServer>() + "/{mgcs_SiteID}/GradeCalcStd/{work_pm_MenuCode}/{work_pmp_PropCode}";
      gradeCalcStdList.Headers.Add("Send-Type", SendType);
      gradeCalcStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, long>((Expression<Func<long>>) (() => mgcs_SiteID));
      gradeCalcStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      gradeCalcStdList.SetSegment<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (mgcs_StoreCode > 0)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, int>((Expression<Func<int>>) (() => mgcs_StoreCode));
      if (mgcs_MemberGrade > 0)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, int>((Expression<Func<int>>) (() => mgcs_MemberGrade));
      if (mgcs_StartDate > 0L)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, long>((Expression<Func<long>>) (() => mgcs_StartDate));
      if (dt_date > 0L)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_start > 0L)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, long>((Expression<Func<long>>) (() => dt_start));
      if (dt_end > 0L)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, long>((Expression<Func<long>>) (() => dt_end));
      if (!string.IsNullOrEmpty(mgd_UseYn))
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, string>((Expression<Func<string>>) (() => mgd_UseYn));
      if (OrderByType > 0)
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      if (!string.IsNullOrEmpty(KeyWord))
        gradeCalcStdList.SetQuery<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      gradeCalcStdList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<MemberGradeCalcStdView>>>>(MethodBase.GetCurrentMethod());
      return gradeCalcStdList;
    }
  }
}
