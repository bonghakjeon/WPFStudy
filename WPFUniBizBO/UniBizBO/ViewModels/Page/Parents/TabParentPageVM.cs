// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.Parents.TabParentPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Linq;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.ViewModels.Page.Parents
{
  public class TabParentPageVM : 
    ParentOnePageBase,
    IHandle<AppWinMsg>,
    IHandle,
    IHandle<MenuBookMarkSelectedMsg>
  {
    public TabParentPageVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      BindableCollection<PageMenuInfo> children = this.MenuInfo.Children;
      if (children != null)
        children.OfType<PageMenuInfo>().ToList<PageMenuInfo>().ForEach((Action<PageMenuInfo>) (menu =>
        {
          IPage instance = menu.GetInstance<IPage>(this.App.ClazzFinder, this.Container);
          if (instance == null)
            return;
          instance.Action<IPage>((Action<IPage>) (page => this.EnsureItem(page)));
        }));
      IPage page1 = this.Items.FirstOrDefault<IPage>();
      if (page1 == null)
        return;
      page1.Action<IPage>((Action<IPage>) (i => this.ActivateItem(i)));
    }

    protected override void ChangeActiveItem(IPage newItem, bool closePrevious)
    {
      PageBase pageBase = (PageBase) newItem;
      if (pageBase != null)
      {
        IEventAggregator eventAggregator = this.EventAggregator;
        OpenedPageMsg message = new OpenedPageMsg((IUbVM) this);
        message.Page = newItem;
        message.DisplaySearchCount = pageBase.DisplaySearchCount;
        message.DisplayTitle = pageBase.MenuInfo.Name;
        string[] strArray = Array.Empty<string>();
        eventAggregator.PublishOnUIThread((object) message, strArray);
      }
      base.ChangeActiveItem(newItem, closePrevious);
    }

    public void Handle(AppWinMsg p_AppWinMsg)
    {
      if (!this.IsActive || this.ActiveItem == null)
        return;
      ((PageBase) this.ActiveItem).OnReceiveAppWinMessageAsync(p_AppWinMsg);
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

    public void Handle(MenuBookMarkSelectedMsg message)
    {
      IPage page = this.Items.Where<IPage>((Func<IPage, bool>) (x => x.MenuInfo.Code == message.Lv4MenuBookMarkCode)).FirstOrDefault<IPage>();
      if (page == null)
        return;
      this.ActivateItem(page);
    }
  }
}
