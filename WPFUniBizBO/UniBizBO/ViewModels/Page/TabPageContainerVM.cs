// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.TabPageContainerVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.ViewModels.Page
{
  public class TabPageContainerVM : 
    PageContainerBase,
    IHandle<DashBoardCloseMsg>,
    IHandle,
    IHandle<CloseTabPageItemMsg>
  {
    public TabPageContainerVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.SelectHomeItem();
    }

    protected override void ChangeActiveItem(IPage newItem, bool closePrevious)
    {
      if (newItem != null)
      {
        if (newItem.GetType().Name.Equals("DashBoardPageVM"))
        {
          IEventAggregator eventAggregator = this.EventAggregator;
          OpenedPageMsg message = new OpenedPageMsg((IUbVM) this);
          message.Page = newItem;
          message.DisplayTitle = newItem.MenuInfo.Name;
          string[] strArray = Array.Empty<string>();
          eventAggregator.PublishOnUIThread((object) message, strArray);
        }
        else
        {
          ParentOnePageBase parentOnePageBase = (ParentOnePageBase) newItem;
          if (parentOnePageBase != null)
          {
            PageBase activeItem = (PageBase) parentOnePageBase.ActiveItem;
            if (activeItem != null)
            {
              IEventAggregator eventAggregator = this.EventAggregator;
              OpenedPageMsg message = new OpenedPageMsg((IUbVM) this);
              message.Page = newItem;
              message.DisplaySearchCount = activeItem.DisplaySearchCount;
              message.DisplayTitle = activeItem.MenuInfo.Name;
              string[] strArray = Array.Empty<string>();
              eventAggregator.PublishOnUIThread((object) message, strArray);
            }
          }
        }
      }
      base.ChangeActiveItem(newItem, closePrevious);
    }

    public override void CloseItem(IPage item)
    {
      base.CloseItem(item);
      if (item.MenuInfo.Name.Equals("DashBoard") || this.Items.Count != 0)
        return;
      this.SelectHomeItem();
    }

    public bool CanSelectPreviousItem() => this.ActiveItem != null && this.Items.IndexOf(this.ActiveItem) > 0;

    public void SelectPreviousItem()
    {
      if (!this.CanSelectPreviousItem())
        return;
      this.ActivateItem(this.Items[this.Items.IndexOf(this.ActiveItem) - 1]);
    }

    public bool CanSelectNextItem() => this.ActiveItem != null && this.Items.IndexOf(this.ActiveItem) < this.Items.Count - 1;

    public void SelectNextItem()
    {
      if (!this.CanSelectNextItem())
        return;
      this.ActivateItem(this.Items[this.Items.IndexOf(this.ActiveItem) + 1]);
    }

    public bool CanCloseAllItem() => true;

    public void CloseAllItem()
    {
      if (!this.CanCloseAllItem())
        return;
      foreach (IPage page in this.Items.ToArray<IPage>())
        this.CloseItem(page);
    }

    public void SelectHomeItem()
    {
      DashBoardPageVM pvm = this.Container.Get<DashBoardPageVM>();
      IPage page = this.Items.Where<IPage>((Func<IPage, bool>) (x => x.MenuInfo.Name.Equals(pvm.MenuInfo.Name))).FirstOrDefault<IPage>();
      if (page != null)
        this.CloseItem(page);
      this.ActivateItem((IPage) pvm);
    }

    public WpfCommand CmdSelectHomeItem
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.SelectHomeItem());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdSelectHomeItem));
      }
    }

    public WpfCommand CmdSelectPreviousItem
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.CanExecuteFunc = (Func<object, bool>) (_ => this.CanSelectPreviousItem());
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.SelectPreviousItem());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdSelectPreviousItem));
      }
    }

    public WpfCommand CmdSelectNextItem
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.CanExecuteFunc = (Func<object, bool>) (_ => this.CanSelectNextItem());
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.SelectNextItem());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdSelectNextItem));
      }
    }

    public WpfCommand CmdCloseAllItem
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.CanExecuteFunc = (Func<object, bool>) (_ => this.CanCloseAllItem());
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.CloseAllItem());
        wpfCommand.Name = "전체 페이지 닫기";
        wpfCommand.Explain = "열려 있는 전체 페이지를 닫습니다";
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdCloseAllItem));
      }
    }

    public void Handle(DashBoardCloseMsg message) => this.CloseItem((IPage) (message.Sender as DashBoardPageVM));

    public void Handle(CloseTabPageItemMsg message)
    {
      IPage page = ((IEnumerable<IPage>) this.Items.ToArray<IPage>()).Where<IPage>((Func<IPage, bool>) (x => x == message.Sender.Parent)).FirstOrDefault<IPage>();
      if (page == null)
        return;
      this.CloseItem(page);
    }
  }
}
