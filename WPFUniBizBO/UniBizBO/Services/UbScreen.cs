// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.UbScreen
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBizBO.Composition;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;
using UniinfoNet.Windows.Wpf.Job;

namespace UniBizBO.Services
{
  [HiddenVm]
  public class UbScreen : 
    Screen,
    IUbVM,
    IScreen,
    IViewAware,
    IHaveDisplayName,
    IScreenState,
    IChild,
    IGuardClose,
    IRequestClose,
    IHandle
  {
    private IReadOnlyDictionary<string, TableColumnInfo> dataHeaders;
    private UniDataViewDescription dataView;

    public IContainer Container { get; set; }

    [Inject]
    public IWindowManager WindowManager { get; set; }

    [Inject]
    public IEventAggregator EventAggregator { get; set; }

    [Inject]
    public UbAppStatus App { get; set; }

    [Inject]
    public LogInPack LogInPackInfo { get; set; }

    public JobProgressManager Job { get; } = new JobProgressManager();

    public CommandDictionary<NotifyCommand> Cmds { get; } = new CommandDictionary<NotifyCommand>();

    public IReadOnlyDictionary<string, TableColumnInfo> DataHeaders
    {
      get => this.dataHeaders;
      set
      {
        this.SetAndNotify<IReadOnlyDictionary<string, TableColumnInfo>>(ref this.dataHeaders, value, nameof (DataHeaders));
        this.DataView.AddTableColumnInfos(value?.Values);
      }
    }

    [ManagedStatus("1bbb2475-f2b5-436f-9c8f-346805752a93")]
    public UniDataViewDescription DataView
    {
      get => this.dataView ?? (this.dataView = new UniDataViewDescription());
      set
      {
        this.dataView = value;
        this.NotifyOfPropertyChange(nameof (DataView));
      }
    }

    public new void NotifyOfPropertyChange([CallerMemberName] string name = "") => base.NotifyOfPropertyChange(name);

    public new void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property) => base.NotifyOfPropertyChange<TProperty>(property);

    public new bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = "") => base.SetAndNotify<T>(ref field, value, propertyName);

    public UbScreen(IContainer container)
    {
      this.Container = container;
      this.Container?.BuildUp((object) this);
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.EventAggregator.Subscribe((IHandle) this);
      CommandManager.RequerySuggested -= new EventHandler(this.CommandManager_RequerySuggested);
      CommandManager.RequerySuggested += new EventHandler(this.CommandManager_RequerySuggested);
      if (this.IsManagedStatusLoaded)
        return;
      this.LoadManagedStatus();
    }

    public bool IsManagedStatusLoaded { get; private set; }

    public void LoadManagedStatus()
    {
      this.App.Local.Status.LoadManagedStatus<UbScreen>(this);
      this.IsManagedStatusLoaded = true;
    }

    public void SaveManagedStatus() => this.App.Local.Status.SaveManagedStatus<UbScreen>(this);

    private void CommandManager_RequerySuggested(object sender, EventArgs e) => this.OnUserAnyAction();

    public virtual void OnUserAnyAction()
    {
    }

    protected override void OnClose()
    {
      base.OnClose();
      CommandManager.RequerySuggested -= new EventHandler(this.CommandManager_RequerySuggested);
      this.EventAggregator?.Unsubscribe((IHandle) this);
      this.SaveManagedStatus();
    }
  }
}
