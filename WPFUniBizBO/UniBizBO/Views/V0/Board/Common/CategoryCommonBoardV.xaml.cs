// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Board.Common.CategoryCommonBoardV
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using MahApps.Metro.Controls;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using UniBizBO.Controls.ComboBox;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Views.V0.Board.Common
{
  public partial class CategoryCommonBoardV : MetroWindow, IComponentConnector
  {
    internal TextBox ctr_tb_keyword;
    internal DatePicker DtDate;
    internal UniDataGrid Datas;
    internal UseYnComboControl ctr_cb_UseYn1;
    internal TextBox ctr_tb_keyword1;
    internal UniDataGrid ctr_grid_lv1;
    internal UniDataGrid ctr_grid_lv2;
    internal UniDataGrid ctr_grid_lv3;
    internal UseYnComboControl ctr_cb_UseYn2;
    internal TreeView GroupView;
    private bool _contentLoaded;

    public CategoryCommonBoardV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/board/common/categorycommonboardv.xaml", UriKind.Relative));
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
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 2:
          this.DtDate = (DatePicker) target;
          break;
        case 3:
          this.Datas = (UniDataGrid) target;
          break;
        case 4:
          this.ctr_cb_UseYn1 = (UseYnComboControl) target;
          break;
        case 5:
          this.ctr_tb_keyword1 = (TextBox) target;
          break;
        case 6:
          this.ctr_grid_lv1 = (UniDataGrid) target;
          break;
        case 7:
          this.ctr_grid_lv2 = (UniDataGrid) target;
          break;
        case 8:
          this.ctr_grid_lv3 = (UniDataGrid) target;
          break;
        case 9:
          this.ctr_cb_UseYn2 = (UseYnComboControl) target;
          break;
        case 10:
          this.GroupView = (TreeView) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
