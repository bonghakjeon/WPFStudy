// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.StoreStdCommonControl
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class StoreStdCommonControl : CommonControlBase, IComponentConnector
  {
    internal 
    #nullable disable
    StoreStdCommonControl root;
    private bool _contentLoaded;

    public StoreStdCommonControl() => this.InitializeComponent();

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      StoreCommonBoardVM vm = this.Container.Get<StoreCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.BeforeDatas = new Dictionary<int, StoreInfoView>();
      if (this.SelectedDataBackup != null)
        vm.BeforeDatas.Add(this.SelectedDataBackup is StoreInfoView selectedDataBackup ? selectedDataBackup.si_StoreCode : 0, this.SelectedDataBackup as StoreInfoView);
      else if (this.SelectedData != null)
        vm.BeforeDatas.Add(this.SelectedData is StoreInfoView selectedData ? selectedData.si_StoreCode : 0, this.SelectedData as StoreInfoView);
      vm.Confirmed += new EventHandler<CommonBoardBase<StoreInfoView>>(this.Vm_Confirmed);
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
        return !(this.SelectedData is StoreInfoView selectedData) ? (string) null : selectedData.si_StoreName;
      }
      if (this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (StoreInfoView storeInfoView in selectedDatas2 != null ? selectedDatas2.OfType<StoreInfoView>() : (IEnumerable<StoreInfoView>) null)
        stringBuilder.Append(storeInfoView.si_StoreName).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void Vm_Confirmed(object sender, CommonBoardBase<StoreInfoView> e)
    {
      if (e == null)
        return;
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.si_StoreCode;
      this.SelectedName = e.SelectedData.si_StoreName;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (StoreInfoView selectedData in (Collection<StoreInfoView>) e.SelectedDatas)
      {
        stringBuilder1.Append(selectedData.si_StoreCode).Append(",");
        stringBuilder2.Append(selectedData.si_StoreName).Append(",");
      }
      if (stringBuilder1.Length > 1)
        --stringBuilder1.Length;
      this.SelectedCodeIn = stringBuilder1.ToString();
      if (stringBuilder2.Length > 1)
        --stringBuilder2.Length;
      this.SelectedNameIn = stringBuilder2.ToString();
      string keyword = e is StoreCommonBoardVM storeCommonBoardVm ? storeCommonBoardVm.Param.Keyword : (string) null;
      if (keyword == null || keyword.Length <= 0)
        return;
      this.Keyword = keyword ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      StoreStdCommonControl stdCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await stdCommonControl.\u003C\u003En__0();
      JobProgressState j = stdCommonControl.Job?.CreateJob("지점 찾기", (string) null);
      try
      {
        string keyword = stdCommonControl.Keyword;
        StoreCommonBoardVM vm = stdCommonControl.Container.Get<StoreCommonBoardVM>();
        vm.IsMultiSelectMode = stdCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          StoreInfoView storeInfoView = vm.Datas.First<StoreInfoView>();
          stdCommonControl.SelectedData = (object) storeInfoView;
          stdCommonControl.SelectedCode = storeInfoView.si_StoreCode;
          stdCommonControl.SelectedName = storeInfoView.si_StoreName;
          stdCommonControl.SelectedCodeIn = storeInfoView.si_StoreCode.ToString();
          stdCommonControl.SelectedNameIn = storeInfoView.si_StoreName;
          j = (JobProgressState) null;
          vm = (StoreCommonBoardVM) null;
        }
        else
        {
          vm.Confirmed += new EventHandler<CommonBoardBase<StoreInfoView>>(stdCommonControl.Vm_Confirmed);
          stdCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (StoreCommonBoardVM) null;
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
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/storestdcommoncontrol.xaml", UriKind.Relative));
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
        this.root = (StoreStdCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
