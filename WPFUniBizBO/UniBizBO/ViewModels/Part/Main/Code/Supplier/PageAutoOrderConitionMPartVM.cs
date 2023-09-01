// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Supplier.PageAutoOrderConitionMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Store;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Composition;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Supplier
{
  public class PageAutoOrderConitionMPartVM : MPartBase<
  #nullable disable
  SupplierView>
  {
    private BindableCollection<AutoOrderConitionView> _AutoOrderConitionDatas = new BindableCollection<AutoOrderConitionView>();
    private StoreInfoView _StoreInfo = new StoreInfoView();
    private IList<CommonCodeView> _AutoOrderRefDayList;
    private bool _IsAdmin;
    private bool _IsEnterNext = true;

    public IReadOnlyDictionary<string, TableColumnInfo> AutoOrderConitionHeader => this.App.Sys?.TableColumns?.GetDictionary<AutoOrderConitionView>();

    public BindableCollection<AutoOrderConitionView> AutoOrderConitionDatas
    {
      get => this._AutoOrderConitionDatas;
      set
      {
        this._AutoOrderConitionDatas = value;
        this.NotifyOfPropertyChange(nameof (AutoOrderConitionDatas));
      }
    }

    public IReadOnlyDictionary<string, TableColumnInfo> StoreInfoHeader => this.App.Sys?.TableColumns?.GetDictionary<StoreInfoView>();

    public StoreInfoView StoreInfo
    {
      get => this._StoreInfo;
      set
      {
        this._StoreInfo = value;
        this.NotifyOfPropertyChange(nameof (StoreInfo));
        this.DoAutoOrderConitionSearchAsync();
      }
    }

    public static IReadOnlyDictionary<int, string> WeekItems { get; } = DateHelper.WeekItems;

    public IList<CommonCodeView> AutoOrderRefDayList
    {
      get => this._AutoOrderRefDayList;
      set
      {
        this._AutoOrderRefDayList = value;
        this.NotifyOfPropertyChange(nameof (AutoOrderRefDayList));
      }
    }

    public bool IsAdmin
    {
      get => this._IsAdmin;
      set
      {
        this._IsAdmin = value;
        this.NotifyOfPropertyChange(nameof (IsAdmin));
      }
    }

    public bool IsEnterNext
    {
      get => this._IsEnterNext;
      set
      {
        this._IsEnterNext = value;
        this.NotifyOfPropertyChange(nameof (IsEnterNext));
      }
    }

    public PageAutoOrderConitionMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.AutoOrderRefDayList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.AutoOrderRefDay].ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.DoSiteInfoSearchAsync(this.App.User.User.Source.emp_BaseStore);
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null)
        return;
      int num = this.PartContainer.IsCreateMode ? 1 : 0;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageAutoOrderConitionMPartVM orderConitionMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await orderConitionMpartVm.\u003C\u003En__0(p_param);
      orderConitionMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void DoSiteInfoSearchAsync(int p_si_StoreCode)
    {
      PageAutoOrderConitionMPartVM orderConitionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (orderConitionMpartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (orderConitionMpartVm.Job).CreateJob("지점 조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<StoreInfoView> returnAsync = await StoreRestServer.GetStoreInfo(orderConitionMpartVm.LogInPackInfo.sendType, orderConitionMpartVm.LogInPackInfo.siteID, p_si_StoreCode, 0, __nonvirtual (orderConitionMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<StoreInfoView>>((UniBizHttpClient) __nonvirtual (orderConitionMpartVm.App).Api);
          orderConitionMpartVm.StoreInfo = returnAsync.GetData<StoreInfoView>();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (orderConitionMpartVm.Container)).Set(__nonvirtual (orderConitionMpartVm.DisplayName) + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void DoAutoOrderConitionSearchAsync()
    {
      PageAutoOrderConitionMPartVM orderConitionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (orderConitionMpartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (orderConitionMpartVm.Job).CreateJob("자동발주 조회", (string) null))
        {
          orderConitionMpartVm.AutoOrderConitionDatas.Clear();
          string sendType = orderConitionMpartVm.LogInPackInfo.sendType;
          long siteId = orderConitionMpartVm.LogInPackInfo.siteID;
          // ISSUE: explicit non-virtual call
          int suSupplier = __nonvirtual (orderConitionMpartVm.WorkDataT).CurrentT.su_Supplier;
          int siStoreCode = orderConitionMpartVm.StoreInfo.si_StoreCode;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (orderConitionMpartVm.MenuInfo).Code;
          int aoc_Supplier = suSupplier;
          int aoc_StoreCode = siStoreCode;
          // ISSUE: explicit non-virtual call
          UbRes<IList<AutoOrderConitionView>> success = (await SupplierRestServer.GetAutoOrderConitionList(sendType, siteId, 0, code, aoc_Supplier: aoc_Supplier, aoc_StoreCode: aoc_StoreCode).ExecuteToReturnAsync<UbRes<IList<AutoOrderConitionView>>>((UniBizHttpClient) __nonvirtual (orderConitionMpartVm.App).Api)).GetSuccess<UbRes<IList<AutoOrderConitionView>>>();
          orderConitionMpartVm.AutoOrderConitionDatas.AddRange((IEnumerable<AutoOrderConitionView>) success.response);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (orderConitionMpartVm.Container)).Set(__nonvirtual (orderConitionMpartVm.DisplayName) + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task PostAutoOrderConitionAsync(List<AutoOrderConitionView> p_list)
    {
      PageAutoOrderConitionMPartVM orderConitionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (orderConitionMpartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (orderConitionMpartVm.Job).CreateJob("자동발주 삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await SupplierRestServer.PostAutoOrderConitionList(orderConitionMpartVm.LogInPackInfo.sendType, orderConitionMpartVm.LogInPackInfo.siteID, 0, __nonvirtual (orderConitionMpartVm.MenuInfo).Code, (IList<AutoOrderConitionView>) p_list).ExecuteToReturnAsync<UbRes<IList<AutoOrderConitionView>>>((UniBizHttpClient) __nonvirtual (orderConitionMpartVm.App).Api)).GetSuccess<UbRes<IList<AutoOrderConitionView>>>();
          foreach (UbModelBase p in p_list)
            p.DB_STATUS = EnumDBStatus.NONE;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (orderConitionMpartVm.Container)).Set(__nonvirtual (orderConitionMpartVm.DisplayName) + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task DeleteAutoOrderConitionAsync(List<AutoOrderConitionView> p_list)
    {
      PageAutoOrderConitionMPartVM orderConitionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (orderConitionMpartVm.PartContainer).IsCreateMode)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (orderConitionMpartVm.Job).CreateJob("자동발주 삭제", (string) null))
          orderConitionMpartVm.DoAutoOrderConitionSearchAsync();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (orderConitionMpartVm.Container)).Set(__nonvirtual (orderConitionMpartVm.DisplayName) + " 오류", ex.Message).ShowDialog();
      }
    }

    public bool CanIsPaymentInput() => this.App.User.User.Source.IsPaymentInput;

    public WpfCommand CmdSaveAutoOrderConition => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.SaveAutoOrderConition())
      };
    }), nameof (CmdSaveAutoOrderConition));

    public void SaveAutoOrderConition()
    {
      if (this.PartContainer.IsCreateMode)
        return;
      List<AutoOrderConitionView> p_list = new List<AutoOrderConitionView>();
      foreach (AutoOrderConitionView orderConitionData in (Collection<AutoOrderConitionView>) this.AutoOrderConitionDatas)
      {
        if (orderConitionData.IsNew)
          p_list.Add(orderConitionData);
      }
      int count = p_list.Count;
      if (p_list.Count <= 0)
        return;
      this.PostAutoOrderConitionAsync(p_list);
    }

    public WpfCommand CmdAddAutoOrderConition => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.AddAutoOrderConition())
      };
    }), nameof (CmdAddAutoOrderConition));

    public void AddAutoOrderConition()
    {
      if (this.PartContainer.IsCreateMode)
        return;
      CategoryCommonBoardVM viewModel = this.Container.Get<CategoryCommonBoardVM>();
      viewModel.IsMultiSelectMode = true;
      viewModel.Param.CtgDepth = this.App.Sys.CommonCodes[CommonCodeTypes.CategoryDepth][1];
      viewModel.Confirmed += new EventHandler<CommonBoardBase<CategoryView>>(this.Vm_CategoryConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    private void Vm_CategoryConfirmed(object sender, CommonBoardBase<CategoryView> e)
    {
      Log.Error("---------------------------------------------");
      foreach (CategoryView selectedData in (Collection<CategoryView>) e.SelectedDatas)
        Log.Error(string.Format("TAB1 lv={0}, name = {1}", (object) selectedData.ctg_Depth, (object) selectedData.ctg_CategoryName));
      if (e is CategoryCommonBoardVM categoryCommonBoardVm && !categoryCommonBoardVm.IsCategory)
      {
        foreach (CategoryView selectedData in (Collection<CategoryView>) e.SelectedDatas)
          Log.Error(string.Format("TAB2 lv={0}, name = {1}", (object) selectedData.ctg_Depth, (object) selectedData.ctg_CategoryName));
      }
      Log.Error("---------------------------------------------");
    }

    public WpfCommand CmdDeleteAutoOrderConition => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.DeleteAutoOrderConition())
      };
    }), nameof (CmdDeleteAutoOrderConition));

    public void DeleteAutoOrderConition()
    {
      if (this.PartContainer.IsCreateMode)
        return;
      List<AutoOrderConitionView> p_list = new List<AutoOrderConitionView>();
      foreach (AutoOrderConitionView orderConitionData in (Collection<AutoOrderConitionView>) this.AutoOrderConitionDatas)
      {
        if (orderConitionData.RowCheckStatus.IsChecked)
        {
          if (orderConitionData.IsNew)
            this.AutoOrderConitionDatas.Remove(orderConitionData);
          else
            p_list.Add(orderConitionData);
        }
      }
      int count = p_list.Count;
      if (p_list.Count <= 0)
        return;
      this.DeleteAutoOrderConitionAsync(p_list);
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }
  }
}
