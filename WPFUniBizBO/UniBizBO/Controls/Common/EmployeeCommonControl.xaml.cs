// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.EmployeeCommonControl
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class EmployeeCommonControl : CommonControlBase, IComponentConnector
  {
    internal 
    #nullable disable
    EmployeeCommonControl root;
    private bool _contentLoaded;

    public EmployeeCommonControl() => this.InitializeComponent();

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      EmployeeCommonBoardVM vm = this.Container.Get<EmployeeCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.Confirmed += new EventHandler<CommonBoardBase<EmployeeView>>(this.Vm_Confirmed);
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
        return !(this.SelectedData is EmployeeView selectedData) ? (string) null : selectedData.emp_Name;
      }
      if (this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (EmployeeView employeeView in selectedDatas2 != null ? selectedDatas2.OfType<EmployeeView>() : (IEnumerable<EmployeeView>) null)
        stringBuilder.Append(employeeView.emp_Name).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void Vm_Confirmed(object sender, CommonBoardBase<EmployeeView> e)
    {
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.emp_Code;
      this.SelectedName = e.SelectedData.emp_Name;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (EmployeeView selectedData in (Collection<EmployeeView>) e.SelectedDatas)
      {
        stringBuilder1.Append(selectedData.emp_Code).Append(",");
        stringBuilder2.Append(selectedData.emp_Name).Append(",");
      }
      if (stringBuilder1.Length > 1)
        --stringBuilder1.Length;
      this.SelectedCodeIn = stringBuilder1.ToString();
      if (stringBuilder2.Length > 1)
        --stringBuilder2.Length;
      this.SelectedNameIn = stringBuilder2.ToString();
      this.Keyword = (e is EmployeeCommonBoardVM employeeCommonBoardVm ? employeeCommonBoardVm.Param.Keyword : (string) null) ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      EmployeeCommonControl employeeCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await employeeCommonControl.\u003C\u003En__0();
      JobProgressState j = employeeCommonControl.Job?.CreateJob("제조사 찾기", (string) null);
      try
      {
        string keyword = employeeCommonControl.Keyword;
        EmployeeCommonBoardVM vm = employeeCommonControl.Container.Get<EmployeeCommonBoardVM>();
        vm.IsMultiSelectMode = employeeCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          EmployeeView employeeView = vm.Datas.First<EmployeeView>();
          employeeCommonControl.SelectedData = (object) employeeView;
          employeeCommonControl.SelectedCode = employeeView.emp_Code;
          employeeCommonControl.SelectedName = employeeView.emp_Name;
          employeeCommonControl.SelectedCodeIn = employeeView.emp_Code.ToString();
          employeeCommonControl.SelectedNameIn = employeeView.emp_Name;
          j = (JobProgressState) null;
          vm = (EmployeeCommonBoardVM) null;
        }
        else
        {
          vm.Confirmed += new EventHandler<CommonBoardBase<EmployeeView>>(employeeCommonControl.Vm_Confirmed);
          employeeCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (EmployeeCommonBoardVM) null;
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
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/employeecommoncontrol.xaml", UriKind.Relative));
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
        this.root = (EmployeeCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
