﻿// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Page.UniSales.Systems.Program.CommonCode.CommonCodeListPageV
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
using UniBizBO.Controls.ComboBox;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Views.V0.Page.UniSales.Systems.Program.CommonCode
{
  public partial class CommonCodeListPageV : UserControl, IComponentConnector
  {
    internal CommonCodeListPageV root;
    internal UseYnComboControl Use;
    internal System.Windows.Controls.ComboBox CommonType;
    internal TextBox ctr_tb_keyword;
    internal UniDataGrid Datas;
    private bool _contentLoaded;

    public CommonCodeListPageV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/page/unisales/systems/program/commoncode/commoncodelistpagev.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.root = (CommonCodeListPageV) target;
          break;
        case 2:
          this.Use = (UseYnComboControl) target;
          break;
        case 3:
          this.CommonType = (System.Windows.Controls.ComboBox) target;
          break;
        case 4:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 5:
          this.Datas = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
