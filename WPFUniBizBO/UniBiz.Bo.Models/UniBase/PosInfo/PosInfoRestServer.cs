// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.PosInfo.PosInfoRestServer
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

namespace UniBiz.Bo.Models.UniBase.PosInfo
{
  [UbRestModel("/Code/PosInfo", TableCodeType.PosInfo, HeaderPath = "")]
  public class PosInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<PosInfoView>> GetPosInfoGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pos_SiteID")] long pos_SiteID,
      [NameConvert("p_pos_ID")] int pos_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<PosInfoView>> posInfoGroup = new UniBizHttpRequest<UbRes<PosInfoView>>(HttpMethod.Get);
      posInfoGroup.Resource = UbRestModelAttribute.GetBasePath<PosInfoRestServer>() + "/{pos_SiteID}/{pos_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      posInfoGroup.Headers.Add("Send-Type", SendType);
      posInfoGroup.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, long>((Expression<Func<long>>) (() => pos_SiteID));
      posInfoGroup.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => pos_ID));
      posInfoGroup.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      posInfoGroup.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      posInfoGroup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<PosInfoView>>>(MethodBase.GetCurrentMethod());
      return posInfoGroup;
    }

    public static UniBizHttpRequest<UbRes<PosInfoView>> PostPosInfoGroup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pos_SiteID")] long pos_SiteID,
      [NameConvert("p_pos_ID")] int pos_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      PosInfoView pData)
    {
      UniBizHttpRequest<UbRes<PosInfoView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<PosInfoView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<PosInfoRestServer>() + "/{pos_SiteID}/{pos_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, long>((Expression<Func<long>>) (() => pos_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => pos_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PosInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<PosInfoView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<PosInfoView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<PosInfoView>>> GetPosInfoList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_pos_SiteID")] long pos_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_pos_ID")] int pos_ID = 0,
      [NameConvert("p_pos_Name")] string pos_Name = null,
      [NameConvert("p_pos_UseYn")] string pos_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<PosInfoView>>> posInfoList = new UniBizHttpRequest<UbRes<IList<PosInfoView>>>(HttpMethod.Get);
      posInfoList.Resource = UbRestModelAttribute.GetBasePath<PosInfoRestServer>() + "/{pos_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      posInfoList.Headers.Add("Send-Type", SendType);
      posInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, long>((Expression<Func<long>>) (() => pos_SiteID));
      posInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      posInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (pos_ID > 0)
        posInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, int>((Expression<Func<int>>) (() => pos_ID));
      if (!string.IsNullOrEmpty(pos_Name))
        posInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, string>((Expression<Func<string>>) (() => pos_Name));
      if (!string.IsNullOrEmpty(pos_UseYn))
        posInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, string>((Expression<Func<string>>) (() => pos_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        posInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<PosInfoView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      posInfoList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<PosInfoView>>>>(MethodBase.GetCurrentMethod());
      return posInfoList;
    }
  }
}
