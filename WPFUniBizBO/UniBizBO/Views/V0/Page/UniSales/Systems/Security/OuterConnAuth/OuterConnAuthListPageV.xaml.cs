// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Page.UniSales.Systems.Security.OuterConnAuth.OuterConnAuthListPageV
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
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Views.V0.Page.UniSales.Systems.Security.OuterConnAuth
{
  public partial class OuterConnAuthListPageV : UserControl, IComponentConnector
  {
    internal OuterConnAuthListPageV root;
    internal ComboBox DevicePermit;
    internal ComboBox AppType;
    internal TextBox ctr_tb_keyword;
    internal TreeView GroupView;
    internal UniDataGrid Datas;
    private bool _contentLoaded;

    public OuterConnAuthListPageV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/page/unisales/systems/security/outerconnauth/outerconnauthlistpagev.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.root = (OuterConnAuthListPageV) target;
          break;
        case 2:
          this.DevicePermit = (ComboBox) target;
          break;
        case 3:
          this.AppType = (ComboBox) target;
          break;
        case 4:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 5:
          this.GroupView = (TreeView) target;
          break;
        case 6:
          this.Datas = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
