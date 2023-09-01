// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.DeptCommonControl
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class DeptCommonControl : CommonControlBase, IComponentConnector
  {
    public static readonly 
    #nullable disable
    DependencyProperty SelectedDepthProperty = DependencyProperty.Register(nameof (SelectedDepth), typeof (int), typeof (DeptCommonControl), new PropertyMetadata((object) 0));
    internal DeptCommonControl root;
    private bool _contentLoaded;

    public DeptCommonControl() => this.InitializeComponent();

    public int SelectedDepth
    {
      get => (int) this.GetValue(DeptCommonControl.SelectedDepthProperty);
      set => this.SetValue(DeptCommonControl.SelectedDepthProperty, (object) value);
    }

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      DeptCommonBoardVM vm = this.Container.Get<DeptCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.SearchContion = this.SearchContion;
      vm.InitControl();
      vm.Confirmed += new EventHandler<CommonBoardBase<DeptView>>(this.Vm_Confirmed);
      vm.Activated += (EventHandler<ActivationEventArgs>) (async (s, e) =>
      {
        if (!e.IsInitialActivate)
          return;
        await Dispatcher.Yield((DispatcherPriority) 6);
        if (string.IsNullOrWhiteSpace(this.Keyword))
          return;
        vm.Param.Keyword = this.Keyword;
        await vm.SearchAsync();
      });
      this.Container.Get<IWindowManager>().ShowDialog((object) vm);
    }

    protected override string OnQueryGetDisplayText(string before)
    {
      if (!this.IsUse)
        return (string) null;
      if (!this.IsMultiSelect)
      {
        if (this.SelectedCode > 0)
          return this.SelectedName;
        return !(this.SelectedData is DeptView selectedData) ? (string) null : selectedData.dpt_DeptName;
      }
      if (this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (DeptView deptView in selectedDatas2 != null ? selectedDatas2.OfType<DeptView>() : (IEnumerable<DeptView>) null)
        stringBuilder.Append(deptView.dpt_DeptName).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void Vm_Confirmed(object sender, CommonBoardBase<DeptView> e)
    {
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.dpt_ID;
      this.SelectedName = e.SelectedData.dpt_DeptName;
      this.SelectedDepth = e.SelectedData.dpt_Depth;
      if (e is DeptCommonBoardVM deptCommonBoardVm1 && !deptCommonBoardVm1.IsDept)
      {
        this.SelectedDatas.Clear();
        this.SelectedDatas.Add((object) deptCommonBoardVm1.SelectedData);
        this.SelectedData = (object) deptCommonBoardVm1.SelectedData;
        this.SelectedCode = deptCommonBoardVm1.SelectedData.dpt_ID;
        this.SelectedName = deptCommonBoardVm1.SelectedData.dpt_DeptName;
        this.SelectedDepth = deptCommonBoardVm1.SelectedData.dpt_Depth;
      }
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (DeptView selectedData in (Collection<DeptView>) e.SelectedDatas)
      {
        stringBuilder1.Append(selectedData.dpt_ID).Append(",");
        stringBuilder2.Append(selectedData.dpt_DeptName).Append(",");
      }
      if (stringBuilder1.Length > 1)
        --stringBuilder1.Length;
      this.SelectedCodeIn = stringBuilder1.ToString();
      if (stringBuilder2.Length > 1)
        --stringBuilder2.Length;
      this.SelectedNameIn = stringBuilder2.ToString();
      string keyword = e is DeptCommonBoardVM deptCommonBoardVm2 ? deptCommonBoardVm2.Param.Keyword : (string) null;
      if (keyword == null || keyword.Length <= 0)
        return;
      this.Keyword = keyword ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      DeptCommonControl deptCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await deptCommonControl.\u003C\u003En__0();
      JobProgressState j = deptCommonControl.Job?.CreateJob("분류 찾기", (string) null);
      try
      {
        string keyword = deptCommonControl.Keyword;
        DeptCommonBoardVM vm = deptCommonControl.Container.Get<DeptCommonBoardVM>();
        vm.IsMultiSelectMode = deptCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          DeptView deptView = vm.Datas.First<DeptView>();
          deptCommonControl.SelectedData = (object) deptView;
          deptCommonControl.SelectedCode = deptView.dpt_ID;
          deptCommonControl.SelectedName = deptView.dpt_DeptName;
          deptCommonControl.SelectedDepth = deptView.dpt_Depth;
          deptCommonControl.SelectedCodeIn = deptView.dpt_ID.ToString();
          deptCommonControl.SelectedNameIn = deptView.dpt_DeptName;
          j = (JobProgressState) null;
          vm = (DeptCommonBoardVM) null;
        }
        else
        {
          vm.Confirmed += new EventHandler<CommonBoardBase<DeptView>>(deptCommonControl.Vm_Confirmed);
          deptCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (DeptCommonBoardVM) null;
        }
      }
      finally
      {
        j?.Dispose();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/deptcommoncontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.root = (DeptCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
