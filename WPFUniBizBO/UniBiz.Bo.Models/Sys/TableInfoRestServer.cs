// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.TableInfoRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.Sys
{
  [UbRestModel("/Sys/TableInfo", TableCodeType.Unknown, HeaderPath = "")]
  public class TableInfoRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<IList<TableView>>> GetTableList()
    {
      UniBizHttpRequest<UbRes<IList<TableView>>> tableList = new UniBizHttpRequest<UbRes<IList<TableView>>>(HttpMethod.Get);
      tableList.Resource = UbRestModelAttribute.GetBasePath<TableInfoRestServer>();
      tableList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<TableView>>>>(MethodBase.GetCurrentMethod());
      return tableList;
    }

    public static UniBizHttpRequest<UbRes<IList<TableView>>> PostTableListCreate(TableCreate pData)
    {
      UniBizHttpRequest<UbRes<IList<TableView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<TableView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<TableInfoRestServer>();
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<TableCreate>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<TableView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
