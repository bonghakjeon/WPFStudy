// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.IPage
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections.Generic;
using System.Threading.Tasks;
using UniBizBO.Composition;

namespace UniBizBO.Services.Page
{
  public interface IPage
  {
    PageMenuInfo MenuInfo { get; set; }

    void SendParamBeforePage(IPage sender);

    void OnReceiveBeforePage(IPage sender);

    Task SendParamAfterPageAsync(IPage sender, ParamBase param, IDictionary<string, object> arg = null);

    Task OnReceiveParamAsync(IPage sender, ParamBase param, IDictionary<string, object> arg = null);

    void RequestCloseFromContainer(bool? dialogResult = null);
  }
}
