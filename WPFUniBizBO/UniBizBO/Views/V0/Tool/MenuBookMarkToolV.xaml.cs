// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Tool.MenuBookMarkToolV
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using UniBizBO.Behaviors;

namespace UniBizBO.Views.V0.Tool
{
  public partial class MenuBookMarkToolV : UserControl, IComponentConnector
  {
    internal Border BottomSeparator;
    internal TextBlock Title;
    internal Border CenterSeparator;
    internal ScrollViewerControllerBehavior _behavior_Favorite;
    internal ItemsControl bookMarkItemsControl;
    private bool _contentLoaded;

    public MenuBookMarkToolV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/tool/menubookmarktoolv.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.BottomSeparator = (Border) target;
          break;
        case 2:
          this.Title = (TextBlock) target;
          break;
        case 3:
          this.CenterSeparator = (Border) target;
          break;
        case 4:
          this._behavior_Favorite = (ScrollViewerControllerBehavior) target;
          break;
        case 5:
          this.bookMarkItemsControl = (ItemsControl) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
