// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Part.Main.Code.Supplier.PagePayContionMPartV
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

namespace UniBizBO.Views.V0.Part.Main.Code.Supplier
{
  public partial class PagePayContionMPartV : UserControl, IComponentConnector
  {
    internal UniDataGrid DeductionAutoTypeDatas;
    internal UniDataGrid SupplierAutoDeductionDatas;
    internal UniDataGrid SupplierHistoryDatas;
    private bool _contentLoaded;

    public PagePayContionMPartV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/part/main/code/supplier/pagepaycontionmpartv.xaml", UriKind.Relative));
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
          this.DeductionAutoTypeDatas = (UniDataGrid) target;
          break;
        case 2:
          this.SupplierAutoDeductionDatas = (UniDataGrid) target;
          break;
        case 3:
          this.SupplierHistoryDatas = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
