// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Setting.SettingBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using GongSolutions.Wpf.DragDrop;
using ModernWpf.Controls;
using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBizBO.Common;
using UniBizBO.Config;
using UniBizBO.Services;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Board.Setting
{
  public class SettingBoardVM : UbScreen, IDropTarget
  {
    private NavigationViewPaneDisplayMode _LeftDisplayMode = NavigationViewPaneDisplayMode.LeftCompact;
    private bool _IsRibbonMenuUse = true;
    private 
    #nullable disable
    Theme _SelectedTheme;
    private BindableCollection<ProgMenuBookMarkView> _MenuBookMarkList = new BindableCollection<ProgMenuBookMarkView>();

    public IList<Tuple<string, NavigationViewPaneDisplayMode>> LeftDisplayModeSelects { get; } = (IList<Tuple<string, NavigationViewPaneDisplayMode>>) new List<Tuple<string, NavigationViewPaneDisplayMode>>()
    {
      new Tuple<string, NavigationViewPaneDisplayMode>("펼치기", NavigationViewPaneDisplayMode.Left),
      new Tuple<string, NavigationViewPaneDisplayMode>("줄이기", NavigationViewPaneDisplayMode.LeftCompact)
    };

    public IList<Tuple<string, bool>> DisplayModeSelects { get; } = (IList<Tuple<string, bool>>) new List<Tuple<string, bool>>()
    {
      new Tuple<string, bool>("좌측메뉴", true),
      new Tuple<string, bool>("상단메뉴", false)
    };

    public NavigationViewPaneDisplayMode LeftDisplayMode
    {
      get => this._LeftDisplayMode;
      set
      {
        this._LeftDisplayMode = value;
        this.NotifyOfPropertyChange(nameof (LeftDisplayMode));
      }
    }

    public bool IsRibbonMenuUse
    {
      get => this._IsRibbonMenuUse;
      set
      {
        this._IsRibbonMenuUse = value;
        this.NotifyOfPropertyChange(nameof (IsRibbonMenuUse));
      }
    }

    [Inject]
    public BOConfig BOConfig { get; set; }

    public BindableCollection<Theme> Themes { get; } = new BindableCollection<Theme>();

    public Theme SelectedTheme
    {
      get => this._SelectedTheme;
      set
      {
        if (this._SelectedTheme == value)
          return;
        this._SelectedTheme = value;
        this.SelectedTheme.LoadTheme(this._SelectedTheme.FileName);
        this.NotifyOfPropertyChange(nameof (SelectedTheme));
      }
    }

    public BindableCollection<ProgMenuBookMarkView> MenuBookMarkList
    {
      get => this._MenuBookMarkList;
      private set
      {
        this._MenuBookMarkList = value;
        this.NotifyOfPropertyChange(nameof (MenuBookMarkList));
      }
    }

    public SettingBoardVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.InitControl();
    }

    private void InitControl()
    {
      this.LeftDisplayMode = this.BOConfig.LeftDisplayMode;
      this.IsRibbonMenuUse = this.BOConfig.IsRibbonMenuUse;
      this.Themes.Clear();
      this.Themes.Add(new Theme()
      {
        Name = "Navy",
        FileName = "NavyTheme"
      });
      this.Themes.Add(new Theme()
      {
        Name = "Brown",
        FileName = "BrownTheme"
      });
      this.SelectedTheme = this.Themes.Where<Theme>((Func<Theme, bool>) (x => x.FileName.Equals(this.BOConfig.DefaultThemeName))).FirstOrDefault<Theme>();
      this.MenuBookMarkList.AddRange((IEnumerable<ProgMenuBookMarkView>) this.App.User.MenuBookMarkList.Select<ProgMenuBookMarkView, ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, ProgMenuBookMarkView>) (item => (ProgMenuBookMarkView) item.Clone())).ToList<ProgMenuBookMarkView>());
    }

    public SettingBoardVM ToShowData()
    {
      this.WindowManager.ShowDialog((object) this);
      return this;
    }

    public WpfCommand CmdSettingSave => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() => new WpfCommand().AutoRefreshOn<WpfCommand>().ApplyExecute(new Action(this.SettingSave))), nameof (CmdSettingSave));

    public void SettingSave()
    {
      try
      {
        Log.Logger.Information("환경설정 저장 시작");
        this.BOConfig.LeftDisplayMode = this.LeftDisplayMode;
        this.BOConfig.IsRibbonMenuUse = this.IsRibbonMenuUse;
        this.BOConfig.DefaultThemeName = this.SelectedTheme.FileName;
        File.WriteAllText(".\\BOConfig.json", this.BOConfig.ToJson<BOConfig>());
        Log.Logger.Information("환경설정 저장 종료");
      }
      catch (Exception ex)
      {
        Log.Logger.Error<string>("환경설정 저장 실패", ex.Message ?? "");
      }
    }

    public WpfCommand<ProgMenuBookMarkView> CmdDelete => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<ProgMenuBookMarkView>>((Func<WpfCommand<ProgMenuBookMarkView>>) (() => new WpfCommand<ProgMenuBookMarkView>().ApplyExecute<ProgMenuBookMarkView>(new Action<ProgMenuBookMarkView>(this.Delete))), nameof (CmdDelete));

    public void Delete(ProgMenuBookMarkView item) => item.db_status = 3;

    public WpfCommand CmdMenuBookMarkListSave => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() => new WpfCommand().AutoRefreshOn<WpfCommand>().ApplyExecute(new Action(this.MenuBookMarkListSave))), nameof (CmdMenuBookMarkListSave));

    public async void MenuBookMarkListSave()
    {
      SettingBoardVM sender = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob("즐겨찾기 저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          UbRes<IList<ProgMenuBookMarkView>> success = (await ProgMenuInfoRestServer.PostProgMenuBookMarkList(sender.LogInPackInfo.sendType, sender.LogInPackInfo.siteID, 0, 0, (IList<ProgMenuBookMarkView>) sender.MenuBookMarkList).ExecuteToReturnAsync<UbRes<IList<ProgMenuBookMarkView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<ProgMenuBookMarkView>>>();
          if (success.isSuccess)
          {
            // ISSUE: explicit non-virtual call
            __nonvirtual (sender.App).User.MenuBookMarkList.Clear();
            List<ProgMenuBookMarkView> list = sender.MenuBookMarkList.Where<ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, bool>) (item => item.db_status != 3)).ToList<ProgMenuBookMarkView>();
            sender.MenuBookMarkList.Clear();
            sender.MenuBookMarkList.AddRange((IEnumerable<ProgMenuBookMarkView>) list);
            // ISSUE: explicit non-virtual call
            __nonvirtual (sender.App).User.MenuBookMarkList.AddRange((IEnumerable<ProgMenuBookMarkView>) sender.MenuBookMarkList.Select<ProgMenuBookMarkView, ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, ProgMenuBookMarkView>) (item => (ProgMenuBookMarkView) item.Clone())).ToList<ProgMenuBookMarkView>());
            // ISSUE: explicit non-virtual call
            __nonvirtual (sender.EventAggregator).PublishOnUIThread((object) new MenuBookMarkChangeMsg((IUbVM) sender));
          }
          else
          {
            sender.MenuBookMarkList.Clear();
            // ISSUE: explicit non-virtual call
            sender.MenuBookMarkList.AddRange((IEnumerable<ProgMenuBookMarkView>) __nonvirtual (sender.App).User.MenuBookMarkList.Select<ProgMenuBookMarkView, ProgMenuBookMarkView>((Func<ProgMenuBookMarkView, ProgMenuBookMarkView>) (item => (ProgMenuBookMarkView) item.Clone())).ToList<ProgMenuBookMarkView>());
            throw new Exception(success.message);
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (sender.Container)).Set("즐겨찾기 저장 오류", ex.Message).ShowDialog();
      }
    }

    public void DragOver(IDropInfo dropInfo)
    {
      ProgMenuBookMarkView data = dropInfo.Data as ProgMenuBookMarkView;
      ProgMenuBookMarkView targetItem = dropInfo.TargetItem as ProgMenuBookMarkView;
      if (data == null || targetItem == null)
        return;
      dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
      dropInfo.Effects = DragDropEffects.Copy;
    }

    public void Drop(IDropInfo dropInfo)
    {
      ProgMenuBookMarkView data = dropInfo.Data as ProgMenuBookMarkView;
      ProgMenuBookMarkView targetItem = dropInfo.TargetItem as ProgMenuBookMarkView;
      int pmbmOrder = data.pmbm_Order;
      data.pmbm_Order = targetItem.pmbm_Order;
      targetItem.pmbm_Order = pmbmOrder;
      this.MenuBookMarkList.Move(this.MenuBookMarkList.IndexOf(data), this.MenuBookMarkList.IndexOf(targetItem));
    }
  }
}
