// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.UniTemplatesRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniImages.UniTemplates.Formtec;
using UniBiz.Bo.Models.UniImages.UniTemplates.Label;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniImages.UniTemplates
{
  [UbRestModel("/Images", TableCodeType.LabelTemplates, HeaderPath = "")]
  public class UniTemplatesRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<LabelTemplatesView>> GetLabelTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<LabelTemplatesView>> labelTemplates = new UniBizHttpRequest<UbRes<LabelTemplatesView>>(HttpMethod.Get);
      labelTemplates.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      labelTemplates.Headers.Add("Send-Type", SendType);
      labelTemplates.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      labelTemplates.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_ID));
      labelTemplates.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      labelTemplates.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (is_thumb_image)
        labelTemplates.SetQuery<UniBizHttpRequest<UbRes<LabelTemplatesView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        labelTemplates.SetQuery<UniBizHttpRequest<UbRes<LabelTemplatesView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      labelTemplates.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LabelTemplatesView>>>(MethodBase.GetCurrentMethod());
      return labelTemplates;
    }

    public static UniBizHttpRequest<UbRes<LabelTemplatesView>> PostLabelTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      LabelTemplatesView pData)
    {
      UniBizHttpRequest<UbRes<LabelTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LabelTemplatesView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<LabelTemplatesView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LabelTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<LabelTemplatesView>> DeleteLabelTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<LabelTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LabelTemplatesView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LabelTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<LabelTemplatesView>> PutLabelTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<LabelTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LabelTemplatesView>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LabelTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<LabelTemplatesView>> PutLabelTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<LabelTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LabelTemplatesView>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, long>((Expression<Func<long>>) (() => ltf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LabelTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LabelTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetLabelTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_ltf_ID")] long ltf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest labelTemplatesFile = new UniBizHttpRequest(HttpMethod.Get);
      labelTemplatesFile.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{ltf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      labelTemplatesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ltf_SiteID));
      labelTemplatesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ltf_ID));
      labelTemplatesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      labelTemplatesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      labelTemplatesFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return labelTemplatesFile;
    }

    public static UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>> GetLabelTemplatesList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ltf_SiteID")] long ltf_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ltf_ID")] long ltf_ID = 0,
      [NameConvert("p_ltf_Title")] string ltf_Title = null,
      [NameConvert("p_ltf_FileName")] string ltf_FileName = null,
      [NameConvert("p_ltf_OriginHash")] string ltf_OriginHash = null,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>> labelTemplatesList = new UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>(HttpMethod.Get);
      labelTemplatesList.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ltf_SiteID}/Templates/Label/{work_pm_MenuCode}/{work_pmp_PropCode}";
      labelTemplatesList.Headers.Add("Send-Type", SendType);
      labelTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, long>((Expression<Func<long>>) (() => ltf_SiteID));
      labelTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      labelTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ltf_ID > 0L)
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, long>((Expression<Func<long>>) (() => ltf_ID));
      if (!string.IsNullOrEmpty(ltf_Title))
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, string>((Expression<Func<string>>) (() => ltf_Title));
      if (!string.IsNullOrEmpty(ltf_FileName))
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, string>((Expression<Func<string>>) (() => ltf_FileName));
      if (!string.IsNullOrEmpty(ltf_OriginHash))
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, string>((Expression<Func<string>>) (() => ltf_OriginHash));
      if (is_thumb_image)
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        labelTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      labelTemplatesList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<LabelTemplatesView>>>>(MethodBase.GetCurrentMethod());
      return labelTemplatesList;
    }

    public static UniBizHttpRequest<UbRes<FormtecTemplatesView>> GetFormtecTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<FormtecTemplatesView>> formtecTemplates = new UniBizHttpRequest<UbRes<FormtecTemplatesView>>(HttpMethod.Get);
      formtecTemplates.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      formtecTemplates.Headers.Add("Send-Type", SendType);
      formtecTemplates.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      formtecTemplates.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_ID));
      formtecTemplates.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      formtecTemplates.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (is_thumb_image)
        formtecTemplates.SetQuery<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        formtecTemplates.SetQuery<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      formtecTemplates.ReplaceByNameConverter<UniBizHttpRequest<UbRes<FormtecTemplatesView>>>(MethodBase.GetCurrentMethod());
      return formtecTemplates;
    }

    public static UniBizHttpRequest<UbRes<FormtecTemplatesView>> PostFormtecTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      FormtecTemplatesView pData)
    {
      UniBizHttpRequest<UbRes<FormtecTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<FormtecTemplatesView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<FormtecTemplatesView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<FormtecTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<FormtecTemplatesView>> DeleteFormtecTemplates(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<FormtecTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<FormtecTemplatesView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<FormtecTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<FormtecTemplatesView>> PutFormtecTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<FormtecTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<FormtecTemplatesView>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<FormtecTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<FormtecTemplatesView>> PutFormtecTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<FormtecTemplatesView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<FormtecTemplatesView>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, long>((Expression<Func<long>>) (() => ftf_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<FormtecTemplatesView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<FormtecTemplatesView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetFormtecTemplatesFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_ftf_ID")] long ftf_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest formtecTemplatesFile = new UniBizHttpRequest(HttpMethod.Get);
      formtecTemplatesFile.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{ftf_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}/File";
      formtecTemplatesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ftf_SiteID));
      formtecTemplatesFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ftf_ID));
      formtecTemplatesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      formtecTemplatesFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      formtecTemplatesFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return formtecTemplatesFile;
    }

    public static UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>> GetFormtecTemplatesList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ftf_SiteID")] long ftf_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ftf_ID")] long ftf_ID = 0,
      [NameConvert("p_ftf_Title")] string ftf_Title = null,
      [NameConvert("p_ftf_FileName")] string ftf_FileName = null,
      [NameConvert("p_ftf_OriginHash")] string ftf_OriginHash = null,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>> formtecTemplatesList = new UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>(HttpMethod.Get);
      formtecTemplatesList.Resource = UbRestModelAttribute.GetBasePath<UniTemplatesRestServer>() + "/{ftf_SiteID}/Templates/Formtec/{work_pm_MenuCode}/{work_pmp_PropCode}";
      formtecTemplatesList.Headers.Add("Send-Type", SendType);
      formtecTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, long>((Expression<Func<long>>) (() => ftf_SiteID));
      formtecTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      formtecTemplatesList.SetSegment<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ftf_ID > 0L)
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, long>((Expression<Func<long>>) (() => ftf_ID));
      if (!string.IsNullOrEmpty(ftf_Title))
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, string>((Expression<Func<string>>) (() => ftf_Title));
      if (!string.IsNullOrEmpty(ftf_FileName))
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, string>((Expression<Func<string>>) (() => ftf_FileName));
      if (!string.IsNullOrEmpty(ftf_OriginHash))
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, string>((Expression<Func<string>>) (() => ftf_OriginHash));
      if (is_thumb_image)
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        formtecTemplatesList.SetQuery<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      formtecTemplatesList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<FormtecTemplatesView>>>>(MethodBase.GetCurrentMethod());
      return formtecTemplatesList;
    }
  }
}
