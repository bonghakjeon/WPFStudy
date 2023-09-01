// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.AppMainV
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using MahApps.Metro.Controls;
using ModernWpf.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace UniBizBO.Views.V0
{
  public partial class AppMainV : MetroWindow, IComponentConnector
  {
    internal AppMainV root;
    internal Grid rootContent;
    internal Border StatusBar;
    internal Border StartusSeparator;
    internal UniinfoNet.Windows.Wpf.SplitView SplitView;
    internal NavigationView NavView;
    private bool _contentLoaded;

    public AppMainV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/appmainv.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.root = (AppMainV) target;
          break;
        case 2:
          this.rootContent = (Grid) target;
          break;
        case 3:
          this.StatusBar = (Border) target;
          break;
        case 4:
          this.StartusSeparator = (Border) target;
          break;
        case 5:
          this.SplitView = (UniinfoNet.Windows.Wpf.SplitView) target;
          break;
        case 6:
          this.NavView = (NavigationView) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
