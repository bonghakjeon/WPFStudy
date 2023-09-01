// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Page.UniSales.Sales.Supplier.Sales.CategoryPageV
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

namespace UniBizBO.Views.V0.Page.UniSales.Sales.Supplier.Sales
{
  public partial class CategoryPageV : UserControl, IComponentConnector
  {
    internal CategoryPageV root;
    internal DatePicker DtStart;
    internal DatePicker DtEnd;
    internal TextBox ctr_tb_keyword;
    internal CheckBox IsStoreTotal;
    internal CheckBox IsTax;
    internal CheckBox IsTaxFree;
    internal CheckBox IsSaleDirect;
    internal CheckBox IsSaleSpe;
    internal CheckBox IsSaleLea;
    internal CheckBox IsStockUnitAmount;
    internal CheckBox IsStockUnitQty;
    internal CheckBox IsStockUnitWeight;
    internal UniDataGrid Datas;
    private bool _contentLoaded;

    public CategoryPageV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/page/unisales/sales/supplier/sales/categorypagev.xaml", UriKind.Relative));
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
          this.root = (CategoryPageV) target;
          break;
        case 2:
          this.DtStart = (DatePicker) target;
          break;
        case 3:
          this.DtEnd = (DatePicker) target;
          break;
        case 4:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 5:
          this.IsStoreTotal = (CheckBox) target;
          break;
        case 6:
          this.IsTax = (CheckBox) target;
          break;
        case 7:
          this.IsTaxFree = (CheckBox) target;
          break;
        case 8:
          this.IsSaleDirect = (CheckBox) target;
          break;
        case 9:
          this.IsSaleSpe = (CheckBox) target;
          break;
        case 10:
          this.IsSaleLea = (CheckBox) target;
          break;
        case 11:
          this.IsStockUnitAmount = (CheckBox) target;
          break;
        case 12:
          this.IsStockUnitQty = (CheckBox) target;
          break;
        case 13:
          this.IsStockUnitWeight = (CheckBox) target;
          break;
        case 14:
          this.Datas = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
