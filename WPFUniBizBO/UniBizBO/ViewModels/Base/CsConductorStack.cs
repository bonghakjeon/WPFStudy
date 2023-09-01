// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Base.CsConductorStack`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;

namespace UniBizBO.ViewModels.Base
{
  public class CsConductorStack<TItem> : 
    Conductor<TItem>.StackNavigation,
    ICsVM,
    IScreen,
    IViewAware,
    IHaveDisplayName,
    IScreenState,
    IChild,
    IGuardClose,
    IRequestClose
    where TItem : class
  {
    public IContainer Container { get; set; }

    [Inject]
    public IWindowManager WindowManager { get; set; }

    [Inject]
    public IEventAggregator EventAggregator { get; set; }

    public JobProgressManager Job { get; } = new JobProgressManager();

    public CommandDictionary<NotifyCommand> Cmds { get; } = new CommandDictionary<NotifyCommand>();

    public new void NotifyOfPropertyChange([CallerMemberName] string name = "") => base.NotifyOfPropertyChange(name);

    public new void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property) => base.NotifyOfPropertyChange<TProperty>(property);

    public new bool SetAndNotify<T>(ref T field, T value, string propertyName) => base.SetAndNotify<T>(ref field, value, propertyName);

    public CsConductorStack(IContainer container)
    {
      this.Container = container;
      this.Container?.BuildUp((object) this);
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      CommandManager.RequerySuggested += new EventHandler(this.OnCommandManagerRequerySuggested);
    }

    protected override void OnClose()
    {
      base.OnClose();
      CommandManager.RequerySuggested -= new EventHandler(this.OnCommandManagerRequerySuggested);
    }

    public virtual void OnCommandManagerRequerySuggested(object sender, EventArgs e)
    {
    }
  }
}
