// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Page.UniSales.Code.CodeInfo.Category.CategoryDepthPageV
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

namespace UniBizBO.Views.V0.Page.UniSales.Code.CodeInfo.Category
{
  public partial class CategoryDepthPageV : UserControl, IComponentConnector
  {
    internal CategoryDepthPageV root;
    internal TextBox ctr_tb_keyword;
    internal UniDataGrid ctr_grid_lv1;
    internal UniDataGrid ctr_grid_lv2;
    internal UniDataGrid ctr_grid_lv3;
    private bool _contentLoaded;

    public CategoryDepthPageV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/page/unisales/code/codeinfo/category/categorydepthpagev.xaml", UriKind.Relative));
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
          this.root = (CategoryDepthPageV) target;
          break;
        case 2:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 3:
          this.ctr_grid_lv1 = (UniDataGrid) target;
          break;
        case 4:
          this.ctr_grid_lv2 = (UniDataGrid) target;
          break;
        case 5:
          this.ctr_grid_lv3 = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
