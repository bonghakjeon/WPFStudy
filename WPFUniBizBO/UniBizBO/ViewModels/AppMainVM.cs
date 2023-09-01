// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.AppMainVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using ModernWpf.Controls;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBizBO.Composition;
using UniBizBO.Config;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Board;
using UniBizBO.ViewModels.Board.Setting;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Page;
using UniBizBO.ViewModels.Page.Parents;
using UniBizBO.ViewModels.Tool;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels
{
  public class AppMainVM : UbScreen, IHandle<
  #nullable disable
  OpenPageMsg>, IHandle, IHandle<OpenedPageMsg>
  {
    private bool isProcessingLogout;
    private string _DisplayTitle = nameof (DisplayTitle);
    private string _DisplaySearchCountDesc = string.Empty;
    private string _ProgVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
    private bool isFirstOpen;
    private PageMenuInfo _SelectedLv1Menu;
    private bool _IsPaneOpen = true;

    public string DisplayTitle
    {
      get => this._DisplayTitle;
      set
      {
        this._DisplayTitle = value;
        this.NotifyOfPropertyChange(nameof (DisplayTitle));
      }
    }

    public string DisplaySearchCountDesc
    {
      get => this._DisplaySearchCountDesc;
      set
      {
        this._DisplaySearchCountDesc = value;
        this.NotifyOfPropertyChange(nameof (DisplaySearchCountDesc));
      }
    }

    [Inject]
    public MenuBookMarkToolVM MenuBookMarkToolVm { get; set; }

    public IPageContainer PageContainer { get; set; }

    public string ProgVersion
    {
      get => this._ProgVersion;
      set
      {
        this._ProgVersion = value;
        this.NotifyOfPropertyChange(nameof (ProgVersion));
      }
    }

    public AppMainVM(IContainer container)
      : base(container)
    {
      this.PageContainer = (IPageContainer) this.Container.Get<TabPageContainerVM>();
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      if (this.PageContainer is IScreenState pageContainer)
        pageContainer.ActivateWith((IScreenState) this);
      this.SystemInitProcess();
      this.EventAggregator.Subscribe((IHandle) this);
      this.OnInitialActivate_Menu();
    }

    protected override void OnClose()
    {
      base.OnClose();
      this.EventAggregator.Unsubscribe((IHandle) this);
    }

    public WpfCommand CmdOpenLogin
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.OpenLogin());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdOpenLogin));
      }
    }

    public void OpenLogin()
    {
      if (!this.Container.Get<LoginBoardVM>().ToShowData().IsLogin)
        return;
      this.isFirstOpen = true;
    }

    public WpfCommand CmdLogout
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.Logout());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdLogout));
      }
    }

    public async void Logout()
    {
      AppMainVM appMainVm = this;
      try
      {
        appMainVm.isProcessingLogout = true;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (appMainVm.Job).CreateJob("로그아웃", (string) null))
        {
          // ISSUE: explicit non-virtual call
          LoginBoardVM viewModel = __nonvirtual (appMainVm.Container).Get<LoginBoardVM>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (appMainVm.WindowManager).ShowWindow((object) viewModel);
          appMainVm.RequestClose(new bool?());
          appMainVm.isProcessingLogout = false;
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (appMainVm.Container)).Set("로그아웃 실패", ex.Message).ShowDialog();
        await Task.Yield();
      }
    }

    protected void SystemPageInitProcess()
    {
      this.App.User.DebugPageMenus = new List<PageMenuInfo>();
      List<PageMenuInfo> debugPageMenus = this.App.User.DebugPageMenus;
      foreach (Type type in this.App.ClazzFinder.GetList<ISystemPage>())
      {
        SystemPageAttribute attribute = type.GetAttribute<SystemPageAttribute>();
        if (attribute != null)
        {
          string lv1Name = attribute?.Lv1Name;
          if (!lv1Name.Equals("디버그"))
          {
            string lv2Name = attribute?.Lv2Name;
            string lv3Name = attribute?.Lv3Name;
            string lv4Name = attribute?.Lv4Name;
            PageMenuInfo pageMenuInfo1 = debugPageMenus.FirstOrDefault<PageMenuInfo>((Func<PageMenuInfo, bool>) (it => it.Name.Equals(lv1Name)));
            if (pageMenuInfo1 == null)
            {
              PageMenuInfo pageMenuInfo2 = new PageMenuInfo();
              pageMenuInfo2.Name = lv1Name;
              pageMenuInfo2.Title = lv1Name;
              pageMenuInfo1 = pageMenuInfo2;
              debugPageMenus.Add(pageMenuInfo1);
            }
            PageMenuInfo pageMenuInfo3 = pageMenuInfo1.Children.FirstOrDefault<PageMenuInfo>((Func<PageMenuInfo, bool>) (it => it.Name.Equals(lv2Name)));
            if (pageMenuInfo3 == null)
            {
              PageMenuInfo pageMenuInfo4 = new PageMenuInfo();
              pageMenuInfo4.Name = lv2Name;
              pageMenuInfo4.Title = lv2Name;
              pageMenuInfo3 = pageMenuInfo4;
              pageMenuInfo1.Children.Add(pageMenuInfo3);
            }
            PageMenuInfo pageMenuInfo5 = pageMenuInfo3.Children.FirstOrDefault<PageMenuInfo>((Func<PageMenuInfo, bool>) (it => it.Name.Equals(lv3Name)));
            if (pageMenuInfo5 == null)
            {
              PageMenuInfo pageMenuInfo6 = new PageMenuInfo();
              pageMenuInfo6.Name = lv3Name;
              pageMenuInfo6.Title = lv3Name;
              pageMenuInfo6.ClazzName = typeof (TabParentPageVM).FullName;
              pageMenuInfo5 = pageMenuInfo6;
              pageMenuInfo3.Children.Add(pageMenuInfo5);
            }
            if (pageMenuInfo5.Children.FirstOrDefault<PageMenuInfo>((Func<PageMenuInfo, bool>) (it => it.Name.Equals(lv4Name))) == null)
            {
              PageMenuInfo pageMenuInfo7 = new PageMenuInfo();
              pageMenuInfo7.Name = lv4Name;
              pageMenuInfo7.Title = lv4Name;
              pageMenuInfo7.ClazzName = type.FullName;
              PageMenuInfo pageMenuInfo8 = pageMenuInfo7;
              pageMenuInfo5.Children.Add(pageMenuInfo8);
            }
          }
        }
      }
    }

    protected void SystemPartInitProcess()
    {
    }

    private void SystemInitProcess()
    {
      this.SystemPageInitProcess();
      this.App.User.RefreshMenu();
    }

    public void Handle(OpenPageMsg message)
    {
      int num = 10;
      IPage page = ((IEnumerable<IPage>) this.PageContainer.Items.Where<IPage>((Func<IPage, bool>) (it => it.MenuInfo.Code == message.Page.MenuInfo.Code)).ToArray<IPage>()).FirstOrDefault<IPage>();
      if (page != null)
      {
        this.PageContainer.AddPage(page);
      }
      else
      {
        if (this.PageContainer.Items.Count > num)
          return;
        this.PageContainer.AddPage(message.Page);
      }
      if (!message.IsMenuBookMarkSelected)
        return;
      IEventAggregator eventAggregator = this.EventAggregator;
      MenuBookMarkSelectedMsg message1 = new MenuBookMarkSelectedMsg((IUbVM) this);
      message1.Lv4MenuBookMarkCode = message.Lv4MenuBookMarkCode;
      string[] strArray = Array.Empty<string>();
      eventAggregator.PublishOnUIThread((object) message1, strArray);
    }

    public void Handle(OpenedPageMsg message)
    {
      this.DisplayTitle = message.DisplayTitle + " UniBizBO";
      if (message.DisplaySearchCount > 0)
        this.DisplaySearchCountDesc = string.Format("{0}건 조회", (object) message.DisplaySearchCount);
      else
        this.DisplaySearchCountDesc = "";
    }

    [Inject]
    public BOConfig BOConfig { get; set; }

    public PageMenuInfo SelectedLv1Menu
    {
      get => this._SelectedLv1Menu;
      set => this.SetAndNotify<PageMenuInfo>(ref this._SelectedLv1Menu, value, nameof (SelectedLv1Menu));
    }

    public bool IsPaneOpen
    {
      get => this._IsPaneOpen;
      set
      {
        this._IsPaneOpen = value;
        this.NotifyOfPropertyChange(nameof (IsPaneOpen));
      }
    }

    private void OnInitialActivate_Menu() => this.SelectedLv1Menu = this.App.User.PageMenus.FirstOrDefault<PageMenuInfo>();

    public bool CanSelectMenu(PageMenuInfo menu) => menu.HasClazz;

    public void SelectMenu(PageMenuInfo menu)
    {
      Type implementType = menu.GetImplementType(this.App.ClazzFinder);
      if (implementType == (Type) null || !typeof (IParentPage).IsAssignableFrom(implementType))
        return;
      IParentPage parentPage = this.Container.Get<IParentPage>(implementType.FullName);
      parentPage.MenuInfo = menu;
      IEventAggregator eventAggregator = this.EventAggregator;
      OpenPageMsg message = new OpenPageMsg((IUbVM) this);
      message.Page = (IPage) parentPage;
      string[] strArray = Array.Empty<string>();
      eventAggregator.PublishOnUIThread((object) message, strArray);
    }

    public WpfCommand<PageMenuInfo> CmdSelectMenu => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<PageMenuInfo>>((Func<WpfCommand<PageMenuInfo>>) (() => new WpfCommand<PageMenuInfo>().ApplyExecute<PageMenuInfo>(new Action<PageMenuInfo>(this.SelectMenu))), nameof (CmdSelectMenu));

    public void SelectLeftMenu(NavigationView menu)
    {
      if (menu == null || !(menu.SelectedItem is PageMenuInfo selectedItem) || selectedItem.Level < 3)
        return;
      Type implementType = selectedItem.GetImplementType(this.App.ClazzFinder);
      if (implementType == (Type) null || !typeof (IParentPage).IsAssignableFrom(implementType))
        return;
      IParentPage parentPage = this.Container.Get<IParentPage>(implementType.FullName);
      parentPage.MenuInfo = selectedItem;
      IEventAggregator eventAggregator = this.EventAggregator;
      OpenPageMsg message = new OpenPageMsg((IUbVM) this);
      message.Page = (IPage) parentPage;
      string[] strArray = Array.Empty<string>();
      eventAggregator.PublishOnUIThread((object) message, strArray);
    }

    public WpfCommand<NavigationView> CmdSelectLeftMenu => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<NavigationView>>((Func<WpfCommand<NavigationView>>) (() => new WpfCommand<NavigationView>().ApplyExecute<NavigationView>(new Action<NavigationView>(this.SelectLeftMenu))), nameof (CmdSelectLeftMenu));

    public WpfCommand CmdMenuModeChange
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.MenuModeChange());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdMenuModeChange));
      }
    }

    public void MenuModeChange() => this.BOConfig.IsRibbonMenuUse = !this.BOConfig.IsRibbonMenuUse;

    public WpfCommand CmdOpenSettingBoard => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() => new WpfCommand().ApplyExecute(new Action(this.OpenSettingBoard))), nameof (CmdOpenSettingBoard));

    public void OpenSettingBoard() => this.Container.Get<SettingBoardVM>().ToShowData();

    public WpfCommand<NavigationView> CmdOpenPane => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<NavigationView>>((Func<WpfCommand<NavigationView>>) (() => new WpfCommand<NavigationView>().ApplyExecute<NavigationView>(new Action<NavigationView>(this.OpenPane))), nameof (CmdOpenPane));

    public void OpenPane(NavigationView menu) => this.IsPaneOpen = menu.IsPaneOpen;
  }
}
