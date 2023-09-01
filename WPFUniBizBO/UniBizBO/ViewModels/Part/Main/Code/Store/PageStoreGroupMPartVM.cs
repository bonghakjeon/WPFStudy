// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Store.PageStoreGroupMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Store;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Composition;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Store
{
  public class PageStoreGroupMPartVM : MPartBase<
  #nullable disable
  StoreGroupHeaderView>
  {
    private IList<CommonCodeView> _StoreGroupTypeList;
    private BindableCollection<StoreGroupDetailView> _DetailDatas = new BindableCollection<StoreGroupDetailView>();
    private StoreGroupDetailView _SelectedDetailData = new StoreGroupDetailView();
    private bool _IsAdmin;

    public IList<CommonCodeView> StoreGroupTypeList
    {
      get => this._StoreGroupTypeList;
      set
      {
        this._StoreGroupTypeList = value;
        this.NotifyOfPropertyChange(nameof (StoreGroupTypeList));
      }
    }

    public BindableCollection<StoreGroupDetailView> DetailDatas
    {
      get => this._DetailDatas;
      set
      {
        this._DetailDatas = value;
        this.NotifyOfPropertyChange(nameof (DetailDatas));
      }
    }

    public StoreGroupDetailView SelectedDetailData
    {
      get => this._SelectedDetailData;
      set
      {
        this._SelectedDetailData = value;
        this.NotifyOfPropertyChange(nameof (SelectedDetailData));
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

    public IReadOnlyDictionary<string, TableColumnInfo> DetailDataHeader => this.App.Sys?.TableColumns?.GetDictionary<StoreGroupDetailView>();

    public PageStoreGroupMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.StoreGroupTypeList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[31].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.DetailDatas.Clear();
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.WorkDataT.CurrentT.Lt_Details == null)
        return;
      this.DetailDatas.AddRange((IEnumerable<StoreGroupDetailView>) this.WorkDataT.CurrentT.Lt_Details);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageStoreGroupMPartVM storeGroupMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await storeGroupMpartVm.\u003C\u003En__0(p_param);
      storeGroupMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public WpfCommand CmdSeqUp => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSeqUp()),
        ExecuteAction = (Action<object>) (_ => await this.OnSeqUp())
      };
    }), nameof (CmdSeqUp));

    public virtual bool CanSeqUp() => true;

    public async Task OnSeqUp()
    {
      PageStoreGroupMPartVM storeGroupMpartVm = this;
      if (storeGroupMpartVm.SelectedDetailData == null || storeGroupMpartVm.SelectedDetailData.sgd_StoreCode == 0 || storeGroupMpartVm.SelectedDetailData.sgd_SortNo <= 0)
      {
        await Task.Yield();
      }
      else
      {
        int sgd_SortNo = storeGroupMpartVm.SelectedDetailData.sgd_SortNo;
        try
        {
          --storeGroupMpartVm.SelectedDetailData.sgd_SortNo;
          // ISSUE: explicit non-virtual call
          using (__nonvirtual (storeGroupMpartVm.Job).CreateJob("정렬 순서 변경", (string) null))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            (await StoreRestServer.PostStoreGroupDetail(storeGroupMpartVm.LogInPackInfo.sendType, storeGroupMpartVm.LogInPackInfo.siteID, storeGroupMpartVm.SelectedDetailData.sgd_StoreCode, storeGroupMpartVm.SelectedDetailData.sgd_GroupCode, 0, __nonvirtual (storeGroupMpartVm.MenuInfo).Code, storeGroupMpartVm.SelectedDetailData).ExecuteToReturnAsync<UbRes<StoreGroupDetailView>>((UniBizHttpClient) __nonvirtual (storeGroupMpartVm.App).Api)).GetData<StoreGroupDetailView>();
            int num1 = storeGroupMpartVm.DetailDatas.IndexOf(storeGroupMpartVm.SelectedDetailData);
            if (num1 > 0 && storeGroupMpartVm.DetailDatas[num1].sgd_SortNo <= storeGroupMpartVm.DetailDatas[num1 - 1].sgd_SortNo)
            {
              int num2;
              storeGroupMpartVm.DetailDatas.Move(num1, num2 = num1 - 1);
            }
            storeGroupMpartVm.OnAppWinMsgArgsRequested("FirstUI");
          }
        }
        catch (Exception ex)
        {
          Log.Logger.Error(ex, ex.Message);
          // ISSUE: explicit non-virtual call
          int num = (int) __nonvirtual (storeGroupMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
          storeGroupMpartVm.SelectedDetailData.sgd_SortNo = sgd_SortNo;
        }
      }
    }

    public WpfCommand CmdSeqDown => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSeqDown()),
        ExecuteAction = (Action<object>) (_ => await this.OnSeqDown())
      };
    }), nameof (CmdSeqDown));

    public bool CanSeqDown() => true;

    public async Task OnSeqDown()
    {
      PageStoreGroupMPartVM storeGroupMpartVm = this;
      if (storeGroupMpartVm.SelectedDetailData == null || storeGroupMpartVm.SelectedDetailData.sgd_StoreCode == 0)
      {
        await Task.Yield();
      }
      else
      {
        int sgd_SortNo = storeGroupMpartVm.SelectedDetailData.sgd_SortNo;
        try
        {
          ++storeGroupMpartVm.SelectedDetailData.sgd_SortNo;
          // ISSUE: explicit non-virtual call
          using (__nonvirtual (storeGroupMpartVm.Job).CreateJob("정렬 순서 변경", (string) null))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            (await StoreRestServer.PostStoreGroupDetail(storeGroupMpartVm.LogInPackInfo.sendType, storeGroupMpartVm.LogInPackInfo.siteID, storeGroupMpartVm.SelectedDetailData.sgd_StoreCode, storeGroupMpartVm.SelectedDetailData.sgd_GroupCode, 0, __nonvirtual (storeGroupMpartVm.MenuInfo).Code, storeGroupMpartVm.SelectedDetailData).ExecuteToReturnAsync<UbRes<StoreGroupDetailView>>((UniBizHttpClient) __nonvirtual (storeGroupMpartVm.App).Api)).GetData<StoreGroupDetailView>();
            int num1 = storeGroupMpartVm.DetailDatas.IndexOf(storeGroupMpartVm.SelectedDetailData);
            if (num1 < storeGroupMpartVm.DetailDatas.Count - 1 && storeGroupMpartVm.DetailDatas[num1].sgd_SortNo > storeGroupMpartVm.DetailDatas[num1 + 1].sgd_SortNo)
            {
              int num2;
              storeGroupMpartVm.DetailDatas.Move(num1, num2 = num1 + 1);
            }
            storeGroupMpartVm.OnAppWinMsgArgsRequested("FirstUI");
          }
        }
        catch (Exception ex)
        {
          Log.Logger.Error(ex, ex.Message);
          // ISSUE: explicit non-virtual call
          int num = (int) __nonvirtual (storeGroupMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
          storeGroupMpartVm.SelectedDetailData.sgd_SortNo = sgd_SortNo;
        }
      }
    }

    public bool CanStoreInsert() => true;

    private async Task DetailInsertAsync(StoreGroupDetailView p_data)
    {
      PageStoreGroupMPartVM storeGroupMpartVm = this;
      try
      {
        if (storeGroupMpartVm.DetailDatas.Where<StoreGroupDetailView>((Func<StoreGroupDetailView, bool>) (it => it.sgd_StoreCode == p_data.sgd_StoreCode)).ToList<StoreGroupDetailView>().Count > 0)
          throw new Exception(" " + p_data.si_StoreName + "(" + p_data.si_StoreViewCode + "). 등록된 지점 입니다.");
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (storeGroupMpartVm.Job).CreateJob("지점 추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          StoreGroupDetailView data = (await StoreRestServer.PostStoreGroupDetail(storeGroupMpartVm.LogInPackInfo.sendType, storeGroupMpartVm.LogInPackInfo.siteID, p_data.sgd_StoreCode, p_data.sgd_GroupCode, 0, __nonvirtual (storeGroupMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<StoreGroupDetailView>>((UniBizHttpClient) __nonvirtual (storeGroupMpartVm.App).Api)).GetData<StoreGroupDetailView>();
          if (storeGroupMpartVm.DetailDatas.Where<StoreGroupDetailView>((Func<StoreGroupDetailView, bool>) (it => it.sgd_StoreCode == p_data.sgd_StoreCode)).ToList<StoreGroupDetailView>().Count == 0)
            storeGroupMpartVm.DetailDatas.Insert(storeGroupMpartVm.DetailDatas.Count, data);
          storeGroupMpartVm.OnAppWinMsgArgsRequested("FirstUI");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (storeGroupMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    private void Vm_StoreConfirmed(object sender, CommonBoardBase<StoreInfoView> e)
    {
      int num = 1;
      if (this.WorkDataT.CurrentT.Lt_Details != null && this.WorkDataT.CurrentT.Lt_Details.Count > 0)
        num = this.WorkDataT.CurrentT.Lt_Details.Max<StoreGroupDetailView>((Func<StoreGroupDetailView, int>) (it => it.sgd_SortNo)) + 1;
      StoreGroupDetailView p_data = new StoreGroupDetailView();
      p_data.row_number = this.WorkDataT.CurrentT.Lt_Details.Count + 1;
      p_data.sgh_GroupType = this.WorkDataT.CurrentT.sgh_GroupType;
      p_data.sgh_GroupName = this.WorkDataT.CurrentT.sgh_GroupName;
      p_data.sgh_Memo = this.WorkDataT.CurrentT.sgh_Memo;
      p_data.sgh_SortNo = this.WorkDataT.CurrentT.sgh_SortNo;
      p_data.sgh_UseYn = this.WorkDataT.CurrentT.sgh_UseYn;
      p_data.sgd_GroupCode = this.WorkDataT.CurrentT.sgh_GroupCode;
      p_data.sgd_StoreCode = e.SelectedData.si_StoreCode;
      p_data.sgd_SortNo = num;
      this.DetailInsertAsync(p_data);
    }

    public void OnStoreInsert()
    {
      StoreCommonBoardVM viewModel = this.Container.Get<StoreCommonBoardVM>();
      viewModel.IsMultiSelectMode = false;
      viewModel.BeforeDatas = new Dictionary<int, StoreInfoView>();
      viewModel.Confirmed += new EventHandler<CommonBoardBase<StoreInfoView>>(this.Vm_StoreConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    public WpfCommand CmdStoreInsert => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanStoreInsert()),
        ExecuteAction = (Action<object>) (_ => this.OnStoreInsert())
      };
    }), nameof (CmdStoreInsert));

    public bool CanStoreDelete() => true;

    public async Task OnStoreDelete()
    {
      PageStoreGroupMPartVM storeGroupMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (storeGroupMpartVm.Job).CreateJob("지점 삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await StoreRestServer.DeleteStoreGroupDetail(storeGroupMpartVm.LogInPackInfo.sendType, storeGroupMpartVm.LogInPackInfo.siteID, storeGroupMpartVm.SelectedDetailData.sgd_StoreCode, storeGroupMpartVm.SelectedDetailData.sgd_GroupCode, 0, __nonvirtual (storeGroupMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<StoreGroupDetailView>>((UniBizHttpClient) __nonvirtual (storeGroupMpartVm.App).Api)).GetData<StoreGroupDetailView>();
          storeGroupMpartVm.DetailDatas.Remove(storeGroupMpartVm.SelectedDetailData);
          storeGroupMpartVm.OnAppWinMsgArgsRequested("FirstUI");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (storeGroupMpartVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
      }
    }

    public WpfCommand CmdStoreDelete => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanStoreDelete()),
        ExecuteAction = (Action<object>) (_ => await this.OnStoreDelete())
      };
    }), nameof (CmdStoreDelete));

    public bool CanDataOpen(StoreInfoView item) => item != null;

    public void DataOpen(StoreInfoView item)
    {
    }

    public WpfCommand<StoreInfoView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<StoreInfoView>>((Func<WpfCommand<StoreInfoView>>) (() => new WpfCommand<StoreInfoView>().AutoRefreshOn<WpfCommand<StoreInfoView>>().ApplyCanExecute<StoreInfoView>(new Func<StoreInfoView, bool>(this.CanDataOpen)).ApplyExecute<StoreInfoView>(new Action<StoreInfoView>(this.DataOpen))), nameof (CmdDataOpen));

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.WinClose();
    }

    public void OnSaveData()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.MenuInfo.Title + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.SaveWorkDataAsync();
    }
  }
}
