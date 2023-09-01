// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.SupplierCommonControl
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class SupplierCommonControl : CommonControlBase, IComponentConnector
  {
    internal 
    #nullable disable
    SupplierCommonControl root;
    private bool _contentLoaded;

    public SupplierCommonControl() => this.InitializeComponent();

    protected override string OnQueryGetDisplayText(string before)
    {
      if (!this.IsUse)
        return (string) null;
      if (!this.IsMultiSelect)
      {
        if (this.SelectedCode > 0)
          return this.SelectedName;
        return !(this.SelectedData is SupplierView selectedData) ? (string) null : selectedData.su_SupplierName;
      }
      if (this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (SupplierView supplierView in selectedDatas2 != null ? selectedDatas2.OfType<SupplierView>() : (IEnumerable<SupplierView>) null)
        stringBuilder.Append(supplierView.su_SupplierName).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void LogBeforeOpenSelectBoard()
    {
      if (this.SearchContion == null || !this.SearchContion.ContainsKey((object) "name") || this.SearchContion[(object) "name"].ToString().Length <= 0)
        return;
      Log.Error("------------------------------------------------------------------------------------------------------");
      Log.Error(string.Format("SupplierCommonControl SearchContion.name =  {0} .", this.SearchContion[(object) "name"]));
      Log.Error("------------------------------------------------------------------------------------------------------");
    }

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      this.LogBeforeOpenSelectBoard();
      SupplierCommonBoardVM vm = this.Container.Get<SupplierCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.SearchContion = this.SearchContion;
      vm.Confirmed += new EventHandler<CommonBoardBase<SupplierView>>(this.Vm_Confirmed);
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

    private void Vm_Confirmed(object sender, CommonBoardBase<SupplierView> e)
    {
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.su_Supplier;
      this.SelectedName = e.SelectedData.su_SupplierName;
      this.SelectedCodeIn = e.SelectedDatas.Select<SupplierView, int>((Func<SupplierView, int>) (it => it.su_Supplier)).ToStringWithSeparator();
      this.SelectedNameIn = e.SelectedDatas.Select<SupplierView, string>((Func<SupplierView, string>) (it => it.su_SupplierName)).ToStringWithSeparator();
      this.Keyword = (e is SupplierCommonBoardVM supplierCommonBoardVm ? supplierCommonBoardVm.Param.Keyword : (string) null) ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      SupplierCommonControl supplierCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await supplierCommonControl.\u003C\u003En__0();
      JobProgressState j = supplierCommonControl.Job?.CreateJob("업체 찾기", (string) null);
      try
      {
        string keyword = supplierCommonControl.Keyword;
        SupplierCommonBoardVM vm = supplierCommonControl.Container.Get<SupplierCommonBoardVM>();
        vm.InitControl();
        vm.IsMultiSelectMode = supplierCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          SupplierView supplierView = vm.Datas.First<SupplierView>();
          supplierCommonControl.SelectedData = (object) supplierView;
          supplierCommonControl.SelectedCode = supplierView.su_Supplier;
          supplierCommonControl.SelectedName = supplierView.su_SupplierName;
          supplierCommonControl.SelectedCodeIn = supplierView.su_Supplier.ToString();
          supplierCommonControl.SelectedNameIn = supplierView.su_SupplierName;
          j = (JobProgressState) null;
          vm = (SupplierCommonBoardVM) null;
        }
        else
        {
          supplierCommonControl.LogBeforeOpenSelectBoard();
          vm.SearchContion = supplierCommonControl.SearchContion;
          vm.Confirmed += new EventHandler<CommonBoardBase<SupplierView>>(supplierCommonControl.Vm_Confirmed);
          supplierCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (SupplierCommonBoardVM) null;
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
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/suppliercommoncontrol.xaml", UriKind.Relative));
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
        this.root = (SupplierCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
