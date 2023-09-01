// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Store.PageStoreMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Models.Addr.MoisGoKr;
using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Store
{
  public class PageStoreMPartVM : MPartBase<
  #nullable disable
  StoreInfoView>
  {
    private bool _IsAdmin;
    private bool _IsStoreSave;

    public bool IsAdmin
    {
      get => this._IsAdmin;
      set
      {
        this._IsAdmin = value;
        this.NotifyOfPropertyChange(nameof (IsAdmin));
      }
    }

    public bool IsStoreSave
    {
      get => this._IsStoreSave;
      set
      {
        this._IsStoreSave = value;
        this.NotifyOfPropertyChange(nameof (IsStoreSave));
      }
    }

    public PageStoreMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.IsStoreSave = this.App.User.User.Source.IsStore;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageStoreMPartVM pageStoreMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageStoreMpartVm.\u003C\u003En__0(p_param);
      pageStoreMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public WpfCommand CmdSaveData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSaveData()),
        ExecuteAction = (Action<object>) (_ => this.SaveData())
      };
    }), nameof (CmdSaveData));

    public bool CanSaveData() => this.App.User.User.Source.IsStore;

    public void SaveData()
    {
      if (!this.CanSaveData())
        return;
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.MenuInfo.Title + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.SaveWorkDataAsync();
    }

    public bool CanSearchZip() => true;

    public void OnSearchZip()
    {
      AddrInfoBoardVM viewModel = this.Container.Get<AddrInfoBoardVM>();
      viewModel.IsMultiSelectMode = false;
      viewModel.Confirmed += new EventHandler<CommonBoardBase<AddrInfoView>>(this.VmAddrInfoConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    private void VmAddrInfoConfirmed(object sender, CommonBoardBase<AddrInfoView> e)
    {
      if (e.SelectedData.ZipNo.Length == 0)
        return;
      this.WorkDataT.CurrentT.si_ZipCode = e.SelectedData.ZipNo;
      this.WorkDataT.CurrentT.si_BizAddr1 = e.SelectedData.RoadAddr;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("si_BizAddr2")), (DispatcherPriority) 4);
    }

    public WpfCommand CmdSearchZip => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchZip()),
        ExecuteAction = (Action<object>) (_ => this.OnSearchZip())
      };
    }), nameof (CmdSearchZip));

    public WpfCommand CmdSearchStore => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchStore()),
        ExecuteAction = (Action<object>) (_ => this.SearchStore())
      };
    }), nameof (CmdSearchStore));

    public bool CanSearchStore() => true;

    public void SearchStore()
    {
      try
      {
        if (!this.CanSearchStore())
          return;
        StoreInfoView storeInfoView = this.Container.Get<StoreCommonBoardVM>().Action<StoreCommonBoardVM>((Action<StoreCommonBoardVM>) (it => it.LoadManagedStatus())).Set("(" + this.WorkDataT.CurrentT.si_StoreName + ")지점 포인트(적립)지점 등록").ShowDialog2Data();
        if (storeInfoView == null || storeInfoView.si_StoreCode == 0)
          return;
        this.WorkDataT.CurrentT.si_MemberMntStore = storeInfoView.si_StoreCode;
        this.WorkDataT.CurrentT.si_StoreNameMember = storeInfoView.si_StoreName;
      }
      catch (Exception ex)
      {
        Log.Error("포인트(적립)지점 등록 오류=" + ex.Message);
        int num = (int) new CommonMsgVM(this.Container).Set("포인트(적립)지점 등록 오류", ex.Message).ShowDialog();
      }
    }
  }
}
