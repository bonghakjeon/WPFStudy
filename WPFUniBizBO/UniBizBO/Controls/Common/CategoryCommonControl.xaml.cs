// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.CategoryCommonControl
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class CategoryCommonControl : CommonControlBase, IComponentConnector
  {
    public static readonly 
    #nullable disable
    DependencyProperty SelectedDepthProperty = DependencyProperty.Register(nameof (SelectedDepth), typeof (int), typeof (CategoryCommonControl), new PropertyMetadata((object) 0));
    public static readonly DependencyProperty SelectedCodeInLv1Property = DependencyProperty.Register(nameof (SelectedCodeInLv1), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty SelectedNameInLv1Property = DependencyProperty.Register(nameof (SelectedNameInLv1), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty SelectedCodeInLv2Property = DependencyProperty.Register(nameof (SelectedCodeInLv2), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty SelectedNameInLv2Property = DependencyProperty.Register(nameof (SelectedNameInLv2), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty SelectedCodeInLv3Property = DependencyProperty.Register(nameof (SelectedCodeInLv3), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    public static readonly DependencyProperty SelectedNameInLv3Property = DependencyProperty.Register(nameof (SelectedNameInLv3), typeof (string), typeof (CategoryCommonControl), new PropertyMetadata((object) string.Empty));
    internal CategoryCommonControl root;
    private bool _contentLoaded;

    public CategoryCommonControl() => this.InitializeComponent();

    public override bool IsUse
    {
      get
      {
        if (!this.IsMultiSelect)
          return this.SelectedData != null || this.SelectedCode > 0;
        IList selectedDatas = this.SelectedDatas;
        if ((selectedDatas != null ? selectedDatas.Count : 0) > 0 || this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
          return true;
        return this.SelectedNameIn != null && this.SelectedNameIn.Length > 0;
      }
      set
      {
        if (value)
        {
          this.SelectedData = this.SelectedDataBackup;
          this.SelectedDatas = this.SelectedDatasBackup;
          this.SelectedCode = this.SelectedCodeBackup;
          this.SelectedName = this.SelectedNameBackup;
          this.SelectedCodeIn = this.SelectedCodeInBackup;
          this.SelectedNameIn = this.SelectedNameInBackup;
          if (this.SelectedCodeInLv1Backup.Length > 0)
            this.SelectedCodeInLv1 = this.SelectedCodeInLv1Backup;
          if (this.SelectedNameInLv1Backup.Length > 0)
            this.SelectedNameInLv1 = this.SelectedNameInLv1Backup;
          if (this.SelectedCodeInLv2Backup.Length > 0)
            this.SelectedCodeInLv2 = this.SelectedCodeInLv2Backup;
          if (this.SelectedNameInLv2Backup.Length > 0)
            this.SelectedNameInLv2 = this.SelectedNameInLv2Backup;
          if (this.SelectedCodeInLv3Backup.Length > 0)
            this.SelectedCodeInLv3 = this.SelectedCodeInLv3Backup;
          if (this.SelectedNameInLv3Backup.Length > 0)
            this.SelectedNameInLv3 = this.SelectedNameInLv3Backup;
          if (this.IsEmptySelect)
            this.CmdOpenSelectBoard.Execute((object) null);
        }
        else
        {
          this.SelectedDataBackup = this.SelectedData;
          this.SelectedDatasBackup = this.SelectedDatas;
          this.SelectedCodeBackup = this.SelectedCode;
          this.SelectedNameBackup = this.SelectedName;
          this.SelectedCodeInBackup = this.SelectedCodeIn;
          this.SelectedNameInBackup = this.SelectedNameIn;
          this.SelectedCodeInLv1Backup = this.SelectedCodeInLv1;
          this.SelectedNameInLv1Backup = this.SelectedNameInLv1;
          this.SelectedCodeInLv2Backup = this.SelectedCodeInLv2;
          this.SelectedNameInLv2Backup = this.SelectedNameInLv2;
          this.SelectedCodeInLv3Backup = this.SelectedCodeInLv3;
          this.SelectedNameInLv3Backup = this.SelectedNameInLv3;
          this.SelectedData = (object) null;
          this.SelectedDatas = (IList) null;
          this.SelectedCode = 0;
          this.SelectedName = string.Empty;
          this.SelectedCodeIn = string.Empty;
          this.SelectedNameIn = string.Empty;
          this.SelectedCodeInLv1 = string.Empty;
          this.SelectedNameInLv1 = string.Empty;
          this.SelectedCodeInLv2 = string.Empty;
          this.SelectedNameInLv2 = string.Empty;
          this.SelectedCodeInLv3 = string.Empty;
          this.SelectedNameInLv3 = string.Empty;
        }
        this.Changed(nameof (IsUse));
      }
    }

    public int SelectedDepth
    {
      get => (int) this.GetValue(CategoryCommonControl.SelectedDepthProperty);
      set => this.SetValue(CategoryCommonControl.SelectedDepthProperty, (object) value);
    }

    public string SelectedCodeInLv1
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedCodeInLv1Property);
      set => this.SetValue(CategoryCommonControl.SelectedCodeInLv1Property, (object) value);
    }

    protected string SelectedCodeInLv1Backup { get; set; }

    public string SelectedNameInLv1
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedNameInLv1Property);
      set => this.SetValue(CategoryCommonControl.SelectedNameInLv1Property, (object) value);
    }

    protected string SelectedNameInLv1Backup { get; set; }

    public string SelectedCodeInLv2
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedCodeInLv2Property);
      set => this.SetValue(CategoryCommonControl.SelectedCodeInLv2Property, (object) value);
    }

    protected string SelectedCodeInLv2Backup { get; set; }

    public string SelectedNameInLv2
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedNameInLv2Property);
      set => this.SetValue(CategoryCommonControl.SelectedNameInLv2Property, (object) value);
    }

    protected string SelectedNameInLv2Backup { get; set; }

    public string SelectedCodeInLv3
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedCodeInLv3Property);
      set => this.SetValue(CategoryCommonControl.SelectedCodeInLv3Property, (object) value);
    }

    protected string SelectedCodeInLv3Backup { get; set; }

    public string SelectedNameInLv3
    {
      get => (string) this.GetValue(CategoryCommonControl.SelectedNameInLv3Property);
      set => this.SetValue(CategoryCommonControl.SelectedNameInLv3Property, (object) value);
    }

    protected string SelectedNameInLv3Backup { get; set; }

    public override bool IsEmptySelect
    {
      get
      {
        if (!this.IsMultiSelect)
          return this.SelectedData == null && this.SelectedCode == 0;
        IList selectedDatas = this.SelectedDatas;
        if ((selectedDatas != null ? selectedDatas.Count : 0) != 0)
          return false;
        return this.SelectedNameIn == null || this.SelectedNameIn.Length == 0;
      }
    }

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      CategoryCommonBoardVM vm = this.Container.Get<CategoryCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.SearchContion = this.SearchContion;
      vm.InitControl();
      vm.Confirmed += new EventHandler<CommonBoardBase<CategoryView>>(this.Vm_Confirmed);
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
        return !(this.SelectedData is CategoryView selectedData) ? (string) null : selectedData.ctg_CategoryName;
      }
      if (this.SelectedNameIn != null && this.SelectedNameIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (CategoryView categoryView in selectedDatas2 != null ? selectedDatas2.OfType<CategoryView>() : (IEnumerable<CategoryView>) null)
        stringBuilder.Append(categoryView.ctg_CategoryName).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void Vm_Confirmed(object sender, CommonBoardBase<CategoryView> e)
    {
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.ctg_ID;
      this.SelectedName = e.SelectedData.ctg_CategoryName;
      this.SelectedDepth = e.SelectedData.ctg_Depth;
      if (e is CategoryCommonBoardVM categoryCommonBoardVm1 && !categoryCommonBoardVm1.IsCategory)
      {
        this.SelectedDatas.Clear();
        this.SelectedDatas.Add((object) categoryCommonBoardVm1.SelectedData);
        this.SelectedData = (object) categoryCommonBoardVm1.SelectedData;
        this.SelectedCode = categoryCommonBoardVm1.SelectedData.ctg_ID;
        this.SelectedName = categoryCommonBoardVm1.SelectedData.ctg_CategoryName;
        this.SelectedDepth = categoryCommonBoardVm1.SelectedData.ctg_Depth;
      }
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      StringBuilder stringBuilder3 = new StringBuilder();
      StringBuilder stringBuilder4 = new StringBuilder();
      StringBuilder stringBuilder5 = new StringBuilder();
      StringBuilder stringBuilder6 = new StringBuilder();
      StringBuilder stringBuilder7 = new StringBuilder();
      StringBuilder stringBuilder8 = new StringBuilder();
      foreach (CategoryView selectedData in (Collection<CategoryView>) e.SelectedDatas)
      {
        stringBuilder1.Append(selectedData.ctg_ID).Append(",");
        stringBuilder2.Append(selectedData.ctg_CategoryName).Append(",");
        if (selectedData.ctg_Depth == 1)
        {
          stringBuilder3.Append(selectedData.ctg_ID).Append(",");
          stringBuilder4.Append(selectedData.ctg_CategoryName).Append(",");
        }
        if (selectedData.ctg_Depth == 2)
        {
          stringBuilder5.Append(selectedData.ctg_ID).Append(",");
          stringBuilder6.Append(selectedData.ctg_CategoryName).Append(",");
        }
        if (selectedData.ctg_Depth == 3)
        {
          stringBuilder7.Append(selectedData.ctg_ID).Append(",");
          stringBuilder8.Append(selectedData.ctg_CategoryName).Append(",");
        }
      }
      if (stringBuilder1.Length > 1)
        --stringBuilder1.Length;
      this.SelectedCodeIn = stringBuilder1.ToString();
      if (stringBuilder3.Length > 1)
        --stringBuilder3.Length;
      this.SelectedCodeInLv1 = stringBuilder3.ToString();
      if (stringBuilder4.Length > 1)
        --stringBuilder4.Length;
      this.SelectedNameInLv1 = stringBuilder4.ToString();
      if (stringBuilder5.Length > 1)
        --stringBuilder5.Length;
      this.SelectedCodeInLv2 = stringBuilder5.ToString();
      if (stringBuilder6.Length > 1)
        --stringBuilder6.Length;
      this.SelectedNameInLv2 = stringBuilder6.ToString();
      if (stringBuilder7.Length > 1)
        --stringBuilder7.Length;
      this.SelectedCodeInLv3 = stringBuilder7.ToString();
      if (stringBuilder8.Length > 1)
        --stringBuilder8.Length;
      this.SelectedNameInLv3 = stringBuilder8.ToString();
      this.SelectedNameIn = stringBuilder2.ToString();
      this.SelectedCodeInLv1Backup = this.SelectedCodeInLv1;
      this.SelectedNameInLv1Backup = this.SelectedNameInLv1;
      this.SelectedCodeInLv2Backup = this.SelectedCodeInLv2;
      this.SelectedNameInLv2Backup = this.SelectedNameInLv2;
      this.SelectedCodeInLv3Backup = this.SelectedCodeInLv3;
      this.SelectedNameInLv3Backup = this.SelectedNameInLv3;
      string keyword = e is CategoryCommonBoardVM categoryCommonBoardVm2 ? categoryCommonBoardVm2.Param.Keyword : (string) null;
      if (keyword == null || keyword.Length <= 0)
        return;
      this.Keyword = keyword ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      CategoryCommonControl categoryCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await categoryCommonControl.\u003C\u003En__0();
      JobProgressState j = categoryCommonControl.Job?.CreateJob("분류 찾기", (string) null);
      try
      {
        string keyword = categoryCommonControl.Keyword;
        CategoryCommonBoardVM vm = categoryCommonControl.Container.Get<CategoryCommonBoardVM>();
        vm.IsMultiSelectMode = categoryCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          CategoryView categoryView = vm.Datas.First<CategoryView>();
          categoryCommonControl.SelectedData = (object) categoryView;
          categoryCommonControl.SelectedCode = categoryView.ctg_ID;
          categoryCommonControl.SelectedName = categoryView.ctg_CategoryName;
          categoryCommonControl.SelectedDepth = categoryView.ctg_Depth;
          categoryCommonControl.SelectedCodeIn = categoryView.ctg_ID.ToString();
          categoryCommonControl.SelectedNameIn = categoryView.ctg_CategoryName;
          if (categoryView.ctg_Depth == 1)
          {
            categoryCommonControl.SelectedCodeInLv1 = categoryView.ctg_ID.ToString();
            categoryCommonControl.SelectedNameInLv1 = categoryView.ctg_CategoryName;
            j = (JobProgressState) null;
            vm = (CategoryCommonBoardVM) null;
          }
          else if (categoryView.ctg_Depth == 2)
          {
            categoryCommonControl.SelectedCodeInLv2 = categoryView.ctg_ID.ToString();
            categoryCommonControl.SelectedNameInLv2 = categoryView.ctg_CategoryName;
            j = (JobProgressState) null;
            vm = (CategoryCommonBoardVM) null;
          }
          else if (categoryView.ctg_Depth != 3)
          {
            j = (JobProgressState) null;
            vm = (CategoryCommonBoardVM) null;
          }
          else
          {
            categoryCommonControl.SelectedCodeInLv3 = categoryView.ctg_ID.ToString();
            categoryCommonControl.SelectedNameInLv3 = categoryView.ctg_CategoryName;
            j = (JobProgressState) null;
            vm = (CategoryCommonBoardVM) null;
          }
        }
        else
        {
          vm.Confirmed += new EventHandler<CommonBoardBase<CategoryView>>(categoryCommonControl.Vm_Confirmed);
          categoryCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (CategoryCommonBoardVM) null;
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
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/categorycommoncontrol.xaml", UriKind.Relative));
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
        this.root = (CategoryCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
