// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.PartBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniBizBO.Composition;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class PartBase : 
    UbScreen,
    IPart,
    IHaveWorkDataSet,
    IDefaultFuncAbleVM<
    #nullable disable
    DefaultPartFunc>,
    IAppWinMsgEventArgs
  {
    private PartMenuInfo menuInfo;

    public PartMenuInfo MenuInfo
    {
      get => this.menuInfo;
      set => this.SetAndNotify<PartMenuInfo>(ref this.menuInfo, value, nameof (MenuInfo));
    }

    public IPartContainer PartContainer
    {
      get
      {
        if (this.Parent is IPartContainer parent1)
          return parent1;
        return !(this.Parent is IPart parent2) ? (IPartContainer) null : parent2.PartContainer;
      }
    }

    public WorkDataSet WorkData => !(this.Parent is IHaveWorkDataSet parent) ? (WorkDataSet) null : parent.WorkData;

    public PartBase(IContainer container)
      : base(container)
    {
    }

    public virtual IEnumerable<DefaultPartFunc> DefaultFuncs { get; set; }

    public virtual IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => (IReadOnlyDictionary<string, TableColumnInfo>) null;

    public virtual bool OnQueryCanDefaultFunc(DefaultPartFunc funcType) => true;

    public virtual void OnQueryDefaultFunc(DefaultPartFunc funcType)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DataHeaders = this.OnQueryDataHeaders();
    }

    public WpfCommand<object> CmdDefaultFunc => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<object>>((Func<WpfCommand<object>>) (() => new WpfCommand<object>().AutoRefreshOn<WpfCommand<object>>().ApplyCanExecute<object>((Func<object, bool>) (it =>
    {
      DefaultPartFunc funcType = (DefaultPartFunc) null;
      switch (it)
      {
        case string name2:
          funcType = new DefaultPartFunc(name2);
          break;
        case DefaultPartFunc defaultPartFunc2:
          funcType = defaultPartFunc2;
          break;
      }
      return this.OnQueryCanDefaultFunc(funcType);
    })).ApplyExecute<object>((Action<object>) (it =>
    {
      DefaultPartFunc funcType = (DefaultPartFunc) null;
      switch (it)
      {
        case string name4:
          funcType = new DefaultPartFunc(name4);
          break;
        case DefaultPartFunc defaultPartFunc4:
          funcType = defaultPartFunc4;
          break;
      }
      this.OnQueryDefaultFunc(funcType);
    }))), nameof (CmdDefaultFunc));

    public virtual async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param) => await Task.Yield();

    public event EventHandler<AppWinMsgEventArgs> AppWinMsgArgsRequested;

    public virtual void OnAppWinMsgArgsRequested(
      string propertyName,
      int propertyKeyNnumber = 0,
      int propertyMessage = 0,
      long propertyWParam = 0,
      long propertyLParam = 0)
    {
      EventHandler<AppWinMsgEventArgs> msgArgsRequested = this.AppWinMsgArgsRequested;
      if (msgArgsRequested == null)
        return;
      msgArgsRequested((object) this, new AppWinMsgEventArgs(propertyName, propertyKeyNnumber, propertyMessage, propertyWParam, propertyLParam));
    }
  }
}
