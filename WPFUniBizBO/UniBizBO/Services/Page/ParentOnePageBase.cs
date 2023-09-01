// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.ParentOnePageBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBizBO.Composition;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.Services.Page
{
  [HiddenVm]
  public abstract class ParentOnePageBase : UbConductorOne<
  #nullable disable
  IPage>, IParentPage, IPage
  {
    public PageMenuInfo MenuInfo { get; set; }

    public ParentOnePageBase(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DisplayName = this.MenuInfo?.Name;
    }

    public void SendParamBeforePage(IPage sender)
    {
      int num = this.Items.IndexOf(sender);
      if (num == 0 || this.Items.Count < num + 1)
        return;
      IPage page = this.Items[num - 1];
      this.ActivateItem(page);
      page.OnReceiveBeforePage(sender);
    }

    public void OnReceiveBeforePage(IPage sender)
    {
    }

    public async Task SendParamAfterPageAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      ParentOnePageBase parentOnePageBase = this;
      int num = parentOnePageBase.Items.IndexOf(sender);
      if (num == -1 || parentOnePageBase.Items.Count <= num + 1)
        return;
      IPage page = parentOnePageBase.Items[num + 1];
      parentOnePageBase.ActivateItem(page);
      await page.OnReceiveParamAsync(sender, param, arg);
    }

    public async Task OnReceiveParamAsync(
      IPage sender,
      ParamBase param,
      IDictionary<string, object> arg = null)
    {
      await Task.Yield();
    }

    public void RequestCloseFromContainer(bool? dialogResult = null)
    {
      if (this.Parent is IParentPage parent)
        parent.RequestCloseFromContainer(dialogResult);
      else
        this.RequestClose(dialogResult);
    }

    protected override void OnClose()
    {
      base.OnClose();
      foreach (IPage page in this.Items.ToArray<IPage>())
      {
        if (page is IRequestClose requestClose)
        {
          bool? dialogResult = new bool?();
          requestClose.RequestClose(dialogResult);
        }
      }
    }

    public WpfCommand CmdRequestCloseFromContainer => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (x => this.RequestCloseFromContainer(new bool?()))
      };
    }), nameof (CmdRequestCloseFromContainer));
  }
}
