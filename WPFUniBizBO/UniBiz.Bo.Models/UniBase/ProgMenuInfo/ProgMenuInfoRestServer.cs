// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuInfoRestServer
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
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class ProgMenuInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<ProgMenuView>> GetProgMenu(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pm_SiteID")] long pm_SiteID,
      [NameConvert("p_pm_MenuCode")] int pm_MenuCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ProgMenuView>> progMenu = new UniBizHttpRequest<UbRes<ProgMenuView>>(HttpMethod.Get);
      progMenu.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pm_SiteID}/{pm_MenuCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenu.Headers.Add("Send-Type", SendType);
      progMenu.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, long>((Expression<Func<long>>) (() => pm_SiteID));
      progMenu.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => pm_MenuCode));
      progMenu.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenu.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      progMenu.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuView>>>(MethodBase.GetCurrentMethod());
      return progMenu;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuView>> PostProgMenu(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pm_SiteID")] long pm_SiteID,
      [NameConvert("p_pm_MenuCode")] int pm_MenuCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ProgMenuView pData)
    {
      UniBizHttpRequest<UbRes<ProgMenuView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ProgMenuView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pm_SiteID}/{pm_MenuCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, long>((Expression<Func<long>>) (() => pm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ProgMenuView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuView>>> GetProgMenuList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pm_SiteID")] long pm_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_pm_ProgKind")] int pm_ProgKind = 0,
      [NameConvert("p_pmA_MenuGroupID")] int pmA_MenuGroupID = 0,
      [NameConvert("p_pm_UseYn")] string pm_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuView>>> progMenuList = new UniBizHttpRequest<UbRes<IList<ProgMenuView>>>(HttpMethod.Get);
      progMenuList.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pm_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuList.Headers.Add("Send-Type", SendType);
      progMenuList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, long>((Expression<Func<long>>) (() => pm_SiteID));
      progMenuList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (pm_ProgKind > 0)
        progMenuList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, int>((Expression<Func<int>>) (() => pm_ProgKind));
      if (pmA_MenuGroupID > 0)
        progMenuList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, int>((Expression<Func<int>>) (() => pmA_MenuGroupID));
      if (!string.IsNullOrEmpty(pm_UseYn))
        progMenuList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, string>((Expression<Func<string>>) (() => pm_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        progMenuList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      progMenuList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuView>>>>(MethodBase.GetCurrentMethod());
      return progMenuList;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuLevel>> GetProgMenuDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pm_SiteID")] long pm_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_pm_ProgKind")] int pm_ProgKind = 0,
      [NameConvert("p_pmA_MenuGroupID")] int pmA_MenuGroupID = 0,
      [NameConvert("p_pm_UseYn")] string pm_UseYn = null)
    {
      UniBizHttpRequest<UbRes<ProgMenuLevel>> progMenuDepth = new UniBizHttpRequest<UbRes<ProgMenuLevel>>(HttpMethod.Get);
      progMenuDepth.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pm_SiteID}/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuDepth.Headers.Add("Send-Type", SendType);
      progMenuDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuLevel>>, long>((Expression<Func<long>>) (() => pm_SiteID));
      progMenuDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuLevel>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuLevel>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (pm_ProgKind > 0)
        progMenuDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuLevel>>, int>((Expression<Func<int>>) (() => pm_ProgKind));
      if (pmA_MenuGroupID > 0)
        progMenuDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuLevel>>, int>((Expression<Func<int>>) (() => pmA_MenuGroupID));
      if (!string.IsNullOrEmpty(pm_UseYn))
        progMenuDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuLevel>>, string>((Expression<Func<string>>) (() => pm_UseYn));
      progMenuDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuLevel>>>(MethodBase.GetCurrentMethod());
      return progMenuDepth;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuPropView>> GetProgMenuProp(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmp_SiteID")] long pmp_SiteID,
      [NameConvert("p_pmp_PropCode")] int pmp_PropCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ProgMenuPropView>> progMenuProp = new UniBizHttpRequest<UbRes<ProgMenuPropView>>(HttpMethod.Get);
      progMenuProp.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenuProp/{pmp_SiteID}/{pmp_PropCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuProp.Headers.Add("Send-Type", SendType);
      progMenuProp.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, long>((Expression<Func<long>>) (() => pmp_SiteID));
      progMenuProp.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => pmp_PropCode));
      progMenuProp.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuProp.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      progMenuProp.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuPropView>>>(MethodBase.GetCurrentMethod());
      return progMenuProp;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuPropView>> PostProgMenuProp(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmp_SiteID")] long pmp_SiteID,
      [NameConvert("p_pmp_PropCode")] int pmp_PropCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ProgMenuPropView pData)
    {
      UniBizHttpRequest<UbRes<ProgMenuPropView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ProgMenuPropView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenuProp/{pmp_SiteID}/{pmp_PropCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, long>((Expression<Func<long>>) (() => pmp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => pmp_PropCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ProgMenuPropView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuPropView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>> GetProgMenuPropList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmp_SiteID")] long pmp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_pmp_ProgKind")] int pmp_ProgKind = 0,
      [NameConvert("p_pmpA_MenuGroupID")] int pmpA_MenuGroupID = 0,
      [NameConvert("p_pmp_UseYn")] string pmp_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>> progMenuPropList = new UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>(HttpMethod.Get);
      progMenuPropList.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenuProp/{pmp_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuPropList.Headers.Add("Send-Type", SendType);
      progMenuPropList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, long>((Expression<Func<long>>) (() => pmp_SiteID));
      progMenuPropList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuPropList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (pmp_ProgKind > 0)
        progMenuPropList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => pmp_ProgKind));
      if (pmpA_MenuGroupID > 0)
        progMenuPropList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => pmpA_MenuGroupID));
      if (!string.IsNullOrEmpty(pmp_UseYn))
        progMenuPropList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, string>((Expression<Func<string>>) (() => pmp_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        progMenuPropList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      progMenuPropList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>>(MethodBase.GetCurrentMethod());
      return progMenuPropList;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuPropLevel>> GetProgMenuPropDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmp_SiteID")] long pmp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_pmp_ProgKind")] int pmp_ProgKind = 0,
      [NameConvert("p_pmpA_MenuGroupID")] int pmpA_MenuGroupID = 0,
      [NameConvert("p_pmp_UseYn")] string pmp_UseYn = null)
    {
      UniBizHttpRequest<UbRes<ProgMenuPropLevel>> progMenuPropDepth = new UniBizHttpRequest<UbRes<ProgMenuPropLevel>>(HttpMethod.Get);
      progMenuPropDepth.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenuProp/{pmp_SiteID}/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuPropDepth.Headers.Add("Send-Type", SendType);
      progMenuPropDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, long>((Expression<Func<long>>) (() => pmp_SiteID));
      progMenuPropDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuPropDepth.SetSegment<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (pmp_ProgKind > 0)
        progMenuPropDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, int>((Expression<Func<int>>) (() => pmp_ProgKind));
      if (pmpA_MenuGroupID > 0)
        progMenuPropDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, int>((Expression<Func<int>>) (() => pmpA_MenuGroupID));
      if (!string.IsNullOrEmpty(pmp_UseYn))
        progMenuPropDepth.SetQuery<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>, string>((Expression<Func<string>>) (() => pmp_UseYn));
      progMenuPropDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuPropLevel>>>(MethodBase.GetCurrentMethod());
      return progMenuPropDepth;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>> PostProgMenuPropList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmp_SiteID")] long pmp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<ProgMenuPropView> pList)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenuProp/{pmp_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, long>((Expression<Func<long>>) (() => pmp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<ProgMenuPropView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuPropView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> GetProgMenuBookMark(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_pmbm_ID")] long pmbm_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> progMenuBookMark = new UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>(HttpMethod.Get);
      progMenuBookMark.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/{pmbm_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progMenuBookMark.Headers.Add("Send-Type", SendType);
      progMenuBookMark.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      progMenuBookMark.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_ID));
      progMenuBookMark.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progMenuBookMark.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      progMenuBookMark.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>>(MethodBase.GetCurrentMethod());
      return progMenuBookMark;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> PostProgMenuBookMark(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_pmbm_ID")] long pmbm_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ProgMenuBookMarkView pData)
    {
      UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/{pmbm_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ProgMenuBookMarkView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> DeleteProgMenuBookMark(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_pmbm_ID")] long pmbm_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ProgMenuBookMarkView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/{pmbm_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, long>((Expression<Func<long>>) (() => pmbm_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgMenuBookMarkView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> GetProgMenuBookMarkList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_pmbm_EmpCode")] int pmbm_EmpCode,
      [NameConvert("p_pmbm_AppType")] int pmbm_AppType,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> menuBookMarkList = new UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>(HttpMethod.Get);
      menuBookMarkList.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/Depth/{pmbm_EmpCode}/{pmbm_AppType}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      menuBookMarkList.Headers.Add("Send-Type", SendType);
      menuBookMarkList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      menuBookMarkList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => pmbm_EmpCode));
      menuBookMarkList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => pmbm_AppType));
      menuBookMarkList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      menuBookMarkList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      menuBookMarkList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>>(MethodBase.GetCurrentMethod());
      return menuBookMarkList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> PostProgMenuBookMarkList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<ProgMenuBookMarkView> pList)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<ProgMenuBookMarkView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> DeleteProgMenuBookMarkList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pmbm_SiteID")] long pmbm_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<ProgMenuBookMarkView> pList)
    {
      UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgMenuInfoRestServer>() + "/ProgMenu/{pmbm_SiteID}/BookMark/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, long>((Expression<Func<long>>) (() => pmbm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<ProgMenuBookMarkView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgMenuBookMarkView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
