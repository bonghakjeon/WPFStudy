// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Base.ICsVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;

namespace UniBizBO.ViewModels.Base
{
  public interface ICsVM : 
    IScreen,
    IViewAware,
    IHaveDisplayName,
    IScreenState,
    IChild,
    IGuardClose,
    IRequestClose
  {
    IContainer Container { get; set; }

    IWindowManager WindowManager { get; set; }

    IEventAggregator EventAggregator { get; set; }

    JobProgressManager Job { get; }

    CommandDictionary<NotifyCommand> Cmds { get; }

    void NotifyOfPropertyChange([CallerMemberName] string name = "");

    void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property);

    bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = "");

    void OnCommandManagerRequerySuggested(object sender, EventArgs e);
  }
}
