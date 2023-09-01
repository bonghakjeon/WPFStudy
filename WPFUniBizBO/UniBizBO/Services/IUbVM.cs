// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.IUbVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UniBizBO.Composition;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.DataView;
using UniinfoNet.Windows.Wpf.Job;

namespace UniBizBO.Services
{
  public interface IUbVM : 
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

    UbAppStatus App { get; }

    JobProgressManager Job { get; }

    CommandDictionary<NotifyCommand> Cmds { get; }

    IReadOnlyDictionary<string, TableColumnInfo> DataHeaders { get; set; }

    UniDataViewDescription DataView { get; set; }

    void OnUserAnyAction();

    bool IsManagedStatusLoaded { get; }

    void LoadManagedStatus();

    void SaveManagedStatus();

    void NotifyOfPropertyChange([CallerMemberName] string name = "");

    void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property);

    bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string propertyName = "");
  }
}
