// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.DashBoardPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;

namespace UniBizBO.ViewModels.Page
{
  public class DashBoardPageVM : PageBase, ISystemPage
  {
    public DashBoardPageVM(IContainer container)
      : base(container)
    {
      this.MenuInfo = new PageMenuInfo();
      this.MenuInfo.Name = "DashBoard";
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.EventAggregator.Subscribe((IHandle) this);
    }

    protected override void OnDeactivate()
    {
      base.OnDeactivate();
      this.EventAggregator.PublishOnUIThread((object) new DashBoardCloseMsg((IUbVM) this));
      this.EventAggregator.Unsubscribe((IHandle) this);
    }
  }
}
