// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.SessionRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.Sys
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class SessionRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<string>> HeadOnLineCheckHeader([NameConvert("pPosNo")] int PosNo)
    {
      UniBizHttpRequest<UbRes<string>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<string>>(HttpMethod.Head);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SessionRestServer>() + "/OnLine/Check/Header/{PosNo}";
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<string>>, int>((Expression<Func<int>>) (() => PosNo));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<string>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<string>> GetLineCheck([NameConvert("pPosNo")] int PosNo)
    {
      UniBizHttpRequest<UbRes<string>> lineCheck = new UniBizHttpRequest<UbRes<string>>(HttpMethod.Get);
      lineCheck.Resource = UbRestModelAttribute.GetBasePath<SessionRestServer>() + "/OnLine/Check/{PosNo}";
      lineCheck.SetSegment<UniBizHttpRequest<UbRes<string>>, int>((Expression<Func<int>>) (() => PosNo));
      lineCheck.ReplaceByNameConverter<UniBizHttpRequest<UbRes<string>>>(MethodBase.GetCurrentMethod());
      return lineCheck;
    }

    public static UniBizHttpRequest<UbRes<string>> PostSessionCheck()
    {
      UniBizHttpRequest<UbRes<string>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<string>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SessionRestServer>() + "/Session/Check";
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<string>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<string>> PostProgOption([NameConvert("Send-Type")] string SendType)
    {
      UniBizHttpRequest<UbRes<string>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<string>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SessionRestServer>() + "/Session/Check/Header";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<string>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
