// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Common.StoreCommonBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Store;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Common
{
  public class StoreCommonBoardVM : CommonBoardBase<
  #nullable disable
  StoreInfoView>
  {
    private string _Title = "지점조회";
    private string _TitleDesc = string.Empty;
    private StoreCommonBoardVM.InitParam _InitControlParam = new StoreCommonBoardVM.InitParam();
    private StoreCommonBoardVM.SearchParam param = new StoreCommonBoardVM.SearchParam();
    private int _TabIndex;

    public StoreCommonBoardVM(IContainer container)
      : base(container)
    {
    }

    public StoreCommonBoardVM Set(string pTitle = null, string pTitleDesc = null, bool? pIsMemberMntStore = null)
    {
      if (pTitle != null && pTitle.Length > 0)
        this.Title = pTitle;
      if (pTitleDesc != null && pTitleDesc.Length > 0)
        this.TitleDesc = pTitleDesc;
      if (pIsMemberMntStore.HasValue)
        this.Param.IsMemberMntStore = pIsMemberMntStore.Value;
      return this;
    }

    public StoreInfoView ShowDialog2Data()
    {
      this.IsMultiSelectMode = false;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (StoreInfoView) null : this.SelectedData;
    }

    public IList<StoreInfoView> ShowDialog2Datas()
    {
      this.IsMultiSelectMode = true;
      this.WindowManager.ShowDialog((object) this);
      return !this.IsConfirm ? (IList<StoreInfoView>) null : (IList<StoreInfoView>) this.SelectedDatas;
    }

    public string Title
    {
      get => this._Title;
      set
      {
        this._Title = value;
        this.NotifyOfPropertyChange(nameof (Title));
      }
    }

    public string TitleDesc
    {
      get => this._TitleDesc;
      set
      {
        this._TitleDesc = value;
        this.NotifyOfPropertyChange(nameof (TitleDesc));
      }
    }

    [ManagedStatus]
    public StoreCommonBoardVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public StoreCommonBoardVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public Dictionary<int, StoreInfoView> BeforeDatas { get; set; } = new Dictionary<int, StoreInfoView>();

    public BindableCollection<StoreGroupHeaderView> StoreGroupDatas { get; } = new BindableCollection<StoreGroupHeaderView>();

    public int TabIndex
    {
      get => this._TabIndex;
      set
      {
        this._TabIndex = value;
        this.NotifyOfPropertyChange(nameof (TabIndex));
      }
    }

    public void OnFunc(DefaultBoardFunc funcType)
    {
      if (funcType.Equals((object) DefaultBoardFunc.Confirm))
      {
        List<StoreInfoView> items = new List<StoreInfoView>();
        foreach (StoreGroupHeaderView storeGroupData in (Collection<StoreGroupHeaderView>) this.StoreGroupDatas)
        {
          foreach (StoreGroupDetailView ltDetail in (IEnumerable<StoreGroupDetailView>) storeGroupData.Lt_Details)
          {
            if (ltDetail.RowCheckStatus.IsChecked)
            {
              List<StoreInfoView> storeInfoViewList = items;
              StoreInfoView storeInfoView = new StoreInfoView();
              storeInfoView.si_StoreCode = ltDetail.sgd_StoreCode;
              storeInfoView.si_StoreName = ltDetail.si_StoreName;
              storeInfoView.si_StoreViewCode = ltDetail.si_StoreViewCode;
              storeInfoView.si_StoreType = ltDetail.si_StoreType;
              storeInfoViewList.Add(storeInfoView);
            }
          }
        }
        if (items.Count == 0)
        {
          int num = (int) new CommonMsgVM(this.Container).Set("지점 선택 필요.", "지점 선택 후 사용 가능.").ShowDialog();
          return;
        }
        this.SelectedDatas.Clear();
        this.SelectedDatas.AddRange((IEnumerable<StoreInfoView>) items);
        this.SelectedData = this.SelectedDatas.FirstOrDefault<StoreInfoView>();
        this.OnConfirm();
      }
      if (!funcType.Equals((object) DefaultBoardFunc.Close))
        return;
      this.OnQueryDefaultFunc(funcType);
    }

    public override void OnConfirm()
    {
      this.InitControlParam.TabIndex = this.TabIndex;
      this.InitControlParam.IsTreeChildrenBind = this.Param.IsTreeChildrenBind;
      base.OnConfirm();
    }

    public override void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (!funcType.Equals((object) DefaultBoardFunc.Search))
        return;
      this.SearchAsync();
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.DefaultFuncs = (IEnumerable<DefaultBoardFunc>) new DefaultBoardFunc[3]
      {
        DefaultBoardFunc.Search,
        DefaultBoardFunc.Confirm,
        DefaultBoardFunc.Close
      };
      this.InitControl();
      this.SearchAsync();
      this.SearchDepthAsync();
    }

    protected void InitControl()
    {
      this.Param.Use = this.InitControlParam.Use;
      this.TabIndex = !this.IsMultiSelectMode ? 0 : this.InitControlParam.TabIndex;
      this.Param.IsTreeChildrenBind = this.InitControlParam.IsTreeChildrenBind;
    }

    public void SetParamBackup()
    {
      if (this.IsMultiSelectMode)
        this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.IsTreeChildrenBind = this.Param.IsTreeChildrenBind;
    }

    public void OnWinClose() => this.RequestClose(new bool?());

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      StoreCommonBoardVM storeCommonBoardVm = this;
      // ISSUE: reference to a compiler-generated method
      await storeCommonBoardVm.\u003C\u003En__0(p_param);
      storeCommonBoardVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async Task SearchAsync(JobProgressState pj = null)
    {
      StoreCommonBoardVM storeCommonBoardVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (pj ?? __nonvirtual (storeCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          IList<StoreInfoView> data = (await StoreRestServer.GetStoreInfoList(storeCommonBoardVm.LogInPackInfo.sendType, storeCommonBoardVm.LogInPackInfo.siteID, 0, 0, si_UseYn: storeCommonBoardVm.Param.UseYn, is_MemberMntStore: storeCommonBoardVm.Param.IsMemberMntStore, KeyWord: storeCommonBoardVm.Param.Keyword).ExecuteToReturnAsync<UbRes<IList<StoreInfoView>>>((UniBizHttpClient) __nonvirtual (storeCommonBoardVm.App).Api)).GetData<IList<StoreInfoView>>();
          storeCommonBoardVm.Datas.Clear();
          storeCommonBoardVm.Datas.AddRange((IEnumerable<StoreInfoView>) data);
          if (data.Count > 0)
            storeCommonBoardVm.OnAppWinMsgArgsRequested("GRID");
          storeCommonBoardVm.SetParamBackup();
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (storeCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public async void SearchDepthAsync()
    {
      StoreCommonBoardVM storeCommonBoardVm = this;
      try
      {
        if (storeCommonBoardVm.Param.IsMemberMntStore)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (storeCommonBoardVm.Job).CreateJob("조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          StoreGroupDepth data = (await StoreRestServer.GetStoreGroupDepth(storeCommonBoardVm.LogInPackInfo.sendType, storeCommonBoardVm.LogInPackInfo.siteID, 0, 0).ExecuteToReturnAsync<UbRes<StoreGroupDepth>>((UniBizHttpClient) __nonvirtual (storeCommonBoardVm.App).Api)).GetData<StoreGroupDepth>();
          foreach (StoreGroupHeaderView storeGroupHeaderView in data)
          {
            if (storeGroupHeaderView.Lt_Details != null)
            {
              foreach (StoreGroupDetailView ltDetail in (IEnumerable<StoreGroupDetailView>) storeGroupHeaderView.Lt_Details)
                ltDetail.RowCheckStatus.IsChecked = storeCommonBoardVm.BeforeDatas.ContainsKey(ltDetail.sgd_StoreCode);
            }
          }
          storeCommonBoardVm.StoreGroupDatas.Clear();
          storeCommonBoardVm.StoreGroupDatas.AddRange((IEnumerable<StoreGroupHeaderView>) data);
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (storeCommonBoardVm.Container)).SetException(ex).ShowDialog();
      }
    }

    public bool CanDataDbClick(StoreInfoView item) => item != null;

    public void DataDbClick(StoreInfoView item)
    {
      this.SelectedData = item;
      this.OnConfirm();
    }

    public WpfCommand<StoreInfoView> CmdDataDbClick => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<StoreInfoView>>((Func<WpfCommand<StoreInfoView>>) (() => new WpfCommand<StoreInfoView>().AutoRefreshOn<WpfCommand<StoreInfoView>>().ApplyCanExecute<StoreInfoView>(new Func<StoreInfoView, bool>(this.CanDataDbClick)).ApplyExecute<StoreInfoView>(new Action<StoreInfoView>(this.DataDbClick))), nameof (CmdDataDbClick));

    public void BtnClick(string argument)
    {
      int num = (int) new CommonMsgVM(this.Container).Set(argument ?? "", "버튼 클릭").ShowDialog();
    }

    public void OnCheckedBoxClick(object p_depth)
    {
      if (!(p_depth is ContentPresenter contentPresenter))
        return;
      if (contentPresenter.DataContext is StoreGroupHeaderView dataContext1)
      {
        if (!this.Param.IsTreeChildrenBind)
          return;
        foreach (UbModelBase ltDetail in (IEnumerable<StoreGroupDetailView>) dataContext1.Lt_Details)
          ltDetail.RowCheckStatus.IsChecked = dataContext1.RowCheckStatus.IsChecked;
      }
      else
      {
        if (!(contentPresenter.DataContext is StoreGroupDetailView dataContext) || !this.Param.IsTreeChildrenBind)
          return;
        foreach (StoreGroupHeaderView storeGroupData in (Collection<StoreGroupHeaderView>) this.StoreGroupDatas)
        {
          if (storeGroupData.sgh_GroupCode == dataContext.sgd_GroupCode)
          {
            bool flag = true;
            foreach (UbModelBase ltDetail in (IEnumerable<StoreGroupDetailView>) storeGroupData.Lt_Details)
            {
              if (!ltDetail.RowCheckStatus.IsChecked)
              {
                flag = false;
                break;
              }
            }
            storeGroupData.RowCheckStatus.IsChecked = flag;
            break;
          }
        }
      }
    }

    public class InitParam : ParamBase<StoreCommonBoardVM.InitParam>
    {
      private bool? use = new bool?(true);
      private int _TabIndex;
      private bool _IsTreeChildrenBind = true;

      public bool? Use
      {
        get => this.use;
        set
        {
          this.use = value;
          this.NotifyOfPropertyChange(nameof (Use));
          this.NotifyOfPropertyChange("UseYn");
        }
      }

      public string UseYn
      {
        get
        {
          bool? use = this.Use;
          bool flag = true;
          if (use.GetValueOrDefault() == flag & use.HasValue)
            return "Y";
          return this.Use.HasValue ? "N" : (string) null;
        }
      }

      public int TabIndex
      {
        get => this._TabIndex;
        set
        {
          this._TabIndex = value;
          this.NotifyOfPropertyChange(nameof (TabIndex));
        }
      }

      public bool IsTreeChildrenBind
      {
        get => this._IsTreeChildrenBind;
        set
        {
          this._IsTreeChildrenBind = value;
          this.NotifyOfPropertyChange(nameof (IsTreeChildrenBind));
        }
      }
    }

    public class SearchParam : ParamBase<StoreCommonBoardVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private bool isMemberMntStore;
      private string keyword = string.Empty;
      private bool _IsTreeChildrenBind = true;

      public bool? Use
      {
        get => this.use;
        set
        {
          this.use = value;
          this.NotifyOfPropertyChange(nameof (Use));
          this.NotifyOfPropertyChange("UseYn");
        }
      }

      public string UseYn
      {
        get
        {
          bool? use = this.Use;
          bool flag = true;
          if (use.GetValueOrDefault() == flag & use.HasValue)
            return "Y";
          return this.Use.HasValue ? "N" : (string) null;
        }
      }

      public bool IsMemberMntStore
      {
        get => this.isMemberMntStore;
        set
        {
          this.isMemberMntStore = value;
          this.NotifyOfPropertyChange(nameof (IsMemberMntStore));
        }
      }

      public string Keyword
      {
        get => this.keyword;
        set
        {
          this.keyword = value;
          this.NotifyOfPropertyChange(nameof (Keyword));
        }
      }

      public bool IsTreeChildrenBind
      {
        get => this._IsTreeChildrenBind;
        set
        {
          this._IsTreeChildrenBind = value;
          this.NotifyOfPropertyChange(nameof (IsTreeChildrenBind));
        }
      }
    }
  }
}
