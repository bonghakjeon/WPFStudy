// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.ComboBox.CommonCodeComboControl
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
using UniBizBO.Composition;

namespace UniBizBO.Controls.ComboBox
{
  public partial class CommonCodeComboControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty SelectedDataProperty = DependencyProperty.Register(nameof (SelectedData), typeof (CommonCode), typeof (CommonCodeComboControl), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty SelectItemsProperty = DependencyProperty.Register(nameof (SelectItems), typeof (IList<CommonCode>), typeof (CommonCodeComboControl), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty SelectedCodeProperty = DependencyProperty.Register(nameof (SelectedCode), typeof (int?), typeof (CommonCodeComboControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) 0));
    internal CommonCodeComboControl root;
    private bool _contentLoaded;

    public CommonCodeComboControl() => this.InitializeComponent();

    public CommonCode SelectedData
    {
      get => (CommonCode) this.GetValue(CommonCodeComboControl.SelectedDataProperty);
      set => this.SetValue(CommonCodeComboControl.SelectedDataProperty, (object) value);
    }

    public IList<CommonCode> SelectItems
    {
      get => (IList<CommonCode>) this.GetValue(CommonCodeComboControl.SelectItemsProperty);
      set => this.SetValue(CommonCodeComboControl.SelectItemsProperty, (object) value);
    }

    public int? SelectedCode
    {
      get => new int?((int) this.GetValue(CommonCodeComboControl.SelectedCodeProperty));
      set => this.SetValue(CommonCodeComboControl.SelectedCodeProperty, (object) value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/combobox/commoncodecombocontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (CommonCodeComboControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
