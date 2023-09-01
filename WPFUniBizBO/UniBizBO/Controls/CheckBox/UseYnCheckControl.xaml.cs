// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.CheckBox.UseYnCheckControl
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

namespace UniBizBO.Controls.CheckBox
{
  public partial class UseYnCheckControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty UseYnProperty = DependencyProperty.Register(nameof (UseYn), typeof (bool?), typeof (UseYnCheckControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (PropertyChangedCallback) null, new CoerceValueCallback(UseYnCheckControl.UseYnCoerce)));
    public static readonly DependencyProperty IsThreeStateProperty = DependencyProperty.Register(nameof (IsThreeState), typeof (bool), typeof (UseYnCheckControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(UseYnCheckControl.IsThreeStateChanged)));
    internal UseYnCheckControl root;
    private bool _contentLoaded;

    public UseYnCheckControl() => this.InitializeComponent();

    public bool? UseYn
    {
      get => (bool?) this.GetValue(UseYnCheckControl.UseYnProperty);
      set => this.SetValue(UseYnCheckControl.UseYnProperty, (object) value);
    }

    private static object UseYnCoerce(DependencyObject s, object e) => !(s as UseYnCheckControl).IsThreeState && e == null ? (object) false : e;

    public bool IsThreeState
    {
      get => (bool) this.GetValue(UseYnCheckControl.IsThreeStateProperty);
      set
      {
        this.SetValue(UseYnCheckControl.IsThreeStateProperty, (object) value);
        this.CoerceValue(UseYnCheckControl.UseYnProperty);
      }
    }

    private static void IsThreeStateChanged(
      DependencyObject s,
      DependencyPropertyChangedEventArgs e)
    {
      s.CoerceValue(UseYnCheckControl.UseYnProperty);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/checkbox/useyncheckcontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (UseYnCheckControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
