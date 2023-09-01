// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Board.Common.DeptCommonBoardV
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
  public partial class DeptCommonBoardV : MetroWindow, IComponentConnector
  {
    internal UseYnComboControl ctr_cb_UseYn;
    internal TextBox ctr_tb_keyword;
    internal System.Windows.Controls.ComboBox DptDepth;
    internal DatePicker DtDate;
    internal UniDataGrid Datas;
    internal UseYnComboControl ctr_cb_UseYn_1;
    internal TextBox ctr_tb_keyword_1;
    internal UniDataGrid ctr_grid_lv1;
    internal UniDataGrid ctr_grid_lv2;
    internal UniDataGrid ctr_grid_lv3;
    private bool _contentLoaded;

    public DeptCommonBoardV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/board/common/deptcommonboardv.xaml", UriKind.Relative));
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
          this.ctr_cb_UseYn = (UseYnComboControl) target;
          break;
        case 2:
          this.ctr_tb_keyword = (TextBox) target;
          break;
        case 3:
          this.DptDepth = (System.Windows.Controls.ComboBox) target;
          break;
        case 4:
          this.DtDate = (DatePicker) target;
          break;
        case 5:
          this.Datas = (UniDataGrid) target;
          break;
        case 6:
          this.ctr_cb_UseYn_1 = (UseYnComboControl) target;
          break;
        case 7:
          this.ctr_tb_keyword_1 = (TextBox) target;
          break;
        case 8:
          this.ctr_grid_lv1 = (UniDataGrid) target;
          break;
        case 9:
          this.ctr_grid_lv2 = (UniDataGrid) target;
          break;
        case 10:
          this.ctr_grid_lv3 = (UniDataGrid) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
