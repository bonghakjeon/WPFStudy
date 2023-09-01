// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.PartModifyInfoControl
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
  public partial class PartModifyInfoControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty CreateTimeProperty = DependencyProperty.Register(nameof (CreateTime), typeof (DateTime), typeof (PartModifyInfoControl), new PropertyMetadata((object) DateTime.MinValue));
    public static readonly DependencyProperty ModifyTimeProperty = DependencyProperty.Register(nameof (ModifyTime), typeof (DateTime), typeof (PartModifyInfoControl), new PropertyMetadata((object) DateTime.MinValue));
    public static readonly DependencyProperty CreateNameProperty = DependencyProperty.Register(nameof (CreateName), typeof (string), typeof (PartModifyInfoControl), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty ModifyNameProperty = DependencyProperty.Register(nameof (ModifyName), typeof (string), typeof (PartModifyInfoControl), new PropertyMetadata((PropertyChangedCallback) null));
    internal PartModifyInfoControl root;
    private bool _contentLoaded;

    public PartModifyInfoControl() => this.InitializeComponent();

    public DateTime CreateTime
    {
      get => (DateTime) this.GetValue(PartModifyInfoControl.CreateTimeProperty);
      set => this.SetValue(PartModifyInfoControl.CreateTimeProperty, (object) value);
    }

    public DateTime ModifyTime
    {
      get => (DateTime) this.GetValue(PartModifyInfoControl.ModifyTimeProperty);
      set => this.SetValue(PartModifyInfoControl.ModifyTimeProperty, (object) value);
    }

    public string CreateName
    {
      get => (string) this.GetValue(PartModifyInfoControl.CreateNameProperty);
      set => this.SetValue(PartModifyInfoControl.CreateNameProperty, (object) value);
    }

    public string ModifyName
    {
      get => (string) this.GetValue(PartModifyInfoControl.ModifyNameProperty);
      set => this.SetValue(PartModifyInfoControl.ModifyNameProperty, (object) value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/partmodifyinfocontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (PartModifyInfoControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
