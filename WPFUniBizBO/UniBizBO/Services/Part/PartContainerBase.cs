// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.PartContainerBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBizBO.Composition;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Parent;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class PartContainerBase : UbConductorOne<
  #nullable disable
  IPart>, IPartContainer, IHaveWorkDataSet
  {
    private string _ContainerTitle = "등록정보";
    public string _ContentsDisplay = string.Empty;
    private WorkDataSet workData;
    private PartMenuInfo menuInfo;

    public PartContainerBase(IContainer container)
      : base(container)
    {
    }

    public string ContainerTitle
    {
      get => this._ContainerTitle;
      protected set
      {
        this._ContainerTitle = value;
        this.NotifyOfPropertyChange(nameof (ContainerTitle));
      }
    }

    public string ContentsDisplay
    {
      get => this._ContentsDisplay;
      set
      {
        this._ContentsDisplay = value;
        this.NotifyOfPropertyChange(nameof (ContentsDisplay));
      }
    }

    public WorkDataSet WorkData
    {
      get => this.workData;
      protected set
      {
        this.workData = value;
        this.NotifyOfPropertyChange(nameof (WorkData));
      }
    }

    public abstract TableCodeType TableCode { get; }

    public PartMenuInfo MenuInfo
    {
      get => this.menuInfo;
      protected set
      {
        this.menuInfo = value;
        this.NotifyOfPropertyChange(nameof (MenuInfo));
      }
    }

    public virtual bool IsManualSaveWorkData { get; set; }

    public virtual bool IsManualLoadWorkData { get; set; }

    public object[] WorkDataKeys { get; set; }

    public bool IsCreateMode
    {
      get => this.WorkDataKeys == null;
      set
      {
        if (!value)
          return;
        this.WorkDataKeys = (object[]) null;
      }
    }

    public virtual bool CanLoadWorkData() => true;

    public virtual bool CanSaveWorkData() => true;

    public virtual bool CanClearWorkData() => true;

    public abstract Task LoadWorkDataAsync();

    public abstract Task SaveWorkDataAsync();

    public abstract Task ClearWorkDataAsync();

    public virtual IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => (IReadOnlyDictionary<string, TableColumnInfo>) null;

    public virtual bool CanRollbackWorkData() => true;

    public virtual async Task RollbackWorkDataAsync()
    {
      this.WorkData?.RollBack();
      await Task.Yield();
    }

    public virtual bool CanConfirm() => true;

    public virtual async Task ConfirmAsync() => await Task.Yield();

    public virtual bool WinClose()
    {
      this.RequestClose(new bool?());
      return true;
    }

    public WpfCommand CmdSaveWorkData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSaveWorkData()),
        ExecuteAction = (Action<object>) (_ => await this.SaveWorkDataAsync())
      };
    }), nameof (CmdSaveWorkData));

    public WpfCommand CmdLoadWorkData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanLoadWorkData()),
        ExecuteAction = (Action<object>) (_ => await this.LoadWorkDataAsync())
      };
    }), nameof (CmdLoadWorkData));

    public WpfCommand CmdClearWorkData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanClearWorkData()),
        ExecuteAction = (Action<object>) (_ => await this.ClearWorkDataAsync())
      };
    }), nameof (CmdClearWorkData));

    public WpfCommand CmdRollbackWorkData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanRollbackWorkData()),
        ExecuteAction = (Action<object>) (_ => await this.RollbackWorkDataAsync())
      };
    }), nameof (CmdRollbackWorkData));

    public WpfCommand CmdConfirm => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanConfirm()),
        ExecuteAction = (Action<object>) (_ => await this.ConfirmAsync())
      };
    }), nameof (CmdConfirm));

    public WpfCommand CmdClose => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanCloseAsync().Result),
        ExecuteAction = (Action<object>) (_ => this.WinClose())
      };
    }), nameof (CmdClose));

    protected abstract Task OnLoadingWorkDataAsync();

    protected abstract Task OnSavingWorkDataAsync();

    protected abstract Task OnClearingWorkDataAsync();

    protected override async void OnInitialActivate()
    {
      PartContainerBase partContainerBase = this;
      // ISSUE: reference to a compiler-generated method
      partContainerBase.\u003C\u003En__0();
      try
      {
        partContainerBase.RefreshMenuInfo();
        // ISSUE: explicit non-virtual call
        __nonvirtual (partContainerBase.DataHeaders) = partContainerBase.OnQueryDataHeaders();
        await partContainerBase.LoadWorkDataAsync();
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        partContainerBase.RequestClose(new bool?());
      }
      partContainerBase.RefreshChildren();
    }

    protected List<PartMenuInfo> GetRelationParts() => this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == this.TableCode)).ToList<PartMenuInfo>();

    protected void RefreshMenuInfo() => this.MenuInfo = this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == this.TableCode)).FirstOrDefault<PartMenuInfo>();

    protected void RefreshChildren()
    {
      this.Items.Clear();
      this.GetRelationParts().ForEach((Action<PartMenuInfo>) (menu =>
      {
        IPart instance = menu.GetInstance<IPart>(this.App.ClazzFinder, this.Container);
        if (instance == null)
          return;
        instance.Action<IPart>((Action<IPart>) (part => this.ActivateItem(part)));
      }));
      if (this.Items.Count <= 0)
        return;
      this.ActiveItem = this.Items.FirstOrDefault<IPart>();
    }

    public void PartAppWinMessage(AppWinMsg p_AppWinMsg)
    {
      if (!this.IsActive || this.ActiveItem == null)
        return;
      ((TabParentPartVM) this.ActiveItem).PartAppWinMessage(p_AppWinMsg);
    }
  }
}
