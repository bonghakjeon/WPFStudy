// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.ComboBox.UseYnComboControl
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace UniBizBO.Controls.ComboBox
{
  public partial class UseYnComboControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty UseYnProperty = DependencyProperty.Register(nameof (UseYn), typeof (bool?), typeof (UseYnComboControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    internal UseYnComboControl root;
    private bool _contentLoaded;

    public IReadOnlyDictionary<string, bool?> Items { get; } = (IReadOnlyDictionary<string, bool?>) new Dictionary<string, bool?>()
    {
      ["전체"] = new bool?(),
      ["사용"] = new bool?(true),
      ["미사용"] = new bool?(false)
    };

    public UseYnComboControl() => this.InitializeComponent();

    public bool? UseYn
    {
      get => (bool?) this.GetValue(UseYnComboControl.UseYnProperty);
      set => this.SetValue(UseYnComboControl.UseYnProperty, (object) value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/combobox/useyncombocontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (UseYnComboControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
