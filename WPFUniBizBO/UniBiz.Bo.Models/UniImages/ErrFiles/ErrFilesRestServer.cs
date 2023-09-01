// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.ErrFiles.ErrFilesRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniImages.ErrFiles
{
  [UbRestModel("/Images", TableCodeType.ErrFiles, HeaderPath = "")]
  public class ErrFilesRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<ErrFilesView>> GetErrFiles(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_ef_UUID")] long ef_UUID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<ErrFilesView>> errFiles = new UniBizHttpRequest<UbRes<ErrFilesView>>(HttpMethod.Get);
      errFiles.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{ef_UUID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      errFiles.Headers.Add("Send-Type", SendType);
      errFiles.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_SiteID));
      errFiles.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_UUID));
      errFiles.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      errFiles.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (is_origin_image)
        errFiles.SetQuery<UniBizHttpRequest<UbRes<ErrFilesView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      errFiles.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrFilesView>>>(MethodBase.GetCurrentMethod());
      return errFiles;
    }

    public static UniBizHttpRequest<UbRes<ErrFilesView>> DeleteErrFiles(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_ef_UUID")] long ef_UUID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<ErrFilesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ErrFilesView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{ef_UUID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_UUID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrFilesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<ErrFilesView>> PostErrFilesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_ef_UUID")] long ef_UUID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<ErrFilesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ErrFilesView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{ef_UUID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_UUID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrFilesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<ErrFilesView>> PostErrFilesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_ef_UUID")] long ef_UUID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<ErrFilesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<ErrFilesView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{ef_UUID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, long>((Expression<Func<long>>) (() => ef_UUID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<ErrFilesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<ErrFilesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetErrFilesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_ef_UUID")] long ef_UUID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest errFilesFile = new UniBizHttpRequest(HttpMethod.Get);
      errFilesFile.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{ef_UUID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      errFilesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ef_SiteID));
      errFilesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ef_UUID));
      errFilesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      errFilesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      errFilesFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return errFilesFile;
    }

    public static UniBizHttpRequest<UbRes<IList<ErrFilesView>>> GetErrFilesList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ef_SiteID")] long ef_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ef_UUID")] long ef_UUID = 0,
      [NameConvert("p_ef_FileName")] string ef_FileName = null,
      [NameConvert("p_ef_Type")] int ef_Type = 0,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<ErrFilesView>>> errFilesList = new UniBizHttpRequest<UbRes<IList<ErrFilesView>>>(HttpMethod.Get);
      errFilesList.Resource = UbRestModelAttribute.GetBasePath<ErrFilesRestServer>() + "/{ef_SiteID}/ErrFiles/{work_pm_MenuCode}/{work_pmp_PropCode}";
      errFilesList.Headers.Add("Send-Type", SendType);
      errFilesList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, long>((Expression<Func<long>>) (() => ef_SiteID));
      errFilesList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      errFilesList.SetSegment<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ef_UUID > 0L)
        errFilesList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, long>((Expression<Func<long>>) (() => ef_UUID));
      if (!string.IsNullOrEmpty(ef_FileName))
        errFilesList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, string>((Expression<Func<string>>) (() => ef_FileName));
      if (ef_Type > 0)
        errFilesList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, int>((Expression<Func<int>>) (() => ef_Type));
      if (is_origin_image)
        errFilesList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        errFilesList.SetQuery<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      errFilesList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<ErrFilesView>>>>(MethodBase.GetCurrentMethod());
      return errFilesList;
    }
  }
}
