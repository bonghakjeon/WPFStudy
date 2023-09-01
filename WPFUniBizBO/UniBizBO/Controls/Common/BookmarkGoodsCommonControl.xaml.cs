// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.BookmarkGoodsCommonControl
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
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Board.Common;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public partial class BookmarkGoodsCommonControl : CommonControlBase, IComponentConnector
  {
    internal 
    #nullable disable
    BookmarkGoodsCommonControl root;
    private bool _contentLoaded;

    public BookmarkGoodsCommonControl() => this.InitializeComponent();

    public override void OnOpenSelectBoard()
    {
      base.OnOpenSelectBoard();
      BookmarkGoodsCommonBoardVM vm = this.Container.Get<BookmarkGoodsCommonBoardVM>();
      vm.IsMultiSelectMode = this.IsMultiSelect;
      vm.Confirmed += new EventHandler<CommonBoardBase<BookmarkGoodsGroupView>>(this.Vm_Confirmed);
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
        return !(this.SelectedData is BookmarkGoodsGroupView selectedData) ? (string) null : selectedData.bgg_GroupName;
      }
      if (this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
        return this.SelectedNameIn;
      IList selectedDatas1 = this.SelectedDatas;
      if ((selectedDatas1 != null ? selectedDatas1.Count : 0) <= 0)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      IList selectedDatas2 = this.SelectedDatas;
      foreach (BookmarkGoodsGroupView bookmarkGoodsGroupView in selectedDatas2 != null ? selectedDatas2.OfType<BookmarkGoodsGroupView>() : (IEnumerable<BookmarkGoodsGroupView>) null)
        stringBuilder.Append(bookmarkGoodsGroupView.bgg_GroupName).Append(", ");
      stringBuilder.Length -= 2;
      return stringBuilder.ToString();
    }

    private void Vm_Confirmed(object sender, CommonBoardBase<BookmarkGoodsGroupView> e)
    {
      this.SelectedDatas = (IList) e.SelectedDatas;
      this.SelectedData = (object) e.SelectedData;
      this.SelectedCode = e.SelectedData.bgg_GroupID;
      this.SelectedName = e.SelectedData.bgg_GroupName;
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (BookmarkGoodsGroupView selectedData in (Collection<BookmarkGoodsGroupView>) e.SelectedDatas)
      {
        stringBuilder1.Append(selectedData.bgg_GroupID).Append(",");
        stringBuilder2.Append(selectedData.bgg_GroupName).Append(",");
      }
      if (stringBuilder1.Length > 1)
        --stringBuilder1.Length;
      this.SelectedCodeIn = stringBuilder1.ToString();
      if (stringBuilder2.Length > 1)
        --stringBuilder2.Length;
      this.SelectedNameIn = stringBuilder2.ToString();
      this.Keyword = (e is BookmarkGoodsCommonBoardVM goodsCommonBoardVm ? goodsCommonBoardVm.Param.Keyword : (string) null) ?? this.Keyword;
    }

    public override async Task OnQuickSearchAsync()
    {
      BookmarkGoodsCommonControl goodsCommonControl = this;
      // ISSUE: reference to a compiler-generated method
      await goodsCommonControl.\u003C\u003En__0();
      JobProgressState j = goodsCommonControl.Job?.CreateJob("관심상품 찾기", (string) null);
      try
      {
        string keyword = goodsCommonControl.Keyword;
        BookmarkGoodsCommonBoardVM vm = goodsCommonControl.Container.Get<BookmarkGoodsCommonBoardVM>();
        vm.IsMultiSelectMode = goodsCommonControl.IsMultiSelect;
        vm.Param.Keyword = keyword;
        await vm.SearchAsync(j);
        if (vm.Datas.Count == 1)
        {
          BookmarkGoodsGroupView bookmarkGoodsGroupView = vm.Datas.First<BookmarkGoodsGroupView>();
          goodsCommonControl.SelectedData = (object) bookmarkGoodsGroupView;
          goodsCommonControl.SelectedCode = bookmarkGoodsGroupView.bgg_GroupID;
          goodsCommonControl.SelectedName = bookmarkGoodsGroupView.bgg_GroupName;
          goodsCommonControl.SelectedCodeIn = bookmarkGoodsGroupView.bgg_GroupID.ToString();
          goodsCommonControl.SelectedNameIn = bookmarkGoodsGroupView.bgg_GroupName;
          j = (JobProgressState) null;
          vm = (BookmarkGoodsCommonBoardVM) null;
        }
        else
        {
          vm.Confirmed += new EventHandler<CommonBoardBase<BookmarkGoodsGroupView>>(goodsCommonControl.Vm_Confirmed);
          goodsCommonControl.Container.Get<IWindowManager>().ShowDialog((object) vm);
          j = (JobProgressState) null;
          vm = (BookmarkGoodsCommonBoardVM) null;
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
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/controls/common/bookmarkgoodscommoncontrol.xaml", UriKind.Relative));
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
        this.root = (BookmarkGoodsCommonControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
