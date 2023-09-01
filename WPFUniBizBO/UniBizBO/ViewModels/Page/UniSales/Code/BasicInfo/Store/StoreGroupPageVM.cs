// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Store.StoreGroupPageVM
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
using System.Windows.Controls;
using System.Windows.Threading;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Store;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;
using UniBizBO.ViewModels.Part.Containers.Code.Store;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Store
{
  public class StoreGroupPageVM : PageBase<
  #nullable disable
  StoreGroupHeaderView>, ISystemPage
  {
    private StoreGroupPageVM.InitParam _InitControlParam = new StoreGroupPageVM.InitParam();
    private StoreGroupPageVM.SearchParam param = new StoreGroupPageVM.SearchParam();
    private StoreGroupDepth _StoreGroupDatas;

    [ManagedStatus]
    public StoreGroupPageVM.InitParam InitControlParam
    {
      get => this._InitControlParam;
      set
      {
        this._InitControlParam = value;
        this.NotifyOfPropertyChange(nameof (InitControlParam));
      }
    }

    public IReadOnlyDictionary<string, bool?> Items { get; } = (IReadOnlyDictionary<string, bool?>) new Dictionary<string, bool?>()
    {
      ["전체"] = new bool?(),
      ["사용"] = new bool?(true),
      ["미사용"] = new bool?(false)
    };

    public StoreGroupPageVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
      }
    }

    public StoreGroupPageVM.SearchParam ParamBackup { get; set; } = new StoreGroupPageVM.SearchParam();

    public Dictionary<int, StoreInfoView> BeforeDatas { get; set; } = new Dictionary<int, StoreInfoView>();

    public StoreGroupDepth StoreGroupDatas
    {
      get => this._StoreGroupDatas;
      set
      {
        this._StoreGroupDatas = value;
        this.NotifyOfPropertyChange(nameof (StoreGroupDatas));
      }
    }

    public IUniDataGridViewer GridViewer { get; set; }

    public StoreGroupPageVM(IContainer container)
      : base(container)
    {
    }

    public override async void OnQueryDefaultFunc(DefaultPageFunc funcType)
    {
      StoreGroupPageVM storeGroupPageVm = this;
      // ISSUE: reference to a compiler-generated method
      storeGroupPageVm.\u003C\u003En__0(funcType);
      if (funcType.Equals((object) DefaultPageFunc.BookMark))
        await storeGroupPageVm.RegBookMarkAsync();
      if (funcType.Equals((object) DefaultPageFunc.Search))
        await storeGroupPageVm.SearchAsync();
      if (funcType.Equals((object) DefaultPageFunc.Create))
        await storeGroupPageVm.CreateAsync();
      if (!funcType.Equals((object) DefaultPageFunc.Close))
        return;
      storeGroupPageVm.CloseItem();
    }

    public override bool OnQueryCanDefaultFunc(DefaultPageFunc funcType) => true;

    protected override void OnClose()
    {
      this.SetParam2InitControlParam();
      base.OnClose();
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      List<DefaultPageFunc> defaultPageFuncList = new List<DefaultPageFunc>()
      {
        DefaultPageFunc.Search
      };
      if (this.App.User.User.Source.IsStore)
        defaultPageFuncList.Add(DefaultPageFunc.Create);
      if (this.App.User.User.Source.IsPermitPrint)
        defaultPageFuncList.Add(DefaultPageFunc.Print);
      if (this.App.User.User.Source.IsPermitExcel)
        defaultPageFuncList.Add(DefaultPageFunc.ExportExcel);
      defaultPageFuncList.Add(DefaultPageFunc.Close);
      this.DefaultFuncs = (IEnumerable<DefaultPageFunc>) defaultPageFuncList.ToArray();
      this.InitControl();
    }

    protected void InitControl()
    {
      this.Param.StoreGroupType = this.App.Sys.CommonCodes[CommonCodeTypes.StoreGroupType].Items[0];
      this.InitControlParam.StoreGroupType = this.InitControlParam.StoreGroupType == null ? this.App.Sys.CommonCodes[CommonCodeTypes.StoreGroupType].Items[0] : this.InitControlParam.StoreGroupType;
      this.Param.Use = this.InitControlParam.Use;
      this.Param.StoreGroupType = this.InitControlParam.StoreGroupType;
    }

    public void SetParamBackup()
    {
      this.ParamBackup = ParamBase<StoreGroupPageVM.SearchParam>.Create((ParamBase) this.Param, (IDictionary<string, object>) null);
      this.SetParam2InitControlParam();
    }

    public void SetParam2InitControlParam()
    {
      this.InitControlParam.Use = this.Param.Use;
      this.InitControlParam.StoreGroupType = this.Param.StoreGroupType;
    }

    protected override void OnActivate()
    {
      base.OnActivate();
      if (this.View == null)
        return;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("Keyword")), (DispatcherPriority) 4);
    }

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      StoreGroupPageVM storeGroupPageVm = this;
      // ISSUE: reference to a compiler-generated method
      await storeGroupPageVm.\u003C\u003En__1(p_param);
      storeGroupPageVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async Task CreateAsync()
    {
      StoreGroupPageVM storeGroupPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (storeGroupPageVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 4)).ToList<PartMenuInfo>().Count == 0)
          return;
        // ISSUE: explicit non-virtual call
        PageStoreGroupPartConVM viewModel = __nonvirtual (storeGroupPageVm.Container).Get<PageStoreGroupPartConVM>();
        // ISSUE: explicit non-virtual call
        __nonvirtual (storeGroupPageVm.WindowManager).ShowDialog((object) viewModel);
        await Task.Yield();
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public async Task SearchAsync()
    {
      StoreGroupPageVM sender = this;
      try
      {
        UbRes<IList<StoreGroupHeaderView>> res;
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (sender.Job).CreateJob(__nonvirtual (sender.MenuInfo).Title + " 검색", (string) null))
        {
          if (sender.StoreGroupDatas != null)
            sender.StoreGroupDatas.Clear();
          string sendType1 = sender.LogInPackInfo.sendType;
          long siteId1 = sender.LogInPackInfo.siteID;
          string useYn = sender.Param.UseYn;
          string keyword1 = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code1 = __nonvirtual (sender.MenuInfo).Code;
          string sgh_UseYn = useYn;
          string KeyWord1 = keyword1;
          // ISSUE: explicit non-virtual call
          res = (await StoreRestServer.GetStoreGroupHeaderList(sendType1, siteId1, code1, 0, sgh_UseYn: sgh_UseYn, KeyWord: KeyWord1).ExecuteToReturnAsync<UbRes<IList<StoreGroupHeaderView>>>((UniBizHttpClient) __nonvirtual (sender.App).Api)).GetSuccess<UbRes<IList<StoreGroupHeaderView>>>();
          sender.Datas.Clear();
          sender.Datas.AddRange((IEnumerable<StoreGroupHeaderView>) res.response);
          string sendType2 = sender.LogInPackInfo.sendType;
          long siteId2 = sender.LogInPackInfo.siteID;
          string keyword2 = sender.Param.Keyword;
          // ISSUE: explicit non-virtual call
          int code2 = __nonvirtual (sender.MenuInfo).Code;
          string KeyWord2 = keyword2;
          // ISSUE: explicit non-virtual call
          UbRes<StoreGroupDepth> returnAsync = await StoreRestServer.GetStoreGroupDepth(sendType2, siteId2, code2, 0, sgh_GroupType: 1, KeyWord: KeyWord2).ExecuteToReturnAsync<UbRes<StoreGroupDepth>>((UniBizHttpClient) __nonvirtual (sender.App).Api);
          sender.StoreGroupDatas = returnAsync.GetData<StoreGroupDepth>();
          if (sender.Datas.Count >= 0)
          {
            sender.DisplaySearchCount = res.response.Count;
            // ISSUE: explicit non-virtual call
            IEventAggregator eventAggregator = __nonvirtual (sender.EventAggregator);
            OpenedPageMsg message = new OpenedPageMsg((IUbVM) sender);
            message.Page = (IPage) sender;
            message.DisplaySearchCount = sender.DisplaySearchCount;
            // ISSUE: explicit non-virtual call
            message.DisplayTitle = __nonvirtual (sender.MenuInfo).Name;
            string[] strArray = Array.Empty<string>();
            eventAggregator.PublishOnUIThread((object) message, strArray);
          }
          sender.SetParamBackup();
        }
        res = (UbRes<IList<StoreGroupHeaderView>>) null;
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
      }
    }

    public bool CanDataOpen(StoreGroupHeaderView item) => item != null;

    public void DataOpen(StoreGroupHeaderView item)
    {
      if (item == null || this.App.User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == item.TableCode)).ToList<PartMenuInfo>().Count == 0)
        return;
      PageStoreGroupPartConVM viewModel = this.Container.Get<PageStoreGroupPartConVM>();
      if (viewModel == null)
        return;
      viewModel.WorkDataKeys = (object[]) item._Key;
      viewModel.SavedAsync = (Func<PageStoreGroupPartConVM, Task>) (async con => await Task.Yield());
      this.WindowManager.ShowDialog((object) viewModel);
    }

    public WpfCommand<StoreGroupHeaderView> CmdDataOpen => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<StoreGroupHeaderView>>((Func<WpfCommand<StoreGroupHeaderView>>) (() => new WpfCommand<StoreGroupHeaderView>().AutoRefreshOn<WpfCommand<StoreGroupHeaderView>>().ApplyCanExecute<StoreGroupHeaderView>(new Func<StoreGroupHeaderView, bool>(this.CanDataOpen)).ApplyExecute<StoreGroupHeaderView>(new Action<StoreGroupHeaderView>(this.DataOpen))), nameof (CmdDataOpen));

    public void DepthBtnClick(object p_object)
    {
      if (!(p_object is ContentPresenter contentPresenter) || !(contentPresenter.DataContext is StoreGroupHeaderView dataContext))
        return;
      this.DataOpen(dataContext);
    }

    public class InitParam : ParamBase<StoreGroupPageVM.InitParam>
    {
      private bool? use = new bool?(true);
      private CommonCodeView _StoreGroupType;

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

      public CommonCodeView StoreGroupType
      {
        get => this._StoreGroupType;
        set
        {
          this._StoreGroupType = value;
          this.NotifyOfPropertyChange(nameof (StoreGroupType));
        }
      }
    }

    public class SearchParam : ParamBase<StoreGroupPageVM.SearchParam>
    {
      private bool? use = new bool?(true);
      private CommonCodeView _StoreGroupType;
      private string keyword;

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

      public CommonCodeView StoreGroupType
      {
        get => this._StoreGroupType;
        set
        {
          this._StoreGroupType = value;
          this.NotifyOfPropertyChange(nameof (StoreGroupType));
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
    }
  }
}
