// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.CommonCodeRestServer
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

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class CommonCodeRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<CommonCodeView>> GetCommonCode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_comm_SiteID")] long comm_SiteID,
      [NameConvert("p_comm_Type")] int comm_Type,
      [NameConvert("p_comm_TypeNo")] int comm_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CommonCodeView>> commonCode = new UniBizHttpRequest<UbRes<CommonCodeView>>(HttpMethod.Get);
      commonCode.Resource = UbRestModelAttribute.GetBasePath<CommonCodeRestServer>() + "/CommonCode/{comm_SiteID}/{comm_Type}/{comm_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      commonCode.Headers.Add("Send-Type", SendType);
      commonCode.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, long>((Expression<Func<long>>) (() => comm_SiteID));
      commonCode.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => comm_Type));
      commonCode.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => comm_TypeNo));
      commonCode.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      commonCode.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      commonCode.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CommonCodeView>>>(MethodBase.GetCurrentMethod());
      return commonCode;
    }

    public static UniBizHttpRequest<UbRes<CommonCodeView>> PostCommonCode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_comm_SiteID")] long comm_SiteID,
      [NameConvert("p_comm_Type")] int comm_Type,
      [NameConvert("p_comm_TypeNo")] int comm_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CommonCodeView pData)
    {
      UniBizHttpRequest<UbRes<CommonCodeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CommonCodeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CommonCodeRestServer>() + "/CommonCode/{comm_SiteID}/{comm_Type}/{comm_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, long>((Expression<Func<long>>) (() => comm_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => comm_Type));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => comm_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CommonCodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CommonCodeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CommonCodeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CommonCodeView>>> GetCommonCodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_comm_SiteID")] long comm_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_comm_Type")] int comm_Type = 0,
      [NameConvert("p_comm_TypeNo")] int comm_TypeNo = -1,
      [NameConvert("p_comm_UseYn")] string comm_UseYn = null,
      [NameConvert("p_order_by")] int orderBy = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CommonCodeView>>> commonCodeList = new UniBizHttpRequest<UbRes<IList<CommonCodeView>>>(HttpMethod.Get);
      commonCodeList.Resource = UbRestModelAttribute.GetBasePath<CommonCodeRestServer>() + "/CommonCode/{comm_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      commonCodeList.Headers.Add("Send-Type", SendType);
      commonCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, long>((Expression<Func<long>>) (() => comm_SiteID));
      commonCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      commonCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (comm_Type > 0)
        commonCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, int>((Expression<Func<int>>) (() => comm_Type));
      if (comm_TypeNo > -1)
        commonCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, int>((Expression<Func<int>>) (() => comm_TypeNo));
      if (!string.IsNullOrEmpty(comm_UseYn))
        commonCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, string>((Expression<Func<string>>) (() => comm_UseYn));
      if (orderBy > 0)
        commonCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, int>((Expression<Func<int>>) (() => orderBy));
      if (!string.IsNullOrEmpty(KeyWord))
        commonCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      commonCodeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CommonCodeView>>>>(MethodBase.GetCurrentMethod());
      return commonCodeList;
    }
  }
}
