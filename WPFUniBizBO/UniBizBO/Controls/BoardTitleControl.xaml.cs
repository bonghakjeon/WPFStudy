﻿// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.BoardTitleControl
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

namespace UniBizBO.Controls
{
  public partial class BoardTitleControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (BoardTitleControl), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty ExplainContentProperty = DependencyProperty.Register(nameof (ExplainContent), typeof (object), typeof (BoardTitleControl), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty CommandContentProperty = DependencyProperty.Register(nameof (CommandContent), typeof (object), typeof (BoardTitleControl), new PropertyMetadata((PropertyChangedCallback) null));
    internal BoardTitleControl root;
    private bool _contentLoaded;

    public BoardTitleControl() => this.InitializeComponent();

    public string Title
    {
      get => (string) this.GetValue(BoardTitleControl.TitleProperty);
      set => this.SetValue(BoardTitleControl.TitleProperty, (object) value);
    }

    public object ExplainContent
    {
      get => this.GetValue(BoardTitleControl.ExplainContentProperty);
      set => this.SetValue(BoardTitleControl.ExplainContentProperty, value);
    }

    public object CommandContent
    {
      get => this.GetValue(BoardTitleControl.CommandContentProperty);
      set => this.SetValue(BoardTitleControl.CommandContentProperty, value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/boardtitlecontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (BoardTitleControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
