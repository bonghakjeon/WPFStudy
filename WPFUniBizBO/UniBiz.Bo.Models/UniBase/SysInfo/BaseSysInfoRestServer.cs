// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.SysInfo.BaseSysInfoRestServer
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
using UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.SysInfo
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class BaseSysInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<ErrorCodeView>> GetErrorCode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_err_SiteID")] long err_SiteID,
      [NameConvert("p_err_ID")] int err_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ErrorCodeView>> errorCode = new UniBizHttpRequest<UbRes<ErrorCodeView>>(HttpMethod.Get);
      errorCode.Resource = UbRestModelAttribute.GetBasePath<BaseSysInfoRestServer>() + "/{err_SiteID}/ErrorCode/{err_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      errorCode.Headers.Add("Send-Type", SendType);
      errorCode.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, long>((Expression<Func<long>>) (() => err_SiteID));
      errorCode.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => err_ID));
      errorCode.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      errorCode.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      errorCode.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrorCodeView>>>(MethodBase.GetCurrentMethod());
      return errorCode;
    }

    public static UniBizHttpRequest<UbRes<ErrorCodeView>> PostErrorCode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_err_SiteID")] long err_SiteID,
      [NameConvert("p_err_ID")] int err_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ErrorCodeView pData)
    {
      UniBizHttpRequest<UbRes<ErrorCodeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ErrorCodeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<BaseSysInfoRestServer>() + "/{err_SiteID}/ErrorCode/{err_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, long>((Expression<Func<long>>) (() => err_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => err_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrorCodeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ErrorCodeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrorCodeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ErrorCodeView>>> GetErrorCodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_err_SiteID")] long err_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_err_ID")] int err_ID = 0,
      [NameConvert("p_err_ViewCode")] string err_ViewCode = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ErrorCodeView>>> errorCodeList = new UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>(HttpMethod.Get);
      errorCodeList.Resource = UbRestModelAttribute.GetBasePath<BaseSysInfoRestServer>() + "/{err_SiteID}/ErrorCode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      errorCodeList.Headers.Add("Send-Type", SendType);
      errorCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, long>((Expression<Func<long>>) (() => err_SiteID));
      errorCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      errorCodeList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (err_ID > 0)
        errorCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, int>((Expression<Func<int>>) (() => err_ID));
      if (!string.IsNullOrEmpty(err_ViewCode))
        errorCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, string>((Expression<Func<string>>) (() => err_ViewCode));
      if (!string.IsNullOrEmpty(KeyWord))
        errorCodeList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      errorCodeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ErrorCodeView>>>>(MethodBase.GetCurrentMethod());
      return errorCodeList;
    }
  }
}
