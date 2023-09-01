// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Part.Main.Code.Store.PageStoreGroupMPartV
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

namespace UniBizBO.Views.V0.Part.Main.Code.Store
{
  public partial class PageStoreGroupMPartV : UserControl, IComponentConnector
  {
    internal UniDataGrid Datas;
    internal TextBox sgh_GroupName;
    internal ComboBox sgh_GroupType;
    internal TextBox sgh_SortNo;
    internal TextBox sgh_Memo;
    private bool _contentLoaded;

    public PageStoreGroupMPartV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/part/main/code/store/pagestoregroupmpartv.xaml", UriKind.Relative));
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
          this.Datas = (UniDataGrid) target;
          break;
        case 2:
          this.sgh_GroupName = (TextBox) target;
          break;
        case 3:
          this.sgh_GroupType = (ComboBox) target;
          break;
        case 4:
          this.sgh_SortNo = (TextBox) target;
          break;
        case 5:
          this.sgh_Memo = (TextBox) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
