// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Dept.DeptRestServer
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

namespace UniBiz.Bo.Models.UniBase.Dept
{
  [UbRestModel("/Code/Dept", TableCodeType.Dept, HeaderPath = "")]
  public class DeptRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<DeptView>> GetDept(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dpt_SiteID")] long dpt_SiteID,
      [NameConvert("p_dpt_ID")] int dpt_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<DeptView>> dept = new UniBizHttpRequest<UbRes<DeptView>>(HttpMethod.Get);
      dept.Resource = UbRestModelAttribute.GetBasePath<DeptRestServer>() + "/{dpt_SiteID}/{dpt_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dept.Headers.Add("Send-Type", SendType);
      dept.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, long>((Expression<Func<long>>) (() => dpt_SiteID));
      dept.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => dpt_ID));
      dept.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dept.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dept.ReplaceByNameConverter<UniBizHttpRequest<UbRes<DeptView>>>(MethodBase.GetCurrentMethod());
      return dept;
    }

    public static UniBizHttpRequest<UbRes<DeptView>> PostDept(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dpt_SiteID")] long dpt_SiteID,
      [NameConvert("p_dpt_ID")] int dpt_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      DeptView pData)
    {
      UniBizHttpRequest<UbRes<DeptView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<DeptView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<DeptRestServer>() + "/{dpt_SiteID}/{dpt_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, long>((Expression<Func<long>>) (() => dpt_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => dpt_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<DeptView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<DeptView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<DeptView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<DeptView>>> GetDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dpt_SiteID")] long dpt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_dpt_ID")] int dpt_ID = 0,
      [NameConvert("p_dpt_DeptName")] string dpt_DeptName = null,
      [NameConvert("p_dpt_ViewCode")] string dpt_ViewCode = null,
      [NameConvert("p_dpt_UseYn")] string dpt_UseYn = null,
      [NameConvert("p_dpt_Depth")] int dpt_Depth = 0,
      [NameConvert("p_dpt_ParentsID")] int dpt_ParentsID = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<DeptView>>> deptList = new UniBizHttpRequest<UbRes<IList<DeptView>>>(HttpMethod.Get);
      deptList.Resource = UbRestModelAttribute.GetBasePath<DeptRestServer>() + "/{dpt_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      deptList.Headers.Add("Send-Type", SendType);
      deptList.SetSegment<UniBizHttpRequest<UbRes<IList<DeptView>>>, long>((Expression<Func<long>>) (() => dpt_SiteID));
      deptList.SetSegment<UniBizHttpRequest<UbRes<IList<DeptView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      deptList.SetSegment<UniBizHttpRequest<UbRes<IList<DeptView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (dpt_ID > 0)
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, int>((Expression<Func<int>>) (() => dpt_ID));
      if (!string.IsNullOrEmpty(dpt_DeptName))
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, string>((Expression<Func<string>>) (() => dpt_DeptName));
      if (!string.IsNullOrEmpty(dpt_ViewCode))
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, string>((Expression<Func<string>>) (() => dpt_ViewCode));
      if (!string.IsNullOrEmpty(dpt_UseYn))
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, string>((Expression<Func<string>>) (() => dpt_UseYn));
      if (dpt_Depth > 0)
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, int>((Expression<Func<int>>) (() => dpt_Depth));
      if (dpt_ParentsID > 0)
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, int>((Expression<Func<int>>) (() => dpt_ParentsID));
      if (!string.IsNullOrEmpty(KeyWord))
        deptList.SetQuery<UniBizHttpRequest<UbRes<IList<DeptView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      deptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<DeptView>>>>(MethodBase.GetCurrentMethod());
      return deptList;
    }

    public static UniBizHttpRequest<UbRes<DeptLevel>> GetDeptDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dpt_SiteID")] long dpt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_dpt_UseYn")] string dpt_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<DeptLevel>> deptDepth = new UniBizHttpRequest<UbRes<DeptLevel>>(HttpMethod.Get);
      deptDepth.Resource = UbRestModelAttribute.GetBasePath<DeptRestServer>() + "/{dpt_SiteID}/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      deptDepth.Headers.Add("Send-Type", SendType);
      deptDepth.SetSegment<UniBizHttpRequest<UbRes<DeptLevel>>, long>((Expression<Func<long>>) (() => dpt_SiteID));
      deptDepth.SetSegment<UniBizHttpRequest<UbRes<DeptLevel>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      deptDepth.SetSegment<UniBizHttpRequest<UbRes<DeptLevel>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(dpt_UseYn))
        deptDepth.SetQuery<UniBizHttpRequest<UbRes<DeptLevel>>, string>((Expression<Func<string>>) (() => dpt_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        deptDepth.SetQuery<UniBizHttpRequest<UbRes<DeptLevel>>, string>((Expression<Func<string>>) (() => KeyWord));
      deptDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<DeptLevel>>>(MethodBase.GetCurrentMethod());
      return deptDepth;
    }
  }
}
