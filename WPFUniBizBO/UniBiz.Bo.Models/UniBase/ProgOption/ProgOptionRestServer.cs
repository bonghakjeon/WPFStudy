// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.ProgOptionRestServer
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

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class ProgOptionRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<ProgOptionView>> GetProgOption(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_opt_SiteID")] long opt_SiteID,
      [NameConvert("p_opt_Code")] int opt_Code,
      [NameConvert("p_opt_StoreCode")] int opt_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ProgOptionView>> progOption = new UniBizHttpRequest<UbRes<ProgOptionView>>(HttpMethod.Get);
      progOption.Resource = UbRestModelAttribute.GetBasePath<ProgOptionRestServer>() + "/ProgOption/{opt_SiteID}/{opt_Code}/{opt_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progOption.Headers.Add("Send-Type", SendType);
      progOption.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, long>((Expression<Func<long>>) (() => opt_SiteID));
      progOption.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => opt_Code));
      progOption.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => opt_StoreCode));
      progOption.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progOption.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      progOption.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgOptionView>>>(MethodBase.GetCurrentMethod());
      return progOption;
    }

    public static UniBizHttpRequest<UbRes<ProgOptionView>> PostProgMenuProp(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_opt_SiteID")] long opt_SiteID,
      [NameConvert("p_opt_Code")] int opt_Code,
      [NameConvert("p_opt_StoreCode")] int opt_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      ProgOptionView pData)
    {
      UniBizHttpRequest<UbRes<ProgOptionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ProgOptionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgOptionRestServer>() + "/ProgOption/{opt_SiteID}/{opt_Code}/{opt_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, long>((Expression<Func<long>>) (() => opt_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => opt_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => opt_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ProgOptionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<ProgOptionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ProgOptionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgOptionView>>> GetProgOptionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_opt_SiteID")] long opt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_opt_Code")] int opt_Code = 0,
      [NameConvert("p_is_opt_Code_ZeroCode")] bool is_opt_Code_ZeroCode = false,
      [NameConvert("p_opt_StoreCode")] int opt_StoreCode = -1,
      [NameConvert("p_is_opt_StoreCode_ZeroCode")] bool is_opt_StoreCode_ZeroCode = false,
      [NameConvert("p_opt_Type")] int opt_Type = 0,
      [NameConvert("p_opt_ValueType")] int opt_ValueType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ProgOptionView>>> progOptionList = new UniBizHttpRequest<UbRes<IList<ProgOptionView>>>(HttpMethod.Get);
      progOptionList.Resource = UbRestModelAttribute.GetBasePath<ProgOptionRestServer>() + "/ProgOption/{opt_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      progOptionList.Headers.Add("Send-Type", SendType);
      progOptionList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, long>((Expression<Func<long>>) (() => opt_SiteID));
      progOptionList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      progOptionList.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (opt_Code > 0)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => opt_Code));
      if (is_opt_Code_ZeroCode)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, bool>((Expression<Func<bool>>) (() => is_opt_Code_ZeroCode));
      if (opt_StoreCode > -1)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => opt_StoreCode));
      if (is_opt_StoreCode_ZeroCode)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, bool>((Expression<Func<bool>>) (() => is_opt_StoreCode_ZeroCode));
      if (opt_Type > 0)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => opt_Type));
      if (opt_ValueType > 0)
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => opt_ValueType));
      if (!string.IsNullOrEmpty(KeyWord))
        progOptionList.SetQuery<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      progOptionList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>>(MethodBase.GetCurrentMethod());
      return progOptionList;
    }

    public static UniBizHttpRequest<UbRes<IList<ProgOptionView>>> PostProgMenuPropList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_opt_SiteID")] long opt_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<ProgOptionView> pList)
    {
      UniBizHttpRequest<UbRes<IList<ProgOptionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<ProgOptionView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ProgOptionRestServer>() + "/ProgOption/{opt_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, long>((Expression<Func<long>>) (() => opt_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<ProgOptionView>>(pList, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ProgOptionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
