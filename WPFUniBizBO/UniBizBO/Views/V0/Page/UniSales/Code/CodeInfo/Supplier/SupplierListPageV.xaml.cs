// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Page.UniSales.Code.CodeInfo.Supplier.SupplierListPageV
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

namespace UniBizBO.Views.V0.Page.UniSales.Code.CodeInfo.Supplier
{
  public partial class SupplierListPageV : UserControl, IComponentConnector
  {
    internal SupplierListPageV root;
    internal UseYnComboControl Use;
    internal System.Windows.Controls.ComboBox SupplierType;
    internal System.Windows.Controls.ComboBox SupplierKind;
    internal System.Windows.Controls.ComboBox StdPreTax;
    internal System.Windows.Controls.ComboBox SupplierMulti;
    internal TextBox ctr_tb_keyword;
    internal UniDataGrid Datas;
    private bool _contentLoaded;

    public SupplierListPageV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/page/unisales/code/codeinfo/supplier/supplierlistpagev.xaml", UriKind.Relative));
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
          this.root = (SupplierListPageV) target;
          break;
        case 2:
          this.Use = (UseYnComboControl) target;
          break;
        case 3:
          this.SupplierType = (System.Windows.Controls.ComboBox) target;
          break;
        case 4:
          this.SupplierKind = (System.Windows.Controls.ComboBox) target;
          break;
        case 5:
          this.StdPreTax = (System.Windows.Controls.ComboBox) target;
          break;
        case 6:
          this.SupplierMulti = (System.Windows.Controls.ComboBox) target;
          break;
        case 7:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 8:
          this.Datas = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
